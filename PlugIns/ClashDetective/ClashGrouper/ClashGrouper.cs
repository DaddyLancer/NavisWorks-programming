//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2013 by Autodesk Inc.

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
using Autodesk.Navisworks.Api;
using WF = System.Windows.Forms;

namespace ClashDetective
{
    // AddIn plugin to show/hide the Clash Detective Addin 
    [PluginAttribute("ClashDetectiveClashGrouper",  //Plugin name
                        "ADSK",           //4 character Developer ID or GUID
                        ToolTip = "Groups clashes according to the items involved", //The tooltip for the item in the ribbon
                        DisplayName = "Clash Grouper")]   //Display name for the Plugin in the Ribbon
   
    // LoadForCanExecute specifies if CanExecuteCommand should cause the Plugin to load
    // Plug-ins are loaded on demand, and will otherwise appear enabled until the user
    // clicks on them and causes them to load.
    [AddInPluginAttribute(AddInLocation.AddIn,
                            LoadForCanExecute=true)]

    class ClashGrouper : AddInPlugin
    {
        public override CommandState CanExecute()
        {
            // NOTE: All methods called from Navisworks should catch handle 
            //       their own excepetions.
            try
            {
                //Inactive if there is no document open or there are no clash tests
                if (Application.MainDocument == null 
                    || Application.MainDocument.IsClear 
                    || Application.MainDocument.GetClash() == null
                    || Application.MainDocument.GetClash().TestsData.Tests.Count == 0) return new CommandState(false);
            }
            catch
            {
                return new CommandState(false);
            }
            return new CommandState(true);
        }

        ClashGrouperDialog theDialog;

        protected override void OnLoaded()
        {
            theDialog = new ClashGrouperDialog();
            ClashGrouperUtils.Init();
        }

        public override int Execute(params string[] parameters)
        {
            theDialog.Setup();
            theDialog.ShowDialog();
            return 0;
        }
    }
}
