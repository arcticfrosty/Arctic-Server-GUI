namespace Server_Wrapper.Forms {
    partial class Server_Settings {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ramMax = new System.Windows.Forms.TextBox();
            this.ramUnit = new System.Windows.Forms.ComboBox();
            this.ramMin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverFile = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ramMax);
            this.groupBox1.Controls.Add(this.ramUnit);
            this.groupBox1.Controls.Add(this.ramMin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Memory Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maximum Memory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Minimum Memory";
            // 
            // ramMax
            // 
            this.ramMax.Location = new System.Drawing.Point(100, 44);
            this.ramMax.Name = "ramMax";
            this.ramMax.Size = new System.Drawing.Size(66, 20);
            this.ramMax.TabIndex = 2;
            this.ramMax.TabStop = false;
            // 
            // ramUnit
            // 
            this.ramUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ramUnit.FormattingEnabled = true;
            this.ramUnit.Items.AddRange(new object[] {
            "MB",
            "GB"});
            this.ramUnit.Location = new System.Drawing.Point(100, 70);
            this.ramUnit.Name = "ramUnit";
            this.ramUnit.Size = new System.Drawing.Size(66, 21);
            this.ramUnit.TabIndex = 1;
            this.ramUnit.TabStop = false;
            this.ramUnit.SelectedIndexChanged += new System.EventHandler(this.ramUnit_SelectedIndexChanged);
            this.ramUnit.Enter += new System.EventHandler(this.ramUnit_Enter);
            this.ramUnit.Leave += new System.EventHandler(this.ramUnit_Leave);
            // 
            // ramMin
            // 
            this.ramMin.Location = new System.Drawing.Point(100, 18);
            this.ramMin.Name = "ramMin";
            this.ramMin.Size = new System.Drawing.Size(66, 20);
            this.ramMin.TabIndex = 0;
            this.ramMin.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.serverFile);
            this.groupBox2.Location = new System.Drawing.Point(191, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 46);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name";
            // 
            // serverFile
            // 
            this.serverFile.Location = new System.Drawing.Point(47, 18);
            this.serverFile.Name = "serverFile";
            this.serverFile.Size = new System.Drawing.Size(146, 20);
            this.serverFile.TabIndex = 6;
            this.serverFile.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(191, 64);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(199, 47);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Server_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 121);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Server_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Server_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ramUnit;
        private System.Windows.Forms.TextBox ramMin;
        private System.Windows.Forms.TextBox ramMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox serverFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveBtn;
    }
}