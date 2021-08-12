Imports System.IO
Imports System.Net
Public Class TikUpdate
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim Ext As String
    Dim FileName As String
    Dim EscTable As New DataTable
    Dim UpGetSql As New DataTable
    Dim UpSQlMax_ As Integer = 0
    Private Sub TikUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        Me.Size = New Point(screenWidth, screenHeight - 120)
        GridUpdt.Size = New Point(Me.Size.Width, Me.Size.Height - 185)
        If StruGrdTk.Tick = 0 Then
            CmbEvent.Enabled = False
            BtnSubmt.Enabled = False
            TxtUpdt.Text = ""
            TxtUpdt.ReadOnly = True
            MsgInf("لا يمكن عمل تحديث على الاستفسار")
            Me.Close()
            Exit Sub
        Else
            CmbEvent.Enabled = True
            BtnSubmt.Enabled = True
            If TxtUpdt.TextLength = 0 Then
                TxtUpdt.ReadOnly = True
            End If
            LblMsg.Text = ""
        End If
        CmbEvent.DataSource = UpdateKTable
        CmbEvent.DisplayMember = "EvNm"
        CmbEvent.ValueMember = "EvId"
        CmbEvent.SelectedIndex = -1
        TxtUpdt.ReadOnly = True
        UpdtCurrTbl.DefaultView.RowFilter = "[TkupTkSql]" & " = " & StruGrdTk.Sql
        GridUpdt.DataSource = UpdtCurrTbl.DefaultView
        Dim FolwID As String = ""
        If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
        UpdateFormt(GridUpdt, FolwID)
        Me.Text = "تحديثات شكوى رقم " & StruGrdTk.Sql
        CompareDataTables(FTPTable, UpdtCurrTbl, GridUpdt)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
        If Usr.PUsrUCatLvl < 3 Or Usr.PUsrUCatLvl > 5 Then
            If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
                TimerEscOpen.Start()
            Else
                TimerEscOpen.Stop()
            End If
        End If
        'StruGrdTk.LstUpEvId

    End Sub
    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        Dim EsStr As String = ""
        Dim Done_ As String = Nothing
        If CmbEvent.SelectedIndex > -1 Then
            If TxtUpdt.TextLength > 0 Then
                If Usr.PUsrID = StruGrdTk.UserId Then
                    If PublicCode.InsTrans("update Tickets set TkFolw = 1, TkEscTyp = 0" & " where (TkSQL = " & StruGrdTk.Sql & ");", "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & TxtUpdt.Text & "','" & "1" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1034&H") = Nothing Then
                        Done_ = "Done"
                    End If
                Else
                    If CmbEvent.SelectedValue = 902 Then
                        If PublicCode.InsUpd("update Tickets set TkEscTyp = 1" & " where (TkSQL = " & StruGrdTk.Sql & ");", "1034&H") = Nothing Then
                            If StruGrdTk.FlwStat = 0 Then
                                EsStr = "متابعه 1 جديد" & vbCrLf & TxtUpdt.Text
                            Else
                                EsStr = "متابعه 1" & vbCrLf & TxtUpdt.Text
                            End If
                        End If
                    Else
                        EsStr = TxtUpdt.Text
                    End If
                    If PublicCode.InsUpd("insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StruGrdTk.Sql & "','" & Trim(EsStr) & "','" & "0" & "','" & CmbEvent.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1034&H") = Nothing Then
                        Done_ = "Done"
                    End If
                End If
                If Done_ <> Nothing Then
                    LblMsg.Text = ("تم إضافة التحديث بنجاح")
                    LblMsg.ForeColor = Color.Green
                    StruGrdTk.LstUpDt = Now
                    StruGrdTk.LstUpTxt = TxtUpdt.Text
                    StruGrdTk.LstUpUsrNm = Usr.PUsrRlNm
                    StruGrdTk.LstUpEvId = CmbEvent.SelectedValue
                    If StruGrdTk.LstUpSys = True Then StruGrdTk.LstUpSys = False
                    '                       TkupSTime,              TkupTxt,     UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread

                    GetUpdtEvnt_()
                    UpSQlMax_ = UpGetSql.Rows(0).Item("TkupSQL")

                    UpdtCurrTbl.Rows.Add(StruGrdTk.LstUpDt, StruGrdTk.LstUpTxt, Usr.PUsrRlNm, Now, Usr.PUsrID, UpSQlMax_, StruGrdTk.Sql, CmbEvent.SelectedValue, 0, Usr.PUsrUCatLvl, 0)
                    UpdtCurrTbl.DefaultView.Sort = "TkupSTime Desc"
                    GridUpdt.Rows(0).Cells("TkupReDt").Value = ""

                    GridUpdt.DataSource = UpGetSql

                    Dim FolwID As String = ""
                    If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
                    UpdateFormt(GridUpdt, FolwID)
                    'GridUpdt.Rows(0).Selected = True             'Select Row(0) Before upload to get SQL As file Name
                    If TxtBrws.TextLength > 0 Then               ' Upload File If TxtBrws is have file
                        If UpSQlMax_ > 0 Then
                            CompareDataTables(FTPTable, UpdtCurrTbl, GridUpdt)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                            Uploadsub()
                        End If
                    Else
                        CompareDataTables(FTPTable, UpdtCurrTbl, GridUpdt)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                    End If
                    CmbEvent.SelectedIndex = -1
                    TxtUpdt.Text = ""
                    TxtUpdt.ReadOnly = True

                    If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
                        CmbEvent.Enabled = False
                        TimerEscOpen.Start()
                    Else
                        CmbEvent.Enabled = True
                        TimerEscOpen.Stop()
                    End If
                Else
                    MsgErr("Error : " & Errmsg)
                End If

            Else
                Beep()
                LblMsg.Text = ("برجاء كتابة نص التحديث")
                LblMsg.ForeColor = Color.Red
            End If
        Else
            Beep()
            LblMsg.Text = ("برجاء اختيار نوع التحديث")
            LblMsg.ForeColor = Color.Red
        End If
    End Sub
    Private Sub GetUpdtEvnt_()
        UpGetSql = New DataTable
        '                                 0        1         2         3         4        5        6         7         8         9
        If PublicCode.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( TkupTkSql = " & StruGrdTk.Sql & ") ORDER BY TkupTkSql,TkupSQL DESC", UpGetSql, "1019&H") = Nothing Then
            UpGetSql.Columns.Add("File")        ' Add files Columns 
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub CompareDataTables(ByVal dt1 As DataTable, ByVal dt2 As DataTable, GridUpdate As DataGridView)
        Dim Results =
            (From table1 In dt1
             Join table2 In dt2 On table1.Field(Of Integer)("ID") Equals table2.Field(Of Integer)("TkupSQL")
             Where table1.Field(Of Integer)("ID") = table2.Field(Of Integer)("TkupSQL")
             Select table1)

        For Count = 0 To GridUpdate.Rows.Count - 1
            For Each row As DataRow In Results
                If row.ItemArray(0) = GridUpdate.Rows(Count).Cells("TkupSQL").Value Then
                    GridUpdate.Rows(Count).Cells(11).Value = "✔"
                    GridUpdate.Rows(Count).Cells(11).Tag = row.ItemArray(1)
                    GridUpdate.Rows(Count).Cells(11).ToolTipText = row.ItemArray(3) & "-" & row.ItemArray(4) & "-" & row.ItemArray(2)
                    Exit For
                End If
            Next
        Next
        GridUpdate.Columns(11).DefaultCellStyle.ForeColor = Color.Green
        GridUpdate.Columns(11).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridUpdate.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub 'Compare attached Table With Update Table
    Private Sub Uploadsub()
        LblMsg.Text = "جاري التحميل ...."
        LblMsg.Refresh()
        'Create Req
        If CheckIfFtpFileExists("ftp://10.10.26.4/CompUpdates/") = False Then
            Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create("ftp://10.10.26.4/CompUpdates/" & UpSQlMax_ & "." & Ext), FtpWebRequest)
            'Upddate property
            mReq.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            mReq.Method = WebRequestMethods.Ftp.UploadFile
            mReq.Timeout = 20000
            'Read file
            Dim MFile() As Byte = File.ReadAllBytes(TxtBrws.Text)
            Me.Enabled = False
            Try
                'Upload
                Dim mStream As Stream = mReq.GetRequestStream()
                mStream.ReadTimeout = 2000
                mStream.Write(MFile, 0, MFile.Length)
                'CleanUp
                mStream.Close()
                mStream.Dispose()
                LblMsg.Text = "تم التحميل بنجاح"
                LblMsg.ForeColor = Color.Green
                TxtBrws.Text = ""
                Dim NewRow As DataRow = FTPTable.NewRow()
                Dim fi As New FileInfo(fd.FileName)
                NewRow("ID") = UpSQlMax_
                NewRow("Name") = UpSQlMax_ & "." & Ext
                NewRow("Date Modified") = Nw
                NewRow("Type") = Ext
                NewRow("Size") = (fi.Length / 1024).ToString("N0") & " KB"
                FTPTable.Rows.Add(NewRow)
                CompareDataTables(FTPTable, UpdtCurrTbl, GridUpdt)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
                Me.Enabled = True
            Catch exs As Exception
                Me.Enabled = True
                LblMsg.Text = ""
                MsgInf("لم يكتمل تحميل الملف بنجاح" & vbCrLf & exs.Message)
            End Try
        Else
            MsgInf("تم تحميل الملف من قبل")
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
    Private Sub Dowload()
        If Split(GridUpdt.CurrentRow.Cells("File").Tag, ".").Count > 1 Then
            LblMsg.Text = "جاري التنزيل ........"
            LblMsg.Refresh()
            LblMsg.ForeColor = Color.Green
            Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/CompUpdates/" & GridUpdt.CurrentRow.Cells("File").Tag)
            request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 20000
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream(),
fileStream As Stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & StruGrdTk.TkId & "_" & GridUpdt.CurrentRow.Cells("File").Tag)

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
                LblMsg.Text = "تم تنزيل الملف بنجاح"
                LblMsg.ForeColor = Color.Green
                Dim Rslt As DialogResult
                Rslt = MessageBox.Show("تم التنزيل بنجاح إلى " & "MyDocuments" & vbCrLf & "هل تريد فتح الملف", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & StruGrdTk.TkId & "_" & GridUpdt.CurrentRow.Cells("File").Tag)
                End If
            Catch ex As Exception
                request.Abort()
                LblMsg.Text = ""
                MsgBox(ex.Message)
            End Try
        Else
            LblMsg.Text = "لا يمكن تنزيل المجلد"
        End If

    End Sub
    Private Sub CopyToolStripitem_Click(sender As Object, e As EventArgs)
        If Len(GridUpdt.CurrentCell.Value.ToString) > 0 Then Clipboard.SetText(GridUpdt.CurrentCell.Value)
    End Sub
    Private Sub DonlodAttchToolStripitem_Click(sender As Object, e As EventArgs) Handles DonlodAttchToolStripitem.Click
        Dowload()
    End Sub
    Private Sub UplodAtchToolStripitem_Click(sender As Object, e As EventArgs) Handles UplodAtchToolStripitem.Click
        Uploadsub()
        CompareDataTables(FTPTable, UpdtCurrTbl, GridUpdt)  ' Compare Attached Table With Updtes Table On SQL Column and File Name
    End Sub
    Private Sub GridUpdt_SelectionChanged(sender As Object, e As EventArgs)
        If GridUpdt.Rows.Count > 0 Then
            If GridUpdt.Columns.Count = 11 Then
                Dim subItem As New ToolStripMenuItem("Download Attached")
                ContextMenuStrip2.Enabled = True
                If DBNull.Value.Equals(GridUpdt.CurrentRow.Cells(10).Value) = False Then
                    If GridUpdt.CurrentRow.Cells(10).Value = "✔" Then
                        ContextMenuStrip2.Items(2).Enabled = True
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                Else
                    If GridUpdt.CurrentRow.Cells(4).Value = Usr.PUsrID Then
                        BtnBrws.Enabled = True
                        If TxtBrws.TextLength > 0 Then
                            ContextMenuStrip2.Items(1).Enabled = True
                        ElseIf TxtBrws.TextLength = 0 Then
                            ContextMenuStrip2.Items(1).Enabled = False
                        End If
                    Else
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                    ContextMenuStrip2.Items(2).Enabled = False
                End If
            End If
        End If


    End Sub
    Private Sub BtnBrws_Click(sender As Object, e As EventArgs) Handles BtnBrws.Click
        LblMsg.Text = ""
        fd.Title = "File Upload"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        fd.Filter = "All files(*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        Path.GetFileName(StrFileName)
        If fd.ShowDialog() = DialogResult.OK Then
            Dim fi As New FileInfo(fd.FileName)
            Dim size As Long = fi.Length
            If size > 2097152 Then
                MsgInf("حجم الملف لابد ان يكون أقل أو يساوى 2 MB" & vbCrLf & "حجم الملف = " & (size / 1024 / 1024).ToString("N2") & " MB")
                Exit Sub
            End If
            StrFileName = fd.FileName
            TxtBrws.Text = StrFileName
            FileName = Path.GetFileName(StrFileName)
            Ext = Split(Path.GetFileName(StrFileName), ".")(1)
            ContextMenuStrip2.Items(1).Enabled = True
        End If
    End Sub
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs) Handles TxtUpdt.Leave
        If TxtUpdt.TextLength = 0 Then
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub TxtUpdt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUpdt.KeyPress
        IntUtly.ValdtIntLetter(e)
    End Sub
    Private Sub CmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent.SelectedIndexChanged
        TxtUpdt.ReadOnly = False
        TxtUpdt.Focus()
        BtnBrws.Enabled = True
    End Sub
    Private Sub TimerEscOpen_Tick(sender As Object, e As EventArgs) Handles TimerEscOpen.Tick
        If EscTable.Rows.Count = 0 Then
            EscTable.Rows.Clear()
            GetTbl("select EscID, EscCC, EscDur from EscProcess where escID = " & StruGrdTk.LstUpEvId - 901, EscTable, "0000&H")
        End If
        Dim Minutws As DateTime = ServrTime()
        Dim Minuts As Double = ServrTime().Subtract(StruGrdTk.LstUpDt).TotalMinutes
        Dim MinutsDef As Integer = EscTable.Rows(0).Item("EscDur") - Minuts

        If StruGrdTk.LstUpEvId = 902 Or StruGrdTk.LstUpEvId = 903 Or StruGrdTk.LstUpEvId = 904 Then
            If Minuts < EscTable.Rows(0).Item("EscDur") Then
                LblMsg.Text = ("تم عمل متابعه 1 وسيتم الرد عليها خلال " & EscTable.Rows(0).Item("EscDur") & " متبقى " & MinutsDef & " دقيقة")
                LblMsg.Refresh()
                CmbEvent.Enabled = False
                BtnSubmt.Enabled = False
                TxtUpdt.Text = "لا يمكن عمل تحديث أثناء فترة المتابعه، ويتم السماح بإضافة تعديل إما بإنتهاء فترة المتابعه أو عمل تحديث من الخطوط الخلفية"
                TxtUpdt.Font = New Font("Times New Roman", 16, FontStyle.Regular)
                TxtUpdt.TextAlign = HorizontalAlignment.Center
                TxtUpdt.ReadOnly = True
                Exit Sub
            Else
                CmbEvent.Enabled = True
                BtnSubmt.Enabled = True
                TxtUpdt.Text = ""
                TxtUpdt.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                TxtUpdt.TextAlign = HorizontalAlignment.Left
                TxtUpdt.ReadOnly = False
            End If
        Else
            CmbEvent.Enabled = True
            BtnSubmt.Enabled = True
            TxtUpdt.Text = ""
            TxtUpdt.Font = New Font("Times New Roman", 14, FontStyle.Regular)
            TxtUpdt.TextAlign = HorizontalAlignment.Left
            TxtUpdt.ReadOnly = False
        End If
    End Sub
    Private Sub TikUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub GridUpdt_SelectionChanged_1(sender As Object, e As EventArgs) Handles GridUpdt.SelectionChanged
        If GridUpdt.Rows.Count > 0 Then
            If GridUpdt.Columns.Count = 12 Then
                Dim subItem As New ToolStripMenuItem("Download Attached")
                ContextMenuStrip2.Enabled = True
                If DBNull.Value.Equals(GridUpdt.CurrentRow.Cells("File").Value) = False Then
                    If GridUpdt.CurrentRow.Cells("File").Value = "✔" Then
                        ContextMenuStrip2.Items(2).Enabled = True
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                Else
                    If GridUpdt.CurrentRow.Cells("TkupUser").Value = Usr.PUsrID Then
                        BtnBrws.Enabled = True
                        If TxtBrws.TextLength > 0 Then
                            ContextMenuStrip2.Items(1).Enabled = True
                        ElseIf TxtBrws.TextLength = 0 Then
                            ContextMenuStrip2.Items(1).Enabled = False
                        End If
                    Else
                        ContextMenuStrip2.Items(1).Enabled = False
                        BtnBrws.Enabled = False
                    End If
                    ContextMenuStrip2.Items(2).Enabled = False
                End If
            End If
        End If
    End Sub
End Class