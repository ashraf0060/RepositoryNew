
Imports System.Data.SqlClient

Public Class ReLogin
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub ReLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        If Cnt_ = 32107 Then
            ExitBtn.Visible = False
            LblUsrOpass.Visible = False
            TxtUsrOPass.Visible = False
            LblUsrPass.Visible = True
            TxtUsrPass.Visible = True
            LblUsCnt_Pass.Visible = True
            TxtUsCnt_Pass.Visible = True
        Else
            ExitBtn.Visible = True
            LblUsrOpass.Visible = True
            TxtUsrOPass.Visible = True
            LblUsrPass.Visible = False
            TxtUsrPass.Visible = False
            LblUsCnt_Pass.Visible = False
            TxtUsCnt_Pass.Visible = False
        End If
        AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Publish Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If
        TxtUsCnt_lNm.Text = My.Settings.LogUsrNm
        TxtUsrOPass.UseSystemPasswordChar = True
        TxtUsrPass.UseSystemPasswordChar = True
        TxtUsCnt_Pass.UseSystemPasswordChar = True
    End Sub

    Private Sub BtSub_Click(sender As Object, e As EventArgs) Handles BtSub.Click
        Randomize()
        If TxtUsrPass.TextLength > 5 Then
            If TxtUsrPass.Text = TxtUsCnt_Pass.Text Then
                GoTo ExitSec
            Else
                LblHint.Text = "كلمة السر غير متطابقة أعد الإدخال"
                Exit Sub
            End If
        Else
            LblHint.Text = "يجب أن تكون كلمة السر 6 (حروف/أرقام) أو أكثر"
            Exit Sub
        End If
ExitSec:
        LblHint.Text = "كلمة السر ناجحة"
        Try
            My.Settings.LogPass = TxtUsrPass.Text
            My.Settings.Save()
            If Cnt_ = 32107 Then
                Me.Close()
            End If
            Cnt_ = 0

            Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TxtUsrPass.Enter
        LblHint.Text = "يجب أن تكون كلمة السر 6 (حروف/أرقام) أو أكثر"
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TxtUsCnt_Pass.Enter
        LblHint.Text = "أعد إدخال كلمة السر"
    End Sub

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Cnt_ = 0
        Close()
    End Sub

    Private Sub TxtUsCnt_lNm_Enter(sender As Object, e As EventArgs) Handles TxtUsCnt_lNm.Enter
        LblHint.Text = "إسم المستخدم"
    End Sub

    Private Sub TxtUsrOPass_Leave(sender As Object, e As EventArgs) Handles TxtUsrOPass.Leave
        If TxtUsrOPass.Text = My.Settings.LogPass Then 'check user name and password status
            LblUsrPass.Visible = True
            TxtUsrPass.Visible = True
            LblUsCnt_Pass.Visible = True
            TxtUsCnt_Pass.Visible = True
        Else
            LblUsrPass.Visible = False
            TxtUsrPass.Visible = False
            LblUsCnt_Pass.Visible = False
            TxtUsCnt_Pass.Visible = False
            TxtUsrOPass.Text = ""
            LblHint.Text = "كلمة السر غير مطابقة من فضلك تأكد من كلمة السر"
        End If
    End Sub

    Private Sub TxtUsrOPass_Enter(sender As Object, e As EventArgs) Handles TxtUsrOPass.Enter
        LblHint.Text = "أعد إدخال كلمة السر الحالية"
    End Sub

    Private Sub ReLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class