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

using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Windows.Forms;

namespace ClashDetective
{
   // AddIn plugin to show/hide the Clash Detective Addin 
   [PluginAttribute("ClashDetectiveSimpleUIAddin",  //Plugin name
                     "ADSK",           //4 character Developer ID or GUID
                     ToolTip = "Clash Detective API Sample", //The tooltip for the item in the ribbon
                     DisplayName = "Clash Detective Simple UI")]   //Display name for the Plugin in the Ribbon
   
   // LoadForCanExecute specifies if CanExecuteCommand should cause the Plugin to load
   // Plug-ins are loaded on demand, and will otherwise appear enabled until the user
   // clicks on them and causes them to load.
   [AddInPluginAttribute(AddInLocation.AddIn,
                         LoadForCanExecute=true)]

   class SimpleUI : AddInPlugin
   {
      public override CommandState CanExecute()
      {
         // NOTE: All methods called from Navisworks should catch handle 
         //       their own excepetions.
         try
         {
            // This holds the document-parts associated with Clash Detective. 
            // Currently there is only one. 
            DocumentClash documentClash = Autodesk.Navisworks.Api.Application.MainDocument.GetClash();

            // Only enabled if there are tests
            if (documentClash == null ||
                documentClash.TestsData == null ||
                documentClash.TestsData.Tests == null ||
                documentClash.TestsData.Tests.Count == 0)
               return new CommandState(false);
         }
         catch
         {
            return new CommandState(false);
         }
         return new CommandState(true);
      }

      public override int Execute(params string[] parameters)
      {
         // NOTE: All methods called from Navisworks should catch and handle 
         //       their own exceptions.
         try
         {
            //Find the plugin
            PluginRecord pr =
               Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClashDetectiveSimpleUIPlugin.ADSK");

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
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
         return 0;
      }
   }
}
