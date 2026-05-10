namespace SharpAlert.ConfigurationDialogs
{
    partial class AlertListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertListForm));
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            AlertHistoryClearButton = new System.Windows.Forms.Button();
            AlertHistoryRefreshButton = new System.Windows.Forms.Button();
            AlertHistoryReplayRecentButton = new System.Windows.Forms.Button();
            AlertHistoryDumpLink = new System.Windows.Forms.LinkLabel();
            BusyLockText = new System.Windows.Forms.Label();
            AlertHistoryOutput = new System.Windows.Forms.TextBox();
            PlayTestButton = new System.Windows.Forms.Button();
            ImportFileButton = new System.Windows.Forms.Button();
            RevealAlertIdentifierInput = new System.Windows.Forms.TextBox();
            RevealButton = new System.Windows.Forms.Button();
            RevealRecentButton = new System.Windows.Forms.Button();
            AlertHistoryReplayAllButton = new System.Windows.Forms.Button();
            WindowTestButton = new System.Windows.Forms.Button();
            DiscordTestButton = new System.Windows.Forms.Button();
            PhoneTestButton = new System.Windows.Forms.Button();
            RemoveButton = new System.Windows.Forms.Button();
            PastAlertsGroup = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            AlertHistoryText = new System.Windows.Forms.Label();
            ConfigurationPanel = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            AutofillTestInfoBox = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            AlertListRefresher = new System.Windows.Forms.Timer(components);
            Rotater = new System.Windows.Forms.Timer(components);
            ChangeAlertInfo = new System.Windows.Forms.Timer(components);
            PastAlertsGroup.SuspendLayout();
            ConfigurationPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ToolTipInformation
            // 
            ToolTipInformation.AutomaticDelay = 250;
            ToolTipInformation.AutoPopDelay = 15000;
            ToolTipInformation.BackColor = System.Drawing.Color.White;
            ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            ToolTipInformation.InitialDelay = 250;
            ToolTipInformation.IsBalloon = true;
            ToolTipInformation.ReshowDelay = 50;
            ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // AlertHistoryClearButton
            // 
            AlertHistoryClearButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryClearButton.BackColor = System.Drawing.Color.FromArgb(20, 0, 0);
            AlertHistoryClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertHistoryClearButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            AlertHistoryClearButton.ForeColor = System.Drawing.Color.Moccasin;
            AlertHistoryClearButton.Image = Properties.Resources.StripesBacking;
            AlertHistoryClearButton.Location = new System.Drawing.Point(514, 125);
            AlertHistoryClearButton.Name = "AlertHistoryClearButton";
            AlertHistoryClearButton.Size = new System.Drawing.Size(150, 67);
            AlertHistoryClearButton.TabIndex = 27;
            AlertHistoryClearButton.Text = "Clear All\r\nAlert History";
            ToolTipInformation.SetToolTip(AlertHistoryClearButton, "Clears the history list.");
            AlertHistoryClearButton.UseVisualStyleBackColor = false;
            AlertHistoryClearButton.Click += AlertHistoryClearButton_Click;
            // 
            // AlertHistoryRefreshButton
            // 
            AlertHistoryRefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryRefreshButton.BackColor = System.Drawing.Color.Transparent;
            AlertHistoryRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            AlertHistoryRefreshButton.FlatAppearance.BorderSize = 0;
            AlertHistoryRefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            AlertHistoryRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            AlertHistoryRefreshButton.Location = new System.Drawing.Point(478, 34);
            AlertHistoryRefreshButton.Name = "AlertHistoryRefreshButton";
            AlertHistoryRefreshButton.Size = new System.Drawing.Size(30, 30);
            AlertHistoryRefreshButton.TabIndex = 25;
            ToolTipInformation.SetToolTip(AlertHistoryRefreshButton, "Refreshes the history list.\r\n");
            AlertHistoryRefreshButton.UseVisualStyleBackColor = false;
            AlertHistoryRefreshButton.Visible = false;
            AlertHistoryRefreshButton.Click += AlertHistoryRefreshButton_Click;
            AlertHistoryRefreshButton.Paint += AlertHistoryRefreshButton_Paint;
            // 
            // AlertHistoryReplayRecentButton
            // 
            AlertHistoryReplayRecentButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryReplayRecentButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertHistoryReplayRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertHistoryReplayRecentButton.Location = new System.Drawing.Point(514, 67);
            AlertHistoryReplayRecentButton.Name = "AlertHistoryReplayRecentButton";
            AlertHistoryReplayRecentButton.Size = new System.Drawing.Size(150, 23);
            AlertHistoryReplayRecentButton.TabIndex = 22;
            AlertHistoryReplayRecentButton.Text = "Replay Most Recent Alert";
            ToolTipInformation.SetToolTip(AlertHistoryReplayRecentButton, "Reimports the most recent alert after removing it from history.\r\nExpiry does not affect whether or not an alert can be replayed.");
            AlertHistoryReplayRecentButton.UseVisualStyleBackColor = false;
            AlertHistoryReplayRecentButton.Click += AlertHistoryReplayRecentButton_Click;
            // 
            // AlertHistoryDumpLink
            // 
            AlertHistoryDumpLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryDumpLink.AutoSize = true;
            AlertHistoryDumpLink.LinkColor = System.Drawing.Color.Pink;
            AlertHistoryDumpLink.Location = new System.Drawing.Point(514, 49);
            AlertHistoryDumpLink.Name = "AlertHistoryDumpLink";
            AlertHistoryDumpLink.Size = new System.Drawing.Size(106, 15);
            AlertHistoryDumpLink.TabIndex = 30;
            AlertHistoryDumpLink.TabStop = true;
            AlertHistoryDumpLink.Text = "Export alert history";
            ToolTipInformation.SetToolTip(AlertHistoryDumpLink, "Dumps the alert history to a folder named \"dump\", then opens the folder in File Explorer.");
            AlertHistoryDumpLink.VisitedLinkColor = System.Drawing.Color.Cyan;
            AlertHistoryDumpLink.LinkClicked += AlertHistoryDumpLink_LinkClicked;
            // 
            // BusyLockText
            // 
            BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            BusyLockText.Font = new System.Drawing.Font("Segoe UI", 12F);
            BusyLockText.Location = new System.Drawing.Point(0, 0);
            BusyLockText.Name = "BusyLockText";
            BusyLockText.Size = new System.Drawing.Size(694, 485);
            BusyLockText.TabIndex = 14;
            BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ToolTipInformation.SetToolTip(BusyLockText, "You'll need to wait for all alerts to finish before continuing.");
            // 
            // AlertHistoryOutput
            // 
            AlertHistoryOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryOutput.BackColor = System.Drawing.Color.Black;
            AlertHistoryOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AlertHistoryOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            AlertHistoryOutput.ForeColor = System.Drawing.Color.White;
            AlertHistoryOutput.Location = new System.Drawing.Point(6, 67);
            AlertHistoryOutput.Multiline = true;
            AlertHistoryOutput.Name = "AlertHistoryOutput";
            AlertHistoryOutput.ReadOnly = true;
            AlertHistoryOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            AlertHistoryOutput.Size = new System.Drawing.Size(502, 125);
            AlertHistoryOutput.TabIndex = 18;
            ToolTipInformation.SetToolTip(AlertHistoryOutput, "This area shows the identifiers of each alert. If an identifier couldn't be found, the identifier will be an MD5 value based on the alert's raw data.");
            AlertHistoryOutput.WordWrap = false;
            // 
            // PlayTestButton
            // 
            PlayTestButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            PlayTestButton.BackColor = System.Drawing.Color.FromArgb(20, 0, 0);
            PlayTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PlayTestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            PlayTestButton.ForeColor = System.Drawing.Color.Moccasin;
            PlayTestButton.Image = Properties.Resources.StripesBacking;
            PlayTestButton.Location = new System.Drawing.Point(514, 22);
            PlayTestButton.Name = "PlayTestButton";
            PlayTestButton.Size = new System.Drawing.Size(150, 117);
            PlayTestButton.TabIndex = 23;
            PlayTestButton.Text = "Create Test Alert\r\nFor Everything";
            ToolTipInformation.SetToolTip(PlayTestButton, "Opens the alert editor window.");
            PlayTestButton.UseVisualStyleBackColor = false;
            PlayTestButton.Click += PlayTestButton_Click;
            // 
            // ImportFileButton
            // 
            ImportFileButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ImportFileButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ImportFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ImportFileButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            ImportFileButton.ForeColor = System.Drawing.Color.White;
            ImportFileButton.Location = new System.Drawing.Point(514, 198);
            ImportFileButton.Name = "ImportFileButton";
            ImportFileButton.Size = new System.Drawing.Size(150, 52);
            ImportFileButton.TabIndex = 26;
            ImportFileButton.Text = "Import Custom\r\nCAP Alert";
            ToolTipInformation.SetToolTip(ImportFileButton, resources.GetString("ImportFileButton.ToolTip"));
            ImportFileButton.UseVisualStyleBackColor = false;
            ImportFileButton.Click += ImportFileButton_Click;
            // 
            // RevealAlertIdentifierInput
            // 
            RevealAlertIdentifierInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RevealAlertIdentifierInput.BackColor = System.Drawing.Color.Black;
            RevealAlertIdentifierInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RevealAlertIdentifierInput.ForeColor = System.Drawing.Color.White;
            RevealAlertIdentifierInput.Location = new System.Drawing.Point(6, 213);
            RevealAlertIdentifierInput.Name = "RevealAlertIdentifierInput";
            RevealAlertIdentifierInput.PlaceholderText = "Example: TXDOT-65535256-a2c4-4f4d-9834-a4a93111b0f7";
            RevealAlertIdentifierInput.Size = new System.Drawing.Size(300, 23);
            RevealAlertIdentifierInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(RevealAlertIdentifierInput, "The alert identifier you want to access.");
            RevealAlertIdentifierInput.UseSystemPasswordChar = true;
            RevealAlertIdentifierInput.TextChanged += RevealAlertIdentifierInput_TextChanged;
            // 
            // RevealButton
            // 
            RevealButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            RevealButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RevealButton.Enabled = false;
            RevealButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RevealButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            RevealButton.Location = new System.Drawing.Point(312, 213);
            RevealButton.Name = "RevealButton";
            RevealButton.Size = new System.Drawing.Size(196, 23);
            RevealButton.TabIndex = 28;
            RevealButton.Text = "Show More Alert Information";
            ToolTipInformation.SetToolTip(RevealButton, "Reveal more information about a specific identifier in the list.");
            RevealButton.UseMnemonic = false;
            RevealButton.UseVisualStyleBackColor = false;
            RevealButton.Click += RevealButton_Click;
            // 
            // RevealRecentButton
            // 
            RevealRecentButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            RevealRecentButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RevealRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RevealRecentButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            RevealRecentButton.Location = new System.Drawing.Point(514, 256);
            RevealRecentButton.Name = "RevealRecentButton";
            RevealRecentButton.Size = new System.Drawing.Size(150, 23);
            RevealRecentButton.TabIndex = 29;
            RevealRecentButton.Text = "Show Recent Alert Info";
            ToolTipInformation.SetToolTip(RevealRecentButton, "Reveal more information about the most recent alert in the list.");
            RevealRecentButton.UseMnemonic = false;
            RevealRecentButton.UseVisualStyleBackColor = false;
            RevealRecentButton.Click += RevealRecentButton_Click;
            // 
            // AlertHistoryReplayAllButton
            // 
            AlertHistoryReplayAllButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryReplayAllButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertHistoryReplayAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertHistoryReplayAllButton.Location = new System.Drawing.Point(514, 96);
            AlertHistoryReplayAllButton.Name = "AlertHistoryReplayAllButton";
            AlertHistoryReplayAllButton.Size = new System.Drawing.Size(150, 23);
            AlertHistoryReplayAllButton.TabIndex = 24;
            AlertHistoryReplayAllButton.Text = "Replay All Alerts";
            ToolTipInformation.SetToolTip(AlertHistoryReplayAllButton, "Processes all alerts in the history again.\r\nThey will be processed as normal.");
            AlertHistoryReplayAllButton.UseVisualStyleBackColor = false;
            AlertHistoryReplayAllButton.Click += AlertHistoryReplayAllButton_Click;
            // 
            // WindowTestButton
            // 
            WindowTestButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            WindowTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            WindowTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            WindowTestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            WindowTestButton.ForeColor = System.Drawing.Color.White;
            WindowTestButton.Location = new System.Drawing.Point(3, 19);
            WindowTestButton.Name = "WindowTestButton";
            WindowTestButton.Size = new System.Drawing.Size(214, 30);
            WindowTestButton.TabIndex = 36;
            WindowTestButton.Text = "Create Window Test Alert";
            ToolTipInformation.SetToolTip(WindowTestButton, "Opens the alert editor window.");
            WindowTestButton.UseVisualStyleBackColor = false;
            WindowTestButton.Click += WindowTestButton_Click;
            // 
            // DiscordTestButton
            // 
            DiscordTestButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DiscordTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            DiscordTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DiscordTestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            DiscordTestButton.ForeColor = System.Drawing.Color.White;
            DiscordTestButton.Location = new System.Drawing.Point(3, 19);
            DiscordTestButton.Name = "DiscordTestButton";
            DiscordTestButton.Size = new System.Drawing.Size(214, 30);
            DiscordTestButton.TabIndex = 36;
            DiscordTestButton.Text = "Create Discord Test Alert";
            ToolTipInformation.SetToolTip(DiscordTestButton, "Opens the alert editor window.");
            DiscordTestButton.UseVisualStyleBackColor = false;
            DiscordTestButton.Click += DiscordTestButton_Click;
            // 
            // PhoneTestButton
            // 
            PhoneTestButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PhoneTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            PhoneTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PhoneTestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            PhoneTestButton.ForeColor = System.Drawing.Color.White;
            PhoneTestButton.Location = new System.Drawing.Point(3, 19);
            PhoneTestButton.Name = "PhoneTestButton";
            PhoneTestButton.Size = new System.Drawing.Size(214, 30);
            PhoneTestButton.TabIndex = 36;
            PhoneTestButton.Text = "Create IP Phone Test Alert";
            ToolTipInformation.SetToolTip(PhoneTestButton, "Opens the alert editor window.");
            PhoneTestButton.UseVisualStyleBackColor = false;
            PhoneTestButton.Click += PhoneTestButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            RemoveButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RemoveButton.Enabled = false;
            RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RemoveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            RemoveButton.Location = new System.Drawing.Point(312, 242);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new System.Drawing.Size(196, 23);
            RemoveButton.TabIndex = 34;
            RemoveButton.Text = "Remove Alert From History";
            ToolTipInformation.SetToolTip(RemoveButton, "Reveal more information about a specific identifier in the list.");
            RemoveButton.UseMnemonic = false;
            RemoveButton.UseVisualStyleBackColor = false;
            RemoveButton.Visible = false;
            // 
            // PastAlertsGroup
            // 
            PastAlertsGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PastAlertsGroup.Controls.Add(label5);
            PastAlertsGroup.Controls.Add(RemoveButton);
            PastAlertsGroup.Controls.Add(label2);
            PastAlertsGroup.Controls.Add(RevealRecentButton);
            PastAlertsGroup.Controls.Add(label1);
            PastAlertsGroup.Controls.Add(AlertHistoryReplayAllButton);
            PastAlertsGroup.Controls.Add(RevealButton);
            PastAlertsGroup.Controls.Add(RevealAlertIdentifierInput);
            PastAlertsGroup.Controls.Add(ImportFileButton);
            PastAlertsGroup.Controls.Add(AlertHistoryDumpLink);
            PastAlertsGroup.Controls.Add(AlertHistoryReplayRecentButton);
            PastAlertsGroup.Controls.Add(AlertHistoryText);
            PastAlertsGroup.Controls.Add(AlertHistoryOutput);
            PastAlertsGroup.Controls.Add(AlertHistoryClearButton);
            PastAlertsGroup.Controls.Add(AlertHistoryRefreshButton);
            PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            PastAlertsGroup.Location = new System.Drawing.Point(12, 12);
            PastAlertsGroup.Name = "PastAlertsGroup";
            PastAlertsGroup.Size = new System.Drawing.Size(670, 285);
            PastAlertsGroup.TabIndex = 5;
            PastAlertsGroup.TabStop = false;
            PastAlertsGroup.Text = "Alert Management";
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(6, 239);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(300, 40);
            label5.TabIndex = 35;
            label5.Text = "The alert IDs box will be replaced with an area that contains more alert information in the future.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 195);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(148, 15);
            label2.TabIndex = 33;
            label2.Text = "Specify Alert ID for options";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 49);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 15);
            label1.TabIndex = 32;
            label1.Text = "Alert IDs";
            // 
            // AlertHistoryText
            // 
            AlertHistoryText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertHistoryText.Font = new System.Drawing.Font("Segoe UI", 16F);
            AlertHistoryText.Location = new System.Drawing.Point(6, 17);
            AlertHistoryText.Name = "AlertHistoryText";
            AlertHistoryText.Size = new System.Drawing.Size(468, 32);
            AlertHistoryText.TabIndex = 6;
            AlertHistoryText.Text = "The alert history is empty right now.";
            // 
            // ConfigurationPanel
            // 
            ConfigurationPanel.Controls.Add(PastAlertsGroup);
            ConfigurationPanel.Controls.Add(groupBox1);
            ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            ConfigurationPanel.Name = "ConfigurationPanel";
            ConfigurationPanel.Size = new System.Drawing.Size(694, 485);
            ConfigurationPanel.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(PlayTestButton);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(AutofillTestInfoBox);
            groupBox1.Controls.Add(label3);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(12, 303);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(670, 170);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alert Testing";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label4);
            groupBox5.Enabled = false;
            groupBox5.ForeColor = System.Drawing.Color.White;
            groupBox5.Location = new System.Drawing.Point(232, 112);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(220, 52);
            groupBox5.TabIndex = 40;
            groupBox5.TabStop = false;
            groupBox5.Text = "Secret Fourth Option";
            // 
            // label4
            // 
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.Location = new System.Drawing.Point(3, 19);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(214, 30);
            label4.TabIndex = 35;
            label4.Text = "There's nothing here yet.";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(PhoneTestButton);
            groupBox4.ForeColor = System.Drawing.Color.White;
            groupBox4.Location = new System.Drawing.Point(6, 112);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(220, 52);
            groupBox4.TabIndex = 39;
            groupBox4.TabStop = false;
            groupBox4.Text = "IP Phone (if any)";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DiscordTestButton);
            groupBox3.ForeColor = System.Drawing.Color.White;
            groupBox3.Location = new System.Drawing.Point(232, 54);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(220, 52);
            groupBox3.TabIndex = 38;
            groupBox3.TabStop = false;
            groupBox3.Text = "Discord Webhooks (all webhooks)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(WindowTestButton);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(6, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(220, 52);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Window Alerts";
            // 
            // AutofillTestInfoBox
            // 
            AutofillTestInfoBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            AutofillTestInfoBox.AutoSize = true;
            AutofillTestInfoBox.Checked = true;
            AutofillTestInfoBox.CheckState = System.Windows.Forms.CheckState.Checked;
            AutofillTestInfoBox.Location = new System.Drawing.Point(511, 145);
            AutofillTestInfoBox.Name = "AutofillTestInfoBox";
            AutofillTestInfoBox.Size = new System.Drawing.Size(153, 19);
            AutofillTestInfoBox.TabIndex = 35;
            AutofillTestInfoBox.Text = "Autofill test information";
            AutofillTestInfoBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(6, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(502, 32);
            label3.TabIndex = 34;
            label3.Text = "In this group, you can test all functions separately, or together.\r\n(CAP data is not used to test these! If you need to, import custom CAP data instead.)";
            // 
            // AlertListRefresher
            // 
            AlertListRefresher.Enabled = true;
            AlertListRefresher.Interval = 500;
            AlertListRefresher.Tick += AlertListRefresher_Tick;
            // 
            // Rotater
            // 
            Rotater.Enabled = true;
            Rotater.Interval = 25;
            Rotater.Tick += Rotater_Tick;
            // 
            // ChangeAlertInfo
            // 
            ChangeAlertInfo.Interval = 1000;
            // 
            // AlertListForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(694, 485);
            Controls.Add(ConfigurationPanel);
            Controls.Add(BusyLockText);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(710, 240);
            Name = "AlertListForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Manager";
            Load += ConfigurationForm_Load;
            VisibleChanged += ConfigurationForm_VisibleChanged;
            PastAlertsGroup.ResumeLayout(false);
            PastAlertsGroup.PerformLayout();
            ConfigurationPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.GroupBox PastAlertsGroup;
        private System.Windows.Forms.LinkLabel AlertHistoryDumpLink;
        private System.Windows.Forms.Button AlertHistoryReplayRecentButton;
        private System.Windows.Forms.Button AlertHistoryRefreshButton;
        private System.Windows.Forms.Label AlertHistoryText;
        private System.Windows.Forms.TextBox AlertHistoryOutput;
        private System.Windows.Forms.Button AlertHistoryClearButton;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.Button PlayTestButton;
        private System.Windows.Forms.Button ImportFileButton;
        private System.Windows.Forms.Timer AlertListRefresher;
        private System.Windows.Forms.Button RevealRecentButton;
        private System.Windows.Forms.Button RevealButton;
        private System.Windows.Forms.TextBox RevealAlertIdentifierInput;
        private System.Windows.Forms.Button AlertHistoryReplayAllButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button WindowTestButton;
        private System.Windows.Forms.CheckBox AutofillTestInfoBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button PhoneTestButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DiscordTestButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer Rotater;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Timer ChangeAlertInfo;
        private System.Windows.Forms.Label label5;
    }
}
