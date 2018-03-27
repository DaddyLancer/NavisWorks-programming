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
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Takeoff;

namespace Takeoff.XMLImportExport.Model
{
   public class ItemEntity : EntityBase
   {
      public ItemEntity()
      {
         Parent = null;
      }

      //Fixed fields
      public Int64? Parent { get; set; }
      public String Name { get; set; }
      public String WBS { get; set; }
      public String Description { get; set; }
      public double Transparency { get; set; }
      public Int64 Color { get; set; }
      public Guid CatalogId { get; set; }
      public Int64? Status { get; set; }
      public object Comment { get; set; }

      public override TakeoffTable GetTakeoffTable()
      {
         return Application.MainDocument.GetTakeoff().Items;
      }

   }
}

