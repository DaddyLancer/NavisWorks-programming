namespace ClashDetective
{
    partial class ClashMarkersControl
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
            this.GroupedResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.IDMarkersOnClickCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Box3DAlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClashMarkerOpacityTextBox = new System.Windows.Forms.Label();
            this.FillAlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.Draw3DGroupBoxesCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawGroupRectanglesCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearSelectionButton = new System.Windows.Forms.Button();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.ShowAllButton = new System.Windows.Forms.Button();
            this.ShowNoneButton = new System.Windows.Forms.Button();
            this.SelectedMarkerTextBox = new System.Windows.Forms.TextBox();
            this.BalloonToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.LockSelectionCheckBox = new System.Windows.Forms.CheckBox();
            this.ZoomToSelectionButton = new System.Windows.Forms.Button();
            this.SettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box3DAlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillAlphaTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupedResultsGroupBox
            // 
            this.GroupedResultsGroupBox.Location = new System.Drawing.Point(8, 120);
            this.GroupedResultsGroupBox.Name = "GroupedResultsGroupBox";
            this.GroupedResultsGroupBox.Size = new System.Drawing.Size(280, 48);
            this.GroupedResultsGroupBox.TabIndex = 8;
            this.GroupedResultsGroupBox.TabStop = false;
            this.GroupedResultsGroupBox.Text = "Result Groups";
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.IDMarkersOnClickCheckBox);
            this.SettingsGroupBox.Controls.Add(this.label6);
            this.SettingsGroupBox.Controls.Add(this.label5);
            this.SettingsGroupBox.Controls.Add(this.label4);
            this.SettingsGroupBox.Controls.Add(this.Box3DAlphaTrackBar);
            this.SettingsGroupBox.Controls.Add(this.label3);
            this.SettingsGroupBox.Controls.Add(this.label2);
            this.SettingsGroupBox.Controls.Add(this.label1);
            this.SettingsGroupBox.Controls.Add(this.ClashMarkerOpacityTextBox);
            this.SettingsGroupBox.Controls.Add(this.FillAlphaTrackBar);
            this.SettingsGroupBox.Controls.Add(this.Draw3DGroupBoxesCheckBox);
            this.SettingsGroupBox.Controls.Add(this.DrawGroupRectanglesCheckBox);
            this.SettingsGroupBox.Location = new System.Drawing.Point(8, 176);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(280, 216);
            this.SettingsGroupBox.TabIndex = 4;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // IDMarkersOnClickCheckBox
            // 
            this.IDMarkersOnClickCheckBox.Checked = true;
            this.IDMarkersOnClickCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IDMarkersOnClickCheckBox.Location = new System.Drawing.Point(8, 192);
            this.IDMarkersOnClickCheckBox.Name = "IDMarkersOnClickCheckBox";
            this.IDMarkersOnClickCheckBox.Size = new System.Drawing.Size(152, 16);
            this.IDMarkersOnClickCheckBox.TabIndex = 13;
            this.IDMarkersOnClickCheckBox.Text = "Marker mouse interaction";
            this.IDMarkersOnClickCheckBox.UseVisualStyleBackColor = true;
            this.IDMarkersOnClickCheckBox.CheckedChanged += new System.EventHandler(this.IDMarkersOnClickCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "100%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "50%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "0%";
            // 
            // Box3DAlphaTrackBar
            // 
            this.Box3DAlphaTrackBar.LargeChange = 2;
            this.Box3DAlphaTrackBar.Location = new System.Drawing.Point(24, 144);
            this.Box3DAlphaTrackBar.Maximum = 20;
            this.Box3DAlphaTrackBar.Name = "Box3DAlphaTrackBar";
            this.Box3DAlphaTrackBar.Size = new System.Drawing.Size(240, 45);
            this.Box3DAlphaTrackBar.TabIndex = 12;
            this.Box3DAlphaTrackBar.Value = 14;
            this.Box3DAlphaTrackBar.Scroll += new System.EventHandler(this.Box3DAlphaTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "50%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "100%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "0%";
            // 
            // ClashMarkerOpacityTextBox
            // 
            this.ClashMarkerOpacityTextBox.AutoSize = true;
            this.ClashMarkerOpacityTextBox.Location = new System.Drawing.Point(8, 24);
            this.ClashMarkerOpacityTextBox.Name = "ClashMarkerOpacityTextBox";
            this.ClashMarkerOpacityTextBox.Size = new System.Drawing.Size(111, 13);
            this.ClashMarkerOpacityTextBox.TabIndex = 3;
            this.ClashMarkerOpacityTextBox.Text = "Clash Marker Opacity:";
            // 
            // FillAlphaTrackBar
            // 
            this.FillAlphaTrackBar.LargeChange = 2;
            this.FillAlphaTrackBar.Location = new System.Drawing.Point(24, 40);
            this.FillAlphaTrackBar.Maximum = 20;
            this.FillAlphaTrackBar.Name = "FillAlphaTrackBar";
            this.FillAlphaTrackBar.Size = new System.Drawing.Size(240, 45);
            this.FillAlphaTrackBar.TabIndex = 9;
            this.FillAlphaTrackBar.Value = 14;
            this.FillAlphaTrackBar.Scroll += new System.EventHandler(this.FillAlphaTrackBar_Scroll);
            // 
            // Draw3DGroupBoxesCheckBox
            // 
            this.Draw3DGroupBoxesCheckBox.AutoSize = true;
            this.Draw3DGroupBoxesCheckBox.Checked = true;
            this.Draw3DGroupBoxesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Draw3DGroupBoxesCheckBox.Location = new System.Drawing.Point(24, 120);
            this.Draw3DGroupBoxesCheckBox.Name = "Draw3DGroupBoxesCheckBox";
            this.Draw3DGroupBoxesCheckBox.Size = new System.Drawing.Size(150, 17);
            this.Draw3DGroupBoxesCheckBox.TabIndex = 11;
            this.Draw3DGroupBoxesCheckBox.Text = "Draw 3D box with opacity:";
            this.Draw3DGroupBoxesCheckBox.UseVisualStyleBackColor = true;
            this.Draw3DGroupBoxesCheckBox.CheckedChanged += new System.EventHandler(this.Draw3DGroupBoxesCheckBox_CheckedChanged);
            // 
            // DrawGroupRectanglesCheckBox
            // 
            this.DrawGroupRectanglesCheckBox.AutoSize = true;
            this.DrawGroupRectanglesCheckBox.Checked = true;
            this.DrawGroupRectanglesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawGroupRectanglesCheckBox.Location = new System.Drawing.Point(8, 96);
            this.DrawGroupRectanglesCheckBox.Name = "DrawGroupRectanglesCheckBox";
            this.DrawGroupRectanglesCheckBox.Size = new System.Drawing.Size(170, 17);
            this.DrawGroupRectanglesCheckBox.TabIndex = 10;
            this.DrawGroupRectanglesCheckBox.Text = "Draw box around result groups";
            this.DrawGroupRectanglesCheckBox.UseVisualStyleBackColor = true;
            this.DrawGroupRectanglesCheckBox.CheckedChanged += new System.EventHandler(this.DrawGroupRectanglesCheckBox_CheckedChanged);
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearSelectionButton.Location = new System.Drawing.Point(264, 56);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(24, 24);
            this.ClearSelectionButton.TabIndex = 4;
            this.ClearSelectionButton.Text = "X";
            this.ClearSelectionButton.UseVisualStyleBackColor = true;
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // ShowAllButton
            // 
            this.ShowAllButton.Location = new System.Drawing.Point(8, 88);
            this.ShowAllButton.Name = "ShowAllButton";
            this.ShowAllButton.Size = new System.Drawing.Size(136, 24);
            this.ShowAllButton.TabIndex = 5;
            this.ShowAllButton.Text = "Show All Tests";
            this.ShowAllButton.UseVisualStyleBackColor = true;
            this.ShowAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // ShowNoneButton
            // 
            this.ShowNoneButton.Location = new System.Drawing.Point(152, 88);
            this.ShowNoneButton.Name = "ShowNoneButton";
            this.ShowNoneButton.Size = new System.Drawing.Size(136, 24);
            this.ShowNoneButton.TabIndex = 6;
            this.ShowNoneButton.Text = "Hide All Tests";
            this.ShowNoneButton.UseVisualStyleBackColor = true;
            this.ShowNoneButton.Click += new System.EventHandler(this.ShowNoneButton_Click);
            // 
            // SelectedMarkerTextBox
            // 
            this.SelectedMarkerTextBox.Location = new System.Drawing.Point(8, 8);
            this.SelectedMarkerTextBox.Multiline = true;
            this.SelectedMarkerTextBox.Name = "SelectedMarkerTextBox";
            this.SelectedMarkerTextBox.ReadOnly = true;
            this.SelectedMarkerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SelectedMarkerTextBox.Size = new System.Drawing.Size(248, 72);
            this.SelectedMarkerTextBox.TabIndex = 1;
            // 
            // BalloonToolTips
            // 
            this.BalloonToolTips.IsBalloon = true;
            // 
            // LockSelectionCheckBox
            // 
            this.LockSelectionCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.LockSelectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockSelectionCheckBox.Location = new System.Drawing.Point(264, 32);
            this.LockSelectionCheckBox.Name = "LockSelectionCheckBox";
            this.LockSelectionCheckBox.Size = new System.Drawing.Size(24, 24);
            this.LockSelectionCheckBox.TabIndex = 3;
            this.LockSelectionCheckBox.Text = "L";
            this.LockSelectionCheckBox.UseVisualStyleBackColor = true;
            this.LockSelectionCheckBox.CheckedChanged += new System.EventHandler(this.LockSelectionCheckBox_CheckedChanged);
            // 
            // ZoomToSelectionButton
            // 
            this.ZoomToSelectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomToSelectionButton.Location = new System.Drawing.Point(264, 8);
            this.ZoomToSelectionButton.Name = "ZoomToSelectionButton";
            this.ZoomToSelectionButton.Size = new System.Drawing.Size(24, 24);
            this.ZoomToSelectionButton.TabIndex = 2;
            this.ZoomToSelectionButton.Text = ">";
            this.ZoomToSelectionButton.UseVisualStyleBackColor = true;
            this.ZoomToSelectionButton.Click += new System.EventHandler(this.ZoomToSelectionButton_Click);
            // 
            // ClashMarkersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ZoomToSelectionButton);
            this.Controls.Add(this.LockSelectionCheckBox);
            this.Controls.Add(this.SelectedMarkerTextBox);
            this.Controls.Add(this.ShowNoneButton);
            this.Controls.Add(this.ShowAllButton);
            this.Controls.Add(this.ClearSelectionButton);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.GroupedResultsGroupBox);
            this.Name = "ClashMarkersControl";
            this.Size = new System.Drawing.Size(296, 400);
            this.Load += new System.EventHandler(this.ClashMarkersControl_Load);
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box3DAlphaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillAlphaTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupedResultsGroupBox;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.CheckBox DrawGroupRectanglesCheckBox;
        private System.Windows.Forms.CheckBox Draw3DGroupBoxesCheckBox;
        private System.Windows.Forms.Label ClashMarkerOpacityTextBox;
        private System.Windows.Forms.TrackBar FillAlphaTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar Box3DAlphaTrackBar;
        private System.Windows.Forms.CheckBox IDMarkersOnClickCheckBox;
        private System.Windows.Forms.Button ClearSelectionButton;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Button ShowAllButton;
        private System.Windows.Forms.Button ShowNoneButton;
        private System.Windows.Forms.TextBox SelectedMarkerTextBox;
        private System.Windows.Forms.ToolTip BalloonToolTips;
        private System.Windows.Forms.CheckBox LockSelectionCheckBox;
        private System.Windows.Forms.Button ZoomToSelectionButton;

    }
}
