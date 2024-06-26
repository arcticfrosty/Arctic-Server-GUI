﻿namespace Server_Wrapper {
    partial class MainFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.sendBtn = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.mainStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBtn = new System.Windows.Forms.Button();
            this.killBtn = new System.Windows.Forms.Button();
            this.scrollBox = new System.Windows.Forms.CheckBox();
            this.restartBtn = new System.Windows.Forms.Button();
            this.serv_Name = new System.Windows.Forms.Label();
            this.ramUsageLabel = new System.Windows.Forms.Label();
            this.ramBar = new System.Windows.Forms.ProgressBar();
            this.statLabel = new System.Windows.Forms.Label();
            this.openServerFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenu.SuspendLayout();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.Location = new System.Drawing.Point(672, 384);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(100, 25);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.AutoWordSelection = true;
            this.txtOutput.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtOutput.ContextMenuStrip = this.conMenu;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(12, 85);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ShortcutsEnabled = false;
            this.txtOutput.Size = new System.Drawing.Size(760, 293);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.TabStop = false;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.ToolTipText = "Copy selected text to clipboard.";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 384);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(469, 25);
            this.txtInput.TabIndex = 4;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.Location = new System.Drawing.Point(566, 384);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 25);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startBtn.Location = new System.Drawing.Point(672, 27);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 25);
            this.startBtn.TabIndex = 6;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // mainStrip
            // 
            this.mainStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(784, 24);
            this.mainStrip.TabIndex = 7;
            this.mainStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openServerFolderToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalSettingToolStripMenuItem,
            this.flagsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Settings";
            // 
            // globalSettingToolStripMenuItem
            // 
            this.globalSettingToolStripMenuItem.Name = "globalSettingToolStripMenuItem";
            this.globalSettingToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.globalSettingToolStripMenuItem.Text = "Server Settings";
            this.globalSettingToolStripMenuItem.Click += new System.EventHandler(this.globalSettingToolStripMenuItem_Click);
            // 
            // flagsToolStripMenuItem
            // 
            this.flagsToolStripMenuItem.Name = "flagsToolStripMenuItem";
            this.flagsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.flagsToolStripMenuItem.Text = "Java Setting";
            this.flagsToolStripMenuItem.Click += new System.EventHandler(this.jvm_settingToolStripMenuItem_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBtn.Location = new System.Drawing.Point(672, 54);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(100, 25);
            this.stopBtn.TabIndex = 8;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // killBtn
            // 
            this.killBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.killBtn.ForeColor = System.Drawing.Color.Red;
            this.killBtn.Location = new System.Drawing.Point(566, 54);
            this.killBtn.Name = "killBtn";
            this.killBtn.Size = new System.Drawing.Size(100, 25);
            this.killBtn.TabIndex = 9;
            this.killBtn.Text = "&Kill";
            this.killBtn.UseVisualStyleBackColor = true;
            this.killBtn.Click += new System.EventHandler(this.killBtn_Click);
            // 
            // scrollBox
            // 
            this.scrollBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollBox.AutoSize = true;
            this.scrollBox.Checked = true;
            this.scrollBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scrollBox.Location = new System.Drawing.Point(487, 389);
            this.scrollBox.Name = "scrollBox";
            this.scrollBox.Size = new System.Drawing.Size(77, 17);
            this.scrollBox.TabIndex = 11;
            this.scrollBox.Text = "Auto Scroll";
            this.scrollBox.UseVisualStyleBackColor = true;
            // 
            // restartBtn
            // 
            this.restartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restartBtn.Location = new System.Drawing.Point(566, 27);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(100, 25);
            this.restartBtn.TabIndex = 12;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // serv_Name
            // 
            this.serv_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.serv_Name.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serv_Name.Location = new System.Drawing.Point(12, 27);
            this.serv_Name.Name = "serv_Name";
            this.serv_Name.Size = new System.Drawing.Size(168, 52);
            this.serv_Name.TabIndex = 13;
            this.serv_Name.Text = "Console";
            this.serv_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ramUsageLabel
            // 
            this.ramUsageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ramUsageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ramUsageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramUsageLabel.Location = new System.Drawing.Point(186, 27);
            this.ramUsageLabel.Name = "ramUsageLabel";
            this.ramUsageLabel.Size = new System.Drawing.Size(342, 26);
            this.ramUsageLabel.TabIndex = 16;
            this.ramUsageLabel.Text = "Memory Usage:";
            this.ramUsageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ramBar
            // 
            this.ramBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ramBar.BackColor = System.Drawing.SystemColors.Control;
            this.ramBar.Enabled = false;
            this.ramBar.Location = new System.Drawing.Point(186, 56);
            this.ramBar.MarqueeAnimationSpeed = 0;
            this.ramBar.Name = "ramBar";
            this.ramBar.Size = new System.Drawing.Size(374, 23);
            this.ramBar.Step = 100;
            this.ramBar.TabIndex = 17;
            // 
            // statLabel
            // 
            this.statLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statLabel.BackColor = System.Drawing.Color.Red;
            this.statLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statLabel.ForeColor = System.Drawing.Color.Transparent;
            this.statLabel.Location = new System.Drawing.Point(534, 27);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(26, 26);
            this.statLabel.TabIndex = 18;
            this.statLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openServerFolderToolStripMenuItem
            // 
            this.openServerFolderToolStripMenuItem.Name = "openServerFolderToolStripMenuItem";
            this.openServerFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openServerFolderToolStripMenuItem.Text = "Open Server Folder";
            this.openServerFolderToolStripMenuItem.Click += new System.EventHandler(this.openServerFolderToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.ramBar);
            this.Controls.Add(this.ramUsageLabel);
            this.Controls.Add(this.serv_Name);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.scrollBox);
            this.Controls.Add(this.killBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.mainStrip);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.sendBtn);
            this.MainMenuStrip = this.mainStrip;
            this.MinimumSize = new System.Drawing.Size(800, 460);
            this.Name = "MainFrm";
            this.Text = "Arctic_\'s Server GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.conMenu.ResumeLayout(false);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.MenuStrip mainStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button killBtn;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalSettingToolStripMenuItem;
        private System.Windows.Forms.CheckBox scrollBox;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagsToolStripMenuItem;
        private System.Windows.Forms.Label ramUsageLabel;
        private System.Windows.Forms.ProgressBar ramBar;
        private System.Windows.Forms.Label statLabel;
        public System.Windows.Forms.Label serv_Name;
        private System.Windows.Forms.ToolStripMenuItem openServerFolderToolStripMenuItem;
    }
}

