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
using System.Collections.Generic;

//Navisworks using declaration
using Takeoff.XMLImportExport.Model;

namespace Takeoff.XMLImportExport.Node
{
   public class NodeBase
   {
      public EntityBase Entity { get; set; }
      public readonly IList<NodeBase> Children = new List<NodeBase>();
      //used to produce the SQL sentence
      public VariableCollectionNode VariableCollection { get; set; }
   }
}
