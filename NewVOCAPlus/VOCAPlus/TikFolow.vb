Imports System.Net
Imports System.IO
Imports System.Threading

Public Class TikFolow
    Dim SerchTable As DataTable = New DataTable()
    Dim TempData As DataView
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Dim CurrRw As Integer
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub FolwTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreciFlag = False Then
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات")
            Beep()
            Invoke(Sub() Me.Close())
        Else
            ProgBar = ProgressBar1
            BtnSub(Me)
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
            Invoke(Sub() SerchTable.Rows.Clear())
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

            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            Invoke(Sub() FilterComb.DataSource = SerchTable)
            FilterComb.DisplayMember = "Item"
            Invoke(Sub() FilterComb.ValueMember = "Kind")
            Invoke(Sub() GridTicket.Visible = False)
            Invoke(Sub() GroupBox1.Visible = False)
            Invoke(Sub() BtnRefrsh.Enabled = False)
            Invoke(Sub() Me.Refresh())

            Dim PrTblTsk As New Thread(AddressOf Load_)
            PrTblTsk.IsBackground = True
            PrTblTsk.Start()
        End If
    End Sub
    Private Sub Load_()
        Invoke(Sub() GridTicket.Visible = False)
        Invoke(Sub() GroupBox1.Visible = False)
        Invoke(Sub() BtnRefrsh.Enabled = False)
        Invoke(Sub() Me.Refresh())
        FilGrdTbl()
        Filtr()
        AddHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
        AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
        AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        Invoke(Sub() BtnRefrsh.Enabled = True)
        Invoke(Sub() GridTicket.Visible = True)
        Invoke(Sub() GroupBox1.Visible = True)
        Invoke(Sub() Me.Refresh())
        'Invoke(Sub() StatBrPnlAr.Text = ("نتيجة البحث : إجمالي عدد " & GridCuntRtrn.TickCount & " -- عدد الشكاوى : " & GridCuntRtrn.CompCount & " -- عدد الاستفسارات : " & GridCuntRtrn.TickCount - GridCuntRtrn.CompCount & " -- شكاوى مغلقة : " & GridCuntRtrn.ClsCount & " -- شكاوى مفتوحة : " & GridCuntRtrn.CompCount - GridCuntRtrn.ClsCount & " -- لم يتم المتابعة : " & GridCuntRtrn.NoFlwCount))
        'Invoke(Sub() GridTicket.ClearSelection())
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

        TickTblMain = New DataTable
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ............."
        WelcomeScreen.StatBrPnlEn.Text = ""
        '  Table                                               0                     1       2       3         4     5       6      7        8       9      10         11       12       13       14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29              30                  31        32          33       34     35       36       37                          38                                            39                                    40                                                      41                                                                                 **********
        '  Grid                                                0                     1       2       3         4     5       6      7        8       9      10         11       12       13       14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29               30                 31        32          33       34     35       36       37                          38                                            39                                    40                                                      41                                                 42                              ***********
        If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm,  TkReOp, format(TkRecieveDt,'yyyy/MM/dd') As TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll WHERE (TkClsStatus = 0) AND (TkEmpNm = " & Usr.PUsrID & ") ORDER BY TkSQL;", TickTblMain, "1028&H") = Nothing Then
            Invoke(Sub() Me.Text = "متابعة الشكاوى" & "_" & ElapsedTimeSpan)
            If TickTblMain.Rows.Count > 0 Then
                Invoke(Sub() StatBrPnlAr.Text = "......... جاري تنسيق البيانات")

                Invoke(Sub() CompGrdTikFill(GridTicket, TickTblMain, ProgBar))  'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                Invoke(Sub() GetUpdtEvnt_())


                Invoke(Sub() TikFormat(TickTblMain, UpdtCurrTbl, ProgressBar1))

                Invoke(Sub() GridTicket.Columns("TkupReDt").Visible = False)
                Invoke(Sub() GridTicket.Columns("TkupUser").Visible = False)
                Invoke(Sub() GridTicket.Columns("LastUpdateID").Visible = False)
                Invoke(Sub() GridTicket.Columns("EvSusp").Visible = False)
                Invoke(Sub() GridTicket.Columns("UCatLvl").Visible = False)
                Invoke(Sub() GridTicket.Columns("TkupUnread").Visible = False)
                Invoke(Sub() StatBrPnlAr.Text = Nothing)
            Else
                Invoke(Sub() StatBrPnlAr.Text = ("خطأ"))
                Beep()
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
        End If

    End Sub
    Private Sub GetUpdtEvnt_()
        UpdtCurrTbl = New DataTable
        '                                 0        1         2         3         4        5        6         7         8         9
        If PublicCode.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( " & CompIds & ") ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H") = Nothing Then
            UpdtCurrTbl.Columns.Add("File")        ' Add files Columns 
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String = ""
        TempData = TickTblMain.DefaultView
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
                FltrStr &= " And (TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd") & "')"
            Else
                FltrStr = "(TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd") & "')"
            End If
        End If

        If ChckUpdMe.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And [محرر آخر تحديث] = UsrRealNm"
            Else
                FltrStr = "[محرر آخر تحديث] = UsrRealNm"
            End If
        ElseIf ChckUpdColeg.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And [محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"
            Else
                FltrStr = "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"
            End If
        ElseIf ChckUpdOther.Checked Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And [محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"
            Else
                FltrStr = "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"
            End If
        ElseIf ChckRead.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkupUnread = False "
            Else
                FltrStr = "TkupUnread = False "
            End If
        ElseIf ChckEsc1.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And LastUpdateID = '" & 902 & "'"
            Else
                FltrStr = "LastUpdateID = '" & 902 & "'"
            End If
        ElseIf ChckEsc2.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And LastUpdateID = '" & 903 & "'"
            Else
                FltrStr = "LastUpdateID = '" & 903 & "'"
            End If
        ElseIf ChckEsc3.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And LastUpdateID = '" & 904 & "'"
            Else
                FltrStr = "LastUpdateID = '" & 904 & "'"
            End If
        ElseIf ChckUpdAll.Checked Then
            If FltrStr.Length > 0 Then

            End If
        End If
        Invoke(Sub()
                   If FilterComb.SelectedIndex > -1 Then
                       WelcomeScreen.StatBrPnlAr.Text = ""
                       If FltrStr.Length > 0 Then
                           TickTblMain.DefaultView.RowFilter = FltrStr
                       Else
                           TickTblMain.DefaultView.RowFilter = String.Empty
                           ChckUpdAll.Checked = True
                       End If

                   Else
                       WelcomeScreen.StatBrPnlAr.Text = "برجاء اختيار نوع البحث"
                       Beep()
                   End If

                   Label4.Text = GridCuntRtrn.CompCount
                   Lbl0.Text = GridCuntRtrn.UpdtFollow
                   Lbl1.Text = GridCuntRtrn.UpdtColleg
                   Lbl2.Text = GridCuntRtrn.UpdtOthrs
                   Lbl3.Text = GridCuntRtrn.NoFlwCount
                   Lbl4.Text = GridCuntRtrn.Recved
                   Lbl5.Text = GridCuntRtrn.UnReadCount
                   Lbl6.Text = GridCuntRtrn.Esc1
                   Lbl7.Text = GridCuntRtrn.Esc2
                   Lbl8.Text = GridCuntRtrn.Esc3
               End Sub)
        Invoke(Sub() ChckColor())
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

        If (GridTicket.SelectedCells.Count) > 0 Then
            If GridTicket.CurrentRow.Index <> -1 Then
                CurrRw = GridTicket.CurrentRow.Index
                StruGrdTk.Tick = GridTicket.CurrentRow.Cells("TkKind").Value
                StruGrdTk.FlwStat = GridTicket.CurrentRow.Cells("TkClsStatus").Value
                StruGrdTk.Sql = GridTicket.CurrentRow.Cells("TkSQL").Value
                StruGrdTk.Ph1 = GridTicket.CurrentRow.Cells("TkClPh").Value
                StruGrdTk.Ph2 = GridTicket.CurrentRow.Cells("TkClPh1").Value.ToString
                StruGrdTk.DtStrt = GridTicket.CurrentRow.Cells("TkDtStart").Value
                StruGrdTk.ClNm = GridTicket.CurrentRow.Cells("TkClNm").Value
                StruGrdTk.Adress = GridTicket.CurrentRow.Cells("TkClAdr").Value.ToString
                StruGrdTk.Email = GridTicket.CurrentRow.Cells("TkMail").Value.ToString
                StruGrdTk.Detls = GridTicket.CurrentRow.Cells("TkDetails").Value.ToString
                StruGrdTk.Area = GridTicket.CurrentRow.Cells("OffArea").Value.ToString
                StruGrdTk.Offic = GridTicket.CurrentRow.Cells("OffNm1").Value.ToString
                StruGrdTk.ProdNm = GridTicket.CurrentRow.Cells("PrdNm").Value
                StruGrdTk.CompNm = GridTicket.CurrentRow.Cells("CompNm").Value
                StruGrdTk.Src = GridTicket.CurrentRow.Cells("SrcNm").Value
                StruGrdTk.Trck = GridTicket.CurrentRow.Cells("TkShpNo").Value.ToString
                StruGrdTk.Orig = GridTicket.CurrentRow.Cells("CounNmSender").Value.ToString
                StruGrdTk.Dist = GridTicket.CurrentRow.Cells("CounNmConsign").Value.ToString
                StruGrdTk.Card = GridTicket.CurrentRow.Cells("TkCardNo").Value.ToString
                StruGrdTk.Gp = GridTicket.CurrentRow.Cells("TkGBNo").Value.ToString
                StruGrdTk.NID = GridTicket.CurrentRow.Cells("TkClNtID").Value.ToString
                StruGrdTk.Amnt = GridTicket.CurrentRow.Cells("TkAmount").Value
                If DBNull.Value.Equals(GridTicket.CurrentRow.Cells("TkTransDate").Value) = False Then StruGrdTk.TransDt = GridTicket.CurrentRow.Cells("TkTransDate").Value
                StruGrdTk.UsrNm = GridTicket.CurrentRow.Cells("UsrRealNm").Value
                StruGrdTk.Help_ = GridTicket.CurrentRow.Cells("CompHelp").Value.ToString
                StruGrdTk.ProdK = GridTicket.CurrentRow.Cells("PrdKind").Value
                StruGrdTk.UserId = GridTicket.CurrentRow.Cells("TkEmpNm").Value
                TikDetails.Text = "شكوى رقم " & StruGrdTk.Sql


                StruGrdTk.LstUpDt = GridTicket.CurrentRow.Cells("تاريخ آخر تحديث").Value
                StruGrdTk.LstUpTxt = GridTicket.CurrentRow.Cells("نص آخر تحديث").Value
                StruGrdTk.LstUpUsrNm = GridTicket.CurrentRow.Cells("محرر آخر تحديث").Value
                StruGrdTk.LstUpEvId = GridTicket.CurrentRow.Cells("LastUpdateID").Value
                frm__ = Me
                gridview_ = GridTicket
                TikDetails.ShowDialog()

            End If
        End If
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



    Private Sub SerchTxt_Leave(sender As Object, e As EventArgs) Handles SerchTxt.Leave
        If SerchTxt.TextLength = 0 Then
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
        End If
    End Sub
    Private Sub Chck_Click(sender As Object, e As EventArgs) Handles ChckUpdOther.Click, ChckUpdMe.Click, ChckUpdColeg.Click, ChckUpdAll.Click, ChckTrnsDy.Click, ChckRead.Click, ChckFlN.Click, ChckEsc3.Click, ChckEsc2.Click, ChckEsc1.Click
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
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridTicket.CurrentCell.Value)
    End Sub
    Private Sub ChckRead_CheckedChanged(sender As Object, e As EventArgs)
        Filtr()
    End Sub
    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs)
        If GridTicket.SelectedCells.Count > 0 Then
            StatBrPnlEn.Text = GridTicket.CurrentRow.Index + 1 & " Of " & GridTicket.Rows.Count.ToString("N0")
        Else
            StatBrPnlEn.Text = ""
        End If

    End Sub


#Region "Tool Strip GridUpdate"
    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If GridTicket.SelectedCells.Count > 0 Then
            TikIDRep_ = GridTicket.CurrentRow.Cells(1).Value
            TikFrmRep.ShowDialog()
        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
    Private Sub GridTicket_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridTicket.RowEnter
        StruGrdTk.Sql = 0
    End Sub

    Private Sub BtnRefrsh_Click(sender As Object, e As EventArgs) Handles BtnRefrsh.Click
        StatBrPnlEn.Text = ""
        RemoveHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
        RemoveHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
        RemoveHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        Dim PrTblTsk As New Thread(AddressOf Load_)
        PrTblTsk.IsBackground = True
        PrTblTsk.Start()
    End Sub
#End Region
End Class