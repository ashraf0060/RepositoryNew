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
        BtnSnd.Visible = False
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
        Try
            Using Client As TcpClient = Server.AcceptTcpClient
                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                ClientsLst.Add(Client)
                TempClient = Client

                Dim ipend As Net.IPEndPoint = Client.Client.RemoteEndPoint
                Dim IPAdrss As String = ipend.Address.ToString

                If DataGridView1.Rows.Count > 0 Then
                    For Each G As DataGridViewRow In DataGridView1.Rows
                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = False Then
                            Invoke(Sub() DataGridView1.Rows.Add(IPAdrss))
                            Exit For
                        ElseIf G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                            Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Green)
                        End If
                    Next
                Else
                    Invoke(Sub() DataGridView1.Rows.Add(IPAdrss))
                    Invoke(Sub() DataGridView1.AutoResizeColumns())
                End If

                Invoke(Sub() DataGridView1.ClearSelection())

                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                Try
                    If RX.BaseStream.CanRead = True Then
                        While RX.BaseStream.CanRead = True
                            Dim RawData As String = RX.ReadLine
                            If Client.Client.Connected = True AndAlso Client.Connected = True AndAlso Client.GetStream.CanRead = True Then
                                REM For some reason this seems to stop the comon tcp connection bug vvv
                                If Not IsNothing(RawData) = True Then

                                    If RawData = "Typing" Then
                                        For Each G As DataGridViewRow In DataGridView1.Rows
                                            If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                                Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Gold)
                                            End If
                                        Next
                                    ElseIf RawData = "NotTyping" Then
                                        For Each G As DataGridViewRow In DataGridView1.Rows
                                            If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                                Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Green)
                                            End If
                                        Next
                                    Else
                                        Invoke(Sub() RichTextBox1.Text += IPAdrss + ">>" + RawData + vbNewLine)
                                    End If
                                ElseIf Not IsNothing(RawData) = False Then
                                    Client.Close()
                                    ClientsLst.Remove(Client)
                                    For Each G As DataGridViewRow In DataGridView1.Rows
                                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                            'Invoke(Sub() DataGridView1.Rows.RemoveAt(G.Index))
                                            Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                                            Exit For
                                        End If
                                    Next
                                    'MsgBox("Session has ended by Remote Client  ==> " & ClientStrng)
                                End If
                                REM ^^^^ Comment it out and test it in your own projects. Mine might be the only stupid one.
                            Else
                                Client.Close()
                                ClientsLst.Remove(Client)
                                For Each G As DataGridViewRow In DataGridView1.Rows
                                    If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                        Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                                        Exit For
                                    End If
                                Next
                                Exit While
                            End If
                        End While
                    ElseIf RX.BaseStream.CanRead = False Then
                        Client.Close()
                        ClientsLst.Remove(Client)
                        Invoke(Sub() DataGridView1.Rows.RemoveAt(Client.Client.RemoteEndPoint.ToString))
                    End If
                Catch ex As Exception
                    If ClientsLst.Contains(Client) Then
                        ClientsLst.Remove(Client)
                        Client.Close()
                    End If
                    For Each G As DataGridViewRow In DataGridView1.Rows
                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                            'Invoke(Sub() DataGridView1.Rows.RemoveAt(G.Index))
                            Invoke(Sub() DataGridView1.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                            Exit For
                        End If
                    Next
                    'MsgBox("Server has been Stoped and all clients has been Dropped")
                End Try
            End Using
        Catch ex As Exception
            If ClientsLst.Contains(TempClient) Then
                '    ClientsLst.Remove(TempClient)
                '    TempClient.Close()
            End If
        End Try
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnSnd.Click
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
                        Invoke(Sub() RichTextBox1.AppendText(Client.Client.RemoteEndPoint.ToString + ">>" + TextBox1.Text + vbNewLine))
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = ClientsLst.Count.ToString
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            BtnSnd.Visible = False
        Else
            BtnSnd.Visible = True
        End If
    End Sub
End Class