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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WF = System.Windows.Forms;

using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api;

namespace ClashDetective
{
    public partial class ClashGrouperDialog : WF.Form
    {
        public ClashGrouperDialog()
        {
            InitializeComponent();

            ToolTips.SetToolTip(GroupByModelRadioButton, "If \"Create Catch-all group\" is checked, all results will be placed in one group");
            ToolTips.SetToolTip(GroupByModelRadioButton, "Group according to the highest level composite item above the clashing item in the selection tree");
            ToolTips.SetToolTip(CatchAllGroupCheckBox, "If results cannot be grouped according to the chosen mode, put them in a catch-all group instead of leaving them ungrouped");

            BalloonToolTips.AutoPopDelay = 0;
            BalloonToolTips.InitialDelay = 0;
            BalloonToolTips.SetToolTip(GroupByClusterAnalysisRadioButton, "Attempts find and group clusters of nearby results via k-means clustering.");
            BalloonToolTips.SetToolTip(NumClustersLabel, "Ideal number of result groups. The process may find fewer groups, but not more.");
            BalloonToolTips.SetToolTip(NumClustersNumericUpDown, BalloonToolTips.GetToolTip(NumClustersLabel));
            BalloonToolTips.SetToolTip(NumAttemptsLabel, "The algorithm will be run this many times and the best variation chosen.");
            BalloonToolTips.SetToolTip(NumAttemptsNumericUpDown, BalloonToolTips.GetToolTip(NumAttemptsLabel));
        }

        private Model PreviouslySelectedModel = null;
        private List<Guid> PreviouslySelectedTests = new List<Guid>();

        /// <summary>
        /// Populates the list box and combo box with the tests and models respectively
        /// </summary>
        public void Setup()
        {
            DocumentClashTests DCT = Application.MainDocument.GetClash().TestsData;

            //In order to populate the combo box with the currently extant tests we need to create an array of objects with two members, one (the
            //DisplayName of the test) to be used as the combo box text and one (a test object) to be used as the actual return value when the item
            //is selected by the user. We'll use a list in order to handle any number of tests.
            List<Tuple<ClashTest,string>> ListDataSource = new List<Tuple<ClashTest,string>>();
            foreach (ClashTest theTest in DCT.Tests)
            {
                Tuple<ClashTest,string> theTuple = new Tuple<ClashTest,string>(theTest, theTest.DisplayName);
                ListDataSource.Add(theTuple);
            }

            TestSelectionListBox.DataSource = ListDataSource;
            TestSelectionListBox.ValueMember = "Item1";
            TestSelectionListBox.DisplayMember = "Item2";

            //If possible, select all of the previously selected tests
            TestSelectionListBox.SelectedItems.Clear();
            foreach (Tuple<ClashTest,string> thePair in ListDataSource)
            {
                if (PreviouslySelectedTests.Contains(thePair.Item1.Guid)) TestSelectionListBox.SelectedItems.Add(thePair);
            }
            if (TestSelectionListBox.SelectedItems.Count == 0) TestSelectionListBox.SelectedIndices.Add(0);

            //Now populate the combo box with the models in the same manner
            List<Tuple<Model, string>> ComboDataSource = new List<Tuple<Model, string>>();
            foreach (Model theModel in Application.MainDocument.Models)
            {
                Tuple<Model, string> thePairing = new Tuple<Model, string>(theModel, System.IO.Path.GetFileName(theModel.FileName));
                ComboDataSource.Add(thePairing);
            }

            ModelSelectionComboBox.DataSource = ComboDataSource;
            ModelSelectionComboBox.ValueMember = "Item1";
            ModelSelectionComboBox.DisplayMember = "Item2";

            //Regenerating the list prevents the combo box from remembering which test was selected, so we do that manually.
            if (PreviouslySelectedModel != null) ModelSelectionComboBox.SelectedItem = ComboDataSource.FirstOrDefault(Pair => Pair.Item1 == PreviouslySelectedModel);

            GroupByIntersectionRadioButton.Enabled = (Application.MainDocument.Grids.ActiveSystem != null);
            GroupByLevelRadioButton.Enabled = (Application.MainDocument.Grids.ActiveSystem != null);
            if (Application.MainDocument.Grids.Systems.Any())
            {
                if (Application.MainDocument.Grids.ActiveSystem == null)
                {
                    RequiresGridsLabel.Text = "To enable these modes, select View tab -> Show Grids";
                    RequiresGridsLabel.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
                else
                {
                    RequiresGridsLabel.Text = "Using the currently displayed grid system \"" + Application.MainDocument.Grids.ActiveSystem.DisplayName + "\"";
                    RequiresGridsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 255);
                }
            }
            else
            {
                RequiresGridsLabel.Text = "These modes require a grid system to be defined";
                RequiresGridsLabel.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            GroupingModes Mode = GroupingModes.Level;
            if (GroupByModelRadioButton.Checked)
            {
                Mode = GroupingModes.ChosenModelPart;
                PreviouslySelectedModel = (Model)ModelSelectionComboBox.SelectedValue;
            }
            else if (GroupByApprovedByRadioButton.Checked) Mode = GroupingModes.ApprovedBy;
            else if (GroupByAssignedToRadioButton.Checked) Mode = GroupingModes.AssignedTo;
            else if (GroupByLevelRadioButton.Checked) Mode = GroupingModes.Level;
            else if (GroupByIntersectionRadioButton.Checked) Mode = GroupingModes.GridIntersection;
            else if (GroupByClusterAnalysisRadioButton.Checked) Mode = GroupingModes.ClusterAnalysis;
            else if (UngroupAllRadioButton.Checked) Mode = GroupingModes.None;

            PreviouslySelectedTests = new List<Guid>();
            ClashGrouperUtils.RelevantGroupingInfo GroupingInfo = new ClashGrouperUtils.RelevantGroupingInfo();
            GroupingInfo.CreateCatchAll = CatchAllGroupCheckBox.Checked && (Mode != GroupingModes.ClusterAnalysis);
            GroupingInfo.GroupingModel = (Model) ModelSelectionComboBox.SelectedValue;
            GroupingInfo.NumClusters = (int) NumClustersNumericUpDown.Value;
            GroupingInfo.NumAttempts = (int) NumAttemptsNumericUpDown.Value;

            foreach (int Index in TestSelectionListBox.SelectedIndices)
            {
                ClashTest theTest = ((Tuple<ClashTest,string>) TestSelectionListBox.Items[Index]).Item1;
                PreviouslySelectedTests.Add(theTest.Guid);
                ClashGrouperUtils.GroupTestClashes(theTest, Mode, GroupingInfo);
            }
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumClustersNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GroupByClusterAnalysisRadioButton.Checked = true;
        }

        private void NumAttemptsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GroupByClusterAnalysisRadioButton.Checked = true;
        }

        private void ModelSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupByModelRadioButton.Checked = true;
        }

        private void NumClustersLabel_Click(object sender, EventArgs e)
        {
            GroupByClusterAnalysisRadioButton.Checked = true;
        }

        private void NumAttemptsLabel_Click(object sender, EventArgs e)
        {
            GroupByClusterAnalysisRadioButton.Checked = true;
        }

        private void NumClustersNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            if (NumClustersNumericUpDown.Text == "") NumClustersNumericUpDown.Value = NumClustersNumericUpDown.Minimum;
        }

        private void NumAttemptsNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            if (NumAttemptsNumericUpDown.Text == "") NumAttemptsNumericUpDown.Value = NumClustersNumericUpDown.Minimum;
        }
    }
}
