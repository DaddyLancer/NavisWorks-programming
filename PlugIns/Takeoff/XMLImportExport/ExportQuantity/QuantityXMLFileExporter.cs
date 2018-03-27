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
using System.Xml;

//Navisworks using declaration
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Common;
using Takeoff.XMLImportExport.Model;
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Utility;

namespace Takeoff.XMLImportExport.ExportQuantity
{
   public class QuantityXMLFileExporter : IXMLFileExporter
   {
      public void TakeoffNodeToXML(TakeoffRootNode takeoff, String filename)
      {
         XmlWriterSettings settings = new XmlWriterSettings();
         settings.Indent = true;
         settings.NewLineChars = NewLine;
         settings.IndentChars = ElementIndent;
         settings.Encoding = System.Text.Encoding.UTF8;
         using (m_writer = XmlTextWriter.Create(filename, settings))
         {
            SerializeTakeoffNode(takeoff);
         }
      }

      #region serialize takeoff node to xml
      public void SerializeTakeoffNode(TakeoffRootNode takeoff)
      {
         String ns = SchemaUrlPrefix + RetrieveSchemaVersion() + SchemaPostFix;
         m_writer.WriteStartElement(XMLField.TakeoffRootNodeName, ns);
         AddVersionToRootNode();
         SerializeQuantityFile(takeoff);
         m_writer.WriteEndElement();
      }

      public void SerializeQuantityFile(TakeoffRootNode takeoff)
      {
         if (takeoff.CatalogNodes.Count == 0)
         {
            return;
         }

         m_writer.WriteStartElement(XMLField.CatalogNodeName);
         foreach (NodeBase node in takeoff.CatalogNodes)
         {
            if (node is ItemGroupNode)
            {
               SerializeItemGroupNode(node as ItemGroupNode);
            }
            else if (node is ItemNode)
            {
               SerializeItemNode(node as ItemNode);
            }
            else if (node is ResourceGroupNode)
            {
               SerializeResourceGroupNode(node as ResourceGroupNode);
            }
            else if (node is ResourceNode)
            {
               SerializeResourceNode(node as ResourceNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         m_writer.WriteEndElement();
      }

      public void SerializeItemGroupNode(ItemGroupNode itemGroup)
      {
         ItemGroupEntity entity = itemGroup.Entity as ItemGroupEntity;
         ItemGroupTable table = entity.GetTakeoffTable() as ItemGroupTable;

         m_writer.WriteStartElement(XMLField.ItemGroupNodeName);

         ToXMLAttributes(table.Name.Name, entity.Name);
         ToXMLAttributes(table.Description.Name, entity.Description);
         ToXMLAttributes(table.WBS.Name, entity.WBS);
         ToXMLAttributes(table.CatalogId.Name, entity.CatalogId.ToString());

         SerializeTakeoffVariableCollection(entity.Variables);

         foreach (NodeBase node in itemGroup.Children)
         {
            if (node is ItemGroupNode)
            {
               SerializeItemGroupNode(node as ItemGroupNode);
            }
            else if (node is ItemNode)
            {
               SerializeItemNode(node as ItemNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         m_writer.WriteEndElement();
      }

      public void SerializeItemNode(ItemNode item)
      {
         ItemEntity entity = item.Entity as ItemEntity;
         ItemTable table = entity.GetTakeoffTable() as ItemTable;

         m_writer.WriteStartElement(XMLField.ItemNodeName);

         ToXMLAttributes(table.Name.Name, entity.Name);
         ToXMLAttributes(table.Description.Name, entity.Description);
         ToXMLAttributes(table.WBS.Name, entity.WBS);
         ToXMLAttributes(table.Transparency.Name, DatabaseUtility.DoubleToNeutralString(entity.Transparency));
         ToXMLAttributes(table.Color.Name, entity.Color.ToString());
         ToXMLAttributes(table.CatalogId.Name, entity.CatalogId.ToString());

         SerializeTakeoffVariableCollection(entity.Variables);
         foreach (NodeBase node in item.Children)
         {
            if (node is StepNode)
            {
               //Do not serialize steps, just serialize its children which types are StepResource
               foreach (NodeBase child in node.Children)
               {
                  if (child is StepResourceNode)
                  {
                     SerializeStepResourceNode(child as StepResourceNode);
                  }
               }
            }
            else if (node is ObjectNode)
            {
               SerializeObjectNode(node as ObjectNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         m_writer.WriteEndElement();
      }

      public void SerializeObjectNode(ObjectNode objectNode)
      {
         ObjectEntity entity = objectNode.Entity as ObjectEntity;
         ObjectTable table = entity.GetTakeoffTable() as ObjectTable;

         m_writer.WriteStartElement(XMLField.ObjectNodeName);
         ToXMLAttributes(table.RowId.Name, entity.RowId.ToString());
         ToXMLAttributes(table.Parent.Name, entity.Parent.ToString());
         ToXMLAttributes(table.WBS.Name, entity.WBS);
         if (entity.ModelItemId != null && !entity.ModelItemId.Equals(Guid.Empty))
         {
            ToXMLAttributes(table.ModelItemId.Name, entity.ModelItemId.ToString());
         }
         if (entity.SavedViewpointId != null && !entity.SavedViewpointId.Equals(Guid.Empty))
         {
            ToXMLAttributes(table.SavedViewpointId.Name, entity.SavedViewpointId.ToString());
         }
         if (entity.SheetId != null)
         {
            ToXMLAttributes(table.SheetId.Name, entity.SheetId.ToString());
         }
         if (entity.Status != null)
         {
            ToXMLAttributes(table.Status.Name, entity.SheetId.ToString());
         }
         SerializeTakeoffVariableCollection(entity.Variables);
         m_writer.WriteEndElement();
      }

      public void SerializeResourceGroupNode(ResourceGroupNode resourceGroup)
      {
         ResourceGroupEntity entity = resourceGroup.Entity as ResourceGroupEntity;
         ResourceGroupTable table = entity.GetTakeoffTable() as ResourceGroupTable;

         m_writer.WriteStartElement(XMLField.ResourceGroupNodeName);

         ToXMLAttributes(table.Name.Name, entity.Name);
         ToXMLAttributes(table.Description.Name, entity.Description);
         ToXMLAttributes(table.RBS.Name, entity.RBS);
         ToXMLAttributes(table.CatalogId.Name, entity.CatalogId.ToString());
         SerializeTakeoffVariableCollection(entity.Variables);
         foreach (NodeBase node in resourceGroup.Children)
         {
            if (node is ResourceGroupNode)
            {
               SerializeResourceGroupNode(node as ResourceGroupNode);
            }
            else if (node is ResourceNode)
            {
               SerializeResourceNode(node as ResourceNode);
            }
         }
         m_writer.WriteEndElement();
      }

      public void SerializeResourceNode(ResourceNode resource)
      {

         ResourceEntity entity = resource.Entity as ResourceEntity;
         ResourceTable table = entity.GetTakeoffTable() as ResourceTable;

         m_writer.WriteStartElement(XMLField.ResourceNodeName);

         ToXMLAttributes(table.Name.Name, entity.Name);
         ToXMLAttributes(table.Description.Name, entity.Description);
         ToXMLAttributes(table.RBS.Name, entity.RBS);

         ToXMLAttributes(table.CatalogId.Name, entity.CatalogId.ToString());
         SerializeTakeoffVariableCollection(entity.Variables);
         foreach (NodeBase node in resource.Children)
         {
            //do nothing, step handles step resource
         }
         m_writer.WriteEndElement();
      }

      public void SerializeStepResourceNode(StepResourceNode stepResource)
      {
         StepResourceEntity entity = stepResource.Entity as StepResourceEntity;
         StepResourceTable table = entity.GetTakeoffTable() as StepResourceTable;
         m_writer.WriteStartElement(XMLField.StepResourceNodeName);

         ToXMLAttributes(table.Description.Name, entity.Description);
         ToXMLAttributes(table.CatalogId.Name, entity.CatalogId.ToString());
         //Add ResourceCatalogId as its resource parent identifier, in this way, able to import step resource that reference existing resource
         ToXMLAttributes(XMLField.ResourceCatalogId, entity.ResourceCatalogId.ToString());

         SerializeTakeoffVariableCollection(entity.Variables);
         foreach (NodeBase node in stepResource.Children)
         {
            if (node is ObjectResourceNode)
            {
               SerializeObjectResourceNode(node as ObjectResourceNode);
            }
         }
         m_writer.WriteEndElement();
      }

      public void SerializeObjectResourceNode(ObjectResourceNode objectResourceNode)
      {
         ObjectResourceEntity entity = objectResourceNode.Entity as ObjectResourceEntity;
         ObjectResourceTable table = entity.GetTakeoffTable() as ObjectResourceTable;

         m_writer.WriteStartElement(XMLField.ObjectResourceNodeName);
         ToXMLAttributes(table.RowId.Name, entity.RowId.ToString());
         ToXMLAttributes(table.ObjectStepId.Name, entity.ObjectStepId.ToString());
         ToXMLAttributes(table.StepResourceId.Name, entity.StepResourceId.ToString());
         SerializeTakeoffVariableCollection(entity.Variables);
         m_writer.WriteEndElement();
      }

      public void SerializeTakeoffVariableCollection(TakeoffVariableCollection collection)
      {
         bool export = false;
         foreach (TakeoffVariable variable in collection)
         {
            if (IsTakeoffVariableHaveValidValue(variable))
            {
               export = true;
               break;
            }
         }
         if (export)
         {
            m_writer.WriteStartElement(XMLField.TakeoffVariableCollectionNodeName);
            foreach (TakeoffVariable variable in collection)
            {
               SerializeTakeoffVariable(variable);
            }
            m_writer.WriteEndElement();
         }
      }

      public void SerializeTakeoffVariable(TakeoffVariable variable)
      {
         bool export = IsTakeoffVariableHaveValidValue(variable);
         if (export)
         {
            TakeoffVariableDefinition variableDef = variable.Definition;
            m_writer.WriteStartElement(XMLField.TakeoffVariableNodeName);
            ToXMLAttributes(XMLField.NameColumn, variableDef.Name);
            if (variableDef.Purpose == Purpose.Calculation || variableDef.Purpose == Purpose.Rollup)
            {
               if (!string.IsNullOrEmpty(variable.ActiveFormula))
               {
                  ToXMLAttributes(Formula, variable.ActiveFormula);
               }
               if (variable.ActiveUnits != TakeoffUnits.Unspecified && variable.ActiveUnits != TakeoffUnits.UnitLess)
               {
                  ToXMLAttributes(Units, variable.ActiveUnits.ToString());
               }
               if (variable.Value != VariantData.FromNone())
               {
                  //When parse value from database, valid values are parsed to double and invalid values are parsed to int32. 
                  //So here use its type to identify which one is valid value and which one is error.
                  if (variable.Value.IsDouble)
                  {
                     ToXMLAttributes(Value, DatabaseUtility.DoubleToNeutralString(variable.ValueToDouble()));
                  }
                  else if (variable.Value.IsInt32)
                  {
                     ToXMLAttributes(Value, Error);
                  }
               }
            }
            else if (variableDef.Purpose == Purpose.Input)
            {
               if (variable.ActiveValue != VariantData.FromNone())
               {
                  if (variable.ActiveValue.IsDisplayString)
                  {
                     ToXMLAttributes(Value, variable.ActiveValue.ToDisplayString());
                  }
                  else if (variable.ActiveValue.IsDouble)
                  {
                     ToXMLAttributes(Value, DatabaseUtility.DoubleToNeutralString(variable.ActiveValue.ToDouble()));
                  }
               }
               if (variable.ActiveUnits != TakeoffUnits.Unspecified && variable.ActiveUnits != TakeoffUnits.UnitLess)
               {
                  ToXMLAttributes(Units, variable.ActiveUnits.ToString());
               }
            }
            else
            {
               Debug.Assert(false);
            }
            m_writer.WriteEndElement();
         }
      }

#endregion

      public bool IsTakeoffVariableHaveValidValue(TakeoffVariable variable)
      {
         TakeoffVariableDefinition variableDef = variable.Definition;
         if (variableDef.Purpose == Purpose.Calculation || variableDef.Purpose == Purpose.Rollup)
         {
            if (!string.IsNullOrEmpty(variable.ActiveFormula))
            {
               return true;
            }
            if (variable.Value != VariantData.FromNone())
            {
               //When parse value from database, valid values are parsed to double and invalid values are parsed to int32. 
               //So here use its type to identify which one is valid value and which one is error.
               if (variable.Value.IsDouble)
               {
                  return true;
               }
               else if (variable.Value.IsInt32)
               {
                  return true;
               }
            }
         }
         else if (variableDef.Purpose == Purpose.Input)
         {
            if (variable.ActiveValue != VariantData.FromNone())
            {
               if (variable.ActiveValue.IsDisplayString)
               {
                  return true;
               }
               else if (variable.ActiveValue.IsDouble)
               {
                  return true;
               }
            }
         }
         else
         {
            Debug.Assert(false);
         }
         return false;
      }

      protected void AddVersionToRootNode()
      {
         String ns = SchemaUrlPrefix + RetrieveSchemaVersion() + SchemaPostFix;
         m_writer.WriteAttributeString("xmlns", "xs", null, W3SchemaURl);
      }

      protected String RetrieveSchemaVersion()
      {
         return Version;
      }

      protected void ToXMLAttributes(String attribute, String value)
      {
         Debug.Assert(attribute != null);
         if (value == null)
            return;
         m_writer.WriteAttributeString(attribute, value);
      }

      protected XmlWriter m_writer = null;

      public const String ElementIndent = "\t";
      public const String NewLine = "\r\n";
      public const String Formula = DatabaseUtility.Formula;
      public const String Units = DatabaseUtility.Units;
      public const String Value = DatabaseUtility.Value;
      public const String Error = "Error";
      public const String SchemaUrlPrefix = @"http://download.autodesk.com/us/navisworks/schemas/";
      public const String W3SchemaURl = @"http://www.w3.org/2001/XMLSchema";
      public const String Version = @"nw-TakeoffQuantity-10.0";
      public const String SchemaPostFix = @".xsd";
   }
}
