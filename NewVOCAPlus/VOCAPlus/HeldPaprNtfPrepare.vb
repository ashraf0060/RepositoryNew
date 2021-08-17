Public Class HeldPaprNtfPrepare
    Dim HeldTable As DataTable = New DataTable
    Dim rwindx As Integer = 0
    Dim Ntf1 As Integer = 0
    Dim NTF2 As Integer = 0
    Dim NTF3 As Integer = 0
    'Dim sqlCon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=ntf;Password=@asdasdasd123321") ' I Have assigned conn STR here and delete this row from all project
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub HeldPhPool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RdioPaperAll.Checked = True
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()

        If GetTbl("SELECT MAX(RsvAdDate) AS MaxDt FROM RsvAd", tempTable, "0000&H") = Nothing Then
            DateTimePicker1.MaxDate = tempTable.Rows(0).Item(0)
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("SELECT MIN(RsvAdDate) AS MinDt FROM RsvAd", tempTable, "0000&H") = Nothing Then
                DateTimePicker1.MinDate = tempTable.Rows(0).Item(0)
                If Format(ServrTime(), "yyyy/MM/dd") <= DateTimePicker1.MaxDate Then
                    DateTimePicker1.Value = Format(ServrTime(), "yyyy/MM/dd")
                Else
                    DateTimePicker1.Value = DateTimePicker1.MaxDate
                End If
                GridHeld.Width = Me.Width - 50
                CloseBtn.Location = New Point(Me.Width - 80, CloseBtn.Location.Y)
                FilPhPool()
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If


        'AddHandler GridPHHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
    End Sub
    Private Sub FilPhPool()
        RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        GridHeld.Visible = False
        Dim Str As String = ""
        Ntf1 = 0
        NTF2 = 0
        NTF3 = 0
        If RdioPapPrnt.Checked = True Then
            Str = "select RsvAdID, RsvAdReln, format(RsvAd.RsvAdDate,'yyyy/MM/dd') As RsvAdDate, RsvAdTrk, RsvAdNo, (SELECT UsrRealNm FROM Int_user WHERE RsvAdEmpNm = UsrId) AS USRNm, RsvAd.RsvAdPrint,(select RSV.RsvConsignee FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvConsignee,(select RSV.RsvAdd FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvAdd,(select RSV.RsvTracing FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvTracing,(select RSV.RsvID FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvID
                                        from RsvAd where (format(RsvAd.RsvAdDate,'yyyy/MM/dd') = '" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & "') and (RsvAd.RsvType = 1) and (RsvAd.RsvAdPrint = 1) order by RsvAdReln"
            Button2.Enabled = False
        ElseIf RdioPapNoPrnt.Checked = True Then
            Str = "select RsvAdID, RsvAdReln, format(RsvAd.RsvAdDate,'yyyy/MM/dd') As RsvAdDate, RsvAdTrk, RsvAdNo, (SELECT UsrRealNm FROM Int_user WHERE RsvAdEmpNm = UsrId) AS USRNm, RsvAd.RsvAdPrint,(select RSV.RsvConsignee FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvConsignee,(select RSV.RsvAdd FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvAdd,(select RSV.RsvTracing FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvTracing,(select RSV.RsvID FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvID
                                        from RsvAd where (format(RsvAd.RsvAdDate,'yyyy/MM/dd') = '" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & "') and (RsvAd.RsvType = 1) and (RsvAd.RsvAdPrint = 0) order by RsvAdReln"
            Button2.Enabled = True
        ElseIf RdioPaperAll.Checked = True Then
            Str = "select RsvAdID, RsvAdReln, format(RsvAd.RsvAdDate,'yyyy/MM/dd') As RsvAdDate, RsvAdTrk, RsvAdNo, (SELECT UsrRealNm FROM Int_user WHERE RsvAdEmpNm = UsrId) AS USRNm, RsvAd.RsvAdPrint,(select RSV.RsvConsignee FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvConsignee,(select RSV.RsvAdd FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvAdd,(select RSV.RsvTracing FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvTracing,(select RSV.RsvID FROM RSV WHERE RSV.RsvID = RsvAd.RsvAdReln) AS RsvID
                                        from RsvAd where (format(RsvAd.RsvAdDate,'yyyy/MM/dd') = '" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & "') and (RsvAd.RsvType = 1) order by RsvAdReln"
            Button2.Enabled = False
        End If
        LblLoad.Visible = True
        Me.Text = "جاري تحميل البيانات ......."
        LblLoad.Text = "جاري تحميل البيانات ......."
        LblLoad.Refresh()
        sqlComminsert_1.Connection = sqlCon
        sqlComminsert_1.CommandType = CommandType.Text
        sqlComminsert_1.CommandText = Str
        Try
            SQLTblAdptr.SelectCommand = sqlComminsert_1
            HeldTable.Rows.Clear()
            HeldTable.Columns.Clear()
            SQLTblAdptr.Fill(HeldTable)
            GridHeld.DataSource = HeldTable
            sqlCon.Close()
            If HeldTable.Rows.Count > 0 Then
                AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
                GridHeld.Visible = True
                For pp = 0 To GridHeld.Rows.Count - 1
                    If GridHeld.Rows(pp).Cells(4).Value = "الأول" Then
                        Ntf1 += 1
                        GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.White
                    ElseIf GridHeld.Rows(pp).Cells(4).Value = "الثاني" Then
                        NTF2 += 1
                        GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AliceBlue
                    ElseIf GridHeld.Rows(pp).Cells(4).Value = "الثالث" Then
                        NTF3 += 1
                        GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AntiqueWhite
                    End If

                Next
                LblLoad.Visible = False
            Else
                LblLoad.Text = "لا توجد بيانات للعرض"
                LblLoad.Refresh()
            End If

            Me.Text = "تجهيز الإخطارات : " & GridHeld.Rows.Count & " ( " & Ntf1 & " إخطار أول " & "- " & NTF2 & " إخطار ثاني " & "- " & NTF3 & " إخطار ثالث )"
            If GridHeld.SelectedCells.Count > 0 Then
                GridHeld.Rows(0).Selected = True
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
            End If
            GridPopulte()
        Catch ex As Exception
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try

    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).HeaderText = "ID"
        GridHeld.Columns(1).Visible = False
        GridHeld.Columns(2).HeaderText = "تاريخ الإخطار"
        GridHeld.Columns(3).HeaderText = "Track No."
        GridHeld.Columns(4).HeaderText = "رقم الإخطار"
        GridHeld.Columns(5).HeaderText = "محرر الإخطار"
        GridHeld.Columns(6).Visible = False
        GridHeld.Columns(7).HeaderText = "المرسل إلية"
        GridHeld.Columns(8).HeaderText = "عنوان العميل"
        GridHeld.Columns(9).HeaderText = "رقم الشحنة"
        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridHeld.AutoResizeColumns()
        GridHeld.Columns(7).Width = 200
        GridHeld.Columns(8).Width = 300
        For yy = 0 To GridHeld.Columns.Count - 1
            GridHeld.Columns(yy).ReadOnly = True
            GridHeld.Columns(yy).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        GridHeld.Columns(3).ReadOnly = False
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs)
        LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
        LblMsg.Refresh()
    End Sub
    Private Sub Ntf_SelectionChanged(sender As Object, e As EventArgs)
        If GridHeld.Rows.Count > 0 Then
            LblMsg.Text = GridHeld.Rows(rwindx).Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
        Else
            LblMsg.Text = 0 & " Of " & 0
            LblMsg.Refresh()
        End If

    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        'AddHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged   
        FilPhPool()
        'Call DateTimePicker1_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub DateTimePicker1_Enter(sender As Object, e As EventArgs) Handles DateTimePicker1.MouseEnter
        'RemoveHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thisBuilder As SqlCommandBuilder = New SqlCommandBuilder(SQLTblAdptr)
        SQLTblAdptr.SelectCommand = sqlComminsert_1
        SQLTblAdptr.Update(HeldTable)
        Button1.Enabled = False
    End Sub
    Private Sub TxtTrck_TextChanged(sender As Object, e As EventArgs) Handles TxtTrck.TextChanged
        If TxtTrck.TextLength = 15 Then
            If Mid(TxtTrck.Text, 1, 1).CompareTo("[A-Z][a-z]*") = 1 And Mid(TxtTrck.Text, 2, 1).CompareTo("[A-Z][a-z]*") = 1 And Mid(TxtTrck.Text, 4, 9).CompareTo("[0-9]*") = 1 And Mid(TxtTrck.Text, 14, 1).CompareTo("[A-Z][a-z]*") = 1 And Mid(TxtTrck.Text, 15, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                If (Trim(UCase(Mid(TxtTrck.Text, 1, 2))) & Trim(Mid(TxtTrck.Text, 4, 9)) & Trim(UCase(Mid(TxtTrck.Text, 14, 2)))).ToString.Length = 13 Then
                    GridHeld.Rows(GridHeld.CurrentRow.Index).Cells(3).Value = Trim(UCase(Mid(TxtTrck.Text, 1, 2))) & Trim(Mid(TxtTrck.Text, 4, 9)) & Trim(UCase(Mid(TxtTrck.Text, 14, 2)))
                    TxtTrck.Text = ""
                    SendKeys.Send("{BACKSPACE}")
                    If GridHeld.CurrentRow.Index < GridHeld.Rows.Count - 1 Then
                        GridHeld.CurrentCell = GridHeld.Rows(GridHeld.CurrentCell.RowIndex + 1).Cells(GridHeld.CurrentCell.ColumnIndex)
                    ElseIf GridHeld.CurrentRow.Index = GridHeld.Rows.Count - 1 Then
                        'SendKeys.Send("{UP}")
                        GridHeld.CurrentCell = GridHeld.Rows(GridHeld.CurrentCell.RowIndex - 1).Cells(GridHeld.CurrentCell.ColumnIndex)
                        GridHeld.CurrentCell = GridHeld.Rows(GridHeld.CurrentCell.RowIndex + 1).Cells(GridHeld.CurrentCell.ColumnIndex)
                        MsgInf("لقد وصلت لآخر إخطار")
                        TxtTrck.ReadOnly = True
                    End If
                End If

            End If
        End If
    End Sub
    Private Sub RdioPapr_Click(sender As Object, e As EventArgs) Handles RdioPapPrnt.Click, RdioPapNoPrnt.Click, RdioPaperAll.Click
        FilPhPool()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        For UU = 0 To GridHeld.Rows.Count - 1
            If InsUpd("insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.Rows(UU).Cells(10).Value & ",'" & "تم طباعة الإخطار تمهيداً لإرسالة" & "','" & OsIP() & "'," & Usr.PUsrID & ")", "0000&H") = Nothing Then
                GridHeld.Rows(UU).Cells(6).Value = True
                GridHeld.CurrentCell = GridHeld.Rows(UU).Cells(5)
                GridHeld.UpdateCellValue(6, UU)
                GridHeld.EndEdit()
            Else
                MsgErr(My.Resources.ConnErr & vbNewLine & My.Resources.TryAgain)
            End If
        Next
        Dim thisBuilder As SqlCommandBuilder = New SqlCommandBuilder(SQLTblAdptr)
        SQLTblAdptr.SelectCommand = sqlComminsert_1
        SQLTblAdptr.Update(HeldTable)
        Button1.Enabled = False
        Button2.Enabled = False
    End Sub
End Class