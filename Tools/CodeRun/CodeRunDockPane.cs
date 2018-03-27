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
// This tool enables users to test plugin code within Navisworks without
// having to create an entire plugin first.
//
//------------------------------------------------------------------
#region CodeRunDockPane
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;

namespace CodeRunDockPane
{
   [Plugin("CodeRun.CodeRunDockPane",                   //Plugin name
                    "ADSK",                              //4 character Developer ID or GUID
                    ToolTip = "Application Information", //The tooltip for the item in the ribbon
                    DisplayName = "CodeRun")]            //Display name for the Plugin in the Ribbon
   [DockPanePlugin(755, 575,     //the preferred sizes
      FixedSize = false,           //(Optional) Can the DockPane can grow and shrink
      AutoScroll = true,           //(Optional) Controls the showing and hiding of the scrollbars
      MinimumWidth = 517,          //(Optional) The minimum Width of the Dock Pane
      MinimumHeight = 380          //(Optional) The minimum Height of the Dock Pane
      )]
   public class CodeRunDockPane : DockPanePlugin
   {
      public override Control CreateControlPane()
      {
         CodeRun.Control.CodeRunControl control = new CodeRun.Control.CodeRunControl();
         control.Dock = DockStyle.Fill;

         control.CreateControl();

         return control;
      }

      public override void DestroyControlPane(Control pane)
      {
         CodeRun.Control.CodeRunControl control = pane as CodeRun.Control.CodeRunControl;
         if (control != null)
         {
            control.Dispose();
         }
      }
   }
}
#endregion
