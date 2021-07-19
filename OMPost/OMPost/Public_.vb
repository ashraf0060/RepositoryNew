Imports System.Data.SqlClient
Imports ClosedXML.Excel

Module Public_
    Public Frm As New Form
    Public GrdView As DataGridView
    Public CntxStrip As New ContextMenuStrip
    Dim Form_ As Form
    Dim BttonCtrl As Button
    Dim TxtBoxCtrl As TextBox
    Dim Slctd As Boolean = False
    Dim bolyy As Boolean = False
    Public StrFileName As String = "X"
    Public OfflineCon As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Oman\OMPost.mdf;Integrated Security=True")
    Public ConSTR As New String("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Oman\OMPost.mdf;Integrated Security=True")
    Public Errmsg As String = ""
    Public MainTbl As New DataTable
    Public sqlComm As New SqlCommand                    'SQL Command
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
    Public Sub LoadfFrm(LblMsg As String, PX As Integer, PY As Integer)
        LoadFrm.Show()
        LoadFrm.Location = New Point((Screen.PrimaryScreen.Bounds.Width - LoadFrm.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - LoadFrm.Height) / 2)
        LoadFrm.Refresh()
    End Sub
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String

        SQLGetAdptr = New SqlDataAdapter
        Errmsg = Nothing
        LoadfFrm("", 350, 500)
        OfflineCon.ConnectionString = ConSTR
        'sqlComm.CommandTimeout = 30
        sqlComm.Connection = OfflineCon
        SQLGetAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SQLGetAdptr.Fill(SqlTbl)
            LoadFrm.Close()
        Catch ex As Exception
            LoadFrm.Close()
            Errmsg = ex.Message
        End Try
        SqlTbl.Dispose()
        SQLGetAdptr.Dispose()
        Return Errmsg
        LoadFrm.Close()
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
            LoadfFrm("", 350, 500)
            Try
                Dim Workbook As XLWorkbook = New XLWorkbook()
                Workbook.Worksheets.Add(MainTbl, "FileNm")
                Workbook.SaveAs(D.FileName)
                LoadFrm.Close()
                MsgBox("Done")
            Catch ex As Exception
                LoadFrm.Close()
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
End Module
