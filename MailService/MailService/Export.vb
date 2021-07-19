Public Class Export
    Private Sub Export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimeFrom.Value = Today
        DateTimeTo.Value = Today
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StatusBarPanel3.Text = "Exporting Data ........ "
        Dim Params(3) As SqlParameter
        Params(0) = New SqlParameter("@From", SqlDbType.Date)
        Params(1) = New SqlParameter("@To", SqlDbType.Date)
        Params(2) = New SqlParameter("@Comp", SqlDbType.NVarChar)
        Params(3) = New SqlParameter("@Prod", SqlDbType.NVarChar)
        sqlComm.Parameters.AddRange(Params)
        Params(0).Value = DateTimeFrom.Value
        Params(1).Value = DateTimeTo.Value
        If TxtComp.TextLength > 0 Then Params(2).Value = TxtComp.Text Else Params(2).Value = DBNull.Value
        If TxtProd.TextLength > 0 Then Params(3).Value = TxtProd.Text Else Params(3).Value = DBNull.Value
        sqlCon = New SqlConnection(strConn)
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.StoredProcedure
        sqlComm.CommandText = "Export"
        ManualSubmit()
        sqlComm.Parameters.RemoveAt("@From")
        sqlComm.Parameters.RemoveAt("@To")
        sqlComm.Parameters.RemoveAt("@Prod")
        sqlComm.Parameters.RemoveAt("@Comp")
        Params(1) = Nothing
    End Sub

    Private Sub ManualSubmit()

        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        StatusBarPanel3.Text = "Exporting Data ........ "
        DataExpSrv(TxtProd.Text & "_" & TxtComp.Text, "Export")
    End Sub
End Class