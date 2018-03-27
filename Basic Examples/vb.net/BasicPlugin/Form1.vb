Imports Autodesk.Navisworks.Api
Imports Autodesk.Navisworks.Api.Plugins



Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TreeView1.Nodes.Add("")
        Dim curSel = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems
        Dim AncestorCount As Integer = curSel.Item(0).Ancestors.Count()

        TreeView1.Nodes.Add(curSel.Item(0).Ancestors(AncestorCount - 1).DisplayName)

        For Each ancestor As ModelItem In curSel.Item(0).Ancestors
            TreeView1.Nodes.Add(ancestor.DisplayName)
        Next


    End Sub
End Class