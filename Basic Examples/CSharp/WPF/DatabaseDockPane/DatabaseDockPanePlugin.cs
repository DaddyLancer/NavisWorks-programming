//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2011 by Autodesk Inc.

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
// This sample illustrates a basic database operation and displayed in
// a dockable pane.
//
//------------------------------------------------------------------
// .Net/Windows
using System;
using System.Collections.Generic;
using System.Data;

using System.Windows.Forms.Integration;
using Autodesk.Navisworks.Api.Plugins;
using NW = Autodesk.Navisworks.Api;
namespace DatabaseDockPane
{
   #region WPFDocPanePlugin

   [Plugin("DatabaseDockPane.DatabaseDockPanePlugin", "ADSK",
      DisplayName = "DatabaseDockPanePlugin",
      ToolTip = "Database WPF Docking Pane Plugin")]
   [DockPanePlugin(150, 200, FixedSize=false)]
   class DatabaseDockPanePlugin : DockPanePlugin
   {
      private WPFHelloWorldControl m_customer_control;
      public override System.Windows.Forms.Control CreateControlPane()
      {
         //create an ElementHost
         ElementHost eh = new ElementHost();

         //assign the control
         eh.AutoSize = true;
         m_customer_control = new WPFHelloWorldControl();
         eh.Child = m_customer_control;

         eh.CreateControl();

         //return the ElementHost
         return eh;
      }

      public override void DestroyControlPane(System.Windows.Forms.Control pane)
      {
         pane.Dispose();
      }

      protected override void OnLoaded()
      {
         // DockPanePlugin loaded, register database loaded and unloaded events.
         NW.Application.MainDocumentChanging += OnMainDocumentChanging;
         NW.Application.ActiveDocument.Database.Loaded += OnDatabaseLoaded;
         NW.Application.ActiveDocument.Database.Unloading += OnDatabaseUnLoading;
      }

      protected override void OnUnloading()
      {
         NW.Application.MainDocumentChanging -= OnMainDocumentChanging;
      }

      private void OnMainDocumentChanging(Object sender, EventArgs args)
      {
         // Close application, unregister events.
         if (NW.Application.ActiveDocument != null)
         {
            NW.Application.ActiveDocument.Database.Loaded -= OnDatabaseLoaded;
            NW.Application.ActiveDocument.Database.Unloading -= OnDatabaseUnLoading;
         }
      }

      private void OnDatabaseLoaded(object sender, EventArgs e)
      {
         // File loaded, enable the buttons and rebuild the table
         m_customer_control.OnEnableButtons(true);
      }

      private void OnDatabaseUnLoading(object sender, EventArgs e)
      {
         // File unloaded. disable the buttons and release the table.
         m_customer_control.OnEnableButtons(false);
      }
   }
   #endregion
}
