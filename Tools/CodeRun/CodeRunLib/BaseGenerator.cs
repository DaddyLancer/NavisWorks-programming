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
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace CodeRunLib
{
   /// <summary>
   /// Provides access to instances of the CodeDomProvider derived code generator and code
   //  compilers. For example VB.NET and C#.NET compilations
   /// </summary>
   internal abstract class BaseGenerator: CodeRunPlugin.CodeRun
   {
      internal void Generate(CodeDomProvider codeProvider, string sourceCode, string classToCreate, string callFunction, out string errors, out string consoleOutput)
      {
         errors = string.Empty;
         consoleOutput = string.Empty;

         try
         {
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            
            //Set the Parameters
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.WarningLevel = 3;
            parameters.TreatWarningsAsErrors = false;
            parameters.MainClass = classToCreate;
            parameters.IncludeDebugInformation = true;
            parameters.CompilerOptions = "/t:library";

            //Add the Assemblies we have loaded in Navisworks
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
               if (!asm.IsDynamic && !parameters.ReferencedAssemblies.Contains(asm.Location) && asm.Location != null && asm.Location != string.Empty)
                  parameters.ReferencedAssemblies.Add(asm.Location);
            }

            //Compile the source
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sourceCode);

            //Error handling
            if (results.Errors.Count > 0)
            {
               foreach (CompilerError CompErr in results.Errors)
               {
                  errors = errors +
                              "Line number " + CompErr.Line +
                              ", Error Number: " + CompErr.ErrorNumber +
                              ", '" + CompErr.ErrorText + ";" +
                              Environment.NewLine + Environment.NewLine;
               }
            }
            else
            {
               //Successful Compile

               //Create an instance
               object o = results.CompiledAssembly.CreateInstance(classToCreate);
               
               //Get the Method to call
               Type type = o.GetType();
               MethodInfo m = type.GetMethod(callFunction);

               //Redirect the console output
               System.IO.StringWriter sw = new System.IO.StringWriter();
               TextWriter consoleOld = Console.Out;
               Console.SetOut(sw);

               //invoke the method on the object
               m.Invoke(o, null);

               //Reset Console output
               Console.SetOut(consoleOld);

               //return the consoleOld output
               consoleOutput += sw.ToString();
            }
         }
         catch (Exception e)
         {
            Exception inner = e.InnerException;
            errors +=
               string.Format("{0}: {1}\r\n\r\nStack Trace:{2}\n",
               inner.GetType().ToString(), inner.Message, inner.StackTrace);
         }
      }
   }
}
