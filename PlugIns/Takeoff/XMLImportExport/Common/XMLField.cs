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

namespace Takeoff.XMLImportExport.Common
{
   public class XMLField
   {
      //xml node name
      public const String TakeoffRootNodeName = "Takeoff";
      public const String CatalogNodeName = "Catalog";
      public const String ConfigFileNodeName = "ConfigFile";
      public const String ItemGroupNodeName = "ItemGroup";
      public const String ItemNodeName = "Item";
      public const String StepNodeName = "Step";
      public const String StepResourceNodeName = "StepResource";
      public const String ObjectNodeName = "Object";
      public const String ObjectStepNodeName = "ObjectStep";
      public const String ObjectResourceNodeName = "ObjectResource";
      public const String ResourceGroupNodeName = "ResourceGroup";
      public const String ResourceNodeName = "Resource";
      public const String TakeoffVariableCollectionNodeName = "VariableCollection";
      public const String TakeoffVariableNodeName = "Variable";

      public const String NameColumn = "Name";
      public const String ResourceCatalogId = "ResourceCatalogId";
   }
}
