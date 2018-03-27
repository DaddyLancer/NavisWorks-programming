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
#pragma once

#pragma region MCDockPane_h
//------------------------------------------------------------------
//Docking pane declaration

using namespace System;
using namespace System::Windows::Forms;
using namespace Autodesk::Navisworks::Api;
using namespace Autodesk::Navisworks::Api::Plugins;

namespace MCDockPane {

   [Plugin("MCDockPane.MCDockPanePlugin", "ADSK",
      DisplayName = "MCDockPanePlugin",
      ToolTip = "Basic Docking Pane Plugin")]
   [DockPanePlugin(100, 300)]
   public ref class MCDockPanePlugin : public Autodesk::Navisworks::Api::Plugins::DockPanePlugin
	{
   public:
      virtual IWin32Window^ CreateHWndPane(IWin32Window^ parent) override;

      virtual void DestroyHWndPane(System::Windows::Forms::IWin32Window^ pane) override;
   };

   [Plugin("MCDockPane.MCAddInPlugin", "ADSK",
      DisplayName = "MCAddInPlugin",
      ToolTip = "Add In Plugin for MCDockPanePlugin")]
   public ref class MCAddInPlugin : public Autodesk::Navisworks::Api::Plugins::AddInPlugin
	{
   public:
      virtual int Execute(array<String^>^ parameters) override;
   };
}
#pragma endregion
