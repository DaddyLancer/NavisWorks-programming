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
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Controls;

namespace MDIViewer
{
   public partial class ChildViewer : Form
   {
      public ChildViewer()
      {
         InitializeComponent();
      }

      private DocumentControl _documentControl = null;

      public DocumentControl DocumentControl
      {
         get
         {
            return _documentControl;
         }
         set
         {
            _documentControl = value;
            //pair the documentControl to the ViewControl
            viewControl.DocumentControl = _documentControl;
         }
      }

      public ViewControl ViewControl
      {
         get
         {
            return viewControl;
         }
      }

      #region static variables and methods
      private class DocumentControlInfo
      {
         public int nextWindowNumber;
         public int instances;

         public DocumentControlInfo()
         {
            nextWindowNumber = 1;
            instances = 1;
         }
      }

      static Dictionary<DocumentControl, DocumentControlInfo> documentControlInfo = new Dictionary<DocumentControl,DocumentControlInfo>();
      public static ChildViewer GetChildInstance(string fileName)
      {
         ChildViewer childViewer = new ChildViewer();
         DocumentControl documentControl = new DocumentControl();
         DocumentControlInfo docInfo = new DocumentControlInfo();
         //Add to the list of DocumentControls in use
         documentControlInfo.Add(documentControl, docInfo);

         if (documentControl.Document.TryOpenFile(fileName))
         {
            //set the window title
            childViewer.Text = documentControl.Document.Title;

            //assign the documentControl
            childViewer.DocumentControl = documentControl;

            //return the valid child control
            return childViewer;
         }
         else
         {
            childViewer.Dispose();
            return null;
         }
      }

      public static ChildViewer GetNewChildInstance(ChildViewer oldChildViewer)
      {
         if (oldChildViewer == null)
            return null;

         DocumentControlInfo docInfo;
         if(!documentControlInfo.TryGetValue(oldChildViewer.DocumentControl, out docInfo))
            return null;

         //create a new ChildViewer
         ChildViewer childViewer = new ChildViewer();

         //Assign the documentControl
         childViewer.DocumentControl = oldChildViewer.DocumentControl;

         //set the window title
         childViewer.Text = childViewer.DocumentControl.Document.FileName + ":" + docInfo.nextWindowNumber;

         //increase the number used in the window title
         docInfo.nextWindowNumber++;

         //increase the number of times this DocumentControl is used
         docInfo.instances++;

         return childViewer;
      }
      #endregion

      private void ChildViewer_Activated(object sender, EventArgs e)
      {
         //Give the ViewControl focus
         viewControl.Focus();
         //set the active View (and the ActiveDocument to DocumentControl.Document)
         viewControl.SetActiveView();
      }

      private void ChildViewer_FormClosing(object sender, FormClosingEventArgs e)
      {
         DocumentControlInfo docInfo;
         if (!documentControlInfo.TryGetValue(DocumentControl, out docInfo))
            return;

         docInfo.instances--;

         if (docInfo.instances == 0)
         {
            documentControlInfo.Remove(DocumentControl);
            DocumentControl.Dispose();
         }
      }
   }
}
