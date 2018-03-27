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
using MessageClientServerInterface;

namespace MessageServer
{
   /// <summary>
   /// This listener implements the IMessageServerInterface. It provides the .NET remoting server
   /// for the MessageClientPlugin to connect to, and in turn raises events which are subscribed to
   /// by the Form (MessageServer). 
   /// </summary>
   internal class MessageServerListener: MarshalByRefObject, IMessageServerInterface
   {
      public delegate void MessageRaisedEventHandler(object sender, MessageRaisedEventArgs e);
      public static event MessageRaisedEventHandler MessageRaised;
      public static event EventHandler NavisworksClosed;

      /// <summary>
      /// Raises an event with the Message to be transmitted
      /// </summary>
      /// <param name="message"></param>
      public void WriteMessage(string message)
      {
         if (MessageRaised != null)
            MessageRaised(this, new MessageRaisedEventArgs(message));
      }

      /// <summary>
      /// Raises an event informing that Navisworks has closed
      /// </summary>
      /// <param name="message"></param>
      public void InformNavisworksClosed()
      {
         if (NavisworksClosed != null)
            NavisworksClosed(this, new EventArgs());
      }
   }
}
