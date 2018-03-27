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
    [Plugin("ClashMarkersDockPanePlugin",  //Plugin name
           "ADSK",                         //4 character Developer ID or GUID
           ToolTip = "Clash Markers Dock Pane",       //The tooltip for the item in the ribbon
           DisplayName = "Clash Markers Dock Pane")]  //Display name for the Plugin in the Ribbon
    [DockPanePlugin(312, 376, AutoScroll = false, FixedSize = false)] // Default size
    class ClashMarkersAddinDockPane : DockPanePlugin
    {
        public ClashMarkersControl Pane;

        public override Control CreateControlPane()
        {
            Pane = null;
            // NOTE: All methods called from Navisworks should catch & handle 
            //       their own exceptions.
            try
            {
                Pane = new ClashMarkersControl();
                Pane.Dock = DockStyle.Fill;
                Pane.CreateControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
            return Pane;
        }

        public override void DestroyControlPane(Control Pane)
        {
            // NOTE: All methods called from Navisworks should catch handle 
            //       their own exceptions.
            try
            {
                ClashMarkersControl Control = Pane as ClashMarkersControl;
                if (Control != null)
                {
                    Control.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        public override void OnVisibleChanged()
        {
            //When the dock window is closed, deactivate the plugin.
            EnableClashMarkers.SetEnabled(Visible);
        }
    }
}