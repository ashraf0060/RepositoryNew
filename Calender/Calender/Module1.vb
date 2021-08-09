Imports System.Data.SqlClient
Imports System.Management
Imports System.Net.NetworkInformation
Imports ClosedXML.Excel
Imports Microsoft.Exchange.WebServices.Data

Module Module1
    Public Cnt_ As Integer
    Public Frm As New Form
    Public GrdView As DataGridView
    Public CntxStrip As New ContextMenuStrip
    Dim Form_ As Form
    Dim BttonCtrl As Button
    Dim TxtBoxCtrl As TextBox
    Dim Slctd As Boolean = False
    Dim bolyy As Boolean = False
    Public StrFileName As String = "X"
    Public OfflineCon As New SqlConnection()
    Public ConSTR As New String(My.Settings.ConStr)
    Public Errmsg As String = ""
    Public MainTbl As New DataTable
    Public sqlComm As New SqlCommand                    'SQL Command
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
    Public ExrtErr As String
    Public Mail_ As New Stru.StruMail
    Public Nw As DateTime
    Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
        OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
    End Function
    'C8:D9:D2:1A::CD:71
    Public Function GetMACAddress() As String
        Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        Dim MACAddress As String = String.Empty
        For Each mo As ManagementObject In moc

            If (MACAddress.Equals(String.Empty)) Then
                If CBool(mo("IPEnabled")) Then MACAddress = mo("MacAddress").ToString()
                MACAddress = MACAddress.Replace(":", String.Empty)
                mo.Dispose()
            End If
        Next
        Return MACAddress
    End Function
    Public Sub AppLog(LogMsg As String, SSqlStrs As String)
        My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
          & "\CalLog" & Format(Now, "yyyyMM") & ".Vlg", Format(Now, "yyyyMMdd HH:mm:ss") & " ," & LogMsg & " &H" & SSqlStrs & vbCrLf, True)
    End Sub
    Public Function CalDate(StDt As Date, ByRef EnDt As Date, ErrHndl As String) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
        Dim WdyCount As Integer = 0
        Dim SQLcalDtAdptr As New SqlDataAdapter
        Dim CaldtTbl As New DataTable
        Try
            StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
            EnDt = DateValue(EnDt)
            sqlComm.Connection = OfflineCon ' Get ID & Date & UserID                        
            sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
            sqlComm.CommandType = CommandType.Text
            SQLcalDtAdptr.SelectCommand = sqlComm
            'If sqlCon.State = ConnectionState.Closed Then
            '    sqlCon.Open()
            'End If
            SQLcalDtAdptr.Fill(CaldtTbl)
            WdyCount = CaldtTbl.Rows(0).Item("WDaysCount")
        Catch ex As Exception
            WdyCount = 1
        End Try
        Return WdyCount
    End Function
    Public Sub MsgInf(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        SQLGetAdptr = New SqlDataAdapter
        Errmsg = Nothing
        'sqlComm.CommandTimeout = 30
        sqlComm.Connection = OfflineCon
        SQLGetAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SQLGetAdptr.Fill(SqlTbl)
            OfflineCon.Close()
        Catch ex As Exception
            AppLog(ex.Message, SSqlStr)
            Errmsg = ex.Message
        End Try
        SqlTbl.Dispose()
        SQLGetAdptr.Dispose()
        Return Errmsg
    End Function
    Public Function InsUpd(SSqlStr As String) As String
        Errmsg = Nothing
        sqlComm.Connection = OfflineCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If OfflineCon.State = ConnectionState.Closed Then
                OfflineCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
        Catch ex As Exception
            Errmsg = ex.Message
        End Try
        Return Errmsg
    End Function
    Public Sub BtnSub(Frm As Form)
        'ConStrFn("My Labtop")
        'sqlCon.ConnectionString = strConn
        Form_ = Frm
        Slctd = False
        For Each CTTTRL In Frm.Controls
            If TypeOf CTTTRL Is TabControl Then
                For Each TabPg In CTTTRL.Controls
                    For Each Crl In TabPg.Controls
                        If TypeOf Crl Is FlowLayoutPanel Then
                            For Each C In Crl.Controls
                                If TypeOf C Is Button Then
                                    BttonCtrl = C
                                    CalIfBtn(BttonCtrl)
                                ElseIf TypeOf C Is TextBox Then
                                    TxtBoxCtrl = C
                                    CalIfTxt(TxtBoxCtrl)
                                ElseIf TypeOf C Is GroupBox Then
                                    For Each CRLS In C.Controls
                                        If TypeOf CRLS Is Button Then
                                            BttonCtrl = CRLS
                                            CalIfBtn(BttonCtrl)
                                        ElseIf TypeOf CRLS Is TextBox Then
                                            TxtBoxCtrl = CRLS
                                            CalIfTxt(TxtBoxCtrl)
                                        End If
                                    Next
                                ElseIf TypeOf C Is FlowLayoutPanel Then
                                    For Each CRLSA In C.Controls
                                        If TypeOf CRLSA Is FlowLayoutPanel Then
                                            For Each H In CRLSA.Controls
                                                If TypeOf H Is Panel Then
                                                    For Each V In H.Controls
                                                        If TypeOf V Is Button Then
                                                            BttonCtrl = V
                                                            CalIfBtn(BttonCtrl)
                                                        End If
                                                    Next
                                                ElseIf TypeOf H Is FlowLayoutPanel Then
                                                    For Each V In H.Controls
                                                        If TypeOf V Is Panel Then
                                                            For Each VF In V.Controls
                                                                If TypeOf VF Is Button Then
                                                                    BttonCtrl = VF
                                                                    CalIfBtn(BttonCtrl)
                                                                End If
                                                            Next
                                                        End If
                                                    Next
                                                End If
                                            Next
                                        ElseIf TypeOf CRLSA Is Panel Then
                                            For Each V In CRLSA.Controls
                                                If TypeOf V Is Button Then
                                                    BttonCtrl = V
                                                    CalIfBtn(BttonCtrl)
                                                End If
                                            Next
                                        End If
                                    Next CRLSA
                                End If
                            Next
                        ElseIf TypeOf Crl Is Button Then
                            BttonCtrl = Crl
                            CalIfBtn(BttonCtrl)
                        ElseIf TypeOf Crl Is TextBox Then
                            TxtBoxCtrl = Crl
                            CalIfTxt(TxtBoxCtrl)
                        End If
                    Next
                Next
            ElseIf TypeOf CTTTRL Is FlowLayoutPanel Then
                For Each Crl In CTTTRL.Controls
                    If TypeOf Crl Is Button Then
                        BttonCtrl = Crl
                        CalIfBtn(BttonCtrl)
                    ElseIf TypeOf Crl Is TextBox Then
                        TxtBoxCtrl = Crl
                        CalIfTxt(TxtBoxCtrl)
                    ElseIf TypeOf Crl Is GroupBox Then
                        For Each C In Crl.Controls
                            If TypeOf C Is Button Then
                                BttonCtrl = C
                                CalIfBtn(BttonCtrl)
                            ElseIf TypeOf C Is TextBox Then
                                TxtBoxCtrl = C
                                CalIfTxt(TxtBoxCtrl)
                            End If
                        Next
                    ElseIf TypeOf Crl Is FlowLayoutPanel Then
                        For Each C In Crl.Controls
                            If TypeOf C Is Panel Then
                                If TypeOf C Is Button Then
                                    BttonCtrl = C
                                    CalIfBtn(BttonCtrl)
                                ElseIf TypeOf C Is Panel Then
                                    For Each D In C.Controls
                                        If TypeOf D Is Button Then
                                            BttonCtrl = D
                                            CalIfBtn(BttonCtrl)
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    ElseIf TypeOf Crl Is Panel Then
                        For Each C In Crl.Controls
                            If TypeOf C Is Button Then
                                BttonCtrl = C
                                CalIfBtn(BttonCtrl)
                            End If
                        Next
                    End If
                    'If Crl.Dock = DockStyle.None Then CmstripAsgn(Crl)
                    'If Application.OpenForms().OfType(Of UConfigCtrls).Any Then
                    '    If Crl.Dock = DockStyle.None And TypeOf Crl IsNot MenuStrip Then SndCntls(Crl)
                    'End If
                Next
            ElseIf TypeOf CTTTRL Is Button Then
                BttonCtrl = CTTTRL
                CalIfBtn(BttonCtrl)
            ElseIf TypeOf CTTTRL Is TextBox Then
                TxtBoxCtrl = CTTTRL
                CalIfTxt(TxtBoxCtrl)
            ElseIf TypeOf CTTTRL Is Panel Then
                For Each C In CTTTRL.Controls
                    If TypeOf C Is Button Then
                        BttonCtrl = C
                        CalIfBtn(BttonCtrl)
                    ElseIf TypeOf C Is TextBox Then
                        TxtBoxCtrl = C
                        CalIfTxt(TxtBoxCtrl)
                    End If
                Next
            End If
        Next
    End Sub
    Public Sub CalIfBtn(Btn As Button)
        BtnCtrl(Btn)
        AddHandler Btn.MouseEnter, (AddressOf Btn_MouseEnter)
        AddHandler Btn.MouseLeave, (AddressOf Btn_MouseLeave)
    End Sub
    Public Sub Btn_MouseEnter(sender As Object, e As EventArgs)
        Dim Botn As Button = sender
        BtnIncrease(Botn)
    End Sub
    Public Sub Btn_MouseLeave(sender As Object, e As EventArgs)
        Dim Botn As Control = sender
        BtnDecrease(Botn)
    End Sub
    Public Sub BtnCtrl(VCBtn As Button)
        VCBtn.BackColor = Color.Transparent
        VCBtn.BackgroundImageLayout = ImageLayout.Stretch
        If Split(VCBtn.Text, " ").Count > 1 Then
            VCBtn.Font = New Font("Times New Roman", VCBtn.Width / 14, FontStyle.Regular, GraphicsUnit.Point)
        Else
            VCBtn.Font = New Font("Times New Roman", VCBtn.Width / 8, FontStyle.Regular, GraphicsUnit.Point)
        End If

        VCBtn.TextAlign = ContentAlignment.MiddleCenter
        VCBtn.FlatStyle = FlatStyle.Flat
        VCBtn.FlatAppearance.BorderSize = 0
        VCBtn.BringToFront()
        'If BttonCtrl.Name.Contains("Submit") Then       'Format all button if contains Name
        'End If
    End Sub
    Public Sub BtnIncrease(VCBtn As Button)
        VCBtn.Width += 10
        VCBtn.Height += 10
        VCBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128)
        VCBtn.FlatAppearance.MouseOverBackColor = Color.Transparent
        VCBtn.Location = New Point(VCBtn.Location.X - 5, VCBtn.Location.Y - 5)
        VCBtn.Font = New Font(VCBtn.Font.Name, VCBtn.Font.Size + 2, FontStyle.Bold, VCBtn.Font.Unit)
        VCBtn.Padding = New Padding(VCBtn.Padding.Left, -2, VCBtn.Padding.Right, -2)
    End Sub
    Public Sub BtnDecrease(VCBtn As Button)
        VCBtn.Width -= 10
        VCBtn.Height -= 10
        VCBtn.Location = New Point(VCBtn.Location.X + 5, VCBtn.Location.Y + 5)
        VCBtn.Font = New Font(VCBtn.Font.Name, VCBtn.Font.Size - 2, FontStyle.Regular, VCBtn.Font.Unit)
        VCBtn.Padding = New Padding(VCBtn.Padding.Left, 0, VCBtn.Padding.Right, 0)
    End Sub
    Public Sub CalIfTxt(TxtBox As TextBox)
        AddHandler TxtBox.Click, (AddressOf TxtSlctOn_Click)
        'AddHandler TxtBox.Enter, (AddressOf TxtSlctOn_Click)
    End Sub
    Private Sub TxtSlctOn_Click(sender As Object, e As EventArgs)
        Dim TxtBox As TextBox = sender
        If bolyy = False Then
            bolyy = True
            TxtBox.SelectAll()
        Else
            bolyy = False
        End If
    End Sub
    Public Function Exprt(FileNm As String) As String
        Dim ExrtErr As String = Nothing
        Dim D As SaveFileDialog = New SaveFileDialog
        With D
            .Title = "Save Excel File"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Filter = "Excel File|*.xlsx"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        D.FileName = FileNm & "_" & Format(Now, "yyyy-MM-dd_HHmm") '& GroupBox1.Tag & GroupBox2.Tag & GroupBox3.Tag & GrpDtKnd.Tag
        If D.ShowDialog() = DialogResult.OK Then
            Try
                Dim Workbook As XLWorkbook = New XLWorkbook()
                Workbook.Worksheets.Add(MainTbl, "FileNm")
                Workbook.SaveAs(D.FileName)
                MsgBox("Done")
            Catch ex As Exception
                ExrtErr = "X"
                MsgBox(ex.Message)
            End Try
        End If
        Return ExrtErr
    End Function
    Public Function SelctSerchTxt(richtxtbx As RichTextBox, Strng As String, Optional bL As Boolean = True) As String
        Dim HH As String = Nothing
        Try
            'richtxtbx = New RichTextBox
            Dim starttxt As Integer = 0
            Dim endtxt As Integer
            endtxt = richtxtbx.Text.LastIndexOf(Strng)
            'richtxtbx.SelectAll()
            'richtxtbx.SelectionBackColor = Color.White
            While starttxt < endtxt
                If richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.MatchCase) > 0 Then
                    If bL = False Then
                        richtxtbx.SelectionBackColor = Color.GreenYellow
                    Else
                        richtxtbx.SelectionBackColor = Color.Red
                        richtxtbx.SelectionColor = Color.Yellow
                    End If

                End If
                starttxt += 1
            End While
        Catch ex As Exception
            HH = "X"
            MsgBox(ex.Message)
        End Try
        Return HH
    End Function
    Public Function SndMail() As String
        ExrtErr = Nothing
        Try
            Dim exchange As ExchangeService
            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\" & My.Settings.MailUsrNm, My.Settings.MailUsrPass)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Dim message As New EmailMessage(exchange)
            If (Mail_.To_).Length > 0 Then
                For LL = 0 To Split(Mail_.To_, ";").Count - 1
                    message.ToRecipients.Add(Trim(Split(Mail_.To_, ";")(LL)))
                Next
            End If
            If (Mail_.CC_).Length > 0 Then
                For LL = 0 To Split(Mail_.CC_, ";").Count - 1
                    message.CcRecipients.Add(Trim(Split(Mail_.CC_, ";")(LL)))
                Next
            End If

            message.Subject = Mail_.Sub_
            message.Body = Mail_.Body_
            'message.Attachments.AddFileAttachment(FileExported)
            'message.Attachments(0).ContentId = Mail_.Sub_ & "_" & Format(Now, "yyyy-MM-dd")
            message.Importance = 1
            message.SendAndSaveCopy()
        Catch exs As Exception
            AppLog(exs.Message, Mail_.To_)
            ExrtErr = exs.Message
        End Try
        Return ExrtErr
    End Function
    Public Function ServrTime() As DateTime
        Dim TimeTble As New DataTable
        TimeTble.Rows.Clear()
        TimeTble.Columns.Clear()
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        Try
            sqlComm.Connection = OfflineCon
            SQLGetAdptr.SelectCommand = sqlComm
            sqlComm.CommandType = CommandType.Text
            sqlComm.CommandText = "Select GetDate()-1 as Now_"
            SQLGetAdptr.Fill(TimeTble)
            Nw = Format(TimeTble.Rows(0).Item(0), "yyyy/MMM/dd hh:mm:ss tt")
        Catch ex As Exception
            Errmsg = "X"
        End Try
        Return Nw
        SQLGetAdptr.Dispose()
        TimeTble.Dispose()
    End Function
End Module
