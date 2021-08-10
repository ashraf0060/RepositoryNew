Public Class TikDetails
    Private Sub TikDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        If StruGrdTk.FlwStat = True Then
            TcktImg.BackgroundImage = My.Resources.Tckoff
            TcktImg.BackgroundImageLayout = ImageLayout.Stretch
            BtnAddEdt.Enabled = False
            TxtDetailsAdd.Enabled = False
            TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة"
            TxtDetailsAdd.TextAlign = HorizontalAlignment.Center
            TxtDetailsAdd.Font = New Font("Times New Roman", 16, FontStyle.Regular)
        Else
            TcktImg.BackgroundImage = My.Resources.Tckon
            TcktImg.BackgroundImageLayout = ImageLayout.Stretch
            BtnAddEdt.Enabled = True
            TxtDetailsAdd.Enabled = True
            TxtDetailsAdd.Text = ""
            TxtDetailsAdd.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            TxtDetailsAdd.TextAlign = HorizontalAlignment.Left
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

        LblHelp.Text = "تم تسجيل الشكوى منذ : " & CalDate(StruGrdTk.DtStrt, Nw, "0000&H") & " يوم عمل"
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
        LblWDays.Text = StruGrdTk.Help_
        SelctSerchTxt(TxtDetails, "تعديل : بواسطة")
    End Sub

    Private Sub BtnAddEdt_Click(sender As Object, e As EventArgs) Handles BtnAddEdt.Click
        If Trim(TxtDetailsAdd.Text).Length > 0 Then
            If InsUpd("update Tickets set TkDetails = '" & TxtDetails.Text & vbCrLf & "تعديل : بواسطة  " & Usr.PUsrRlNm & " في " & ServrTime() & " من خلال IP : " & OsIP() & vbCrLf & TxtDetailsAdd.Text & "' where TkSQL = " & StruGrdTk.Sql, "000&H") = Nothing Then
                TxtDetails.Text &= vbCrLf & "تعديل : بواسطة  " & Usr.PUsrRlNm & " في " & ServrTime() & " من خلال IP : " & OsIP() & vbCrLf & TxtDetailsAdd.Text
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
        If LblHelp.Text.Length > 0 Then
            If LblHelp.Visible = True Then
                LblHelp.Visible = False
            Else
                LblHelp.Visible = True
            End If
        End If
    End Sub

    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        TikUpdate.ShowDialog()
    End Sub
End Class