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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClashEventViewer
{
   public partial class EventLog : UserControl
   {
      public TextWriter SaveFile { get; set; }

      string userComment = "<Resource not found>";
      public string UserComment
      {
         get { return userComment; }
         set
         {
            userComment = value;
            label1.Text = value + ":";
         }
      }

      public string AddCommentToolTip
      {
         set { toolTip.SetToolTip(btnAddComment, value); }
      }

      public string ClearToolTip
      {
         set { toolTip.SetToolTip(btnClear, value); }
      }

      public string UserCommentToolTip
      {
         set { toolTip.SetToolTip(tbUserComment, value); }
      }

      public EventLog()
      {
         SaveFile = null;
         InitializeComponent();
      }

      private void btnClear_Click(object sender, EventArgs e)
      {
         this.actionLog.Items.Clear();
      }

      private void btnAddComment_Click(object sender, EventArgs e)
      {
         btnAddComment_Click();
      }

      private void btnAddComment_Click()
      {
         if (tbUserComment.Text.Length > 0)
         {
            int index = this.actionLog.Items.Add(UserComment + ": " + tbUserComment.Text);
            if (tbUserComment.AutoCompleteCustomSource.Contains(tbUserComment.Text))
            {
               tbUserComment.AutoCompleteCustomSource.Remove(tbUserComment.Text);
            }
            tbUserComment.AutoCompleteCustomSource.Add(tbUserComment.Text);
            if (tbUserComment.AutoCompleteCustomSource.Count > 16)
               tbUserComment.AutoCompleteCustomSource.RemoveAt(16);
            this.actionLog.SelectedIndex = index;
         }
      }

      private void clearToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.actionLog.Items.Clear();
      }


      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DialogResult result = saveFileDialog.ShowDialog();
         if (result == DialogResult.OK)
         {
            if (SaveFile != null)
            {
               SaveFile.Close();
               SaveFile = null;
            }
            SaveFile = new StreamWriter(saveFileDialog.FileName);
         }
      }

      private void stopSaveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (SaveFile == null)
            return;

         SaveFile.Close();
         SaveFile = null;
      }
   }
}
