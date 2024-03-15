﻿using Server_Wrapper.Forms;
using Server_Wrapper.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                    maxRam = Util.getRamInMB();
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
                        ramBar.Value = ramBarValue;
                    } else {
                        ramBar.Value = 100;
                    }
                } else {
                    maxRam = Util.getRamInMB();
                    ramUsageLabel.ForeColor = Color.Black;
                    ramUsageLabel.Text = $"Memory Usage: 0MB / {maxRam}MB";
                    ramBar.Value = 0;
                }
            };
            timer.Start();
        }

        //Util

        protected void cmdExecute() {
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
                if (dir.Contains(" ")) {
                    MessageBox.Show("Your path contains space!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                statLabel.BackColor = Color.Yellow;
                int ramMinRaw = Properties.Settings.Default.ramMin;
                int ramMaxRaw = Properties.Settings.Default.ramMax;
                char ramUnit = Util.getRamUnit();
                string serverFile = Properties.Settings.Default.serverFile;
                string serverJar = $"{dir}{serverFile}";
                string ramMin = $"{ramMinRaw}{ramUnit}";
                string ramMax = $"{ramMaxRaw}{ramUnit}";
                string java_path = Properties.Settings.Default.java_path;
                string jvm_args = Properties.Settings.Default.jvm_args;
                txtOutput.Clear();
                UpdateRichTextBox($"Server Directory: {serverJar}");
                UpdateRichTextBox($"Allocated Ram: \t{ramMax}\n");
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
                process.OutputDataReceived += (s, data) => {
                    UpdateRichTextBox(data.Data);
                    if (data.Data != null && data.Data.Contains("Done (")) {
                        UpdateRichTextBox($"[{timeStamp()}] [System] Server is successfully started.");
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
                    UpdateRichTextBox($"[{timeStamp()}] [System] Server is successfully stopped.");
                    statLabel.Invoke((MethodInvoker)delegate {
                        statLabel.BackColor = Color.Red;
                    });
                };
                cmdHistory.Clear();
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
            } else {
                MessageBox.Show("Server is already running!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Util.showFrm(frm, true, true);
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
                    Application.Exit();
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
                UpdateRichTextBox($"[{timeStamp()}] [System] Process killed successfully.");
            } else {
                MessageBox.Show("Server is offline!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new About();
            Util.showFrm(frm, true, true);
        }
        private void jvm_settingToolStripMenuItem_Click(object sender, EventArgs e) {
            Form frm = new Forms.Jvm_args();
            Util.showFrm(frm, true, true);
        }
    }
}