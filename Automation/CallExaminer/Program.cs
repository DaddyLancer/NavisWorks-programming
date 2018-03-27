//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2009 by Autodesk Inc.

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
//------------------------------------------------------------------
//
// This sample shows one of the methods by which a plugin can react
// differently depending on whether or not it is running through
// Automation.
// Note: requires the Examiner plugin to be built beforehand.
//------------------------------------------------------------------

using Autodesk.Navisworks.Api.Automation;
using System;

namespace CallExaminer
{
   class Program
   {
      static void Main(string[] args)
      {
         NavisworksApplication navisworksApplication = null;
         try
         {
            // Start Navisworks
            navisworksApplication = new NavisworksApplication();

            //Call the Examiner Plugin using the arguments passed to this exe
            navisworksApplication.ExecuteAddInPlugin("Examiner.Examiner.ADSK", args);
         }
         catch (InvalidOperationException e)
         {
            Console.WriteLine("InvalidOperationException: " + e.Message);
         }
         catch (ArgumentException e)
         {
            Console.WriteLine("ArgumentException: " + e.Message);
         }
         finally
         {
            //Close Navisworks
            if (navisworksApplication != null)
            {
               navisworksApplication.Dispose();
            }
         }
      }
   }
}
