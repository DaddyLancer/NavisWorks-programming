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

using System.Windows.Forms;

namespace Viewer
{
   public partial class SelectionSetItemNameForm : Form
   {
      public SelectionSetItemNameForm(bool folder)
      {
         if (folder)
         {
            Text = "New  Folder";
         }
         else
         {
            Text = "New  Selection Set";
         }
         InitializeComponent();
      }

      public string ItemName
      {
         get
         {
            return itemName.Text;
         }
      }
   }
}
