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

//------------------------------------------------------------------

#pragma region MCDockPane_cpp
//Docking pane implementation

#include "stdafx.h"
#include "MCDockPanePlugin.h"
#include "Win32WindowWrapper.h"

IWin32Window^ MCDockPane::MCDockPanePlugin::CreateHWndPane(IWin32Window^ parent)
{
   //Get the HWND for the control we wish to show in a dock pane
   HWND hwnd = CreateWindowEx(0,
            L"STATIC", L"Hello World", (WS_CHILD | WS_VISIBLE),
            0, 0, 100, 150, (HWND)parent->Handle.ToPointer(),
            NULL, NULL, NULL);
   ::SetWindowText(hwnd, L"Hello World!!!");

   //Wrap it into a suitable IWin32Window container
   IWin32Window^ win = gcnew Win32WindowWrapper(hwnd);

   //return the container
   return win;
}

void MCDockPane::MCDockPanePlugin::DestroyHWndPane(System::Windows::Forms::IWin32Window^ pane)
{
   //Destroy the window
   ::DestroyWindow((HWND)pane->Handle.ToPointer());
}

int MCDockPane::MCAddInPlugin::Execute(array<String^>^ parameters)
{
   if (Autodesk::Navisworks::Api::Application::IsAutomated)
   {
      throw gcnew InvalidOperationException("Invalid when running using Automation");
   }

   //Find the plugin
   Plugins::PluginRecord^ pr =
      Autodesk::Navisworks::Api::Application::Plugins->FindPlugin("MCDockPane.MCDockPanePlugin.ADSK");

   if (pr != nullptr && dynamic_cast<DockPanePluginRecord^>(pr) && pr->IsEnabled)
   {
      //check if it needs loading
      if (pr->LoadedPlugin == nullptr)
      {
         pr->LoadPlugin();
      }

      DockPanePlugin^ dpp = dynamic_cast<DockPanePlugin^>(pr->LoadedPlugin);
      if (dpp != nullptr)
      {
         //switch the Visible flag
         dpp->Visible = !dpp->Visible;
      }
   }
   return 0;
}
#pragma endregion

