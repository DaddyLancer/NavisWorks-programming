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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using MessageClientServerInterface;
using System.Net.Sockets;

namespace MessageClientPlugin
{
   /// <summary>
   /// This class handles the messages being sent through .NET remoting to the server program.
   /// </summary>
   static class MessageHandler
   {
      static IMessageServerInterface messageServer;

      static MessageHandler()
      {
         try
         {
            //Create channel to message server using .NET Remoting
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);

            //Gets a proxy reference to the IMessageServerInterface
            messageServer = (IMessageServerInterface)Activator.GetObject(
               typeof(IMessageServerInterface)
               , "tcp://localhost:9932/MessageServerListener");
         }
         catch (System.ArgumentNullException ane)
         {
            MessageBox.Show("Invalid URL\n" + ane.Message);
         }
         catch (System.Runtime.Remoting.RemotingException re)
         {
            MessageBox.Show("type is not marshaled by reference.-or-type is an interface.\n" + re.Message);
         }
         catch (System.MemberAccessException mae)
         {
            MessageBox.Show("This member was invoked with a late-binding mechanism.\n" + mae.Message);

         }
         finally
         {
            if (messageServer == null)
            {
               MessageBox.Show("Problem connecting to message server");
            }
         }
      }

      static public void WriteMessage(string message)
      {
         try
         {
            if (messageServer != null)
            {
               messageServer.WriteMessage(message);
            }
         }
         catch (SocketException)
         {
            //Server not running
            messageServer = null;
         }
      }

      static public void InformNavisworksClosed()
      {
         try
         {
            if (messageServer != null)
            {
               messageServer.InformNavisworksClosed();
            }
         }
         catch (SocketException)
         {
            //server not running
            messageServer = null;
         }

      }
   }
}
