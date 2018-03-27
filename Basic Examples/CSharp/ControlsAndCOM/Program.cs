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
// This sample illustrates how to use a DocumentControl to load a document
// in conjunction with the existing COM API.
//
//------------------------------------------------------------------
#region ControlsAndCOM
using System;
using System.Windows.Forms;

//Add the namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Controls;

using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.ComApi;


namespace ControlsAndCOM
{
   class Program
   {
      [STAThreadAttribute]
      static void Main(string[] args)
      {
         //Set to single document mode
         Autodesk.Navisworks.Api.Controls.ApplicationControl.ApplicationType = ApplicationType.SingleDocument;

         //Initialise the api
         ApplicationControl.Initialize();

         //Create a DocumentControl
         DocumentControl documentControl = new DocumentControl();

         //Set as main document, needs to be called as COM works on the application's MainDocument
         documentControl.SetAsMainDocument();

         //Dialog for selecting the Location of the file to open
         OpenFileDialog dlg = new OpenFileDialog();

         //Ask user for file location
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            //If the user has selected a valid location, then tell DocumentControl to open the file
            if (documentControl.Document.TryOpenFile(dlg.FileName))
            {
               //Select the first root item using the API
               ModelItemCollection newSelection = new ModelItemCollection();
               newSelection.Add(documentControl.Document.Models.First.RootItem);
               documentControl.Document.CurrentSelection.CopyFrom(newSelection);

               //now query the selection using the COM API
               ComApi.InwOpState10 state;
               state = ComApiBridge.ComApiBridge.State;

               foreach (ComApi.InwOaPath path in state.CurrentSelection.Paths())
               {
                  ComApi.InwOaNode node;
                  node = path.Nodes().Last() as ComApi.InwOaNode;
                  MessageBox.Show("UserName=" + node.UserName);
               }
            }
         }
         
         //Dispose of the DocumentControl
         documentControl.Dispose();

         //Finish use of the API.
         ApplicationControl.Terminate();

      }
   }
}
#endregion