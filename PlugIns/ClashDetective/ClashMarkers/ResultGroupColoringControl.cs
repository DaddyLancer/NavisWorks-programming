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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NW = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;

namespace ClashDetective
{
    public partial class ResultGroupColoringControl : UserControl
    {
        /// <summary>
        /// The GUID of the group this control is associated with.
        /// </summary>
        public Guid GroupGuid;
        /// <summary>
        /// Creates and initializes a new coloring control at the given x and y relative to the parent control, representing the group with the given GUID.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="GroupGuid"></param>
        public ResultGroupColoringControl(int x, int y, Guid GroupGuid)
        {
            InitializeComponent();
            Location = new Point(x, y);
            this.GroupGuid = GroupGuid;
            FillColorDialogButton.BackColor = NWColorToSystemColor(ClashMarkersUtils.GroupsInfo[GroupGuid].FillColor);
            OutlineColorDialogButton.BackColor = NWColorToSystemColor(ClashMarkersUtils.GroupsInfo[GroupGuid].OutlineColor);
            DrawGroupCheckBox.Checked = ClashMarkersUtils.GroupsInfo[GroupGuid].DrawGroup;

            //If this is the control for ungrouped results, the GroupGuid will be the test GUID.
            NW.GroupItem theGroup = (NW.GroupItem) Autodesk.Navisworks.Api.Application.MainDocument.GetClash().TestsData.ResolveGuid(GroupGuid);
            if (!ClashMarkersUtils.GroupsInfo[GroupGuid].IsUngroupedResults)
            {
                DrawGroupCheckBox.Text = theGroup.DisplayName;
                GroupCountLabel.Text = "(" + theGroup.Children.Count + ")";
            }
            else
            {
                DrawGroupCheckBox.Text = "(Ungrouped Results)";

                int Count = theGroup.Children.Where(item => !item.IsGroup).ToList().Count;

                GroupCountLabel.Text = "(" + Count + ")";
            }
            ToolTips.SetToolTip(GroupCountLabel, "Group Count");
            ToolTips.SetToolTip(FillColorDialogButton, "Fill color");
            ToolTips.SetToolTip(OutlineColorDialogButton, "Outline color");
        }

        public void UpdateSelectedMarker(ClashResult SelectedResult, Guid GroupGuid)
        {
            if (SelectedResult == null || GroupGuid != this.GroupGuid) DrawGroupCheckBox.Font = new Font(DrawGroupCheckBox.Font, FontStyle.Regular);
            else DrawGroupCheckBox.Font = new Font(DrawGroupCheckBox.Font, FontStyle.Bold);
        }

        public void UpdateVisibilityCheckbox()
        {
            DrawGroupCheckBox.Checked = ClashMarkersUtils.GroupsInfo[GroupGuid].DrawGroup;
        }

        private void FillColorDialogButton_Click(object sender, EventArgs e)
        {
            Color theColor = GetColor(ClashMarkersUtils.GroupsInfo[GroupGuid].FillColor);
            if (theColor == Color.Empty) return;
            FillColorDialogButton.BackColor = theColor;

            ClashMarkersUtils.GroupsInfo[GroupGuid].FillColor = SystemColorToNWColor(theColor);
            NW.Application.ActiveDocument.ActiveView.RequestDelayedRedraw(NW.ViewRedrawRequests.All);
        }

        private NW.Color SystemColorToNWColor(Color theColor)
        {
            return new NW.Color(theColor.R / 255.0, theColor.G / 255.0, theColor.B / 255.0);
        }

        private Color NWColorToSystemColor(NW.Color theColor)
        {
            return Color.FromArgb((int)(theColor.R * 255.0), (int)(theColor.G * 255.0), (int)(theColor.B * 255.0));
        }

        private void OutlineColorDialogButton_Click(object sender, EventArgs e)
        {
            Color theColor = GetColor(ClashMarkersUtils.GroupsInfo[GroupGuid].OutlineColor);
            if (theColor == Color.Empty) return;
            OutlineColorDialogButton.BackColor = theColor;

            ClashMarkersUtils.GroupsInfo[GroupGuid].OutlineColor = SystemColorToNWColor(theColor);
            NW.Application.ActiveDocument.ActiveView.RequestDelayedRedraw(NW.ViewRedrawRequests.All);
        }

        /// <summary>
        /// Displays a color dialog and returns the System.Color picked, or Color.Empty if the dialog was cancelled.
        /// </summary>
        /// <param name="CurrentColor"></param>
        /// <returns></returns>
        private Color GetColor(NW.Color CurrentColor)
        {
            ColorDialog theDialog = new ColorDialog();
            theDialog.ShowHelp = true;
            theDialog.Color = NWColorToSystemColor(CurrentColor);
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                return theDialog.Color;
            }
            else return Color.Empty;
        }

        private void DrawGroupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DrawGroupCheckBox.Checked && Parent != null) ((TestColoringControl)Parent).SetDrawTestCheckBox(true); //Parent can be null when program is closing
            ClashMarkersUtils.GroupsInfo[GroupGuid].DrawGroup = DrawGroupCheckBox.Checked;
            NW.Application.ActiveDocument.ActiveView.RequestDelayedRedraw(NW.ViewRedrawRequests.All);
        }

        public void SetDrawGroupCheckBox(bool State)
        {
            DrawGroupCheckBox.Checked = State;
        }
    }
}
