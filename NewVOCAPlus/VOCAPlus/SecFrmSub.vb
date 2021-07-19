Public Class SecFrmSub
    Dim SwichItemTable As DataTable = New DataTable
    Dim SwichUsrsTable As DataTable = New DataTable
    Dim UsrCatTable As DataTable = New DataTable
    Dim primaryKey(0) As DataColumn
    Private Sub SecFrmSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'where SwType = 'Tab' or SwType = 'tabMn'
        'SELECT CatLvId, CatLvNm FROM IntUserCatLvCD

        SwichItemTable.Rows.Clear()
        GetTbl("select SwID, SwNm, SwType from ASwitchboard order by SwSer, SwID", SwichItemTable, "0000&H")


        UsrCatTable.Rows.Clear()
        GetTbl("SELECT CatLvId, CatLvNm FROM IntUserCatLvCD", UsrCatTable, "0000&H")

        ComboBox1.DataSource = UsrCatTable
        ComboBox1.DisplayMember = "CatLvNm"
        ComboBox1.ValueMember = "CatLvId"
        primaryKey(0) = UsrCatTable.Columns("SwID")
        UsrCatTable.PrimaryKey = primaryKey

        If ComboBox1.ValueMember = "CatLvId" Then
            SwichUsrsTable.Rows.Clear()
            GetTbl("SELECT UsrId, UsrNm, UsrLevel, UCatLvl, UsrSusp FROM Int_user INNER JOIN IntUserCat ON UsrCat = UCatId  where UCatLvl = " & ComboBox1.SelectedValue, SwichUsrsTable, "0000&H")
            DataGridView1.DataSource = SwichUsrsTable
            SwichUsrsTable.Columns.Add("New")
            DataGridView1.Columns(5).Width = 300
        End If

        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        SwichUsrsTable.Rows.Clear()
        GetTbl("SELECT UsrId, UsrNm, UsrLevel, UCatLvl, UsrSusp FROM Int_user INNER JOIN IntUserCat ON UsrCat = UCatId  where UCatLvl = " & ComboBox1.SelectedValue, SwichUsrsTable, "0000&H")
        For fff = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(fff).Cells(5).Value = ""
            For Cnt_ = 0 To SwichItemTable.Rows.Count - 1
                If Mid(DataGridView1.Rows(fff).Cells(2).Value, SwichItemTable.Rows(Cnt_).Item(0), 1) = "A" Then
                    If SwichItemTable.Rows(Cnt_).Item(2) = "Tab" Then
                        DataGridView1.Rows(fff).Cells(5).Value += vbCrLf & vbCrLf & "قائمة " & SwichItemTable.Rows(Cnt_).Item(1) & ":" & vbCrLf
                    Else
                        DataGridView1.Rows(fff).Cells(5).Value += SwichItemTable.Rows(Cnt_).Item(1) & " - "
                    End If

                End If

            Next
            If DataGridView1.Rows(fff).Cells(4).Value = True Then
                DataGridView1.Rows(fff).DefaultCellStyle.ForeColor = Color.Red
            Else
                DataGridView1.Rows(fff).DefaultCellStyle.ForeColor = Color.Green
            End If
        Next
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.AutoResizeRows()
        DataGridView1.AutoResizeColumns()
        'SwichUsrsTable.Rows.Clear()
        'If SwichItemTable.Rows.Count > 0 Then
        '    GetTbl("select usrid, UsrRealNm, UsrGender, UsrSusp from Int_user where SUBSTRING(UsrLevel," & ComboBox1.SelectedValue.ToString & ",1) = 'A'", SwichUsrsTable, "0000&H")
        'End If

        'DataGridView1.DataSource = SwichUsrsTable
        'ComboBox1.DisplayMember = "SwNm"
        'ComboBox1.ValueMember = "SwID"
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        If Len(DataGridView1.CurrentCell.Value.ToString) > 0 Then Clipboard.SetText(DataGridView1.CurrentCell.Value)
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'If DataGridView1.SelectedRows.Count > 0 Then
        '    DataGridView1.CurrentRow.Cells(4).Value = ""
        '    For Cnt_ = 0 To DataGridView2.Rows.Count - 1
        '        If Mid(DataGridView1.CurrentRow.Cells(2).Value, DataGridView2.Rows(Cnt_).Cells(0).Value, 1) = "A" Then
        '            If DataGridView2.Rows(Cnt_).Cells(2).Value = "Tab" Then DataGridView1.CurrentRow.Cells(4).Value += vbCrLf
        '            DataGridView1.CurrentRow.Cells(4).Value += DataGridView2.Rows(Cnt_).Cells(1).Value & " - "
        '        End If
        '    Next



        'For Cnt_ = 0 To DataGridView1.CurrentRow.Cells(2).Value.ToString.Length - 1
        '    If Mid(DataGridView1.CurrentRow.Cells(2).Value, Cnt_ + 1, 1) = "A" Then
        '        Dim MendRw As DataRow = SwichItemTable.Rows.Find(Cnt_ + 1)
        '        DataGridView1.CurrentRow.Cells(4).Value += MendRw.ItemArray(1) & " - "
        '    End If
        'Next

        'End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For fff = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(fff).Cells(4).Value = ""
            For Cnt_ = 0 To SwichItemTable.Rows.Count - 1
                If Mid(DataGridView1.Rows(fff).Cells(2).Value, SwichItemTable.Rows(Cnt_).Item(0), 1) = "A" Then
                    If SwichItemTable.Rows(Cnt_).Item(2) = "Tab" Then
                        DataGridView1.Rows(fff).Cells(4).Value += vbCrLf & vbCrLf & "قائمة " & SwichItemTable.Rows(Cnt_).Item(1) & ":" & vbCrLf
                    Else
                        DataGridView1.Rows(fff).Cells(4).Value += SwichItemTable.Rows(Cnt_).Item(1) & " - "
                    End If

                End If
            Next
        Next
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgInf(DataGridView1.CurrentRow.Cells(4).Value.ToString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(LblSecLvl_)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click
        If LblSecLvl_.Length > 0 Then
            If RadioButton1.Checked = True Then
                InsUpd("Update Int_user set int_user.UsrLevel = '" & LblSecLvl_ & "' where UsrId = " & DataGridView1.CurrentRow.Cells(0).Value, "0000&H")
                RadioButton1.Checked = False
                MsgInf("تم تعديل الصلاحيات لـ " & DataGridView1.CurrentRow.Cells(1).Value)
            ElseIf RadioButton2.Checked = True Then
                For FwV = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(FwV).Cells(4).Value = False Then
                        If InsUpd("Update Int_user set int_user.UsrLevel = '" & LblSecLvl_ & "' where UsrId = " & DataGridView1.Rows(FwV).Cells(0).Value, "0000&H") <> Nothing Then
                            MsgErr(My.Resources.ConnErr & vbNewLine & My.Resources.TryAgain)
                            Exit For
                        End If
                    End If
                Next
                RadioButton2.Checked = False
                MsgInf("تم تعديل الصلاحيات لـ " & ComboBox1.Text)
            ElseIf RadioButton3.Checked = True Then
                For FwV = 0 To DataGridView1.Rows.Count - 1
                    If InsUpd("Update Int_user set int_user.UsrLevel = '" & LblSecLvl_ & "' where UsrId = " & DataGridView1.Rows(FwV).Cells(0).Value, "0000&H") <> Nothing Then
                        MsgErr(My.Resources.ConnErr & vbNewLine & My.Resources.TryAgain)
                        Exit For
                    End If
                Next
                RadioButton3.Checked = False
                MsgInf("تم تعديل الصلاحيات لـ " & ComboBox1.Text)
            End If
        Else
            MsgInf("Please choose the example")
        End If

    End Sub
End Class