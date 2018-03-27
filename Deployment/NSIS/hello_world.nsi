;------------------------------------------------------------------
; NavisWorks Sample code
;------------------------------------------------------------------

; (C) Copyright 2010 by Autodesk Inc.

; Permission to use, copy, modify, and distribute this software in
; object code form for any purpose and without fee is hereby granted,
; provided that the above copyright notice appears in all copies and
; that both that copyright notice and the limited warranty and
; restricted rights notice below appear in all supporting
; documentation.

; AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
; AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
; MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
; DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
; UNINTERRUPTED OR ERROR FREE.
;------------------------------------------------------------------
;
; This is an example installer for the 'Hello World' Sample 
; illustrated in the  User guide.
;
; Requires NSIS 2.45
;
; To customize this for your own plug-ins you should only need to edit
; the defines below.  Note this script assumes your plug-in has no dependent
; assemblies, and will therefore need to be extended to install dependent
; assemblies in the Dependencies folder.
;
;------------------------------------------------------------------


;------------------------------------------------------------------
;
;Defines
;
!define SHORT_NAME "Hello World"
!define PROGRAM_NAME "${SHORT_NAME} Plugin"
!define COMPANY Autodesk
!define DEV_ID ADSK
!define MAJOR_VERSION 1
!define MINOR_VERSION 0
!define BUILD 0
!define ASSEMBLY_NAME BasicPlugIn
!define INSTALL_FILESET ..\..\PlugIns\${ASSEMBLY_NAME}\Release\*.*
!define UNINSTALL_LOCATION "$COMMONFILES\${COMPANY}\Navisworks 13\PlugIns\${SHORT_NAME}"
!define UNINSTALLER_NAME uninstall.exe
!define PAUSE_MS 2000

;------------------------------------------------------------------
;
;Installer attributes
;
Name "${PROGRAM_NAME}"

OutFile setup.exe

;Best compression
SetCompressor /SOLID zlib

;Run as admin on Vista, Windows 7 etc.
RequestExecutionLevel admin

;Show progress to the user at install time
ShowInstDetails show
ShowUninstDetails show

;Add file level version information to the installer, uninstaller
  VIAddVersionKey ProductName "${PROGRAM_NAME}"

  VIAddVersionKey Comments ""
  VIAddVersionKey CompanyName "${COMPANY}"
  VIAddVersionKey LegalCopyright "(C) ${COMPANY}"
  VIAddVersionKey FileDescription "${PROGRAM_NAME}"
  VIAddVersionKey FileVersion "${MAJOR_VERSION}.${MINOR_VERSION}.0.${BUILD}"
  VIAddVersionKey ProductVersion "${MAJOR_VERSION}.${MINOR_VERSION}.0.${BUILD}"
  VIAddVersionKey InternalName ""
  VIAddVersionKey LegalTrademarks ""
  VIAddVersionKey OriginalFilename ""
  VIAddVersionKey PrivateBuild ""
  VIAddVersionKey SpecialBuild ""

  VIProductVersion ${MAJOR_VERSION}.${MINOR_VERSION}.0.${BUILD}

;------------------------------------------------------------------
;
;Includes
;

;Modern UI
!include "MUI2.nsh"

;64 bit macros
!include "x64.nsh"

;File/Path functions
!include "FileFunc.nsh"

;Used for VersionCompare macro
!include "WordFunc.nsh"

;------------------------------------------------------------------
;
;Global variables
;
var location
var num_products_installed
var products_installed
var install_size_kb
var example_install_location

;------------------------------------------------------------------
;
;UI Pages
;
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_INSTFILES
;Must redefine the text prior to including the finish page macro
!define MUI_FINISHPAGE_TEXT $products_installed
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

;------------------------------------------------------------------
;
;Languages
;

!insertmacro MUI_LANGUAGE "English"

;------------------------------------------------------------------

;------------------------------------------------------------------
;
;Convenience defines
;
!define ARP "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PROGRAM_NAME}"
!define API_KEY "SOFTWARE\Autodesk\Navisworks API Runtime\13"
!define API_PLUGINS_SUBKEY "PlugIns"

;Auto uninstall of old versions
Function .onInit
 
  ReadRegStr $0 HKLM "${ARP}" "UninstallString"
  StrCmp $0 "" done

  ReadRegStr $1 HKLM "${ARP}" "DisplayVersion"
  StrCmp $1 "" done

  ;Check the version of the uninstaller to make sure we don't downgrade
  ${VersionCompare} "${MAJOR_VERSION}.${MINOR_VERSION}.0.${BUILD}" $1 $2
  IntCmp $2 1 upgrade reinstall downgrade

downgrade:
  MessageBox MB_OK|MB_ICONEXCLAMATION \
   "A newer version of ${PROGRAM_NAME} is already installed$\n$\n \
   Click 'OK' to cancel the install"
  Abort

reinstall:
  MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
    "${PROGRAM_NAME} is already installed. $\n$\nClick 'OK' to reinstall" \
    IDOK uninst
  Abort

upgrade:
  MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
    "${PROGRAM_NAME} is already installed. $\n$\nClick 'OK' to remove the \
    previous version or 'Cancel' to cancel this upgrade." IDOK uninst
  Abort
 
;Run the uninstaller
uninst:
  ${GetParent} $0 $1
  ;Strip leading speechmark in first character, GetParent macro loses the 
  ;trailing speechmark for us
  StrCpy $2 $1 "" 1
  ;Do not copy the uninstaller to a temp file
  ExecWait '$0 _?=$2'
  ;Don't need to delete the uninstaller here as long as we are writing our
  ;new uninstaller to the same location
done:
 
FunctionEnd

Function Install

  ;Sets the target location, creates the folder
  SetOutPath "$location\PlugIns\${ASSEMBLY_NAME}.${DEV_ID}"

  ;Unpacks the files to be installed to the target location
  File /r ${INSTALL_FILESET}

  ;Note the size of our new folder
  ${GetSize} "$OUTDIR" "/S=0K" $R0 $R1 $R2
  IntOp $install_size_kb $install_size_kb + $R0

  ;Records the folder where we have installed plug-ins, because we could 
  ;install to multiple locations and we need to tidy up comprehensively at 
  ;uninstall time
  WriteRegStr HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}\${SHORT_NAME}" "$OUTDIR" "$OUTDIR"

  ;Records this folder so we can tell Add/Remove Programs this is where we
  ;are located
  StrCpy $example_install_location "$OUTDIR"

  ;Keep a count of the number of products installed, so we know if we have been
  ;successful
  IntOp $num_products_installed $num_products_installed + 1
FunctionEnd

;On x64 platforms, we need to use the x64 registry.  Because this installer is
;32 bit we will get redirected to the WOW32 node otherwise
!macro RedirectRegistryForX64
  ${If} ${RunningX64} 
    SetRegView 64
  ${EndIf}
!macroend

;The install section
Section
  ;Initialize our count of the number of times we have installed the plug-in
  ;For some reason, there is no IntCpy and we have to use StrCpy
  StrCpy $num_products_installed 0

  ;Initialize the size count
  StrCpy $install_size_kb 0

  ;Initialize the text that details in which products we have installed the
  ;plug-in
  StrCpy $products_installed "${PROGRAM_NAME} has been installed for the following products:$\r$\n"

  ;Initialize the var storing one of our install locations
  StrCpy $example_install_location ""

  !insertmacro RedirectRegistryForX64

  ;Enumerate over the api key looking for installed products
  StrCpy $0 0
  loop:
    ClearErrors
    EnumRegKey $1 HKLM "${API_KEY}" $0

    ;Exit loop if no more entries
    StrCmp $1 "" done

    ;Increment the counter
    IntOp $0 $0 + 1

    ;Find where this API Runtime is located
    ReadRegStr $location HKLM "${API_KEY}\$1" Path
    IfErrors loop

    call Install

    ;Update our text list of products we have installed against
    StrCpy $2 "$products_installed$\r$\n- $1"
    StrCpy $products_installed $2

    ;Give the user a chance to see what we have installed
    Sleep ${PAUSE_MS} 

    ;Next registry entry
    GoTo loop
  done:

  ;If no products found, abort
  IntCmp $num_products_installed 0 0 +2 +2
    Abort "No Navisworks installs found"

  ;Add the text list of products installed against to the finish page text
  StrCpy $2 "$products_installed$\r$\n$\rClick Finish to close this wizard."
  StrCpy $products_installed $2

  ;Write uninstaller
  CreateDirectory "${UNINSTALL_LOCATION}"
  WriteUninstaller "${UNINSTALL_LOCATION}\${UNINSTALLER_NAME}"
  
  ;Record the size of the uninstaller
  ${GetSize} "${UNINSTALL_LOCATION}" "/S=0K" $0 $1 $2
  IntOp $install_size_kb $install_size_kb + $0

  ;Create Add/Remove Programs entry
  WriteRegStr HKLM "${ARP}" "DisplayName" "${PROGRAM_NAME}"
  WriteRegStr HKLM "${ARP}" "DisplayVersion" \
    "${MAJOR_VERSION}.${MINOR_VERSION}.0.${BUILD}"
  WriteRegStr HKLM "${ARP}" "UninstallString" \
    "$\"${UNINSTALL_LOCATION}\${UNINSTALLER_NAME}$\""
  WriteRegStr HKLM "${ARP}" "InstallLocation" "$example_install_location"
  ; Convert the decimal KB value to DWORD
  IntFmt $install_size_kb "0x%08X" $install_size_kb
  ;Unfortunately, this doesn't work on every OS
  WriteRegDWORD HKLM "${ARP}" "EstimatedSize" "$install_size_kb"

  Sleep ${PAUSE_MS}

SectionEnd

;Uninstall logic
Section "Uninstall"

  SetDetailsPrint both

  !insertmacro RedirectRegistryForX64

  ;Enumerate our plug-ins sub key to find all the places we have installed
  ;the plug-in, and delete the key and the folder where the plug-in was
  ;installed
  StrCpy $0 0
  loop:
    EnumRegValue $1 HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}\${SHORT_NAME}" $0

    ;Exit loop if no more items
    StrCmp $1 "" done

    ;Increment our counter
    IntOp $0 $0 + 1

    ReadRegStr $2 HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}\${SHORT_NAME}" $1
    ;Remove the folder and registry entry reminder
    RMDir /r /REBOOTOK $2
    DetailPrint "Remove registry entry: HKLM\${API_KEY}\${API_PLUGINS_SUBKEY}\$1"
    DeleteRegValue HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}" $1

    Sleep ${PAUSE_MS}

    ;Next registry entry
    GoTo loop
  done:

  ;Remove the plug-ins sub key if it is empty
  DeleteRegKey /ifempty HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}\${SHORT_NAME}"
  DeleteRegKey /ifempty HKLM "${API_KEY}\${API_PLUGINS_SUBKEY}"

  ;Remove the uninstaller, and its containing folders if empty
  DetailPrint "Removing uninstaller"
  Delete "${UNINSTALL_LOCATION}\${UNINSTALLER_NAME}"
  ;Remove the containing folders if empty
  StrCpy $0 "${UNINSTALL_LOCATION}\${UNINSTALLER_NAME}"
  ClearErrors
get_parent_dir:
  ${GetParent} $0 $1

  ;Exit loop if no parent folder returned
  StrCmp $1 "" remove_arp

  ;Attempt to remove the folder
  RMDir $1

  ;Exit loop if we didn't remove that folder, possibly because it wasn't empty
  IfErrors remove_arp

  ;Set things up so next time round we work on the parent folder
  StrCpy $0 $1
  Goto get_parent_dir

remove_arp:
  DetailPrint "Removing Add/Remove Programs entry"
  DeleteRegKey HKLM "${ARP}"

  Sleep ${PAUSE_MS}

SectionEnd
