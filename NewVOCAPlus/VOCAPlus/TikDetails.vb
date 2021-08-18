Public Class TikDetails
    Private Sub TikDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If StruGrdTk.FlwStat = True Then
            TcktImg.BackgroundImage = My.Resources.Tckoff
            TcktImg.BackgroundImageLayout = ImageLayout.Stretch
            BtnAddEdt.Enabled = False
            TxtDetailsAdd.Enabled = False
            TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة"
            TxtDetailsAdd.TextAlign = HorizontalAlignment.Center
            TxtDetailsAdd.Font = New Font("Times New Roman", 16, FontStyle.Regular)
            BtnClos.Visible = False
        Else
            TcktImg.BackgroundImage = My.Resources.Tckon
            TcktImg.BackgroundImageLayout = ImageLayout.Stretch
            BtnAddEdt.Enabled = True
            TxtDetailsAdd.Enabled = True
            TxtDetailsAdd.Text = ""
            TxtDetailsAdd.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            TxtDetailsAdd.TextAlign = HorizontalAlignment.Left
            If StruGrdTk.UsrNm = Usr.PUsrRlNm Then
                BtnClos.Visible = True
            Else
                BtnClos.Visible = False
            End If
        End If

        TxtPh1.Text = StruGrdTk.Ph1
        TxtPh2.Text = StruGrdTk.Ph2
        TxtDt.Text = StruGrdTk.DtStrt
        TxtNm.Text = StruGrdTk.ClNm
        TxtAdd.Text = StruGrdTk.Adress
        TxtEmail.Text = StruGrdTk.Email
        TxtDetails.Text = StruGrdTk.Detls
        TxtArea.Text = StruGrdTk.Area
        TxtOff.Text = StruGrdTk.Offic
        TxtProd.Text = StruGrdTk.ProdNm
        TxtComp.Text = StruGrdTk.CompNm
        TxtSrc.Text = StruGrdTk.Src
        TxtTrck.Text = StruGrdTk.Trck
        TxtOrgin.Text = StruGrdTk.Orig
        TxtDist.Text = StruGrdTk.Dist
        TxtCard.Text = StruGrdTk.Card
        TxtGP.Text = StruGrdTk.Gp
        TxtNId.Text = StruGrdTk.NID
        TxtAmount.Text = StruGrdTk.Amnt
        If Year(StruGrdTk.TransDt) < 2000 Then
            TxtTransDt.Text = ""
        Else
            TxtTransDt.Text = StruGrdTk.TransDt
        End If

        TxtFolw.Text = StruGrdTk.UsrNm


        LblWDays.Text = "تم تسجيل الشكوى منذ : " & CalDate(StruGrdTk.DtStrt, Nw, "0000&H") & " يوم عمل"
        If StruGrdTk.ProdK = 1 Then
            GroupBox3.Visible = True
            GroupBox4.Visible = False
        ElseIf StruGrdTk.ProdK = 2 Then
            GroupBox3.Visible = False
            GroupBox4.Visible = True
        Else
            GroupBox3.Visible = False
            GroupBox4.Visible = False
        End If
        LblHelp.Text = StruGrdTk.Help_
        TxtTikID.Text = "شكوى رقم : " & StruGrdTk.Sql
        TxtTikID.RightToLeft = RightToLeft.Yes
        TxtTikID.Font = New Font("Times New Roman", 14, FontStyle.Bold)
        TxtTikID.TextAlign = ContentAlignment.BottomCenter
        SelctSerchTxt(TxtDetails, "تعديل : بواسطة")
    End Sub

    Private Sub BtnAddEdt_Click(sender As Object, e As EventArgs) Handles BtnAddEdt.Click
        If Trim(TxtDetailsAdd.Text).Length > 0 Then
            If InsUpd("update Tickets set TkDetails = '" & TxtDetails.Text & vbCrLf & "تعديل : بواسطة  " & Usr.PUsrRlNm & " في " & ServrTime() & " من خلال IP : " & OsIP() & vbCrLf & TxtDetailsAdd.Text & "' where TkSQL = " & StruGrdTk.Sql, "000&H") = Nothing Then
                TxtDetails.Text &= vbCrLf & "تعديل : بواسطة  " & Usr.PUsrRlNm & " في " & ServrTime() & " من خلال IP : " & OsIP() & vbCrLf & TxtDetailsAdd.Text
                SelctSerchTxt(TxtDetails, "تعديل : بواسطة")
                StruGrdTk.Detls = TxtDetails.Text
                GetPrntrFrm(frm__, gridview_)
                TxtDetailsAdd.Text = ""
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        Else
            MsgInf("يرجى إدخال نص التعديل")
        End If
    End Sub
    Private Sub TikDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TimerVisInvs.Stop()
        Me.Dispose()
    End Sub
    Private Sub TimerVisInvs_Tick(sender As Object, e As EventArgs) Handles TimerVisInvs.Tick
        If LblWDays.Text.Length > 0 Then
            If LblWDays.Visible = True Then
                LblWDays.Visible = False
            Else
                LblWDays.Visible = True
            End If
        End If
    End Sub
    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        TikUpdate.ShowDialog()
    End Sub
    Private Sub BtnClos_Click(sender As Object, e As EventArgs) Handles BtnClos.Click
        Dim Rslt As DialogResult
        Rslt = MessageBox.Show("سيتم إغلاق الشكوى نهائيا" & vbCrLf & "هل تريد الإستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        If Rslt = DialogResult.Yes Then
            BtnClos.Enabled = False
            If InsTrans("update Tickets set TkDtClose = (Select GetDate())" & ", TkDuration = " & CalDate(StruGrdTk.DtStrt, Nw, "1036&H") & ", TkClsStatus = 1" & ", TkFolw = 1" & " where (TkSQL = " & StruGrdTk.Sql & ");",
                    "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" &
                    StruGrdTk.Sql & "','" & "The Complaint has been closed" & "','" & "1" & "','" & "900" & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1037&H") = Nothing Then
                TcktImg.BackgroundImage = My.Resources.Tckoff
                StruGrdTk.ClsStat = True
                BtnClos.BackgroundImage = My.Resources.Tckoff
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                UpdtCurrTbl.DefaultView.RowFilter = "[TkupTkSql]" & " = " & StruGrdTk.Sql
                Dim UpSql As New List(Of String)
                For uu = 0 To UpdtCurrTbl.DefaultView.Count - 1
                    If UpdtCurrTbl.DefaultView(uu).Item("TkupUnread") = False Then
                        UpSql.Add("TkupSQL = " & UpdtCurrTbl.DefaultView(uu).Item("TkupSQL"))
                    Else
                        Exit For
                    End If
                Next
                If UpSql.Count > 0 Then
                    If PublicCode.InsUpd("update TkEvent set TkupUnread = 1, TkupReDt = (Select GetDate())" & " where  " & String.Join(" OR ", UpSql) & ";", "1035&H") = Nothing Then

                    Else
                        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
                    End If
                End If
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                BtnUpd.Visible = False

                Usr.PUsrClsN -= 1   'to don't recieve notification with Ticket count trnasfered to 
                GetPrntrFrm(frm__, gridview_)
                TikFormat(TickTblMain, UpdtCurrTbl, ProgBar)
                BtnAddEdt.Enabled = False
                TxtDetailsAdd.Enabled = False
                TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة"
                TxtDetailsAdd.TextAlign = HorizontalAlignment.Center
                TxtDetailsAdd.Font = New Font("Times New Roman", 16, FontStyle.Regular)
                MsgInf("تم إغلاق الشكوى رقم " & StruGrdTk.TkId & " في عدد " & CalDate(StruGrdTk.DtStrt, CStr(Nw), "1036&H") & " يوم عمل")
            Else
                BtnClos.Enabled = True
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        End If
    End Sub
End Class