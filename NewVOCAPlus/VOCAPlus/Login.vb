Imports System.Threading
Imports System.Drawing.Drawing2D
Imports System.Reflection

Public Class Login
    Dim HardTable As DataTable = New DataTable
    Dim VerTbl As DataTable = New DataTable
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmbo.Items.Add("Eg Server")
        Cmbo.Items.Add("My Labtop")
        Cmbo.Items.Add("Test Database")
        ' Check Ver.
        LblUsrIP.Text = "IP: " & OsIP()
        'AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString ' major.minor.build.revision
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If

        ChckAdmin()
        BtnSub(Me)

        Dim PrTblTsk As New Thread(AddressOf HrdWre)
            PrTblTsk.IsBackground = True
            PrTblTsk.Start()

GoodVer:  '       *****      End Check Ver.
            TxtUsrNm.Select()
            MskLbl.Text = LCase(Environment.UserName)
            Me.BtnShow.Text = "Show Password"
            For Cnt_ = 0 To (InputLanguage.InstalledInputLanguages.Count - 1)
                If InputLanguage.InstalledInputLanguages(Cnt_).Culture.TwoLetterISOLanguageName = ("ar") Then
                    ArabicInput = InputLanguage.InstalledInputLanguages(Cnt_)
                ElseIf InputLanguage.InstalledInputLanguages(Cnt_).Culture.TwoLetterISOLanguageName = ("en") Or InputLanguage.InstalledInputLanguages(Cnt_).Culture.TwoLetterISOLanguageName = ("ع") Then
                    EnglishInput = InputLanguage.InstalledInputLanguages(Cnt_)
                End If
            Next Cnt_





        'Dim oShell As Object
        'Dim oLink As Object
        ''you don’t need to import anything in the project reference to create the Shell Object
        'Try
        '    oShell = CreateObject("WScript.Shell")
        '    oLink = oShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & "VOCA+" & ".lnk")

        '    oLink.TargetPath = Uri.UnescapeDataString(New System.UriBuilder(System.Reflection.Assembly.GetExecutingAssembly.CodeBase).Path)
        '    oLink.WindowStyle = 1
        '    oLink.Save()
        'Catch ex As Exception

        'End Try
        'MsgBox(Uri.UnescapeDataString((New System.UriBuilder(System.Reflection.Assembly.GetExecutingAssembly.CodeBase).Path)))

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'VerTbl.Rows.Clear()
        'VerTbl.Columns.Clear()

        'If GetTbl("select VerMj, VerMn, VerBl, VerRv From ALib", VerTbl, "1000&H") = Nothing Then
        '    If VerTbl.Rows(0).Item(0).ToString & "." & VerTbl.Rows(0).Item(1).ToString & "." & VerTbl.Rows(0).Item(2).ToString & "." & VerTbl.Rows(0).Item(3).ToString <> Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4) Then
        '        LblHdr.ForeColor = Color.Red
        '        LblHdr.Text = "- There is a newer version Available For DownLoad! Please Remove Proxy and restart App Again." & vbCrLf & "- You Can call Support Team If Needed." & vbCrLf & "- Newer Version is : " & VerTbl.Rows(0).Item(0).ToString & "." & VerTbl.Rows(0).Item(1).ToString & "." & VerTbl.Rows(0).Item(2).ToString & "." & VerTbl.Rows(0).Item(3).ToString
        '        TxtUsrNm.Enabled = False
        '        TxtUsrPass.Enabled = False
        '        MskLbl.Visible = False
        '        LblUsrNm.Visible = False
        '        LblUsrPw.Visible = False
        '        BtnShow.Visible = False
        '        LogInBtn.Visible = False
        '    End If
        '    GoTo GoodVer
        'Else
        '    Close()
        'End If

    End Sub
    Private Sub HrdWre()
        On Error Resume Next
        If PublicCode.GetTbl("select IpId, IpStime FROM SdHardCollc WHERE ((IpId= '" & OsIP() & "'));", HardTable, "1000&H") = Nothing Then
            If HardTable.Rows.Count = 0 Then 'insert new computer hardware information if not founded into Hardware Table
                HrdCol()
                PublicCode.InsUpd("insert into SdHardCollc (IpId, IpLocation, IpProsseccor, IpRam, IpNetwork, IpSerialNo, IpCollect) values ('" & OsIP() & "','" & "Location" & "','" & HrdCol.HProcc & "','" & HrdCol.HRam & "','" & HrdCol.HNetwrk & "','" & HrdCol.HSerNo & "','" & True & "');", "1000&H") 'Append access Record
            ElseIf Math.Abs(DateTime.Parse(Today).Subtract(DateTime.Parse(HardTable.Rows(0).Item(1))).TotalDays) > 30 Then
                HrdCol()
                PublicCode.InsUpd("UPDATE SdHardCollc SET IpProsseccor ='" & HrdCol.HProcc & "', IpRam ='" & HrdCol.HRam & "', IpNetwork ='" & HrdCol.HNetwrk & "', IpSerialNo ='" & HrdCol.HSerNo & "', IpStime ='" & Format(ServrTime(), "yyyy-MM-dd") & "' where IpId='" & OsIP() & "';", "1000&H")
            End If
        End If
Sec2:
        HardTable.Clear()
        HardTable.Dispose()
        GC.Collect()
    End Sub
    Private Sub LogInBtn__Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        Loginn()
    End Sub
    Private Sub Loginn()
        LogInBtn.Enabled = False
        Dim SQLSTR As String = ""
        Dim Msgs As String = ""
        Dim LblImg As Image = My.Resources.Empty
        If TxtUsrNm.Text = "" Then TxtUsrNm.Text = MskLbl.Text
        StatusBarPanel1.Text = "Connecting ..........."
        UserTable.Rows.Clear()
        UserTable.Columns.Clear()
        LblLogin.Text = "          Authenticating"
        LblLogin.Image = My.Resources.Info
        LblLogin.ForeColor = Color.Blue
        LblLogin.Refresh()
        '                              0       1       2      3       4            5        6           7           8          9          10        11     as SaltKey                                                                                                                                                                     ,   12                        13         14       15      16        17        18         19         20         21         22         23        24              ************
        If PublicCode.GetTbl("SELECT UsrId, UsrCat, UsrNm, UsrPass, UsrLevel, UsrRealNm, UsrGender, UsrActive, UsrLastSeen, UsrSusp, UsrTkCount, RIGHT(dbo.IntGuid.PRGUID, CAST(LEFT(dbo.IntGuid.Id, 2) AS int) / 2) + SUBSTRING(dbo.IntGuid.GUID, 3, 5) + LEFT(dbo.IntGuid.PRGUID, CAST(RIGHT(dbo.IntGuid.Id, 2) AS int) / 2) AS SaltKey, UCatNm, UsrSisco, UsrGsm, UsrCalCntr, UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UCatLvl, UsrRecevDy, UsrClsUpdtd, UsrTikFlowDy, UsrEmail FROM int_user INNER JOIN dbo.IntGuid ON int_user.UsrKey = SUBSTRING(dbo.IntGuid.GUID, 26, 11) INNER JOIN dbo.IntUserCat ON int_user.UsrCat = dbo.IntUserCat.UCatId Where (UsrNm = N'" & Me.TxtUsrNm.Text & "');", UserTable, "1001&H") = Nothing Then
            StatusBarPanel1.Text = "Online"
            StatusBarPanel1.Icon = My.Resources.WSOn032
        Else
            LogInBtn.Enabled = True
            StatusBarPanel1.Icon = My.Resources.WSOff032
            LblLogin.Text = ("          " & My.Resources.ConnErr & " - " & My.Resources.TryAgain)
            LblLogin.Image = My.Resources.Check_Marks2
            LblLogin.ForeColor = Color.Red
            LblLogin.Refresh()
            Exit Sub
        End If

        If UserTable.Rows.Count = 1 Then
            Usr.PUsrID = UserTable.Rows(0).Item(0).ToString                     'store user ID
            Usr.PUsrCat = UserTable.Rows(0).Item(1).ToString                    'Current User Catagory
            Usr.PUsrNm = UserTable.Rows(0).Item(2).ToString                     'Current User Name
            Usr.PUsrPWrd = UserTable.Rows(0).Item(3).ToString                   'Current User Password
            Usr.PUsrLvl = UserTable.Rows(0).Item(4).ToString                    'Current User Class
            Usr.PUsrRlNm = UserTable.Rows(0).Item(5).ToString                   'Current user Real Name
            Usr.PUsrMail = UserTable.Rows(0).Item("UsrEmail").ToString          'Current user UsrEmail
            Usr.PUsrSisco = UserTable.Rows(0).Item("UsrSisco").ToString         'Current user UsrSisco
            Usr.PUsrGsm = UserTable.Rows(0).Item("UsrGsm").ToString             'Current user UsrGsm
            Usr.PUsrGndr = UserTable.Rows(0).Item(6).ToString                   'Current user Gender
            Usr.PUsrActv = UserTable.Rows(0).Item(7).ToString                   'Current User Active Or not
            Usr.PUsrLstS = UserTable.Rows(0).Item(8).ToString                   'Current User LastSeen
            Usr.PUsrSusp = UserTable.Rows(0).Item(9).ToString                   'Current User Suspended Or not
            Usr.PUsrTcCnt = UserTable.Rows(0).Item(10).ToString                 'Ticket Count
            Usr.PUsrSltKy = UserTable.Rows(0).Item(11).ToString                 'SaltKey
            Usr.PUsrCatNm = UserTable.Rows(0).Item(12).ToString                 'Catagory name
            Usr.PUsrCalCntr = UserTable.Rows(0).Item("UsrCalCntr").ToString     'Call Center Boolean
            Usr.PUsrUCatLvl = UserTable.Rows(0).Item("UCatLvl").ToString        'User Cat. Level
            Usr.PUsrClsN = UserTable.Rows(0).Item("UsrClsN").ToString           'Open Complaint Count
            Usr.PUsrFlN = UserTable.Rows(0).Item("UsrFlN").ToString             'No Follow Count
            Usr.PUsrReOpY = UserTable.Rows(0).Item("UsrReOpY").ToString         'ReOPen Couunt
            Usr.PUsrUnRead = UserTable.Rows(0).Item("UsrUnRead").ToString       'Unread Events Count
            Usr.PUsrEvDy = UserTable.Rows(0).Item("UsrEvDy").ToString           'Event Count Per Day
            Usr.PUsrClsYDy = UserTable.Rows(0).Item("UsrClsYDy").ToString       'Closed Complaint Per day
            Usr.PUsrReadYDy = UserTable.Rows(0).Item("UsrReadYDy").ToString     'Read Events Count Per Day
            Usr.PUsrRecvDy = UserTable.Rows(0).Item("UsrRecevDy").ToString      'RecievedTickets Count Per Day
            Usr.PUsrClsUpdtd = UserTable.Rows(0).Item("UsrClsUpdtd").ToString    'Closed Tickets with New Updates
            Usr.PUsrFolwDay = UserTable.Rows(0).Item("UsrTikFlowDy").ToString    'Closed Tickets with New Updates
        Else    'if user Name is Error
            SQLSTR = "insert into Int_access (UaccNm, UaccUsrIP, UaccStat) values ('" & TxtUsrNm.Text & "','" & OsIP() & "','" & "Fa" & "');" 'Append access Record
            Msgs = "          Invalid User Name Or Password"
            LblImg = My.Resources.Check_Marks2
            LblLogin.ForeColor = Color.Red
            GoTo sec_UsrErr_
        End If


        If Usr.PUsrSusp = True Then  'if user is suspended
            SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtUsrNm.Text & "','" & Usr.PUsrID & "','" & OsIP() & "','" & "Su" & "');" 'Append access Record with Su Stat
            Msgs = "          User has been suspended" & " - " & "Please Call System Administrator"
            LblImg = My.Resources.Check_Marks2
            LblLogin.ForeColor = Color.Red
            GoTo sec_UsrErr_
        End If

        'Admin Login For Every user Related to Mac address
        For Cnt_ = 0 To MacTable.Rows.Count - 1
            If MacTable.Rows(Cnt_).Item(0).ToString = getMacAddress() + OsIP() Then
                If MacTable.Rows(Cnt_).Item(1) = True Then
                    TxtUsrPass.Text = PassDecoding(Usr.PUsrPWrd, Usr.PUsrSltKy)
                    Exit For
                End If
            End If
        Next
        'If OsIP() = "10.10.26.4" Or OsIP() = "10.11.51.232" Or OsIP() = "10.11.51.233" Or OsIP() = "10.10.220.128" Or OsIP() = "10.10.220.129" Then
        '    TxtUsrPass.Text = (PassDecoding(Usr.PUsrPWrd, Usr.PUsrSltKy))
        'End If
        If TxtUsrNm.Text = Usr.PUsrNm And TxtUsrPass.Text = PassDecoding(Usr.PUsrPWrd, Usr.PUsrSltKy) Then 'check user name and password status
            LblLogin.Text = "          Login has been succeeded"
            LblLogin.Image = My.Resources.Check_Marks1
            LblLogin.ForeColor = Color.Green
            LblLogin.Refresh()
            If Usr.PUsrActv = True Or Usr.PUsrActv = False Then              'XXXXXXXXXXX to cancel this delete   *** Or Usr.PUsrActv = 1  ***     'if user Not Active
                If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                    If PublicCode.InsUpd("UPDATE Int_user SET UsrActive = 1, UsrIP ='" & OsIP() & "', UsrVer = '" & Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4) & "', UsrLastSeen = '" & Format(ServrTime(), "yyyy-MM-dd HH:mm:ss") & "' WHERE (UsrNm = '" & TxtUsrNm.Text & "');", "1007&H") <> Nothing Then  'Update User Active =  True    
                        StatusBarPanel1.Icon = My.Resources.WSOff032
                        Exit Sub
                    End If
                Else
                    If PublicCode.InsUpd("UPDATE Int_user SET UsrActive = 1, UsrIP ='" & OsIP() & "', UsrVer = '" & "Not Publsh" & "', UsrLastSeen = '" & Format(ServrTime(), "yyyy-MM-dd HH:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1007&H") <> Nothing Then  'Update User Active =  True    
                        StatusBarPanel1.Icon = My.Resources.WSOff032
                        Exit Sub
                    End If
                End If
                If PublicCode.InsUpd("insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat)  values ('" & TxtUsrNm.Text & "','" & Usr.PUsrID & "','" & OsIP() & "','" & "OK" & "');", "1008&H") <> Nothing Then 'Append access Record
                    LogInBtn.Enabled = True
                    StatusBarPanel1.Icon = My.Resources.WSOff032
                    Exit Sub
                End If
                GC.Collect()
                If PassDecoding(Usr.PUsrPWrd, Usr.PUsrSltKy) = "0000" Then  '     obstacle  user to Change the default Pass with the new on
                    Cnt_ = 32107 ' pass code to close the exit buttom
                    ReLogin.Show()
                    Me.Close()
                    Exit Sub
                Else
UpdtMobil_:
                    If LblLogin.Text = "          Login has been succeeded" Then
                        If Usr.PUsrGsm.Length = 0 Then
                            MyProfile.ShowDialog()
                            If Usr.PUsrGsm.Length = 0 Then
                                GoTo UpdtMobil_
                            Else
                                WelcomeScreen.Show()
                                Me.Close()
                                Me.Dispose()
                                Exit Sub
                            End If
                        Else
                            WelcomeScreen.Show()
                            Me.Close()
                            Me.Dispose()
                            Exit Sub
                        End If
                    End If

                End If
            Else                                                   'elseif user Already Active
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtUsrNm.Text & "','" & Usr.PUsrID & "','" & OsIP() & "','" & "AC" & "');" 'Append access Record as active user
                Msgs = "          User Already Active On another Mashine" & vbNewLine & "If you didn't already signed in, Please Call System Administrator"
                LblImg = My.Resources.Check_Marks2
                LblLogin.ForeColor = Color.Red
                GoTo sec_UsrErr_
            End If
        Else                                                       'elseif user Name Is OK, But Password is Error
            SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtUsrNm.Text & "','" & Usr.PUsrID & "','" & OsIP() & "','" & "Fa" & "');" 'Append access Record
            Msgs = "          Invalid User Name Or Password"
            LblImg = My.Resources.Check_Marks2
            LblLogin.ForeColor = Color.Red
        End If



sec_UsrErr_:
        LogInBtn.Enabled = True
        If PublicCode.InsUpd(SQLSTR, "1010&H") <> Nothing Then
        End If
        'MessageBox.Show(Msgs, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        LblLogin.Text = Msgs
        LblLogin.Image = LblImg
        LblLogin.Refresh()
        GC.Collect()
    End Sub
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click  ', Me.FormClosing

        'Dim frmCollection = Application.OpenForms
        'If frmCollection.OfType(Of WelcomeScreen).Any And frmCollection.OfType(Of Login).Any Then

        'Else

        'End If

        WelcomeScreen.CntxtMnuStrp.Close()
        On Error Resume Next
        For Each f As Form In My.Application.OpenForms
            f.Close()
            f.Dispose()
        Next
        Me.Close()

    End Sub
    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        If TxtUsrPass.UseSystemPasswordChar = True Then
            TxtUsrPass.UseSystemPasswordChar = False
            Me.BtnShow.Text = "Hide PassWord"
        Else
            TxtUsrPass.UseSystemPasswordChar = True
            Me.BtnShow.Text = "Show PassWord"
        End If
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TxtUsrNm.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput            'Tansfer writing to English
    End Sub
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TxtUsrPass.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput            'Tansfer writing to English
    End Sub
    Private Sub TxtUsrNm_TextChanged(sender As Object, e As EventArgs) Handles TxtUsrNm.TextChanged
        If TxtUsrNm.TextLength > 0 Then
            Me.MskLbl.Visible = False
        Else
            Me.MskLbl.Visible = True
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TxtUsrNm.Text = ComboBox1.Text 'XXXXXXXXXXXXXXXXXXXXXX DELETE
    End Sub
    Private Sub TxtUsrPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsrPass.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Loginn()
        End If
    End Sub
    Private Sub Cmbo_SelectedIndexChanged(sender As Object, e As EventArgs)
        ConStrFn(Cmbo.Text)
        ChckAdmin()
    End Sub
    Private Sub ChckAdmin()
        'If Cmbo.Items.Count > 0 Then Cmbo.Items.Clear()

        If ServerNm = "Egypt Post Server" Then
            Cmbo.Text = "Eg Server"
        ElseIf ServerNm = "My Labtop" Then
            Cmbo.Text = "My Labtop"
        ElseIf ServerNm = "Test Database" Then
            Cmbo.Text = "Test Database"
        End If
        AddHandler Cmbo.SelectedIndexChanged, AddressOf Cmbo_SelectedIndexChanged
        MacTable.Rows.Clear()
        If GetTbl("select Mac, Admin from AMac where Mac ='" & getMacAddress() + OsIP() & "'", MacTable, "8888&H") = Nothing Then
            If MacTable.Rows.Count > 0 Then
                Cmbo.Visible = True
            End If
            'For Cnt_ = 0 To MacTable.Rows.Count - 1
            '    If MacTable.Rows(Cnt_).Item(0).ToString = getMacAddress() + OsIP() Then
            '        Cmbo.Visible = True
            '        Exit For
            '    Else
            '        Cmbo.Visible = False
            '    End If
            'Next
        Else
            'RemoveHandler Cmbo.SelectedIndexChanged, AddressOf Cmbo_SelectedIndexChanged
            ''Cmbo.Text = "My Labtop"
            'ConStrFn(Cmbo.Text)
            'If GetTbl("select Mac, Admin from AMac where Mac ='" & getMacAddress() + OsIP() & "'", MacTable, "0000&H") = Nothing Then
            '    For Cnt_ = 0 To MacTable.Rows.Count - 1
            '        If MacTable.Rows(Cnt_).Item(0).ToString = getMacAddress() + OsIP() Then
            '            Cmbo.Visible = True
            '            Exit For
            '        Else
            '            Cmbo.Visible = False
            '        End If
            '    Next
            'End If
        End If
    End Sub
    Private Sub LblUsrIP_Click(sender As Object, e As EventArgs) Handles LblUsrIP.Click
        MsgBox(GetMACAddressNew())
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim tes As New DataTable
        If LogCollect() > 0 Then
            Dim FF As New Form
            Dim hh As New DataGridView
            FF.Controls.Add(hh)
            hh.DataSource = LogOfflinTbl
            FF.WindowState = FormWindowState.Maximized
            hh.Dock = DockStyle.Fill
            FF.ShowDialog()
        Else
            MsgBox("there is No Records to Display")
        End If
    End Sub
End Class