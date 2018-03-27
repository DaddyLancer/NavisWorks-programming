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
using System.ComponentModel;
//using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using WF = System.Windows.Forms;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;

namespace ClashDetective
{
    public partial class ClashMarkersControl : WF.UserControl
    {
        public ClashMarkersControl()
        {
            InitializeComponent();
        }

        private void ClashMarkersControl_Load(object sender, EventArgs e)
        {
            ClashMarkersUtils.CollectionChanged += new EventHandler(ClashMarkersUtils_CollectionChanged);
            ClashMarkersUtils.SelectedMarkerChanged += new ClashMarkersUtils.SelectedMarkerChangedHandler(ClashMarkersUtils_SelectedMarkerChanged);
            ClashMarkersUtils.MarkerVisibilityChanged += new ClashMarkersUtils.MarkerVisibilityChangedHandler(ClashMarkersUtils_MarkerVisibilityChanged);

            ToolTips.SetToolTip(ZoomToSelectionButton, "Zoom to selected");
            ToolTips.SetToolTip(LockSelectionCheckBox, "Lock selection. Prevents other markers being selected.");
            ToolTips.SetToolTip(ClearSelectionButton, "Clear selection");
            ToolTips.SetToolTip(ShowAllButton, "Show markers for all tests");
            ToolTips.SetToolTip(ShowNoneButton, "Hide markers for all tests");

            BalloonToolTips.AutoPopDelay = 0;
            BalloonToolTips.InitialDelay = 0;
            BalloonToolTips.SetToolTip(IDMarkersOnClickCheckBox,
                "Left-click: Select marker. Clash info is displayed at the top of this pane.\n" +
                "Control + Left-click: Show only this group.\n" +
                "Control + Shift + Left-click: Show only this test.\n\n"
                + "Control + Middle-click: Hide this group.\n"
                + "Control + Shift + Middle-click: Hide this test."
                );

            UpdateSelectedMarkerInfo();
        }

        void ClashMarkersUtils_SelectedMarkerChanged(Guid Marker)
        {
            UpdateSelectedMarkerInfo();
        }

        /// <summary>
        /// Updates display of selected marker from ClashMarkerUtils.SelectedMarker
        /// </summary>
        private void UpdateSelectedMarkerInfo()
        {
            ClashResult Result = Application.MainDocument.GetClash().TestsData.ResolveGuid(ClashMarkersUtils.SelectedMarker) as ClashResult;
            Guid GroupGuid = Guid.Empty;
            Guid TestGuid = Guid.Empty;
            if (Result != null)
            {
                GroupGuid = Result.Parent.Guid;
                if (!(Result.Parent.Parent is ClashTest)) TestGuid = GroupGuid;
                else TestGuid = Result.Parent.Parent.Guid;
            }

            foreach (TestColoringControl theControl in ColoringControls)
            {
                theControl.UpdateSelectedMarker(Result, GroupGuid, TestGuid);
            }

            if (Result == null)
            {
                SelectedMarkerTextBox.Text = "Click on a clash marker for more information.";
                SelectedMarkerTextBox.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
                ZoomToSelectionButton.Enabled = false;
                ClearSelectionButton.Enabled = false;
                return;
            }
            SelectedMarkerTextBox.Text = "Name: " + Result.DisplayName + Environment.NewLine + "Group: ";

            if (Result.Parent is ClashTest) SelectedMarkerTextBox.Text += "";
            else SelectedMarkerTextBox.Text += Result.Parent.DisplayName;

            SelectedMarkerTextBox.Text += Environment.NewLine + "Status: " + Result.Status + Environment.NewLine + "Distance: " + Result.Distance + Environment.NewLine + 
                "Assigned to: " + Result.AssignedTo + Environment.NewLine + "Approved by: " + Result.ApprovedBy;
            SelectedMarkerTextBox.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            SelectedMarkerTextBox.ForeColor = System.Drawing.Color.Black;
            ZoomToSelectionButton.Enabled = true;
            ClearSelectionButton.Enabled = true;
        }

        void ClashMarkersUtils_CollectionChanged(object Sender, EventArgs e)
        {
            UpdateColoringControls();
        }

        void ClashMarkersUtils_MarkerVisibilityChanged()
        {
            foreach (TestColoringControl theControl in ColoringControls)
            {
                theControl.UpdateVisibilityCheckboxes();
            }
        }

        private List<TestColoringControl> ColoringControls = new List<TestColoringControl>();

        /// <summary>
        /// Updates coloring controls from ClashMarkersUtils.
        /// </summary>
        public void UpdateColoringControls()
        {
            DocumentClash theDocument = Autodesk.Navisworks.Api.Application.MainDocument.GetClash();

            foreach (TestColoringControl theControl in ColoringControls)
            {
                theControl.Dispose();
            }
            ColoringControls = new List<TestColoringControl>();
            int x = 8;
            int y = 16;
            foreach(KeyValuePair<Guid, ClashMarkersUtils.TestDrawInformation> thePair in ClashMarkersUtils.TestsInfo)
            {
                TestColoringControl theControl = new TestColoringControl(x, y, thePair.Key);
                ColoringControls.Add(theControl);
                GroupedResultsGroupBox.Controls.Add(theControl);
                y += theControl.Height;
            }
            GroupedResultsGroupBox.Height = y + 8;

            SettingsGroupBox.Location = new System.Drawing.Point(SettingsGroupBox.Location.X, GroupedResultsGroupBox.Location.Y + GroupedResultsGroupBox.Height);

            DrawGroupRectanglesCheckBox.Checked = ClashMarkersUtils.DrawGroupBoxes;
            Draw3DGroupBoxesCheckBox.Checked = ClashMarkersUtils.Draw3DGroupBoxes;
            FillAlphaTrackBar.Value = (int)(ClashMarkersUtils.ClashMarkerAlpha * 20);
            Box3DAlphaTrackBar.Value = (int)(ClashMarkersUtils.GroupBox3DAlpha * 20);
            IDMarkersOnClickCheckBox.Checked = ClashMarkersUtils.EnableMouseInteractions;
        }

        private void DrawGroupRectanglesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClashMarkersUtils.DrawGroupBoxes = DrawGroupRectanglesCheckBox.Checked;
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.All);
        }

        private void Draw3DGroupBoxesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClashMarkersUtils.Draw3DGroupBoxes = Draw3DGroupBoxesCheckBox.Checked;
            if (!DrawGroupRectanglesCheckBox.Checked) DrawGroupRectanglesCheckBox.Checked = true;
            else Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.Render);
        }

        private void FillAlphaTrackBar_Scroll(object sender, EventArgs e)
        {
            ClashMarkersUtils.ClashMarkerAlpha = (decimal) (FillAlphaTrackBar.Value / 20.0);
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
        }

        private void Box3DAlphaTrackBar_Scroll(object sender, EventArgs e)
        {
            ClashMarkersUtils.GroupBox3DAlpha = (decimal)(Box3DAlphaTrackBar.Value / 20.0);
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.Render);
        }

        private void IDMarkersOnClickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClashMarkersUtils.EnableMouseInteractions = IDMarkersOnClickCheckBox.Checked;
            if (!IDMarkersOnClickCheckBox.Checked)
            {
                ClashMarkersUtils.SetSelectedMarker(Guid.Empty);
                UpdateSelectedMarkerInfo();
            }
        }

        private void ClearSelectionButton_Click(object sender, EventArgs e)
        {
            ClashMarkersUtils.SetSelectedMarker(Guid.Empty);
            UpdateSelectedMarkerInfo();
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            foreach(TestColoringControl theControl in ColoringControls)
            {
                theControl.SetDrawTestCheckBox(true);
            }
        }

        private void ShowNoneButton_Click(object sender, EventArgs e)
        {
            foreach (TestColoringControl theControl in ColoringControls)
            {
                theControl.SetDrawTestCheckBox(false);
            }
        }

        private void LockSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClashMarkersUtils.SelectionLocked = LockSelectionCheckBox.Checked;
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
        }

        private void ZoomToSelectionButton_Click(object sender, EventArgs e)
        {
            ClashResult Selection = (ClashResult)Application.MainDocument.GetClash().TestsData.ResolveGuid(ClashMarkersUtils.SelectedMarker);
            BoundingBox3D ClashBox = Selection.BoundingBox;
            ClashBox = ClashBox.Translate(Selection.Center - ClashBox.Center);
            Viewpoint NewViewpoint = Application.ActiveDocument.CurrentViewpoint.Value.CreateCopy();
            NewViewpoint.ZoomBox(ClashBox);
            Application.ActiveDocument.CurrentViewpoint.CopyFrom(NewViewpoint);
        }
    }
}