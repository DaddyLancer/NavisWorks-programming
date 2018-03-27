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
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api;

namespace ClashDetective
{
    public partial class AddGroup : Form
    {
        // The selected clash-test, including all its settings and results. 
        public ClashTest SelTest { get; set; }
      
        public AddGroup()
        {
            InitializeComponent();
            // Set a default value for the group name
            this.txtBoxGroupName.Text = "New Group";
        }

        private void AddGroup_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (SavedItem issue in SelTest.Children)
                {
                    ClashResult rt = issue as ClashResult;

                    // Find all results that are not in a group already
                    if (null != rt)
                    {
                        listBox1.Items.Add(rt.DisplayName);
                    }
                }
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string newGroupName = txtBoxGroupName.Text;

                // Gets a reference to the Primary Document being worked on. Once set the
                // MainDocument does not change for the lifetime of the application
                Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            
                // This holds the document-parts associated with Clash Detective. 
                // Currently there is only one. 
                DocumentClash documentClash = document.GetClash();

                // Document part for currently defined clash tests.
                DocumentClashTests DCT = documentClash.TestsData;

                ClashResultGroup group;
                int groupNdx = SelTest.Children.IndexOfDisplayName(newGroupName);
                // Check that name esists
                if (-1 == groupNdx)
                {
                    // New group
                    ClashResultGroup newGroup = new ClashResultGroup();
                    newGroup.DisplayName = newGroupName;
                    // Adds a copy of the new group item as the first item in the test
                    DCT.TestsInsertCopy(SelTest, 0, newGroup);
                    // get reference to the group item
                    group = (ClashResultGroup)SelTest.Children[0];
                }
                else
                {
                    // Add to existing group
                    group = (ClashResultGroup)SelTest.Children[groupNdx];
                }

                // Move all selected issues into the group
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    int index = SelTest.Children.IndexOfDisplayName(listBox1.SelectedItems[i].ToString());
                    ClashResult rt = SelTest.Children[index] as ClashResult;
                    if (rt != null)
                    {
                        if (!chkStatus.Checked ||
                                rt.Status == ClashResultStatus.New)
                        {
                            DCT.TestsMove(SelTest, index, group, 0);
                        }
                    }
                }
            }
            catch { }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
