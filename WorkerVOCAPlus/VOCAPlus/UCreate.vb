
Public Class UCreate
    Private Sub UCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NonEditableLbl(LblId)
        NonEditableTxT(TxtId)
        Dim CatTbl As DataTable = New DataTable
        Dim TempNode() As TreeNode
        CatTbl.Rows.Clear()
        UserTree.Nodes.Add("0", "Root", 1, 3)
        '                 0  ,     1    ,   2 
        If GetTbl("SELECT UCatId, UCatIdSub, UCatNm FROM IntUserCat WHERE (UCatLvl <> 0) ORDER BY UCatIdSub", CatTbl, "1016&H") = Nothing Then
            For Cnt_ = 0 To CatTbl.Rows.Count - 1
                Dim dddddd As String = CatTbl(Cnt_).Item(1).ToString
                TempNode = UserTree.Nodes.Find(CatTbl(Cnt_).Item(1).ToString, True)
                TempNode(0).Nodes.Add(CatTbl(Cnt_).Item(0).ToString, CatTbl(Cnt_).Item(2).ToString, 0, 2)
                If TempNode(0).Nodes.Count > 0 Then
                    TempNode(0).ImageIndex = 1
                    TempNode(0).SelectedImageIndex = 3
                End If
            Next Cnt_
            BtnUsrCreate.Select()
            BSave.Visible = False
        Else
            WelcomeScreen.StatBrPnlEn.Text = "  Offline - Can't open User Create Form...  "
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Close()
        End If

    End Sub
    Private Sub TxtName_Enter(sender As Object, e As EventArgs) Handles TxtNm.Enter
        LblHNm.Visible = True
        LblNm.Visible = True
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNm.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not Char.IsNumber(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub TxtName_Leave(sender As Object, e As EventArgs) Handles TxtNm.LostFocus
        Dim SqlUsrComm As New SqlCommand ' Check if Id exist
        Dim ReaderS As SqlDataReader
        Dim PUsername As String
        If Len(Me.TxtNm.Text) < 3 Then
            FooterLbl.Text = "User name Must be more than 3 characters"
            TxtNm.Select()
        Else
            Try
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                    WelcomeScreen.StatBrPnlEn.Text = "  Online  "
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOn032
                End If
            Catch ex As Exception
                TxtNm.Text = ""
                WelcomeScreen.TimerCon.Start()
                WelcomeScreen.StatBrPnlEn.Text = "  Offline - Failed to check User Name"
                WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                AppLog("1017&H", ex.Message, "Failed to Failed to check User Name if it is dublicated in the table")
                Exit Sub
            End Try
            SqlUsrComm.Connection = sqlCon
            SqlUsrComm.CommandType = CommandType.Text
            SqlUsrComm.CommandText = "SELECT UsrNm FROM Int_user WHERE (UsrNm = '" & TxtNm.Text & "')"   'Check User name if exist
            Try
                ReaderS = SqlUsrComm.ExecuteReader
                ReaderS.Read()
                PUsername = ReaderS!UsrNm                                  'Current User Name
                ReaderS.Close()

                TxtNm.BackColor = Color.FromArgb(255, 192, 192)
                FooterLbl.Text = "User Id Is already taken, try onther one..."
                TxtNm.Text = ""
                Exit_.Select()
                Refresh()
            Catch                                                              'if user Name is New
                FooterLbl.Text = "User Name Is Ok"
                TxtNm.BackColor = Color.FromArgb(192, 255, 192)
                ChkVal()
                TxtNm.Enabled = False
                LblHNm.Visible = False
                TxtEmail.Text = TxtNm.Text & "@egyptpost.org"
                TxtEmail.BackColor = Color.FromArgb(50, 255, 50)
                TxtRNm.Visible = True
                TxtRNm.Select()
            End Try
        End If
    End Sub

    Private Sub TxtRName_enter(sender As Object, e As EventArgs) Handles TxtRNm.Enter
        LblHRNm.Visible = True
        LblRNm.Visible = True
    End Sub

    Private Sub TxtRName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRNm.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub TxtRName_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtRNm.LostFocus
        If Len(TxtRNm.Text) <= 0 Then
            FooterLbl.Text = "Real user name Can't be empty You have to put a name"
            TxtRNm.BackColor = Color.FromArgb(255, 192, 192)
        Else
            FooterLbl.Text = "Real Name Is accepted"
            TxtRNm.BackColor = Color.FromArgb(192, 255, 192)
            TxtRNm.Enabled = False
            LblHRNm.Visible = False
            ChkVal()
            CBxGndr.Visible = True
            CBxGndr.Select()
        End If
    End Sub
    Private Sub CBxGndr_Enter(sender As Object, e As EventArgs) Handles CBxGndr.Enter
        LblHGndr.Visible = True
        LblGndr.Visible = True
    End Sub

    Private Sub CBxGndr_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CBxGndr.SelectionChangeCommitted
        FooterLbl.Text = "Gender Is accepted"
        CBxGndr.BackColor = Color.FromArgb(192, 255, 192)
        CBxGndr.Enabled = False
        LblHGndr.Visible = False
        ChkVal()
        TxtGSM.Visible = True
        TxtGSM.Select()
    End Sub
    Private Sub TxtGSM_Enter(sender As Object, e As EventArgs) Handles TxtGSM.Enter
        LblHGsm.Visible = True
        LblGsm.Visible = True
    End Sub
    Private Sub TxtGSM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGSM.KeyPress
        IntUtly.ValdtInt(e)
    End Sub
    Private Sub TxtGSM_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtGSM.LostFocus
        If Len(TxtGSM.Text) <> 11 Then
            FooterLbl.Text = "Gsm must a valied phone number Consist of 11 number"
            TxtGSM.BackColor = Color.FromArgb(255, 192, 192)
        Else
            FooterLbl.Text = "GSM Is accepted"
            TxtGSM.BackColor = Color.FromArgb(192, 255, 192)
            TxtGSM.Enabled = False
            LblHGsm.Visible = False
            ChkVal()
            TxtEmail.Visible = True
            '   TxtEmail.Select()
        End If
    End Sub
    Private Sub TxtEmail_Enter(sender As Object, e As EventArgs) Handles TxtEmail.Enter
        LblHEmail.Visible = True
        LblEmail.Visible = True
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles TxtEmail.LostFocus
        If IntUtly.IsValidEmail(TxtEmail.Text) Then
            FooterLbl.Text = "Email Is accepted"
            TxtEmail.BackColor = Color.FromArgb(192, 255, 192)
            TxtEmail.Enabled = False
            LblHEmail.Visible = False
            TxtCat.Visible = True
            TxtCat.Select()
            ChkVal()
        Else
            FooterLbl.Text = "Email must a valid "
            TxtEmail.BackColor = Color.FromArgb(255, 192, 192)
        End If
    End Sub

    Private Sub TxtCat_Enter(sender As Object, e As EventArgs) Handles TxtCat.Enter
        LblHCat.Visible = True
        UserTree.Location = New Point(568, 1)
        UserTree.Size = New Size(360, 485)
        UserTree.Visible = True
        UserTree.Select()
    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterSelect
        If e.Action <> TreeViewAction.Unknown Then  ' The code only executes if the user caused the checked state to change.
            TxtCat.Text = UserTree.SelectedNode.Name
            TxtCat.Select()
            TxtCat.Enabled = False
            UserTree.Visible = False
            TxtCat.BackColor = Color.FromArgb(192, 255, 192)
            TxtCat.Enabled = False
            LblHCat.Visible = False
            ChkVal()
        End If
    End Sub

    Sub ChkVal()
        ProgBar.Value += 1
        If ProgBar.Value > 5 Then
            BackColor = Color.FromArgb(192, 255, 192)
            LblInf.Visible = True
            BSave.Visible = True
            BSave.Select()
        End If
        TextBox1.Text = ProgBar.Value
        Refresh()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

        Dim Rslt As DialogResult
        Dim sqlCommA As New SqlCommand
        FooterLbl.Text = "Everything is Ok...  Ready to Save"
        MsgBox("Are you sure to save ?", MsgBoxStyle.YesNo & MsgBoxStyle.Information & MsgBoxStyle.ApplicationModal & MsgBoxStyle.Critical, "Information")
        If Rslt = DialogResult.Cancel Then
            GoTo ExitSec '                       clear form here
        End If
        ' Start Saving Progress
        If PublicCode.InsUpd("INSERT INTO Int_User (UsrId, UsrNm, UsrCat, UsrPass, UsrKey, UsrRealNm, UsrGender, UsrGsm, UsrEmail) VALUES (" & TxtId.Text & ",'" & TxtNm.Text & "', '" & TxtCat.Text & "', 'HDJRJi0dIhNwY5H0iB7zjQ==' , 'A430FABA825' , '" & TxtRNm.Text & "' , '" & CBxGndr.Text & "' , '" & TxtGSM.Text & "' , '" & TxtEmail.Text & "' );", "1015&H") <> Nothing Then
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            FooterLbl.Text = "Fail To save Current new user Please try againg"
            Exit Sub
        End If

ExitSec:
        WelcomeScreen.StatBrPnlEn.Text = "  Online  "
        WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOn032
        FrmReset()
        BtnUsrCreate.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnUsrCreate.Click
        Dim sqlCommA As New SqlCommand
        Dim ReaderA As SqlDataReader
        FrmReset()
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlCommA.Connection = sqlCon
            sqlCommA.CommandText = "SELECT MAX(UsrId) AS MaxUsrId FROM Int_user WHERE (UsrId < 32000)"
            sqlCommA.CommandType = CommandType.Text
            ReaderA = sqlCommA.ExecuteReader
            ReaderA.Read()
            TxtId.Text = ReaderA!MaxUsrId + 1
            ReaderA.Close()
            'sqlCon.Close()

            LblNm.Visible = True
            TxtNm.Visible = True
            TxtNm.Select()
            ProgBar.Value = 0
            WelcomeScreen.StatBrPnlEn.Text = "  Online  "
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOn032
        Catch ex As Exception
            WelcomeScreen.TimerCon.Start()
            WelcomeScreen.StatBrPnlEn.Text = "  Offline  "
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            AppLog("1014&H", ex.Message, sqlCommA.CommandText)
            Exit Sub
        End Try

    End Sub
    Private Sub Exit__Click(sender As Object, e As EventArgs) Handles Exit_.Click
        Close()
    End Sub
    Private Sub FrmReset()
        BackColor = Color.FromArgb(200, 200, 200)
        TxtId.Text = ""
        LblNm.Visible = False
        TxtNm.Visible = False
        TxtNm.Enabled = True
        TxtNm.BackColor = Color.White
        TxtNm.Text = ""
        LblRNm.Visible = False
        TxtRNm.Visible = False
        TxtRNm.Enabled = True
        TxtRNm.BackColor = Color.White
        TxtRNm.Text = ""
        LblGndr.Visible = False
        CBxGndr.Visible = False
        CBxGndr.Enabled = True
        CBxGndr.BackColor = Color.White
        CBxGndr.Text = ""
        LblGsm.Visible = False
        TxtGSM.Visible = False
        TxtGSM.Enabled = True
        TxtGSM.BackColor = Color.White
        TxtGSM.Text = ""
        LblEmail.Visible = False
        TxtEmail.Visible = False
        TxtEmail.Enabled = True
        TxtEmail.BackColor = Color.White
        TxtEmail.Text = ""
        LblCat.Visible = False
        TxtCat.Visible = False
        TxtCat.Enabled = True
        TxtCat.BackColor = Color.White
        TxtCat.Text = ""
    End Sub
End Class