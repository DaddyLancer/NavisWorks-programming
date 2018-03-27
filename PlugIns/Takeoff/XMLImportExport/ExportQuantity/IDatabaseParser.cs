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

namespace Takeoff.XMLImportExport.Utility
{
   public interface IDatabaseParser
   {
      TakeoffRootNode ParseDatabase();
      ItemGroupNode ParseItemgroup(Int64 rowId);
      ItemNode ParseItem(Int64 rowId);
      ObjectNode ParseObject(Int64 rowId);
      StepNode ParseStep(Int64 rowId);
      ObjectStepNode ParseObjectStep(Int64 rowId);
      ResourceGroupNode ParseResourceGroup(Int64 rowId);
      ResourceNode ParseResource(Int64 rowId);
      StepResourceNode ParseStepResource(Int64 rowId);
      ObjectResourceNode ParseObjectResource(Int64 rowId);
   }
}
