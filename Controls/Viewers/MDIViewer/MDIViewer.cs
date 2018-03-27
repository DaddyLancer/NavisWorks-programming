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
// This sample demonstrates how to build an MDI Viewer for Navisworks files using
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

namespace MDIViewer
{
   public partial class MDIViewer : Form, IApplicationGui
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

      #region Initialization and load
      private static AppInfoForm _appInfoForm = new AppInfoForm();
      private static SelectionSetsForm _selectionSetsForm = new SelectionSetsForm();
      private static MyToolPlugin _toolPlugin;

      public MDIViewer()
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

         //Add ApplicationControl to the appInfoForm Tree
         _appInfoForm.AddRootNode(typeof(ApplicationControl), "ApplicationControl", null);

         // Add this EXE to plugin list to load our internal custom plugin
         // CodeBase property gets the location prior to shadow copy
         string my_path = Path.GetFullPath((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
         Autodesk.Navisworks.Api.Application.Plugins.AddPluginAssembly(my_path);

         // Fetch said registered plugin
         _toolPlugin = (MyToolPlugin)Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("MDIViewer.MyToolPlugin.ADSK").LoadPlugin();
      }

      private void MDIViewer_Load(object sender, EventArgs e)
      {
         SetupDocumentToolCombo();
         SetupSelectionBehavior();

         //Assign as Application.GUI
         ApplicationControl.SetApplicationGui(this);
      }

      private void MDIViewer_MdiChildActivate(object sender, EventArgs e)
      {
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            documentTool.Enabled = true;

            //check whether the tool has changed to avoid sending a changed event when unnecessary
            if (documentTool.SelectedItem == null || Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.Value !=
               (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem)
            {
               //Assign the document tool
               documentTool.SelectedItem =
                  Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.Value;
            }
         }
         else
         {
            documentTool.Enabled = false;
         }
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

         ChildViewer childViewer = ActiveMdiChild as ChildViewer;

         //Check the document exists
         if (childViewer != null)
         {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filter;
            //set default filename to Document.SuggestedFileName
            dlg.FileName = childViewer.DocumentControl.Document.SuggestedFileName;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               filename = dlg.FileName;
            }
         }

         return filename;
      }

      private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChildViewer childViewer = ActiveMdiChild as ChildViewer;

         string fileName = GetOutputFileName("Navisworks files (*.nwd;*.nwc;*.nwf)|*.nwd;*.nwc;*.nwf|All files (*.*)|*.*");
         if (fileName != string.Empty)
         {
            //Save the file
            childViewer.DocumentControl.Document.SaveFile(fileName);
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

      /// <summary>
      /// Loads a document into a new tab in the tab control
      /// </summary>
      /// <param name="fileOperation">The file operation.</param>
      private void LoadDocument(FileOperation fileOperation)
      {
         ChildViewer childViewer = ActiveMdiChild as ChildViewer;
         if (childViewer == null)
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

         //Ask user for file location
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            switch (fileOperation)
            {
               case FileOperation.Open:
                  //get current Window
                  childViewer = ChildViewer.GetChildInstance(dlg.FileName);
                  SetupChildViewer(childViewer);
                  break;
               case FileOperation.Merge:
                  //...Merge the file
                  childViewer.DocumentControl.Document.MergeFile(dlg.FileName);
                  break;
               case FileOperation.Append:
                  //...Append the file
                  childViewer.DocumentControl.Document.AppendFile(dlg.FileName);
                  break;
            }
         }
      }

      private void SetupChildViewer(ChildViewer childViewer)
      {
         if (childViewer != null)
         {
            //assign parent
            childViewer.MdiParent = this;
            //show the child form
            childViewer.Show();
            //bring it to the front
            childViewer.BringToFront();

            //Add to the FormClosing event
            childViewer.FormClosing += new FormClosingEventHandler(childViewer_FormClosing);

            //Add to the appInfoForm Tree
            _appInfoForm.AddRootNode(typeof(DocumentControl), "DocumentControl", childViewer.DocumentControl);
            _appInfoForm.AddRootNode(typeof(ViewControl), "ViewControl", childViewer.ViewControl);
         }
      }

      void childViewer_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (sender is ChildViewer)
         {
            _appInfoForm.RemoveRootNode(((ChildViewer)sender).DocumentControl);
            _appInfoForm.RemoveRootNode(((ChildViewer)sender).ViewControl);
            ((ChildViewer)sender).Dispose();
         }
      }

      private void publishToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Check the document exists
         ChildViewer childViewer = ActiveMdiChild as ChildViewer;
         if (childViewer == null)
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
            childViewer.DocumentControl.Document.PublishFile(dlg.FileName, publishProperties);
         }
      }

      private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ApplicationControlProperties applicationControlProperties = new ApplicationControlProperties();
         applicationControlProperties.ShowDialog();
      }

      private void cullingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (ActiveMdiChild != null && typeof(ChildViewer) == ActiveMdiChild.GetType())
         {
            ((ChildViewer)ActiveMdiChild).DocumentControl.ShowCullingOptionsGui();
         }
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
         if (!_appInfoForm.Visible)
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
         ChildViewer childViewer = ActiveMdiChild as ChildViewer;
         if (childViewer != null)
            childViewer.DocumentControl.Document.CurrentSelection.SelectAll();
      }

      private void fromSearchToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SearchSelect searchDlg = new SearchSelect();
         searchDlg.Show(this);
      }
      #endregion

      #region Window Menu
      private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChildViewer childViewer = ChildViewer.GetNewChildInstance(ActiveMdiChild as ChildViewer);
         SetupChildViewer(childViewer);
      }

      private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LayoutMdi(MdiLayout.Cascade);
      }

      private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LayoutMdi(MdiLayout.TileVertical);
      }

      private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LayoutMdi(MdiLayout.TileHorizontal);
      }

      private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LayoutMdi(MdiLayout.ArrangeIcons);
      }

      private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         foreach (Form childForm in MdiChildren)
         {
            childForm.Close();
         }
      }
      #endregion

      #region ToolBars
      private void ResetFocusToChildWindow()
      {
         //set focus back to view control
         ChildViewer childViewer = ActiveMdiChild as ChildViewer;

         //clear then reactivate the child
         ActivateMdiChild(null);
         ActivateMdiChild(childViewer);
      }

      #region DocumentTool
      private void SetupDocumentToolCombo()
      {
         foreach (object val in Enum.GetValues(typeof(Autodesk.Navisworks.Api.Tool)))
         {
            documentTool.Items.Add(val);
         }
      }

      private void documentTool_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            //Assign the document tool
            //check whether the tool has changed to avoid sending a changed event when unnecessary
            if (Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.Value !=
               (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem)
            {
               Autodesk.Navisworks.Api.Tool tool = (Autodesk.Navisworks.Api.Tool)documentTool.SelectedItem;
               if (tool == Tool.CustomToolPlugin)
                  Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.SetCustomToolPlugin(_toolPlugin);
               else
                  Autodesk.Navisworks.Api.Application.ActiveDocument.Tool.Value = tool;

               //set focus back to view control
               ResetFocusToChildWindow();
            }
         }
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
            ResetFocusToChildWindow();
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

      private void MDIViewer_FormClosing(object sender, FormClosingEventArgs e)
      {
         //ensure API knows there is no longer a GUI to use
         ApplicationControl.SetApplicationGui(null);
      }
   }

   // Tool plugins allow custom handling of mouse events & rendering on the view.
   // Override as required to implement desired tool behavior.
   [Plugin("MDIViewer.MyToolPlugin", "ADSK",
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
