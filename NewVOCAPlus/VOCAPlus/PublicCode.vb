Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Mail
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports Microsoft.Exchange.WebServices.Data
Imports VOCAPlus.Strc
Module PublicCode

    Public screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    Public MLXX As String = ""       ' Mail Password From Lib Table
    Public Errmsg As String          ' Handel error message
    Public Esc As String = ""
    Public EscCnt As Integer = 0
    Public EscID As Integer = 0
    Public EnglishInput As InputLanguage
    Public ArabicInput As InputLanguage
    Public GenSaltKey As String = "754A8DBBBE83563B7A724710FCF14FAD"
    ' CAPS LOACK
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Public Const VK_CAPITAL As Integer = &H14               ' CAPS LOACK
    Public Const KEYEVENTF_EXTENDEDKEY As Integer = &H1     ' CAPS LOACK
    Public Const KEYEVENTF_KEYUP As Integer = &H2           ' CAPS LOACK
    Public Usr As New Strc.CurrentUser
    Public SQLSTR As String
    Public Cnt_ As Integer                              'Counter
    Public EncDecTxt As String                          'Encoding decoding string
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public sqlComm As New SqlCommand                    'SQL Command
    Public sqlCommUpddate_ As New SqlCommand            'SQL Command
    Public sqlComminsert_1 As New SqlCommand            'SQL Command
    Public sqlComminsert_2 As New SqlCommand            'SQL Command
    Public sqlComminsert_3 As New SqlCommand            'SQL Command
    Public sqlComminsert_4 As New SqlCommand            'SQL Command
    Public Reader_ As SqlDataReader                     'SQL Reader
    Public SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Public tempTable As DataTable = New DataTable
    Public UserTable As DataTable = New DataTable
    Public AreaTable As DataTable = New DataTable
    Public OfficeTable As DataTable = New DataTable
    Public CompSurceTable As DataTable = New DataTable
    Public CountryTable As DataTable = New DataTable
    Public ProdKTable As DataTable = New DataTable
    Public ProdCompTable As DataTable = New DataTable
    Public UpdateKTable As DataTable = New DataTable
    Public FTPTable As New DataTable
    Public MacTable As New DataTable
    Public CtrlsTbl As DataTable = New DataTable
    Public ConTbl As New DataTable
    Public LogOfflinTbl As New DataTable
    Public CompfflinTbl As New DataTable

    Public PreciFlag As Boolean = False                 'Load princible tables
    Public PrciTblCnt As Integer = 0                    'Counter for Thread
    Public ExpDTable As New DataTable                   'Export data Function to use its count every time i use this function
    Public ExpTrFlseTable As New DataTable
    Public ExpStr As String
    Public Rws As Integer
    Public Col As Integer
    Public DataExprRtrn As Strc.ExprXlsx                     'Return Counters Structure of Export Function
    Public GridCuntRtrn As Strc.TickInfo                     'Return Counters Structure of Gridview Function
    Public StruGrdTk As Strc.TickFld                     'Return Fields Structure of Tickets Gridview Function
    Public Msg As String
    Public LblSecLvl_ As String = "" 'FOR SEC fORM
    'Public Const strConn As String = "Data Source=sql5041.site4now.net;Initial Catalog=DB_A49C49_vocaplus;Persist Security Info=True;User ID=DB_A49C49_vocaplus_admin;Password=Hemonad105046"
    'Public Const strConn As String = "Server=tcp:egyptpostazure.database.windows.net,1433;Initial Catalog=vocaplus;Persist Security Info=False;User ID=sw;Password=Hemonad105046;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    Public strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
    'Public strConnCssys As String = "Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=import;Password=ASD_asd123"
    'Public Const strConn As String = "Data Source=HOSPC\HOSPCSQLSRV;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Public sqlCon As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Public ServerNm As String = "Egypt Post Server"
    Public Distin As String = ""
    Public StrFileName As String = "X"
    Public Nw As DateTime = ServrTime()
    Public TikIDRep_ As Integer
    Public Rslt As DialogResult
    Public Property MousePosition As Object

#Region "Form Adjust"
    Dim Form_ As Form
    Dim BttonCtrl As Button
    Dim TxtBoxCtrl As TextBox
    Dim TabPg As New TabPage
    Dim DefCmStrip As ContextMenuStrip
    Dim TikCmStrip As ContextMenuStrip
    Dim UpdtCmStrip As ContextMenuStrip
    Dim MenStrip As MenuStrip
    Dim CmStripCatch As New ToolStripMenuItem
    Dim CmStripFix As New ToolStripMenuItem
    Dim CmStripRest As New ToolStripMenuItem
    Dim CmStripFrmt As New ToolStripMenuItem
    Dim CmStripCatchTik As New ToolStripMenuItem
    Dim CmStripFixTik As New ToolStripMenuItem
    Dim CmStripRestTik As New ToolStripMenuItem
    Dim CmStripFrmtTik As New ToolStripMenuItem
    Dim CmStripCopy As New ToolStripMenuItem
    Dim CmStripPast As New ToolStripMenuItem
    Dim CmStripPrvw As New ToolStripMenuItem
    Dim CmStripUpload As New ToolStripMenuItem
    Dim CmStripDwnload As New ToolStripMenuItem

    Dim CmstripItemTmp1 As New ToolStripMenuItem
    Dim CmstripItemTmp2 As New ToolStripMenuItem
    Dim CmstripItemTmp3 As New ToolStripMenuItem

    Dim MenStripCmboFnt As New ToolStripComboBox
    Dim MenStripForward As New ToolStripMenuItem
    Dim MenStripBack As New ToolStripMenuItem
    Dim MenStripFlowBreak As New ToolStripMenuItem
    Dim MenStripMargin As New ToolStripMenuItem
    Dim MenStripMrgnLft As New ToolStripTextBox
    Dim MenStripMrgnTop As New ToolStripTextBox
    Dim MenStripMrgnRght As New ToolStripTextBox
    Dim MenStripMrgnBttm As New ToolStripTextBox
    Dim MenStripFlwDirc As New ToolStripComboBox
    Dim MenStripResetAll As New ToolStripMenuItem
#End Region

    Dim MyPen As Pen = New Pen(Drawing.Color.Blue, 5)
    Dim myGraphics As Graphics

    Dim CmstripTmpTmp3 As New ToolStripMenuItem
    Dim UsrCnrlTbl As DataTable
    Dim Drow As DataRow
    Dim primaryKey(0) As DataColumn
    Public CtlCnt As Integer = 0
    Dim CTTTRL As Control
    Dim BacCtrl As Control
    Dim Slctd As Boolean = False
    Dim bolyy As Boolean = False
    Dim CompList As New List(Of String) 'list of tickets to get tickets updates
    Public CompIds As String ' tickets to get tickets updates
    Public TickTblMain As New DataTable
    Public UpdtCurrTbl As DataTable
    Public ProgBar As ProgressBar
    Public frm__ As Form
    Public gridview_ As DataGridView
    Public ElapsedTimeSpan As String
    Public Function ConStrFn(tt As String) As String
        '@VocaPlus$21-2

        If tt = "Eg Server" Then
            strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
            ServerNm = "Egypt Post Server"
        ElseIf tt = "My Labtop" Then
            strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
            ServerNm = "My Labtop"
        ElseIf tt = "Test Database" Then
            strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
            ServerNm = "Test Database"
        End If
        If sqlCon.State = ConnectionState.Connecting Or sqlCon.State = ConnectionState.Open Then
            sqlCon.Close()
        End If
        sqlCon.ConnectionString = strConn
        Return strConn
    End Function
    Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
        OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
    End Function
    Function getMacAddress() As String      'Returns the Mac address 
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(0).GetPhysicalAddress.ToString
    End Function
    Public Function GetMACAddressNew() As String
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
    Public Function SEmail(ETo As String, Optional ECc As String = "", Optional EBc As String = "", Optional Esub As String = "", Optional EMsg As String = "", Optional ETch As String = "X", Optional EPri As String = "N") As Integer
        '   Email Function Ver. 4.0
        Dim Smtp_Server As New SmtpClient
        Dim E_mail As New MailMessage()
        Try
            Smtp_Server.Host = My.Settings.StmpH
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(My.Settings.StmpU, My.Settings.StmpP)
            Smtp_Server.Port = My.Settings.StmpR ';    //alternative port number Is 8889
            Smtp_Server.EnableSsl = False

            '  E_mail = New MailMessage()
            E_mail.From = New MailAddress(My.Settings.FEmail)
            For Each ETo In ETo.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.To.Add(ETo)
            Next
            For Each ECc In ECc.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.CC.Add(ECc)
            Next
            For Each EBc In EBc.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                E_mail.Bcc.Add(EBc)
            Next
            Select Case EPri
                Case EPri = "H"
                    E_mail.Priority = MailPriority.High
                Case EPri = "L"
                    E_mail.Priority = MailPriority.Low
                Case Else
                    E_mail.Priority = MailPriority.Normal
            End Select
            E_mail.Subject = Esub
            If ETch <> "X" Then
                'E_mail.Attachments.Add(New Attachment(ETch))
            End If
            E_mail.IsBodyHtml = False
            E_mail.Body = EMsg
            Smtp_Server.Send(E_mail)
            SEmail = 1

        Catch error_t As Exception
            Errmsg = error_t.Message & ", " & error_t.InnerException.Message
            SEmail = 0
        End Try
        Return SEmail
    End Function
    Public Function CalDate(StDt As Date, ByRef EnDt As Date, ErrHndl As String) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
        Dim WdyCount As Integer = 0
        Dim SQLcalDtAdptr As New SqlDataAdapter
        Dim CaldtTbl As New DataTable
        Try

            StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
            EnDt = DateValue(EnDt)
            sqlComm.Connection = sqlCon ' Get ID & Date & UserID                        
            sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
            sqlComm.CommandType = CommandType.Text
            SQLcalDtAdptr.SelectCommand = sqlComm
            'If sqlCon.State = ConnectionState.Closed Then
            '    sqlCon.Open()
            'End If
            SQLcalDtAdptr.Fill(CaldtTbl)
            WdyCount = CaldtTbl.Rows(0).Item("WDaysCount")
            AppLogTbl(Split(ErrHndl, "&H")(0), 0,, sqlComm.CommandText, CaldtTbl.Rows.Count)
        Catch ex As Exception
            AppLog(ErrHndl, ex.Message, sqlComm.CommandText)
            AppLogTbl(Split(ErrHndl, "&H")(0), 1, ex.Message, sqlComm.CommandText, CaldtTbl.Rows.Count)
            WdyCount = 1
        End Try
        Return WdyCount
    End Function
    Public Sub DataExp(sQlfLNm As String)
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه

        Try                                                                                                       'Try If there is available Connection
            If ExpDTable.Rows.Count > 0 Then
                WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & ExpDTable.Rows.Count & " بيان"
                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")

                XLWrkBk.Title = ("VOCA Plus Auto Exported Data")
                XLWrkBk.Subject = ("Export Screen")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")

                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus"
                XLWrkSht.Cells(2, 1) = "Ashraf Farag"
                XLWrkSht.Cells(3, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Rows("1:3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                XLWrkSht.Rows("1:3").Font.FontStyle = "Bold"
                XLWrkSht.Rows("1:1").font.color = Color.Red
                XLWrkSht.Rows("1:3").Font.Size = 12
                XLWrkSht.Rows("1:1").Font.Name = "Times New Roman"
                XLWrkSht.Rows("2:2").Font.Name = "Lucida Handwriting"
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Font.Color = Color.Black
                'Set Merge Signature Cells
                XLWrkSht.Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(1, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(3, 1), XLWrkSht.Cells(3, ExpDTable.Columns.Count)).Merge()

                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"

                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "yyyy/MM/dd" 'Date Columns
                    ElseIf ExpDTable.Columns(Col).ToString.Contains("تليفون") Or ExpDTable.Columns(Col).ToString.Contains("Phone") Or ExpDTable.Columns(Col).ToString.Contains("كارت") Or ExpDTable.Columns(Col).ToString.Contains("قومي") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" 'Date Columns
                    End If
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & Rws + 1 & " من " & ExpDTable.Rows.Count
                    'GC.Collect()
                    'FlushMemory()
                Next Rws
                With XLWrkSht
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Color = Color.Black
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).WrapText = False
                    .Cells.Columns.AutoFit()
                    '.Cells.EntireColumn.AutoFit()
                End With
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                Distin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & sQlfLNm & "_" & Format(Now, "dd-MM-yyyy_HH_mm_ss") & ".xlsx"
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
                WelcomeScreen.StatBrPnlAr.Text = "تم استخراج عدد " & ExpDTable.Rows.Count & " بيان إلى MyDocuments"
            Else
                WelcomeScreen.StatBrPnlAr.Text = "لا توجد بيانات لإستخراجها في المدة المحددة"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo End_
        End Try

        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        FlushMemory()
        WelcomeScreen.StatBrPnlAr.Text = ""
End_:

    End Sub
    Public Function Exprt(FileNm As String, Tbl As DataTable) As String
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
            LoadFrm("", 350, 500)
            Try
                Dim Workbook As XLWorkbook = New XLWorkbook()
                Workbook.Worksheets.Add(Tbl, "FileNm")
                Workbook.SaveAs(D.FileName)
                LodngFrm.Close()
                MsgBox("Done")
            Catch ex As Exception
                LodngFrm.Close()
                Exprt = "X"
                MsgBox(ex.Message)
            End Try
        End If
        Return ExrtErr
    End Function
    Function PassEncoding(password As String, FSaltKey As String) As String
        Dim Wrapper As New Simple3Des(FSaltKey)
        EncDecTxt = Wrapper.EncryptData(password)
        Return EncDecTxt
    End Function
    Function PassDecoding(password As String, FSaltKey As String) As String
        Dim wrapper As New Simple3Des(FSaltKey)
        Try '        DecryptData throws if the wrong password is used.
            EncDecTxt = wrapper.DecryptData(password)
        Catch ex As System.Security.Cryptography.CryptographicException
            EncDecTxt = "false"
        End Try
        Return EncDecTxt
    End Function
    Function HrdCol() As Strc.HrdColc
        Dim MyOBJ As Object
        Dim Items As New Strc.HrdColc
        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_Processor") ' Proccessor Information
        For Each Device In MyOBJ
            Items.HProcc &= Device.Name.ToString + " " + Device.CurrentClockSpeed.ToString + " Mhz"
        Next
        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_NetworkAdapter") ' Network Information
        For Each Device In MyOBJ
            Items.HNetwrk &= Device.Name.ToString & " & "
        Next

        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_PhysicalMemory")  ' Ram Information
        For Each Device In MyOBJ
            Items.HRam &= " Ram Capacity : " & Device.Capacity / 1024 / 1024 / 1024 & " Giga " & "Manufacturer : " & Device.Manufacturer
        Next

        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_bios")  ' Bios Information
        For Each Device In MyOBJ
            Items.HSerNo &= "Serial Number: " & Device.serialNumber & " Manufacturer : " & Device.Manufacturer
        Next
        Return Items
    End Function
    Function TrckNo(ByVal source As String) As String 'Extract Email Addresses From String
        Dim mc As MatchCollection
        Dim i As Integer
        Dim Emails As String = ""
        ' expression garnered from www.regexlib.com - thanks guys!
        mc = Regex.Matches(source, "([A-Z]+) ([0-9]+) ([A-Z])")

        '               "([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})"
        For i = 0 To mc.Count - 1
            Emails &= mc(i).Value & "; "
        Next
        Emails = Left(Emails, Emails.Length - 2)
        Return Emails
    End Function
    Public Sub AppLog(ErrHndls As String, LogMsg As String, SSqlStrs As String)
        On Error Resume Next
        My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
          & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Format(Now, "yyyyMMdd HH:mm:ss") & " ," & ErrHndls & LogMsg & " &H" & PassEncoding(SSqlStrs, GenSaltKey) & vbCrLf, True)
    End Sub
    Public Sub AppLogTbl(ErrCd As Integer, Typ As Integer, Optional EXMsg As String = "", Optional SSqlStrs As String = "", Optional rwCnt As Integer = -1)
        'Dim Now_ As DateTime
        'Dim sqlComm1 As New SqlCommand
        'Try
        '    Dim OfflineCon As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OfflineDB.mdf;Integrated Security=True")
        '    sqlComm1.Connection = OfflineCon
        '    If OfflineCon.State = ConnectionState.Closed Then
        '        OfflineCon.Open()
        '    End If
        '    sqlComm1.CommandType = CommandType.Text
        '    If ServrTime() = "00:00:00" Then
        '        Now_ = Format(Now, "yyyy/MMM/dd hh:mm:ss tt")
        '    Else
        '        Now_ = Nw
        '    End If
        '    sqlComm1.CommandText = "insert into ALog ([LogDt],[LogErrCD],[Logtype],[LogExMsg],[LogSQLStr],[LogRwCnt],[LogIP],LogUsrID) Values ('" & Format(Now, "yyyy/MMM/dd hh:mm:ss tt") & "'," & ErrCd & "," & Typ & ",'" & Replace(EXMsg, "'", "$") & "','" & Replace(SSqlStrs, "'", "$") & "'," & rwCnt & ",'" & OsIP() & "'," & Usr.PUsrID &
        '    ");"
        '    sqlComm1.ExecuteNonQuery()
        'Catch ex As Exception
        '    AppLog("0000&H", ex.Message, sqlComm1.CommandText)
        'End Try
    End Sub
    Public Sub MsgInf(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Sub MsgErr(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String) As String
        Dim StW As New Stopwatch
        StW.Start()
        Errmsg = Nothing
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        sqlComm.Connection = sqlCon
        SQLGetAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            SQLGetAdptr.Fill(SqlTbl)
            AppLogTbl(Split(ErrHndl, "&H")(0), 0, "", SSqlStr, SqlTbl.Rows.Count)
            If PreciFlag = True Then
                If ErrHndl <> "1005&H" And ErrHndl <> "9999&H" And ErrHndl <> "8888&H" Then
                    If PublicCode.InsUpd("UPDATE Int_user SET UsrLastSeen = (Select GetDate()) WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H") = Nothing Then  'Update User Active = false = 
                        WelcomeScreen.LblLstSeen.Text = "Last Seen : " & ServrTime()
                    End If
                End If
            End If
            StW.Stop()
            Dim TimSpn As TimeSpan = (StW.Elapsed)
            ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds / 10)
            sqlCon.Close()
        Catch ex As Exception
            Dim frmCollection = Application.OpenForms
            If frmCollection.OfType(Of WelcomeScreen).Any Then
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            End If
            AppLog(ErrHndl, ex.Message, SSqlStr)
            AppLogTbl(Split(ErrHndl, "&H")(0), 1, ex.Message, SSqlStr, SqlTbl.Rows.Count)
            Errmsg = ex.Message
        End Try
        SQLGetAdptr.Dispose()
        Return Errmsg
    End Function
    Public Function InsUpd(SSqlStr As String, ErrHndl As String) As String
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            AppLogTbl(Split(ErrHndl, "&H")(0), 0,, SSqlStr)
        Catch ex As Exception
            Dim frmCollection = Application.OpenForms
            If frmCollection.OfType(Of WelcomeScreen).Any Then
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            End If
            AppLog(ErrHndl, ex.Message, SSqlStr)
            Errmsg = ex.Message
            AppLogTbl(Split(ErrHndl, "&H")(0), 1, ex.Message, SSqlStr)
        End Try
        Return Errmsg
    End Function
    Public Function InsTrans(TranStr1 As String, TranStr2 As String, ErrHndl As String) As String
        Errmsg = Nothing
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = TranStr1
            sqlComminsert_2.CommandText = TranStr2
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            Tran.Commit()
            AppLogTbl(Split(ErrHndl, "&H")(0), 0, , TranStr1 & "_" & TranStr2)
        Catch ex As Exception
            Tran.Rollback()
            AppLog(ErrHndl, ex.Message, TranStr1 & "_" & TranStr2)
            AppLogTbl(Split(ErrHndl, "&H")(0), 1, ex.Message, TranStr1 & "_" & TranStr2)
            Dim frmCollection = Application.OpenForms
            If frmCollection.OfType(Of WelcomeScreen).Any Then
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            End If
            Errmsg = ex.Message
        End Try
        Return Errmsg
    End Function
    Public Sub CompGrdTikFill(GrdTick As DataGridView, Tbl As DataTable, ProgBar As ProgressBar) ' New Sub
        GrdTick.DataSource = Tbl.DefaultView
        CompList = New List(Of String)
        For HH = 0 To Tbl.Columns.Count - 1
            If Tbl.Columns(HH).ColumnName = "TkDtStart" Then
                GrdTick.Columns(HH).HeaderText = "تاريخ الشكوى"
            ElseIf Tbl.Columns(HH).ColumnName = "TkID" Then
                GrdTick.Columns(HH).HeaderText = "رقم الشكوى"
            ElseIf Tbl.Columns(HH).ColumnName = "SrcNm" Then
                GrdTick.Columns(HH).HeaderText = "مصدر الشكوى"
            ElseIf Tbl.Columns(HH).ColumnName = "TkClNm" Then
                GrdTick.Columns(HH).HeaderText = "اسم العميل"
            ElseIf Tbl.Columns(HH).ColumnName = "TkClPh" Then
                GrdTick.Columns(HH).HeaderText = "تليفون العميل1"
            ElseIf Tbl.Columns(HH).ColumnName = "TkClPh1" Then
                GrdTick.Columns(HH).HeaderText = "تليفون العميل2"
            ElseIf Tbl.Columns(HH).ColumnName = "PrdNm" Then
                GrdTick.Columns(HH).HeaderText = "اسم المنتج"
            ElseIf Tbl.Columns(HH).ColumnName = "CompNm" Then
                GrdTick.Columns(HH).HeaderText = "نوع الشكوى"
            ElseIf Tbl.Columns(HH).ColumnName = "UsrRealNm" Then
                GrdTick.Columns(HH).HeaderText = "متابع الشكوى"
            Else
                GrdTick.Columns(HH).HeaderText = "unknown"
                GrdTick.Columns(HH).Visible = False
            End If
        Next
        ProgBar.Visible = True
        For GG = 0 To GrdTick.Rows.Count - 1
            ProgBar.Maximum = GrdTick.Rows.Count
            ProgBar.Value = GG + 1
            ProgBar.Refresh()
            CompList.Add("TkupTkSql = " & GrdTick.Rows(GG).Cells(0).Value)
        Next
        CompIds = String.Join(" OR ", CompList)
        Tbl.Columns.Add("تاريخ آخر تحديث")
        Tbl.Columns.Add("نص آخر تحديث")
        Tbl.Columns.Add("محرر آخر تحديث")
        Tbl.Columns.Add("TkupReDt")
        Tbl.Columns.Add("TkupUser")
        Tbl.Columns.Add("LastUpdateID")
        Tbl.Columns.Add("EvSusp")
        Tbl.Columns.Add("UCatLvl")
        Tbl.Columns.Add("TkupUnread")
        ProgBar.Visible = False
    End Sub
    Public Sub GetPrntrFrm(Frm As Form, GV As DataGridView)
        Dim gg As DataGridView = Frm.Controls(GV.Name)
        gg.CurrentRow.Cells("TkDetails").Value = StruGrdTk.Detls
        gg.CurrentRow.Cells("تاريخ آخر تحديث").Value = StruGrdTk.LstUpDt
        gg.CurrentRow.Cells("نص آخر تحديث").Value = StruGrdTk.LstUpTxt
        gg.CurrentRow.Cells("محرر آخر تحديث").Value = StruGrdTk.LstUpUsrNm
        gg.CurrentRow.Cells("LastUpdateID").Value = StruGrdTk.LstUpEvId
        gg.CurrentRow.Cells("TkClsStatus").Value = StruGrdTk.ClsStat

        If Frm.Name = "TikFolow" Then
            If StruGrdTk.ClsStat = True Then
                gg.Rows.RemoveAt(gg.CurrentRow.Index)
            End If
        End If

    End Sub
    Public Sub UpdateFormt(GridUpd As DataGridView, Optional StrTick As String = "")     'UpGrgFrmt(GridUpdt, GridTicket)
        For Cnt_ = 0 To GridUpd.Rows.Count - 1
            If GridUpd.Rows(Cnt_).Cells("EvSusp").Value = True Then                             'Event Sys True
                GridUpd.Rows(Cnt_).Cells("TkupReDt").Value = ""                                    'Read Date
                GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSys
            ElseIf StrTick <> "" Then
                If GridUpd.Rows(Cnt_).Cells("TkupUser").Value = StrTick Then                        'Event UserId
                    GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrUsr
                ElseIf GridUpd.Rows(Cnt_).Cells("TkupUser").Value <> StrTick Then                        'Event UserId
                    If GridUpd.Rows(Cnt_).Cells("UCatLvl").Value >= 3 And GridUpd.Rows(Cnt_).Cells("UCatLvl").Value <= 5 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSamCat
                    ElseIf GridUpd.Rows(Cnt_).Cells("UCatLvl").Value = 12 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrOperation
                    Else
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrNotUsr
                    End If
                End If
            End If

            If Year(GridUpd.Rows(Cnt_).Cells("TkupReDt").Value) < 2000 Then
                GridUpd.Rows(Cnt_).Cells("TkupReDt").Value = ""                                    'Read Date
            End If
            'If GridUpd.Rows(Cnt_).Cells("TkupUnread").Value = False Then                              'Read Status
            '    GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            'Else
            GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            'End If

        Next
        'TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread
        GridUpd.Columns("TkupSTime").DefaultCellStyle.Format = "dd/MM/yyyy ddd HH:mm"
        GridUpd.Columns("TkupSTime").HeaderText = "تاريخ التحديث"
        GridUpd.Columns("TkupTxt").HeaderText = "نص التحديث"
        GridUpd.Columns("UsrRealNm").HeaderText = "محرر التحديث"
        GridUpd.Columns("TkupReDt").HeaderText = "قراءة التحديث"
        GridUpd.Columns("TkupUser").Visible = False
        GridUpd.Columns("TkupSQL").Visible = False
        GridUpd.Columns("TkupTkSql").Visible = False
        GridUpd.Columns("TkupEvtId").Visible = False
        GridUpd.Columns("EvSusp").Visible = False
        GridUpd.Columns("UCatLvl").Visible = False
        GridUpd.Columns("TkupUnread").Visible = False
        GridUpd.AutoResizeColumns()
        GridUpd.Columns("TkupTxt").Width = GridUpd.Width - (GridUpd.Columns("TkupSTime").Width + GridUpd.Columns("UsrRealNm").Width + GridUpd.Columns("TkupReDt").Width + GridUpd.Columns("File").Width + 50)
        GridUpd.Columns("TkupTxt").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridUpd.AutoResizeRows()
        GridUpd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridUpd.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Function TikFormat(TblTicket As DataTable, TblUpdt As DataTable, ProgBar As ProgressBar) As TickInfo ' Function to Adjust Ticket Gridview
        GridCuntRtrn = New TickInfo
        ProgBar.Visible = True

        For Rws = 0 To TblTicket.Rows.Count - 1
            GridCuntRtrn.TickCount += 1                                          'Grid record count
            ProgBar.Maximum = TblTicket.Rows.Count
            ProgBar.Value = GridCuntRtrn.TickCount
            ProgBar.Refresh()


            Try
                TblUpdt.DefaultView.RowFilter = "[TkupTkSql]" & " = " & TblTicket.Rows(Rws).Item("TkSQL")
                TblTicket.Rows(Rws).Item("تاريخ آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupSTime")
                TblTicket.Rows(Rws).Item("نص آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupTxt")
                TblTicket.Rows(Rws).Item("محرر آخر تحديث") = TblUpdt.DefaultView(0).Item("UsrRealNm")
                TblTicket.Rows(Rws).Item("TkupReDt") = TblUpdt.DefaultView(0).Item("TkupReDt")
                TblTicket.Rows(Rws).Item("TkupUser") = TblUpdt.DefaultView(0).Item("TkupUser")
                TblTicket.Rows(Rws).Item("LastUpdateID") = TblUpdt.DefaultView(0).Item("TkupEvtId")
                TblTicket.Rows(Rws).Item("EvSusp") = TblUpdt.DefaultView(0).Item("EvSusp")
                TblTicket.Rows(Rws).Item("UCatLvl") = TblUpdt.DefaultView(0).Item("UCatLvl")
                TblTicket.Rows(Rws).Item("TkupUnread") = TblUpdt.DefaultView(0).Item("TkupUnread")

                StruGrdTk.LstUpDt = TblUpdt.DefaultView(0).Item("TkupSTime")
                StruGrdTk.LstUpTxt = TblUpdt.DefaultView(0).Item("TkupTxt")
                StruGrdTk.LstUpUsrNm = TblUpdt.DefaultView(0).Item("UsrRealNm")
                StruGrdTk.LstUpEvId = TblUpdt.DefaultView(0).Item("TkupEvtId")
            Catch ex As Exception
                TblTicket.Rows(Rws).Delete()
            End Try



        Next Rws
        GridCuntRtrn.CompCount = Convert.ToInt32(TblTicket.Compute("count(TkSQL)", String.Empty))
        GridCuntRtrn.NoFlwCount = Convert.ToInt32(TblTicket.Compute("count(TkFolw)", "TkFolw = 'False'"))
        GridCuntRtrn.Recved = Convert.ToInt32(TblTicket.Compute("count(TkRecieveDt)", "TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd").ToString & "'"))
        GridCuntRtrn.ClsCount = Convert.ToInt32(TblTicket.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"))
        GridCuntRtrn.UpdtFollow = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] = UsrRealNm"))
        GridCuntRtrn.UpdtColleg = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"))
        GridCuntRtrn.UpdtOthrs = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"))
        GridCuntRtrn.UnReadCount = Convert.ToInt32(TblTicket.Compute("count(TkupUnread)", "TkupUnread = 'False'"))
        GridCuntRtrn.Esc1 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 902"))
        GridCuntRtrn.Esc2 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 903"))
        GridCuntRtrn.Esc3 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 904"))

        ProgBar.Visible = False
        Return GridCuntRtrn 'Return Counters Structure
    End Function
    Public Sub SubGrdTikFill(GrdTick As DataGridView, Tbl As DataTable) 'To Delete Because The new one is "CompGrdTikFill"
        GrdTick.DataSource = Tbl
        If GrdTick.Columns(0).HeaderText <> "م" Then GrdTick.Columns.Insert(0, New DataGridViewTextBoxColumn())
        GrdTick.Columns(0).HeaderText = "م"
        GrdTick.Columns(0).Visible = False                                  '.HeaderText = "م"
        GrdTick.Columns(1).Visible = False                                 '.HeaderText = "SQL"
        GrdTick.Columns(2).Visible = False                                 '.HeaderText = "Product Kind"
        GrdTick.Columns(3).HeaderText = "تاريخ الشكوى"
        GrdTick.Columns(4).HeaderText = "رقم الشكوى"
        GrdTick.Columns(5).HeaderText = "مصدر الشكوى"
        GrdTick.Columns(6).HeaderText = "اسم العميل"
        GrdTick.Columns(7).HeaderText = "تليفون العميل1"
        GrdTick.Columns(8).HeaderText = "تليفون العميل2"
        GrdTick.Columns(9).Visible = False                                  '.HeaderText = "ايميل العميل"
        GrdTick.Columns(10).Visible = False                                 '.HeaderText = "عنوان العميل"
        GrdTick.Columns(11).HeaderText = "رقم الكارت"
        GrdTick.Columns(12).HeaderText = "رقم الشحنة"
        GrdTick.Columns(13).Visible = False                                 '.HeaderText = "رقم أمر الدقع"
        GrdTick.Columns(14).Visible = False                                 '.HeaderText = "الرقم القومي"
        GrdTick.Columns(15).Visible = False                                 '.HeaderText = "مبلغ العملية"
        GrdTick.Columns(16).Visible = False                                 '.HeaderText = "تاريخ العملية"
        GrdTick.Columns(17).Visible = False                                 '.HeaderText = "نوع المنتج"
        GrdTick.Columns(18).HeaderText = "نوع الخدمة"
        GrdTick.Columns(19).HeaderText = "نوع الشكوى"
        GrdTick.Columns(20).Visible = False                                 '.HeaderText = "بلد الراسل"
        GrdTick.Columns(21).Visible = False                                 '.HeaderText = "بلد المرسل إلية"
        GrdTick.Columns(22).HeaderText = "اسم المكتب"
        GrdTick.Columns(23).Visible = False                                 '.HeaderText = "اسم المنطقة"
        GrdTick.Columns(24).HeaderText = "تفاصيل الشكوى"
        GrdTick.Columns(25).Visible = False                                 '.HeaderText = "حالة الشكوى"
        GrdTick.Columns(26).Visible = False                                 '.HeaderText = "حالة المتابعة"
        GrdTick.Columns(27).Visible = False                                 '.HeaderText = "كود متابع الشكوى"
        GrdTick.Columns(28).HeaderText = "متابع الشكوى"
        GrdTick.Columns(29).Visible = False                                 '.HeaderText = "LstSqlEv"
        GrdTick.Columns(30).HeaderText = "تاريخ آخر تحديث"
        GrdTick.Columns(31).HeaderText = "نص آخر تحديث"
        GrdTick.Columns(32).Visible = False                                 '.HeaderText = "TkupUnread"
        GrdTick.Columns(33).Visible = False                                 '.HeaderText = "TkupEvtId"
        GrdTick.Columns(34).Visible = False                                 '.HeaderText = "EvNm"
        GrdTick.Columns(35).Visible = False                                 '.HeaderText = "EvSusp"
        GrdTick.Columns(36).HeaderText = "محرر آخر تحديث"                  '.HeaderText = "محرر اخر تحديث"
        GrdTick.Columns(37).Visible = False                                 '.HeaderText = "TkReOp"
        On Error Resume Next
        GrdTick.Columns(38).Visible = False                                 'Columns(16) "تاريخ استلام الشكوى"
        GrdTick.Columns(39).Visible = False                                 'Columns(36) عدد المتابعات
        GrdTick.Columns(40).Visible = False                                 ' نوع المنتج
        GrdTick.Columns(41).Visible = False
        GrdTick.Columns(42).Visible = False

        GrdTick.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GrdTick.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
        'GrdTick.AutoResizeColumns()
        GrdTick.Columns(24).Width = 400
        GrdTick.Columns(31).Width = 400
        GrdTick.Columns(24).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GrdTick.Columns(31).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GrdTick.AutoResizeRows()
        GrdTick.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Sub GrdTikFill(GrdTick As DataGridView, Tbl As DataTable)
        GrdTick.DataSource = Tbl
        'If GrdTick.Columns(0).HeaderText <> "م" Then GrdTick.Columns.Insert(0, New DataGridViewTextBoxColumn())

        GrdTick.Columns(0).HeaderText = "م"
        GrdTick.Columns(1).Visible = False                                 '.HeaderText = "SQL"
        GrdTick.Columns(2).Visible = False                                 '.HeaderText = "Product Kind"
        GrdTick.Columns(3).HeaderText = "تاريخ الشكوى"
        GrdTick.Columns(4).HeaderText = "رقم الشكوى"
        GrdTick.Columns(5).HeaderText = "مصدر الشكوى"
        GrdTick.Columns(6).HeaderText = "اسم العميل"
        GrdTick.Columns(7).HeaderText = "تليفون العميل1"
        GrdTick.Columns(8).HeaderText = "تليفون العميل2"
        GrdTick.Columns(9).Visible = False                                  '.HeaderText = "ايميل العميل"
        GrdTick.Columns(10).Visible = False                                 '.HeaderText = "عنوان العميل"
        GrdTick.Columns(11).HeaderText = "رقم الكارت"
        GrdTick.Columns(12).HeaderText = "رقم الشحنة"
        GrdTick.Columns(13).Visible = False                                 '.HeaderText = "رقم أمر الدقع"
        GrdTick.Columns(14).Visible = False                                 '.HeaderText = "الرقم القومي"
        GrdTick.Columns(15).Visible = False                                 '.HeaderText = "مبلغ العملية"
        GrdTick.Columns(16).Visible = False                                 '.HeaderText = "تاريخ العملية"
        GrdTick.Columns(17).Visible = False                                 '.HeaderText = "نوع المنتج"
        GrdTick.Columns(18).HeaderText = "نوع الخدمة"
        GrdTick.Columns(19).HeaderText = "نوع الشكوى"
        GrdTick.Columns(20).Visible = False                                 '.HeaderText = "بلد الراسل"
        GrdTick.Columns(21).Visible = False                                 '.HeaderText = "بلد المرسل إلية"
        GrdTick.Columns(22).HeaderText = "اسم المكتب"
        GrdTick.Columns(23).Visible = False                                 '.HeaderText = "اسم المنطقة"
        GrdTick.Columns(24).HeaderText = "تفاصيل الشكوى"
        GrdTick.Columns(25).Visible = False                                 '.HeaderText = "حالة الشكوى"
        GrdTick.Columns(26).Visible = False                                 '.HeaderText = "حالة المتابعة"
        GrdTick.Columns(27).Visible = False                                 '.HeaderText = "كود متابع الشكوى"
        GrdTick.Columns(28).HeaderText = "متابع الشكوى"
        GrdTick.Columns(29).Visible = False                                 '.HeaderText = "LstSqlEv"
        GrdTick.Columns(30).HeaderText = "تاريخ آخر تحديث"
        GrdTick.Columns(31).HeaderText = "نص آخر تحديث"
        GrdTick.Columns(32).Visible = False                                 '.HeaderText = "TkupUnread"
        GrdTick.Columns(33).Visible = False                                 '.HeaderText = "TkupEvtId"
        GrdTick.Columns(34).Visible = False                                 '.HeaderText = "EvNm"
        GrdTick.Columns(35).Visible = False                                 '.HeaderText = "EvSusp"
        GrdTick.Columns(36).Visible = False                                 '.HeaderText = "TkupUser"
        GrdTick.Columns(37).Visible = False                                 '.HeaderText = "TkReOp"
        GrdTick.Columns(38).Visible = False                                 '.HeaderText = "TkRecieveDt"
        GrdTick.Columns(39).HeaderText = "محرر التحديث"
        GrdTick.Columns(40).Visible = False                                 '.HeaderText = "UpdtUserLvl"
        GrdTick.Columns(41).Visible = False                                 '.HeaderText = "UpdtUserCase"
        GrdTick.Columns(42).Visible = False                                 '.HeaderText = "Help"

        GrdTick.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GrdTick.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
        GrdTick.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'GrdTick.AutoResizeColumns()
        'GrdTick.Columns(24).Width = 400
        'GrdTick.Columns(31).Width = 400
        GrdTick.Columns(24).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GrdTick.Columns(31).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GrdTick.AutoResizeRows()

        'GrdTick.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Function FncGrdCurrRow(GrdTicket As DataGridView, CurRw As Integer) As TickFld
        StruGrdTk.Ser = GrdTicket.Rows(CurRw).Cells(0).Value
        StruGrdTk.Sql = GrdTicket.Rows(CurRw).Cells(1).Value
        StruGrdTk.Tick = GrdTicket.Rows(CurRw).Cells(2).Value
        StruGrdTk.DtStrt = GrdTicket.Rows(CurRw).Cells(3).Value
        StruGrdTk.TkId = GrdTicket.Rows(CurRw).Cells(4).Value
        StruGrdTk.Src = GrdTicket.Rows(CurRw).Cells(5).Value
        StruGrdTk.ClNm = GrdTicket.Rows(CurRw).Cells(6).Value
        StruGrdTk.Ph1 = GrdTicket.Rows(CurRw).Cells(7).Value
        StruGrdTk.Ph2 = GrdTicket.Rows(CurRw).Cells(8).Value.ToString
        StruGrdTk.Email = GrdTicket.Rows(CurRw).Cells(9).Value.ToString
        StruGrdTk.Adress = GrdTicket.Rows(CurRw).Cells(10).Value.ToString
        StruGrdTk.Card = GrdTicket.Rows(CurRw).Cells(11).Value.ToString
        StruGrdTk.Trck = GrdTicket.Rows(CurRw).Cells(12).Value.ToString
        StruGrdTk.Gp = GrdTicket.Rows(CurRw).Cells(13).Value.ToString
        StruGrdTk.NID = GrdTicket.Rows(CurRw).Cells(14).Value.ToString
        StruGrdTk.Amnt = GrdTicket.Rows(CurRw).Cells(15).Value.ToString
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(16).Value) = False Then StruGrdTk.TransDt = GrdTicket.Rows(CurRw).Cells(16).Value
        StruGrdTk.ProdK = GrdTicket.Rows(CurRw).Cells(17).Value.ToString
        StruGrdTk.ProdNm = GrdTicket.Rows(CurRw).Cells(18).Value.ToString
        StruGrdTk.CompNm = GrdTicket.Rows(CurRw).Cells(19).Value.ToString
        StruGrdTk.Orig = GrdTicket.Rows(CurRw).Cells(20).Value.ToString
        StruGrdTk.Dist = GrdTicket.Rows(CurRw).Cells(21).Value.ToString
        StruGrdTk.Offic = GrdTicket.Rows(CurRw).Cells(22).Value.ToString
        StruGrdTk.Area = GrdTicket.Rows(CurRw).Cells(23).Value.ToString
        StruGrdTk.Detls = GrdTicket.Rows(CurRw).Cells(24).Value.ToString
        StruGrdTk.ClsStat = GrdTicket.Rows(CurRw).Cells(25).Value
        StruGrdTk.FlwStat = GrdTicket.Rows(CurRw).Cells(26).Value
        'If GrdTicket.Rows(CurRw).Cells(27).Value.ToString IsNot Nothing Then StruGrdTk.UserId = GrdTicket.Rows(CurRw).Cells(27).Value
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(27).Value) = False Then
            StruGrdTk.UserId = GrdTicket.Rows(CurRw).Cells(27).Value
        End If
        StruGrdTk.UsrNm = GrdTicket.Rows(CurRw).Cells(28).Value.ToString
        StruGrdTk.LstUpSql = GrdTicket.Rows(CurRw).Cells(29).Value
        'StruGrdTk.LstUpDt = GrdTicket.Rows(CurRw).Cells(30).Value
        StruGrdTk.LstUpTxt = GrdTicket.Rows(CurRw).Cells(31).Value
        StruGrdTk.LstUpUnRd = GrdTicket.Rows(CurRw).Cells(32).Value
        StruGrdTk.LstUpEvId = GrdTicket.Rows(CurRw).Cells(33).Value
        StruGrdTk.LstUpEnNm = GrdTicket.Rows(CurRw).Cells(34).Value
        StruGrdTk.LstUpSys = GrdTicket.Rows(CurRw).Cells(35).Value
        StruGrdTk.LstUpUsrNm = GrdTicket.Rows(CurRw).Cells(36).Value.ToString
        'On Error Resume Next
        On Error Resume Next
        If DBNull.Value.Equals(GrdTicket.Rows(CurRw).Cells(38).Value) = False Then StruGrdTk.RecvDt = GrdTicket.Rows(CurRw).Cells(38).Value
        StruGrdTk.EscCnt = GrdTicket.Rows(CurRw).Cells(39).Value
        StruGrdTk.PrdKNm = GrdTicket.Rows(CurRw).Cells(40).Value

        StruGrdTk.Help_ = GrdTicket.Rows(CurRw).Cells("CompHelp").Value.ToString
        Return StruGrdTk 'Return Grid Columns Structure
    End Function
    Public Function FncGrdTickInfo(GrdTicket As DataGridView) As TickInfo ' Function to Adjust Ticket Gridview
        GridCuntRtrn.TickCount = 0
        GridCuntRtrn.CompCount = 0
        GridCuntRtrn.NoFlwCount = 0
        GridCuntRtrn.UnReadCount = 0
        GridCuntRtrn.ClsCount = 0
        For Rws = 0 To GrdTicket.Rows.Count - 1
            GrdTicket.Rows(Rws).Cells(0).Value = Rws + 1                         'Set Grid Serial
            GridCuntRtrn.TickCount += 1                                          'Grid record count
            If GrdTicket.Rows(Rws).Cells(2).Value = True Then                    'if ticket kind is complaint
                GridCuntRtrn.CompCount += 1
            End If    'if Close Status is True                      if Ticket Kind is Complaint
            If GrdTicket.Rows(Rws).Cells(25).Value = True And GrdTicket.Rows(Rws).Cells(2).Value = True Then
                GridCuntRtrn.ClsCount += 1
            End If
            If GrdTicket.Rows(Rws).Cells(26).Value = False Then                   'if No Follow Status is True
                GridCuntRtrn.NoFlwCount += 1
            End If
            If GrdTicket.Rows(Rws).Cells(32).Value = False Then                   'if Read Status is false
                GridCuntRtrn.UnReadCount += 1
                GrdTicket.Rows(Rws).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            End If
        Next
        GrdTicket.AutoResizeColumns()
        Return GridCuntRtrn 'Return Counters Structure
    End Function
    Public Sub UpGrgFrmt(GridUpd As DataGridView, Optional StrTick As String = "")     'UpGrgFrmt(GridUpdt, GridTicket)
        For Cnt_ = 0 To GridUpd.Rows.Count - 1
            If GridUpd.Rows(Cnt_).Cells(5).Value = True Then                             'Event Sys True
                GridUpd.Rows(Cnt_).Cells(8).Value = ""                                    'Read Date
                GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSys
            ElseIf StrTick <> "" Then
                If GridUpd.Rows(Cnt_).Cells(4).Value = StrTick Then                        'Event UserId
                    If Year(GridUpd.Rows(Cnt_).Cells(8).Value) < 2000 Then
                        GridUpd.Rows(Cnt_).Cells(8).Value = ""                                  'Read Date
                    End If
                    GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrUsr
                ElseIf GridUpd.Rows(Cnt_).Cells(4).Value <> StrTick Then                        'Event UserId
                    If GridUpd.Rows(Cnt_).Cells(9).Value >= 3 And GridUpd.Rows(Cnt_).Cells(9).Value <= 5 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrSamCat
                    ElseIf GridUpd.Rows(Cnt_).Cells(9).Value = 12 Then
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrOperation
                    Else
                        GridUpd.Rows(Cnt_).DefaultCellStyle.BackColor = My.Settings.ClrNotUsr
                    End If
                End If
            End If
            If GridUpd.Rows(Cnt_).Cells(6).Value = False Then                              'Read Status
                If Year(GridUpd.Rows(Cnt_).Cells(8).Value) < 2000 Then
                    GridUpd.Rows(Cnt_).Cells(8).Value = ""                                    'Read Date
                End If
                GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            Else
                GridUpd.Rows(Cnt_).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            End If

        Next
        GridUpd.Columns(0).Visible = False                                                'Event SQL
        GridUpd.Columns(1).HeaderText = "تاريخ التحديث"
        GridUpd.Columns(2).HeaderText = "نص التحديث"
        GridUpd.Columns(3).HeaderText = "محرر التحديث"
        GridUpd.Columns(4).Visible = False                                               'Event UserId
        GridUpd.Columns(5).Visible = False                                               'Event Sys True
        GridUpd.Columns(6).Visible = False                                               'Read Status
        GridUpd.Columns(7).Visible = False                                               'Ticket SQL Relation
        GridUpd.Columns(8).HeaderText = "قراءة التحديث"
        GridUpd.Columns(9).Visible = False                                               '.HeaderText = "UCatLvl"
        GridUpd.AutoResizeColumns()
        GridUpd.Columns(2).Width = 600
        GridUpd.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridUpd.AutoResizeRows()
        GridUpd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridUpd.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    End Sub
    Public Function MyTeam(LedrCat As Integer, LedrId As Integer, UsrCas As String, Optional OnlyBckOff As Boolean = False) As String

        Dim UsrTable As DataTable = New DataTable
        Dim UsrStr As String = Nothing
        Dim BckOff As String = ""
        Dim TempNode() As TreeNode
        Dim TreeTemp As TreeView = New TreeView
        UsrTable.Rows.Clear()
        TreeTemp.Nodes.Clear()
        TreeTemp.Nodes.Add(LedrCat, LedrId)
        If OnlyBckOff = True Then
            BckOff = "AND (UCatLvl between 3 and 5)"
        End If
        UsrStr = UsrCas & " = " & Usr.PUsrID & " OR "
        'TkEmpNm
        '                   0  ,    1  ,     2     ***   
        If GetTbl("Select UsrId, UCatId, UCatIdSub From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) " & BckOff & " Order By UCatIdSub, UsrRealNm", UsrTable, "1048&H") = Nothing Then
            For Cnt_ = 0 To UsrTable.Rows.Count - 1
                TempNode = TreeTemp.Nodes.Find(UsrTable(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(UsrTable(Cnt_).Item(1).ToString, UsrTable(Cnt_).Item(0).ToString)
                    UsrStr &= UsrCas & " = " & UsrTable(Cnt_).Item(0).ToString & " OR "
                End If
            Next Cnt_
            If UsrStr.Length > 0 Then UsrStr = "(" & Mid(UsrStr, 1, UsrStr.Length - 4) & ")" Else UsrStr = ""
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If

        Return UsrStr
    End Function
    Public Sub LoadFrm(LblMsg As String, PX As Integer, PY As Integer)
        LodngFrm.Show()
        LodngFrm.Location = New Point((Screen.PrimaryScreen.Bounds.Width - LodngFrm.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - LodngFrm.Height) / 2)
        LodngFrm.Refresh()
        LodngFrm.LblMsg.Text = LblMsg
        LodngFrm.LblMsg.Refresh()
    End Sub
    Public Sub BtnSub(Frm As Form)
        'ConStrFn("My Labtop")
        'sqlCon.ConnectionString = strConn
        Form_ = Frm
        If Frm.Name <> "Login" Then
            Frm.Location = New Point(0, 52)
        End If

        Slctd = False
#Region "Default ContextMenuStrip"
        DefCmStrip = New ContextMenuStrip
        DefCmStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        CmStripPast = New ToolStripMenuItem
        'CmStripCatch = New ToolStripMenuItem
        'CmStripFix = New ToolStripMenuItem
        'CmStripRest = New ToolStripMenuItem
        CmStripFrmt = New ToolStripMenuItem

        DefCmStrip.Items.Add(CmStripPast)
        'DefCmStrip.Items.Add(CmStripCatch)
        'DefCmStrip.Items.Add(CmStripFix)
        'DefCmStrip.Items.Add(CmStripRest)
        DefCmStrip.Items.Add(CmStripFrmt)

        CmStripPast.Image = My.Resources.Paste1
        'CmStripCatch.Image = My.Resources.Catch1
        'CmStripFix.Image = My.Resources.pin1
        'CmStripRest.Image = My.Resources.Reset1
        CmStripFrmt.Image = My.Resources.Format1

        CmStripPast.Text = "Paste"
        'CmStripCatch.Text = "Catch Control"
        'CmStripFix.Text = "Fix Control"
        'CmStripRest.Text = "Restore Control"
        CmStripFrmt.Text = "Format Control"

        AddHandler CmStripPast.Click, AddressOf Paste_Click
        'AddHandler CmStripCatch.Click, AddressOf CmStripCatch_Click
        'AddHandler CmStripFix.Click, AddressOf CmStripFix_Click
        'AddHandler CmStripRest.Click, AddressOf CmStripRest_Click
        AddHandler CmStripFrmt.Click, AddressOf CmStripFrmt_Click
#End Region

#Region "Ticket ContextMenuStrip"
        TikCmStrip = New ContextMenuStrip
        TikCmStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        CmStripCopy = New ToolStripMenuItem
        CmStripPast = New ToolStripMenuItem
        CmStripPrvw = New ToolStripMenuItem
        'CmStripCatchTik = New ToolStripMenuItem
        'CmStripFixTik = New ToolStripMenuItem
        'CmStripRestTik = New ToolStripMenuItem
        CmStripFrmtTik = New ToolStripMenuItem

        TikCmStrip.Items.Add(CmStripCopy)
        TikCmStrip.Items.Add(CmStripPast)
        TikCmStrip.Items.Add(CmStripPrvw)
        'TikCmStrip.Items.Add(CmStripCatchTik)
        'TikCmStrip.Items.Add(CmStripFixTik)
        'TikCmStrip.Items.Add(CmStripRestTik)
        TikCmStrip.Items.Add(CmStripFrmtTik)

        CmStripCopy.Image = My.Resources.Copy
        CmStripPast.Image = My.Resources.Paste1
        CmStripPrvw.Image = My.Resources.Preview
        'CmStripCatchTik.Image = My.Resources.Catch1
        'CmStripFixTik.Image = My.Resources.pin1
        'CmStripRestTik.Image = My.Resources.Reset1
        CmStripFrmtTik.Image = My.Resources.Format1

        CmStripCopy.Text = "Copy Selected Cell"
        CmStripPast.Text = "Paste"
        CmStripPrvw.Text = "Preview " + Chr(38) + " Print"
        'CmStripCatchTik.Text = "Catch Control"
        'CmStripFixTik.Text = "Fix Control"
        'CmStripRestTik.Text = "Restore Control"
        CmStripFrmtTik.Text = "Format Control"

        AddHandler CmStripCopy.Click, AddressOf CopySelectedToolStripMenuItem_Click_1
        AddHandler CmStripPast.Click, AddressOf Paste_Click
        AddHandler CmStripPrvw.Click, AddressOf PreviewToolStripMenuItem_Click
        'AddHandler CmStripCatchTik.Click, AddressOf CmStripCatch_Click
        'AddHandler CmStripFixTik.Click, AddressOf CmStripFix_Click
        'AddHandler CmStripRestTik.Click, AddressOf CmStripRest_Click
        AddHandler CmStripFrmtTik.Click, AddressOf CmStripFrmt_Click
#End Region
        'UsrCnrlTbl = New DataTable
        'If GetTbl("Select * from AUsrControls where UCtlFormName = '" & Form_.Name & "' AND UCtlUsrId = " & Usr.PUsrID & " order by UCtlIndx", UsrCnrlTbl, "0000&H") = Nothing Then
        '    primaryKey(0) = UsrCnrlTbl.Columns("UCtlControlName")
        '    UsrCnrlTbl.PrimaryKey = primaryKey
        'Else
        '    MsgErr("Connection has been lost" & vbNewLine & "Please try agian")
        'End If
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
                                CmstripAsgn(C)
                                'If Application.OpenForms().OfType(Of UConfigCtrls).Any Then
                                '    If C.Dock = DockStyle.None And TypeOf C IsNot MenuStrip Then SndCntls(C)
                                'End If
                            Next
                        ElseIf TypeOf Crl Is Button Then
                            BttonCtrl = Crl
                            CalIfBtn(BttonCtrl)
                        ElseIf TypeOf Crl Is TextBox Then
                            TxtBoxCtrl = Crl
                            CalIfTxt(TxtBoxCtrl)
                        End If
                        CmstripAsgn(Crl)
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
                    CmstripAsgn(Crl)
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
            CmstripAsgn(CTTTRL)
        Next

#Region "Menu Strip"
        MenStrip = New MenuStrip
        MenStrip.Font = New Font("Times New Roman", 14, FontStyle.Regular)
        'Cmstrip1.RightToLeft = RightToLeft.Yes
        MenStrip.Dock = DockStyle.None
        MenStrip.AutoSize = False
        MenStrip.Width = Frm.Size.Width / 2
        MenStrip.Height = 30
        MenStrip.BackColor = Color.AntiqueWhite
        Frm.Controls.Add(MenStrip)
        MenStrip.Visible = False


        MenStripCmboFnt = New ToolStripComboBox
        'MenStripForward = New ToolStripMenuItem
        'MenStripBack = New ToolStripMenuItem
        'MenStripFlowBreak = New ToolStripMenuItem
        'MenStripMargin = New ToolStripMenuItem
        'MenStripMrgnLft = New ToolStripTextBox
        'MenStripMrgnTop = New ToolStripTextBox
        'MenStripMrgnRght = New ToolStripTextBox
        'MenStripMrgnBttm = New ToolStripTextBox
        'MenStripFlwDirc = New ToolStripComboBox
        'MenStripResetAll = New ToolStripMenuItem

        MenStripCmboFnt.Text = 0

        'MenStripForward.Text = "Forward"
        'MenStripBack.Text = "Back"
        'MenStripFlowBreak.Text = "Flow Break"
        'MenStripMargin.Text = "Margin"
        'MenStripResetAll.Text = "Reset All"


        MenStrip.Items.Add(MenStripCmboFnt)
        'MenStrip.Items.Add(MenStripForward)
        'MenStrip.Items.Add(MenStripBack)
        'MenStrip.Items.Add(MenStripFlowBreak)
        'MenStrip.Items.Add(MenStripMargin)
        'MenStrip.Items.Add(MenStripMrgnLft)
        'MenStrip.Items.Add(MenStripMrgnTop)
        'MenStrip.Items.Add(MenStripMrgnRght)
        'MenStrip.Items.Add(MenStripMrgnBttm)
        'MenStrip.Items.Add(MenStripFlwDirc)
        'MenStrip.Items.Add(MenStripResetAll)

        'For gg = 0 To MenStrip.Items.Count - 1
        '    MenStrip.Items(gg).BackColor = Color.Aqua
        '    MenStrip.Items(gg).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        'Next
        'MenStripFlwDirc.Items.Add("LeftToRight")
        'MenStripFlwDirc.Items.Add("TopDown")
        'MenStripFlwDirc.Items.Add("RightToLeft")
        'MenStripFlwDirc.Items.Add("BottomUp")


        'MenStripFlwDirc.RightToLeft = RightToLeft.No
        'MenStripFlwDirc.Size = New Point(75, 20)
        'MenStripMrgnLft.Size = New Point(30, 20)
        'MenStripMrgnTop.Size = New Point(30, 20)
        'MenStripMrgnRght.Size = New Point(30, 20)
        'MenStripMrgnBttm.Size = New Point(30, 20)

        MenStripCmboFnt.ComboBox.Height = 50
        MenStripCmboFnt.Size = New Point(75, 20)
        MenStripCmboFnt.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        MenStripCmboFnt.ComboBox.Text = HorizontalAlignment.Center
        MenStripCmboFnt.ComboBox.RightToLeft = RightToLeft.Yes

        For dd = 8 To 18
            MenStripCmboFnt.ComboBox.Items.Add(dd)
        Next

        AddHandler MenStripCmboFnt.SelectedIndexChanged, AddressOf FontSize_Click
        'AddHandler MenStripForward.Click, AddressOf MenStripForward_Click
        'AddHandler MenStripBack.Click, AddressOf MenStripBack_Click
        'AddHandler MenStripFlowBreak.Click, AddressOf MenStripFlowBreak_Click
        'AddHandler MenStripMargin.Click, AddressOf MenStripMargin_Click
        'AddHandler MenStripResetAll.Click, AddressOf MenStripResetAll_Click


        'CmStripFix.Enabled = False
#End Region
        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Public Function CmstripAsgn(Cnrol As Control) As Control
        '        Dim frmCollection = Application.OpenForms
        '        If frmCollection.OfType(Of WelcomeScreen).Any And frmCollection.OfType(Of Login).Any Then
        '            GoTo ChckCntlIfExit_
        '        ElseIf frmCollection.OfType(Of UConfigCtrls).Any Or frmCollection.OfType(Of Login).Any Then
        '            'Cnrol.Location = Cnrol.Location
        '            Cnrol.Font = Cnrol.Font
        '            Cnrol.Width = Cnrol.Width
        '            Cnrol.Height = Cnrol.Height
        '            Cnrol.ContextMenuStrip = DefCmStrip
        '            AddHandler Cnrol.MouseEnter, AddressOf Ctrl_MouseEnter
        '        Else
        '            GoTo ChckCntlIfExit_
        '        End If
        '        Return Cnrol
        '        Exit Function
        'ChckCntlIfExit_:

        '        If UsrCnrlTbl.Rows.Count > 0 Then
        '            Drow = UsrCnrlTbl.Rows.Find(Cnrol.Name)
        '            If Cnrol.Name = Drow.ItemArray(2) Then
        '                GoTo Yes_
        '            End If
        '        Else
        '            Dim Ctrls As New DataTable
        '            If GetTbl("Select  '',[CtlFormName], [CtlControlName], [CtlControlType],[CtlX], [CtlY], [CtlFntSize],[CtlFntWidth], [CtlFntHeight],[CtlIndx],[CtlMargnLft],[CtlMargnTop],[CtlMargnRght],[CtlMargnBttm],[CtlFlowBreak], " & Usr.PUsrID & " from AControls where CtlFormName = '" & Form_.Name & "' order by CtlIndx", Ctrls, "0000&H") = Nothing Then
        '                Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon)
        '                SQLBulkCopy.DestinationTableName = "AUsrControls"
        '                If sqlCon.State = ConnectionState.Closed Then
        '                    sqlCon.Open()
        '                End If
        '                SQLBulkCopy.WriteToServer(Ctrls)
        '                UsrCnrlTbl = Ctrls.Copy
        '                primaryKey(0) = UsrCnrlTbl.Columns("CtlControlName")
        '                UsrCnrlTbl.PrimaryKey = primaryKey
        '                SQLBulkCopy.Close()
        '                WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل الأدوات للإستخدام الأول ... " ' & Ctrls.Rows(0).Item(3)
        '                'GoTo Yes_
        '                'If InsUpd("insert into AUsrControls ([UCtlFormName],[UCtlControlName],[UCtlControlType],[UCtlX],[UCtlY],[UCtlFntSize],[UCtlFntWidth],[UCtlFntHeight],[UCtlIndx],[UCtlMargnLft],[UCtlMargnTop],[UCtlMargnRght],[UCtlMargnBttm],[UCtlFlowBreak],[UCtlUsrId]) values('" & Ctrls.Rows(0).Item(1) & "','" & Ctrls.Rows(0).Item(2) & "','" & Ctrls.Rows(0).Item(3) & "'," & Ctrls.Rows(0).Item(4) & "," & Ctrls.Rows(0).Item(5) & "," & Ctrls.Rows(0).Item(6) & "," & Ctrls.Rows(0).Item(7) & "," & Ctrls.Rows(0).Item(8) & "," & Ctrls.Rows(0).Item(9) & "," & Ctrls.Rows(0).Item(10) & "," & Ctrls.Rows(0).Item(11) & "," & Ctrls.Rows(0).Item(12) & "," & Ctrls.Rows(0).Item(13) & ",'" & Ctrls.Rows(0).Item(14) & "'," & Usr.PUsrID & ")", "0000&H") = Nothing Then
        '                'End If
        '            Else
        '                MsgErr("Connection has been lost" & vbNewLine & "Please try agian")
        '            End If
        '        End If
        '        Exit Function
        'Yes_:
        '        Cnrol.Font = New Font(Cnrol.Font.FontFamily, Drow.ItemArray(6), Cnrol.Font.Style)
        '        Cnrol.Width = Drow.ItemArray(7)
        '        Cnrol.Height = Drow.ItemArray(8)
        '        Dim rr As FlowLayoutPanel = Cnrol.Parent
        '        rr.Controls.SetChildIndex(Cnrol, Drow.ItemArray(9))
        '        Cnrol.Margin = New Padding(Drow.ItemArray(10), Drow.ItemArray(11), Drow.ItemArray(12), Drow.ItemArray(13))
        '        rr.SetFlowBreak(Cnrol, Drow.ItemArray(14))
        If Cnrol.Name = "GridUpdt" Then
            If Cnrol.ContextMenuStrip IsNot Nothing Then
                Cnrol.ContextMenuStrip.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                'CmStripCatch = New ToolStripMenuItem
                'CmStripFix = New ToolStripMenuItem
                'CmStripRest = New ToolStripMenuItem
                'CmStripFrmt = New ToolStripMenuItem

                'Cnrol.ContextMenuStrip.Items.Add(CmStripCatch)
                'Cnrol.ContextMenuStrip.Items.Add(CmStripFix)
                'Cnrol.ContextMenuStrip.Items.Add(CmStripRest)
                'Cnrol.ContextMenuStrip.Items.Add(CmStripFrmt)

                'CmStripCatch.Image = My.Resources.Catch1
                'CmStripFix.Image = My.Resources.pin1
                'CmStripRest.Image = My.Resources.Reset1
                'CmStripFrmt.Image = My.Resources.Format1

                'CmStripCatch.Text = "Catch Control"
                'CmStripFix.Text = "Fix Control"
                'CmStripRest.Text = "Restore Control"
                'CmStripFrmt.Text = "Format Control"

                'AddHandler CmStripCatch.Click, AddressOf CmStripCatch_Click
                'AddHandler CmStripFix.Click, AddressOf CmStripFix_Click
                'AddHandler CmStripRest.Click, AddressOf CmStripRest_Click
                'AddHandler CmStripFrmt.Click, AddressOf CmStripFrmt_Click
            End If
        Else
            Cnrol.ContextMenuStrip = TikCmStrip
        End If

        AddHandler Cnrol.MouseEnter, AddressOf Ctrl_MouseEnter
        Return Cnrol
    End Function
    Private Sub SndCntls(Ctrl As Control)
        If Ctrl.Dock = DockStyle.None Then
            Ctrl.ContextMenuStrip = DefCmStrip
            CtrlsTbl.Rows.Add()
            CtrlsTbl.Rows(CtlCnt).Item(1) = Form_.Name
            CtrlsTbl.Rows(CtlCnt).Item(2) = Ctrl.Name
            Dim Typ_ As Type = Ctrl.GetType
            CtrlsTbl.Rows(CtlCnt).Item(3) = Split(Typ_.ToString, ".")(3)
            CtrlsTbl.Rows(CtlCnt).Item(4) = Ctrl.Location.X
            CtrlsTbl.Rows(CtlCnt).Item(5) = Ctrl.Location.Y
            CtrlsTbl.Rows(CtlCnt).Item(6) = Ctrl.Font.SizeInPoints
            CtrlsTbl.Rows(CtlCnt).Item(7) = (Ctrl.Width)
            CtrlsTbl.Rows(CtlCnt).Item(8) = (Ctrl.Height)
            Dim rr As FlowLayoutPanel = Ctrl.Parent
            CtrlsTbl.Rows(CtlCnt).Item(9) = rr.Controls.GetChildIndex(Ctrl)
            CtrlsTbl.Rows(CtlCnt).Item(10) = Ctrl.Margin.Left
            CtrlsTbl.Rows(CtlCnt).Item(11) = Ctrl.Margin.Top
            CtrlsTbl.Rows(CtlCnt).Item(12) = Ctrl.Margin.Right
            CtrlsTbl.Rows(CtlCnt).Item(13) = Ctrl.Margin.Bottom
            CtrlsTbl.Rows(CtlCnt).Item(14) = rr.GetFlowBreak(Ctrl)
            CtlCnt += 1
        End If
    End Sub
    Public Sub CalIfBtn(Btn As Button)
        VCtheme.BtnCtrl(Btn)
        AddHandler Btn.MouseEnter, (AddressOf Btn_MouseEnter)
        AddHandler Btn.MouseLeave, (AddressOf Btn_MouseLeave)
    End Sub
    Public Sub CalIfTxt(TxtBox As TextBox)
        AddHandler TxtBox.Click, (AddressOf TxtSlctOn_Click)
        'AddHandler TxtBox.Enter, (AddressOf TxtSlctOn_Click)
    End Sub
    Public Sub Ctrl_MouseEnter(sender As Object, e As EventArgs)
        If Slctd = False Then
            CTTTRL = sender
            BacCtrl = CTTTRL.Parent
            'CTTTRL.BringToFront()
            If TypeOf CTTTRL Is DataGridView Then
                CmStripPast.Enabled = False
                If CTTTRL.Name = "GridTicket" Then
                    CmStripPrvw.Enabled = True
                ElseIf CTTTRL.Name = "GridHeld" Then
                    CmStripPrvw.Enabled = False
                ElseIf CTTTRL.Name = "GridHeldUpdt" Then
                    CmStripPrvw.Enabled = False
                End If
            ElseIf TypeOf CTTTRL Is TextBox Or TypeOf CTTTRL Is MaskedTextBox Then
                CmStripPrvw.Enabled = False
                CmStripPast.Enabled = True
            Else
                CmStripPrvw.Enabled = False
                CmStripPast.Enabled = False
            End If
        End If
        MenStrip.Visible = False

    End Sub
    Public Sub Btn_MouseEnter(sender As Object, e As EventArgs)
        Dim Botn As Button = sender
        BtnIncrease(Botn)
    End Sub
    Public Sub Btn_MouseLeave(sender As Object, e As EventArgs)
        Dim Botn As Control = sender
        BtnDecrease(Botn)
    End Sub
    'Public Sub Frm_MouseMove(sender As Object, e As MouseEventArgs)
    '    CTTTRL.Location = New Point(e.X - (CTTTRL.Size.Width / 2), e.Y + 1)
    '    WelcomeScreen.StatBrPnlEn.Text = New Point(e.X, e.Y).ToString
    'End Sub
    Private Sub CopySelectedToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Dim sms = (sender.GetCurrentParent()).SourceControl
        If TypeOf sms Is DataGridView Then
            Clipboard.SetText(sms.CurrentCell.Value)
        ElseIf TypeOf sms Is TextBox Or TypeOf sms Is MaskedTextBox Then
            Clipboard.SetText(sms.Text)
        End If
    End Sub
    Private Sub Paste_Click(sender As Object, e As EventArgs)
        Dim sms = (sender.GetCurrentParent()).SourceControl
        sms.Text = Clipboard.GetText()
    End Sub
    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim hit As DataGridView.HitTestInfo = GridTicket.HitTest()
        Dim sms = sender.GetCurrentParent().SourceControl
        If sms.SelectedCells.Count > 0 Then
            TikIDRep_ = sms.CurrentRow.Cells(0).Value
            TikFrmRep.ShowDialog()
        Else
            MsgInf("برجاء اختيار الشكوى المراد عرضها أولاً")
        End If
    End Sub
    Public Sub CmStripCatch_Click(sender As Object, e As EventArgs)
        'AddHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        BacCtrl.ContextMenuStrip = DefCmStrip
        CmStripCatch.Enabled = False
        CmStripFix.Enabled = True
        CmStripCatchTik.Enabled = False
        CmStripFixTik.Enabled = True
        Slctd = True
    End Sub
    Public Sub CmStripFix_Click(sender As Object, e As EventArgs)
        InsUpd("Update AUsrControls set UCtlX = " & CTTTRL.Location.X & ", UCtlY = " & CTTTRL.Location.Y & ", UCtlFntSize = " & CTTTRL.Font.Size &
               " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        'RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
        CmStripCatchTik.Enabled = True
        CmStripFixTik.Enabled = False
    End Sub
    Public Sub CmStripRest_Click(sender As Object, e As EventArgs)
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")
        CTTTRL.Location = New Point(tempTable.Rows(0).Item(4), tempTable.Rows(0).Item(5))
        CTTTRL.Font = New Font(CTTTRL.Font.FontFamily, tempTable.Rows(0).Item(6), CTTTRL.Font.Style)
        CTTTRL.Width = tempTable.Rows(0).Item(7)
        CTTTRL.Height = tempTable.Rows(0).Item(8)
        InsUpd("Update AUsrControls set UCtlX = " & CTTTRL.Location.X & ", UCtlY = " & CTTTRL.Location.Y & ", UCtlFntSize = " & CTTTRL.Font.Size & ", UCtlFntWidth = " & CTTTRL.Width & ", UCtlFntHeight = " & CTTTRL.Height &
               " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        'RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
        CmStripCatchTik.Enabled = True
        CmStripFixTik.Enabled = False
    End Sub
    Public Sub FontSize_Click(sender As Object, e As EventArgs)
        'Drow = UsrCnrlTbl.Rows.Find(CTTTRL.Name)
        'If CTTTRL.Name = Drow.ItemArray(2) Then
        CTTTRL.Font = New Font(CTTTRL.Font.FontFamily, CInt(MenStripCmboFnt.Text), CTTTRL.Font.Style)
        '    Drow.ItemArray(6) = 15
        'End If
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")
        'InsUpd("Update AUsrControls set UCtlFntSize = " & CTTTRL.Font.Size &
        '       " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        'RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        'WelcomeScreen.StatBrPnlEn.Text = ""

        Dim PPoint As Point
        PPoint = MenStrip.PointToScreen(New Point(MenStripCmboFnt.ComboBox.Location.X + MenStripCmboFnt.ComboBox.Width / 2, MenStripCmboFnt.ComboBox.Location.Y + MenStripCmboFnt.ComboBox.Height / 2))
        Cursor.Position = PPoint
    End Sub
    Public Sub MenStripForward_Click(sender As Object, e As EventArgs)
        Dim rr As FlowLayoutPanel = CTTTRL.Parent
        Dim CurrIndex As Integer = rr.Controls.GetChildIndex(CTTTRL)
        rr.Controls.SetChildIndex(CTTTRL, CurrIndex + 1)

        'rr.Controls.Item(rr.Controls.GetChildIndex(CTTTRL) - 1)
        If CurrIndex < rr.Controls.Count Then
            If IsNothing(myGraphics) = False Then myGraphics.Dispose()
            rr.Refresh()
            myGraphics = rr.CreateGraphics
            myGraphics.DrawRectangle(MyPen, CTTTRL.Location.X, CTTTRL.Location.Y, CTTTRL.Width, CTTTRL.Height)
            'InsUpd("update AAAAA set AAAAA.indx = " & rr.Controls.GetChildIndex(CTTTRL) & " Where AAAAA.Name = '" & CTTTRL.Name & "'", "0000&H")
            Dim ff As Control = rr.Controls.Item(rr.Controls.GetChildIndex(CTTTRL) - 1)
            'InsUpd("update AAAAA set AAAAA.indx = " & rr.Controls.GetChildIndex(rr.Controls.Item(rr.Controls.GetChildIndex(CTTTRL) - 1)) & " Where AAAAA.Name = '" & rr.Controls.Item(rr.Controls.GetChildIndex(CTTTRL) - 1).Name & "'", "0000&H")
        End If


        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")

        'CTTTRL.Width = CTTTRL.Width + 1
        'InsUpd("Update AUsrControls set UCtlFntWidth = " & CTTTRL.Width &
        '           " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        ''RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        'WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False

    End Sub
    Public Sub MenStripBack_Click(sender As Object, e As EventArgs)
        Dim rr As FlowLayoutPanel = CTTTRL.Parent
        Dim CurrIndex As Integer = rr.Controls.GetChildIndex(CTTTRL)
        If CurrIndex - 1 > 0 Then
            rr.Controls.SetChildIndex(CTTTRL, CurrIndex - 1)
            If IsNothing(myGraphics) = False Then myGraphics.Dispose()
            rr.Refresh()
            myGraphics = rr.CreateGraphics
            myGraphics.DrawRectangle(MyPen, CTTTRL.Location.X, CTTTRL.Location.Y, CTTTRL.Width, CTTTRL.Height)
            'InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")
            'InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) + 1)) & " Where AAAAA.Name = '" & FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) + 1).Name & "'", "0000&H")
        End If

        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")
        'CTTTRL.Width = CTTTRL.Width - 1
        'InsUpd("Update AUsrControls set UCtlFntWidth = " & CTTTRL.Width &
        '       " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        ''RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        'WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
    End Sub
    Public Sub MenStripFlowBreak_Click(sender As Object, e As EventArgs)
        Dim rr As FlowLayoutPanel = CTTTRL.Parent

        If rr.GetFlowBreak(CTTTRL) = False Then
            rr.SetFlowBreak(CTTTRL, True)
            MenStripFlowBreak.Text = "Same Line"
        Else
            rr.SetFlowBreak(CTTTRL, False)
            MenStripFlowBreak.Text = "New Line"
        End If

        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")
        'CTTTRL.Height = CTTTRL.Height + 1
        'InsUpd("Update AUsrControls set UCtlFntHeight = " & CTTTRL.Height &
        '       " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        ''RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        'WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
    End Sub
    Public Sub MenStripMargin_Click(sender As Object, e As EventArgs)
        Dim rr As FlowLayoutPanel = CTTTRL.Parent
        CTTTRL.Margin = New Padding(MenStripMrgnLft.Text, MenStripMrgnTop.Text, MenStripMrgnRght.Text, MenStripMrgnBttm.Text)
        If IsNothing(myGraphics) = False Then myGraphics.Dispose()
        rr.Refresh()
        myGraphics = rr.CreateGraphics
        myGraphics.DrawRectangle(MyPen, CTTTRL.Location.X, CTTTRL.Location.Y, CTTTRL.Width, CTTTRL.Height)
        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("select * from AControls where CtlFormName = '" & Form_.Name & "' AND CtlControlName = '" & CTTTRL.Name & "'", tempTable, "0000&H")
        'CTTTRL.Height = CTTTRL.Height - 1
        'InsUpd("Update AUsrControls set UCtlFntHeight = " & CTTTRL.Height &
        '       " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & CTTTRL.Name & "'", "0000&H")
        ''RemoveHandler BacCtrl.MouseMove, AddressOf Frm_MouseMove
        'WelcomeScreen.StatBrPnlEn.Text = ""
        Slctd = False
        CmStripCatch.Enabled = True
        CmStripFix.Enabled = False
    End Sub
    Public Sub CmStripFrmt_Click(sender As Object, e As EventArgs)
        MenStrip.Visible = True
        MenStrip.BringToFront()
        MenStrip.Dock = DockStyle.Top

        'Dim rr As FlowLayoutPanel = CTTTRL.Parent
        'myGraphics = rr.CreateGraphics
        'MyPen.DashStyle = Drawing.Drawing2D.DashStyle.Solid
        'myGraphics.DrawRectangle(MyPen, CTTTRL.Location.X, CTTTRL.Location.Y, CTTTRL.Width, CTTTRL.Height)

        'If rr.GetFlowBreak(CTTTRL) = False Then
        '    MenStripFlowBreak.Text = "New Line"
        'Else
        '    MenStripFlowBreak.Text = "Same Line"
        'End If


        'MenStripMrgnLft.Text = CTTTRL.Margin.Left
        'MenStripMrgnTop.Text = CTTTRL.Margin.Top
        'MenStripMrgnRght.Text = CTTTRL.Margin.Right
        'MenStripMrgnBttm.Text = CTTTRL.Margin.Bottom

        'Dim X_ As Integer = 0
        'Dim Y_ As Integer = 0

        'If TypeOf CTTTRL.Parent Is Form Or TypeOf CTTTRL.Parent Is TabPage Then
        '    If CTTTRL.Location.X + MenStrip.Width > Form_.Width Then
        '        X_ = CTTTRL.Location.X - MenStrip.Width
        '    Else
        '        X_ = CTTTRL.Location.X
        '    End If
        'ElseIf TypeOf CTTTRL.Parent Is GroupBox Then
        '    If CTTTRL.Parent.Location.X + MenStrip.Width > Form_.Width Then
        '        X_ = CTTTRL.Parent.Location.X - MenStrip.Width
        '    Else
        '        X_ = CTTTRL.Parent.Location.X
        '    End If
        'End If

        'If TypeOf CTTTRL.Parent Is Form Or TypeOf CTTTRL.Parent Is TabPage Then
        '    If CTTTRL.Location.Y + MenStrip.Height + CTTTRL.Height + 35 > Form_.Height Then
        '        Y_ = (CTTTRL.Location.Y) + (CTTTRL.Location.Y + MenStrip.Height + CTTTRL.Height + 35 - Form_.Height) - MenStrip.Height
        '    Else
        '        Y_ = CTTTRL.Location.Y + CTTTRL.Height
        '    End If
        'ElseIf TypeOf CTTTRL.Parent Is GroupBox Then
        '    If CTTTRL.Parent.Location.Y + MenStrip.Height > Form_.Height Then
        '        Y_ = CTTTRL.Parent.Location.Y - CTTTRL.Height - MenStrip.Height
        '    Else
        '        Y_ = CTTTRL.Parent.Location.Y
        '    End If
        'End If


        'MenStrip.Location = New Point(X_, Y_)

        If Form_.RightToLeft = True Then
            MenStrip.RightToLeft = RightToLeft.No
        Else
            MenStrip.RightToLeft = RightToLeft.Yes
        End If

        MenStripCmboFnt.Text = CTTTRL.Font.Size
        Dim PPoint As Point
        PPoint = MenStrip.PointToScreen(New Point(MenStripCmboFnt.ComboBox.Location.X + MenStripCmboFnt.ComboBox.Width / 2, MenStripCmboFnt.ComboBox.Location.Y + MenStripCmboFnt.ComboBox.Height / 2))
        Cursor.Position = PPoint

        'If TypeOf CTTTRL.Parent Is Form Or TypeOf CTTTRL.Parent Is TabPage Then
        '    If CTTTRL.Location.X + Cmstrip1.Width > Form_.Width Then
        '        Cmstrip1.Location = New Point(X_, CTTTRL.Location.Y + CTTTRL.Height)
        '    Else
        '        Cmstrip1.Location = New Point(CTTTRL.Location.X, CTTTRL.Location.Y + CTTTRL.Height)
        '    End If

        'ElseIf TypeOf CTTTRL.Parent Is GroupBox Then
        '    If CTTTRL.Parent.Location.X + Cmstrip1.Width > Form_.Width Then
        '        Cmstrip1.Location = New Point(CTTTRL.Parent.Location.X - Cmstrip1.Width, CTTTRL.Parent.Location.Y + CTTTRL.Height)
        '    Else
        '        Cmstrip1.Location = New Point(CTTTRL.Parent.Location.X, CTTTRL.Parent.Location.Y + CTTTRL.Height)
        '    End If
        'End If



    End Sub
    Public Sub MenStripResetAll_Click(sender As Object, e As EventArgs)
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl("Select * from AControls where CtlFormName = '" & Form_.Name & "'", tempTable, "0000&H")

        Dim EstCtrl As New Control

        For Each CTTTRL In Form_.Controls
            If TypeOf CTTTRL Is TabControl Then
                For Each TabPg1 In CTTTRL.Controls
                    For Each Crl As Control In TabPg1.Controls
                        For cnt = 0 To tempTable.Rows.Count - 1
                            If Crl.Name = tempTable.Rows(cnt).Item(2) Then
                                Crl.Location = New Point(tempTable.Rows(cnt).Item(4), tempTable.Rows(cnt).Item(5))
                                Crl.Font = New Font(Crl.Font.FontFamily, tempTable.Rows(cnt).Item(6), Crl.Font.Style)
                                Crl.Width = tempTable.Rows(cnt).Item(7)
                                Crl.Height = tempTable.Rows(cnt).Item(8)
                                UpdtCtrl(Crl)
                            End If
                        Next cnt
                        If TypeOf TabPg1 Is GroupBox Then
                            For Each c As Control In TabPg1
                                For cnt = 0 To tempTable.Rows.Count - 1
                                    If c.Name = tempTable.Rows(cnt).Item(2) Then
                                        c.Location = New Point(tempTable.Rows(cnt).Item(4), tempTable.Rows(cnt).Item(5))
                                        c.Font = New Font(c.Font.FontFamily, tempTable.Rows(cnt).Item(6), c.Font.Style)
                                        c.Width = tempTable.Rows(cnt).Item(7)
                                        c.Height = tempTable.Rows(cnt).Item(8)
                                        UpdtCtrl(c)
                                    End If
                                Next cnt
                            Next
                        End If
                    Next
                Next
            ElseIf TypeOf CTTTRL Is GroupBox Then
                For Each c As Control In CTTTRL.Controls
                    For cnt = 0 To tempTable.Rows.Count - 1
                        If c.Name = tempTable.Rows(cnt).Item(2) Then
                            c.Location = New Point(tempTable.Rows(cnt).Item(4), tempTable.Rows(cnt).Item(5))
                            c.Font = New Font(c.Font.FontFamily, tempTable.Rows(cnt).Item(6), c.Font.Style)
                            c.Width = tempTable.Rows(cnt).Item(7)
                            c.Height = tempTable.Rows(cnt).Item(8)
                            UpdtCtrl(c)
                        End If
                    Next
                Next
            End If
            For cnt = 0 To tempTable.Rows.Count - 1
                If CTTTRL.Name = tempTable.Rows(cnt).Item(2) Then
                    CTTTRL.Location = New Point(tempTable.Rows(cnt).Item(4), tempTable.Rows(cnt).Item(5))
                    CTTTRL.Font = New Font(CTTTRL.Font.FontFamily, tempTable.Rows(cnt).Item(6), CTTTRL.Font.Style)
                    CTTTRL.Width = tempTable.Rows(cnt).Item(7)
                    CTTTRL.Height = tempTable.Rows(cnt).Item(8)
                    UpdtCtrl(CTTTRL)
                End If
            Next cnt

        Next
        MenStrip.Visible = False
    End Sub
    Private Sub UpdtCtrl(UpdtCtrl As Control)
        InsUpd("Update AUsrControls set UCtlX = " & UpdtCtrl.Location.X & ", UCtlY = " & UpdtCtrl.Location.Y & ", UCtlFntSize = " & UpdtCtrl.Font.Size & ", UCtlFntWidth = " & UpdtCtrl.Width & ", UCtlFntHeight = " & UpdtCtrl.Height &
             " Where UCtlUsrId = " & Usr.PUsrID & " AND UCtlFormName = '" & Form_.Name & "' AND UCtlControlName = '" & UpdtCtrl.Name & "'", "0000&H")
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
    Public Sub GettAttchUpdtesFils()
        LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل الصورة المرفقات .................."
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل قائمة المرفقات .................."
        Dim lol As String
        Dim arr() As String
        FTPTable.Rows.Clear()
        FTPTable.Columns.Clear()
        Dim colInt32 As New DataColumn("ID")
        colInt32.DataType = Type.GetType("System.Int32")
        FTPTable.Columns.Add(colInt32)
        FTPTable.Columns.Add("Name")
        FTPTable.Columns.Add("Date Modified")
        FTPTable.Columns.Add("Type")
        FTPTable.Columns.Add("Size")

        'UpdtCurrTbl
        Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/CompUpdates/")
        request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
        request.Timeout = 10000
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            responseStream.ReadTimeout = 20000
            Dim reader As StreamReader = New StreamReader(responseStream)
            Do
                lol = reader.ReadLine
                If Len(lol) < 1 Then Exit Do
                arr = Split(lol, vbNewLine)
                For i = 0 To Split(lol, vbNewLine).Count - 1
                    If Len(arr(i)) > 0 Then
                        Dim FilNm As String = 0
                        Dim FileDt As DateTime = Split(Split(arr(i), " ")(0), "-")(1) & "/" & Split(Split(arr(i), " ")(0), "-")(0) & "/" & Split(Split(arr(i), " ")(0), "-")(2) & " " & Split(arr(i), " ")(2)
                        Dim FileType As String = ""
                        Dim INT_ As Integer = Nothing
                        Dim FilSize As Double = 0
                        Dim FilSize2 As String = ""

                        If Split(arr(i), " ").Count > 1 Then
                            INT_ = Split(arr(i), " ").Count - 1
                            If (Split(arr(i), " ")(9)) = "<DIR>" Then
                                FilNm = Trim(Split(arr(i), ">")(1))
                                FileType = "Folder"
                                FilSize = 0
                            ElseIf IsNumeric(Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)) = True Then
                                FilSize = Split(Trim(Mid(arr(i), 20, Len(arr(i)))), " ")(0)
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
                            End If
                            FTPTable.Rows.Add(Split(FilNm, ".")(0), FilNm, FileDt, FileType, FilSize2)
                        End If
                    End If
                Next
            Loop
            request.Abort()
            reader.Close()
            response.Close()
            WelcomeScreen.StatBrPnlAr.Text = ""
        Catch ex As Exception
            WelcomeScreen.StatBrPnlAr.Text = "لم يتم تحميل قائمة المرفقات"
            request.Abort()
        End Try
    End Sub ' Attached Table
    Public Function ServrTime() As DateTime
        Dim TimeTble As New DataTable
        TimeTble.Rows.Clear()
        TimeTble.Columns.Clear()
        Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
        Try
            'sqlComm.CommandTimeout = 90
            sqlComm.Connection = sqlCon
            SQLGetAdptr.SelectCommand = sqlComm
            sqlComm.CommandType = CommandType.Text
            sqlComm.CommandText = "Select GetDate() as Now_"
            SQLGetAdptr.Fill(TimeTble)
            Nw = Format(TimeTble.Rows(0).Item(0), "yyyy/MMM/dd hh:mm:ss tt")

        Catch ex As Exception
            Errmsg = "X"
            Dim frmCollection = Application.OpenForms
            If frmCollection.OfType(Of WelcomeScreen).Any Then
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            End If
        End Try
        Return Nw
        SQLGetAdptr.Dispose()
    End Function
    Public Sub FlushMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub
    Public Sub CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String)
        Dim oShell As Object
        Dim oLink As Object
        'you don’t need to import anything in the project reference to create the Shell Object
        Try
            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetParntCtrl(Contl As Control) As List(Of Control)
        Dim CtrlTree As New List(Of Control)
        Do
            If Nothing Is Contl.Parent Then
                Return CtrlTree
            Else
                Contl = Contl.Parent
            End If
            CtrlTree.Add(Contl)
        Loop
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
        message.Importance = Import
        Try
            message.SendAndSaveCopy()
        Catch ex As Exception
            MailRsult = "X"
        End Try
        Return MailRsult
    End Function
    Public Function LogCollect() As Integer
        Dim Colecrslt As Integer = 0
        Dim Transction As SqlTransaction = Nothing             'SQL Transaction
        Dim OfflineCon As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OfflineDB.mdf;Integrated Security=True")
        Dim SQLGetAdptr1 As New SqlDataAdapter            'SQL Table Adapter
        Dim SQLComX As New SqlCommand
        SQLComX.Connection = OfflineCon
        SQLGetAdptr1.SelectCommand = SQLComX
        SQLComX.CommandType = CommandType.Text
        SQLComX.CommandText = "select [LogSer],[LogDt],[LogErrCD],[Logtype],[LogExMsg],[LogSQLStr],[LogRwCnt],[LogIP],[LogUsrID],[VErrFrm],[VErrSub],[VErrDetails],[VErrRmrk] from ALog LEFT OUTER JOIN AErrApdx on VErrId = LogErrCD order by LogSer"
        Try
            LogOfflinTbl.Rows.Clear()
            LogOfflinTbl.Columns.Clear()
            SQLGetAdptr1.Fill(LogOfflinTbl)
            Dim Max_ As New Integer
            If LogOfflinTbl.Rows.Count > 0 Then
                Colecrslt = LogOfflinTbl.Rows.Count
                Max_ = LogOfflinTbl.Rows(LogOfflinTbl.Rows.Count - 1).Item(0)
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                Transction = sqlCon.BeginTransaction()
                Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Transction)
                SQLBulkCopy.DestinationTableName = "ALog"
                'Try
                For PP = 0 To 8
                    SQLBulkCopy.ColumnMappings.Add(LogOfflinTbl.Columns(PP).ColumnName, LogOfflinTbl.Columns(PP).ColumnName)
                Next
                SQLBulkCopy.WriteToServer(LogOfflinTbl)
                Transction.Commit()
                'Try
                Dim SQLCom As New SqlCommand
                SQLCom.Connection = OfflineCon
                SQLCom.CommandType = CommandType.Text
                SQLCom.CommandText = "Delete from ALog Where LogSer <=" & Max_
                If OfflineCon.State = ConnectionState.Closed Then
                    OfflineCon.Open()
                End If
                SQLCom.ExecuteNonQuery()
                '    Catch ex As Exception
                '        MsgBox(ex.Message.ToString)
                '    End Try
                'Catch ex As Exception
                '    Transction.Rollback()
                '    MsgBox(ex.Message.ToString)
                'End Try
            Else
                AppLogTbl(1000000, 0, "", "There is No records To Collect", LogOfflinTbl.Rows.Count)
            End If
            AppLogTbl(1000000, 0, "", "Log has been collected from " & LogOfflinTbl.Rows(0).Item(0) & " To " & LogOfflinTbl.Rows(LogOfflinTbl.Rows.Count - 1).Item(0), LogOfflinTbl.Rows.Count)
        Catch ex As Exception
            Colecrslt = -1
            AppLogTbl(1000001, 1, ex.Message, SQLComX.CommandText)
        End Try
        Return Colecrslt
    End Function
    Public Function CompOffLine() As Integer
        Dim Colecrslt As Integer = 0
        Dim Transction As SqlTransaction = Nothing             'SQL Transaction
        Dim OfflineCon As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OfflineDB.mdf;Integrated Security=True")
        'Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\SharedVB\NewVOCAPlus\VOCAPlus\OfflineDB.mdf;Integrated Security=True
        Dim SQLGetAdptr1 As New SqlDataAdapter            'SQL Table Adapter
        Dim SQLComX As New SqlCommand
        SQLComX.Connection = OfflineCon
        SQLGetAdptr1.SelectCommand = SQLComX
        SQLComX.CommandType = CommandType.Text
        SQLComX.CommandText = "select [TkSQL],[TkID],[TkDtStart],[TkDtClose],[TkDuration],[TkKind],[TkFnPrdCd],[TkCompSrc],[TkClNm],[TkClPh],[TkClPh1],[TkClAdr],[TkClNtID],[TkShpNo],[TkGBNo],[TkCardNo],[TkAmount],[TkTransDate],[TkDetails],[TkSndrCoun],[TkConsigCoun],[TkTaskOwnr],[TkOffNm],[TkEmpNm0],[TkEmpNm],[TkRecieveDt],[TkSatLv],[TkFolw],[TkClsStatus],[TkMail],[TkMailYN],[TkReOp],[TkQlity],[TkEscTyp],[TkReAssign],TkRegisOff,TkRegisOffAprvd from Tickets order by TkSQL"
        Try
            CompfflinTbl.Rows.Clear()
            CompfflinTbl.Columns.Clear()
            SQLGetAdptr1.Fill(CompfflinTbl)
            Dim Max_ As New Integer
            If CompfflinTbl.Rows.Count > 0 Then
                Colecrslt = CompfflinTbl.Rows.Count
                Max_ = CompfflinTbl.Rows(CompfflinTbl.Rows.Count - 1).Item(0)
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                Transction = sqlCon.BeginTransaction()
                Dim SQLStr As String = ""
                For FF = 0 To CompfflinTbl.Rows.Count - 1
                    SQLStr &= "[TkID] = " & CompfflinTbl.Rows(FF).Item(0) & " Or "
                Next
                sqlComminsert_1.Connection = sqlCon
                sqlComminsert_1.Transaction = Transction
                sqlComminsert_1.CommandText = "update Tickets set Tickets.TkID = Tickets.TkSQL, TkRegisOff = 1 where " & Mid(SQLStr, 1, SQLStr.Length - 4)

                Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Transction)
                SQLBulkCopy.DestinationTableName = "Tickets"
                Try
                    For PP = 0 To CompfflinTbl.Columns.Count - 1
                        SQLBulkCopy.ColumnMappings.Add(CompfflinTbl.Columns(PP).ColumnName, CompfflinTbl.Columns(PP).ColumnName)
                    Next
                    SQLBulkCopy.WriteToServer(CompfflinTbl)
                    sqlComminsert_1.ExecuteNonQuery()
                    Transction.Commit()
                    Try
                        Dim SQLCom As New SqlCommand
                        SQLCom.Connection = OfflineCon
                        SQLCom.CommandType = CommandType.Text
                        SQLCom.CommandText = "Delete from Tickets Where TkID <=" & Max_
                        If OfflineCon.State = ConnectionState.Closed Then
                            OfflineCon.Open()
                        End If
                        SQLCom.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString)
                    End Try
                Catch ex As Exception
                    Transction.Rollback()
                    MsgBox(ex.Message.ToString)
                End Try
            Else
                AppLogTbl(1000000, 0, "", "There is No Complaints To Collect", CompfflinTbl.Rows.Count)
            End If
            AppLogTbl(1000000, 0, "", "Log has been collected from ", CompfflinTbl.Rows.Count)
        Catch ex As Exception
            Colecrslt = -1
            AppLogTbl(1000001, 1, ex.Message, SQLComX.CommandText)
        End Try
        Return Colecrslt
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
                        richtxtbx.SelectionFont = New Font("Times New Roman", 14, FontStyle.Bold)
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
End Module

