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

#region LogDockPanePlugin

using System;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;

namespace ClashEventViewer
{
   [Plugin("ClashEventViewer.LogDockPanePlugin",    //Plugin name
            "ADSK",                                 //4 character Developer ID or GUID
            DisplayName = "Clash Event Viewer")]    //Display name for the Plugin (overridden if localized DisplayName available in a name file) 
   [DockPanePlugin(600, 200, AutoScroll = true, FixedSize = false)] // Default size
   // Name of the Localisation file which will contain the localised DisplayName string and any other localised strings
   [Strings("LogDockPanePlugin.name")]
   public class LogDockPanePlugin : DockPanePlugin
   {
      public EventLog LogWindow = null;

      public override Control CreateControlPane()
      {
         try
         {
            //create the control that will be used to display in the pane
            LogWindow = new EventLog();
            LogWindow.AutoSize = true;

            Initialize();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Exception " + ex.GetType().Name + " in CreateControlPane");
         }
         return LogWindow;
      }

      public override void DestroyControlPane(Control pane)
      {
         try
         {
            Uninitialize();
            pane.Dispose();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Exception " + ex.GetType().Name + " in DestroyControlPane");
         }
      }

      /// <summary>
      /// This is the root document for all model interaction via the API. It contains a set
      /// of document-parts, each dedicated to a particular aspect of the model properties 
      /// and behaviour.
      /// </summary>
      private Document document = null;

      /// <summary>
      /// This is the document-part associated with Clash Detective. Currently there is 
      /// only one. It provides the root access to all Clash data via the API.
      /// </summary>
      private DocumentClash DocumentClash
      {
         get { return document == null ? null : document.GetClash(); }
      }

      /// <summary>
      /// Initialization method that attaches handlers to all events that we are interested in
      /// </summary>
      private void Initialize()
      {
         try
         {
            InitializeUIStrings();

            document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document != null)
            {
               // Occurs when the TestsData contained in this object have changed. 
               DocumentClash.TestsData.Changed += new EventHandler<SavedItemChangedEventArgs>(TestsData_Changed);
               // Occurs when the collection of Models has changed, when a different model is opened, or a model is appended or merged. 
               document.Models.CollectionChanged += new EventHandler<EventArgs>(Models_CollectionChanged);

               // Occurs when a Transaction (multiple batched edits) begins, before any of the edits in the transaction take place.
               document.TransactionBeginning += new EventHandler<EventArgs>(MainDocument_TransactionBeginning);
               // Occurs when a Transaction (multiple batched edits) has ended and all the edits have been completed or rolled back. 
               document.TransactionEnded += new EventHandler<EventArgs>(MainDocument_TransactionEnded);
               // Occurs when the Viewpoint contained in this object has changed. 
               document.CurrentViewpoint.Changed += new EventHandler<EventArgs>(CurrentViewpoint_Changed);

               docTitle = document.Title;
               Log(loggingFor + " " + docTitle);
            }
         }
         catch { }
      }

      /// <summary>
      /// Tear-down when application is closing to disconnect event handlers, and any other finalisation.
      /// </summary>
      private void Uninitialize()
      {
         try
         {
            if (document != null)
            {
               document.Models.CollectionChanged -= new EventHandler<EventArgs>(Models_CollectionChanged);
               DocumentClash.TestsData.Changed -= new EventHandler<SavedItemChangedEventArgs>(TestsData_Changed);
            }

            if (LogWindow.SaveFile != null)
               LogWindow.SaveFile.Close();

            LogWindow = null;
            document = null;
         }
         catch { }
      }

      private string docTitle = null;
      private string prefix = "";
      private string loggingFor = "<Resource not found>";
      private string viewpointChanged = "<Resource not found>";
      private string transaction = "<Resource not found>";
      private string documentAdded = "<Resource not found>";
      private string mainDocumentChanged = "<Resource not found>";
      private string testDataChangedFormat = "<Resource not found>";

      /// <summary>
      /// Gets localized strings from the 'name' file to generate messages in the event log when
      /// the events occur.
      /// </summary>
      private void InitializeUIStrings()
      {
         loggingFor = this.TryGetString("LoggingFor");
         viewpointChanged = this.TryGetString("ViewpointChanged");
         transaction = this.TryGetString("Transaction");
         documentAdded = this.TryGetString("DocumentAdded");
         mainDocumentChanged = this.TryGetString("MainDocumentChanged");
         testDataChangedFormat = this.TryGetString("TestDataChangedFormat");

         LogWindow.UserComment = this.TryGetString("UserComment");
         LogWindow.UserCommentToolTip = this.TryGetString("UserCommentToolTip");
         LogWindow.AddCommentToolTip = this.TryGetString("AddCommentToolTip");
         LogWindow.ClearToolTip = this.TryGetString("ClearToolTip");
      }

      #region Event Handlers - each handler generates a message in the log window indicating the event

      private void CurrentViewpoint_Changed(object sender, EventArgs e)
      {
         try
         {
            // Position of the camera within the current Viewpoint within the document 
            Point3D pt = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentViewpoint.Value.Position;

            Log(string .Format("{0} [X={1:0.00} Y={2:0.00} Z={3:0.00}]", viewpointChanged, pt.X, pt.Y, pt.Z));
         }
         catch { }
      }

      private void MainDocument_TransactionEnded(object sender, EventArgs e)
      {
         try
         {
            prefix = prefix.Substring(0, prefix.Length - 2);
            Log("}");
         }
         catch { }
      }

      private void MainDocument_TransactionBeginning(object sender, EventArgs e)
      {
         try
         {
            Log(transaction + " {");
            prefix = prefix + "  ";
         }
         catch { }
      }

      private void Models_CollectionChanged(object sender, EventArgs e)
      {
         try
         {
            if (docTitle == Autodesk.Navisworks.Api.Application.MainDocument.Title)
            {
               // This Model is being unloaded so save logging here.
               return;
            }
            LogWindow.actionLog.Items.Clear();
            docTitle = document.Title;
            Log(loggingFor + " " + docTitle);
         }
         catch { }
      }

      private void TestsData_Changed(object sender, SavedItemChangedEventArgs e)
      {
         try
         {
            SavedItem item = e.Action == SavedItemChangedAction.Remove ? e.OldItem : e.NewItem;
            if (item != null)
            {
               string itemName = string.Empty;
               string sep = string.Empty;

               while (item != null && item.DisplayName != "TestRoot")
               {
                  // This is either a Group or Test
                  itemName = item.DisplayName + sep + itemName;
                  sep = "/";
                  item = item.Parent;
               }
               Log(string.Format(testDataChangedFormat, itemName, e.Action.ToString()));
            }
         }
         catch { }
      }

      #endregion // Event handlers

      /// <summary>
      /// Method that actually does the job of posting a message in the event viewer window.
      /// </summary>
      private void Log(string logMessage)
      {
         if (LogWindow != null)
         {
            string item = prefix + logMessage;
            int index = LogWindow.actionLog.Items.Add(item);
            LogWindow.actionLog.SelectedIndex = index;

            if (LogWindow.SaveFile != null)
            {
               LogWindow.SaveFile.WriteLine(item);
               LogWindow.SaveFile.Flush();
            }
         }
      }
   }
}
#endregion

