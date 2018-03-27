namespace MessageSenderReceiver
{
    partial class MessageReceived
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
            this.label1 = new System.Windows.Forms.Label();
            this.messageContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.returnValue = new System.Windows.Forms.NumericUpDown();
            this.close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.returnValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message Received:";
            // 
            // messageContent
            // 
            this.messageContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.messageContent.Location = new System.Drawing.Point(15, 29);
            this.messageContent.Multiline = true;
            this.messageContent.Name = "messageContent";
            this.messageContent.ReadOnly = true;
            this.messageContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.messageContent.Size = new System.Drawing.Size(257, 108);
            this.messageContent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Return value to message sender";
            // 
            // returnValue
            // 
            this.returnValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnValue.Location = new System.Drawing.Point(15, 157);
            this.returnValue.Name = "returnValue";
            this.returnValue.Size = new System.Drawing.Size(65, 20);
            this.returnValue.TabIndex = 4;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(197, 157);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 5;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // MessageReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.close);
            this.Controls.Add(this.returnValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageContent);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(292, 231);
            this.Name = "MessageReceived";
            this.Text = "Message Received";
            ((System.ComponentModel.ISupportInitialize)(this.returnValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox messageContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown returnValue;
        private System.Windows.Forms.Button close;
    }
}