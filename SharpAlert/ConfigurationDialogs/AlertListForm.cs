using NAudio.CoreAudioApi;
using SharpAlert.AlertComponents;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlertPluginBase.AlertContents;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class AlertListForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();

        public AlertListForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            RefreshAlertHistory();

            if (Initialized) return;
            Initialized = true;

            //lock (notify)
            //{
            //    notify.BalloonTipTitle = "SharpAlert is initializing Settings";
            //    notify.BalloonTipText = "Settings is getting ready to be shown. This may take a few moments.";
            //    notify.BalloonTipIcon = ToolTipIcon.Info;
            //    notify.ShowBalloonTip(5000);
            //}

            RefreshAlertHistory();
        }

        private void AlertHistoryClearButton_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Are you sure you want to destroy the alert history?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                ClearAlertHistory();
            }
        }

        private void RefreshAlertHistory()
        {
            lock (SharpDataHistory)
            {
                if (SharpDataHistory.Count != 0)
                {
                    string DataHistory = string.Empty;
                    
                    foreach (var item in SharpDataHistory)
                    {
                        DataHistory = $"{item.Name}\r\n{DataHistory}";
                    }

                    string plural = $"There is 1 alert in the history.";
                    if (SharpDataHistory.Count != 1) plural = $"There are {SharpDataHistory.Count} alerts in the history.";

                    AlertHistoryText.Text = plural;
                    AlertHistoryOutput.Text = DataHistory.Trim();
                }
                else
                {
                    AlertHistoryText.Text = "The alert history is empty right now.";
                    AlertHistoryOutput.Clear();
                }

                AlertHistoryRefreshButton.Visible = false;
                LastKnownHistoryCount = SharpDataHistory.Count;
            }
        }

        private void AlertHistoryRefreshButton_Click(object sender, EventArgs e)
        {
            //AlertHistoryRefreshButton.BackColor = Color.FromArgb(60, 60, 60);
            AlertListRefresher.Enabled = false;
            AlertHistoryRefreshButton.Visible = false;
            RefreshAlertHistory();
            AlertListRefresher.Enabled = true;
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            try
            {
                RefreshAlertHistory();
                if (SharpDataHistory.Count != 0)
                {
                    lock (SharpDataQueue)
                    {
                        lock (SharpDataHistory)
                        {
                            var alert = SharpDataHistory.Last();

                            SharpDataHistory.Remove(alert);

                            if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                            {
                                alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                            }
                            else
                            {
                                alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                            }

                            SharpDataQueue.Add(alert);

                            //AlertInfo alertInfo = dataproc.ap.ProcessAlertItem(alert, true, false);

                            //if (alertInfo == null)
                            //{
                            //    MessageBox.Show("The alert does not meet the requirements you've set, so it has not been relayed.",
                            //        "SharpAlert",
                            //        MessageBoxButtons.OK,
                            //        MessageBoxIcon.Exclamation);
                            //}
                            //else
                            //{
                            //    if (!string.IsNullOrWhiteSpace(alertInfo.AlertDiscardReason))
                            //    {
                            //        MessageBox.Show($"{alertInfo.AlertDiscardReason}",
                            //            "SharpAlert",
                            //            MessageBoxButtons.OK,
                            //            MessageBoxIcon.Exclamation);
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"There are no items in the history.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private void AlertHistoryReplayAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to process all alerts again?\r\nThis may take some time.", "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            try
            {
                RefreshAlertHistory();
                if (SharpDataHistory.Count != 0)
                {
                    lock (SharpDataQueue)
                    {
                        lock (SharpDataHistory)
                        {
                            List<SharpDataItem> DataItems = [.. SharpDataHistory];
                            SharpDataHistory.Clear();
                            SharpDataQueue.AddRange(DataItems);

                            //if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                            //{
                            //    alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                            //}
                            //else
                            //{
                            //    alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                            //}

                            //AlertInfo alertInfo = dataproc.ap.ProcessAlertItem(alert, true, false);

                            //if (alertInfo == null)
                            //{
                            //    MessageBox.Show("The alert does not meet the requirements you've set, so it has not been relayed.",
                            //        "SharpAlert",
                            //        MessageBoxButtons.OK,
                            //        MessageBoxIcon.Exclamation);
                            //}
                            //else
                            //{
                            //    if (!string.IsNullOrWhiteSpace(alertInfo.AlertDiscardReason))
                            //    {
                            //        MessageBox.Show($"{alertInfo.AlertDiscardReason}",
                            //            "SharpAlert",
                            //            MessageBoxButtons.OK,
                            //            MessageBoxIcon.Exclamation);
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"There are no items in the history.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }
        private void AlertHistoryDumpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Export all alerts separately?\r\n" +
                "Choosing NO will bundle all alerts into one file.",
                "SharpAlert",
                MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Cancel) return;

            if (SharpDataHistory.Count != 0)
            {
                try
                {
                    string directory = QuickSettings.ConfigDirPath + "\\Exports";

                    Directory.CreateDirectory(directory);
                    lock (SharpDataHistory)
                    {
                        //BundledAlerts_Timestamp.cap
                        if (result == DialogResult.Yes)
                        {
                            char[] invalidChars = Path.GetInvalidFileNameChars();

                            foreach (var item in SharpDataHistory)
                            {
                                string name = item.Name;

                                foreach (char character in name)
                                {
                                    if (invalidChars.Contains(character))
                                    {
                                        name = name.Replace(character, '_');
                                    }
                                }

                                File.WriteAllText(directory + "\\" + name + ".xml", item.Data);
                            }
                        }
                        else
                        {
                            if (result == DialogResult.No)
                            {
                                //string FullData = "<SharpAlertMassImport>true</SharpAlertMassImport>\r\n";

                                string FullData = string.Empty;

                                foreach (var item in SharpDataHistory)
                                {
                                    FullData += $"{item.Data}";
                                }

                                File.WriteAllText(directory + $"\\Bundled_{DateTime.UtcNow.Ticks}.xml", FullData);
                            }
                        }
                    }

                    MessageBox.Show($"{SharpDataHistory.Count} alert(s) have been exported.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Process.Start("explorer.exe", $"{directory}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"There are no alerts in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void PlayTestButton_Click(object sender, EventArgs e)
        {
            ProcessAlertTest(true, true, true, AutofillTestInfoBox.Checked);
        }

        private void ImportFileButton_Click(object sender, EventArgs e)
        {
            AddFileToQueue();
        }

        private int LastKnownHistoryCount = 0;

        private void AlertListRefresher_Tick(object sender, EventArgs e)
        {
            if (SharpDataHistory.Count != LastKnownHistoryCount)
            {
                AlertHistoryRefreshButton.Visible = true;
            }
        }

        private void ConfigurationForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void RevealButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataItem alert = null;

                lock (SharpDataHistory)
                {
                    string input = RevealAlertIdentifierInput.Text;

                    alert = SharpDataHistory.FirstOrDefault(item =>
                        string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));

                    if (alert == null)
                    {
                        MessageBox.Show("The alert identifier doesn't exist here.\r\nCheck it again, or try another!", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PastAlertsGroup.Enabled = true;
                        return;
                    }
                    else
                    {
                        RevealAlertIdentifierInput.Clear();
                    }
                }

                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private readonly AlertInfoForm aif = new();

        private void RevealRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                var alert = SharpDataHistory.Last();
                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private void WindowTestButton_Click(object sender, EventArgs e)
        {
            ProcessAlertTest(false, true, false, AutofillTestInfoBox.Checked);
        }

        private void DiscordTestButton_Click(object sender, EventArgs e)
        {
            ProcessAlertTest(true, false, false, AutofillTestInfoBox.Checked);
        }

        private void PhoneTestButton_Click(object sender, EventArgs e)
        {
            ProcessAlertTest(false, false, true, AutofillTestInfoBox.Checked);
        }

        private int Angle = 0;
        private readonly int AngleStep = 2;
        private readonly Image RefreshImage = Resources.arrows_rotate_solid_28x28;

        private void Rotater_Tick(object sender, EventArgs e)
        {
            Angle += AngleStep;

            if (Angle >= 360)
            {
                Angle -= 360;
            }

            AlertHistoryRefreshButton.Refresh();
        }

        private void AlertHistoryRefreshButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.TranslateTransform(AlertHistoryRefreshButton.Width / 2, AlertHistoryRefreshButton.Height / 2);
            G.RotateTransform(Angle);
            G.DrawImage(RefreshImage, new Point(-(RefreshImage.Width / 2), -(RefreshImage.Height / 2)));
        }

        private void RevealAlertIdentifierInput_TextChanged(object sender, EventArgs e)
        {
            ChangeAlertInfo.Enabled = false;
            RevealButton.Enabled = !string.IsNullOrWhiteSpace(RevealAlertIdentifierInput.Text);
            ChangeAlertInfo.Enabled = true;
        }
    }
}

