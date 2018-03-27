namespace Examiner
{
   partial class SearchForm
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
         this.hasItemsNamed = new System.Windows.Forms.CheckBox();
         this.searchPropertyCategory = new System.Windows.Forms.TextBox();
         this.searchItemName = new System.Windows.Forms.TextBox();
         this.propertyCategory = new System.Windows.Forms.CheckBox();
         this.searchForItems = new System.Windows.Forms.Button();
         this.isRequired = new System.Windows.Forms.CheckBox();
         this.hasGeometry = new System.Windows.Forms.CheckBox();
         this.representsLayer = new System.Windows.Forms.CheckBox();
         this.isHidden = new System.Windows.Forms.CheckBox();
         this.representsInsert = new System.Windows.Forms.CheckBox();
         this.selectResults = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.saveToFile = new System.Windows.Forms.TextBox();
         this.browseForFile = new System.Windows.Forms.Button();
         this.overrideTransparencyValue = new System.Windows.Forms.NumericUpDown();
         this.overrideTransparency = new System.Windows.Forms.CheckBox();
         this.overrideColor = new System.Windows.Forms.CheckBox();
         this.overrideColorValue = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.hiddenNoChange = new System.Windows.Forms.RadioButton();
         this.dontHide = new System.Windows.Forms.RadioButton();
         this.hidden = new System.Windows.Forms.RadioButton();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.requiredNoChange = new System.Windows.Forms.RadioButton();
         this.notRequired = new System.Windows.Forms.RadioButton();
         this.required = new System.Windows.Forms.RadioButton();
         this.browseForOutputFile = new System.Windows.Forms.Button();
         this.resultingNWD = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.colorDialog = new System.Windows.Forms.ColorDialog();
         ((System.ComponentModel.ISupportInitialize)(this.overrideTransparencyValue)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // hasItemsNamed
         // 
         this.hasItemsNamed.AutoSize = true;
         this.hasItemsNamed.Location = new System.Drawing.Point(6, 19);
         this.hasItemsNamed.Name = "hasItemsNamed";
         this.hasItemsNamed.Size = new System.Drawing.Size(119, 17);
         this.hasItemsNamed.TabIndex = 0;
         this.hasItemsNamed.Text = "Class Display Name";
         this.hasItemsNamed.UseVisualStyleBackColor = true;
         this.hasItemsNamed.CheckedChanged += new System.EventHandler(this.hasItemsNamed_CheckedChanged);
         // 
         // searchPropertyCategory
         // 
         this.searchPropertyCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.searchPropertyCategory.Enabled = false;
         this.searchPropertyCategory.Location = new System.Drawing.Point(6, 92);
         this.searchPropertyCategory.Name = "searchPropertyCategory";
         this.searchPropertyCategory.Size = new System.Drawing.Size(357, 20);
         this.searchPropertyCategory.TabIndex = 3;
         // 
         // searchItemName
         // 
         this.searchItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.searchItemName.Enabled = false;
         this.searchItemName.Location = new System.Drawing.Point(6, 42);
         this.searchItemName.Name = "searchItemName";
         this.searchItemName.Size = new System.Drawing.Size(357, 20);
         this.searchItemName.TabIndex = 1;
         // 
         // propertyCategory
         // 
         this.propertyCategory.AutoSize = true;
         this.propertyCategory.Location = new System.Drawing.Point(6, 69);
         this.propertyCategory.Name = "propertyCategory";
         this.propertyCategory.Size = new System.Drawing.Size(216, 17);
         this.propertyCategory.TabIndex = 2;
         this.propertyCategory.Text = "Has PropertyCategory with DisplayName";
         this.propertyCategory.UseVisualStyleBackColor = true;
         this.propertyCategory.CheckedChanged += new System.EventHandler(this.propertyCategory_CheckedChanged);
         // 
         // searchForItems
         // 
         this.searchForItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.searchForItems.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.searchForItems.Location = new System.Drawing.Point(156, 523);
         this.searchForItems.Name = "searchForItems";
         this.searchForItems.Size = new System.Drawing.Size(75, 23);
         this.searchForItems.TabIndex = 2;
         this.searchForItems.Text = "Search";
         this.searchForItems.UseVisualStyleBackColor = true;
         this.searchForItems.Click += new System.EventHandler(this.searchForItems_Click);
         // 
         // isRequired
         // 
         this.isRequired.AutoSize = true;
         this.isRequired.Location = new System.Drawing.Point(6, 164);
         this.isRequired.Name = "isRequired";
         this.isRequired.Size = new System.Drawing.Size(80, 17);
         this.isRequired.TabIndex = 8;
         this.isRequired.Text = "Is Required";
         this.isRequired.UseVisualStyleBackColor = true;
         // 
         // hasGeometry
         // 
         this.hasGeometry.AutoSize = true;
         this.hasGeometry.Location = new System.Drawing.Point(6, 118);
         this.hasGeometry.Name = "hasGeometry";
         this.hasGeometry.Size = new System.Drawing.Size(96, 17);
         this.hasGeometry.TabIndex = 4;
         this.hasGeometry.Text = "With Geometry";
         this.hasGeometry.UseVisualStyleBackColor = true;
         // 
         // representsLayer
         // 
         this.representsLayer.AutoSize = true;
         this.representsLayer.Location = new System.Drawing.Point(121, 141);
         this.representsLayer.Name = "representsLayer";
         this.representsLayer.Size = new System.Drawing.Size(109, 17);
         this.representsLayer.TabIndex = 7;
         this.representsLayer.Text = "represents a layer";
         this.representsLayer.UseVisualStyleBackColor = true;
         // 
         // isHidden
         // 
         this.isHidden.AutoSize = true;
         this.isHidden.Location = new System.Drawing.Point(6, 141);
         this.isHidden.Name = "isHidden";
         this.isHidden.Size = new System.Drawing.Size(79, 17);
         this.isHidden.TabIndex = 6;
         this.isHidden.Text = "Are Hidden";
         this.isHidden.UseVisualStyleBackColor = true;
         // 
         // representsInsert
         // 
         this.representsInsert.AutoSize = true;
         this.representsInsert.Location = new System.Drawing.Point(121, 118);
         this.representsInsert.Name = "representsInsert";
         this.representsInsert.Size = new System.Drawing.Size(118, 17);
         this.representsInsert.TabIndex = 5;
         this.representsInsert.Text = "represents an insert";
         this.representsInsert.UseVisualStyleBackColor = true;
         // 
         // selectResults
         // 
         this.selectResults.AutoSize = true;
         this.selectResults.Location = new System.Drawing.Point(6, 208);
         this.selectResults.Name = "selectResults";
         this.selectResults.Size = new System.Drawing.Size(132, 17);
         this.selectResults.TabIndex = 9;
         this.selectResults.Text = "Select results in Model";
         this.selectResults.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 228);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(259, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Save search results to file (leave blank if not required)";
         // 
         // saveToFile
         // 
         this.saveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.saveToFile.Location = new System.Drawing.Point(6, 244);
         this.saveToFile.Name = "saveToFile";
         this.saveToFile.Size = new System.Drawing.Size(326, 20);
         this.saveToFile.TabIndex = 11;
         // 
         // browseForFile
         // 
         this.browseForFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.browseForFile.Location = new System.Drawing.Point(338, 242);
         this.browseForFile.Name = "browseForFile";
         this.browseForFile.Size = new System.Drawing.Size(25, 23);
         this.browseForFile.TabIndex = 12;
         this.browseForFile.Text = "...";
         this.browseForFile.UseVisualStyleBackColor = true;
         this.browseForFile.Click += new System.EventHandler(this.browseForFile_Click);
         // 
         // overrideTransparencyValue
         // 
         this.overrideTransparencyValue.DecimalPlaces = 3;
         this.overrideTransparencyValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
         this.overrideTransparencyValue.Location = new System.Drawing.Point(259, 49);
         this.overrideTransparencyValue.Name = "overrideTransparencyValue";
         this.overrideTransparencyValue.Size = new System.Drawing.Size(73, 20);
         this.overrideTransparencyValue.TabIndex = 3;
         // 
         // overrideTransparency
         // 
         this.overrideTransparency.AutoSize = true;
         this.overrideTransparency.Location = new System.Drawing.Point(27, 50);
         this.overrideTransparency.Name = "overrideTransparency";
         this.overrideTransparency.Size = new System.Drawing.Size(188, 17);
         this.overrideTransparency.TabIndex = 2;
         this.overrideTransparency.Text = "Override Permanent Transparency";
         this.overrideTransparency.UseVisualStyleBackColor = true;
         // 
         // overrideColor
         // 
         this.overrideColor.AutoSize = true;
         this.overrideColor.Location = new System.Drawing.Point(27, 20);
         this.overrideColor.Name = "overrideColor";
         this.overrideColor.Size = new System.Drawing.Size(220, 17);
         this.overrideColor.TabIndex = 0;
         this.overrideColor.Text = "Override Permanent Colour on ModelItem";
         this.overrideColor.UseVisualStyleBackColor = true;
         // 
         // overrideColorValue
         // 
         this.overrideColorValue.Location = new System.Drawing.Point(259, 16);
         this.overrideColorValue.Name = "overrideColorValue";
         this.overrideColorValue.Size = new System.Drawing.Size(73, 23);
         this.overrideColorValue.TabIndex = 1;
         this.overrideColorValue.UseVisualStyleBackColor = true;
         this.overrideColorValue.Click += new System.EventHandler(this.overrideColorValue_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.browseForFile);
         this.groupBox1.Controls.Add(this.saveToFile);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.selectResults);
         this.groupBox1.Controls.Add(this.hasItemsNamed);
         this.groupBox1.Controls.Add(this.searchPropertyCategory);
         this.groupBox1.Controls.Add(this.searchItemName);
         this.groupBox1.Controls.Add(this.representsInsert);
         this.groupBox1.Controls.Add(this.propertyCategory);
         this.groupBox1.Controls.Add(this.isHidden);
         this.groupBox1.Controls.Add(this.representsLayer);
         this.groupBox1.Controls.Add(this.isRequired);
         this.groupBox1.Controls.Add(this.hasGeometry);
         this.groupBox1.Location = new System.Drawing.Point(6, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(369, 285);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Search options";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.groupBox4);
         this.groupBox2.Controls.Add(this.groupBox3);
         this.groupBox2.Controls.Add(this.browseForOutputFile);
         this.groupBox2.Controls.Add(this.resultingNWD);
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Controls.Add(this.overrideTransparencyValue);
         this.groupBox2.Controls.Add(this.overrideTransparency);
         this.groupBox2.Controls.Add(this.overrideColor);
         this.groupBox2.Controls.Add(this.overrideColorValue);
         this.groupBox2.Location = new System.Drawing.Point(6, 306);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(368, 211);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Changes to the selection";
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.hiddenNoChange);
         this.groupBox4.Controls.Add(this.dontHide);
         this.groupBox4.Controls.Add(this.hidden);
         this.groupBox4.Location = new System.Drawing.Point(27, 120);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(327, 39);
         this.groupBox4.TabIndex = 8;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Should the selected ModelItems be Hidden?";
         // 
         // hiddenNoChange
         // 
         this.hiddenNoChange.AutoSize = true;
         this.hiddenNoChange.Checked = true;
         this.hiddenNoChange.Location = new System.Drawing.Point(222, 19);
         this.hiddenNoChange.Name = "hiddenNoChange";
         this.hiddenNoChange.Size = new System.Drawing.Size(78, 17);
         this.hiddenNoChange.TabIndex = 11;
         this.hiddenNoChange.TabStop = true;
         this.hiddenNoChange.Text = "No change";
         this.hiddenNoChange.UseVisualStyleBackColor = true;
         // 
         // dontHide
         // 
         this.dontHide.AutoSize = true;
         this.dontHide.Location = new System.Drawing.Point(109, 19);
         this.dontHide.Name = "dontHide";
         this.dontHide.Size = new System.Drawing.Size(39, 17);
         this.dontHide.TabIndex = 10;
         this.dontHide.Text = "No";
         this.dontHide.UseVisualStyleBackColor = true;
         // 
         // hidden
         // 
         this.hidden.AutoSize = true;
         this.hidden.Location = new System.Drawing.Point(18, 19);
         this.hidden.Name = "hidden";
         this.hidden.Size = new System.Drawing.Size(43, 17);
         this.hidden.TabIndex = 9;
         this.hidden.Text = "Yes";
         this.hidden.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.requiredNoChange);
         this.groupBox3.Controls.Add(this.notRequired);
         this.groupBox3.Controls.Add(this.required);
         this.groupBox3.Location = new System.Drawing.Point(27, 75);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(327, 39);
         this.groupBox3.TabIndex = 4;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Are all the selected ModelItems Required?";
         // 
         // requiredNoChange
         // 
         this.requiredNoChange.AutoSize = true;
         this.requiredNoChange.Checked = true;
         this.requiredNoChange.Location = new System.Drawing.Point(222, 19);
         this.requiredNoChange.Name = "requiredNoChange";
         this.requiredNoChange.Size = new System.Drawing.Size(78, 17);
         this.requiredNoChange.TabIndex = 7;
         this.requiredNoChange.TabStop = true;
         this.requiredNoChange.Text = "No change";
         this.requiredNoChange.UseVisualStyleBackColor = true;
         // 
         // notRequired
         // 
         this.notRequired.AutoSize = true;
         this.notRequired.Location = new System.Drawing.Point(109, 19);
         this.notRequired.Name = "notRequired";
         this.notRequired.Size = new System.Drawing.Size(39, 17);
         this.notRequired.TabIndex = 6;
         this.notRequired.Text = "No";
         this.notRequired.UseVisualStyleBackColor = true;
         // 
         // required
         // 
         this.required.AutoSize = true;
         this.required.Location = new System.Drawing.Point(18, 19);
         this.required.Name = "required";
         this.required.Size = new System.Drawing.Size(43, 17);
         this.required.TabIndex = 5;
         this.required.Text = "Yes";
         this.required.UseVisualStyleBackColor = true;
         // 
         // browseForOutputFile
         // 
         this.browseForOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.browseForOutputFile.Location = new System.Drawing.Point(338, 181);
         this.browseForOutputFile.Name = "browseForOutputFile";
         this.browseForOutputFile.Size = new System.Drawing.Size(25, 23);
         this.browseForOutputFile.TabIndex = 15;
         this.browseForOutputFile.Text = "...";
         this.browseForOutputFile.UseVisualStyleBackColor = true;
         this.browseForOutputFile.Click += new System.EventHandler(this.browseForOutputFile_Click);
         // 
         // resultingNWD
         // 
         this.resultingNWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.resultingNWD.Location = new System.Drawing.Point(6, 183);
         this.resultingNWD.Name = "resultingNWD";
         this.resultingNWD.Size = new System.Drawing.Size(326, 20);
         this.resultingNWD.TabIndex = 14;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 167);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(88, 13);
         this.label2.TabIndex = 13;
         this.label2.Text = "Save results into:";
         // 
         // SearchForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(387, 552);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.searchForItems);
         this.Name = "SearchForm";
         this.Text = "SearchForm";
         ((System.ComponentModel.ISupportInitialize)(this.overrideTransparencyValue)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox hasItemsNamed;
      private System.Windows.Forms.TextBox searchPropertyCategory;
      private System.Windows.Forms.TextBox searchItemName;
      private System.Windows.Forms.CheckBox propertyCategory;
      private System.Windows.Forms.Button searchForItems;
      private System.Windows.Forms.CheckBox isRequired;
      private System.Windows.Forms.CheckBox hasGeometry;
      private System.Windows.Forms.CheckBox representsLayer;
      private System.Windows.Forms.CheckBox isHidden;
      private System.Windows.Forms.CheckBox representsInsert;
      private System.Windows.Forms.CheckBox selectResults;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox saveToFile;
      private System.Windows.Forms.Button browseForFile;
      private System.Windows.Forms.NumericUpDown overrideTransparencyValue;
      private System.Windows.Forms.CheckBox overrideTransparency;
      private System.Windows.Forms.CheckBox overrideColor;
      private System.Windows.Forms.Button overrideColorValue;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.RadioButton requiredNoChange;
      private System.Windows.Forms.RadioButton notRequired;
      private System.Windows.Forms.RadioButton required;
      private System.Windows.Forms.RadioButton hiddenNoChange;
      private System.Windows.Forms.RadioButton dontHide;
      private System.Windows.Forms.RadioButton hidden;
      private System.Windows.Forms.ColorDialog colorDialog;
      private System.Windows.Forms.Button browseForOutputFile;
      private System.Windows.Forms.TextBox resultingNWD;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.GroupBox groupBox4;

   }
}