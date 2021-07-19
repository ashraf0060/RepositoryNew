Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Public Class ZTest
    Inherits System.Web.UI.Page
    Dim servrstsus As Boolean = False
    Dim servrTring As Boolean = False
    Dim Servr As TcpListener
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        StartServer()
    End Sub

    Private Function StartServer() As Boolean
        If servrstsus = False Then
            servrTring = True
            Try
                Servr = New TcpListener(IPAddress.Any, 80)
                Servr.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                servrstsus = True
                Label9.Text = servrstsus.ToString
            Catch ex As Exception
                servrstsus = False
            End Try
            servrTring = False
        End If
        Return True
    End Function
    Private Function Handler_Client(ByVal State As Object) As Boolean
        Dim Tempclient As TcpClient
        Try
            Using Client As TcpClient = Servr.AcceptTcpClient
                If servrTring = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                Tempclient = Client
                'Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                If RX.BaseStream.CanRead = True Then
                    Do

                        Dim RawData As String = RX.ReadLine
                        If Split(RawData, ">>").Count > 1 Then
                            If Trim(Split(RawData, ">>")(1)) = "Empty" Then
                                Label9.Text = ""
                            Else
                                Label9.Text += RawData + vbNewLine
                            End If
                        Else
                            Label9.Text += RawData + vbNewLine
                        End If
                    Loop While RX.BaseStream.CanRead = True
                End If
            End Using
        Catch ex As Exception
            StartServer()
        End Try

        Return True
    End Function
End Class