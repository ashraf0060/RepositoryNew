Public Class HeldPaprNtf
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    Dim rwindx As Integer = 0
    Dim Ntf1 As Integer = 0
    Dim NTF2 As Integer = 0
    Dim NTF3 As Integer = 0
    'Dim sqlCon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=ntf;Password=@asdasdasd123321") ' I Have assigned conn STR here and delete this row from all project
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    Private Sub HeldPhPool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
        Me.GridHeld.Width = Me.Size.Width - 30
        Me.GridHeld.Height = Me.Size.Height - 200
        CloseBtn.Location = New Point(Me.Width - 80, CloseBtn.Location.Y)
        RdioPaperAll.Checked = True
        FilPhPool()
    End Sub
    Private Sub BtnDoNtf_Click(sender As Object, e As EventArgs) Handles BtnDoNtf.Click
        Rslt = MessageBox.Show("سيتم عمل عدد " & GridHeld.Rows.Count & vbNewLine & "                                " & Ntf1 & " إخطار أول" & vbNewLine & "                                " & NTF2 & " إخطار ثاني" & vbNewLine & "                                " & NTF3 & " إخطار ثالث" & vbNewLine & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        If Rslt = DialogResult.Yes Then
            Ntf1 = 0
            NTF2 = 0
            NTF3 = 0
            RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
            AddHandler GridHeld.SelectionChanged, AddressOf Ntf_SelectionChanged
            BtnDoNtf.Enabled = False
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            Tran = sqlCon.BeginTransaction()
            Try
                For rwindx = 0 To GridHeld.Rows.Count - 1
                    Dim PhnTyp As String = ""
                    Dim RsvStr As String = ""
                    Dim RsvUpStr As String = ""
                    If GridHeld.Rows(rwindx).Cells(7).Value = 0 Then
                        Ntf1 += 1
                        PhnTyp = "insert into RsvAd (RsvAdReln, RsvAdNo, RsvAdEmpNm, RsvType) VALUES (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'الأول'," & Usr.PUsrID & ",'" & 1 & "')"
                        RsvStr = "update rsv set RsvType = 1, Rsv_ad_Date = (Select GetDate()), Rsv_Days = 0, Phonefailure = 0 where Rsv.RsvID = " & GridHeld.Rows(rwindx).Cells(0).Value
                        RsvUpStr = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'" & "تم عمل الإخطار الورقي الأول" & "','" & OsIP() & "'," & Usr.PUsrID & ")"
                    ElseIf GridHeld.Rows(rwindx).Cells(7).Value = 1 Then
                        NTF2 += 1
                        PhnTyp = "insert into RsvAd (RsvAdReln, RsvAdNo, RsvAdEmpNm, RsvType) VALUES (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'الثاني'," & Usr.PUsrID & ",'" & 1 & "')"
                        RsvStr = "update rsv set RsvType = 2, RsvPHN = 0, Rsv_ad_Date = (Select GetDate()), Rsv_Days = 0, Phonefailure = 0 where Rsv.RsvID = " & GridHeld.Rows(rwindx).Cells(0).Value
                        RsvUpStr = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'" & "تم عمل الإخطار الورقي الثاني" & "','" & OsIP() & "'," & Usr.PUsrID & ")"
                    ElseIf GridHeld.Rows(rwindx).Cells(7).Value = 2 Then
                        NTF3 += 1
                        PhnTyp = "insert into RsvAd (RsvAdReln, RsvAdNo, RsvAdEmpNm, RsvType) VALUES ('" & GridHeld.Rows(rwindx).Cells(0).Value & "','الثالث','" & Usr.PUsrID & "','" & 1 & "')"
                        RsvStr = "update rsv set RsvType = 3, Rsv_ad_Date = (Select GetDate()), Rsv_Days = 0, Phonefailure = 0 where Rsv.RsvID = " & GridHeld.Rows(rwindx).Cells(0).Value
                        RsvUpStr = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'" & "تم عمل الإخطار الورقي الثالث" & "','" & OsIP() & "'," & Usr.PUsrID & ")"
                    End If
                    sqlComminsert_1.Connection = sqlCon
                    sqlComminsert_2.Connection = sqlCon
                    sqlComminsert_3.Connection = sqlCon
                    sqlComminsert_1.CommandType = CommandType.Text
                    sqlComminsert_2.CommandType = CommandType.Text
                    sqlComminsert_3.CommandType = CommandType.Text
                    sqlComminsert_1.CommandText = RsvUpStr
                    sqlComminsert_2.CommandText = PhnTyp
                    sqlComminsert_3.CommandText = RsvStr
                    sqlComminsert_1.Transaction = Tran
                    sqlComminsert_2.Transaction = Tran
                    sqlComminsert_3.Transaction = Tran
                    sqlComminsert_1.ExecuteNonQuery()
                    sqlComminsert_2.ExecuteNonQuery()
                    sqlComminsert_3.ExecuteNonQuery()

                    If GridHeld.Rows.Count > 0 Then
                        LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                    Else
                        LblMsg.Text = ""
                    End If
                    If GridHeld.Rows.Count = 0 Then
                        Me.BackColor = Color.White
                    End If
                    If rwindx > 1 Then GridHeld.Rows(rwindx - 1).Selected = False
                    GridHeld.Rows(rwindx).Selected = True
                    GridHeld.Rows(rwindx).DefaultCellStyle.ForeColor = Color.Green
                    If rwindx > 0 Then GridHeld.FirstDisplayedScrollingRowIndex = rwindx - 1
                Next rwindx
                Tran.Commit()
                MsgInf("تم عمل عدد " & GridHeld.Rows.Count & vbNewLine & "                                " & Ntf1 & " إخطار أول" & vbNewLine & "                                " & NTF2 & " إخطار ثاني" & vbNewLine & "                                " & NTF3 & " إخطار ثالث")
                HeldTable.Rows.Clear()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)
                AppLog("0000&H", ex.Message, "" & "_" & "")
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            End Try
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            BtnDoNtf.Enabled = True
            RemoveHandler GridHeld.SelectionChanged, AddressOf Ntf_SelectionChanged
            AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        End If
    End Sub
    Private Sub FilPhPool()
        RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        Dim column As New DataGridViewButtonColumn()
        Dim Str As String = ""
        With column
            .Name = "استبعاد"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Popup
            .Text = "استبعاد"
        End With
        Ntf1 = 0
        NTF2 = 0
        NTF3 = 0

        GridHeld.DataSource = ""
        GridHeld.Columns.Clear()

        If RdioPaprOnly.Checked = True Then
            Str = "SELECT RsvID, RsvNo, RsvTracing, CounNm, RsvConsignee, RsvMob, RsvAdd, RsvType, RsvType1, RsvOut, RsvDate, RsvDoc
                                       FROM dbo.Notification
                                       WHERE (((RsvMob) Is Null Or (RsvMob)='0')) OR ((Not (RsvMob) Is Null And (RsvMob)<>'0') AND ((RsvType)=2) AND ((Phonefailure)=0)) ORDER BY RsvID"
        ElseIf RdioAftrPh.Checked = True Then
            Str = "SELECT RsvID, RsvNo, RsvTracing, CounNm, RsvConsignee, RsvMob, RsvAdd, RsvType, RsvType1, RsvOut, RsvDate, RsvDoc
                                       FROM dbo.Notification
                                       WHERE (Phonefailure = 1) ORDER BY RsvDate"
        ElseIf RdioPaperAll.Checked = True Then
            Str = "SELECT RsvID, RsvNo, RsvTracing, CounNm, RsvConsignee, RsvMob, RsvAdd, RsvType, RsvType1, RsvOut, RsvDate, RsvDoc
                                       FROM dbo.Notification
                                       WHERE (((RsvMob) Is Null Or (RsvMob)='0')) OR ((Not (RsvMob) Is Null And (RsvMob)<>'0') AND ((RsvType)=2) AND ((Phonefailure)=0) or (Phonefailure)=1) ORDER BY RsvID"
        End If


        HeldTable.Rows.Clear()
        HeldTable.Columns.Clear()
        If GetTbl(Str, HeldTable, "0000&H") = Nothing Then
            GridHeld.DataSource = HeldTable
            GridHeld.Columns.Add(column)
            For pp = 0 To GridHeld.Rows.Count - 1
                If GridHeld.Rows(pp).Cells(7).Value = 0 Then
                    Ntf1 += 1
                    GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.White
                ElseIf GridHeld.Rows(pp).Cells(7).Value = 1 Then
                    NTF2 += 1
                    GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AliceBlue
                ElseIf GridHeld.Rows(pp).Cells(7).Value = 2 Then
                    NTF3 += 1
                    GridHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AntiqueWhite
                End If

                GridHeld.Rows(pp).Cells(12).Value = "استبعاد"
            Next
            If GridHeld.Rows.Count > 0 Then
                If GridHeld.SelectedCells.Count > 0 Then
                    GridHeld.Rows(0).Selected = True
                    LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                    LblMsg.Refresh()
                End If
            Else
                LblMsg.Text = ""
            End If

            GridPopulte()
            AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If



        'Catch ex As Exception
        '    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        'End Try
    End Sub
    Private Sub GridPopulte()
        'RsvID, RsvNo, RsvTracing,  CounNm, RsvConsignee, RsvMob, RsvAdd, RsvType, RsvType1, RsvOut, RsvDate, RsvDoc
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).Visible = False
        GridHeld.Columns(1).Visible = False
        GridHeld.Columns(2).HeaderText = "رقم الشحنة"
        GridHeld.Columns(3).HeaderText = "بلد المنشأ"
        GridHeld.Columns(4).HeaderText = "اسم العميل"
        GridHeld.Columns(5).HeaderText = "رقم التليفون"
        GridHeld.Columns(6).HeaderText = "عنوان العميل"
        GridHeld.Columns(7).HeaderText = "عدد الإخطارات"
        GridHeld.Columns(8).Visible = False
        GridHeld.Columns(9).Visible = False
        GridHeld.Columns(10).HeaderText = "تاريخ الحجز"
        GridHeld.Columns(11).HeaderText = "المطلوب"
        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridHeld.AutoResizeColumns()
        GridHeld.Columns(6).Width = 300
        GridHeld.Columns(11).Width = 400

        For yy = 0 To GridHeld.Columns.Count - 1
            GridHeld.Columns(yy).ReadOnly = True
            GridHeld.Columns(yy).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        GridHeld.Columns(0).ReadOnly = False
        GridHeld.Columns(9).ReadOnly = False
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs)
        If GridHeld.Rows.Count > 0 Then
            LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
        Else
            LblMsg.Text = ""
        End If
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
    Private Sub GridPHHeld_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridHeld.CellClick
        If GridHeld.Columns(e.ColumnIndex).Name = "استبعاد" Then
            Rslt = MessageBox.Show("سيتم استبعاد الشحنة رقم " & GridHeld.CurrentRow.Cells(2).Value & " باسم " & GridHeld.CurrentRow.Cells(4).Value, "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            If Rslt = DialogResult.Yes Then
                sqlComminsert_1.Connection = sqlCon
                sqlComminsert_2.Connection = sqlCon
                sqlComminsert_1.CommandType = CommandType.Text
                sqlComminsert_2.CommandType = CommandType.Text
                sqlComminsert_1.CommandText = "UPDATE Rsv SET Rsv.RsvOut = 1 WHERE (Rsv.RsvID= " & GridHeld.CurrentRow.Cells(0).Value & ");"
                sqlComminsert_2.CommandText = "INSERT INTO RsvUpdate (RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) Values 
                                        (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & "تم استبعاد الشحنة من منظومة الإخطارات لعدم اكتمال البيانات المطلوبة" & "'," & Usr.PUsrID & "," & 1 & ",'" & OsIP() & "')"
                Try
                    If sqlCon.State = ConnectionState.Closed Then
                        sqlCon.Open()
                    End If
                    Tran = sqlCon.BeginTransaction()
                    sqlComminsert_1.Transaction = Tran
                    sqlComminsert_2.Transaction = Tran
                    sqlComminsert_1.ExecuteNonQuery()
                    sqlComminsert_2.ExecuteNonQuery()
                    Tran.Commit()
                    If GridHeld.CurrentRow.Cells(7).Value = 0 Then
                        Ntf1 -= 1
                    ElseIf GridHeld.CurrentRow.Cells(7).Value = 1 Then
                        NTF2 -= 1
                    ElseIf GridHeld.CurrentRow.Cells(7).Value = 2 Then
                        NTF3 -= 1
                    End If
                    GridHeld.Rows.RemoveAt(GridHeld.CurrentRow.Index)
                Catch ex As Exception
                    Tran.Rollback()
                    MsgErr(ex.Message)
                End Try
                'sqlCon.Close()
                'SqlConnection.ClearPool(sqlCon)
            End If
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub RdioPapr_Click(sender As Object, e As EventArgs) Handles RdioPaprOnly.Click, RdioAftrPh.Click, RdioPaperAll.Click
        FilPhPool()
    End Sub
End Class