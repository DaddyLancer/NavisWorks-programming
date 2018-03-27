//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2012 by Autodesk Inc.

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

using System;
using System.Windows.Forms;

namespace ClashDetective
{
   public partial class NewTestName : Form
   {
      public string TestName { get; set; }
      
      public NewTestName(string TestName)
         : this()
      {
         this.TestName = TestName;
         tbTestName.Text = TestName;
      }

      public NewTestName()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (tbTestName.Text == string.Empty)
            MessageBox.Show("Please enter a value", "Empty value");
         else
         {
            TestName = tbTestName.Text;
            Close();
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         TestName = null;
         Close();
      }
   }
}
