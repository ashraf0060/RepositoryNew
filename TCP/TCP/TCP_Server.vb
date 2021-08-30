Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class TCP_Server
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim ClientsLst As New List(Of TcpClient)

    'https://www.dreamincode.net/forums/topic/375960-tcpip-list-of-connected-clients/
    Private Sub TCP_Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True
        StartServer()
    End Sub
    Private Sub BtnStpSrvr_Click(sender As Object, e As EventArgs) Handles BtnStpSrvr.Click
        StopServer()
    End Sub
    Private Sub BtnStrtSrvr_Click(sender As Object, e As EventArgs) Handles BtnStrtSrvr.Click
        StartServer()
    End Sub
    Function StartServer()
        If ServerStatus = False Then
            ServerTrying = True
            Try
                Server = New TcpListener(IPAddress.Parse("192.168.1.240"), 4305)
                Server.Start()
                ServerStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                Me.Icon = My.Resources.WSOn032
                BtnStrtSrvr.Enabled = False
                BtnStpSrvr.Enabled = True
            Catch ex As Exception
                ServerStatus = False
                Me.Icon = My.Resources.WSOff032
                BtnStrtSrvr.Enabled = True
                BtnStpSrvr.Enabled = False
            End Try
            ServerTrying = False
        End If
        Return True
    End Function
    Function StopServer()
        If ServerStatus = True Then
            ServerTrying = True
            Try
                For Each Client As TcpClient In ClientsLst
                    Client.Close()
                Next
                Server.Stop()
                ServerStatus = False
                Me.Icon = My.Resources.WSOff032
                BtnStpSrvr.Enabled = False
                BtnStrtSrvr.Enabled = True
            Catch ex As Exception
                StopServer()
                BtnStpSrvr.Enabled = True
                BtnStrtSrvr.Enabled = False
            End Try
            ServerTrying = False
        End If
        Return True
    End Function

    Function Handler_Client(ByVal state As Object)
        Dim TempClient As TcpClient
        Dim ClientStrng As String
        Try
            Using Client As TcpClient = Server.AcceptTcpClient
                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                ClientsLst.Add(Client)
                TempClient = Client
                ClientStrng = Client.Client.RemoteEndPoint.ToString
                Invoke(Sub() ListBox1.Items.Add(Client.Client.RemoteEndPoint.ToString))

                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                Try
                    If RX.BaseStream.CanRead = True Then
                        While RX.BaseStream.CanRead = True
                            Dim RawData As String = RX.ReadLine
                            If Client.Client.Connected = True AndAlso Client.Connected = True AndAlso Client.GetStream.CanRead = True Then
                                REM For some reason this seems to stop the comon tcp connection bug vvv
                                Dim RawDataLength As String
                                If Not IsNothing(RawData) = True Then
                                    RawDataLength = RawData.Length.ToString()
                                    Invoke(Sub() RichTextBox1.Text += Client.Client.RemoteEndPoint.ToString + ">>" + RawData + vbNewLine)
                                ElseIf Not IsNothing(RawData) = False Then
                                    RawDataLength = ""
                                    Client.Close()
                                    ClientsLst.Remove(Client)
                                    Invoke(Sub() ListBox1.Items.Remove(ClientStrng))
                                End If
                                REM ^^^^ Comment it out and test it in your own projects. Mine might be the only stupid one.
                            Else
                                Client.Close()
                                ClientsLst.Remove(Client)
                                Invoke(Sub() ListBox1.Items.Remove(Client.Client.RemoteEndPoint.ToString))
                                Exit While
                            End If
                        End While
                    ElseIf RX.BaseStream.CanRead = False Then
                        Client.Close()
                        ClientsLst.Remove(Client)
                        Invoke(Sub() ListBox1.Items.Add(Client.Client.RemoteEndPoint.ToString))
                    End If
                Catch ex As Exception
                    If ClientsLst.Contains(Client) Then
                        ClientsLst.Remove(Client)
                        Invoke(Sub() ListBox1.Items.Remove(ClientStrng))
                        Client.Close()
                    End If

                End Try


                'If RX.BaseStream.CanRead = False Then
                'Client.Close()
                'ClientsLst.Remove(Client)
                'Invoke(Sub() ListBox1.Items.Add(Client.Client.RemoteEndPoint.ToString))
                'Else
                'Invoke(Sub() ListBox1.Items.Remove(Client.Client.RemoteEndPoint.ToString))
                'End If
                ''   Console.Beep()
            End Using
            'If ClientsLst.Contains(TempClient) Then
            '    ClientsLst.Remove(TempClient)
            '    TempClient.Close()
            'End If
        Catch ex As Exception
            If ClientsLst.Contains(TempClient) Then
                '    ClientsLst.Remove(TempClient)
                '    TempClient.Close()
            End If
        End Try
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
    End Sub
    Function SendToClients(ByVal Data As String)
        If ServerStatus = True Then
            If ClientsLst.Count > 0 Then
                Try
                    REM  Broadcast data to all clients
                    REM To target one client,
                    REM USAGE: If client.client.remoteendpoint.tostring.contains(IP As String) Then
                    REM I am sorry for the lack of preparation for this project and in the video.
                    REM I wrote 99% of this from the top of my head,  no one is perfect, bound to make mistakes.
                    For Each Client As TcpClient In ClientsLst
                        Dim TX1 As New StreamWriter(Client.GetStream)
                        ''   Dim RX1 As New StreamReader(Client.GetStream)
                        TX1.WriteLine(Data)
                        Invoke(Sub() RichTextBox1.Text += Client.Client.RemoteEndPoint.ToString + ">>" + TextBox1.Text + vbNewLine)
                        TX1.Flush()
                        Invoke(Sub() TextBox1.Clear())
                    Next
                Catch ex As Exception
                    SendToClients(Data)
                End Try
            End If
        End If
        Return True
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If CheckBox1.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If TextBox1.Text.Length > 0 Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
                End If
            End If
        End If

    End Sub
End Class