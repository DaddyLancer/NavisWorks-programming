using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublishFile
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

      public string[] Files
      {
         get
         {
            string[] files = new string[InputFiles.Items.Count];
            for (int i = 0; i < InputFiles.Items.Count; i++)
            {
               files[i] = InputFiles.Items[i].ToString();
            }
            return files;
         }
      }
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

      private void AddFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Title = "File To Add";
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            InputFiles.Items.Add(dlg.FileName);
         }
      }

      private void RemoveFile_Click(object sender, EventArgs e)
      {
         while (InputFiles.SelectedItems.Count > 0)
         {
            InputFiles.Items.Remove(InputFiles.SelectedItems[0]);
         }
      }
   }
}
