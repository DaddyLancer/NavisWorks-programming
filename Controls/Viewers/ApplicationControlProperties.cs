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
using Autodesk.Navisworks.Api.Controls;

namespace Viewer
{
   public partial class ApplicationControlProperties : Form
   {
      public ApplicationControlProperties()
      {
         InitializeComponent();
      }

      private void ApplicationControlProperties_Load(object sender, EventArgs e)
      {
         //private System.Windows.Forms.CheckBox closeFileAfterLoad;
         closeFileAfterLoad.Checked = ApplicationControl.CloseFileAfterLoad;

         //private System.Windows.Forms.CheckBox isHardwarAccelerationActive;
         isHardwarAccelerationActive.Checked = ApplicationControl.IsHardwareAccelerationActive;

         //private System.Windows.Forms.CheckBox isHardwarAccelerationAvailable;
         isHardwarAccelerationAvailable.Checked = ApplicationControl.IsHardwareAccelerationAvailable;

         //private System.Windows.Forms.CheckBox preferHardwareAcceleration;
         preferHardwareAcceleration.Checked = ApplicationControl.PreferHardwareAcceleration;
      }

      private void ok_Click(object sender, EventArgs e)
      {
         //private System.Windows.Forms.CheckBox closeFileAfterLoad;
         ApplicationControl.CloseFileAfterLoad = closeFileAfterLoad.Checked;

         //private System.Windows.Forms.CheckBox preferHardwareAcceleration;
         ApplicationControl.PreferHardwareAcceleration = preferHardwareAcceleration.Checked;
      }
   }
}
