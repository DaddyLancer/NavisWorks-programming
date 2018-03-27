namespace ClashDetective
{
    partial class TestColoringControl
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
            this.DrawTestCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupCountLabel = new System.Windows.Forms.Label();
            this.ShowAllButton = new System.Windows.Forms.Button();
            this.ShowNoneButton = new System.Windows.Forms.Button();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // DrawTestCheckBox
            // 
            this.DrawTestCheckBox.AutoEllipsis = true;
            this.DrawTestCheckBox.Checked = true;
            this.DrawTestCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawTestCheckBox.Location = new System.Drawing.Point(0, 0);
            this.DrawTestCheckBox.Name = "DrawTestCheckBox";
            this.DrawTestCheckBox.Size = new System.Drawing.Size(104, 24);
            this.DrawTestCheckBox.TabIndex = 0;
            this.DrawTestCheckBox.Text = "Test Name";
            this.DrawTestCheckBox.UseVisualStyleBackColor = true;
            this.DrawTestCheckBox.CheckedChanged += new System.EventHandler(this.DrawTestCheckBox_CheckedChanged);
            // 
            // GroupCountLabel
            // 
            this.GroupCountLabel.AutoSize = true;
            this.GroupCountLabel.Location = new System.Drawing.Point(104, 4);
            this.GroupCountLabel.Name = "GroupCountLabel";
            this.GroupCountLabel.Size = new System.Drawing.Size(37, 13);
            this.GroupCountLabel.TabIndex = 1;
            this.GroupCountLabel.Text = "(9999)";
            // 
            // ShowAllButton
            // 
            this.ShowAllButton.Location = new System.Drawing.Point(144, 2);
            this.ShowAllButton.Name = "ShowAllButton";
            this.ShowAllButton.Size = new System.Drawing.Size(56, 20);
            this.ShowAllButton.TabIndex = 2;
            this.ShowAllButton.Text = "All";
            this.ShowAllButton.UseVisualStyleBackColor = true;
            this.ShowAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // ShowNoneButton
            // 
            this.ShowNoneButton.Location = new System.Drawing.Point(208, 2);
            this.ShowNoneButton.Name = "ShowNoneButton";
            this.ShowNoneButton.Size = new System.Drawing.Size(56, 20);
            this.ShowNoneButton.TabIndex = 3;
            this.ShowNoneButton.Text = "None";
            this.ShowNoneButton.UseVisualStyleBackColor = true;
            this.ShowNoneButton.Click += new System.EventHandler(this.ShowNoneButton_Click);
            // 
            // TestColoringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowNoneButton);
            this.Controls.Add(this.ShowAllButton);
            this.Controls.Add(this.GroupCountLabel);
            this.Controls.Add(this.DrawTestCheckBox);
            this.Name = "TestColoringControl";
            this.Size = new System.Drawing.Size(264, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DrawTestCheckBox;
        private System.Windows.Forms.Label GroupCountLabel;
        private System.Windows.Forms.Button ShowAllButton;
        private System.Windows.Forms.Button ShowNoneButton;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}
