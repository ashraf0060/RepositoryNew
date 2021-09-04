Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class TCP_Server
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim Client As TcpClient
    Dim ClientsLst As New List(Of TcpClient)

    'https://www.dreamincode.net/forums/topic/375960-tcpip-list-of-connected-clients/
    Private Sub TCP_Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True
        BtnSnd.Visible = False
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Label2.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            Label2.Text = "Publish Ver. : This isn't a Publish version"
        End If
        TextBox2.Text = "select Int_user.UsrIP as IP_ from Int_user where Int_user.UsrSusp = 0 and Int_user.UsrActive = 1  group by  Int_user.UsrIP order by Int_user.UsrIP"
        TextBox3.Text = 500
        StartServer()
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Gett)
    End Sub
    Private Sub Gett()
        Dim Tbl As New DataTable
        Dim Fn As New APblicClss.Func
        Fn.GetTblXX(TextBox2.Text, Tbl)
        Invoke(Sub() DataGridView3.DataSource = Tbl)

        If CheckBox2.Checked = True Then DataGridView1.Rows.Clear()

        For YY = 0 To Tbl.Rows.Count - 1
            Dim Bol As Boolean = False
            Invoke(Sub() Me.Text = YY + 1 & " Of " & Tbl.Rows.Count & " =======> " & Tbl.Rows(YY).Item("IP_").ToString)
            Client = New TcpClient
            Try
                Client.ConnectAsync(Tbl.Rows(YY).Item("IP_").ToString, 4305)
                Thread.Sleep(Val(TextBox3.Text))
                If Client.Connected = True Then
                    If DataGridView1.Rows.Count > 0 Then
                        For Each HH As DataGridViewRow In DataGridView1.Rows
                            If HH.Cells(0).Value = Tbl.Rows(YY).Item("IP_").ToString Then
                                Invoke(Sub() HH.DefaultCellStyle.ForeColor = Color.Green)
                                Bol = True
                                'Client.Close()
                                Exit For
                            Else
                                Invoke(Sub() HH.DefaultCellStyle.ForeColor = Color.Red)
                            End If
                        Next
                    End If
                    If Bol = False Then
                        Invoke(Sub() DataGridView1.Rows.Add(Tbl.Rows(YY).Item("IP_").ToString))
                        Invoke(Sub() DataGridView1.AutoResizeColumns())
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                'Client.Close()
            End Try
        Next YY
        For UU = 0 To ClientsLst.Count - 1
            MsgBox(ClientsLst(UU).Client.LocalEndPoint.ToString)
        Next
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Gett)
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
            'Parse("10.11.51.232")
            Try
                Server = New TcpListener(IPAddress.Any, 4305)

                Server.Start()
                ServerStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                Me.Icon = My.Resources.WSOn032
                BtnStrtSrvr.Enabled = False
                BtnStpSrvr.Enabled = True
                Me.Text = IPAddress.Any.ToString
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
            Using Client As TcpClient = Server.AcceptTcpClient()
                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                ClientsLst.Add(Client)
                TempClient = Client

                Dim IPAdrss As String = Split(Client.Client.LocalEndPoint.ToString, ":")(0)

                If DataGridView2.Rows.Count > 0 Then
                    For Each G As DataGridViewRow In DataGridView2.Rows
                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = False Then
                            Invoke(Sub() DataGridView2.Rows.Add(IPAdrss))
                            Exit For
                        ElseIf G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                            Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Green)
                        End If
                    Next
                Else
                    Invoke(Sub() DataGridView2.Rows.Add(IPAdrss))
                    Invoke(Sub() DataGridView2.AutoResizeColumns())
                End If

                Invoke(Sub() DataGridView2.ClearSelection())

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
                                        For Each G As DataGridViewRow In DataGridView2.Rows
                                            If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                                Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Gold)
                                            End If
                                        Next
                                    ElseIf RawData = "NotTyping" Then
                                        For Each G As DataGridViewRow In DataGridView2.Rows
                                            If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                                Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Green)
                                            End If
                                        Next
                                    Else
                                        Invoke(Sub() RichTextBox1.Text += IPAdrss + ">>" + RawData + vbNewLine)
                                        Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                                        Invoke(Sub() RichTextBox1.Focus())
                                    End If
                                ElseIf Not IsNothing(RawData) = False Then
                                    Client.Close()
                                    ClientsLst.Remove(Client)
                                    For Each G As DataGridViewRow In DataGridView2.Rows
                                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                            'Invoke(Sub() DataGridView2.Rows.RemoveAt(G.Index))
                                            Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                                            Exit For
                                        End If
                                    Next
                                    'MsgBox("Session has ended by Remote Client  ==> " & ClientStrng)
                                End If
                                REM ^^^^ Comment it out and test it in your own projects. Mine might be the only stupid one.
                            Else
                                Client.Close()
                                ClientsLst.Remove(Client)
                                For Each G As DataGridViewRow In DataGridView2.Rows
                                    If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                                        Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                                        Exit For
                                    End If
                                Next
                                Exit While
                            End If
                        End While
                    ElseIf RX.BaseStream.CanRead = False Then
                        Client.Close()
                        ClientsLst.Remove(Client)
                        Invoke(Sub() DataGridView2.Rows.RemoveAt(Client.Client.RemoteEndPoint.ToString))
                    End If
                Catch ex As Exception
                    If ClientsLst.Contains(Client) Then
                        ClientsLst.Remove(Client)
                        Client.Close()
                    End If
                    For Each G As DataGridViewRow In DataGridView2.Rows
                        If G.Cells(0).Value.ToString.Contains(IPAdrss) = True Then
                            'Invoke(Sub() DataGridView2.Rows.RemoveAt(G.Index))
                            Invoke(Sub() DataGridView2.Rows(G.Index).DefaultCellStyle.ForeColor = Color.Red)
                            Exit For
                        End If
                    Next
                    'MsgBox("Server has been Stoped and all clients has been Dropped")
                End Try
            End Using
        Catch ex As Exception
            If ClientsLst.Contains(TempClient) Then
                ClientsLst.Remove(TempClient)
                TempClient.Close()
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
                        Invoke(Sub() RichTextBox1.AppendText("You : " & Client.Client.RemoteEndPoint.ToString + " >> " + TextBox1.Text + vbNewLine))
                        Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                        Invoke(Sub() RichTextBox1.Focus())
                        Invoke(Sub() TextBox1.Focus())
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