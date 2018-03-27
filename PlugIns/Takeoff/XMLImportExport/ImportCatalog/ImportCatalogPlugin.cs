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
using System.Windows.Forms;

//Navisworks using declaration
using NWAPI = Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Data;
using Autodesk.Navisworks.Api.Interop;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Takeoff;

//Example using declaration
using Takeoff.XMLImportExport.Common;
using Takeoff.XMLImportExport.Node;
using Takeoff.XMLImportExport.Utility;

namespace Takeoff.XMLImportExport.ImportCatalog
{
   //AddIn plugin to show/hide the ImportCatalog Addin
   [Plugin("TakeoffImportCatalog",  // Plugin name
       "ADSK",                                                  // 4 character Developer ID or GUID
       DisplayName = "Quantification Import Catalog",                             // Display name for the Plugin in the Ribbon (non-localised if defined here)
       ToolTip = "Import a specified catalog which will be used by Quantification.")]  //The tooltip for the item in the ribbon

   // LoadForCanExecute specifies if CanExecuteCommand should cause the Plugin to load
   // Plug-ins are loaded on demand, and will otherwise appear enabled until the user
   // clicks on them and causes them to load.
   [AddInPluginAttribute(AddInLocation.AddIn, LoadForCanExecute = true)]
   public class ImportCatalogPlugin : AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         //get catalog file path
         string catalog_file = string.Empty;
         if (!PromptForOpenFilename(out catalog_file))
         {
            return 0;
         }

         try
         {
            bool valid = false;
            TakeoffRootNode root = null;
            IDatabaseImporter importer = new CatalogDatabaseImporter();
            root = new CatalogXMLFileParser(catalog_file).ParseCatalog();
            valid = importer.ContainsValidImport(root);
            if (valid)
            {
               bool canceled = false;
               NWAPI.Transaction nwtrans = null;
               try
               {
                  using (nwtrans = NWAPI.Application.MainDocument.BeginTransaction("Import Catalog"))
                  {
                     using (NavisworksTransaction trans = NWAPI.Application.MainDocument.Database.BeginTransaction(DatabaseChangedAction.Edited))
                     {
                        try
                        {
                           importer.Import(root);
                        }
                        catch (CatalogConflictCancelException)
                        {
                           canceled = true;
                        }

                        if (canceled)
                        {
                           trans.Rollback();
                           Autodesk.Navisworks.Internal.ApiImplementation.TakeoffImpl.RollbackDocument(NWAPI.Application.MainDocument);
                        }
                        else
                        {
                           trans.Commit();
                        }
                     }
                  }
               }
               catch (DatabaseException ex)
               {
                  Autodesk.Navisworks.Internal.ApiImplementation.TakeoffImpl.RollbackDocument(NWAPI.Application.MainDocument);

                  String error = string.Format("Product Quantification module meet an error ({0})", ex.Message);
                  MessageBox.Show(error, m_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
         catch (CatalogItemContainsIllegalVariableException)
         {
            String error = Autodesk.Navisworks.Api.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Variable_Not_Legal");
            MessageBox.Show(error, m_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (CatalogFormatCorruptException ex)
         {
            MessageBox.Show(ex.Message, m_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (CatalogConflictCancelException)
         {
            //being canceled
         }
         catch (CatalogException)
         {
            String error = Autodesk.Navisworks.Api.Application.Resources.TryGetString("TakeoffPlugin_Catalog_Format_Corrupt");
            MessageBox.Show(error, m_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, m_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         return 0;
      }

      public override CommandState CanExecute()
      {
         CommandState s = new CommandState();
         s.IsChecked = false;
         s.IsVisible = true;
         s.IsEnabled = false;

         if (NWAPI.Application.MainDocument != null && NWAPI.Application.MainDocument.GetTakeoff().GetHasSetUp())
         {
            s.IsEnabled = true;
         }

         return s;
      }

      public bool PromptForOpenFilename(out String fileName)
      {
         //Dialog for selecting the Location of the file to open
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Title = m_caption;
         dlg.Filter = m_filter;

         //Ask user for file location
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            fileName = dlg.FileName;
            return true;
         }
         else
         {
            fileName = string.Empty;
            return false;
         }
      }

      private const string m_caption = "Import Catalog";
      private const string m_filter = "Quantification Catalogs (*.xml)|*.xml";
   }
}
