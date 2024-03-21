using System;
using System.Windows.Forms;

namespace Server_Wrapper.Forms {
    public partial class Server_Settings : Form {

        private string lastItem = "";
        private bool userInteract = false;

        public Server_Settings() {
            InitializeComponent();
        }
        private void Server_Settings_Load(object sender, EventArgs e) {
            //Init Settings
            ramMin.Text = Properties.Settings.Default.ramMin.ToString();
            ramMax.Text = Properties.Settings.Default.ramMax.ToString();
            ramUnit.Text = Properties.Settings.Default.ramUnit.ToString();
            serverFile.Text = Properties.Settings.Default.serverFile.ToString();
        }
        private void saveBtn_Click(object sender, EventArgs e) {
            try {
                Properties.Settings.Default.ramMin = Convert.ToInt32(ramMin.Text);
                Properties.Settings.Default.ramMax = Convert.ToInt32(ramMax.Text);
                Properties.Settings.Default.ramUnit = ramUnit.Text;
                Properties.Settings.Default.serverFile = serverFile.Text;
                if (Convert.ToInt32(ramMin.Text) > Convert.ToInt32(ramMax.Text)) {
                    MessageBox.Show("Save unsuccessful!\nMinimum RAM should be lower or equal to the maximum!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Save successful.\nPlease restart the server.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch {
                MessageBox.Show("Save unsuccessful!\nPlease check your settings.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ramUnit_Enter(object sender, EventArgs e) {
            userInteract = true;
        }
        private void ramUnit_Leave(object sender, EventArgs e) {
            userInteract = false;
        }
        private void ramUnit_SelectedIndexChanged(object sender, EventArgs e) {
            if (!userInteract) {
                return;
            }
            string currentItem = ramUnit.SelectedItem.ToString();
            if (currentItem == lastItem) {
                return;
            }
            lastItem = currentItem;
            if (int.TryParse(ramMin.Text, out int min) && int.TryParse(ramMax.Text, out int max)) {
                switch (ramUnit.SelectedItem.ToString()) {
                    case "GB":
                    if (min > 0 && max > 0) {
                        ramMin.Text = (min / 1024) > 1 ? (min / 1024).ToString() : "1";
                        ramMax.Text = (max / 1024) > 1 ? (max / 1024).ToString() : "1";
                    } else {
                        ramMin.Text = "1";
                        ramMax.Text = "1";
                    }
                    break;
                    case "MB":
                    if (min > 0 && max > 0) {
                        ramMin.Text = (min * 1024).ToString();
                        ramMax.Text = (max * 1024).ToString();
                    } else {
                        ramMin.Text = "1024";
                        ramMax.Text = "1024";
                    }
                    break;
                    default:
                    throw new Exception("Something went wrong!");
                }
            } else {
                MessageBox.Show("Please enter a valid number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
