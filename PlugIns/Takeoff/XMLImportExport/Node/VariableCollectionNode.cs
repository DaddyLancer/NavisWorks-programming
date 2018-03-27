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

namespace Takeoff.XMLImportExport.Node
{
   public class VariableCollectionNode
   {
      public readonly List<VariableNode> Variables = new List<VariableNode>();
   }

   public class VariableNode
   {
      public String VariableName { get; set; }
      public Dictionary<String, String> Properties { get; set; }
   }
}
