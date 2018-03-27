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

namespace ClashDetective
{
   partial class TestEdit
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
         this.btnSetSelection = new System.Windows.Forms.Button();
         this.cbSelfIntersect = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.rbSelectionA = new System.Windows.Forms.RadioButton();
         this.rbSelectionB = new System.Windows.Forms.RadioButton();
         this.btnDone = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(6, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(234, 44);
         this.label1.TabIndex = 0;
         this.label1.Text = "Select one or more elements in the view, select A or B and click the button below" +
    ".";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // btnSetSelection
         // 
         this.btnSetSelection.Location = new System.Drawing.Point(73, 176);
         this.btnSetSelection.Name = "btnSetSelection";
         this.btnSetSelection.Size = new System.Drawing.Size(90, 36);
         this.btnSetSelection.TabIndex = 1;
         this.btnSetSelection.Text = "Set Selection";
         this.btnSetSelection.UseVisualStyleBackColor = true;
         this.btnSetSelection.Click += new System.EventHandler(this.btnSetSelection_Click);
         // 
         // cbSelfIntersect
         // 
         this.cbSelfIntersect.AutoSize = true;
         this.cbSelfIntersect.Location = new System.Drawing.Point(86, 147);
         this.cbSelfIntersect.Name = "cbSelfIntersect";
         this.cbSelfIntersect.Size = new System.Drawing.Size(87, 17);
         this.cbSelfIntersect.TabIndex = 3;
         this.cbSelfIntersect.Text = "Self-intersect";
         this.cbSelfIntersect.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.rbSelectionB);
         this.groupBox1.Controls.Add(this.rbSelectionA);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(13, 13);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(246, 125);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Set Test Selection";
         // 
         // rbSelectionA
         // 
         this.rbSelectionA.AutoSize = true;
         this.rbSelectionA.Location = new System.Drawing.Point(22, 86);
         this.rbSelectionA.Name = "rbSelectionA";
         this.rbSelectionA.Size = new System.Drawing.Size(79, 17);
         this.rbSelectionA.TabIndex = 5;
         this.rbSelectionA.TabStop = true;
         this.rbSelectionA.Text = "Selection A";
         this.rbSelectionA.UseVisualStyleBackColor = true;
         // 
         // rbSelectionB
         // 
         this.rbSelectionB.AutoSize = true;
         this.rbSelectionB.Location = new System.Drawing.Point(131, 86);
         this.rbSelectionB.Name = "rbSelectionB";
         this.rbSelectionB.Size = new System.Drawing.Size(79, 17);
         this.rbSelectionB.TabIndex = 6;
         this.rbSelectionB.TabStop = true;
         this.rbSelectionB.Text = "Selection B";
         this.rbSelectionB.UseVisualStyleBackColor = true;
         // 
         // btnDone
         // 
         this.btnDone.Location = new System.Drawing.Point(172, 176);
         this.btnDone.Name = "btnDone";
         this.btnDone.Size = new System.Drawing.Size(90, 36);
         this.btnDone.TabIndex = 5;
         this.btnDone.Text = "Done";
         this.btnDone.UseVisualStyleBackColor = true;
         this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
         // 
         // TestEdit
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(274, 227);
         this.Controls.Add(this.btnDone);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.cbSelfIntersect);
         this.Controls.Add(this.btnSetSelection);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "TestEdit";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Set Test Selections";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnSetSelection;
      private System.Windows.Forms.CheckBox cbSelfIntersect;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton rbSelectionB;
      private System.Windows.Forms.RadioButton rbSelectionA;
      private System.Windows.Forms.Button btnDone;
   }
}