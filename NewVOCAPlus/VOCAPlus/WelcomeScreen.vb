Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports Microsoft.Exchange.WebServices.Data

Public Class WelcomeScreen
    Dim servrstsus As Boolean = False
    Dim servrTring As Boolean = False
    Dim Servr As TcpListener
    ReadOnly TicTable As DataTable = New DataTable
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private cmdSelectCommand As SqlCommand
    Private dadPurchaseInfo As New SqlDataAdapter
    Private UpdtCmd As New SqlDataAdapter
    Private InsrtCmd As New SqlDataAdapter
    Private builder As SqlCommandBuilder
    Private dsPurchaseInfo As New DataSet
    Dim Frm As New Form
    Dim Btn1 As New Button
    Dim Btn2 As New Button
    Dim Btn3 As New Button
    Dim Grid1 As New DataGridView
    Dim Grid2 As New DataGridView
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub WelcomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimerOp.Start()
        LblSrvrNm.Text = ServerNm
        BtnSub(Me)
        Me.Size = New Point(screenWidth, screenHeight)
        If System.Text.Encoding.Default.HeaderName <> "windows-1256" Then
            GroupBox1.Visible = False
            GrpCounters.Visible = False
            Me.BackgroundImage = My.Resources.Language_for_Non_Unicode_Programs
        Else
            LblLanguage.Visible = False
            FlowLayoutPanel1.Visible = False
            If ServerNm = "Egypt Post Server" Then
                Me.BackgroundImage = My.Resources.VocaWtr
                Me.BackgroundImageLayout = ImageLayout.Stretch
                Me.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf ServerNm = "My Labtop" Then
                Me.BackgroundImage = My.Resources.Empty
                Me.BackColor = Color.White
            ElseIf ServerNm = "Test Database" Then
                Me.BackgroundImage = My.Resources.Demo
                Me.BackgroundImageLayout = ImageLayout.Tile
                Me.BackColor = Color.White
            End If
            Dim SwichTabTable As DataTable = New DataTable
            Dim SwichButTable As DataTable = New DataTable
            Dim PrTblTsk As New Thread(AddressOf PreciTbl)
            PrTblTsk.IsBackground = True
            LblClrSys.BackColor = My.Settings.ClrSys
            LblClrUsr.BackColor = My.Settings.ClrUsr
            LblClrSamCat.BackColor = My.Settings.ClrSamCat
            LblClrNotUsr.BackColor = My.Settings.ClrNotUsr
            LblClrOperation.BackColor = My.Settings.ClrOperation
            Dim ConterWidt As Integer = 0
            If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                GrpCounters.Text = "ملخص أرقامي حتى : " & Now
                GrpCounters.Visible = True
                LblClsN.Text = Usr.PUsrClsN
                LblFlN.Text = Usr.PUsrFlN
                LblClsYDy.Text = Usr.PUsrClsYDy
                LblEvDy.Text = Usr.PUsrEvDy
                LblUnRead.Text = Usr.PUsrUnRead
                LblReadYDy.Text = Usr.PUsrReadYDy
                LblReOpY.Text = Usr.PUsrReOpY
                LblRecivDy.Text = Usr.PUsrRecvDy
                LblClsUpdted.Text = Usr.PUsrClsUpdtd
                LblFolwDy.Text = Usr.PUsrFolwDay
                ConterWidt = GrpCounters.Width + GrpCounters.Margin.Left + GrpCounters.Margin.Right
            Else
                GrpCounters.Visible = False
                ConterWidt = 0
            End If
            Invoke(Sub()
                       'FlowLayoutPanel1.Height = screenHeight - 150
                       'FlowLayoutPanel1.Width = screenWidth - 20
                       DbStat.Margin = New Padding(DbStat.Margin.Left, DbStat.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (DbStat.Width + DbStat.Margin.Left), DbStat.Margin.Bottom)
                       PictureBox1.Margin = New Padding(PictureBox1.Margin.Left, PictureBox1.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (GroupBox1.Width + GroupBox1.Margin.Right + GroupBox1.Margin.Left + ConterWidt + PictureBox1.Width + PictureBox1.Margin.Left), PictureBox1.Margin.Bottom)
                       LblUsrRNm.Margin = New Padding(LblUsrRNm.Margin.Left, LblUsrRNm.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblUsrRNm.Width + LblUsrRNm.Margin.Left), LblUsrRNm.Margin.Bottom)
                       LblSrvrNm.Margin = New Padding(LblSrvrNm.Margin.Left, LblSrvrNm.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblSrvrNm.Width + LblUsrRNm.Margin.Left), LblSrvrNm.Margin.Bottom)
                       LblLstSeen.Margin = New Padding(LblLstSeen.Margin.Left, LblLstSeen.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblLstSeen.Width + LblUsrRNm.Margin.Left), LblLstSeen.Margin.Bottom)
                   End Sub)
            FlowLayoutPanel1.Visible = True
            If PublicCode.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew FROM ASwitchboard WHERE (SwType = N'Tab') AND (SwNm <> N'NA') ORDER BY SwID", SwichTabTable, "1002&H") = Nothing Then
                For Cnt_ = 0 To SwichTabTable.Rows.Count - 1
                    Dim NewTab As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)
                    Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)  'YYYYYYYYYYY
                    If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "A" Or
                        Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
                        MenuSw.Items.Add(NewTab)
                        CntxtMnuStrp.Items.Add(NewTabCx)                     'YYYYYYYYYYY
                        SwichButTable.Rows.Clear()
                        If PublicCode.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNm, SwObjImg, SwObjNew FROM ASwitchboard WHERE (SwType <> N'Tab') AND (SwNm <> N'NA') AND (SwSer ='" & SwichTabTable.Rows(Cnt_).Item(1).ToString & "') ORDER BY SwID;", SwichButTable, "1002&H") = Nothing Then
                            For Cnt_1 = 0 To SwichButTable.Rows.Count - 1
                                Dim subItem As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)
                                Dim subItemCx As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)  'YYYYYYYYYYY
                                If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "A" Or
                                   Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then
                                    NewTab.DropDownItems.Add(subItem)
                                    NewTabCx.DropDownItems.Add(subItemCx)    'YYYYYYYYYYY
                                    subItem.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString
                                    If DBNull.Value.Equals(SwichButTable.Rows(Cnt_1).Item("SwObjImg")) = False Then
                                        Dim Cnt_ = ImageList1.Images(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
                                        Dim dd = My.Resources.ResourceManager.GetObject(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
                                        subItem.Image = Cnt_
                                    End If
                                    subItemCx.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString  'YYYYYYYYYYY
                                    AddHandler subItem.Click, AddressOf ClkEvntClick
                                    AddHandler subItemCx.Click, AddressOf ClkEvntClick  '✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔
                                End If
                                If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then
                                    subItem.AccessibleName = "True"
                                    subItemCx.AccessibleName = "True"
                                End If
                            Next Cnt_1
                        Else
                            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                            Login.Show()
                            Me.Close()
                        End If
                    End If
                    If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
                        NewTab.AccessibleName = "True"
                        NewTabCx.AccessibleName = "True"
                        AddHandler NewTab.Click, AddressOf TabClick
                        AddHandler NewTabCx.Click, AddressOf TabClick
                    End If
                    NewTab = Nothing
                Next Cnt_
                Dim Signout As New ToolStripMenuItem("Sign Out")  'YYYYYYYYYYY
                Dim Exit_ As New ToolStripMenuItem("Exit")  'YYYYYYYYYYY
                CntxtMnuStrp.Items.Add(Signout)  'YYYYYYYYYYY
                CntxtMnuStrp.Items.Add(Exit_)  'YYYYYYYYYYY
                AddHandler Signout.Click, AddressOf SnOutBt_Click  'YYYYYYYYYYY
                AddHandler Exit_.Click, AddressOf ExtBt_Click  'YYYYYYYYYYY
                AreaTable.Rows.Clear()
                OfficeTable.Rows.Clear()
                CompSurceTable.Rows.Clear()
                CountryTable.Rows.Clear()
                ProdKTable.Rows.Clear()
                ProdCompTable.Rows.Clear()
                UpdateKTable.Rows.Clear()
                PrciTblCnt = 0
                LblLstSeen.Text = "Last Seen : " & ServrTime() 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                LoadFrm("جاري تحميل البيانات ...", (screenWidth - LodngFrm.Width) / 2, (screenHeight - LodngFrm.Height) / 2)
                PrTblTsk.Start()
                StatBrPnlEn.Text = "  Online  "
                StatBrPnlEn.Icon = My.Resources.WSOn032
            Else
                Login.Show()
                Me.Close()
            End If

            PubVerLbl.Text = "IP: " & OsIP()
            If Usr.PUsrGndr = "Male" Then
                LblUsrRNm.Text = "Welcome Back Mr. " & Usr.PUsrRlNm
            Else
                LblUsrRNm.Text = "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm
            End If

            NonEditableLbl(LblUsrRNm)
            Me.Text = "VOCA Plus - Welcome " & Usr.PUsrRlNm
            'AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString
            If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                LblUsrIP.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
            Else
                LblUsrIP.Text = "Publish Ver. : This isn't a Publish version"
            End If
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            GetTbl("Select Mlxx from Alib", tempTable, "0000&H")
            MLXX = tempTable.Rows(0).Item(0).ToString
            TimerTikCoun.Start()
            TimrFlsh.Start()
            TimerColctLog.Start()
            SwichTabTable.Dispose()
            SwichButTable.Dispose()
            GC.Collect()
            StartServer()
        End If
    End Sub
    Private Sub TabClick(sender As System.Object, e As System.EventArgs)
        sender.AccessibleName = "False"
        sender.backcolor = Color.White
        sender.font = New Font("Times New Roman", 14, FontStyle.Regular)
        InsUpd("update Int_user set UsrLevel = SUBSTRING(UsrLevel,1,(select SwID from ASwitchboard where SwNm = '" & sender.text & "')-1) + 'A' + SUBSTRING(UsrLevel,(select SwID from ASwitchboard where SwNm = '" & sender.text & "') + 1,100) where UsrId = " & Usr.PUsrID, "0000&H")
    End Sub
    Private Sub ClkEvntClick(sender As System.Object, e As System.EventArgs)
        Dim formName As String = "VOCAPlus." & sender.tag
        Dim form_ = CType(Activator.CreateInstance(Type.GetType(formName)), Form)

        sender.AccessibleName = "False"
        sender.backcolor = Color.White
        sender.font = New Font("Times New Roman", 14, FontStyle.Regular)
        InsUpd("update Int_user set UsrLevel = SUBSTRING(UsrLevel,1,(select SwID from ASwitchboard where SwObjNm = '" & sender.tag & "')-1) + 'A' + SUBSTRING(UsrLevel,(select SwID from ASwitchboard where SwObjNm = '" & sender.tag & "') + 1,100) where UsrId = " & Usr.PUsrID, "0000&H")

        If Application.OpenForms.Count > 2 Then
            MsgInf("لا يمكن فتح أكثر من شاشتين في نفس الوقت" & vbCrLf & "يرجى إغلاق أحد الشاشات المفتوحة وإعادة المحاولة")
            Exit Sub
        End If
        For Each f As Form In My.Application.OpenForms
            If f.Name = form_.Name Then
                'MsgInf("شاشة " & form.Text & " مفتوحة بالفعل")
                Exit Sub
            End If
        Next
        form_.ShowDialog()
    End Sub
    'Exit Button close Welcome Screen And Update Active Status in Int_User Table
    'Exit Button close Welcome Screen And open Login Form And Update Active Status in Int_User Table
    'Disable Close Button[X] In the Vb.Net
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TimerTikCoun_Tick(sender As Object, e As EventArgs) Handles TimerTikCoun.Tick
        'Ckeck User Tickets Count And Update It in Int_User Table If Different
        Nw = ServrTime()
        TicTable.Rows.Clear()
        If PublicCode.GetTbl("select UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UsrRecevDy, UsrClsUpdtd, UsrLastSeen, UsrTikFlowDy, UsrActive,UsrLogSnd from Int_user where UsrId = " & Usr.PUsrID & ";", TicTable, "1005&H") = Nothing Then
            If TicTable.Rows.Count > 0 Then
                If TicTable.Rows(0).Item("UsrActive") = False Then
                    'Login.ExitBtn.Enabled = False
                    Login.TxtUsrNm.Text = Usr.PUsrNm
                    'Login.ExitBtn.Enabled = False
                    Login.TxtUsrNm.Enabled = False
                    Dim frmCollection = Application.OpenForms
                    If frmCollection.OfType(Of Login).Any Then
                        Login.TxtUsrPass.Focus()
                    Else
                        CntxtMnuStrp.Enabled = False
                        CntxtMnuStrp.Enabled = False
                        Login.ShowDialog()
                        CntxtMnuStrp.Enabled = True
                        CntxtMnuStrp.Enabled = True
                    End If
                End If
                If Math.Abs(DateTime.Parse(Nw).Subtract(DateTime.Parse(TicTable.Rows(0).Item("UsrLastSeen"))).TotalMinutes) > 30 Then
                End If

#Region "Send Log File If UsrLogSnd is True"
                If TicTable.Rows(0).Item("UsrLogSnd") = True Then
                    TimerColctLog.Interval = 5000
                    '    tempTable.Rows.Clear()
                    '    tempTable.Columns.Clear()
                    '    GetTbl("Select Mlxx from Alib", tempTable, "0000&H")
                    '    Dim exchange As ExchangeService
                    '    exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
                    '    exchange.Credentials = New WebCredentials("egyptpost\voca-support", tempTable.Rows(0).Item(0).ToString)
                    '    exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                    '    Dim message As New EmailMessage(exchange)
                    '    message.ToRecipients.Add("voca-support@egyptpost.org")
                    '    message.CcRecipients.Add("a.farag@egyptpost.org")
                    '    message.Subject = "VOCA Log Of " & Usr.PUsrRlNm & "," & Usr.PUsrID & "," & OsIP()
                    '    message.Body = "VOCA Log File"
                    '    Dim fileAttachment As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "VOCALog" & Format(Now, "yyyyMM") & ".Vlg"
                    '    message.Attachments.AddFileAttachment(fileAttachment)
                    '    message.Attachments(0).ContentId = "VOCALog" & Format(Now, "yyyyMM")
                    '    message.Importance = 1
                    '    Try
                    '        message.SendAndSaveCopy()
                    If PublicCode.InsUpd("UPDATE Int_user SET UsrLogSnd = 0  WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H") = Nothing Then
                    End If
                    '    Catch ex As Exception
                    '        MsgInf(ex.Message)
                    '    End Try
                End If

#End Region

            End If
        End If
        If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
            Dim Notif As String = ""
            StatBrPnlEn.Icon = My.Resources.WSOn032
            GrpCounters.Text = "ملخص أرقامي حتى : " & Now
            'If Now.Subtract(TicTable.Rows(0).Item("UsrLastSeen")) Then
            If TicTable.Rows.Count > 0 Then
                Notif = "جديد :"
                Dim ss As Integer = TicTable.Rows(0).Item("UsrClsN")
                If Usr.PUsrClsN < TicTable.Rows(0).Item("UsrClsN") Then
                    Notif &= vbCrLf & "شكاوى مفتوحه : " & TicTable.Rows(0).Item("UsrClsN") - Usr.PUsrClsN
                    Usr.PUsrClsN = TicTable.Rows(0).Item("UsrClsN")
                    LblClsN.Text = Usr.PUsrClsN
                End If
                If Usr.PUsrFlN < TicTable.Rows(0).Item("UsrFlN") Then
                    Notif &= vbCrLf & "لم يتم التعامل : " & TicTable.Rows(0).Item("UsrFlN") - Usr.PUsrFlN
                    Usr.PUsrFlN = TicTable.Rows(0).Item("UsrFlN")
                    LblFlN.Text = Usr.PUsrFlN
                End If
                If Usr.PUsrReOpY < TicTable.Rows(0).Item("UsrReOpY") Then
                    Notif &= vbCrLf & "معاد فتحها اليوم : " & TicTable.Rows(0).Item("UsrReOpY") - Usr.PUsrReOpY
                    Usr.PUsrReOpY = TicTable.Rows(0).Item("UsrReOpY")
                    LblReOpY.Text = Usr.PUsrReOpY
                End If
                If Usr.PUsrUnRead < TicTable.Rows(0).Item("UsrUnRead") Then
                    Notif &= vbCrLf & "تحديثات غير مقروءه : " & TicTable.Rows(0).Item("UsrUnRead")
                    Usr.PUsrUnRead = TicTable.Rows(0).Item("UsrUnRead")
                    LblUnRead.Text = Usr.PUsrUnRead
                End If
                If Usr.PUsrEvDy < TicTable.Rows(0).Item("UsrEvDy") Then
                    Notif &= vbCrLf & "عدد تحديثات اليوم : " & TicTable.Rows(0).Item("UsrEvDy")
                    Usr.PUsrEvDy = TicTable.Rows(0).Item("UsrEvDy")
                    LblEvDy.Text = Usr.PUsrEvDy
                End If
                If Usr.PUsrClsYDy < TicTable.Rows(0).Item("UsrClsYDy") Then
                    Notif &= vbCrLf & "تم إغلاقها اليوم : " & TicTable.Rows(0).Item("UsrClsYDy")
                    Usr.PUsrClsYDy = TicTable.Rows(0).Item("UsrClsYDy")
                    LblClsYDy.Text = Usr.PUsrClsYDy
                End If
                If Usr.PUsrReadYDy < TicTable.Rows(0).Item("UsrReadYDy") Then
                    Notif &= vbCrLf & "تحديثات مقروءه اليوم : " & TicTable.Rows(0).Item("UsrReadYDy") - Usr.PUsrReadYDy
                    Usr.PUsrReadYDy = TicTable.Rows(0).Item("UsrReadYDy")
                    LblReadYDy.Text = Usr.PUsrReadYDy
                End If
                If Usr.PUsrRecvDy < TicTable.Rows(0).Item("UsrRecevDy") Then
                    Notif &= vbCrLf & "استلام اليوم : " & TicTable.Rows(0).Item("UsrRecevDy") - Usr.PUsrRecvDy
                    Usr.PUsrRecvDy = TicTable.Rows(0).Item("UsrRecevDy")
                    LblRecivDy.Text = Usr.PUsrRecvDy
                End If
                If Usr.PUsrClsUpdtd < TicTable.Rows(0).Item("UsrClsUpdtd") Then
                    Notif &= vbCrLf & "تحديثات شكاوى مغلقة : " & TicTable.Rows(0).Item("UsrClsUpdtd") - Usr.PUsrRecvDy
                    Usr.PUsrClsUpdtd = TicTable.Rows(0).Item("UsrClsUpdtd")
                    LblClsUpdted.Text = Usr.PUsrClsUpdtd
                End If
                If Usr.PUsrFolwDay < TicTable.Rows(0).Item("UsrTikFlowDy") Then
                    Notif &= vbCrLf & "تم التعامل اليوم : " & TicTable.Rows(0).Item("UsrTikFlowDy") - Usr.PUsrFolwDay
                    Usr.PUsrFolwDay = TicTable.Rows(0).Item("UsrTikFlowDy")
                    LblFolwDy.Text = Usr.PUsrFolwDay
                End If

                '                    LblFolwDy.Text = Usr.PUsrFolwDay
                'If TicTable.Rows(0).Item(0) > Usr.PUsrTcCnt Then                 'Ticket Count
                If Notif.Length > 6 Then
                    NotifyIcon1.ShowBalloonTip(0, "", Notif, ToolTipIcon.Info)
                End If
            End If
        End If
    End Sub
    Private Sub TimerOp_Tick(sender As Object, e As EventArgs) Handles TimerOp.Tick
        If Opacity < 1 Then
            Opacity += 0.1
        Else
            Me.TimerOp.Stop()
        End If
    End Sub
    Private Sub SnOutBt_Click(sender As Object, e As EventArgs) Handles SnOutBt.Click
        SinOutEvent()
        Login.Show()
        Login.TxtUsrNm.Text = Usr.PUsrNm
        Login.TxtUsrPass.Focus()
        Close()
    End Sub
    Private Sub ExtBt_Click(sender As Object, e As EventArgs) Handles ExtBt.Click
        SinOutEvent()
        Close()
    End Sub
    Private Sub SinOutEvent()
        CntxtMnuStrp.Close()
        FlushMemory()
        PublicCode.InsUpd("UPDATE Int_user SET UsrActive = 0" & " WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
    End Sub
    Private Sub TimerCon_Tick(sender As Object, e As EventArgs) Handles TimerCon.Tick
        Dim ConnOff As New Thread(AddressOf Conoff)
        ConnOff.IsBackground = True
        If ConnOff.IsAlive = False Then
            ConnOff.Start()
        End If
    End Sub
    Private Sub PreciTbl()
        Dim primaryKey(0) As DataColumn
        Dim NotComplete As String = "لم يتم تحميل"
        Invoke(Sub() PublicCode.LoadFrm("", 350, 500))
        If AreaTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text = "جاري تحميل أسماء المناطق ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H") = Nothing Then
                PrciTblCnt += 1
            Else
                NotComplete += " أسماء المناطق / "
            End If
        End If
        If OfficeTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أسماء المكاتب ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H") = Nothing Then
                PrciTblCnt += 1
            Else
                NotComplete += " أسماء المكاتب / "
            End If
        End If
        If CompSurceTable.Rows.Count = 0 Then
            Dim SrcStr As String = ""
            If Usr.PUsrUCatLvl = 7 Then
                SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
            Else
                SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
            End If
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل مصادر الشكوى ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl(SrcStr, CompSurceTable, "1012&H") = Nothing Then
                PrciTblCnt += 1
            Else
                NotComplete += " مصادر الشكوى / "
            End If
        End If
        If CountryTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أسماء الدول ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H") = Nothing Then
                primaryKey(0) = CountryTable.Columns("CounCd")
                CountryTable.PrimaryKey = primaryKey
                PrciTblCnt += 1
            Else
                NotComplete += " أسماء الدول / "
            End If
        End If
        If ProdKTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع الخدمات ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H") = Nothing Then
                primaryKey(0) = ProdKTable.Columns("ProdKNm")
                ProdKTable.PrimaryKey = primaryKey
                PrciTblCnt += 1
            Else
                NotComplete += " أنواع الخدمات / "
            End If
        End If
        If ProdCompTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع المنتجات ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())
            If PublicCode.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H") = Nothing Then
                primaryKey(0) = ProdCompTable.Columns("FnSQL")
                ProdCompTable.PrimaryKey = primaryKey
                PrciTblCnt += 1
            Else
                NotComplete += " أنواع المنتجات / "
            End If
        End If
        If UpdateKTable.Rows.Count = 0 Then
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع التحديثات ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Invoke(Sub() LodngFrm.LblMsg.ScrollToCaret())

            If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                If PublicCode.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H") = Nothing Then
                    PrciTblCnt += 1
                Else
                    NotComplete += " أنواع التحديثات / "
                End If
            Else
                If PublicCode.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H") = Nothing Then
                    PrciTblCnt += 1
                Else
                    NotComplete += " أنواع التحديثات / "
                End If
            End If
        End If
        If PrciTblCnt = 7 Then
            PreciFlag = True
            DbStat.BackgroundImage = My.Resources.DBOn
            DbStat.Tag = "تم تحميل قواعد البيانات الأساسية بنجـــاح"
        Else
            DbStat.BackgroundImage = My.Resources.DBOff
            DbStat.Tag = "لم يكتمل تحميل كل قواعد البيانات الأساسية"
            Me.TimerCon.Start()
            StatusBar1.Invoke(Sub() StatBrPnlEn.Text = "  Offline  ")
            StatusBar1.Invoke(Sub() StatBrPnlEn.Icon = My.Resources.WSOff032)
        End If
        Invoke(Sub() LodngFrm.Close())
        Invoke(Sub() LodngFrm.Dispose())
        GettAttchUpdtesFils()
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/UserPic/" & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg")
        request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
        request.Method = WebRequestMethods.Ftp.DownloadFile
        request.Timeout = 20000
        Dim frmCollection = Application.OpenForms
        If frmCollection.OfType(Of WelcomeScreen).Any Then
            Invoke(Sub() StatBrPnlAr.Text = "جاري تحميل الصورة الشخصية ..................")

            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream()
                Dim buffer As Byte() = New Byte(10240 - 1) {}
                Invoke(Sub() PictureBox1.Image = Image.FromStream(ftpStream)) 'Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & Usr.PUsrID & ".jpg")
                Invoke(Sub() PictureBox1.Refresh())
                Invoke(Sub() PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage)
                Invoke(Sub() PictureBox1.BorderStyle = BorderStyle.None)
                request.Abort()
                ftpStream.Close()
                ftpStream.Dispose()
                StatBrPnlAr.Text = ""
            Catch ex As Exception
                'MsgBox(ex.Message)
                Invoke(Sub() StatBrPnlAr.Text = "لم يتم تحميل الصورة الشخصية")
            End Try
            If NotComplete = "لم يتم تحميل" Then
                NotComplete = ""
            End If
            Invoke(Sub() StatBrPnlAr.Text = NotComplete)
        End If
    End Sub
    Private Sub Conoff()
        Dim PrTblTsk As New Thread(AddressOf PreciTbl)
        PrTblTsk.IsBackground = True
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            If PreciFlag = False Then PrTblTsk.Start()
            StatBrPnlEn.Text = ""
            StatusBar1.Invoke(Sub() StatBrPnlEn.Icon = My.Resources.WSOn032)
            TimerCon.Stop()
        Catch ex As Exception
            StatusBar1.Invoke(Sub() StatBrPnlEn.Icon = My.Resources.WSOff032)
        End Try
    End Sub
    'Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Private Sub DbStat_MouseHover(sender As Object, e As EventArgs) Handles DbStat.MouseHover
        ToolTip1.Show(DbStat.Tag, DbStat, 0, 20, 2000)
    End Sub
    Private Sub MenuSw_Click(sender As Object, e As EventArgs) Handles MenuSw.Click
        If PreciFlag = True Then
            PublicCode.InsUpd("UPDATE Int_user SET UsrLastSeen = '" & Format(Now, "yyyy/MM/dd h:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
        End If
    End Sub
    Private Sub TimrFlsh_Tick(sender As Object, e As EventArgs) Handles TimrFlsh.Tick
        For Each NewTabq As ToolStripMenuItem In MenuSw.Items
            If NewTabq.AccessibleName = "True" Then
                If NewTabq.BackColor = Color.Orange Then
                    TimrFlsh.Interval = 700
                    NewTabq.BackColor = Color.White
                    NewTabq.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                ElseIf NewTabq.BackColor <> Color.Orange Then
                    TimrFlsh.Interval = 2000
                    NewTabq.BackColor = Color.Orange
                    NewTabq.Font = New Font("Times New Roman", 14, FontStyle.Bold)
                End If
            End If
            For Each gg In NewTabq.DropDownItems
                If gg.AccessibleName = "True" Then
                    If gg.BackColor = Color.Orange Then
                        TimrFlsh.Interval = 700
                        gg.BackColor = Color.White
                        gg.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                    ElseIf gg.BackColor <> Color.Orange Then
                        TimrFlsh.Interval = 2000
                        gg.BackColor = Color.Orange
                        gg.Font = New Font("Times New Roman", 14, FontStyle.Bold)
                    End If
                End If
            Next
        Next
        For Each NewTabq As ToolStripMenuItem In CntxtMnuStrp.Items
            If NewTabq.AccessibleName = "True" Then
                If NewTabq.BackColor = Color.Orange Then
                    TimrFlsh.Interval = 700
                    NewTabq.BackColor = Color.White
                    NewTabq.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                ElseIf NewTabq.BackColor <> Color.Orange Then
                    TimrFlsh.Interval = 2000
                    NewTabq.BackColor = Color.Orange
                    NewTabq.Font = New Font("Times New Roman", 14, FontStyle.Bold)
                End If
            End If
            For Each gg In NewTabq.DropDownItems
                If gg.AccessibleName = "True" Then
                    If gg.BackColor = Color.Orange Then
                        TimrFlsh.Interval = 700
                        gg.BackColor = Color.White
                        gg.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                    ElseIf gg.BackColor <> Color.Orange Then
                        TimrFlsh.Interval = 2000
                        gg.BackColor = Color.Orange
                        gg.Font = New Font("Times New Roman", 14, FontStyle.Bold)
                    End If
                End If
            Next
        Next
        'CntxtMnuStrp
    End Sub
    Public Function StartServer()
        If servrstsus = False Then
            servrTring = True
            Try
                Servr = New TcpListener(IPAddress.Any, 80)
                Servr.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                servrstsus = True
            Catch ex As Exception
                servrstsus = False
            End Try
            servrTring = False
        End If
        Return True
    End Function
    Public Function Handler_Client(ByVal State As Object)
        Dim Tempclient As TcpClient
        Try
            Using Client As TcpClient = Servr.AcceptTcpClient
                If servrTring = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                Tempclient = Client
                'Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                If RX.BaseStream.CanRead = True Then
                    Do

                        Dim RawData As String = RX.ReadLine
                        If Split(RawData, ">>").Count > 1 Then
                            If Trim(Split(RawData, ">>")(1)) = "Empty" Then
                                Invoke(Sub() Label9.Text = "")
                            Else
                                Invoke(Sub() Label9.Text += RawData + vbNewLine)
                                If RawData.Length > 0 Then NotifyIcon1.ShowBalloonTip(0, "", RawData + " ", ToolTipIcon.Info)
                            End If
                        Else
                            If RawData.Length > 0 Then NotifyIcon1.ShowBalloonTip(0, "", RawData + " ", ToolTipIcon.Info)
                            Invoke(Sub() Label9.Text += RawData + vbNewLine)
                        End If
                    Loop While RX.BaseStream.CanRead = True
                End If
            End Using
        Catch ex As Exception
            StartServer()
        End Try

        Return True
    End Function
    Private Sub TimerColctLog_Tick(sender As Object, e As EventArgs) Handles TimerColctLog.Tick
        TimerColctLog.Interval = 600000
        If LogCollect() > 0 Then
        End If
        'If CompOffLine() > 0 Then
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Frm.Controls.Add(Btn1)
        Frm.Controls.Add(Btn2)
        Frm.Controls.Add(Btn3)
        Frm.Controls.Add(Grid1)
        'Frm.Controls.Add(Grid2)
        Frm.WindowState = FormWindowState.Maximized
        AddHandler Btn1.Click, AddressOf Button_Click
        AddHandler Btn2.Click, AddressOf ButtonXX_Click
        AddHandler Btn3.Click, AddressOf ButtonRefill_Click
        Btn1.Text = "Fill"
        Btn2.Text = "Update"
        Btn3.Text = "ReFill"
        Btn1.Location = New Point(0, 10)
        Btn2.Location = New Point(80, 10)
        Btn3.Location = New Point(160, 10)
        Grid1.Location = New Point(35, 40)
        Grid1.Dock = DockStyle.Bottom
        Grid1.Size = New Point(350, 650)
        Frm.ShowDialog()
        RemoveHandler Btn1.Click, AddressOf Button_Click
        RemoveHandler Btn2.Click, AddressOf ButtonXX_Click
        RemoveHandler Btn3.Click, AddressOf ButtonRefill_Click
    End Sub
    Private Sub Button_Click(sender As Object, e As EventArgs)

        Try
            cmdSelectCommand = New SqlCommand("select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm", sqlCon)
            cmdSelectCommand.CommandTimeout = 30

            dadPurchaseInfo.SelectCommand = cmdSelectCommand
            'UpdtCmd.UpdateCommand = cmdSelectCommand
            'InsrtCmd.InsertCommand = cmdSelectCommand
            builder = New SqlCommandBuilder(dadPurchaseInfo)

            CompSurceTable.Rows.Clear()
            CompSurceTable.Columns.Clear()
            dadPurchaseInfo.Fill(CompSurceTable)
            Grid1.DataSource = CompSurceTable

        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
    End Sub
    Private Sub ButtonXX_Click(sender As Object, e As EventArgs)

        Try
            'Dim cmdSelectCommand As SqlCommand = New SqlCommand("se lect SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm", sqlCon)
            'cmdSelectCommand.CommandTimeout = 30
            'CompSurceTable.Rows(5).Item(1) = "YYY"

            'dadPurchaseInfo.Update(CompSurceTable)
            'dadPurchaseInfo.Fill(CompSurceTable)
            'dadPurchaseInfo.UpdateCommand = builder.GetUpdateCommand()
            'builder.RefreshSchema()
            'Dim Row() As Data.DataRow
            'Row = CompSurceTable.Select("TkSQL = '133267'")
            'Row(0).Item("TkID") = 9999
            'dadPurchaseInfo.UpdateCommand.ExecuteNonQuery()

            dadPurchaseInfo.Update(CompSurceTable)

            Grid1.DataSource = CompSurceTable
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try


    End Sub
    Private Sub ButtonRefill_Click(sender As Object, e As EventArgs)
        Try
            CompSurceTable.Rows.Clear()
            dadPurchaseInfo.Fill(CompSurceTable)
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
    End Sub
End Class