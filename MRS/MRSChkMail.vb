Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Public Class MRSChkMail

    Dim HasAttachment As Boolean = False
    Dim aryAttachments() As String
    Dim networkStream As NetworkStream
    Dim readStream As StreamReader
    Dim EmailHeader As String = ""
    Dim EmailBody As String = ""
    Dim strRetrieve As String = ""
    Dim SrvDelRep As String
    Dim Ertv As Integer = 0
    Dim Edrp As Integer = 0

    Dim EHshk As Integer = 0
    Dim ERej As Integer = 0
    Dim MailRequest As New DataTable


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 30000
        Dim aryStats(2) As String
        Dim Fdfrom, Fdto, FDcc, Fdsbjct, FdDt, Fdtht, Fdpri, Fdsbend As Integer
        Dim PrsFrom, PrsTo, PrsCC, PrsSbjct As String
        Dim PrsDt As Date

        If TxtSrvRsp.Text.Length > 5000 Then
            TxtSrvRsp.Text = ""
        End If


        Dim popServer As New TcpClient()
        Try
            popServer.Connect(My.Settings.StmpH, My.Settings.PopR)
            networkStream = popServer.GetStream()
            readStream = New StreamReader(networkStream)
            TxtSrvRsp.Text += vbCrLf & "MSR. Job Start at " & Now & vbCrLf
            LblFtr.Text = "MRS. Extrating Email From Pop3 Start"
            TxtSrvRsp.Text += readStream.ReadLine() + vbCrLf
            TxtSrvRsp.Text += PopCommand(networkStream, "USER " & My.Settings.ExUNm) & vbCrLf
            TxtSrvRsp.Text += PopCommand(networkStream, "PASS " & My.Settings.StmpP) & vbCrLf

            Dim serverStats As String = PopCommand(networkStream, "STAT")  ' raw number of email then size 
            aryStats = serverStats.Split(" ")
            Me.Refresh()

            If Integer.Parse(aryStats(1)) > 0 Then '                        ' if there is email
                TxtSrvRsp.Text += "number of emails: " & aryStats(1) & vbCrLf
                For Cnt_ = 1 To Integer.Parse(aryStats(1))                  ' for each email found
                    strRetrieve = "RETR " + Cnt_.ToString + vbCrLf
                    TxtSrvRsp.Text += "List of Email(s) ..............." & vbCrLf
                    For NOemaila As Integer = 1 To Integer.Parse(aryStats(1))
                        TxtSrvRsp.Text += PopCommand(networkStream, "LIST " & Cnt_.ToString) & vbCrLf
                    Next NOemaila
                    TxtSrvRsp.Text += "Retrive Email No. " & Cnt_ & vbCrLf
                    GetEmail(strRetrieve)


                    Fdfrom = 0
                    Fdto = 0
                    FDcc = 0
                    Fdsbjct = 0
                    Fdsbend = 0
                    FdDt = 0
                    Fdtht = 0
                    Fdpri = 0
                    PrsFrom = ""
                    PrsTo = ""
                    PrsCC = ""
                    PrsSbjct = ""

                    Try
                        TxtSrvRsp.Text += "Retrive Email No. " & Cnt_ & " Done." & vbCrLf
                        TxtSrvRsp.Text += PopCommand(networkStream, "DELE " & Cnt_) & vbCrLf
                        TxtSrvRsp.Text += "Retrive Email No. " & Cnt_ & " Was Marked For Deletion" & vbCrLf
                        '  **********                  start parse Section
                        Fdfrom = InStr(1, EmailHeader, "From:", CompareMethod.Text)
                        Fdto = InStr(1, EmailHeader, "To:")
                        FDcc = InStr(1, EmailHeader, "CC:")
                        Fdsbjct = InStr(1, EmailHeader, "Subject:")
                        Fdsbend = InStr(Fdsbjct, EmailHeader, vbNewLine)
                        Fdtht = InStr(1, EmailHeader, "Thread-Topic:")
                        FdDt = InStr(1, EmailHeader, "Date:")
                        Fdpri = InStr(1, EmailHeader, "X-Priority:")

                        PrsFrom = EmailHeader.Substring(Fdfrom + 5, (InStr(Fdfrom, EmailHeader, vbCr)) - Fdfrom - 6)    'extract From: << until >> to:

                        If FDcc > 0 Then            ' cc is found  in email
                            PrsTo = EmailHeader.Substring(Fdto + 3, FDcc - Fdto - 4)    'extract To:   << until >> cc:
                            PrsCC = EmailHeader.Substring(FDcc + 3, Fdsbjct - FDcc - 4) 'extract CC:   << until >> Subject:
                        Else                        ' cc Not found  in email
                            PrsTo = EmailHeader.Substring(Fdto + 3, Fdsbjct - Fdto - 4) 'extract To:   << until >> Subject:
                            PrsCC = ""                                                    'empty the CC: 

                        End If
                        If Fdtht > 0 Then            ' Thread-Topic is found  in email
                            PrsSbjct = EmailHeader.Substring(Fdsbjct + 8, Fdtht - Fdsbjct - 9) 'extract Subject: << until >> Thread-Topic:
                        Else
                            If Fdsbjct < FdDt Then
                                PrsSbjct = EmailHeader.Substring(Fdsbjct + 8, FdDt - Fdsbjct - 9) 'extract Subject: << until >> Date:
                            Else
                                PrsSbjct = EmailHeader.Substring(Fdsbjct + 8, Fdsbend - Fdsbjct - 9) 'extract Subject: << unrtil >> end of line
                            End If
                        End If


                        Try

                            PrsDt = DateTime.Parse(EmailHeader.Substring(FdDt + 10, 20), Globalization.CultureInfo.InvariantCulture)
                        Catch

                            PrsDt = DateTime.Parse(EmailHeader.Substring(FdDt + 5, 17), Globalization.CultureInfo.InvariantCulture)
                        End Try

                        PrsFrom = EEAStr(PrsFrom)
                        PrsTo = EEAStr(PrsTo)
                        If PrsCC <> "" Then
                            PrsCC = EEAStr(PrsCC)
                        End If

                        ' **********                     end Parse Section       
                        If Split(PrsFrom, "@")(1) = "egyptpost.org" Or Split(PrsFrom, "@")(1) = "jubar.me" Then

                            sqlCon.Open()
                            sqlComm.Connection = sqlCon

                            sqlComm.CommandText = "INSERT INTO MRSInbox (MrsFrom, MrsTo, MrsCC, MrsSubject, MrsSndDt) VALUES('" & PrsFrom & "', '" & PrsTo & "', '" & PrsCC & "', '" & PrsSbjct & "', '" & Format(PrsDt, "yyyy/MM/dd HH:mm:ss") & "');"
                            sqlComm.CommandType = CommandType.Text
                            sqlComm.ExecuteNonQuery()
                            TxtSrvRsp.Text += "Complete Extracting & Saving Email No.:" & Cnt_ & vbCrLf
                            Ertv += 1
                            LblERtv.Text = "Email Retrived = " & Ertv
                        Else
                            TxtSrvRsp.Text += "Complete Extracting, out of Egyptpost.org  Email No.:" & Cnt_ & "Droped" & vbCrLf
                            Edrp += 1
                            LblEDrp.Text = "Email Droped = " & Edrp
                        End If




                    Catch ex As Exception
                        TxtErr.Text = ex.Message

                    End Try
                    Me.Refresh()
                Next Cnt_
            Else
                TxtSrvRsp.Text += "No Email Found..." & vbCrLf

            End If
            TxtSrvRsp.Text += "Job Complete..." & Now & vbCrLf
        Catch ex As Exception
            TxtErr.Text = ex.Message
        End Try
        TxtSrvRsp.Text += "End Negotiate with Email server" & vbCrLf
        TxtSrvRsp.Text += PopCommand(networkStream, "QUIT") & vbCrLf
        TxtSrvRsp.SelectionStart = TxtSrvRsp.TextLength - 12
        TxtSrvRsp.SelectionLength = 10
        TxtSrvRsp.ScrollToCaret()
        ' *******   Hand schack     seconde step

        Dim ConfMailBody As String = ""
        Dim To_ As String = ""
        Dim CC_ As String = ""
        Dim Subject_ As String = ""
        Dim Body_ As String = ""

        '                                        
        sqlComm.CommandText = "SELECT MrsSql, MrsFrom, MrsTo, MrsCC, MrsSubject, MrsSndDt, MrsHandSck, MsrNotRegister, 
                                            UsrMRS, UsrRealNm, UsrGender 
                                        FROM Int_user RIGHT OUTER JOIN  MRSInbox ON Int_user.UsrEmail = MrsFrom
                                        WHERE (MrsHandSck = 0)
                                        ORDER BY MrsSql"
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm

        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If

        MailRequest.Rows.Clear()
        SQLTblAdptr.Fill(MailRequest)
        TxtSrvRsp.Text += "Record Count : " & MailRequest.Rows.Count & vbCrLf
        For Cnt_ = 0 To MailRequest.Rows.Count - 1

            To_ = MailRequest.Rows(Cnt_).Item(1).ToString
            CC_ = MailRequest.Rows(Cnt_).Item(3).ToString
            Subject_ = "Re:" + MailRequest.Rows(Cnt_).Item(4).ToString

            If DBNull.Value.Equals(MailRequest.Rows(Cnt_).Item(8)) Then

                ConfMailBody = "Dear Sir," + Chr(13) + Chr(13) +
    "Thanks for using MRS (Mail Request Service)" + Chr(13) + "Your Request has been Rejected by server, Because you are unregistered in this service." + Chr(13) +
    "Best Regards" + Chr(13) + Chr(13) +
    "This Is an auto mail Service, Please don't reply." + Chr(13) +
    "Website: http://10.10.26.14:8000/VOCAPlus.aspx" + Chr(13) +
    "---------------------------------------------------------------------------"

                sqlComm.CommandText = "Update MRSInbox set MrsHandSck=-1, MsrNotRegister=-1 where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                ERej += 1
                LblERej.Text = "Email ReJected = " & ERej
            ElseIf Not DBNull.Value.Equals(MailRequest.Rows(Cnt_).Item(8)) Then
                If MailRequest.Rows(Cnt_).Item(8) = False Then
                    ConfMailBody = "Dear Sir," + Chr(13) + Chr(13) +
    "Thanks for using MRS (Mail Request Service)" + Chr(13) + "Your Request has been Rejected by server, Because you are unregistered in this service." + Chr(13) +
    "Best Regards" + Chr(13) + Chr(13) +
    "This Is an auto mail Service, Please don't reply." + Chr(13) +
    "Website: http://10.10.26.14:8000/VOCAPlus.aspx" + Chr(13) +
    "---------------------------------------------------------------------------"

                    sqlComm.CommandText = "Update MRSInbox set MrsHandSck=-1, MsrNotRegister=-1 where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                    ERej += 1
                    LblERej.Text = "Email ReJected = " & ERej
                ElseIf (MailRequest.Rows(Cnt_).Item(8)) = True Then

                    ConfMailBody = "Dear " + MailRequest.Rows(Cnt_).Item(9).ToString + "," + Chr(13) + Chr(13) +
    "Thanks for using MRS (Mail Request Service), Your Request has been recieved Successfully, and we will reply As soon As possible With In 5 minutes. 

Best Regards,

This Is an auto mail Service, Please don't reply.
http://10.10.26.14:8000/VOCAPlus.aspx
-------------------------------------------------------------------"
                    sqlComm.CommandText = "Update MRSInbox set MrsHandSck=-1 where MrsSql=" + MailRequest.Rows(Cnt_).Item(0).ToString + ";"
                    EHshk += 1
                    LblEHandSh.Text = "Email HandShaked = " & EHshk
                End If
            End If
            LblFtr.Text = "Sending Mail To " & To_ & "  ......."
            TxtSrvRsp.Text += "Sending Mail To " & To_ & "  ......." & vbCrLf
            SEmail(To_, CC_,, Subject_, ConfMailBody)
            TxtSrvRsp.Text += "Mail has been sent " & vbCrLf
            sqlComm.ExecuteNonQuery()
            TxtSrvRsp.Text += "Waiting..." & vbCrLf
            TxtSrvRsp.SelectionStart = TxtSrvRsp.TextLength - 12
            TxtSrvRsp.SelectionLength = 10
            TxtSrvRsp.ScrollToCaret()

        Next Cnt_
        LblFtr.Text = "MRS. Job End"
        TxtSrvRsp.Text += "Waiting..." & vbCrLf
        TxtSrvRsp.SelectionStart = TxtSrvRsp.TextLength - 12
        TxtSrvRsp.SelectionLength = 10
        TxtSrvRsp.ScrollToCaret()

        ' *******   Send request   third    step
















    End Sub
    Private Sub GetEmail(SrvGetmailCom As String)
        Dim serverBytes() As Byte = Encoding.ASCII.GetBytes(SrvGetmailCom)

        Dim streamReader As StreamReader
        Dim TextLine As String = ""
        Dim linefeeds As Integer
        EmailHeader = ""
        EmailBody = ""
        Try

            networkStream.Write(serverBytes, 0, serverBytes.Length)
            streamReader = New StreamReader(networkStream)
            streamReader = New StreamReader(networkStream)
            Do While streamReader.Peek() <> -1

                TextLine += streamReader.ReadLine() & vbNewLine

            Loop
            TextLine = ""
            streamReader = New StreamReader(networkStream)
            Do While streamReader.Peek() <> -1

                TextLine += streamReader.ReadLine() & vbNewLine

            Loop

            linefeeds = InStr(1, TextLine, vbCrLf & vbCrLf)

            If linefeeds <> 0 Then
                EmailHeader = TextLine.Substring(0, linefeeds - 1)
                EmailBody = TextLine.Substring(linefeeds + 1, TextLine.Length - EmailHeader.Length - 3)

            End If
        Catch ex As Exception

            TxtErr.Text = ex.Message

        End Try
    End Sub
    Function PopCommand(networkStream As NetworkStream, serverCommand As String) As String
        Try
            serverCommand &= vbCrLf
            Dim serverBytes() As Byte = Encoding.ASCII.GetBytes(serverCommand)
            Dim readStreamBytes As StreamReader
            Dim SrvReponse As String

            networkStream.Write(serverBytes, 0, serverBytes.Length)
            readStreamBytes = New StreamReader(networkStream)
            SrvReponse = readStreamBytes.ReadLine()

            Return SrvReponse

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
