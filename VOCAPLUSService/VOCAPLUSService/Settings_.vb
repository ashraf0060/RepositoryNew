Public Class Settings_
    Private Sub Settings__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.MlUsr
        TextBox2.Text = My.Settings.MlPss
    End Sub

    Private Sub BtnSbmt_Click(sender As Object, e As EventArgs) Handles BtnSbmt.Click
        My.Settings.Save()
    End Sub
End Class