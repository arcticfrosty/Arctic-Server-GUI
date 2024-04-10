using Server_Wrapper.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Server_Wrapper.Forms {
    public partial class Jvm_args : Form {
        public Jvm_args() {
            InitializeComponent();
        }
        private void Jvm_args_Load(object sender, EventArgs e) {
            flagtxtBox.Text = Properties.Settings.Default.jvm_args;
            javaPathList.Text = Properties.Settings.Default.java_path;
            var javaPaths = Utils.FindJavaInstallations();
            foreach (var javaPath in javaPaths) {
                javaPathList.Items.Add($"{javaPath}\\bin\\java.exe");
            }
        }
        private void saveBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Confirm save?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }
            string checkedFlags = flagtxtBox.Text.Replace("java ", "")
                    .Replace("--nogui", "nogui")
                    .Replace("server.jar", "{serverJar}");
            if (!(flagtxtBox.Text.Contains("{ramMin}") || flagtxtBox.Text.Contains("{ramMax}") || flagtxtBox.Text.Contains("{serverJar}"))) {
                //MessageBox.Show("Since you didn't replaced the variables, we have replace it for you.", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                Regex regexMin = new Regex(@"-Xms(\d+)[MG]");
                Regex regexMax = new Regex(@"-Xmx(\d+)[MG]");
                string output = regexMin.Replace(regexMax.Replace(checkedFlags, "-Xmx{ramMax}"), "-Xms{ramMin}");
                checkedFlags = output;
            }
            flagtxtBox.Text = checkedFlags;
            Properties.Settings.Default.jvm_args = flagtxtBox.Text;
            if (!string.IsNullOrEmpty(javaPathList.Text)) {
                Properties.Settings.Default.java_path = javaPathList.Text;
            } else {
                Properties.Settings.Default.java_path = null;
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("Saved sucessfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void resetBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Confirm reset?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string def = "-Xms{ramMin} -Xmx{ramMax} --add-modules=jdk.incubator.vector -jar {serverJar} nogui";
                flagtxtBox.Text = def;
                Properties.Settings.Default.jvm_args = def;
                Properties.Settings.Default.Save();
                MessageBox.Show("Arguments has been reset.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void helpBtn_Click(object sender, EventArgs e) {
            MessageBox.Show("{minRam} is the minimum Ram allocated to your server." +
                "\n{maxRam} is the maximum Ram allocated to your server." +
                "\n{serverJar} is the name of your JAR file." +
                "\n\nDo not touch if you don't know what it does." +
                "\nChanging this may break the memory monitoring.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(flagtxtBox.SelectedText)) {
                flagtxtBox.Copy();
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(Clipboard.GetText())) {
                flagtxtBox.Paste();
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(flagtxtBox.SelectedText)) {
                flagtxtBox.Cut();
            }
        }
        private void flagBtn_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://flags.sh/");
        }
    }
}
