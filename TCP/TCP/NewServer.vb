Imports System.Net
Imports System.Net.Sockets

Public Class NewServer
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim TCPSckt As Socket
    Private Sub NewServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Threading.ThreadPool.QueueUserWorkItem(AddressOf StartServer)
    End Sub
    Function StartServer()
        If ServerStatus = False Then
            ServerTrying = True
            Try
                Server = New TcpListener(IPAddress.Any, 4305)
                Server.Start()
                TCPSckt = Server.AcceptSocket
                'TCPSckt.Blocking = False
                ServerStatus = True
                Invoke(Sub() Me.Text = "Server Connected")
                Invoke(Sub() Me.Icon = My.Resources.WSOn032)
                Invoke(Sub() BtnStrtSrvr.Enabled = False)
                Invoke(Sub() BtnStpSrvr.Enabled = True)
                Invoke(Sub() Me.Text += IPAddress.Any.ToString)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Catch ex As Exception
                ServerStatus = False
                Invoke(Sub() Me.Icon = My.Resources.WSOff032)
                Invoke(Sub() BtnStrtSrvr.Enabled = True)
                Invoke(Sub() BtnStpSrvr.Enabled = False)
            End Try
            ServerTrying = False
        End If
        Return True
    End Function
    Private Sub Handler_Client(state As Object)
        Try
            Dim RcvByts(TCPSckt.ReceiveBufferSize) As Byte
            TCPSckt.Receive(RcvByts)
            Dim dsdsc As String = Split(System.Text.Encoding.UTF8.GetString(RcvByts), vbNewLine)(0)
            Dim hh As Integer = Trim(System.Text.Encoding.UTF8.GetString(RcvByts)).Length
            If dsdsc = "Typing" Then

            ElseIf dsdsc = "NotTyping" Then

            ElseIf dsdsc <> "Typing" Then
                Invoke(Sub() RichTextBox1.Text &= System.Text.Encoding.UTF8.GetString(RcvByts) & vbCrLf)
                Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                Invoke(Sub() RichTextBox1.Focus())
                Invoke(Sub() TextBox1.Focus())
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
    End Sub
    Private Sub BtnSnd_Click(sender As Object, e As EventArgs) Handles BtnSnd.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
    End Sub
    Private Sub BtnStrtSrvr_Click(sender As Object, e As EventArgs) Handles BtnStrtSrvr.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf StartServer)
    End Sub
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
    Private Sub SendToClients(state As Object)
        Invoke(Sub()
                   If (Trim(TextBox1.Text)).Length > 0 Then
                       Dim SndByts() As Byte = System.Text.Encoding.UTF8.GetBytes("Ashraf >> " & TextBox1.Text & vbCrLf)
                       TCPSckt.Send(SndByts)
                       RichTextBox1.Text += System.Text.Encoding.UTF8.GetString(SndByts)
                       Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                       Invoke(Sub() RichTextBox1.Focus())
                       Invoke(Sub() TextBox1.Focus())
                       TextBox1.Clear()
                   End If
               End Sub)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            BtnSnd.Visible = False
        Else
            BtnSnd.Visible = True
        End If
    End Sub
End Class