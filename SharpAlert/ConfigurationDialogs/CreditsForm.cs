using System;
using System.Drawing;
using System.Windows.Forms;
using SharpAlert.AlertComponents;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
        }

#pragma warning disable IDE1006 // Naming Styles
        private void label5_DoubleClick(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://www.youtube.com/watch?v=1KC-2_DnhQg");
        }

        private void CreditsForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }


        private bool UpDown = true;

        private void WindowShake_Tick(object sender, EventArgs e)
        {
            if (AprilFools.IsAprilFoolsNow)
            {
                if (UpDown)
                {
                    Location = new Point(Location.X, Location.Y + 10);
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - 10);
                }

                UpDown = !UpDown;
            }
        }

        private void ShowLibrariesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Costura.Fody - © Fody Contributors - MIT License - https://opensource.org/licenses/MIT\r\nDiscordRichPresence - © Lachee - MIT License - https://github.com/Lachee/discord-rpc-csharp/blob/master/LICENSE\r\nHidLibrary - © Mike O’Brien - MIT License - https://github.com/mikeobrien/HidLibrary/blob/master/LICENSE\r\nNAudio - © Mark Heath and contributors - MIT License - https://github.com/naudio/NAudio/blob/master/license.txt\r\nNewtonsoft.Json - © James Newton-King - MIT License - https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md\r\nFody - © Fody Contributors - MIT License - https://github.com/Fody/Fody/blob/master/License.txt\r\n\r\nAwokenNotifications - © BunnyTub", "SharpAlert - Libraries used (Tool generated list)");
        }

        private void SkewerKing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/637078631943897103");
        }

        private void BoxedApplePieLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://www.youtube.com/channel/UCyEsuDNsAPqMAGMtxL8V1Vw");
        }

        private void InterstateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/602238459838595081");
        }

        private void ConnorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://x.com/ithastobeconnor");
        }

        private void Anon1Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The person who has contributed this asset has asked to remain anonymous. No URL is available.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KwaziizLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://kwaziiz.carrd.co/");
        }

        private int TargetHeight = 380;
        private const double EaseFactor = 0.16;
        private const int StopThreshold = 1;
        private bool AnimationRunning = false;

        private void AnimateLogo(int targetHeight)
        {
            TargetHeight = targetHeight;

            if (LogoAnimation.Enabled)
            {
            }
            else
            {
                LogoAnimation.Enabled = true;
            }
        }

        private void LogoAnimation_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.25) return;

            int current = CharactersPicture.Height;
            int delta = TargetHeight - current;

            if (Math.Abs(delta) <= StopThreshold)
            {
                CharactersPicture.Height = TargetHeight;
                AnimationRunning = false;
                return;
            }

            //pictureBox1.SendToBack();
            AnimationRunning = true;

            int step = (int)Math.Ceiling(delta * EaseFactor);

            if (step == 0) step = -1;
            CharactersPicture.Height += step;
        }

        private void CharactersPicture_MouseEnter(object sender, EventArgs e)
        {
            AnimateLogo(355);
            BounceHigh = false;
            Bouncer.Enabled = true;
            //AnimateLogo(355);
        }

        private void CharactersPicture_MouseLeave(object sender, EventArgs e)
        {
            Bouncer.Enabled = false;
            AnimateLogo(380);
        }

        private bool BounceHigh = true;

        private void Bouncer_Tick(object sender, EventArgs e)
        {
            if (BounceHigh)
            {
                AnimateLogo(355);
            }
            else
            {
                AnimateLogo(380);
            }

            BounceHigh = !BounceHigh;
        }

        private void ScrollText1_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/475296501862498304");
        }

        private void ScrollText2_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/422894211130720267");
        }

        private void ScrollText3_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/608175034661470209");
        }

        private void ScrollText4_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/602238459838595081");
        }

        private void ScrollText5_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/451936795802992640");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CharactersPicture_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://www.youtube.com/@SPCHalethorpe09");
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}

