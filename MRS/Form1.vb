Imports Microsoft.Exchange.WebServices.Data
Imports System.Threading
Imports System.IO

Public Class Form1
    Dim PrsFrom, PrsTo, PrsCC, PrsSbjct As String '
    Dim PrsDt As Date
    Dim CCDrop As Boolean = False
    Dim MailCount As Integer = 0
    Dim TMailCount As Integer = 0
    Dim Ertv As Integer = 0
    Dim Edrp As Integer = 0
    Dim EHshk As Integer = 0
    Dim ERej As Integer = 0
    Dim JbRef As Integer = 0
    Dim MailRequest As New DataTable
    Dim AutoCompTbl As New DataTable
    Dim primaryKey(0) As DataColumn
    Dim AutoDRRow As DataRow
    Dim FoldrTbl As New DataTable
    Dim EmailSubj As String = ""
    Dim EmailBody As String = ""
    Dim ChkDay As Date = Today
    Private exchange As ExchangeService
    Dim message As EmailMessage
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeViewFolder.Nodes.Add("Inbox", "Inbox")
        TreeViewFolder.Nodes.Add("Drafts", "Drafts")
        TreeViewFolder.Nodes.Add("SentItems", "SentItems")
        TreeViewFolder.Nodes.Add("DeletedItems", "DeletedItems")
        TreeViewFolder.Nodes.Add("JunkEmail", "JunkEmail")
        TreeViewFolder.Nodes.Add("Outbox", "Outbox")

        TreeViewFolder.SelectedNode = TreeViewFolder.Nodes(0)

        webMail.Width = Me.Size.Width - 210

        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        ListView1.Columns.Add("From Name", 100)
        ListView1.Columns.Add("From Address", 100)
        ListView1.Columns.Add("To", 150)
        ListView1.Columns.Add("CC", 150)
        ListView1.Columns.Add("Subject", 150)
        ListView1.Columns.Add("Body", 200)

        FoldrTbl.Columns.Add("From Name")
        FoldrTbl.Columns.Add("From Address")
        FoldrTbl.Columns.Add("To")
        FoldrTbl.Columns.Add("CC")
        FoldrTbl.Columns.Add("Subject")
        FoldrTbl.Columns.Add("Body")
    End Sub
#Region "Fill Auto Complete Table With Reader Method"
    Private Sub AutoComp1()
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        Invoke(Sub() LblFtr.Text = "Getting Auto Fill Data ...")
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "Select DISTINCT AutMail from AutoComplete"
        Reader_ = sqlComm.ExecuteReader
        Reader_.Read()
        While Reader_.Read()
            With TextBox1
                Invoke(Sub() .AutoCompleteMode = AutoCompleteMode.Suggest)
                Invoke(Sub() .AutoCompleteSource = AutoCompleteSource.CustomSource)
                Invoke(Sub() .AutoCompleteCustomSource.Add(Reader_.Item(0)))
            End With
        End While
        Invoke(Sub() LblFtr.Text = "")
        Reader_.Close()
        sqlCon.Close()
    End Sub
#End Region
#Region "Fill Auto Complete Table With DataTable Method"
    Private Sub AutoComp()
        AutoCompTbl.Rows.Clear()
        GetTbl("Select DISTINCT AutMail from AutoComplete", AutoCompTbl, "0000&H")
        Invoke(Sub()
                   With TextBox1
                       .AutoCompleteMode = AutoCompleteMode.Suggest
                       .AutoCompleteSource = AutoCompleteSource.CustomSource
                       For Cnt_ = 0 To AutoCompTbl.Rows.Count - 1
                           .AutoCompleteCustomSource.Add(AutoCompTbl.Rows(Cnt_).Item("AutMail"))
                       Next
                   End With
               End Sub)
    End Sub
#End Region
#Region "Get Folder Items To Gridview Control"
    Private Sub GetFoldrItems1()
        'primaryKey(0) = AutoCompTbl.Columns("AutMail")
        'AutoCompTbl.PrimaryKey = primaryKey
        'DirRow = AutoCompTbl.Rows.Find(TextBox1.Text)

        If IsNothing(AutoDRRow) = True Then
            Dim NewRow As DataRow = AutoCompTbl.NewRow()
            'NewRow("AutMail") = TextBox1.Text
            AutoCompTbl.Rows.Add(NewRow)
            Invoke(Sub() TextBox1.AutoCompleteCustomSource.Add(TextBox1.Text))
            InsUpd("insert into AutoComplete (AutMail) Values ('" & TextBox1.Text & "')", "0000&H")
        End If
        ConnectToExchangeServer()
        If exchange IsNot Nothing Then
            Try
                Invoke(Sub()
                           DataGridView1.Rows.Clear()

                           Dim MlFldrNm As New WellKnownFolderName
                           If IsNothing(TreeViewFolder.SelectedNode) = False Then
                               If TreeViewFolder.SelectedNode.Name = "Inbox" Then
                                   MlFldrNm = WellKnownFolderName.Inbox
                               ElseIf TreeViewFolder.SelectedNode.Name = "Drafts" Then
                                   MlFldrNm = WellKnownFolderName.Drafts
                               ElseIf TreeViewFolder.SelectedNode.Name = "SentItems" Then
                                   MlFldrNm = WellKnownFolderName.SentItems
                               ElseIf TreeViewFolder.SelectedNode.Name = "DeletedItems" Then
                                   MlFldrNm = WellKnownFolderName.DeletedItems
                               ElseIf TreeViewFolder.SelectedNode.Name = "JunkEmail" Then
                                   MlFldrNm = WellKnownFolderName.JunkEmail
                               ElseIf TreeViewFolder.SelectedNode.Name = "Outbox" Then
                                   MlFldrNm = WellKnownFolderName.Outbox
                               End If
                           End If
                           Dim findResults As FindItemsResults(Of Item) = exchange.FindItems(MlFldrNm, New ItemView(10000))
                           MsgTxtResp("Retriving {Ref. " & JbRef & "} Start at " & Now)
                           MsgTxtResp("number of emails:  " & findResults.Count)
                           MailCount = 0
                           TMailCount += findResults.Count
                           For Each item As Item In findResults
                               PrsFrom = ""
                               PrsTo = ""
                               PrsCC = ""
                               PrsSbjct = ""
                               CCDrop = False
                               MailCount += 1
                               Invoke(Sub() LblFtr.Text = ("Proccess email: " & MailCount & " Of " & findResults.Count))
                               message = EmailMessage.Bind(exchange, item.Id)
                               PrsFrom = message.From.Address
                               PrsSbjct = message.Subject
                               PrsCC = message.CcRecipients.ToString
                               If PrsSbjct = Nothing Then
                                   PrsSbjct = "X"
                               End If
                               PrsSbjct = Strings.Right(PrsSbjct, PrsSbjct.Length - Strings.InStr(PrsSbjct, "MRSCOMP", CompareMethod.Text) + 1)
                               PrsDt = message.DateTimeReceived
                               PrsTo = message.ToRecipients.Item(0).Address

                               Dim NewRow As DataRow = FoldrTbl.NewRow()
                               NewRow("From Name") = message.From.Name
                               NewRow("From Address") = message.From.Address
                               For Tocnt = 0 To message.DisplayTo.Count - 1
                                   NewRow("To") &= message.DisplayTo(Tocnt).ToString
                               Next Tocnt
                               If IsNothing(message.DisplayCc) = False Then
                                   For CCcnt = 0 To message.DisplayCc.Count - 1
                                       NewRow("CC") &= message.DisplayCc(CCcnt)
                                   Next CCcnt
                               End If
                               NewRow("Subject") = message.Subject
                               NewRow("Body") = message.Body
                               FoldrTbl.Rows.Add(NewRow)
                           Next
                           Invoke(Sub() DataGridView1.DataSource = FoldrTbl)
                           'Invoke(Sub() DataGridView1.Columns(5).Visible = False)
                           Invoke(Sub() LblFtr.Text = "")
                       End Sub)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TxtFrmNm.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtFrmAdd.Text = DataGridView1.CurrentRow.Cells(1).Value
        TxtTo.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtCc.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TxtSub.Text = DataGridView1.CurrentRow.Cells(4).Value
        webMail.DocumentText = DataGridView1.CurrentRow.Cells(5).Value
    End Sub
#End Region
#Region "Get Folder Items to Webrowser Control"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim AutoComplt As New Thread(AddressOf GetFoldrItems)
        AutoComplt.IsBackground = True
        AutoComplt.Start()
    End Sub
    Private Sub GetFoldrItems()
        Invoke(Sub()
                   If IsNothing(AutoDRRow) = True Then
                       Dim NewRow As DataRow = AutoCompTbl.NewRow()
                       'NewRow("AutMail") = TextBox1.Text
                       AutoCompTbl.Rows.Add(NewRow)
                       TextBox1.AutoCompleteCustomSource.Add(TextBox1.Text)
                       InsUpd("insert into AutoComplete (AutMail) Values ('" & TextBox1.Text & "')", "0000&H")
                   End If
                   ConnectToExchangeServer()
                   If exchange IsNot Nothing Then
                       Try
                           ListView1.Items.Clear()
                           Dim MlFldrNm As New WellKnownFolderName
                       If IsNothing(TreeViewFolder.SelectedNode) = False Then
                           If TreeViewFolder.SelectedNode.Name = "Inbox" Then
                                   MlFldrNm = WellKnownFolderName.Inbox
                               ElseIf TreeViewFolder.SelectedNode.Name = "Drafts" Then
                               MlFldrNm = WellKnownFolderName.Drafts
                           ElseIf TreeViewFolder.SelectedNode.Name = "SentItems" Then
                               MlFldrNm = WellKnownFolderName.SentItems
                           ElseIf TreeViewFolder.SelectedNode.Name = "DeletedItems" Then
                               MlFldrNm = WellKnownFolderName.DeletedItems
                           ElseIf TreeViewFolder.SelectedNode.Name = "JunkEmail" Then
                               MlFldrNm = WellKnownFolderName.JunkEmail
                           ElseIf TreeViewFolder.SelectedNode.Name = "Outbox" Then
                               MlFldrNm = WellKnownFolderName.Outbox
                           End If
                       End If
                           Dim findResults As FindItemsResults(Of Item) = exchange.FindItems(MlFldrNm, New ItemView(1000))
                           MsgTxtResp("Retriving {Ref. " & JbRef & "} Start at " & Now)
                       MsgTxtResp("number of emails:  " & findResults.Count)
                       MailCount = 0
                       TMailCount += findResults.Count
                       For Each item As Item In findResults
                           PrsFrom = ""
                           PrsTo = ""
                           PrsCC = ""
                           PrsSbjct = ""
                           CCDrop = False
                           MailCount += 1
                           LblFtr.Text = ("Proccess email: " & MailCount & " Of " & findResults.Count)
                           message = EmailMessage.Bind(exchange, item.Id)
                           PrsFrom = message.From.Address
                           PrsSbjct = message.Subject
                           PrsCC = message.CcRecipients.ToString
                           If PrsSbjct = Nothing Then
                               PrsSbjct = "X"
                           End If
                           PrsSbjct = Strings.Right(PrsSbjct, PrsSbjct.Length - Strings.InStr(PrsSbjct, "MRSCOMP", CompareMethod.Text) + 1)
                           PrsDt = message.DateTimeReceived
                           PrsTo = message.ToRecipients.Item(0).Address

                           Dim Fdto As Integer = InStr(1, message.From.ToString, "SMTP:")
                           Dim DDD As String = Mid(message.From.ToString, Fdto + 6, Len(message.From.ToString))
                           Dim sHTMLCOntent As String = message.Body


                           Dim Arr(5) As String
                               Dim itm As ListViewItem
                               Dim itdm As ListViewItem

                           Arr(0) = message.From.Name
                           Arr(1) = message.From.Address
                           For Tocnt = 0 To message.DisplayTo.Count - 1
                               Arr(2) &= message.DisplayTo(Tocnt).ToString
                           Next Tocnt
                           If IsNothing(message.DisplayCc) = False Then
                               For CCcnt = 0 To message.DisplayCc.Count - 1
                                   Arr(3) &= message.DisplayCc(CCcnt)
                               Next CCcnt
                           End If
                           Arr(4) = message.Subject


                               'If (message.Attachments.Count) > 0 Then
                               '    For i = 0 To message.Attachments.Count - 1
                               '        Dim sType As String = message.Attachments(i).ContentType.ToLower()
                               '        If (sType.Contains("image")) Then
                               '            Dim sID As String = message.Attachments(i).ContentId

                               '            sType = sType.Replace("image/", "")
                               '            Dim sFilename As String = sID + "." + sType
                               '            Dim sPathPlusFilename As String = Directory.GetCurrentDirectory() + "\" + sFilename
                               '            message.Attachments(i).Load()
                               '            Dim oldString As String = "cid:" + sID
                               '            sHTMLCOntent = sHTMLCOntent.Replace(oldString, sPathPlusFilename)
                               '        End If
                               '    Next
                               '    Arr(5) = sHTMLCOntent
                               'Else
                               '    Arr(5) = message.Body
                               '    'MsgBox(message.Attachments(0).ContentId & vbCrLf & message.Attachments(0).ContentLocation & vbCrLf & message.Attachments(0).ContentType & vbCrLf & message.Attachments(0).Name & vbCrLf & message.Attachments.Count)
                               'End If
                               If message.HasAttachments = False Then
                               If message.Attachments.Count > 0 Then
                                   For Cnt_ = 0 To message.Attachments.Count - 1
                                       itdm = New ListViewItem(message.Attachments(Cnt_).Name)
                                       ListView2.Items.Add(itdm)
                                   Next
                               End If
                           End If

                           For Each attachment As Attachment In message.Attachments
                               If TypeOf attachment Is FileAttachment Then
                                   Dim fileAttachment As FileAttachment = TryCast(attachment, FileAttachment)
                                   'Save the attachment to local workpath                   
                                   fileAttachment.Load()
                                   fileAttachment.Load("c:\WorkPath\" + (fileAttachment.Size.ToString) & "_" & fileAttachment.Name)
                               End If
                           Next
                           Arr(5) = message.Body
                           itm = New ListViewItem(Arr)
                           ListView1.Items.Add(itm)
                       Next
                       LblFtr.Text = ""
                       Catch ex As Exception
                       MsgBox(ex.Message)
                       End Try
                   End If
               End Sub)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim AutoComplt As New Thread(AddressOf AutoComp1)
        AutoComplt.IsBackground = True
        AutoComplt.Start()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListView1.SelectedItems(0).SubItems(5).Text = My.Computer.Clipboard.GetText()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            ListView1.View = View.LargeIcon
        ElseIf ComboBox1.SelectedIndex = 1 Then
            ListView1.View = View.SmallIcon
        ElseIf ComboBox1.SelectedIndex = 2 Then
            ListView1.View = View.List
        ElseIf ComboBox1.SelectedIndex = 3 Then
            ListView1.View = View.Tile
        ElseIf ComboBox1.SelectedIndex = 4 Then
            ListView1.View = View.Details
        End If
        ListView1.LabelWrap = True

    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        TxtFrmNm.Text = ListView1.SelectedItems(0).SubItems(0).Text
        TxtFrmAdd.Text = ListView1.SelectedItems(0).SubItems(1).Text
        TxtTo.Text = ListView1.SelectedItems(0).SubItems(2).Text
        TxtCc.Text = ListView1.SelectedItems(0).SubItems(3).Text
        TxtSub.Text = ListView1.SelectedItems(0).SubItems(4).Text
        webMail.DocumentText = ListView1.SelectedItems(0).SubItems(5).Text
        My.Computer.Clipboard.SetText(ListView1.SelectedItems(0).SubItems(5).Text)
    End Sub
#End Region
#Region "Connect to server"
    Public Sub ConnectToExchangeServer()
        For Each c In Me.Controls
            If TypeOf c Is TextBox Then
                Invoke(Sub() c.text = "")
            ElseIf TypeOf c Is WebBrowser Then
                Invoke(Sub() c.DocumentText = "")
            End If
            Invoke(Sub() c.Refresh())
        Next
        Invoke(Sub() Me.Refresh())
        Invoke(Sub() LblFtr.Text = "Connecting to Exchange Server..")
        Invoke(Sub() TxtSrvRsp.Text += vbCrLf & "Connecting to Exchange Server.." & vbCrLf)
        Invoke(Sub() TxtSrvRsp.Refresh())
        Try

            exchange = New ExchangeService(ExchangeVersion.Exchange2013_SP1)
            exchange.Credentials = New WebCredentials(My.Settings.ExUNm, My.Settings.ExPass)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            'exchange.AutodiscoverUrl(My.Settings.ExEmail) ' efg
            Invoke(Sub() LblFtr.Text = "Connected successfully to Server : " + exchange.Url.Host)
            Invoke(Sub() TxtSrvRsp.Text += "Connected successfully to Server : " + exchange.Url.Host & vbCrLf)
            Invoke(Sub() TxtSrvRsp.Refresh())
        Catch ex As Exception
            TxtSrvRsp.Text += "Error Connecting to Exchange Server!!" + Now + ex.Message & vbCrLf
            TxtSrvRsp.Refresh()
            TxtSrvRsp.ScrollToCaret()
        End Try

    End Sub
#End Region
    Sub MsgTxtResp(MsgTxt As String)
        TxtSrvRsp.Text += MsgTxt & vbCrLf
        TxtSrvRsp.Refresh()


        'If InStr(MsgTxt, "Waiting") = 1 Then
        '    TxtSrvRsp.SelectionStart = TxtSrvRsp.TextLength - 12
        '    TxtSrvRsp.SelectionLength = 10
        'End If


        TxtSrvRsp.SelectionStart = (TxtSrvRsp.TextLength - 1)
        TxtSrvRsp.SelectionLength = 0
        TxtSrvRsp.ScrollToCaret()

    End Sub
End Class