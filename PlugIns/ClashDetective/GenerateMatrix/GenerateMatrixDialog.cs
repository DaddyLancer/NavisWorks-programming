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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WF = System.Windows.Forms;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api;

namespace ClashDetective
{
    public partial class GenerateMatrixDialog : WF.Form
    {
        private Guid PreviouslySelectedTest = Guid.Empty;

        /// <summary>
        /// Populates the combo box with all the tests from the document.
        /// </summary>
        public void Setup()
        {
            DocumentClashTests DCT = Application.MainDocument.GetClash().TestsData;

            //In order to populate the combo box with the currently extant tests we need to create an array of objects with two members, one (the
            //DisplayName of the test) to be used as the combo box text and one (a test object) to be used as the actual return value when the item
            //is selected by the user. We'll use a list in order to handle any number of tests.

            List<TestAndNamePairing> DataSource = new List<TestAndNamePairing>();
            foreach (ClashTest theTest in DCT.Tests)
            {
                TestAndNamePairing thePairing = new TestAndNamePairing();
                thePairing.Test = theTest;
                thePairing.DisplayName = theTest.DisplayName;
                DataSource.Add(thePairing);
            }

            TemplateTestComboBox.DataSource = DataSource;
            TemplateTestComboBox.DisplayMember = "DisplayName";
            TemplateTestComboBox.ValueMember = "Test";

            //Regenerating the list prevents the combo box from remembering which test was selected, so we do that manually.
            TemplateTestComboBox.SelectedItem = DataSource.FirstOrDefault(Pair => (Pair.Test.Guid == PreviouslySelectedTest));

            //Update the "run all" button to show the number of tests
            int TestCount = 0, OldTestCount = 0;
            foreach (ClashTest theTest in DCT.Tests)
            {
                if (theTest.DisplayName.Contains(GenerateMatrixUtil.TestIdentifierString))
                {
                    TestCount++;
                    if (theTest.Status != ClashTestStatus.Complete) OldTestCount++;
                }
            }

            UpdateAllTestsButton.Text = "Update ClashMatrix tests (" + OldTestCount + "/" + TestCount + ")";
            //Reset the selected control
            this.ActiveControl = UpdateAllTestsButton;

            UpdateControlEnabledStatus();
        }

        public GenerateMatrixDialog()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            DocumentClash documentClash = Application.MainDocument.GetClash();

            if (ClearExistingCheckBox.Checked) GenerateMatrixUtil.ClearGeneratedTests();

            if (GenerateNewTestsCheckBox.Checked)
            {
                if (UseTemplateCheckBox.Checked)
                {
                    PreviouslySelectedTest = ((ClashTest) TemplateTestComboBox.SelectedValue).Guid;
                    GenerateMatrixUtil.GenerateTests((ClashTest)TemplateTestComboBox.SelectedValue);
                }
                else GenerateMatrixUtil.GenerateTests();
                if (RunAfterCheckBox.Checked)
                {
                    GenerateMatrixUtil.RunLatestTests();
                }
            }
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class TestAndNamePairing
        {
            public ClashTest Test { get; set; }
            public string DisplayName { get; set; }
        }

        private void GenerateMatrixDialog_Shown(object sender, EventArgs e)
        {
            UpdateControlEnabledStatus();
        }

        private void UseTemplateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlEnabledStatus();
        }

        private void GenerateNewTestsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlEnabledStatus();
        }

        /// <summary>
        /// Enables/Disables the controls on the form based on which checkboxes have been ticked.
        /// </summary>
        private void UpdateControlEnabledStatus()
        {
            bool Enabled = GenerateNewTestsCheckBox.Enabled && GenerateNewTestsCheckBox.Checked;
            UseTemplateCheckBox.Enabled = Enabled && (TemplateTestComboBox.Items.Count > 0);
            if (!UseTemplateCheckBox.Enabled) UseTemplateCheckBox.Checked = false;
            RunAfterCheckBox.Enabled = Enabled;

            TemplateTestComboBox.Enabled = UseTemplateCheckBox.Enabled && UseTemplateCheckBox.Checked;
        }

        private void UpdateAllTestsButton_Click(object sender, EventArgs e)
        {
            //Run all tests, skipping those marked complete unless control-clicked. Close the form if any tests were run.
            if (GenerateMatrixUtil.RunAllTests(!((ModifierKeys & WF.Keys.Control) == WF.Keys.Control))) Close();
        }
    }
}
