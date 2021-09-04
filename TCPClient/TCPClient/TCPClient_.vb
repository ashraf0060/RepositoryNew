Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Threading

Public Class TCPClient_
    Dim Client As TcpClient
    Dim RX As StreamReader
    Dim TX As StreamWriter
    Dim Server As TcpListener
    Dim Bol As Boolean = False
    Dim Lst As Integer
    Private Sub TCPClient__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Conct)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnCnct.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Conct)
    End Sub
    Private Function IsPortOpen(ByVal Host As String, ByVal PortNumber As Integer) As Boolean
        Dim Client As TcpClient = Nothing
        Try
            Client = New TcpClient(Host, PortNumber)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not Client Is Nothing Then
                Client.Close()
            End If
        End Try
    End Function

    Function Connected()
        'Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
        REM Has connected to server and now listening for data from the server
        'Invoke(Sub() Me.Text = "Disconnected")

Jkjkjk_:
        Dim ipProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipEndPoints As IPEndPoint() = ipProperties.GetActiveTcpListeners()
        For Each EndPoint As IPEndPoint In ipEndPoints
            If EndPoint.ToString = "10.11.51.233:4305" Then
                Bol = True
                Exit For
            End If
        Next
        Invoke(Sub() Me.Text = "Connected")
        Invoke(Sub() TextBox1.Enabled = True)
            Try
                If RX.BaseStream.CanRead = True Then
                'ThreadPool.QueueUserWorkItem(AddressOf Connected)
                While RX.BaseStream.CanRead = True
                        'autoEvent.Set()
                        Dim RawData As String = RX.ReadLine
                    If Not IsNothing(RawData) = True Then
                        If RawData.ToUpper = "/MSG" Then
                            Threading.ThreadPool.QueueUserWorkItem(AddressOf MSG1, "Hello World.")
                        Else
                            Invoke(Sub() RichTextBox1.AppendText("Server>>" + RawData + vbNewLine))
                            Invoke(Sub() Lst = RichTextBox1.Text.LastIndexOf("Server>>"))
                            Invoke(Sub() SelctSerchTxt(RichTextBox1, "Server>>"))
                        End If
                    End If
                    GoTo Jkjkjk_
                End While
                End If
                'autoEvent.Set()
            Catch ex As Exception
                Client.Close()
                Invoke(Sub()
                           Invoke(Sub() Me.Text = "Disconnected")
                           Invoke(Sub() BtnCnct.Enabled = True)
                           Invoke(Sub() BtnDscnct.Enabled = False)
                           Invoke(Sub() TextBox1.Enabled = False)
                       End Sub)
            End Try

        MsgBox("fsfsf")
        Return True
    End Function
    Function MSG1(ByVal Data As String)
        REM Creates a messageBox for new threads to stop freezing
        MsgBox(Data)
        Return True
    End Function
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        REM When you press enter on the textbox to send the message
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBox1.Text.Length > 0 Then
                SendToServer(TextBox1.Text)
            End If
        Else
            SendToServer("Typing")
        End If
    End Sub
    Function SendToServer(ByVal Data As String)
        REM Send a message to the server
        Try

            If Data = "Typing" Then
                TX.WriteLine(Data)
                'TextBox1.Clear()
                TX.Flush()
            ElseIf Data = "NotTyping" Then
                TX.WriteLine(Data)
                'TextBox1.Clear()
                TX.Flush()
            ElseIf Data <> "Typing" Then
                TX.WriteLine(Data)
                Invoke(Sub() RichTextBox1.Text += Format(Now, "yyyy/MM/dd") & " : You " & " : " & Data & vbNewLine)
                Invoke(Sub() TextBox1.Clear())
                TX.Flush()
                Invoke(Sub() SelctSerchTxt(RichTextBox1, "Server>>"))
                Invoke(Sub() TextBox1.Focus())
            End If
        Catch ex As Exception

        End Try
        Return True
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnDscnct.Click
        Try
            Client.Close()
            Invoke(Sub() RichTextBox1.Text += "Connection Ended" + vbNewLine)
            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            Invoke(Sub() BtnCnct.Enabled = True)
            Invoke(Sub() BtnDscnct.Enabled = False)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Conct()
        Invoke(Sub() Me.Text = "Connecting .... ")
        Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
        Invoke(Sub() BtnCnct.Enabled = False)
        'Try
        REM IP, Port
        REM If port is in a textbox, use: integer.parse(textbox1.text)  instead of the port number vvv
        Client = New TcpClient()
        Client.Connect("192.168.1.240", 4305)
        'Client.ConnectAsync("10.11.51.232", 4305)

        If Client.GetStream.CanRead = True Then
                Invoke(Sub() TextBox1.Enabled = True)
                RX = New StreamReader(Client.GetStream)
                TX = New StreamWriter(Client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
                Invoke(Sub() BtnCnct.Enabled = False)
                Invoke(Sub() BtnDscnct.Enabled = True)
                Invoke(Sub() Me.Text = "Connected")
                Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            End If
        'Catch ex As Exception
        '    Invoke(Sub() BtnCnct.Enabled = True)
        '    Invoke(Sub() BtnDscnct.Enabled = False)
        '    Invoke(Sub() Me.Text = ex.Message)
        '    Invoke(Sub() RichTextBox1.Text += "Failed to connect, E: " + ex.Message + vbNewLine)
        '    Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
        'End Try
    End Sub
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        SendToServer("NotTyping")
    End Sub
    Public Function SelctSerchTxt(richtxtbx As RichTextBox, Strng As String) As String
        Dim HH As String = Nothing
        Try
            'richtxtbx = New RichTextBox
            Dim starttxt As Integer = Lst
            Dim endtxt As Integer
            endtxt = richtxtbx.TextLength
            While starttxt < endtxt
                If richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.MatchCase) > 0 Then
                    'richtxtbx.SelectionBackColor = Color.GreenYellow
                    Invoke(Sub() richtxtbx.SelectionAlignment = HorizontalAlignment.Left)
                End If
                starttxt += 1
            End While
            Invoke(Sub() richtxtbx.SelectionStart = richtxtbx.Text.Length)
            Invoke(Sub() richtxtbx.Focus())
        Catch ex As Exception
            HH = "X"
            MsgBox(ex.Message)
        End Try
        Return HH
    End Function
End Class