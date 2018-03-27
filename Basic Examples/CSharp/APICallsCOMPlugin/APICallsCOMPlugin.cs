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
// Demonstrates how to use the COM API from within a plugin.
//
//------------------------------------------------------------------
#region CallingCOMFromPlugin
using System.Windows.Forms;

//Add the namespaces
using Autodesk.Navisworks.Api.Plugins;

using ComApi=Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge=Autodesk.Navisworks.Api.ComApi;

namespace APICallsCOMPlugin
{
   [PluginAttribute("APICallsCOMPlugin.APICallsCOMPlugin",                    //Plugin name
                    "ADSK",                                                   //4 character Developer ID or GUID
                    ToolTip = "Demonstrates using the COM API within a .NET API Plugin", //The tooltip for the item in the ribbon
                    DisplayName = ".NET_COM")]                                     //Display name for the Plugin in the Ribbon

   public class APICallsCOMPlugin : AddInPlugin                               //Derives from AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         // NOTE: All methods called from Navisworks should catch handle 
         //       their own excepetions.
         try
         {
            #region Using_ComApiBridge_State
            ComApi.InwOpState10 state;
            state = ComApiBridge.ComApiBridge.State;

            foreach (ComApi.InwOaPath path in state.CurrentSelection.Paths())
            {
               ComApi.InwOaNode node;
               node = path.Nodes().Last() as ComApi.InwOaNode;
               MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "UserName=" + node.UserName);
            }
            #endregion
         }
         catch { }
         return 0;
      }
   }
}
#endregion
