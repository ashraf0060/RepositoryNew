Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Public Class Form2
    Dim ClientTbl As New DataTable
    Dim servrstsus As Boolean = False
    Dim servrTring As Boolean = False
    Dim Servr As TcpListener
    Dim Clients As New List(Of TcpClient)
    Dim IP_ As IPAddress
    Dim newFrm As Boolean = False
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClientTbl.Columns.Add("Clint")
        TextBox3.Text = OsIP()
        RadioButton1.Checked = True
        IP_ = IPAddress.Parse(TextBox3.Text)
        TextBox4.Text = 80
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartServer()
    End Sub
    Function StartServer()
        If servrstsus = False Then
            servrTring = True
            Try
                Servr = New TcpListener(IPAddress.Any, TextBox4.Text)
                Servr.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                servrstsus = True
            Catch ex As Exception
                servrstsus = False
            End Try
            servrTring = False
        End If
        Return True
    End Function
    Private Function Handler_Client(ByVal State As Object)
        Dim Tempclient As TcpClient
        Try
            Dim fffff As String = ""
            Dim Client As TcpClient = Servr.AcceptTcpClient
            If servrTring = False Then
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            End If
            Clients.Add(Client)
            Tempclient = Client
            Dim TX As New StreamWriter(Client.GetStream)
            Dim RX As New StreamReader(Client.GetStream)
            'If RX.BaseStream.CanRead = True Then

            Do
                If RX.BaseStream.CanRead = False Then Form3.Show()
                'If RX.BaseStream.CanRead = False Then
                '    Form3.Text = "Message From VOCA Team"
                '    Form3.Show()
                'Else
                Dim RawData As String = RX.ReadLine
                RichTextBox1.Text += RawData + vbNewLine
                'End If

            Loop While RX.BaseStream.CanRead = True

            'End If
            If RX.BaseStream.CanRead = False Then
                Client.Close()
                Clients.Remove(Client)
            End If

            If Tempclient.GetStream.CanRead = False Then
                Tempclient.Close()
                Clients.Remove(Tempclient)
            End If
        Catch ex As Exception
            RichTextBox1.Text += ex.Message + vbNewLine
        End Try
        Return True
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Handler_Client()
    End Sub
End Class