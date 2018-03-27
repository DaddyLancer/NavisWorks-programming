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

using Microsoft.CSharp;

namespace CodeRunLib
{
   class CodeRunCSharp : BaseGenerator
   {

      #region ICodeRun Members
      public override string Language
      {
         get
         {
            return "Visual C# .NET";
         }
      }

      public override void Generate(string code, string fullClassName, string mainFunction, out string errors, out string consoleOutput)
      {
         errors = string.Empty;
         consoleOutput = string.Empty;
         Generate(new CSharpCodeProvider(), code, fullClassName, mainFunction, out errors, out consoleOutput);
      }

      public override string StartCode
      {
         get
         {
            return
            "using System;\r\n" +
            "using System.Collections.Generic;\r\n" +
            "using System.ComponentModel;\r\n" +
            "using System.Drawing;\r\n" +
            "using System.Linq;\r\n" +
            "using System.Text;\r\n" +
            "using System.Windows.Forms;\r\n\r\n" +
            "using Autodesk.Navisworks.Api;\r\n\r\n" +
            "namespace CScript\r\n" +
            "{\r\n" +
            "  public class CScript\r\n" +
            "  {\r\n" +
            "     static public void Main()\r\n" +
            "     {\r\n" +
            "        /*Code goes here!!*/\r\n" +
            "     }\r\n" +
            "  }\r\n" +
            "}\r\n";
         }
      }
      #endregion

      public override string[] FileExtensions
      {
         get
         {
            return new string[] { "*.cs" };
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
