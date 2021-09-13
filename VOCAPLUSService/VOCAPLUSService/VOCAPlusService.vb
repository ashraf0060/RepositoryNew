Imports System.Data.SqlClient
Imports System.Threading
Imports ClosedXML.Excel
Imports Microsoft.Exchange.WebServices.Data
Public Class VOCAPlusService
    Private exchange As ExchangeService
    Dim AcbDataTable As New DataTable
    Dim WeekTable As New DataTable
    Dim escTable As New DataTable
    Dim WdNo As Boolean = False
    Dim State As String = ""
    Dim FolwStr As String = ""
    Dim EscCount As Integer = 0
    Dim EsclTsk As New Thread(AddressOf EscSub)
    Dim sss As Integer = 0
    Dim MailTbl As New DataTable
    Public Mail_ As New Stru.StruMail
    Dim ExrtErr As String
    Private BdyStrt As String
    Private BdyEnd As String
    Private Sub VOCAPlusService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
        'Me.TxtErr.Width = Me.Size.Width - 30
        Me.TxtErr.Height = Me.Size.Height - 100
        CombHour.Text = Now.Hour
        CombMin.Text = Now.Minute + 1
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If
        Span_ = TimeSpan.Parse("00:01:00")
        nxt = " On " & Now.Add(TimeSpan.Parse("00:01:00"))
    End Sub
    Private Function SendMailEx(Coun_ As Integer) As Integer
        Dim MailRslt As Integer = 0
        If EscCnt > 4 Then EscCnt = 4
        'Try

SendMail_:
        Invoke(Sub() TxtErr.Text = Now & " : " & "Trying To Connect To Mail Server " & vbCrLf & TxtErr.Text)
        'Invoke(Sub() DataGridView3.DataSource = Nothing)
        escTable.Rows.Clear()
        escTable.Columns.Clear()
        If GetTbl("select EscID, EscCC, EscDur, EscUCatLvl from EscProcess where escID = " & EscCnt & " and EscUCatLvl = " & AcbDataTable.Rows(0).Item("CCUCatLvl").ToString(), escTable) = Nothing Then
            exchange = New ExchangeService(ExchangeVersion.Exchange2013_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\acb", "ASD_asd123")
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Invoke(Sub() TxtErr.Text = Now & " : " & "Connected successfully to Server : " + exchange.Url.Host & vbCrLf & TxtErr.Text)
            Invoke(Sub() TxtErr.Text = Now & " : " & "Sending New Message To " & AcbDataTable.Rows(0).Item("FLWMail").ToString & vbCrLf & TxtErr.Text)
            'Invoke(Sub() DataGridView3.DataSource = escTable)
            Dim message As New EmailMessage(exchange)
            'message.ToRecipients.Add("a.farag@egyptpost.org")
            message.ToRecipients.Add(AcbDataTable.Rows(0).Item("FLWMail").ToString)
            message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CSTLMail").ToString)
            message.CcRecipients.Add(AcbDataTable.Rows(0).Item("CCTLMail").ToString)
            message.CcRecipients.Add(AcbDataTable.Rows(0).Item("UsrEscEmail").ToString)

            If escTable.Rows.Count > 0 Then 'XXXXXXXXXXXXXXXXXXXXXXXXX Revisit this IF row line because without this there will be error because of LVL of suspended User
                If DBNull.Value.Equals(escTable.Rows(0).Item("EscCC")) = False Then
                    If Split(escTable.Rows(0).Item("EscCC"), ";").Count > 0 Then
                        For Cnountt = 0 To Split(escTable.Rows(0).Item("EscCC"), ";").Count - 1
                            message.CcRecipients.Add(Split(escTable.Rows(0).Item("EscCC"), ";")(Cnountt))
                        Next
                    End If
                End If
            End If
            message.Subject = Esc & " ل" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & " " & AcbDataTable.Rows(0).Item("TeamNm").ToString & " شكوى رقم : " & EscAtoTable.Rows(Coun_).Item("TkID").ToString
            Dim aa As String = EscAtoTable.Rows(Coun_).Item("ProdKNm")
            Dim StatPic As String = ""
            Dim file As String = ""
            If EscAtoTable.Rows(Coun_).Item("TkClsStatus") = True Then
                State = "مغلقة"
                file = "C:\Tckoff.png"
                StatPic = "Tckoff.png"
            Else
                State = "مفتوحه"
                file = "C:\Tckon.png"
                StatPic = "Tckon.png"
            End If

            message.Attachments.AddFileAttachment(StatPic, file)
            'message.Attachments(0).IsInline = True
            message.Attachments(0).ContentId = StatPic
            Dim colr As String
            If WdNo = True Then colr = "Green" Else colr = "Red"
#Region "Body Message"
            message.Body = "<p Style=" & Chr(34) & "text-align: center;" & Chr(34) & "><Span style=" & Chr(34) & "color: rgb(65, 168, 95); font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong>تشغيل تجريبي لنظام المتابعات التلقائي</strong></span></p><br>" &
                                        "<p Style=" & Chr(34) & "text-align: right;direction: rtl" & Chr(34) & "><Span style=" & Chr(34) & "color: Black ; font-family:Times New Roman; font-size: 14px;text-align: right;direction: rtl" & Chr(34) & "><strong>جميع البيانات الوارده في هذا الإيميل مطابقه للواقع، والمتابعه صحيحة، طبقاً لقواعد المتابعات المعلنة.<br>في حالة ظهور أي أخطاء من أي نوع يرجى التواصل على  voca-support@egyptpost.org</strong></span></p><br>" &
                                        "<table style=" & Chr(34) & " width:100%;direction: rtl;" & Chr(34) & "><tbody><tr><td style=" & Chr(34) & "width: 70.0000%;" & Chr(34) & "<div style=" & Chr(34) & "text-align: right;vertical-align:text-top;font-size: 18px;" & Chr(34) & " >استاذ (ه) / " & AcbDataTable.Rows(0).Item(5).ToString & "<br> نص التحديث : <Span Style=" & Chr(34) & "color:" & colr & Chr(34) & ";>" & Esc & "</span><br><br><br><Span Style=" & Chr(34) & "color:Black;font-family:Courier New" & Chr(34) & ";>" & FolwStr & "</span></div></td><td style=" & Chr(34) & "width: 30.0000%;" & Chr(34) & ">" & "<div style=" & Chr(34) & "text-align: left;" & Chr(34) & "><img src=" & Chr(34) & StatPic & Chr(34) & " style=" & Chr(34) & "width: 172px;" & Chr(34) & " class=" & Chr(34) & "fr-fic fr-dib fr-fil" & Chr(34) & "></td></tr></tbody></table>" &
                                        "<table style=“ & Chr(34) & “width: 100%; direction: rtl; border-style: solid; border-color:" & colr & Chr(34) & “><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>رقم الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkID").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>اسم العميل:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkClNm").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>تاريخ تسجيل الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkDtStart").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>تاريخ استلام الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkRecieveDt").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>حالة الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & State & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>مصدر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("SrcNm").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>عدد المتابعات:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkEscTyp").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>تاريخ آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("LstUpdtTime").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>نص آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("TkupTxt").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>محرر آخر تحديث:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("LstUpUsr").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>نوع المنتح:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("ProdKNm").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>اسم الخدمة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("PrdNm").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>نوع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & EscAtoTable.Rows(Coun_).Item("CompNm").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>محرر الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & AcbDataTable.Rows(0).Item(1).ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>متابع الشكوى:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                        “>" & AcbDataTable.Rows(0).Item("FolwUsr").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>مشرف المجموعة:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                                        AcbDataTable.Rows(0).Item("CCTL").ToString & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                        “><strong>التليفون الداخلي:</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) & “>" &
                                        AcbDataTable.Rows(0).Item("CCFlwPh").ToString & "-" & AcbDataTable.Rows(0).Item("CCTLPh").ToString & "</div></td></tr></tbody></table>" & "<br><br><p style=" & Chr(34) & "direction:rtl;text-align: right;" & Chr(34) & ">تم إرسال هذا البريد الإلكتروني من خلال تطبيق +VOCA<br>تم ارسال هذا البريد الإلكتروني حيث أنك طرف من أطراف المتابعه (محرر المتابعه - متابع الشكوى - إدارة الجودة - مشرف أو مدير مسئول)<br>يرجى عدم الرد على هذا الإيميل.<br>للتواصل يرجى الإرسال على voca-support@egyptpost.org</p> "
#End Region
            message.Body.BodyType = BodyType.HTML
            Try
                message.SendAndSaveCopy()
            Catch ex As Exception
                sss += 1
                Invoke(Sub() TxtErr.Text = Now & " Error : " & ex.Message & vbCrLf & TxtErr.Text)
                GoTo SendMail_
            End Try

            Invoke(Sub() TxtErr.Text = Now & " : " & "Mail has been set " & vbCrLf & TxtErr.Text)

        End If
        'Catch ex As Exception
        '    MailRslt = 1
        '    Invoke(Sub() TxtErr.Text = Now & " : " & "Faild to Send Mail " & ex.Message & vbCrLf & TxtErr.Text)
        'End Try
        Return MailRslt
    End Function
    Private Sub TimerSec_Tick_1(sender As Object, e As EventArgs) Handles TimerSecnods.Tick
        LblTimer.Text = "Next Job Will Be After : " & (Span_ - TimeSpan.Parse("00:00:01")).ToString & nxt
        LblTimer.Refresh()
        Span_ -= TimeSpan.Parse("00:00:01")
        Label1.Text = "Now Is : " & Now

        If TxtErr.TextLength = TxtErr.MaxLength Then
            TxtErr.Text = "Empty Again"
        End If

    End Sub
    Private Sub TimerEsc_Tick(sender As Object, e As EventArgs) Handles TimerEsc.Tick
        Dim WW = ServrTime()
        Dim WWq = Format(WW, "HH:mm")
        Dim WWwq = Format(WW, "mm")

#Region "Body"
        BdyStrt = "<p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:36.0pt;margin-bottom:8.0pt;margin-left:0cm;line-height:107%;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;text-indent:-18.0pt;'><strong><span style='font-size:19px;line-height:107%;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;'>نظام البريد التلقائي لتطبيق&nbsp;</span></strong><strong><span dir=" & Chr(34) & "LTR" & Chr(34) & " style='font-size:24px;line-height:107%;font-family:" & Chr(34) & "Bahnschrift Condensed" & Chr(34) & ",sans-serif;color:#0070C0;'>VOCA Plus</span></strong></p>
<p dir= " & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:36.0pt;margin-bottom:8.0pt;margin-left:0cm;line-height:107%;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;text-indent:-18.0pt;'><strong><span dir=" & Chr(34) & "RTL" & Chr(34) & " style='font-size:19px;line-height:107%;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;'>&nbsp;</span></strong></p>
<div style='margin-top:0cm;margin-right:0cm;margin-bottom:8.0pt;margin-left:0cm;line-height:107%;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;'>
    <ul style=" & Chr(34) & "font-size 20px;direction:ltr;text-align:Right;" & Chr(34) & "<span style='font-family: " & Chr(34) & "Times New Roman" & Chr(34) & ", serif; color: rgb(65, 168, 95);text-align:right;'><strong><span style=" & Chr(34) & "font-size: 20px;direction:ltr;text-align:Right;" & Chr(34) & ">"
        BdyEnd = " </span></strong></span>
    </ul>
</div>
<p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:36.0pt;margin-bottom:.0001pt;margin-left:0cm;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span style='font-size:19px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;'>&nbsp;</span><span style=" & Chr(34) & "font-size:16px;font-family:&quot;Times New Roman&quot;,serif;color:black;" & Chr(34) & "></span><span style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:black;'>&nbsp;</span></p>
<div align=" & Chr(34) & "right" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:8.0pt;margin-left:0cm;line-height:107%;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;'>
    <table dir=" & Chr(34) & "rtl" & Chr(34) & " style=" & Chr(34) & "border: none;margin-left:-1.0pt;border-collapse:collapse;" & Chr(34) & ">
        <tbody>
            <tr>
                <td style=" & Chr(34) & "width: 97.3pt;border-top: none;border-right: none;border-bottom: none;border-image: initial;border-left: 1pt solid windowtext;padding: 0cm 5.4pt;height: 56.2pt;vertical-align: top;" & Chr(34) & ">
                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span dir=" & Chr(34) & "LTR" & Chr(34) & " style=" & Chr(34) & "font-size:15px;color:black;" & Chr(34) & ">&nbsp;</span></p>
                    <table style=" & Chr(34) & "border: none;width:76.5pt;margin-left:.1pt;border-collapse:collapse;" & Chr(34) & ">
                        <tbody>
                            <tr>
                                <td style=" & Chr(34) & "border:solid #DDDDDD 1.0pt;padding:.75pt .75pt .75pt .75pt;height:5.35pt;" & Chr(34) & "><br></td>
                            </tr>
                            <tr>
                                <td style=" & Chr(34) & "border:solid #DDDDDD 1.0pt;border-top:none;padding:.75pt .75pt .75pt .75pt;height:41.5pt;" & Chr(34) & "><br></td>
                                <td style=" & Chr(34) & "border:solid #DDDDDD 1.0pt;border-left:none;padding:.75pt .75pt .75pt .75pt;height:41.5pt;" & Chr(34) & ">
                                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span dir=" & Chr(34) & "LTR" & Chr(34) & ">&nbsp;<img src=" & Chr(34) & "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEA3ADcAAD/2wBDAAIBAQEBAQIBAQECAgICAgQDAgICAgUEBAMEBgUGBgYFBgYGBwkIBgcJBwYGCAsICQoKCgoKBggLDAsKDAkKCgr/2wBDAQICAgICAgUDAwUKBwYHCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgr/wAARCACqAKoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKaxIPWgBl3d29jbtdXUyxxouWdjgAV4p8Uf21/CfgO7kttD8OXWsCFiJZLc4Gfb1rk/2o/wBrHSNN+IDfBHQ7W4luI7UzXl3C3yIePkPvXO/CHwTaNL/wlviiMXFzId0Mcn3YVPoKqUXG1xJp7HsPwW/bE+G/xcmj0uVLjSNQk+5a38ZXf7Ke9euKwYZFeHzyeH7pFiutJt32n5f3Yytdn4M+I0UDppeqzloeFjmY8p9fapGd9RSKwYZXpS0AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABWD8R/FUPgvwje+IJHCtFC3lbu7Y4Fb1fPH/BRL4vaZ8LvhUF1O9WFbxZEXLYw2MA/qa0pU5VKiiurJlLli2fGXg/xdcfFD41ar4ka5aT7TqT
                                    CWRmzkoTmvqbRdUW3sY4Ub7qgV+Vf7M/7R9z8GP2pbj4Ua54kbWLHVLzz7S8K7VRZmJAHPbHNfpRpGvJd2kcsb5DLmujGKTxUr/wBJaImjb2asd0NaJON5/OtCy1ds/eriba/ZhndWtY3pPJaohTvoU5H0R8KfEzeIPDyxXEm6e2+R/Xb/AAk/UV1FeQ/s96u/9vXGlg/LNbeY31UgD+devA5FYTjyysOLugoJx2orL8W+KrDwlpE2rahIAsakqufvYGT+lSMk1/xZ4b8LW4u/EWtW9nGejTyYqXR9e0fxBZLqOh6lDdW7fdmhkDKa+On+KGkftVeOZ9X0HU5LjR4LiS3mEiYXKnaVXn9a9g+EOg6F8H/Mi8IyTrazcy2M05ZM+q+lVKLjKzBO57hRVPRdastdslvrGXcp4K91PoauVIBRRRQAUUUUAFFFFABRRRQAE4Ga/OP/AILw6/fWei6Hp8R/dhSzKWwpJ6Zr9HG5GK+F/wDgsV8NYfG/h2ya5tWk3WzNCqdWKdVHvzXRhJcuIizKtFyptI/DLTNR1qX9oux14XHzW9xHFuVu+7tX7N/CrXpLzwlp8krZZrVCfyr8pdB+B+oL+0tp4i02SxsZ7hZFt5ZdxG3pkkDk+lfp98ObsWmj29op/wBXGq1tWj++fqKD91HrFjek4+atzTbgtgZri9Ivt+Mmuo0icMBzXRTpkSkepfAe6eDx5Cm7/WRMn8q98r59/Z+R7nx/Dxu8uBpP5V9BDpXHjI8taxrTd4iN0r5u/bQ+LcHhzwd4iv5L1Ut9N02RA27GCR81fR15Mbe1kn/uIW/IV+Tn/BWz9ozUfCmlw6DYxxzLq11NJcQzfcZcngjuKnCw9pXimwqS5YNnqn7Bmv6LqHwvttd0a6ikivC02Y2HVjk596+g28QHZhW/Wvyf/wCCM/x28QH4peLvhrNM39kvILrT4MnZBk8qo9Oa/S+31Z5VwWrWUJVKjfmJS5Ynr/wb8Xyw+Jl0uRmZLwbduf4gOD+QxXbfFn4maf8ADfwxcaoZ4zdCMmGGRgBn1Oa8H8Ia2+l6zb6nu/1Mgf8AKvJP+CgHxb0nV9R8K+G9Y1hYV1fxNGyq0m3IAJAPsMCoeH/ecpSl7tz6V+Cnxb+KOuySa547ktJNNuRm2t7eHZNH7+9ew6Xqtlq9mt5ZTBlb9D6GvnTwr4jjtNEt0gddqwrtx06V1HgP4lyaNrZ80s8MykSRhuM44P8ASsXCRXMe2ZFFfN3hb47eJfid8Vb3UPC3jFV0vR7gwXFrFzG8g4ZD9CCM17z4Y8YWXiNWiUeXOnLRZ6j1HtUWaGbFFFFIAooooAK8B/4KFeA7jxL8IP8AhJrGAyS6PL5kigdIj94/oK9+qj4i0LTvEujXWg6tAslteQNFNGw4ZSKAPxs8Y/DDQvEdrJe6VAltqMcgmtbpV5SQdDXV/CT4jDWLP7DqC/Z9Ss8R31sx5Vh/EP8AZPauw/aM+CevfAX4m3fhu8gc6fNI0um3OOJIyeB9RXjvxE8J+JzLH46+HEqprNnybZjhLxO8bf0Nd1Fcxl
                                    U02Po7w5r0cqr+8rudBvlZAQ1fL3wb+Puh+NbIxzeZp+pWzbL7TLr5ZYHHUe49xmvcPA3ij+2PLh052lZ22qFycn0r2MPTjKN7nJM+n/2WdPlvNfvtaUfu7e38o/Vj/wDWr3MZxzXD/APwLL4H8DQw6hHi8uv31x6jPRT9K7ivBxVRVK8mjspx5YJFfVQX0y4RerQOB/3ya/HP/gpt8LL34maU11bWlxPcaPeSo8VqMyYyeQPriv2SkwVwa/Pn9s/wPdfDv413wntv9B1hjc27Mvykn7w/AmjCy5ao6keaNj4T/wCCWnwo1j4e/EHXNd8U2j2t1KmLWGZcM0Wclvev0V0LUBOilX7V81eMdDu7SODxp4JgVdU0vLpGgx58fVoz9ev1FerfAn4q6H8SNBh1rSJ/m+5dWz/6yCQcMjD1Br2KNLmlY5pS0PYBcfZLGS6c/Kqk15frXw1+F3xw0/Vh8QdP/tJbiUKqTNzayRn5DGf4OQDxXsXhvwhd+N9G1CysfvQ6fJOD67R0rx34WaVPbX99D4lspbfzZFmQf3uMfzrmxkeXEcq7F0fehc6L4Ta9fWfhiPQL6WQyWEz26mRssyI2FJPfIrovEnjOHwl4Y1DxVeyFYbGzeaRgegCmuKvdR07RfiBcaLaXC7mjSUxbvmGR1qL9oO0v9f8AgB4l0fS5gtxfaa8EJ9SwxitqeHjy3ZE6j2R5r/wTb/a88F/F648X+G9LfydU0/WpZ7hN3EscjFlZT9CAfevs74XeNZ4PGtm5lby3k2SKD1B6D86/Kb/gln8DfFnwG+Jmv6j46t3s7jUYRHYxycGWNcZY++RX6Y/ByOXWfFunwxfMWmB/Ln+lcsqHMpT9TWM+WyPqgHtRTVp1eYbhRRRQAUUVHcXMNpG01zMsaKMlmOAKAOE/aD+BHhb46eBp9A12BVuoVaSwvAvzQyY9fT2r87tZ+G2s+G9ZudEuI9zWszRs6chsHrX3p8Xfjl/xLptB8FOzSSKVlvB0A/2a8Bk8ImeZrm6XczNlmI613YPn9p5GdTlcT59079kZPjr4utdLs9Fkt9VkbbHqdnIYpI19WZeStez/AAf/AGMP2vP2ff2rvCL6dqul+JPh+0QGuXFxaqktq2OSPU56GvQ/hTeS/D7xRDr1jaq235ZEx95e4r6b8K+MND8W2IutLugW25khP3kPoRXRjqlSnK0dFYyoKMo6muBgYAoooryTpCvH/wBsv4I2Hxe+GE91EirqWkqZ7KTufVc+hr2AnFeQ/tHfFvTdI8PXHhyC/WITt5VxcMcY/wBge9VHmUroD8/yLzRm+z3kLqQcfMKr+G/gh8Wrrx4vjP4IaPc2l5ekf2hZywstreD+8eytj+KvWfE1n4cuJFnhuI5mWQN/qic8/Svffh9+094XufBq+EfElj9lK2vkrcWsOCOMA4x2r1pYqVOmrWZyxp8zI/2G/iDqN7pureFPiR8P77QdctdQNqxvVUx3aDI3xHPKHHt1rhP2hfAWtfCn4ypbaejTaPrzNNZ4H+ocn5l+meldfp/xG8OaNfKlxqH2ua
                                    1jJtL6GMjfznaw9a5v4p+ONX+Iep2niu/nmCWsm1IXXAjz6e1csuZ1lPmvc0jZRta1jw/9pLwF4vi+JOk+N/A0jDWLSyCG3wfLu4cjdG2O/oa25I/GfxQ+EOralFod7pWoeGL2Ea1o95CVYJImVZT0YcjpmvrP4BxeEtTjVNc0m3mvJcNazTQhiu0cqCeh71J8efHukXa33wy0TSHmu2WP+0HjjXaFIyqk569DXRWxk4R9nFW7smNH3uZs+BdT0LVPENlG2kyta6layCazm2n5XH8J9iMg/Wvqr9hDXpvFWuLa+MdOm0zWrGzMxsZoyPN52GRDjBTJ4781o/CHwnoXg/Vpr3WvAMN8skO2NZolbDZznmvoPwadC1bSrfxFZ6LDausTRLtjAaNA3K5HbIzWeIxkeR04LfqEKT5uZm6ODtpa4Gx+Let65JNNoehWrW8d1JCr3FwysxRipPAPGRWhqXxFv9L8LRaxPpkTXU1yIY4RIdhOeTnGentXmnQddRXP+F/Fl/rOpSadfwW8bRx7x5MhY9cdxW9h/WgB2eM15T8avFM02tL4djkxFFGGZVP3ifX6V6jdXMdrbPczSBVjUsx9ABXy5pPxQsPit4m1rXNNfMMGqS2ytuznYcVpGnOUXNLRWv8AMV1ewaxdxWtz5BXnPpUaRrcLuAqHx5G1rqNvOB8snf3qfSmEkQNe5SjFRVjjk3zE0Fiq/NWv4d8V3PhzWopLObZIpz9fb3FVVABwBXP31/5Xi5bUN9yNTXROEakbSIUuWSsfVfh/V4dc0m31OH/lrGCR6HuKuk45rhfgbrH2rRJtL/592D7vXdzXdHpXzdSLp1HFndGXNG5wf7QX7Q3ws/Zy8CSeNvir4oj0uzkkEEEknWSVuFUAd818p/FDxevjTxPoSpN50Elu9427uxIwfyNeJ/8ABx98YrjRPBfhXwJbTL82vW8v0UZLH8wK2vgN4zj+IWi6R4ojm3xjQ7YKw7FowSK9/GZL9T4fw2YNu9VyXkkrWt66mcavPWlDsesQRRKBiNR/wGrkGwdVWstL0etTLqKqM7q+cNjageMEc15t8afj3pPw+8W2/hXVUZraezLzMq52HIwa7EayiDrXn/i3T/D3iL4iWuoyRR3W+Jo7yGRdwGCABz7V2YKmqlXUzqy5Y3PVvg18VtR174er4r8JMyyQLItjPMu0O4U4b6Vzf7Kvi74h+LPDGqeNvirrK3utX2t3CXE6rtXYkjKqgegAAre8QazpPg/wBZ21lHHZ2+5o1SFQqqCh6VyHw/1uw8K+ELfTrW4yrO8289WLtuyffmvTzL2dLCqFldta9bL/AIc58PzOTPb7fxEkI3h/ujPWvZNJZtC+Esl5vAK6XLOD6EoWr48uPiVG8i2ovPLMjhd7HhcnGa7fxH8aviZ4O+GV9p+p2cl5p7qsKX0UoZNhwM9cjj2rxadGVSLkuh1c1nY67wP43tNO8O2rSyBWkTzn57t8x/U11PjrV7TTdG8LW15PgtdSXTK39xlbH86+PtG+Nlxrnj+w8C6esn+kSxp5in5QC4Xb9
                                    ec16N/wUL+JN/4I8R+H/B2kXzRzWuiBJmRuVbdWRR9T/CI2+qi+1uP5j5ixxv6rjP8AOu12v/erzf8AZIt72L4DaFc6mxa4uLbzZXbq2TkH8q9KoA8w/bC+Jtr8If2cfFfjieXZ9l0mXY2cYYqcGvg//gkP421f4i/s0/8ACU65KZLq5167aZuuSWFep/8ABev4sTeB/wBkS48KWF1sm16b7LIueiMOteGf8EMdY0+b9lt9NkmXdDr9yjD05FfdUcsVLgOeMa1nVik/JJr8zjdTmxfJ2R9c/E/EXhpbt+DDKpBrP8L3yzW6tv7D+VbHxz0DWtU8ByL4XsWuZFcM0cfXb3NcL4G1ORYFhuAyuoAZX4IrxaUk4qxMo2Z6HEVxya8w8W+K49P+Lc2nGXB+zxtj6ivQra8BizmuF+PPw1vLnwnbfGvw/CzSaVdGDVlj+8YD0c/7pH610VKkacVcmMXJs90/Z31x21MedJtiuIdo5+8+eB+Vez5+XIr4y+Dvxbt5p4beG7/dKo2lW6N619ReAvGzaxaR2d8+52X9zN/f9vrXjY6m5VHOOx1U5e7Zn4bf8HB/xcvvFv7U6+CPtKmz0YfKv+2a9x/4J0ve2f7Mmkahqc5aSZT5bN1CD7o/AV8g/wDBbKZ3/bZ8Qo7kltQC8+7Yr7K/ZvjXwl8APCuiou0rpcTMPcqK/S+NPZ4fgzK6MFa8b/hr+ZyYT3sROR7OfEAXrNUUvihVHMtcRP4jOceZ+teUeE/2kz45+M2p/DXSLFvI0mNmurxm4dgcbRX5KeifQV14wCRs5l+6PWud+G+qf2pqk+pM2d9wxB/Guda+1DVpf7M08eZPcfu4Vz1Y8Cuw+Fnwd+KeiTf8I/qPhSeO+jb96rY259ck8ivRwPLG8m+xjV1PQvidaaf4j+D19a3YPmQxpJbOrYKNuAz+Wa8Q8TeNdWsdAmh0cmS6gs9lqnq4Xj9a9K+PumfEn4b/AA/W51HTt1veTrBN5bcQr13H8sV4Rdaocsd/f1qcwqxqVFyu+gUYuMdTofhVqr62ul6d8Vri6ZZIw2sSWm7ehxkkbeeD6Vp/Hj4y2ngjxzD8BfAGn6w2jXVgt5/bF/I7R3MeAQFz0IJxg4PFcLpXxD8G+C9Yi1Lxnq2o2cDfLDNp6yFt3odgzirnxG+LuifFW407wb8K11TWpowZGDWkmdxOOpHHWs4x/wBmcrlNvntYm8A+NLbw7470zXb3U47ZLW5EnnTH5RjnqK7D4k+LPHf7aPx5OoeBdBkvbVfJgku4d3koqgBm3MBnv0r0P9jf9jXVrbVJPGPxy8KWN9bzW+y30W8Tcoz/ABNx1+lfb/w2+E3w+8FaNDH4a8EWWkqfm+y2sYCA+uK5+aPs7W+ZfU1vhtoa+GvAWj6AqBfsmmwxED1CAH9a3KamMcUuG/vVAz8r/wDg4r1O4On+HdHDt5fyuV7Zr5Q/4JDftLWHgO71/wCDl/qXkzG+N9Zqz48wN94D6YH519Tf8HE11avqHh3TftUf2lrfzUtw48xkX7zBeuB3PQV+K3jHxx4m+Gfi+
                                    Hxt4N1eSz1CxmDQ3Ebc/eHB9RX9CcO5LDiDw3WCUrO7afZp3Vzx6lR0sY5H9Jfw0+NtrqMUcctyG3e9ddr3gHQ/G1sda8PCOG/C7vl4WT2Nfnv8A/ih480/4eaB4r1+Vrhb7T4pp5Y+qMRzkelfWPwL/aGs7hYkN9uDYGN1fhL9pgsQ6c/suz+R6koqpE6WK8uLMPa3cTxyRkqysDwa9c/Zvt9N8T+D9Y0nVII7i3ml8uaGRdyspBqPS5PC/iWJbiaxgkaUZZmQHNbvhPRLPwC1zP4bdYY7pw8lv1XP9K6K1b61RtFGUY+zldny5+0D+zT4x/Zv1+fx14Fhm1DwrNLveOJS0liSc4IHVfQ16d8APiA3iTwNb+KNUvvJtZpvKtXaTb8wr6G0u+tPFuiSR3tpGyvuinhb5lPY8Hsa8P8AEPwV8JwLdad8ZdY0vRfDOm3klzpa2WofZSdxOC2COg7dKwpVrJxqdDSUb6xPg/8A4K0f8EgPFfx38RyftP8AwR8bxXN1HKlzrWhag2FkiVgS8bjJ3exwKh0Cf+zvDOn6YnC29nHHj0wuK+oPEHxj8Nat+zl45j+H/iiHUrfw/cPa292lwJN8DPgAnnPAr5RS58q3SPd0WvQzfOMbmGEw+GrSvGkmo6K6Ttp57GeHpxjKTXU0570sCN/UYrjPAnwp8FfDnWdU1/QLaT7Zq1w0t5cSyFmYk5wM9BW5Lff7VVZb/r81eAdJY1jx/dfD62/4TOxtftE2myLNFD/fYHpX0Jf/ALR3g79pz4SWNtH4m1Tw74kljWbdp6urRSDqpI4wa8F8F/s861+1df3Xwo0DxjNoc01qZv7SgjDtHtYcYPHNbw/4Ja/tufDaIxfDf446bqCr0F8zRu34Kprqw1WlT+NXM6kJS2NT486r4k0HwPpvhzVPGeo6hHNdbmF9cM5bCkZwTXi174jXzltLZZJ5nOEhgUsxP0Fev6L/AME/f23vHPiGGT4weLNPSxhh8tntt7MDnqoKgV9NfAn9hLwL8MPLkj0T7VqAA8y6uIS0jH2JGBU4mpTqVbwVkVCMoxszjf8Agnx8FtNtPDupa38Y/Bkd02qMv2ewuLdXZUx/tdM9a+r/AAV8Bvgbaq2oeF/h7Z6fNnEnkxBGB+oq54W+GDWSKJ4Ft4sfdX759j6fhXTavq3h3wD4avNe1e7hsdN021e5vLmZsLFGilmdj7AE1zlC6b4S0PR8G0s1yv3WkbcR9M1+T3/BVD9tP9ov9iP/AILX/B/TvhP8RNSuvDPjXwTPceJfBt9dM9jP5czJuRDkRMFUNlQCSDnrXU/E3/g65/Yp8G+LL7w74H+BHxO8aWtjdyQf2z4d0iJ7aYo20shZwSDjjivzf/bO/wCCr/wk/bP/AOCmXgv9sTVfg144sfDPgvwxcaXb+HX05X1MGXdudo1YqBlj3rSn7P2i59rq/pcUublfLuf0qeA/FMfjXwZpfi6GDy11KwiuVj/u71Bx+ta/z+1fj94C/wCDo/4UXGmaD8H/AIOfsQfFa41NYbfTrG41zSFhs1IATzJHVjtQ
                                    YyT2FfWll/wWG+H8VnDFrfwv14XixqLwWdsXhEuPm2N/Eu7OD3GK7MPluMzCpP6rBySfTt0OepiqOGivbSSb/pn5H/8ABxh8Pf2sP2ZP289I+PHjX4x3Xi/QdYtf+KYkvLdYY9PhBHm2DpGNuwjGG+8+Oegr5U/a88IeHX8KeHfit8O5TNoPiyxhubPrmOTK719hk8V+tn/B1H4EsvGfwF+23CAyeH7dNXtl2/NJJDkBPx3fpX5S/A6HVvjd+w9feBXie71Twj4gS4tLS0tzJMtluGyNVUE889u1ff8Ah9m2JyfNIUZy/d1ot26XV/x0MMZGNSnzdU7H6u/BHSEg+D3h20KDC6TCCpH+wK5D9rD4l337KvwF8VftGeCtKhur/wAM6a14ml3E7Jb3RDAbW28gc9q9v+B/wP8AiPq3w70dV8NzWsY0+EbrlCmPlHY818X/APBeLXtc8KeB/B37G3gm5a88XfETXIxNptrhmks04aJgem7cGGeoQ18FjKkJYqp1u3+Z2KOise0/8Euf+Cpfx2/ao+Ed5448c/D/AEvTrqHVprTTotHupHjm8s4YHzMEbcjn3r7r+C/7T2m/E7UW8I3uqWdr4ktkVmslulYOPTgmvyK8K+Gtc/Zd+DujfDXwbp+ofZ9NhksJNW0u2kVbm5babyRyowDuVPm6YzXhum/tCfGP4lfG268IfsqeOrrQbfS8p4u8fLh5AnRoLcHIYk/x+3B610YjCfValOhC7qtK683rb1Stc5aOI9tTlUlpG7s/Jdfmf0A/Hf8Aal+EnwA+Dfif4jfEb4oWvhW30ewkfUJpZ1M0LAcbI/vSEnoACf1r8IPjD/wUd/bB/ap1681r4P8Awb1/x14c+0MsGoeJ9WmsWlXJwyRxsEKEdO/tXLePfhR4K+Jf7YHhP4Max8RfF3iLT9I8P/2z42PiXxJcXh1LlPLUh3ZU3E5+XHHFfpF+zn8JvhFoehw6rqOqab9u2gf2RHKscFgv8MUcfCkL0zjNaUcvjXjOrXnyKL5dNW5LdLpZdXcJYh05RhTXM2r+SXn69D87/wBnz/gqN4z+CGqX3wZ+OvwlbwRoepXijUYdIlmlAfP35Vmwdmf4kz+Vfd2n6/puuaNa+INDvo7ywvoFms7yFt0c0ZHDA/SvLf8Agtl+zb4A8bfAhfH3hjw/ar4q0O2a6tbi3A3XUIKq0LMOq4Ofwrxv/gkT8av+Ei/Zx8RfCTWtRmuW8I6oh0+SZs7VuA0ixL6KoGAK82tQqfWPZ3vbb0Wp0RqR9nzbH1jcagFPLV5b8df2s/hf8Cbm10DXLi81jxHqGBpvhTQYxNf3OSB93pGOc5cqMVxv7Yn7Wkv7OXwlk8YWGlCbVtSY23hy1usr9om5zJt+8UUA8gY3bR3rU/4JW/sB+L/iVqlr8TvH17NfePvGlsmq+JfElxHmbR9MfDRW8ef9XLKpU7eAo3YxxRgcHLG1uW9kleTeyS6v9F1ZOJrxw9Pmtdt2S7s9E+AH7Q3/AAUA8JatdeKvg78Kvh5pbXkfk2sPiXUL6e+jUnlZVtEkjRu
                                    PWuum/wCDgn9tD9ir41aH8P8A/gob+xPotr4Y1iaOGw8XeErqeSS4LMF3r54VcDPKnD+gNfon8F/2c/BXwj0iPRvBfhuGxXaokMMeZZm/vSN95mPq1aP7UH7CHwi/bE+D9x8OPjX4D0/VFt5kvtDjuxhra+iO+GXevzLhgAdvVSRzTxH1H2nJQv2vJrX5Jafewp/WFHmq29F/n1PXfhj8S/BHxk8G2XjfwTqsd9p9/bxzRNjDKrAEBlPKnB7iulChRgAflXkf7Gf7POsfs5/CiPwx4r16PUtcvp2utWurddsKyMTiKIcYjQHavA4Feuk4HWsMTTpUq8oU5c0Vs+5pRlOpTUpxs307DZpo4EMsrBVUZZmOAB61+Qf/AAV1/wCDin4XfDLxhrP7In7PPws034jXCyf2f4s1DU72SHT4mYgNBG0RzK/Yj7vBBr1P/gtN/wAFGPH0Wt23/BOD9i3xXDb/ABJ8WWrSeMPEsTAr4T0bH7+dj0WVk4UH+964r8kP+CpvwC+HfwDtvgFpPw38O3FtYzeH5jfaxew4ufEFwNQ+e/lY/M5fkgn+FqI0a3sXWS91NK/m+gOpT9ooN6tXt5H7Df8ABOD9j79l74xfDO617xJ8HLLTZNNhsZjDp8K2sKfaLVZyiiLAKpu25I5xzXwb/wAEvvh18Ov2oP8Agq78aNe/4R5YdJk8aT+G7WzCjEMFpnlSOhYRcsOea/Vz/gl7p2n3/wABbqMp8t5Y6cJ9rfeU2SD+VeE/se/8Epdf/YU/bw174ifCXw7qereF/FWvXOr6hqmo3MKxWsk4YsFUNvLAtt5GMV61SpKrj90oxjdJtJJ8nRadXeyOOMVDD67t26vTm/yPqm0/4Jy/so2Nx5tt4FuV/vRjVJtjDuCu7BHt0r0qx+C/wp06yh0+z+HukpDbxLHEgsU+VVGAOnpXVgA9etLtX0rzZY7HSSTqP72jqWHoR2ivuPmD/goT+wR4f/bE8N3lz4q1uSG207R5mhs4VB+0SLGxCtn+HOK/Cn/g3s8Qab8NP2wPE3gbxrAv2xrUXcsNxGGKfYpWRhz/ANdRke1f04ahbJeWM1rIMiSJkP4jFfzF/sq+HT4E/wCC9XxO8D6ZERD/AMJR4g0yOJeoDTwkAD8K0w+KrSq0oTl7sXZeSb1CpFKnJpeZ/RB8b/E3w8+AfwY1r42/ETxLDY6F4f0l7++muVCokarnAx3JwB9a/Er9kr4afGj/AIKE/tgap+3Z478O7de+IF69h8I9KvVDHQdFjcj+0ZU+6u1SoRhljvPpX0D/AMFPf2jYf+ChfxMsf2QNCuNR/wCFUfD2a0uPiNd6bIy/8JNq+MRaLFt5kwVbzFGR0zX3t/wT0/Y/T4C+DF+IXjXR7aHxTrNnHGtnbxgR6NYKP3NlEBwoQcHHXvmu3A0YYOLxtdXUXaCf2pL/ANtju++i6nLiqkq0lhqe7V5P+Vf5vZfNnx//AMF249K/YA/4Jat4S8C20MOpeIriDwxpuqRZ8+CSVGd7jd13ERkE+/vXzL/wQ2/YJ8K/Fj4Q+G9J17RJJ
                                    otWjv8AVtVuYCEklXdGII88fKA719Yf8HYPwt8SeOv+CcumeM9DsnmtfB/ji01XWmVSfKtBFKjOfozqPxrzP/g18+OmheOPh3D4Kvb6FdW8PxXVjLa7xvWFnQ25x/tKrVy4TFTjiqleT99xlr5tb/izarh4yoxpJe6mtPJPY5j9oL/giV4h/Z//AGw5v2kfhl4rnfwjrHhVdJ1PS7m0lmntJUK7WDIpypwevtVLxN/wTt/bL8PW6+MvCFtZa9p94gntvsN0Y7go3IyHxg1+3k9vDdRtBPCrxvwyuuQarxeHvD9unlw6PaoFGAqwqMVyyry+rxpLo29+6S2+S6m3J+8c32t93/Dn8/f7SfgX9pP4Wfs8+NPiT8YfB2oWeg6X4fZJptUuQ4iZiqYUZOSSa5D/AIN//wBnV/Emnp42uLU3Vv4o8YRxNbyd4LSKWOViPQOy819L/wDBw9+0tL+1p8UvDf8AwSt/ZXure71CS8F98SNRtMfZdOtlH+qnYcAYyx9GUA9a+pv+COf7G/hrwH4Js/GFjpLL4b8P6OuieD5JIzHJfgY+03zgYz5siBlPoTXfl1OUfaYufwwTV+8pKyS89W/RHNiqnw0I7yafok7t/hY/If8A4KqNY/H3/gsR4f8A2WoBHDofhefT9N0tbUAeWZFFzcA44+9Div3W/wCCePwDtvD/AMKbrxle28UF1rmrSv5kMY3PaRsUt19gI+BivwR/br1VPgP/AMF9Nc8VeOE+x22leO7e6uJJF/5YXMciRH6fvBX9J37KwsF+BHh+2sJVkigs1iWRTkNtGMj1rnpVvZ4CpFPWTjf0V3b5v8jWdPmxEJPpe3q7L8jutN0PTtKULZ26qQMbzyx59assOc0/IHeuN+Nnx5+Ev7PHhA+PfjH45sdB0o3cNrHc30wXzZpXCJGo6sxYjgZNcJ0HXGVIhvkYADuTXyX/AMFfv+CmnhD/AIJzfsw3XjLTXj1Lxx4jk/srwLoMThpLq/lBVHx2VTzk8EgDvXmv/BU/9n74hftW3+j+KNI/aA8c6L8M9E0u4vdal8D61DY28LQ5Mkk8odZWYKGARSRnqM4r8Xf2dv2Wbf8A4KA/HXxV4oj+MPxI1b4b+Gdci03wTdalqbX2q6heO4aLyTcMURdoMuQQRjnBrqhgsTUqQhBXctldX+fb52MZV6MYyk3ot9/6fyP0I/4JX/8ABOv4hfEDxRda7+0BFfXvizxZNH4h+NHiu+jcT3E0mJYNIidukQUoWVfl+Qr7Vx3/AAd9/DfTvBXg34M/ELw1Y29nDpslxpFrBD8oijWJ5lRVHQAoK7WP/giR+15bxCKy/ap/aBt425eO28VWiZ+pEwzXzP8A8FaP+CSvxI/Zx/Yyvv2ifiJ8TviZ4gk8O6xBDJa+OvEg1CNo52EfmRqJHEbbnAzxXZjJYmph4U+VRpwWiUou7e8nZ6tv8LI58NGnGtKd25y6tNadFr2P1d/4Ih+JZ/FH7KOn6zcTbvtWg6I6tnO4/wBnxBv/AB7NfaIUnkCvy6/4NnvjPdfEH9lPQtHvHVXsdNur
                                    a4TP3WhujHEPr5QB+lfqMGHTNceMfPUjPvGP4JL9Doorli15v87i0UUVymw2V1Vck1/Lr8X/AIF/tea5/wAFdfjJ8Rfgdp2oeEVh+KmpTN481a18i0sLWRwDOrSgCXgHATJya/qIf+tfml8dIo9Z/wCCq1v4K1eNbrRplgebSblfMtXbn5jE2UJ9yK9jJcthmeL9nOTSSbdutunl6627HBmOMlg8PzxV29Dqf+CUv7C+jaRpWl/FbxFoFwnh/RNzeEbfVo/3+pXbnM2r3AbkyyEAqTyBnpX6CA4GKr6VbwWmnw2trAkcccarHHGoVVAHQAdBU0vB4rmzHFyxdbbljFWjFbJdv1b6s1weHWHp3bvKWrfdv9Oy6HN/Gv4PeBPj78Kde+DfxN0WPUdB8RadJZalZzLuV42Hv3BwR7iv54fjH/wT9/4KMf8ABCX9q1vj9+y9plx4u8GwXRksbyzR5RdWe7ItbuFfnZwD95AcY4Nf0j/wdO1cZ8dLW1n+GmrPPbRuyWrlCyA7T6j0rkpR9pUUe50SlyxbPzZ+Bv8AwdH/AAl8UeG47b40fsffFTw/4ghjC3Vva+GZ5oZnxyY8KWAz03c1l/tDf8Fjf2yP2qfB03g39j34H3Pwn0jUkaK4+InxIZYriKI8MbW0U+a8pHQFDWh4iJhtLy8iO2ZY3KzLww/HrW9/wSksbL4ifFLWpviDZxa61jNus21iMXRt2z1TzN20/TFfU4XhujOnKrUqNqKvZK1/nd2+48fEZrUpyUIxV31/4Bzf/BOv/gkpHqJk8Ua7Y6xa6DrFx9s8WeLdeyuteMZi24qc/NBbbudvyk8ZBr9VvDfh/RvCmhWvhvw7p8NpY2MKw2ttbxhUjRRgKAOgAqWEBbdVUYAAxjtxU6/dNeFjcdLFctKMVCnG9or8W31k+rf4I7sNhY0ZOcnzTla7f5JdEux+Sf8AwcQ/8EVfGf7Wdyn7ZX7L2jJe+NNM09bfxJ4eEixtrFumNkkbEgCWMDAyQMZ74r5f/wCCfH/Be39rn/gnr4Ej/Zp/a7/ZG8d+NNM0BfI0vUNK0iUX0Cj/AJZSSMojkC9AwJJ7k1/QQ6q4ZGXKleVPevz/AP2vre3Hxp1CzECeSuNsW0bRx6dKnA4P65Jx5rW8r/5Glet7FXtc8Tvv+Dmb4pfGHTJtA/ZV/wCCZnxKk8QPETb3PjWFLPT4z6yS5XAH17V434L+Cf7cf/BQL4/6d8Zf2uvE0fjjxJYP5nhL4b+HS3/CNeGWbrPdS8RzyxE/LhmOa7Lxpr2uRfHDw/oEWs3a2M90qzWS3DCGReOGTO0j6iv1r+CHhbwx4U+H9jaeFvDlhpsUkKtJHp9mkKs2OpCAZNe/WynD5PhYYup+8b2T0ivW12/vR5ix1bGVnQj7q6tav5dvxPzU/wCC8Y+LH7H/APwSF0v9nj4ewa5rereNvEUdh4k1TQbaWSWMyFrmdwIwWCM6bMejYrn/APg3c/Zxt/Dnw++HcPiTQZLNrDR9T1uTT9StTb3S3zXZjjdonAYBYpGVSR0NfpD+3BbW837NviK
                                    aa3jZ4YFeFmUEo24fMD2PuK+T/wDgi9fXuufEDxtqutXct5dQt5MNzdSGSRI9w+QM2SF9ulc2Bo1MRhcTmMp+8k1a382ja7b9jXEVIU6lLDKOmj37fmfomBjtXh//AAUb/ZasP2zv2MfH37PN3b+ZNrWiSHTV6f6ZH+8g5/66Kte4VG5Pm4r5tnrH88P/AAbtfGH41fsZ/tS+Kv2dPj78Pde0vRoLp5da1nU7CWC1028hXyWHmOAhjfBYYJJJB6V/Ql4f17R/EujWuv6Dfx3VneQrLb3ETZWRGGQRX5xf8FHgF/bS8J6GoxZajr1oNQs/+WV0MrxInR/xBr9GtAsLHStHtNP0yyht7eKFVjgt4wiIvoAOAK9nHZdHC5ZQr8zbnfTokrf5/wDAOChipVcZUpWso2+Zp0UUV4x3n//Z" & Chr(34) & " style=" & Chr(34) & "width: 66pt; height: 55.5pt;" & Chr(34) & " alt=" & Chr(34) & "image" & Chr(34) & "></span></p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style=" & Chr(34) & "width:305.1pt;padding:0cm 5.4pt 0cm 5.4pt;height:56.2pt;" & Chr(34) & ">
                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><strong><span style=" & Chr(34) & "font-size:16px;color:black;" & Chr(34) & ">نظام البريد التلقائي</span></strong></p>
                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><strong><span dir=" & Chr(34) & "LTR" & Chr(34) & " style=" & Chr(34) & "font-size:15px;color:black;" & Chr(34) & ">&nbsp;</span></strong></p>
                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:black;'>البريد الإلكتروني<em>:&nbsp;</em></span><em><span dir=" & Chr(34) & "LTR" & Chr(34) & " style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:black;'>&nbsp;</span></em><span dir=" & Chr(34) & "LTR" & Chr(34) & "><a href=" & Chr(34) & "mailto:voca-support@egyptpost.org" & Chr(34) & "><em><span style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:#0563C1;'>voca-support@egyptpost.org</span></em></a></span></p>
                    <p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:black;'>الموقع الإلكتروني<em>:&nbsp;</em></span><em><span dir=" & Chr(34) & "LTR" & Chr(34) & " style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:black;'>&nbsp;</span></em><span dir=" & Chr(34) & "LTR" & Chr(34) & "><a href=" & Chr(34) & "http://10.10.26.4:8000/vocaplus.aspx" & Chr(34) & "><em><span style='font-size:16px;font-family:" & Chr(34) & "Times New Roman" & Chr(34) & ",serif;color:#0563C1;'>http://10.10.26.4:8000/vocaplus.aspx</span></em></a></span></p>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:normal;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;'><span style=" & Chr(34) & "font-size:15px;color:black;" & Chr(34) & ">&nbsp;</span></p>
<p dir=" & Chr(34) & "RTL" & Chr(34) & " style='margin-top:0cm;margin-right:0cm;margin-bottom:8.0pt;margin-left:0cm;line-height:107%;font-size:15px;font-family:" & Chr(34) & "Calibri" & Chr(34) & ",sans-serif;text-align:right;'><span dir=" & Chr(34) & "LTR" & Chr(34) & ">&nbsp;</span></p>"
#End Region
        If Format(WW, "HH:mm:ss") < #1/1/0001 11:00:00 PM# And Format(WW, "HH:mm:ss") > #1/1/0001 09:00:00 AM# Then
            If Format(WW, "mm") = CombMin.Text Then
                If GetTbl("select * from AutoMail where AutoMail.MailRule = 'H'", MailTbl) = Nothing Then
                    If MailTbl.Rows.Count > 0 Then
                        Invoke(Sub() TxtErr.Text = Now & " :  Starting Auto Mail ..." & vbCrLf & TxtErr.Text)
                        Invoke(Sub() TxtErr.Refresh())
                        Try
                            Invoke(Sub() TxtErr.Text = Now & " :  Trying to send " & MailTbl.Rows.Count & " Mails ..." & vbCrLf & TxtErr.Text)
                            Invoke(Sub() TxtErr.Refresh())
                            For YY = 0 To MailTbl.Rows.Count - 1
                                Invoke(Sub() TxtErr.Text = Now & " :  Trying to send " & YY + 1 & " Of " & MailTbl.Rows.Count & " Mails ..." & vbCrLf & TxtErr.Text)
                                Invoke(Sub() TxtErr.Refresh())
                                Mail_.Slct_ = MailTbl.Rows(YY).Item(1).ToString
                                Mail_.To_ = MailTbl.Rows(YY).Item(2).ToString
                                Mail_.CC_ = MailTbl.Rows(YY).Item(3).ToString
                                Mail_.BCc_ = ""
                                Mail_.Sub_ = MailTbl.Rows(YY).Item(4).ToString & "_" & Format(WW, "HH") & "_" & Format(WW, "yyyy/MM/dd,dddd")
                                Mail_.Body_ = BdyStrt & MailTbl.Rows(YY).Item(5).ToString & Format(WW, "HH:mm") & BdyEnd
                                Invoke(Sub() TxtErr.Text = Now & " :  Exporting " & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                                Invoke(Sub() TxtErr.Refresh())
                                If Exprt(MailTbl.Rows(YY).Item(4).ToString & "_" & Format(Now, "yyMMdd")) = Nothing Then
                                    Invoke(Sub() TxtErr.Text = Now & " :  Sending Mail to " & Mail_.To_ & " ..." & vbCrLf & TxtErr.Text)
                                    Invoke(Sub() TxtErr.Refresh())
                                    If SndMail() = Nothing Then
                                        Invoke(Sub() TxtErr.Text = Now & " :  Mail to " & Mail_.To_ & " has been sent ..." & vbCrLf & TxtErr.Text)
                                        Invoke(Sub() TxtErr.Refresh())
                                    Else
                                        Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.To_ & vbCrLf & TxtErr.Text)
                                        Invoke(Sub() TxtErr.Refresh())
                                    End If
                                Else
                                    Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                                    Invoke(Sub() TxtErr.Refresh())
                                End If
                            Next
                        Catch exs As Exception
                            Invoke(Sub() TxtErr.Text = Now & " :  Error : " & exs.Message & vbCrLf & TxtErr.Text)
                            Invoke(Sub() TxtErr.Refresh())
                        End Try
                    Else
                        Invoke(Sub() TxtErr.Text = Now & " :  There Nothing To send ..." & vbCrLf & TxtErr.Text)
                        Invoke(Sub() TxtErr.Refresh())
                    End If
                Else
                    Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                    Invoke(Sub() TxtErr.Refresh())
                    Exit Sub
                End If
            End If
        ElseIf Format(WW, "HH:mm:ss") = #1/1/0001 11:00:00 PM# And Format(WW, "mm") = CombMin.Text Then
            If GetTbl("select * from AutoMail where AutoMail.MailRule = 'D'", MailTbl) = Nothing Then
                If MailTbl.Rows.Count > 0 Then
                    Invoke(Sub() TxtErr.Text = Now & " :  Starting Auto Mail ..." & vbCrLf & TxtErr.Text)
                    Invoke(Sub() TxtErr.Refresh())
                    Try
                        Invoke(Sub() TxtErr.Text = Now & " :  Trying to send " & MailTbl.Rows.Count & " Mails ..." & vbCrLf & TxtErr.Text)
                        Invoke(Sub() TxtErr.Refresh())
                        For YY = 0 To MailTbl.Rows.Count - 1
                            Invoke(Sub() TxtErr.Text = Now & " :  Trying to send " & YY + 1 & " Of " & MailTbl.Rows.Count & " Mails ..." & vbCrLf & TxtErr.Text)
                            Invoke(Sub() TxtErr.Refresh())
                            Mail_.Slct_ = MailTbl.Rows(YY).Item(1).ToString
                            Mail_.To_ = MailTbl.Rows(YY).Item(2).ToString
                            Mail_.CC_ = MailTbl.Rows(YY).Item(3).ToString
                            Mail_.BCc_ = ""
                            Mail_.Sub_ = MailTbl.Rows(YY).Item(4).ToString & "_" & Format(WW, "yyyy/MM/dd,dddd")
                            Mail_.Body_ = BdyStrt & MailTbl.Rows(YY).Item(5).ToString & BdyEnd
                            Invoke(Sub() TxtErr.Text = Now & " :  Exporting " & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                            Invoke(Sub() TxtErr.Refresh())
                            If Exprt(MailTbl.Rows(YY).Item(4).ToString & "_" & Format(Now, "yyMMdd")) = Nothing Then
                                Invoke(Sub() TxtErr.Text = Now & " :  Sending Mail to " & Mail_.To_ & " ..." & vbCrLf & TxtErr.Text)
                                Invoke(Sub() TxtErr.Refresh())
                                If SndMail() = Nothing Then
                                    Invoke(Sub() TxtErr.Text = Now & " :  Mail to " & Mail_.To_ & " has been sent ..." & vbCrLf & TxtErr.Text)
                                    Invoke(Sub() TxtErr.Refresh())
                                Else
                                    Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.To_ & vbCrLf & TxtErr.Text)
                                    Invoke(Sub() TxtErr.Refresh())
                                End If
                            Else
                                Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                                Invoke(Sub() TxtErr.Refresh())
                            End If
                        Next
                    Catch exs As Exception
                        Invoke(Sub() TxtErr.Text = Now & " :  Error : " & exs.Message & vbCrLf & TxtErr.Text)
                        Invoke(Sub() TxtErr.Refresh())
                    End Try
                Else
                    Exit Sub
                End If
            Else
                Invoke(Sub() TxtErr.Text = Now & " :  Error : " & ExrtErr & Mail_.Sub_ & vbCrLf & TxtErr.Text)
                Invoke(Sub() TxtErr.Refresh())
            End If
        End If

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'Dim GGTT As DateTime = Format(ServrTime(), "HH:mm:ss")

        WdysTable.Rows.Clear()
        If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate(),111) as Now_)", WdysTable) = Nothing Then
            If WdysTable.Rows(0).Item("HDy") = 1 Then
                If Format(WW, "HH:mm:ss") < #1/1/0001 04:00:00 PM# And Format(WW, "HH:mm:ss") > #1/1/0001 09:00:00 AM# Then
                    TimerEsc.Stop()
                    ''    DataGridView1.DataSource = ""
                    ''    EscAtoTable.Rows.Clear()
                    ''    If GetTbl("SELECT TkID, TkClNm, TkDtStart, TkRecieveDt, TkClsStatus, SrcNm, TkEscTyp, LstUpdtTime, TkupTxt, dbo.Int_user.UsrRealNm AS LstUpUsr, ProdKNm, PrdNm, CompNm, TkupEvtId, TkFolw, TkupSendEsc, TkupSQL FROM dbo.TicketsAll INNER JOIN dbo.TkEvent ON TkSQL = TkupTkSql INNER JOIN dbo.TicLstEv ON TkupSQL = dbo.TicLstEv.LstSqlEv INNER JOIN dbo.CDEvent ON TkupEvtId = dbo.CDEvent.EvId INNER JOIN dbo.Int_user ON TkupUser = dbo.Int_user.UsrId
                    ''WHERE (TkupEvtId = 902) OR (TkupEvtId = 903)", EscAtoTable) = Nothing Then
                    ''        If EscAtoTable.Rows.Count > 0 Then
                    ''            Invoke(Sub() DataGridView1.DataSource = EscAtoTable)
                    ''            For ggg As Integer = 0 To DataGridView1.Columns.Count - 1
                    ''                Invoke(Sub() DataGridView1.Columns(ggg).Width = 50)
                    ''            Next
                    ''            Invoke(Sub() DataGridView1.Columns(7).Width = 130)
                    ''        End If
                    ''    End If
                    Dim EsclTsk As New Thread(AddressOf EscSub)
                    EsclTsk.IsBackground = True
                    TimerEsc.Stop()
                    TimerSecnods.Stop()
                    EsclTsk.Start()
                Else
                    Span_ = TimeSpan.Parse("00:01:00")
                    nxt = " On " & Now.Add(TimeSpan.Parse("00:01:00"))
                    Invoke(Sub() TimerEsc.Start())
                End If
            Else

            End If
        End If
    End Sub
    Private Sub EscSub()
        Invoke(Sub() TxtErr.Text = Now & " :  Starting Job ............" & vbCrLf & TxtErr.Text)
        Invoke(Sub() TxtErr.Text = Now & " :  Get Esclation Data ..." & vbCrLf & TxtErr.Text)
        Invoke(Sub() DataGridView1.DataSource = Nothing)
        EscAtoTable.Rows.Clear()
        If GetTbl("SELECT TkID, TkClNm, TkDtStart, TkRecieveDt, TkClsStatus, SrcNm, TkEscTyp, LstUpdtTime, TkupTxt, dbo.Int_user.UsrRealNm AS LstUpUsr, ProdKNm, PrdNm, CompNm, TkupEvtId, TkFolw, TkupSendEsc, TkupSQL FROM dbo.TicketsAll INNER JOIN dbo.TkEvent ON TkSQL = TkupTkSql INNER JOIN dbo.TicLstEv ON TkupSQL = dbo.TicLstEv.LstSqlEv INNER JOIN dbo.CDEvent ON TkupEvtId = dbo.CDEvent.EvId INNER JOIN dbo.Int_user ON TkupUser = dbo.Int_user.UsrId
                WHERE (TkupEvtId = 902) OR (TkupEvtId = 903)", EscAtoTable) = Nothing Then
            Invoke(Sub() DataGridView1.DataSource = EscAtoTable)
            For ggg As Integer = 0 To DataGridView1.Columns.Count - 1
                Invoke(Sub() DataGridView1.Columns(ggg).Width = 50)
            Next
            Invoke(Sub() DataGridView1.Columns(7).Width = 130)
            If EscAtoTable.Rows.Count > 0 Then
                WdysTable.Rows.Clear()
                If GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = (Select CONVERT(nvarchar, GetDate(),111) as Now_)", WdysTable) = Nothing Then

                    For Cnt = 0 To EscAtoTable.Rows.Count - 1


                        Dim Minuts As Double
                        Dim MinutsDef As Integer
                        Invoke(Sub() TxtErr.Text = Now & " :  Trying With : " & Cnt + 1 & " Of " & EscAtoTable.Rows.Count & vbCrLf & TxtErr.Text)
                        Invoke(Sub() DataGridView2.DataSource = Nothing)
                        AcbDataTable.Rows.Clear()
                        Invoke(Sub() TxtErr.Text = Now & " : " & vbCrLf & "Trying To Get Data " & vbCrLf & TxtErr.Text)
                        If GetTbl("SELECT TkSQL, MAX(DISTINCT dbo.Int_user.UsrRealNm) AS UsrEsc, MAX(DISTINCT dbo.Int_user.UsrEmail) AS UsrEscEmail, MAX(DISTINCT Int_user_3.UsrRealNm) AS CSTL, MAX(DISTINCT Int_user_3.UsrEmail) 
                                 AS CSTLMail, Int_user_1.UsrRealNm AS FolwUsr, Int_user_1.UsrSisco AS CCFlwPh, Int_user_1.UsrEmail AS FLWMail, Int_user_2.UsrRealNm AS CCTL, Int_user_2.UsrEmail AS CCTLMail, 
                                 Int_user_2.UsrSisco AS CCTLPh, IntUserCat_1.UCatNm AS TeamNm, IntUserCat_1.UCatLvl AS CCUCatLvl
                                 FROM dbo.IntUserCat AS IntUserCat_1 INNER JOIN
                                 dbo.Int_user AS Int_user_1 INNER JOIN
                                 dbo.Tickets ON Int_user_1.UsrId = TkEmpNm ON IntUserCat_1.UCatId = Int_user_1.UsrCat INNER JOIN
                                 dbo.Int_user AS Int_user_2 ON IntUserCat_1.UCatIdSub = Int_user_2.UsrCat INNER JOIN
                                 dbo.TkEvent ON TkSQL = dbo.TkEvent.TkupTkSql INNER JOIN
                                 dbo.TicLstEv ON dbo.TkEvent.TkupSQL = dbo.TicLstEv.LstSqlEv INNER JOIN
                                 dbo.Int_user INNER JOIN
                                 dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                                 dbo.Int_user AS Int_user_3 ON dbo.IntUserCat.UCatIdSub = Int_user_3.UsrCat ON dbo.TkEvent.TkupUser = dbo.Int_user.UsrId
                                 GROUP BY TkSQL, Int_user_1.UsrRealNm, Int_user_1.UsrSisco, Int_user_1.UsrEmail, Int_user_2.UsrRealNm, Int_user_2.UsrEmail, Int_user_2.UsrSisco, IntUserCat_1.UCatNm,  IntUserCat_1.UCatLvl
                                 HAVING TkSQL = " & EscAtoTable.Rows(Cnt).Item("TkID"), AcbDataTable) = Nothing Then
                            Invoke(Sub() DataGridView2.DataSource = AcbDataTable)
                            Invoke(Sub() DataGridView1.Rows(Cnt).Selected = True)
                        Else
                            Invoke(Sub() TxtErr.Text = Now & " : " & "There is No Tickets " & vbCrLf & TxtErr.Text)
                            Exit Sub
                        End If
                        If EscAtoTable.Rows(Cnt).Item("TkFolw") = 0 Then FolwStr = "جديد : لم يتم عمل أي تحديثات من متابع الشكوى" Else FolwStr = ""

                        Invoke(Sub() TxtErr.Text = Now & " : " & "Esclatio 1 Of Ticket No.: " & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)

                        If EscAtoTable.Rows(Cnt).Item("TkupEvtId") = 902 Then
                            EscCnt = 1
                            Esc = "تم عمل متابعة 1 من خلال التطبيق"
                            Dim WW = ServrTime()
                            If EscAtoTable.Rows(Cnt).Item("TkupSendEsc") = False Then

                                If Format(WW, "HH:mm:ss") < #1/1/0001 04:00:00 PM# AndAlso Format(WW, "HH:mm:ss") > #1/1/0001 09:00:00 AM# AndAlso WdysTable.Rows(0).Item("HDy") = 1 Then
                                    WeekTable.Rows.Clear()
                                    GetTbl("select HDate, HDay, HDayW, HDy from CDHolDay where HDate = '" & Format(EscAtoTable.Rows(Cnt).Item("LstUpdtTime"), "yyyy/MM/dd") & "'", WeekTable)
                                    If EscAtoTable.Rows(Cnt).Item("LstUpdtTime") > #1/1/0001 04:00:00 PM# Or EscAtoTable.Rows(Cnt).Item("LstUpdtTime") < #1/1/0001 09:00:00 AM# Or WeekTable.Rows(0).Item("HDy") = 1 Then
                                        If InsTrans("update TkEvent Set TkupSendEsc = 1, TkupTxt = TkupTxt + Char(13)  + ' تم تعديل وقت تسجيل المتابعة من ' + CONVERT(VARCHAR, (select TkupSTime from TkEvent  where TkupSQL = " & EscAtoTable.Rows(Cnt).Item("TkupSQL") & ") , 120) + ' إلى الوقت الحالى', TkupSTime = (Select GetDate()) where TkupSQL = " & EscAtoTable.Rows(Cnt).Item("TkupSQL"),
                                                        "update Tickets set TkEscTyp = 1 Where TkSQL = " & EscAtoTable.Rows(Cnt).Item("TkID")) = Nothing Then
                                            SendMailEx(Cnt)
                                        Else
                                            Invoke(Sub() TxtErr.Text = Now & " : " & "Faild To Update Esclation Time Of Ticket No." & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)
                                        End If
                                    Else
                                        InsTrans("update TkEvent set TkupSendEsc = 1 where TkupSQL = " & EscAtoTable.Rows(Cnt).Item("TkupSQL"),
                                                        "update Tickets set TkEscTyp = 1 Where TkSQL = " & EscAtoTable.Rows(Cnt).Item("TkID"))
                                        SendMailEx(Cnt)
                                    End If
                                End If

                            ElseIf EscAtoTable.Rows(Cnt).Item("TkupSendEsc") = True Then
                                escTable.Rows.Clear()
                                GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscAtoTable.Rows(Cnt).Item("TkEscTyp"), escTable)
                                Minuts = WW.Subtract(EscAtoTable.Rows(Cnt).Item("LstUpdtTime")).TotalMinutes
                                MinutsDef = escTable.Rows(0).Item("EscDur") - Minuts
                                If Minuts > escTable.Rows(0).Item("EscDur") Then
                                    If EscAtoTable.Rows(Cnt).Item("TkEscTyp") = 1 Then
                                        Esc = "تم عمل متابعة 2 بشكل آلى من خلال التطبيق"
                                        EscID = 903
                                        EscCnt = 2
                                        Invoke(Sub() TxtErr.Text = Now & " : " & "Trying To Insert Update " & vbCrLf & TxtErr.Text)
                                        If InsTrans("update Tickets set TkEscTyp = " & EscCnt & " where (TkSQL = " & EscAtoTable.Rows(Cnt).Item("TkID") & ")",
                                                             "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser, TkupSendEsc) VALUES ('" & EscAtoTable.Rows(Cnt).Item("TkID") & "','" & Esc & "','" & "0" & "','" & EscID & "','" & OsIP() & "','" & "32000" & "','" & 1 & "')") = Nothing Then
                                            If SendMailEx(Cnt) = 0 Then                     ' Send Mail
                                                Invoke(Sub() TxtErr.Text = Now & " : " & "Escalation has been done " & vbCrLf & TxtErr.Text)
                                            Else
                                                Invoke(Sub() TxtErr.Text = Now & " : " & "Faild To Sending mail Of Ticket No." & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)
                                            End If
                                        Else
                                            Invoke(Sub() TxtErr.Text = Now & " : " & "Faild To insert Update and sending mail Of Ticket No." & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)
                                        End If
                                    End If
                                End If
                            End If
                        ElseIf EscAtoTable.Rows(Cnt).Item("TkupEvtId") = 903 Then
                            escTable.Rows.Clear()
                            GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & EscAtoTable.Rows(Cnt).Item("TkEscTyp"), escTable)
                            Minuts = ServrTime().Subtract(EscAtoTable.Rows(Cnt).Item("LstUpdtTime")).TotalMinutes
                            MinutsDef = escTable.Rows(0).Item("EscDur") - Minuts
                            If Minuts > escTable.Rows(0).Item("EscDur") Then
                                If EscAtoTable.Rows(Cnt).Item("TkEscTyp") = 2 Then
                                    Esc = "تم عمل متابعة 3 بشكل آلى من خلال التطبيق"
                                    EscID = 904
                                    EscCnt = 3
                                    Invoke(Sub() TxtErr.Text = Now & " : " & "Trying To Insert Update " & vbCrLf & TxtErr.Text)
                                    If InsTrans("update Tickets set TkEscTyp = " & EscCnt & " where (TkSQL = " & EscAtoTable.Rows(Cnt).Item("TkID") & ")",
                                                         "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser, TkupSendEsc) VALUES ('" & EscAtoTable.Rows(Cnt).Item("TkID") & "','" & Esc & "','" & "0" & "','" & EscID & "','" & OsIP() & "','" & "32000" & "','" & 1 & "')") = Nothing Then
                                        If SendMailEx(Cnt) = 0 Then                     ' Send Mail
                                            Invoke(Sub() TxtErr.Text = Now & " : " & "Escalation has been done " & vbCrLf & TxtErr.Text)
                                        Else
                                            Invoke(Sub() TxtErr.Text = Now & " : " & "Faild To Sending mail Of Ticket No." & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)
                                        End If
                                    Else
                                        Invoke(Sub() TxtErr.Text = Now & " : " & "Faild To insert Update and sending mail Of Ticket No." & EscAtoTable.Rows(Cnt).Item("TkID") & vbCrLf & TxtErr.Text)
                                    End If
                                End If
                            End If
                        End If
                        Esc = ""
                        EscCnt = 0
                        EscID = 0
                    Next Cnt
                End If
            Else
                'MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                'Exit Sub
            End If
        Else
            Invoke(Sub() TxtErr.Text = Now & " : Failed To Fill Esclation Table" & vbCrLf & TxtErr.Text)
        End If


        Invoke(Sub() TxtErr.Text = Now & " :  Job has been finished " & vbCrLf & TxtErr.Text)
        sqlCcon.Close()
        SqlConnection.ClearPool(sqlCcon)
        Span_ = TimeSpan.Parse("00:01:00")
        nxt = " On " & Now.Add(TimeSpan.Parse("00:01:00"))
        Invoke(Sub() CombHour.Text = Now.Hour)
        Invoke(Sub() TimerEsc.Start())
        Invoke(Sub() TimerSecnods.Start())
        Invoke(Sub() TxtErr.Text = Now & " :  Waiting For Next Job" & nxt & vbCrLf & TxtErr.Text)
        Exit Sub
Done_:
        Invoke(Sub() TxtErr.Text = Now & " :  Job has been finished : " & vbCrLf & TxtErr.Text)
        Span_ = TimeSpan.Parse("00:01:00")
        nxt = " On " & Now.Add(TimeSpan.Parse("00:01:00"))
        Invoke(Sub() TimerEsc.Start())
        Invoke(Sub() TimerSecnods.Start())
        Invoke(Sub() LblTimer.Text = "Next Job Will Be After : " & (Span_ - TimeSpan.Parse("00:00:01")).ToString & nxt)
    End Sub
    Private Function SndMail() As String
        ExrtErr = Nothing


        Try
            Dim exchange As ExchangeService
            exchange = New ExchangeService(ExchangeVersion.Exchange2010)
            exchange.Credentials = New WebCredentials(My.Settings.MlUsr, My.Settings.MlPss)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Dim message As New EmailMessage(exchange)
            For LL = 0 To Split(Mail_.To_, ";").Count - 1
                message.ToRecipients.Add(Trim(Split(Mail_.To_, ";")(LL)))
            Next
            For LL = 0 To Split(Mail_.CC_, ";").Count - 1
                message.CcRecipients.Add(Trim(Split(Mail_.CC_, ";")(LL)))
            Next

            message.Subject = Mail_.Sub_
            message.Body = Mail_.Body_
            message.Attachments.AddFileAttachment(FileExported)
            message.Attachments(0).ContentId = Mail_.Sub_ & "_" & Format(Now, "yyyy-MM-dd")
            message.Importance = 1

            message.SendAndSaveCopy()
        Catch exs As Exception
            ExrtErr = exs.Message
        End Try
        Return ExrtErr
    End Function
    Private Function Exprt(FileNm As String) As String
        ExrtErr = Nothing
        FileExported = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & FileNm & ".xlsx"

        Dim Workbook As New XLWorkbook

        For JJ = 0 To Split(Mail_.Slct_, "$").Count - 1
            ExpoTbl = New DataTable
            If GetTbl(Split(Mail_.Slct_, "$")(JJ), ExpoTbl) = Nothing Then
                'If ExpoTbl.Rows.Count > 0 Then
                ExpoTbl.Rows.Add()
                'For UU = 0 To ExpoTbl.Columns.Count - 1
                '    If ExpoTbl.Columns(UU).DataType.Name.ToString = "Int32" Then
                '        ExpoTbl.Rows(ExpoTbl.Rows.Count - 1).Item(UU) = Convert.ToInt32(ExpoTbl.Compute("SUM(" & ExpoTbl.Columns(UU).ColumnName & ")", String.Empty))
                '    End If
                'Next
                Workbook.Worksheets.Add(ExpoTbl, FileNm & JJ + 1)
                'End If
            End If
        Next
        Try
            Workbook.SaveAs(FileExported)
            Workbook.Dispose()
            Dim XLApp As New Microsoft.Office.Interop.Excel.Application
            Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook = XLApp.Workbooks.Open(FileExported)
            Dim XLWrkSht As New Microsoft.Office.Interop.Excel.Worksheet
            Try
                Dim MMM As Integer = XLWrkBk.Sheets.Count
                XLWrkSht = CType(XLWrkBk.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                XLWrkSht.Activate()
                XLWrkSht.Range("A:Z").WrapText = False
                ExpoTbl.Dispose()
                XLWrkBk.Save()
                XLWrkBk.Close()
                XLApp.Quit()
            Catch ex As Exception
                ExrtErr = ex.Message
            End Try
            XLApp = Nothing
            XLWrkBk = Nothing
            XLWrkSht = Nothing
        Catch ex As Exception
            ExrtErr = ex.Message
        End Try
        Return ExrtErr
    End Function

    Private Sub BtnAbort_Click(sender As Object, e As EventArgs) Handles BtnAbort.Click
        Settings_.ShowDialog()
    End Sub
End Class