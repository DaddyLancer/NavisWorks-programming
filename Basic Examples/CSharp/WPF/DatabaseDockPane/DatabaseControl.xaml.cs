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
using System.Globalization;
using System.Windows.Controls;
using System.Windows;
using System.Data;




namespace DatabaseDockPane
{
   /// <summary>
   /// Interaction logic for UserControl1.xaml
   /// </summary>
   public partial class WPFHelloWorldControl : UserControl
   {
      public WPFHelloWorldControl()
      {         
         InitializeComponent();
         m_test_data = new TestData();
         DataContext = m_test_data;
      }

      public void OnEnableButtons(bool enable)
      {
         if (enable == m_loadedfile)
            return;

         m_insert.IsEnabled = enable;
         m_update.IsEnabled = enable;
         m_delete.IsEnabled = enable;
         m_loadedfile = enable;
         if (enable)
         {
            // Register events and rebuild table
            m_test_data.RegisterEvent();
            m_test_data.ReBuild();
         }
         else
         {
            // Unregister events and release table.
            m_test_data.UnRegisterEvent();
            if (m_test_data != null && m_test_data.MyTable != null)
            {
               m_test_data.MyTable.Clear();
            }
         }
      }


      private void Button_Click_Insert(object sender, RoutedEventArgs e)
      {
         DataRowView row = m_grid.SelectedItem as DataRowView;
         string temp = m_test_data.CurrentItemName();
         if (temp == null)
         {
            MessageBox.Show("Please select item in canvas");
            return;
         }
         string item_name = temp;

         // Following data use hard code, you can pop up dialog to get it or get from other place, like xml, text....
         int count = 1;
         double price = 3.55;

         // Insert a new row into database base on above data.
         m_test_data.InsertRow(item_name, count, price);
      }

      private void Button_Click_Delete(object sender, RoutedEventArgs e)
      {
         DataRowView row = m_grid.SelectedItem as DataRowView;
         if (row == null)
         {
            MessageBox.Show("Please select a record in left grid and update price, count");
            return;
         }

         // Delete the select row from database.
         int id = int.Parse(row.Row["ID"].ToString());
         m_test_data.DeleteRow(id);
      }

      private void Button_Click_Update(object sender, RoutedEventArgs e)
      {
         DataRowView row = m_grid.SelectedItem as DataRowView;
         if (row == null)
         {
            MessageBox.Show("Please select a record");
            return;
         }

         // Get the update data from tableview and use them to update database.
         int id = int.Parse(row.Row["ID"].ToString());
         double price = double.Parse(row.Row["price"].ToString());
         string value = String.Format("item_name='{0}', count={1}, price={2:F2}", row.Row["item_name"], row.Row["count"], price.ToString("F2", CultureInfo.InvariantCulture));
         m_test_data.UpdateRow(id, value);
      }

      private TestData m_test_data;
      private bool m_loadedfile = false;
   }
}
