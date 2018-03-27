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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api;

namespace ClashDetective
{
   public partial class SimpleUIControl : UserControl
   {
      // Dates that have not been set are returned as 01/01/1970 00:00:00 by the API
      private static readonly DateTime unixEpoch = new DateTime(1970, 01, 01, 00, 00, 00);

      public SimpleUIControl()
      {
         InitializeComponent();

         toolTip.SetToolTip(btnAddGroup, "Add a new group to the selected test.");
         toolTip.SetToolTip(btnAddTest, "Add a new test.");
         toolTip.SetToolTip(btnDump, "Refresh the tests tree.");
         toolTip.SetToolTip(btnEditResult, "Set the selected result to 'Approved'.");
         toolTip.SetToolTip(btnEditTest, "[Re]set the (A & B) Selections for the selected test.");
         toolTip.SetToolTip(btnReport, "Create a text report.");
         toolTip.SetToolTip(btnRun, "[Re]run the seleted test.");
         toolTip.SetToolTip(btnRunAll, "[Re]run all the tests.");
      }

      private void btnDump_Click(object sender, EventArgs e)
      {
         RefreshTree();
      }

      #region RefreshTree
      /// <summary>
      /// This method refreshes the Test/Results tree control based on the current contents
      /// of Clash Detective in the running Navisworks application.
      /// </summary>
      public void RefreshTree()
      {
         try
         {
            treeViewTests.Nodes.Clear();

            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;

            // Provides access to the various document-parts associated with clash detective,
            // if the model has clash data. 
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            // The Clash document contains TestsData 
            // - TestsData is the root container for all clash data associated with the current model. 
            // - TestsData contains a set of Tests
            // - Each Test contains a set of child issues of type IClashResult. These may be 
            //   of type ClashResult or ClashResultGroup, and accessed via its Children property.
            // - A ClashResultGroup represents a grouped set of ClashResults and these can be accessed
            //   via its Children property 
            foreach (ClashTest test in documentClash.TestsData.Tests)
            {
               TreeNode eachTopNode = treeViewTests.Nodes.Add(test.DisplayName);
               eachTopNode.Tag = documentClash.TestsData.CreateReference(test);

               foreach (IClashResult issue in test.Children)
               {
                  ClashResultGroup group = issue as ClashResultGroup;
                  if (null != group)
                  {
                     TreeNode eachNode = eachTopNode.Nodes.Add(group.DisplayName);
                     // Creating a reference is a way of generating a unique id for a Clash
                     // Detective object. It can be cached to enable comparison/access to
                     // the underlying API object at a later time.
                     eachNode.Tag = documentClash.TestsData.CreateReference(group);
                     RecurseTree(group, eachNode);
                  }
                  else
                  {
                     ClashResult result = issue as ClashResult;
                     if (null != result)
                     {
                        TreeNode eachNode1 = eachTopNode.Nodes.Add(result.DisplayName);
                        eachNode1.Tag = documentClash.TestsData.CreateReference(result);
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      private void RecurseTree(ClashResultGroup group, TreeNode parentNode)
      {
         try
         {
            // Provides access to the various document-parts associated with clash detective. 
            DocumentClash documentClash = Autodesk.Navisworks.Api.Application.MainDocument.GetClash();

            foreach (IClashResult issue in group.Children)
            {
               ClashResultGroup eachGroup = issue as ClashResultGroup;
               if (null != eachGroup)
               {
                  TreeNode eachGroupNode = parentNode.Nodes.Add(eachGroup.DisplayName);
                  // Creating a reference is a way of generating a unique id for a Clash
                  // Detective object. It can be cached to enable comparison/access to
                  // the underlying API object at a later time.
                  eachGroupNode.Tag = documentClash.TestsData.CreateReference(eachGroup);
                  RecurseTree(eachGroup, eachGroupNode);
               }
               else
               {
                  ClashResult result = issue as ClashResult;
                  if (null != result)
                  {
                     parentNode.Nodes.Add(result.DisplayName).Tag = documentClash.TestsData.CreateReference(result);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }
      #endregion

      #region CreateReport
      private void btnReport_Click(object sender, EventArgs e)
      {
         try
         {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
               Stream stream = saveFileDialog.OpenFile();
               DumpToFile(stream);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Writes the current Clash data to an output file.
      /// </summary>
      private void DumpToFile(Stream stream)
      {
         try
         {
            if (null == stream)
               return;

            // only have anything to write if a model is open and it has clash data
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null)
               return;

            using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.ASCII))
            {
               foreach (ClashTest test in documentClash.TestsData.Tests)
               {
                  writer.WriteLine("*********Test:" + test.DisplayName + "*********");

                  foreach (IClashResult issue in test.Children)
                  {
                     ClashResultGroup group = issue as ClashResultGroup;
                     if (null != group)
                     {
                        writer.WriteLine(String.Format("Group={0} Status={1}", group.DisplayName, group.Status.ToString()));
                        RecurseToFile(group, writer);
                     }
                     else
                     {
                        ClashResult result = issue as ClashResult;
                        if (null != result)
                        {
                           writer.WriteLine(String.Format("Result={0} Status={1}", result.DisplayName, result.Status.ToString()));
                        }
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Helper method for DumpToFile, to recursively write Clash data to file.
      /// </summary>
      private void RecurseToFile(ClashResultGroup group, StreamWriter writer)
      {
         if (writer == null)
            throw new ArgumentNullException("writer is null");

         try
         {
            foreach (IClashResult issue in group.Children)
            {
               ClashResultGroup eachGroup = issue as ClashResultGroup;
               if (null != eachGroup)
               {
                  writer.WriteLine(String.Format("Group={0} Status={1}", eachGroup.DisplayName, eachGroup.Status.ToString()));

                  RecurseToFile(eachGroup, writer);
               }
               else
               {
                  ClashResult result = issue as ClashResult;
                  if (null != result)
                  {
                     writer.WriteLine(String.Format("    >>Result={0} Status={1}", result.DisplayName, result.Status.ToString()));
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }
      #endregion

      /// <summary>
      /// Populates the 'Info' pane with information about the selected Clash object in 
      /// the 'Clash Tests' hierarchy.
      /// </summary>
      private void treeViewTests_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         try
         {
            propertiesView.Nodes.Clear();

            // check there is still a model loaded since the last refresh
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;
            // Provides access to the various document-parts associated with clash detective,
            // if the model has clash data. 
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            // Access the underlying API Clash object by using the cached SavedItemReference
            // on our selected tree node.
            TreeNode node = e.Node;

            // If it is a ClashTest object we can access all its settings and results
            ClashTest test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
            if (test != null)
            {
               propertiesView.Nodes.Add("DisplayName: " + test.DisplayName);
               propertiesView.Nodes.Add("Status:" + test.Status.ToString());
               // Check for Comments
               if (test.Comments.Any())
               {
                  propertiesView.Nodes.Add("Comments: ");
                  foreach (var c in test.Comments)
                  {
                     propertiesView.Nodes.Add("  >>Author: " + c.Author);
                     propertiesView.Nodes.Add("    Text: " + c.Body);
                     propertiesView.Nodes.Add("    Status: " + c.Status.ToString());
                  }
               }
               else
               {
                  propertiesView.Nodes.Add("Comments: <None>");
               }
               propertiesView.Nodes.Add("Last Time: " + test.LastRun.ToString());
               propertiesView.Nodes.Add("SimulationType: " + test.SimulationType.ToString());
               propertiesView.Nodes.Add("Test Type:" + test.TestType.ToString());
               TreeNode tmpNode = propertiesView.Nodes.Add("SelectionA");
               tmpNode.Tag = documentClash.TestsData.CreateReference(test);
               TreeNode tmpNode1 = propertiesView.Nodes.Add("SelectionB");
               tmpNode1.Tag = documentClash.TestsData.CreateReference(test);

               return;
            }

            // The selected node may correspond to a ClashResultGroup i.e. a grouping of 
            // related clash results inside a Clash test. 
            // Again we can access its properties and child results. Some properties are 
            // dependent on the combined properties of the child results.
            ClashResultGroup group = document.ResolveReference(node.Tag as SavedItemReference) as ClashResultGroup;
            if (group != null)
            {
               propertiesView.Nodes.Add("DisplayName: " + group.DisplayName);
               propertiesView.Nodes.Add("Results number: " + group.Children.Count);
               propertiesView.Nodes.Add(" ");
               propertiesView.Nodes.Add("Status: " + group.Status.ToString());

               propertiesView.Nodes.Add("ApprovedBy: " + (group.ApprovedByVaries ? "*VARIES*" : group.ApprovedBy));
               propertiesView.Nodes.Add("AssignedTo: " + (group.AssignedToVaries ? "*VARIES*" : group.AssignedTo));
               return;
            }
            // The selected node may correspond to a ClashResult i.e. represents a single 
            // geometry clash detected in a Clash test. We can access its properties.
            ClashResult result = document.ResolveReference(node.Tag as SavedItemReference) as ClashResult;
            if (result != null)
            {
               propertiesView.Nodes.Add("DisplayName: " + result.DisplayName);
               propertiesView.Nodes.Add("Status: " + result.Status.ToString());
               if (result.Comments.Any())
               {
                  propertiesView.Nodes.Add("Comments: ");
                  foreach (var c in result.Comments)
                  {
                     propertiesView.Nodes.Add("  >>Author: " + c.Author);
                     propertiesView.Nodes.Add("    Text: " + c.Body);
                     propertiesView.Nodes.Add("    Status: " + c.Status.ToString());
                  }
               }
               else
               {
                  propertiesView.Nodes.Add("Comments: <None>");
               }
               propertiesView.Nodes.Add("ApprovedBy: " + result.ApprovedBy);
               propertiesView.Nodes.Add("AssignedTo: " + result.AssignedTo);
               propertiesView.Nodes.Add(string.Format("Center Pt : ({0:0.00}, {1:0.00}, {2:0.00})",
                                                                     result.Center.X,
                                                                     result.Center.Y,
                                                                     result.Center.Z));
               string time = result.ApprovedTime == unixEpoch ? "" : result.ApprovedTime.ToString();
               propertiesView.Nodes.Add("ApprovedTime: " + time);
               propertiesView.Nodes.Add(string.Format("Distance: {0:0.00} ", result.Distance) + document.Units.ToString());

               TreeNode tmpNode = propertiesView.Nodes.Add("Item1");
               tmpNode.Tag = documentClash.TestsData.CreateReference(result);
               TreeNode tmpNode1 = propertiesView.Nodes.Add("Item2");
               tmpNode1.Tag = documentClash.TestsData.CreateReference(result);
               return;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Runs all the Clash tests listed in the Clash Detective window in the running 
      /// Navisworks application.
      /// </summary>
      private void btnRunAll_Click(object sender, EventArgs e)
      {
         if (treeViewTests.Nodes.Count == 0)
         {
            MessageBox.Show("There are no Clash Tests!");
         }
         else
            RunTest(true);
      }

      /// <summary>
      /// Runs the Clash test corresponding to the currently selected node in the Addin
      /// Clash Tests hierarchy.
      /// </summary>
      private void btnRunTest_Click(object sender, EventArgs e)
      {
         Document document = Autodesk.Navisworks.Api.Application.MainDocument;
         if (document == null || document.IsClear)
            return;

         TreeNode node = treeViewTests.SelectedNode;
         ClashTest test = null;
         if (node != null)
         {
            // we identify the Clash Test API object by resolving the cached reference stored
            // on the selected tree node.
            test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
         }

         if (test == null)
         {
            MessageBox.Show("Please select a test from the tree view of Clash Tests! You may need to refresh the view.");
         }
         else
            RunTest(false, test);
      }

      /// <summary>
      /// If runAll is true then all existing tests in the running Navisworks application
      /// will be run. Otherwise, only the test specified by 'oTest' will be run.
      /// </summary>
      private void RunTest(bool runAll, ClashTest oTest = null)
      {
         try
         {
            DocumentClash documentClash = Autodesk.Navisworks.Api.Application.MainDocument.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            if (runAll && documentClash.TestsData.Tests.Count > 0)
            {
               documentClash.TestsData.TestsRunAllTests();
            }
            else
            {
               documentClash.TestsData.TestsRunTest(oTest);
            }
            RefreshTree();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Highlights the corresponding item in the main application scene when either:
      /// (a) Selection A or B property of a Clash Test is clicked in the Addin 
      /// properties pane, or 
      /// (b) Item 1 or Item 2 property of a Clash Result is clicked in the Addin 
      /// properties pane.
      /// All other surrounding objects are made translucent.
      /// </summary>
      private void propertiesView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         try
         {
            TreeNode node = e.Node;
            ClashTest test = null;
            ClashResult result = null;
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            // can't do anything if the model has been closed since the last refresh
            if (document == null || document.IsClear)
               return;

            // undo any previous selection or transparency settings
            document.CurrentSelection.Clear();
            document.Models.ResetAllPermanentMaterials();

            switch (node.Text)
            {
               // SelectionA or SelectionB property clicked - current object is a Clash Test
               case "SelectionA":
                  test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
                  if (test != null)
                  {
                     document.CurrentSelection.CopyFrom(test.SelectionA.Selection.GetSelectedItems());
                  }
                  break;

               case "SelectionB":
                  test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
                  if (test != null)
                  {
                     document.CurrentSelection.CopyFrom(test.SelectionB.Selection.GetSelectedItems());
                  }
                  break;

               // Item1 or Item2 property clicked - current object is a Clash Result
               case "Item1":
                  result = document.ResolveReference(node.Tag as SavedItemReference) as ClashResult;
                  if (result != null)
                  {
                     document.CurrentSelection.CopyFrom(result.Selection1);
                  }
                  break;

               case "Item2":
                  result = document.ResolveReference(node.Tag as SavedItemReference) as ClashResult;
                  if (result != null)
                  {
                     document.CurrentSelection.CopyFrom(result.Selection2);
                  }
                  break;
            }
            // Focuses the view on the currently selected objects.
            Autodesk.Navisworks.Api.Application.ActiveDocument.ActiveView.FocusOnCurrentSelection();

            //--------------------------------------------------------------
            // Now make all the surrounding objects partially transparent
            //--------------------------------------------------------------

            // ModelItemCollection is a collection of ModelItems. Often used to represent 
            // an explicit selection.
            // ModelItem represents an instance within the model hierarchy, corresponding 
            // to an item in the Navisworks selection tree.

            // Create a collection each for items that should be visible and items that 
            // should be transparent
            ModelItemCollection hidden = new ModelItemCollection();
            ModelItemCollection visible = new ModelItemCollection();
            // populate the visible items, based on current selection
            foreach (ModelItem item in document.CurrentSelection.SelectedItems)
            {
               if (item.AncestorsAndSelf != null)
                  visible.AddRange(item.AncestorsAndSelf);
               if (item.Descendants != null)
                  visible.AddRange(item.Descendants);
            }

            // Populate the transparent items i.e. all items then subtract the visible items
            foreach (ModelItem toShow in visible)
            {
               if (toShow.Parent != null)
               {
                  hidden.AddRange(toShow.Parent.Children);
               }
            }
            foreach (ModelItem toShow in visible)
            {
               hidden.Remove(toShow);
            }

            // Set the transparency for items that are not part of the current selection
            document.Models.OverridePermanentTransparency(hidden, 0.9);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Opens a dialog that allows the Addin user to group results in the currently 
      /// selected test.
      /// </summary>
      private void btnAddGroup_Click(object sender, EventArgs e)
      {
         try
         {
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;

            DocumentClash documentClash = document.GetClash();

            TreeNode node = treeViewTests.SelectedNode;
            ClashTest test = null;
            if (node != null)
            {
               // get the clash test (api object) using the cached reference on the node. 
               test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
            }
            if (test == null)
            {
               MessageBox.Show("Please select a test from the tree view of Clash Tests! You may need to refresh your tests list first.");
            }
            else
            {
               // Show dialog to create new group and add selected results
               AddGroup form = new AddGroup();
               form.SelTest = test;
               // make sure the dialog has a parent window, if possible
               Form appWnd = null;
               if (System.Windows.Forms.Application.OpenForms.Count > 0)
               {
                  appWnd = System.Windows.Forms.Application.OpenForms[0];
               }
               form.ShowDialog(appWnd);
               RefreshTree();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Opens a dialog that allows the Addin user to change the selectd items for the
      /// currently selected Clash Test.
      /// </summary>
      private void btnEditTest_Click(object sender, EventArgs e)
      {
         try
         {
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            // The DocumentClashTests  is accessible through TestsData.
            DocumentClashTests DCT = documentClash.TestsData;

            TreeNode node = treeViewTests.SelectedNode;
            ClashTest test = null;
            if (node != null)
            {
               test = document.ResolveReference(node.Tag as SavedItemReference) as ClashTest;
            }
            if (test == null)
            {
               MessageBox.Show("Please select a test from the tree view of Clash Tests! You may need to refresh the list.");
            }
            else
            {
               // Show form to add selections and update test
               TestEdit frm = new TestEdit(this, test, document);
               // NOTE: this form can't be modal as the user needs to pick items in the scene
               // so we make sure it stays on top
               frm.TopMost = true;
               frm.Show();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Edits the curently selected Clash Result - in this case the only edit being made is
      /// to change the result status to Approved.
      /// </summary>
      private void btnEditResult_Click(object sender, EventArgs e)
      {
         try
         {
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            TreeNode node = treeViewTests.SelectedNode;
            if (node == null)
               return;
            ClashResult rt = document.ResolveReference(node.Tag as SavedItemReference) as ClashResult;
            // Check that we have a result selected.
            if (rt == null)
            {
               MessageBox.Show("Please select a result from the tree view of Clash Tests!");
            }
            else
            {
               MessageBox.Show("The result status will change to Approved");
               // Sets the Status on an IClashResult stored in the document part.
               // If the result is a ClashResultGroup, then the status will be set individually 
               // on all its children. 
               documentClash.TestsData.TestsEditResultStatus(rt, ClashResultStatus.Approved);
               RefreshTree();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }

      /// <summary>
      /// Creates a new test with some default settings. As a starting point the first
      /// object in the model hierarchy is set as SelectionA and the second item in the 
      /// model hierarchy is set as SelectionB.
      /// </summary>
      private void btnAddTest_Click(object sender, EventArgs e)
      {
         try
         {
            Document document = Autodesk.Navisworks.Api.Application.MainDocument;
            if (document == null || document.IsClear)
               return;
            DocumentClash documentClash = document.GetClash();
            if (documentClash == null || documentClash.TestsData == null)
               return;

            DocumentClashTests DCT = documentClash.TestsData;

            NewTestName frm = new NewTestName("NewTest");
            frm.ShowDialog();
            if (frm.TestName == null)
               return;

            ClashTest newTest = new ClashTest();

            newTest.DisplayName = frm.TestName;
            ModelItemCollection selA = new ModelItemCollection();
            ModelItemCollection selB = new ModelItemCollection();
            int index = 0;
            foreach (ModelItem item in document.Models[0].RootItem.Children)
            {
               if (index == 0)
                  selA.Add(item); //add first item to SelectionA
               if (index == 1)
               {
                  selB.Add(item); //add second item to SelectionB
                  break;
               }
               index++;
            }
            newTest.SelectionA.Selection.CopyFrom(selA);
            newTest.SelectionB.Selection.CopyFrom(selB);
            //set other properties of the test
            //…
            DCT.TestsAddCopy(newTest);
            RefreshTree();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.GetType().Name);
         }
      }
   }
}
