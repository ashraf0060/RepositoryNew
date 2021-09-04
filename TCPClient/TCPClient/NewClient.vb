Imports System.Net.Sockets

Public Class NewClient
    Dim TcpClnt As TcpClient
    Dim TcpClntStream As NetworkStream
    Private Sub NewClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPort.Text = 4305
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TcpClnt = New TcpClient("10.11.51.233", Val(TxtPort.Text))
        TcpClntStream = TcpClnt.GetStream
        Me.Text = TcpClnt.Client.RemoteEndPoint.ToString
        Threading.ThreadPool.QueueUserWorkItem(AddressOf ClntRcvStream)
    End Sub
    Private Sub ClntRcvStream()
        If TcpClntStream.DataAvailable = True Then
            Dim RcvByts(TcpClnt.ReceiveBufferSize) As Byte
            TcpClntStream.Read(RcvByts, 0, CInt(TcpClnt.ReceiveBufferSize))
            Invoke(Sub() RichTextBox1.Text += System.Text.Encoding.UTF8.GetString(RcvByts))
            Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
            Invoke(Sub() RichTextBox1.Focus())
            Invoke(Sub() TextBox1.Focus())
        End If
        Threading.ThreadPool.QueueUserWorkItem(AddressOf ClntRcvStream)
    End Sub
    Private Sub ClntSndStream()
        Invoke(Sub()
                   If (Trim(TextBox1.Text)).Length > 0 Then
                       Dim SndByts() As Byte = System.Text.Encoding.UTF8.GetBytes(TextBox1.Text & vbCrLf)
                       TcpClnt.Client.Send(SndByts)
                       RichTextBox1.Text += System.Text.Encoding.UTF8.GetString(SndByts)
                       Invoke(Sub() RichTextBox1.SelectionStart = RichTextBox1.Text.Length)
                       Invoke(Sub() RichTextBox1.Focus())
                       Invoke(Sub() TextBox1.Focus())
                       TextBox1.Clear()
                   End If

               End Sub)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Threading.ThreadPool.QueueUserWorkItem(AddressOf ClntSndStream)
        End If

    End Sub


End Class