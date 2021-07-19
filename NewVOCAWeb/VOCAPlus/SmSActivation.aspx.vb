Imports Microsoft.Exchange.WebServices.Data
Imports System.Data.SqlClient
Public Class SmSActivation
    Inherits System.Web.UI.Page
    Private exchange As ExchangeService
    Dim Errmsg As String
    Dim sqlComm As New SqlCommand                    'SQL Command
    Dim sqlCon As New SqlConnection '(strConn) ' I Have assigned conn STR here and delete this row from all project
    Dim sqlCConCCSYS As New SqlConnection ' I Have assigned conn STR here and delete this row from all project
    Dim SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Dim IP_ As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IP_ = Request.UserHostAddress
        TxtMail.Text = "a.farag"
        TxtPass.Text = "@HemoNad105046"
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ConnectToExchangeServer() = Nothing Then
            Colct.Visible = True
            Crdentials0.Visible = False
            Crdentials.Visible = False
        Else
            Lbl.Text = "Can't Connect"
            Colct.Visible = False
            Crdentials0.Visible = True
            Crdentials.Visible = True
        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If InsUpd("insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat)  values ('" & Split(LblUsr.Text, " ")(1) & "','" & Split(LblUsr.Text, " ")(0) & "','" & IP_ & "','" & "AA" & "');") = Nothing Then
            Literal1.Text = "Submited"
        End If
    End Sub
    Private Function ConnectToExchangeServer() As String
        Dim Str As String = Nothing
        Literal1.Text = "Connecting to Exchange Server.."
        Try
            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\" + TxtMail.Text, TxtPass.Text)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")

            Dim message As New EmailMessage(exchange)
            message.ToRecipients.Add("a.farag@egyptpost.org")
            message.SendAndSaveCopy()
            Literal1.Text = "Connected successfully to Server : " + exchange.Url.Host
            Dim Usrtbl As New DataTable
            GetTbl("select UsrRealNmEn, UsrId from Int_User where UsrNm = '" & TxtMail.Text & "'", Usrtbl)
            If Usrtbl.Rows.Count > 0 Then
                LblStat.Text = "Welcome : " & Usrtbl.Rows(0).Item(0).ToString
                LblUsr.Text = Usrtbl.Rows(0).Item(1).ToString & " " & TxtMail.Text
            Else
                'Str = "X"
            End If

        Catch ex As Exception
            Literal1.Text = "Error Connecting to Exchange Server!!" & Now & ex.Message & vbCrLf
            Str = "X"
        End Try
        Return Str
    End Function
    Private Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlCon.ConnectionString = strConn
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
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
    Private Function InsUpd(SSqlStr As String) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        Dim sqlCon As New SqlConnection
        Errmsg = Nothing
        sqlCon.ConnectionString = strConn
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Lbl.Text = "Error Connecting !!" & Now & ex.Message & vbCrLf

            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function

    Protected Sub UpdatePanel1_Load(sender As Object, e As EventArgs) Handles UpdatePanel1.DataBinding

    End Sub
End Class