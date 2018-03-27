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
using Autodesk.Navisworks.Api.Plugins;

namespace MessageClientPlugin
{
   /// <summary>
   /// This is a simple AddInPlugin to demonstrate sending a standard message
   /// to the server as a result of user input
   /// </summary>
   [PluginAttribute("MessageClientPlugin.MessageClient",                   //Plugin name
                    "ADSK",                                       //4 character Developer ID or GUID
                    ToolTip = "This plugin sends messages using .NET remoting to a listening server ",//The tooltip for the item in the ribbon
                    DisplayName = "Message Client")]          //Display name for the Plugin in the Ribbon
   public class MessageClient : AddInPlugin                        //Derives from AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         MessageHandler.WriteMessage("hello from the client");
         return 0;
      }
   }
}
