Public Class LodngFrm
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub LodngFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblMsg.Text = ""
    End Sub
End Class