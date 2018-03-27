//------------------------------------------------------------------
// NavisWorks Sample code
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
//
// This sample demonstrates how to use the Automation and plugin parts
// of the API to send and receieve information from a stand alone
// application and a Navisworks Plugin
//
//------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace MessageSenderReceiver
{
    public partial class MessageReceived : Form
    {
        public MessageReceived()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Message to display on screen
        /// </summary>
        public string Message
        {
            set
            {
                messageContent.Text = value;
            }
        }

        /// <summary>
        /// The value to return to the sender of the message
        /// </summary>
        public int ReturnValue
        {
            get
            {
                return Convert.ToInt32(returnValue.Value);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
