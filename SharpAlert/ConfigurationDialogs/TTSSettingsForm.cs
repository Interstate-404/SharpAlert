using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class TTSSettingsForm : Form
    {
        private bool _suppressVoiceEvent;
        private string _lastDiagnostic = "";

        public TTSSettingsForm()
        {
            InitializeComponent();
        }

        private void TTSSettingsForm_Load(object sender, EventArgs e)
        {
            PopulateVoiceCombo();

            RateBar.Value = Clamp(QuickSettings.Instance.VoiceRate, -10, 10);
            PitchBar.Value = Clamp(QuickSettings.Instance.VoicePitch, -10, 10);
            VolumeBar.Value = Clamp(QuickSettings.Instance.alertVolume, 0, 10);

            UpdateValueLabels();
        }

        private void TTSSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure no preview leaks past form close.
            SapiInterop.PreviewInProgress = false;
            SapiInterop.CancelLiveSynthesis(force: true);
        }

        private void PopulateVoiceCombo()
        {
            _suppressVoiceEvent = true;
            try
            {
                VoiceCombo.Items.Clear();
                VoiceCombo.Items.Add("(System Default)");

                foreach (var voice in SapiInterop.GetAllVoices())
                {
                    VoiceCombo.Items.Add(voice.Name);
                }

                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.ProgramVoice))
                {
                    var found = SapiInterop.FindVoice(QuickSettings.Instance.ProgramVoice);
                    if (found != null)
                    {
                        int idx = VoiceCombo.Items.IndexOf(found.Name);
                        VoiceCombo.SelectedIndex = idx >= 0 ? idx : 0;
                    }
                    else
                    {
                        VoiceCombo.SelectedIndex = 0;
                    }
                }
                else
                {
                    VoiceCombo.SelectedIndex = 0;
                }
            }
            finally
            {
                _suppressVoiceEvent = false;
            }
        }

        private void UpdateValueLabels()
        {
            RateValueLabel.Text = FormatSigned(RateBar.Value);
            PitchValueLabel.Text = FormatSigned(PitchBar.Value);
            VolumeValueLabel.Text = VolumeBar.Value.ToString();
        }

        private static string FormatSigned(int v) => v > 0 ? $"+{v}" : v.ToString();

        private static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);

        private void VoiceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressVoiceEvent) return;

            if (VoiceCombo.SelectedIndex <= 0)
            {
                QuickSettings.Instance.ProgramVoice = string.Empty;
                return;
            }

            string selectedName = VoiceCombo.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedName)) return;

            var voice = SapiInterop.FindVoice(selectedName);
            if (voice != null)
            {
                QuickSettings.Instance.ProgramVoice = voice.TokenId;
            }
        }

        private void VoiceClearLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VoiceCombo.SelectedIndex = 0;
        }

        private void RefreshVoicesButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                SapiInterop.GetAllVoices(refresh: true);
                PopulateVoiceCombo();
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void RateBar_Scroll(object sender, EventArgs e)
        {
            QuickSettings.Instance.VoiceRate = RateBar.Value;
            UpdateValueLabels();
        }

        private void PitchBar_Scroll(object sender, EventArgs e)
        {
            QuickSettings.Instance.VoicePitch = PitchBar.Value;
            UpdateValueLabels();
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            QuickSettings.Instance.alertVolume = VolumeBar.Value;
            UpdateValueLabels();
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            string text = string.IsNullOrWhiteSpace(PreviewText.Text)
                ? "This is a test of the SharpAlert text to speech system."
                : PreviewText.Text;

            var voice = string.IsNullOrWhiteSpace(QuickSettings.Instance.ProgramVoice)
                ? null
                : SapiInterop.FindVoice(QuickSettings.Instance.ProgramVoice);
            string tokenId = voice?.TokenId;
            string voiceLabel = voice?.Name ?? "system default";

            int rate = RateBar.Value;
            int pitch = PitchBar.Value;
            int volume = VolumeBar.Value * 10;

            PreviewButton.Enabled = false;
            SetStatus($"Speaking ({voiceLabel}, vol={volume}, rate={rate}, pitch={pitch})...",
                System.Drawing.Color.LightSkyBlue);

            Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                Exception failure = null;
                SapiInterop.PreviewInProgress = true;
                try
                {
                    SapiInterop.SynthesizeLive(text, tokenId, volume, rate, pitch);
                }
                catch (Exception ex)
                {
                    failure = ex;
                    Console.WriteLine($"[TTS Settings] Preview failed: {ex}");
                }
                finally
                {
                    SapiInterop.PreviewInProgress = false;
                }
                sw.Stop();

                string diag = SapiInterop.LastLiveDiagnostic;

                BeginInvoke(new Action(() =>
                {
                    if (failure != null)
                    {
                        SetStatus($"Preview failed: {failure.Message}", System.Drawing.Color.IndianRed);
                        if (!string.IsNullOrWhiteSpace(diag))
                        {
                            MessageBox.Show(diag,
                                "TTS Preview - Diagnostic trace",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        SetStatus($"Done (synthesis took {sw.ElapsedMilliseconds} ms).", System.Drawing.Color.Silver);
                    }
                    PreviewButton.Enabled = true;
                    _lastDiagnostic = diag;
                }));
            });
        }

        private void SetStatus(string text, System.Drawing.Color color)
        {
            StatusLabel.ForeColor = color;
            StatusLabel.Text = text;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lastDiagnostic)) return;
            MessageBox.Show(_lastDiagnostic,
                "TTS Preview - Diagnostic trace",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SapiInterop.PreviewInProgress = false;
            SapiInterop.CancelLiveSynthesis(force: true);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            RateBar.Value = 0;
            PitchBar.Value = 0;
            VolumeBar.Value = 8;
            QuickSettings.Instance.VoiceRate = 0;
            QuickSettings.Instance.VoicePitch = 0;
            QuickSettings.Instance.alertVolume = 8;
            UpdateValueLabels();
        }

        private void WindowsSpeechButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\Windows\\system32\\rundll32.exe",
                    "shell32.dll,Control_RunDLL C:\\Windows\\system32\\speech\\speechux\\sapi.cpl");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't open the Windows Speech Properties dialog.\n{ex.Message}",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
