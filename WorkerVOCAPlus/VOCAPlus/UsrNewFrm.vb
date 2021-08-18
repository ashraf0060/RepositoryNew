Public Class UsrNewFrm
    Dim SwTbl As New DataTable
    Private Sub UsrNewFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SwTbl.Rows.Clear()
        SwTbl.Columns.Clear()
        GetTbl("Select * from ASwitchboard", SwTbl, "0000&H")
        DataGridView1.DataSource = SwTbl
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ATbbl As New DataTable
        GetTbl("select Int_user.UsrId from Int_user where (Int_user.UsrSusp = 0) and (SUBSTRING(UsrLevel," & DataGridView1.CurrentRow.Cells(0).Value & ",1) = 'H' or SUBSTRING(UsrLevel," & DataGridView1.CurrentRow.Cells(0).Value & ",1) = 'A')", ATbbl, "0000&H")
        If ATbbl.Rows.Count > 0 Then
            For YY = 0 To ATbbl.Rows.Count - 1
                InsUpd("update Int_user set UsrLevel = SUBSTRING(UsrLevel,1," & DataGridView1.CurrentRow.Cells(0).Value - 1 & ") + 'H' + SUBSTRING(UsrLevel," & DataGridView1.CurrentRow.Cells(0).Value + 1 & ",100) where UsrId = " & ATbbl.Rows(YY).Item(0), "0000&H")
            Next
        End If

    End Sub
End Class