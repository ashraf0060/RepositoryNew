Imports Microsoft.Exchange.WebServices.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net
Public Class vocasupport
    Inherits System.Web.UI.Page
    Dim Errmsg As String
    Dim UserTable As DataTable = New DataTable
    Dim IP_ As String
    Dim Loctin As String = ""
    Dim TkTyp As String = ""
    Dim IssuTyp As String = ""
    'Dim UserTable As DataTable = New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IP_ = Request.UserHostAddress
        If Left(IP_, 9) = "10.10.200" Then
            Loctin = "Maadi Technology Village"
        ElseIf Left(IP_, 8) = "10.11.51" _
            Or Left(IP_, 8) = "10.11.56" _
            Or Left(IP_, 8) = "10.11.58" Then
            Loctin = "Sabeel Building"
        ElseIf Left(IP_, 9) = "10.10.220" Then
            Loctin = "Home"
        Else
            Loctin = "Unknown"
        End If
        TxtMail.Focus()
        'registerTrigger(BtnUpload)
        'registerTrigger(BtnSubmit)
    End Sub
    Protected Sub LogInBtn_Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        LogInBtn.Enabled = False
        Dim SQLSTR As String
        Dim Msgs As String
        UserTable.Rows.Clear()
        UserTable.Columns.Clear()
        Lbl.Text = "          Authenticating"
        Lbl.ForeColor = Color.Blue

        Try
            UserTable.Rows.Clear()

            If GETTTbl("SELECT        dbo.Int_user.UsrId, dbo.Int_user.UsrCat, dbo.Int_user.UsrNm, dbo.Int_user.UsrPass, dbo.Int_user.UsrLevel, dbo.Int_user.UsrRealNmEn, dbo.Int_user.UsrGender, dbo.Int_user.UsrActive, 
                         dbo.Int_user.UsrLastSeen, dbo.Int_user.UsrSusp, dbo.Int_user.UsrTkCount, RIGHT(dbo.IntGuid.PRGUID, CAST(LEFT(dbo.IntGuid.Id, 2) AS int) / 2) + SUBSTRING(dbo.IntGuid.GUID, 3, 5) 
                         + LEFT(dbo.IntGuid.PRGUID, CAST(RIGHT(dbo.IntGuid.Id, 2) AS int) / 2) AS SaltKey, dbo.IntUserCat.UCatNmEn, dbo.Int_user.UsrSisco, dbo.Int_user.UsrGsm, dbo.Int_user.UsrCalCntr, dbo.Int_user.UsrClsN, 
                         dbo.Int_user.UsrFlN, dbo.Int_user.UsrReOpY, dbo.Int_user.UsrUnRead, dbo.Int_user.UsrEvDy, dbo.Int_user.UsrClsYDy, dbo.Int_user.UsrReadYDy, dbo.IntUserCat.UCatLvl, dbo.Int_user.UsrRecevDy, 
                         dbo.Int_user.UsrClsUpdtd, dbo.Int_user.UsrTikFlowDy, dbo.IntUserCatLvCD.CatLvNm AS Cat2
FROM            dbo.Int_user INNER JOIN
                         dbo.IntGuid ON dbo.Int_user.UsrKey = SUBSTRING(dbo.IntGuid.GUID, 26, 11) INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId
WHERE        (UsrNm = N'" & TxtMail.Text & "');", UserTable) = Nothing Then

                Msgs = "          Login has been succeeded"
                Lbl.ForeColor = Color.Green
            Else
                Lbl.Text = "          Err"
                LogInBtn.Enabled = True
                Beep()
                Exit Sub
            End If
            If UserTable.Rows.Count = 1 Then
                LblUrId.Text = UserTable.Rows(0).Item(0).ToString                     'store user ID
                'PUsrCat = CInt(UserTable.Rows(0).Item(1))                    'Current User Catagory
                LblUsNm.Text = UserTable.Rows(0).Item(2).ToString                     'Current User Name
                'Usr.PUsrPWrd = UserTable.Rows(0).Item(3).ToString                   'Current User Password
                'Usr.PUsrLvl = UserTable.Rows(0).Item(4).ToString                    'Current User Class
                'Usr.PUsrRlNm = UserTable.Rows(0).Item(5).ToString                   'Current user Real Name
                'Usr.PUsrGndr = UserTable.Rows(0).Item(6).ToString                   'Current user Gender
                'Usr.PUsrActv = CBool(UserTable.Rows(0).Item(7))                   'Current User Active Or not
                'Usr.PUsrLstS = UserTable.Rows(0).Item(8).ToString                   'Current User LastSeen
                'Usr.PUsrSusp = UserTable.Rows(0).Item(9).ToString                   'Current User Suspended Or not
                'Usr.PUsrSltKy = UserTable.Rows(0).Item(11).ToString                 'SaltKey
                'Usr.PUsrCatNm = UserTable.Rows(0).Item(12).ToString                 'Catagory name
                'Usr.PUsrCatNm2 = UserTable.Rows(0).Item("Cat2").ToString             'Catagory name
            Else    'if user Name is Error
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrIP, UaccStat) values ('" & TxtMail.Text & "','" & Request.UserHostAddress & "','" & "FW" & "');" 'Append access Record
                Msgs = "          Invalid User Name Or Password"
                Lbl.ForeColor = Color.Red
                Beep()
                GoTo sec_UsrErr_
            End If
            If CBool(UserTable.Rows(0).Item(9).ToString) = True Then  'if user is suspended
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtMail.Text & "','" & CInt(UserTable.Rows(0).Item(0)) & "','" & Request.UserHostAddress & "','" & "SW" & "');" 'Append access Record with Su Stat
                Msgs = "          User has been suspended" & " - " & "Please Call System Administrator"
                Lbl.ForeColor = Color.Red
                Beep()
                GoTo sec_UsrErr_
            End If
            If TxtMail.Text = UserTable.Rows(0).Item(2).ToString And TxtPass.Text = PassDecoding(UserTable.Rows(0).Item(3).ToString, UserTable.Rows(0).Item(11).ToString) Then 'check user name and password status
                Msgs = "          Login has been succeeded"
                Lbl.ForeColor = Color.Green
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtMail.Text & "','" & CInt(UserTable.Rows(0).Item(0)) & "','" & Request.UserHostAddress & "','" & "OW" & "');" 'Append access Record as active user
                Lbl.ForeColor = Color.Green
                LblUsrRNm.Text = UserTable.Rows(0).Item(5).ToString
                LblUsrLeader.Text = UserTable.Rows(0).Item("Cat2").ToString
                LblUsrCat.Text = UserTable.Rows(0).Item(12).ToString
                LblLction.Text = Loctin
                UsrData.Visible = True
                Crdentials0.Visible = False
                Row1.Visible = True
                Dim Sw As New DataTable
                Dim Whr As String = ""
                For cc = 0 To UserTable.Rows(0).Item(4).ToString.Length - 1
                    If Mid(UserTable.Rows(0).Item(4).ToString, cc + 1, 1) = "A" Then
                        Whr += "SwID = " & cc + 1 & " Or "
                    End If
                Next
                Sw.Rows.Clear()


                sqlComm.Connection = sqlCon
                SQLTblAdptr.SelectCommand = sqlComm
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "select ASwitchboard.SwID, ASwitchboard.SwNm from ASwitchboard where (ASwitchboard.SwType = 'TabMn') AND (" & Mid(Whr, 1, Whr.Length - 4) & ") order by SwNm"
                Try
                    If sqlCon.State = ConnectionState.Closed Then
                        sqlCon.ConnectionString = strConn
                        sqlCon.Open()
                    End If
                    SQLTblAdptr.Fill(Sw)
                    If Sw.Rows.Count > 0 Then
                        DropDownList1.Items.Add("Please Select")
                        DropDownList1.Items.Add("All Application")
                        For UU = 0 To Sw.Rows.Count - 1
                            DropDownList1.Items.Add(Sw.Rows(UU).Item(1).ToString)
                        Next
                        DropDownList1.SelectedIndex = -1
                        GoTo sec_UsrErr_
                    Else
                        Lbl.ForeColor = Color.Red
                        Lbl.Text = "You didn't have any access to Application"
                        Beep()
                    End If



                    sqlCon.Close()
                    SqlConnection.ClearPool(sqlCon)
                Catch ex As Exception
                    Errmsg = "X"
                End Try


            Else                                                       'elseif user Name Is OK, But Password is Error
                SQLSTR = "insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat) values ('" & TxtMail.Text & "','" & CInt(UserTable.Rows(0).Item(0)) & "','" & Request.UserHostAddress & "','" & "FW" & "');" 'Append access Record
                Msgs = "          Invalid User Name Or Password"
                Lbl.ForeColor = Color.Red
                Lbl.Text = "          Err _ "
                Beep()
            End If

sec_UsrErr_:
            LogInBtn.Enabled = True
            If InsUpd(SQLSTR) <> Nothing Then
            End If
            'MessageBox.Show(Msgs, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Lbl.Text = Msgs
        Catch ex As Exception
            Lbl.Text = "          Err _ " & ex.Message
            Beep()
        End Try
    End Sub
    Protected Sub RdRequest_CheckedChanged(sender As Object, e As EventArgs) Handles RdRequest.CheckedChanged
        Lbl.Text = ""
        RdRequest.ForeColor = Color.Green
        RdIssue.ForeColor = Color.Black
        RdIssue.Checked = False
    End Sub
    Protected Sub RdIssue_CheckedChanged(sender As Object, e As EventArgs) Handles RdIssue.CheckedChanged
        Lbl.Text = ""
        RdRequest.ForeColor = Color.Black
        RdIssue.ForeColor = Color.Green
        RdRequest.Checked = False
    End Sub
    Protected Sub Nxt1_Click(sender As Object, e As EventArgs) Handles BtnNxt1.Click
        If RdIssue.Checked Then
            If RdIssue.Checked Then
                Row1.Visible = False
                Row2.Visible = True
                Lbl.Text = ""
            End If
        ElseIf RdRequest.Checked Then
            Lbl.Text = "Cooming Soon ...."
            Lbl.ForeColor = Color.Green
            Beep()
        Else
            Lbl.Text = "Please Select Ticket Type"
            Lbl.ForeColor = Color.Red
            Beep()
        End If

    End Sub
    Protected Sub Bck1_Click(sender As Object, e As EventArgs) Handles BtnBck1.Click
        If RdIssue.Checked Then
            Row1.Visible = True
            Row2.Visible = False
        End If
    End Sub
    'Protected Sub RdAttYes_CheckedChanged(sender As Object, e As EventArgs) Handles RdAttYes.CheckedChanged
    '    FileUpload1.Enabled = True
    '    BtnUpload.Enabled = True
    '    RdAttNo.Checked = False
    '    RdAttYes.ForeColor = Color.Green
    '    RdAttNo.ForeColor = Color.Black
    'End Sub
    'Protected Sub RdAttNo_CheckedChanged(sender As Object, e As EventArgs) Handles RdAttNo.CheckedChanged
    '    FileUpload1.Enabled = True
    '    BtnUpload.Enabled = True
    '    RdAttYes.Checked = False
    '    RdAttYes.ForeColor = Color.Black
    '    RdAttNo.ForeColor = Color.Green
    'End Sub
    Protected Sub RdSlow_CheckedChanged(sender As Object, e As EventArgs) Handles RdSlow.CheckedChanged
        RdErr.Checked = False
        RdSlow.ForeColor = Color.Green
        RdErr.ForeColor = Color.Black
    End Sub
    Protected Sub RdErr_CheckedChanged(sender As Object, e As EventArgs) Handles RdErr.CheckedChanged
        RdSlow.Checked = False
        RdSlow.ForeColor = Color.Black
        RdErr.ForeColor = Color.Green
    End Sub
    Protected Sub BtnNxt2_Click(sender As Object, e As EventArgs) Handles BtnNxt2.Click
        If (RdSlow.Checked = True Or RdErr.Checked = True) And (DropDownList1.Text <> "Please Select") Then 'And (RdAttYes.Checked = True Or RdAttNo.Checked) = True
            Finsh.Visible = True
            Finsh1.Visible = True
            Row2.Visible = False
            Lbl.Text = ""
            If RdIssue.Checked Then TkTyp = "Issue" Else TkTyp = "Request"
            If RdSlow.Checked Then IssuTyp = "Slow Performance" Else IssuTyp = "Error Message"

            L2.Text = LblUsrRNm.Text
            L4.Text = TkTyp
            L6.Text = IssuTyp
            L8.Text = DropDownList1.SelectedItem.ToString
            L10.Text = IP_
            L12.Text = Loctin
        Else
            Lbl.Text = "Please Complete All Choices"
            Lbl.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Protected Sub BtnBck2_Click(sender As Object, e As EventArgs) Handles BtnBck2.Click
        If RdIssue.Checked Then
            Finsh.Visible = False
            Finsh1.Visible = False
            Row2.Visible = True
        End If
    End Sub
    Protected Sub BtnFnsh_Click(sender As Object, e As EventArgs) Handles BtnFnsh.Click
        Finsh1.Visible = False
        Submt.Visible = True
    End Sub
    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim maxtbl As New DataTable
        'Finsh.Visible = False

        BtnSubmit.Visible = False
        Rsult.Visible = True
        Try
            Dim TkType_ As Integer
            If RdIssue.Checked Then
                TkType_ = 0
            Else
                TkType_ = 1
            End If

            Dim IssuType_ As Integer
            If RdSlow.Checked Then
                IssuType_ = 0
            Else
                IssuType_ = 1
            End If

            'LoadFrm("جاري تحميل البيانات ...", 500, 350)
            Errmsg = Nothing
            sqlComm.Connection = sqlCon
            sqlComm.CommandType = CommandType.Text
            sqlComm.CommandText = "insert into AVOCAIssu (VoIssAgentId ,VoIss_IP , VoIssTkTyp,VoIssType,VoIssName,VoIssAttach, VoIssDetls ) values 
             (" & CInt(LblUrId.Text) & ",'" & Request.UserHostAddress & "'," & TkType_ & "," & IssuType_ & ",'" & DropDownList1.SelectedItem.ToString & "','" & "" & "','" & TxtDetails.Text & "')"
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.ConnectionString = strConn
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            Lbl.Text += sqlComm.CommandText
            sqlComm.CommandText = "select max(VoIssID) as Max_ from AVOCAIssu where VoIssAgentId =" & CInt(LblUrId.Text) & " and FORMAT( VoIssTime,'yyyy/MM/dd') = FORMAT( GETDATE(),'yyyy/MM/dd') "
            SQLTblAdptr.SelectCommand = sqlComm
            SQLTblAdptr.Fill(maxtbl)

            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
            Lbl.Text += sqlComm.CommandText
        Catch ex As Exception
            Lbl.Text += sqlComm.CommandText
            Errmsg = "X"
        End Try

        'Try
        '    'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        '    sqlComm.Connection = sqlCon
        '    SQLTblAdptr.SelectCommand = sqlComm
        '    sqlComm.CommandType = CommandType.Text
        '    sqlComm.CommandText = "select max(VoIssID) as Max_ from AVOCAIssu where VoIssAgentId = 1 and FORMAT( VoIssTime,'yyyy/MM/dd') = FORMAT( GETDATE(),'yyyy/MM/dd') "

        '    If sqlCon.State = ConnectionState.Closed Then
        '        sqlCon.ConnectionString = strConn
        '        sqlCon.Open()
        '    End If
        '    SQLTblAdptr.Fill(maxtbl)
        '    sqlCon.Close()
        '    SqlConnection.ClearPool(sqlCon)
        'Catch ex As Exception
        '    Lbl.Text = ex.Message & "_" & sqlComm.CommandText
        '    Lbl.ForeColor = Color.Red
        'End Try

        Try

            Lbl.Text += "Trying To Send Mail ..."
            Lbl.ForeColor = Color.Green

            Dim exchange As ExchangeService
            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\voca-support", "asd_ASD123")
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Dim message As New EmailMessage(exchange)
            message.ToRecipients.Add(LblUsNm.Text & "@egyptpost.org")
            message.ToRecipients.Add("voca-support@egyptpost.org")
            message.CcRecipients.Add("RTM_TEAM@EgyptPost.Org")
            If RdIssue.Checked Then TkTyp = "Issue" Else TkTyp = "Request"
            If RdSlow.Checked Then IssuTyp = "Slow Performance" Else IssuTyp = "Error Message"

            message.Subject = TkTyp & " Ticket From : " & LblUsrRNm.Text & " IP Address : " & Request.UserHostAddress


            Dim detls As String = TxtDetails.Text.Replace(vbNewLine, "<BR>")

            'For YY = 0 To Split(TxtDetails.Text, vbCrLf).Count - 1
            '    detls += Split(TxtDetails.Text, vbCrLf)(YY) & vbCrLf
            'Next





            Dim Bdy As String = L1.Text & L2.Text & ",<BR>" & L3.Text & L4.Text & L5.Text & L6.Text & L7.Text & L8.Text & L9.Text & L10.Text & L11.Text & L12.Text & L13.Text & "<BR>" & "<BR>" & "<Span style=" & Chr(34) & "color: rgb(65, 168, 95); font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong><br><br>" & "Details : </strong></span><pre>" & TxtDetails.Text & "</pre>"
            'Dim Pos0 As Integer = InStr(4, LblFinsh.Text, "Selected", CompareMethod.Text)
            'Dim Pos1 As Integer = InStr(4, LblFinsh.Text, "That", CompareMethod.Text)
            'Bdy = Mid(LblFinsh.Text, Pos0, LblFinsh.Text.Length)


            message.Body = Bdy & "<BR>" & "<BR>" & "<BR>" & "<Span style=" & Chr(34) & "color:Black; font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong>" & "We received Your " & TkTyp.ToString & "  and it will be checked  " & " Within the working hours from 8:00 AM - 05:00 PM" & "<BR>" &
               "<Span style=" & Chr(34) & "color: rgb(65, 168, 95); font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong><br><br>" & "Your Ref. : " & maxtbl.Rows(0).Item(0).ToString & "</strong></span>" &
              "<BR>" & "<BR>" & "<Span style=" & Chr(34) & "color: Blue; font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & ">" & "VOCA issues will be considered as global, in case are be more than 7.5% from the concurrent users count" & "</span>"
            message.Importance = CType(1, Importance)
            message.Body.BodyType = BodyType.HTML
            message.SendAndSaveCopy()


            LblRslt.Text = "<Span style=" & Chr(34) & "color:Black; font-family:Times New Roman; font-size: 24px;text-align: center" & Chr(34) & "><strong>" & "We received Your " & TkTyp.ToString & "  and it will be checked  " & " Within the working hours from 8:00 AM - 05:00 PM" & "<strong>" & "<BR>" &
               "<Span style=" & Chr(34) & "color: rgb(65, 168, 95); font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong>" & "Your Ref. : " & maxtbl.Rows(0).Item(0).ToString & "</strong></span>"
            Lbl.Text = "<Span style=" & Chr(34) & "color: Blue; font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & ">" & "VOCA issues will be considered as global, in case are be more than 7.5% from the concurrent users count" & "</span>"
            'Lbl.Text += TkTyp & "_" & IssuTyp & "_" & LblUrId.Text
            Lbl.ForeColor = Color.Blue
        Catch ex As Exception
            'Lbl.Text = ex.Message
            Lbl.Text += sqlComm.CommandText & ex.Message
            Lbl.ForeColor = Color.Red
        End Try


        'If SndExchngMil("voca-support@egyptpost.org", "a.farag@egyptpost.org", "", TkTyp & " Ticket From : " & Usr.PUsrRlNm & " IP Address : " & Request.UserHostAddress, Mid(LblFinsh.Text, testPos, LblFinsh.Text.Length)) = Nothing Then
        '    LblRslt.Text = "Done"
        '    Lbl.Text = "Mail has been sent"
        '    Lbl.ForeColor = Color.Green



        '    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
        '       & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Server.MapPath("AttachIssu\\"), True)
        '    If (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
        '      & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg")) Then
        '        File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
        '       & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Server.MapPath("AttachIssu\\"), True)

        '    End If
        'End If




    End Sub
    'Protected Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
    '    Try
    '        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AttachIssu/") + FileUpload1.FileName)
    '        Lbl.Text = "File has been Uploaded"
    '        Lbl.ForeColor = Color.Green
    '        RdAttNo.Enabled = False
    '        RdAttYes.Enabled = False
    '        FileUpload1.Enabled = False
    '        BtnUpload.Enabled = False
    '    Catch ex As Exception
    '        Lbl.Text = ex.Message
    '    End Try
    'End Sub
    Public Sub registerTrigger(CT As Control)
        ScriptManager1.RegisterPostBackControl(CT)
    End Sub
End Class