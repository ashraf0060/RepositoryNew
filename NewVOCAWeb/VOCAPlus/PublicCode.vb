Imports Microsoft.Exchange.WebServices.Data
Imports System.Data.SqlClient
Module PublicCode
    Public SecTmer As Integer
    Public EncDecTxt As String                          'Encoding decoding string
    Dim Errmsg As String
    Public sqlComm As New SqlCommand                    'SQL Command
    Public sqlCon As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Public sqlCConCCSYS As New SqlConnection ' I Have assigned conn STR here and delete this row from all project
    Public SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Public strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046" ' "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Public Nw As DateTime = ServrTime()
    Public Function GETTTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.ConnectionString = strConn
                sqlCon.Open()
            End If
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Public Function InsUpd(SSqlStr As String) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.ConnectionString = strConn
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
    Public Function PassEncoding(password As String, FSaltKey As String) As String
        Dim Wrapper As New Simple3Des(FSaltKey)
        EncDecTxt = Wrapper.EncryptData(password)
        Return EncDecTxt
    End Function
    Public Function PassDecoding(password As String, FSaltKey As String) As String
        Dim wrapper As New Simple3Des(FSaltKey)
        Try '        DecryptData throws if the wrong password is used.
            EncDecTxt = wrapper.DecryptData(password)
        Catch ex As System.Security.Cryptography.CryptographicException
            EncDecTxt = "false"
        End Try
        Return EncDecTxt
    End Function
    Public Function ServrTime() As DateTime
        Errmsg = Nothing
        Dim TimeTble As New DataTable
        TimeTble.Rows.Clear()
        TimeTble.Columns.Clear()
        Try
            PublicCode.GETTTbl("Select GetDate() as Now_", TimeTble)
            Nw = CDate(Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt"))
            'WelcomeScreen.LblLstSeen.Text = Nw
        Catch ex As Exception

        End Try
        Return Nw
    End Function
    Public Function SndExchngMil(To_ As String, Optional Cc_ As String = "", Optional Bcc_ As String = "" _
                               , Optional Suj As String = "", Optional Body_ As String = "", Optional Import As Integer = 0) As String
        Dim MailRsult As String = Nothing

        Dim exchange As ExchangeService
        exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
        exchange.Credentials = New WebCredentials("egyptpost\voca-support", "asd_ASD123")
        exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
        Dim message As New EmailMessage(exchange)
        message.ToRecipients.Add(To_)
        If Cc_.Length > 0 Then message.CcRecipients.Add(Cc_)
        If Bcc_.Length > 0 Then message.BccRecipients.Add(Bcc_)
        message.Subject = Suj
        message.Body = Body_
        'message.Attachments.AddFileAttachment(AttchNam, AttchLction)
        'message.Attachments(0).ContentId = AttchNam
        message.Importance = CType(Import, Importance)
        Try
            message.SendAndSaveCopy()
        Catch ex As Exception
            MailRsult = "X"
        End Try
        Return MailRsult
    End Function

End Module
