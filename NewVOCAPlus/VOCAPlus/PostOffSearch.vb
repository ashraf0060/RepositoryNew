Imports System.Data.SqlClient
Public Class PostOffSearch
    Dim tbl As New DataTable
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        Dim NodeTbl As New DataTable
        GetTbl("select Sector from PO group by Sector  order by Sector", NodeTbl, "0000&H")
        For tt = 0 To NodeTbl.Rows.Count - 1
            TreeView1.Nodes.Add(NodeTbl.Rows(tt).Item(0), NodeTbl.Rows(tt).Item(0), 0)
        Next
        NodeTbl.Rows.Clear()
        NodeTbl.Columns.Clear()
        GetTbl("select Area,Sector from PO group by Area,Sector order by Area", NodeTbl, "0000&H")
        Dim TempNode() As TreeNode
        For hh = 0 To NodeTbl.Rows.Count - 1
            TempNode = TreeView1.Nodes.Find(NodeTbl(hh).Item(1), True)
            TempNode(0).ForeColor = Color.Green
            TempNode(0).NodeFont = New Font("Times New Roman", 14, FontStyle.Bold)
            If TempNode.Length > 0 Then TempNode(0).Nodes.Add(NodeTbl(hh).Item(0), NodeTbl(hh).Item(0), 1)
        Next
        NodeTbl.Rows.Clear()
        NodeTbl.Columns.Clear()
        GetTbl("select PostOffice,Area from PO group by PostOffice,Area order by PostOffice", NodeTbl, "0000&H")
        For hh = 0 To NodeTbl.Rows.Count - 1
            TempNode = TreeView1.Nodes.Find(NodeTbl(hh).Item(1), True)
            TempNode(0).ForeColor = Color.Blue
            TempNode(0).NodeFont = New Font("Times New Roman", 12, FontStyle.Regular)
            If TempNode.Length > 0 Then TempNode(0).Nodes.Add(NodeTbl(hh).Item(0), NodeTbl(hh).Item(0), 2)
        Next
        Fillll()
        Filtr_()
        Colr()
        DataGridView1.Columns(0).Visible = False
        Button1.Visible = False
        AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
    End Sub
    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
        Filtr_()
        Colr()
    End Sub
    Private Sub Colr()
        For ff = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(ff).Cells(6).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(6).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(7).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(7).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(8).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(8).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(9).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(9).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(10).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(10).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(11).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(11).Style.ForeColor = Color.Green
            End If
            If DataGridView1.Rows(ff).Cells(12).Value = "✔" Then
                DataGridView1.Rows(ff).Cells(12).Style.ForeColor = Color.Green
            End If
        Next
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        Colr()
    End Sub
    Private Sub Fillll()
        tbl.Rows.Clear()
        tbl.Columns.Clear()
        GetTbl("SELECT [ID] 
               ,[Sector] As [القطاع]
               ,[Area] As [المنطقة]
               ,[PostOffice] As [اسم المكتب]
               ,[WorkingTime] As [مواعيد العمل]
               ,[DaysOff] As [أيام الأجازة]
               ,CASE WHEN [EMS] = 1 THEN N'✔' ELSE N'' END AS [البريد السريع]
               , CASE WHEN [ExpressParcel] = 1 THEN N'✔' ELSE N'' END AS [Express Parcel]
               , CASE WHEN [ATM] = 1 THEN N'✔' ELSE N'' END AS [ATM]
               , CASE WHEN [Transfer] = 1 THEN N'✔' ELSE N'' END AS [حوالات فورية]
               , CASE WHEN [RecivedTransferIFS] = 1 THEN N'✔' ELSE N'' END AS [استقبال حوالات دولية]
               , CASE WHEN [CivilStatusServices] = 1 THEN N'✔' ELSE N'' END AS [الأحوال المدنية]
               , CASE WHEN [RS] = 1 THEN N'✔' ELSE N'' END AS [الشهر العقاري]
               ,[Address] As [العنوان]
               ,[Notes] As [ملاحظات]
               ,[PostalCode] As [الرمز البريدي]
               ,[FinancialCode] As [كود مالي]
            from PO order by Sector, Area, PostOffice", tbl, "0000&H")
        DataGridView1.DataSource = tbl
        For ff = 0 To DataGridView1.Columns.Count - 1
            If ff >= 6 And ff <= 12 Then
                DataGridView1.Columns(ff).DefaultCellStyle.Font = New Font("Times New Roman", 16, FontStyle.Bold)
            Else
                DataGridView1.Columns(ff).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            End If
            DataGridView1.Columns(ff).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        Next
        Colr()
    End Sub
    Private Sub Filtr_()
        Dim FltrStr As String = ""
        If txtSearch.TextLength > 0 Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And [اسم المكتب] like '%" & txtSearch.Text & "%'  or   [العنوان] Like'%" & txtSearch.Text & "%' "
            Else
                FltrStr = "[اسم المكتب] like '%" & txtSearch.Text & "%'  or   [العنوان] Like'%" & txtSearch.Text & "%' "
            End If
        End If
        If ChckEMS.Checked = True Then
            ChckEMS.ForeColor = Color.Green
            ChckEMS.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [البريد السريع] = " & "'✔'"
            Else
                FltrStr = "[البريد السريع] = " & "'✔'"
            End If
        Else
            ChckEMS.ForeColor = Color.Black
            ChckEMS.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckEMS.Refresh()
        If ChckEXP.Checked = True Then
            ChckEXP.ForeColor = Color.Green
            ChckEXP.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [Express Parcel] = " & "'✔'"
            Else
                FltrStr = "[Express Parcel] = " & "'✔'"
            End If
        Else
            ChckEXP.ForeColor = Color.Black
            ChckEXP.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckEXP.Refresh()
        If ChckATM.Checked = True Then
            ChckATM.ForeColor = Color.Green
            ChckATM.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [ATM] = " & "'✔'"
            Else
                FltrStr = "[ATM] = " & "'✔'"
            End If
        Else
            ChckATM.ForeColor = Color.Black
            ChckATM.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckATM.Refresh()
        If ChckTrnsf.Checked = True Then
            ChckTrnsf.ForeColor = Color.Green
            ChckTrnsf.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [حوالات فورية] = " & "'✔'"
            Else
                FltrStr = "[حوالات فورية] = " & "'✔'"
            End If
        Else
            ChckTrnsf.ForeColor = Color.Black
            ChckTrnsf.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckTrnsf.Refresh()
        If ChckTrnReciv.Checked = True Then
            ChckTrnReciv.ForeColor = Color.Green
            ChckTrnReciv.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [استقبال حوالات دولية] = " & "'✔'"
            Else
                FltrStr = "[استقبال حوالات دولية] = " & "'✔'"
            End If
        Else
            ChckTrnReciv.ForeColor = Color.Black
            ChckTrnReciv.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckTrnReciv.Refresh()
        If ChckCivil.Checked = True Then
            ChckCivil.ForeColor = Color.Green
            ChckCivil.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            If FltrStr.Length > 0 Then
                FltrStr &= " And [الأحوال المدنية] = " & "'✔'"
            Else
                FltrStr = "[الأحوال المدنية] = " & "'✔'"
            End If
        Else
            ChckCivil.ForeColor = Color.Black
            ChckCivil.Font = New Font("Times New Roman", 10, FontStyle.Regular)
        End If
        ChckCivil.Refresh()
        If IsNothing(TreeView1.SelectedNode) = False Then
            If TreeView1.SelectedNode.Level = 0 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " And [القطاع] = '" & TreeView1.SelectedNode.Name & "'"
                Else
                    FltrStr = " [القطاع] = '" & TreeView1.SelectedNode.Name & "'"
                End If
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " And [المنطقة] = '" & TreeView1.SelectedNode.Name & "'"
                Else
                    FltrStr = " [المنطقة] = '" & TreeView1.SelectedNode.Name & "'"
                End If
            ElseIf TreeView1.SelectedNode.Level = 2 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " And [اسم المكتب] = '" & TreeView1.SelectedNode.Name & "'"
                Else
                    FltrStr = " [اسم المكتب] = '" & TreeView1.SelectedNode.Name & "'"
                End If
            End If
        End If
        If FltrStr.Length > 0 Then
            tbl.DefaultView.RowFilter = FltrStr
        Else
            tbl.DefaultView.RowFilter = String.Empty
        End If
        Label1.Text = "نتيجة البحث : " & tbl.DefaultView.Count.ToString("N0")
        Label1.Refresh()
        'tbl.DefaultView.RowFilter = " [PostOffice] Like'%" & txtSearch.Text & "%'  or  [Address] Like'%" & txtSearch.Text & "%' "
    End Sub
    Private Sub ChckEMS_CheckedChanged(sender As Object, e As EventArgs) Handles ChckEMS.CheckedChanged, ChckEXP.CheckedChanged, ChckATM.CheckedChanged, ChckTrnsf.CheckedChanged, ChckTrnReciv.CheckedChanged, ChckCivil.CheckedChanged
        Filtr_()
        Colr()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TreeView1.SelectedNode = Nothing
        Button1.Visible = False
        Filtr_()
        Colr()
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Filtr_()
        Colr()
        Button1.Visible = True
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TreeView1.ExpandAll()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TreeView1.CollapseAll()
    End Sub
End Class