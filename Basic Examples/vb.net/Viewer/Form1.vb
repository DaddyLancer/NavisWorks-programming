'------------------------------------------------------------------
' NavisWorks Sample code
'------------------------------------------------------------------
'
' (C) Copyright 2010 by Autodesk Inc.
'
' Permission to use, copy, modify, and distribute this software in
' object code form for any purpose and without fee is hereby granted,
' provided that the above copyright notice appears in all copies and
' that both that copyright notice and the limited warranty and
' restricted rights notice below appear in all supporting
' documentation.
'
' AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
' AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
' MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
' DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
' UNINTERRUPTED OR ERROR FREE.
'------------------------------------------------------------------
'
' This sample demonstrates a basic Viewer for Navisworks files using
' the Controls part of the API
'
'------------------------------------------------------------------

Imports Autodesk.Navisworks.Api.Controls

Public Class Form1

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'Finish use of the API
        Autodesk.Navisworks.Api.Controls.ApplicationControl.Terminate()
    End Sub

    Public Sub New()
        'Set to single document mode
        Autodesk.Navisworks.Api.Controls.ApplicationControl.ApplicationType = ApplicationType.SingleDocument

        'Initialise the API
        Autodesk.Navisworks.Api.Controls.ApplicationControl.Initialize()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        'Dialog for selecting the Location of the file toolStripMenuItem1 open
        Dim dlg As OpenFileDialog = New OpenFileDialog()

        'Ask user for file location
        If dlg.ShowDialog() = DialogResult.OK Then
            'If the user has selected a valid location, then tell DocumentControl to open the file
            'As DocumentCtrl is linked to ViewControl
            documentControl.Document.TryOpenFile(dlg.FileName)
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
End Class
