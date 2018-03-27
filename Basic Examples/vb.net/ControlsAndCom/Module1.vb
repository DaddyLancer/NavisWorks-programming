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
' This sample illustrates how to use a DocumentControl to load a document
' in conjunction with the existing COM API.
'
'------------------------------------------------------------------
Imports System
Imports System.Windows.Forms

'Add the namespaces
Imports Autodesk.Navisworks.Api
Imports Autodesk.Navisworks.Api.Controls

Imports ComApi = Autodesk.Navisworks.Api.Interop.ComApi
Imports ComApiBridge = Autodesk.Navisworks.Api.ComApi
Module Module1

    Sub Main()
        'Set to single document mode
        Autodesk.Navisworks.Api.Controls.ApplicationControl.ApplicationType = ApplicationType.SingleDocument

        'Initialise the api
        ApplicationControl.Initialize()

        'Create a DocumentControl
        Dim documentControl As DocumentControl = New DocumentControl()

        'Set as main document, needs to be called as COM works on the application's MainDocument
        DocumentControl.SetAsMainDocument()

        'Dialog for selecting the Location of the file to open
        Dim dlg As OpenFileDialog = New OpenFileDialog()

        'Ask user for file location
        If dlg.ShowDialog() = DialogResult.OK Then

            'If the user has selected a valid location, then tell DocumentControl to open the file
            If (documentControl.Document.TryOpenFile(dlg.FileName)) Then

                'Select the first root item using the API
                Dim newSelection As ModelItemCollection = New ModelItemCollection()
                newSelection.Add(documentControl.Document.Models.First.RootItem)
                documentControl.Document.CurrentSelection.CopyFrom(newSelection)

                'now query the selection using the COM API
                Dim state As ComApi.InwOpState10
                state = ComApiBridge.ComApiBridge.State

                For Each path As ComApi.InwOaPath In state.CurrentSelection.Paths()
                    Dim node As ComApi.InwOaNode
                    node = path.Nodes().Last()
                    MessageBox.Show("UserName=" + node.UserName)
                Next
            End If
        End If

        'Dispose of the DocumentControl
        documentControl.Dispose()

        'Finish use of the API.
        ApplicationControl.Terminate()
    End Sub

End Module
