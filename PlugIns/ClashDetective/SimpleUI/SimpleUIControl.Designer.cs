//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2012 by Autodesk Inc.

// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.

// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//------------------------------------------------------------------

namespace ClashDetective
{
    partial class SimpleUIControl
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
            this.treeViewTests = new System.Windows.Forms.TreeView();
            this.propertiesView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnEditTest = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnEditResult = new System.Windows.Forms.Button();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // treeViewTests
            // 
            this.treeViewTests.Location = new System.Drawing.Point(18, 32);
            this.treeViewTests.Name = "treeViewTests";
            this.treeViewTests.Size = new System.Drawing.Size(130, 214);
            this.treeViewTests.TabIndex = 0;
            this.treeViewTests.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTests_NodeMouseClick);
            // 
            // propertiesView
            // 
            this.propertiesView.Location = new System.Drawing.Point(154, 32);
            this.propertiesView.Name = "propertiesView";
            this.propertiesView.Size = new System.Drawing.Size(225, 214);
            this.propertiesView.TabIndex = 1;
            this.propertiesView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.propertiesView_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clash Tests";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Info";
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(18, 266);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(84, 39);
            this.btnDump.TabIndex = 3;
            this.btnDump.Text = "Refresh Tests";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(291, 266);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(84, 39);
            this.btnAddGroup.TabIndex = 4;
            this.btnAddGroup.Text = "Add Group...";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnEditTest
            // 
            this.btnEditTest.Location = new System.Drawing.Point(110, 317);
            this.btnEditTest.Name = "btnEditTest";
            this.btnEditTest.Size = new System.Drawing.Size(84, 39);
            this.btnEditTest.TabIndex = 5;
            this.btnEditTest.Text = "Set Test Selections...";
            this.btnEditTest.UseVisualStyleBackColor = true;
            this.btnEditTest.Click += new System.EventHandler(this.btnEditTest_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(110, 266);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(84, 39);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run Selected Test";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(291, 317);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 39);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Save Report...";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnEditResult
            // 
            this.btnEditResult.Location = new System.Drawing.Point(201, 317);
            this.btnEditResult.Name = "btnEditResult";
            this.btnEditResult.Size = new System.Drawing.Size(84, 39);
            this.btnEditResult.TabIndex = 8;
            this.btnEditResult.Text = "Set Result Approved";
            this.btnEditResult.UseVisualStyleBackColor = true;
            this.btnEditResult.Click += new System.EventHandler(this.btnEditResult_Click);
            // 
            // btnAddTest
            // 
            this.btnAddTest.Location = new System.Drawing.Point(18, 317);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(84, 39);
            this.btnAddTest.TabIndex = 9;
            this.btnAddTest.Text = "Add New Test...";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(200, 266);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(84, 39);
            this.btnRunAll.TabIndex = 10;
            this.btnRunAll.Text = "Run All Tests";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // SimpleUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRunAll);
            this.Controls.Add(this.btnAddTest);
            this.Controls.Add(this.btnEditResult);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnEditTest);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertiesView);
            this.Controls.Add(this.treeViewTests);
            this.Name = "SimpleUIControl";
            this.Size = new System.Drawing.Size(396, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewTests;
        private System.Windows.Forms.TreeView propertiesView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnEditTest;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnEditResult;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
