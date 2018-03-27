namespace Viewer
{
   partial class SearchSelect
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
         this.searchList = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.remove = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.searchCondition = new System.Windows.Forms.ComboBox();
         this.ignoreCase = new System.Windows.Forms.ComboBox();
         this.negate = new System.Windows.Forms.ComboBox();
         this.search = new System.Windows.Forms.Button();
         this.propertyCategoryNames = new System.Windows.Forms.ComboBox();
         this.categoryName = new System.Windows.Forms.ComboBox();
         this.add = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.propertyName = new System.Windows.Forms.ComboBox();
         this.categoryLabel = new System.Windows.Forms.Label();
         this.propertyLabel = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.propertyValue = new System.Windows.Forms.TextBox();
         this.dataPropertyNames = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.searchGroup = new System.Windows.Forms.ComboBox();
         this.label6 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // searchList
         // 
         this.searchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.searchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader2});
         this.searchList.FullRowSelect = true;
         this.searchList.Location = new System.Drawing.Point(12, 113);
         this.searchList.Name = "searchList";
         this.searchList.Size = new System.Drawing.Size(656, 113);
         this.searchList.TabIndex = 0;
         this.searchList.UseCompatibleStateImageBehavior = false;
         this.searchList.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Search Condition";
         this.columnHeader1.Width = 159;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Category";
         this.columnHeader3.Width = 112;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Property";
         this.columnHeader4.Width = 114;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Value";
         this.columnHeader5.Width = 120;
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Ignore Case";
         this.columnHeader6.Width = 78;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Negate";
         this.columnHeader2.Width = 68;
         // 
         // remove
         // 
         this.remove.CausesValidation = false;
         this.remove.Location = new System.Drawing.Point(674, 135);
         this.remove.Name = "remove";
         this.remove.Size = new System.Drawing.Size(75, 23);
         this.remove.TabIndex = 1;
         this.remove.Text = "Remove";
         this.remove.UseVisualStyleBackColor = true;
         this.remove.Click += new System.EventHandler(this.remove_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(88, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Search Condition";
         // 
         // searchCondition
         // 
         this.searchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.searchCondition.FormattingEnabled = true;
         this.searchCondition.Items.AddRange(new object[] {
            "HasCategoryByDisplayName",
            "HasCategoryByName",
            "HasPropertyByDisplayName",
            "HasPropertyByName"});
         this.searchCondition.Location = new System.Drawing.Point(12, 25);
         this.searchCondition.Name = "searchCondition";
         this.searchCondition.Size = new System.Drawing.Size(160, 21);
         this.searchCondition.TabIndex = 4;
         this.searchCondition.SelectedIndexChanged += new System.EventHandler(this.searchCondition_SelectedIndexChanged);
         // 
         // ignoreCase
         // 
         this.ignoreCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ignoreCase.FormattingEnabled = true;
         this.ignoreCase.Items.AddRange(new object[] {
            "False",
            "True"});
         this.ignoreCase.Location = new System.Drawing.Point(688, 25);
         this.ignoreCase.Name = "ignoreCase";
         this.ignoreCase.Size = new System.Drawing.Size(55, 21);
         this.ignoreCase.TabIndex = 5;
         // 
         // negate
         // 
         this.negate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.negate.FormattingEnabled = true;
         this.negate.Items.AddRange(new object[] {
            "False",
            "True"});
         this.negate.Location = new System.Drawing.Point(12, 73);
         this.negate.Name = "negate";
         this.negate.Size = new System.Drawing.Size(55, 21);
         this.negate.TabIndex = 6;
         // 
         // search
         // 
         this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.search.CausesValidation = false;
         this.search.Location = new System.Drawing.Point(674, 203);
         this.search.Name = "search";
         this.search.Size = new System.Drawing.Size(75, 23);
         this.search.TabIndex = 7;
         this.search.Text = "Search";
         this.search.UseVisualStyleBackColor = true;
         this.search.Click += new System.EventHandler(this.search_Click);
         // 
         // propertyCategoryNames
         // 
         this.propertyCategoryNames.FormattingEnabled = true;
         this.propertyCategoryNames.Location = new System.Drawing.Point(178, 25);
         this.propertyCategoryNames.Name = "propertyCategoryNames";
         this.propertyCategoryNames.Size = new System.Drawing.Size(164, 21);
         this.propertyCategoryNames.TabIndex = 9;
         // 
         // categoryName
         // 
         this.categoryName.FormattingEnabled = true;
         this.categoryName.Location = new System.Drawing.Point(178, 25);
         this.categoryName.Name = "categoryName";
         this.categoryName.Size = new System.Drawing.Size(164, 21);
         this.categoryName.TabIndex = 10;
         // 
         // add
         // 
         this.add.Location = new System.Drawing.Point(674, 71);
         this.add.Name = "add";
         this.add.Size = new System.Drawing.Size(75, 23);
         this.add.TabIndex = 11;
         this.add.Text = "Add";
         this.add.UseVisualStyleBackColor = true;
         this.add.Click += new System.EventHandler(this.add_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 97);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(74, 13);
         this.label2.TabIndex = 12;
         this.label2.Text = "Search details";
         // 
         // propertyName
         // 
         this.propertyName.FormattingEnabled = true;
         this.propertyName.Location = new System.Drawing.Point(348, 25);
         this.propertyName.Name = "propertyName";
         this.propertyName.Size = new System.Drawing.Size(164, 21);
         this.propertyName.TabIndex = 14;
         // 
         // categoryLabel
         // 
         this.categoryLabel.AutoSize = true;
         this.categoryLabel.Location = new System.Drawing.Point(175, 9);
         this.categoryLabel.Name = "categoryLabel";
         this.categoryLabel.Size = new System.Drawing.Size(49, 13);
         this.categoryLabel.TabIndex = 15;
         this.categoryLabel.Text = "Category";
         // 
         // propertyLabel
         // 
         this.propertyLabel.AutoSize = true;
         this.propertyLabel.Location = new System.Drawing.Point(345, 8);
         this.propertyLabel.Name = "propertyLabel";
         this.propertyLabel.Size = new System.Drawing.Size(46, 13);
         this.propertyLabel.TabIndex = 16;
         this.propertyLabel.Text = "Property";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 56);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(42, 13);
         this.label3.TabIndex = 17;
         this.label3.Text = "Negate";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(515, 8);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(34, 13);
         this.label4.TabIndex = 19;
         this.label4.Text = "Value";
         // 
         // propertyValue
         // 
         this.propertyValue.Location = new System.Drawing.Point(518, 25);
         this.propertyValue.Name = "propertyValue";
         this.propertyValue.Size = new System.Drawing.Size(164, 20);
         this.propertyValue.TabIndex = 18;
         // 
         // dataPropertyNames
         // 
         this.dataPropertyNames.FormattingEnabled = true;
         this.dataPropertyNames.Location = new System.Drawing.Point(348, 25);
         this.dataPropertyNames.Name = "dataPropertyNames";
         this.dataPropertyNames.Size = new System.Drawing.Size(164, 21);
         this.dataPropertyNames.TabIndex = 20;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(70, 56);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(36, 13);
         this.label5.TabIndex = 22;
         this.label5.Text = "Group";
         // 
         // searchGroup
         // 
         this.searchGroup.FormattingEnabled = true;
         this.searchGroup.Location = new System.Drawing.Point(73, 73);
         this.searchGroup.Name = "searchGroup";
         this.searchGroup.Size = new System.Drawing.Size(160, 21);
         this.searchGroup.TabIndex = 23;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(685, 9);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(64, 13);
         this.label6.TabIndex = 24;
         this.label6.Text = "Ignore Case";
         // 
         // SearchSelect
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(759, 238);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.searchGroup);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.propertyValue);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.propertyLabel);
         this.Controls.Add(this.categoryLabel);
         this.Controls.Add(this.propertyName);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.add);
         this.Controls.Add(this.categoryName);
         this.Controls.Add(this.propertyCategoryNames);
         this.Controls.Add(this.search);
         this.Controls.Add(this.negate);
         this.Controls.Add(this.ignoreCase);
         this.Controls.Add(this.searchCondition);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.remove);
         this.Controls.Add(this.searchList);
         this.Controls.Add(this.dataPropertyNames);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MinimumSize = new System.Drawing.Size(767, 264);
         this.Name = "SearchSelect";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Search and Select";
         this.Load += new System.EventHandler(this.SearchSelect_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView searchList;
      private System.Windows.Forms.Button remove;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox searchCondition;
      private System.Windows.Forms.ComboBox ignoreCase;
      private System.Windows.Forms.ComboBox negate;
      private System.Windows.Forms.Button search;
      private System.Windows.Forms.ComboBox propertyCategoryNames;
      private System.Windows.Forms.ComboBox categoryName;
      private System.Windows.Forms.Button add;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ComboBox propertyName;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.Label categoryLabel;
      private System.Windows.Forms.Label propertyLabel;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox propertyValue;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ComboBox dataPropertyNames;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox searchGroup;
      private System.Windows.Forms.Label label6;
   }
}
