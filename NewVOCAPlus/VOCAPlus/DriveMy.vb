Imports System.Net
Imports System.IO
Public Class DriveMy
    Dim FrsPopu As Boolean = False
    Dim MainDirectry As String = ""
    Dim Directry As String = ""
    Dim usrNm As String
    Dim usrPss As String
    Dim StrFileName As String
    Dim FileName As String
    Dim Ext As String
    Dim DirRow As DataRow                'Store Product Row filtered after Combo selection
    Dim FTPTable As DataTable = New DataTable
    Private ReadOnly SecNODESTHATMATCH As New List(Of TreeNode) 'Tree Search Function
    Private Sub DriveMy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim primaryKey(0) As DataColumn
        BtnSub(Me)
        FTPTable.Rows.Clear()
        FTPTable.Columns.Clear()
        CheckBox1.Enabled = False
        CheckBox1.BackColor = Color.Red
        CheckBox1.Text = "Limited User"
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات .................."
        If GetTbl("select FtpSql, FtpDir, FtpAdminUser, FtpReadUser from ftpusers", FTPTable, "0000&H") = Nothing Then
            primaryKey(0) = FTPTable.Columns("FtpSql")
            FTPTable.PrimaryKey = primaryKey
            CombDir.DataSource = FTPTable
            CombDir.DisplayMember = "FtpDir"
            CombDir.ValueMember = "FtpSql"
            CombDir.ResetText()

            AddHandler CombDir.SelectedIndexChanged, (AddressOf CombDir_SelectedIndexChanged)

            GroupBox1.Enabled = False
            DataGridView1.Enabled = False
            BtnBack.Enabled = False
            TxtUsrNm.Text = ""
            TxtUsrPass.Text = ""
            DataGridView1.Columns.Add("1", "Name")
            DataGridView1.Columns.Add("2", "Date Modified")
            DataGridView1.Columns.Add("3", "Type")
            DataGridView1.Columns.Add("4", "Size")
            DataGridView1.Columns(0).Width = 250
            DataGridView1.Columns(1).Width = 120
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 70
            Me.Text = "FTP - Discon.nected"
            WelcomeScreen.StatBrPnlAr.Text = ""
        Else
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
        End If
    End Sub
    Private Sub BtnLogn_Click(sender As Object, e As EventArgs) Handles BtnLogn.Click
        If CombDir.SelectedIndex = -1 Then
            MsgInf("برجاء اختيار اسم المكتبه الخاصه بك أولاً")
        Else
            TreeView1.Nodes(0).Text = CombDir.Text
            Gett()
            TreeView1.Nodes(0).Expand()
        End If
    End Sub
    Private Sub Gett()
        Lblmssg.Text = "جاري التحميل ........"
        Lblmssg.Refresh()
        usrNm = TxtUsrNm.Text
        usrPss = TxtUsrPass.Text
        Dim lol As String
        Dim arr() As String
        DataGridView1.Rows.Clear()
        Dim request As FtpWebRequest = WebRequest.Create(MainDirectry)
        request.Credentials = New NetworkCredential(usrNm, usrPss)
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
        request.Timeout = 10000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            responseStream.ReadTimeout = 20000
            Dim reader As StreamReader = New StreamReader(responseStream)
            If IsNothing(TreeView1.SelectedNode) = False Then
                If TreeView1.SelectedNode.Nodes.Count > 0 Then
                    TreeView1.SelectedNode.Nodes.Clear()
                End If
            End If

            Do
                lol = reader.ReadLine
                If Len(lol) < 1 Then Exit Do
                arr = Split(lol, vbNewLine)
                For i = 0 To Split(lol, vbNewLine).Count - 1
                    If Len(arr(i)) > 0 Then
                        Dim FilNm As String = 0
                        Dim FileDt As String = ""
                        Dim FileType As String = ""
                        Dim INT_ As Integer = Nothing
                        Dim FilSize As Double = 0
                        Dim FilSize2 As String = ""

                        If Split(arr(i), " ").Count > 1 Then
                            INT_ = Split(arr(i), " ").Count - 1
                            If (Split(arr(i), " ")(9)) = "<DIR>" Then
                                FileDt = (Split(arr(i), " ")(0)) & " " & (Split(arr(i), " ")(2))
                                FilNm = Trim(Split(arr(i), ">")(1))
                                FileType = "Folder"
                                FilSize = 0
                            ElseIf IsNumeric(Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)) = True Then
                                FileDt = (Split(arr(i), " ")(0)) & " " & (Split(arr(i), " ")(2))
                                FilSize = Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)
                                Dim dddeee As String = (FilSize).ToString.Length
                                FilNm = Mid(Trim(Mid(arr(i), 20, Len(arr(i)))), (FilSize).ToString.Length + 2)
                                FileType = "oooo"
                            End If
                            If FileType <> "Folder" Then
                                INT_ = Split(FilNm, ".").Count - 1
                                Dim tyrtr As String = Split(FilNm, ".")(INT_)
                                Select Case tyrtr
                                    Case "exe"
                                        FileType = "Application"
                                    Case "rar"
                                        FileType = "WinRAR archive"
                                    Case "xlsm"
                                        FileType = "Microsoft Excel Macro-Enabled Worksheet"
                                    Case "xlsx"
                                        FileType = "Microsoft Excel Worksheet"
                                    Case "jpg"
                                        FileType = "JPG File"
                                    Case "xls"
                                        FileType = "Microsoft Excel 97-2003"
                                    Case "pptx"
                                        FileType = "Microsoft PowerPoint Presentation"
                                    Case "accdb"
                                        FileType = "Microsoft Access"
                                    Case "doc"
                                        FileType = "Microsoft Word"
                                    Case "docx"
                                        FileType = "Microsoft Word"
                                    Case "csv"
                                        FileType = "Microsoft Excel Comma Separated Values File"
                                    Case "iso"
                                        FileType = "iso"
                                    Case "txt"
                                        FileType = "Text Document"
                                    Case "pdf"
                                        FileType = "PDF"
                                    Case "msg"
                                        FileType = "MSG File"
                                    Case "png"
                                        FileType = "PNG File"
                                    Case Else
                                        FileType = "Unknown"
                                End Select
                            End If
                            If FilSize > 0 Then
                                FilSize2 = (FilSize / 1024).ToString("N0") & " KB"
                            Else
                                FilSize2 = ""
                                If FrsPopu = False Then
                                    TreeView1.Nodes(0).Nodes.Add(FilNm, FilNm)
                                    'TreeView1.Nodes(0).Expand()

                                ElseIf IsNothing(TreeView1.SelectedNode) = False Then
                                    TreeView1.SelectedNode.Nodes.Add(FilNm, FilNm)
                                    TreeView1.SelectedNode.Expand()
                                End If
                            End If

                        End If
                        DataGridView1.Rows.Add(FilNm, FileDt, FileType, FilSize2)
                    End If
                Next
            Loop
            FrsPopu = True
            DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
            reader.Close()
            response.Close()
            'DataGridView1.AutoResizeColumns()
            Me.Text = "FTP - Connected"
            Label1.Text = UCase(Mid(MainDirectry, 18, Len(MainDirectry)))
            Label1.Refresh()
            Lblmssg.Text = ""
            Lblmssg.Refresh()
            GroupBox1.Enabled = True
            DataGridView1.Enabled = True
            CombDir.Enabled = False
            BtnLogn.Enabled = False
            If IsNothing(TreeView1.SelectedNode) = False Then
                TreeView1.SelectedNode.BackColor = Color.LightBlue
            End If
        Catch ex As Exception
            Lblmssg.Text = ""
            MainDirectry = "ftp://10.10.26.4/" & CombDir.Text
            BtnLogn.Enabled = True
            GroupBox1.Enabled = False
            DataGridView1.Enabled = False
            CombDir.Enabled = True
            Me.Text = "FTP - Disconnected"
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Dowload()
        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            Lblmssg.Text = "جاري التنزيل ........"
            Lblmssg.Refresh()
            Lblmssg.ForeColor = Color.Green
            Dim request As FtpWebRequest = WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value)
            request.Credentials = New NetworkCredential(usrNm, usrPss)
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 20000
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream(),
                                            fileStream As Stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)

                Dim buffer As Byte() = New Byte(10240 - 1) {}
                Dim read As Integer = 0
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
                Dim Rslt As DialogResult
                Rslt = MessageBox.Show("تم التنزيل بنجاح" & vbCrLf & "هل تريد فتح الملف", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DataGridView1.CurrentRow.Cells(0).Value)
                End If
            Catch ex As Exception
                request.Abort()
                Lblmssg.Text = ""
                MsgBox(ex.Message)
            End Try
        Else
            Lblmssg.Text = "لا يمكن تنزيل المجلد"
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        'Dim CurDir As String = Mid(MainDirectry, Len(CombDir.Text) + 18, Len(MainDirectry))
        'Dim Cnt_r As Integer = Split(CurDir, "/").Count - 2
        'Dim Dir As String = ""
        'For cnt = 0 To Split(CurDir, "/").Count - 3
        '    Dir &= Split(CurDir, "/")(cnt) & "/"
        'Next
        'Dim NewDir As String = Mid(Dir, 1, Len(Dir))
        'If NewDir = "/" Then
        '    BtnBack.Enabled = False
        'Else
        '    BtnBack.Enabled = True
        'End If
        'MainDirectry = "ftp://10.10.26.4/" & CombDir.Text & NewDir
        'Gett()
        '  MsgBox(Split(Directry, "/").Count & vbCrLf & Split(Directry, "/")(Split(Directry, "/").Count - 2) & vbCrLf & MainDirectry)
    End Sub
    Private Sub BtnBrws_Click(sender As Object, e As EventArgs) Handles BtnBrws.Click
        Lblmssg.Text = ""
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "File Upload"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        fd.Filter = "All Files (*.*)|*.*|All files(*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        Path.GetFileName(StrFileName)
        If fd.ShowDialog() = DialogResult.OK Then
            StrFileName = fd.FileName
            TextBox1.Text = StrFileName
            FileName = Path.GetFileName(StrFileName)
            Ext = Split(Path.GetFileName(StrFileName), ".")(1)
        End If
    End Sub
    Private Sub BtnUplod_Click(sender As Object, e As EventArgs) Handles BtnUplod.Click
        'Create Req
        Dim FTPReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry), FtpWebRequest)
        'Upddate property
        FTPReq.Credentials = New NetworkCredential(usrNm, usrPss)
        FTPReq.Method = WebRequestMethods.Ftp.ListDirectory
        FTPReq.Timeout = 20000
        Try
            FTPReq.GetResponse()
            FTPReq.Abort()
            Uploadsub()
            Gett()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Uploadsub()
        Lblmssg.Text = "جاري التحميل ...."
        Lblmssg.Refresh()
        'Create Req
        If CheckIfFtpFileExists(MainDirectry & FileName) = False Then
            Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & FileName), FtpWebRequest)
            'Upddate property
            mReq.Credentials = New NetworkCredential(usrNm, usrPss)
            mReq.Method = WebRequestMethods.Ftp.UploadFile
            mReq.Timeout = 20000
            'Read file
            Dim buffer As Byte() = New Byte(10240 - 1) {}
            Dim MFile() As Byte = File.ReadAllBytes(TextBox1.Text)
            Try
                'Upload
                Dim mStream As Stream = mReq.GetRequestStream()
                mStream.ReadTimeout = 2000
                mStream.Write(MFile, 0, MFile.Length)
                'CleanUp
                mStream.Close()
                mStream.Dispose()
                Lblmssg.Text = "تم التحميل بنجاح"
                Lblmssg.ForeColor = Color.Green
                TextBox1.Text = ""
            Catch exs As Exception
                MsgBox(exs.Message)
            End Try
        Else
            MsgInf("تم تحميل الملف من قبل")
        End If
    End Sub
    Private Function CheckIfFtpFileExists(ByVal fileUri As String) As Boolean
        Dim exist As Boolean = False
        Dim request As FtpWebRequest = WebRequest.Create(fileUri)
        request.Credentials = New NetworkCredential(usrNm, usrPss)
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
    Private Sub BtnDwnld_Click(sender As Object, e As EventArgs) Handles BtnDwnld.Click
        Dowload()
    End Sub
    Private Sub BtnCreatDir_Click(sender As Object, e As EventArgs) Handles BtnCreatDir.Click
        Try
            Dim Dir As String = InputBox("Write Folder Name", "New Directory Name", "NewFolder")
            If Dir.Length > 0 Then
                If Dir.Contains(".") Or Dir.Contains(" ") Then
                    MsgInf("اسم المجلد لابد أن لا يشمل أي مسافات أو .")
                Else
                    If CheckIfFtpFileExists(MainDirectry & Dir) = False Then
                        Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & Dir), FtpWebRequest)
                        'Upddate property
                        mReq.Timeout = 20000
                        mReq.Credentials = New NetworkCredential(usrNm, usrPss)
                        mReq.Method = WebRequestMethods.Ftp.MakeDirectory
                        'mReq.KeepAlive = True
                        'mReq.UseBinary = True
                        mReq.GetResponse()
                        Gett()
                    Else
                        MsgInf("GHGHGH")
                    End If
                    'Create Req

                End If

            Else
                MsgInf("برجاء إدخال اسم المجلد")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CombDir_SelectedIndexChanged(sender As Object, e As EventArgs)
        MainDirectry = "ftp://10.10.26.4/" & CombDir.Text & "/"
        CheckBox1.Enabled = True
        TreeView1.Nodes(0).Text = CombDir.Text
        TreeView1.Nodes(0).Name = CombDir.Text
        DirRow = FTPTable.Rows.Find(CombDir.SelectedIndex + 1)
        If CheckBox1.Checked = True Then
            TxtUsrNm.Text = DirRow.ItemArray(2)
            BtnCreatDir.Enabled = True
            BtnDelete.Enabled = True
            BtnRnm.Enabled = True
            BtnUplod.Enabled = True
            BtnBrws.Enabled = True
            CheckBox1.BackColor = Color.LimeGreen
            CheckBox1.Text = "Admin User"
        Else
            TxtUsrNm.Text = DirRow.ItemArray(3)
            BtnCreatDir.Enabled = False
            BtnDelete.Enabled = False
            BtnRnm.Enabled = False
            BtnUplod.Enabled = False
            BtnBrws.Enabled = False
            CheckBox1.BackColor = Color.Red
            CheckBox1.Text = "Limited User"
        End If
        If TxtUsrNm.Text = "anonymous" Then
            TxtUsrPass.Text = ""
            TxtUsrPass.Visible = False
            LblUsrPw.Visible = False
        Else
            TxtUsrPass.Visible = True
            LblUsrPw.Visible = True
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            'Dowload()
        Else
            Lblmssg.Text = "جاري التحميل ........"
            Lblmssg.Refresh()
            'Dim ddd As New TreeNode = SecSearchTreeView(TreeView1, DataGridView1.CurrentRow.Cells(0).Value.ToString)
            TreeView1.SelectedNode = SecSearchTreeView(TreeView1, DataGridView1.CurrentRow.Cells(0).Value.ToString)
            MainDirectry = "ftp://10.10.26.4/" & Replace(TreeView1.SelectedNode.FullPath, "\", "/") & "/"

            Gett()
        End If
    End Sub
    Private Sub BtnRmvDir_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value), FtpWebRequest)
            'Upddate property
            mReq.Credentials = New NetworkCredential(usrNm, usrPss)
            mReq.Method = WebRequestMethods.Ftp.DeleteFile
            mReq.Timeout = 20000
            mReq.GetResponse()
            Gett()
        Else
            Dim lol As String
            Dim arr() As String
            Dim request As FtpWebRequest = WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value.ToString & "/")
            request.Credentials = New NetworkCredential(usrNm, usrPss)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Timeout = 20000
            Try
                Lblmssg.Text = "جاري التحميل ........"
                Dim response As FtpWebResponse = request.GetResponse()
                Dim responseStream As Stream = response.GetResponseStream()
                responseStream.ReadTimeout = 20000
                Dim reader As StreamReader = New StreamReader(responseStream)
                Do
                    lol = reader.ReadLine
                    If Len(lol) < 1 Then Exit Do

                    arr = Split(lol, vbNewLine)
                    For i = 0 To Split(lol, vbNewLine).Count - 1
                        Dim dsd As Integer = Split(arr(i), ".").Count
                        If Split(arr(i), ".").Count < 2 Then
                            MsgInf("لا يمكن مسح المجلد" & vbCrLf & "حيث أن المجلد يحتوى على مجلدات فرعيه")
                            Exit Sub
                        End If
                    Next
                    If Split(lol, vbNewLine).Count > 0 Then
                        For i = 0 To Split(lol, vbNewLine).Count - 1
                            If Len(arr(i)) > 0 Then
                                'delete all files
                                Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value.ToString & "/" & lol), FtpWebRequest)
                                'Upddate property
                                mReq.Credentials = New NetworkCredential(usrNm, usrPss)
                                mReq.Method = WebRequestMethods.Ftp.DeleteFile
                                mReq.GetResponse()
                                mReq.Abort()
                            End If
                        Next
                    End If

                Loop
                reader.Close()
                response.Close()

                'Delete folder after delete all files
                Dim mReq1 As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value), FtpWebRequest)
                'Upddate property
                mReq1.Credentials = New NetworkCredential(usrNm, usrPss)
                mReq1.Method = WebRequestMethods.Ftp.RemoveDirectory
                mReq1.GetResponse()
                mReq1.Abort()
                Lblmssg.Text = ""
                Gett()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BtnRnm_Click(sender As Object, e As EventArgs) Handles BtnRnm.Click
        'Create Req
        Dim mReq As FtpWebRequest = DirectCast(WebRequest.Create(MainDirectry & DataGridView1.CurrentRow.Cells(0).Value), FtpWebRequest)
        'Upddate property
        mReq.Credentials = New NetworkCredential(usrNm, usrPss)
        mReq.Method = WebRequestMethods.Ftp.Rename
        mReq.Timeout = 20000

        If Split(DataGridView1.CurrentRow.Cells(0).Value, ".").Count > 1 Then
            Dim OldName As String = Split(DataGridView1.CurrentRow.Cells(0).Value, ".")(0)
            Dim NewName As String = InputBox("Write New Name", "New File Name", OldName)
            mReq.RenameTo = NewName & "." & Split(DataGridView1.CurrentRow.Cells(0).Value, ".")(1)
            mReq.GetResponse()
        Else
            Dim OldName As String = DataGridView1.CurrentRow.Cells(0).Value
            Dim NewName As String = InputBox("Write New Name", "New Directory Name", OldName)
            mReq.RenameTo = NewName
            mReq.GetResponse()

        End If
        Gett()
    End Sub
    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles BtnHome.Click
        MainDirectry = "ftp://10.10.26.4/" & CombDir.Text & "/"
        Gett()
    End Sub
    Private Sub SnOutBt_Click(sender As Object, e As EventArgs) Handles SnOutBt.Click
        TreeView1.Nodes(0).Text = CombDir.Text
        MainDirectry = "ftp://10.10.26.4/" & CombDir.Text & "/"
        Label1.Text = CombDir.Text & "/"
        BtnLogn.Enabled = True
        GroupBox1.Enabled = False
        DataGridView1.Enabled = False
        CombDir.Enabled = True
        Me.Text = "FTP - Disconnected"
        DataGridView1.Rows.Clear()
        TreeView1.Nodes(0).Nodes.Clear()
        TreeView1.Nodes(0).Text = ""
        FrsPopu = False
    End Sub
    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            TxtUsrNm.Text = DirRow.ItemArray(2)
            BtnCreatDir.Enabled = True
            BtnDelete.Enabled = True
            BtnRnm.Enabled = True
            BtnUplod.Enabled = True
            BtnBrws.Enabled = True
            CheckBox1.BackColor = Color.LimeGreen
            CheckBox1.Text = "Admin User"
        Else
            TxtUsrNm.Text = DirRow.ItemArray(3)
            BtnCreatDir.Enabled = False
            BtnDelete.Enabled = False
            BtnRnm.Enabled = False
            BtnUplod.Enabled = False
            BtnBrws.Enabled = False
            CheckBox1.BackColor = Color.Red
            CheckBox1.Text = "Limited User"
        End If
        If TxtUsrNm.Text = "anonymous" Then
            TxtUsrPass.Text = ""
            TxtUsrPass.Visible = False
            LblUsrPw.Visible = False
        Else
            TxtUsrPass.Visible = True
            LblUsrPw.Visible = True
        End If
    End Sub
    Private Sub BtnBck2_Click(sender As Object, e As EventArgs) Handles BtnBck2.Click
        Dim CurDir As String = Mid(MainDirectry, Len(CombDir.Text) + 18, Len(MainDirectry))
        Dim Cnt_r As Integer = Split(CurDir, "/").Count - 2
        Dim Dir As String = ""
        For cnt = 0 To Split(CurDir, "/").Count - 3
            Dir &= Split(CurDir, "/")(cnt) & "/"
        Next
        Dim NewDir As String = Mid(Dir, 1, Len(Dir))

        'If NewDir = "" Then
        '    BtnBack.Enabled = False
        'Else
        '    BtnBack.Enabled = True
        'End If
        MainDirectry = "ftp://10.10.26.4/" & CombDir.Text & NewDir

        If IsNothing(TreeView1.SelectedNode) = False Then
            If TreeView1.SelectedNode.Level > 0 Then TreeView1.SelectedNode = TreeView1.SelectedNode.Parent
            If TreeView1.SelectedNode.Level = 0 Then
                BtnBack.Enabled = False
            Else
                BtnBack.Enabled = True
            End If
        End If
        Gett()
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Action <> TreeViewAction.Unknown Then
            Lblmssg.Text = "جاري التحميل ........"
            Lblmssg.Refresh()
            MainDirectry = "ftp://10.10.26.4/" & Replace(TreeView1.SelectedNode.FullPath, "\", "/") & "/"
            Gett()
        End If

    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If IsNothing(TreeView1.SelectedNode) = False Then TreeView1.SelectedNode.BackColor = Color.White
    End Sub
    Private Function SecSearchTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        SecNODESTHATMATCH.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If
            SecRecursiveSearch(TN, TextToFind)
        Next
        If SecNODESTHATMATCH.Count > 0 Then
            Return SecNODESTHATMATCH(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub SecRecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If

            SecRecursiveSearch(TN, TextToFind)
        Next
    End Sub
End Class