using System.Windows.Forms;

namespace Server_Wrapper.Forms {
    public partial class About : Form {
        public About() {
            InitializeComponent();
        }

        private void ghLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/arcticfrosty");
        }
    }
}
