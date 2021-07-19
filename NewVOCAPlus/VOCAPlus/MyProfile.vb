Imports System.Net
Imports System.IO
Imports System.Threading
Public Class MyProfile
    Dim D As OpenFileDialog = New OpenFileDialog
    Dim Directry As String = "ftp://10.10.26.4/UserPic/"
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub MyProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        RadioRght.Checked = False
        RadioWrng.Checked = False
        RadioRght.Enabled = True
        RadioWrng.Enabled = True
        LblUsrRNm.Text = Usr.PUsrRlNm
        txtSisco.Text = Usr.PUsrSisco
        txtMobile.Text = Usr.PUsrGsm
        txtMail.Text = Usr.PUsrMail
        Label5.Text = "فقط لمره واحده يرجى القيام بالتالي لإكتمال تسجيل الدخول: " & vbNewLine & "                    - ادخال رقم موبايل صحيح" & vbNewLine & "                    - التأكيد على صحة عنوان البريد الإلكتروني من عدمه"
        Label5.ForeColor = Color.Red
        If txtMobile.TextLength = 11 Then
            Timer1.Stop()
            Label5.Visible = False
        Else
            Timer1.Start()
            Label5.Visible = True
        End If
        If CheckIfFtpFileExists(Directry & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg") = True Then
            Dim request As FtpWebRequest = WebRequest.Create(Directry & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg")
            request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 20000
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream()
                Dim buffer As Byte() = New Byte(10240 - 1) {}
                PictureBox1.Image = Image.FromStream(ftpStream) 'Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & Usr.PUsrID & ".jpg")
                'Loop While read > 0
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.BorderStyle = BorderStyle.None
                request.Abort()
                ftpStream.Close()
                ftpStream.Dispose()
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtMobile.TextLength = 11 Then
            If InsUpd("Update Int_User set UsrSisco = '" & txtSisco.Text & "', UsrGsm = '" & txtMobile.Text & "', UsrEmail = '" & txtMail.Text & "' where UsrId = " & Usr.PUsrID, "0000&H") = Nothing Then
                Usr.PUsrSisco = txtSisco.Text
                Usr.PUsrGsm = txtMobile.Text
                Usr.PUsrMail = txtMail.Text
                Timer1.Stop()
                Label5.Visible = False
                MsgInf("تم تسجيل البيانات بنجاح")
            End If
        Else
            MsgErr("برجاء التحقق من رقم الموبايل")
        End If

    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub BtnUploadimage_Click(sender As Object, e As EventArgs) Handles btnUploadimage.Click
        Lblmssg.Text = ""
        Dim D As OpenFileDialog = OpenFileDialog1
        With D
            .Title = "Picture Upload"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Filter = "JPG|*.jpg"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        If D.ShowDialog() = DialogResult.OK Then
            Lblmssg.Refresh()

            Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(Directry & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg"), FtpWebRequest)
            'Upddate property
            mReq.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            mReq.Method = WebRequestMethods.Ftp.UploadFile
            mReq.Timeout = 20000
            'Read file
            Dim MFile() As Byte = File.ReadAllBytes(D.FileName)
            Dim fi As New FileInfo(D.FileName)
            Dim size As Long = fi.Length
            If size > 1048576 Then
                MsgInf("حجم الصوره لابد ان يكون أقل أو يساوى 1024 KB" & vbCrLf & "حجم الملف = " & (size / 1024).ToString("N2") & " KB")
                Exit Sub
            End If
            Lblmssg.Text = "Loading ............"
            Try
                'Upload
                Dim mStream As Stream = mReq.GetRequestStream()
                mStream.ReadTimeout = 20000
                mStream.Write(MFile, 0, MFile.Length)
                'CleanUp
                mStream.Close()
                mStream.Dispose()
                Lblmssg.Text = "Done"
                PictureBox1.Image = Image.FromFile(D.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.BorderStyle = BorderStyle.None
            Catch ex As Exception
                Lblmssg.Text = ""
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Function CheckIfFtpFileExists(ByVal fileUri As String) As Boolean
        Dim exist As Boolean = False
        Dim request As FtpWebRequest = WebRequest.Create(fileUri)
        request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
        request.Method = WebRequestMethods.Ftp.GetFileSize
        request.Timeout = 20000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            request.Abort()
            ' THE FILE EXISTS
            exist = True
        Catch ex As WebException
            Dim response As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                ' THE FILE DOES NOT EXIST
                exist = False
            End If
        End Try
        Return exist
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 2000
        If Label5.Visible = True Then
            Label5.Visible = False
            Timer1.Interval = 500
        Else
            Label5.Visible = True
            Timer1.Interval = 2000
        End If

        If txtMobile.TextLength = 11 And RadioRght.Checked = True Or RadioWrng.Checked = True Then
            btnExit.Enabled = True
            Timer1.Stop()
            Label5.Text = "تم اكتمال المطلوب بنجاح" & vbNewLine & "لن يتم طلب ذلك منك مره أخرى" & vbNewLine & "يرجى إغلاق الشاشة الحالية لتسجيل الدخول"
            Label5.ForeColor = Color.Green
            Label5.Visible = True
        Else
            btnExit.Enabled = False
        End If
    End Sub
    Private Sub RadioRght_Click(sender As Object, e As EventArgs) Handles RadioRght.CheckedChanged, RadioWrng.CheckedChanged
        If RadioRght.Checked = True Then
            Invoke(Sub() RadioRght.Enabled = False)
            Invoke(Sub() RadioWrng.Enabled = False)
        ElseIf RadioWrng.Checked = True Then
            Invoke(Sub() RadioRght.Enabled = False)
            Invoke(Sub() RadioWrng.Enabled = False)
        End If

        Dim SndMailTsk As New Thread(AddressOf SndMail)
        SndMailTsk.IsBackground = True
        SndMailTsk.Start()
    End Sub
    Private Sub SndMail()
#Region "Email Body"
        Dim Bdy As String = "<p><span style= " & Chr(34) & "text-align: left;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">Dear " & Usr.PUsrRlNm & ",</span></p>
<p><span style =  " & Chr(34) & "text-align: left;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > You recieved this message because you have confirmed your email address on <strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "><span style=" & Chr(34) & " color: #339966;" & Chr(34) & ">VOCA Plus</span>&nbsp;</span></strong></span><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">Application, and you will not recieve this mail again.</span></p>
<ul>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > If your email address is correct and you are the right User, please don't reply.</span></li>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > please feel free to contact us any time On <a href=" & Chr(34) & "mailto:voca-support@egyptpost.org" & Chr(34) & ">VOCA Support Team</a>.</span></li>
</ul>" &
"<br>

<p style= " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & "><span  >عزيزي " & Usr.PUsrRlNm & "</span></p>
<p style =  " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "  dir=" & Chr(34) & "rtl" & Chr(34) & "><span " & " >لقد استلمت هذا البريد الإلكتروني فقط لتأكيد بريديك الألكتروني المسجل على تطبيق  <strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "><span style=" & Chr(34) & " color: #339966;" & Chr(34) & ">VOCA Plus</span>&nbsp;</span></strong></span><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">، ونخبرك أيضا أنك لن تستلم هذه الرسالة مره أخرى.</span></p>


<ul style=" & Chr(34) & "padding-left: 150px; text-align: right;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & ">

<li><span style = " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & " >في حالة كونك المستخدم الصحيح وقد قمت باستلام الرسالة بالفعل، رجاء لا تقوم بالرد على هذا الإيميل..</span></li>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > لا تردد في التواصل معنا في أي وقت على  <a href=" & Chr(34) & "mailto:voca-support@egyptpost.org" & Chr(34) & ">VOCA Support Team</a>.</span></li>
</ul>" &
"<p><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " data-mce-mark=" & Chr(34) & "1" & Chr(34) & ">Best Regard,</span></p>
<p><strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " data-mce-mark=" & Chr(34) & "1" & Chr(34) & ">VOCA Plus Team</span></strong></p>" & "<img src=" & Chr(34) & "ftp://10.10.26.4/CallCenter/Attch/VocaIcon1.jpg" & Chr(34) & "width=" & Chr(34) & "64" & Chr(34) & " height=" & Chr(34) & "64" & Chr(34) & " />"
#End Region
        If RadioRght.Checked = True Then
            If SndExchngMil("voca-support@egyptpost.org", Usr.PUsrMail,, "Verification Mail From VOCA Plus Application", Bdy, 2) = Nothing Then
                MsgInf("لقد تم ارسال ايميل لك للتأكيد صحة بريدك الإلكتروني" & vbNewLine & "يرجى عدم الرد على الأيميل")
            End If
        ElseIf RadioWrng.Checked = True Then
            If SndExchngMil("voca-support@egyptpost.org",,, "Email Verification failure Of " & Usr.PUsrRlNm & " _ " & "User ID : " & Usr.PUsrID, "", 2) = Nothing Then
                MsgInf("تم ارسال ايميل بعدم صحة بريدك الإلكتروني لفرق الدعم الخاص بالتطبيق" & vbNewLine & "وسيتم التواصل معك في أقرب وقت" & vbNewLine & "يمكنك التواصل مباشرة ايضا مع فريق RTM وذلك لتقديم المساعده")
            End If
        End If
    End Sub
    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        If txtMobile.TextLength = 11 Then
            If InsUpd("Update Int_User set UsrGsm = '" & txtMobile.Text & "' where UsrId = " & Usr.PUsrID, "0000&H") = Nothing Then
                Usr.PUsrGsm = txtMobile.Text
            Else
                txtMobile.Text = ""
                MsgErr("فشل في الاتصال" & vbNewLine & "يرجى أدخال رقم الموبايل مره أخرى")
            End If
        End If
    End Sub
End Class