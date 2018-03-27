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
    public partial class TestColoringControl : UserControl
    {
        public Guid TestGuid;
        private List<ResultGroupColoringControl> ColoringControls = new List<ResultGroupColoringControl>();

        public TestColoringControl(int x, int y, Guid TestGuid)
        {
            InitializeComponent();
            Location = new Point(x, y);
            this.TestGuid = TestGuid;

            DrawTestCheckBox.Checked = ClashMarkersUtils.TestsInfo[TestGuid].DrawTest;
            NW.GroupItem theTest = (NW.GroupItem)Autodesk.Navisworks.Api.Application.MainDocument.GetClash().TestsData.ResolveGuid(TestGuid);
            DrawTestCheckBox.Text = theTest.DisplayName;
            GroupCountLabel.Text = "(" + theTest.Children.Count + ")";
            ToolTips.SetToolTip(GroupCountLabel, "Number of groups and ungrouped clashes");
            ToolTips.SetToolTip(ShowAllButton, "Show all groups");
            ToolTips.SetToolTip(ShowNoneButton, "Hide all groups");

            y = Height;
            x = 16;
            ResultGroupColoringControl theControl;
            foreach (NW.SavedItem theGroup in theTest.Children)
            {
                if (!theGroup.IsGroup) continue;
                theControl = new ResultGroupColoringControl(x, y, theGroup.Guid);
                ColoringControls.Add(theControl);
                Controls.Add(theControl);
                Height += theControl.Height;
                y += theControl.Height;
            }
            //Ungrouped results control
            theControl = new ResultGroupColoringControl(x, y, TestGuid);
            ColoringControls.Add(theControl);
            Controls.Add(theControl);
            Height += theControl.Height;
        }

        public void UpdateSelectedMarker(ClashResult SelectedResult, Guid GroupGuid, Guid TestGuid)
        {
            if (SelectedResult == null || TestGuid != this.TestGuid) DrawTestCheckBox.Font = new Font(DrawTestCheckBox.Font, FontStyle.Regular);
            else DrawTestCheckBox.Font = new Font(DrawTestCheckBox.Font, FontStyle.Bold);

            foreach (ResultGroupColoringControl theControl in ColoringControls)
            {
                theControl.UpdateSelectedMarker(SelectedResult, GroupGuid);
            }
        }

        public void UpdateVisibilityCheckboxes()
        {
            DrawTestCheckBox.Checked = ClashMarkersUtils.TestsInfo[TestGuid].DrawTest;
            foreach (ResultGroupColoringControl theControl in ColoringControls)
            {
                theControl.UpdateVisibilityCheckbox();
            }
        }

        public void SetDrawTestCheckBox(bool State)
        {
            if (DrawTestCheckBox.Checked == State) return;
            DrawTestCheckBox.Checked = State;
        }

        private void DrawTestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClashMarkersUtils.TestsInfo[TestGuid].DrawTest = DrawTestCheckBox.Checked;
            NW.Application.ActiveDocument.ActiveView.RequestDelayedRedraw(NW.ViewRedrawRequests.All);
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            foreach (ResultGroupColoringControl theControl in ColoringControls)
            {
                theControl.SetDrawGroupCheckBox(true);
            }
        }

        private void ShowNoneButton_Click(object sender, EventArgs e)
        {
            foreach (ResultGroupColoringControl theControl in ColoringControls)
            {
                theControl.SetDrawGroupCheckBox(false);
            }
        }
    }
}
