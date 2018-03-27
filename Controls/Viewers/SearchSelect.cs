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
// This sample demonstrates how to build an SDI/MDI Viewer for Navisworks files using
// the Controls part of the API.
//
//------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;

namespace Viewer
{
   public partial class SearchSelect : Form
   {
      public SearchSelect()
      {
         InitializeComponent();

         //Fill the PropertyCategoryNames into propertyCategoryNames
         FillComboFromTypeProperties(typeof(PropertyCategoryNames), propertyCategoryNames, categoryName);
         //Fill the DataPropertyNames into dataPropertyNames
         FillComboFromTypeProperties(typeof(DataPropertyNames), dataPropertyNames, propertyName);
         //defaults
         searchCondition.SelectedIndex = 0;
         negate.SelectedIndex = 0;
         propertyCategoryNames.SelectedIndex = 0;
         categoryName.SelectedIndex = 0;
         dataPropertyNames.SelectedIndex = 0;
         propertyName.SelectedIndex = 0;
      }


      private void SearchSelect_Load(object sender, EventArgs e)
      {
         EnableControls();
      }

      private void SearchSelect_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            e.Cancel = true;
            Hide();
         }
      }

      static int MemberCompare(System.Reflection.MemberInfo item1, System.Reflection.MemberInfo item2)
      {
         return item1.Name.CompareTo(item2.Name);
      }

      private static void FillComboFromTypeProperties(Type currentType, ComboBox nameCombo, ComboBox displayNameCombo)
      {
         //Properties
         System.Reflection.PropertyInfo[] propertyInfo = currentType.GetProperties(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
         // sort by name
         Array.Sort(propertyInfo, MemberCompare);

         //add the properties of the class
         foreach (System.Reflection.PropertyInfo info in propertyInfo)
         {
            try
            {
               if (info.CanRead)
               {
                  object[] attributes = info.GetCustomAttributes(typeof(System.ComponentModel.EditorBrowsableAttribute), true);
                  if (attributes == null || attributes.Length == 0)
                  {
                     displayNameCombo.Items.Add(info.Name);
                     nameCombo.Items.Add(info.GetValue(null, null).ToString());
                  }
               }
            }
            catch (Exception)
            { }
         }
      }

      private void searchCondition_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableControls();
      }

      private void EnableControls()
      {
         //ensure rellevent fields are enabled
         propertyCategoryNames.Visible = (searchCondition.Text.Contains("ByName"));
         dataPropertyNames.Visible = (searchCondition.Text.Contains("ByName"));
         categoryName.Visible = !propertyCategoryNames.Visible;
         propertyName.Visible = !propertyCategoryNames.Visible;
         ignoreCase.Enabled = (searchCondition.Text.Contains("HasProperty"));
         dataPropertyNames.Enabled = (searchCondition.Text.Contains("HasProperty"));
         propertyName.Enabled = (searchCondition.Text.Contains("HasProperty"));
         propertyValue.Enabled = (searchCondition.Text.Contains("HasProperty"));
      }

      private void add_Click(object sender, EventArgs e)
      {
         //check validity of the dialog content
         if (searchCondition.Text == string.Empty ||
            (propertyCategoryNames.Visible && propertyCategoryNames.Text == string.Empty) ||
            (categoryName.Visible && categoryName.Text == string.Empty) ||
            negate.Text == string.Empty ||
            (propertyCategoryNames.Visible && propertyCategoryNames.Enabled && propertyCategoryNames.Text == string.Empty) ||
            (propertyName.Visible && propertyName.Enabled && propertyName.Text == string.Empty) ||
            (propertyValue.Enabled && propertyValue.Text == string.Empty) ||
            searchGroup.Text == string.Empty)
         {
            return;
         }

         ListViewGroup newGroup = null;
         foreach (ListViewGroup lvg in searchList.Groups)
         {
            if (lvg.Name == searchGroup.Text)
            {
               newGroup = lvg;
               break;
            }
         }

         //Add group if necessary
         if (newGroup == null)
         {
            newGroup = new ListViewGroup(searchGroup.Text, searchGroup.Text);
            searchList.Groups.Add(newGroup);
            searchGroup.Items.Add(searchGroup.Text);
         }

         ListViewItem li = searchList.Items.Add(searchCondition.Text);
         li.Group = newGroup;
         if (categoryName.Visible)
            li.SubItems.Add(categoryName.Text);
         else
            li.SubItems.Add(propertyCategoryNames.Text);

         if (propertyName.Enabled && propertyName.Visible)
            li.SubItems.Add(propertyName.Text);
         else if (dataPropertyNames.Enabled && dataPropertyNames.Visible)
            li.SubItems.Add(dataPropertyNames.Text);
         else 
            li.SubItems.Add(string.Empty);

         if(propertyValue.Enabled)
            li.SubItems.Add(propertyValue.Text);
         else
            li.SubItems.Add(string.Empty);

         li.SubItems.Add(ignoreCase.Text);
         li.SubItems.Add(negate.Text);
      }

      private void remove_Click(object sender, EventArgs e)
      {
         while (searchList.SelectedItems.Count > 0)
         {
            searchList.Items.Remove(searchList.SelectedItems[0]);
         }
      }

      private void search_Click(object sender, EventArgs e)
      {
         //Create a new search
         Search search = new Search();

         foreach (ListViewGroup lvg in searchList.Groups)
         {
            Boolean firstInGroup = true;
            foreach (ListViewItem li in lvg.Items)
            {
               SearchCondition searchCondition;
               switch (li.Text)
               {
                  case "HasCategoryByDisplayName":
                     searchCondition = SearchCondition.HasCategoryByDisplayName(li.SubItems[1].Text);
                     break;
                  case "HasCategoryByName":
                     searchCondition = SearchCondition.HasCategoryByName(li.SubItems[1].Text);
                     break;
                  case "HasPropertyByDisplayName":
                     searchCondition = SearchCondition.HasPropertyByDisplayName(li.SubItems[1].Text, li.SubItems[2].Text);
                     break;
                  case "HasPropertyByName":
                     searchCondition = SearchCondition.HasPropertyByName(li.SubItems[1].Text, li.SubItems[2].Text);
                     break;
                  default:
                     continue;
               }
               //First in each group needs to identify it is a group
               if (firstInGroup)
               {
                  searchCondition = searchCondition.StartGroup();
                  firstInGroup = false;
               }

               //search for propert value only if 
               if (li.SubItems[3].Text != string.Empty)
               {
                  searchCondition = searchCondition.EqualValue(VariantData.FromDisplayString(li.SubItems[3].Text));
               }

               //ignore Case
               if (li.SubItems[4].Text != string.Empty && Convert.ToBoolean(li.SubItems[4].Text) == true)
               {
                  searchCondition = searchCondition.IgnoreStringValueCase();
               }

               //Negate the search condition
               if (Convert.ToBoolean(li.SubItems[5].Text) == true)
               {
                  //if 'not equal to' then negate
                  searchCondition = searchCondition.Negate();
               }

               //add the final search
               search.SearchConditions.Add(searchCondition);
            }
         }

         //set the selection to everything
         search.Selection.SelectAll();
         search.Locations = SearchLocations.DescendantsAndSelf;

         //get the resulting collection by applying the search
         if (Autodesk.Navisworks.Api.Application.ActiveDocument != null)
         {
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.CopyFrom(
            search.FindAll(Autodesk.Navisworks.Api.Application.ActiveDocument, false));
         }
      }
   }
}
