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

namespace MessageClientServerInterface
{
   /// <summary>
   /// This interface defines the communication from the client to the server that is available
   /// using .NET Remoting
   /// </summary>
   public interface IMessageServerInterface
   {
      /// <summary>
      /// Tells the Server to write a specific message
      /// </summary>
      /// <param name="message">the message to send</param>
      void WriteMessage(string message);

      /// <summary>
      /// Tells the server that Navisworks has closed
      /// </summary>
      void InformNavisworksClosed();
   }
}
