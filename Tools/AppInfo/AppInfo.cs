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
// This sample illustrates the various aspects available as properties
//
//------------------------------------------------------------------

using System;
using Autodesk.Navisworks.Api.Plugins;

namespace AppInfo
{
   [PluginAttribute("AppInfo.AppInfo",                   //Plugin name
                    "ADSK",                              //4 character Developer ID or GUID
                    ToolTip = "Application Information", //The tooltip for the item in the ribbon
                    DisplayName = "AppInfo")]            //Display name for the Plugin in the Ribbon
#region AddInPluginAttribute_usage
   [AddInPluginAttribute(AddInLocation.AddIn)]
#endregion
   public class AppInfo : AddInPlugin                    //Derives from AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         if (Autodesk.Navisworks.Api.Application.IsAutomated)
         {
            throw new InvalidOperationException("Invalid when running using Automation");
         }

         //Find the plugin
         PluginRecord pr =
            Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("AppInfo.AppInfoDockPane.ADSK");

         if (pr != null && pr is DockPanePluginRecord && pr.IsEnabled)
         {
            //check if it needs loading
            if (pr.LoadedPlugin == null)
            {
               pr.LoadPlugin();
            }

            DockPanePlugin dpp = pr.LoadedPlugin as DockPanePlugin;
            if (dpp != null)
            {
               //switch the Visible flag
               dpp.Visible = !dpp.Visible;
            }
         }

         return 0;
      }
   }
}
