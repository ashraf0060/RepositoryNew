Imports System.Net
Imports System.IO
Imports System.Threading
Imports VOCAPlus.Strc

Public Class TikFolow
    Dim Def As New APblicClss.Defntion
    Dim Fn As New APblicClss.Func
    Dim SerchTable As DataTable = New DataTable()
    Dim TempData As DataView
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Dim CurrRw As Integer
    Dim FrmErr As String = Nothing
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub FolwTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
        Me.GridTicket.Width = Me.Size.Width - 30
        Me.GridTicket.Height = Me.Size.Height - 200
        GroupBox1.Location = New Point((Me.Size.Width - GroupBox1.Size.Width) / 2, GroupBox1.Location.Y)
        If PreciFlag = False Then
            Beep()
            Me.Close()
        Else
            ProgBar = ProgressBar1
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

            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            FilterComb.DataSource = SerchTable
            FilterComb.DisplayMember = "Item"
            FilterComb.ValueMember = "Kind"


            GridTicket.Visible = False
            GroupBox1.Visible = False
            BtnRefrsh.Enabled = False
            Me.Refresh()
            Def.Thread_ = New Thread(AddressOf NewFill_)
            Def.Thread_.IsBackground = True
            Def.Thread_.Start()
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
    Private Sub NewFill_()
        Dim Fn As New APblicClss.Func
        Dim primaryKey(0) As DataColumn
        GridCuntRtrn = New TickInfo
        TickTblMain = New DataTable
        StruGrdTk.Sql = 0
        RemoveHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
        RemoveHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
        RemoveHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        Invoke(Sub() BtnRefrsh.Enabled = False)
        Invoke(Sub() GroupBox1.Enabled = False)
        Invoke(Sub() FilterComb.Enabled = False)
        Invoke(Sub() StatBrPnlAr.Text = "جاري تحميل البيانات ...........")

        Invoke(Sub() BtnCncl.Enabled = True)
        Invoke(Sub() CloseBtn.Enabled = True)

        primaryKey(0) = TickTblMain.Columns("TkSQL")
        TickTblMain.PrimaryKey = primaryKey
        FltrStr = " Where " & " (TkClsStatus = 0)  and TkEmpNm = " & Usr.PUsrID
        Invoke(Sub() GridTicket.Visible = False)
        If Fn.GetTblXX("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm,  TkReOp, format(TkRecieveDt,'yyyy/MM/dd') As TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll " & FltrStr & "  ORDER BY TkSQL;", TickTblMain, "1028&H") = Nothing Then
            Invoke(Sub() Me.Text = "متابعة الشكاوى" & "_" & ElapsedTimeSpan)
            If TickTblMain.Rows.Count > 0 Then
                Invoke(Sub() StatBrPnlAr.Text = "جاري تحميل التحديثات ...........")

                Invoke(Sub() Fn.CompGrdTikFill1(GridTicket, TickTblMain, ProgressBar1)) 'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                Invoke(Sub() Fn.GetUpdtEvnt_1())
                If Me.IsHandleCreated = True Then
                    Invoke(Sub() Me.Text += " _ التحديثات" & "_" & ElapsedTimeSpan)
                    Invoke(Sub() StatBrPnlAr.Text = "جاري تنسيق البيانات ...........")
                    'Invoke(Sub() StatBrPnlAr.Refresh())
                    Invoke(Sub() GridTicket.Columns("TkupReDt").Visible = False)
                    Invoke(Sub() GridTicket.Columns("TkupUser").Visible = False)
                    Invoke(Sub() GridTicket.Columns("LastUpdateID").Visible = False)
                    Invoke(Sub() GridTicket.Columns("EvSusp").Visible = False)
                    Invoke(Sub() GridTicket.Columns("UCatLvl").Visible = False)
                    Invoke(Sub() GridTicket.Columns("TkupUnread").Visible = False)
                End If



                Invoke(Sub() ProgressBar1.Visible = True)

                For Rws = 0 To TickTblMain.Rows.Count - 1
                    GridCuntRtrn.TickCount += 1                                          'Grid record count
                    Invoke(Sub() StatBrPnlAr.Text = Rws + 1 & " من " & TickTblMain.Rows.Count)
                    ProgressBar1.Maximum = TickTblMain.Rows.Count
                    Invoke(Sub() ProgressBar1.Value = GridCuntRtrn.TickCount)
                    Try
                        UpdtCurrTbl.DefaultView.RowFilter = "[TkupTkSql]" & " = " & TickTblMain.Rows(Rws).Item("TkSQL")
                        TickTblMain.Rows(Rws).Item("تاريخ آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("TkupSTime")
                        TickTblMain.Rows(Rws).Item("نص آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("TkupTxt")
                        TickTblMain.Rows(Rws).Item("محرر آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("UsrRealNm")
                        TickTblMain.Rows(Rws).Item("TkupReDt") = UpdtCurrTbl.DefaultView(0).Item("TkupReDt")
                        TickTblMain.Rows(Rws).Item("TkupUser") = UpdtCurrTbl.DefaultView(0).Item("TkupUser")
                        TickTblMain.Rows(Rws).Item("LastUpdateID") = UpdtCurrTbl.DefaultView(0).Item("TkupEvtId")
                        TickTblMain.Rows(Rws).Item("EvSusp") = UpdtCurrTbl.DefaultView(0).Item("EvSusp")
                        TickTblMain.Rows(Rws).Item("UCatLvl") = UpdtCurrTbl.DefaultView(0).Item("UCatLvl")
                        TickTblMain.Rows(Rws).Item("TkupUnread") = UpdtCurrTbl.DefaultView(0).Item("TkupUnread")

                        StruGrdTk.LstUpDt = UpdtCurrTbl.DefaultView(0).Item("TkupSTime")
                        StruGrdTk.LstUpTxt = UpdtCurrTbl.DefaultView(0).Item("TkupTxt")
                        StruGrdTk.LstUpUsrNm = UpdtCurrTbl.DefaultView(0).Item("UsrRealNm")
                        StruGrdTk.LstUpEvId = UpdtCurrTbl.DefaultView(0).Item("TkupEvtId")

                    Catch ex As Exception
                        MsgBox("Error :" & ex.Message)
                    End Try
                Next Rws
                Invoke(Sub() ProgressBar1.Visible = False)

                GridCuntRtrn.CompCount = Convert.ToInt32(TickTblMain.Compute("count(TkSQL) ", String.Empty))
                GridCuntRtrn.NoFlwCount = Convert.ToInt32(TickTblMain.Compute("count(TkFolw)", "TkFolw = 'False'"))
                GridCuntRtrn.Recved = Convert.ToInt32(TickTblMain.Compute("count(TkRecieveDt)", "TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd").ToString & "'"))
                GridCuntRtrn.ClsCount = Convert.ToInt32(TickTblMain.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"))
                GridCuntRtrn.UpdtFollow = Convert.ToInt32(TickTblMain.Compute("count(UsrRealNm)", "[محرر آخر تحديث] = UsrRealNm"))
                GridCuntRtrn.UpdtColleg = Convert.ToInt32(TickTblMain.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"))
                GridCuntRtrn.UpdtOthrs = Convert.ToInt32(TickTblMain.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"))
                GridCuntRtrn.UnReadCount = Convert.ToInt32(TickTblMain.Compute("count(TkupUnread)", "TkupUnread = 'False'"))
                GridCuntRtrn.Esc1 = Convert.ToInt32(TickTblMain.Compute("count(LastUpdateID)", "LastUpdateID = 902"))
                GridCuntRtrn.Esc2 = Convert.ToInt32(TickTblMain.Compute("count(LastUpdateID)", "LastUpdateID = 903"))
                GridCuntRtrn.Esc3 = Convert.ToInt32(TickTblMain.Compute("count(LastUpdateID)", "LastUpdateID = 904"))
                Invoke(Sub() GridTicket.ClearSelection())
                Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold))
                Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False)
                Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter)
                Invoke(Sub() GridTicket.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular))
                Invoke(Sub() GridTicket.AutoResizeColumns())
                Invoke(Sub() GridTicket.Columns("نص آخر تحديث").Width = 250)
                AddHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
                AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
                AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
                Invoke(Sub() StatBrPnlAr.Text = "")
                Invoke(Sub() Filtr())
                Invoke(Sub() GroupBox1.Visible = True)
            Else
                Invoke(Sub() StatBrPnlAr.Text = "لا توجد شكاوى للمتابعة")
            End If
            Invoke(Sub() GridTicket.Visible = True)
        Else
            Invoke(Sub() StatBrPnlAr.Text = "لم ينجح البحث - يرجى المحاولة مرة أخرى")
            Invoke(Sub() Beep())
        End If
            FltrStr = Nothing
            Invoke(Sub() BtnRefrsh.Enabled = True)
        Invoke(Sub() BtnCncl.Enabled = False)
        Invoke(Sub() GroupBox1.Enabled = True)
        Invoke(Sub() FilterComb.Enabled = True)
    End Sub
    Private Sub Filtr()
        FrmErr = Nothing
        Try

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

            If FilterComb.SelectedIndex > -1 Then
                WelcomeScreen.StatBrPnlAr.Text = ""
                If FltrStr.Length > 0 Then
                    TickTblMain.DefaultView.RowFilter = FltrStr
                Else
                    TickTblMain.DefaultView.RowFilter = String.Empty
                    ChckUpdAll.Checked = True
                End If

            Else
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "برجاء اختيار نوع البحث")
                Beep()
            End If

            Invoke(Sub() Label4.Text = GridCuntRtrn.CompCount)
            Invoke(Sub() Lbl0.Text = GridCuntRtrn.UpdtFollow)
            Invoke(Sub() Lbl1.Text = GridCuntRtrn.UpdtColleg)
            Invoke(Sub() Lbl2.Text = GridCuntRtrn.UpdtOthrs)
            Invoke(Sub() Lbl3.Text = GridCuntRtrn.NoFlwCount)
            Invoke(Sub() Lbl4.Text = GridCuntRtrn.Recved)
            Invoke(Sub() Lbl5.Text = GridCuntRtrn.UnReadCount)
            Invoke(Sub() Lbl6.Text = GridCuntRtrn.Esc1)
            Invoke(Sub() Lbl7.Text = GridCuntRtrn.Esc2)
            Invoke(Sub() Lbl8.Text = GridCuntRtrn.Esc3)
            Invoke(Sub() ChckColor())
            Invoke(Sub() StatBrPnlEn.Text = "")
        Catch ex As Exception
            FrmErr = "X"
        End Try
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
                If Fn.TikGVDblClck(GridTicket) = Nothing Then
                    TikDetails.Text = "شكوى رقم " & StruGrdTk.Sql
                    TikDetails.ShowDialog()
                Else
                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
                End If
            End If
        End If
    End Sub
    Private Sub Chck_Click(sender As Object, e As EventArgs) Handles ChckUpdOther.Click, ChckUpdMe.Click, ChckUpdColeg.Click, ChckUpdAll.Click, ChckTrnsDy.Click, ChckRead.Click, ChckFlN.Click, ChckEsc3.Click, ChckEsc2.Click, ChckEsc1.Click
        Filtr()
    End Sub
    Private Sub ChckColor()
        FrmErr = Nothing
        'Dim StW As New Stopwatch
        'StW.Start()
        Try
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

            'StW.Stop()
            'Dim TimSpn As TimeSpan = (StW.Elapsed)
            'MsgBox(String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds / 10))
        Catch ex As Exception
            FrmErr = "X"
        End Try
    End Sub
    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs)
        If GridTicket.SelectedCells.Count > 0 Then
            StatBrPnlEn.Text = GridTicket.CurrentRow.Index + 1 & " من " & GridTicket.Rows.Count.ToString("N0")
        Else
            StatBrPnlEn.Text = ""
        End If

    End Sub
    Private Sub GridTicket_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridTicket.RowEnter
        StruGrdTk.Sql = 0
    End Sub
    Private Sub BtnRefrsh_Click(sender As Object, e As EventArgs) Handles BtnRefrsh.Click
        Def.Thread_ = New Thread(AddressOf NewFill_)
        Def.Thread_.IsBackground = True
        Def.Thread_.Start()
    End Sub
    Private Sub BtnCncl_Click(sender As Object, e As EventArgs) Handles BtnCncl.Click
        Def.Thread_.Abort()
        Invoke(Sub() GroupBox1.Enabled = True)
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        BtnRefrsh.Enabled = True
        GridTicket.Visible = False
        StatBrPnlAr.Text = ""
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Def.Thread_.Abort()
        Me.Close()
    End Sub
End Class