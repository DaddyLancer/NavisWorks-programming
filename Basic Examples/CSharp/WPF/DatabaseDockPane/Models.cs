//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2011 by Autodesk Inc.

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
// This sample illustrates a basic database operation and displayed in
// a dockable pane.
//
//------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Data;

namespace DatabaseDockPane
{
   public class TestData:INotifyPropertyChanged
   {
      public TestData()
      {

      }

      public void RegisterEvent()
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;
         database.Changed += OnDatabaseChanged;
      }

      public void UnRegisterEvent()
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;
         database.Changed -= OnDatabaseChanged;
      }

      public void ReBuild()
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;

         // If opened file doesn't contain the table, then we create the table. Create table or change table structure, please use Reset to notify UI to
         // rebuild.
         using (NavisworksTransaction trans = database.BeginTransaction(DatabaseChangedAction.Reset))
         {
            NavisworksCommand cmd = trans.Connection.CreateCommand();

            string sql = "CREATE TABLE IF NOT EXISTS order_test(item_name TEXT, count INTEGER DEFAULT 1, price CURRENCY DEFAULT 100.55)";
            cmd.CommandText = sql;
            int affected = cmd.ExecuteNonQuery();
            trans.Commit();
         }

         // If need to support Changed event for the table, you must call the EnableTableUndoable.
         database.EnableTableUndoable("order_test");
      }

      void OnDatabaseChanged(object sender, DatabaseChangedEventArgs args)
      {
         switch (args.Action)
         {
            case DatabaseChangedAction.Reset:
               FillTable();
               break;
            case DatabaseChangedAction.Edited:

               // you can use foreach(DatabaseChange change in args.Changes.Where(tablename, changetype)) filter what you are interested changes.
               foreach (DatabaseChange change in args.Changes )
               {
                  HandleDatabaseChange(change);
               }
               break;
         }
      }

      void HandleDatabaseChange(DatabaseChange change)
      {
         switch (change.ChangedType)
         {
            case DatabaseChangeTypes.Insert:
               {
                  string sql = string.Format("select ROWID as ID, item_name, count, price,  price*count as Totalcost from order_test WHERE ROWID = {0}", change.RowId);
                  NavisworksDataAdapter adapter = new NavisworksDataAdapter(sql, Autodesk.Navisworks.Api.Application.ActiveDocument.Database.Value);
                  DataTable temp = new DataTable();
                  adapter.Fill(MyTable);

                  DataRow row = MyTable.Rows.Find(change.RowId);
                  row.AcceptChanges();
                  break;
               }
            case DatabaseChangeTypes.Delete:
               {
                  DataRow row = MyTable.Rows.Find(change.RowId);
                  if (row != null)
                  {
                     row.Delete();
                     row.AcceptChanges();
                  }
                  break;
               }
            case DatabaseChangeTypes.Update:
               {
                  string sql = string.Format("select ROWID as ID, item_name, count, price,  price*count as Totalcost from order_test WHERE ROWID = {0}", change.RowId);
                  NavisworksDataAdapter adapter = new NavisworksDataAdapter(sql, Autodesk.Navisworks.Api.Application.ActiveDocument.Database.Value);
                  DataTable temp = new DataTable();
                  adapter.Fill(MyTable);

                  DataRow row = MyTable.Rows.Find(change.RowId);
                  row.AcceptChanges();
                  break;
               }
         }
      }
      public object Focused { get; set; }

      public void FillTable()
      {
         NavisworksDataAdapter adapter = new NavisworksDataAdapter("select ROWID as ID, item_name, count, price,  price*count as Totalcost from order_test", Autodesk.Navisworks.Api.Application.ActiveDocument.Database.Value);
         DataTable temp = new DataTable();
         adapter.Fill(temp);
         temp.PrimaryKey = new DataColumn[] { temp.Columns["ID"] };
         MyTable = temp;
         PropertyChanged(this, new PropertyChangedEventArgs("MyTable"));
      }

      public void DeleteRow(int i)
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;
         using (NavisworksTransaction trans = database.BeginTransaction(DatabaseChangedAction.Edited))
         {
            NavisworksCommand cmd = trans.Connection.CreateCommand();

            string sql = string.Format("DELETE FROM order_test WHERE ROWID=={0}", i);
            cmd.CommandText = sql;
            int affected = cmd.ExecuteNonQuery();
            trans.Commit();
         }
      }

      public void InsertRow(string item_name, int count, double price)
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;
         using (NavisworksTransaction trans = database.BeginTransaction(DatabaseChangedAction.Edited))
         {
            NavisworksCommand cmd = trans.Connection.CreateCommand();

            cmd.Parameters.AddWithValue("@p1", item_name);

            NavisworksParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@p2";
            p2.Value = count;

            NavisworksParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@p3";
            p3.Value = price;

            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            string insert_sql = "INSERT INTO order_test(item_name, count, price) VALUES(@p1, @p2, @p3);";
            cmd.CommandText = insert_sql;
            int affected = cmd.ExecuteNonQuery();
            trans.Commit();
         }
      }

      public void UpdateRow(int i, string value)
      {
         DocumentDatabase database = Autodesk.Navisworks.Api.Application.ActiveDocument.Database;
         using (NavisworksTransaction trans = database.BeginTransaction(DatabaseChangedAction.Edited))
         {
            NavisworksCommand cmd = trans.Connection.CreateCommand();

            string sql = string.Format("UPDATE order_test SET {0} WHERE ROWID=={1}", value, i);
            cmd.CommandText = sql;
            int affected = cmd.ExecuteNonQuery();
            trans.Commit();
         }
      }

      public DataTable MyTable
      {
         get;
         set;
      }

      public string CurrentItemName()
      {
         DocumentCurrentSelection s = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection;
         if (s.SelectedItems.Count > 0)
         {
            return s.SelectedItems[0].DisplayName;
         }
         else
         {
            return null;
         }
      }
      public event PropertyChangedEventHandler PropertyChanged;
   }
}
