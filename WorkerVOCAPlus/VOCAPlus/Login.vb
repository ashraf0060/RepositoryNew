Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Login
    Dim VerTbl As DataTable = New DataTable
    Dim NotComplete As String = "لم يتم تحميل"
    Private Sub HrdWrWrkr_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles HrdWrWrkr.DoWork
        ' This event handler is where the actual work is done.
        ' This method runs on the background thread.
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        ' Get the Words object and call the main method.
        Dim WC As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        WC.HrdWre(worker)
    End Sub
    <Obsolete>
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CheckForIllegalCrossThreadCalls = False
        'Dim Forms As New List(Of Form)()
        'For Each t As Type In Me.GetType().Assembly.GetTypes()
        '    If IsNothing(t.BaseType) = False Then
        '        If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
        '            Forms.Add(CType(Activator.CreateInstance(Type.GetType("VOCAPlus." & t.Name)), Form))
        '            'CType(Activator.CreateInstance(Type.GetType(formName)), Form)

        '            Dim formName As String = "VOCAPlus." & t.Name
        '            Foooooooooooorm = CType(Activator.CreateInstance(Type.GetType(formName)), Form)
        '            RemoveHandler Foooooooooooorm.Load, AddressOf Frm_Activated
        '            AddHandler Foooooooooooorm.Load, AddressOf Frm_Activated
        '        End If
        '    End If
        'Next
        'Dim PrTblTswk As New Thread(AddressOf Main)

        'PrTblTswk.IsBackground = True
        'PrTblTswk.Start()
        'Exit Sub
        Cmbo.Items.Add("Eg Server")
        Cmbo.Items.Add("My Labtop")
        Cmbo.Items.Add("Test Database")
        Cmbo.SelectedItem = "Eg Server"
        ServerCD = Cmbo.SelectedItem
        RemoveHandler Cmbo.SelectedIndexChanged, AddressOf Cmbo_SelectedIndexChanged
        AddHandler Cmbo.SelectedIndexChanged, AddressOf Cmbo_SelectedIndexChanged
        StatusBarPanel1.Icon = My.Resources.WSOff032
        ' Check Ver.
        LblUsrIP.Text = "IP: " & OsIP()
        'AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString ' major.minor.build.revision
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If


GoodVer:  '       *****      End Check Ver.
        TxtUsrNm.Select()
        TxtUsrNm.Text = LCase(Environment.UserName)
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
        Invoke(Sub()
                   Dim WC As New APblicClss.Func
                   If HrdWrWrkr.IsBusy = False Then
                       HrdWrWrkr.RunWorkerAsync(WC)
                   End If
               End Sub)


    End Sub
    Private Sub LogInBtn__Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        Loginn()
    End Sub
    Private Sub Loginn()
        Dim Def As New APblicClss.Defntion
        Dim Fn As New APblicClss.Func
        LogInBtn.Enabled = False
        Dim SQLSTR As String = ""
        Dim Msgs As String = ""
        Dim LblImg As Image = My.Resources.Empty
        StatusBarPanel1.Text = "Connecting ..........."
        UserTable.Rows.Clear()
        UserTable.Columns.Clear()
        LblLogin.Text = "          Authenticating"
        LblLogin.Image = My.Resources.Info
        LblLogin.ForeColor = Color.Blue
        LblLogin.Refresh()
        Timer1.Stop()
        '                              0       1       2      3       4            5        6           7           8          9          10        11     as SaltKey                                                                                                                                                                     ,   12                        13         14       15      16        17        18         19         20         21         22         23        24              ************
        If GetTbl("SELECT UsrId, UsrCat, UsrNm, UsrPass, UsrLevel, UsrRealNm, UsrGender, UsrActive, UsrLastSeen, UsrSusp, UsrTkCount, RIGHT(dbo.IntGuid.PRGUID, CAST(LEFT(dbo.IntGuid.Id, 2) AS int) / 2) + SUBSTRING(dbo.IntGuid.GUID, 3, 5) + LEFT(dbo.IntGuid.PRGUID, CAST(RIGHT(dbo.IntGuid.Id, 2) AS int) / 2) AS SaltKey, UCatNm, UsrSisco, UsrGsm, UsrCalCntr, UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UCatLvl, UsrRecevDy, UsrClsUpdtd, UsrTikFlowDy, UsrEmail FROM int_user INNER JOIN dbo.IntGuid ON int_user.UsrKey = SUBSTRING(dbo.IntGuid.GUID, 26, 11) INNER JOIN dbo.IntUserCat ON int_user.UsrCat = dbo.IntUserCat.UCatId Where (UsrNm = N'" & Me.TxtUsrNm.Text & "');", UserTable, "1001&H") = Nothing Then
            StatusBarPanel1.Text = "Online"
            StatusBarPanel1.Icon = My.Resources.WSOn032
        Else

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
            If MacTable.Rows(Cnt_).Item(0).ToString = GetMACAddressNew() Then
                If MacTable.Rows(Cnt_).Item(1) = True Then
                    TxtUsrPass.Text = Fn.PassDecoding(Usr.PUsrPWrd, Usr.PUsrSltKy)
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
                                Dim Cn As New APblicClss.Func
                                If WrkrLogin.IsBusy = False Then
                                    WrkrLogin.RunWorkerAsync(Cn)
                                End If
                                Exit Sub
                            End If
                        Else
                            Dim Cn As New APblicClss.Func
                            If WrkrLogin.IsBusy = False Then
                                WrkrLogin.RunWorkerAsync(Cn)
                            End If
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

        LogInBtn.Enabled = True

sec_UsrErr_:
        LogInBtn.Enabled = True
        If PublicCode.InsUpd(SQLSTR, "1010&H") <> Nothing Then
        End If
        'MessageBox.Show(Msgs, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        LblLogin.Text = Msgs
        LblLogin.Image = LblImg
        LblLogin.Refresh()
        GC.Collect()
        Timer1.Start()
    End Sub

#Region "XXXXXXXXXXXXXXXXXXXXXXXXXXX"
    'Private Sub SwitchBoard()
    '    Dim SwichTabTable As DataTable = New DataTable
    '    Dim SwichButTable As DataTable = New DataTable
    '    Dim PrTblTsk As New Thread(AddressOf PreciTbl)
    '    PrTblTsk.IsBackground = True
    '    If PublicCode.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew FROM ASwitchboard WHERE (SwType = N'Tab') AND (SwNm <> N'NA') ORDER BY SwID", SwichTabTable, "1002&H") = Nothing Then
    '        WelcomeScreen.FlowLayoutPanel1.Visible = False
    '        WelcomeScreen.Refresh()
    '        WelcomeScreen.MenuSw.Items.Clear()
    '        WelcomeScreen.CntxtMnuStrp.Items.Clear()
    '        For Cnt_ = 0 To SwichTabTable.Rows.Count - 1
    '            Dim NewTab As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)
    '            Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)  'YYYYYYYYYYY

    '            If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "A" Or
    '                    Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then

    '                WelcomeScreen.MenuSw.Items.Add(NewTab)
    '                WelcomeScreen.CntxtMnuStrp.Items.Add(NewTabCx)                     'YYYYYYYYYYY
    '                SwichButTable.Rows.Clear()
    '                If PublicCode.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNm, SwObjImg, SwObjNew FROM ASwitchboard WHERE (SwType <> N'Tab') AND (SwNm <> N'NA') AND (SwSer ='" & SwichTabTable.Rows(Cnt_).Item(1).ToString & "') ORDER BY SwID;", SwichButTable, "1002&H") = Nothing Then
    '                    For Cnt_1 = 0 To SwichButTable.Rows.Count - 1
    '                        Dim subItem As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)
    '                        Dim subItemCx As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)  'YYYYYYYYYYY
    '                        If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "A" Or
    '                               Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then
    '                            NewTab.DropDownItems.Add(subItem)
    '                            NewTabCx.DropDownItems.Add(subItemCx)    'YYYYYYYYYYY
    '                            subItem.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString
    '                            If DBNull.Value.Equals(SwichButTable.Rows(Cnt_1).Item("SwObjImg")) = False Then
    '                                Dim Cnt_ = ImageList1.Images(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
    '                                Dim dd = My.Resources.ResourceManager.GetObject(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
    '                                subItem.Image = Cnt_
    '                            End If
    '                            subItemCx.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString  'YYYYYYYYYYY
    '                            AddHandler subItem.Click, AddressOf ClkEvntClick
    '                            AddHandler subItemCx.Click, AddressOf ClkEvntClick  '✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔✔
    '                        End If
    '                        If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then
    '                            subItem.AccessibleName = "True"
    '                            subItemCx.AccessibleName = "True"
    '                        End If
    '                    Next Cnt_1
    '                Else
    '                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
    '                End If
    '            End If
    '            If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
    '                NewTab.AccessibleName = "True"
    '                NewTabCx.AccessibleName = "True"
    '                AddHandler NewTab.Click, AddressOf TabClick
    '                AddHandler NewTabCx.Click, AddressOf TabClick
    '            End If
    '            NewTab = Nothing
    '        Next Cnt_
    '        WelcomeScreen.FlowLayoutPanel1.Visible = True
    '        WelcomeScreen.Refresh()
    '        PrciTblCnt = 0
    '        SwichTabTable.Dispose()
    '        SwichButTable.Dispose()
    '        LoadFrm((screenWidth - LodngFrm.Width) / 2, (screenHeight - LodngFrm.Height) / 2)
    '        Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل البيانات ...")
    '        Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '        PrTblTsk.Start()
    '    Else
    '        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
    '    End If
    'End Sub

    'Private Sub PreciTbl()
    '    Dim primaryKey(0) As DataColumn
    '    AreaTable = New DataTable
    '    OfficeTable = New DataTable
    '    CompSurceTable = New DataTable
    '    CountryTable = New DataTable
    '    ProdKTable = New DataTable
    '    ProdCompTable = New DataTable
    '    UpdateKTable = New DataTable
    '    Invoke(Sub() PublicCode.LoadFrm(350, 500))
    '    Invoke(Sub() LodngFrm.LblMsg.Text = "جاري تحميل أسماء المناطق ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())

    '    If PublicCode.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H") = Nothing Then
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " أسماء المناطق / "
    '    End If

    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أسماء المكاتب ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If PublicCode.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H") = Nothing Then
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " أسماء المكاتب / "
    '    End If

    '    Dim SrcStr As String = ""
    '    If Usr.PUsrUCatLvl = 7 Then
    '        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
    '    Else
    '        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
    '    End If
    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل مصادر الشكوى ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If PublicCode.GetTbl(SrcStr, CompSurceTable, "1012&H") = Nothing Then
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " مصادر الشكوى / "
    '    End If


    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أسماء الدول ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If PublicCode.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H") = Nothing Then
    '        primaryKey(0) = CountryTable.Columns("CounCd")
    '        CountryTable.PrimaryKey = primaryKey
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " أسماء الدول / "
    '    End If


    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع الخدمات ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If PublicCode.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H") = Nothing Then
    '        primaryKey(0) = ProdKTable.Columns("ProdKNm")
    '        ProdKTable.PrimaryKey = primaryKey
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " أنواع الخدمات / "
    '    End If


    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع المنتجات ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If PublicCode.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H") = Nothing Then
    '        primaryKey(0) = ProdCompTable.Columns("FnSQL")
    '        ProdCompTable.PrimaryKey = primaryKey
    '        PrciTblCnt += 1
    '    Else
    '        NotComplete += " أنواع المنتجات / "
    '    End If

    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل أنواع التحديثات ...")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
    '        If PublicCode.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H") = Nothing Then
    '            PrciTblCnt += 1
    '        Else
    '            NotComplete += " أنواع التحديثات / "
    '        End If
    '    Else
    '        If PublicCode.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H") = Nothing Then
    '            PrciTblCnt += 1
    '        Else
    '            NotComplete += " أنواع التحديثات / "
    '        End If
    '    End If
    '    If PrciTblCnt = 7 Then
    '        PreciFlag = True
    '        WelcomeScreen.DbStat.BackgroundImage = My.Resources.DBOn
    '        WelcomeScreen.DbStat.Tag = "تم تحميل قواعد البيانات الأساسية بنجـــاح"
    '        LodUsrPic()
    '        If Usr.PUsrGndr = "Male" Then
    '            Invoke(Sub() WelcomeScreen.LblUsrRNm.Text = "Welcome Back Mr. " & Usr.PUsrRlNm)
    '            Invoke(Sub() WelcomeScreen.Text = "VOCA Plus - " & "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
    '        Else
    '            Invoke(Sub() WelcomeScreen.LblUsrRNm.Text = "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
    '            Invoke(Sub() WelcomeScreen.Text = "VOCA Plus - " & "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
    '        End If

    '        NonEditableLbl(WelcomeScreen.LblUsrRNm)
    '        TimerClose.Start()
    '        Invoke(Sub() LodngFrm.Close())
    '        Invoke(Sub() LodngFrm.Dispose())
    '        Invoke(Sub() WelcomeScreen.Show())
    '        Invoke(Sub() Me.Close())
    '    Else
    '        MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
    '        MsgErr(NotComplete)
    '    End If

    '    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'End Sub
    'Private Sub LodUsrPic()
    '    Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/UserPic/" & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg")
    '    request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
    '    request.Method = WebRequestMethods.Ftp.DownloadFile
    '    request.Timeout = 10000
    '    Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل الصورة الشخصية ..................")
    '    Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '    Try
    '        Dim ftpStream As Stream = request.GetResponse().GetResponseStream()
    '        Dim buffer As Byte() = New Byte(10240 - 1) {}
    '        WelcomeScreen.PictureBox1.Image = Image.FromStream(ftpStream) 'Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & Usr.PUsrID & ".jpg")
    '        WelcomeScreen.PictureBox1.Refresh()
    '        WelcomeScreen.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    '        WelcomeScreen.PictureBox1.BorderStyle = BorderStyle.None
    '        request.Abort()
    '        ftpStream.Close()
    '        ftpStream.Dispose()
    '        WelcomeScreen.StatBrPnlAr.Text = ""
    '    Catch ex As Exception
    '        Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "لم يتم تحميل الصورة الشخصية")
    '        Invoke(Sub() LodngFrm.LblMsg.Refresh())
    '        WelcomeScreen.PictureBox1.Image = My.Resources.UsrResm
    '        WelcomeScreen.PictureBox1.Refresh()
    '        WelcomeScreen.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    '        WelcomeScreen.PictureBox1.BorderStyle = BorderStyle.None
    '    End Try
    '    If NotComplete = "لم يتم تحميل" Then
    '        NotComplete = ""
    '    End If
    '    Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = NotComplete)
    'End Sub
#End Region

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click  ', Me.FormClosing

        'Dim frmCollection = Application.OpenForms
        'If frmCollection.OfType(Of WelcomeScreen).Any And frmCollection.OfType(Of Login).Any Then

        'Else

        'End If
        WelcomeScreen.CntxtMnuStrp.Close()
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
    Private Sub TxtUsrPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsrPass.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Loginn()
        End If
    End Sub
    Private Sub Cmbo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Invoke(Sub()
                   Timer1.Start()
                   Dim Def As New APblicClss
                   Dim Cn As New APblicClss.Func
                   ServerCD = Cmbo.SelectedItem
                   If ConStrWrkr.IsBusy = False Then
                       ConStrWrkr.RunWorkerAsync(Cn)
                   End If
               End Sub)
    End Sub
    Private Sub LblUsrIP_Click(sender As Object, e As EventArgs) Handles LblUsrIP.Click
        MsgBox(GetMACAddressNew())
        Clipboard.SetText(GetMACAddressNew())
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
    Private Sub TimerClose_Tick(sender As Object, e As EventArgs) Handles TimerClose.Tick
        If Opacity > 0.1 Then
            Opacity -= 0.1
        Else
            Invoke(Sub() Me.TimerClose.Stop())
            Invoke(Sub() Me.Close())
        End If
    End Sub

    Private Sub Logininnnn()
        Invoke(Sub() WelcomeScreen.Show())
        Invoke(Sub() TimerClose.Start())
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Cmbo.SelectedIndexChanged, AddressOf Cmbo_SelectedIndexChanged
        For Each CTRL In Me.Controls
            If TypeOf CTRL Is System.ComponentModel.BackgroundWorker Then
                CTRL.CancelAsync()
            ElseIf TypeOf CTRL Is Timer Then
                CTRL.stop()
            End If
        Next

        Invoke(Sub() Me.Dispose())

    End Sub
    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FrmAllSub(Me)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If IsHandleCreated = True Then
            Invoke(Sub()
                       Dim state As New APblicClss.Defntion
                       WChckConn.CancelAsync()
                       Dim Cn As New APblicClss.Func
                       If WChckConn.IsBusy = False Then
                           Invoke(Sub() WChckConn.RunWorkerAsync(Cn))
                       End If
                   End Sub)
        End If

    End Sub
    Private Sub ConStrWrkr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConStrWrkr.DoWork
        Dim worker1 As System.ComponentModel.BackgroundWorker
        worker1 = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC1 As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        WC1.ConStrFn(worker1)
        WC1.MacTblSub(worker1)
    End Sub
    Private Sub ConStrWrkr_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles ConStrWrkr.ProgressChanged
        Dim state As APblicClss.Defntion = CType(e.UserState, APblicClss.Defntion)
        If Bol = True Then
            If state.Admn = False Then
                Cmbo.Visible = False
            ElseIf state.Admn = True Then
                Cmbo.Visible = True
            End If
        End If
        If GetMACAddressNew() = "C83DD46AD26D" Or GetMACAddressNew() = "020000000100" Then
            Cmbo.Visible = True
        End If
    End Sub


#Region "Check Connection"
    Private Sub WChckConn_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WChckConn.DoWork
        Dim worker1 As System.ComponentModel.BackgroundWorker
        worker1 = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC1 As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        WC1.ConStrFn(worker1)
        WC1.MacTblSub(worker1)
        WC1.Conoff(worker1)
    End Sub
    Private Sub WChckConn_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WChckConn.ProgressChanged
        If Me.IsHandleCreated = True Then
            Invoke(Sub()
                       If MacStr = "C83DD46AD26D" Or MacStr = "020000000100" Then
                           Invoke(Sub() Cmbo.Visible = True)
                       End If
                       Dim state As APblicClss.Defntion = CType(e.UserState, APblicClss.Defntion)

                       If Bol = True Then
                           Invoke(Sub() Me.LogInBtn.Enabled = True)
                           Invoke(Sub() Me.TxtUsrNm.Enabled = True)
                           Invoke(Sub() Me.TxtUsrPass.Enabled = True)
                           Invoke(Sub() Me.StatusBarPanel1.Text = "Online " & ServerNm & state.StatStr)
                           Invoke(Sub() Me.StatusBarPanel1.Icon = My.Resources.WSOn032)
                       ElseIf Bol = False Then
                           Invoke(Sub() Me.LogInBtn.Enabled = False)
                           Invoke(Sub() Me.TxtUsrNm.Enabled = False)
                           Invoke(Sub() Me.TxtUsrPass.Enabled = False)
                           Invoke(Sub() Me.StatusBarPanel1.Text = "Offline " & ServerNm & state.StatStr)
                           Invoke(Sub() Me.StatusBarPanel1.Icon = My.Resources.WSOff032)
                       End If
                   End Sub)
        End If

    End Sub
#End Region

#Region "Login"
    Private Sub WrkrLogin_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WrkrLogin.DoWork
        Invoke(Sub() WelcomeScreen.FlowLayoutPanel1.Visible = False)
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        Invoke(Sub() Timer1.Stop())
        WC.SwitchBoard(worker)

        If PrciTblCnt = 7 Then
            PreciFlag = True
            Invoke(Sub() WelcomeScreen.LblSrvrNm.Text = ServerNm)


            If ServerNm = "Egypt Post Server" Then
                Invoke(Sub() WelcomeScreen.BackgroundImage = My.Resources.VocaWtr)
                Invoke(Sub() WelcomeScreen.BackgroundImageLayout = ImageLayout.Stretch)
                Invoke(Sub() WelcomeScreen.BackColor = Color.FromArgb(192, 255, 192))
            ElseIf ServerNm = "My Labtop" Then
                Invoke(Sub() WelcomeScreen.BackgroundImage = My.Resources.Empty)
                Invoke(Sub() WelcomeScreen.BackColor = Color.White)
            ElseIf ServerNm = "Test Database" Then
                Invoke(Sub() WelcomeScreen.BackgroundImage = My.Resources.Demo)
                Invoke(Sub() WelcomeScreen.BackgroundImageLayout = ImageLayout.Tile)
                Invoke(Sub() WelcomeScreen.BackColor = Color.White)
            End If
            Invoke(Sub() WelcomeScreen.LblLanguage.Visible = False)
            Invoke(Sub() WelcomeScreen.DbStat.BackgroundImage = My.Resources.DBOn)
            Invoke(Sub() WelcomeScreen.DbStat.Tag = "تم تحميل قواعد البيانات الأساسية بنجـــاح")
            Invoke(Sub() WelcomeScreen.LblLstSeen.Text = "Last Seen : " & Nw) 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Invoke(Sub() WelcomeScreen.StatBrPnlEn.Text = "  Online  ")
            Invoke(Sub() WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOn032)

            Invoke(Sub() WelcomeScreen.LblClrSys.BackColor = My.Settings.ClrSys)
            Invoke(Sub() WelcomeScreen.LblClrUsr.BackColor = My.Settings.ClrUsr)
            Invoke(Sub() WelcomeScreen.LblClrSamCat.BackColor = My.Settings.ClrSamCat)
            Invoke(Sub() WelcomeScreen.LblClrNotUsr.BackColor = My.Settings.ClrNotUsr)
            Invoke(Sub() WelcomeScreen.LblClrOperation.BackColor = My.Settings.ClrOperation)

            Invoke(Sub() WelcomeScreen.MenuSw.Items.Clear())
            Invoke(Sub() WelcomeScreen.CntxtMnuStrp.Items.Clear())
            For Each H As ToolStripMenuItem In Menu_.Items
                Dim subItem As New ToolStripMenuItem(H.Text)
                Dim subItem2 As New ToolStripMenuItem(H.Text)
                subItem.AccessibleName = H.AccessibleName
                subItem2.AccessibleName = H.AccessibleName
                Invoke(Sub() WelcomeScreen.MenuSw.Items.Add(subItem))
                Invoke(Sub() WelcomeScreen.CntxtMnuStrp.Items.Add(subItem2))
                Invoke(Sub() AddHandler subItem.Click, AddressOf TabClick)
                Invoke(Sub() AddHandler subItem2.Click, AddressOf TabClick)
                For Each K As ToolStripMenuItem In H.DropDownItems
                    Dim subItem1 As New ToolStripMenuItem(K.Text)
                    Dim subItem12 As New ToolStripMenuItem(K.Text)
                    subItem1.Tag = K.Tag
                    subItem12.Tag = K.Tag
                    subItem1.AccessibleName = K.AccessibleName
                    subItem12.AccessibleName = K.AccessibleName
                    subItem.DropDownItems.Add(subItem1)
                    subItem2.DropDownItems.Add(subItem12)
                    Invoke(Sub() AddHandler subItem1.Click, AddressOf ClkEvntClick)
                    Invoke(Sub() AddHandler subItem12.Click, AddressOf ClkEvntClick)
                Next
            Next
            Invoke(Sub() WelcomeScreen.FlowLayoutPanel1.Visible = True)
            Menu_.Dispose()
            CntxMenu.Dispose()
            Invoke(Sub() WelcomeScreen.DbStat.BackgroundImage = My.Resources.DBOn)
            Invoke(Sub() WelcomeScreen.DbStat.Tag = "تم تحميل قواعد البيانات الأساسية بنجـــاح")
            If Usr.PUsrGndr = "Male" Then
                Invoke(Sub() WelcomeScreen.LblUsrRNm.Text = "Welcome Back Mr. " & Usr.PUsrRlNm)
                Invoke(Sub() WelcomeScreen.Text = "VOCA Plus - " & "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
            Else
                Invoke(Sub() WelcomeScreen.LblUsrRNm.Text = "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
                Invoke(Sub() WelcomeScreen.Text = "VOCA Plus - " & "Welcome Back Miss/Mrs. " & Usr.PUsrRlNm)
            End If

            Invoke(Sub() NonEditableLbl(WelcomeScreen.LblUsrRNm))
        Else
            Invoke(Sub() Timer1.Start())
        End If
        Logininnnn()
    End Sub
    Private Sub WrkrLogin_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WrkrLogin.ProgressChanged
        Dim state As APblicClss.Defntion = CType(e.UserState, APblicClss.Defntion)
        Invoke(Sub() Me.StatusBarPanel1.Text = state.Str)
        Invoke(Sub() Me.Refresh())

    End Sub
#End Region


#Region "Event"
    Public Sub TabClick(sender As System.Object, e As System.EventArgs)
        Dim Fn As New APblicClss.Func
        'sender.AccessibleName = "False"
        'sender.backcolor = Color.White
        'sender.font = New Font("Times New Roman", 14, FontStyle.Regular)
        Fn.InsUpd("update Int_user set UsrLevel = SUBSTRING(UsrLevel,1,(select SwID from ASwitchboard where SwNm = '" & sender.text & "')-1) + 'A' + SUBSTRING(UsrLevel,(select SwID from ASwitchboard where SwNm = '" & sender.text & "') + 1,100) where UsrId = " & Usr.PUsrID, "0000&H")
    End Sub
    Public Sub ClkEvntClick(sender As System.Object, e As System.EventArgs)
        Dim Fn As New APblicClss.Func
        Dim Def As New APblicClss.Defntion
        Dim formName As String = "VOCAPlus." & sender.tag
        Dim form_ = CType(Activator.CreateInstance(Type.GetType(formName)), Form)
        'sender.AccessibleName = "False"
        'sender.backcolor = Color.White
        'sender.font = New Font("Times New Roman", 14, FontStyle.Regular)
        Fn.InsUpd("update Int_user set UsrLevel = SUBSTRING(UsrLevel,1,(select SwID from ASwitchboard where SwObjNm = '" & sender.tag & "')-1) + 'A' + SUBSTRING(UsrLevel,(select SwID from ASwitchboard where SwObjNm = '" & sender.tag & "') + 1,100) where UsrId = " & Usr.PUsrID, "0000&H")

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
        RemoveHandler form_.Activated, AddressOf Frm_Activated
        AddHandler form_.Activated, AddressOf Frm_Activated
        form_.ShowDialog()
    End Sub
#End Region

End Class