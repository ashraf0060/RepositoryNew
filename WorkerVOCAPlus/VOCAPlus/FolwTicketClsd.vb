Public Class FolwTicketClsd
    Dim SerchTable As DataTable = New DataTable()
    Dim UpdtCurrTbl As DataTable = New DataTable
    Dim FollowTable As DataTable = New DataTable
    Dim TempData As DataView
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub FolwTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreciFlag = False Then
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
            Me.Close()
        Else
            WelcomeScreen.StatBrPnlAr.Text = ""
            SerchTable.Rows.Clear()
            SerchTable.Columns.Clear()
            SerchTable.Columns.Add("Kind")
            SerchTable.Columns.Add("Item")

            SerchTable.Rows.Add("STR", "اسم العميل")
            SerchTable.Rows.Add("STR", "الرقم القومي")
            SerchTable.Rows.Add("STR", "تليفون العميل1")
            SerchTable.Rows.Add("STR", "تليفون العميل2")
            SerchTable.Rows.Add("Int", "رقم الشكوى")
            SerchTable.Rows.Add("STR", "رقم الكارت")
            SerchTable.Rows.Add("STR", "رقم الشحنة")
            SerchTable.Rows.Add("STR", "رقم أمر الدفع")
            SerchTable.Rows.Add("STR", "مصدر الشكوى")
            SerchTable.Rows.Add("Int", "مبلغ العملية")

            FilterComb.DataSource = SerchTable
            FilterComb.DisplayMember = "Item"
            FilterComb.ValueMember = "Kind"
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            FilterComb.ValueMember = "Kind"
            FilGrdTbl()
            Filtr()
            AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
            AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        End If
    End Sub
    Public Sub NumberOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow number from 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    Public Sub AESpaceNumberOnly(ByVal e As KeyPressEventArgs)  ' 
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 32 Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Arabic, English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub FilGrdTbl()
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        FollowTable.Rows.Clear()
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ........................."
        RemoveHandler RdioClsd.Click, (AddressOf RdioClsdUpdtd_CheckedChanged)
        RemoveHandler RdioClsdUpdtd.Click, (AddressOf RdioClsdUpdtd_CheckedChanged)
        Dim Str As String = ""
        If RdioClsdUpdtd.Checked = True Then
            Str = " AND (TkupEvtId <> 900)"
        ElseIf RdioClsd.Checked = True Then
            Str = ""
        End If
        AddHandler RdioClsd.Click, (AddressOf RdioClsdUpdtd_CheckedChanged)
        AddHandler RdioClsdUpdtd.Click, (AddressOf RdioClsdUpdtd_CheckedChanged)
        '  Table                                               0                     1       2       3         4     5       6      7        8       9      10         11       12        13       14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29              30                  31        32          33       34     35       36       37               38                          39                                    40                                                      41                                                                                 **********
        '  Grid                                                0                     1       2       3         4     5       6      7        8       9      10         11       12       13        14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29               30                 31        32          33       34     35       36       37               38                          39                                    40                                                      41                                                                                 ***********
        If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, TicketsAll.UsrRealNm, TicLstEv.LstSqlEv, TicLstEv.LstUpdtTime, TkEvent.TkupTxt, TkEvent.TkupUnread, TkEvent.TkupEvtId, CDEvent.EvNm, CDEvent.EvSusp, Int_user.UsrRealNm AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CASE WHEN TkEmpNm = TkupUser THEN 0 ELSE CASE WHEN UCatLvl between 3 and 5 then 1 ELSE 2 END END AS UpdtUserCase FROM TicketsAll INNER JOIN TkEvent ON TkSQL = TkEvent.TkupTkSql INNER JOIN TicLstEv ON TkEvent.TkupSQL = TicLstEv.LstSqlEv INNER JOIN CDEvent ON TkEvent.TkupEvtId = CDEvent.EvId INNER JOIN Int_user ON TkEvent.TkupUser = Int_user.UsrId INNER JOIN dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId WHERE (TkClsStatus = 1) AND (TkEmpNm = " & Usr.PUsrID & ")" & Str & " ORDER BY TkSQL;", FollowTable, "1028&H") = Nothing Then
            WelcomeScreen.StatBrPnlAr.Text = ""
            PublicCode.SubGrdTikFill(GridTicket, FollowTable)
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String = ""
        TempData = FollowTable.DefaultView
        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
            If SerchTxt.TextLength > 0 Then
                If FilterComb.SelectedValue = "Int" Then
                    For Cnt_ = 0 To GridTicket.Columns.Count - 1
                        If FilterComb.Text = GridTicket.Columns(Cnt_).HeaderText Then
                            FltrStr = "[" & GridTicket.Columns(Cnt_).Name & "]" & " = '" & SerchTxt.Text & "'"
                            Exit For
                        End If
                    Next
                Else
                    For Cnt_ = 0 To GridTicket.Columns.Count - 1
                        If FilterComb.Text = GridTicket.Columns(Cnt_).HeaderText Then
                            FltrStr = "[" & GridTicket.Columns(Cnt_).Name & "]" & " like '" & SerchTxt.Text & "%'"
                            Exit For
                        End If
                    Next
                End If
            End If
        End If

        If ChckFlN.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkFolw = False "
            Else
                FltrStr = "TkFolw = False "
            End If
        End If
        If ChckTrnsDy.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And (TkRecieveDt = '" & Format(ServrTime(), "dd/MM/yyyy") & "')"
            Else
                FltrStr = "(TkRecieveDt = '" & Format(ServrTime(), "dd/MM/yyyy") & "')"
            End If
        End If

        If ChckUpdMe.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And UpdtUserCase = '" & 0 & "'"
            Else
                FltrStr = "UpdtUserCase = '" & 0 & "'"
            End If
        ElseIf ChckUpdColeg.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And UpdtUserCase = '" & 1 & "'"
            Else
                FltrStr = "UpdtUserCase = '" & 1 & "'"
            End If
        ElseIf ChckUpdOther.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And UpdtUserCase = '" & 2 & "'"
            Else
                FltrStr = "UpdtUserCase = '" & 2 & "'"
            End If
        ElseIf ChckRead.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkupUnread = False "
            Else
                FltrStr = "TkupUnread = False "
            End If
        ElseIf ChckUpdAll.Checked Then
            If FltrStr.Length > 0 Then

            End If
        End If


        If FilterComb.SelectedIndex > -1 Then
            WelcomeScreen.StatBrPnlAr.Text = ""
            If FltrStr.Length > 0 Then
                FollowTable.DefaultView.RowFilter = FltrStr
            Else
                FollowTable.DefaultView.RowFilter = String.Empty
                ChckUpdAll.Checked = True
            End If

        Else
            WelcomeScreen.StatBrPnlAr.Text = "برجاء اختيار نوع البحث"
            Beep()
        End If
        Label4.Text = GridTicket.Rows.Count.ToString("N0")
        Lbl0.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("UpdtUserCase").Value = 0 And row.Cells("UpdtUserCase").Value IsNot DBNull.Value
                     Select row.Cells("UpdtUserCase").Value).Count().ToString("N0")
        Lbl1.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("UpdtUserCase").Value = 1 And row.Cells("UpdtUserCase").Value IsNot DBNull.Value
                     Select row.Cells("UpdtUserCase").Value).Count().ToString("N0")
        Lbl2.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("UpdtUserCase").Value = 2 And row.Cells("UpdtUserCase").Value IsNot DBNull.Value
                     Select row.Cells("UpdtUserCase").Value).Count().ToString("N0")
        Lbl3.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("TkFolw").Value = 0 And row.Cells("TkFolw").Value IsNot DBNull.Value
                     Select row.Cells("TkFolw").Value).Count().ToString("N0")
        Lbl4.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where Format(row.Cells("TkRecieveDt").Value.ToString, "short date") = Format(ServrTime(), "short date") And row.Cells("TkRecieveDt").Value IsNot DBNull.Value.ToString
                     Select row.Cells("TkRecieveDt").Value).Count().ToString("N0")
        Lbl5.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("TkupUnread").Value = 0 And row.Cells("TkupUnread").Value IsNot DBNull.Value
                     Select row.Cells("TkupUnread").Value).Count().ToString("N0")
        ChckColor()
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs)
        Filtr()
    End Sub
    Private Sub FilterComb_SelectedIndexChanged(sender As Object, e As EventArgs)
        SerchTxt.Text = ""
        SerchTxt.Focus()
        SerchTxt.ForeColor = Color.Black
    End Sub
    Private Sub GridTicket_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick

        If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2

        If GridTicket.Rows.Count > 0 Then
            PublicCode.FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
            If StruGrdTk.ClsStat = True Then
                TcktImg.BackgroundImage = My.Resources.Tckoff
            Else
                TcktImg.BackgroundImage = My.Resources.Tckon
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
            TxtTransDt.Text = StruGrdTk.TransDt
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
            TabPage2.Text = "Ref.: " & StruGrdTk.TkId

        End If
    End Sub
    Private Sub BtnBck_Click(sender As Object, e As EventArgs) Handles BtnBck.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub SerchTxt_Enter(sender As Object, e As EventArgs) Handles SerchTxt.Enter
        If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
            SerchTxt.Text = ""
            SerchTxt.ForeColor = Color.Black
        End If
    End Sub
    Private Sub SerchTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SerchTxt.KeyPress
        If FilterComb.SelectedValue = "Int" Then
            NumberOnly(e)
        Else
            AESpaceNumberOnly(e)
        End If
    End Sub
    Private Sub GridUpdt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUpdt.CellClick
        If GridUpdt.CurrentRow.Cells(6).Value = False Then
            If PublicCode.InsUpd("update TkEvent set TkupUnread = 1, TkupReDt = " & "CONVERT(DATETIME, '" & Format(ServrTime(), "dd/MM/yyyy") & "',103) where TkupSQL = " & GridUpdt.CurrentRow.Cells(0).Value & ";", "1035&H") = Nothing Then
                GridUpdt.CurrentRow.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                If GridUpdt.CurrentRow.Index = 0 Then GridTicket.CurrentRow.Cells(32).Value = True
                GridUpdt.CurrentRow.Cells(6).Value = True
                GridUpdt.CurrentRow.Cells(8).Value = Now
                'UpdtEvent()
            Else
                MsgErr("لم يتم تسجيل قراءة التحديث" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        End If
    End Sub
    Private Sub UpdtEvent()
        UpdtCurrTbl.Rows.Clear()
        '                    0        1         2         3         4         5        6          7           8         9
        If PublicCode.GetTbl("SELECT TkupSQL, TkupSTime, TkupTxt, UsrRealNm, TkupUser, EvSusp, TkupUnread, TkupTkSql, TkupReDt, UCatLvl FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where (TkupTkSql = " & StruGrdTk.Sql & ") ORDER BY TkupSQL DESC", UpdtCurrTbl, "1029&H") = Nothing Then
            GridUpdt.DataSource = UpdtCurrTbl
            UpGrgFrmt(GridUpdt, StruGrdTk.UserId)
            'GridTickRwsUpdt()                  ' Call Grid Function and Update status Bar
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.TabPages.Contains(TabPage3) = True Then
            If TabControl1.SelectedIndex = 2 Then
                TabPage3.Text = "Ticket No.: " & StruGrdTk.TkId & " Updates"
                UpdtEvent()
            End If
        End If
    End Sub
    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        If TabControl1.TabPages.Contains(TabPage3) = False Then TabControl1.TabPages.Insert(2, TabPage3)
        TabControl1.SelectedTab = TabPage3
        'UpdtEvent()
    End Sub
    Private Sub SerchTxt_Leave(sender As Object, e As EventArgs) Handles SerchTxt.Leave
        If SerchTxt.TextLength = 0 Then
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
        End If
    End Sub
    Private Sub BtnBck2_Click(sender As Object, e As EventArgs) Handles BtnBck2.Click
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub Chck_CheckedChanged(sender As Object, e As EventArgs) Handles ChckUpdOther.CheckedChanged, ChckFlN.CheckedChanged, ChckTrnsDy.CheckedChanged, ChckUpdColeg.CheckedChanged, ChckUpdMe.CheckedChanged, ChckUpdAll.CheckedChanged
        Filtr()
    End Sub
    Private Sub ChckColor()
        For Each c In GroupBox1.Controls
            If TypeOf c Is RadioButton Then
                If c.Checked = True Then
                    c.BackColor = Color.LimeGreen
                    c.font = New Font("Times New Roman", 12, FontStyle.Bold)
                Else
                    c.BackColor = Color.White
                    c.font = New Font("Times New Roman", 10, FontStyle.Regular)
                End If
            ElseIf TypeOf c Is Label Then
                If CDbl(Val(c.Text)) > 0 Then
                    c.ForeColor = Color.Green
                    c.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                Else
                    c.ForeColor = Color.Black
                    c.Font = New Font("Times New Roman", 6, FontStyle.Regular)
                End If
            End If
        Next
    End Sub

    'Private Sub TxtUpdt_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUpdt.KeyDown
    '    If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
    '        TxtUpdt.Text = Clipboard.GetText()
    '    End If
    'End Sub

    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Clipboard.SetText(GridTicket.CurrentCell.Value)
    End Sub

    Private Sub ChckRead_CheckedChanged(sender As Object, e As EventArgs) Handles ChckRead.CheckedChanged
        Filtr()
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        If Len(GridTicket.CurrentCell.Value.ToString) > 0 Then Clipboard.SetText(GridTicket.CurrentCell.Value)
    End Sub
    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        'Dim hit As DataGridView.HitTestInfo = GridTicket.HitTest()
        If GridTicket.SelectedCells.Count > 0 Then
            TikIDRep_ = GridTicket.CurrentRow.Cells(1).Value
            TikFrmRep.ShowDialog()
        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
    Private Sub RdioClsdUpdtd_CheckedChanged(sender As Object, e As EventArgs)
        RemoveHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
        RemoveHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        FilGrdTbl()
        Filtr()
        AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
        AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
    End Sub
End Class