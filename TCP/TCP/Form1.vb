Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Form1
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim Clients As New List(Of TcpClient)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartServer()
    End Sub

    Function StartServer()
        If ServerStatus = False Then
            ServerTrying = True
            Try
                Server = New TcpListener(IPAddress.Any, 4305)
                Server.Start()
                ServerStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Catch ex As Exception
                ServerStatus = False
            End Try
            ServerTrying = False
        End If
        Return True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StopServer()
    End Sub
    Function StopServer()
        If ServerStatus = True Then
            ServerTrying = True
            Try
                For Each Client As TcpClient In Clients
                    Client.Close()
                Next
                Server.Stop()
                ServerStatus = False
            Catch ex As Exception
                StopServer()
            End Try
            ServerTrying = False
        End If
        Return True
    End Function
    Function Handler_Client(ByVal state As Object)
        Dim TempClient As TcpClient

        Try
            Using Client As TcpClient = Server.AcceptTcpClient
                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If

                Clients.Add(Client)
                TempClient = Client


                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                Try
                    If RX.BaseStream.CanRead = True Then
                        While RX.BaseStream.CanRead = True
                            Dim RawData As String = RX.ReadLine
                            If Client.Client.Connected = True AndAlso Client.Connected = True AndAlso Client.GetStream.CanRead = True Then
                                REM For some reason this seems to stop the comon tcp connection bug vvv
                                Dim RawDataLength As String
                                If Not IsNothing(RawData.Length.ToString) = True Then
                                    RawDataLength = RawData.Length.ToString()
                                Else
                                    RawDataLength = ""
                                End If
                                REM ^^^^ Comment it out and test it in your own projects. Mine might be the only stupid one.
                                Invoke(Sub() RichTextBox1.Text += Client.Client.RemoteEndPoint.ToString + ">>" + RawData + vbNewLine)
                                Invoke(Sub() ListBox1.Items.Add(Client.Client.RemoteEndPoint.ToString))
                            Else
                                ListBox1.Items.Remove(Client.Client.RemoteEndPoint.ToString)
                                Exit While
                            End If
                        End While
                    End If
                Catch ex As Exception
                    If Clients.Contains(Client) Then
                        Clients.Remove(Client)
                        Invoke(Sub() ListBox1.Items.Remove(Client.Client.RemoteEndPoint.ToString))
                        Client.Close()
                    End If

                End Try


                If RX.BaseStream.CanRead = False Then
                    Client.Close()
                    Clients.Remove(Client)
                    Invoke(Sub() ListBox1.Items.Add(Client.Client.RemoteEndPoint.ToString))
                Else
                    Invoke(Sub() ListBox1.Items.Remove(Client.Client.RemoteEndPoint.ToString))
                End If
                ''   Console.Beep()
            End Using
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        Catch ex As Exception
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        End Try

        Return True
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
    End Sub
    Function SendToClients(ByVal Data As String)
        If ServerStatus = True Then
            If Clients.Count > 0 Then
                Try
                    REM  Broadcast data to all clients
                    REM To target one client,
                    REM USAGE: If client.client.remoteendpoint.tostring.contains(IP As String) Then
                    REM I am sorry for the lack of preparation for this project and in the video.
                    REM I wrote 99% of this from the top of my head,  no one is perfect, bound to make mistakes.
                    For Each Client As TcpClient In Clients
                        Dim TX1 As New StreamWriter(Client.GetStream)
                        ''   Dim RX1 As New StreamReader(Client.GetStream)
                        TX1.WriteLine(Data)
                        TX1.Flush()
                    Next
                Catch ex As Exception
                    SendToClients(Data)
                End Try
            End If
        End If
        Return True
    End Function
    REM   Timer1 enabled = true
    REM Just if you want to always have a count of connected clients.
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Clients.Count.ToString
    End Sub
End Class