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
// This is the 'Hello World' Sample illustrated in the User guide.
// It demonstrates the various aspects of a basic plugin.
//
//------------------------------------------------------------------
#region HelloWorld

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

//Add two new namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;


namespace BasicPlugIn
{
   [PluginAttribute("BasicPlugIn.ABasicPlugin",                   //Plugin name
                    "ADSK",                                       //4 character Developer ID or GUID
                    ToolTip = "BasicPlugIn.ABasicPlugin tool tip",//The tooltip for the item in the ribbon
                    DisplayName = "Hello World Plugin")]          //Display name for the Plugin in the Ribbon

   public class ABasicPlugin : AddInPlugin                        //Derives from AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "Hello World");
         return 0;
      }
   }
}
#endregion