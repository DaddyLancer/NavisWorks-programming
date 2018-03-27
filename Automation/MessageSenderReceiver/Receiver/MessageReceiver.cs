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
using Autodesk.Navisworks.Api.Plugins;


namespace MessageSenderReceiver
{
   #region MessageSenderReceiver_MessageReceiver
   [PluginAttribute("MessageSenderReceiver.MessageReceiver",     //Plugin name
                    "ADSK")]                                     //4 character Developer ID or GUID
   [AddInPluginAttribute(AddInLocation.None)]                    //Identifies this as an Addin Plugin, that will not display in the ribbon
   public class MessageReceiver : AddInPlugin                    //Derives from AddInPlugin
   {
      public override int Execute(params string[] parameters)
      {
         //initialise a buffer to store the message
         String buffer = string.Empty;

         //Iterate the parameters and build the complete message
         foreach (String param in parameters)
         {
            buffer = buffer + "\r\n" + param;
         }

         //create the dialog to display to the user
         MessageReceived messageReceived = new MessageReceived();

         //assign the message to be displayed
         messageReceived.Message = buffer;

         //Show the dialog
         messageReceived.ShowDialog(Autodesk.Navisworks.Api.Application.Gui.MainWindow);

         //return the the caller the value given by the user
         return messageReceived.ReturnValue;
      }
   }
   #endregion
}
