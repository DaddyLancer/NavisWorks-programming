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
// a dockable pane.
//
//------------------------------------------------------------------

using System.Windows.Forms.Integration;
using Autodesk.Navisworks.Api.Plugins;

namespace WpfDockPane
{
   #region WPFDocPanePlugin

   [Plugin("WpfDockPane.WPFDocPanePlugin", "ADSK",
      DisplayName = "WPFDocPanePlugin",
      ToolTip = "Basic WPF Docking Pane Plugin")]
   [DockPanePlugin(150, 200, FixedSize=false)]
   class WPFDocPanePlugin : DockPanePlugin
   {
      public override System.Windows.Forms.Control CreateControlPane()
      {
         //create an ElementHost
         ElementHost eh = new ElementHost();

         //assign the control
         eh.AutoSize = true;
         eh.Child = new WPFHelloWorldControl();

         eh.CreateControl();

         //return the ElementHost
         return eh;
      }

      public override void DestroyControlPane(System.Windows.Forms.Control pane)
      {
         pane.Dispose();
      }
   }
   #endregion
}
