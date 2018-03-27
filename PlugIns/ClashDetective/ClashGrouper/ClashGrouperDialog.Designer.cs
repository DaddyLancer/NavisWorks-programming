namespace ClashDetective
{
    partial class ClashGrouperDialog
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
            this.components = new System.ComponentModel.Container();
            this.TestSelectionListBox = new System.Windows.Forms.ListBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TestSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupByModelRadioButton = new System.Windows.Forms.RadioButton();
            this.ModelSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ModelSelectionLabel = new System.Windows.Forms.Label();
            this.GroupByAssignedToRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupByApprovedByRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupByLevelRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupingModeGroupBox = new System.Windows.Forms.GroupBox();
            this.RequiresGridsLabel = new System.Windows.Forms.Label();
            this.NumAttemptsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumAttemptsLabel = new System.Windows.Forms.Label();
            this.NumClustersLabel = new System.Windows.Forms.Label();
            this.NumClustersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GroupByClusterAnalysisRadioButton = new System.Windows.Forms.RadioButton();
            this.UngroupAllRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupByIntersectionRadioButton = new System.Windows.Forms.RadioButton();
            this.OtherSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.CatchAllGroupCheckBox = new System.Windows.Forms.CheckBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.BalloonToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.TestSelectionGroupBox.SuspendLayout();
            this.GroupingModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAttemptsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumClustersNumericUpDown)).BeginInit();
            this.OtherSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestSelectionListBox
            // 
            this.TestSelectionListBox.FormattingEnabled = true;
            this.TestSelectionListBox.Location = new System.Drawing.Point(8, 24);
            this.TestSelectionListBox.Name = "TestSelectionListBox";
            this.TestSelectionListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TestSelectionListBox.Size = new System.Drawing.Size(176, 108);
            this.TestSelectionListBox.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(8, 216);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(96, 26);
            this.OKButton.TabIndex = 15;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(512, 216);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(96, 26);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TestSelectionGroupBox
            // 
            this.TestSelectionGroupBox.Controls.Add(this.TestSelectionListBox);
            this.TestSelectionGroupBox.Location = new System.Drawing.Point(8, 8);
            this.TestSelectionGroupBox.Name = "TestSelectionGroupBox";
            this.TestSelectionGroupBox.Size = new System.Drawing.Size(192, 144);
            this.TestSelectionGroupBox.TabIndex = 0;
            this.TestSelectionGroupBox.TabStop = false;
            this.TestSelectionGroupBox.Text = "Group results from tests:";
            // 
            // GroupByModelRadioButton
            // 
            this.GroupByModelRadioButton.AutoSize = true;
            this.GroupByModelRadioButton.Checked = true;
            this.GroupByModelRadioButton.Location = new System.Drawing.Point(8, 24);
            this.GroupByModelRadioButton.Name = "GroupByModelRadioButton";
            this.GroupByModelRadioButton.Size = new System.Drawing.Size(218, 17);
            this.GroupByModelRadioButton.TabIndex = 5;
            this.GroupByModelRadioButton.TabStop = true;
            this.GroupByModelRadioButton.Text = "According to which component of model:";
            this.GroupByModelRadioButton.UseVisualStyleBackColor = true;
            // 
            // ModelSelectionComboBox
            // 
            this.ModelSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelSelectionComboBox.FormattingEnabled = true;
            this.ModelSelectionComboBox.Location = new System.Drawing.Point(24, 48);
            this.ModelSelectionComboBox.Name = "ModelSelectionComboBox";
            this.ModelSelectionComboBox.Size = new System.Drawing.Size(192, 21);
            this.ModelSelectionComboBox.TabIndex = 6;
            this.ModelSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.ModelSelectionComboBox_SelectedIndexChanged);
            // 
            // ModelSelectionLabel
            // 
            this.ModelSelectionLabel.AutoSize = true;
            this.ModelSelectionLabel.Location = new System.Drawing.Point(24, 72);
            this.ModelSelectionLabel.Name = "ModelSelectionLabel";
            this.ModelSelectionLabel.Size = new System.Drawing.Size(114, 13);
            this.ModelSelectionLabel.TabIndex = 6;
            this.ModelSelectionLabel.Text = "is involved in the clash";
            // 
            // GroupByAssignedToRadioButton
            // 
            this.GroupByAssignedToRadioButton.AutoSize = true;
            this.GroupByAssignedToRadioButton.Location = new System.Drawing.Point(240, 144);
            this.GroupByAssignedToRadioButton.Name = "GroupByAssignedToRadioButton";
            this.GroupByAssignedToRadioButton.Size = new System.Drawing.Size(146, 17);
            this.GroupByAssignedToRadioButton.TabIndex = 13;
            this.GroupByAssignedToRadioButton.TabStop = true;
            this.GroupByAssignedToRadioButton.Text = "By \"Assigned to\" property";
            this.GroupByAssignedToRadioButton.UseVisualStyleBackColor = true;
            // 
            // GroupByApprovedByRadioButton
            // 
            this.GroupByApprovedByRadioButton.AutoSize = true;
            this.GroupByApprovedByRadioButton.Location = new System.Drawing.Point(240, 168);
            this.GroupByApprovedByRadioButton.Name = "GroupByApprovedByRadioButton";
            this.GroupByApprovedByRadioButton.Size = new System.Drawing.Size(151, 17);
            this.GroupByApprovedByRadioButton.TabIndex = 14;
            this.GroupByApprovedByRadioButton.TabStop = true;
            this.GroupByApprovedByRadioButton.Text = "By \"Approved by\" property";
            this.GroupByApprovedByRadioButton.UseVisualStyleBackColor = true;
            // 
            // GroupByLevelRadioButton
            // 
            this.GroupByLevelRadioButton.AutoSize = true;
            this.GroupByLevelRadioButton.Location = new System.Drawing.Point(240, 56);
            this.GroupByLevelRadioButton.Name = "GroupByLevelRadioButton";
            this.GroupByLevelRadioButton.Size = new System.Drawing.Size(101, 17);
            this.GroupByLevelRadioButton.TabIndex = 11;
            this.GroupByLevelRadioButton.TabStop = true;
            this.GroupByLevelRadioButton.Text = "By building level";
            this.GroupByLevelRadioButton.UseVisualStyleBackColor = true;
            // 
            // GroupingModeGroupBox
            // 
            this.GroupingModeGroupBox.Controls.Add(this.RequiresGridsLabel);
            this.GroupingModeGroupBox.Controls.Add(this.NumAttemptsNumericUpDown);
            this.GroupingModeGroupBox.Controls.Add(this.NumAttemptsLabel);
            this.GroupingModeGroupBox.Controls.Add(this.NumClustersLabel);
            this.GroupingModeGroupBox.Controls.Add(this.NumClustersNumericUpDown);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByApprovedByRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByClusterAnalysisRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.UngroupAllRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByIntersectionRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByLevelRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByAssignedToRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.ModelSelectionLabel);
            this.GroupingModeGroupBox.Controls.Add(this.GroupByModelRadioButton);
            this.GroupingModeGroupBox.Controls.Add(this.ModelSelectionComboBox);
            this.GroupingModeGroupBox.Location = new System.Drawing.Point(208, 8);
            this.GroupingModeGroupBox.Name = "GroupingModeGroupBox";
            this.GroupingModeGroupBox.Size = new System.Drawing.Size(400, 200);
            this.GroupingModeGroupBox.TabIndex = 4;
            this.GroupingModeGroupBox.TabStop = false;
            this.GroupingModeGroupBox.Text = "Grouping Mode:";
            // 
            // RequiresGridsLabel
            // 
            this.RequiresGridsLabel.ForeColor = System.Drawing.Color.Red;
            this.RequiresGridsLabel.Location = new System.Drawing.Point(236, 24);
            this.RequiresGridsLabel.Name = "RequiresGridsLabel";
            this.RequiresGridsLabel.Size = new System.Drawing.Size(152, 32);
            this.RequiresGridsLabel.TabIndex = 22;
            this.RequiresGridsLabel.Text = "To enable these modes, select View tab -> Show Grids";
            // 
            // NumAttemptsNumericUpDown
            // 
            this.NumAttemptsNumericUpDown.Location = new System.Drawing.Point(160, 142);
            this.NumAttemptsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumAttemptsNumericUpDown.Name = "NumAttemptsNumericUpDown";
            this.NumAttemptsNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.NumAttemptsNumericUpDown.TabIndex = 9;
            this.NumAttemptsNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumAttemptsNumericUpDown.ValueChanged += new System.EventHandler(this.NumAttemptsNumericUpDown_ValueChanged);
            this.NumAttemptsNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.NumAttemptsNumericUpDown_Validating);
            // 
            // NumAttemptsLabel
            // 
            this.NumAttemptsLabel.AutoSize = true;
            this.NumAttemptsLabel.Location = new System.Drawing.Point(24, 144);
            this.NumAttemptsLabel.Name = "NumAttemptsLabel";
            this.NumAttemptsLabel.Size = new System.Drawing.Size(107, 13);
            this.NumAttemptsLabel.TabIndex = 20;
            this.NumAttemptsLabel.Text = "Number of variations:";
            this.NumAttemptsLabel.Click += new System.EventHandler(this.NumAttemptsLabel_Click);
            // 
            // NumClustersLabel
            // 
            this.NumClustersLabel.AutoSize = true;
            this.NumClustersLabel.Location = new System.Drawing.Point(24, 120);
            this.NumClustersLabel.Name = "NumClustersLabel";
            this.NumClustersLabel.Size = new System.Drawing.Size(122, 13);
            this.NumClustersLabel.TabIndex = 19;
            this.NumClustersLabel.Text = "Number of result groups:";
            this.NumClustersLabel.Click += new System.EventHandler(this.NumClustersLabel_Click);
            // 
            // NumClustersNumericUpDown
            // 
            this.NumClustersNumericUpDown.Location = new System.Drawing.Point(160, 117);
            this.NumClustersNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumClustersNumericUpDown.Name = "NumClustersNumericUpDown";
            this.NumClustersNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.NumClustersNumericUpDown.TabIndex = 8;
            this.NumClustersNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumClustersNumericUpDown.ValueChanged += new System.EventHandler(this.NumClustersNumericUpDown_ValueChanged);
            this.NumClustersNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.NumClustersNumericUpDown_Validating);
            // 
            // GroupByClusterAnalysisRadioButton
            // 
            this.GroupByClusterAnalysisRadioButton.AutoSize = true;
            this.GroupByClusterAnalysisRadioButton.Location = new System.Drawing.Point(8, 96);
            this.GroupByClusterAnalysisRadioButton.Name = "GroupByClusterAnalysisRadioButton";
            this.GroupByClusterAnalysisRadioButton.Size = new System.Drawing.Size(114, 17);
            this.GroupByClusterAnalysisRadioButton.TabIndex = 7;
            this.GroupByClusterAnalysisRadioButton.TabStop = true;
            this.GroupByClusterAnalysisRadioButton.Text = "By cluster analysis:";
            this.GroupByClusterAnalysisRadioButton.UseVisualStyleBackColor = true;
            // 
            // UngroupAllRadioButton
            // 
            this.UngroupAllRadioButton.AutoSize = true;
            this.UngroupAllRadioButton.Location = new System.Drawing.Point(8, 168);
            this.UngroupAllRadioButton.Name = "UngroupAllRadioButton";
            this.UngroupAllRadioButton.Size = new System.Drawing.Size(112, 17);
            this.UngroupAllRadioButton.TabIndex = 10;
            this.UngroupAllRadioButton.TabStop = true;
            this.UngroupAllRadioButton.Text = "Ungroup all results";
            this.UngroupAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // GroupByIntersectionRadioButton
            // 
            this.GroupByIntersectionRadioButton.AutoSize = true;
            this.GroupByIntersectionRadioButton.Location = new System.Drawing.Point(240, 80);
            this.GroupByIntersectionRadioButton.Name = "GroupByIntersectionRadioButton";
            this.GroupByIntersectionRadioButton.Size = new System.Drawing.Size(150, 17);
            this.GroupByIntersectionRadioButton.TabIndex = 12;
            this.GroupByIntersectionRadioButton.TabStop = true;
            this.GroupByIntersectionRadioButton.Text = "By closest grid intersection";
            this.GroupByIntersectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // OtherSettingsGroupBox
            // 
            this.OtherSettingsGroupBox.Controls.Add(this.CatchAllGroupCheckBox);
            this.OtherSettingsGroupBox.Location = new System.Drawing.Point(8, 160);
            this.OtherSettingsGroupBox.Name = "OtherSettingsGroupBox";
            this.OtherSettingsGroupBox.Size = new System.Drawing.Size(192, 48);
            this.OtherSettingsGroupBox.TabIndex = 2;
            this.OtherSettingsGroupBox.TabStop = false;
            this.OtherSettingsGroupBox.Text = "Other Settings";
            // 
            // CatchAllGroupCheckBox
            // 
            this.CatchAllGroupCheckBox.AutoSize = true;
            this.CatchAllGroupCheckBox.Location = new System.Drawing.Point(8, 24);
            this.CatchAllGroupCheckBox.Name = "CatchAllGroupCheckBox";
            this.CatchAllGroupCheckBox.Size = new System.Drawing.Size(130, 17);
            this.CatchAllGroupCheckBox.TabIndex = 3;
            this.CatchAllGroupCheckBox.Text = "Create catch-all group";
            this.CatchAllGroupCheckBox.UseVisualStyleBackColor = true;
            // 
            // BalloonToolTips
            // 
            this.BalloonToolTips.IsBalloon = true;
            // 
            // ClashGrouperDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(614, 252);
            this.Controls.Add(this.OtherSettingsGroupBox);
            this.Controls.Add(this.GroupingModeGroupBox);
            this.Controls.Add(this.TestSelectionGroupBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClashGrouperDialog";
            this.ShowIcon = false;
            this.Text = "Group Clash Results";
            this.TestSelectionGroupBox.ResumeLayout(false);
            this.GroupingModeGroupBox.ResumeLayout(false);
            this.GroupingModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAttemptsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumClustersNumericUpDown)).EndInit();
            this.OtherSettingsGroupBox.ResumeLayout(false);
            this.OtherSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox TestSelectionListBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox TestSelectionGroupBox;
        private System.Windows.Forms.RadioButton GroupByModelRadioButton;
        private System.Windows.Forms.ComboBox ModelSelectionComboBox;
        private System.Windows.Forms.Label ModelSelectionLabel;
        private System.Windows.Forms.RadioButton GroupByAssignedToRadioButton;
        private System.Windows.Forms.RadioButton GroupByApprovedByRadioButton;
        private System.Windows.Forms.RadioButton GroupByLevelRadioButton;
        private System.Windows.Forms.GroupBox GroupingModeGroupBox;
        private System.Windows.Forms.RadioButton GroupByIntersectionRadioButton;
        private System.Windows.Forms.GroupBox OtherSettingsGroupBox;
        private System.Windows.Forms.CheckBox CatchAllGroupCheckBox;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.RadioButton UngroupAllRadioButton;
        private System.Windows.Forms.RadioButton GroupByClusterAnalysisRadioButton;
        private System.Windows.Forms.Label NumClustersLabel;
        private System.Windows.Forms.NumericUpDown NumClustersNumericUpDown;
        private System.Windows.Forms.ToolTip BalloonToolTips;
        private System.Windows.Forms.NumericUpDown NumAttemptsNumericUpDown;
        private System.Windows.Forms.Label NumAttemptsLabel;
        private System.Windows.Forms.Label RequiresGridsLabel;

    }
}