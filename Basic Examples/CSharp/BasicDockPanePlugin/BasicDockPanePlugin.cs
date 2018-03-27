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
// This sample illustrates a basic Hello world message displayed in
// a dockable pane, and localised.
//
//------------------------------------------------------------------
#region BasicDockPanePlugin

using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;

namespace BasicDockPanePlugin
{
   [Plugin("BasicDockPanePlugin.BasicDockPanePlugin", "ADSK",
      DisplayName = "BasicDockPanePlugin",
      ToolTip = "Basic Docking Pane Plugin")]
   [DockPanePlugin(100, 300)]
   [Strings("BasicDockPanePlugin.ADSK.name")] //name of the Localisation file
   public class BasicDockPanePlugin : DockPanePlugin
   {

      public override Control CreateControlPane()
      {
         //create the control that will be used to display in the pane
         HelloWorldControl control = new HelloWorldControl();

         control.Dock = DockStyle.Fill;

         //localisation
         control.Text = this.TryGetString("HelloWorldText");

         //create the control
         control.CreateControl();

         return control;
      }

      public override void DestroyControlPane(Control pane)
      {
         pane.Dispose();
      }
   }
}
#endregion