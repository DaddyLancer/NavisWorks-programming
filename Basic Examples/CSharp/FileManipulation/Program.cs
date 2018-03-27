//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2009 by Autodesk Inc.

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
// This sample demonstrates how to use the Automation parts of the API
// to open two AutoCad DWG files in Navisworks and save as a single 
// Navisworks file. All without showing the GUI.
//
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManipulation
{
   class Program
   {
      static void Main(string[] args)
      {
         #region OpenSaveHelloWorld
         Autodesk.Navisworks.Api.Automation.NavisworksApplication automationApplication = null;
         try
         {
            //Get Current Working directory
            string workingDir = System.IO.Directory.GetCurrentDirectory().TrimEnd('\\');

            //create NavisworksApplication automation object
            automationApplication =
               new Autodesk.Navisworks.Api.Automation.NavisworksApplication();

            //disable progress whilst we do this procedure
            automationApplication.DisableProgress();

            //Open two AutoCAD files
            automationApplication.OpenFile(workingDir + "\\hello.dwg", workingDir + "\\world.dwg");

            //Save the combination into a Navisworks file
            automationApplication.SaveFile(workingDir + "\\hello_world.nwd");

            //Re-enable progress
            automationApplication.EnableProgress();
         }
         catch (Autodesk.Navisworks.Api.Automation.AutomationException e)
         {
            //An error occurred, display it to the user
            System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
         }
         catch (Autodesk.Navisworks.Api.Automation.AutomationDocumentFileException e)
         {
            //An error occurred, display it to the user
            System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
         }
         finally
         {
            if (automationApplication != null)
            {
               automationApplication.Dispose();
               automationApplication = null;
            }
         }
         #endregion
      }
   }
}
