
Imports System.Threading

Public Class Start
    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Invoke(Sub() LblUsrIP.Text = "IP: " & OsIP())
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Invoke(Sub() PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4))
        Else
            Invoke(Sub() PubVerLbl.Text = "Publish Ver. : This isn't a Publish version")
        End If
        Timer2.Start()
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Login.Show()
        Timer2.Stop()
        Me.Close()
    End Sub

End Class