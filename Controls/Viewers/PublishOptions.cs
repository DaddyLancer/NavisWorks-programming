//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2010 by Autodesk Inc.

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
//
// This sample demonstrates how to build a Viewer for Navisworks files using
// the Controls part of the API
//
//------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace Viewer
{
   public partial class PublishOptions : Form
   {
      #region Form entries
      public string FileName { get { return fileName.Text; } set { fileName.Text = value; } }
      public bool AllowResave { get { return allowResave.Checked; } set { allowResave.Checked = value; } }
      public string Author { get { return author.Text; } set { author.Text = value; } }
      public string Comments { get { return comments.Text; } set { comments.Text = value; } }
      public string Copyright { get { return copyright.Text; } set { copyright.Text = value; } }
      public bool DisplayAtPassword { get { return displayAtPassword.Checked; } set { displayAtPassword.Checked = value; } }
      public bool DisplayOnOpen { get { return displayOnOpen.Checked; } set { displayOnOpen.Checked = value; } }
      public bool EmbedDatabaseProperties { get { return embedDatabaseProperties.Checked; } set { embedDatabaseProperties.Checked = value; } }
      public bool EmbedTextures { get { return embedTextures.Checked; } set { embedTextures.Checked = value; } }
      public DateTime Expires { get { return expires.Value; } set { expires.Value = value; } }
      public DateTime Published { get { return published.Value; } set { published.Value = value; } }
      public string Keywords { get { return keywords.Text; } set { keywords.Text = value; } }
      public bool PreventObjectPropertyExport { get { return preventObjectPropertyExport.Checked; } set { preventObjectPropertyExport.Checked = value; } }
      public string PublishedFor { get { return publishedFor.Text; } set { publishedFor.Text = value; } }
      public string Publisher { get { return publisher.Text; } set { publisher.Text = value; } }
      public string Subject { get { return subject.Text; } set { subject.Text = value; } }
      public string Title { get { return title.Text; } set { title.Text = value; } }
      public string Password { get { return password.Text; } set { password.Text = value; } }
      #endregion

      public PublishOptions()
      {
         InitializeComponent();
      }

      private void browseFile_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Title = "Publish to";
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            FileName = dlg.FileName;
         }
      }
   }
}
