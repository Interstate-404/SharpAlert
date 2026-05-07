using NAudio.Wave;
using SharpAlert.ProgramWorker;
using SIPSorcery.Media;
using SIPSorcery.SIP;
using SIPSorcery.SIP.App;
using System;
using System.IO;
using System.Net;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlertPluginBase.AlertContents;

namespace SharpAlert.DataProcessing
{
    internal static class NewCallManager
    {
        private static bool Initialized = false;
        private static SIPRegistrationUserAgent sipper;
        private static SIPTransport transport;
        private static SIPUDPChannel udpChannel;
        //private static SIPUserAgent userAgent;

        public static void InitCallManager()
        {
            if (Initialized) return;
            Initialized = true;

            transport = new();
            udpChannel = new SIPUDPChannel(new IPEndPoint(IPAddress.Any, 0));
            transport.AddSIPChannel(udpChannel);
            SIPURI uri = SIPURI.ParseSIPURI("sip:redacted@192.168.1.186");
            sipper = new(transport, null, uri, "authUsername redacted", "password redacted", null, "192.168.1.186", uri, 3600, null, 60, 300, 3, true)
            {
                //UserDisplayName = "SharpAlert",
            };
            sipper.Start();
            Console.WriteLine("STARTED SIP CLIENT ----------------");
            sipper.RegistrationFailed += (uri, response, err) =>
            {
                Console.WriteLine("ERROR ----------------");
                Console.WriteLine($"{uri}: Registration failed ({err}): {response.Status} {response.StatusCode} {response.ReasonPhrase}");
                throw new Exception($"{uri}: Registration failed ({err}): {response.Status} {response.StatusCode} {response.ReasonPhrase}");
            };
            sipper.RegistrationTemporaryFailure += (uri, response, err) =>
            {
                Console.WriteLine("ERROR ----------------");
                Console.WriteLine($"{uri}: Registration temporary fail: {response.Status} {response.StatusCode} {response.ReasonPhrase}");
                throw new Exception($"{uri}: Registration temporary fail: {response.Status} {response.StatusCode} {response.ReasonPhrase}");
            };
            sipper.RegistrationRemoved += (uri, response) =>
            {
                Console.WriteLine("ERROR ----------------");
                Console.WriteLine($"{uri}: Registration removed: {response.Status} {response.StatusCode} {response.ReasonPhrase}");
                throw new Exception($"{uri}: Registration removed: {response.Status} {response.StatusCode} {response.ReasonPhrase}");
            };
            sipper.RegistrationSuccessful += (uri, response) => Console.WriteLine($"---------- {uri.ToString()} registration succeeded.");
        }

        public static void MakeAlertCall(AlertInfo info)
        {
            try
            {
                //string callTo = QuickSettings.Instance.PhoneIP;
                //if (string.IsNullOrWhiteSpace(callTo)) return;

                Notify.ShowNotification("Placing call now.",
                    "Alert Call",
                    ToolTipIcon.Info);

                //var winAudioEndPoint = new WindowsAudioEndPoint(new AudioEncoder());
                //winAudioEndPoint.ToMediaEndPoints()

                using var voipMediaSession = new VoIPMediaSession();
                //voipMediaSession 12
                var callDescriptor = new SIPCallDescriptor(
                    username: "18618",
                    password: "password redacted",
                    uri: "sip:18612@192.168.1.186",
                    from: "sip:18618@192.168.1.186",
                    to: "sip:18612@192.168.1.186",
                    routeSet: null,
                    customHeaders: null,
                    authUsername: "authUsername redacted",
                    callDirection: SIPCallDirection.Out,
                    contentType: null,
                    content: null,
                    mangleIPAddress: null
                );

                using var userAgent = new SIPUserAgent(transport, null);

                userAgent.ClientCallTrying += (uac, resp) =>
                {
                    Console.WriteLine($"------ TRYING: {resp.StatusCode}");
                };
                userAgent.ClientCallRinging += (uac, resp) =>
                {
                    Console.WriteLine($"------ RINGING: {resp.StatusCode}");
                };
                userAgent.ClientCallFailed += (uac, err, resp) =>
                {
                    Console.WriteLine($"------ CALL FAILED: {err}");

                    if (resp != null)
                    {
                        Console.WriteLine(resp.ToString());
                    }
                };
                userAgent.OnCallHungup += (dialog) =>
                {
                    Console.WriteLine("------ CALL ENDED.");
                };
                userAgent.ClientCallAnswered += (uac, resp) =>
                {
                    Console.WriteLine($"------ CALL ANSWERED: {resp.StatusCode}");
                    Console.WriteLine($"Media session attached: {voipMediaSession != null}");
                };

                voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);
                bool callResult = userAgent.Call(callDescriptor, voipMediaSession, 12).Result;

                if (callResult)
                {
                    Notify.ShowNotification("Call answered by phone.",
                        "Alert Call",
                        ToolTipIcon.Info);

                    static MemoryStream SpeakToMe(string speak)
                    {
                        SpeechSynthesizer ss = new();
                        using MemoryStream ms = new();

                        ss.SetOutputToWaveStream(ms);
                        ss.Speak(speak);
                        ms.Position = 0;

                        using WaveFileReader reader = new(ms);
                        var outFormat = new WaveFormat(16000, reader.WaveFormat.BitsPerSample, reader.WaveFormat.Channels);
                        using var resampler = new MediaFoundationResampler(reader, outFormat)
                        {
                            ResamplerQuality = 60
                        };

                        var rs = new MemoryStream();
                        WaveFileWriter.WriteWavFileToStream(rs, resampler);
                        rs.Position = 0;

                        ss.Dispose();

                        return rs;
                    }

                    object WaitObject = new();

                    userAgent.OnDtmfTone += (a, b) =>
                    {
                        switch (a)
                        {
                            case 1:
                                lock (WaitObject)
                                {
                                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.SineWave);
                                    Thread.Sleep(500);
                                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);
                                    voipMediaSession.AudioExtrasSource.SendAudioFromStream(
                                        SpeakToMe(info.AlertBodyText),
                                        SIPSorceryMedia.Abstractions.AudioSamplingRatesEnum.Rate16KHz
                                    ).Wait();
                                }
                                break;
                        }

                        userAgent.Hangup();
                    };

                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);
                    voipMediaSession.AudioExtrasSource.SendAudioFromStream(
                        SpeakToMe($"EMERGENCY ALERT. {info.AlertEventType}. Press 1 to hear the alert text. Hang up or do nothing to ignore."),
                        SIPSorceryMedia.Abstractions.AudioSamplingRatesEnum.Rate16KHz
                    ).Wait();


                    Thread.Sleep(5000);
                    lock (WaitObject)
                    {
                        Thread.Sleep(500);
                        userAgent.Hangup();
                    }

                    Notify.ShowNotification("Call ended.",
                        "Alert Call",
                        ToolTipIcon.Info);
                }
                else
                {
                    Notify.ShowNotification("Call rejected or failed.",
                        "Alert Call",
                        ToolTipIcon.Info);
                }

                //userAgent.Close();
                //sipTransport.Shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Notify.ShowNotification($"Call error. {ex.Message}",
                    "Alert Call",
                    ToolTipIcon.Info);
            }
        }
    }
}
