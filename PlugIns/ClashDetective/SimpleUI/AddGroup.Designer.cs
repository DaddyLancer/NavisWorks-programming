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
    partial class AddGroup
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
         this.txtBoxGroupName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.chkStatus = new System.Windows.Forms.CheckBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // txtBoxGroupName
         // 
         this.txtBoxGroupName.Location = new System.Drawing.Point(18, 25);
         this.txtBoxGroupName.Name = "txtBoxGroupName";
         this.txtBoxGroupName.Size = new System.Drawing.Size(136, 20);
         this.txtBoxGroupName.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(17, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(92, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "New Group Name";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(15, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(118, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Non-Grouped Results :-";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(15, 267);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(51, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Condition";
         // 
         // chkStatus
         // 
         this.chkStatus.AutoSize = true;
         this.chkStatus.Location = new System.Drawing.Point(18, 283);
         this.chkStatus.Name = "chkStatus";
         this.chkStatus.Size = new System.Drawing.Size(124, 17);
         this.chkStatus.TabIndex = 5;
         this.chkStatus.Text = "Result Status is New";
         this.chkStatus.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(18, 314);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(58, 28);
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(96, 314);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(58, 28);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // listBox1
         // 
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(18, 77);
         this.listBox1.Name = "listBox1";
         this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
         this.listBox1.Size = new System.Drawing.Size(136, 173);
         this.listBox1.TabIndex = 8;
         // 
         // AddGroup
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(173, 353);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.chkStatus);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtBoxGroupName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AddGroup";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add Group";
         this.Load += new System.EventHandler(this.AddGroup_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox listBox1;
    }
}