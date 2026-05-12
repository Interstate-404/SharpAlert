namespace SharpAlert.ConfigurationDialogs.DiscordPanels
{
    partial class DiscordRestrictionUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TopBarImage = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            TitleText = new System.Windows.Forms.Label();
            SubtitleText = new System.Windows.Forms.Label();
            ReasonTitleText = new System.Windows.Forms.Label();
            RestrictionOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)TopBarImage).BeginInit();
            SuspendLayout();
            // 
            // TopBarImage
            // 
            TopBarImage.Dock = System.Windows.Forms.DockStyle.Top;
            TopBarImage.Image = Properties.Resources.RestrictedBar;
            TopBarImage.Location = new System.Drawing.Point(0, 0);
            TopBarImage.Name = "TopBarImage";
            TopBarImage.Size = new System.Drawing.Size(758, 62);
            TopBarImage.TabIndex = 0;
            TopBarImage.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Red;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 62);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(758, 2);
            panel1.TabIndex = 1;
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(3, 67);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(739, 30);
            TitleText.TabIndex = 2;
            TitleText.Text = "The Discord Rich Presence feature has found that your account is restricted.";
            // 
            // SubtitleText
            // 
            SubtitleText.AutoSize = true;
            SubtitleText.Font = new System.Drawing.Font("Segoe UI", 12F);
            SubtitleText.Location = new System.Drawing.Point(6, 97);
            SubtitleText.Name = "SubtitleText";
            SubtitleText.Size = new System.Drawing.Size(580, 42);
            SubtitleText.TabIndex = 3;
            SubtitleText.Text = "Some features relating to Discord functionality have been disabled. You can appeal\r\nthis restriction and find more information here: https://bunnytub.com/SharpAlert";
            // 
            // ReasonTitleText
            // 
            ReasonTitleText.AutoSize = true;
            ReasonTitleText.Font = new System.Drawing.Font("Segoe UI", 14F);
            ReasonTitleText.Location = new System.Drawing.Point(3, 152);
            ReasonTitleText.Name = "ReasonTitleText";
            ReasonTitleText.Size = new System.Drawing.Size(393, 25);
            ReasonTitleText.TabIndex = 4;
            ReasonTitleText.Text = "Here is the reason for your restriction (if any):";
            // 
            // RestrictionOutput
            // 
            RestrictionOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RestrictionOutput.BackColor = System.Drawing.Color.Black;
            RestrictionOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RestrictionOutput.Font = new System.Drawing.Font("Segoe UI", 16F);
            RestrictionOutput.ForeColor = System.Drawing.Color.White;
            RestrictionOutput.Location = new System.Drawing.Point(6, 180);
            RestrictionOutput.Margin = new System.Windows.Forms.Padding(6);
            RestrictionOutput.Multiline = true;
            RestrictionOutput.Name = "RestrictionOutput";
            RestrictionOutput.ReadOnly = true;
            RestrictionOutput.Size = new System.Drawing.Size(746, 213);
            RestrictionOutput.TabIndex = 5;
            RestrictionOutput.Text = "You hate the LGBTQ+, but use SharpAlert, software made by a person who is bi? Make it make sense. This restriction is permanent.";
            // 
            // DiscordRestrictionUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            Controls.Add(RestrictionOutput);
            Controls.Add(ReasonTitleText);
            Controls.Add(SubtitleText);
            Controls.Add(TitleText);
            Controls.Add(panel1);
            Controls.Add(TopBarImage);
            ForeColor = System.Drawing.Color.White;
            Name = "DiscordRestrictionUserControl";
            Size = new System.Drawing.Size(758, 399);
            ((System.ComponentModel.ISupportInitialize)TopBarImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox TopBarImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Label ReasonTitleText;
        private System.Windows.Forms.TextBox RestrictionOutput;
    }
}
