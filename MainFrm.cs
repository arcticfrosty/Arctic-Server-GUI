using Server_Wrapper.Forms;
using Server_Wrapper.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Server_Wrapper {
    public partial class MainFrm : Form {

        private Process process;
        private List<string> cmdHistory = new List<string>();
        private int cmdIndex = 0;

        //Main Function

        public MainFrm() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtInput.KeyDown += txtInput_KeyDown;
            bool i = false;
            int maxRam;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                if (process != null && !process.HasExited) {
                    process.Refresh();
                    maxRam = Utils.getRamInMB();
                    long memoryInBytes = process.WorkingSet64;
                    int memoryInMegabytes = (int)memoryInBytes / 1048576;
                    if (memoryInMegabytes <= maxRam) {
                        ramUsageLabel.Text = $"Memory Usage: {memoryInMegabytes}MB / {maxRam}MB";
                        ramUsageLabel.ForeColor = Color.Black;
                    } else {
                        int overloadRam = ((memoryInMegabytes - maxRam) * 100) / maxRam;
                        ramUsageLabel.Text = $"Memory Usage: {memoryInMegabytes}MB / {maxRam}MB (+{overloadRam}% RAM Overload!)";
                        if (i) {
                            ramUsageLabel.ForeColor = Color.Red;
                            i = false;
                        } else {
                            ramUsageLabel.ForeColor = Color.Black;
                            i = true;
                        }
                    }
                    int ramBarValue = (int)((memoryInMegabytes * 100) / maxRam);
                    if (ramBarValue <= 100) {
                        if (ramBarValue < 0) {
                            ramBarValue = -(ramBarValue);
                        }
                        ramBar.Value = ramBarValue;
                    } else {
                        ramBar.Value = 100;
                    }
                } else {
                    maxRam = Utils.getRamInMB();
                    ramUsageLabel.ForeColor = Color.Black;
                    ramUsageLabel.Text = $"Memory Usage: 0MB / {maxRam}MB";
                    ramBar.Value = 0;
                }
            };
            timer.Start();
        }

        //Utility

        protected void cmdExecute() {
            if (process != null && !process.HasExited) {
                string input = txtInput.Text.Replace("/", "");
                process.StandardInput.WriteLine(input);
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
        protected void StartServer() {
            if (process == null || process.HasExited) {
                //Stopwatch timer = new Stopwatch();
                string rawDir = AppDomain.CurrentDomain.BaseDirectory;
                string dir = rawDir.Replace("\\", "/");
                if (dir.Contains(" ")) {
                    MessageBox.Show("Your path contains space!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string serv_path = $"{dir}";
                string eulaFile = "eula.txt";
                string fulleulaPath = Path.Combine(serv_path, eulaFile);
                string serverFile = Properties.Settings.Default.serverFile;
                string serverJar = Path.Combine(serv_path, serverFile);
                if (!File.Exists(serverJar)) {
                    MessageBox.Show($"{serverFile} does not exist in the current directory.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                statLabel.BackColor = Color.Yellow;
                if (!File.Exists(fulleulaPath)) {
                    if (MessageBox.Show("Do you agree to Mojang EULA?.\nGo to https://account.mojang.com/documents/minecraft_eula for more info.",
                        "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        using (StreamWriter sw = File.CreateText(fulleulaPath)) {
                            sw.WriteLine("#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula).");
                            sw.WriteLine("eula=true");
                        }
                    } else {
                        statLabel.Invoke((MethodInvoker)delegate {
                            statLabel.BackColor = Color.Red;
                        });
                        return;
                    }
                }
                string java_path = Properties.Settings.Default.java_path;
                if (string.IsNullOrEmpty(java_path)) {
                    MessageBox.Show("Java environment not found." +
                        "\nPlease set it in the Java setting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statLabel.Invoke((MethodInvoker)delegate {
                        statLabel.BackColor = Color.Red;
                    });
                    return;
                }
                //timer.Start();
                int ramMinRaw = Properties.Settings.Default.ramMin;
                int ramMaxRaw = Properties.Settings.Default.ramMax;
                char ramUnit = Utils.getRamUnit();
                string ramMin = $"{ramMinRaw}{ramUnit}";
                string ramMax = $"{ramMaxRaw}{ramUnit}";
                string jvm_args = Properties.Settings.Default.jvm_args;
                txtOutput.Clear();
                updateRichTextBox($"Server Directory: {serverJar}");
                updateRichTextBox($"Allocated Ram: \t{ramMax}\n");
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    FileName = java_path,
                    Arguments = jvm_args
                    .Replace("{ramMin}", ramMin)
                    .Replace("{ramMax}", ramMax)
                    .Replace("{serverJar}", serverJar),
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = dir
                };
                process = new Process { StartInfo = startInfo };
                process.OutputDataReceived += (s, data) => {
                    if (!string.IsNullOrEmpty(data.Data)) {
                        updateRichTextBox(data.Data);
                    }
                    if (data.Data != null && (data.Data.Contains("Done (") || data.Data.Contains("Server started on") || data.Data.Contains("listening on"))) {
                        updateRichTextBox($"[{Utils.timeStamp()} INFO]: Server is successfully started.");
                        statLabel.Invoke((MethodInvoker)delegate {
                            statLabel.BackColor = Color.LimeGreen;
                        });
                    } else if (data.Data != null && data.Data.Contains("Stopping the server")) {
                        statLabel.Invoke((MethodInvoker)delegate {
                            statLabel.BackColor = Color.Yellow;
                        });
                    }
                };
                process.Exited += (s, data) => {
                    updateRichTextBox($"[{Utils.timeStamp()} INFO]: Server is successfully stopped.");
                    statLabel.Invoke((MethodInvoker)delegate {
                        statLabel.BackColor = Color.Red;
                    });
                    //timer.Stop();
                    //int elapsedTime = (int)(timer.ElapsedMilliseconds / 1000);
                    //if (elapsedTime < 60) {
                    //    MessageBox.Show("Server Crashed!" +
                    //        $"\nServer exited in {elapsedTime} seconds." , "Crashed!" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    //}
                };
                cmdHistory.Clear();
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
            } else {
                MessageBox.Show("Server is already running!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void updateRichTextBox(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(updateRichTextBox), new object[] { text });
                return;
            }
            txtOutput.AppendText(text + Environment.NewLine);
            if (scrollBox.Checked) {
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        //Buttons and Others

        private void sendBtn_Click(object sender, EventArgs e) {
            cmdExecute();
        }
        private void clearBtn_Click(object sender, EventArgs e) {
            txtInput.Clear();
        }
        private void txtInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                cmdExecute();
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
                txtOutput.Copy();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult message = MessageBox.Show("Do you want to exit?" +
                "\nThis will force the server to terminate.",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes) {
                if (process != null && !process.HasExited) {
                    process.Kill();
                    process = null;
                }
                Application.Exit();
            }
        }
        private void globalSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new Server_Settings();
            Utils.showFrm(frm, false, true);
        }
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                DialogResult message = MessageBox.Show("Do you want to exit?" +
                    "\nThis will force the server to terminate.", "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.No) {
                    e.Cancel = true;
                } else {
                    if (process != null && !process.HasExited) {
                        process.Kill();
                        process = null;
                    }
                    //this.FormClosing -= MainFrm_FormClosing;
                    Application.Exit();
                }
            }
        }
        private void startBtn_Click(object sender, EventArgs e) {
            StartServer();
        }
        private void stopBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                process.StandardInput.WriteLine("stop");
                process.StandardInput.WriteLine("end");
            } else {
                MessageBox.Show("Server is offline!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void restartBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                process.StandardInput.WriteLine("stop");
                process.StandardInput.WriteLine("end");
                process.WaitForExit(5000);
                if (!process.HasExited) {
                    process.Kill();
                    process = null;
                }
            }
            StartServer();
        }
        private void killBtn_Click(object sender, EventArgs e) {
            if (process != null && !process.HasExited) {
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    FileName = "taskkill",
                    Arguments = $"/PID {process.Id} /T /F",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Process killer = new Process {
                    StartInfo = startInfo
                };
                killer.Start();
                process.Kill();
                process = null;
                updateRichTextBox($"[{Utils.timeStamp()} INFO]: Process killed successfully.");
            } else {
                MessageBox.Show("Server is offline!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new About();
            Utils.showFrm(frm, false, true);
        }
        private void jvm_settingToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new Jvm_args();
            Utils.showFrm(frm, true, true);
        }

        private void openServerFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            string rawDir = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start("explorer.exe", rawDir);
        }
    }
}