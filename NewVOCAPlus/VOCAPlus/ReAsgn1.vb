Public Class ReAsgn1
    Private ReadOnly UserTable As DataTable = New DataTable
    Private ReAsinTable As DataTable = New DataTable
    Dim UsrStr As String = ""
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub ReAsgn1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        Dim TempNode() As TreeNode
        UserTree.ImageList = ImgLst
        UserTree.Nodes.Add(Usr.PUsrCat.ToString, Usr.PUsrID & " - " & Usr.PUsrCatNm & " - " & Usr.PUsrRlNm, 1, 3)
        '                   0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
        If GetTbl("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) AND (UCatLvl between 3 and 5) Order By UCatIdSub, UsrRealNm", UserTable, "1025&H") = Nothing Then
            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTable(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(0).ToString & " - " & UserTable(Cnt_).Item(4).ToString, 0, 2)
                    UsrStr &= "TkEmpNm = " & UserTable(Cnt_).Item(0).ToString & " OR "
                    If TempNode(0).Nodes.Count > 0 Then
                        TempNode(0).ImageIndex = 1
                        TempNode(0).SelectedImageIndex = 3
                    End If
                End If
            Next Cnt_
            If UsrStr.Length > 0 Then UsrStr = Mid(UsrStr, 1, UsrStr.Length - 4) Else UsrStr = ""
            UserTree.ExpandAll()
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Me.Close()
        End If
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        BtnGet.Tag = "تحميل"
        LblMsg.Text = ""
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtCompId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCompId.KeyPress
        IntUtly.ValdtInt(e)
    End Sub
    Private Sub TxtCompId_TextChanged(sender As Object, e As EventArgs) Handles TxtCompId.TextChanged
        BtnGet.Tag = "تحميل"
        BtnGet.Enabled = True
        BtnGet.BackgroundImage = My.Resources.DbGet
        LblMsg.Text = ""
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "TxtCompId" Then
                    ctrl.Text = ""
                End If
            End If
        Next
    End Sub
    Private Sub BtnGet_Click(sender As Object, e As EventArgs) Handles BtnGet.Click
        Dim sqlCominsert_1 As New SqlCommand            'SQL Command
        Dim sqlCominsert_2 As New SqlCommand            'SQL Command

        If TxtCompId.TextLength > 0 Then
            BtnGet.Enabled = False
            If BtnGet.Tag = "تحميل" Then
                ReAsinTable.Rows.Clear()
                ReAsinTable.Columns.Clear()
                LblMsg.Text = "جاري تحميل البيانات ...."
                LblMsg.ForeColor = Color.Green
                '                   0          1          2         3      4      5      6       7        8         9        10       11        12      
                If GetTbl("SELECT TkSQL, TkClsStatus, TkDtStart, TkKind, TkID, TkClNm, PrdNm, CompNm, UsrRealNm, TkClPh, TkDetails, TkShpNo, TkCardNo FROM TicketsAll WHERE (TkID = " & TxtCompId.Text & ") AND (TkClsStatus = 0) AND (" & UsrStr & ");", ReAsinTable, "1030&H") = Nothing Then
                    If ReAsinTable.Rows.Count > 0 Then
                        BtnGet.Tag = "تحويل"
                        BtnGet.BackgroundImage = My.Resources.CpTrns
                        LblMsg.Text = ""

                        TxtPh1.Text = ReAsinTable(0).Item(9).ToString
                        TxtDt.Text = ReAsinTable(0).Item(2).ToString
                        TxtNm.Text = ReAsinTable(0).Item(5).ToString
                        TxtDetails.Text = ReAsinTable(0).Item(10).ToString
                        TxtProd.Text = ReAsinTable(0).Item(6).ToString
                        TxtComp.Text = ReAsinTable(0).Item(7).ToString
                        TxtFollNm.Text = ReAsinTable(0).Item(8).ToString
                        TxtTrck.Text = ReAsinTable(0).Item(11).ToString
                        TxtCard.Text = ReAsinTable(0).Item(12).ToString
                    Else
                        ReAsinTable.Rows.Clear()
                        ReAsinTable.Columns.Clear()
                        If PublicCode.GetTbl("SELECT TkSQL, TkClsStatus, TkKind FROM TicketsAll WHERE (TkID = " & TxtCompId.Text & ");", ReAsinTable, "1030&H") = Nothing Then
                            If ReAsinTable.Rows.Count > 0 Then
                                If ReAsinTable(0).Item(2) = 0 Then
                                    LblMsg.Text = "لا يمكن إعادة فتح الاستفسار  - وأيضاً لا يخص أعضاء فريقك"
                                    LblMsg.ForeColor = Color.Red
                                    Beep()
                                Else
                                    If ReAsinTable(0).Item(1) = True Then
                                        LblMsg.Text = "الشكوى التي تريد تحويلها مغلقة - ولا تخص أعضاء فريقك"
                                        LblMsg.ForeColor = Color.Red
                                        Beep()
                                    Else
                                        LblMsg.Text = "الشكوى التي تريد تحويلها لا تخص أعضاء فريقك"
                                        LblMsg.ForeColor = Color.Red
                                        Beep()
                                    End If
                                End If
                            Else
                                LblMsg.Text = "لا توجد شكوى بهذا الرقم - من فضلك تأكد من الرقم وأعد المحاولة"
                                LblMsg.ForeColor = Color.Red
                                Beep()
                            End If
                        Else
                            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        End If
                    End If
                Else
                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End If
            Else
                If UserTree.SelectedNode IsNot Nothing Then
                    If UserTree.SelectedNode.Level <> 0 Then
                        If TxtFollNm.Text = Split(UserTree.SelectedNode.Text, " - ")(2) Then
                            LblMsg.Text = "لا يمكن تحويل الشكوى لنفس متابع الشكوى الحالى"
                            LblMsg.ForeColor = Color.Red
                            Beep()
                        Else
                            Dim Rslt As DialogResult
                            Rslt = MessageBox.Show("سيتم تحويل الشكوى رقم " & ReAsinTable(0).Item(4) & " إلى " & Split(UserTree.SelectedNode.Text, " - ")(2) & vbCrLf & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                            If Rslt = DialogResult.Yes Then
                                BtnGet.Enabled = False
                                LblMsg.Text = "جاري تحويل الشكوى ...."
                                LblMsg.ForeColor = Color.Green
                                Try
                                    If sqlCon.State = ConnectionState.Closed Then
                                        sqlCon.Open()
                                    End If
                                    sqlCominsert_1.Connection = sqlCon
                                    sqlCominsert_2.Connection = sqlCon
                                    sqlCominsert_1.CommandType = CommandType.Text
                                    sqlCominsert_2.CommandType = CommandType.Text
                                    sqlCominsert_1.CommandText = "update Tickets set TkEmpNm = " & Split(UserTree.SelectedNode.Text, " - ")(0) & ", TkFolw = 0, TkRecieveDt = (Select GetDate()) Where (TkSQL = " & ReAsinTable(0).Item(0) & ");"
                                    sqlCominsert_2.CommandText = "insert into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & ReAsinTable(0).Item(0) & "','" & "The Complaint has been transfered to " & Split(UserTree.SelectedNode.Text, " - ")(2) & "','" & "1" & "','" & "100" & "','" & OsIP() & "','" & Usr.PUsrID & "')"
                                    Tran = sqlCon.BeginTransaction()
                                    sqlCominsert_1.Transaction = Tran
                                    sqlCominsert_2.Transaction = Tran
                                    sqlCominsert_1.ExecuteNonQuery()
                                    sqlCominsert_2.ExecuteNonQuery()
                                    Tran.Commit()
                                    BtnGet.Tag = "تحميل"
                                    BtnGet.Enabled = True
                                    BtnGet.BackgroundImage = My.Resources.DbGet
                                    TxtFollNm.Text = Split(UserTree.SelectedNode.Text, " - ")(2)
                                    LblMsg.Text = "تم تحويل الشكوى رقم " & TxtCompId.Text & " إلى " & Split(UserTree.SelectedNode.Text, " - ")(2) & " بنجاح"
                                    LblMsg.ForeColor = Color.Green
                                Catch ex As Exception
                                    Tran.Rollback()
                                    AppLog("1033&H", ex.Message, sqlCominsert_1.CommandText & "_" & sqlCominsert_2.CommandText)
                                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                                End Try
                                'sqlCon.Close()
                                'SqlConnection.ClearPool(sqlCon)

                            Else
                                BtnGet.Tag = "تحميل"
                                BtnGet.Enabled = True
                                BtnGet.BackgroundImage = My.Resources.DbGet
                                LblMsg.Text = ""
                                For Each ctrl As Control In Me.Controls
                                    If TypeOf ctrl Is TextBox Then
                                        ctrl.Text = ""
                                    End If
                                Next
                            End If
                        End If
                    Else
                        LblMsg.Text = "لا يمكن تحويل الشكوى لمدير المجموعة"
                        LblMsg.ForeColor = Color.Red
                        Beep()
                    End If
                Else
                    LblMsg.Text = "يرجى اختيار الموظف المراد التحويل له أولا"
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            End If
        Else
            LblMsg.Text = "يرجى ادخال رقم الشكوى أولا"
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
        BtnGet.Enabled = True
    End Sub

    Private Sub BtnGet_MouseEnter(sender As Object, e As EventArgs) Handles BtnGet.MouseEnter
        ToolTip1.Show(BtnGet.Tag, BtnGet, 0, 20, 2000)
    End Sub
End Class