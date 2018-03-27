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
using System.IO;

namespace Takeoff.XMLImportExport.ExportQuantity
{
   //AddIn plugin to show/hide the ImportCatalog Addin
   [Plugin("TakeoffExportQuantity",  // Plugin name
       "ADSK",                                                  // 4 character Developer ID or GUID
       DisplayName = "Quantification Export Quantities",                             // Display name for the Plugin in the Ribbon (non-localised if defined here)
       ToolTip = "Export Quantities to XML file.")]  //The tooltip for the item in the ribbon

   // LoadForCanExecute specifies if CanExecuteCommand should cause the Plugin to load
   // Plug-ins are loaded on demand, and will otherwise appear enabled until the user
   // clicks on them and causes them to load.
   [AddInPluginAttribute(AddInLocation.AddIn, LoadForCanExecute = true)]
   public class ExportQuantityPlugin : AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         //set path of quantity file to export
         string quantity_file = string.Empty;
         if (!PromptForSaveFilename(out quantity_file))
         {
            return 0;
         }

         try
         {
            TakeoffRootNode root = new QuantityDatabaseParser().ParseDatabase();
            IXMLFileExporter exporter = new QuantityXMLFileExporter();
            exporter.TakeoffNodeToXML(root, quantity_file);
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

      public bool PromptForSaveFilename(out String fileName)
      {
         //Dialog for selecting the location of the file to save
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.Title = m_caption;
         saveDlg.Filter = m_filter;
         saveDlg.FileName = m_default_name;
         saveDlg.DefaultExt = "xlsx";

         if (saveDlg.ShowDialog() == DialogResult.OK)
         {
            fileName = saveDlg.FileName;
            return true;
         }
         else
         {
            fileName = string.Empty;
            return false;
         }
      }

      private const string m_caption = "Export Quantity";
      private const string m_filter = "Quantification Quantities (*.xml)|*.xml";
      private const string m_default_name = "New Quantity Report";
   }
}
