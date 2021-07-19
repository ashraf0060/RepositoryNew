Imports Microsoft.Exchange.WebServices.Data
Imports System.Net.Mail
Module PublicCode
    Public Errmsg As String = ""
    Public sqlComm As New SqlCommand          'SQL Command
    Public sqlComminsert_1 As New SqlCommand  'SQL Command
    Public sqlComminsert_2 As New SqlCommand  'SQL Command
    Public Reader_ As SqlDataReader           'SQL Reader
    Public SQLTblAdptr As New SqlDataAdapter  'SQL Table Adapter
    'Public strConn As String = "Data Source=NEW-VOCA\SQLVOCAPLUS;Initial Catalog=VOCAPlus;Integrated Security=True"
    Public strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
    Public sqlCon As SqlConnection
    Public ExpDTable As New DataTable        'Export data Function to use its count every time i use this function
    Public StrFileName As String = "X"
    Public Distin As String = "X"
    Public MailTable As New DataTable
    Public AutoMailRWS As Integer
    Public ArtiMSG As String = ""
    Function OsIP() As String              'Returns the Ip address 
        OsIP = System.Net.Dns.GetHostEntry(Environment.MachineName).AddressList(0).ToString()
    End Function
    Public Function SEmail(ETo As String, Optional ECc As String = "", Optional EBc As String = "", Optional Esub As String = "", Optional EMsg As String = "", Optional ETch As String = "X", Optional EPri As String = "N") As Integer
        '   Email Function Ver. 4.0
        Dim Smtp_Server As New SmtpClient
        Dim E_mail As New MailMessage()
        sqlCon = New SqlConnection(strConn)
        sqlComminsert_2.Connection = sqlCon
        sqlComminsert_2.CommandType = CommandType.Text
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        Try
            Smtp_Server.Host = My.Settings.StmpH
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(My.Settings.StmpU, My.Settings.StmpP)
            Smtp_Server.Port = My.Settings.StmpR ';    //alternative port number Is 8889
            Smtp_Server.EnableSsl = False

            E_mail = New MailMessage()
            E_mail.From = New MailAddress(My.Settings.FEmail)
            For Each ETo In ETo.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.To.Add(ETo)
            Next
            For Each ECc In ECc.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.CC.Add(ECc)
            Next
            For Each EBc In EBc.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.Bcc.Add(EBc)
            Next
            Select Case EPri
                Case EPri = "H"
                    E_mail.Priority = MailPriority.High
                Case EPri = "L"
                    E_mail.Priority = MailPriority.Low
                Case Else
                    E_mail.Priority = MailPriority.Normal
            End Select
            E_mail.Subject = Esub
            If ETch <> "X" Then
                'E_mail.Attachments.Add(New Attachment(ETch))
            End If
            E_mail.IsBodyHtml = False
            E_mail.Body = EMsg
            Smtp_Server.Send(E_mail)
            SEmail = 1

        Catch error_t As Exception
            '& ", " & error_t.InnerException.Message
            Errmsg = error_t.Message
            'MsgBox(Errmsg)
            sqlComminsert_2.CommandText = "Insert into ArtInt (AIJob) Values (' Mail Of " & Errmsg & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & " Not Sent" & "');"
            sqlComminsert_2.ExecuteNonQuery()
            SEmail = 0
        End Try

        sqlComminsert_2.CommandText = "Insert into ArtInt (AIJob) Values (' Mail Of " & MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & " Has Been Sent" & "');"
        sqlComminsert_2.ExecuteNonQuery()
        Return SEmail

    End Function
    Public Function CalDate(StDt As Date, ByRef EnDt As Date) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
        Dim WdyCount As Integer
        StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
        EnDt = DateValue(EnDt)

        If StDt > EnDt Then         ' check right date in case of.....
            MsgBox("خطأ..... تاريخ الإنتهاء قبل تاريخ البدأ")
        End If
        If StDt = EnDt Then         ' check right date in case of.....
            MsgBox("تاريخ الإنتهاء  يساوي تاريخ البدأ")
        End If
        sqlCon = New SqlConnection(strConn)
        sqlComm.Connection = sqlCon ' Get ID & Date & UserID
        sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (((HDate) Between'" + StDt + "' And '" + EnDt + "') AND ((HDy)=1));"
        sqlComm.CommandType = CommandType.Text
        sqlCon.Open()
        Reader_ = sqlComm.ExecuteReader
        Reader_.Read()
        WdyCount = Reader_!WDaysCount
        Reader_.Close()
        Return WdyCount
    End Function
    Public Function DataExpSrv(sQlfLNm As String, SQLsTRS As String) As String
        Errmsg = Nothing
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim Rws As Integer
        Dim Col As Integer
        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه
        Try                                                                                                       'Try If there is available Connection
            sqlCon = New SqlConnection(strConn)
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_1.CommandText = ""
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.CommandText = SQLsTRS
            SQLTblAdptr.SelectCommand = sqlComm
            Try
                ExpDTable.Rows.Clear()
                ExpDTable.Columns.Clear()
                SQLTblAdptr.Fill(ExpDTable)
                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")
                XLWrkBk.Title = ("VOCA Plus Auto Exported Data")
                XLWrkBk.Subject = ("Auto Mail Service")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")
                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus Auto Mail Service"
                XLWrkSht.Cells(2, 1) = "Ashraf Farag"
                XLWrkSht.Cells(3, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Rows("1:3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                XLWrkSht.Rows("1:3").Font.FontStyle = "Bold"
                XLWrkSht.Rows("1:1").font.color = Color.Red
                XLWrkSht.Rows("1:3").Font.Size = 12
                XLWrkSht.Rows("1:1").Font.Name = "Times New Roman"
                XLWrkSht.Rows("2:2").Font.Name = "Lucida Handwriting"
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Font.Color = Color.Black
                'Set Merge Signature Cells
                XLWrkSht.Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(1, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(3, 1), XLWrkSht.Cells(3, ExpDTable.Columns.Count)).Merge()


                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "yyyy/mm/dd" 'Date Columns
                    End If
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"


                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                Next Rws
                With XLWrkSht
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Color = Color.Black
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).WrapText = False
                    .Cells.Columns.AutoFit()
                    '.Cells.EntireColumn.AutoFit()
                End With
                Distin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & sQlfLNm & Format(Now, "dd-MM-yyyy_HH_mm_ss") & ".xlsx"
                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
            Catch ex As Exception
                Errmsg = "X"
                GoTo End_
            End Try
        Catch ex As Exception
            Errmsg = "X"
            GoTo End_
        End Try
        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        GC.Collect()
        sqlComminsert_1.CommandText = "Insert into ArtInt (AIJob) Values (' File Exported Of " & MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & "');"
        sqlComminsert_1.ExecuteNonQuery()
End_:
        Return Errmsg
    End Function
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SqlTbl.Rows.Clear()
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Public Function SndExchngMil(To_ As String, Optional Cc_ As String = "", Optional Bcc_ As String = "" _
                              , Optional Suj As String = "", Optional Body_ As String = "", Optional Import As Integer = 2, Optional AttchNam As String = "", Optional AttchLction As String = "") As String
        Dim MailRsult As String = Nothing

        Dim exchange As ExchangeService
        exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
        exchange.Credentials = New WebCredentials("egyptpost\voca-support", "ASD*asd123")
        exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
        Dim message As New EmailMessage(exchange)
        message.ToRecipients.Add(To_)
        If Cc_.Length > 0 Then message.CcRecipients.Add(Cc_)
        If Bcc_.Length > 0 Then message.BccRecipients.Add(Bcc_)
        message.Subject = Suj
        message.Body = Body_
        If Distin.Length > 0 Then
            message.Attachments.AddFileAttachment(AttchNam, AttchLction)
            message.Attachments(0).ContentId = AttchNam
        End If
        message.Importance = Import
        Try
            message.SendAndSaveCopy()
        Catch ex As Exception
            MailRsult = "X"
        End Try
        Return MailRsult
    End Function
End Module
