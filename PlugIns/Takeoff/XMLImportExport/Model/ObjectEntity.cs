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
   /// <summary>
   /// Object entity is generally used to export to external file, update from external file.
   /// Can use ObjectTable.InsertVirtualTakeoff to create virtual takeoff
   /// </summary>
   public class ObjectEntity : EntityBase
   {
      public ObjectEntity()
      {
         Parent = -1;
      }

      //Fixed field
      public Int64 Parent { get; set; }
      public String WBS { get; set; }
      public Guid? ModelItemId { get; set; }
      public Guid? SavedViewpointId { get; set; }
      public Int64? SheetId { get; set; }
      public Int64? Status { get; set; }
      public object Comment { get; set; }

      override public TakeoffTable GetTakeoffTable()
      {
         return Application.MainDocument.GetTakeoff().Objects;
      }
   }
}
