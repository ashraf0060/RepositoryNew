Public Class HeldPhPool
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    Dim UsrPhTbl As DataTable = New DataTable()
    Dim tREETbl As DataTable = New DataTable()
    Dim TempNode() As TreeNode
    Dim UsrStr As String = ""
    Dim cobindx As Integer = -1
    Dim rwindx As Integer = 0
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=CSSYS;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    Private Sub HeldPhPool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsrStr = ""
        tREETbl.Rows.Clear()
        UserTree.ImageList = ImgLst

        UserTree.Nodes.Add(Usr.PUsrCat.ToString, Usr.PUsrID & " - " & Usr.PUsrCatNm & " - " & Usr.PUsrRlNm, 1, 3)
        '                   0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
        If GetTbl("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0)  Order By UCatIdSub, UsrRealNm", tREETbl, "1025&H") = Nothing Then
            For Cnt_ = 0 To tREETbl.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(tREETbl(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(tREETbl(Cnt_).Item(1).ToString, tREETbl(Cnt_).Item(0).ToString & " - " & tREETbl(Cnt_).Item(4).ToString, 0, 2)
                    UsrStr &= "UsrId = " & tREETbl(Cnt_).Item(0).ToString & " OR "
                    If TempNode(0).Nodes.Count > 0 Then
                        TempNode(0).ImageIndex = 1
                        TempNode(0).SelectedImageIndex = 3
                    End If
                End If
            Next Cnt_
            If UsrStr.Length > 0 Then
                UsrStr = Mid(UsrStr, 1, UsrStr.Length - 4)
                FilPhPool1()
            Else
                UsrStr = ""
            End If
            UserTree.ExpandAll()
        End If
        RadioButton1.Checked = True
        Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
        GridHeld.Size = New Point(Me.Width - (UserTree.Width + 45), Me.Height - 125)
        UserTree.Size = New Point(UserTree.Width, Me.Height - 125)
        'GridPHHeld.Width = Me.Width - 20

        AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Rslt As DialogResult
        sqlComminsert_3.Connection = sqlCon
        sqlComminsert_3.CommandType = CommandType.Text
        sqlComminsert_4.Connection = sqlCon
        sqlComminsert_4.CommandType = CommandType.Text
        RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        AddHandler GridHeld.SelectionChanged, AddressOf Ntf_SelectionChanged
        Dim MsgNm As String = ""
        Dim UsrIdd As Integer
        If Val(TxtCnt.Text) > 0 Then
            If RadioButton1.Checked = True Then
                If IsNothing(UserTree.SelectedNode) = False Then
                    MsgNm = Split(UserTree.SelectedNode.Text.ToString, "-")(2)
                    UsrIdd = Split(UserTree.SelectedNode.Text.ToString, "-")(0)
                Else
                    LblMsg.Text = "برجاء اختيار اسم الموظف "
                    LblMsg.ForeColor = Color.Red
                    LblMsg.Refresh()
                    Exit Sub
                End If
            ElseIf RadioButton2.Checked = True Then
                If CombUsrs.SelectedIndex <> -1 Then
                    MsgNm = Trim(Split(CombUsrs.Text, "|")(1))
                    UsrIdd = CombUsrs.SelectedValue
                Else
                    LblMsg.Text = "برجاء اختيار اسم الموظف "
                    LblMsg.ForeColor = Color.Red
                    LblMsg.Refresh()
                    Exit Sub
                End If
            End If
        Else
            LblMsg.Text = "برجاء ادخال العدد المراد تحويله "
            LblMsg.ForeColor = Color.Red
            LblMsg.Refresh()
            Exit Sub
        End If
        Rslt = MessageBox.Show("سيتم تحويل عدد " & Val(TxtCnt.Text) & " لـ" & MsgNm, "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        If Rslt = DialogResult.Yes Then
                    If sqlCon.State = ConnectionState.Closed Then
                        sqlCon.Open()
                    End If
                    Tran = sqlCon.BeginTransaction()
                    For rwindx = 0 To Val(TxtCnt.Text) - 1
                sqlComminsert_3.CommandText = "UPDATE Rsv SET Rsv.RsvAssignUser = " & UsrIdd & " WHERE (Rsv.RsvID= " & GridHeld.Rows(rwindx).Cells(0).Value & ");"
                sqlComminsert_4.CommandText = "INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) Values 
                                        (" & GridHeld.Rows(rwindx).Cells(0).Value & ",'" & "تم تحويل الشحنة لشاشة الاخطارات التليفونية" & "'," & Usr.PUsrID & "," & 1 & ",'" & OsIP() & "')"
                        Try
                            sqlComminsert_3.Transaction = Tran
                            sqlComminsert_4.Transaction = Tran
                            sqlComminsert_3.ExecuteNonQuery()
                            sqlComminsert_4.ExecuteNonQuery()
                            LblMsg.Text = rwindx + 1 & " Of " & Val(TxtCnt.Text)
                            LblMsg.ForeColor = Color.Green
                            LblMsg.Refresh()
                        Catch ex As Exception
                            Tran.Rollback()
                            LblMsg.Text = rwindx + 1 & " Of " & Val(TxtCnt.Text)
                            LblMsg.ForeColor = Color.Red
                            LblMsg.Refresh()
                        End Try
                        If rwindx > 1 Then GridHeld.Rows(rwindx - 1).Selected = False
                        GridHeld.Rows(rwindx).Selected = True
                        GridHeld.Rows(rwindx).DefaultCellStyle.ForeColor = Color.Green
                        If rwindx > 0 Then GridHeld.FirstDisplayedScrollingRowIndex = rwindx - 1
                    Next
                    Tran.Commit()
                    RemoveHandler GridHeld.SelectionChanged, AddressOf Ntf_SelectionChanged
                    LblMsg.Text = "تم تحويل عدد " & Val(TxtCnt.Text)
                    LblMsg.ForeColor = Color.Green
                    LblMsg.Refresh()
                    FilPhPool1()
                End If

                AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
    End Sub
    Private Sub FilPhPool1()
        RemoveHandler CombUsrs.SelectedIndexChanged, AddressOf CombUsrs_SelectedIndexChanged
        HeldTable.Rows.Clear()
        UsrPhTbl.Rows.Clear()
        If GetTbl("SELECT RsvID, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvMob, RsvAdd, RsvReason, RsvDate, RsvDoc, RsvType, RsvType1 FROM Notification
                                                                WHERE ((Not (RsvMob) Is Null And (RsvMob) <>'0') AND ((RsvType)<2) AND ((RsvAssignUser) Is Null) AND ((Phonefailure)=0))
                                                                ORDER BY RsvID;", HeldTable, "0000&H") = Nothing And
        GetTbl("select Int_user.UsrId, Int_user.UsrRealNm, CountOfRsvID,Int_user.UsrCat from Int_user LEFT OUTER join (

                        SELECT        RsvAssignUser, AssignedUser AS Name_, COUNT(RsvID) AS CountOfRsvID
                        FROM            dbo.Notification
                        WHERE        (NOT (RsvAssignUser IS NULL)) AND (Phonefailure = 0) AND (RsvType < 2)
                        GROUP BY RsvAssignUser, AssignedUser) As gg on Int_user.UsrId = gg.RsvAssignUser
 
                        where (Int_user.UsrSusp = 0) AND " & UsrStr & "ORDER BY UsrId", UsrPhTbl, "0000&H") = Nothing Then
            GridHeld.DataSource = HeldTable
            If GridHeld.SelectedCells.Count > 0 Then
                GridHeld.Rows(0).Selected = True
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
            Else
                LblMsg.Text = ""
            End If
            For fff = 0 To UsrPhTbl.Rows.Count - 1
                If UsrPhTbl.Rows(fff).Item(2).ToString.Length = 0 Then
                    UsrPhTbl.Rows(fff).Item(1) = "0   | " & UsrPhTbl.Rows(fff).Item(1)
                ElseIf UsrPhTbl.Rows(fff).Item(2).ToString.Length > 0 Then
                    Dim nnn As Integer = UsrPhTbl.Rows(fff).Item(2).ToString.Length
                    Dim Spce As String = "    "
                    Spce = Mid(Spce, 1, 4 - UsrPhTbl.Rows(fff).Item(2).ToString.Length)
                    UsrPhTbl.Rows(fff).Item(1) = UsrPhTbl.Rows(fff).Item(2) & Spce & "| " & UsrPhTbl.Rows(fff).Item(1)
                End If
            Next
            CombUsrs.DataSource = UsrPhTbl
            CombUsrs.DisplayMember = "UsrRealNm"
            CombUsrs.ValueMember = "Usrid"
            CombUsrs.SelectedIndex = -1
            If cobindx > -1 Then
                CombUsrs.SelectedIndex = cobindx
            Else
                CombUsrs.SelectedIndex = -1
            End If
            TxtCnt.Text = ""
            GridPopulte()
            AddHandler CombUsrs.SelectedIndexChanged, AddressOf CombUsrs_SelectedIndexChanged
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If

    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).Visible = False
        GridHeld.Columns(1).HeaderText = "رقم الشحنة"
        GridHeld.Columns(2).HeaderText = "بلد المنشأ"
        GridHeld.Columns(3).HeaderText = "الوزن"
        GridHeld.Columns(4).HeaderText = "اسم العميل"
        GridHeld.Columns(5).HeaderText = "رقم الموبايل"
        GridHeld.Columns(6).Visible = False
        GridHeld.Columns(7).Visible = False
        GridHeld.Columns(8).HeaderText = "تاريخ الحجز"
        GridHeld.Columns(9).Visible = False
        GridHeld.Columns(10).Visible = False
        GridHeld.Columns(11).Visible = False
        '     GridHeld.Columns(12).HeaderText = "اسم الموظف"
        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GridHeld.AutoResizeColumns()
        'LblMsg.Text = "تم تحميل  " & UsrPhTbl.Rows.Count & " بيان"
        'LblMsg.ForeColor = Color.Green
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs)
        LblMsg.Text = GridHeld.CurrentRow.Index & " Of " & GridHeld.Rows.Count.ToString()
        LblMsg.Refresh()
    End Sub
    Private Sub Ntf_SelectionChanged(sender As Object, e As EventArgs)
        If GridHeld.Rows.Count > 0 Then
            LblMsg.Text = GridHeld.Rows(rwindx).Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
        Else
            LblMsg.Text = 0 & " Of " & 0
            LblMsg.Refresh()
        End If

    End Sub
    Private Sub CombUsrs_SelectedIndexChanged(sender As Object, e As EventArgs)
        cobindx = CombUsrs.SelectedIndex
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton1.Checked = True Then
            GridHeld.Size = New Point(Me.Width - (UserTree.Width + 45), Me.Height - 125)
            UserTree.Size = New Point(UserTree.Width, Me.Height - 125)
            UserTree.Visible = True
            CombUsrs.Visible = False
        Else
            GridHeld.Size = New Point(Me.Width - (45), Me.Height - 125)
            UserTree.Size = New Point(UserTree.Width, Me.Height - 125)
            UserTree.Visible = False
            CombUsrs.Visible = True
        End If
    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterSelect
        'MsgBox(Split(UserTree.SelectedNode.Text.ToString, "-")(0))
    End Sub
End Class