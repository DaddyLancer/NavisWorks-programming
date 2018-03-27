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
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;

namespace ClashDetective
{
   public partial class TestEdit : Form
   {      
      private Document Document { get; set; }
      private ClashTest Test { get; set; }
      private ClashTest CopyTest { get; set; }
      private SimpleUIControl ClashAddInCtrl { get; set; }
      
      private bool modified = false;

      /// <summary>
      /// Dialog that allows the user to select an item in the scene of the running 
      /// Navisworks application and set that as the Selection A or B for the Clash Test
      /// currently selected in the Addin 'Clash Tests' hierarchy.
      /// </summary>
      /// <param name="AddinControl">The Addin control displaying the currently selected test.</param>
      /// <param name="Test">The curently selected ClashTest for which Selection A and B can be set.</param>
      /// <param name="Document">Represents the contents of one or more loaded files into which the user makes selections.</param>
      public TestEdit(SimpleUIControl AddinControl, ClashTest Test, Document Document)
         : this()
      {
         this.Test = Test;
         this.ClashAddInCtrl = AddinControl;
         this.Document = Document;
         this.CopyTest = this.Test.CreateCopy() as ClashTest;
      }

      public TestEdit()
      {
         InitializeComponent();
      }

      private void btnSetSelection_Click(object sender, EventArgs e)
      {
         if (Document.CurrentSelection.SelectedItems.Count == 0)
         {
            MessageBox.Show("Current Selection is empty! Please make a selection!");
         }
         else if (rbSelectionA.Checked)
         {
            // Modify SelectionA with the current selection(s)
            CopyTest.SelectionA.Selection.CopyFrom(Document.CurrentSelection.SelectedItems);

            // Whether to clash this clash selection against itself 
            CopyTest.SelectionA.SelfIntersect = cbSelfIntersect.Checked;
            modified = true;
         }
         else
         {
            // Modify SelectionB with the current selection(s)
            CopyTest.SelectionB.Selection.CopyFrom(Document.CurrentSelection.SelectedItems);

            // Whether to clash this clash selection against itself 
            CopyTest.SelectionB.SelfIntersect = cbSelfIntersect.Checked;
            modified = true;
         }
      }

      private void btnDone_Click(object sender, EventArgs e)
      {
         if (modified)
         {
            // Update the existing test
            // Sets all the values of the properties in a clash test with values
            // copied from another test. This enables the properties on a test to
            // be edited without the performance overhead of replacing it (which
            // would involve replacing all contained IClashResults).
            Document.GetClash().TestsData.TestsEditTestFromCopy(Test, CopyTest);
            // Update the Tests/Results control
            ClashAddInCtrl.RefreshTree();
         }
         Close();
      }
   }
}
