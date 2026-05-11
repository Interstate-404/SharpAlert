namespace SharpAlert.ConfigurationDialogs
{
    partial class CreditsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsForm));
            label5 = new System.Windows.Forms.Label();
            BoxedApplePieLink = new System.Windows.Forms.LinkLabel();
            SkewerKingLink = new System.Windows.Forms.LinkLabel();
            WindowShake = new System.Windows.Forms.Timer(components);
            InterstateLink = new System.Windows.Forms.LinkLabel();
            ShowLibrariesButton = new System.Windows.Forms.Button();
            LogoAnimation = new System.Windows.Forms.Timer(components);
            CharactersPicture = new System.Windows.Forms.PictureBox();
            Bouncer = new System.Windows.Forms.Timer(components);
            ConnorLink = new System.Windows.Forms.LinkLabel();
            Anon1Link = new System.Windows.Forms.LinkLabel();
            KwaziizLink = new System.Windows.Forms.LinkLabel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)CharactersPicture).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(9, 9);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(576, 42);
            label5.TabIndex = 0;
            label5.Text = "SharpAlert is a project created by BunnyTub, written and built in C# (.NET).\r\nThis fork was made by Interstate 404 // Sevyn.";
            label5.Click += label5_Click;
            label5.DoubleClick += label5_DoubleClick;
            // 
            // BoxedApplePieLink
            // 
            BoxedApplePieLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            BoxedApplePieLink.AutoSize = true;
            BoxedApplePieLink.BackColor = System.Drawing.Color.Transparent;
            BoxedApplePieLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            BoxedApplePieLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            BoxedApplePieLink.Location = new System.Drawing.Point(9, 83);
            BoxedApplePieLink.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            BoxedApplePieLink.Name = "BoxedApplePieLink";
            BoxedApplePieLink.Size = new System.Drawing.Size(198, 15);
            BoxedApplePieLink.TabIndex = 2;
            BoxedApplePieLink.TabStop = true;
            BoxedApplePieLink.Text = "BoxedApplePie (Other OC drawings)";
            BoxedApplePieLink.LinkClicked += BoxedApplePieLink_LinkClicked;
            // 
            // SkewerKingLink
            // 
            SkewerKingLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            SkewerKingLink.AutoSize = true;
            SkewerKingLink.BackColor = System.Drawing.Color.Transparent;
            SkewerKingLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            SkewerKingLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            SkewerKingLink.Location = new System.Drawing.Point(9, 65);
            SkewerKingLink.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            SkewerKingLink.Name = "SkewerKingLink";
            SkewerKingLink.Size = new System.Drawing.Size(161, 15);
            SkewerKingLink.TabIndex = 1;
            SkewerKingLink.TabStop = true;
            SkewerKingLink.Text = "SkewerKing (Webhook icons)";
            SkewerKingLink.LinkClicked += SkewerKing_LinkClicked;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // InterstateLink
            // 
            InterstateLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            InterstateLink.AutoSize = true;
            InterstateLink.BackColor = System.Drawing.Color.Transparent;
            InterstateLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            InterstateLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            InterstateLink.Location = new System.Drawing.Point(9, 101);
            InterstateLink.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            InterstateLink.Name = "InterstateLink";
            InterstateLink.Size = new System.Drawing.Size(234, 15);
            InterstateLink.TabIndex = 3;
            InterstateLink.TabStop = true;
            InterstateLink.Text = "Interstate404 (Added U.S. marine locations)";
            InterstateLink.LinkClicked += InterstateLink_LinkClicked;
            // 
            // ShowLibrariesButton
            // 
            ShowLibrariesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ShowLibrariesButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ShowLibrariesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ShowLibrariesButton.Location = new System.Drawing.Point(727, 41);
            ShowLibrariesButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            ShowLibrariesButton.Name = "ShowLibrariesButton";
            ShowLibrariesButton.Size = new System.Drawing.Size(116, 23);
            ShowLibrariesButton.TabIndex = 0;
            ShowLibrariesButton.Text = "Show Libraries";
            ShowLibrariesButton.UseVisualStyleBackColor = false;
            ShowLibrariesButton.Click += ShowLibrariesButton_Click;
            // 
            // LogoAnimation
            // 
            LogoAnimation.Enabled = true;
            LogoAnimation.Interval = 15;
            LogoAnimation.Tick += LogoAnimation_Tick;
            // 
            // CharactersPicture
            // 
            CharactersPicture.Dock = System.Windows.Forms.DockStyle.Top;
            CharactersPicture.Image = Properties.Resources.Characters2;
            CharactersPicture.Location = new System.Drawing.Point(0, 0);
            CharactersPicture.Name = "CharactersPicture";
            CharactersPicture.Size = new System.Drawing.Size(855, 375);
            CharactersPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            CharactersPicture.TabIndex = 110;
            CharactersPicture.TabStop = false;
            CharactersPicture.Click += CharactersPicture_Click;
            CharactersPicture.MouseEnter += CharactersPicture_MouseEnter;
            CharactersPicture.MouseLeave += CharactersPicture_MouseLeave;
            // 
            // Bouncer
            // 
            Bouncer.Interval = 250;
            Bouncer.Tick += Bouncer_Tick;
            // 
            // ConnorLink
            // 
            ConnorLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ConnorLink.AutoSize = true;
            ConnorLink.BackColor = System.Drawing.Color.Transparent;
            ConnorLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            ConnorLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            ConnorLink.Location = new System.Drawing.Point(9, 119);
            ConnorLink.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            ConnorLink.Name = "ConnorLink";
            ConnorLink.Size = new System.Drawing.Size(206, 15);
            ConnorLink.TabIndex = 4;
            ConnorLink.TabStop = true;
            ConnorLink.Text = "MaybeConnor (Ideas, SharpWX icons)";
            ConnorLink.LinkClicked += ConnorLink_LinkClicked;
            // 
            // Anon1Link
            // 
            Anon1Link.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            Anon1Link.AutoSize = true;
            Anon1Link.BackColor = System.Drawing.Color.Transparent;
            Anon1Link.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            Anon1Link.LinkColor = System.Drawing.Color.DeepSkyBlue;
            Anon1Link.Location = new System.Drawing.Point(9, 137);
            Anon1Link.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            Anon1Link.Name = "Anon1Link";
            Anon1Link.Size = new System.Drawing.Size(244, 15);
            Anon1Link.TabIndex = 5;
            Anon1Link.TabStop = true;
            Anon1Link.Text = "Anonymous Artist (Connor's OC drawn here)";
            Anon1Link.LinkClicked += Anon1Link_LinkClicked;
            // 
            // KwaziizLink
            // 
            KwaziizLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            KwaziizLink.AutoSize = true;
            KwaziizLink.BackColor = System.Drawing.Color.Transparent;
            KwaziizLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            KwaziizLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            KwaziizLink.Location = new System.Drawing.Point(9, 155);
            KwaziizLink.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            KwaziizLink.Name = "KwaziizLink";
            KwaziizLink.Size = new System.Drawing.Size(201, 15);
            KwaziizLink.TabIndex = 6;
            KwaziizLink.TabStop = true;
            KwaziizLink.Text = "Kwaziiz (BunnyTub's OC drawn here)";
            KwaziizLink.LinkClicked += KwaziizLink_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(610, 101);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 19);
            label2.TabIndex = 112;
            label2.Text = "Connor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(408, 101);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 19);
            label1.TabIndex = 111;
            label1.Text = "BunnyTub";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(287, 115);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 19);
            label3.TabIndex = 114;
            label3.Text = "Interstate 404";
            label3.Click += label3_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = System.Drawing.Color.Transparent;
            linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = System.Drawing.Color.DeepSkyBlue;
            linkLabel1.Location = new System.Drawing.Point(9, 173);
            linkLabel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(249, 15);
            linkLabel1.TabIndex = 115;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "SPCHalethorpe09 (Interstate's OC drawn here)";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // CreditsForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ClientSize = new System.Drawing.Size(855, 350);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(KwaziizLink);
            Controls.Add(Anon1Link);
            Controls.Add(ConnorLink);
            Controls.Add(ShowLibrariesButton);
            Controls.Add(InterstateLink);
            Controls.Add(SkewerKingLink);
            Controls.Add(BoxedApplePieLink);
            Controls.Add(label5);
            Controls.Add(CharactersPicture);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreditsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "About SharpAlert";
            HelpButtonClicked += CreditsForm_HelpButtonClicked;
            Load += CreditsForm_Load;
            ((System.ComponentModel.ISupportInitialize)CharactersPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel BoxedApplePieLink;
        private System.Windows.Forms.LinkLabel SkewerKingLink;
        private System.Windows.Forms.Timer WindowShake;
        private System.Windows.Forms.LinkLabel InterstateLink;
        private System.Windows.Forms.Button ShowLibrariesButton;
        private System.Windows.Forms.Timer LogoAnimation;
        private System.Windows.Forms.PictureBox CharactersPicture;
        private System.Windows.Forms.Timer Bouncer;
        private System.Windows.Forms.LinkLabel ConnorLink;
        private System.Windows.Forms.LinkLabel Anon1Link;
        private System.Windows.Forms.LinkLabel KwaziizLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
