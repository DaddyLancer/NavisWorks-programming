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
   ///Object step is produced from database trigger, should not insert object step directly
   ///Although ObjectStepTable contains input column, those are only column reference, should not query & modify input column directly from ObjectStep
   ///Instead, should through Object Table
   /// </summary>
   public class ObjectStepEntity : EntityBase
   {
      public ObjectStepEntity()
      {
         ObjectId = -1;
         StepId = -1;
      }
      //Fixed field
      public Int64 ObjectId { get; set; }
      public Int64 StepId { get; set; }

      override public TakeoffTable GetTakeoffTable()
      {
         return Application.MainDocument.GetTakeoff().ObjectSteps;
      }
   }
}
