Public Class UReset
    Dim URstTbl As DataTable = New DataTable
    Dim TmpUsrSusp As Boolean
    Private Sub UReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '     0  ,    1 ,   2      ,    3   ,  4
        Me.Size = New Point(screenWidth, screenHeight - 100)
        UsrData.Size = New Point(UsrData.Width, Me.Height - 100)
        If PublicCode.GetTbl("SELECT UsrId, UsrNm, UsrRealNm, UsrSusp, UCatNm FROM Int_user INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId", URstTbl, "1046&H") = Nothing Then
            BindingSource1.DataSource = URstTbl
            BindNavigatorUsr.BindingSource = BindingSource1
            UsrData.DataSource = BindingSource1
            UsrData.AutoResizeColumns()
            InputLanguage.CurrentInputLanguage = ArabicInput
        End If
        Refresh()
    End Sub
    Private Sub Filtration(sender As Object, e As EventArgs) Handles Susd.Click, Resm.Click, Alls.Click, BtnFltr.Click
        Dofiltr()
    End Sub
    Sub Dofiltr()
        Dim Filtr As String = String.Empty
        If Susd.Checked = True Then
            Filtr = "[UsrSusp]=1"
        ElseIf Resm.Checked = True Then
            Filtr = "[UsrSusp]=0"
        ElseIf Alls.Checked = True Then
            Filtr = String.Empty
        End If
        If TxtUsrNm.TextLength > 0 Then
            If Filtr.Length > 0 Then Filtr += " and "
            Filtr += "([UsrRealNm] like '%" & TxtUsrNm.Text & "%'"
            Filtr += " or [UsrNm] like '%" & TxtUsrNm.Text & "%')"
        End If
        If TxtUsrNm.TextLength > 0 Then
        End If
        URstTbl.DefaultView.RowFilter = Filtr
        LblHint.Text = " "
    End Sub
    Private Sub UsrData_SelectionChanged(sender As Object, e As EventArgs) Handles UsrData.SelectionChanged
        LblHint.Text = " "
        CuCnt_UsrSta()
    End Sub
    Private Sub BtnSuRs_Click(sender As Object, e As EventArgs) Handles BtnSuRs.Click
        Dim Rslt As DialogResult
        Rslt = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If Rslt = DialogResult.Yes Then
            If PublicCode.InsUpd("UPDATE Int_user SET UsrSusp ='" & TmpUsrSusp & "' WHERE (UsrId = " & UsrData.CurrentRow.Cells(0).Value & ");", "1040&H") = Nothing Then
                LblHint.Text = "Current user status was changed from " & UsrData.CurrentRow.Cells(3).Value & " to " & TmpUsrSusp.ToString
                UsrData.CurrentRow.Cells(3).Value = TmpUsrSusp
                CuCnt_UsrSta()
                If TmpUsrSusp = False Then
                    InsUpd("delete from AUsrControls where UCtlUsrId = " & UsrData.CurrentRow.Cells(0).Value, "0000&H")
                Else
                    ''AddCtrlsToUsrTbl()
                End If
            Else
                LblHint.Text = "Can't Update the data right now Please try again later"
            End If
        Else
            LblHint.Text = "Nothing Happend"
        End If
    End Sub
    Sub CuCnt_UsrSta()
        Try
            BtnPassRst.Enabled = True
            BtnSuRs.Enabled = True
            If IsNothing(UsrData.CurrentRow) = False Then
                LblCUsr.Text = "Current Selected user: " & UsrData.CurrentRow.Cells(2).Value
                If UsrData.CurrentRow.Cells(3).Value = True Then
                    TmpUsrSusp = False
                    BtnSuRs.BackgroundImage = My.Resources.UsrSusp
                    BtnSuRs.Tag = "Push to resume suspended User"
                    BtnPassRst.BackgroundImage = My.Resources.recgrey
                    BtnPassRst.Enabled = False
                    BtnRstCtrls.Enabled = False
                Else
                    TmpUsrSusp = True
                    BtnSuRs.BackgroundImage = My.Resources.Usrresm
                    BtnSuRs.Tag = "Push to suspend Current Selected User"
                    BtnPassRst.BackgroundImage = My.Resources.RstPass
                    BtnPassRst.Enabled = True
                    BtnRstCtrls.Enabled = True
                End If
            End If
        Catch ex As Exception
            LblCUsr.Text = "There is no Current Selected user: "
            BtnPassRst.Enabled = False
            BtnSuRs.Enabled = False
        End Try
    End Sub
    Private Sub BtnPassRst_Click(sender As Object, e As EventArgs) Handles BtnPassRst.Click
        Dim Rslt As DialogResult
        Rslt = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If Rslt = DialogResult.Yes Then
            If PublicCode.InsUpd("UPDATE Int_user SET UsrPass = 'HDJRJi0dIhNwY5H0iB7zjQ==' , UsrKey = 'A430FABA825' WHERE (UsrId = " & UsrData.CurrentRow.Cells(0).Value & ");", "1041&H") = Nothing Then
                LblHint.Text = "Current user' password was reset to the default "
            Else
                LblHint.Text = "Can't Update the data right now Please try again later"
            End If
        Else
            LblHint.Text = "Nothing Happend"
        End If
    End Sub
    Private Sub BtnSuRs_MouseHover(sender As Object, e As EventArgs) Handles BtnSuRs.MouseHover
        ToolTip1.Show(BtnSuRs.Tag, BtnSuRs)
    End Sub
    Private Sub TxtUsrNm_TextChanged(sender As Object, e As EventArgs) Handles TxtUsrNm.TextChanged
        Dofiltr()
    End Sub
    Private Sub CopyToolStripitem_Click(sender As Object, e As EventArgs) Handles CopyToolStripitem.Click
        Clipboard.SetText(UsrData.CurrentCell.Value)
    End Sub
    Private Sub BtnRstCtrls_Click(sender As Object, e As EventArgs) Handles BtnRstCtrls.Click
        'UsrData.CurrentRow.Cells(0).Value
        Rslt = MessageBox.Show("You Will Reset All Controls to " & UsrData.CurrentRow.Cells(2).Value & " AND HE CAN'T GET THIS CONFIGRATION AGAIN" & vbNewLine &
                               "Are You Sure", "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification Or MessageBoxOptions.ServiceNotification)
        If Rslt = DialogResult.Yes Then
            InsUpd("delete from AUsrControls where UCtlUsrId = " & UsrData.CurrentRow.Cells(0).Value, "0000&H")
            'Me.WindowState = FormWindowState.Maximized
            'AddCtrlsToUsrTbl()
        End If
    End Sub
    Private Sub AddCtrlsToUsrTbl()
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        If GetTbl("Select [Ctlcount],[CtlFormName],[CtlControlName],[CtlControlType],[CtlX],[CtlY],[CtlFntSize],[CtlFntWidth],[CtlFntHeight] from AControls", tempTable, "0000&H") = Nothing Then
            tempTable.Columns.Add("UsrID_")
            For tt = 0 To tempTable.Rows.Count - 1
                tempTable.Rows(tt).Item("UsrID_") = UsrData.CurrentRow.Cells(0).Value
            Next
            Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon)
            SQLBulkCopy.DestinationTableName = "AUsrControls"
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            SQLBulkCopy.WriteToServer(tempTable)
            SQLBulkCopy.Close()
        End If
    End Sub
End Class