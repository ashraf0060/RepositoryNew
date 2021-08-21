Public Class LodngFrm
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub LodngFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        LblMsg.Text = ""
        Dim Cn As New APblicClss.Func
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync(Cn)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        Dim WC As APblicClss.Func = CType(e.Argument, APblicClss.Func)
        'LodngFrm.Show()
        WC.LoadFrm(worker)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim state As APblicClss.Defntion = CType(e.UserState, APblicClss.Defntion)
        Me.LblMsg.Text = state.StatStr
    End Sub
End Class