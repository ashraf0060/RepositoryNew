''This code is by UNO TEAM (thanks to uno freeware)
'If you are looking for something to use for your projects...
'just with no problem
Public Class DemoApp
    Inherits System.Windows.Forms.Form

    'Windows Form Designer generated code <- you should not care about this ->
#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
        initform()
    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DestIP As System.Windows.Forms.TextBox
    Friend WithEvents DestPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SendButton As System.Windows.Forms.Button
    Friend WithEvents OutgoingMessage As System.Windows.Forms.TextBox
    Friend WithEvents StartStopButton As System.Windows.Forms.Button
    Friend WithEvents ServerPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents IncomingMessagesList As System.Windows.Forms.ListBox
    Friend WithEvents LocalIPLabel As System.Windows.Forms.Label
    Friend WithEvents IPscanRange As System.Windows.Forms.TextBox
    Friend WithEvents ScanPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents ScanProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents FoundIPList As System.Windows.Forms.ListBox
    Friend WithEvents ScanButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SendButton = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.OutgoingMessage = New System.Windows.Forms.TextBox
        Me.DestPort = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.DestIP = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.IncomingMessagesList = New System.Windows.Forms.ListBox
        Me.ServerPort = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.LocalIPLabel = New System.Windows.Forms.Label
        Me.StartStopButton = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.FoundIPList = New System.Windows.Forms.ListBox
        Me.ScanButton = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.ScanPort = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.IPscanRange = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ScanProgressBar = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        CType(Me.DestPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ServerPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ScanPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(568, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This sample application shows one usage of the three classes exposed by the .NET " & _
        "assembly (dll) UNOLibs.Net       <-  thanks to codeproject.com for hosting this " & _
        "shit ->"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(8, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(528, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "UNOLibs.Net and this demo application is made by <- uno team -> (thanks to uno fr" & _
        "eeware for the code)"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(8, 504)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(592, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Feel free to use this assembly in any way and you can change code as well. any co" & _
        "mment or question is welcome at uno.one@email.it"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SendButton)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.OutgoingMessage)
        Me.GroupBox1.Controls.Add(Me.DestPort)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DestIP)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(72, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 208)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UNOLibs.Net.Clientclass"
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(8, 176)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(160, 24)
        Me.SendButton.TabIndex = 6
        Me.SendButton.Text = "SEND"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(56, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "message/command:"
        '
        'OutgoingMessage
        '
        Me.OutgoingMessage.Location = New System.Drawing.Point(8, 120)
        Me.OutgoingMessage.MaxLength = 800
        Me.OutgoingMessage.Multiline = True
        Me.OutgoingMessage.Name = "OutgoingMessage"
        Me.OutgoingMessage.Size = New System.Drawing.Size(160, 48)
        Me.OutgoingMessage.TabIndex = 4
        Me.OutgoingMessage.Text = "TextBox1"
        '
        'DestPort
        '
        Me.DestPort.Location = New System.Drawing.Point(104, 72)
        Me.DestPort.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.DestPort.Minimum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.DestPort.Name = "DestPort"
        Me.DestPort.Size = New System.Drawing.Size(64, 20)
        Me.DestPort.TabIndex = 3
        Me.DestPort.Value = New Decimal(New Integer() {6666, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "destination port :"
        '
        'DestIP
        '
        Me.DestIP.Location = New System.Drawing.Point(80, 40)
        Me.DestIP.Name = "DestIP"
        Me.DestIP.Size = New System.Drawing.Size(88, 20)
        Me.DestIP.TabIndex = 0
        Me.DestIP.Text = "0.0.0.0"
        Me.DestIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "destination IP (1.2.3.4 format)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.IncomingMessagesList)
        Me.GroupBox2.Controls.Add(Me.ServerPort)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.LocalIPLabel)
        Me.GroupBox2.Controls.Add(Me.StartStopButton)
        Me.GroupBox2.Location = New System.Drawing.Point(112, 264)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 216)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UNOLibs.Net.ServerClass"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(280, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "incoming list :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IncomingMessagesList
        '
        Me.IncomingMessagesList.Location = New System.Drawing.Point(8, 64)
        Me.IncomingMessagesList.Name = "IncomingMessagesList"
        Me.IncomingMessagesList.Size = New System.Drawing.Size(352, 147)
        Me.IncomingMessagesList.TabIndex = 12
        '
        'ServerPort
        '
        Me.ServerPort.Location = New System.Drawing.Point(264, 21)
        Me.ServerPort.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.ServerPort.Minimum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.ServerPort.Name = "ServerPort"
        Me.ServerPort.Size = New System.Drawing.Size(56, 20)
        Me.ServerPort.TabIndex = 11
        Me.ServerPort.Value = New Decimal(New Integer() {6666, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(200, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "server port"
        '
        'LocalIPLabel
        '
        Me.LocalIPLabel.Location = New System.Drawing.Point(16, 24)
        Me.LocalIPLabel.Name = "LocalIPLabel"
        Me.LocalIPLabel.Size = New System.Drawing.Size(153, 16)
        Me.LocalIPLabel.TabIndex = 9
        Me.LocalIPLabel.Text = "Local IP :"
        '
        'StartStopButton
        '
        Me.StartStopButton.Location = New System.Drawing.Point(320, 20)
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New System.Drawing.Size(40, 22)
        Me.StartStopButton.TabIndex = 8
        Me.StartStopButton.Text = "Start"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FoundIPList)
        Me.GroupBox3.Controls.Add(Me.ScanButton)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.ScanPort)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.IPscanRange)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.ScanProgressBar)
        Me.GroupBox3.Location = New System.Drawing.Point(344, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(184, 208)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "UNOLibs.Net.ServerScanner"
        '
        'FoundIPList
        '
        Me.FoundIPList.Location = New System.Drawing.Point(8, 128)
        Me.FoundIPList.Name = "FoundIPList"
        Me.FoundIPList.Size = New System.Drawing.Size(168, 69)
        Me.FoundIPList.TabIndex = 13
        '
        'ScanButton
        '
        Me.ScanButton.Location = New System.Drawing.Point(8, 104)
        Me.ScanButton.Name = "ScanButton"
        Me.ScanButton.Size = New System.Drawing.Size(48, 18)
        Me.ScanButton.TabIndex = 9
        Me.ScanButton.Text = "Scan"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 32)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "1.2.3.0 will scan from 1.2.3.1 to 1.2.3.254"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ScanPort
        '
        Me.ScanPort.Location = New System.Drawing.Point(120, 80)
        Me.ScanPort.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.ScanPort.Minimum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.ScanPort.Name = "ScanPort"
        Me.ScanPort.Size = New System.Drawing.Size(56, 20)
        Me.ScanPort.TabIndex = 7
        Me.ScanPort.Value = New Decimal(New Integer() {6666, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(56, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "scan port :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IPscanRange
        '
        Me.IPscanRange.Location = New System.Drawing.Point(88, 24)
        Me.IPscanRange.Name = "IPscanRange"
        Me.IPscanRange.Size = New System.Drawing.Size(88, 20)
        Me.IPscanRange.TabIndex = 4
        Me.IPscanRange.Text = "0.0.0.0"
        Me.IPscanRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "scan IPs :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ScanProgressBar
        '
        Me.ScanProgressBar.Location = New System.Drawing.Point(56, 104)
        Me.ScanProgressBar.Maximum = 30
        Me.ScanProgressBar.Name = "ScanProgressBar"
        Me.ScanProgressBar.Size = New System.Drawing.Size(120, 16)
        Me.ScanProgressBar.Step = 1
        Me.ScanProgressBar.TabIndex = 0
        '
        'DemoApp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 539)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DemoApp"
        Me.Text = "Example demo for UNOLibs.Net"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DestPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ServerPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ScanPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    'Form handmade part <- you should not care about this ->
#Region "Form handmade part"
    'This Sub is called from the NEW method declared in the windows form generated shit
    'we use the server here only for retrieving local ip
    Private Sub initform()
        Srv = New UNOLibs.Net.ServerClass(6666, False)
        Me.DestIP.Text = Srv.LocalIP
        Me.LocalIPLabel.Text = "Local IP : " + Srv.LocalIP
        Dim iipp() As String = Srv.LocalIP.Split(".")
        Me.IPscanRange.Text = iipp(0) + "." + iipp(1) + "." + iipp(2) + ".0"
    End Sub
#End Region

    'Stuff starts from here 
    'Please note that the UNOLibs.Net.dll assembly must be in the references
    'of any program that will use that classes

    'Just look at the REGION related to your interests
    'Just declare our objects we will use note that we don't need
    'to care about sockets-threading and generally annoying code.
    Dim Cli As New UNOLibs.Net.ClientClass 'we use new here cause client need no more initialization
    Dim WithEvents Srv As UNOLibs.Net.ServerClass
    Dim WithEvents Scanner As UNOLibs.Net.ServerScanner

#Region "Implementing the UNOLibs.Net.ClientClass"
    'Basically you use a client when you want to send data to a 
    'specified IP as PORT
    'This Sub Handles the Send Button.Click event It reads the IP,PORT and DATA
    'from the form (can be yours variables) and sends the data.
    Private Sub SendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendButton.Click
        'Read DATA from the form
        Dim IP As String = DestIP.Text
        Dim PORT As Integer = DestPort.Value
        Dim DATA As String = OutgoingMessage.Text
        'Now send it.
        Try
            Cli.SendMessage(IP, PORT, DATA)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error sending message")
        End Try
    End Sub
    'It's done ) verify it starting the server and sending a message
    'to your IP/PORT
#End Region

#Region "Implementing the UNOLibs.Net.ServerClass"
    'Basically you use a server when you want to listen for incoming data
    'on a specified port. This demo let the user stop the server,change port,
    'and restart it also, so steps are:

    '1.Start the server on a specified port / stop function.
    Private Sub StartStopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartStopButton.Click
        If Not Srv.isRunning Then
            'Clear messages from previous session(don't care to this)
            Me.IncomingMessagesList.Items.Clear()
            'Retrieve PORT
            Dim PORT As Integer = ServerPort.Value
            'Start the server
            'You can use AutoStart = true as here or call later Srv.StartServer
            Srv = Nothing
            Srv = New UNOLibs.Net.ServerClass(PORT, True)
            'It's already Started!
            Me.StartStopButton.Text = "stop"
        Else
            'Stop and terminate the server
            Srv.StopServer()
            Me.StartStopButton.Text = "start"
        End If
    End Sub

    '2 And then you want to get the data that arrives to your server
    'right? maybe also execute subs or filtering ips... ok.
    'just have to wrtie the sub that handles the incoming message event.
    'The message will be in Args.Message, the sender ip in Args.SenderIP.
    Private Sub OnIncomingMessage(ByVal Args As UNOLibs.Net.ServerClass.InMessEvArgs) Handles Srv.IncomingMessage
        'Example of Reading and display Message
        Me.IncomingMessagesList.Items.Add(Args.senderIP + " --> " + Args.message)
        'Example of executing command
        If Args.message = "closeform" Then
            examplesub()
        End If
        'example of filtering IP : in this case the filter is displaying
        'a message only when certain IP are sending messages to us
        If Args.senderIP.Equals(Srv.LocalIP) Then
            MessageBox.Show("This message comes from this computer", "Filtering IP example")
        End If
    End Sub
    Private Sub examplesub()
        MessageBox.Show("This is an example", "Example of command execution")
    End Sub

    'That's it for the server ))
#End Region

#Region "Implementing the UNOLibs.Net.ServerScanner"
    'Basicall you use a scanner when you want to scan an IP range for some
    'server wich may be running on a specified port
    'Note that the scanner allows easy interation with a ProgressBar.
    'To to this using the UNOLibs library is easy :
    '1.Retrieve the scan parameters and start a new scanner
    Private Sub ScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanButton.Click
        'Retrieving scan parameters from the form
        Dim ScanParameters As New UNOLibs.Net.ServerScanner.ScannerParameters
        ScanParameters.SubnetToScanIP = Me.IPscanRange.Text
        ScanParameters.TCPPort = Me.ScanPort.Value
        'We say here that we divided our progress bar in 30 steps
        'and so we will need 30 perform step events
        ScanParameters.useProgressBarEvent = True
        ScanParameters.progressbarsteps = 30
        'Start the scan
        Scanner = New UNOLibs.Net.ServerScanner(ScanParameters)
        Me.FoundIPList.Items.Add("Scan started")
        Me.FoundIPList.Refresh()
        Scanner.StartScan()
        'Because we know how's the story we disable the button until the scan completes
        'and we write the scan has begun in the list
        Me.ScanButton.Enabled = False
    End Sub

    '2.Retrieve found ips in this example application we just add it to the list
    Private Sub OnIPFound(ByVal IP As String) Handles Scanner.IPfound
        Me.FoundIPList.Items.Add(IP)
        Me.FoundIPList.Refresh()
    End Sub
    '3.What to do when one of the 30 steps we required happens?
    'In this example application we just perform a step of our progress bar
    Private Sub OnPBEvent() Handles Scanner.PerformPBStep
        Me.ScanProgressBar.PerformStep()
    End Sub
    '4.When the scan is complete we Destroy the scanner object and we reenable the
    'scan button
    Private Sub OnScanComplete() Handles Scanner.ScanFinished
        Scanner = Nothing
        ScanButton.Enabled = True
        Me.FoundIPList.Items.Add("Scan completed")
        Me.FoundIPList.Refresh()
    End Sub
    'That's IT for the scanner
#End Region

End Class
