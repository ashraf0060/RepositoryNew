Imports Microsoft.Exchange.WebServices.Data
Public Class MRSEx

    Private exchange As ExchangeService
    Dim message As EmailMessage
    Dim PrsFrom, PrsTo, PrsCC, PrsSbjct As String '
    Dim PrsDt As Date
    Dim CCDrop As Boolean = False
    Dim MailCount As Integer = 0
    Dim TMailCount As Integer = 0
    Dim Ertv As Integer = 0
    Dim Edrp As Integer = 0
    Dim EHshk As Integer = 0
    Dim ERej As Integer = 0
    Dim JbRef As Integer = 0
    Dim MailRequest As New DataTable
    Dim EmailSubj As String = ""
    Dim EmailBody As String = ""
    Dim ChkDay As Date = Today
    Private Sub MRSEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbInterval.Items.Add("1")
        CmbInterval.Items.Add("5")
        CmbInterval.Items.Add("10")
        CmbInterval.Items.Add("15")
        CmbInterval.Items.Add("30")
        CmbInterval.SelectedItem = "10"
    End Sub
    Private Sub CmbInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInterval.SelectedIndexChanged
        Timer1.Interval = CmbInterval.Text * 60000
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = CmbInterval.Text * 60000
        ConnectToExchangeServer()
        Dim aaa As String

        'Dim ts As New TimeSpan(0, -1, 0, 0)
        'Dim [date] As DateTime = DateTime.Now.Add(ts)
        'Dim filter As New SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.DateTimeReceived, [date])
        If Today > ChkDay Then

            Try
                sqlComm.Connection = sqlCon
                sqlCon.Open()

            sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "INSERT INTO MrsSrvLog (SLDt, SLRtv, SLDrp, SLHSh, SLRej, SLRws, SLCol, SLCel) VALUES('" & ChkDay & "', '" & Ertv & "', '" &
                    Edrp & "', '" & EHshk & "', '" & ERej & "', '" & TxtRows.Text & "', '" & TxtCol.Text & "', '" & TxtCell.Text & "');"
                sqlComm.ExecuteNonQuery()
                sqlCon.Close()
                ChkDay = Today
                Ertv = 0
                Edrp = 0
                EHshk = 0
                ERej = 0
                JbRef = 0
                TxtRows.Text = 0
                TxtCol.Text = 0
                TxtCell.Text = 0
                TxtErtv.Text = 0
                TxtEDrp.Text = 0
                TxtEHandSh.Text = 0
                TxtERej.Text = 0
            Catch ex As Exception

            End Try

            ' counter zero and save
        End If
        JbRef += 1
        If TxtSrvRsp.TextLength > 32000 Then
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\MrsLog\TxtSrvRsp" & Format(Now, "yyyyMMdd") & ".txt", TxtSrvRsp.Text, False)
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\MrsLog\TxtSrvErr" & Format(Now, "yyyyMMdd") & ".txt", TxtErr.Text, False)
            TxtSrvRsp.Text = ""
            TxtErr.Text = ""
        End If

        '(Rws) * (Col) & " Of " & ExpDTable.Rows.Count * ExpDTable.Columns.Count

        If exchange IsNot Nothing Then
            Try
                Dim findResults As FindItemsResults(Of Item)     = exchange.FindItems(WellKnownFolderName.Inbox, New ItemView(50))

                MsgTxtResp("MSR. Job {Ref. " & JbRef & "} Start at " & Now)

                LblFtr.Text = "MRS. Extrating Email From Exchange server Start" & vbCrLf
                MsgTxtResp("number of emails:  " & findResults.Count)
                MailCount = 0
                TMailCount += findResults.Count
                For Each item As Item In findResults
                    PrsFrom = ""
                    PrsTo = ""
                    PrsCC = ""
                    PrsSbjct = ""
                    CCDrop = False
                    MailCount += 1
                    MsgTxtResp("Proccess email: " & MailCount & " Of " & findResults.Count)
                    message = EmailMessage.Bind(exchange, item.Id)
                    PrsFrom = message.From.Address
                    PrsSbjct = message.Subject
                    If PrsSbjct = Nothing Then
                        PrsSbjct = "X"
                    End If
                    PrsSbjct = Strings.Right(PrsSbjct, PrsSbjct.Length - Strings.InStr(PrsSbjct, "MRSCOMP", CompareMethod.Text) + 1)


                    PrsDt = message.DateTimeReceived
                    PrsTo = message.ToRecipients.Item(0).Address

                    For Cnt_ = 0 To message.CcRecipients.Count - 1

                        If InStr(Split(message.CcRecipients.Item(Cnt_).Address, "@")(1), "egyptpost.org", CompareMethod.Text) = 1 Or InStr(Split(message.CcRecipients.Item(Cnt_).Address, "@")(1), "jubar.me", CompareMethod.Text) = 1 Then
                            PrsCC += message.CcRecipients.Item(Cnt_).Address + "; "
                        Else
                            CCDrop = True
                        End If

                    Next
                    If PrsCC.Length > 0 Then
                        PrsCC = Mid(PrsCC, 1, PrsCC.Length - 2)
                    End If

                    If InStr(Split(PrsFrom, "@")(1), "egyptpost.org", CompareMethod.Text) = 1 Or InStr(Split(PrsFrom, "@")(1), "jubar.me", CompareMethod.Text) = 1 Then

                        Try
                            sqlCon.Open()
                            sqlComm.Connection = sqlCon
                            sqlComm.CommandText = "INSERT INTO MRSInbox (MrsFrom, MrsTo, MrsCC, MrsCCDrop, MrsSubject, MrsSndDt) VALUES('" & PrsFrom & "', '" & PrsTo & "', '" & PrsCC & "', '" & CCDrop & "', '" & PrsSbjct & "', '" & Format(PrsDt, "yyyy/MM/dd HH:mm:ss") & "');"
                            sqlComm.CommandType = CommandType.Text
                            sqlComm.ExecuteNonQuery()
                            message.Delete(DeleteMode.MoveToDeletedItems)
                            MsgTxtResp("Complete Extracting & Saving Email No.: " & MailCount)
                            Ertv += 1
                            TxtErtv.Text = Ertv
                        Catch ex As Exception
                            TxtErr.Text += vbCrLf & "connect to SQL Job Ref." & JbRef & " - " & ex.Message + Now + vbCrLf
                            TxtErr.Refresh()
                            TxtErr.ScrollToCaret()
                        End Try
                    Else
                        message.Delete(DeleteMode.MoveToDeletedItems)
                        MsgTxtResp("Complete Extracting, out of Egyptpost.org  Email No.: " & MailCount & " Droped")
                        Edrp += 1
                        TxtEDrp.Text = Edrp
                    End If

                Next
                If findResults.Items.Count <= 0 Then

                    MsgTxtResp("No Messages found!!")

                End If

            Catch ex As Exception
                TxtErr.Text += vbCrLf & "connect to Ex. SRV Job Ref." & JbRef & " - " & ex.Message + vbCrLf
                TxtErr.Refresh()
                TxtErr.ScrollToCaret()
            End Try


        End If


        HndShck() '           *******   Hand schack     seconde step


        ' *******   Send request   third    step
        '  all procedure start with Sts have pareamets start with porcedure name and any paramaters without date.
        '  all procedure start with Dts have pareamets start with porcedure name and from date, to date, any parameters.


        sqlComm.CommandText = "SELECT MrsSql, MrsFrom, MrsCC, MrsSubject, User_RealName, User_Gender
                                    FROM dbo.Int_user INNER JOIN   dbo.MRSInbox ON dbo.Int_user.User_Email = MrsFrom
                                    WHERE (MrsHandSck = 1) AND (MsrNotRegister = 0) AND (MrsSucss = 0) AND (MrsSbjGood = 1) ORDER BY MrsSql"

        SQLTblAdptr.SelectCommand = sqlComm
        MailRequest.Rows.Clear()
        MailRequest.Columns.Clear()
        SQLTblAdptr.Fill(MailRequest)
        MsgTxtResp("Export Job Record Count : " & MailRequest.Rows.Count)

        For Cnt_ = 0 To MailRequest.Rows.Count - 1

            sqlCommProcd.CommandType = CommandType.StoredProcedure
            sqlCommProcd.CommandText = Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(0)
            EmailSubj = "Re: [MRS Ref. " + MailRequest.Rows(Cnt_).Item(0).ToString + "] " + EmailSubj
            EmailBody = "<font size=2>Dear " + Gndr(MailRequest.Rows(Cnt_).Item(5).ToString) + MailRequest.Rows(Cnt_).Item(4).ToString + ", </font>"

            If InStr(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(0), "MrsComp", CompareMethod.Text) = 1 Then


                Smrscomp()


                ' elseif  Split(Subject_, ",")(0) = "xxx"  with anthor procedure
            End If

            If DataExprRtrn.Distin <> "X" Then

                TxtCol.Text += DataExprRtrn.ColCnt
                TxtRows.Text += DataExprRtrn.RwsCnt
                TxtCell.Text += (DataExprRtrn.RwsCnt * DataExprRtrn.ColCnt)
                EmailBody += "<br><font size=2>Please Find Attached. <br> Attached File Information : </font>"
                EmailBody += "<br><br><font size=2>Records Count : " & DataExprRtrn.RwsCnt.ToString & "</font>"
                EmailBody += "<br><font size=2>Columns Count : " & DataExprRtrn.ColCnt.ToString & "</font>"
                EmailBody += My.Resources.MsgSign + vbCrLf
                EmailBody += My.Resources.MsgConfed
                MsgTxtResp("Exporting Function Done successfully")
            ElseIf DataExprRtrn.NoDatas = True Then
                EmailBody = Strings.Left(EmailBody, EmailBody.Length - 8)
                EmailBody += ",  But there is no data within your time's period, or recheck your parameters. </font>"
                EmailBody += My.Resources.MsgSign + vbCrLf
            Else

                EmailBody += "<br><br><font size=2>Thanks for using MRS, Export Function has been failed, Please confirm the subject text and try again Later. </font>"
                EmailBody += My.Resources.MsgSign
                MsgTxtResp("Exporting Function Failed")
            End If



            MsgTxtResp("Sending Export Mail To " & MailRequest.Rows(Cnt_).Item(1).ToString)

            If SEmail(MailRequest.Rows(Cnt_).Item(1).ToString, MailRequest.Rows(Cnt_).Item(2).ToString, , EmailSubj, EmailBody, DataExprRtrn.Distin, "H") = 1 Then
                Try
                    MsgTxtResp("Export Mail has been sent To " & MailRequest.Rows(Cnt_).Item(1).ToString)
                    sqlComminsert_2.CommandType = CommandType.Text
                    sqlComminsert_2.CommandText = "Update MRSInbox set MrsSucss=-1, MrsFshDt='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "' where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                    sqlComminsert_2.ExecuteNonQuery()
                Catch ex As Exception
                    TxtErr.Text += "Job Ref." & JbRef & " Export Mail has been sent To " & MailRequest.Rows(Cnt_).Item(1).ToString & vbCrLf
                    TxtErr.Text += "But can't Update SQL Table" & "Because Of " & ex.Message & vbCrLf
                    TxtErr.Refresh()
                    TxtErr.ScrollToCaret()
                End Try
            Else
                TxtErr.Text += "Job Ref." & JbRef & " Export Mail Not sent To : " & MailRequest.Rows(Cnt_).Item(1).ToString & Errmsg & vbCrLf
                TxtErr.Refresh()
                TxtErr.ScrollToCaret()
            End If

        Next Cnt_

        LblFtr.Text = "MRS. Job End"
        MsgTxtResp("Waiting...")
    End Sub
    Public Sub ConnectToExchangeServer()
        TxtSrvRsp.Text += vbCrLf & "Connecting to Exchange Server.." & vbCrLf
        TxtSrvRsp.Refresh()
        Try

            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials(My.Settings.ExUNm, My.Settings.ExPass)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            'exchange.AutodiscoverUrl(My.Settings.ExEmail) ' efg
            TxtSrvRsp.Text += "Connected successfully to Server : " + exchange.Url.Host & vbCrLf
            TxtSrvRsp.Refresh()
        Catch ex As Exception
            TxtErr.Text += "Error Connecting to Exchange Server!!" + Now + ex.Message & vbCrLf
            TxtErr.Refresh()
            TxtErr.ScrollToCaret()
        End Try

    End Sub
    Sub HndShck()                ' start Hand Shack
        '                                        
        sqlComm.CommandText = "SELECT MrsSql, MrsFrom, MrsTo, MrsCC, MrsSubject, MrsSndDt, MrsHandSck, MsrNotRegister, 
                                        UsrMRS, User_RealName, User_Gender, MrsCCDrop
                                        FROM Int_user RIGHT OUTER JOIN  MRSInbox ON Int_user.User_Email = MrsFrom
                                        WHERE (MrsHandSck = 0)
                                        ORDER BY MrsSql"
        sqlComm.Connection = sqlCon
        sqlCommProcd.Connection = sqlCon
        sqlComminsert_1.Connection = sqlCon
        sqlComminsert_2.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm

        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If

        MailRequest.Rows.Clear()
        MailRequest.Columns.Clear()
        sqlComm.CommandType = CommandType.Text
        SQLTblAdptr.Fill(MailRequest)
        MsgTxtResp("Handshack Record Count : " & MailRequest.Rows.Count)

        For Cnt_ = 0 To MailRequest.Rows.Count - 1


            EmailSubj = "Re: [MRS Ref. " + MailRequest.Rows(Cnt_).Item(0).ToString + "] " + MailRequest.Rows(Cnt_).Item(4).ToString
            EmailBody = "<font size=3>Dear " + Gndr(MailRequest.Rows(Cnt_).Item(10).ToString) + MailRequest.Rows(Cnt_).Item(9).ToString + ",</font>"
            EmailBody += "<br> <br> <font size=2>Thanks for using MRS (Mail Request Service) </font>"
            If DBNull.Value.Equals(MailRequest.Rows(Cnt_).Item(8)) Then
                EmailBody += "<font size=2>, Your Request has been rejected by server, because you are not a VOCA User </font>"
                If MailRequest.Rows(Cnt_).Item(11) = True Then
                    EmailBody += "<br> <font size=2>There is one or more CC receipt has been dropped (they will not receive any data) because they are out of Egypt Post Domain</font>"
                End If
                EmailBody += My.Resources.MsgSign

                sqlComm.CommandText = "Update MRSInbox set MrsHandSck=-1, MsrNotRegister=-1 where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                ERej += 1
                EHshk += 1
                TxtERej.Text = ERej
                TxtEHandSh.Text = EHshk
            ElseIf MailRequest.Rows(Cnt_).Item(8) = False Then
                EmailBody += "<font size=2>, Your Request has been rejected by server, because you are unregistered in this service.</font>"
                If MailRequest.Rows(Cnt_).Item(11) = True Then
                    EmailBody += "<br> <font size=2>There is one or more CC reciept has been dropped (they will not receive any data) because they are out of Egypt Post Domain.</font>"
                End If
                EmailBody += My.Resources.MsgSign
                sqlComm.CommandText = "Update MRSInbox set MrsHandSck=-1, MsrNotRegister=-1 where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                ERej += 1
                EHshk += 1
                TxtERej.Text = ERej
                TxtEHandSh.Text = EHshk
            ElseIf (MailRequest.Rows(Cnt_).Item(8)) = True Then
                Dim SbGd As Boolean
                If Split(EmailSubj, ",").Count >= 3 Then
                    If Strings.InStr(MailRequest.Rows(Cnt_).Item(4).ToString, "MRS", CompareMethod.Text) = 1 And IsDate(Trim(Split(MailRequest.Rows(Cnt_).Item(4).ToString, ",")(1))) = True _
                                And IsDate(Trim(Split(MailRequest.Rows(Cnt_).Item(4).ToString, ",")(2))) = True Then
                        SbGd = True
                    Else
                        SbGd = False
                    End If
                Else
                    SbGd = False
                End If


                If SbGd = True Then
                    EmailBody += "<font size=2>, Your Request has been received successfully, and we will reply ASAP Within 5 minutes.</font>"
                Else
                    EmailBody += "<font size=2>, Your Request has been received successfully, but MRS can't analyze your request.</font>"
                    EmailBody += "<font size=2>, Please rebuild your parameters.</font>"
                    ERej += 1
                    TxtERej.Text = ERej

                End If


                If MailRequest.Rows(Cnt_).Item(11) = True Then
                    EmailBody += "<br> <font size=2>There is one or more CC reciept has been dropped (they will not receive any data) because they are out of from Egypt Post Domain.</font>"
                End If
                EmailBody += My.Resources.MsgSign

                sqlComm.CommandText = "Update MRSInbox set MrsHandSck=1, MrsSbjGood=" & Convert.ToInt32(SbGd) & " where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                EHshk += 1
                TxtEHandSh.Text = EHshk
            End If

            MsgTxtResp("Sending handshake Mail To " & MailRequest.Rows(Cnt_).Item(1).ToString & "  .......")


            If SEmail(MailRequest.Rows(Cnt_).Item(1).ToString, MailRequest.Rows(Cnt_).Item(3).ToString,, EmailSubj, EmailBody) = 1 Then
                MsgTxtResp("handshake Mail has been sent ")

                sqlComm.ExecuteNonQuery()
                'MsgTxtResp("Waiting...")


            Else
                sqlComminsert_1.CommandText = "Insert into ArtInt (AIJbNm, AIJob) Values ('MRS', 'Mail To " & MailRequest.Rows(Cnt_).Item(1).ToString & " Failure Because " & Errmsg & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & "');"
                sqlComminsert_1.ExecuteNonQuery()
                TxtErr.Text += "Job Ref." & JbRef & " handshake Mail Not sent To : " & MailRequest.Rows(Cnt_).Item(1).ToString & Errmsg & vbCrLf
                TxtErr.Refresh()
                TxtErr.ScrollToCaret()
            End If

        Next Cnt_

    End Sub
    Function Gndr(Genders As String) As String
        Dim Gndrrtn As String = ""
        If Genders = "Male" Then
            Gndrrtn = "Mr. "
        ElseIf Genders = "Female" Then
            Gndrrtn = "Miss/Mrs "
        ElseIf IsDBNull(Genders) Then
            Gndrrtn = "Sir., "
        End If
        Return Gndrrtn
    End Function
    Sub MsgTxtResp(MsgTxt As String)
        TxtSrvRsp.Text += MsgTxt & vbCrLf
        TxtSrvRsp.Refresh()


        'If InStr(MsgTxt, "Waiting") = 1 Then
        '    TxtSrvRsp.SelectionStart = TxtSrvRsp.TextLength - 12
        '    TxtSrvRsp.SelectionLength = 10
        'End If


        TxtSrvRsp.SelectionStart = (TxtSrvRsp.TextLength - 1)
        TxtSrvRsp.SelectionLength = 0
        TxtSrvRsp.ScrollToCaret()

    End Sub
    Sub Smrscomp()  ' handel procedure MRSCOMP
        Dim DtSwp As Boolean

        MsgTxtResp("Exporting .........." & Cnt_ + 1 & " of " & MailRequest.Rows.Count)
        Dim Params(3) As SqlParameter          'SQL Parametes
        Params(0) = New SqlParameter("@From", SqlDbType.Date)
        Params(1) = New SqlParameter("@To", SqlDbType.Date)
        Params(2) = New SqlParameter("@Comp", SqlDbType.NChar)
        Params(3) = New SqlParameter("@Leader", SqlDbType.NChar)
        sqlCommProcd.Parameters.AddRange(Params)



        If Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1)) <= Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(2)) Then
            Params(0).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1))
            Params(1).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(2))
            DtSwp = False
        Else
            Params(0).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(2))
            Params(1).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1))
            DtSwp = True
        End If


        Try
            Params(2).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(3))

            If Params(2).Value.ToString.Length = 0 Then 'make parameter is nothing if empty
                Params(2).Value = Nothing
            End If
        Catch ex As Exception
            Params(2).Value = Nothing
        End Try
        Try
            Params(3).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(4))
            If Params(3).Value.ToString.Length = 0 Then 'make parameter is nothing if empty
                Params(3).Value = Nothing
            End If
        Catch ex As Exception
            Params(3).Value = Nothing
        End Try

        'DateTime.Parse(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(2))
        'DateTime.Parse(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1))
        'Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1))
        If Math.Abs(DateTime.Parse(Params(1).Value).Subtract(DateTime.Parse(Params(0).Value)).TotalDays) <= 31 Then

            EmailBody += "<br><br> <font size=2>Thanks For Using MRS, Your Request has been done successfully.</font>"

        Else
            Dim aaa As Date = DateAdd("d", 30, Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1)))
            'Params(0).Value = Trim(Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(1))
            Params(1).Value = Format(DateAdd("d", 30, Params(0).Value), "yyyy/MM/dd")
            EmailBody += "<br><br> <font size=2>Thanks for using MRS, You have requested more than One Month, so MRS reduced the period to 30 days form your start Date.</font>"
        End If

        If DtSwp = True Then
            EmailBody += "<br><br> <font size=2> MRS swapped the start date and the end date as you sent the end date less than the start date.</font>"
        End If

        If Params(2).Value = Nothing Then
            DataExpSrv("MRS_Ref-" + MailRequest.Rows(Cnt_).Item(0).ToString, Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(0), "Complaint Report From " + Format(Date.Parse(Params(0).Value), "dd-MM-yyyy") + " To " + Format(Date.Parse(Params(1).Value), "dd-MM-yyyy"))
        Else
            DataExpSrv("MRS_Ref-" + MailRequest.Rows(Cnt_).Item(0).ToString, Split(MailRequest.Rows(Cnt_).Item(3).ToString, ",")(0), "Complaint Of " + Params(2).Value + " From " + Format(Date.Parse(Params(0).Value), "dd-MM-yyyy") + " To " + Format(Date.Parse(Params(1).Value), "dd-MM-yyyy"))
        End If
        sqlCommProcd.Parameters.Clear()


    End Sub
End Class