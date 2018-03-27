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
// This sample illustrates the various properties available in the API
//
//------------------------------------------------------------------
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Text;

namespace AppInfo
{
   public partial class AppInfoForm : Form
   {
      public AppInfoForm()
      {
         InitializeComponent();
      }

      public void AddRootNode(Type rootType, string title, object instance)
      {
         appInfoControl.AddRootNode(rootType, title, instance);
      }

      public void RemoveRootNode(object rootObject)
      {
         appInfoControl.RemoveRootNode(rootObject);
      }

      private void AppInfoForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            e.Cancel = true;
            Hide();
         }
         else
         {
            appInfoControl.CleanUp();
         }
      }
   }
}
