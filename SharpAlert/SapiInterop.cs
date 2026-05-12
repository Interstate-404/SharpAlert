using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpAlert
{
    /// <summary>
    /// Represents a SAPI 5 voice discovered from the registry.
    /// </summary>
    public class SapiVoiceInfo
    {
        public string Name { get; init; }
        public string TokenId { get; init; }

        public override string ToString() => Name;
    }

    /// <summary>
    /// Direct SAPI 5 COM interop for voice enumeration and synthesis.
    /// Unlike System.Speech.Synthesis.SpeechSynthesizer, this can access voices registered
    /// in all registry hives (64-bit, WOW6432Node, and Speech_OneCore).
    /// </summary>
    public static class SapiInterop
    {
        private static readonly string[] VoiceRegistryPaths =
        [
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech\Voices",
            @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Speech\Voices",
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices",
        ];

        private static List<SapiVoiceInfo> _cachedVoices;

        /// <summary>
        /// Enumerates all SAPI 5 voices across the standard, WOW6432Node, and OneCore registry hives.
        /// Results are cached; pass refresh=true to re-scan.
        /// </summary>
        public static List<SapiVoiceInfo> GetAllVoices(bool refresh = false)
        {
            if (_cachedVoices != null && !refresh)
                return _cachedVoices;

            var voices = new List<SapiVoiceInfo>();
            var seenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var registryPath in VoiceRegistryPaths)
            {
                try
                {
                    Type categoryType = Type.GetTypeFromProgID("SAPI.SpObjectTokenCategory");
                    if (categoryType == null) continue;

                    dynamic category = Activator.CreateInstance(categoryType);
                    category.SetId(registryPath, false);
                    dynamic tokens = category.EnumerateTokens();

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        dynamic token = tokens.Item(i);
                        try
                        {
                            string id = token.Id;
                            string name = token.GetDescription();

                            if (seenNames.Add(name))
                            {
                                voices.Add(new SapiVoiceInfo
                                {
                                    Name = name,
                                    TokenId = id
                                });
                                Console.WriteLine($"[SAPI Interop] Found voice: {name}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[SAPI Interop] Error reading voice token: {ex.Message}");
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(token);
                        }
                    }

                    Marshal.ReleaseComObject(tokens);
                    Marshal.ReleaseComObject(category);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SAPI Interop] Could not enumerate {registryPath}: {ex.Message}");
                }
            }

            _cachedVoices = voices;
            Console.WriteLine($"[SAPI Interop] Total voices found: {voices.Count}");
            return voices;
        }

        /// <summary>
        /// Finds a voice by token ID (exact), display name (exact), or partial name match.
        /// </summary>
        public static SapiVoiceInfo FindVoice(string nameOrId)
        {
            if (string.IsNullOrWhiteSpace(nameOrId)) return null;

            var voices = GetAllVoices();

            // Exact token ID match
            var match = voices.Find(v =>
                string.Equals(v.TokenId, nameOrId, StringComparison.OrdinalIgnoreCase));
            if (match != null) return match;

            // Exact name match
            match = voices.Find(v =>
                string.Equals(v.Name, nameOrId, StringComparison.OrdinalIgnoreCase));
            if (match != null) return match;

            // Partial name match
            return voices.Find(v =>
                v.Name.Contains(nameOrId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Re-enumerates voice tokens from all registry hives to find a live COM token
        /// matching the given token ID. Unlike SpObjectToken.SetId(), this works across
        /// registry hives (WOW6432Node, OneCore) from a 64-bit process.
        /// The caller is responsible for releasing the returned COM object.
        /// </summary>
        private static dynamic FindLiveVoiceToken(string tokenId)
        {
            foreach (var registryPath in VoiceRegistryPaths)
            {
                try
                {
                    Type categoryType = Type.GetTypeFromProgID("SAPI.SpObjectTokenCategory");
                    if (categoryType == null) continue;

                    dynamic category = Activator.CreateInstance(categoryType);
                    category.SetId(registryPath, false);
                    dynamic tokens = category.EnumerateTokens();

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        dynamic token = tokens.Item(i);
                        try
                        {
                            string id = token.Id;
                            if (string.Equals(id, tokenId, StringComparison.OrdinalIgnoreCase))
                            {
                                // Found it — release the collection but keep the token alive
                                Marshal.ReleaseComObject(tokens);
                                Marshal.ReleaseComObject(category);
                                Console.WriteLine($"[SAPI Interop] Resolved live token for: {tokenId}");
                                return token;
                            }
                        }
                        catch { /* skip unreadable token */ }

                        Marshal.ReleaseComObject(token);
                    }

                    Marshal.ReleaseComObject(tokens);
                    Marshal.ReleaseComObject(category);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SAPI Interop] Error searching {registryPath}: {ex.Message}");
                }
            }

            Console.WriteLine($"[SAPI Interop] Could not find live token for: {tokenId}");
            return null;
        }

        /// <summary>
        /// Synthesizes text to a WAV MemoryStream.
        /// Tries in-process SAPI COM first (fast, works for 64-bit voices).
        /// Falls back to a 32-bit PowerShell bridge for 32-bit-only voice engines.
        /// rate and pitch use SAPI's -10..+10 scale; 0 is default.
        /// </summary>
        public static MemoryStream SynthesizeToStream(string text, string voiceTokenId = null, int rate = 0, int pitch = 0)
        {
            try
            {
                return SynthesizeInProcess(text, voiceTokenId, rate, pitch);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SAPI Interop] In-process synthesis failed: {ex.Message}");
            }

            // Fall back to 32-bit bridge for voices whose engine DLLs are 32-bit only
            string voiceName = null;
            if (!string.IsNullOrWhiteSpace(voiceTokenId))
            {
                voiceName = FindVoice(voiceTokenId)?.Name;
            }

            Console.WriteLine($"[SAPI Interop] Falling back to 32-bit bridge for voice: {voiceName ?? "(default)"}");
            return SynthesizeVia32BitBridge(text, voiceName, rate, pitch);
        }

        /// <summary>
        /// XML-escapes text and prepends a SAPI <pitch absmiddle='N'/> tag if pitch != 0.
        /// Pass alongside the SVSFIsXML flag (8) to SpVoice.Speak.
        /// </summary>
        private static string BuildSapiXml(string text, int pitch)
        {
            string escaped = (text ?? "")
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;");
            if (pitch == 0) return escaped;
            int clamped = Math.Clamp(pitch, -10, 10);
            return $"<pitch absmiddle=\"{clamped}\"/>{escaped}";
        }

        /// <summary>
        /// Builds an SSML document for System.Speech (.NET) consumption.
        /// Pitch is mapped 1 unit per semitone.
        /// </summary>
        private static string BuildSsml(string text, int pitch)
        {
            string escaped = (text ?? "")
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;");
            int clamped = Math.Clamp(pitch, -10, 10);
            string sign = clamped >= 0 ? "+" : "";
            string body = clamped == 0
                ? escaped
                : $"<prosody pitch=\"{sign}{clamped}st\">{escaped}</prosody>";
            return "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">" +
                   body + "</speak>";
        }

        /// <summary>
        /// In-process synthesis using 64-bit SAPI COM. Fast but only works for
        /// voices whose engine DLLs are 64-bit compatible.
        /// </summary>
        private static MemoryStream SynthesizeInProcess(string text, string voiceTokenId, int rate = 0, int pitch = 0)
        {
            Type spVoiceType = Type.GetTypeFromProgID("SAPI.SpVoice")
                ?? throw new InvalidOperationException("SAPI.SpVoice COM class not available on this system.");

            dynamic spVoice = Activator.CreateInstance(spVoiceType);
            dynamic voiceToken = null;
            string tempFile = Path.Combine(Path.GetTempPath(), $"sa_tts_{Guid.NewGuid():N}.wav");

            try
            {
                if (!string.IsNullOrWhiteSpace(voiceTokenId))
                {
                    voiceToken = FindLiveVoiceToken(voiceTokenId);
                    if (voiceToken != null)
                    {
                        spVoice.Voice = voiceToken;
                        Console.WriteLine($"[SAPI Interop] Voice set successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"[SAPI Interop] Voice '{voiceTokenId}' not found, using system default.");
                    }
                }

                spVoice.Rate = Math.Clamp(rate, -10, 10);

                Type fileStreamType = Type.GetTypeFromProgID("SAPI.SpFileStream");
                dynamic spFileStream = Activator.CreateInstance(fileStreamType);

                // SSFMCreateForWrite = 3
                spFileStream.Open(tempFile, 3);
                spVoice.AudioOutputStream = spFileStream;

                // SVSFIsXML = 8, SVSFDefault = 0
                string payload = BuildSapiXml(text, pitch);
                int flags = pitch != 0 ? 8 : 0;
                spVoice.Speak(payload, flags);

                spFileStream.Close();
                Marshal.ReleaseComObject(spFileStream);

                byte[] wavData = File.ReadAllBytes(tempFile);
                return new MemoryStream(wavData);
            }
            finally
            {
                if (voiceToken != null) Marshal.ReleaseComObject(voiceToken);
                Marshal.ReleaseComObject(spVoice);
                try { File.Delete(tempFile); } catch { }
            }
        }

        private static volatile bool _cancelLive;
        private static Process _liveBridgeProcess;
        private static readonly object _liveSynthLock = new();

        /// <summary>
        /// While true, "soft" CancelLiveSynthesis() calls become no-ops. Used by the
        /// TTS preview window so the AlertDisplayer audio-cleanup loop doesn't kill
        /// previews while no alert is active. Cancellation forced by a new
        /// SynthesizeLive call or an explicit user Stop still goes through.
        /// </summary>
        public static volatile bool PreviewInProgress = false;

        /// <summary>
        /// Captures the trace of the most recent live synthesis call (path taken,
        /// voice resolution, timing). The UI surfaces this for diagnosis when audio
        /// doesn't come out as expected.
        /// </summary>
        public static string LastLiveDiagnostic { get; private set; } = "";
        private static readonly System.Text.StringBuilder _diag = new();

        private static void Diag(string line)
        {
            Console.WriteLine(line);
            lock (_diag) { _diag.AppendLine(line); }
        }

        private static void ResetDiag()
        {
            lock (_diag) { _diag.Clear(); }
        }

        private static void FlushDiag()
        {
            lock (_diag) { LastLiveDiagnostic = _diag.ToString(); }
        }

        /// <summary>
        /// Plays TTS live through SAPI's audio output (streaming, no WAV buffering).
        /// Audio starts immediately as the engine generates it.
        /// Tries in-process first, falls back to 32-bit bridge.
        /// Only one live synthesis runs at a time; new calls cancel any in-progress speech.
        /// </summary>
        public static void SynthesizeLive(string text, string voiceTokenId = null, int volume = 100, int rate = 0, int pitch = 0)
        {
            // Force-cancel any prior live synthesis (including previews) before taking
            // the channel for this new request.
            CancelLiveSynthesis(force: true);

            lock (_liveSynthLock)
            {
                ResetDiag();
                _cancelLive = false;

                try
                {
                    SynthesizeLiveInProcess(text, voiceTokenId, volume, rate, pitch);
                    FlushDiag();
                    return;
                }
                catch (Exception ex)
                {
                    Diag($"[SAPI Interop] In-process live synthesis failed: {ex.Message}");
                }

                string voiceName = !string.IsNullOrWhiteSpace(voiceTokenId)
                    ? FindVoice(voiceTokenId)?.Name : null;

                Diag($"[SAPI Interop] Falling back to 32-bit live bridge for voice: {voiceName ?? "(default)"}");
                try
                {
                    SynthesizeLiveVia32BitBridge(text, voiceName, volume, rate, pitch);
                }
                finally
                {
                    FlushDiag();
                }
            }
        }

        /// <summary>
        /// Cancels any in-progress live synthesis (in-process or 32-bit bridge).
        /// Background cleanup callers (e.g., the AlertDisplayer audio-loop) should use
        /// force=false so previews aren't killed when no alert is active. Real alert
        /// TTS and explicit user-stop should pass force=true.
        /// </summary>
        public static void CancelLiveSynthesis(bool force = false)
        {
            if (!force && PreviewInProgress) return;

            _cancelLive = true;

            try
            {
                var p = _liveBridgeProcess;
                if (p != null && !p.HasExited)
                {
                    p.Kill();
                    _liveBridgeProcess = null;
                    Console.WriteLine("[SAPI Interop] Killed 32-bit bridge process.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SAPI Interop] Error cancelling bridge: {ex.Message}");
            }
        }

        /// <summary>
        /// Live in-process synthesis: SAPI plays directly through its default audio output.
        /// Uses async mode for cancellation support.
        /// </summary>
        private static void SynthesizeLiveInProcess(string text, string voiceTokenId, int volume, int rate = 0, int pitch = 0)
        {
            Type spVoiceType = Type.GetTypeFromProgID("SAPI.SpVoice")
                ?? throw new InvalidOperationException("SAPI.SpVoice COM class not available.");

            dynamic spVoice = Activator.CreateInstance(spVoiceType);
            dynamic voiceToken = null;

            try
            {
                // Resolve a voice token. If caller didn't specify one, fall back to the
                // first voice we can enumerate — relying on SpVoice's default voice often
                // produces silence when the registered default lives in a hive this
                // 64-bit process can't load (e.g., WOW6432Node-only voices).
                string resolvedTokenId = voiceTokenId;
                string resolvedSource = "caller";

                if (string.IsNullOrWhiteSpace(resolvedTokenId))
                {
                    var voices = GetAllVoices();
                    if (voices.Count > 0)
                    {
                        resolvedTokenId = voices[0].TokenId;
                        resolvedSource = $"auto-picked '{voices[0].Name}'";
                    }
                }

                if (!string.IsNullOrWhiteSpace(resolvedTokenId))
                {
                    voiceToken = FindLiveVoiceToken(resolvedTokenId);
                    if (voiceToken != null)
                    {
                        spVoice.Voice = voiceToken;
                        Diag($"[SAPI Interop] In-process voice set from {resolvedSource}.");
                    }
                    else
                    {
                        Diag($"[SAPI Interop] Could not resolve live token '{resolvedTokenId}' ({resolvedSource}) — letting SpVoice fall back to its default.");
                    }
                }
                else
                {
                    Diag("[SAPI Interop] No SAPI voices enumerated; relying on SpVoice default.");
                }

                spVoice.Volume = Math.Clamp(volume, 0, 100);
                spVoice.Rate = Math.Clamp(rate, -10, 10);

                // SVSFlagsAsync = 1, SVSFIsXML = 8 — async so we can cancel; XML for pitch tag
                string payload = BuildSapiXml(text, pitch);
                int flags = pitch != 0 ? (1 | 8) : 1;

                ulong streamNum;
                try
                {
                    streamNum = (ulong)Convert.ToInt64(spVoice.Speak(payload, flags));
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"In-process SpVoice.Speak threw: {ex.Message}", ex);
                }

                Diag($"[SAPI Interop] In-process Speak queued stream #{streamNum}.");

                // Poll for completion or cancellation
                var sw = Stopwatch.StartNew();
                bool everPolled = false;
                while (true)
                {
                    bool done = spVoice.WaitUntilDone(100);
                    if (done) break;
                    everPolled = true;

                    if (_cancelLive)
                    {
                        // SVSFPurgeBeforeSpeak = 2 — cancel all pending/current speech
                        spVoice.Speak("", 2);
                        spVoice.WaitUntilDone(1000);
                        Diag("[SAPI Interop] Live synthesis cancelled.");
                        break;
                    }
                }
                sw.Stop();
                Diag($"[SAPI Interop] In-process Speak completed in {sw.ElapsedMilliseconds} ms (polled={everPolled}).");

                // Heuristic: if Speak claims to be done before WaitUntilDone ever blocked,
                // and we had non-trivial text, audio almost certainly didn't actually play.
                // Throw so the outer SynthesizeLive falls back to the 32-bit bridge.
                int minExpectedMs = Math.Min(800, Math.Max(120, (text ?? "").Length * 30));
                if (!everPolled && sw.ElapsedMilliseconds < minExpectedMs && !string.IsNullOrWhiteSpace(text))
                {
                    throw new InvalidOperationException(
                        $"In-process SAPI returned in {sw.ElapsedMilliseconds} ms without queueing audible speech (expected >= {minExpectedMs} ms for {(text ?? "").Length}-char text).");
                }
            }
            finally
            {
                if (voiceToken != null) Marshal.ReleaseComObject(voiceToken);
                Marshal.ReleaseComObject(spVoice);
            }
        }

        /// <summary>
        /// Live synthesis via 32-bit PowerShell bridge: the 32-bit process plays audio
        /// directly through the default audio device as it synthesizes.
        /// </summary>
        private static void SynthesizeLiveVia32BitBridge(string text, string voiceName, int volume, int rate = 0, int pitch = 0)
        {
            if (!File.Exists(PowerShell32Path))
                throw new FileNotFoundException("32-bit PowerShell not found.", PowerShell32Path);

            bool useSsml = pitch != 0;
            string payload = useSsml ? BuildSsml(text, pitch) : text;

            string tempTxt = Path.Combine(Path.GetTempPath(), $"sa_tts_{Guid.NewGuid():N}.txt");

            try
            {
                File.WriteAllText(tempTxt, payload, Encoding.UTF8);

                string voiceSelection = string.IsNullOrWhiteSpace(voiceName)
                    ? ""
                    : $"$synth.SelectVoice('{voiceName.Replace("'", "''")}');";

                string speakCall = useSsml ? "$synth.SpeakSsml($text);" : "$synth.Speak($text);";

                string script = $@"
Add-Type -AssemblyName System.Speech;
$synth = New-Object System.Speech.Synthesis.SpeechSynthesizer;
{voiceSelection}
$synth.Volume = {Math.Clamp(volume, 0, 100)};
$synth.Rate = {Math.Clamp(rate, -10, 10)};
$text = [System.IO.File]::ReadAllText('{tempTxt.Replace("'", "''")}', [System.Text.Encoding]::UTF8);
$synth.SetOutputToDefaultAudioDevice();
{speakCall}
$synth.Dispose();
";

                string encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));

                var psi = new ProcessStartInfo
                {
                    FileName = PowerShell32Path,
                    Arguments = $"-NoProfile -NonInteractive -EncodedCommand {encoded}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                _liveBridgeProcess = process;
                process.WaitForExit();
                _liveBridgeProcess = null;

                Console.WriteLine("[SAPI Interop] 32-bit live bridge completed.");
            }
            finally
            {
                try { File.Delete(tempTxt); } catch { }
            }
        }

        private static readonly string PowerShell32Path =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                @"SysWOW64\WindowsPowerShell\v1.0\powershell.exe");

        /// <summary>
        /// Synthesizes text by spawning 32-bit PowerShell, which can load 32-bit SAPI
        /// voice engine DLLs that a 64-bit process cannot. Slower due to process startup
        /// but works for any installed voice regardless of bitness.
        /// </summary>
        private static MemoryStream SynthesizeVia32BitBridge(string text, string voiceName, int rate = 0, int pitch = 0)
        {
            if (!File.Exists(PowerShell32Path))
                throw new FileNotFoundException("32-bit PowerShell not found. Cannot use 32-bit voice engines.", PowerShell32Path);

            string tempWav = Path.Combine(Path.GetTempPath(), $"sa_tts_{Guid.NewGuid():N}.wav");
            string tempTxt = Path.Combine(Path.GetTempPath(), $"sa_tts_{Guid.NewGuid():N}.txt");

            bool useSsml = pitch != 0;
            string payload = useSsml ? BuildSsml(text, pitch) : text;

            try
            {
                File.WriteAllText(tempTxt, payload, Encoding.UTF8);

                // Build a PowerShell script that loads System.Speech in the 32-bit CLR,
                // selects the voice by name, synthesizes to a WAV file.
                string voiceSelection = string.IsNullOrWhiteSpace(voiceName)
                    ? ""
                    : $"$synth.SelectVoice('{voiceName.Replace("'", "''")}');";

                string speakCall = useSsml ? "$synth.SpeakSsml($text);" : "$synth.Speak($text);";

                string script = $@"
Add-Type -AssemblyName System.Speech;
$synth = New-Object System.Speech.Synthesis.SpeechSynthesizer;
{voiceSelection}
$synth.Rate = {Math.Clamp(rate, -10, 10)};
$text = [System.IO.File]::ReadAllText('{tempTxt.Replace("'", "''")}', [System.Text.Encoding]::UTF8);
$synth.SetOutputToWaveFile('{tempWav.Replace("'", "''")}');
{speakCall}
$synth.Dispose();
";

                string encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));

                var psi = new ProcessStartInfo
                {
                    FileName = PowerShell32Path,
                    Arguments = $"-NoProfile -NonInteractive -EncodedCommand {encoded}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                };

                using var process = Process.Start(psi);
                string stderr = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0 || !File.Exists(tempWav))
                {
                    throw new Exception($"32-bit TTS bridge failed (exit {process.ExitCode}): {stderr}");
                }

                Console.WriteLine("[SAPI Interop] 32-bit bridge synthesis succeeded.");
                byte[] wavData = File.ReadAllBytes(tempWav);
                return new MemoryStream(wavData);
            }
            finally
            {
                try { File.Delete(tempWav); } catch { }
                try { File.Delete(tempTxt); } catch { }
            }
        }
    }
}
