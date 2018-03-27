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

//Navisworks using declaration
using Autodesk.Navisworks.Api.Takeoff;

namespace Takeoff.XMLImportExport.Model
{
   //instance of one row in database
   //either use a data structure to present one row
   //or use a DataRow to present one row
   abstract public class EntityBase
   {
      public EntityBase()
      {
         RowId = -1;
      }

      //Fixed field
      public Int64 RowId { get; set; }

      //Variable field
      public TakeoffVariableCollection Variables { get; set; }

      //Corresponding table definition
      abstract public TakeoffTable GetTakeoffTable();
   }
}
