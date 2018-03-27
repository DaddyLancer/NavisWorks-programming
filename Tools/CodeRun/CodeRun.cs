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

namespace CodeRunPlugin
{
   /// <summary>
   /// Implement this abstract class to use other languages language 
   /// </summary>
   public abstract class CodeRun
   {
      /// <summary>
      /// Runs the code provided by code
      /// </summary>
      /// <param name="headerDirectives">any header directives required</param>
      /// <param name="code">the code to run</param>
      /// <param name="errors">any erros that occur during either compiling the code or running it</param>
      /// <param name="consoleOutput">any output directed to the console</param>
      public abstract void Generate(string code, string fullClassName, string mainFunction, out string errors, out string consoleOutput);

      /// <summary>
      /// Gets the language that this code compiler handles 
      /// </summary>
      public abstract string Language
      {
         get;
      }

      /// <summary>
      /// Gets whether this is a scripting language
      /// </summary>
      public abstract bool IsScriptingLanguage
      {
         get;
      }

      /// <summary>
      /// Gets the default start code that must be filled in to do the appropriate task
      /// </summary>
      public abstract string StartCode
      {
         get;
      }

      /// <summary>
      /// Gets the file extension associated with file created using this code language
      /// </summary>
      public abstract string[] FileExtensions
      {
         get;
      }

      /// <summary>
      /// Override ToString for ComboBox display
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
         return Language;
      }
   }
}
