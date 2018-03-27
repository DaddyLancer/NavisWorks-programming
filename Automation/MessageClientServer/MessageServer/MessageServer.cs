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
// Demonstrates one method in which, by way of .NET remoting, Navisworks
// can be started through Automation and data can be communicated back
// to the calling program.
//
//------------------------------------------------------------------
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Automation;

namespace MessageServer
{
   public partial class MessageServer : Form
   {
      //.NET Remoting channel
      TcpServerChannel chan = null;

      public MessageServer()
      {
         InitializeComponent();
      }

      private void startNavisworks_Click(object sender, EventArgs e)
      {
         //Start Navisworks up and dont wait for it
         System.Threading.Thread aThread = new System.Threading.Thread(
            new System.Threading.ThreadStart(StartNavisworksSeparate));

         //start the thread
         aThread.Start();

         //ensure that we can't start more than one Navisworks
         startNavisworks.Enabled = false;
      }

      /// <summary>
      /// This is only provided as a function to be used by a thread. 
      /// This is because NavisworksApplication() blocks the main thread until after
      /// the GuiCreated Event has been handled, GuiCreated in turn raises an event handled here by 
      /// MessageServerListener_MessageRaised. As the handling of this event is blocked by the constructor
      /// it stays in a deadlock. By starting Navisworks from a separate thread, we avoid the deadlock.
      /// </summary>
      private static void StartNavisworksSeparate()
      {
         //Create a Navisworks Automation object
         NavisworksApplication navApp = new NavisworksApplication();

         //Ensure that the Application stays alive after we dispose of its reference.
         navApp.StayOpen();

         //make Navisworks Visible
         navApp.Visible = true;

         //Dispose of our reference, Navisworks is now a completely separate process
         navApp.Dispose();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         //Create / Register a channel as a .NET remoting server
         chan = new TcpServerChannel(9932);
         ChannelServices.RegisterChannel(chan, false);

         //Set up the Service end using the MessageServerListener class
         RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(MessageServerListener)
            , "MessageServerListener"
            , WellKnownObjectMode.Singleton);

         //Attach to the listening event
         MessageServerListener.MessageRaised += MessageServerListener_MessageRaised;
         MessageServerListener.NavisworksClosed += MessageServerListener_NavisworksClosed;
      }

      void MessageServerListener_MessageRaised(object sender, MessageRaisedEventArgs e)
      {
         if (InvokeRequired)
         {
            //When this event is raised it is from the Navisworks process, so we need to invoke the 
            //event  on the Form's own thread.
            MessageServerListener.MessageRaisedEventHandler mrea
               = new MessageServerListener.MessageRaisedEventHandler(MessageServerListener_MessageRaised);
            Invoke(mrea, new object[] { sender, e });
         }
         else
         {
            //this is where the event is actually handled by the Form's own thread
            receivedOutput.Text += e.Message;
            receivedOutput.Text += "\r\n";
         }
      }

      void MessageServerListener_NavisworksClosed(object sender, EventArgs e)
      {
         if (InvokeRequired)
         {
            //When this event is raised it is from the Navisworks process, so we need to invoke the 
            //event  on the Form's own thread.
            EventHandler mrea
               = new EventHandler(MessageServerListener_NavisworksClosed);
            Invoke(mrea, new object[] { sender, e });
         }
         else
         {
            //ensure that we can re-start Navisworks
            startNavisworks.Enabled = true;
         }
      }
   }
}
