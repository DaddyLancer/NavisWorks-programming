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

//.net system using declaration
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Navisworks using declaration
using NWAPI = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Data;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Model;
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Common;

namespace Takeoff.XMLImportExport.Utility
{
   /// <summary>
   /// This class contains all the utilities to operate on database
   /// </summary>
   public class DatabaseUtility
   {
      #region Insert/update entities into database
      public static Int64 InsertItemGroup(ItemGroupEntity entity, Int64? parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ItemGroupTable table = entity.GetTakeoffTable() as ItemGroupTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Parent.Name, new NavisworksParameter("@" + table.Parent.Name, !parentId.HasValue ? null : parentId.Value.ToString())));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.WBS.Name, new NavisworksParameter("@" + table.WBS.Name, entity.WBS)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertItem(ItemEntity entity, Int64? parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ItemTable table = entity.GetTakeoffTable() as ItemTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Parent.Name, new NavisworksParameter("@" + table.Parent.Name, !parentId.HasValue ? null : parentId.Value.ToString())));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.WBS.Name, new NavisworksParameter("@" + table.WBS.Name, entity.WBS)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Transparency.Name, new NavisworksParameter("@" + table.Transparency.Name, entity.Transparency)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Color.Name, new NavisworksParameter("@" + table.Color.Name, entity.Color)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertStep(StepEntity entity, Int64 parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         StepTable table = entity.GetTakeoffTable() as StepTable;
         Debug.Assert(table != null);
         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.ItemId.Name, new NavisworksParameter("@" + table.ItemId.Name, parentId)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertStepResource(StepResourceEntity entity, Int64 stepId, Int64 resourceId)
      {
         StepResourceTable table = entity.GetTakeoffTable() as StepResourceTable;
         Debug.Assert(table != null);

         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.ResourceId.Name, new NavisworksParameter("@" + table.ResourceId.Name, resourceId)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.StepId.Name, new NavisworksParameter("@" + table.StepId.Name, stepId)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertResourceGroup(ResourceGroupEntity entity, Int64? parentId)
      {
         //ResourceGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ResourceGroupTable table = entity.GetTakeoffTable() as ResourceGroupTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Parent.Name, new NavisworksParameter("@" + table.Parent.Name, !parentId.HasValue ? null : parentId.Value.ToString())));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.RBS.Name, new NavisworksParameter("@" + table.RBS.Name, entity.RBS)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertResource(ResourceEntity entity, Int64? parentId)
      {
         //ResourceGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ResourceTable table = entity.GetTakeoffTable() as ResourceTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Parent.Name, new NavisworksParameter("@" + table.Parent.Name, !parentId.HasValue ? null : parentId.Value.ToString())));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.RBS.Name, new NavisworksParameter("@" + table.RBS.Name, entity.RBS)));
         Int64 rowId = InsertEntityWithCatalogId(table.DbTableName, columnValuePair, table.CatalogId.Name, entity.CatalogId);
         entity.RowId = rowId;
         return rowId;
      }

      public static Int64 InsertEntityWithCatalogId(String dbTableName, List<KeyValuePair<String, NavisworksParameter>> columnParametersPair, String catalogIdName, Guid catalogId)
      {
         Debug.Assert(!String.IsNullOrEmpty(dbTableName));
         Debug.Assert(columnParametersPair != null);
         Debug.Assert(columnParametersPair.Count > 0);

         StringBuilder sql = new StringBuilder();
         sql.Append("INSERT INTO ");
         sql.Append(dbTableName);
         StringBuilder columns = new StringBuilder();
         StringBuilder values = new StringBuilder();

         columns.Append("( ");
         columns.Append(catalogIdName);
         columns.Append(", ");
         values.Append(" VALUES( ");
         values.Append("@catalogId, ");
         bool firstEnter = true;
         foreach (var variable in columnParametersPair)
         {
            if (firstEnter)
            {
               firstEnter = false;
            }
            else
            {
               columns.Append(", ");
               values.Append(", ");
            }
            columns.Append(variable.Key);
            values.Append(variable.Value.ParameterName);
         }
         columns.Append(" ) ");
         values.Append(" )");
         sql.Append(columns);
         sql.Append(values);


         Debug.Assert(NWAPI.Application.MainDocument != null);

         //Database entry: DocumentTakeoff.Database
         DocumentTakeoff doc = NWAPI.Application.MainDocument.GetTakeoff();
         Debug.Assert(doc != null);
         //Any database modification must be inside transaction
         //Either using an existing transaction or create a new transaction
         //In case of batch group insert, here should use an existing transaction here.
         Debug.Assert(doc.Database.ExistLiveTransaction);
         using (NavisworksCommand cmd = new NavisworksCommand(sql.ToString(), doc.Database.Value))
         {
            NavisworksParameter p = cmd.CreateParameter();
            p.ParameterName = "@catalogId";
            if (catalogId == Guid.Empty)
            {
               catalogId = Guid.NewGuid();
            }
            p.Value = catalogId;
            p.DbType = System.Data.DbType.Guid;
            cmd.Parameters.Add(p);

            foreach (KeyValuePair<String, NavisworksParameter> value in columnParametersPair)
            {
               cmd.Parameters.Add(value.Value);
            }

            cmd.ExecuteNonQuery();
         }
         return GetLastInsertRowId();
      }

      /// <summary>
      /// Call sqlite function last_insert_rowid() to return the ROWID of the last row insert from the database connection
      /// </summary>
      public static Int64 GetLastInsertRowId()
      {
         using (NavisworksConnection connection = NWAPI.Application.MainDocument.Database.Value)
         {
            NavisworksCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select last_insert_rowid()";
            using (NavisWorksDataReader dataReader = cmd.ExecuteReader())
            {
               Int64 last_id = -1;
               if (dataReader.Read())
               {
                  Int64.TryParse(dataReader[0].ToString(), out last_id);
               }
               return last_id;
            }
         }
      }

      public static void UpdateItemGroup(ItemGroupEntity entity, Int64 rowId, Int64? parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ItemGroupTable table = entity.GetTakeoffTable() as ItemGroupTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));

         //update should only update display, should not try to update the entity relation

         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.WBS.Name, new NavisworksParameter("@" + table.WBS.Name, entity.WBS)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.Parent.Name, parentId);
         entity.RowId = rowId;
      }

      public static void UpdateItem(ItemEntity entity, Int64 rowId, Int64? parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ItemTable table = entity.GetTakeoffTable() as ItemTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.WBS.Name, new NavisworksParameter("@" + table.WBS.Name, entity.WBS)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Transparency.Name, new NavisworksParameter("@" + table.Transparency.Name, entity.Transparency)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Color.Name, new NavisworksParameter("@" + table.Color.Name, entity.Color)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.Parent.Name, parentId);
         entity.RowId = rowId;
      }

      public static void UpdateStep(StepEntity entity, Int64 rowId, Int64 parentId)
      {
         //ItemGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         StepTable table = entity.GetTakeoffTable() as StepTable;
         Debug.Assert(table != null);
         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();

         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.ItemId.Name, parentId);
         entity.RowId = rowId;
      }

      public static void UpdateStepResource(StepResourceEntity entity, Int64 rowId, Int64 stepId, Int64 resourceId)
      {
         StepResourceTable table = entity.GetTakeoffTable() as StepResourceTable;
         Debug.Assert(table != null);
         if (!TestEntityParent(table.DbTableName, rowId, table.ResourceId.Name, resourceId))
         {
            String error = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_StepResource_Cannot_Change_ResourceId");
            throw new CatalogFormatCorruptException(error);
         }
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.StepId.Name, stepId);
         entity.RowId = rowId;
      }

      public static void UpdateResourceGroup(ResourceGroupEntity entity, Int64 rowId, Int64? parentId)
      {
         //ResourceGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ResourceGroupTable table = entity.GetTakeoffTable() as ResourceGroupTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.RBS.Name, new NavisworksParameter("@" + table.RBS.Name, entity.RBS)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.Parent.Name, parentId);
         entity.RowId = rowId;
      }

      public static void UpdateResource(ResourceEntity entity, Int64 rowId, Int64? parentId)
      {
         //ResourceGroup(name should not be null)
         Debug.Assert(entity.Name != null);
         ResourceTable table = entity.GetTakeoffTable() as ResourceTable;
         Debug.Assert(table != null);

         ////Directly operate on database
         ////Database schema entry: TakeoffTable
         List<KeyValuePair<String, NavisworksParameter>> columnValuePair = new List<KeyValuePair<String, NavisworksParameter>>();
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Name.Name, new NavisworksParameter("@" + table.Name.Name, entity.Name)));

         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.Description.Name, new NavisworksParameter("@" + table.Description.Name, entity.Description)));
         columnValuePair.Add(new KeyValuePair<string, NavisworksParameter>(table.RBS.Name, new NavisworksParameter("@" + table.RBS.Name, entity.RBS)));
         UpdateEntity(table.DbTableName, columnValuePair, table.RowId.Name, rowId, table.Parent.Name, parentId);
         entity.RowId = rowId;

      }

      public static void UpdateEntityVariableCollection(EntityBase entity, VariableCollectionNode variableCollectionNode)
      {
         Debug.Assert(entity.RowId > 0);

         TakeoffVariableCollection variableCollection = entity.GetTakeoffTable().SelectVariables(entity.RowId);
         foreach (TakeoffVariable variable in variableCollection)
         {
            VariableNode variableNode = FindVariableNode(variableCollectionNode, variable.Definition.Name);
            if (variable.IsAbleToSetFormula)
            {
               if (variableNode == null)
               {
                  variable.Formula = null;
               }
               else
               {
                  if (variableNode.Properties.ContainsKey(Formula))
                  {
                     variable.Formula = variableNode.Properties[Formula];
                  }
                  else
                  {
                     variable.Formula = null;
                  }
               }
            }
            try
            {
               if (variable.IsAbleToSetUnits)
               {
                  if (variableNode == null)
                  {
                     variable.SetUnitsToNull();
                  }
                  else
                  {
                     if (variableNode.Properties.ContainsKey(Units))
                     {
                        Int32 number;
                        bool isNumber = Int32.TryParse(variableNode.Properties[Units], out number);
                        if (isNumber)
                        {
                           variable.Units = (TakeoffUnits)number;
                        }
                        else
                        {
                           TakeoffUnits unit;
                           bool isUnit = Enum.TryParse(variableNode.Properties[Units], true, out unit);
                           if (isUnit)
                           {
                              variable.Units = unit;
                           }
                           else
                           {
                              Debug.Assert(false);
                           }
                        }
                     }
                     else
                     {
                        variable.SetUnitsToNull();
                     }
                  }
               }
            }
            catch (System.ArgumentException)//set unit may cause exception by TakeoffVariable.IsOkToSetUnitForUnitsGroup
            {
               String error = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Unit_Is_Not_fit_Unit_Group");
               throw new CatalogFormatCorruptException(error);
            }
         }
         entity.GetTakeoffTable().UpdateVariables(entity.RowId, variableCollection);
      }

      public static void UpdateEntity(String dbTableName, List<KeyValuePair<String, NavisworksParameter>> columnParametersPair, String idColumn, Int64 rowId, String parentColumn, Int64? parentId)
      {
         Debug.Assert(!String.IsNullOrEmpty(dbTableName));
         Debug.Assert(columnParametersPair != null);
         Debug.Assert(columnParametersPair.Count > 0);

         StringBuilder sql = new StringBuilder();
         sql.Append("UPDATE ");
         sql.Append(dbTableName);
         sql.Append(" SET ");

         if (!TestEntityParent(dbTableName, rowId, parentColumn, parentId))
         {
            sql.Append(parentColumn);
            sql.Append(" = ");
            sql.Append("@parentId");
            sql.Append(", ");
         }

         bool firstEnter = true;
         foreach (var variable in columnParametersPair)
         {
            if (firstEnter)
            {
               firstEnter = false;
            }
            else
            {
               sql.Append(", ");
            }
            sql.Append(variable.Key);
            sql.Append(" = ");
            sql.Append(variable.Value.ParameterName);
         }

         sql.Append(" WHERE ");
         sql.Append(idColumn);
         sql.Append(" = ");
         sql.Append("@rowId");


         Debug.Assert(NWAPI.Application.MainDocument != null);

         //Database entry: DocumentTakeoff.Database
         DocumentTakeoff doc = NWAPI.Application.MainDocument.GetTakeoff();
         Debug.Assert(doc != null);
         //Any database modification must be inside transaction
         //Either using an existing transaction or create a new transaction
         //In case of batch group insert, here should use an existing transaction here.
         Debug.Assert(doc.Database.ExistLiveTransaction);
         using (NavisworksCommand cmd = new NavisworksCommand(sql.ToString(), doc.Database.Value))
         {
            NavisworksParameter p = cmd.CreateParameter();
            p.ParameterName = "@parentId";
            if (parentId.HasValue)
            {
               p.Value = parentId.Value;
            }
            else
            {
               p.Value = null;
            }
            cmd.Parameters.Add(p);

            p = cmd.CreateParameter();
            p.ParameterName = "@rowId";
            p.Value = rowId;
            p.DbType = DbType.Int64;
            cmd.Parameters.Add(p);

            foreach (var variable in columnParametersPair)
            {
               cmd.Parameters.Add(variable.Value);
            }
            cmd.ExecuteNonQuery();
         }
      }

      /// <summary>
      /// Test whether the entity has parent
      /// </summary>
      /// <param name="dbTableName"></param>
      /// <param name="rowId"></param>
      /// <param name="dbColumnName"></param>
      /// <param name="expected"></param>
      /// <returns></returns>
      public static bool TestEntityParent(String dbTableName, Int64 rowId, String dbColumnName, Int64? expected)
      {
         Dictionary<String, Object> parent = new Dictionary<String, Object>();
         parent.Add(dbColumnName, null);
         bool succeed = SelectEntity(dbTableName, rowId, parent);
         Debug.Assert(succeed);
         Int64? result = null;
         if (parent[dbColumnName] != null)
         {
            result = (Int64)parent[dbColumnName];
         }
         return expected.Equals(result);
      }
      #endregion

      #region Get entity information from database
      public static ItemGroupEntity GetItemGroup(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ItemGroupEntity itemGroup = new ItemGroupEntity();
         ItemGroupTable table = itemGroup.GetTakeoffTable() as ItemGroupTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.Parent.Name, null);
         columns.Add(table.Name.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.WBS.Name, null);
         columns.Add(table.CatalogId.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            itemGroup.RowId = (Int64)columns[table.RowId.Name];
            if (columns[table.Parent.Name] == null)
            {
               itemGroup.Parent = null;
            }
            else
            {
               itemGroup.Parent = (Int64)columns[table.Parent.Name];
            }
            itemGroup.Name = (String)columns[table.Name.Name];
            itemGroup.Description = (String)columns[table.Description.Name]; //null-able
            itemGroup.WBS = (String)columns[table.WBS.Name];
            itemGroup.CatalogId = (Guid)columns[table.CatalogId.Name];
            itemGroup.Variables = table.SelectVariables(rowId);
            return itemGroup;
         }
         else
         {
            return null;
         }

      }

      public static ItemEntity GetItem(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ItemEntity item = new ItemEntity();
         ItemTable table = item.GetTakeoffTable() as ItemTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.Parent.Name, null);
         columns.Add(table.Name.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.WBS.Name, null);
         columns.Add(table.Transparency.Name, null);
         columns.Add(table.Color.Name, null);
         columns.Add(table.CatalogId.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            item.RowId = (Int64)columns[table.RowId.Name];
            if (columns[table.Parent.Name] == null)
            {
               item.Parent = null;
            }
            else
            {
               item.Parent = (Int64)columns[table.Parent.Name];
            }
            item.Name = (String)columns[table.Name.Name];
            item.Description = (String)columns[table.Description.Name];
            item.WBS = (String)columns[table.WBS.Name];
            item.Transparency = (Double)columns[table.Transparency.Name];
            item.Color = (Int64)columns[table.Color.Name];
            item.CatalogId = (Guid)columns[table.CatalogId.Name];
            item.Variables = table.SelectVariables(rowId);
            return item;
         }
         else
         {
            return null;
         }
      }

      public static ObjectEntity GetObject(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ObjectEntity objectEntity = new ObjectEntity();
         ObjectTable table = objectEntity.GetTakeoffTable() as ObjectTable;
         Debug.Assert(table != null);

         columns.Add(table.RowId.Name, null);
         columns.Add(table.Parent.Name, null);
         columns.Add(table.WBS.Name, null);
         columns.Add(table.ModelItemId.Name, null);
         columns.Add(table.SavedViewpointId.Name, null);
         columns.Add(table.SheetId.Name, null);
         columns.Add(table.Status.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);
         if (succeedQuery)
         {
            objectEntity.RowId = (Int64)columns[table.RowId.Name];
            objectEntity.Parent = (Int64)columns[table.Parent.Name];
            objectEntity.WBS = (String)columns[table.WBS.Name];
            if (columns[table.ModelItemId.Name] != null)
            {
               objectEntity.ModelItemId = (Guid)columns[table.ModelItemId.Name];
            }
            if (columns[table.SavedViewpointId.Name] != null)
            {
               objectEntity.SavedViewpointId = (Guid)columns[table.SavedViewpointId.Name];
            }
            if (columns[table.SheetId.Name] != null)
            {
               objectEntity.SheetId = (Int64)columns[table.SheetId.Name];
            }
            if (columns[table.Status.Name] != null)
            {
               objectEntity.Status = (Int64)columns[table.Status.Name];
            }
            objectEntity.Variables = table.SelectVariables(rowId);
            return objectEntity;
         }
         else
         {
            return null;
         }
      }

      public static StepEntity GetStep(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         StepEntity step = new StepEntity();
         StepTable table = step.GetTakeoffTable() as StepTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.ItemId.Name, null);
         columns.Add(table.Name.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.CatalogId.Name, null);

         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            step.RowId = (Int64)columns[table.RowId.Name];
            Debug.Assert(columns[table.ItemId.Name] != null);
            step.ItemId = (Int64)columns[table.ItemId.Name];
            step.Name = (String)columns[table.Name.Name];
            step.Description = (String)columns[table.Description.Name];
            step.CatalogId = (Guid)columns[table.CatalogId.Name];
            step.Variables = table.SelectVariables(rowId);
            return step;
         }
         else
         {
            return null;
         }

      }

      public static ObjectStepEntity GetObjectStep(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ObjectStepEntity objectStepEntity = new ObjectStepEntity();
         ObjectStepTable table = objectStepEntity.GetTakeoffTable() as ObjectStepTable;
         Debug.Assert(table != null);

         columns.Add(table.RowId.Name, null);
         columns.Add(table.ObjectId.Name, null);
         columns.Add(table.StepId.Name, null);

         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);
         if (succeedQuery)
         {
            objectStepEntity.RowId = (Int64)columns[table.RowId.Name];
            objectStepEntity.ObjectId = (Int64)columns[table.ObjectId.Name];
            objectStepEntity.StepId = (Int64)columns[table.StepId.Name];
            objectStepEntity.Variables = table.SelectVariables(rowId);
            return objectStepEntity;
         }
         else
         {
            return null;
         }
      }

      public static ResourceGroupEntity GetResourceGroup(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ResourceGroupEntity resourceGroup = new ResourceGroupEntity();
         ResourceGroupTable table = resourceGroup.GetTakeoffTable() as ResourceGroupTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.Parent.Name, null);
         columns.Add(table.RBS.Name, null);
         columns.Add(table.Name.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.CatalogId.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            resourceGroup.RowId = (Int64)columns[table.RowId.Name];
            if (columns[table.Parent.Name] == null)
            {
               resourceGroup.Parent = null;
            }
            else
            {
               resourceGroup.Parent = (Int64)columns[table.Parent.Name];
            }
            resourceGroup.Name = (String)columns[table.Name.Name];
            resourceGroup.Description = (String)columns[table.Description.Name];
            resourceGroup.RBS = (String)columns[table.RBS.Name];
            resourceGroup.CatalogId = (Guid)columns[table.CatalogId.Name];
            resourceGroup.Variables = table.SelectVariables(rowId);
            return resourceGroup;
         }
         else
         {
            return null;
         }
      }

      public static ResourceEntity GetResource(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ResourceEntity resource = new ResourceEntity();
         ResourceTable table = resource.GetTakeoffTable() as ResourceTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.Parent.Name, null);
         columns.Add(table.RBS.Name, null);
         columns.Add(table.Name.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.CatalogId.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            resource.RowId = (Int64)columns[table.RowId.Name];
            if (columns[table.Parent.Name] == null)
            {
               resource.Parent = null;
            }
            else
            {
               resource.Parent = (Int64)columns[table.Parent.Name];
            }
            resource.Name = (String)columns[table.Name.Name];
            resource.Description = (String)columns[table.Description.Name];
            resource.RBS = (String)columns[table.RBS.Name];
            resource.CatalogId = (Guid)columns[table.CatalogId.Name];
            resource.Variables = table.SelectVariables(rowId);
            return resource;
         }
         else
         {
            return null;
         }
      }

      public static StepResourceEntity GetStepResource(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         StepResourceEntity stepResource = new StepResourceEntity();
         StepResourceTable table = stepResource.GetTakeoffTable() as StepResourceTable;
         Debug.Assert(table != null);
         columns.Add(table.RowId.Name, null);
         columns.Add(table.StepId.Name, null);
         columns.Add(table.ResourceId.Name, null);
         columns.Add(table.Description.Name, null);
         columns.Add(table.CatalogId.Name, null);
         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);

         if (succeedQuery)
         {
            stepResource.RowId = (Int64)columns[table.RowId.Name];
            stepResource.StepId = (Int64)columns[table.StepId.Name];
            stepResource.ResourceId = (Int64)columns[table.ResourceId.Name];
            stepResource.Description = (String)columns[table.Description.Name];
            stepResource.CatalogId = (Guid)columns[table.CatalogId.Name];
            stepResource.Variables = table.SelectVariables(rowId);
            columns = new Dictionary<string, object>();
            ResourceEntity resource = new ResourceEntity();
            ResourceTable resourceTable = resource.GetTakeoffTable() as ResourceTable;
            columns.Add(resourceTable.CatalogId.Name, null);
            succeedQuery = SelectEntity(resourceTable.DbTableName, stepResource.ResourceId, columns);
            Debug.Assert(succeedQuery);
            stepResource.ResourceCatalogId = (Guid)columns[resourceTable.CatalogId.Name];
            return stepResource;
         }
         else
         {
            return null;
         }
      }

      public static ObjectResourceEntity GetObjectResource(Int64 rowId)
      {
         Dictionary<String, Object> columns = new Dictionary<String, Object>();
         ObjectResourceEntity objectResourceEntity = new ObjectResourceEntity();
         ObjectResourceTable table = objectResourceEntity.GetTakeoffTable() as ObjectResourceTable;
         Debug.Assert(table != null);

         columns.Add(table.RowId.Name, null);
         columns.Add(table.ObjectStepId.Name, null);
         columns.Add(table.StepResourceId.Name, null);

         bool succeedQuery = SelectEntity(table.DbTableName, rowId, columns);
         if (succeedQuery)
         {
            objectResourceEntity.RowId = (Int64)columns[table.RowId.Name];
            objectResourceEntity.ObjectStepId = (Int64)columns[table.ObjectStepId.Name];
            objectResourceEntity.StepResourceId = (Int64)columns[table.StepResourceId.Name];
            objectResourceEntity.Variables = table.SelectVariables(rowId);
            return objectResourceEntity;
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Fill the dictionary with data from database
      /// </summary>
      /// <param name="dbTableName"></param>
      /// <param name="columns"></param>
      /// <returns>false if no corresponding row in database</returns>
      public static bool SelectEntity(String dbTableName, Int64 rowId, Dictionary<String, Object> columns)
      {
         StringBuilder sql = new StringBuilder();
         bool succeedQuery = false;
         if (columns.Count == 0)
         {
            Debug.Assert(false);
         }
         else
         {
            sql.Append("SELECT ");
            bool firstEnter = true;
            foreach (String column in columns.Keys)
            {
               if (firstEnter)
               {
                  firstEnter = false;
               }
               else
               {
                  sql.Append(",");
               }
               sql.Append(column);
            }
            sql.Append(" FROM ");
            sql.Append(dbTableName);
            sql.Append(" WHERE ID == ");
            sql.Append("@rowId");
            DocumentTakeoff doc = NWAPI.Application.MainDocument.GetTakeoff();
            using (NavisworksCommand cmd = new NavisworksCommand(sql.ToString(), doc.Database.Value))
            {
               NavisworksParameter p = cmd.CreateParameter();
               p.ParameterName = "@rowId";
               p.Value = rowId;
               p.DbType = DbType.Int64;
               cmd.Parameters.Add(p);

               NavisWorksDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                  foreach (String column in columns.Keys.ToList<String>())
                  {
                     if (reader[column] is DBNull)
                     {
                        columns[column] = null;
                     }
                     else
                     {
                        columns[column] = reader[column];
                     }
                  }
                  succeedQuery = true;
               }
            }
         }
         return succeedQuery;

      }
      #endregion

      public static VariableNode FindVariableNode(VariableCollectionNode variableCollectionNode, String variableName)
      {
         if (variableCollectionNode == null)
            return null;
         if (variableCollectionNode.Variables == null)
            return null;
         if (variableCollectionNode.Variables.Count == 0)
            return null;
         VariableNode node = null;
         foreach (VariableNode v in variableCollectionNode.Variables)
         {
            if (v.VariableName.Equals(variableName))
            {
               node = v;
               break;
            }
         }
         return node;
      }

      /// <summary>
      /// Query ids from specific database table with condition
      /// </summary>
      /// <param name="dbTableName"></param>
      /// <param name="referenceId"></param>
      /// <param name="referenceColumn"></param>
      /// <returns></returns>
      public static List<Int64> SelectIds(String dbTableName, Int64? referenceId, String referenceColumn)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("SELECT ID FROM ");
         sql.Append(dbTableName);
         sql.Append(" WHERE ");
         sql.Append(referenceColumn);
         sql.Append(" is ");
         sql.Append("@referenceId");

         List<Int64> ids = new List<Int64>();
         DocumentTakeoff doc = NWAPI.Application.MainDocument.GetTakeoff();
         using (NavisworksCommand cmd = new NavisworksCommand(sql.ToString(), doc.Database.Value))
         {
            NavisworksParameter p = cmd.CreateParameter();
            p.ParameterName = "@referenceId";
            if (referenceId.HasValue)
            {
               p.Value = referenceId.Value;
            }
            else
            {
               p.Value = null;
            }
            cmd.Parameters.Add(p);

            NavisWorksDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               Debug.Assert(!(reader[0] is DBNull));
               ids.Add(Int64.Parse(reader[0].ToString()));
            }
         }
         return ids;
      }

      public static bool ExistResourceWithCatalogId(Guid catalogId, out Int64 Id)
      {
         ResourceEntity entity = new ResourceEntity();
         ResourceTable table = entity.GetTakeoffTable() as ResourceTable;
         return TestIfCatalogIdExistInDatabase(table.DbTableName, table.CatalogId.Name, catalogId, out Id);
      }

      /// <summary>
      /// Query catalog id from specific table in database to test whether it exists already
      /// </summary>
      /// <param name="dbTableName">database table name</param>
      /// <param name="idColumnName">column name of catalog id in database</param>
      /// <param name="catalogId">real catalog id</param>
      /// <param name="id">real id</param>
      public static bool TestIfCatalogIdExistInDatabase(String dbTableName, String idColumnName, Guid catalogId, out Int64 id)
      {
         id = -1;
         String sql = String.Format("SELECT ID FROM {0} WHERE {1} == @catalogId;", dbTableName, idColumnName);
         using (NavisworksConnection connection = NWAPI.Application.MainDocument.Database.Value)
         {
            NavisworksCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            NavisworksParameter p = cmd.CreateParameter();
            p.ParameterName = "@catalogId";
            p.Value = catalogId;
            p.DbType = DbType.Guid;
            cmd.Parameters.Add(p);
            using (NavisWorksDataReader dataReader = cmd.ExecuteReader())
            {
               bool exist = false;
               if (dataReader.Read())
               {
                  exist = Int64.TryParse(dataReader[0].ToString(), out id);
               }
               return exist;
            }
         }
      }

      public static String DoubleToNeutralString(Double number)
      {
         return number.ToString(System.Globalization.CultureInfo.InvariantCulture);
      }

      //const strings for variable's property name
      public const String Formula = "Formula";
      public const String Units = "Units";
      public const String Value = "Value";
   }
}
