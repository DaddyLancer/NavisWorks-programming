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
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

namespace MessageClientPlugin
{
   /// <summary>
   /// This plugin subscribes to events and reports on the events
   /// being raised to the MessageServer
   /// </summary>
   [PluginAttribute("MessageClientPlugin.EventInformer",                   //Plugin name
                    "ADSK",                                       //4 character Developer ID or GUID
                    ToolTip = "This plugin sends messages using .NET remoting to a listening server ",//The tooltip for the item in the ribbon
                    DisplayName = "Message Client")]          //Display name for the Plugin in the Ribbon
   public class EventInformer : EventWatcherPlugin
   {
      public override void OnLoaded()
      {
         //subscribe to events
         Application.GuiCreated += Application_GuiCreated;
         Application.GuiDestroying += Application_GuiDestroying;
         Application.DocumentAdded += Application_DocumentAdded;
         Application.DocumentRemoved += Application_DocumentRemoved;
         Application.ActiveDocumentChanging += Application_ActiveDocumentChanging;
         Application.ActiveDocumentChanged += Application_ActiveDocumentChanged;
         Application.MainDocumentChanging += Application_MainDocumentChanging;
         Application.MainDocumentChanged += Application_MainDocumentChanged;
      }


      public override void OnUnloading()
      {
         //unsubscribe from events
         Application.GuiCreated -= Application_GuiCreated;
         Application.GuiDestroying -= Application_GuiDestroying;
         Application.DocumentAdded -= Application_DocumentAdded;
         Application.DocumentRemoved -= Application_DocumentRemoved;
         Application.ActiveDocumentChanging -= Application_ActiveDocumentChanging;
         Application.ActiveDocumentChanged -= Application_ActiveDocumentChanged;
         Application.MainDocumentChanging -= Application_MainDocumentChanging;
         Application.MainDocumentChanged -= Application_MainDocumentChanged;

         //Inform server that Navisworks has closed
         MessageHandler.InformNavisworksClosed();
      }

      void Application_GuiCreated(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Gui Created");
      }

      void Application_GuiDestroying(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Gui Destroying");
      }

      void Application_ActiveDocumentChanging(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Active Document changing from: " + AsString(Application.ActiveDocument));
      }

      void Application_ActiveDocumentChanged(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Active Document changed to: " + AsString(Application.ActiveDocument));
      }

      void Application_MainDocumentChanging(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Main Document changing from: " + AsString(Application.MainDocument));
      }

      void Application_MainDocumentChanged(object sender, EventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Main Document changed to: " + AsString(Application.MainDocument));
      }

      void Application_DocumentAdded(object sender, DocumentEventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Document has been Added: " + AsString(e.Document));
      }

      void Application_DocumentRemoved(object sender, DocumentEventArgs e)
      {
         //Inform server of the event
         MessageHandler.WriteMessage("Document has been Removed: " + AsString(e.Document));
      }

      private string AsString(object ob)
      {
         return (ob == null) ? "<null>" : ob.ToString();
      }
   }
}
