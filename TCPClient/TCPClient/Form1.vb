Imports System.IO
Imports System.Net.Sockets

Public Class Form1
    Dim Client As TcpClient
    Dim RX As StreamReader
    Dim TX As StreamWriter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        REM Connect Button
        Try
            REM IP, Port
            REM If port is in a textbox, use: integer.parse(textbox1.text)  instead of the port number vvv
            Client = New TcpClient("192.168.1.3", 4305)
            If Client.GetStream.CanRead = True Then
                RX = New StreamReader(Client.GetStream)
                TX = New StreamWriter(Client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
            End If
        Catch ex As Exception
            RichTextBox1.Text += "Failed to connect, E: " + ex.Message + vbNewLine

        End Try
    End Sub
    Function Connected()
        REM Has connected to server and now listening for data from the server
        If RX.BaseStream.CanRead = True Then
            Try
                While RX.BaseStream.CanRead = True
                    Dim RawData As String = RX.ReadLine
                    .If RawData.ToUpper = "/MSG" Then
                        Threading.ThreadPool.QueueUserWorkItem(AddressOf MSG1, "Hello World.")
                    Else
                        RichTextBox1.Text += "Server>>" + RawData + vbNewLine
                    End If
                End While
            Catch ex As Exception
                Client.Close()
                RichTextBox1.Text += "Disconnected" + vbNewLine
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
                TextBox1.Clear()
            End If
        End If
    End Sub
    Function SendToServer(ByVal Data As String)
        REM Send a message to the server
        Try
            TX.WriteLine(Data)
            RichTextBox1.Text += Now & " : " & Data & vbNewLine
            TX.Flush()
        Catch ex As Exception

        End Try
        Return True
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        REM Stops crossthreadingIssues
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        REM Disconnect Button
        Try
            Client.Close()
            RichTextBox1.Text += "Connection Ended" + vbNewLine
        Catch ex As Exception

        End Try
    End Sub
End Class