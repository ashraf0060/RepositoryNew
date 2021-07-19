Imports System.Net
Imports System.IO
Public Class HeldPaperPrint
    Dim hldID As Integer
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    'Dim sqlCon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=voca;Password=asdasdasD123") ' I Have assigned conn STR here and delete this row from all project
    Dim Directry As String = "ftp://10.10.26.4/AirportPaperWorkRecieved/"
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub HeldPaperPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        BtnOpen.Text = "الكل"
        Filgrid()
        BtnOpn.Enabled = False
    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).HeaderText = "م"
        GridHeld.Columns(1).HeaderText = "اسم القسم"
        GridHeld.Columns(2).Visible = False
        GridHeld.Columns(3).Visible = False
        GridHeld.Columns(4).HeaderText = "رقم الشحنة"
        GridHeld.Columns(5).HeaderText = "بلد المنشأ"
        GridHeld.Columns(6).Visible = False
        GridHeld.Columns(7).HeaderText = "اسم العميل"
        GridHeld.Columns(8).Visible = False
        GridHeld.Columns(9).Visible = False '.HeaderText = "رقم الموبايل"
        GridHeld.Columns(10).Visible = False
        GridHeld.Columns(11).HeaderText = "تاريخ الحجز"
        GridHeld.Columns(12).Visible = False
        GridHeld.Columns(13).HeaderText = "حالة الشحنة"
        GridHeld.Columns(14).Visible = False
        GridHeld.Columns(15).Visible = False
        GridHeld.Columns(16).Visible = False   '.HeaderText = "موقع الحجز"
        GridHeld.Columns(17).HeaderText = "اخطار تليفوني"
        GridHeld.Columns(18).HeaderText = "استلام الأوراق"
        GridHeld.Columns(19).HeaderText = "طباعة الأوراق"
        GridHeld.Columns(20).HeaderText = "استبعاد"
        GridHeld.Columns(21).Visible = False
        GridHeld.Columns(22).Visible = False

        GridHeld.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(17).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(17).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(18).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(18).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(19).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(19).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(20).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(20).DefaultCellStyle.ForeColor = Color.Red

        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridHeld.AutoResizeColumns()
        GridHeld.Columns(0).Width = 50
        GridHeld.Columns(1).Width = 70
        GridHeld.Columns(7).Width = 200
        GridHeld.Columns(17).Width = 50
        GridHeld.Columns(18).Width = 50
        GridHeld.Columns(19).Width = 50
        GridHeld.Columns(20).Width = 50

        LblMsg.Text = "تم تحميل  " & HeldTable.Rows.Count & " بيان"
        LblMsg.ForeColor = Color.Green
    End Sub
    Private Sub Filgrid()
        Dim primaryKey(0) As DataColumn
        Dim Str As String = ""
        '   Table                                                                    0        1           2     3         4           5           6          7       8        9        10        11       12       13        14       15                     16                                                                     17                                                        18                                                     19                                                                    20            21         22                23                24                  27                  
        If BtnOpen.SelectedItem = "الكل" Then
            Str = "SELECT ROW_NUMBER() Over (Order by RsvDate) As [S.N.],  Store_Name, RsvID, RsvNo, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDate, RsvType, RsvType1, RsvDoc, RsvEmpNm, CASE WHEN RsvStr > 5 THEN 'رمسيس' ELSE 'مطار القاهرة'END As Location, CASE WHEN RsvPHN = 1 THEN N'✔' ELSE '' END As RsvPHN, CASE WHEN RsvRec = 1 THEN N'✔' ELSE '' END As RsvRec, CASE WHEN RsvPrintPaper = 1 THEN N'✔' ELSE '' END As RsvPrintPaper, CASE WHEN RsvOut = 1 THEN N'✘' ELSE '' END As RsvOut, MONTH(RsvDate) AS Month, YEAR(RsvDate) AS Year FROM RsvRecivPaperPrint  WHERE (YEAR(RsvDate) > 2018) ORDER BY RsvDate"
        Else
            Str = "SELECT ROW_NUMBER() Over (Order by RsvDate) As [S.N.],  Store_Name, RsvID, RsvNo, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDate, RsvType, RsvType1, RsvDoc, RsvEmpNm, CASE WHEN RsvStr > 5 THEN 'رمسيس' ELSE 'مطار القاهرة'END As Location, CASE WHEN RsvPHN = 1 THEN N'✔' ELSE '' END As RsvPHN, CASE WHEN RsvRec = 1 THEN N'✔' ELSE '' END As RsvRec, CASE WHEN RsvPrintPaper = 1 THEN N'✔' ELSE '' END As RsvPrintPaper, CASE WHEN RsvOut = 1 THEN N'✘' ELSE '' END As RsvOut, MONTH(RsvDate) AS Month, YEAR(RsvDate) AS Year FROM RsvRecivPaperPrint  WHERE (YEAR(RsvDate) > 2018) AND RsvDoc LIKE '%" & BtnOpen.SelectedItem & "%' ORDER BY RsvDate"
        End If
        HeldTable.Rows.Clear()
        If GetTbl(Str, HeldTable, "0000&H") = Nothing Then
                If HeldTable.Rows.Count > 0 Then
                    GridHeld.DataSource = HeldTable
                GridPopulte()
                Gett()
            Else
                    LblMsg.Text = ("لا توجد شحنات للطباعة")
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnRefrsh.Click
        Filgrid()
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub Gett()
        Dim lol As String
        Dim arr() As String
        Dim request As FtpWebRequest = WebRequest.Create(Directry & GridHeld.CurrentRow.Cells(4).Value & "/")
        request.Credentials = New NetworkCredential("Airport", "asdasdasD123")
        request.Method = WebRequestMethods.Ftp.ListDirectory
        'request.Timeout = 20000
        Lblmssg.Text = "جاري تحميل البيانات ........"
        Lblmssg.Refresh()
        Lblmssg.ForeColor = Color.Green
        Try
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("1", "اسم المستند")
            DataGridView1.Columns.Add("2", "تم التنزيل")
            DataGridView1.Columns(1).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            DataGridView1.Columns(1).DefaultCellStyle.ForeColor = Color.Green
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim response As FtpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(responseStream)
            responseStream.ReadTimeout = 20000
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
            DataGridView1.AutoResizeColumns()
            Lblmssg.Text = ""
            reader.Close()
            reader.Dispose()
            response.Close()
            response.Dispose()
            responseStream.Close()
            responseStream.Dispose()
        Catch ex As Exception
            Lblmssg.Text = ""
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try
    End Sub
    Private Sub GridHeld_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridHeld.CellClick
        hldID = GridHeld.CurrentRow.Cells(2).Value
        Gett()
    End Sub
    Private Sub BtnDwnld_Click(sender As Object, e As EventArgs) Handles BtnDwnld.Click
        Dim Rslt As DialogResult
        'If ListBox1.SelectedIndex <> -1 Then
        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            If GridHeld.CurrentRow.Cells(19).Value = "" Then
                Rslt = MessageBox.Show("سيتم تسجيل طباعة الأوراق" & vbCrLf & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    UpdtStat()
                    insrtUpdt()
                    GridHeld.CurrentRow.Cells(19).Value = "✔"
                Else
                    Exit Sub
                End If
            End If
            Lblmssg.Text = "جاري التنزيل ........"
            Lblmssg.Refresh()
            Lblmssg.ForeColor = Color.Green
            Dim request As FtpWebRequest = WebRequest.Create(Directry & GridHeld.CurrentRow.Cells(4).Value & "/" & DataGridView1.CurrentRow.Cells(0).Value)
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
        'Else
        '    MsgInf("برجاء اختيار المستند المراد تنزيله")
        'End If
    End Sub
    Private Sub UpdtStat()
        If InsUpd("update Rsv set RsvPrintPaper = 1 where RsvID = " & hldID, "0000&H") = Nothing Then

        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub insrtUpdt()
        If InsUpd("INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) values ( '" & hldID & "','" & "تم تسجيل طباعة أوراق التخليص" & "'," & Usr.PUsrID & ",'" & 1 & "','" & OsIP() & "') ", "0000&H") = Nothing Then

        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub Download_Click_1(sender As Object, e As EventArgs) Handles Download.Click
        'To check this sub later
        Try
            Dim _request As FtpWebRequest = WebRequest.Create(Directry & GridHeld.CurrentRow.Cells(4).Value & "/" & DataGridView1.CurrentRow.Cells(0).Value)
            _request.KeepAlive = False
            _request.Method = WebRequestMethods.Ftp.DownloadFile
            _request.Credentials = New NetworkCredential("Airport", "asdasdasD123")
            Dim _response As FtpWebResponse = _request.GetResponse()
            Dim responseStream As Stream = _response.GetResponseStream()
            Dim fs As New FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value, FileMode.Create)
            responseStream.CopyTo(fs)
            responseStream.Close()
            _response.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Download Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BtnOpen.SelectedIndexChanged
        Filgrid()
    End Sub
    Private Sub BtnOpn_Click(sender As Object, e As EventArgs) Handles BtnOpn.Click
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.CurrentRow.Cells(1).Value = "" Then
            BtnOpn.Enabled = False
        Else
            BtnOpn.Enabled = True
        End If
    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridHeld.CurrentCell.Value)
    End Sub
End Class