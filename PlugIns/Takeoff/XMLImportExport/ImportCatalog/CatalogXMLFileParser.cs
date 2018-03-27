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
using System.IO;
using System.Windows.Forms;
using System.Xml;

//Navisworks using declaration
using NWAPI = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Model;
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Common;

namespace Takeoff.XMLImportExport.ImportCatalog
{
   public class CatalogXMLFileParser : IXMLFileParser
   {
      public CatalogXMLFileParser(string filename)
      {
         File = filename;
         LoadXMLFile();
      }

      public String File { get; set; }

      public void LoadXMLFile()
      {
         XmlReaderSettings settings = new XmlReaderSettings();
         AddSchemasValidator(settings);
         settings.ValidationType = ValidationType.Schema;
         using (XmlReader reader = XmlReader.Create(File, settings))
         {
            XmlDocument doc = new XmlDocument();
            try
            {
               doc.Load(reader);
               doc.Validate(null);
            }
            catch (System.Xml.XmlException)
            {
               String xmlCorrupt = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_XML_Corrupt");
               throw new CatalogFormatCorruptException(xmlCorrupt);
            }
            catch (System.Xml.Schema.XmlSchemaValidationException)
            {
               String validationFailed = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Validation_Failed");
               throw new CatalogFormatCorruptException(validationFailed);
            }

            //check root node in xml file
            m_root = doc.GetElementsByTagName(XMLField.TakeoffRootNodeName)[0];
            if (m_root == null)
            {
               String takeoffNodeMissing = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_TakeoffNode_Missing");
               throw new CatalogFormatCorruptException(takeoffNodeMissing);
            }

            String versionString = GetVersionString(m_root);
            if (!Version.Equals(versionString))
            {
               String versionUnknonw = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Version_Unknown");
               throw new CatalogFormatCorruptException(versionUnknonw);
            }
         }
      }

      protected void AddSchemasValidator(XmlReaderSettings reader)
      {
         String ns = SchemaUrlPrefix + Version + SchemaPostFix;
         String catalogXsd = Version + SchemaPostFix;
         String catalogXsdFullPath;
         if (FindXSDFile(SchemasDirectory, catalogXsd, out catalogXsdFullPath))
         {
            reader.Schemas.Add(ns, catalogXsdFullPath);
         }
      }

      private bool FindXSDFile(string subdir, string filename, out string resolved_path)
      {
         
         String directory = AssemblyDirectory;
         string path = Path.Combine(directory, subdir,filename);
         if (System.IO.File.Exists(path))
         {
            resolved_path = path;
            return true;
         }
         else
         {
            resolved_path = string.Empty;
            return false;
         }         
      }

      /// <summary>
      /// To get the directory of Navisworks exe
      /// </summary>
      public static string AssemblyDirectory
      {
         get
         {
            string codeBase = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return System.IO.Path.GetDirectoryName(path);
         }
      }

      protected String GetVersionString(XmlNode root)
      {
         String version = null;
         String ns = root.NamespaceURI;
         if (!String.IsNullOrEmpty(ns) && ns.StartsWith(SchemaUrlPrefix))
         {
            string fileName = ns.Substring(SchemaUrlPrefix.Length);
            if (fileName.Length > SchemaPostFix.Length)
            {
               version = fileName.Substring(0, fileName.Length - SchemaPostFix.Length);
            }
         }
         return version;
      }

      #region Parse Catalog
      public TakeoffRootNode ParseCatalog()
      {
         XmlNode catalog = null;
         foreach (XmlNode node in m_root.ChildNodes)
         {
            if (node.Name.Equals(XMLField.CatalogNodeName))
            {
               catalog = node;
               break;
            }
         }

         //catalog element can be null;
         if (catalog == null || catalog.ChildNodes.Count == 0)
            return null;

         TakeoffRootNode takeoffNode = new TakeoffRootNode();
         Debug.Assert(catalog.Name.Equals(XMLField.CatalogNodeName));
         foreach (XmlNode xmlNode in catalog.ChildNodes)
         {
            if (xmlNode.Name.Equals(XMLField.ItemGroupNodeName))
            {
               ItemGroupNode child = ParseItemGroup(xmlNode);
               takeoffNode.CatalogNodes.Add(child);
               child.Parent = null;
            }
            else if (xmlNode.Name.Equals(XMLField.ItemNodeName))
            {
               ItemNode child = ParseItem(xmlNode);
               takeoffNode.CatalogNodes.Add(child);
               child.Parent = null;
            }
            else if (xmlNode.Name.Equals(XMLField.ResourceGroupNodeName))
            {
               ResourceGroupNode child = ParseResourceGroup(xmlNode);
               takeoffNode.CatalogNodes.Add(child);
               child.Parent = null;
            }
            else if (xmlNode.Name.Equals(XMLField.ResourceNodeName))
            {
               ResourceNode child = ParseResource(xmlNode);
               takeoffNode.CatalogNodes.Add(child);
               child.Parent = null;
            }
            else
            {
               Debug.Assert(false);
            }
         }
         Clear();
         return takeoffNode;
      }

      private void Clear()
      {
         m_itemgroup_set.Clear();
         m_item_set.Clear();
         m_step_set.Clear();
         m_stepresource_set.Clear();
         m_resourcegroup_set.Clear();
         m_resource_set.Clear();
      }

      public ItemGroupNode ParseItemGroup(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.ItemGroupNodeName));
         ItemGroupNode itemGroupNode = new ItemGroupNode();
         //fill in entity attribute
         FillItemGroupAttributes(itemGroupNode, xmlNode);

         //parse child nodes
         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.ItemGroupNodeName))
            {
               ItemGroupNode child = ParseItemGroup(childNode);
               itemGroupNode.Children.Add(child);
               child.Parent = itemGroupNode;
            }
            else if (childNode.Name.Equals(XMLField.ItemNodeName))
            {
               ItemNode child = ParseItem(childNode);
               itemGroupNode.Children.Add(child);
               child.Parent = itemGroupNode;
            }
            else if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               itemGroupNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else
            {
               Debug.Assert(false);
            }

         }
         return itemGroupNode;
      }

      public ItemNode ParseItem(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.ItemNodeName));
         ItemNode itemNode = new ItemNode();
         FillItemAttributes(itemNode, xmlNode);

         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               itemNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else if (childNode.Name.Equals(XMLField.StepNodeName))
            {
               StepNode child = ParseStep(childNode);
               itemNode.Children.Add(child);
               child.Item = itemNode;
            }
            else
            {
               Debug.Assert(false);
            }
         }
         return itemNode;
      }

      public StepNode ParseStep(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.StepNodeName));
         StepNode stepNode = new StepNode();
         FillStepAttributes(stepNode, xmlNode);

         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               stepNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else if (childNode.Name.Equals(XMLField.StepResourceNodeName))
            {
               StepResourceNode child = ParseStepResource(childNode);
               stepNode.Children.Add(child);
               child.Step = stepNode;
            }
            else
            {
               Debug.Assert(false);
            }
         }
         return stepNode;
      }

      public StepResourceNode ParseStepResource(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.StepResourceNodeName));
         StepResourceNode stepResourceNode = new StepResourceNode();
         FillStepResourceAttributes(stepResourceNode, xmlNode);

         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               stepResourceNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         return stepResourceNode;
      }

      public ResourceGroupNode ParseResourceGroup(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.ResourceGroupNodeName));
         ResourceGroupNode resourceGroupNode = new ResourceGroupNode();
         FillResourceGroupAttributes(resourceGroupNode, xmlNode);

         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.ResourceGroupNodeName))
            {
               ResourceGroupNode child = ParseResourceGroup(childNode);
               resourceGroupNode.Children.Add(child);
               child.Parent = resourceGroupNode;
            }
            else if (childNode.Name.Equals(XMLField.ResourceNodeName))
            {
               ResourceNode child = ParseResource(childNode);
               resourceGroupNode.Children.Add(child);
               child.Parent = resourceGroupNode;
            }
            else if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               resourceGroupNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         return resourceGroupNode;
      }

      public ResourceNode ParseResource(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.ResourceNodeName));
         ResourceNode resourceNode = new ResourceNode();
         FillResourceAttributes(resourceNode, xmlNode);
         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            if (childNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName))
            {
               resourceNode.VariableCollection = ParseTakeoffVariableCollection(childNode);
            }
            else
            {
               Debug.Assert(false);
            }
         }
         return resourceNode;
      }

      public VariableCollectionNode ParseTakeoffVariableCollection(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.TakeoffVariableCollectionNodeName));
         VariableCollectionNode variableCollectionNode = new VariableCollectionNode();
         foreach (XmlNode childNode in xmlNode.ChildNodes)
         {
            Debug.Assert(childNode.Name.Equals(XMLField.TakeoffVariableNodeName));
            VariableNode variableNode = ParseTakeoffVariable(childNode);
            if (variableCollectionNode.Variables.Find(x => x.VariableName.Equals(variableNode.VariableName)) != null)
            {
               String duplicateVariable = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Takeoff_Variable_Duplicate");

               String error = String.Empty;
               if (!String.IsNullOrEmpty(duplicateVariable))
               {
                  error = String.Format(duplicateVariable, variableNode.VariableName);
               }
               throw new CatalogFormatCorruptException(error);
            }
            variableCollectionNode.Variables.Add(variableNode);
         }
         return variableCollectionNode;
      }

      public VariableNode ParseTakeoffVariable(XmlNode xmlNode)
      {
         Debug.Assert(xmlNode.Name.Equals(XMLField.TakeoffVariableNodeName));
         VariableNode variableNode = new VariableNode();
         FillVariableAttributes(variableNode, xmlNode);
         return variableNode;
      }
      #endregion

      #region Fill Attribute
      private void FillItemGroupAttributes(ItemGroupNode itemGroup, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         ItemGroupEntity entity = new ItemGroupEntity();
         ItemGroupTable table = entity.GetTakeoffTable() as ItemGroupTable;
         CheckPropertyMustExist(properties, table.Name.Name);
         CheckPropertyMustExist(properties, table.WBS.Name);
         entity.Name = properties[table.Name.Name];
         entity.Parent = null;
         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         if (properties.ContainsKey(table.Parent.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.Parent.Name], out id))
            {
               entity.Parent = id;
            }

         }
         if (properties.ContainsKey(table.WBS.Name))
         {
            entity.WBS = properties[table.WBS.Name];
         }
         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }
         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_itemgroup_set, entity.CatalogId);
         }
         itemGroup.Entity = entity;
      }

      private void FillItemAttributes(ItemNode item, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         ItemEntity entity = new ItemEntity();
         ItemTable table = entity.GetTakeoffTable() as ItemTable;
         CheckPropertyMustExist(properties, table.Name.Name);
         CheckPropertyMustExist(properties, table.WBS.Name);
         CheckPropertyMustExist(properties, table.Transparency.Name);
         CheckPropertyMustExist(properties, table.Color.Name);
         entity.Name = properties[table.Name.Name];
         entity.Transparency = ParseNeutralStringToDouble(properties[table.Transparency.Name]);
         entity.Color = Int64.Parse(properties[table.Color.Name]);
         entity.Parent = null;
         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         if (properties.ContainsKey(table.Parent.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.Parent.Name], out id))
            {
               entity.Parent = id;
            }
         }
         entity.WBS = properties[table.WBS.Name];

         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }
         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_item_set, entity.CatalogId);
         }
         item.Entity = entity;
      }

      private void FillStepAttributes(StepNode step, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         StepEntity entity = new StepEntity();
         StepTable table = entity.GetTakeoffTable() as StepTable;

         CheckPropertyMustExist(properties, table.Name.Name);

         entity.Name = properties[table.Name.Name];

         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         if (properties.ContainsKey(table.ItemId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.ItemId.Name], out id))
            {
               entity.ItemId = id;
            }
         }
         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }

         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_step_set, entity.CatalogId);
         }
         step.Entity = entity;
      }

      private void FillStepResourceAttributes(StepResourceNode stepResource, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         StepResourceEntity entity = new StepResourceEntity();
         StepResourceTable table = entity.GetTakeoffTable() as StepResourceTable;
         CheckPropertyMustExist(properties, XMLField.ResourceCatalogId);

         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }
         if (properties.ContainsKey(table.StepId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.StepId.Name], out id))
            {
               entity.StepId = id;
            }
         }
         if (properties.ContainsKey(table.ResourceId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.ResourceId.Name], out id))
            {
               entity.ResourceId = id;
            }
         }
         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_stepresource_set, entity.CatalogId);
         }
         if (properties.ContainsKey(XMLField.ResourceCatalogId))
         {
            entity.ResourceCatalogId = new Guid(properties[XMLField.ResourceCatalogId]);
         }
         stepResource.Entity = entity;
      }

      private void FillResourceGroupAttributes(ResourceGroupNode resourceGroup, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         ResourceGroupEntity entity = new ResourceGroupEntity();
         ResourceGroupTable table = entity.GetTakeoffTable() as ResourceGroupTable;

         CheckPropertyMustExist(properties, table.Name.Name);
         CheckPropertyMustExist(properties, table.RBS.Name);

         entity.Name = properties[table.Name.Name];
         entity.RBS = properties[table.RBS.Name];
         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }
         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         entity.Parent = null;
         if (properties.ContainsKey(table.Parent.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.Parent.Name], out id))
            {
               entity.Parent = id;
            }
         }
         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_resourcegroup_set, entity.CatalogId);
         }
         resourceGroup.Entity = entity;
      }

      private void FillResourceAttributes(ResourceNode resource, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);
         ResourceEntity entity = new ResourceEntity();
         ResourceTable table = entity.GetTakeoffTable() as ResourceTable;
         CheckPropertyMustExist(properties, table.Name.Name);
         CheckPropertyMustExist(properties, table.RBS.Name);

         entity.Name = properties[table.Name.Name];
         entity.RBS = properties[table.RBS.Name];
         if (properties.ContainsKey(table.RowId.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.RowId.Name], out id))
            {
               entity.RowId = id;
            }
         }
         if (properties.ContainsKey(table.Description.Name))
         {
            entity.Description = properties[table.Description.Name];
         }
         entity.Parent = null;
         if (properties.ContainsKey(table.Parent.Name))
         {
            Int64 id;
            if (Int64.TryParse(properties[table.Parent.Name], out id))
            {
               entity.Parent = id;
            }
         }
         if (properties.ContainsKey(table.CatalogId.Name))
         {
            entity.CatalogId = new Guid(properties[table.CatalogId.Name]);
            CheckGuidAlreadyExist(m_resource_set, entity.CatalogId);
         }
         resource.Entity = entity;
      }

      private void FillVariableAttributes(VariableNode variable, XmlNode node)
      {
         Dictionary<String, String> properties = DictionaryFromAttributes(node);

         CheckPropertyMustExist(properties, XMLField.NameColumn);

         variable.VariableName = properties[XMLField.NameColumn];
         properties.Remove(XMLField.NameColumn);
         variable.Properties = properties;
      }

      private void CheckPropertyMustExist(Dictionary<String, String> properties, String property)
      {
         if (!properties.ContainsKey(property))
         {
            string error = NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Missing_Property");
            throw new CatalogFormatCorruptException(error + property);
         }
      }

      private Dictionary<String, String> DictionaryFromAttributes(XmlNode node)
      {
         Dictionary<String, String> dic = new Dictionary<String, String>();
         foreach (XmlAttribute attibute in node.Attributes)
         {
            dic.Add(attibute.Name, attibute.Value);
         }
         return dic;
      }

      private void CheckGuidAlreadyExist(HashSet<Guid> set, Guid guid)
      {
         if (!guid.Equals(Guid.Empty))
         {
            if (!set.Contains(guid))
            {
               set.Add(guid);
            }
            else
            {
               throw new CatalogFormatCorruptException(NWAPI.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Duplicated_Guid"));
            }
         }
      }

      private Double ParseNeutralStringToDouble(String s)
      {
         return Double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
      }
      #endregion

      //const
      public const String SchemasDirectory = "schemas";
      public const String SchemaUrlPrefix = @"http://download.autodesk.com/us/navisworks/schemas/";
      public const String Version = @"nw-TakeoffCatalog-10.0";
      public const String SchemaPostFix = @".xsd";

      //variable
      private XmlNode m_root;

      //set for duplicated GUID check
      private HashSet<Guid> m_itemgroup_set = new HashSet<Guid>();
      private HashSet<Guid> m_item_set = new HashSet<Guid>();
      private HashSet<Guid> m_step_set = new HashSet<Guid>();
      private HashSet<Guid> m_stepresource_set = new HashSet<Guid>();
      private HashSet<Guid> m_resourcegroup_set = new HashSet<Guid>();
      private HashSet<Guid> m_resource_set = new HashSet<Guid>();
   }
}
