//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2010 by Autodesk Inc.

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
// This sample demonstrates how to build an SDI/MDI Viewer for Navisworks files using
// the Controls part of the API.
//
//------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;

namespace Viewer
{
   public partial class SelectionSetsForm : Form
   {
      #region Intialisation \ CleanUp

      public SelectionSetsForm()
      {
         InitializeComponent();

         //Add event handlers for Application events
         Autodesk.Navisworks.Api.Application.ActiveDocumentChanging += Application_ActiveDocumentChanging;
         Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += Application_ActiveDocumentChanged;
      }

      private void SelectionSets_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            //This ensures the form isnt disposed early
            e.Cancel = true;
            Hide();
         }
         else
         {
            if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
            {
               //unsubscribe from Active Document Events
               Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.Changed -= SelectionSets_Changed;
               Autodesk.Navisworks.Api.Application.ActiveDocumentChanging -= Application_ActiveDocumentChanging;
               Autodesk.Navisworks.Api.Application.ActiveDocumentChanged -= Application_ActiveDocumentChanged;
            }

            while (selectionSetsTree.TopNode != null)
            {
               ClearNodes(selectionSetsTree.TopNode);
               selectionSetsTree.Nodes.Remove(selectionSetsTree.TopNode);
            }
         }
      }

      /// <summary>
      /// Clear the associated object with this node and all children
      /// </summary>
      /// <param name="currNode"></param>
      private void ClearNodes(TreeNode currNode)
      {
         ClearChildNodes(currNode);
         currNode.Tag = null;
      }

      /// <summary>
      /// Clear the associated object with only the children of this node
      /// </summary>
      /// <param name="currNode"></param>
      private void ClearChildNodes(TreeNode currNode)
      {
         foreach (TreeNode child in currNode.Nodes)
         {
            ClearNodes(child);
         }
      }
      #endregion

      #region Autodesk.Navisworks.Api.Application events
      void Application_ActiveDocumentChanging(object sender, EventArgs e)
      {
         //unsubscribe from the old Document's SelectionSets event
         if(Autodesk.Navisworks.Api.Application.ActiveDocument != null)
            Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.Changed -= SelectionSets_Changed;
      }

      void Application_ActiveDocumentChanged(object sender, EventArgs e)
      {
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            //subscribe to the new Document's SelectionSets event
            Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.Changed += SelectionSets_Changed;

            //Update the tree
            UpdateSelectionSets();
         }
      }
      #endregion

      #region DocumentParts.DocumentSelectionSets Events
      void SelectionSets_Changed(object sender, SavedItemChangedEventArgs e)
      {
         SavedItem newItem = e.NewItem;
         GroupItem newParent = e.NewParent;
         SavedItem oldItem = e.OldItem;
         GroupItem oldParent = e.OldParent;

         //Action property determines what has happened to the SelectionSet
         switch (e.Action)
         {
            case SavedItemChangedAction.Add:
               AddNode(newParent, newItem);
               break;
            case SavedItemChangedAction.Remove:
               RemoveNode(oldItem, oldParent);
               break;
            case SavedItemChangedAction.Replace:
               ReplaceNode(oldItem, oldParent, newItem);
               break;
            case SavedItemChangedAction.Move:
               RemoveNode(oldItem, oldParent);
               AddNode(newParent, newItem);
               break;
            case SavedItemChangedAction.Reset:
            default:
               UpdateSelectionSets();
               break;
         }
      }
      #endregion

      #region Actions on tree
      private void selectionSetsTree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
      {
         ClearChildNodes(e.Node);
         e.Node.Nodes.Clear();
         e.Node.Nodes.Add("Working...");
      }

      private void selectionSetsTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
      {
         //Clear 'Working' nodes in tree
         e.Node.Nodes.Clear();

         //Fill the child nodes with the child GroupItem information
         FillNodesFromGroupItem(e.Node.Nodes, e.Node.Tag as GroupItem);
      }


      private void selectionSetsTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
      {
         //determine if this is a selection set being selected
         SelectionSet selectionSet = e.Node.Tag as SelectionSet;
         if (selectionSet != null &&
            Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            //Clear current selection
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();
            if (selectionSet.HasExplicitModelItems)
            {
               //Selection based on a collection of ModelItems
               Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.CopyFrom(
                  selectionSet.ExplicitModelItems);
            }
            else if (selectionSet.HasSearch)
            {
               //Selection based on the results of a Search
               Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.CopyFrom(
                  selectionSet.Search.FindAll(Autodesk.Navisworks.Api.Application.ActiveDocument, false));
            }
         }
      }
      #endregion

      #region Context Menu Items
      /// <summary>
      /// Creates either a folder or a selection set in the tree
      /// </summary>
      /// <param name="folder">true for a folder, false for a selection set</param>
      private void CreateSavedItem(bool folder)
      {
         //First check we have a valid document
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null &&
            !Autodesk.Navisworks.Api.Application.ActiveDocument.IsClear &&
            Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets != null)
         {
            GroupItem group = null;

            if (selectionSetsTree.SelectedNode == null)
            {
               group = Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem;
            }
            else
            {
               group = selectionSetsTree.SelectedNode.Tag as GroupItem;
               
               //if this is not a group, is it a selection set?
               if (group == null)
               {
                  SelectionSet set = selectionSetsTree.SelectedNode.Tag as SelectionSet;
                  if (set != null)
                  {
                     //Can only create folders/selection sets under GroupItems
                     group = set.Parent;
                  }
               }
            }

            if (group == null)
               return;

            SelectionSetItemNameForm frm = new SelectionSetItemNameForm(folder);

            //Ask user for the folder name
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
               SavedItem newItem = null;
               if (folder)
               {
                  //Create the FolderItem
                  newItem = new FolderItem();
               }
               else
               {
                  //Create the SelectionSet
                  newItem = new SelectionSet(Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems);
               }

               //Set the display name
               newItem.DisplayName = frm.ItemName;

               //insert the new FolderItem/SelectionSet into the Document SelectionSets
               Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.InsertCopy(group, group.Children.Count, newItem);

               //Note: There is no need to add into tree here as this will be handled by 
               //the ActiveDocument.SelectionSets.Changed event
               //TreeNode node = AddNode(selectionSetsTree.SelectedNode, newFolder);
            }
         }
      }

      private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //create a FolderItem
         CreateSavedItem(true);
      }

      private void newSelectionSetToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Create a SelectionSet
         CreateSavedItem(false);
      }

      private void removeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null &&
            selectionSetsTree.SelectedNode != selectionSetsTree.TopNode)
         {
            SavedItem savedItem = selectionSetsTree.SelectedNode.Tag as SavedItem;
            if (selectionSetsTree.SelectedNode == null || savedItem == null)
            {
               //Can only remove viable savedItems
               return;
            }
            bool val = Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.Remove(savedItem);
         }

      }
      #endregion

      #region Add / Remove /Replace Nodes
      private void FillNodesFromGroupItem(TreeNodeCollection treeNodes, GroupItem groupItem)
      {
         if (groupItem == null)
            return;

         foreach (SavedItem savedItem in groupItem.Children)
         {
            AddNode(treeNodes, savedItem);
         }
      }

      /// <summary>
      /// Creates a node for the SavedItem in the collection
      /// </summary>
      /// <param name="treeNodes"></param>
      /// <param name="savedItem"></param>
      private TreeNode AddNode(TreeNodeCollection parentNodeCollection, SavedItem savedItem)
      {
         TreeNode node = parentNodeCollection.Add(savedItem.DisplayName);
         node.Tag = savedItem;
         if (savedItem is GroupItem)
         {
            node.Nodes.Add("Working...");
            node.ImageIndex = 0; //Folder icon
            node.SelectedImageIndex = 0;
         }
         else
         {
            node.ImageIndex = 1; //SelectionSet icon
            node.SelectedImageIndex = 1;
         }
         return node;
      }

      private TreeNode AddNode(SavedItem newParent, SavedItem newItem)
      {
         //find the node and add it to its children
         if (newParent == Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem)
            return AddNode(selectionSetsTree.Nodes, newItem);
         else
         {
            TreeNode groupNode = FindNode(newParent, true, true);
            if (groupNode != null)
            {
               return AddNode(groupNode.Nodes, newItem);
            }
         }
         return null;
      }

      private void RemoveNode(TreeNodeCollection parentNodeCollection, SavedItem savedItem)
      {
         TreeNode node = FindNode(parentNodeCollection, savedItem, false, false);
         if(node != null)
         {
            node.Remove();
         }
      }

      private void RemoveNode(SavedItem item, SavedItem itemParent)
      {
         //find the node and remove it from its children
         if (itemParent == Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem)
            RemoveNode(selectionSetsTree.Nodes, item);
         else
         {
            TreeNode groupNode = FindNode(itemParent, true, true);
            if (groupNode != null)
            {
               RemoveNode(groupNode.Nodes, item);
            }
         }
      }

      private void ReplaceNode(SavedItem oldItem, SavedItem oldParent, SavedItem newItem)
      {
         TreeNode oldParentNode = FindNode(oldParent, true, true);
         if (oldParentNode != null)
         {
            TreeNode oldNode = FindNode(oldParentNode.Nodes, oldItem, false, true);
            if (oldNode != null)
            {
               oldNode.Tag = newItem;
               oldNode.Text = newItem.DisplayName;
            }
         }
      }
      #endregion

      #region Utility Functions
      private TreeNode FindNode(SavedItem savedItem, bool searchChildren, bool onlyExpanded)
      {
         //return selectionSetsTree.Nodes.Find(savedItem.DisplayName, true).Where(
         //   x => ((GroupItem)x.Tag).Equals(savedItem) && (!onlyExpanded || x.IsExpanded));
         return FindNode(selectionSetsTree.Nodes, savedItem, searchChildren, onlyExpanded);
      }

      private TreeNode FindNode(TreeNodeCollection nodes, SavedItem savedItem, bool searchChildren, bool onlyExpanded)
      {
         TreeNode returnNode = null;
         foreach (TreeNode node in nodes)
         {

            if (node.Tag != null && ((SavedItem)(node.Tag)).Equals(savedItem) &&
                (!onlyExpanded || node.IsExpanded || node.Nodes.Count == 0))
            {
               returnNode = node;
            }
            else if(searchChildren)
            {
               returnNode = FindNode(node.Nodes, savedItem, searchChildren, onlyExpanded);
            }
            if (returnNode != null)
               break;
         }

         return returnNode;
      }

      /// <summary>
      /// Searches up the tree, starting from child node, to find the parent node. 
      /// </summary>
      /// <param name="parent"></param>
      /// <param name="child"></param>
      /// <returns>true when parent is a descendent of the child node.</returns>
      private bool IsChildNode(TreeNode parent, TreeNode child)
      {
         if (selectionSetsTree.Nodes.Count == 0)
            return true;

         if (parent == null) parent = selectionSetsTree.Nodes[0];
         if (child == null) child = selectionSetsTree.Nodes[0];
         if (child == parent) return true;

         //search reached highest node, no match
         if (child.Parent == null)
            return false;

         return IsChildNode(parent, child.Parent);
      }

      /// <summary>
      /// Refreshes the entire tree
      /// </summary>
      public void UpdateSelectionSets()
      {
         selectionSetsTree.Nodes.Clear();
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            FolderItem root = Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem;
            foreach (SavedItem item in root.Children)
            {
               AddNode(selectionSetsTree.Nodes, item);
            }            
         }
      }
      #endregion

      #region SavedItem Label Edit
      private void selectionSetsTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
      {
         SavedItem itemChanging  = e.Node.Tag as SavedItem;
         if (itemChanging == null)
            return;
         
         //Cancel edit so that events take care of the rename
         e.CancelEdit = true;

         //create the replacement item
         SavedItem newItem = itemChanging.CreateCopy();
         newItem.DisplayName = e.Label;

         GroupItem itemParent = null;

         //identify the parent item
         itemParent = itemChanging.Parent;

         //ensure we have the parent item
         if (itemParent == null)
            return;

         //Replace the item in the selection set
         Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.ReplaceWithCopy(
            itemParent,
            itemParent.Children.IndexOf(itemChanging), newItem);

      }
      #endregion

      #region Drag and Drop nodes
      private void selectionSetsTree_ItemDrag(object sender, ItemDragEventArgs e)
      {
         selectionSetsTree.DoDragDrop(e.Item, DragDropEffects.Move);
      }

      private void selectionSetsTree_DragEnter(object sender, DragEventArgs e)
      {
         e.Effect = DragDropEffects.Move;
      }

      private void selectionSetsTree_DragDrop(object sender, DragEventArgs e)
      {
         //Get the node being moved and the new parent node
         TreeNode oldNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
         if (oldNode == null ||
            !(sender is TreeView))
            return;
         Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
         TreeNode newParentNode = ((TreeView)sender).GetNodeAt(pt);

         //Get the necessary saved items
         SavedItem item = oldNode.Tag as SavedItem;
         GroupItem oldParent = null;
         GroupItem newParent = null;

         //get the GroupItem information for the parent of the node being moved
         if(oldNode.Parent==null)
            oldParent = Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem;
         else
            oldParent = oldNode.Parent.Tag as GroupItem;

         //get the GroupItem information for the new parent node
         if(newParentNode==null)
            newParent = Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.RootItem;
         else
            newParent = newParentNode.Tag as GroupItem;

         //check it's a valid move
         if (item == null ||
            oldParent == null || newParent == null || newParent == oldParent || IsChildNode(oldNode, newParentNode))
            return;

         //get the index of the item in the GroupItem's children
         int sourceIndex = oldParent.Children.IndexOf(item);

         //finally move the item
         Autodesk.Navisworks.Api.Application.ActiveDocument.SelectionSets.Move(oldParent, sourceIndex, newParent, newParent.Children.Count);
      }
      #endregion
   }
}