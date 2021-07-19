Public Class TicketRAsgnMany
    Private ReadOnly UsrTable As DataTable = New DataTable
    Dim SerchTable As DataTable = New DataTable()
    Dim UpdtCurrTbl As DataTable = New DataTable
    Dim FollowTable As DataTable = New DataTable
    Dim TempNode() As TreeNode
    Dim UsrStr As String = ""
    Dim UsrStrAftrSlct As String = ""
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
            BtnSub(Me)
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
            'FilterComb.SelectedIndex = -1
            UsrTable.Rows.Clear()
            UserTree.ImageList = ImgLst
            If Mid(Usr.PUsrLvl, 17, 1) = "A" Then
                UserTree.Nodes.Add("2", 32006 & " - " & "الإدارة العامة لخدمة العملاء" & " - " & "رفعت السعيد", 1, 3)
            Else
                UserTree.Nodes.Add(Usr.PUsrCat.ToString, Usr.PUsrID & " - " & Usr.PUsrCatNm & " - " & Usr.PUsrRlNm, 1, 3)
            End If
            '                   0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
            If GetTbl("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) Order By UCatIdSub, UsrRealNm", UsrTable, "1025&H") = Nothing Then
                For Cnt_ = 0 To UsrTable.Rows.Count - 1
                    TempNode = UserTree.Nodes.Find(UsrTable(Cnt_).Item(2).ToString, True)
                    If TempNode.Length > 0 Then
                        TempNode(0).Nodes.Add(UsrTable(Cnt_).Item(1).ToString, UsrTable(Cnt_).Item(0).ToString & " - " & UsrTable(Cnt_).Item(4).ToString, 0, 2)
                        UsrStr &= "TkEmpNm = " & UsrTable(Cnt_).Item(0).ToString & " OR "
                        If TempNode(0).Nodes.Count > 0 Then
                            TempNode(0).ImageIndex = 1
                            TempNode(0).SelectedImageIndex = 3
                        End If
                    End If
                Next Cnt_
                If UsrStr.Length > 0 Then UsrStr = " AND (" & Mid(UsrStr, 1, UsrStr.Length - 4) & ")" Else UsrStr = ""
                UserTree.CollapseAll()
            End If
            FilGrdTbl()
            Filtr()
            AddHandler FilterComb.SelectedIndexChanged, (AddressOf FilterComb_SelectedIndexChanged)
            AddHandler SerchTxt.TextChanged, (AddressOf SerchTxt_TextChanged)
            AddHandler UserTree.AfterSelect, (AddressOf UserTree_AfterSelect)
            UserTree.SelectedNode = UserTree.Nodes(0)
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
        '  Table                       0      1       2         3      4     5       6       7         8       9         10         11       12       13       14        15         16      17      18       19               20          21      22        23         24        25        26          27                  28                   29                   30                  31                32                33              34                  35                     36                       37                                 38        39                                    40                                                                                          **********
        If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, TicketsAll.UsrRealNm, TicLstEv.LstSqlEv, TicLstEv.LstUpdtTime, TkEvent.TkupTxt, TkEvent.TkupUnread, TkEvent.TkupEvtId, CDEvent.EvNm, CDEvent.EvSusp, Int_user.UsrRealNm AS LstUpUsr, TkReOp, CONVERT(VARCHAR, TkRecieveDt, 111) As TkRecieveDt, TkEscTyp, ProdKNm, CASE WHEN TkEmpNm = TkupUser THEN 0 ELSE CASE WHEN IntUserCat.UCatLvl between 3 and 5 then 1 ELSE 2 END END AS UpdtUserCase FROM TicketsAll INNER JOIN TkEvent ON TkSQL = TkEvent.TkupTkSql INNER JOIN TicLstEv ON TkEvent.TkupSQL = TicLstEv.LstSqlEv INNER JOIN CDEvent ON TkEvent.TkupEvtId = CDEvent.EvId INNER JOIN Int_user ON TkEvent.TkupUser = Int_user.UsrId INNER JOIN IntUserCat ON dbo.Int_user.UsrCat = IntUserCat.UCatId WHERE (TkClsStatus = 0) " & UsrStr & " ORDER BY TkSQL;", FollowTable, "1028&H") = Nothing Then
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
                FltrStr &= " And (TkRecieveDt = '" & Format(Nw, "dd/MM/yyyy") & "')"
            Else
                FltrStr = "(TkRecieveDt = '" & Format(Nw, "dd/MM/yyyy") & "')"
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
        If IsNothing(UserTree.SelectedNode) = False Then
            If FltrStr.Length > 0 Then
                FltrStr &= " And " & Mid(UsrStrAftrSlct, 5, UsrStrAftrSlct.Length)
            Else
                FltrStr = Mid(UsrStrAftrSlct, 5, UsrStrAftrSlct.Length)
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
                     Where Format(row.Cells("TkRecieveDt").Value.ToString, "short date") = Format(Now, "short date") And row.Cells("TkRecieveDt").Value IsNot DBNull.Value.ToString
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
        If GridTicket.Rows.Count > 0 Then
            PublicCode.FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
            If StruGrdTk.ClsStat = True Then
                TcktImg.BackgroundImage = My.Resources.Tckoff
                BtnUpd.Visible = False
            Else
                TcktImg.BackgroundImage = My.Resources.Tckon
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
            TabControl1.SelectedTab = TabPage2
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
    Private Sub GridUpdt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUpdt.CellClick
        If GridUpdt.CurrentRow.Cells(6).Value = False Then
            If PublicCode.InsUpd("update TkEvent set TkupUnread = 1, TkupReDt = (Select GetDate()) where TkupSQL = " & GridUpdt.CurrentRow.Cells(0).Value & ";", "1035&H") = Nothing Then
                GridUpdt.CurrentRow.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                If GridUpdt.CurrentRow.Index = 0 Then GridTicket.CurrentRow.Cells(32).Value = True
                GridUpdt.CurrentRow.Cells(6).Value = True
                GridUpdt.CurrentRow.Cells(8).Value = Now
            Else
                MsgErr("لم يتم تسجيل قراءة التحديث" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        End If
    End Sub
    Private Sub CmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent.SelectedIndexChanged
        TxtUpdt.ReadOnly = False
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
    Private Sub BtnBck2_Click(sender As Object, e As EventArgs) Handles BtnBck2.Click
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs)
        If UserTree.SelectedNode.Nodes.Count > 0 Then
            UsrStrAftrSlct = ""
            For Cnt_ = 0 To UsrTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTree.SelectedNode.Name.ToString, True)
                If UserTree.SelectedNode.Name.ToString = UsrTable(Cnt_).Item(2).ToString Then
                    UsrStrAftrSlct &= "TkEmpNm = " & UsrTable(Cnt_).Item(0).ToString & " OR "
                End If
            Next Cnt_
            If UsrStrAftrSlct.Length > 0 Then
                If UsrStrAftrSlct.Length > 0 Then UsrStrAftrSlct = "AND (" & Mid(UsrStrAftrSlct, 1, UsrStrAftrSlct.Length - 4) & ")" Else UsrStrAftrSlct = ""
            Else
                UsrStrAftrSlct = ""
            End If
        Else
            UsrStrAftrSlct = "AND (TkEmpNm = " & Split(UserTree.SelectedNode.Text, "-")(0) & ")"
        End If
        Filtr()
    End Sub
    Private Sub Chck_CheckedChanged(sender As Object, e As EventArgs) Handles ChckUpdOther.CheckedChanged, ChckFlN.CheckedChanged, ChckTrnsDy.CheckedChanged, ChckUpdColeg.CheckedChanged, ChckUpdMe.CheckedChanged, ChckUpdAll.CheckedChanged, ChckRead.CheckedChanged, ChckEsc1.CheckedChanged, ChckEsc2.CheckedChanged, ChckEsc3.CheckedChanged
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

    Private Sub SerchTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles SerchTxt.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            SerchTxt.Text = Clipboard.GetText()
        End If
    End Sub

    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs) Handles GridTicket.SelectionChanged
        If GridTicket.SelectedCells.Count > 0 Then
            StatBrPnlEn.Text = GridTicket.CurrentRow.Index + 1 & " Of " & GridTicket.Rows.Count.ToString("N0")
        End If
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridTicket.CurrentCell.Value)
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
    Private Sub submt()
        RemoveHandler UserTree.AfterSelect, (AddressOf UserTree_SelectForTransfer)
        Dim TrnsErr As Boolean = False
        Dim TrnsECnt_Count As Integer = 0
        Dim TrnsCnt As Integer = 0
        For Cnt_ = 0 To GridTicket.Rows.Count - 1
            'PublicCode.FncGrdCurrRow(GridTicket, Cnt_)
            TrnsCnt += 1
            LblStus.Text = "جاري تحويل " & TrnsCnt & " من " & (From row As DataGridViewRow In GridTicket.Rows
                                                               Where Len(row.Cells(28).Value.ToString) > 0 And row.Cells(28).Value IsNot DBNull.Value.ToString
                                                               Select row.Cells(28).Value).Count().ToString("N0") & " شكوى"
            LblStus.Refresh()
            LblStus.ForeColor = Color.Green
            Try
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                sqlComminsert_1.Connection = sqlCon
                sqlComminsert_2.Connection = sqlCon
                sqlComminsert_1.CommandType = CommandType.Text
                sqlComminsert_2.CommandType = CommandType.Text

                sqlComminsert_1.CommandText = "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & GridTicket.Rows(Cnt_).Cells(1).Value.ToString & "','" & "The Complain has been Transfered To " & Trim(Split(UserTree.SelectedNode.Text, "-")(2)) & "','" & "1" & "'," & 100 & ",'" & OsIP() & "','" & Usr.PUsrID & "')"
                sqlComminsert_2.CommandText = "update Tickets set TkEmpNm = " & Trim(Split(UserTree.SelectedNode.Text, "-")(0)) & ", TkRecieveDt = (Select GetDate()) Where (TkSQL = " & GridTicket.Rows(Cnt_).Cells(1).Value & ")"
                '                                                                                                                                 
                Tran = sqlCon.BeginTransaction()
                sqlComminsert_1.Transaction = Tran
                sqlComminsert_2.Transaction = Tran
                sqlComminsert_1.ExecuteNonQuery()
                sqlComminsert_2.ExecuteNonQuery()
                Tran.Commit()
                'sqlCon.Close()
                'SqlConnection.ClearPool(sqlCon)
            Catch ex As Exception
                Tran.Rollback()
                AppLog("1027&H", Errmsg, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText)
                TrnsErr = True
                TrnsECnt_Count += 1
            End Try
        Next Cnt_
        AddHandler UserTree.AfterSelect, (AddressOf UserTree_AfterSelect)
        LblStus.Text = "تم تحويل عدد " & (From row As DataGridViewRow In GridTicket.Rows
                                          Where Len(row.Cells(28).Value.ToString) > 0 And row.Cells(28).Value IsNot DBNull.Value.ToString
                                          Select row.Cells(28).Value).Count().ToString("N0") & " شكوى إلى " & Trim(Split(UserTree.SelectedNode.Text, "-")(2))
        LblMsg.ForeColor = Color.Green
        FilGrdTbl()
        BtnSubmit.Text = "تحويل"
        BtnSubmit.BackgroundImage = My.Resources.recgreen
        'Filtr()
        If TrnsErr = True Then GoTo Err_
        Exit Sub
Err_:
        LblStus.Text = ""
        WelcomeScreen.TimerCon.Start()
        WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
        MsgErr("كود خطأ : " & "1027&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & "لم يتم تحويل عدد " & TrnsECnt_Count)
    End Sub
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        If BtnSubmit.Text = "تحويل" Then
            RemoveHandler UserTree.AfterSelect, (AddressOf UserTree_AfterSelect)
            MsgInf("برجاء اختيار اسم الموظف المراد التحويل له")
            UserTree.Refresh()
            AddHandler UserTree.AfterSelect, (AddressOf UserTree_SelectForTransfer)
        ElseIf BtnSubmit.Text = "Submit" Then
            Rslt = MessageBox.Show("سيتم تحويل عدد " & GridTicket.Rows.Count & " شكوى من " & GridTicket.Rows(0).Cells(28).Value & vbNewLine & "إلى " & Split(UserTree.SelectedNode.Text, "-")(2) & vbNewLine & "هل تريد الاستمرار ؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            If Rslt = DialogResult.Yes Then submt()
        End If

    End Sub
    Private Sub UserTree_SelectForTransfer(sender As Object, e As TreeViewEventArgs)
        BtnSubmit.Text = "Submit"
        BtnSubmit.BackgroundImage = My.Resources.recblue
    End Sub
End Class