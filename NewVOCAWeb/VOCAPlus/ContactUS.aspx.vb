Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net.Mail

Public Class ContactUs
    Inherits System.Web.UI.Page
    Dim OsIP As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        OsIP = Request.UserHostAddress
        'TextBox2.Text = OsIP
        'Label1.Text = OsIP
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Smtp_Server As New SmtpClient
        Dim E_mail As New MailMessage()

        Try
            Label1.Text = "Sending Mail To voca-support@egyptpost.org"
            Smtp_Server.Host = "mail.egyptpost.org"
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("voca-support@egyptpost.org", "ASD_asd123")
            Smtp_Server.Port = 25
            Smtp_Server.EnableSsl = False
            '10.10.28.14
            '10.10.28.7
            E_mail = New MailMessage()
            E_mail.From = New MailAddress(TextBox1.Text + "@egyptpost.org")
            E_mail.To.Add("voca-support@egyptpost.org")
            E_mail.CC.Add(TextBox1.Text + "@egyptpost.org")
            E_mail.Subject = "VOCA+ Web Teckit : " + TextBox3.Text + " & Client IP: " + Request.ServerVariables("REMOTE_ADDR")

            E_mail.IsBodyHtml = True
            E_mail.Body = TextBox4.Text
            Smtp_Server.Send(E_mail)
            Label1.Text = "Message has been sent To voca-support@egyptpost.org"
            TextBox1.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            Label1.ForeColor = Drawing.Color.Green
        Catch error_t As Exception
            Label1.Text = "Failed to sending Mail To voca-support@egyptpost.org"
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class