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
// This sample illustrates a basic Hello world message displayed in
// a dockable pane.
//
//------------------------------------------------------------------
using System.Windows.Forms;

namespace BasicDockPanePlugin
{
   public partial class HelloWorldControl : UserControl
   {
      public override string Text {
         get
         {
            return helloWorldText.Text;
         }
         set
         {
            helloWorldText.Text = value;
         }
      }
      public HelloWorldControl()
      {
         InitializeComponent();
         if (Text != null && Text != string.Empty)
         {
            helloWorldText.Text = Text;
         }
      }
   }
}
