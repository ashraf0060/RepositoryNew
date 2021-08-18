Imports System.Management

Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LogInBtn_Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        ' This method runs on the main thread.
        ' Initialize the object that the background worker calls.

    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' This event handler is called when the background thread finishes.
        ' This method runs on the main thread.
        If e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            MessageBox.Show("Word counting canceled.")
        Else
            'MessageBox.Show("Finished counting words.")
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' This event handler is where the actual work is done.
        ' This method runs on the background thread.
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        ' Get the Words object and call the main method.
        Dim WC As Log = CType(e.Argument, Log)
        WC.CheckCon("select Mac, Admin from AMac where Mac ='" & WC.GetMACAddressNew() & "'", worker)
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ' This method runs on the main thread.
        Dim state As ClLogin.Defntin = CType(e.UserState, ClLogin.Defntin)
        Label1.Text = state.StatStr
        StatusBarPanel1.Text = "Mac : " & state.StatStr
    End Sub
    Private Sub BackgroundWorker2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        ' This event handler is where the actual work is done.
        ' This method runs on the background thread.
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        ' Get the Words object and call the main method.
        Dim WC As Log = CType(e.Argument, Log)
        WC.CheckCon("select Mac, Admin from AMac where Mac ='" & WC.GetMACAddressNew() & "'", worker)
    End Sub
    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ' This method runs on the main thread.
        Dim state As ClLogin.Defntin = CType(e.UserState, ClLogin.Defntin)
        Label2.Text = state.StatStr
        StatusBarPanel1.Text = "Users: " & state.StatStr
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim WC As New Log
        Label1.Text = "Running"
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync(WC)
        End If
        Dim WC1 As New Log
        Label2.Text = "Running"
        If BackgroundWorker2.IsBusy = False Then
            BackgroundWorker2.RunWorkerAsync(WC1)
        End If
    End Sub
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Form2.Show()
    End Sub
    Public Class Log

        Public Function GetMACAddressNew() As String
            Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            Dim MACAddress As String = String.Empty
            For Each mo As ManagementObject In moc

                If (MACAddress.Equals(String.Empty)) Then
                    If CBool(mo("IPEnabled")) Then MACAddress = mo("MacAddress").ToString()
                    MACAddress = MACAddress.Replace(":", String.Empty)
                    mo.Dispose()
                End If
            Next
            Return MACAddress
        End Function
        Public Sub CheckCon(Str As String, worker As System.ComponentModel.BackgroundWorker)
Recon_:
            Dim ss As New ClLogin.Defntin
            Dim Fn As New ClLogin.Func
            Login.StatusBarPanel1.Text = "Connecting ..........."
            Login.LogInBtn.Enabled = False
            Login.TxtUsrNm.Enabled = False
            Login.TxtUsrPass.Enabled = False
            ss.MacTable = New DataTable
            ss.StatStr = "Runnung"
            If Fn.GetTbl(Str, ss.MacTable, "8888&H", worker) = "Connecting" Then
                Login.StatusBarPanel1.Text = ""
                If ss.MacTable.Rows.Count > 0 Then
                    ss.StatStr = "Done" & "_" & ss.MacTable.Rows.Count
                    ss.cnt = ss.MacTable.Rows.Count
                    Login.LogInBtn.Enabled = True
                    Login.TxtUsrNm.Enabled = True
                    Login.TxtUsrPass.Enabled = True
                    Login.StatusBarPanel1.Text = "Online"
                Else
                    Login.Cmbo.Visible = False
                    'MsgBox("Not Allowed" & vbCrLf & "Your Mac Address : " & Fn.GetMACAddressNew())
                    'Invoke(Sub() Close())
                    'Application.Exit()
                End If
            Else
                ss.StatStr = ss.StatStr
                ss.MacTable.Dispose()
            End If
            worker.ReportProgress(0, ss)
        End Sub
    End Class

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub
End Class