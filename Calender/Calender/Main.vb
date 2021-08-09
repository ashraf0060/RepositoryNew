Imports System.Data.SqlClient

Public Class Main
    Dim Com As New SqlCommand
    Dim SQLGetAdptrff As New SqlDataAdapter
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        DataGridView1.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 150)
        Try
            SQLGetAdptrff = New SqlDataAdapter
            OfflineCon.ConnectionString = ConSTR
            Com.CommandTimeout = 30
            Com.Connection = OfflineCon
            SQLGetAdptrff.SelectCommand = Com
            Dim builder As New SqlCommandBuilder(SQLGetAdptrff)
            'SQLGetAdptr.UpdateCommand = Com
            Com.CommandType = CommandType.Text
            Com.CommandText = "select [Sql] AS [مسلسل], [ItemNm] As [البيان],[Details] As [التفاصيل] ,[DuDate]  As [تاريخ الحدث],[Wdays] As [يوم التذكير] ,[To_] As [To] ,[CC_] As [CC] ,[LstSend] AS [تاريخ أخر ارسال],[Ignore] from Main"
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()
            SQLGetAdptrff.Fill(MainTbl)
            DataGridView1.DataSource = MainTbl
            Me.WindowState = FormWindowState.Maximized
            Me.Text = "الشاشة الرئيسيه" & " - " & MainTbl.Rows.Count
            DataGridView1.DefaultCellStyle.Font = New Font("Times New Roman", 12, System.Drawing.FontStyle.Regular)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 14, System.Drawing.FontStyle.Regular)
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.AutoResizeColumnHeadersHeight()
            'DataGridView1.AutoResizeColumns()
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.Columns(0).Visible = False
            'DataGridView1.Columns(7).Visible = False
        Catch ex As Exception
            AppLog(ex.Message, Com.CommandText)
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
            DataGridView1.Columns(0).Visible = False
            'DataGridView1.Columns(7).Visible = False
            MsgBox("Updated")
        Catch ex As Exception
            AppLog(ex.Message, Com.CommandText)
            MsgBox("Err Function : " & ex.Message)
        End Try
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.CurrentCell.ColumnIndex = 4 Then
            If DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value.ToString.Length > 0 Then
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(7).Value = ServrTime()
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(8).Value = 0
            End If
        End If

    End Sub
End Class
