Public Class TikEdit
    Dim EditTable As DataTable = New DataTable
    Dim PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Dim UpTxt As String = ""
    Dim ReAssgnSTR As String = ""
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TikEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        TreeView1.Visible = False
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            GroupBox3.Visible = False
            GroupBox4.Visible = False
            ChckReAssign.Enabled = False
            ChckReAssign.BackColor = Color.Red
Popul_:
            If TreeView1.Nodes.Count = 1 Or TreeView1.Nodes.Count = Nothing Then
                Dim Root As String = ""
                Dim Child1 As String = ""
                TreeView1.ImageList = ImgLst
                ' Populate Main Root
                TreeView1.Nodes.Clear()

                For Cnt_ = 0 To ProdKTable.Rows.Count - 1
                    TreeView1.Nodes.Add(ProdKTable.Rows(Cnt_).Item(0).ToString, ProdKTable.Rows(Cnt_).Item(1).ToString, 1, 3)
                Next

                'Populate Products Nodes
                For Cnt_ = 0 To ProdCompTable.Rows.Count - 1
                    For Each n As TreeNode In Me.TreeView1.Nodes
                        If n.Name = ProdCompTable.Rows(Cnt_).Item(1).ToString Then
                            TreeView1.SelectedNode = n
                        End If
                    Next
                    If Child1 <> ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString Then
                        TreeView1.SelectedNode.Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnProdCd").ToString(), ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString(), 1, 3)
                    End If
                    Child1 = ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString
                Next

                ' Populate Complaints Nodes
                For Cnt_ = 0 To ProdCompTable.Rows.Count - 1
                    For Cnt_1 = 0 To TreeView1.Nodes.Count - 1
                        For Cnt_2 = 0 To TreeView1.Nodes(Cnt_1).Nodes.Count - 1
                            If Split(TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ToString, ": ")(1) = (ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString) Then
                                TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnSQL").ToString(), ProdCompTable.Rows(Cnt_).Item("CompNm").ToString(), 0, 2)
                                For Cont As Integer = 0 To TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).GetNodeCount(True) - 1
                                    TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Item(Cont).ForeColor = Color.Green
                                Next Cont
                                TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ForeColor = Color.FromArgb(165, 42, 42)
                            End If
                        Next Cnt_2
                    Next Cnt_1
                Next Cnt_
            End If
            AddHandler TreeView1.AfterSelect, AddressOf TreeView1_AfterSelect
        End If

    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)
        UpTxt = ""
        TreeView1.SelectedNode.Expand()
        If (TreeView1.SelectedNode.Level) = 2 Then
            If ChckReAssign.Checked = True Then
                tempTable.Rows.Clear()
                tempTable.Columns.Clear()
                GetTbl("SELECT UsrRealNm, dbo.VwFnProd.FnSQL FROM dbo.VwFnProd INNER JOIN dbo.Int_user ON dbo.VwFnProd.FnMngr = UsrId WHERE (dbo.VwFnProd.FnSQL = " & TreeView1.SelectedNode.Name & ")", tempTable, "0000&H")
                ReAssgnSTR = "سيتم تحويل الشكوى من " & TxtFolw.Text & " إلى " & tempTable.Rows(0).Item(0) & " خلال 15 دقيقة" & vbCrLf
                LblText.Text = ReAssgnSTR
            Else
                LblText.Text = ""
            End If

            If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> EditTable.Rows(0).Item("ProdKNm").ToString Then
                ChckReAssign.Enabled = True
                SubmitBtn.Enabled = True
                UpTxt = "تم تعديل نوع الخدمة من " & EditTable.Rows(0).Item("ProdKNm").ToString & " إلى " & Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) & vbCrLf
            End If

            If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) <> EditTable.Rows(0).Item("PrdNm").ToString Then
                ChckReAssign.Enabled = True
                SubmitBtn.Enabled = True
                TxtProd.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1)
                TxtProd.BackColor = Color.Aqua
                UpTxt &= "تم تعديل " & TxtProd.Tag & " من " & EditTable.Rows(0).Item("PrdNm").ToString & " إلى " & TxtProd.Text & vbCrLf
            Else
                TxtProd.Text = EditTable.Rows(0).Item("PrdNm").ToString
                TxtProd.BackColor = Color.White
            End If

            If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2) <> EditTable.Rows(0).Item("CompNm").ToString Then
                ChckReAssign.Enabled = True
                SubmitBtn.Enabled = True
                TxtComp.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2)
                TxtComp.BackColor = Color.Aqua
                UpTxt &= "تم تعديل " & TxtComp.Tag & " من " & EditTable.Rows(0).Item("CompNm").ToString & " إلى " & TxtComp.Text
            Else
                TxtComp.Text = EditTable.Rows(0).Item("CompNm").ToString
                TxtComp.BackColor = Color.White
            End If
        Else
            ChckReAssign.Enabled = False
            SubmitBtn.Enabled = False
            ChckReAssign.Checked = False
            ChckReAssign.BackColor = Color.Red
            LblText.Text = ""
            TxtProd.Text = EditTable.Rows(0).Item("PrdNm").ToString
            TxtComp.Text = EditTable.Rows(0).Item("CompNm").ToString
            TxtProd.BackColor = Color.White
            TxtComp.BackColor = Color.White
        End If

    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If TreeView1.SelectedNode Is Nothing Then
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                TreeView1.SelectedNode.Parent.Parent.Collapse(False)  'True to leave the child nodes in their Current state; false to collapse the child nodes.
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                TreeView1.SelectedNode.Parent.Collapse(False)
            ElseIf TreeView1.SelectedNode.Level = 0 Then
                TreeView1.SelectedNode.Collapse(False)
            End If
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub BtnGet_Click(sender As Object, e As EventArgs) Handles BtnGet.Click
        EditTable.Rows.Clear()
        lblMsg.Text = "جاري تحميل البيانات ............."
        lblMsg.Refresh()
        lblMsg.ForeColor = Color.DarkGreen
        If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '' AS LstUpdtTime, '' AS TkupTxt, 1 AS TkupUnread, 0 AS TkupEvtId, '' AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll  where TkID = " & TxtTikID.Text & " ORDER BY TkSQL DESC;", EditTable, "1050&H") = Nothing Then
            If EditTable.Rows.Count > 0 Then
                If EditTable.Rows(0).Item("TkKind") = True Then
                    If EditTable.Rows(0).Item("PrdKind") = 1 Then
                        GroupBox3.Visible = True
                        GroupBox4.Visible = False
                    ElseIf EditTable.Rows(0).Item("PrdKind") = 2 Then
                        GroupBox3.Visible = False
                        GroupBox4.Visible = True
                    Else
                        GroupBox3.Visible = False
                        GroupBox4.Visible = False
                    End If
                    TxtComp.BackColor = Color.White
                    TxtProd.BackColor = Color.White
                    TreeView1.CollapseAll()

                    If EditTable.Rows(0).Item("TkClsStatus") = True Then
                        TreeView1.Visible = False
                        lblMsg.Text = ("الشكوى مغلقة ولا يمكن تعديلها")
                        lblMsg.ForeColor = Color.Red
                        Exit Sub
                    End If
                    TxtPh1.Text = EditTable.Rows(0).Item("TkClPh").ToString
                    TxtPh2.Text = EditTable.Rows(0).Item("TkClPh1").ToString
                    TxtDt.Text = EditTable.Rows(0).Item("TkDtStart").ToString
                    TxtNm.Text = EditTable.Rows(0).Item("TkClNm").ToString
                    TxtAdd.Text = EditTable.Rows(0).Item("TkClAdr").ToString
                    TxtEmail.Text = EditTable.Rows(0).Item("TkMail").ToString
                    TxtDetails.Text = EditTable.Rows(0).Item("TkDetails").ToString
                    TxtArea.Text = EditTable.Rows(0).Item("OffArea").ToString
                    TxtOff.Text = EditTable.Rows(0).Item("OffNm1").ToString
                    TxtProd.Text = EditTable.Rows(0).Item("PrdNm").ToString
                    TxtComp.Text = EditTable.Rows(0).Item("CompNm").ToString
                    TxtSrc.Text = EditTable.Rows(0).Item("SrcNm").ToString
                    TxtTrck.Text = EditTable.Rows(0).Item("TkShpNo").ToString
                    TxtOrgin.Text = EditTable.Rows(0).Item("CounNmSender").ToString
                    TxtDist.Text = EditTable.Rows(0).Item("CounNmConsign").ToString
                    TxtCard.Text = EditTable.Rows(0).Item("TkCardNo").ToString
                    TxtGP.Text = EditTable.Rows(0).Item("TkGBNo").ToString
                    TxtNId.Text = EditTable.Rows(0).Item("TkClNtID").ToString
                    TxtAmount.Text = EditTable.Rows(0).Item("TkAmount").ToString
                    TxtTransDt.Text = EditTable.Rows(0).Item("TkTransDate").ToString
                    TxtFolw.Text = EditTable.Rows(0).Item("UsrRealNm").ToString
                    SubmitBtn.Enabled = True
                    lblMsg.Text = ""
                    TreeView1.Visible = True
                Else
                    lblMsg.Text = ("الرقم الذي تم ادخاله يخص استفسار" & " - " & "لا يمكن تعديل بيانات الاستفسار")
                    lblMsg.ForeColor = Color.Red
                End If
            Else
                TreeView1.Visible = False
                lblMsg.Text = ("لا توجد شكوى مسجلة بهذا الرقم" & vbCrLf & "يرجى التأكد من الرقم وإعادة المحاولة")
                lblMsg.ForeColor = Color.Red
            End If
        End If
    End Sub
    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        If IsNothing(TreeView1.SelectedNode) = False Then
            If TreeView1.SelectedNode.Level = 2 Then
                Dim ReAssgn As Integer = 0
                If ChckReAssign.Checked = True Then
                    UpTxt &= vbCrLf & "تم تجهيز الشكوى للتحويل للفريق المختص"
                    ReAssgn = 1
                Else
                    ReAssgnSTR = ""
                End If
                If UpTxt.Length > 0 Then
                    Dim Rslt As DialogResult
                    Rslt = MessageBox.Show(ReAssgnSTR & "هل تريد حفظ التعديلات؟", "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                    If Rslt = DialogResult.Yes Then
                        PublicCode.InsTrans("update Tickets set TkFnPrdCd = " & TreeView1.SelectedNode.Name & ", TkReAssign = " & ReAssgn & " where TkSQL = " & EditTable.Rows(0).Item("TkSQL"), "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               (" & EditTable.Rows(0).Item("TkSQL") & ",'" & UpTxt & "','" & "0" & "','" & "901" & "','" & OsIP() & "','" & Usr.PUsrID & "');", "1051&H")
                        lblMsg.Text = ("تمت التعديلات بنجاح")
                        lblMsg.ForeColor = Color.DarkGreen
                        SubmitBtn.Enabled = False
                    End If

                Else
                    lblMsg.Text = ("لا توجد هناك أي تعديلات للحفظ")
                    lblMsg.ForeColor = Color.DarkGreen
                End If
            Else
                MsgInf("برجاء اختيار توع الخدمة ونوع الشكوى")
            End If
        Else
            MsgInf("برجاء اختيار توع الخدمة ونوع الشكوى")
        End If



    End Sub
    Private Sub ChckReAssign_Click(sender As Object, e As EventArgs) Handles ChckReAssign.Click
        If ChckReAssign.Checked = True Then
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            GetTbl("SELECT UsrRealNm, dbo.VwFnProd.FnSQL FROM dbo.VwFnProd INNER JOIN dbo.Int_user ON dbo.VwFnProd.FnMngr = UsrId WHERE (dbo.VwFnProd.FnSQL = " & TreeView1.SelectedNode.Name & ")", tempTable, "0000&H")
            ReAssgnSTR = "سيتم تحويل الشكوى من " & TxtFolw.Text & " إلى " & tempTable.Rows(0).Item(0) & " خلال 15 دقيقة" & vbCrLf
            LblText.Text = ReAssgnSTR
            ChckReAssign.BackColor = Color.LimeGreen
        Else
            LblText.Text = ""
            ChckReAssign.BackColor = Color.Red
        End If
    End Sub
End Class