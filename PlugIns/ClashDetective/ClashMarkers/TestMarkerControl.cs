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
        public ResultGroupColoringControl(int x, int y, Guid GroupGuid)
        {
            InitializeComponent();
            Location = new Point(x, y);
            this.GroupGuid = GroupGuid;
            FillColorDialogButton.BackColor = NWColorToSystemColor(ClashMarkersUtils.GroupColors[GroupGuid].FillColor);
            OutlineColorDialogButton.BackColor = NWColorToSystemColor(ClashMarkersUtils.GroupColors[GroupGuid].OutlineColor);
            DrawTestCheckBox.Checked = ClashMarkersUtils.GroupColors[GroupGuid].DrawGroup;

            //If this is the control for ungrouped results, the GroupGuid will be the empty GUID.
            NW.GroupItem theGroup = (NW.GroupItem) Autodesk.Navisworks.Api.Application.MainDocument.GetClash().TestsData.ResolveGuid(GroupGuid);
            if (GroupGuid != Guid.Empty)
            {
                DrawTestCheckBox.Text = theGroup.DisplayName;
                GroupCountLabel.Text = "(" + theGroup.Children.Count + ")";
            }
            else
            {
                DrawTestCheckBox.Text = "(Ungrouped Results)";

                int Count = 0;
                foreach (ClashTest theTest in Autodesk.Navisworks.Api.Application.MainDocument.GetClash().TestsData.Tests)
                {
                    foreach (NW.SavedItem theResult in theTest.Children)
                    {
                        if (!theResult.IsGroup) Count++;
                    }
                }

                GroupCountLabel.Text = "(" + Count + ")";
            }
            ToolTips.SetToolTip(GroupCountLabel, "Group Count");
            ToolTips.SetToolTip(FillColorDialogButton, "Fill color");
            ToolTips.SetToolTip(OutlineColorDialogButton, "Outline color");
        }

        private void FillColorDialogButton_Click(object sender, EventArgs e)
        {
            Color theColor = GetColor(ClashMarkersUtils.GroupColors[GroupGuid].FillColor);
            if (theColor == Color.Empty) return;
            FillColorDialogButton.BackColor = theColor;

            ClashMarkersUtils.GroupColors[GroupGuid].FillColor = SystemColorToNWColor(theColor);
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
            Color theColor = GetColor(ClashMarkersUtils.GroupColors[GroupGuid].OutlineColor);
            if (theColor == Color.Empty) return;
            OutlineColorDialogButton.BackColor = theColor;

            ClashMarkersUtils.GroupColors[GroupGuid].OutlineColor = SystemColorToNWColor(theColor);
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
            ClashMarkersUtils.GroupColors[GroupGuid].DrawGroup = DrawTestCheckBox.Checked;
            NW.Application.ActiveDocument.ActiveView.RequestDelayedRedraw(NW.ViewRedrawRequests.All);
        }

        public void SetDrawGroupCheckBox(bool State)
        {
            DrawTestCheckBox.Checked = State;
        }
    }
}
