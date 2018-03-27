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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CodeRunPlugin;

namespace CodeRun.Control
{
   public partial class CodeRunControl : UserControl
   {
      public CodeRunControl()
      {
         InitializeComponent();
      }

      private void run_Click(object sender, EventArgs e)
      {
         if (codeCompiler.SelectedItem != null)
         {
            output.Text = "";
            string errors = string.Empty;
            string consoleOutput = string.Empty;

            Generate(((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem), mainCodeBody.Text, fullClassName.Text,
               mainFunction.Text, out errors, out consoleOutput);

            if (errors != string.Empty)
            {
               output.ForeColor = Color.Red;
               output.Text = errors;
            }
            else
            {
               output.ForeColor = Color.Blue;
               output.Text = consoleOutput;
            }
         }
      }

      private void CodeRunForm_Load(object sender, EventArgs e)
      {
         string compilerFolder = (typeof(CodeRunPlugin.CodeRun).Assembly.Location);
         int folderPos = compilerFolder.LastIndexOf("\\");
         if (folderPos > -1)
            compilerFolder = compilerFolder.Substring(0, folderPos);
         else
            compilerFolder = string.Empty;

         try
         {
            string[] compilers = Directory.GetFiles(compilerFolder + "\\Compilers", "*.dll");
            foreach (string compiler in compilers)
            {
               try
               {
                  Assembly assembly = Assembly.LoadFrom(compiler);

                  // Walk through each type in the assembly looking for classes derived from CodeRun
                  foreach (Type type in assembly.GetTypes())
                  {
                     if (type.IsClass == true && !type.IsAbstract)
                     {
                        object classObj = Activator.CreateInstance(type);

                        if (classObj is CodeRunPlugin.CodeRun)
                        {
                           codeCompiler.Items.Add(classObj);
                        }
                     }
                  }
               }
               catch (Exception ex)
               {
                  output.Text = string.Format("{0}: {1}\r\n\r\nStack Trace:{2}\n",
                     ex.GetType().ToString(), ex.Message, ex.StackTrace);
               }
            }
         }
         catch (DirectoryNotFoundException)
         {
            //ok as nothing to load
         }
      }

      private void openFileMenuItem_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDlg = new OpenFileDialog();
         StringBuilder filter = GetFileOpenSaveFilter();
         openDlg.Filter = filter.ToString();

         if (openDlg.ShowDialog(Autodesk.Navisworks.Api.Application.Gui.MainWindow) == DialogResult.OK)
         {
            using (StreamReader reader = new StreamReader(openDlg.FileName))
            {
               if (reader != null)
               {
                  mainCodeBody.Text = reader.ReadToEnd();
               }
            }
         }
      }

      private void saveCodeMenuItem_Click(object sender, EventArgs e)
      {
         SaveFileDialog openDlg = new SaveFileDialog();
         StringBuilder filter = GetFileOpenSaveFilter();
         openDlg.Filter = filter.ToString();
         if (openDlg.ShowDialog(Autodesk.Navisworks.Api.Application.Gui.MainWindow) == DialogResult.OK)
         {
            using (StreamWriter writer = new StreamWriter(openDlg.FileName))
            {
               if (writer != null)
               {
                  writer.Write(mainCodeBody.Text);
                  writer.Flush();
               }
            }
         }
      }

      private void setDefaultTemplate_Click(object sender, EventArgs e)
      {
         if (codeCompiler.SelectedItem != null)
         {
            mainCodeBody.Text = ((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem).StartCode;
         }
      }

      /// <summary>
      /// Applies the code and produces an output
      /// </summary>
      /// <param name="codeRunner">the class that will return the output</param>
      /// <param name="code">the sourcecode</param>
      /// <param name="fullClassName">the full qualified class to use for the test (should be contained in the value of the code paramater )</param>
      /// <param name="mainFunction">the funcion in the class to call</param>
      /// <param name="errors">any errors that occurred during compilation or run</param>
      /// <param name="consoleOutput">any console output as a reult of running the code.</param>
      private static void Generate(CodeRunPlugin.CodeRun codeRunner, string code, string fullClassName, string mainFunction, out string errors, out string consoleOutput)
      {
         errors = string.Empty;
         consoleOutput = string.Empty;
         try
         {
            if (codeRunner != null)
            {
               codeRunner.Generate(code, fullClassName, mainFunction, out errors, out consoleOutput);
            }
         }
         catch (Exception e)
         {
            errors +=
               string.Format("{0}: {1}\r\n\r\nStack Trace:{2}\n",
               e.GetType().ToString(), e.Message, e.StackTrace);
         }
      }

      /// <summary>
      /// Returns a StringBuilder with the file extension for opening/saving with 
      /// the selected instance of the CodeRun derived class.
      /// </summary>
      /// <returns></returns>
      private StringBuilder GetFileOpenSaveFilter()
      {
         StringBuilder filter = new StringBuilder(100);
         if (codeCompiler.SelectedItem != null)
         {
            filter.Append(((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem).Language.Replace("|", "") + "|");
            foreach (string fileExt in ((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem).FileExtensions)
            {
               filter.Append(fileExt);
               filter.Append("|");
            }
         }
         filter.Append("All Files|*.*");
         return filter;
      }

      private void codeCompiler_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (codeCompiler.SelectedItem != null)
         {
            mainFunction.Enabled = !(((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem).IsScriptingLanguage);
            fullClassName.Enabled = !(((CodeRunPlugin.CodeRun)codeCompiler.SelectedItem).IsScriptingLanguage);
         }
      }
   }
}
