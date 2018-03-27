//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2014 by Autodesk Inc.

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

//.net using declaration
using System;
using System.Collections.Generic;

//Navisworks using declaration
using NWAPI = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Model;
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Utility;

namespace Takeoff.XMLImportExport.ExportQuantity
{
   public class QuantityDatabaseParser : IDatabaseParser
   {
      #region Parse database
      public TakeoffRootNode ParseDatabase()
      {
         TakeoffRootNode node = new TakeoffRootNode();
         List<Int64> groupIds = DatabaseUtility.SelectIds(DocTakeoff.ItemGroups.DbTableName, null, DocTakeoff.ItemGroups.Parent.Name);
         foreach (Int64 rowId in groupIds)
         {
            node.CatalogNodes.Add(ParseItemgroup(rowId));
         }
         List<Int64> itemIds = DatabaseUtility.SelectIds(DocTakeoff.Items.DbTableName, null, DocTakeoff.Items.Parent.Name);
         foreach (Int64 rowId in itemIds)
         {
            node.CatalogNodes.Add(ParseItem(rowId));
         }
         List<Int64> resourceGroupIds = DatabaseUtility.SelectIds(DocTakeoff.ResourceGroups.DbTableName, null, DocTakeoff.ResourceGroups.Parent.Name);
         foreach (Int64 rowId in resourceGroupIds)
         {
            node.CatalogNodes.Add(ParseResourceGroup(rowId));
         }
         List<Int64> resourceIds = DatabaseUtility.SelectIds(DocTakeoff.Resources.DbTableName, null, DocTakeoff.Resources.Parent.Name);
         foreach (Int64 rowId in resourceIds)
         {
            node.CatalogNodes.Add(ParseResource(rowId));
         }
         return node;
      }

      public ItemGroupNode ParseItemgroup(Int64 rowId)
      {
         ItemGroupNode node = new ItemGroupNode();
         ItemGroupEntity entity = DatabaseUtility.GetItemGroup(rowId);
         node.Entity = entity;
         ItemGroupTable table = entity.GetTakeoffTable() as ItemGroupTable;
         List<Int64> childGroups = DatabaseUtility.SelectIds(table.DbTableName, rowId, table.Parent.Name);
         foreach (Int64 id in childGroups)
         {
            ItemGroupNode child = ParseItemgroup(id);
            node.Children.Add(child);
            child.Parent = node;
         }
         ItemTable itemTable = DocTakeoff.Items;
         //Get items that reference this item group
         List<Int64> childItems = DatabaseUtility.SelectIds(itemTable.DbTableName, rowId, itemTable.Parent.Name);
         foreach (Int64 id in childItems)
         {
            ItemNode child = ParseItem(id);
            node.Children.Add(child);
            child.Parent = node;
         }
         return node;
      }

      public ItemNode ParseItem(Int64 rowId)
      {
         ItemNode node = new ItemNode();
         ItemEntity entity = DatabaseUtility.GetItem(rowId);
         node.Entity = entity;

         //parse step
         StepTable stepTable = DocTakeoff.Steps;
         List<Int64> childStep = DatabaseUtility.SelectIds(stepTable.DbTableName, rowId, stepTable.ItemId.Name);
         foreach (Int64 id in childStep)
         {
            StepNode child = ParseStep(id);
            node.Children.Add(child);
            child.Item = node;
         }

         //parse objects under this item
         List<Int64> childObject = DatabaseUtility.SelectIds(DocTakeoff.Objects.DbTableName, rowId, DocTakeoff.Objects.Parent.Name);
         List<NodeBase> childObjectList = new List<NodeBase>();
         foreach (Int64 id in childObject)
         {
            ObjectNode child = ParseObject(id);
            childObjectList.Add(child);
            child.Parent = node;
         }
         if (childObjectList.Count != 0)
         {
            //reverse the order between object and step to consistent with export schema
            childObjectList.AddRange(node.Children);
            node.Children.Clear();
            ((List<NodeBase>)node.Children).AddRange(childObjectList);
         }
         return node;
      }

      public StepNode ParseStep(Int64 rowId)
      {
         StepNode node = new StepNode();
         StepEntity entity = DatabaseUtility.GetStep(rowId);
         node.Entity = entity;

         //parse step resources
         List<Int64> childStepResource = DatabaseUtility.SelectIds(DocTakeoff.StepResources.DbTableName, rowId, DocTakeoff.StepResources.StepId.Name);
         foreach (Int64 id in childStepResource)
         {
            StepResourceNode child = ParseStepResource(id);
            node.Children.Add(child);
            child.Step = node;
         }

         //parse object steps
         List<Int64> childObjectStep = DatabaseUtility.SelectIds(DocTakeoff.ObjectSteps.DbTableName, rowId, DocTakeoff.ObjectSteps.StepId.Name);
         List<NodeBase> childObjectStepList = new List<NodeBase>();
         foreach (Int64 id in childObjectStep)
         {
            ObjectStepNode child = ParseObjectStep(id);
            child.Step = node;
            childObjectStepList.Add(child);
         }
         if (childObjectStepList.Count != 0)
         {
            //reverse the order of object step, and step resource to consistent with export schema
            childObjectStepList.AddRange(node.Children);
            node.Children.Clear();
            ((List<NodeBase>)node.Children).AddRange(childObjectStepList);
         }

         return node;
      }

      public StepResourceNode ParseStepResource(Int64 rowId)
      {
         StepResourceNode node = new StepResourceNode();
         StepResourceEntity entity = DatabaseUtility.GetStepResource(rowId);
         node.Entity = entity;

         //parse object resources
         List<Int64> childObjectResource = DatabaseUtility.SelectIds(DocTakeoff.ObjectResources.DbTableName, rowId, DocTakeoff.ObjectResources.StepResourceId.Name);
         //step resource have no other type child but object resource
         foreach (Int64 id in childObjectResource)
         {
            ObjectResourceNode child = ParseObjectResource(id);
            child.StepResource = node;
            node.Children.Add(child);
         }

         return node;
      }

      public ObjectNode ParseObject(Int64 rowId)
      {
         ObjectNode objectNode = new ObjectNode();
         objectNode.Entity = DatabaseUtility.GetObject(rowId);
         return objectNode;
      }

      public ObjectStepNode ParseObjectStep(Int64 rowId)
      {
         ObjectStepNode objectStepNode = new ObjectStepNode();
         objectStepNode.Entity = DatabaseUtility.GetObjectStep(rowId);
         return objectStepNode;
      }

      public ObjectResourceNode ParseObjectResource(Int64 rowId)
      {
         ObjectResourceNode objectResourceNode = new ObjectResourceNode();
         objectResourceNode.Entity = DatabaseUtility.GetObjectResource(rowId);
         return objectResourceNode;
      }

      public ResourceGroupNode ParseResourceGroup(Int64 rowId)
      {
         ResourceGroupNode node = new ResourceGroupNode();
         ResourceGroupEntity entity = DatabaseUtility.GetResourceGroup(rowId);
         node.Entity = entity;

         List<Int64> childGroup = DatabaseUtility.SelectIds(DocTakeoff.ResourceGroups.DbTableName, rowId, DocTakeoff.ResourceGroups.Parent.Name);
         foreach (Int64 id in childGroup)
         {
            ResourceGroupNode child = ParseResourceGroup(id);
            node.Children.Add(child);
            child.Parent = node;
         }
         List<Int64> childResource = DatabaseUtility.SelectIds(DocTakeoff.Resources.DbTableName, rowId, DocTakeoff.Resources.Parent.Name);
         foreach (Int64 id in childResource)
         {
            ResourceNode child = ParseResource(id);
            node.Children.Add(child);
            child.Parent = node;
         }
         return node;
      }

      public ResourceNode ParseResource(Int64 rowId)
      {
         ResourceNode node = new ResourceNode();
         ResourceEntity entity = DatabaseUtility.GetResource(rowId);
         node.Entity = entity;
         //step resource is parsed by step

         return node;
      }
      #endregion

      public static DocumentTakeoff DocTakeoff
      {
         get { return NWAPI.Application.MainDocument.GetTakeoff(); }
      }
   }
}
