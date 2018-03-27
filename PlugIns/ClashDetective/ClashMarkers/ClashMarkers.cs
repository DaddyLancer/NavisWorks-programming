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
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;
using WF = System.Windows.Forms;

namespace ClashDetective
{
    // Add a button, which will be an AddInPlugin, to toggle the ClashMarkers RenderPlugin
    [Plugin("ClashDetectiveClashMarkers",  // Plugin name
        "ADSK",                                                  // 4 character Developer ID or GUID
        DisplayName = "Clash Markers",                             // Display name for the Plugin in the Ribbon (non-localised if defined here)
        ToolTip = "Marks the location of clashes in the main view.")]  //The tooltip for the item in the ribbon
    [AddInPluginAttribute(AddInLocation.AddIn, LoadForCanExecute=true)]  // The button will appear in the Add-ins tab
    public class EnableClashMarkers : AddInPlugin
    {
        public static bool enabled
        { get; private set; }

        public static void SetEnabled(bool Value)
        {
            enabled = Value;
        }

        public static EnableClashMarkers ObjectReference;

        public override CommandState CanExecute()
        {
            CommandState theCommandState = new CommandState(true); //Button is always enabled
            theCommandState.IsChecked = false;
            theCommandState.IsVisible = true;

            PluginRecord DockPane = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClashMarkersDockPanePlugin.ADSK");
            if(DockPane == null) return theCommandState;
            if(!DockPane.IsLoaded) return theCommandState;

            ClashMarkersControl thePane = ((ClashMarkersAddinDockPane)(DockPane.LoadedPlugin)).Pane;
            if(thePane == null) return theCommandState;

            DockPanePlugin thePlugin = (DockPanePlugin)DockPane.LoadedPlugin;
            theCommandState.IsChecked = thePlugin.Visible;
            enabled = thePlugin.Visible;

            return theCommandState;
        }

        protected override void OnLoaded()
        {
            //Store a static reference to the object for convenience.
            ObjectReference = this;
        }

        public override int Execute(params string[] parameters)
        {
            enabled = !enabled;
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);

            try
            {
                //Find the plugin
                PluginRecord pr =
                   Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClashMarkersDockPanePlugin.ADSK");

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
                        if (dpp.Visible) ClashMarkersUtils.UpdateGroupsList();
                    }
                }
            }
            catch (Exception ex)
            {
                WF.MessageBox.Show(ex.Message, ex.GetType().Name);
            }

            return 0;
        }
    }

    // The RenderPlugin, which will handle the actual rendering.
    [Plugin("ClashDetectiveClashMarkers.RenderClashMarkers", "ADSK", DisplayName = "ClashMarkersRenderPlugin")]
    public class RenderClashMarkers : RenderPlugin
    {
        protected override void OnLoaded()
        {
            DocumentClash theDocument = Application.ActiveDocument.GetClash();
            theDocument.TestsData.Changed += TestsData_Changed;
            Application.MainDocument.TransactionBeginning += Transaction_Beginning;
            Application.MainDocument.TransactionEnded += Transaction_Ended;
            Application.GuiDestroying += GuiDestroying;
            ClashMarkersUtils.Init();
            ClashMarkersUtils.UpdateGroupsList();
        }

        void GuiDestroying(object sender, EventArgs e)
        {
            Application.MainDocument.TransactionBeginning -= Transaction_Beginning;
            Application.MainDocument.TransactionEnded -= Transaction_Ended;
            Application.GuiDestroying -= GuiDestroying;
            ClashMarkersUtils.UpdatesSuppressed = true;
        }

        void Transaction_Beginning(object sender, EventArgs e)
        {
            ClashMarkersUtils.UpdatesSuppressed = true;
        }

        void Transaction_Ended(object sender, EventArgs e)
        {
            if (Application.ActiveDocument == null) return;
            ClashMarkersUtils.UpdatesSuppressed = false;
            ClashMarkersUtils.UpdateGroupsList();
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.All);
        }

        void TestsData_Changed(object sender, SavedItemChangedEventArgs e)
        {
            if (!EnableClashMarkers.enabled) return;
            ClashMarkersUtils.UpdateGroupsList();
        }

        public override void OverlayRender(View theView, Graphics theGraphics)
        {
            if (!EnableClashMarkers.enabled) return;
            ClashMarkersUtils.DrawAllMarkers(theGraphics, theView);
        }

        public override void Render(View theView, Graphics theGraphics)
        {
            if (!EnableClashMarkers.enabled) return;
            ClashMarkersUtils.MainRenderDrawing(theGraphics);
        }

        public override BoundingBox3D MakeRenderBoundingBox(View theView)
        {
            if (!(EnableClashMarkers.enabled && ClashMarkersUtils.Draw3DGroupBoxes)) return new BoundingBox3D();
            return ClashMarkersUtils.GetCombinedBoundingBox();
        }
    }

    //The InputPlugin, which will handle clicking on clash markers.
    [Plugin("ClashDetectiveClashMarkers.InputPlugin", "ADSK", DisplayName = "ClashMarkersInputPlugin")]
    public class ClashMarkersInput : InputPlugin
    {
        public override bool MouseDown(View theView, KeyModifiers Modifiers, ushort Button, int x, int y, double TimeOffset)
        {
            //Button: 1 is LMB, 2 is middle button. RMB does not trigger event
            if (!EnableClashMarkers.enabled) return false;
            if (!ClashMarkersUtils.EnableMouseInteractions) return false;
            if (Button != 1 && Button != 2) return false; //If not LMB or middle button

            int MarkerClickRadius = (int) (ClashMarkersUtils.MarkerRadius + ClashMarkersUtils.MarkerOutlineThickness/2);
            double BestDepth = -1;
            ClashResult BestResult = null;

            foreach (ClashMarkersUtils.ResultDrawInformation theInfo in ClashMarkersUtils.ResultDrawList)
            {
                int DistanceFromMarker = (int) Math.Sqrt(Math.Pow(theInfo.Projection.X - x, 2) + Math.Pow(theInfo.Projection.Y - y, 2));

                if (DistanceFromMarker < MarkerClickRadius && ((theInfo.Projection.Depth < BestDepth) || (BestDepth == -1)))
                {
                    BestDepth = theInfo.Projection.Depth;
                    BestResult = theInfo.Result;
                }
            }
            if (BestResult == null) return false; //No marker clicked, do not intercept click

            if (Button == 1) //LMB
            {
                if (Modifiers.HasFlag(KeyModifiers.Ctrl) && Modifiers.HasFlag(KeyModifiers.Shift)) //Control+shift clicking a marker shows only that test
                {
                    Guid TestGuid;
                    if (BestResult.Parent.Parent is ClashTest) TestGuid = BestResult.Parent.Parent.Guid;
                    else TestGuid = BestResult.Parent.Guid;

                    foreach(ClashMarkersUtils.TestDrawInformation theInfo in ClashMarkersUtils.TestsInfo.Values)
                    {
                        if(theInfo.TestGuid != TestGuid) theInfo.DrawTest = false;
                    }
                    
                }
                else if (Modifiers.HasFlag(KeyModifiers.Ctrl)) //Control-clicking a marker shows only that group
                {
                    Guid GroupGuid = BestResult.Parent.Guid;

                    foreach(ClashMarkersUtils.GroupDrawInformation theInfo in ClashMarkersUtils.GroupsInfo.Values)
                    {
                        if (theInfo.GroupGuid != GroupGuid) theInfo.DrawGroup = false;
                    }
                }
                else
                {
                    if (ClashMarkersUtils.SelectionLocked && ClashMarkersUtils.SelectedMarker != Guid.Empty) return false; //Don't intercept clicks when selection is locked.

                    if (BestResult.Guid == ClashMarkersUtils.SelectedMarker) ClashMarkersUtils.SetSelectedMarkerAndSyncPanel(Guid.Empty); //If the selected marker is clicked, deselect it.
                    else ClashMarkersUtils.SetSelectedMarkerAndSyncPanel(BestResult.Guid);
                }
            }
            else //MMB
            {
                if (Modifiers.HasFlag(KeyModifiers.Ctrl) && Modifiers.HasFlag(KeyModifiers.Shift)) //Control+shift clicking a marker hides that test
                {
                    Guid TestGuid;
                    if (BestResult.Parent.Parent is ClashTest) TestGuid = BestResult.Parent.Parent.Guid;
                    else TestGuid = BestResult.Parent.Guid;
                    ClashMarkersUtils.TestsInfo[TestGuid].DrawTest = false;
                }
                else if (Modifiers.HasFlag(KeyModifiers.Ctrl)) //Control-clicking a marker hides that group
                {
                    ClashMarkersUtils.GroupsInfo[BestResult.Parent.Guid].DrawGroup = false;
                }
                else return false; //A plain middle click is not intercepted
            }
            ClashMarkersUtils.TriggerMarkerVisibilityChanged(); //Causes pane to update from ClashMarkersUtils
            return true; //Intercept mouse click to prevent the selected tool from registering the click
        }
    }
}