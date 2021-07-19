
Imports System.Net
Imports System.IO
Public Class HeldPaperRePrint
    Dim hldID As Integer
    Dim Ext As String
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    Dim Directry As String = "ftp://10.10.26.4/AirportPaperWorkRecieved/"
    'Dim sqlCConCCSYS As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=voca;Password=asdasdasD123") ' I Have assigned conn STR here and delete this row from all project
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub HeldPapeCnt_eciev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        GridHeldUpdt.Columns.Add("م", "م")                                 '0
        GridHeldUpdt.Columns.Add("RsvUpdate_time", "تاريخ التحديث")       '1
        GridHeldUpdt.Columns.Add("RsvUpdateTxt", "نص التحديث")            '2
        GridHeldUpdt.Columns.Add("User_RealName", "محرر التحديث")         '3
        GridHeldUpdt.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeldUpdt.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub GetUpdtEvent()
        UpdtHeldTbl.Rows.Clear()
        If GetTbl("SELECT RsvRelationID, RsvUpdate_time, RsvUpdateTxt, Int_user.UsrRealNm FROM Int_user INNER JOIN RsvUpdate ON Int_user.Usrid = RsvUpdateUser INNER JOIN Rsv ON RsvRelationID =  dbo.Rsv.RsvID where RsvRelationID = " & hldID & " ORDER BY RsvUpdate_time DESC", UpdtHeldTbl, "0000&H") = Nothing Then
            If UpdtHeldTbl.Rows.Count > 0 Then
                GridHeldUpdt.Rows.Clear()
                For Cnt_ = 0 To UpdtHeldTbl.Rows.Count - 1
                    GridHeldUpdt.Rows.Add()
                    GridHeldUpdt.Rows(Cnt_).Cells(0).Value = Cnt_ + 1
                    GridHeldUpdt.Rows(Cnt_).Cells(1).Value = UpdtHeldTbl(Cnt_).Item(1).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(2).Value = UpdtHeldTbl(Cnt_).Item(2).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(3).Value = UpdtHeldTbl(Cnt_).Item(3).ToString
                Next
                GridHeldUpdt.AutoResizeColumns()
                GridHeldUpdt.Columns(2).Width = 350
                GridHeldUpdt.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                GridHeldUpdt.AutoResizeRows()
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub TxtUpdt_KeyPress(sender As Object, e As KeyPressEventArgs)
        IntUtly.ValdtIntLetter(e)
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtTrck_TextChanged(sender As Object, e As EventArgs) Handles TxtTrck.TextChanged
        If TxtTrck.TextLength = 13 Then
            FillHldtable()
        Else
            TxtDt.Text = ""
            TxtPh.Text = ""
            TxtNm.Text = ""
            TxtAdd.Text = ""
            TxtOrgin.Text = ""
            TxtWieght.Text = ""
            TxtDoc.Text = ""
            TxtReason.Text = ""
            hldID = 0
            LblStat.Text = ""
            GridHeldUpdt.Rows.Clear()
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("1", "اسم المستند")
            DataGridView1.Columns.Add("2", "تم التنزيل")
        End If
    End Sub
    Private Sub FillHldtable()
        Lblmssg.Text = "جاري تحميل البيانات ........"
        Lblmssg.Refresh()
        '                   0           1         2     3          4        5         6           7           8       9       10        11      12          13      14      15                                      16                                        17         18         19        20          21          22                          23                              
        HeldTable.Rows.Clear()
        If GetTbl("SELECT Rsv_Days, Store_Name, RsvID, RsvNo, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDate, RsvType, RsvType1, RsvDoc, RsvEmpNm, CASE WHEN RsvStr > 5 THEN 'رمسيس' ELSE 'مطار القاهرة'END As Location, RsvRec, RsvPrintPaper, RsvOut,Phonefailure, RsvStart, Rsv_ad_Date,  MONTH(RsvDate) AS Month, YEAR(RsvDate) AS Year FROM Rsv INNER JOIN Int_user ON RsvEmpNm = Usrid INNER JOIN CDCountry ON RsvOrgin = CDCountry.CounCd INNER JOIN Stores ON RsvStr = Store_No WHERE (YEAR(RsvDate) > 2018) AND RsvTracing = '" & TxtTrck.Text & "' ORDER BY RsvDate", HeldTable, "0000&H") = Nothing Then
            If HeldTable.Rows.Count > 0 Then
                If HeldTable.Rows.Count > 1 Then
                    Me.BackColor = Color.Aqua
                    ComboBox2.Enabled = True
                Else
                    ComboBox2.Enabled = False
                    Me.BackColor = Color.White
                End If
                ComboBox2.Items.Clear()
                For Cnt_ = 0 To HeldTable.Rows.Count - 1
                    ComboBox2.Items.Add(Cnt_ + 1)
                Next
                ComboBox2.SelectedIndex = 0
                TxtDt.Text = HeldTable.Rows(0).Item(11).ToString
                TxtPh.Text = HeldTable.Rows(0).Item(9).ToString
                TxtNm.Text = HeldTable.Rows(0).Item(7).ToString
                TxtAdd.Text = HeldTable.Rows(0).Item(8).ToString
                TxtOrgin.Text = HeldTable.Rows(0).Item(5).ToString
                TxtWieght.Text = HeldTable.Rows(0).Item(6).ToString
                TxtDoc.Text = HeldTable.Rows(0).Item(10).ToString
                TxtReason.Text = HeldTable.Rows(0).Item(14).ToString
                hldID = HeldTable.Rows(0).Item(2).ToString
                If HeldTable.Rows(0).Item(17) = 0 Then
                    LblStat.Text = "لم يتم تسجيل استلام الأوراق"
                    LblStat.ForeColor = Color.Red
                Else
                    LblStat.Text = "تم تسجيل استلام الأوراق"
                    LblStat.ForeColor = Color.Green
                End If
                If HeldTable.Rows(0).Item(21) = 0 Then
                    LblClint.Text = "لم يتم تسجيل حضور العميل"
                    LblClint.ForeColor = Color.Red
                Else
                    LblClint.Text = "تم تسجيل حضور العميل"
                    LblClint.ForeColor = Color.Green
                End If
                GetUpdtEvent()
                Gett()
                Lblmssg.Text = ""
            Else
                TxtDt.Text = ""
                TxtPh.Text = ""
                TxtNm.Text = ""
                TxtAdd.Text = ""
                TxtOrgin.Text = ""
                TxtWieght.Text = ""
                TxtDoc.Text = ""
                TxtReason.Text = ""
                hldID = 0
                LblStat.Text = ""
                GridHeldUpdt.Rows.Clear()
                MsgInf("لا توجد شحنة مسجلة بهذا الرقم" & vbCrLf & "برجاء التأكد من رقم الشحنة")
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub Gett()
        Dim FTPReq As FtpWebRequest = DirectCast(WebRequest.Create(Directry & TxtTrck.Text & "/"), FtpWebRequest)
        'Upddate property
        FTPReq.Credentials = New NetworkCredential("Airport", "asdasdasD123")
        FTPReq.Method = WebRequestMethods.Ftp.ListDirectory
        Try
            FTPReq.GetResponse()
            FTPReq.Abort()
        Catch ex As Exception

            Exit Sub
        End Try
        Dim lol As String
        Dim arr() As String

        Dim request As FtpWebRequest = WebRequest.Create(Directry & TxtTrck.Text & "/")
        request.Credentials = New NetworkCredential("Airport", "asdasdasD123")
        request.Method = WebRequestMethods.Ftp.ListDirectory
        request.Timeout = 20000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            responseStream.ReadTimeout = 20000
            Dim reader As StreamReader = New StreamReader(responseStream)


            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("1", "اسم المستند")
            DataGridView1.Columns.Add("2", "تم التنزيل")
            DataGridView1.Columns(1).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            DataGridView1.Columns(1).DefaultCellStyle.ForeColor = Color.Green
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Do
                lol = reader.ReadLine
                If Len(lol) < 1 Then Exit Do
                arr = Split(lol, vbNewLine)
                For i = 0 To Split(lol, vbNewLine).Count - 1
                    If Len(arr(i)) > 0 Then
                        DataGridView1.Rows.Add(arr(i))
                    End If
                Next
            Loop
            reader.Close()
            response.Close()
        Catch ex As Exception
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try
    End Sub
    Private Sub insrtUpdt()
        If InsUpd("INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) values (" & hldID & ",'" & "تـــم إعادة طباعة أوراق التخليص " & Chr(34) & Split(DataGridView1.CurrentRow.Cells(0).Value, "_")(0) & Chr(34) & "'," & Usr.PUsrID & ",'" & 1 & "','" & OsIP() & "') ", "0000&H") = Nothing Then

        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Lblmssg.Text = "جاري تحميل البيانات ........"
        Lblmssg.Refresh()
        If HeldTable.Rows.Count > 0 Then
            TxtDt.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(11).ToString
            TxtPh.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(9).ToString
            TxtNm.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(7).ToString
            TxtAdd.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(8).ToString
            TxtOrgin.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(5).ToString
            TxtWieght.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(6).ToString
            TxtDoc.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(10).ToString
            TxtReason.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(14).ToString
            hldID = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(2).ToString
            If HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(17) = 0 Then
                LblStat.Text = "لم يتم تسجيل استلام الأوراق"
                LblStat.ForeColor = Color.Red
            Else
                LblStat.Text = "تم تسجيل استلام الأوراق"
                LblStat.ForeColor = Color.Green
            End If
            If HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(21) = 0 Then
                LblClint.Text = "لم يتم تسجيل حضور العميل"
                LblClint.ForeColor = Color.Red
            Else
                LblClint.Text = "تم تسجيل حضور العميل"
                LblClint.ForeColor = Color.Green
            End If
            GetUpdtEvent()
            Gett()
            Lblmssg.Text = ""
        Else
            TxtDt.Text = ""
            TxtPh.Text = ""
            TxtNm.Text = ""
            TxtAdd.Text = ""
            TxtOrgin.Text = ""
            TxtWieght.Text = ""
            TxtDoc.Text = ""
            TxtReason.Text = ""
            hldID = 0
            LblStat.Text = ""
            GridHeldUpdt.Rows.Clear()
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("1", "اسم المستند")
            DataGridView1.Columns.Add("2", "تم التنزيل")
        End If

    End Sub
    Private Sub BtnDwnld_Click(sender As Object, e As EventArgs) Handles BtnDwnld.Click
        'If ListBox1.SelectedIndex <> -1 Then
        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            insrtUpdt()
            GetUpdtEvent()
            Lblmssg.Text = "جاري التنزيل ........"
            Lblmssg.Refresh()
            Lblmssg.ForeColor = Color.Green
            Dim request As FtpWebRequest = WebRequest.Create(Directry & TxtTrck.Text & "/" & DataGridView1.CurrentRow.Cells(0).Value)
            request.Credentials = New NetworkCredential("Airport", "asdasdasD123")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 20000
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream(),
                                            fileStream As Stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)
                Dim buffer As Byte() = New Byte(10240 - 1) {}
                Dim read As Integer
                Do
                    read = ftpStream.Read(buffer, 0, buffer.Length)
                    If read > 0 Then
                        fileStream.Write(buffer, 0, read)
                    End If
                Loop While read > 0
                request.Abort()
                ftpStream.Close()
                ftpStream.Dispose()
                fileStream.Close()
                fileStream.Dispose()
                Lblmssg.Text = "تم تنزيل الملف بنجاح"
                Lblmssg.ForeColor = Color.Green
                DataGridView1.CurrentRow.Cells(1).Value = "✔"
                If CheckBox1.Checked = True Then
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)
                End If
                BtnOpn.Enabled = True
            Catch ex As Exception
                Lblmssg.Text = ""
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End Try
        Else
            Lblmssg.Text = "لا يمكن تنزيل المجلد"
            Lblmssg.ForeColor = Color.Red
        End If
    End Sub
    Private Sub BtnOpn_Click(sender As Object, e As EventArgs) Handles BtnOpn.Click
        Try
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)
        Catch ex As Exception
            MsgInf("لم يتم العثور على الملف" & vbCrLf & "برجاء تأكد من تنزيل الملف وأعد المحاوله")
        End Try

    End Sub
End Class