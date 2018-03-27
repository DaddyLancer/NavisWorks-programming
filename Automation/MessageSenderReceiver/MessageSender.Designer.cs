namespace CallPlugin
{
    partial class MessageSender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendToPlugin = new System.Windows.Forms.Button();
            this.startNavisworks = new System.Windows.Forms.Button();
            this.closeNavisworks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageText
            // 
            this.messageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.messageText.Enabled = false;
            this.messageText.Location = new System.Drawing.Point(12, 77);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(245, 68);
            this.messageText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message to send to Plugin:";
            // 
            // sendToPlugin
            // 
            this.sendToPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sendToPlugin.Enabled = false;
            this.sendToPlugin.Location = new System.Drawing.Point(12, 151);
            this.sendToPlugin.Name = "sendToPlugin";
            this.sendToPlugin.Size = new System.Drawing.Size(245, 23);
            this.sendToPlugin.TabIndex = 2;
            this.sendToPlugin.Text = "Send To Plugin";
            this.sendToPlugin.UseVisualStyleBackColor = true;
            this.sendToPlugin.Click += new System.EventHandler(this.sendToPlugin_Click);
            // 
            // startNavisworks
            // 
            this.startNavisworks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startNavisworks.Location = new System.Drawing.Point(12, 23);
            this.startNavisworks.Name = "startNavisworks";
            this.startNavisworks.Size = new System.Drawing.Size(245, 23);
            this.startNavisworks.TabIndex = 3;
            this.startNavisworks.Text = "Start Navisworks";
            this.startNavisworks.UseVisualStyleBackColor = true;
            this.startNavisworks.Click += new System.EventHandler(this.startNavisworks_Click);
            // 
            // closeNavisworks
            // 
            this.closeNavisworks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.closeNavisworks.Enabled = false;
            this.closeNavisworks.Location = new System.Drawing.Point(12, 199);
            this.closeNavisworks.Name = "closeNavisworks";
            this.closeNavisworks.Size = new System.Drawing.Size(245, 23);
            this.closeNavisworks.TabIndex = 4;
            this.closeNavisworks.Text = "Close Navisworks";
            this.closeNavisworks.UseVisualStyleBackColor = true;
            this.closeNavisworks.Click += new System.EventHandler(this.closeNavisworks_Click);
            // 
            // MessageSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 232);
            this.Controls.Add(this.closeNavisworks);
            this.Controls.Add(this.startNavisworks);
            this.Controls.Add(this.sendToPlugin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageText);
            this.MinimumSize = new System.Drawing.Size(277, 266);
            this.Name = "MessageSender";
            this.Text = "MessageSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendToPlugin;
        private System.Windows.Forms.Button startNavisworks;
        private System.Windows.Forms.Button closeNavisworks;
    }
}

