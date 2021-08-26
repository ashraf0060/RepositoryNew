Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports Microsoft.Exchange.WebServices.Data

Public Class WelcomeScreen
    Dim servrstsus As Boolean = False
    Dim servrTring As Boolean = False
    Dim Servr As TcpListener

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
        If PreciFlag = True Then
            PubVerLbl.Text = "IP: " & OsIP()
            'AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString
            If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                LblUsrIP.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
            Else
                LblUsrIP.Text = "Publish Ver. : This isn't a Publish version"
            End If
        Else
            Me.Close()
        End If
        GC.Collect()
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
        If IsHandleCreated = True Then
            Invoke(Sub()
                       Dim WC As New APblicClss.Func
                       If WkrTikCount.IsBusy = False Then
                           Invoke(Sub() WkrTikCount.RunWorkerAsync(WC))
                       End If
                   End Sub)
        End If
    End Sub
    Private Sub TimerOp_Tick(sender As Object, e As EventArgs) Handles TimerOp.Tick
        If Opacity < 1 Then
            Opacity += 0.06
        Else
            Login.TimerClose.Stop()
            TimerCon.Start()
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
        Me.CntxtMnuStrp.Close()
        'Invoke(Sub() LodngFrm.Close())
        'Invoke(Sub() LodngFrm.Dispose())
        On Error Resume Next
        For Each f As Form In My.Application.OpenForms
            f.Close()
            f.Dispose()
        Next
        Me.Close()
        Application.Exit()
    End Sub
    Private Sub SinOutEvent()
        CntxtMnuStrp.Close()
        FlushMemory()
        PublicCode.InsUpd("UPDATE Int_user SET UsrActive = 0" & " WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
    End Sub
    Private Sub TimerCon_Tick(sender As Object, e As EventArgs) Handles TimerCon.Tick
        If IsHandleCreated = True Then
            Invoke(Sub()
                       If sqlCon.State = ConnectionState.Closed Then
                           Dim state As New APblicClss.Defntion
                           Dim Cn As New APblicClss.Func
                           If WChckConn.IsBusy = False Then
                               Invoke(Sub() WChckConn.RunWorkerAsync(Cn))
                           End If
                       End If

                   End Sub)
        End If
    End Sub
#Region "Check Connection"
    Private Sub WChckConn_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WChckConn.DoWork
        Dim worker1 As System.ComponentModel.BackgroundWorker
        worker1 = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC1 As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        WC1.Conoff(worker1)
    End Sub
    Private Sub WChckConn_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WChckConn.ProgressChanged
        If Me.IsHandleCreated = True Then
            Invoke(Sub()
                       Dim state As APblicClss.Defntion = CType(e.UserState, APblicClss.Defntion)
                       If Bol = True Then
                           StatusBar1.Invoke(Sub() StatBrPnlEn.Text = "Online " & ServerNm)
                           StatusBar1.Invoke(Sub() StatBrPnlEn.Icon = My.Resources.WSOn032)
                       ElseIf Bol = False Then
                           StatusBar1.Invoke(Sub() StatBrPnlEn.Icon = My.Resources.WSOff032)
                           StatusBar1.Invoke(Sub() StatBrPnlEn.Text = "Offline " & ServerNm)
                       End If
                   End Sub)
        End If
    End Sub
#End Region
    'Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Private Sub DbStat_MouseHover(sender As Object, e As EventArgs) Handles DbStat.MouseHover
        ToolTip1.Show(DbStat.Tag, DbStat, 0, 20, 2000)
    End Sub
    Private Sub MenuSw_Click(sender As Object, e As EventArgs) Handles MenuSw.Click
        Dim Fn As New APblicClss.Func
        If PreciFlag = True Then
            'Fn.InsUpd("UPDATE Int_user SET UsrLastSeen = '" & Format(Now, "yyyy/MM/dd h:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H", worker)  'Update User Active = false
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
    Private Sub WelcomeScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Invoke(Sub()
                   For Each CTRL In Me.Controls
                       If TypeOf CTRL Is Timer Then
                           CTRL.stop()
                       ElseIf TypeOf CTRL Is System.ComponentModel.BackgroundWorker Then
                           CTRL.CancelAsync()
                       End If
                   Next
                   CntxtMnuStrp.Close()
                   Me.Dispose()
               End Sub)
    End Sub
    Private Sub WelcomeScreen_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FrmAllSub(Me)
        TimerOp.Start()

        Me.Size = New Point(screenWidth, screenHeight)
        If System.Text.Encoding.Default.HeaderName <> "windows-1256" Then
            GroupBox1.Visible = False
            GrpCounters.Visible = False
            Me.BackgroundImage = My.Resources.Language_for_Non_Unicode_Programs
        Else
            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Dim Ext_ As Boolean = False
            For Each N As ToolStripMenuItem In CntxtMnuStrp.Items
                If N.Text = "Sign Out" Then
                    Ext_ = True
                    Exit For
                End If
            Next

            If Ext_ = False Then
                Dim Signout As New ToolStripMenuItem("Sign Out")  'YYYYYYYYYYY
                Dim Exit_ As New ToolStripMenuItem("Exit")  'YYYYYYYYYYY
                CntxtMnuStrp.Items.Add(Signout)  'YYYYYYYYYYY
                CntxtMnuStrp.Items.Add(Exit_)  'YYYYYYYYYYY

                RemoveHandler Signout.Click, AddressOf SnOutBt_Click  'YYYYYYYYYYY
                RemoveHandler Exit_.Click, AddressOf ExtBt_Click  'YYYYYYYYYYY

                AddHandler Signout.Click, AddressOf SnOutBt_Click  'YYYYYYYYYYY
                AddHandler Exit_.Click, AddressOf ExtBt_Click  'YYYYYYYYYYY
            End If

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
            DbStat.Margin = New Padding(DbStat.Margin.Left, DbStat.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (DbStat.Width + DbStat.Margin.Left), DbStat.Margin.Bottom)
            PictureBox1.Margin = New Padding(PictureBox1.Margin.Left, PictureBox1.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (GroupBox1.Width + GroupBox1.Margin.Right + GroupBox1.Margin.Left + ConterWidt + PictureBox1.Width + PictureBox1.Margin.Left), PictureBox1.Margin.Bottom)
            LblUsrRNm.Margin = New Padding(LblUsrRNm.Margin.Left, LblUsrRNm.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblUsrRNm.Width + LblUsrRNm.Margin.Left), LblUsrRNm.Margin.Bottom)
            LblSrvrNm.Margin = New Padding(LblSrvrNm.Margin.Left, LblSrvrNm.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblSrvrNm.Width + LblUsrRNm.Margin.Left), LblSrvrNm.Margin.Bottom)
            LblLstSeen.Margin = New Padding(LblLstSeen.Margin.Left, LblLstSeen.Margin.Top, FlowLayoutPanel1.ClientRectangle.Width - (LblLstSeen.Width + LblUsrRNm.Margin.Left), LblLstSeen.Margin.Bottom)
            TimerTikCoun.Start()
            TimrFlsh.Start()

        End If
    End Sub
    Private Sub WkrTikCount_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WkrTikCount.DoWork
        Dim worker1 As System.ComponentModel.BackgroundWorker
        worker1 = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC1 As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        WC1.TikCntrSub(worker1)
    End Sub

    Private Sub WkrTikCount_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WkrTikCount.ProgressChanged

    End Sub

    Private Sub WkrTikCount_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WkrTikCount.RunWorkerCompleted
        Dim Fn As New APblicClss.Func
        If e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            MessageBox.Show("Word counting canceled.")
        Else
            'MessageBox.Show("Finished counting words.")

            If TicTable.Rows.Count > 0 Then
                If TicTable.Rows(0).Item("UsrActive") = False Then


                    Dim frmCollection = Application.OpenForms
                    If frmCollection.OfType(Of Login).Any Then
                    Else
                        Invoke(Sub() Login.ExitBtn.Enabled = False)
                        Invoke(Sub() Login.TxtUsrNm.Text = Usr.PUsrNm)
                        Invoke(Sub() Login.TxtUsrPass.Focus())
                        Invoke(Sub() Login.TxtUsrNm.ReadOnly = True)
                        Invoke(Sub() CntxtMnuStrp.Enabled = False)
                        Invoke(Sub() CntxtMnuStrp.Enabled = False)
                        Invoke(Sub() Login.ShowDialog())
                        'Invoke(Sub() TimerTikCoun.Start())
                        'Invoke(Sub() Login.Timer1.Start())
                        Invoke(Sub() CntxtMnuStrp.Enabled = True)
                        Invoke(Sub() CntxtMnuStrp.Enabled = True)
                        Exit Sub
                    End If
                End If
                'If Math.Abs(DateTime.Parse(Nw).Subtract(DateTime.Parse(TicTable.Rows(0).Item("UsrLastSeen"))).TotalMinutes) > 30 Then
                'End If

#Region "Send Log File If UsrLogSnd is True"
                If TicTable.Rows(0).Item("UsrLogSnd") = True Then
                    'TimerColctLog.Interval = 5000
                    tempTable = New DataTable
                    Fn.GetTbl("Select Mlxx from Alib", tempTable, "0000&H", sender)
                    Dim exchange As ExchangeService
                    exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
                    exchange.Credentials = New WebCredentials("egyptpost\voca-support", tempTable.Rows(0).Item(0).ToString)
                    exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                    Dim message As New EmailMessage(exchange)
                    'message.ToRecipients.Add("voca-support@egyptpost.org")
                    message.CcRecipients.Add("a.farag@egyptpost.org")
                    message.Subject = "VOCA Log Of " & Usr.PUsrRlNm & "," & Usr.PUsrID & "," & OsIP()
                    message.Body = "VOCA Log File"
                    Dim fileAttachment As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "VOCALog" & Format(Now, "yyyyMM") & ".Vlg"
                    message.Attachments.AddFileAttachment(fileAttachment)
                    message.Attachments(0).ContentId = "VOCALog" & Format(Now, "yyyyMM")
                    message.Importance = 1
                    Try
                        message.SendAndSaveCopy()
                        If Fn.InsUpd("UPDATE Int_user SET UsrLogSnd = 0  WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H", sender) = Nothing Then
                        End If
                    Catch ex As Exception
                        MsgInf(ex.Message)
                    End Try
                End If

#End Region

            End If
            If IsHandleCreated = True Then
                Invoke(Sub()
                           If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                               Dim Notif As String = ""
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
                                   If Notif.Length > 6 Then
                                       NotifyIcon1.ShowBalloonTip(0, "", Notif, ToolTipIcon.Info)
                                   End If
                               End If
                           End If
                       End Sub)
            End If

        End If

    End Sub
End Class