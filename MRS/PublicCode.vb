Imports System.Net.Mail
Imports System.Text.RegularExpressions

Module PublicCode
    Public Errmsg As String = ""           'Ashraf-pc\AshrafSQL XXXXXXXXXXXX
    Public Const strConn As String = "Data Source=Ashraf-pc\AshrafSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Public sqlComm As New SqlCommand          'SQL Command
    Public sqlCommProcd As New SqlCommand     'SQL Command
    Public sqlComminsert_1 As New SqlCommand  'SQL Command
    Public sqlComminsert_2 As New SqlCommand  'SQL Command
    Public Reader_ As SqlDataReader           'SQL Reader
    Public SQLTblAdptr As New SqlDataAdapter  'SQL Table Adapter
    Public Cnt_ As Integer                    ' Counter
    Public SqlStr As String
    Public ExpDTable As New DataTable        'Export data Function to use its count every time i use this function
    Public Rws As Integer
    Public Col As Integer
    Public StrFileName As String = "X"
    Public MailTable As New DataTable
    Public AutoMailRWS As Integer
    Public ArtiMSG As String = ""
    Public DataExprRtrn As ExprXlsx
    Public Test As String = "Test"
    'Public Const strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus;Password=ASDasdasd54321"
    Public sqlCon As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Public Structure ExprXlsx
        Dim RwsCnt As Integer
        Dim ColCnt As Integer
        Dim Distin As String
        Dim NoDatas As Boolean
    End Structure

    Public Function SEmail(ETo As String, Optional ECc As String = "", Optional EBc As String = "", Optional Esub As String = "", Optional EMsg As String = "", Optional ETch As String = "X", Optional EPri As String = "N") As Integer
        '   Email Function Ver. 4.0
        Dim Smtp_Server As New SmtpClient
        Dim E_mail As New MailMessage()
        sqlComminsert_2.Connection = sqlCon
        sqlComminsert_2.CommandType = CommandType.Text
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        Try
            Smtp_Server.Host = My.Settings.StmpH
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(My.Settings.FEmail, My.Settings.StmpP)
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
                E_mail.Attachments.Add(New Attachment(ETch))
            End If
            E_mail.IsBodyHtml = True
            E_mail.Body = EMsg
            Smtp_Server.Send(E_mail)
            SEmail = 1
            'sqlComminsert_2.CommandText = "Insert into ArtInt (AIJob) Values (' Mail Of " & MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & " Has Been Sent" & "');"
            'sqlComminsert_2.ExecuteNonQuery()
            Return SEmail
        Catch error_t As Exception
            Errmsg = error_t.Message
            'MRSEx.MsgTxtResp("Sending Mail Failed " & "Becuase of " & error_t.Message)

            SEmail = 0
        End Try



    End Function
    Public Function DataExpSrv(sQlfLNm As String, SQLsTRS As String, SQlHdr As String) As ExprXlsx
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه

        Try                                                                                                       'Try If there is available Connection
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_1.CommandText = ""
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlCommProcd.CommandText = SQLsTRS
            SQLTblAdptr.SelectCommand = sqlCommProcd
            Try
                ExpDTable.Rows.Clear()
                ExpDTable.Columns.Clear()
                SQLTblAdptr.Fill(ExpDTable)

                DataExprRtrn.RwsCnt = ExpDTable.Rows.Count
                DataExprRtrn.ColCnt = ExpDTable.Columns.Count

                If DataExprRtrn.RwsCnt = 0 Then
                    DataExprRtrn.NoDatas = True
                    DataExprRtrn.Distin = "X"
                    Exit Function
                Else
                    DataExprRtrn.NoDatas = False
                End If

                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")

                XLWrkBk.Title = ("VOCA Plus Auto Exported Data " & sQlfLNm)
                XLWrkBk.Subject = ("MRS")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")

                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus MRS    By Ashraf Farag"
                XLWrkSht.Cells(2, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Cells(3, 1) = SQlHdr
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

                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"

                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "yyyy/mm/dd" 'Date Columns
                    ElseIf ExpDTable.Columns(Col).ToString.Contains("تليفون") Or ExpDTable.Columns(Col).ToString.Contains("Phone") Or ExpDTable.Columns(Col).ToString.Contains("كارت") Or ExpDTable.Columns(Col).ToString.Contains("قومي") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" 'Date Columns
                    End If
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter



                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    MRSEx.LblFtr.Text = (Rws + 1) * (Col) & " Of " & ExpDTable.Rows.Count * ExpDTable.Columns.Count
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
                DataExprRtrn.Distin = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & sQlfLNm & ".xlsx"
                '                                               Environment.SpecialFolder.UserProfile.MyDocuments
                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(DataExprRtrn.Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
            Catch ex As Exception
                MRSEx.TxtErr.Text += "Exporting Function Failed " & "Becuase of " & ex.Message & vbCrLf
                MRSEx.TxtErr.Refresh()
                MRSEx.TxtErr.ScrollToCaret()
                GoTo End_
            End Try
        Catch ex As Exception
            MRSEx.TxtErr.Text += "Connecting to SQL when Exporting failed " & "Becuase of " & ex.Message & vbCrLf
            MRSEx.TxtErr.Refresh()
            MRSEx.TxtErr.ScrollToCaret()
            'sqlComminsert_1.CommandText = "Insert into ArtInt (AIJob) Values (' File Of " & MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & " Not Exported Because Of Connection Issue" & "');"
            'sqlComminsert_1.ExecuteNonQuery()
            DataExprRtrn.Distin = "X"
            GoTo End_

        End Try

        Return DataExprRtrn


        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        'sqlComminsert_1.CommandText = "Insert into ArtInt (AIJob) Values (' File Exported Of " & MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Format(Now, "dd-MM-yyyy_HH_mm_ss") & "');"
        'sqlComminsert_1.ExecuteNonQuery()

End_:

    End Function
    Function EEAStr(ByVal source As String) As String 'Extract Email Addresses From String
        Dim mc As MatchCollection
        Dim i As Integer
        Dim Emails As String = ""
        ' expression garnered from www.regexlib.com - thanks guys!
        mc = Regex.Matches(source, "([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})")
        For i = 0 To mc.Count - 1
            Emails &= mc(i).Value & "; "
        Next
        Emails = Left(Emails, Emails.Length - 2)
        Return Emails
    End Function
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception

            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
    Public Function InsUpd(SSqlStr As String, ErrHndl As String) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            'LoadFrm("", 500, 350)
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
End Module
