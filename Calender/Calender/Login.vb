Imports System.Threading
Imports System.Drawing.Drawing2D
Imports System.Reflection

Public Class Login
    Dim HardTable As DataTable = New DataTable
    Dim VerTbl As DataTable = New DataTable
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OsIP() <> "10.16.1.116" Or OsIP() <> "192.168.43.38" Then
            If getMacAddress() = "00090FFE0001" Then
                Panel5.Visible = True
            Else
                Panel5.Visible = False
            End If
        Else
            MsgBox("Not Allowed")
            Exit Sub
            Me.Close()
        End If

        ' Check Ver.
        LblUsrIP.Text = "IP: " & OsIP()
        'AssVerLbl.Text = "Assembly Ver. : " & My.Application.Info.Version.ToString ' major.minor.build.revision
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If
        BtnSub(Me)

GoodVer:  '       *****      End Check Ver.
        TxtUsrNm.Select()
        Me.BtnShow.Text = "Show Password"
        TxtUsrNm.Text = My.Settings.LogUsrNm
        TxtUsrPass.Text = My.Settings.LogPass






        'Dim oShell As Object
        'Dim oLink As Object
        ''you don’t need to import anything in the project reference to create the Shell Object
        'Try
        '    oShell = CreateObject("WScript.Shell")
        '    oLink = oShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & "VOCA+" & ".lnk")

        '    oLink.TargetPath = Uri.UnescapeDataString(New System.UriBuilder(System.Reflection.Assembly.GetExecutingAssembly.CodeBase).Path)
        '    oLink.WindowStyle = 1
        '    oLink.Save()
        'Catch ex As Exception

        'End Try
        'MsgBox(Uri.UnescapeDataString((New System.UriBuilder(System.Reflection.Assembly.GetExecutingAssembly.CodeBase).Path)))

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'VerTbl.Rows.Clear()
        'VerTbl.Columns.Clear()

        'If GetTbl("select VerMj, VerMn, VerBl, VerRv From ALib", VerTbl, "1000&H") = Nothing Then
        '    If VerTbl.Rows(0).Item(0).ToString & "." & VerTbl.Rows(0).Item(1).ToString & "." & VerTbl.Rows(0).Item(2).ToString & "." & VerTbl.Rows(0).Item(3).ToString <> Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4) Then
        '        LblHdr.ForeColor = Color.Red
        '        LblHdr.Text = "- There is a newer version Available For DownLoad! Please Remove Proxy and restart App Again." & vbCrLf & "- You Can call Support Team If Needed." & vbCrLf & "- Newer Version is : " & VerTbl.Rows(0).Item(0).ToString & "." & VerTbl.Rows(0).Item(1).ToString & "." & VerTbl.Rows(0).Item(2).ToString & "." & VerTbl.Rows(0).Item(3).ToString
        '        TxtUsrNm.Enabled = False
        '        TxtUsrPass.Enabled = False
        '        MskLbl.Visible = False
        '        LblUsrNm.Visible = False
        '        LblUsrPw.Visible = False
        '        BtnShow.Visible = False
        '        LogInBtn.Visible = False
        '    End If
        '    GoTo GoodVer
        'Else
        '    Close()
        'End If

    End Sub
    Private Sub LogInBtn__Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        Loginn()
    End Sub
    Private Sub Loginn()
        If TxtUsrPass.Text = "0000" And My.Settings.LogPass = "0000" Then
            ReLogin.ShowDialog()
        Else
            If TxtUsrNm.Text = My.Settings.LogUsrNm And TxtUsrPass.Text = My.Settings.LogPass Then
                Main.Show()
                Hidden.Show()
                Hidden.Hide()
                Me.Close()
            Else
                MsgInf("برجاء التأكد من كلمة اسم المستخدم وكلمة المرور")
            End If
        End If
    End Sub
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click  ', Me.FormClosing

        'Dim frmCollection = Application.OpenForms
        'If frmCollection.OfType(Of WelcomeScreen).Any And frmCollection.OfType(Of Login).Any Then

        'Else

        'End If

        On Error Resume Next
        For Each f As Form In My.Application.OpenForms
            f.Close()
            f.Dispose()
        Next
        Me.Close()

    End Sub
    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        If TxtUsrPass.UseSystemPasswordChar = True Then
            TxtUsrPass.UseSystemPasswordChar = False
            Me.BtnShow.Text = "Hide PassWord"
        Else
            TxtUsrPass.UseSystemPasswordChar = True
            Me.BtnShow.Text = "Show PassWord"
        End If
    End Sub
    Private Sub TxtUsrPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsrPass.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Loginn()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReLogin.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Settings_.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.LogPass = "0000"
        My.Settings.Save()
    End Sub
End Class