Imports System.Data.SqlClient

Public Class Test
    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim state As New ClLogin.Defntin
        Dim dd As New DataTable
        state.StatStr = "Connecting"
        Dim StW As New Stopwatch
        StW.Start()

        state.Errmsg = Nothing
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        Dim sqlCommW As New SqlCommand
        Try
            If state.sqlCon.State = ConnectionState.Closed Then
                state.sqlCon.Open()
            End If
            SQLGetAdptr = New SqlDataAdapter            'SQL Table Adapter
            sqlCommW = New SqlCommand("select * from int_user", state.sqlCon)
            SQLGetAdptr.SelectCommand = sqlCommW
            SQLGetAdptr.Fill(dd)
            StW.Stop()
            Dim TimSpn As TimeSpan = (StW.Elapsed)
            Me.Text = TimSpn.ToString
        Catch ex As Exception
        state.StatStr = ex.Message
        'MsgBox(ex.Message)
        End Try
        DataGridView1.DataSource = dd
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim state As New ClLogin.Defntin
        Dim dd As New DataTable
        state.StatStr = "Connecting"
        Dim StW As New Stopwatch
        StW.Start()

        state.Errmsg = Nothing
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        Dim sqlCommW As New SqlCommand
        Try
            If state.sqlCon.State = ConnectionState.Closed Then
                state.sqlCon.Open()
            End If
            SQLGetAdptr = New SqlDataAdapter            'SQL Table Adapter
            sqlCommW = New SqlCommand("select * from int_user", state.sqlCon)
            SQLGetAdptr.SelectCommand = sqlCommW
            SQLGetAdptr.Fill(dd)
            StW.Stop()
            Dim TimSpn As TimeSpan = (StW.Elapsed)
            Me.Text = TimSpn.ToString
        Catch ex As Exception
            state.StatStr = ex.Message
            'MsgBox(ex.Message)
        End Try
        DataGridView1.DataSource = dd
    End Sub
End Class