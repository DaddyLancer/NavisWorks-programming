namespace ClashDetective
{
    partial class GenerateMatrixDialog
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
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.RunAfterCheckBox = new System.Windows.Forms.CheckBox();
            this.main_label = new System.Windows.Forms.Label();
            this.TemplateTestComboBox = new System.Windows.Forms.ComboBox();
            this.UseTemplateCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearExistingCheckBox = new System.Windows.Forms.CheckBox();
            this.GenerateNewTestsCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdateAllTestsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(16, 264);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(96, 26);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(176, 264);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(96, 26);
            this.button_cancel.TabIndex = 9;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // RunAfterCheckBox
            // 
            this.RunAfterCheckBox.AutoSize = true;
            this.RunAfterCheckBox.Location = new System.Drawing.Point(32, 232);
            this.RunAfterCheckBox.Name = "RunAfterCheckBox";
            this.RunAfterCheckBox.Size = new System.Drawing.Size(154, 17);
            this.RunAfterCheckBox.TabIndex = 7;
            this.RunAfterCheckBox.Text = "Run new tests immediately.";
            this.RunAfterCheckBox.UseVisualStyleBackColor = true;
            // 
            // main_label
            // 
            this.main_label.Location = new System.Drawing.Point(8, 8);
            this.main_label.Name = "main_label";
            this.main_label.Size = new System.Drawing.Size(272, 32);
            this.main_label.TabIndex = 0;
            this.main_label.Text = "The ClashMatrix plugin generates a clash test for each pair of models in the file" +
    ".";
            // 
            // TemplateTestComboBox
            // 
            this.TemplateTestComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TemplateTestComboBox.FormattingEnabled = true;
            this.TemplateTestComboBox.Location = new System.Drawing.Point(48, 200);
            this.TemplateTestComboBox.Name = "TemplateTestComboBox";
            this.TemplateTestComboBox.Size = new System.Drawing.Size(224, 21);
            this.TemplateTestComboBox.TabIndex = 6;
            // 
            // UseTemplateCheckBox
            // 
            this.UseTemplateCheckBox.AutoSize = true;
            this.UseTemplateCheckBox.Location = new System.Drawing.Point(32, 176);
            this.UseTemplateCheckBox.Name = "UseTemplateCheckBox";
            this.UseTemplateCheckBox.Size = new System.Drawing.Size(168, 17);
            this.UseTemplateCheckBox.TabIndex = 5;
            this.UseTemplateCheckBox.Text = "Use settings from existing test:";
            this.UseTemplateCheckBox.UseVisualStyleBackColor = true;
            this.UseTemplateCheckBox.CheckedChanged += new System.EventHandler(this.UseTemplateCheckBox_CheckedChanged);
            // 
            // ClearExistingCheckBox
            // 
            this.ClearExistingCheckBox.AutoSize = true;
            this.ClearExistingCheckBox.Location = new System.Drawing.Point(16, 128);
            this.ClearExistingCheckBox.Name = "ClearExistingCheckBox";
            this.ClearExistingCheckBox.Size = new System.Drawing.Size(173, 17);
            this.ClearExistingCheckBox.TabIndex = 3;
            this.ClearExistingCheckBox.Text = "Clear existing ClashMatrix tests.";
            this.ClearExistingCheckBox.UseVisualStyleBackColor = true;
            // 
            // GenerateNewTestsCheckBox
            // 
            this.GenerateNewTestsCheckBox.AutoSize = true;
            this.GenerateNewTestsCheckBox.Checked = true;
            this.GenerateNewTestsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GenerateNewTestsCheckBox.Location = new System.Drawing.Point(16, 152);
            this.GenerateNewTestsCheckBox.Name = "GenerateNewTestsCheckBox";
            this.GenerateNewTestsCheckBox.Size = new System.Drawing.Size(159, 17);
            this.GenerateNewTestsCheckBox.TabIndex = 4;
            this.GenerateNewTestsCheckBox.Text = "Generate a new set of tests.";
            this.GenerateNewTestsCheckBox.UseVisualStyleBackColor = true;
            this.GenerateNewTestsCheckBox.CheckedChanged += new System.EventHandler(this.GenerateNewTestsCheckBox_CheckedChanged);
            // 
            // UpdateAllTestsButton
            // 
            this.UpdateAllTestsButton.Location = new System.Drawing.Point(8, 24);
            this.UpdateAllTestsButton.Name = "UpdateAllTestsButton";
            this.UpdateAllTestsButton.Size = new System.Drawing.Size(256, 26);
            this.UpdateAllTestsButton.TabIndex = 1;
            this.UpdateAllTestsButton.Text = "Update all ClashMatrix Tests";
            this.UpdateAllTestsButton.UseVisualStyleBackColor = true;
            this.UpdateAllTestsButton.Click += new System.EventHandler(this.UpdateAllTestsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateAllTestsButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run Tests";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 194);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Tests";
            // 
            // GenerateMatrixDialog
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(288, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GenerateNewTestsCheckBox);
            this.Controls.Add(this.ClearExistingCheckBox);
            this.Controls.Add(this.UseTemplateCheckBox);
            this.Controls.Add(this.TemplateTestComboBox);
            this.Controls.Add(this.main_label);
            this.Controls.Add(this.RunAfterCheckBox);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateMatrixDialog";
            this.Text = "ClashMatrix";
            this.Shown += new System.EventHandler(this.GenerateMatrixDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox RunAfterCheckBox;
        private System.Windows.Forms.Label main_label;
        private System.Windows.Forms.ComboBox TemplateTestComboBox;
        private System.Windows.Forms.CheckBox UseTemplateCheckBox;
        private System.Windows.Forms.CheckBox ClearExistingCheckBox;
        private System.Windows.Forms.CheckBox GenerateNewTestsCheckBox;
        private System.Windows.Forms.Button UpdateAllTestsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}