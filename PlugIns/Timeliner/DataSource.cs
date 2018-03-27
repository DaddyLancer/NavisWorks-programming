//------------------------------------------------------------------
// Navisworks Sample code
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

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Globalization;
using Microsoft.Win32;


using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Timeliner;


// Creates a new Timeliner Datasource which reads a csv style file and creates/imports Timeliner Tasks from that data.
// This sample demonstrates:
//    * Custom Datasource class layout and attributes.
//    * Task & hierarchy creation.
//    * Datasource Field mapping (User driven and automatic).


namespace Autodesk.Navisworks.Timeliner
{

   [PluginAttribute("TimelinerDataSource_SampleDatasource_NET.DumpTimelinerTasks",  // Plugin name
                    "ADSK",                                                         // Developer ID or GUID
                    DisplayName = "Sample Datasource")]                             // Display name for the Plugin in the Ribbon
   [AddInPlugin(AddInLocation.None)]                                                // Plugin icon location 
   [Interface("TimelinerDataSourceProvider", "Navisworks", DisplayName = "Sample Datasource")]   
   public sealed class SampleDataSource : TimelinerDataSourceProvider
   {
      public SampleDataSource()
      {
      }


      public override TimelinerDataSource CreateDataSource(string displayName)
      {
         // Create Data Source with a unique name.
         // If the name isn't set, The plugin framework will provide default name: 
         // "New Data Source", "New Data Source 1" etc.
         TimelinerDataSource dataSource = new TimelinerDataSource(displayName);
         
         // Prompt to select a CSV file
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Title = "Select File";
         dlg.Filter = "csv files (*.csv)|*.csv";
         dlg.CheckFileExists = true;
         dlg.Multiselect = false;
         bool? result = dlg.ShowDialog();
         if (result.HasValue && result == true)
         {
            dataSource.ProjectIdentifier = dlg.FileName;
         }

         // Build the list of external fields we will allow the user to map to Timeliner Task data
         BuildAvailableFields(dataSource);

         // DataSourceProviderId should be set to Plugin.Id which should (a property of TimelinerDataSourceProvider)
         // If not set then the framework cannot find the plugin it should use for Synchronize & Rebuild. 
         dataSource.DataSourceProviderId = base.Id;
         // Version, whatever you like
         dataSource.DataSourceProviderVersion = 1.0;
         // Some user friendly name, ideally matching the name of the plugin itself  
         dataSource.DataSourceProviderName = "SampleDataSource";

         return dataSource;
      }


      // Called when the user clicks edit in the datasource tab. In here we check that the previously selected datasource file still exists, if not 
      // we allow the user to select a new target file. Any existing field mappings will be maintained after clicking edit..
      public override void UpdateDataSource(TimelinerDataSource dataSource)
      {
         FileReferenceResolver resolver = new FileReferenceResolver();
         FileReferenceResolveResult result = resolver.Resolve(dataSource.ProjectIdentifier);
         if (result.Response == FileResolutionResponse.OK)
         {
            dataSource.ProjectIdentifier = result.FileNameToOpen;
         }


         // Upgraded 2011 Navisworks Projects do not have available fields built, ensure we have a list of fields.
         if (dataSource.AvailableFields.Count == 0)
         {
            BuildAvailableFields(dataSource);
         }
      }


      private void BuildAvailableFields(TimelinerDataSource dataSource)
      {
         // Populate the AvailableFields with the fields you wish users to be able to map. 
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("UniqueId", "Unique Id"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("Name", "Name"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("ActualStartDate", "Actual Start Date"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("ActualEndDate", "Actual End Date"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("PlannedStartDate", "Planned Start Date"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("PlannedEndDate", "Planned End Date"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("MaterialCost", "Material Cost"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("LaborCost", "Labor Cost"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("EquipmentCost", "Equipment Cost"));
         dataSource.AvailableFields.Add(new TimelinerDataSourceField("SubcontractorCost", "Subcontractor Cost"));
      }


      // This function is called when the user selects Rebuild or Synchronize on the data source and is responsible for creating Timeliner tasks 
      // from the selected external data. In this example a csv file is opened and a single Timeliner task is created from each record 
      // contained within the file. The Task hierarchy is the returned via TimelinerImportTasksResult.
      protected override TimelinerImportTasksResult ImportTasksCore(TimelinerDataSource dataSource)
      {        
         TimelinerImportTasksResult importResult = new TimelinerImportTasksResult();

         // TaskTypeWasSet will initially be null. It must be set to true if Task.SimulationTaskTypeName is set on any Task, otherwise it remains false.
         importResult.TaskTypeWasSet = false;

         TimelinerTask rootTask = new TimelinerTask();

         // Set the ExternalId on the root task
         rootTask.SynchronizationId = TimelinerTask.DataSourceRootTaskIdentifier;

         // Read the source data. In this sample. ProjectIdentifier is the CSV file 
         StreamReader fileStream = new StreamReader(dataSource.ProjectIdentifier);

         // The numeric and datetime values string representation depends on the locale, here we use US.
         CultureInfo cultureInfo = new CultureInfo("en-US");

         // Store the field names
         string strLine = fileStream.ReadLine();
         string[] fieldNames = strLine.Split(',');

         while (!fileStream.EndOfStream)
         {
            // Read a row & split on the comma character.
            strLine = fileStream.ReadLine();
            string[] fields = strLine.Split(',');

            // Create sub task.
            TimelinerTask task = new TimelinerTask();

            // Some of the Timeliner Task fields below are populated directly from the external csv data, for example SynchronizationId is hardcoded to be 
            // mapped to the first field in a csv row. However there are some fields which the user can select how the csv data will map to Timeliner Task data. 
            // When the user is presented with the Field Mapping dialog they can select which csv fields map to which Timeliner Task fields. 
            // If the user has set any of these mappings we map the data accordingly.

            // SynchronizationId
            task.SynchronizationId = fields[0];

            // Task name
            task.DisplayName = fields[1];

            String strField;

            // IsActualEnabled
            task.IsActualEnabled = fields[2] == "1" ? true : false;
            // ActualStartDate
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskActualStartField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.ActualStartDate = DateTime.Parse(strField, cultureInfo);
            }
            // ActualEndDate
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskActualEndField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.ActualEndDate = DateTime.Parse(strField, cultureInfo);
            }

            // IsPlannedEnabled
            task.IsPlannedEnabled = fields[5] == "1" ? true : false;
            // PlannedStartDate
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskPlannedStartField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.PlannedStartDate = DateTime.Parse(strField, cultureInfo);
            }
            // PlannedEndDate
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskPlannedEndField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.PlannedEndDate = DateTime.Parse(strField, cultureInfo);
            }

            // SimulationTaskTypeName
            task.SimulationTaskTypeName = fields[8];
            if (String.IsNullOrEmpty(task.SimulationTaskTypeName) == false)
            {
               // Update the import result if SimulationTaskTypeName is set
               importResult.TaskTypeWasSet = true;
            }

            // Material cost
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskMaterialCostField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.MaterialCost = Double.Parse(strField, cultureInfo);
            }
            // Labor cost
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskLaborCostField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.LaborCost = Double.Parse(strField, cultureInfo);
            }
            // Equip Cost
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskEquipmentCostField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.EquipmentCost = Double.Parse(strField, cultureInfo);
            }
            // SubContact cost
            strField = StringValueOfCsvField(fieldNames, fields, dataSource.TaskSubcontractorCostField);
            if (!String.IsNullOrEmpty(strField))
            {
               task.SubcontractorCost = Double.Parse(strField, cultureInfo);
            }

            // Every task has a Children member which can be populated to create hierarchy. In this example every task we 
            // import is a child of the root task.
            rootTask.Children.Add(task);
         }

         // Close the file stream.
         fileStream.Close();

         importResult.RootTask = rootTask;

         // Return the TimelinerImportTasksResult.
         return importResult;
      }


      public string StringValueOfCsvField(String[] fieldNames, String[] row, TimelinerDataSourceField field)
      {
         // We rely on the field names contained on the first line of our sample csv file matching the field id's that 
         // we made available for mapping in BuildAvailableFields.
         int index = Array.IndexOf(fieldNames, field.Id);
         if (index == -1)
         {
            return null;
         }
         return row[index];
      }


      public override TimelinerValidateSettingsResult ValidateSettings(TimelinerDataSource dataSource)
      {
         // You do not need to implement this.
         return new TimelinerValidateSettingsResult(true);
      }


      protected override void DisposeManagedResources()
      {
      }


      protected override void DisposeUnmanagedResources()
      {
      }


      public override bool IsAvailable
      {
         get
         {
            // If the datasource cannot be queried at all, return false here.
            return true;
         }
      }
   }
}
