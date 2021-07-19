Imports System.Data.SqlClient

Public Class ProdGroup
    Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim Com As New SqlCommand
    Private Sub ProdGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ErrFunction As String = Nothing
        Try
            Me.BackColor = Color.White
            Dim BtnUpdate As New Button
            Dim BtnExport As New Button
            Dim panel1 As New FlowLayoutPanel
            CntxStrip = New ContextMenuStrip
            panel1.BorderStyle = BorderStyle.FixedSingle
            panel1.Dock = DockStyle.Top
            panel1.Height = 70
            GrdView = New DataGridView
            GrdView.Height = Screen.PrimaryScreen.Bounds.Height - 150
            Me.Controls.Add(panel1)
            panel1.BackColor = Color.White
            panel1.Controls.Add(BtnUpdate)
            BtnUpdate.Text = "Update"
            AddHandler BtnUpdate.Click, AddressOf BtUpdt_click
            panel1.Controls.Add(BtnExport)
            BtnExport.BackgroundImage = My.Resources.Export
            BtnExport.FlatStyle = FlatStyle.Flat
            BtnExport.FlatAppearance.BorderColor = Color.White
            BtnExport.BackgroundImageLayout = ImageLayout.Zoom
            BtnExport.Size = New Point(50, 40)
            BtnExport.FlatStyle = FlatStyle.Flat
            AddHandler BtnExport.Click, AddressOf BtnExport_click
            GrdView.BackgroundColor = Color.White
            GrdView.ContextMenuStrip = CntxStrip
            AddHandler GrdView.CellClick, AddressOf renamCol
            CntxStrip.Items.Add("Clear Column")
            AddHandler CntxStrip.Click, AddressOf Removeolumn_Click
            CntxStrip.Items(0).Image = My.Resources._Exit
            Me.Controls.Add(GrdView)
            GrdView.Dock = DockStyle.Bottom
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()

            Try
                SQLGetAdptr = New SqlDataAdapter
                LoadfFrm("", 350, 500)
                Com.CommandTimeout = 30
                Com.Connection = OfflineCon
                SQLGetAdptr.SelectCommand = Com
                Dim builder As New SqlCommandBuilder(SQLGetAdptr)
                'SQLGetAdptr.UpdateCommand = Com
                Com.CommandType = CommandType.Text
                Com.CommandText = "select [ItmNm] AS [Item name],[ProType] as [Product Type] from ProdType"

                SQLGetAdptr.Fill(MainTbl)
                LoadFrm.Close()
                GrdView.DataSource = MainTbl
                'GrdView.AllowUserToAddRows = False
                GrdView.AllowUserToDeleteRows = False
                'GrdView.ReadOnly = True
                Me.WindowState = FormWindowState.Maximized
                Me.Text = "Product Groups" & " - " & MainTbl.Rows.Count

                GrdView.DefaultCellStyle.Font = New Font("Times New Roman", 12, System.Drawing.FontStyle.Regular)
                GrdView.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 14, System.Drawing.FontStyle.Regular)
                GrdView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GrdView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
                GrdView.AutoResizeColumnHeadersHeight()
                GrdView.AutoResizeColumns()
            Catch ex As Exception
                LoadFrm.Close()
                MsgBox("Err Function : " & ex.Message)
            End Try

            'If GetTbl("select * from ProdType", MainTbl) = Nothing Then

            'Else
            '    MsgBox("Fill Err : " & Errmsg)
            'End If
        Catch ex As Exception
            ErrFunction = "X"
            MsgBox("Err Function : " & ex.Message)
        End Try

    End Sub
    Private Sub BtUpdt_click(sender As Object, e As EventArgs)
        Try
            SQLGetAdptr.Update(MainTbl)
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()
            SQLGetAdptr.Fill(MainTbl)
            GrdView.AutoResizeColumnHeadersHeight()
            GrdView.AutoResizeColumns()
            MsgBox("Updated")
        Catch ex As Exception
            MsgBox("Err Function : " & ex.Message)
        End Try

    End Sub

    Private Sub renamCol(sender As Object, e As DataGridViewCellEventArgs)
        CntxStrip.Items(0).Text = "Delete : " & GrdView.Columns(GrdView.CurrentCell.ColumnIndex).Name
    End Sub

    Private Sub Removeolumn_Click(sender As Object, e As EventArgs)
        MainTbl.Columns.RemoveAt(GrdView.CurrentCell.ColumnIndex)
    End Sub
    Private Sub BtnExport_click(sender As Object, e As EventArgs)
        Exprt(Me.Text)
    End Sub
    Private Sub ProdGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class