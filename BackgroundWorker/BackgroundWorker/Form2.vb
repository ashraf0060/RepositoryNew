Public Class Form2
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
        'Dim WC As ClLogin.Func = CType(e.Argument, ClLogin.Func)
        'WC.CheckCon("select Mac, Admin from AMac where Mac ='" & WC.GetMACAddressNew() & "'", worker)
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ' This method runs on the main thread.
        Dim state As ClLogin.Defntin = CType(e.UserState, ClLogin.Defntin)
        Label1.Text = state.StatStr
        StatusBarPanel1.Text = state.StatStr
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim WC As New ClLogin.Func
        Dim Df As New ClLogin.Defntin
        Label1.Text = "Running"
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync(WC)
        End If
    End Sub
End Class