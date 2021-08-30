Imports VOCAPlus.Strc
Imports System.Threading

Public Class TikSearchNew
    Dim Def As New APblicClss.Defntion
    Dim Fn As New APblicClss.Func
    Dim SerchItmTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim CurrRw As Integer
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TikSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
        Me.GridTicket.Width = screenWidth - 30
        Me.GridTicket.Height = Me.Height - 180
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            SerchItmTable.Rows.Clear()
            SerchItmTable.Columns.Clear()
            SerchItmTable.Columns.Add("Kind")
            SerchItmTable.Columns.Add("Item")

            SerchItmTable.Rows.Add("Int-TkID", "رقم الشكوى")
            SerchItmTable.Rows.Add("STR-TkClNm", "اسم العميل")
            SerchItmTable.Rows.Add("STR-TkClPh", "تليفون العميل1")
            SerchItmTable.Rows.Add("STR-TkClPh1", "تليفون العميل2")
            SerchItmTable.Rows.Add("STR-TkCardNo", "رقم الكارت")
            SerchItmTable.Rows.Add("STR-TkShpNo", "رقم الشحنة")
            SerchItmTable.Rows.Add("STR-TkGBNo", "رقم أمر الدفع")
            SerchItmTable.Rows.Add("STR-TkClNtID", "الرقم القومي")
            SerchItmTable.Rows.Add("Int-TkAmount", "مبلغ العملية")
            SerchItmTable.Rows.Add("STR-SrcNm", "مصدر الشكوى")


            FilterComb.DataSource = SerchItmTable
            FilterComb.DisplayMember = "Item"
            FilterComb.ValueMember = "Kind"

            PrdItmTable.Rows.Clear()
            PrdItmTable.Columns.Clear()
            PrdItmTable.Columns.Add("ID")
            PrdItmTable.Columns.Add("Item")

            PrdItmTable.Rows.Add("0", "All")
            PrdItmTable.Rows.Add("1", "مالية")
            PrdItmTable.Rows.Add("2", "بريدية")
            PrdItmTable.Rows.Add("3", "حكومية")
            PrdItmTable.Rows.Add("4", "مجتمعية")

            PrdKComb.DataSource = PrdItmTable
            PrdKComb.DisplayMember = "Item"
            PrdKComb.ValueMember = "ID"

            WelcomeScreen.StatBrPnlAr.Text = ""

        End If
    End Sub
#Region "First Tab"
    Private Sub BtnSerch_Click(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Def.Thread_ = New Thread(AddressOf Filtr)
        Def.Thread_.IsBackground = True
        Def.Thread_.Start()
    End Sub
    Private Sub FilterComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComb.SelectedIndexChanged

        If FilterComb.Text = "الرقم القومي" Then
            FilterComb.MaxLength = 14
        ElseIf FilterComb.Text = "تليفون العميل1" Then
            SerchTxt.MaxLength = 11
        ElseIf FilterComb.Text = "تليفون العميل2" Then
            SerchTxt.MaxLength = 11
        ElseIf FilterComb.Text = "رقم الكارت" Or FilterComb.Text = "رقم أمر الدفع" Then
            SerchTxt.MaxLength = 16
        Else
            SerchTxt.MaxLength = 50
        End If
        Dim Def As New APblicClss.Defntion
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
        SerchTxt.ForeColor = Color.Black
        SerchTxt.Focus()
        SerchTxt.Text = ""
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        Dim Def As New APblicClss.Defntion
        If RadioButton1.Checked = True Then
            Def.TickKindFltr = 0
        ElseIf RadioButton2.Checked = True Then
            Def.TickKindFltr = 1
        ElseIf RadioButton3.Checked = True Then
            Def.TickKindFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub RdioOpen_Click(sender As Object, e As EventArgs) Handles RdioOpen.Click, Rdiocls.Click, RdioAll.Click
        Dim Def As New APblicClss.Defntion
        If RdioOpen.Checked = True Then
            Def.TicOpnFltr = 0
        ElseIf Rdiocls.Checked = True Then
            Def.TicOpnFltr = 1
        ElseIf RdioAll.Checked = True Then
            Def.TicOpnFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        Dim Def As New APblicClss.Defntion
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrdKComb.SelectedIndexChanged
        Dim Def As New APblicClss.Defntion
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub Filtr()
        Dim Fn As New APblicClss.Func
        Dim primaryKey(0) As DataColumn
        GridCuntRtrn = New TickInfo
        TickSrchTable = New DataTable
        StruGrdTk.Sql = 0
        Invoke(Sub() BtnSerch.Enabled = False)
        Invoke(Sub() GroupBox1.Enabled = False)
        Invoke(Sub() GroupBox2.Enabled = False)
        Invoke(Sub() PrdKComb.Enabled = False)
        Invoke(Sub() FilterComb.Enabled = False)
        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Or Trim(SerchTxt.Text).Length > 0 Then
            Invoke(Sub() LblMsg.Text = "جاري تحميل البيانات ...........")
            Invoke(Sub() LblMsg.ForeColor = Color.Green)
            Invoke(Sub() LblMsg.Refresh())
            Invoke(Sub()
                       If Split(FilterComb.SelectedValue, "-")(0) = "Int" Then
                           FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " = '" & SerchTxt.Text & "'"
                       Else
                           FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " like '" & SerchTxt.Text & "%'"
                       End If

                       If PrdKComb.SelectedIndex <> 0 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[PrdKind]" & " = '" & PrdKComb.SelectedIndex & "'"
                           Else
                               FltrStr = "[PrdKind]" & " = '" & PrdKComb.SelectedIndex & "'"
                           End If
                       End If
                       If Def.TickKindFltr <> 2 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[TkKind]" & " = " & Def.TickKindFltr
                           Else
                               FltrStr = "[TkKind]" & " = " & Def.TickKindFltr
                           End If
                       End If
                       If Def.TicOpnFltr <> 2 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[TkClsStatus]" & " = " & Def.TicOpnFltr
                           Else
                               FltrStr = "[TkClsStatus]" & " = " & Def.TicOpnFltr
                           End If
                       End If
                   End Sub)
            Invoke(Sub() BtnCncl.Enabled = True)
            Invoke(Sub() CloseBtn.Enabled = True)

            primaryKey(0) = TickSrchTable.Columns("TkSQL")
            TickSrchTable.PrimaryKey = primaryKey
            If FltrStr.Length > 0 Then
                FltrStr = " Where " & FltrStr
                Invoke(Sub() GridTicket.Visible = False)
                If Fn.GetTblXX("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll " & FltrStr & " ORDER BY TkSQL DESC;", TickSrchTable, "1042&H") = Nothing Then
                    Invoke(Sub() Me.Text = "بحث الشكاوى والاستفسارات" & "_" & ElapsedTimeSpan)
                    If TickSrchTable.Rows.Count > 0 Then
                        Invoke(Sub() LblMsg.Text = "جاري تحميل التحديثات ...........")
                        Invoke(Sub() LblMsg.ForeColor = Color.Blue)

                        Invoke(Sub() Fn.CompGrdTikFill1(GridTicket, TickSrchTable, ProgressBar1)) 'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                        Invoke(Sub() Fn.GetUpdtEvnt_1())
                        If Me.IsHandleCreated = True Then
                            Invoke(Sub() Me.Text += " _ التحديثات" & "_" & ElapsedTimeSpan)
                            Invoke(Sub() LblMsg.Text = "جاري تنسيق البيانات ...........")
                            Invoke(Sub() LblMsg.ForeColor = Color.Blue)
                            'Invoke(Sub() LblMsg.Refresh())
                            Invoke(Sub() GridTicket.Columns("TkupReDt").Visible = False)
                            Invoke(Sub() GridTicket.Columns("TkupUser").Visible = False)
                            Invoke(Sub() GridTicket.Columns("LastUpdateID").Visible = False)
                            Invoke(Sub() GridTicket.Columns("EvSusp").Visible = False)
                            Invoke(Sub() GridTicket.Columns("UCatLvl").Visible = False)
                            Invoke(Sub() GridTicket.Columns("TkupUnread").Visible = False)
                        End If



                        Invoke(Sub() ProgressBar1.Visible = True)

                        For Rws = 0 To TickSrchTable.Rows.Count - 1
                            GridCuntRtrn.TickCount += 1                                          'Grid record count
                            Invoke(Sub() LblMsg.Text = Rws + 1 & " من " & TickSrchTable.Rows.Count)
                            ProgressBar1.Maximum = TickSrchTable.Rows.Count
                            Invoke(Sub() ProgressBar1.Value = GridCuntRtrn.TickCount)
                            Try
                                UpdtCurrTbl.DefaultView.RowFilter = "[TkupTkSql]" & " = " & TickSrchTable.Rows(Rws).Item("TkSQL")
                                TickSrchTable.Rows(Rws).Item("تاريخ آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("TkupSTime")
                                TickSrchTable.Rows(Rws).Item("نص آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("TkupTxt")
                                TickSrchTable.Rows(Rws).Item("محرر آخر تحديث") = UpdtCurrTbl.DefaultView(0).Item("UsrRealNm")
                                TickSrchTable.Rows(Rws).Item("TkupReDt") = UpdtCurrTbl.DefaultView(0).Item("TkupReDt")
                                TickSrchTable.Rows(Rws).Item("TkupUser") = UpdtCurrTbl.DefaultView(0).Item("TkupUser")
                                TickSrchTable.Rows(Rws).Item("LastUpdateID") = UpdtCurrTbl.DefaultView(0).Item("TkupEvtId")
                                TickSrchTable.Rows(Rws).Item("EvSusp") = UpdtCurrTbl.DefaultView(0).Item("EvSusp")
                                TickSrchTable.Rows(Rws).Item("UCatLvl") = UpdtCurrTbl.DefaultView(0).Item("UCatLvl")
                                TickSrchTable.Rows(Rws).Item("TkupUnread") = UpdtCurrTbl.DefaultView(0).Item("TkupUnread")

                                StruGrdTk.LstUpDt = UpdtCurrTbl.DefaultView(0).Item("TkupSTime")
                                StruGrdTk.LstUpTxt = UpdtCurrTbl.DefaultView(0).Item("TkupTxt")
                                StruGrdTk.LstUpUsrNm = UpdtCurrTbl.DefaultView(0).Item("UsrRealNm")
                                StruGrdTk.LstUpEvId = UpdtCurrTbl.DefaultView(0).Item("TkupEvtId")

                            Catch ex As Exception
                            End Try
                        Next Rws
                        Invoke(Sub() ProgressBar1.Visible = False)

                        GridCuntRtrn.CompCount = Convert.ToInt32(TickSrchTable.Compute("count(TkSQL)", String.Empty))
                        GridCuntRtrn.NoFlwCount = Convert.ToInt32(TickSrchTable.Compute("count(TkFolw)", "TkFolw = 'False'"))
                        GridCuntRtrn.Recved = Convert.ToInt32(TickSrchTable.Compute("count(TkRecieveDt)", "TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd").ToString & "'"))
                        GridCuntRtrn.ClsCount = Convert.ToInt32(TickSrchTable.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"))
                        GridCuntRtrn.UpdtFollow = Convert.ToInt32(TickSrchTable.Compute("count(UsrRealNm)", "[محرر آخر تحديث] = UsrRealNm"))
                        GridCuntRtrn.UpdtColleg = Convert.ToInt32(TickSrchTable.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"))
                        GridCuntRtrn.UpdtOthrs = Convert.ToInt32(TickSrchTable.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"))
                        GridCuntRtrn.UnReadCount = Convert.ToInt32(TickSrchTable.Compute("count(TkupUnread)", "TkupUnread = 'False'"))
                        GridCuntRtrn.Esc1 = Convert.ToInt32(TickSrchTable.Compute("count(LastUpdateID)", "LastUpdateID = 902"))
                        GridCuntRtrn.Esc2 = Convert.ToInt32(TickSrchTable.Compute("count(LastUpdateID)", "LastUpdateID = 903"))
                        GridCuntRtrn.Esc3 = Convert.ToInt32(TickSrchTable.Compute("count(LastUpdateID)", "LastUpdateID = 904"))
                        Invoke(Sub() LblMsg.Text = ("نتيجة البحث : إجمالي عدد " & GridCuntRtrn.TickCount & " -- عدد الشكاوى : " & GridCuntRtrn.CompCount & " -- عدد الاستفسارات : " & GridCuntRtrn.TickCount - GridCuntRtrn.CompCount & " -- شكاوى مغلقة : " & GridCuntRtrn.ClsCount & " -- شكاوى مفتوحة : " & GridCuntRtrn.CompCount - GridCuntRtrn.ClsCount & " -- لم يتم المتابعة : " & GridCuntRtrn.NoFlwCount))
                        Invoke(Sub() LblMsg.ForeColor = Color.Green)
                        Invoke(Sub() GridTicket.ClearSelection())
                        Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold))
                        Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False)
                        Invoke(Sub() GridTicket.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter)
                        Invoke(Sub() GridTicket.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular))
                        Invoke(Sub() GridTicket.AutoResizeColumns())
                        Invoke(Sub() GridTicket.Columns("نص آخر تحديث").Width = 250)

                    Else
                        Invoke(Sub() LblMsg.Text = ("لا توجد نتيجة للبحث بـ" & FilterComb.Text))
                        Invoke(Sub() LblMsg.ForeColor = Color.Red)
                    End If
                    Invoke(Sub() GridTicket.Visible = True)
                Else
                    Invoke(Sub() LblMsg.Text = "لم ينجح البحث - يرجى المحاولة مرة أخرى")
                    Invoke(Sub() LblMsg.ForeColor = Color.Red)
                    Invoke(Sub() Beep())
                End If
            Else
            End If
        Else
            Invoke(Sub() LblMsg.Text = ("برجاء ادخال كلمات البحث"))
            Invoke(Sub() LblMsg.ForeColor = Color.Red)
            Beep()
        End If
        FltrStr = Nothing
        Invoke(Sub() BtnSerch.Enabled = True)
        Invoke(Sub() BtnCncl.Enabled = False)
        Invoke(Sub() GroupBox1.Enabled = True)
        Invoke(Sub() GroupBox2.Enabled = True)
        Invoke(Sub() PrdKComb.Enabled = True)
        Invoke(Sub() FilterComb.Enabled = True)
    End Sub
    Private Sub SerchTxt_Enter(sender As Object, e As EventArgs) Handles SerchTxt.Enter
        If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
            SerchTxt.Text = ""
            SerchTxt.ForeColor = Color.Black
        End If
    End Sub
    Private Sub SerchTxt_Leave(sender As Object, e As EventArgs) Handles SerchTxt.Leave, MyBase.Load
        If SerchTxt.TextLength = 0 Then
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
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
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        If IsNothing(Def.Thread_) = False Then
            If Def.Thread_.IsAlive = True Then
                Def.Thread_.Abort()
            End If
        End If

        Me.Close()
    End Sub
#End Region
    Private Sub SerchTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SerchTxt.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Def.Thread_ = New Thread(AddressOf Filtr)
            Def.Thread_.IsBackground = True
            Def.Thread_.Start()
        End If
    End Sub
    Private Sub GridTicket_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridTicket.RowEnter
        StruGrdTk.Sql = 0
    End Sub
    Private Sub TikSearchNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub BtnCncl_Click(sender As Object, e As EventArgs) Handles BtnCncl.Click
        Def.Thread_.Abort()
        Invoke(Sub() GroupBox1.Enabled = True)
        Invoke(Sub() GroupBox2.Enabled = True)
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        BtnSerch.Enabled = True
        GridTicket.Visible = False
        LblMsg.Text = ""
        Invoke(Sub() PrdKComb.Enabled = True)
        Invoke(Sub() FilterComb.Enabled = True)
    End Sub
End Class