Imports System.Data.SqlClient


Public Class Form2
    Private sqlComm As New SqlCommand                    'SQL Command
    Private SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Private tempTable As DataTable = New DataTable
    Private strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
    Private sqlCon As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "select * from Tickets"
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl(TextBox1.Text, tempTable)
        DataGridView1.DataSource = tempTable
    End Sub
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        'If sqlCon.State <> ConnectionState.Connecting And sqlCon.State <> ConnectionState.Open Then

        'End If
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        sqlComm.CommandTimeout = 90
        sqlComm.Connection = sqlCon
        SQLGetAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            'If sqlCon.State = ConnectionState.Closed Then
            '    sqlCon.ConnectionString = strConn
            '    sqlCon.Open()
            'End If
            SQLGetAdptr.Fill(SqlTbl)
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        SQLGetAdptr.Dispose()
        'LodngFrm.Close()
    End Function
    Public Function InsUpd(SSqlStr As String) As String
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            'LoadFrm("", 500, 350)
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl(TextBox1.Text, tempTable)
        DataGridView1.DataSource = tempTable
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        InsUpd("delete from Tickets")
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        strConn = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        strConn = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\SharedVB\InternalDatabase\TestAshraf\Database1.mdf;Integrated Security=True"
    End Sub
End Class