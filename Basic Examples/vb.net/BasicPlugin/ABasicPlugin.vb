'------------------------------------------------------------------
' NavisWorks Sample code
'------------------------------------------------------------------

' (C) Copyright 2010 by Autodesk Inc.

' Permission to use, copy, modify, and distribute this software in
' object code form for any purpose and without fee is hereby granted,
' provided that the above copyright notice appears in all copies and
' that both that copyright notice and the limited warranty and
' restricted rights notice below appear in all supporting
' documentation.

' AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
' AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
' MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
' DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
' UNINTERRUPTED OR ERROR FREE.
'------------------------------------------------------------------
'
' This is the VB equivalent of the 'Hello World' Sample illustrated
' in the User guide.
' It demonstrates the various aspects of a basic plugin.
'
'------------------------------------------------------------------

Option Explicit On
#Region "HelloWorld"
Imports System.Windows.Forms
Imports Autodesk.Navisworks.Api.Plugins
Imports Autodesk.Navisworks.Api

<PluginAttribute(
                "BasicVBPlugIn.ABasicVBPlugin",
                 "ADSK",
                 ToolTip:="BasicPlugIn.ABasicVBPlugin tool tip",
                 DisplayName:="Hello World-VB",
                 Options:=PluginOptions.None)>
Public Class ABasicPlugin
    Inherits AddInPlugin

    Public Overrides Function Execute(ByVal ParamArray parameters() As String) As Integer
        '        MessageBox.Show("HelloWorldi")
        Dim frm1 As New Form1
        frm1.Show()
        Return 0
    End Function

End Class
#End Region