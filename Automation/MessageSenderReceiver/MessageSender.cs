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
// Note: this sample requires the MessageReceiver plug-in to be built first
//
//------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace CallPlugin
{
    public partial class MessageSender : Form
    {
        /// <summary>
        /// The NavisWorks Application
        /// </summary>
        Autodesk.Navisworks.Api.Automation.NavisworksApplication navisworksApplication;

        /// <summary>
        /// The ID Prefix, or developer friendly name for the plugin we want to call
        /// </summary>
        const string pluginIDPrefix = "MessageSenderReceiver.MessageReceiver";

        /// <summary>
        /// The unique GUID for the plugin
        /// </summary>
        const string pluginGUID = "ADSK";

        public MessageSender()
        {
            InitializeComponent();
        }

        private void sendToPlugin_Click(object sender, EventArgs e)
        {
            // Execute command on our message receiver
            int retval = navisworksApplication.ExecuteAddInPlugin(pluginIDPrefix + "." + pluginGUID, messageText.Text);
            
            //Show the result received from the plugin
            MessageBox.Show(String.Format("Plugin returned {0}", retval));
        }

        private void startNavisworks_Click(object sender, EventArgs e)
        {
            if (navisworksApplication == null)
            {
                // Start Navisworks
                navisworksApplication = new Autodesk.Navisworks.Api.Automation.NavisworksApplication();

                //Make it visible
                navisworksApplication.Visible = true;

                //Enable/Disable the other controls
                messageText.Enabled = true;
                sendToPlugin.Enabled = true;
                closeNavisworks.Enabled = true;
                startNavisworks.Enabled = false;
            }
        }

        private void closeNavisworks_Click(object sender, EventArgs e)
        {
            if (navisworksApplication != null)
            {
                //dispose of the application and close it down
                navisworksApplication.Dispose();
                navisworksApplication = null;

                //Enable/Disable the other controls
                messageText.Enabled = false;
                sendToPlugin.Enabled = false;
                closeNavisworks.Enabled = false;
                startNavisworks.Enabled = true;
            }

        }
    }
}
