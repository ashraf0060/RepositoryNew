Imports System.Data.SqlClient

Public Class Main
    Dim Com As New SqlCommand
    Dim SQLGetAdptrff As New SqlDataAdapter
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        DataGridView1.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 150)
        Try
            SQLGetAdptrff = New SqlDataAdapter
            LoadfFrm("", 350, 500)
            OfflineCon.ConnectionString = ConSTR
            Com.CommandTimeout = 30
            Com.Connection = OfflineCon
            SQLGetAdptrff.SelectCommand = Com
            Dim builder As New SqlCommandBuilder(SQLGetAdptrff)
            'SQLGetAdptr.UpdateCommand = Com
            Com.CommandType = CommandType.Text
            Com.CommandText = "select * from Main"
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()
            SQLGetAdptrff.Fill(MainTbl)
            LodngFrm.Close()
            DataGridView1.DataSource = MainTbl
            'DataGridView1.AllowUserToAddRows = False
            'DataGridView1.AllowUserToDeleteRows = False
            'DataGridView1.ReadOnly = True
            Me.WindowState = FormWindowState.Maximized
            Me.Text = "الشاشة الرئيسيه" & " - " & MainTbl.Rows.Count
            DataGridView1.DefaultCellStyle.Font = New Font("Times New Roman", 12, System.Drawing.FontStyle.Regular)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 14, System.Drawing.FontStyle.Regular)
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.AutoResizeColumnHeadersHeight()
            DataGridView1.AutoResizeColumns()
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Catch ex As Exception
            LodngFrm.Close()
            MsgBox("Err Function : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            SQLGetAdptrff.Update(MainTbl)
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()
            SQLGetAdptrff.Fill(MainTbl)
            DataGridView1.AutoResizeColumnHeadersHeight()
            DataGridView1.AutoResizeColumns()
            MsgBox("Updated")
        Catch ex As Exception
            MsgBox("Err Function : " & ex.Message)
        End Try
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class
