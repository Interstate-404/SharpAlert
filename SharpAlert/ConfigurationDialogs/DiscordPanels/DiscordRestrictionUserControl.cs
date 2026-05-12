using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs.DiscordPanels
{
    public partial class DiscordRestrictionUserControl : UserControl
    {
        public DiscordRestrictionUserControl(string reason)
        {
            InitializeComponent();
            RestrictionOutput.Text = reason;
        }
    }
}
