namespace SharpAlert
{
    partial class RestrictedInFullForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestrictedInFullForm));
            TopBarImage = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)TopBarImage).BeginInit();
            SuspendLayout();
            // 
            // TopBarImage
            // 
            TopBarImage.Dock = System.Windows.Forms.DockStyle.Top;
            TopBarImage.Image = Properties.Resources.RestrictedBar100;
            TopBarImage.Location = new System.Drawing.Point(0, 0);
            TopBarImage.Name = "TopBarImage";
            TopBarImage.Size = new System.Drawing.Size(752, 62);
            TopBarImage.TabIndex = 1;
            TopBarImage.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Red;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 62);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(752, 2);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            label1.Location = new System.Drawing.Point(0, 64);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(3);
            label1.Size = new System.Drawing.Size(752, 197);
            label1.TabIndex = 3;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestrictedInFullForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(752, 261);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(TopBarImage);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RestrictedInFullForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Restricted (Client Locked)";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)TopBarImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox TopBarImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}