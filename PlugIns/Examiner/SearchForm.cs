//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2009 by Autodesk Inc.

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
//
// This sample demonstrates basic LINQ style searching capabilities
// in the .NET API
//
//------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Examiner
{
   public partial class SearchForm : Form
   {
      public enum ChangeDecision
      {
         No,
         Yes,
         NoChange
      }
      public bool ItemsNamed { get; set; }
      public string SearchItemName { get; set; }
      public bool PropertyCategory { get; set; }
      public string SearchPropertyCategory { get; set; }
      public bool HasGeometry { get; set; }
      public bool IsHidden { get; set; }
      public bool IsRequired { get; set; }
      public bool RepresentsInsert { get; set; }
      public bool RepresentsLayer { get; set; }
      public bool SelectItems { get; set; }
      public string ResultsFileOut { get; set; }
      public bool OverrideColor { get; set; }
      public Autodesk.Navisworks.Api.Color OverrideColorValue { get; set; }
      public bool OverrideTransparency { get; set; }
      public double OverrideTransparencyValue { get; set; }
      public ChangeDecision Required { get; set; }
      public ChangeDecision Hidden { get; set; }
      public string ResultingNWD { get; set; }

      public SearchForm()
      {
         InitializeComponent();
      }

      private void searchForItems_Click(object sender, EventArgs e)
      {
         //Search for ClassDisplayName matching the text, regardless of upper/lower case
         ItemsNamed = hasItemsNamed.Checked;
         SearchItemName = searchItemName.Text;

         //Search where the Property categories for the modelitem have a specific display name
         PropertyCategory = propertyCategory.Checked;
         SearchPropertyCategory = searchPropertyCategory.Text;

         //find the model items with the Geometry
         HasGeometry = hasGeometry.Checked;

         //hidden model items
         IsHidden = isHidden.Checked;

         //required by the model
         IsRequired = isRequired.Checked;

         RepresentsInsert = representsInsert.Checked;

         RepresentsLayer = representsLayer.Checked;

         ResultsFileOut = saveToFile.Text;

         //Select the items in the model that are contained in the collection
         SelectItems = selectResults.Checked;

         //What to change?

         //Override color
         OverrideColor = overrideColor.Checked;
         if (OverrideColor)
         {
            OverrideColorValue = new Autodesk.Navisworks.Api.Color(
               Convert.ToDouble(overrideColorValue.ForeColor.R) / 255.0,
               Convert.ToDouble(overrideColorValue.ForeColor.G) / 255.0,
               Convert.ToDouble(overrideColorValue.ForeColor.B) / 255.0);
         }

         //Override Trnasparency
         OverrideTransparency = overrideTransparency.Checked;
         if(OverrideTransparency)
         {
            OverrideTransparencyValue = Convert.ToDouble(overrideTransparencyValue.Value);
         }

         //Override Required flag
         if (required.Checked)
            Required = ChangeDecision.Yes;
         else if (notRequired.Checked)
            Required = ChangeDecision.No;
         else
            Required = ChangeDecision.NoChange;

         //Override Hidden flag
         if (hidden.Checked)
            Hidden = ChangeDecision.Yes;
         else if (dontHide.Checked)
            Hidden = ChangeDecision.No;
         else
            Hidden = ChangeDecision.NoChange;

         //output NWD
         ResultingNWD = resultingNWD.Text;
      }

      private void hasItemsNamed_CheckedChanged(object sender, EventArgs e)
      {
         searchItemName.Enabled = hasItemsNamed.Checked;
      }

      private void propertyCategory_CheckedChanged(object sender, EventArgs e)
      {
         searchPropertyCategory.Enabled = propertyCategory.Checked;
      }

      private void browseForFile_Click(object sender, EventArgs e)
      {
         SaveFileDialog openFile = new SaveFileDialog();
         if (openFile.ShowDialog() == DialogResult.OK)
         {
            saveToFile.Text = openFile.FileName;
         }
      }

      private void overrideColorValue_Click(object sender, EventArgs e)
      {
         if (colorDialog.ShowDialog() == DialogResult.OK)
         {
            overrideColorValue.ForeColor = colorDialog.Color;
            overrideColorValue.BackColor = colorDialog.Color;
         }
      }

      private void browseForOutputFile_Click(object sender, EventArgs e)
      {
         SaveFileDialog openFile = new SaveFileDialog();
         if (openFile.ShowDialog() == DialogResult.OK)
         {
            resultingNWD.Text = openFile.FileName;
         }
      }
   }
}
