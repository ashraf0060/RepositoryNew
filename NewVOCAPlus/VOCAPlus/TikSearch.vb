Imports System.Net
Imports System.IO
Imports Microsoft.Exchange.WebServices.Data
Public Class TikSearch
    Dim TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Dim PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Dim TickKindFltr As Integer = 2   'ticket kind      0=Inquiry and 1=Complaint
    Dim TicOpnFltr As Integer = 2      'ticket Sttaus   0=Open and 1=Close and 2=All
    Dim SerchItmTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim TickSrchTable As DataTable = New DataTable
    Dim UpdtCurrTbl As DataTable = New DataTable()
    Dim EscTable As New DataTable
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Private exchange As ExchangeService
    Dim Span_ As New TimeSpan
    Dim nxt As String
    Dim FileName As String
    Dim Ext As String
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TikSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else

            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
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
            CmbEvent.DataSource = UpdateKTable
            CmbEvent.DisplayMember = "EvNm"
            CmbEvent.ValueMember = "EvId"
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
        End If
    End Sub
#Region "First Tab"
    Private Sub BtnSerch_Click(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Filtr()
        TimerEscOpen.Stop()
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
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
        SerchTxt.ForeColor = Color.Black
        SerchTxt.Focus()
        SerchTxt.Text = ""
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If RadioButton1.Checked = True Then
            TickKindFltr = 0
        ElseIf RadioButton2.Checked = True Then
            TickKindFltr = 1
        ElseIf RadioButton3.Checked = True Then
            TickKindFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub RdioOpen_Click(sender As Object, e As EventArgs) Handles RdioOpen.Click, Rdiocls.Click, RdioAll.Click
        If RdioOpen.Checked = True Then
            TicOpnFltr = 0
        ElseIf Rdiocls.Checked = True Then
            TicOpnFltr = 1
        ElseIf RdioAll.Checked = True Then
            TicOpnFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrdKComb.SelectedIndexChanged
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String = ""
        Dim primaryKey(0) As DataColumn
        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
            LblMsg.Text = "جاري التحميل البيانات ..........."
            LblMsg.ForeColor = Color.Green
            LblMsg.Refresh()

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
            If TickKindFltr <> 2 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " and" & "[TkKind]" & " = " & TickKindFltr
                Else
                    FltrStr = "[TkKind]" & " = " & TickKindFltr
                End If
            End If
            If TicOpnFltr <> 2 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " and" & "[TkClsStatus]" & " = " & TicOpnFltr
                Else
                    FltrStr = "[TkClsStatus]" & " = " & TicOpnFltr
                End If
            End If
            primaryKey(0) = TickSrchTable.Columns("TkSQL")
            TickSrchTable.PrimaryKey = primaryKey
            TickSrchTable.Rows.Clear()
            If FltrStr.Length > 0 Then
                FltrStr = " Where " & FltrStr
                '  Grid                        1        2       3       4      5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27             28                    29                  30                  31               32                    33              34             35              36                        37        38            39       40      **************
                If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '' AS LstUpdtTime, '' AS TkupTxt, 1 AS TkupUnread, 0 AS TkupEvtId, '' AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll " & FltrStr & " ORDER BY TkSQL DESC;", TickSrchTable, "1042&H") = Nothing Then
                    If TickSrchTable.Rows.Count > 0 Then
                        SubGrdTikFill(GridTicket, TickSrchTable)  'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                        FncGrdTickInfo(GridTicket)
                        LblMsg.Text = ("نتيجة البحث : إجمالي عدد " & GridCuntRtrn.TickCount & " -- عدد الشكاوى : " & GridCuntRtrn.CompCount & " -- عدد الاستفسارات : " & GridCuntRtrn.TickCount - GridCuntRtrn.CompCount & " -- شكاوى مغلقة : " & GridCuntRtrn.ClsCount & " -- شكاوى مفتوحة : " & GridCuntRtrn.CompCount - GridCuntRtrn.ClsCount & " -- لم يتم المتابعة : " & GridCuntRtrn.NoFlwCount)
                        LblMsg.ForeColor = Color.Green
                        GridTicket.ClearSelection()
                    Else
                        LblMsg.Text = ("لا توجد نتيجة للبحث بـ" & FilterComb.Text)
                        LblMsg.ForeColor = Color.Red
                        Beep()
                    End If
                Else
                    LblMsg.Text = "لم ينجح البحث - يرجى المحاولة مرة أخرى"
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            End If
        Else
            LblMsg.Text = ("برجاء ادخال كلمات البحث")
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
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
                If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
                PublicCode.FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
                If StruGrdTk.ClsStat = True Then
                    TcktImg.BackgroundImage = My.Resources.Tckoff
                    BtnAddEdt.Enabled = False
                    TxtDetailsAdd.Enabled = False
                    TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة"
                    TxtDetailsAdd.TextAlign = HorizontalAlignment.Center
                    TxtDetailsAdd.Font = New Font("Times New Roman", 16, FontStyle.Regular)
                Else
                    TcktImg.BackgroundImage = My.Resources.Tckon
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
                TxtTransDt.Text = StruGrdTk.TransDt
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
                TabControl1.SelectedTab = TabPage2
                TickSrchTable.Rows.Clear()
                TabControl1.TabPages.Remove(TabPage1)
                If StruGrdTk.Tick = 0 Then
                    TabPage2.Text = "Inquiry No.: " & StruGrdTk.TkId
                Else
                    TabPage2.Text = "Complaint No.: " & StruGrdTk.TkId
                End If
            End If
            LblHelp.Text = StruGrdTk.Help_
        End If

    End Sub
    Private Sub BckBtn2_Click(sender As Object, e As EventArgs) Handles Btn2Bck.Click
        If TabControl1.TabPages.Contains(TabPage1) = False Then TabControl1.TabPages.Insert(1, TabPage1)
        TabControl1.SelectedTab = TabPage1
        TabControl1.TabPages.Remove(TabPage2)
        For Each c As Control In TabPage2.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If

        Next
        For Each c As Control In GroupBox4.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
        For Each c As Control In GroupBox3.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
#End Region

#Region "Updates Partision"
    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        Dim EsStr As String = ""
        If CmbEvent.SelectedIndex > -1 Then
            If TxtUpdt.TextLength > 0 Then
                If Usr.PUsrID = StruGrdTk.UserId Then
                    If PublicCode.InsTrans("update Tickets set TkFolw = 1, TkEscTyp = 0" & " where (TkSQL = " & StruGrdTk.Sql & ");", "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & TxtUpdt.Text & "','" & "1" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1034&H") <> Nothing Then
                    End If
                Else
                    If CmbEvent.SelectedValue = 902 Then
                        If PublicCode.InsUpd("update Tickets set TkEscTyp = 1" & " where (TkSQL = " & StruGrdTk.Sql & ");", "1034&H") = Nothing Then
                            If StruGrdTk.FlwStat = 0 Then
                                EsStr = "متابعه 1 جديد" & vbCrLf & TxtUpdt.Text
                            Else
                                EsStr = "متابعه 1" & vbCrLf & TxtUpdt.Text
                            End If
                        End If
                    Else
                        EsStr = TxtUpdt.Text
                    End If
                    If PublicCode.InsUpd("insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & Trim(EsStr) & "','" & "0" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1034&H") <> Nothing Then
                    End If
                End If
                LblMsg.Text = ("تم إضافة التحديث بنجاح")
                LblMsg.ForeColor = Color.Green
                StruGrdTk.LstUpDt = Now
                StruGrdTk.LstUpTxt = TxtUpdt.Text
                StruGrdTk.LstUpEvId = CmbEvent.SelectedValue
                If StruGrdTk.LstUpSys = True Then StruGrdTk.LstUpSys = False
                StruGrdTk.LstUpUsrNm = Usr.PUsrID
                GetUpdtEvent(StruGrdTk.Sql)
                Dim FolwID As String = ""
                If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
                UpGrgFrmt(GridUpdt, FolwID)
                'GridUpdt.Rows(0).Selected = True             'Select Row(0) Before upload to get SQL As file Name
                If TxtBrws.TextLength > 0 Then               ' Upload File If TxtBrws is have file
                    CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                    Uploadsub()
                Else
                    CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                End If
                CmbEvent.SelectedIndex = -1
                TxtUpdt.Text = ""
                TxtUpdt.ReadOnly = True

                If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
                    CmbEvent.Enabled = False
                    TimerEscOpen.Start()
                Else
                    CmbEvent.Enabled = True
                    TimerEscOpen.Stop()
                End If
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
    Private Sub InsUpdtSub(StrWhere As Integer, Knd As ComboBox, Txt As TextBox, LblNm As Label)
        If Knd.SelectedIndex > -1 Then
            If Txt.TextLength > 0 Then
                If PublicCode.InsUpd("insert into TkEvent (TkupTkSql, TkupTxt, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StrWhere & "','" & Txt.Text & "','" & Knd.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1018&H") = Nothing Then
                    LblNm.Text = ("تم إضافة التحديث بنجاح")
                    LblNm.ForeColor = Color.Green
                    Knd.SelectedIndex = -1
                    Txt.Text = ""
                    Txt.ReadOnly = True
                End If
            Else
                LblNm.Text = ("برجاء كتابة نص التحديث")
                LblNm.ForeColor = Color.Red
                Beep()
            End If
        Else
            LblNm.Text = ("برجاء اختيار نوع التحديث")
            LblNm.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Public Sub GetUpdtEvent(StrWhere As Integer)
        UpdtCurrTbl.Rows.Clear()
        '                                 0        1         2         3         4        5        6         7         8         9
        If PublicCode.GetTbl("SELECT TkupSQL, TkupSTime, TkupTxt, UsrRealNm, TkupUser, EvSusp, TkupUnread, TkupTkSql, TkupReDt, UCatLvl FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where (TkupTkSql = " & StrWhere & ") ORDER BY TkupSQL DESC", UpdtCurrTbl, "1019&H") = Nothing Then
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub CompareDataTables(ByVal dt1 As DataTable, ByVal dt2 As DataTable)
        Dim Results =
            (From table1 In dt1
             Join table2 In dt2 On table1.Field(Of Integer)("ID") Equals table2.Field(Of Integer)("TkupSQL")
             Where table1.Field(Of Integer)("ID") = table2.Field(Of Integer)("TkupSQL")
             Select table1)

        For Count = 0 To GridUpdt.Rows.Count - 1
            For Each row As DataRow In Results
                If row.ItemArray(0) = GridUpdt.Rows(Count).Cells(0).Value Then
                    GridUpdt.Rows(Count).Cells(10).Value = "✔"
                    GridUpdt.Rows(Count).Cells(10).Tag = row.ItemArray(1)
                    GridUpdt.Rows(Count).Cells(10).ToolTipText = row.ItemArray(3) & "-" & row.ItemArray(4) & "-" & row.ItemArray(2)
                    Exit For
                End If
            Next
        Next
        GridUpdt.Columns(10).DefaultCellStyle.ForeColor = Color.Green
        GridUpdt.Columns(10).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridUpdt.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub 'Compare attached Table With Update Table
    Private Sub CmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent.SelectedIndexChanged
        TxtUpdt.ReadOnly = False
        TxtUpdt.Focus()
        BtnBrws.Enabled = True
    End Sub
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs) Handles TxtUpdt.Leave
        If TxtUpdt.TextLength = 0 Then
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        'If GridTicket.Rows.Count = TempData.Count Then        'Because when clear GridView to RePopulate din't Make Error 1019
        If TabControl1.TabPages.Contains(TabPage3) = False Then TabControl1.TabPages.Insert(1, TabPage3)
        TabControl1.SelectedTab = TabPage3
        TabControl1.TabPages.Remove(TabPage2)
    End Sub
    Private Sub BtnBckComp_Click(sender As Object, e As EventArgs) Handles BtnBckComp.Click
        If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2
        TabControl1.TabPages.Remove(TabPage3)
    End Sub
    Private Sub TxtUpdt2_KeyPress(sender As Object, e As KeyPressEventArgs)
        IntUtly.ValdtIntLetter(e)
    End Sub
    Private Sub GridUpdt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUpdt.CellClick

    End Sub
#End Region
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
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.TabPages.Contains(TabPage2) = True Then
        LblMsg.Text = ""
        If TabControl1.SelectedTab.Name = "TabPage1" Then
            If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
                SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
            End If
            TimerEscOpen.Stop()
        ElseIf TabControl1.SelectedTab.Name = "TabPage2" Then
            TimerVisInvs.Start()

            If Usr.PUsrUCatLvl < 3 And Usr.PUsrUCatLvl > 5 Then
                If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
                    TimerEscOpen.Start()
                Else
                    TimerEscOpen.Stop()
                End If
            End If

        ElseIf TabControl1.SelectedTab.Name = "TabPage3" Then
            GetUpdtEvent(StruGrdTk.Sql)
            GridUpdt.DataSource = UpdtCurrTbl
            Dim FolwID As String = ""
            If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
            If UpdtCurrTbl.Columns.Count = 10 Then
                UpdtCurrTbl.Columns.Add("File")        ' Add files Columns If Not Added
            End If
            UpGrgFrmt(GridUpdt, FolwID)
            LblWdays2.Text = "تم تسجيل الشكوى منذ :" & CalDate(StruGrdTk.DtStrt, Nw, "0000&H") & " يوم عمل"
            GettAttchUpdtesFils()
            CompareDataTables(FTPTable, UpdtCurrTbl)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
            If GridUpdt.SelectedRows.Count = 0 Then
                ContextMenuStrip2.Enabled = False
            End If
            If StruGrdTk.Tick = 0 Then
                TabPage3.Text = "Inquiry No. : " & StruGrdTk.TkId & " Updates"
                CmbEvent.Enabled = False
                BtnSubmt.Enabled = False
                TxtUpdt.Text = ""
                TxtUpdt.ReadOnly = True
                LblMsg.Text = "لا يمكن عمل تحديث على الاستفسار"
            Else
                TabPage3.Text = "Complaint No. : " & StruGrdTk.TkId & " Updates"
                CmbEvent.Enabled = True
                BtnSubmt.Enabled = True
                If TxtUpdt.TextLength = 0 Then
                    TxtUpdt.ReadOnly = True
                End If
                LblMsg.Text = ""
            End If

            Dim AcbDataTable As New DataTable
            Dim WdysTable As New DataTable

            If Usr.PUsrUCatLvl < 3 Or Usr.PUsrUCatLvl > 5 Then
                If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
                    TimerEscOpen.Start()
                Else
                    CmbEvent.Enabled = True
                    BtnSubmt.Enabled = True
                    TxtUpdt.Text = ""
                    TxtUpdt.ReadOnly = True
                    TxtUpdt.TextAlign = HorizontalAlignment.Left
                    TimerEscOpen.Stop()
                End If
            End If
            CmbEvent.SelectedIndex = -1
            TimerVisInvs.Start()
        End If
    End Sub
#Region "Esclation Buttons 'Not Used'"
    Private Sub BtnEsc_Click(sender As Object, e As EventArgs) Handles BtnEsc.Click
        ' 289421
        Dim AcbDataTable As New DataTable
        Dim EscTable As New DataTable
        Dim WdysTable As New DataTable
        Dim State As String = ""
        Dim Body_ As String = ""
        Dim EscCount As Integer = 0
        Dim WdNo As Boolean = False
        Dim sss As DateTime = Format(ServrTime(), "HH:mm:ss")

        LblMsg.Text = ""
        If StruGrdTk.EscCnt > 4 Then EscCount = 4 Else EscCount = StruGrdTk.EscCnt
        EscTable.Rows.Clear()
        EscTable.Columns.Clear()

        WdysTable.Rows.Clear()
        WdysTable.Columns.Clear()
        If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate(),111) as Now_)", WdysTable, "0000&H") = Nothing Then
            If WdysTable.Rows(0).Item("HDy") = 0 Then
                For cnt = 1 To 10
                    WdysTable.Rows.Clear()
                    If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate() +" & cnt & ",111) as Now_)", WdysTable, "0000&H") = Nothing Then
                        If WdysTable.Rows(0).Item("HDy") = 1 Then
                            MsgInf("القسم المختص أجازه اليوم، وسيتم التواصل مع العميل خلال مواعيد العمل الرسمية" & vbCrLf & "إبتداء من يوم " & WdysTable.Rows(0).Item("HDate") & " من الساعه 8 صباحاًوحتى الخامسه مساء يوميا " & vbCrLf & "ماعدا الجمعه والسبت والأجازات الرسمية")
                            WdNo = True
                            Exit For
                        End If
                    Else
                        MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        Exit Sub
                    End If
                Next
            ElseIf Format(ServrTime(), "HH:mm:ss") >= #1/1/0001 04:00:00 PM# Then
                WdysTable.Rows.Clear()
                For cnt = 1 To 10
                    WdysTable.Rows.Clear()
                    If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate() +" & cnt & ",111) as Now_)", WdysTable, "0000&H") = Nothing Then
                        If WdysTable.Rows(0).Item("HDy") = 1 Then
                            MsgInf("القسم المختص خارج مواعيد العمل، وسيتم التواصل مع العميل خلال مواعيد العمل الرسمية" & vbCrLf & "إبتداء من يوم " & WdysTable.Rows(0).Item("HDate") & " من الساعه 8 صباحاًوحتى الخامسه مساء يوميا " & vbCrLf & "ماعدا الجمعه والسبت والأجازات الرسمية")
                            WdNo = True
                            Exit For
                        End If
                    Else
                        MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        Exit Sub
                    End If
                Next
            End If
        Else
            MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Exit Sub
        End If

EscSecResp_:

        If EscCount > 0 Then
            If GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscCount, EscTable, "0000&H") = Nothing Then
                Dim Minuts As Double = ServrTime().Subtract(StruGrdTk.LstUpDt).TotalMinutes
                Dim MinutsDef As Integer = EscTable.Rows(0).Item("EscDur") - Minuts
                If StruGrdTk.LstUpEvId = 902 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 1 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 903 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 2 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 904 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 3 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 905 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل أقصى عدد من المتابعات وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 906 Or StruGrdTk.LstUpEvId = 907 Or StruGrdTk.LstUpEvId = 908 Or StruGrdTk.LstUpEvId = 909 Then
                    MsgInf("بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل المتابعه")
                    Exit Sub
                End If
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                Exit Sub
            End If
        End If

EscSec_:
        Try
            If StruGrdTk.EscCnt = 0 Then
                If WdNo = True Then
                    Esc = "بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل متابعة 1"
                    EscID = 906
                ElseIf WdNo = False Then
                    Esc = "تم عمل متابعة 1"
                    EscID = 902
                End If
                EscCnt = 1
            ElseIf StruGrdTk.EscCnt = 1 Then
                If WdNo = True Then
                    Esc = "بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل متابعة 2"
                    EscID = 907
                ElseIf WdNo = False Then
                    Esc = "تم عمل متابعة 2"
                    EscID = 903
                End If
                EscCnt = 2
            ElseIf StruGrdTk.EscCnt = 2 Then
                If WdNo = True Then
                    Esc = "بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل متابعة 3"
                    EscID = 908
                ElseIf WdNo = False Then
                    Esc = "تم عمل متابعة 3"
                    EscID = 904
                End If
                EscCnt = 3
            Else
                If WdNo = True Then
                    Esc = "بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم تسجيل الوصول للحد الأقصى للمتابعات "
                    EscID = 909
                ElseIf WdNo = False Then
                    Esc = "تم الوصول للحد الأقصى للمتابعات"
                    EscID = 905
                End If
                EscCnt = StruGrdTk.EscCnt + 1
            End If
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscCnt, tempTable, "0000&H") = Nothing Then
                AcbDataTable.Rows.Clear()
                LblMsg.Text = "Trying To Get Data "
                LblMsg.Refresh()
                If GetTbl("SELECT Tickets.TkSQL, Int_user.UsrRealNm AS UsrTik, Int_user.UsrEmail, Int_user_3.UsrRealNm AS CSTL, Int_user_3.UsrEmail AS CSTLMail, Int_user_1.UsrRealNm AS FolwUsr, Int_user_1.UsrSisco AS CCFlwPh, Int_user_1.UsrEmail AS FLWMail, Int_user_2.UsrRealNm AS CCTL, Int_user_2.UsrEmail AS CCTLMail, Int_user_2.UsrSisco AS CCTLPh, IntUserCat_1.UCatNm AS TeamNm
                    FROM Int_user AS Int_user_3 INNER JOIN (Int_user AS Int_user_2 INNER JOIN (IntUserCat INNER JOIN (IntUserCat AS IntUserCat_1 INNER JOIN (Int_user AS Int_user_1 INNER JOIN (Int_user INNER JOIN Tickets ON Int_user.UsrId = Tickets.TkEmpNm0) ON Int_user_1.UsrId = Tickets.TkEmpNm) ON IntUserCat_1.UCatId = Int_user_1.UsrCat) ON IntUserCat.UCatId = Int_user.UsrCat) ON Int_user_2.UsrCat = IntUserCat_1.UCatIdSub) ON Int_user_3.UsrCat = IntUserCat.UCatIdSub
                    where Tickets.TkSQL = " & StruGrdTk.Sql, AcbDataTable, "0000&H") = Nothing Then
                    LblMsg.Text = "Trying To Connect To Mail Server "
                    LblMsg.Refresh()

                    exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
                    exchange.Credentials = New WebCredentials("egyptpost\acb", "Hemonad105046")
                    exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                    LblMsg.Text = "Connected successfully to Server : " + exchange.Url.Host
                    LblMsg.Refresh()
                    LblMsg.Text = "Sending New Message To " & AcbDataTable.Rows(0).Item("FLWMail").ToString
                    LblMsg.Refresh()
                    Dim message As New EmailMessage(exchange)

                    message.ToRecipients.Add("a.farag@egyptpost.org")
                    'message.ToRecipients.Add(AcbDataTable.Rows(0).Item("FLWMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CSTLMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CCTLMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("UsrEmail").ToString)
                    'For Cnt = 0 To Split(tempTable.Rows(0).Item("EscCC"), ";").Count - 1
                    '    message.CcRecipients.Add(Split(tempTable.Rows(0).Item("EscCC"), ";")(Cnt))
                    'Next

                    message.Subject = Esc & " ل" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & " " & AcbDataTable.Rows(0).Item("TeamNm").ToString & " شكوى رقم : " & StruGrdTk.Sql
                    Dim aa As String = StruGrdTk.PrdKNm
                    If StruGrdTk.ClsStat = True Then State = "مغلقة" Else State = "مفتوحه"
                    Dim colr As String
                    If WdNo = True Then colr = "Green" Else colr = "Red"

                    message.Body = "<p style=" & Chr(34) & "text-align: right;" & Chr(34) & "><span style=" & Chr(34) & "font-size: 18px;" & Chr(34) & " >استاذ (ه) / " & AcbDataTable.Rows(0).Item(5).ToString & " </span></p>" &
                               "<p style=" & Chr(34) & "direction:rtl;text-align: right;color:Black;" & Chr(34) & ">" & "نص التحديث : " & "</p> " &
                               "<p style=" & Chr(34) & "direction:rtl;text-align: right;color:" & colr & ";" & Chr(34) & ">" & "             " & Esc & "</p> " &
                               "<table style=“ & Chr(34) & “width: 100%; direction: rtl; border-style: solid; border-color:" & colr & Chr(34) & “><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>رقم الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.Sql & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>اسم العميل:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.ClNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ تسجيل الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.DtStrt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ استلام الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.RecvDt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>حالة الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & State & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>مصدر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.Src & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>عدد المتابعات:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.EscCnt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpDt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نص آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpTxt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>محرر آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpUsrNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نوع المنتح:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.PrdKNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>اسم الخدمة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.ProdNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نوع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.CompNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>محرر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & AcbDataTable.Rows(0).Item(1).ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>متابع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>مشرف المجموعة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                               AcbDataTable.Rows(0).Item("CCTL").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>التليفون الداخلي:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                               AcbDataTable.Rows(0).Item("CCFlwPh").ToString & "-" & AcbDataTable.Rows(0).Item("CCTLPh").ToString & "</div></td></tr></tbody></table>" & "<br><br><p style=" & Chr(34) & "direction:rtl;text-align: right;" & Chr(34) & ">تم إرسال هذا البريد الإلكتروني من خلال تطبيق +VOCA</p> "
                    message.SendAndSaveCopy()
                    LblMsg.Text = "Mail has been set "
                    LblMsg.Refresh()


                    LblMsg.Text = "Trying To Insert Update "
                    LblMsg.Refresh()
                    If InsTrans("update Tickets set TkEscTyp = " & EscCnt & " where (TkSQL = " & StruGrdTk.Sql & ")",
                                                 "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & Esc & "','" & "0" & "','" & EscID & "','" & OsIP() & "','" & Usr.PUsrID & "')", "0000&H") = Nothing Then

                        GetUpdtEvent(StruGrdTk.Sql)
                        Dim FolwID As String = ""
                        If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
                        UpGrgFrmt(GridUpdt, FolwID)

                        LblMsg.Text = "Escalation has been done "
                        LblMsg.Refresh()
                        Filtr()
                        If StruGrdTk.EscCnt > 0 Then
                            MsgInf(Esc & "، سيتم الرد عليها من قبل الموظف المختص خلال " & EscTable.Rows(0).Item("EscDur") & " دقيقة" & vbCrLf & "لتنفيذ الطلب سيتم إغلاق بيانات الشكوى")
                        Else
                            MsgInf(Esc & vbCrLf & "لتنفيذ الطلب سيتم إغلاق بيانات الشكوى")
                        End If
                        Esc = ""
                        EscCnt = 0
                        EscID = 0
                        TabControl1.TabPages.Remove(TabPage3)
                        TabControl1.TabPages.Remove(TabPage2)
                    Else
                        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    End If

                End If
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                Exit Sub
            End If

        Catch ex As Exception
            LblMsg.Text = "Error Connecting to Exchange Server!!" + Now + ex.Message
            LblMsg.Refresh()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 289421
        Dim AcbDataTable As New DataTable
        Dim EscTable As New DataTable
        Dim WdysTable As New DataTable
        Dim State As String = ""
        Dim Body_ As String = ""
        Dim EscCount As Integer = 0
        Dim WdNo As Boolean = False
        Dim sss As DateTime = Format(ServrTime(), "HH:mm:ss")


        LblMsg.Text = ""
        If StruGrdTk.EscCnt > 4 Then EscCount = 4 Else EscCount = StruGrdTk.EscCnt
        EscTable.Rows.Clear()
        EscTable.Columns.Clear()

        WdysTable.Rows.Clear()
        WdysTable.Columns.Clear()
        If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate(),111) as Now_)", WdysTable, "0000&H") = Nothing Then
            If WdysTable.Rows(0).Item("HDy") = 0 Then
                For cnt = 1 To 10
                    WdysTable.Rows.Clear()
                    If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate() +" & cnt & ",111) as Now_)", WdysTable, "0000&H") = Nothing Then
                        If WdysTable.Rows(0).Item("HDy") = 1 Then
                            MsgInf("القسم المختص أجازه اليوم، وسيتم التواصل مع العميل خلال مواعيد العمل الرسمية" & vbCrLf & "إبتداء من يوم " & WdysTable.Rows(0).Item("HDate") & " من الساعه 8 صباحاًوحتى الخامسه مساء يوميا " & vbCrLf & "ماعدا الجمعه والسبت والأجازات الرسمية")
                            WdNo = True
                            Exit For
                        End If
                    Else
                        MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        Exit Sub
                    End If
                Next
            ElseIf Format(ServrTime(), "HH:mm:ss") >= #1/1/0001 04:00:00 PM# Then
                WdysTable.Rows.Clear()
                For cnt = 1 To 10
                    WdysTable.Rows.Clear()
                    If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate() +" & cnt & ",111) as Now_)", WdysTable, "0000&H") = Nothing Then
                        If WdysTable.Rows(0).Item("HDy") = 1 Then
                            MsgInf("القسم المختص خارج مواعيد العمل، وسيتم التواصل مع العميل خلال مواعيد العمل الرسمية" & vbCrLf & "إبتداء من يوم " & WdysTable.Rows(0).Item("HDate") & " من الساعه 8 صباحاًوحتى الخامسه مساء يوميا " & vbCrLf & "ماعدا الجمعه والسبت والأجازات الرسمية")
                            WdNo = True
                            Exit For
                        End If
                    Else
                        MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        Exit Sub
                    End If
                Next
            End If
        Else
            MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Exit Sub
        End If

EscSecResp_:

        If EscCount > 0 Then
            If GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscCount, EscTable, "0000&H") = Nothing Then
                Dim Minutws As DateTime = ServrTime()
                Dim Minuts As Double = ServrTime().Subtract(StruGrdTk.LstUpDt).TotalMinutes
                Dim MinutsDef As Integer = EscTable.Rows(0).Item("EscDur") - Minuts
                If StruGrdTk.LstUpEvId = 902 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 1 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 903 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 2 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 904 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل متابعه 3 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 905 Then
                    If Minuts < EscTable.Rows(0).Item("EscDur") Then
                        MsgInf("تم عمل أقصى عدد من المتابعات وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & vbCrLf & "متبقى " & MinutsDef & " دقيقة")
                        Exit Sub
                    End If
                ElseIf StruGrdTk.LstUpEvId = 906 Or StruGrdTk.LstUpEvId = 907 Or StruGrdTk.LstUpEvId = 908 Or StruGrdTk.LstUpEvId = 909 Then
                    MsgInf("بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل المتابعه")
                    Exit Sub
                End If
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                Exit Sub
            End If
        End If
EscSec_:
        Try
            If StruGrdTk.EscCnt = 0 Then
                If WdNo = True Then
                    Esc = "بسبب أن القسم المختص خارج مواعيد العمل الرسمية فإنه بشكل تلقائي يوم " & WdysTable.Rows(0).Item("HDay") & " الموافق " & WdysTable.Rows(0).Item("HDate") & " سيتم عمل متابعة 1"
                    EscID = 906
                ElseIf WdNo = False Then
                    Esc = "تم عمل متابعة 1"
                    EscID = 902
                End If
                EscCnt = 1
            End If

            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscCnt, tempTable, "0000&H") = Nothing Then
                AcbDataTable.Rows.Clear()
                LblMsg.Text = "Trying To Get Data "
                LblMsg.Refresh()
                If GetTbl("SELECT Tickets.TkSQL, Int_user.UsrRealNm AS UsrTik, Int_user.UsrEmail, Int_user_3.UsrRealNm AS CSTL, Int_user_3.UsrEmail AS CSTLMail, Int_user_1.UsrRealNm AS FolwUsr, Int_user_1.UsrSisco AS CCFlwPh, Int_user_1.UsrEmail AS FLWMail, Int_user_2.UsrRealNm AS CCTL, Int_user_2.UsrEmail AS CCTLMail, Int_user_2.UsrSisco AS CCTLPh, IntUserCat_1.UCatNm AS TeamNm
                    FROM Int_user AS Int_user_3 INNER JOIN (Int_user AS Int_user_2 INNER JOIN (IntUserCat INNER JOIN (IntUserCat AS IntUserCat_1 INNER JOIN (Int_user AS Int_user_1 INNER JOIN (Int_user INNER JOIN Tickets ON Int_user.UsrId = Tickets.TkEmpNm0) ON Int_user_1.UsrId = Tickets.TkEmpNm) ON IntUserCat_1.UCatId = Int_user_1.UsrCat) ON IntUserCat.UCatId = Int_user.UsrCat) ON Int_user_2.UsrCat = IntUserCat_1.UCatIdSub) ON Int_user_3.UsrCat = IntUserCat.UCatIdSub
                    where Tickets.TkSQL = " & StruGrdTk.Sql, AcbDataTable, "0000&H") = Nothing Then
                    LblMsg.Text = "Trying To Connect To Mail Server "
                    LblMsg.Refresh()

                    exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
                    exchange.Credentials = New WebCredentials("egyptpost\acb", "Hemonad105046")
                    exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                    LblMsg.Text = "Connected successfully to Server : " + exchange.Url.Host
                    LblMsg.Refresh()
                    LblMsg.Text = "Sending New Message To " & AcbDataTable.Rows(0).Item("FLWMail").ToString
                    LblMsg.Refresh()
                    Dim message As New EmailMessage(exchange)

                    message.ToRecipients.Add("a.farag@egyptpost.org")
                    'message.ToRecipients.Add(AcbDataTable.Rows(0).Item("FLWMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CSTLMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CCTLMail").ToString)
                    'message.CcRecipients.Add(AcbDataTable.Rows(0).Item("UsrEmail").ToString)
                    'For Cnt = 0 To Split(tempTable.Rows(0).Item("EscCC"), ";").Count - 1
                    '    message.CcRecipients.Add(Split(tempTable.Rows(0).Item("EscCC"), ";")(Cnt))
                    'Next

                    message.Subject = Esc & " ل" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & " " & AcbDataTable.Rows(0).Item("TeamNm").ToString & " شكوى رقم : " & StruGrdTk.Sql
                    Dim aa As String = StruGrdTk.PrdKNm
                    If StruGrdTk.ClsStat = True Then State = "مغلقة" Else State = "مفتوحه"
                    Dim colr As String
                    If WdNo = True Then colr = "Green" Else colr = "Red"

                    message.Body = "<p style=" & Chr(34) & "text-align: right;" & Chr(34) & "><span style=" & Chr(34) & "font-size: 18px;" & Chr(34) & " >استاذ (ه) / " & AcbDataTable.Rows(0).Item(5).ToString & " </span></p>" &
                               "<p style=" & Chr(34) & "direction:rtl;text-align: right;color:Black;" & Chr(34) & ">" & "نص التحديث : " & "</p> " &
                               "<p style=" & Chr(34) & "direction:rtl;text-align: right;color:" & colr & ";" & Chr(34) & ">" & "             " & Esc & "</p> " &
                               "<table style=“ & Chr(34) & “width: 100%; direction: rtl; border-style: solid; border-color:" & colr & Chr(34) & “><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>رقم الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.Sql & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>اسم العميل:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.ClNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ تسجيل الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.DtStrt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ استلام الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.RecvDt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>حالة الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & State & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>مصدر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.Src & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>عدد المتابعات:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.EscCnt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>تاريخ آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpDt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نص آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpTxt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>محرر آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.LstUpUsrNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نوع المنتح:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.PrdKNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>اسم الخدمة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.ProdNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>نوع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & StruGrdTk.CompNm & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>محرر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & AcbDataTable.Rows(0).Item(1).ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>متابع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                               “>" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>مشرف المجموعة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                               AcbDataTable.Rows(0).Item("CCTL").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                               “><strong>التليفون الداخلي:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                               AcbDataTable.Rows(0).Item("CCFlwPh").ToString & "-" & AcbDataTable.Rows(0).Item("CCTLPh").ToString & "</div></td></tr></tbody></table>" & "<br><br><p style=" & Chr(34) & "direction:rtl;text-align: right;" & Chr(34) & ">تم إرسال هذا البريد الإلكتروني من خلال تطبيق +VOCA</p> "
                    message.SendAndSaveCopy()
                    LblMsg.Text = "Mail has been set "
                    LblMsg.Refresh()


                    LblMsg.Text = "Trying To Insert Update "
                    LblMsg.Refresh()
                    If InsTrans("update Tickets set TkEscTyp = " & EscCnt & " where (TkSQL = " & StruGrdTk.Sql & ")",
                                             "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & Esc & "','" & "0" & "','" & EscID & "','" & OsIP() & "','" & Usr.PUsrID & "')", "0000&H") = Nothing Then

                        GetUpdtEvent(StruGrdTk.Sql)
                        Dim FolwID As String = ""
                        If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
                        UpGrgFrmt(GridUpdt, FolwID)

                        LblMsg.Text = "Escalation has been done "
                        LblMsg.Refresh()
                        Filtr()
                        If StruGrdTk.EscCnt > 0 Then
                            MsgInf(Esc & "، سيتم الرد عليها من قبل الموظف المختص خلال " & EscTable.Rows(0).Item("EscDur") & " دقيقة" & vbCrLf & "لتنفيذ الطلب سيتم إغلاق بيانات الشكوى")
                        Else
                            MsgInf(Esc & vbCrLf & "لتنفيذ الطلب سيتم إغلاق بيانات الشكوى")
                        End If
                        Esc = ""
                        EscCnt = 0
                        EscID = 0
                        TabControl1.TabPages.Remove(TabPage3)
                        TabControl1.TabPages.Remove(TabPage2)
                    Else
                        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    End If

                End If
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                Exit Sub
            End If

        Catch ex As Exception
            LblMsg.Text = "Error Connecting to Exchange Server!!" + Now + ex.Message
            LblMsg.Refresh()
        End Try
    End Sub
#End Region
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
    Private Sub TimerEscOpen_Tick(sender As Object, e As EventArgs) Handles TimerEscOpen.Tick
        If EscTable.Rows.Count = 0 Then
            EscTable.Rows.Clear()
            GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & StruGrdTk.LstUpEvId - 901, EscTable, "0000&H")
        End If
        Dim Minutws As DateTime = ServrTime()
        Dim Minuts As Double = ServrTime().Subtract(StruGrdTk.LstUpDt).TotalMinutes
        Dim MinutsDef As Integer = EscTable.Rows(0).Item("EscDur") - Minuts

        If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
            If Minuts < EscTable.Rows(0).Item("EscDur") Then
                LblMsg.Text = ("تم عمل متابعه 1 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & " متبقى " & MinutsDef & " دقيقة")
                LblMsg.Refresh()
                CmbEvent.Enabled = False
                BtnSubmt.Enabled = False
                TxtUpdt.Text = "لا يمكن عمل تحديث أثناء فترة المتابعه، ويتم السماح بإضافة تعديل إما بإنتهاء فترة المتابعه أو عمل تحديث من الخطوط الخلفية"
                TxtUpdt.Font = New Font("Times New Roman", 16, FontStyle.Regular)
                TxtUpdt.TextAlign = HorizontalAlignment.Center
                TxtUpdt.ReadOnly = True
                Exit Sub
            End If
        Else
            CmbEvent.Enabled = True
            BtnSubmt.Enabled = True
            TxtUpdt.Text = ""
            TxtUpdt.Font = New Font("Times New Roman", 14, FontStyle.Regular)
            TxtUpdt.TextAlign = HorizontalAlignment.Left
            TxtUpdt.ReadOnly = False
        End If
    End Sub
    Private Sub TikSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TimerEscOpen.Stop()
        TimerVisInvs.Stop()
    End Sub
#Region "Tool Strip GridUpdate"
    Private Sub CopyToolStripitem_Click(sender As Object, e As EventArgs) Handles CopyToolStripitem.Click
        If Len(GridUpdt.CurrentCell.Value.ToString) > 0 Then Clipboard.SetText(GridUpdt.CurrentCell.Value)
    End Sub
    Private Sub DonlodAttchToolStripitem_Click(sender As Object, e As EventArgs) Handles DonlodAttchToolStripitem.Click
        Dowload()
    End Sub
    Private Sub UplodAtchToolStripitem_Click(sender As Object, e As EventArgs) Handles UplodAtchToolStripitem.Click
        Uploadsub()
    End Sub

    Private Sub GridUpdt_SelectionChanged(sender As Object, e As EventArgs) Handles GridUpdt.SelectionChanged
        If GridUpdt.Rows.Count > 0 Then
            If GridUpdt.Columns.Count = 11 Then
                Dim subItem As New ToolStripMenuItem("Download Attached")
                ContextMenuStrip2.Enabled = True
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

    Private Sub SerchTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SerchTxt.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Filtr()
            TimerEscOpen.Stop()
        End If

    End Sub

    Private Sub TimerVisInvs_Tick(sender As Object, e As EventArgs) Handles TimerVisInvs.Tick
        If LblWDays.Text.Length > 0 Then
            If LblWDays.Visible = True Then
                LblWDays.Visible = False
            Else
                LblWDays.Visible = True
            End If
        End If
        If LblWdays2.Text.Length > 0 Then
            If LblWdays2.Visible = True Then
                LblWdays2.Visible = False
            Else
                LblWdays2.Visible = True
            End If
        End If
    End Sub
#End Region

End Class