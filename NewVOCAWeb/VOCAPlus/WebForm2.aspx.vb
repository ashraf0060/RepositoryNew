Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SqlTbl As New DataTable
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "SELECT        CASE WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 9) = '10.10.200' THEN 'Maadi' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 7) = '10.11.5' THEN 'Sabeel' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 6) 
                         = '10.122' THEN 'Airport' ELSE 'Others' END AS Location, COUNT(dbo.Int_user.UsrCat) AS Count
FROM            dbo.Int_user INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId
WHERE        (format(dbo.Int_user.UsrLastSeen, 'yyyy/MM/dd') = format(getdate(), 'yyyy/MM/dd'))
GROUP BY  CASE WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 9) = '10.10.200' THEN 'Maadi' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 7) 
                         = '10.11.5' THEN 'Sabeel' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 6) = '10.122' THEN 'Airport' ELSE 'Others' END
						 order by Count desc"
        Dim ff As String = ""
        Try
            'If sqlCon.State = ConnectionState.Closed Then
            '    sqlCon.ConnectionString = strConn
            '    sqlCon.Open()
            'End If
            SQLTblAdptr.Fill(SqlTbl)
            GridView1.DataSource = SqlTbl
            GridView1.DataBind()

            For hh = 0 To SqlTbl.Columns.Count - 1
                ff &= SqlTbl.Columns(hh).ColumnName
            Next
            Label1.Text = CStr((SqlTbl.Rows.Count)) & "_" & ff
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Label1.Text = ex.Message & "_" & ff
        End Try
    End Sub

End Class