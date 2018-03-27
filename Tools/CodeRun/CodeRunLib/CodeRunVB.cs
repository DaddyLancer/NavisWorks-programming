//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2010 by Autodesk Inc.

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
// This tool enables users to test plugin code within Navisworks without
// having to create an entire plugin first.
//
//------------------------------------------------------------------

using Microsoft.VisualBasic;

namespace CodeRunLib
{
   class CodeRunVB : BaseGenerator
   {
      public override string Language
      {
         get
         {
            return "Visual Basic .NET";
         }
      }

      #region ICodeRun Members

      public override void Generate(string code, string fullClassName, string mainFunction, out string errors, out string consoleOutput)
      {
         errors = string.Empty;
         consoleOutput = string.Empty;
         Generate(new VBCodeProvider(), code, fullClassName, mainFunction, out errors, out consoleOutput);
      }

      public override string StartCode
      {
         get
         {
            return
               "Imports System\r\n" +
               "Imports System.Collections.Generic\r\n" +
               "Imports System.ComponentModel\r\n" +
               "Imports System.Drawing\r\n" +
               "Imports System.Linq\r\n" +
               "Imports System.Text\r\n" +
               "Imports System.Windows.Forms\r\n\r\n" +
               "Imports Autodesk.Navisworks.Api\r\n\r\n" +
               "namespace CScript\r\n" +
               "  class CScript\r\n" +
               "     Public Sub Main()\r\n" +
               "     'CODE GOES HERE \r\n" +
               "     End Sub\r\n" + 
               "  end class\r\n" +
               "end namespace\r\n";
         }
      }

      #endregion

      public override string[] FileExtensions
      {
         get
         {
            return new string[] { "*.vb" };
         }
      }

      public override bool IsScriptingLanguage
      {
         get
         {
            return false;
         }
      }
   }
}
