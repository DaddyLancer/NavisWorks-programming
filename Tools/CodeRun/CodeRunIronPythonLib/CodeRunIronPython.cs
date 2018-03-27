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

using System;
using System.IO;

// Requires IronPython 2.6 -- see http://ironpython.net/
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace CodeRunLib
{
   class CodeRunIronPython : CodeRunPlugin.CodeRun
   {
      public ScriptEngine m_engine;
      public ScriptScope m_scope;

      public CodeRunIronPython()
      {
         m_engine = Python.CreateEngine();
      }

      #region ICodeRun Members
      public override string Language
      {
         get
         {
            return "IronPython";
         }
      }

      public override void Generate(string code, string fullClassName, string mainFunction, out string errors, out string consoleOutput)
      {
         errors = string.Empty;
         consoleOutput = string.Empty;

         m_scope = m_engine.CreateScope();

         try
         {
            // Redirect output
            MemoryStream ms = new MemoryStream();
            m_engine.Runtime.IO.SetOutput(ms, new StreamWriter(ms));

            object resp = m_engine.Execute(code, m_scope);

            string std_out = ReadFromStream(ms);

            if(std_out.Length > 0)
              consoleOutput += std_out;

            if (resp != null)
            {
              consoleOutput += m_engine.Operations.Format(resp);
            }
         }
         catch (Exception ex)
         {
            ExceptionOperations eo;
            eo = m_engine.GetService<ExceptionOperations>();
            errors += eo.FormatException(ex);
            return;
         }
      }

      public override string StartCode
      {
         get
         {
            return @"import clr
clr.AddReference('Autodesk.Navisworks.Api')
from Autodesk.Navisworks.Api import *

doc = Application.ActiveDocument
";
         }
      }
      #endregion

      public override string[] FileExtensions
      {
         get
         {
            return new string[] { "*.py" };
         }
      }

      public override bool IsScriptingLanguage
      {
         get
         {
            return true;
         }
      }

      private string ReadFromStream(Stream s)
      {
         s.Seek(0, SeekOrigin.Begin);
         StreamReader reader = new StreamReader(s);
         return reader.ReadToEnd();
      }
   }
}
