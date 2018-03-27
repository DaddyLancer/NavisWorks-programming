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
#pragma region Win32WindowWrapper
//------------------------------------------------------------------
//Win32WindowWrapper.h wraps the IWin32Window
namespace MCDockPane 
{
   private ref class Win32WindowWrapper : public System::Windows::Forms::IWin32Window
   {
   private:
      HWND m_Win32Window;

   public:
      Win32WindowWrapper(HWND win)
      {
         m_Win32Window = win;
      }


      virtual property IntPtr Handle
      {
         IntPtr get()
         {
            return (IntPtr)m_Win32Window;
         }
      }

      operator HWND() { return m_Win32Window; }
   };
}
#pragma endregion