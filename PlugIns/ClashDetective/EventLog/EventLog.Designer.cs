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

namespace ClashEventViewer
{
   partial class EventLog
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
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stopSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolTip = new System.Windows.Forms.ToolTip(this.components);
         this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
         this.actionLog = new System.Windows.Forms.ListBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tbUserComment = new System.Windows.Forms.TextBox();
         this.btnAddComment = new System.Windows.Forms.Button();
         this.btnClear = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.contextMenuStrip1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.stopSaveToolStripMenuItem});
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size(166, 70);
         // 
         // clearToolStripMenuItem
         // 
         this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
         this.clearToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.clearToolStripMenuItem.Text = "&Clear";
         this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.saveToolStripMenuItem.Text = "&Start file output...";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
         // 
         // stopSaveToolStripMenuItem
         // 
         this.stopSaveToolStripMenuItem.Name = "stopSaveToolStripMenuItem";
         this.stopSaveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.stopSaveToolStripMenuItem.Text = "S&top file output";
         this.stopSaveToolStripMenuItem.Click += new System.EventHandler(this.stopSaveToolStripMenuItem_Click);
         // 
         // saveFileDialog
         // 
         this.saveFileDialog.Filter = "Log Files |*.log|All Files | *.*";
         this.saveFileDialog.SupportMultiDottedExtensions = true;
         this.saveFileDialog.Title = "Save Event Ouptut...";
         // 
         // actionLog
         // 
         this.actionLog.ContextMenuStrip = this.contextMenuStrip1;
         this.actionLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.actionLog.FormattingEnabled = true;
         this.actionLog.Location = new System.Drawing.Point(0, 0);
         this.actionLog.Margin = new System.Windows.Forms.Padding(0);
         this.actionLog.Name = "actionLog";
         this.actionLog.Size = new System.Drawing.Size(596, 147);
         this.actionLog.TabIndex = 0;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.btnClear);
         this.groupBox1.Controls.Add(this.btnAddComment);
         this.groupBox1.Controls.Add(this.tbUserComment);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.groupBox1.Location = new System.Drawing.Point(0, 147);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(596, 49);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         // 
         // tbUserComment
         // 
         this.tbUserComment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
         this.tbUserComment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.tbUserComment.Location = new System.Drawing.Point(116, 19);
         this.tbUserComment.Name = "tbUserComment";
         this.tbUserComment.Size = new System.Drawing.Size(267, 20);
         this.tbUserComment.TabIndex = 4;
         // 
         // btnAddComment
         // 
         this.btnAddComment.Location = new System.Drawing.Point(393, 14);
         this.btnAddComment.Name = "btnAddComment";
         this.btnAddComment.Size = new System.Drawing.Size(83, 30);
         this.btnAddComment.TabIndex = 3;
         this.btnAddComment.Text = "&Add Comment";
         this.btnAddComment.UseVisualStyleBackColor = true;
         this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
         // 
         // btnClear
         // 
         this.btnClear.Location = new System.Drawing.Point(484, 14);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(83, 30);
         this.btnClear.TabIndex = 1;
         this.btnClear.Text = "&Clear Log";
         this.btnClear.UseVisualStyleBackColor = true;
         this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(6, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(96, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "&User Comment :";
         // 
         // EventLog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.actionLog);
         this.Controls.Add(this.groupBox1);
         this.Margin = new System.Windows.Forms.Padding(0);
         this.Name = "EventLog";
         this.Size = new System.Drawing.Size(596, 196);
         this.contextMenuStrip1.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ToolTip toolTip;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.SaveFileDialog saveFileDialog;
      private System.Windows.Forms.ToolStripMenuItem stopSaveToolStripMenuItem;
      public System.Windows.Forms.ListBox actionLog;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.Button btnAddComment;
      private System.Windows.Forms.TextBox tbUserComment;
   }
}