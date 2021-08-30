Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class TCPClient_
    Dim Client As TcpClient
    Dim RX As StreamReader
    Dim TX As StreamWriter
    Dim Server As TcpListener
    Private Sub TCPClient__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Conct)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnCnct.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Conct)
    End Sub
    Function Connected()
        'Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
        REM Has connected to server and now listening for data from the server
        If RX.BaseStream.CanRead = True Then

            Try
                While RX.BaseStream.CanRead = True
                    Dim RawData As String = RX.ReadLine
                    If Not IsNothing(RawData) = True Then
                        If RawData.ToUpper = "/MSG" Then
                            Threading.ThreadPool.QueueUserWorkItem(AddressOf MSG1, "Hello World.")
                        Else
                            Invoke(Sub() RichTextBox1.Text += "Server>>" + RawData + vbNewLine)
                            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                        End If
                    End If

                End While
            Catch ex As Exception
                Client.Close()
                Invoke(Sub() RichTextBox1.Text += "Disconnected" + vbNewLine)
                Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                Invoke(Sub() BtnCnct.Enabled = True)
                Invoke(Sub() BtnDscnct.Enabled = False)
            End Try
        End If
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
        End If
    End Sub
    Function SendToServer(ByVal Data As String)
        REM Send a message to the server
        Try
            TX.WriteLine(Data)
            RichTextBox1.Text += Now & " : " & Data & vbNewLine
            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            Invoke(Sub() RichTextBox1.Focus())
            Invoke(Sub() TextBox1.Focus())
            TextBox1.Clear()
            TX.Flush()
        Catch ex As Exception

        End Try
        Return True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnDscnct.Click
        Try
            Client.Close()
            RichTextBox1.Text += "Connection Ended" + vbNewLine
            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            BtnCnct.Enabled = True
            BtnDscnct.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Conct()
        Invoke(Sub() RichTextBox1.Text += "Connecting .... " + vbNewLine)
        Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
        Invoke(Sub() BtnCnct.Enabled = False)
        Try
            REM IP, Port
            REM If port is in a textbox, use: integer.parse(textbox1.text)  instead of the port number vvv
            Client = New TcpClient("192.168.1.240", 4305)
            If Client.GetStream.CanRead = True Then
                RX = New StreamReader(Client.GetStream)
                TX = New StreamWriter(Client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
                Invoke(Sub() BtnCnct.Enabled = False)
                Invoke(Sub() BtnDscnct.Enabled = True)
                Invoke(Sub() RichTextBox1.Text += "Connected" + vbNewLine)
                Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            End If
        Catch ex As Exception
            Invoke(Sub() BtnCnct.Enabled = True)
            Invoke(Sub() BtnDscnct.Enabled = False)
            Invoke(Sub() RichTextBox1.Text += "Failed to connect, E: " + ex.Message + vbNewLine)
            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
        End Try
    End Sub
End Class