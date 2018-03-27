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
using System.Diagnostics;
using System.Windows.Forms;

//Navisworks using declaration
using NWAPI = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Model;
using Takeoff.XMLImportExport.Utility;
using Takeoff.XMLImportExport.Common;

namespace Takeoff.XMLImportExport.ImportCatalog
{
   public class CatalogDatabaseImporter : IDatabaseImporter
   {
      //Provide a chance not to begin database transaction before import
      public Boolean ContainsValidImport(TakeoffRootNode root)
      {
         if (root == null)
            return false;
         if (root.CatalogNodes.Count == 0)
            return false;
         return PreImport(root);
      }

      #region Import
      public void Import(TakeoffRootNode root)
      {
         //root will be null if no catalog element;
         if (root == null)
         {
            return;
         }
         if (!PreImport(root))
         {
            return;
         }
         foreach (NodeBase node in root.CatalogNodes)
         {
            if (node is ItemGroupNode)
            {
               Import(node as ItemGroupNode, null);
            }
            else if (node is ItemNode)
            {
               Import(node as ItemNode, null);
            }
            else if (node is ResourceGroupNode)
            {
               Import(node as ResourceGroupNode, null);
            }
            else if (node is ResourceNode)
            {
               Import(node as ResourceNode, null);
            }
            else
            {
               Debug.Assert(false);
            }
         }

         //when import step resource we need to check whether the resource already existed
         foreach (StepResourceNode node in PengdingStepResourceNode)
         {
            StepResourceEntity entity = node.Entity as StepResourceEntity;
            Debug.Assert(entity != null);
            StepNode step = node.Step;

            if (ExistingResourceNode.ContainsKey(entity.ResourceCatalogId))
            {
               ResourceNode resource = ExistingResourceNode[entity.ResourceCatalogId];
               //using database row id instead of row id in catalog file
               Import(node, step.Entity.RowId, resource.Entity.RowId);
               UpdateVariableCollection(node);

            }
            else
            {
               Int64 resourceId;
               if (DatabaseUtility.ExistResourceWithCatalogId(entity.ResourceCatalogId, out resourceId))
               {
                  Import(node, step.Entity.RowId, resourceId);
               }
               else
               {
                  String error = "Some step resource can't find its master resource.";
                  throw new CatalogFormatCorruptException(error);
               }
            }

         }
         CleanStatus();
      }

      public void Import(ItemGroupNode itemGroup, Int64? parentId)
      {
         ItemGroupEntity entity = itemGroup.Entity as ItemGroupEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (import)
         {
            ImportItemGroup(entity, parentId, exist);
            UpdateVariableCollection(itemGroup);
            foreach (Node.NodeBase node in itemGroup.Children)
            {
               if (node is ItemGroupNode)
               {
                  Import(node as ItemGroupNode, entity.RowId);
               }
               else if (node is ItemNode)
               {
                  Import(node as ItemNode, entity.RowId);
               }
               else
               {
                  Debug.Assert(false);
               }
            }
         }
      }

      public void Import(ItemNode item, Int64? parentId)
      {
         ItemEntity entity = item.Entity as ItemEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (import)
         {
            ImportItem(entity, parentId, exist);
            UpdateVariableCollection(item);
            foreach (Node.NodeBase node in item.Children)
            {
               if (node is StepNode)
               {
                  Import(node as StepNode, entity.RowId);
               }
            }
         }
      }

      public void Import(StepNode step, Int64 itemId)
      {
         StepEntity entity = step.Entity as StepEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (import)
         {
            ImportStep(entity, itemId, exist);
            UpdateVariableCollection(step);
            foreach (Node.NodeBase node in step.Children)
            {
               if (node is StepResourceNode)
               {
                  StepResourceNode stepResourceNode = node as StepResourceNode;
                  Debug.Assert(stepResourceNode != null);
                  Import(stepResourceNode, entity.RowId, (stepResourceNode.Entity as StepResourceEntity).ResourceCatalogId);
               }
            }
         }
      }

      public void Import(StepResourceNode stepResource, Int64 stepId, Guid resourceCatalogId)
      {
         StepResourceEntity entity = stepResource.Entity as StepResourceEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (import)
         {
            if (ExistingResourceNode.ContainsKey(resourceCatalogId))
            {
               ImportStepResource(entity, stepId, ExistingResourceNode[resourceCatalogId].Entity.RowId, exist);
               UpdateVariableCollection(stepResource);
            }
            else
            {
               PengdingStepResourceNode.Add(stepResource);
            }
         }
      }

      public void Import(StepResourceNode stepResource, Int64 stepId, Int64 resourceId)
      {
         StepResourceEntity stepResourceEntity = stepResource.Entity as StepResourceEntity;
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(stepResourceEntity, out exist, out import);
         if (import)
         {
            Debug.Assert(stepResourceEntity != null);
            ImportStepResource(stepResourceEntity, stepId, resourceId, exist);
            UpdateVariableCollection(stepResource);
         }
      }

      public void Import(ResourceGroupNode resourceGroup, Int64? parentId)
      {
         ResourceGroupEntity entity = resourceGroup.Entity as ResourceGroupEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;
         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (import)
         {
            ImportResourceGroup(entity, parentId, exist);
            UpdateVariableCollection(resourceGroup);
            foreach (Node.NodeBase node in resourceGroup.Children)
            {
               if (node is ResourceGroupNode)
               {
                  Import(node as ResourceGroupNode, entity.RowId);
               }
               else if (node is ResourceNode)
               {
                  Import(node as ResourceNode, entity.RowId);
               }
               else
               {
                  Debug.Assert(false);
               }
            }
         }
      }

      public void Import(ResourceNode resource, Int64? parentId)
      {
         ResourceEntity entity = resource.Entity as ResourceEntity;
         Debug.Assert(entity != null);
         bool exist = false;
         bool import = false;

         CheckCatalogAlreadyExist(entity, out exist, out import);
         if (exist || import)
         {
            ExistingResourceNode[entity.CatalogId] = resource;
         }
         if (import)
         {
            ImportResource(entity, parentId, exist);
            UpdateVariableCollection(resource);
         }
      }

      protected void ImportItemGroup(ItemGroupEntity entity, Int64? parentId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateItemGroup(entity, entity.RowId, parentId);
         }
         else
         {
            DatabaseUtility.InsertItemGroup(entity, parentId);
         }

      }
      protected void ImportItem(ItemEntity entity, Int64? parentId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateItem(entity, entity.RowId, parentId);
         }
         else
         {
            DatabaseUtility.InsertItem(entity, parentId);
         }

      }
      protected void ImportStep(StepEntity entity, Int64 itemId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateStep(entity, entity.RowId, itemId);
         }
         else
         {
            DatabaseUtility.InsertStep(entity, itemId);
         }
      }
      protected void ImportResourceGroup(ResourceGroupEntity entity, Int64? parentId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateResourceGroup(entity, entity.RowId, parentId);
         }
         else
         {
            DatabaseUtility.InsertResourceGroup(entity, parentId);
         }
      }
      protected void ImportResource(ResourceEntity entity, Int64? parentId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateResource(entity, entity.RowId, parentId);
         }
         else
         {
            DatabaseUtility.InsertResource(entity, parentId);
         }

      }
      protected void ImportStepResource(StepResourceEntity entity, Int64 stepId, Int64 resourceId, bool update)
      {
         if (update)
         {
            DatabaseUtility.UpdateStepResource(entity, entity.RowId, stepId, resourceId);
         }
         else
         {
            DatabaseUtility.InsertStepResource(entity, stepId, resourceId);
         }
      }

      protected void UpdateVariableCollection(NodeBase entityNode)
      {
         VariableCollectionNode variableCollectionNode = entityNode.VariableCollection;
         EntityBase entity = entityNode.Entity;
         Debug.Assert(entity.RowId > 0);

         DatabaseUtility.UpdateEntityVariableCollection(entity, variableCollectionNode);
      }
      #endregion

      /// <summary>
      /// Pre-check before import catalog
      /// </summary>
      /// <param name="root"></param>
      /// <returns>return false if stop import</returns>
      public bool PreImport(TakeoffRootNode root)
      {
         if (IsCatalogItemContainsIllegalVariables(root))
         {
            String error = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Variable_Not_Legal");
            throw new CatalogItemContainsIllegalVariableException(error);
         }

         bool overlap = IsCatalogItemOverlapInDatabase(root);
         if (overlap)
         {
            RetrieveCatalogItemConflictResult();
            if (IsCatalogItemConflictResultCancel())
            {
               return false;
            }
         }

         return true;
      }

      #region Check illegal variables
      /// <summary>
      /// Check if any of the catalog nodes contain illegal variables
      /// </summary>
      /// <param name="root"></param>
      /// <returns></returns>
      public bool IsCatalogItemContainsIllegalVariables(TakeoffRootNode root)
      {
         if (root == null)
         {
            return false;
         }
         foreach (NodeBase node in root.CatalogNodes)
         {
            if (IsCatalogItemContainsIllegalVariables(node))
            {
               return true;
            }
         }
         return false;
      }

      public bool IsCatalogItemContainsIllegalVariables(NodeBase node)
      {
         EntityBase entity = node.Entity;
         VariableCollectionNode collectionNode = node.VariableCollection;
         if (collectionNode != null && collectionNode.Variables != null && collectionNode.Variables.Count > 0)
         {
            TakeoffVariableDefinitionCollection variableDefCollection = entity.GetTakeoffTable().Variables;
            foreach (VariableNode n in collectionNode.Variables)
            {
               if (variableDefCollection.FindVariableDefByName(n.VariableName) == null)
               {
                  return true;
               }
            }
         }
         foreach (NodeBase n in node.Children)
         {
            if (IsCatalogItemContainsIllegalVariables(n))
            {
               return true;
            }
         }
         return false;
      }
      #endregion

      #region Check overlap with database
      /// <summary>
      /// Check if these catalog nodes are already exist in database
      /// </summary>
      /// <param name="root"></param>
      /// <returns></returns>
      public bool IsCatalogItemOverlapInDatabase(TakeoffRootNode root)
      {
         if (root == null)
         {
            return false;
         }
         foreach (NodeBase node in root.CatalogNodes)
         {
            if (IsCatalogItemOverlapInDatabase(node))
            {
               return true;
            }
         }
         return false;
      }

      public bool IsCatalogItemOverlapInDatabase(NodeBase node)
      {

         EntityBase entity = node.Entity;
         if (IsCatalogItemOverlapInDatabase(entity))
         {
            return true;
         }
         foreach (NodeBase n in node.Children)
         {
            if (IsCatalogItemOverlapInDatabase(n))
            {
               return true;
            }
         }
         return false;
      }

      protected bool IsCatalogItemOverlapInDatabase(EntityBase entity)
      {
         Guid? catalogId = GetCatalogId(entity);

         Int64 existing_id;
         if (TestEntityExistInDatabaseByCatalogId(entity, catalogId, out existing_id))
         {
            return true;
         }
         return false;
      }
      #endregion

      protected Guid? GetCatalogId(EntityBase entity)
      {
         Guid? catalogId = null;

         //do not handle object in catalog importer
         if (entity is ItemEntity)
         {
            catalogId = (entity as ItemEntity).CatalogId;
         }
         else if (entity is ItemGroupEntity)
         {
            catalogId = (entity as ItemGroupEntity).CatalogId;
         }
         else if (entity is ResourceGroupEntity)
         {
            catalogId = (entity as ResourceGroupEntity).CatalogId;
         }
         else if (entity is ResourceEntity)
         {
            catalogId = (entity as ResourceEntity).CatalogId;
         }
         else if (entity is StepEntity)
         {
            catalogId = (entity as StepEntity).CatalogId;
         }
         else if (entity is StepResourceEntity)
         {
            catalogId = (entity as StepResourceEntity).CatalogId;
         }
         else
         {
            System.Diagnostics.Debug.Assert(false, "Unknown entity type or the entity type do not support catalog id.");
         }
         return catalogId;
      }

      protected bool IsCatalogItemConflictResultCancel()
      {
         return m_conflict_result.HasValue && m_conflict_result.Value == CatalogItemConflictResult.Cancel;
      }

      protected void CheckCatalogAlreadyExist(EntityBase entity, out bool exist, out bool import)
      {
         exist = false;
         import = false;
         Int64 existing_id;
         Guid? catalogId = GetCatalogId(entity);
         if (TestEntityExistInDatabaseByCatalogId(entity, catalogId, out existing_id))
         {
            exist = true;
            entity.RowId = existing_id;
            import = RetrieveCatalogItemConflictResult();
         }
         else
         {
            import = true;
         }
      }

      protected bool RetrieveCatalogItemConflictResult()
      {
         bool import = false;
         if (!m_conflict_result.HasValue)
         {
            String message = "Some imported items have the same name as existing items. Choose 'Yes' to replace the existing items with the imported items, or choose 'No' to keep the existing items. Choose 'Cancel' to cancel the import.";
            String caption = "Import Catalog";
            DialogResult dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dialogResult)
            {
               case DialogResult.Yes:
                  m_conflict_result = CatalogItemConflictResult.Replace;
                  break;
               case DialogResult.No:
                  m_conflict_result = CatalogItemConflictResult.Keep;
                  break;
               case DialogResult.Cancel:
                  m_conflict_result = CatalogItemConflictResult.Cancel;
                  break;
                  throw new CatalogConflictCancelException("Rollback");
            }
         }

         switch (m_conflict_result.Value)
         {
            case CatalogItemConflictResult.Replace:
               import = true;
               break;
            case CatalogItemConflictResult.Keep:
               import = false;
               break;
            case CatalogItemConflictResult.Cancel:
               throw new CatalogConflictCancelException("Rollback");
         }

         return import;
      }

      /// <summary>
      /// Use catalog id to check whether entity exists in current database
      /// </summary>
      /// <param name="entity"></param>
      /// <param name="catalogId"></param>
      /// <param name="id"></param>
      /// <returns></returns>
      protected bool TestEntityExistInDatabaseByCatalogId(EntityBase entity, Guid? catalogId, out Int64 id)
      {
         id = -1;
         Trace.Assert(entity is ItemGroupEntity || entity is ItemEntity ||
            entity is StepEntity || entity is StepResourceEntity ||
            entity is ResourceGroupEntity || entity is ResourceEntity, "Entity type not support catalog id");

         if (!(catalogId.HasValue && catalogId.Value!= Guid.Empty))
         {
            return false;
         }
         TakeoffTable table = entity.GetTakeoffTable();
         return DatabaseUtility.TestIfCatalogIdExistInDatabase(table.DbTableName, NWAPI.Application.MainDocument.GetTakeoff().Items.CatalogId.Name, catalogId.Value, out id);
      }

      protected void CleanStatus()
      {
         m_conflict_result = null;
         PengdingStepResourceNode.Clear();
         ExistingResourceNode.Clear();
      }

      public enum CatalogItemConflictResult
      {
         Replace,
         Keep,
         Cancel
      }

      private CatalogItemConflictResult? m_conflict_result = null;
      //step resource which referenced current-not-existing resource will postpone to end, have one chance to handle at the end
      private List<StepResourceNode> PengdingStepResourceNode = new List<StepResourceNode>();
      //remember available resources
      private Dictionary<Guid, ResourceNode> ExistingResourceNode = new Dictionary<Guid, ResourceNode>();      

   }
}
