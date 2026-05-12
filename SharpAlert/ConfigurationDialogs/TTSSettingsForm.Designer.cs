namespace SharpAlert.ConfigurationDialogs
{
    partial class TTSSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTSSettingsForm));
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);

            VoiceLabel = new System.Windows.Forms.Label();
            VoiceCombo = new System.Windows.Forms.ComboBox();
            VoiceClearLink = new System.Windows.Forms.LinkLabel();
            RefreshVoicesButton = new System.Windows.Forms.Button();

            RateLabel = new System.Windows.Forms.Label();
            RateValueLabel = new System.Windows.Forms.Label();
            RateBar = new System.Windows.Forms.TrackBar();

            PitchLabel = new System.Windows.Forms.Label();
            PitchValueLabel = new System.Windows.Forms.Label();
            PitchBar = new System.Windows.Forms.TrackBar();

            VolumeLabel = new System.Windows.Forms.Label();
            VolumeValueLabel = new System.Windows.Forms.Label();
            VolumeBar = new System.Windows.Forms.TrackBar();

            PreviewLabel = new System.Windows.Forms.Label();
            PreviewText = new System.Windows.Forms.TextBox();
            PreviewButton = new System.Windows.Forms.Button();
            StopButton = new System.Windows.Forms.Button();

            ResetButton = new System.Windows.Forms.Button();
            WindowsSpeechButton = new System.Windows.Forms.Button();
            DoneButton = new System.Windows.Forms.Button();
            StatusLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RateBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PitchBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).BeginInit();
            SuspendLayout();

            //
            // LogoBox
            //
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(48, 48);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            LogoBox.TabIndex = 0;
            LogoBox.TabStop = false;

            //
            // TitleText
            //
            TitleText.AutoSize = false;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 18F);
            TitleText.ForeColor = System.Drawing.Color.White;
            TitleText.Location = new System.Drawing.Point(63, 14);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(450, 40);
            TitleText.TabIndex = 1;
            TitleText.Text = "TTS Settings";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            //
            // VoiceLabel
            //
            VoiceLabel.AutoSize = true;
            VoiceLabel.ForeColor = System.Drawing.Color.White;
            VoiceLabel.Location = new System.Drawing.Point(12, 72);
            VoiceLabel.Name = "VoiceLabel";
            VoiceLabel.Size = new System.Drawing.Size(40, 15);
            VoiceLabel.TabIndex = 2;
            VoiceLabel.Text = "Voice";

            //
            // VoiceCombo
            //
            VoiceCombo.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            VoiceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            VoiceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            VoiceCombo.ForeColor = System.Drawing.Color.White;
            VoiceCombo.FormattingEnabled = true;
            VoiceCombo.Location = new System.Drawing.Point(12, 90);
            VoiceCombo.Name = "VoiceCombo";
            VoiceCombo.Size = new System.Drawing.Size(370, 23);
            VoiceCombo.TabIndex = 3;
            ToolTipInformation.SetToolTip(VoiceCombo, "Voices enumerated across 64-bit, WOW6432Node, and OneCore registry hives.");
            VoiceCombo.SelectedIndexChanged += VoiceCombo_SelectedIndexChanged;

            //
            // RefreshVoicesButton
            //
            RefreshVoicesButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RefreshVoicesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RefreshVoicesButton.Location = new System.Drawing.Point(388, 90);
            RefreshVoicesButton.Name = "RefreshVoicesButton";
            RefreshVoicesButton.Size = new System.Drawing.Size(72, 23);
            RefreshVoicesButton.TabIndex = 4;
            RefreshVoicesButton.Text = "Refresh";
            ToolTipInformation.SetToolTip(RefreshVoicesButton, "Re-scan SAPI voice registry.");
            RefreshVoicesButton.UseVisualStyleBackColor = false;
            RefreshVoicesButton.Click += RefreshVoicesButton_Click;

            //
            // VoiceClearLink
            //
            VoiceClearLink.ActiveLinkColor = System.Drawing.Color.White;
            VoiceClearLink.AutoSize = true;
            VoiceClearLink.LinkColor = System.Drawing.Color.LightSkyBlue;
            VoiceClearLink.Location = new System.Drawing.Point(12, 116);
            VoiceClearLink.Name = "VoiceClearLink";
            VoiceClearLink.Size = new System.Drawing.Size(140, 15);
            VoiceClearLink.TabIndex = 5;
            VoiceClearLink.TabStop = true;
            VoiceClearLink.Text = "Use system default voice";
            VoiceClearLink.LinkClicked += VoiceClearLink_LinkClicked;

            //
            // RateLabel
            //
            RateLabel.AutoSize = true;
            RateLabel.ForeColor = System.Drawing.Color.White;
            RateLabel.Location = new System.Drawing.Point(12, 148);
            RateLabel.Name = "RateLabel";
            RateLabel.Size = new System.Drawing.Size(34, 15);
            RateLabel.TabIndex = 6;
            RateLabel.Text = "Rate";

            //
            // RateValueLabel
            //
            RateValueLabel.AutoSize = false;
            RateValueLabel.ForeColor = System.Drawing.Color.Silver;
            RateValueLabel.Location = new System.Drawing.Point(420, 148);
            RateValueLabel.Name = "RateValueLabel";
            RateValueLabel.Size = new System.Drawing.Size(40, 15);
            RateValueLabel.TabIndex = 7;
            RateValueLabel.Text = "0";
            RateValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // RateBar
            //
            RateBar.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            RateBar.LargeChange = 2;
            RateBar.Location = new System.Drawing.Point(8, 166);
            RateBar.Maximum = 10;
            RateBar.Minimum = -10;
            RateBar.Name = "RateBar";
            RateBar.Size = new System.Drawing.Size(454, 45);
            RateBar.TabIndex = 8;
            RateBar.TickFrequency = 2;
            RateBar.Value = 0;
            RateBar.Scroll += RateBar_Scroll;
            RateBar.ValueChanged += RateBar_Scroll;

            //
            // PitchLabel
            //
            PitchLabel.AutoSize = true;
            PitchLabel.ForeColor = System.Drawing.Color.White;
            PitchLabel.Location = new System.Drawing.Point(12, 211);
            PitchLabel.Name = "PitchLabel";
            PitchLabel.Size = new System.Drawing.Size(36, 15);
            PitchLabel.TabIndex = 9;
            PitchLabel.Text = "Pitch";

            //
            // PitchValueLabel
            //
            PitchValueLabel.AutoSize = false;
            PitchValueLabel.ForeColor = System.Drawing.Color.Silver;
            PitchValueLabel.Location = new System.Drawing.Point(420, 211);
            PitchValueLabel.Name = "PitchValueLabel";
            PitchValueLabel.Size = new System.Drawing.Size(40, 15);
            PitchValueLabel.TabIndex = 10;
            PitchValueLabel.Text = "0";
            PitchValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // PitchBar
            //
            PitchBar.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            PitchBar.LargeChange = 2;
            PitchBar.Location = new System.Drawing.Point(8, 229);
            PitchBar.Maximum = 10;
            PitchBar.Minimum = -10;
            PitchBar.Name = "PitchBar";
            PitchBar.Size = new System.Drawing.Size(454, 45);
            PitchBar.TabIndex = 11;
            PitchBar.TickFrequency = 2;
            PitchBar.Value = 0;
            PitchBar.Scroll += PitchBar_Scroll;
            PitchBar.ValueChanged += PitchBar_Scroll;

            //
            // VolumeLabel
            //
            VolumeLabel.AutoSize = true;
            VolumeLabel.ForeColor = System.Drawing.Color.White;
            VolumeLabel.Location = new System.Drawing.Point(12, 274);
            VolumeLabel.Name = "VolumeLabel";
            VolumeLabel.Size = new System.Drawing.Size(53, 15);
            VolumeLabel.TabIndex = 12;
            VolumeLabel.Text = "Volume";

            //
            // VolumeValueLabel
            //
            VolumeValueLabel.AutoSize = false;
            VolumeValueLabel.ForeColor = System.Drawing.Color.Silver;
            VolumeValueLabel.Location = new System.Drawing.Point(420, 274);
            VolumeValueLabel.Name = "VolumeValueLabel";
            VolumeValueLabel.Size = new System.Drawing.Size(40, 15);
            VolumeValueLabel.TabIndex = 13;
            VolumeValueLabel.Text = "8";
            VolumeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // VolumeBar
            //
            VolumeBar.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            VolumeBar.LargeChange = 1;
            VolumeBar.Location = new System.Drawing.Point(8, 292);
            VolumeBar.Maximum = 10;
            VolumeBar.Minimum = 0;
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new System.Drawing.Size(454, 45);
            VolumeBar.TabIndex = 14;
            VolumeBar.TickFrequency = 1;
            VolumeBar.Value = 8;
            VolumeBar.Scroll += VolumeBar_Scroll;
            VolumeBar.ValueChanged += VolumeBar_Scroll;

            //
            // PreviewLabel
            //
            PreviewLabel.AutoSize = true;
            PreviewLabel.ForeColor = System.Drawing.Color.White;
            PreviewLabel.Location = new System.Drawing.Point(12, 340);
            PreviewLabel.Name = "PreviewLabel";
            PreviewLabel.Size = new System.Drawing.Size(80, 15);
            PreviewLabel.TabIndex = 15;
            PreviewLabel.Text = "Preview text";

            //
            // PreviewText
            //
            PreviewText.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            PreviewText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PreviewText.ForeColor = System.Drawing.Color.White;
            PreviewText.Location = new System.Drawing.Point(12, 358);
            PreviewText.Multiline = true;
            PreviewText.Name = "PreviewText";
            PreviewText.Size = new System.Drawing.Size(282, 60);
            PreviewText.TabIndex = 16;
            PreviewText.Text = "This is a test of the SharpAlert text to speech system.";

            //
            // PreviewButton
            //
            PreviewButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreviewButton.Location = new System.Drawing.Point(300, 358);
            PreviewButton.Name = "PreviewButton";
            PreviewButton.Size = new System.Drawing.Size(160, 27);
            PreviewButton.TabIndex = 17;
            PreviewButton.Text = "Test voice";
            ToolTipInformation.SetToolTip(PreviewButton, "Speak the preview text with current settings.");
            PreviewButton.UseVisualStyleBackColor = false;
            PreviewButton.Click += PreviewButton_Click;

            //
            // StopButton
            //
            StopButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            StopButton.Location = new System.Drawing.Point(300, 391);
            StopButton.Name = "StopButton";
            StopButton.Size = new System.Drawing.Size(160, 27);
            StopButton.TabIndex = 18;
            StopButton.Text = "Stop preview";
            StopButton.UseVisualStyleBackColor = false;
            StopButton.Click += StopButton_Click;

            //
            // ResetButton
            //
            ResetButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ResetButton.Location = new System.Drawing.Point(12, 432);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new System.Drawing.Size(120, 27);
            ResetButton.TabIndex = 19;
            ResetButton.Text = "Reset to defaults";
            ToolTipInformation.SetToolTip(ResetButton, "Reset rate/pitch/volume to 0/0/8.");
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;

            //
            // WindowsSpeechButton
            //
            WindowsSpeechButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            WindowsSpeechButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            WindowsSpeechButton.Location = new System.Drawing.Point(138, 432);
            WindowsSpeechButton.Name = "WindowsSpeechButton";
            WindowsSpeechButton.Size = new System.Drawing.Size(170, 27);
            WindowsSpeechButton.TabIndex = 20;
            WindowsSpeechButton.Text = "Windows Speech Properties";
            ToolTipInformation.SetToolTip(WindowsSpeechButton, "Open Windows' sapi.cpl control panel.");
            WindowsSpeechButton.UseVisualStyleBackColor = false;
            WindowsSpeechButton.Click += WindowsSpeechButton_Click;

            //
            // DoneButton
            //
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(388, 432);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(72, 27);
            DoneButton.TabIndex = 21;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;

            //
            // StatusLabel
            //
            StatusLabel.AutoSize = false;
            StatusLabel.ForeColor = System.Drawing.Color.Silver;
            StatusLabel.Location = new System.Drawing.Point(12, 396);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(282, 22);
            StatusLabel.TabIndex = 22;
            StatusLabel.Text = "";
            StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            StatusLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            StatusLabel.Click += StatusLabel_Click;

            //
            // TTSSettingsForm
            //
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(472, 471);
            Controls.Add(StatusLabel);
            Controls.Add(DoneButton);
            Controls.Add(WindowsSpeechButton);
            Controls.Add(ResetButton);
            Controls.Add(StopButton);
            Controls.Add(PreviewButton);
            Controls.Add(PreviewText);
            Controls.Add(PreviewLabel);
            Controls.Add(VolumeBar);
            Controls.Add(VolumeValueLabel);
            Controls.Add(VolumeLabel);
            Controls.Add(PitchBar);
            Controls.Add(PitchValueLabel);
            Controls.Add(PitchLabel);
            Controls.Add(RateBar);
            Controls.Add(RateValueLabel);
            Controls.Add(RateLabel);
            Controls.Add(VoiceClearLink);
            Controls.Add(RefreshVoicesButton);
            Controls.Add(VoiceCombo);
            Controls.Add(VoiceLabel);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TTSSettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SharpAlert - TTS Settings";
            FormClosing += TTSSettingsForm_FormClosing;
            Load += TTSSettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RateBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PitchBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label VoiceLabel;
        private System.Windows.Forms.ComboBox VoiceCombo;
        private System.Windows.Forms.LinkLabel VoiceClearLink;
        private System.Windows.Forms.Button RefreshVoicesButton;
        private System.Windows.Forms.Label RateLabel;
        private System.Windows.Forms.Label RateValueLabel;
        private System.Windows.Forms.TrackBar RateBar;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.Label PitchValueLabel;
        private System.Windows.Forms.TrackBar PitchBar;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Label VolumeValueLabel;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.TextBox PreviewText;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button WindowsSpeechButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label StatusLabel;
    }
}
