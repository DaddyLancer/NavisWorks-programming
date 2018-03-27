//------------------------------------------------------------------
// Navisworks Sample code
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

using System;
using System.Diagnostics;
using System.Text;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Timeliner;


// Example showing how to iterate over Timeliner Tasks & access key properties.
// Any existing Timeliner tasks will have their details dumped to debug output.


namespace Timeliner
{

   [PluginAttribute("Timeliner.DumpTimelinerTasks",                     // Plugin name
                    "ADSK",                                             // Developer ID or GUID
                    ToolTip = "Timeliner.DumpTimelinerTasks tool tip",  // The tooltip for the item in the ribbon
                    DisplayName = "Timeliner:DumpTimelinerTasks")]      // Display name for the Plugin in the Ribbon
   [AddInPlugin(AddInLocation.AddIn)]                                   // Plugin icon location 
   public class DumpTimelinerTasks : AddInPlugin
   { 
      public override int Execute(params string[] parameters)
      {
         Debug.WriteLine("---------");
         Debug.WriteLine("Task List");
         Debug.WriteLine("---------");

         // Iterate over any existing Timeliner Tasks
         DocumentTimeliner doc_timeliner = Application.MainDocument.GetTimeliner();
         foreach (TimelinerTask task in doc_timeliner.Tasks)
         {
            DumpTask(task, 0);
         }

         return 0;
      }


      // Recursive function that will print a Task & any children it has to the output console.
      private void DumpTask(TimelinerTask task, UInt32 level)
      {
         for (Int32 i = 0; i < level; i++)
         {
            Debug.Write("  ");
         }

         StringBuilder builder = new StringBuilder();
         builder.Append(task.DisplayName);
         if (task.PlannedStartDate != null && task.PlannedEndDate != null)
         {
            builder.Append(" Planned Start Date - " + task.PlannedStartDate.ToString() + " Planned End Date - " + task.PlannedEndDate.ToString());
         }
         Debug.WriteLine(builder.ToString());

         foreach (TimelinerTask child in task.Children)
         {
            DumpTask(child, level+1);
         }
      }

   }
}
