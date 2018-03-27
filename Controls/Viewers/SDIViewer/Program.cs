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
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Controls;

namespace SDIViewer
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         #region SDIViewer_Program_Main
         try
         {
            //Set to single document mode
            Autodesk.Navisworks.Api.Controls.ApplicationControl.ApplicationType = ApplicationType.SingleDocument;

            //Initialise the api
            Autodesk.Navisworks.Api.Controls.ApplicationControl.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SDIViewer());

            //Finish use of the API.
            Autodesk.Navisworks.Api.Controls.ApplicationControl.Terminate();
         }
         catch (Autodesk.Navisworks.Api.RuntimeLoaderException)
         {
            MessageBox.Show(
               "The program is trying to use a Navisworks control but the control" +
               "can't find a Navisworks runtime to use. For example if no Navisworks product is installed.");

         }
         #endregion
      }
   }
}
