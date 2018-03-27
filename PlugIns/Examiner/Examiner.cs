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
// This sample demonstrates basic LINQ style searching capabilities
// in the .NET API
//
//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

//Add two new namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

namespace Examiner
{
   [PluginAttribute("Examiner.Examiner",
                    "ADSK",
                    ToolTip = "Multi purpose plugin, demonstrates various aspects of plugins",
                    DisplayName = "Examiner")]

   public class Examiner : AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         //Ensure if the plugin is loaded through Automation that parameters have been passed.
         if (Autodesk.Navisworks.Api.Application.IsAutomated &&
            parameters.Length == 0)
         {
            throw new InvalidOperationException("Running through Automation requires parameters to be set");
         }

         //variables for examination
         string fileIn = string.Empty;
         string fileOut = string.Empty;
         bool itemsNamed = false;
         string searchItemName = string.Empty;
         bool propertyCategory = false;
         string searchPropertyCategory = string.Empty;
         bool hasGeometry = false;
         bool isHidden = false;
         bool isRequired = false;
         bool representsInsert = false;
         bool representsLayer = false;
         bool selectItems = false;
         Autodesk.Navisworks.Api.Color overrideColor = null;
         bool overrideTransparency = false;
         double overrideTransparencyValue = 0.0;
         SearchForm.ChangeDecision required = SearchForm.ChangeDecision.NoChange;
         SearchForm.ChangeDecision hidden = SearchForm.ChangeDecision.NoChange;
         string resultingNWD = string.Empty;

         if (parameters.Length == 0)
         {
            SearchForm searchForm = new SearchForm();
            if (searchForm.ShowDialog() != DialogResult.OK)
               return 0;

            //assign values
            fileOut = searchForm.ResultsFileOut;
            itemsNamed = searchForm.ItemsNamed;
            searchItemName = searchForm.SearchItemName;
            propertyCategory = searchForm.PropertyCategory;
            searchPropertyCategory = searchForm.SearchPropertyCategory;
            hasGeometry = searchForm.HasGeometry;
            isHidden = searchForm.IsHidden;
            isRequired = searchForm.IsRequired;
            representsInsert = searchForm.RepresentsInsert;
            representsLayer = searchForm.RepresentsLayer;
            selectItems = searchForm.SelectItems;

            //values to set
            if (searchForm.OverrideColor)
               overrideColor = searchForm.OverrideColorValue;
            overrideTransparency = searchForm.OverrideTransparency;
            overrideTransparencyValue = searchForm.OverrideTransparencyValue;
            required = searchForm.Required;
            hidden = searchForm.Hidden;
            resultingNWD = searchForm.ResultingNWD;
         }
         else
         {
            string[] separators = { ":" };
            foreach (string param in parameters)
            {
               string[] pairs = param.Split(separators, 2, StringSplitOptions.RemoveEmptyEntries);
               switch (pairs[0].ToLower())
               {
                  case "/resultsfile":
                     if (pairs.Length > 1)
                        fileOut = pairs[1];
                     break;
                  case "/itemsnamed":
                     itemsNamed = true;
                     if (pairs.Length > 1)
                        searchItemName = pairs[1];
                     break;
                  case "/propertycategory":
                     propertyCategory = true;
                     if (pairs.Length > 1)
                        searchPropertyCategory = pairs[1];
                     break;
                  case "/hasgeometry":
                     hasGeometry = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/ishidden":
                     isHidden = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/isrequired":
                     isRequired = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/representsinsert":
                     representsInsert = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/representslayer":
                     representsLayer = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/selectitems":
                     selectItems = (pairs.Length == 1 || IsTrue(pairs[1]));
                     break;
                  case "/filein":
                     if (pairs.Length > 1)
                        fileIn = pairs[1];
                     break;

                  //Values to assign
                  case "/savenwd":
                     if (pairs.Length > 1)
                        resultingNWD = pairs[1];
                     break;
                  case "/overridecolor":
                     if (pairs.Length > 1)
                     {
                        string[] rgb = pairs[1].Split(separators, 3, StringSplitOptions.RemoveEmptyEntries);
                        if (rgb.Length > 2)
                           overrideColor = new Color(Convert.ToDouble(rgb[0]), Convert.ToDouble(rgb[1]), Convert.ToDouble(rgb[2]));
                     }
                     break;
                  case "/overridetransparency":
                     overrideTransparency = true;
                     if (pairs.Length > 1)
                        overrideTransparencyValue = Convert.ToDouble(pairs[1]);
                     break;
                  case "/required":
                     if (pairs.Length == 1 || IsTrue(pairs[1]))
                        required = SearchForm.ChangeDecision.Yes;
                     else
                        required = SearchForm.ChangeDecision.No;
                     break;
                  case "/hidden":
                     if (pairs.Length == 1 || IsTrue(pairs[1]))
                        hidden = SearchForm.ChangeDecision.Yes;
                     else
                        hidden = SearchForm.ChangeDecision.No;
                     break;
                  default:
                     throw new InvalidOperationException("invalid parameter passed");
               }
            }
            //check there is a file for examination
            if (fileIn.Length < 3)
               throw new System.ArgumentException("No input file passed in parameter list");
            else
            {
               if (!Autodesk.Navisworks.Api.Application.MainDocument.TryOpenFile(fileIn))
                  return 0;
            }
         }

         //Do the search
         IEnumerable<ModelItem> items =
           Autodesk.Navisworks.Api.Application.ActiveDocument.Models.RootItemDescendantsAndSelf.
           Where(x =>
              //Search for ClassDisplayName matching the text, regardless of upper/lower case
              (!itemsNamed || x.ClassDisplayName.ToLower() == searchItemName.ToLower())
              &&
                 //Search where the Property categories for the modelitem have a specific display name
              (!propertyCategory || x.PropertyCategories.FindCategoryByDisplayName(searchPropertyCategory) != null)
              &&
                 //find the model items with the Geometry
              (!hasGeometry || x.HasGeometry)
              &&
                 //hidden model items
              (!isHidden || x.IsHidden)
              &&
                 //required by the model
              (!isRequired || x.IsRequired)
              &&
              (!representsInsert || x.IsInsert)
              &&
              (!representsLayer || x.IsLayer)
           );

         //Select the items if required
         if (selectItems)
         {
            //Select the items in the model that are contained in the collection
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.CopyFrom(items);
         }

         if (fileOut.Length > 3)
         {
            try
            {
               //Write out a list of the ModelItems
               using (TextWriter fileWriter =
                   new StreamWriter(fileOut))
               {
                  fileWriter.WriteLine(fileIn);
                  foreach (ModelItem item in items)
                  {
                     fileWriter.Write("DisplayName:'");
                     fileWriter.Write(item.DisplayName);
                     fileWriter.Write("', ClassName:'");
                     fileWriter.Write(item.ClassName);
                     fileWriter.Write("', ClassDisplayName:'");
                     fileWriter.Write(item.ClassDisplayName);
                     fileWriter.Write("', ToString:'");
                     fileWriter.Write(item.ToString());
                     fileWriter.WriteLine("'");
                  }
               }
            }
            catch (System.UnauthorizedAccessException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw new InvalidOperationException(e.Message, e);
               else
               {
                  MessageBox.Show(e.Message, "Access is denied");
               }
            }
            catch (System.ArgumentNullException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw e;
               else
               {
                  MessageBox.Show(e.Message, "path is null");
               }
            }
            catch (System.ArgumentException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw e;
               else
               {
                  MessageBox.Show(e.Message, "Invalid Argument");
               }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw new InvalidOperationException(e.Message, e);
               else
               {
               //     The specified path is invalid, such as being on an unmapped drive.
                  MessageBox.Show(e.Message, "Directory Not Found");
               }
            }
            catch (System.IO.PathTooLongException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw new InvalidOperationException(e.Message, e);
               else
               {
               //     The specified path, file name, or both exceed the system-defined maximum
               //     length. For example, on Windows-based platforms, paths must be less than
               //     248 characters, and file names must be less than 260 characters.
                  MessageBox.Show(e.Message, "Invalid Path");
               }
            }
            catch (System.IO.IOException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw new InvalidOperationException(e.Message, e);
               //     path includes an incorrect or invalid syntax for file name, directory name,
               //     or volume label syntax.
               else
               {
                  MessageBox.Show(e.Message, "Invalid Path");
               }
            }
            catch (System.Security.SecurityException e)
            {
               if (Autodesk.Navisworks.Api.Application.IsAutomated)
                  throw new InvalidOperationException(e.Message, e);
               else
               {
                  //     The caller does not have the required permission.
                  MessageBox.Show(e.Message, "Access is denied.");
               }
            }
         }

         //Override color
         if (overrideColor != null)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.Models.OverridePermanentColor(items, overrideColor);
         }
         //override transparency
         if (overrideTransparency)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.Models.OverridePermanentTransparency(items, overrideTransparencyValue);
         }

         //override required flag
         if (required != SearchForm.ChangeDecision.NoChange)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.Models.SetRequired(items, (required == SearchForm.ChangeDecision.Yes));
         }

         //override hidden flag
         if (hidden != SearchForm.ChangeDecision.NoChange)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.Models.SetHidden(items, (hidden == SearchForm.ChangeDecision.Yes));
         }

         //Save to file
         if (resultingNWD.Length > 3)
         {
            //save the file
            Autodesk.Navisworks.Api.Application.ActiveDocument.SaveFile(resultingNWD);
         }

         return 0;
      }

      /// <summary>
      /// returns whether a given string can be considered a value of true
      /// </summary>
      /// <param name="arg">the string to evaluate</param>
      /// <returns>boolean value equivelent of true or false</returns>
      private static bool IsTrue(string arg)
      {
         return "trueyes1".Contains(arg.ToLower());
      }
   }
}