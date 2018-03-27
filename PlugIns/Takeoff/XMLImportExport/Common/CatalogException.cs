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

namespace Takeoff.XMLImportExport.Common
{
   public class CatalogException : Exception
   {
      public CatalogException(String message) : base(message) { }
   }
   public class CatalogConflictCancelException : CatalogException
   {
      public CatalogConflictCancelException(String message) : base(message) { }
   }
   public class CatalogFormatCorruptException : CatalogException
   {
      public CatalogFormatCorruptException(String message) : base(message) { }
   }
   public class CatalogItemContainsIllegalVariableException : CatalogException
   {
      public CatalogItemContainsIllegalVariableException(String message) : base(message) { }
   }
}
