Public Class UConstr
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        For Cnt1_ = 1 To 0 Step -0.01
            Opacity = Cnt1_
            Threading.Thread.Sleep(50)
        Next
        Close()
    End Sub
End Class