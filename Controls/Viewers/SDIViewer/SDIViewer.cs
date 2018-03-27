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
// This sample demonstrates how to build an SDI Viewer for Navisworks files using
// the Controls part of the API
//
//------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AppInfo;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.ApplicationParts;
using Autodesk.Navisworks.Api.Controls;
using Autodesk.Navisworks.Api.Plugins;
using Viewer;


namespace SDIViewer
{
   public partial class SDIViewer : Form, IApplicationGui
   {
      #region IApplicationGui Members
      public IWin32Window MainWindow
      {
         get { return this; }
      }

      public bool GetDockPanePluginVisibility(string pluginId)
      {
         return false;
      }

      public void SetDockPanePluginVisibility(string pluginId, bool visible)
      {
      }

      public void SetRaiseIdle(Action<EventArgs> raiseIdle)
      {
      }

      public void SetDockPanePluginActive(string pluginId)
      {
      }

      public bool IsSignedIn()
      {
         return false;
      }

      public bool SignIn()
      {
         return false;
      }

      public string SignInUserName
      {
         get { return String.Empty; }
      }

      public bool SignOut()
      {
         return false;
      }

      #endregion

      #region Properties
      public DocumentControl DocumentControl
      {
         get
         {
            return documentControl;
         }
      }

      public ViewControl ViewControl1
      {
         get
         {
            return viewControl1;
         }
      }

      //ViewControl for split pane
      private Autodesk.Navisworks.Api.Controls.ViewControl viewControl2;

      public ViewControl ViewControl2
      {
         get
         {
            return viewControl2;
         }
      }
      #endregion

      #region Initialization and load
      private static AppInfoForm _appInfoForm = new AppInfoForm();
      private static SelectionSetsForm _selectionSetsForm = new SelectionSetsForm();
      private static MyToolPlugin _toolPlugin;

      public SDIViewer()
      {
         InitializeComponent();
         #region ProgressViewer_AddingEventHandlers
         Autodesk.Navisworks.Api.Application.ProgressBeginning += new EventHandler<Autodesk.Navisworks.Api.ProgressBeginningEventArgs>(Application_ProgressBeginning);

         Autodesk.Navisworks.Api.Application.ProgressUpdating += new EventHandler<Autodesk.Navisworks.Api.ProgressUpdatingEventArgs>(Application_ProgressUpdating);

         Autodesk.Navisworks.Api.Application.ProgressErrorReporting += new EventHandler<Autodesk.Navisworks.Api.ProgressErrorReportingEventArgs>(Application_ProgressErrorReporting);

         Autodesk.Navisworks.Api.Application.ProgressMessageReporting += new EventHandler<Autodesk.Navisworks.Api.ProgressMessageReportingEventArgs>(Application_ProgressMessageReporting);

         Autodesk.Navisworks.Api.Application.ProgressEnded += new EventHandler<Autodesk.Navisworks.Api.ProgressEndedEventArgs>(Application_ProgressEnded);

         progressBar.ProgressBar.Maximum = 100;
         #endregion

         #region ToolChanged event addition
         documentControl.Document.Tool.Changed += new EventHandler<EventArgs>(Tool_Changed);
         #endregion

         //Add ApplicationControl to the appInfoForm Tree
         _appInfoForm.AddRootNode(typeof(ApplicationControl), "ApplicationControl", null);

         // Add this EXE to plugin list to load our internal custom plugin
         // CodeBase property gets the location prior to shadow copy
         string my_path = Path.GetFullPath((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
         Autodesk.Navisworks.Api.Application.Plugins.AddPluginAssembly(my_path);

         // Fetch said registered plugin
         _toolPlugin = (MyToolPlugin)Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("SDIViewer.MyToolPlugin.ADSK").LoadPlugin();
      }


      private void SDIViewer_Load(object sender, EventArgs e)
      {
         //Assign as Application.GUI
         ApplicationControl.SetApplicationGui(this);

         //Call set as main Document
         documentControl.SetAsMainDocument();

         SetupDocumentToolCombo();
         SetupSelectionBehavior();

         //Add to the appInfoForm Tree
         _appInfoForm.AddRootNode(typeof(DocumentControl), "DocumentControl", DocumentControl);
         _appInfoForm.AddRootNode(typeof(ViewControl), "ViewControl1", ViewControl1);
      }
      #endregion

      #region File Menu
      enum FileOperation
      {
         Open,
         Merge,
         Append
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadDocument(FileOperation.Open);
      }

      private string GetOutputFileName(string filter)
      {
         string filename = string.Empty;
         //Check the document has content
         if (documentControl.Document.IsClear != true)
         {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filter;
            //set default filename to Document.SuggestedFileName
            dlg.FileName = documentControl.Document.SuggestedFileName;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               filename = dlg.FileName;
            }
         }

         return filename;
      }

      private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string fileName = GetOutputFileName("Navisworks files (*.nwd;*.nwc;*.nwf)|*.nwd;*.nwc;*.nwf|All files (*.*)|*.*");
         if (fileName != string.Empty)
         {
            //Save the file
            documentControl.Document.SaveFile(fileName);
         }
      }

      private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadDocument(FileOperation.Merge);
      }

      private void appendToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadDocument(FileOperation.Append);
      }

      private void LoadDocument(FileOperation fileOperation)
      {
         if (documentControl.Document.IsClear == true)
            fileOperation = FileOperation.Open;

         //Dialog for selecting the Location of the file to open
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = "All files (*.*)|*.*";
         switch (fileOperation)
         {
            case FileOperation.Merge:
               dlg.Title = "Merge File from";
               break;
            case FileOperation.Append:
               dlg.Title = "Append File from";
               break;
            default:
               break;
         }

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            switch (fileOperation)
            {
               case FileOperation.Open:
                  //If the user has selected a valid location, then tell DocumentControl to open the file
                  //As DocumentCtrl is linked to ViewControl
                  documentControl.Document.TryOpenFile(dlg.FileName);

                  //update document tool
                  documentTool.SelectedItem = documentControl.Document.Tool.Value;
                  documentTool.Enabled = true;
                  break;
               case FileOperation.Merge:
                  //...Merge the file
                  documentControl.Document.MergeFile(dlg.FileName);
                  break;
               case FileOperation.Append:
                  //...Append the file
                  documentControl.Document.AppendFile(dlg.FileName);
                  break;
            }

            //set the title
            Text = documentControl.Document.Title;
         }
      }

      private void publishToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Check the document has content
         if (documentControl.Document.IsClear == true)
            return;

         PublishOptions dlg = new PublishOptions();

         //Get the publish options
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            PublishProperties publishProperties = new PublishProperties();
            publishProperties.AllowResave = dlg.AllowResave;
            publishProperties.Author = dlg.Author;
            publishProperties.Comments = dlg.Comments;
            publishProperties.Copyright = dlg.Copyright;
            publishProperties.DisplayAtPassword = dlg.DisplayAtPassword;
            publishProperties.DisplayOnOpen = dlg.DisplayOnOpen;
            publishProperties.EmbedDatabaseProperties = dlg.EmbedDatabaseProperties;
            publishProperties.EmbedTextures = dlg.EmbedTextures;
            publishProperties.ExpiryDate = dlg.Expires;
            publishProperties.Keywords = dlg.Keywords;
            publishProperties.PreventObjectPropertyExport = dlg.PreventObjectPropertyExport;
            publishProperties.PublishDate = dlg.Published;
            publishProperties.PublishedFor = dlg.PublishedFor;
            publishProperties.Publisher = dlg.Publisher;
            publishProperties.Subject = dlg.Subject;
            publishProperties.Title = dlg.Title;
            publishProperties.SetPassword(dlg.Password);

            //publish the file
            documentControl.Document.PublishFile(dlg.FileName, publishProperties);
         }
      }

      private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ApplicationControlProperties applicationControlProperties = new ApplicationControlProperties();
         applicationControlProperties.ShowDialog();
      }

      private void cullingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         documentControl.ShowCullingOptionsGui();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }
      #endregion

      #region View Menu
      private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         toolStrip.Visible = toolBarToolStripMenuItem.Checked;
      }

      private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         statusStrip.Visible = statusBarToolStripMenuItem.Checked;
      }

      private void applicationInformationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(!_appInfoForm.Visible)
            _appInfoForm.Show(this);
      }

      private void selectionSetsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (!_selectionSetsForm.Visible)
            _selectionSetsForm.Show(this);
      }
      #endregion

      #region Selection Menu
      private void focusOnCurrentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null &&
            Autodesk.Navisworks.Api.Application.ActiveDocument.ActiveView != null)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.ActiveView.FocusOnCurrentSelection();
         }
      }

      private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         documentControl.Document.CurrentSelection.SelectAll();
      }

      private void fromSearchToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SearchSelect searchDlg = new SearchSelect();
         searchDlg.Show(this);
      }
      #endregion

      #region ToolBars
      #region DocumentTool
      void Tool_Changed(object sender, EventArgs e)
      {
         if (documentTool.SelectedItem == null ||
            documentControl.Document.Tool.Value != (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem)
         {
            documentTool.SelectedItem = documentControl.Document.Tool.Value;
         }
      }

      private void SetupDocumentToolCombo()
      {
         foreach (object val in Enum.GetValues(typeof(Autodesk.Navisworks.Api.Tool)))
         {
            documentTool.Items.Add(val);
         }
      }

      private void documentTool_SelectedIndexChanged(object sender, EventArgs e)
      {
         //Assign the document tool
         //check whether the tool has changed to avoid sending a changed event when unnecessary
         if (documentControl.Document.Tool.Value !=
            (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem)
         {
            Autodesk.Navisworks.Api.Tool tool = (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem;
            if (tool == Tool.CustomToolPlugin)
               Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.SetCustomToolPlugin(_toolPlugin);
            else
               Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.Value = tool;

            //set focus back to the appropriate view control
            if (viewControl2 != null &&
               viewControl2.View == Autodesk.Navisworks.Api.Application.ActiveDocument.ActiveView)
               viewControl2.Focus();
            else
               viewControl1.Focus();
         }

         //enable Document Tool
         documentTool.Enabled = true;
      }
      #endregion

      #region SelectionBehavior
      //private System.Windows.Forms.ToolStripComboBox selectionBehavior;
      private void SetupSelectionBehavior()
      {

         foreach (object val in Enum.GetValues(typeof(Autodesk.Navisworks.Api.SelectionBehavior)))
         {
            selectionBehavior.Items.Add(val);
         }
         selectionBehavior.SelectedItem = ApplicationControl.SelectionBehavior;
      }

      private void selectionBehavior_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (selectionBehavior.SelectedItem != null &&
            ApplicationControl.SelectionBehavior != (Autodesk.Navisworks.Api.SelectionBehavior)selectionBehavior.SelectedItem)
         {
            ApplicationControl.SelectionBehavior = (Autodesk.Navisworks.Api.SelectionBehavior)selectionBehavior.SelectedItem;

            //set focus back to view control
            viewControl1.Focus();
         }
      }
      #endregion
      #endregion

      #region ProgressViewer_Event_Handlers
      //The following are the declarations for controls in a windows form
      //private System.Windows.Forms.StatusStrip statusStrip;
      //private System.Windows.Forms.ToolStripStatusLabel statusText;
      //private System.Windows.Forms.ToolStripProgressBar progressBar;
      //private System.Windows.Forms.ToolStripStatusLabel statusSubText;

      void UpdateStatusBar()
      {
         statusStrip.Refresh();
      }

      void Application_ProgressBeginning(object sender, Autodesk.Navisworks.Api.ProgressBeginningEventArgs e)
      {
         statusText.Text = e.Title;
         statusSubText.Text = string.Empty;
         progressBar.Visible = true;
         e.Handled = true;
         UpdateStatusBar();
      }

      void Application_ProgressUpdating(object sender, Autodesk.Navisworks.Api.ProgressUpdatingEventArgs e)
      {
         int value = Convert.ToInt32(e.OverallFractionDone * 100.000);
         if (progressBar.ProgressBar.Value != value)
         {
            progressBar.ProgressBar.Value = value;
            e.Handled = true;
            UpdateStatusBar();
         }
      }

      void Application_ProgressMessageReporting(object sender, Autodesk.Navisworks.Api.ProgressMessageReportingEventArgs e)
      {
         if (statusSubText.Text != e.Message)
         {
            statusSubText.Text = e.Message;
            e.Handled = true;
            UpdateStatusBar();
         }
      }

      void Application_ProgressErrorReporting(object sender, Autodesk.Navisworks.Api.ProgressErrorReportingEventArgs e)
      {
         if (MessageBox.Show(e.Message, "Error", MessageBoxButtons.OKCancel) != DialogResult.OK)
         {
            e.Canceled = true;
         }
         e.Handled = true;
         UpdateStatusBar();
      }

      void Application_ProgressEnded(object sender, Autodesk.Navisworks.Api.ProgressEndedEventArgs e)
      {
         statusText.Text = string.Empty;
         statusSubText.Text = string.Empty;
         progressBar.Visible = false;
         UpdateStatusBar();
      }
      #endregion

      #region Window menu

      private void splitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;

         //suspend layout of the splitter and the pane
         splitContainer.SuspendLayout();
         splitContainer.Panel2.SuspendLayout();

         //is splitter to be split
         if (splitContainer.Panel2Collapsed)
         {
            //Remove from AppInfo
            _appInfoForm.RemoveRootNode(viewControl2);

            splitContainer.Panel2.Controls.Remove(viewControl2);
            viewControl2.Dispose();
            viewControl2 = null;

            //set the active View
            viewControl1.SetActiveView();
         }
         else
         {
            //Create the ViewControl in the split pane
            viewControl2 = new Autodesk.Navisworks.Api.Controls.ViewControl();
            viewControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            viewControl2.DocumentControl = documentControl;
            viewControl2.Location = new System.Drawing.Point(0, 0);
            viewControl2.Name = "viewControl2";
            splitContainer.Panel2.Controls.Add(viewControl2);

            //set the active View
            viewControl2.SetActiveView();

            //Add to the AppInfo
            _appInfoForm.AddRootNode(typeof(ViewControl), "ViewControl2", viewControl2);
         }

         //Resume layout and redraw
         splitContainer.Panel2.ResumeLayout(true);
         splitContainer.ResumeLayout(true);

         //set the ckeck for identifying this as split or not
         splitToolStripMenuItem.Checked = !splitContainer.Panel2Collapsed;
      }
      #endregion

      private void SDIViewer_FormClosing(object sender, FormClosingEventArgs e)
      {
         //ensure API knows there is no longer a GUI to use
         ApplicationControl.SetApplicationGui(null);
      }
   }

   // Tool plugins allow custom handling of mouse events & rendering on the view.
   // Override as required to implement desired tool behavior.
   [Plugin("SDIViewer.MyToolPlugin", "ADSK",
      DisplayName = "MyToolPlugin",
      ToolTip = "Primitive Select Custom Tool Plugin")]
   public class MyToolPlugin : ToolPlugin
   {
      public override bool MouseDown(Autodesk.Navisworks.Api.View view, KeyModifiers modifiers, ushort button, int x, int y, double timeOffset)
      {
         // Very simple primitive additive select. Doesn't follow Windows 'standard' of 'mouse down to start select, mouse up if you really mean it'

         PickItemResult result = view.PickItemFromPoint(x, y);
         if (result != null)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Add(result.ModelItem);
            return true;
         }
         // As you can only have one tool plugin active, it isn't actually possible
         // to pass control to another handler at this time. However, good practice
         // to indicate whether you handled the call.
         return false;
      }
   }
}
