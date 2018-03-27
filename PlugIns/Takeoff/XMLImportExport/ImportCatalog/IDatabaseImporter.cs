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

//Example using declaration
using Takeoff.XMLImportExport.Node;

namespace Takeoff.XMLImportExport.ImportCatalog
{
   public interface IDatabaseImporter
   {
      Boolean ContainsValidImport(TakeoffRootNode root);
      void Import(TakeoffRootNode root);
      void Import(ItemGroupNode itemGroup, Int64? parentId);
      void Import(ItemNode item, Int64? parentId);
      void Import(StepNode step, Int64 ItemId);
      void Import(ResourceGroupNode resourceGroup, Int64? parentId);
      void Import(ResourceNode resource, Int64? parentId);
      void Import(StepResourceNode stepResource, Int64 stepId, Int64 resourceId);
   }
}
