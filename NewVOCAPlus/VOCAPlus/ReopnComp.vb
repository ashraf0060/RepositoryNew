Public Class ReopnComp
    Private ReopnTable As DataTable = New DataTable
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub ReopnComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm", True)
        BtnGet.Tag = "تحميل"
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        LblMsg.Text = ""
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtCompId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCompId.KeyPress
        IntUtly.ValdtInt(e)
    End Sub
    Private Sub TxtCompId_TextChanged(sender As Object, e As EventArgs) Handles TxtCompId.TextChanged
        BtnGet.Tag = "تحميل"
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        LblMsg.Text = ""
        TcktImg.BackgroundImage = My.Resources.Empty
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "TxtCompId" Then
                    ctrl.Text = ""
                End If
            End If
        Next
    End Sub
    Private Sub BtnGet_Click(sender As Object, e As EventArgs) Handles BtnGet.Click
        If TxtCompId.TextLength > 0 Then
            BtnGet.Enabled = False
            If BtnGet.Tag = "تحميل" Then
                ReopnTable.Rows.Clear()
                LblMsg.Text = "جاري تحميل البيانات ...."
                LblMsg.ForeColor = Color.Green
                '                   0          1          2         3      4      5      6       7        8         9        10             
                If GetTbl("SELECT TkSQL, TkClsStatus, TkDtStart, TkKind, TkID, TkClNm, PrdNm, CompNm, UsrRealNm, TkClPh, TkDetails FROM TicketsAll WHERE (TkID = " & TxtCompId.Text & ") AND (TkClsStatus = 1) AND (" & MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm", True) & ");", ReopnTable, "1030&H") = Nothing Then
                    If ReopnTable.Rows.Count > 0 Then
                        TxtPh1.Text = ReopnTable(0).Item(9).ToString
                        TxtDt.Text = ReopnTable(0).Item(2).ToString
                        TxtNm.Text = ReopnTable(0).Item(5).ToString
                        TxtDetails.Text = ReopnTable(0).Item(10).ToString
                        TxtProd.Text = ReopnTable(0).Item(6).ToString
                        TxtComp.Text = ReopnTable(0).Item(7).ToString
                        TxtFollNm.Text = ReopnTable(0).Item(8).ToString
                        If ReopnTable(0).Item(3) = 0 Then
                            LblMsg.Text = "لا يمكن إعادة فتح الاستفسار"
                            LblMsg.ForeColor = Color.Red
                            Beep()
                        Else
                            If ReopnTable(0).Item(1) = True Then
                                TcktImg.BackgroundImage = My.Resources.Tckoff
                                BtnGet.Tag = "فتح"
                                BtnGet.BackgroundImage = My.Resources.CpOpen
                                LblMsg.Text = ""
                            Else
                                TcktImg.BackgroundImage = My.Resources.Tckon
                                BtnGet.Tag = "تحميل"
                                LblMsg.Text = "الشكوى رقم " & TxtCompId.Text & " مفتوحة بالفعل"
                                LblMsg.ForeColor = Color.Red
                                Beep()
                            End If

                        End If
                    Else
                        ReopnTable.Rows.Clear()
                        If GetTbl("SELECT TkSQL, TkClsStatus, TkDtStart, TkKind, TkID, TkClNm, PrdNm, CompNm, UsrRealNm, TkClPh, TkDetails FROM TicketsAll WHERE (TkID = " & TxtCompId.Text & ") AND (TkClsStatus = 1)", ReopnTable, "1030&H") = Nothing Then
                            If ReopnTable.Rows.Count > 0 Then
                                LblMsg.Text = "الشكوى لا تخص فريقك - من فضلك تأكد من الرقم الذي قمت بإدخاله"
                                LblMsg.ForeColor = Color.Red
                                Beep()
                            Else
                                LblMsg.Text = "لا توجد شكوى مسجلة بهذا الرقم - الشكوى قد تكون مفتوحة - من فضلك تأكد من الرقم الذي قمت بإدخاله"
                                LblMsg.ForeColor = Color.Red
                                Beep()
                            End If
                        End If
                    End If
                Else
                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End If
            Else
                Dim Rslt As DialogResult
                Rslt = MessageBox.Show("سيتم إعادة فتح الشكوى رقم " & ReopnTable(0).Item(4) & vbCrLf & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    BtnGet.Enabled = False
                    LblMsg.Text = "جاري إعادة فتح الشكوى ...."
                    LblMsg.ForeColor = Color.Green
                    If InsTrans("update Tickets set TkClsStatus = 0, TkDtClose = '', TkReOp = 1 where (TkSQL = " & ReopnTable(0).Item(0) & ");",
                "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & ReopnTable(0).Item(0) & "','" & "The Complaint has been Reopened" & "','" & "1" & "','" & "999" & "','" & OsIP() & "','" & Usr.PUsrID & "')",
                "1031&H") = Nothing Then
                        BtnGet.Tag = "تحميل"
                        BtnGet.Enabled = True
                        BtnGet.BackgroundImage = My.Resources.DbGet
                        LblMsg.Text = "تم إعادة فتح الشكوى رقم " & ReopnTable(0).Item(4) & " بنجاح"
                        LblMsg.ForeColor = Color.Green
                        TcktImg.BackgroundImage = My.Resources.Tckon
                    Else
                        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    End If
                Else
                    BtnGet.Tag = "تحميل"
                    BtnGet.Enabled = True
                    BtnGet.BackgroundImage = My.Resources.DbGet
                    LblMsg.Text = ""
                    TcktImg.BackgroundImage = My.Resources.Empty
                    For Each ctrl As Control In Me.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.Text = ""
                        End If
                    Next
                End If
            End If
        Else
            LblMsg.Text = "يرجى ادخال رقم الشكوى أولا"
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
        BtnGet.Enabled = True
    End Sub

    Private Sub BtnGet_MouseEnter(sender As Object, e As EventArgs) Handles BtnGet.MouseEnter
        ToolTip1.Show(BtnGet.Tag, BtnGet, 0, 20, 500)
    End Sub
End Class