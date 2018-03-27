namespace ClashDetective
{
    partial class ResultGroupColoringControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DrawGroupCheckBox = new System.Windows.Forms.CheckBox();
            this.FillColorDialogButton = new System.Windows.Forms.Button();
            this.OutlineColorDialogButton = new System.Windows.Forms.Button();
            this.GroupCountLabel = new System.Windows.Forms.Label();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // DrawGroupCheckBox
            // 
            this.DrawGroupCheckBox.AutoEllipsis = true;
            this.DrawGroupCheckBox.Checked = true;
            this.DrawGroupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawGroupCheckBox.Location = new System.Drawing.Point(0, 0);
            this.DrawGroupCheckBox.Name = "DrawGroupCheckBox";
            this.DrawGroupCheckBox.Size = new System.Drawing.Size(128, 32);
            this.DrawGroupCheckBox.TabIndex = 0;
            this.DrawGroupCheckBox.Text = "Group Name";
            this.DrawGroupCheckBox.UseVisualStyleBackColor = false;
            this.DrawGroupCheckBox.CheckedChanged += new System.EventHandler(this.DrawGroupCheckBox_CheckedChanged);
            // 
            // FillColorDialogButton
            // 
            this.FillColorDialogButton.Location = new System.Drawing.Point(176, 8);
            this.FillColorDialogButton.Name = "FillColorDialogButton";
            this.FillColorDialogButton.Size = new System.Drawing.Size(32, 16);
            this.FillColorDialogButton.TabIndex = 2;
            this.FillColorDialogButton.UseVisualStyleBackColor = true;
            this.FillColorDialogButton.Click += new System.EventHandler(this.FillColorDialogButton_Click);
            // 
            // OutlineColorDialogButton
            // 
            this.OutlineColorDialogButton.Location = new System.Drawing.Point(216, 8);
            this.OutlineColorDialogButton.Name = "OutlineColorDialogButton";
            this.OutlineColorDialogButton.Size = new System.Drawing.Size(32, 16);
            this.OutlineColorDialogButton.TabIndex = 3;
            this.OutlineColorDialogButton.UseVisualStyleBackColor = true;
            this.OutlineColorDialogButton.Click += new System.EventHandler(this.OutlineColorDialogButton_Click);
            // 
            // GroupCountLabel
            // 
            this.GroupCountLabel.AutoSize = true;
            this.GroupCountLabel.Location = new System.Drawing.Point(128, 8);
            this.GroupCountLabel.Name = "GroupCountLabel";
            this.GroupCountLabel.Size = new System.Drawing.Size(43, 13);
            this.GroupCountLabel.TabIndex = 1;
            this.GroupCountLabel.Text = "(99999)";
            // 
            // ResultGroupColoringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupCountLabel);
            this.Controls.Add(this.OutlineColorDialogButton);
            this.Controls.Add(this.FillColorDialogButton);
            this.Controls.Add(this.DrawGroupCheckBox);
            this.Name = "ResultGroupColoringControl";
            this.Size = new System.Drawing.Size(248, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DrawGroupCheckBox;
        private System.Windows.Forms.Button FillColorDialogButton;
        private System.Windows.Forms.Button OutlineColorDialogButton;
        private System.Windows.Forms.Label GroupCountLabel;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}
