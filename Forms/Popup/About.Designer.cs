namespace Server_Wrapper.Forms {
    partial class About {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.ghLink = new System.Windows.Forms.LinkLabel();
            this.srcCodeLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ghLink
            // 
            this.ghLink.AutoSize = true;
            this.ghLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ghLink.Location = new System.Drawing.Point(12, 307);
            this.ghLink.Name = "ghLink";
            this.ghLink.Size = new System.Drawing.Size(38, 13);
            this.ghLink.TabIndex = 1;
            this.ghLink.TabStop = true;
            this.ghLink.Text = "Github";
            this.ghLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ghLink_LinkClicked);
            // 
            // srcCodeLink
            // 
            this.srcCodeLink.AutoSize = true;
            this.srcCodeLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.srcCodeLink.Location = new System.Drawing.Point(56, 307);
            this.srcCodeLink.Name = "srcCodeLink";
            this.srcCodeLink.Size = new System.Drawing.Size(69, 13);
            this.srcCodeLink.TabIndex = 2;
            this.srcCodeLink.TabStop = true;
            this.srcCodeLink.Text = "Source Code";
            this.srcCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.srcCodeLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 273);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 329);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.srcCodeLink);
            this.Controls.Add(this.ghLink);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel ghLink;
        private System.Windows.Forms.LinkLabel srcCodeLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}