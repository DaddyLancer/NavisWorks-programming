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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

namespace InputAndRenderHandling
{
   // Add a button to toggle the InputPlugin example. This can be used to turn the example on and off.
   [Plugin("InputAndRenderHandling.EnableInputPluginExample",  // Plugin name
      "ADSK",                                                  // 4 character Developer ID or GUID
      DisplayName = "InputPlugin",                             // Display name for the Plugin in the Ribbon (non-localised if defined here)
      ToolTip = "Enable the InputPlugin example which demonstrates handling mouse and keyboard input.")]  //The tooltip for the item in the ribbon
   [AddInPluginAttribute(AddInLocation.AddIn)]                 // The button will appear in the Add-ins tab
   public class EnableInputPluginExample : AddInPlugin
   {
      public static bool enabled
      { get; private set; }

      public override int Execute(params string[] parameters)
      {
         enabled = !enabled;
         Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
         return 0;
      }

      public override CommandState CanExecute()
      {
         CommandState s = new CommandState();
         s.IsChecked = enabled;
         s.IsVisible = true;
         s.IsEnabled = true;
         return s;
      }
   }

   // The InputPlugin example.
   [Plugin("InputAndRenderHandling.InputPluginExample", "ADSK", DisplayName = "InputPlugin")]
   public class InputPluginExample : InputPlugin
   {
      public override bool MouseDown(View view, KeyModifiers modifiers, ushort button, int x, int y, double timeOffset)
      {
         if (EnableInputPluginExample.enabled)
         {
            bool doubleClick = modifiers.HasFlag(KeyModifiers.DoubleClick);//Determine if trigered by one of the following: WM_LBUTTONDBLCLK, WM_MBUTTONDBLCLK or WM_RBUTTONDBLCLK.

            PickItemResult itemResult = view.PickItemFromPoint(x, y);
            if (itemResult != null)
            {
               ModelItem modelItem = itemResult.ModelItem;
               Debug.WriteLine(modelItem.ClassDisplayName);
            }
         }
         return false;
      }

      public override bool MouseUp(View view, KeyModifiers modifiers, ushort button, int x, int y, double timeOffset)
      {
         if (EnableInputPluginExample.enabled)
         {

         }
         return false;
      } 
      
      public override bool ContextMenu(View view, int x, int y)
      {
         if (EnableInputPluginExample.enabled)
         {

         }
         return false;
      }

      public override bool KeyDown(View view, KeyModifiers modifier, ushort key, double timeOffset)
      {
         Debug.WriteLine(modifier.ToString() + ", " + key);
         return false;
      }
   }

   // Add a button to toggle the RenderPlugin example. This can be used to turn the example on and off.
   [Plugin("InputAndRenderHandling.EnableRenderPluginExample", "ADSK", DisplayName = "RenderPlugin",
      ToolTip = "Enable the RenderPlugin example which demonstrates handling rendering.")]
   [AddInPluginAttribute(AddInLocation.AddIn)]
   public class EnableRenderPluginExample : AddInPlugin
   {
      public static bool enabled
      { get; private set; }

      public override int Execute(params string[] parameters)
      {
         enabled = !enabled;
         Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
         return 0;
      }

      public override CommandState CanExecute()
      {
         CommandState s = new CommandState();
         s.IsChecked = enabled;
         s.IsVisible = true;
         s.IsEnabled = true;
         return s;
      }
   }

   // The RenderPlugin example.
   [Plugin("InputAndRenderHandling.RenderPluginExample", "ADSK", DisplayName = "RenderPlugin")]
   public class RenderPluginExample : RenderPlugin
   {
      public override void OverlayRender(View view, Graphics graphics)
      {
         if (EnableRenderPluginExample.enabled)
         {
            Color skyBlue = Color.FromByteRGB(130, 202, 255);
            graphics.Color(skyBlue, 0.7);

            Point2D bottomLeft = new Point2D(20, 20);
            Point2D topRight = new Point2D(view.Width - 20, 60);
            graphics.Rectangle(bottomLeft, topRight, true);
         }
      }
   }

   // Add a button to enable the ToolPlugin example. 
   // This button will select the example as the current tool. The tool will only be unselected when a different tool (eg. Walk, Orbit) is selected.
   [Plugin("InputAndRenderHandling.EnableToolPluginExample", "ADSK", DisplayName = "ToolPlugin",
      ToolTip = "Enable the ToolPlugin example which demonstrates handling input and rendering.")]
   [AddInPluginAttribute(AddInLocation.AddIn)]
   public class EnableToolPluginExample : AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         ToolPluginRecord toolPluginRecord = (ToolPluginRecord)Application.Plugins.FindPlugin("InputAndRenderHandling.ToolPluginExample.ADSK");
         Application.MainDocument.Tool.SetCustomToolPlugin(toolPluginRecord.LoadPlugin());
         return 0;
      }

      public override CommandState CanExecute()
      {
         CommandState s = new CommandState();
         s.IsChecked = Application.MainDocument.Tool.CustomToolPluginId == "InputAndRenderHandling.ToolPluginExample.ADSK";
         s.IsVisible = true;
         s.IsEnabled = true;
         return s;
      }
   }

   // The ToolPlugin example.
   [Plugin("InputAndRenderHandling.ToolPluginExample", "ADSK", DisplayName = "ToolPlugin")]
   public class ToolPluginExample : ToolPlugin
   {
      ModelItem clickedModel = null;

      public override bool MouseDown(View view, KeyModifiers modifiers, ushort button, int x, int y, double timeOffset)
      {
         bool doubleClick = modifiers.HasFlag(KeyModifiers.DoubleClick);//Determine if trigered by one of the following: WM_LBUTTONDBLCLK, WM_MBUTTONDBLCLK or WM_RBUTTONDBLCLK.

         PickItemResult itemResult = view.PickItemFromPoint(x, y);
         if (itemResult != null)
         {
            clickedModel = itemResult.ModelItem;
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.Render);
         }
         return false;
      }

      public override bool MouseUp(View view, KeyModifiers modifiers, ushort button, int x, int y, double timeOffset)
      {
         return false;
      }

      public override bool ContextMenu(View view, int x, int y)
      {
         return false;
      }
      public override void Render(View view, Graphics graphics)
      {
         if (clickedModel != null)
         {
            Color indianRed = Color.FromByteRGB(247, 93, 89);
            graphics.Color(indianRed, 0.5);

            BoundingBox3D boundingBox = clickedModel.BoundingBox();

            Point3D origin = boundingBox.Min;
            Vector3D xVector = new Vector3D((boundingBox.Max - boundingBox.Min).X, 0, 0);
            Vector3D yVector = new Vector3D(0, (boundingBox.Max - boundingBox.Min).Y, 0);
            Vector3D zVector = new Vector3D(0, 0, (boundingBox.Max - boundingBox.Min).Z);
            graphics.Cuboid(origin, xVector, yVector, zVector, true);
         }
      }
   }
}
