using Server_Wrapper.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Server_Wrapper {
    public partial class MainFrm : Form {

        private Process process;
        private List<string> cmdHistory = new List<string>();
        private int cmdIndex = 0;

        public MainFrm() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtInput.KeyDown += txtInput_KeyDown;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                if (process != null && !process.HasExited) {
                    process.Refresh();
                    long memoryInBytes = process.WorkingSet64;
                    int memoryInMegabytes = (int) memoryInBytes / 1048576;
                    ramUsageLabel.Text = $"Memory usage: {memoryInMegabytes}MB";
                } else {
                    ramUsageLabel.Text = "Memory usage: 0MB";
                }
            };
            timer.Start();
        }

        //Utils

        protected void execCmd() {
            if (process != null && !process.HasExited) {
                process.StandardInput.WriteLine(txtInput.Text);
                if (!cmdHistory.Contains(txtInput.Text)) {
                    if (cmdHistory.Count >= 32) {
                        cmdHistory.RemoveAt(0);
                    }
                    cmdHistory.Add(txtInput.Text);
                }
                cmdIndex = cmdHistory.Count;
                txtInput.Clear();
            } else if (!string.IsNullOrEmpty(txtInput.Text)) {
                txtInput.Clear();
                MessageBox.Show("Server is offline!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void startServer() {
            if (process == null || process.HasExited) {
                string rawdir = AppDomain.CurrentDomain.BaseDirectory;
                string dir = rawdir.Replace("\\", "/");

                int ramMinRaw = Properties.Settings.Default.ramMin;
                int ramMaxRaw = Properties.Settings.Default.ramMax;
                char ramUnit;
                string serverFile = Properties.Settings.Default.serverFile;
                string serverJar = $"{dir}{serverFile}";

                switch (Properties.Settings.Default.ramUnit) {
                    case "GB":
                    ramUnit = 'G';
                    break;
                    case "MB":
                    ramUnit = 'M';
                    break;
                    default: throw new Exception("Unable to set Ram allocation!");
                }

                string ramMin = $"{ramMinRaw}{ramUnit}";
                string ramMax = $"{ramMaxRaw}{ramUnit}";

                string java_path = Properties.Settings.Default.java_path;

                string jvm_args = Properties.Settings.Default.jvm_args;

                txtOutput.Clear();

                UpdateRichTextBox("==============================================================================================");
                UpdateRichTextBox($"Server Directory: {serverJar}");
                UpdateRichTextBox($"Allocated Ram: \t{ramMax}");
                UpdateRichTextBox("==============================================================================================");

                ProcessStartInfo startInfo = new ProcessStartInfo {
                    FileName = java_path,
                    Arguments = jvm_args.Replace("{ramMin}", ramMin).Replace("{ramMax}", ramMax).Replace("{serverJar}", serverJar),
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = dir
                };

                process = new Process { StartInfo = startInfo };

                process.OutputDataReceived += (s, data) => UpdateRichTextBox(data.Data);
                process.Exited += (s, data) => UpdateRichTextBox($"[{timeStamp()}] [System] Server is successfully stopped.");

                cmdHistory.Clear();

                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
            } else {
                MessageBox.Show("Server is already running!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected static void showFrm(Form frm, bool resize) {
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (!resize) {
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            frm.Show();
        }
        protected static void showDiag(Form frm, bool resize) {
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (!resize) {
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            frm.ShowDialog();
        }

        private void UpdateRichTextBox(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(UpdateRichTextBox), new object[] { text });
                return;
            }
            txtOutput.AppendText(text + Environment.NewLine);
            if (scrollBox.Checked) {
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        private static string timeStamp() {
            string time = DateTime.Now.ToString("HH:mm:ss");
            return time;
        }

        //Buttons

        private void sendBtn_Click(object sender, EventArgs e) {
            execCmd();
        }

        private void clearBtn_Click(object sender, EventArgs e) {
            txtInput.Clear();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                execCmd();
                e.SuppressKeyPress = true;
            }
            if (process != null && !process.HasExited) {
                if (e.KeyCode == Keys.Up) {
                    if (cmdIndex > 0) {
                        cmdIndex--;
                        txtInput.Text = cmdHistory[cmdIndex];
                    }
                    e.Handled = true;
                } else if (e.KeyCode == Keys.Down) {
                    if (cmdIndex < cmdHistory.Count - 1) {
                        cmdIndex++;
                        txtInput.Text = cmdHistory[cmdIndex];
                    }
                    e.Handled = true;
                }
                txtInput.SelectionStart = txtInput.Text.Length;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtOutput.SelectedText)) {
                Clipboard.SetText(txtOutput.SelectedText);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult message = MessageBox.Show("Do you want to exit?\nThis will force the server to terminate.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (message == DialogResult.Yes) {
                if (process != null && !process.HasExited) {
                    process.Kill();
                }
                Application.Exit();
            }
        }
        private void globalSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new Server_Settings();
            showDiag(frm, false);
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                DialogResult message = MessageBox.Show("Do you want to exit?\nThis will force the server to terminate.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.No) {
                    e.Cancel = true;
                } else {
                    if (process != null && !process.HasExited) {
                        process.Kill();
                    }
                    this.FormClosing -= MainFrm_FormClosing;
                }
            }
        }

        private void startBtn_Click(object sender, EventArgs e) {
            startServer();
        }

        private void stopBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                process.StandardInput.WriteLine("stop");
            } else {
                MessageBox.Show("Server is offline!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restartBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                process.StandardInput.WriteLine("stop");
                process.WaitForExit(5000);

                if (!process.HasExited) {
                    process.Kill();
                }
            }
            startServer();
        }

        private void killBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                Process killer = new Process();
                killer.StartInfo.FileName = "taskkill";
                killer.StartInfo.Arguments = $"/PID {process.Id} /T /F";
                killer.Start();

                process.Kill();

                process = null;
                UpdateRichTextBox($"[{timeStamp()}] [System] Process killed successfully.");
            } else {
                MessageBox.Show("Server is offline!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new About();
            showDiag(frm, true);
        }

        private void jvm_settingToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new Forms.Jvm_args();
            showDiag(frm, true);
        }
    }
}