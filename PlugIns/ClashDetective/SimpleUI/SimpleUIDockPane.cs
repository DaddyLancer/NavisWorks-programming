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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Navisworks.Api.Plugins;

namespace ClashDetective
{
   /// <summary>
   /// The Clash Detective Addin window works with the Clash data for the currently loaded 
   /// model in the running Navisworks application. It shows how the Clash data for the model 
   /// can be viewed, interrogated, and modified.
   /// 
   /// We suggest you use a relatively samll model when using this sample as we have not
   /// built-in any optimisations for large models or data sets.
   /// </summary>
   [Plugin("ClashDetectiveSimpleUIPlugin",  //Plugin name
           "ADSK",                         //4 character Developer ID or GUID
           ToolTip = "Clash Detective API Sample",       //The tooltip for the item in the ribbon
           DisplayName = "Clash Detective API Sample")]  //Display name for the Plugin in the Ribbon
   [DockPanePlugin(400, 376, AutoScroll = true, FixedSize = false)] // Default size
   class ClashDetectiveAddinDockPane : DockPanePlugin
   {
      public override Control CreateControlPane()
      {
         SimpleUIControl control = null;
         // NOTE: All methods called from Navisworks should catch & handle 
         //       their own excepetions.
         try
         {
            control = new SimpleUIControl();
            control.Dock = DockStyle.Fill;
            control.CreateControl();
            control.RefreshTree();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
         return control;
      }

      public override void DestroyControlPane(Control pane)
      {
         // NOTE: All methods called from Navisworks should catch handle 
         //       their own excepetions.
         try
         {
            SimpleUIControl control = pane as SimpleUIControl;
            if (control != null)
            {
               control.Dispose();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }
   }
}
