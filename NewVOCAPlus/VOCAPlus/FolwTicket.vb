Imports System.Net
Imports System.IO
Public Class FolwTicket
    Dim SerchTable As DataTable = New DataTable()
    Dim UpdtCurrTbl As DataTable = New DataTable
    Dim FollowTable As DataTable = New DataTable
    Dim TempData As DataView
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim FileName As String
    Dim Ext As String
    Private ds As DateTime = Now
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
            CmbEvent.DataSource = UpdateKTable
            CmbEvent.DisplayMember = "EvNm"
            CmbEvent.ValueMember = "EvId"
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

            AddHandler GridTicket.SelectionChanged, AddressOf GridTicket_SelectionChanged
            AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
            AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
        End If
        If (Now.Subtract(ds).TotalMilliseconds) > 1000 Then
            Me.Text &= "_" & ((Now.Subtract(ds).TotalMilliseconds) / 1000).ToString("N2") & " Sec"
        Else
            Me.Text &= "_" & ((Now.Subtract(ds).TotalMilliseconds)).ToString("N2") & " M Sec"
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
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ...................."
        '  Table                                               0                     1       2       3         4     5       6      7        8       9      10         11       12       13       14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29              30                  31        32          33       34     35       36       37                          38                                            39                                    40                                                      41                                                                                 **********
        '  Grid                                                0                     1       2       3         4     5       6      7        8       9      10         11       12       13       14        15        16         17      18      19        20            21          22        23       24          25        26       27                  28              29               30                 31        32          33       34     35       36       37                          38                                            39                                    40                                                      41                                                 42                              ***********
        If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, TicketsAll.UsrRealNm, TicLstEv.LstSqlEv, TicLstEv.LstUpdtTime, TkEvent.TkupTxt, TkEvent.TkupUnread, TkEvent.TkupEvtId, CDEvent.EvNm, CDEvent.EvSusp, Int_user.UsrRealNm AS LstUpUsr, TkReOp, CONVERT(VARCHAR, TkRecieveDt, 111) As TkRecieveDt, TkEscTyp, ProdKNm, CASE WHEN TkEmpNm = TkupUser THEN 0 ELSE CASE WHEN IntUserCat.UCatLvl between 3 and 5 then 1 ELSE 2 END END AS UpdtUserCase,CompHelp FROM TicketsAll INNER JOIN TkEvent ON TkSQL = TkEvent.TkupTkSql INNER JOIN TicLstEv ON TkEvent.TkupSQL = TicLstEv.LstSqlEv INNER JOIN CDEvent ON TkEvent.TkupEvtId = CDEvent.EvId INNER JOIN Int_user ON TkEvent.TkupUser = Int_user.UsrId INNER JOIN IntUserCat ON dbo.Int_user.UsrCat = IntUserCat.UCatId WHERE (TkClsStatus = 0) AND (TkEmpNm = " & Usr.PUsrID & ") ORDER BY TkSQL;", FollowTable, "1028&H") = Nothing Then
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
                FltrStr &= " And (TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd") & "')"
            Else
                FltrStr = "(TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd") & "')"
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
        ElseIf ChckEsc1.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkupEvtId = '" & 902 & "'"
            Else
                FltrStr = "TkupEvtId = '" & 902 & "'"
            End If
        ElseIf ChckEsc2.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkupEvtId = '" & 903 & "'"
            Else
                FltrStr = "TkupEvtId = '" & 903 & "'"
            End If
        ElseIf ChckEsc3.Checked = True Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And TkupEvtId = '" & 904 & "'"
            Else
                FltrStr = "TkupEvtId = '" & 904 & "'"
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
                     Where Format(row.Cells("TkRecieveDt").Value.ToString, "Short Date") = Format(Nw, "Short Date") And row.Cells("TkRecieveDt").Value IsNot DBNull.Value.ToString
                     Select row.Cells("TkRecieveDt").Value).Count().ToString("N0")
        Lbl5.Text = (From row As DataGridViewRow In GridTicket.Rows
                     Where row.Cells("TkupUnread").Value = 0 And row.Cells("TkupUnread").Value IsNot DBNull.Value
                     Select row.Cells("TkupUnread").Value).Count().ToString("N0")
        Lbl6.Text = ((From row As DataGridViewRow In GridTicket.Rows
                      Where row.Cells("TkupEvtId").Value = 902 And row.Cells("TkupEvtId").Value IsNot DBNull.Value
                      Select row.Cells("TkupEvtId").Value).Count()).ToString("N0")
        Lbl7.Text = ((From row As DataGridViewRow In GridTicket.Rows
                      Where row.Cells("TkupEvtId").Value = 903 And row.Cells("TkupEvtId").Value IsNot DBNull.Value
                      Select row.Cells("TkupEvtId").Value).Count()).ToString("N0")
        Lbl8.Text = ((From row As DataGridViewRow In GridTicket.Rows
                      Where row.Cells("TkupEvtId").Value = 904 And row.Cells("TkupEvtId").Value IsNot DBNull.Value
                      Select row.Cells("TkupEvtId").Value).Count()).ToString("N0")
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
                BtnClos.BackgroundImage = My.Resources.Tckoff
                BtnClos.Enabled = False
                BtnUpd.Visible = False
            Else
                TcktImg.BackgroundImage = My.Resources.Tckon
                BtnClos.BackgroundImage = My.Resources.CpClose
                BtnClos.Enabled = True
                BtnUpd.Visible = True
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
            LblHelp.Text = StruGrdTk.Help_

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
    Private Sub CmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent.SelectedIndexChanged
        TxtUpdt.ReadOnly = False
        BtnBrws.Enabled = True
    End Sub
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs) Handles TxtUpdt.Leave
        If TxtUpdt.TextLength = 0 Then
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        If CmbEvent.SelectedIndex > -1 Then
            If TxtUpdt.TextLength > 0 Then
                'If StruGrdTk.FlwStat = False Then
                Try
                    If sqlCon.State = ConnectionState.Closed Then
                        sqlCon.Open()
                    End If
                    sqlComminsert_1.Connection = sqlCon
                    sqlComminsert_2.Connection = sqlCon
                    sqlComminsert_3.Connection = sqlCon
                    sqlComminsert_1.CommandType = CommandType.Text
                    sqlComminsert_2.CommandType = CommandType.Text
                    sqlComminsert_3.CommandType = CommandType.Text
                    sqlComminsert_1.CommandText = "update Tickets set TkFolw = 1, TkEscTyp = 0" & " where (TkSQL = " & StruGrdTk.Sql & ");"
                    sqlComminsert_2.CommandText = "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & TxtUpdt.Text & "','" & "1" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')"
                    sqlComminsert_3.CommandText = "update TkEvent set TkupUnread = 1, TkupReDt = (Select GetDate())" & " where (TkupTkSql = " & StruGrdTk.Sql & ") AND (TkupUnread = 0);"
                    Tran = sqlCon.BeginTransaction()
                    sqlComminsert_1.Transaction = Tran
                    sqlComminsert_2.Transaction = Tran
                    sqlComminsert_3.Transaction = Tran
                    sqlComminsert_1.ExecuteNonQuery()
                    sqlComminsert_2.ExecuteNonQuery()
                    sqlComminsert_3.ExecuteNonQuery()
                    Tran.Commit()
                    'sqlCon.Close()
                    'SqlConnection.ClearPool(sqlCon)
                    GridTicket.CurrentRow.Cells(26).Value = True
                Catch ex As Exception
                    Tran.Rollback()
                    AppLog("1039&H", ex.Message, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText)
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                    MsgErr("كود خطأ : " & "1039&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    Exit Sub
                End Try
                'Else
                '    If PublicCode.InsTrans("update Tickets set TkEscTyp = 0" & " where (TkSQL = " & StruGrdTk.Sql & ");", "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & TxtUpdt.Text & "','" & "1" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1034&H") <> Nothing Then
                '        Exit Sub
                '    End If
                'End If
                LblMsg.Text = ("تم إضافة التحديث بنجاح")
                LblMsg.ForeColor = Color.Green
                GridTicket.CurrentRow.Cells(30).Value = Format(Now, "yyyy/MM/dd")
                GridTicket.CurrentRow.Cells(31).Value = TxtUpdt.Text
                If GridTicket.CurrentRow.Cells(35).Value = True Then GridTicket.CurrentRow.Cells(35).Value = False
                GridTicket.CurrentRow.Cells(36).Value = Usr.PUsrID
                UpdtEvent()
                GridUpdt.Rows(0).Selected = True             'Select Row(0) Before upload to get SQL As file Name
                If TxtBrws.TextLength > 0 Then               ' Upload File If TxtBrws is have file
                    CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                    Uploadsub()
                Else
                    CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                End If
                CmbEvent.SelectedIndex = -1
                TxtUpdt.Text = ""
                TxtUpdt.ReadOnly = True
            Else
                Beep()
                LblMsg.Text = ("برجاء كتابة نص التحديث")
                LblMsg.ForeColor = Color.Red
            End If
        Else
            Beep()
            LblMsg.Text = ("برجاء اختيار نوع التحديث")
            LblMsg.ForeColor = Color.Red
        End If
    End Sub
    Private Sub UpdtEvent()
        UpdtCurrTbl.Rows.Clear()
        '                    0        1         2         3         4         5        6          7           8         9
        If PublicCode.GetTbl("SELECT TkupSQL, TkupSTime, TkupTxt, UsrRealNm, TkupUser, EvSusp, TkupUnread, TkupTkSql, TkupReDt, UCatLvl FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where (TkupTkSql = " & StruGrdTk.Sql & ") ORDER BY TkupSQL DESC", UpdtCurrTbl, "1029&H") = Nothing Then

        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.TabPages.Contains(TabPage3) = True Then
            If TabControl1.SelectedIndex = 2 Then
                TabPage3.Text = "Ticket No.: " & StruGrdTk.TkId & " Updates"
                If UpdtCurrTbl.Columns.Count = 10 Then
                    UpdtCurrTbl.Columns.Add("File")        ' Add files Columns If Not Added
                End If
                UpdtEvent()
                GridUpdt.DataSource = UpdtCurrTbl
                If UpdtCurrTbl.Columns.Count = 10 Then
                    UpdtCurrTbl.Columns.Add("File")        ' Add files Columns If Not Added
                End If
                UpGrgFrmt(GridUpdt, StruGrdTk.UserId)
                GettAttchUpdtesFils()
                CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                If GridUpdt.SelectedRows.Count = 0 Then
                    ContextMenuStrip2.Enabled = False
                End If
                If TxtUpdt.TextLength = 0 Then
                    CmbEvent.SelectedIndex = -1
                    TxtUpdt.ReadOnly = True
                End If
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
    Private Sub BtnClos_Click(sender As Object, e As EventArgs) Handles BtnClos.Click
        Dim Rslt As DialogResult
        Rslt = MessageBox.Show("سيتم إغلاق الشكوى نهائيا" & vbCrLf & "هل تريد الإستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        If Rslt = DialogResult.Yes Then
            BtnClos.Enabled = False
            If InsTrans("update Tickets set TkDtClose = (Select GetDate())" & ", TkDuration = " & CalDate(StruGrdTk.DtStrt, ServrTime, "1036&H") & ", TkClsStatus = 1" & ", TkFolw = 1" & " where (TkSQL = " & StruGrdTk.Sql & ");",
                    "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" &
                    StruGrdTk.Sql & "','" & "The Complaint has been closed" & "','" & "1" & "','" & "900" & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1037&H") = Nothing Then
                TcktImg.BackgroundImage = My.Resources.Tckoff
                GridTicket.CurrentRow.Cells(25).Value = True
                BtnClos.BackgroundImage = My.Resources.Tckoff
                GridTicket.Rows.RemoveAt(GridTicket.CurrentRow.Index)
                BtnUpd.Visible = False
                If TabControl1.TabPages.Contains(TabPage3) = True Then TabControl1.TabPages.Remove(TabPage3)
                Usr.PUsrClsN -= 1   'to don't recieve notification with Ticket count trnasfered to 
                MsgInf("تم إغلاق الشكوى رقم " & StruGrdTk.TkId & " في عدد " & CalDate(StruGrdTk.DtStrt, CStr(Nw), "1036&H") & " يوم عمل")
            Else
                BtnClos.Enabled = True
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        End If
    End Sub
    Private Sub BtnBck2_Click(sender As Object, e As EventArgs) Handles BtnBck2.Click
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub Chck_CheckedChanged(sender As Object, e As EventArgs) Handles ChckUpdOther.CheckedChanged, ChckUpdMe.CheckedChanged, ChckUpdColeg.CheckedChanged, ChckUpdAll.CheckedChanged, ChckTrnsDy.CheckedChanged, ChckRead.CheckedChanged, ChckFlN.CheckedChanged, ChckEsc3.CheckedChanged, ChckEsc2.CheckedChanged, ChckEsc1.CheckedChanged
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
    Private Sub ChckRead_CheckedChanged(sender As Object, e As EventArgs) Handles ChckRead.CheckedChanged
        Filtr()
    End Sub
    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs)

        If GridTicket.SelectedCells.Count > 0 Then
            StatBrPnlEn.Text = GridTicket.CurrentRow.Index + 1 & " Of " & GridTicket.Rows.Count.ToString("N0")
        End If

    End Sub
    Private Sub CompareDataTables(ByVal dt1 As DataTable, ByVal dt2 As DataTable)
        Dim Results =
            (From table1 In dt1
             Join table2 In dt2 On table1.Field(Of Integer)("ID") Equals table2.Field(Of Integer)("TkupSQL")
             Where table1.Field(Of Integer)("ID") = table2.Field(Of Integer)("TkupSQL")
             Select table1)
        For Each row As DataRow In Results
            For Count = 0 To GridUpdt.Rows.Count - 1
                If row.ItemArray(0) = GridUpdt.Rows(Count).Cells(0).Value Then
                    GridUpdt.Rows(Count).Cells(10).Value = "✔"
                    GridUpdt.Rows(Count).Cells(10).Tag = row.ItemArray(1)
                    GridUpdt.Rows(Count).Cells(10).ToolTipText = row.ItemArray(3) & "-" & row.ItemArray(4)
                End If
            Next
        Next
        GridUpdt.Columns(10).DefaultCellStyle.ForeColor = Color.Green
        GridUpdt.Columns(10).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridUpdt.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub 'Compare attached Table With Update Table
#Region "FTP Get & Upload & Download Sub"
    Private Sub BtnBrws_Click(sender As Object, e As EventArgs) Handles BtnBrws.Click
        LblMsg.Text = ""
        fd.Title = "File Upload"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        fd.Filter = "All files(*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        Path.GetFileName(StrFileName)
        If fd.ShowDialog() = DialogResult.OK Then
            Dim fi As New FileInfo(fd.FileName)
            Dim size As Long = fi.Length
            If size > 2097152 Then
                MsgInf("حجم الملف لابد ان يكون أقل أو يساوى 2 MB" & vbCrLf & "حجم الملف = " & (size / 1024 / 1024).ToString("N2") & " MB")
                Exit Sub
            End If
            StrFileName = fd.FileName
            TxtBrws.Text = StrFileName
            FileName = Path.GetFileName(StrFileName)
            Ext = Split(Path.GetFileName(StrFileName), ".")(1)
            ContextMenuStrip2.Items(1).Enabled = True
        End If
    End Sub
    Private Sub Uploadsub()
        LblMsg.Text = "جاري التحميل ...."
        LblMsg.Refresh()
        'Create Req
        If CheckIfFtpFileExists("ftp://10.10.26.4/CompUpdates/") = False Then
            Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create("ftp://10.10.26.4/CompUpdates/" & GridUpdt.CurrentRow.Cells(0).Value & "." & Ext), FtpWebRequest)
            'Upddate property
            mReq.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            mReq.Method = WebRequestMethods.Ftp.UploadFile
            mReq.Timeout = 20000
            'Read file
            Dim MFile() As Byte = File.ReadAllBytes(TxtBrws.Text)
            Me.Enabled = False
            Try
                'Upload
                Dim mStream As Stream = mReq.GetRequestStream()
                mStream.ReadTimeout = 2000
                mStream.Write(MFile, 0, MFile.Length)
                'CleanUp
                mStream.Close()
                mStream.Dispose()
                LblMsg.Text = "تم التحميل بنجاح"
                LblMsg.ForeColor = Color.Green
                TxtBrws.Text = ""
                Dim NewRow As DataRow = FTPTable.NewRow()
                Dim fi As New FileInfo(fd.FileName)
                NewRow("ID") = GridUpdt.CurrentRow.Cells(0).Value
                NewRow("Name") = GridUpdt.CurrentRow.Cells(0).Value & "." & Ext
                NewRow("Date Modified") = Nw
                NewRow("Type") = Ext
                NewRow("Size") = (fi.Length / 1024).ToString("N0") & " KB"
                FTPTable.Rows.Add(NewRow)
                CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                Me.Enabled = True
            Catch exs As Exception
                Me.Enabled = True
                LblMsg.Text = ""
                CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                MsgInf("لم يكتمل تحميل الملف بنجاح" & vbCrLf & exs.Message)
            End Try
        Else
            MsgInf("تم تحميل الملف من قبل")
        End If
    End Sub
    Private Function CheckIfFtpFileExists(ByVal fileUri As String) As Boolean
        Dim exist As Boolean = False
        Dim request As FtpWebRequest = WebRequest.Create(fileUri)
        request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
        request.Method = WebRequestMethods.Ftp.GetFileSize
        request.Timeout = 20000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            request.Abort()
            ' THE FILE EXISTS
            exist = True
        Catch ex As WebException
            Dim response As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                ' THE FILE DOES NOT EXIST
                exist = False
            End If
        End Try
        Return exist
    End Function
    Private Sub Dowload()
        If Split(GridUpdt.CurrentRow.Cells(10).Tag, ".").Count > 1 Then
            LblMsg.Text = "جاري التنزيل ........"
            LblMsg.Refresh()
            LblMsg.ForeColor = Color.Green
            Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/CompUpdates/" & GridUpdt.CurrentRow.Cells(10).Tag)
            request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 20000
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream(),
fileStream As Stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & StruGrdTk.TkId & "_" & GridUpdt.CurrentRow.Cells(10).Tag)

                Dim buffer As Byte() = New Byte(10240 - 1) {}
                Dim read As Integer
                Do
                    read = ftpStream.Read(buffer, 0, buffer.Length)
                    If read > 0 Then
                        fileStream.Write(buffer, 0, read)
                    End If
                Loop While read > 0
                request.Abort()
                ftpStream.Close()
                ftpStream.Dispose()
                fileStream.Close()
                fileStream.Dispose()
                LblMsg.Text = "تم تنزيل الملف بنجاح"
                LblMsg.ForeColor = Color.Green
                Dim Rslt As DialogResult
                Rslt = MessageBox.Show("تم التنزيل بنجاح إلى " & "MyDocuments" & vbCrLf & "هل تريد فتح الملف", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & StruGrdTk.TkId & "_" & GridUpdt.CurrentRow.Cells(10).Tag)
                End If
            Catch ex As Exception
                request.Abort()
                LblMsg.Text = ""
                MsgBox(ex.Message)
            End Try
        Else
            LblMsg.Text = "لا يمكن تنزيل المجلد"
        End If

    End Sub
#End Region
#Region "Tool Strip GridUpdate"
    Private Sub CopyToolStripitem_Click(sender As Object, e As EventArgs) Handles CopyToolStripitem.Click
        Clipboard.SetText(GridUpdt.CurrentCell.Value)
    End Sub
    Private Sub DonlodAttchToolStripitem_Click(sender As Object, e As EventArgs) Handles DonlodAttchToolStripitem.Click
        Dowload()
    End Sub
    Private Sub UplodAtchToolStripitem_Click(sender As Object, e As EventArgs) Handles UplodAtchToolStripitem.Click
        Uploadsub()
    End Sub
    Private Sub GridUpdt_SelectionChanged(sender As Object, e As EventArgs) Handles GridUpdt.SelectionChanged
        If GridUpdt.Rows.Count > 0 Then
            GridUpdt.Rows(0).Selected = True
            If GridUpdt.CurrentRow.Cells(6).Value = False Then
                If PublicCode.InsUpd("update TkEvent set TkupUnread = 1, TkupReDt = (Select GetDate())" & " where TkupSQL = " & GridUpdt.CurrentRow.Cells(0).Value & ";", "1035&H") = Nothing Then
                    GridUpdt.CurrentRow.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                    If GridUpdt.CurrentRow.Index = 0 Then GridTicket.CurrentRow.Cells(32).Value = True
                    GridUpdt.CurrentRow.Cells(6).Value = True
                    GridUpdt.CurrentRow.Cells(8).Value = Now
                    'UpdtEvent()
                Else
                    MsgErr("لم يتم تسجيل قراءة التحديث" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End If
            End If
            ContextMenuStrip2.Enabled = True
            Dim subItem As New ToolStripMenuItem("Download Attached")
            If GridUpdt.Columns.Count = 11 Then
                If DBNull.Value.Equals(GridUpdt.CurrentRow.Cells(10).Value) = False Then
                    If GridUpdt.CurrentRow.Cells(10).Value = "✔" Then
                        ContextMenuStrip2.Items(2).Enabled = True
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                Else
                    If GridUpdt.CurrentRow.Cells(4).Value = Usr.PUsrID Then
                        BtnBrws.Enabled = True
                        If TxtBrws.TextLength > 0 Then
                            ContextMenuStrip2.Items(1).Enabled = True
                        ElseIf TxtBrws.TextLength = 0 Then
                            ContextMenuStrip2.Items(1).Enabled = False
                        End If
                    Else
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                    ContextMenuStrip2.Items(2).Enabled = False
                End If
            End If
        End If


    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If GridTicket.SelectedCells.Count > 0 Then
            TikIDRep_ = GridTicket.CurrentRow.Cells(1).Value
            TikFrmRep.ShowDialog()
        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
#End Region
End Class