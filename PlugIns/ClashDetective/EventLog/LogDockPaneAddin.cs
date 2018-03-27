//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2012 by Autodesk Inc.

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
// This sample illustrates a basic Clash API events logger/viewer
// in a dockable pane.
//
//------------------------------------------------------------------
using System;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api;
using System.Windows.Forms;

namespace ClashEventViewer
{
   /// <summary>
   /// This plugin defines the command button that will appear in the Add-ins tab of the ribbon.
   /// </summary>
   /// 
   [Plugin("ClashEventViewer.LogDockPaneAddin",          //Plugin name
           "ADSK",                                       //4 character Developer ID or GUID
           DisplayName = "Clash Event Viewer",                       //Display name for the Plugin in the Ribbon (non-localised if defined here)
           ToolTip = "Shows/hides the Clash Event Viewer")]          //The tooltip for the item in the ribbon

   [AddInPluginAttribute(AddInLocation.AddIn)]    // The button will appear in the Add-ins tab

   // Note: we have not defined a name file for this plugin so the non-localised string defined in
   // attributes will appear in the GUI

   public class LogDockPaneAddin : AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         try
         {
            if (Autodesk.Navisworks.Api.Application.IsAutomated)
            {
               throw new InvalidOperationException("Invalid when running using Automation");
            }
            //Find the plugin
            DockPanePluginRecord pr =
               Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClashEventViewer.LogDockPanePlugin.ADSK") as DockPanePluginRecord;

            if (pr != null && pr.IsEnabled)
            {
               DockPanePlugin dpp = pr.LoadedPlugin;
               //check if it needs loading
               if (dpp == null)
               {
                  dpp = pr.TryLoadPlugin();
               }

               if (dpp != null)
               {
                  //switch the Visible flag
                  dpp.Visible = !dpp.Visible;
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Exception " + ex.GetType().Name + " in Execute");
         }
         return 0;
      }
   }
}
