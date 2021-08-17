Imports System.Threading
Public Class HeldPhAllUsr
    Dim HeldTable As DataTable = New DataTable
    Dim UsrPhTbl As DataTable = New DataTable()
    Dim UsrPhTbl1 As DataTable = New DataTable()
    Dim cobindx As Integer = -1
    Dim rwindx As Integer = 0
    Dim Ntf1 As Integer = 0
    Dim NTF2 As Integer = 0
    Dim NTF3 As Integer = 0
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=CSSYS;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    'Dim sqlCon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=ntf;Password=@asdasdasd123321") ' I Have assigned conn STR here and delete this row from all project
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub HeldSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilPhPool1()
    End Sub
    Private Sub FilPhPool1()
        RemoveHandler CombUsrs.SelectedIndexChanged, AddressOf CombUsrs_SelectedIndexChanged
        RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        HeldTable.Rows.Clear()
        UsrPhTbl.Rows.Clear()
        If GetTbl("SELECT RsvID, RsvTracing, RsvWeight, RsvConsignee, CounNm, RsvMob, RsvAdd, RsvReason, RsvDate, RsvDoc, RsvType, RsvType1, RsvAssignUser, AssignedUser FROM dbo.Notification
                                        WHERE (Phonefailure = 0) AND (RsvType < 2) AND (RsvMob IS NOT  NULL) AND (RsvAssignUser IS NOT NULL) ORDER BY RsvID", HeldTable, "0000&H") = Nothing And
            GetTbl("select Int_user.UsrId, Int_user.UsrRealNm, CountOfRsvID,Int_user.UsrCat from Int_user LEFT OUTER join (

SELECT        RsvAssignUser, AssignedUser AS Name_, COUNT(RsvID) AS CountOfRsvID
FROM            dbo.Notification
WHERE        (NOT (RsvAssignUser IS NULL)) AND (Phonefailure = 0) AND (RsvType < 2)
GROUP BY RsvAssignUser, AssignedUser) As gg on Int_user.UsrId = gg.RsvAssignUser
 
where (Int_user.UsrSusp = 0) AND (Int_user.UsrCat = 213 or Int_user.UsrCat = 127 or Int_user.UsrCat = 125 or Int_user.UsrCat = 126 or Int_user.UsrCat = 29 or Int_user.UsrCat =9 )
ORDER BY Int_user.UsrCat DESC, Int_user.UsrRealNm", UsrPhTbl, "0000&H") = Nothing Then

            GridHeld.DataSource = HeldTable
            If GridHeld.SelectedCells.Count > 0 Then
                GridHeld.Rows(0).Selected = True
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
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
            CombUsrs.ResetText()

            UsrPhTbl1 = UsrPhTbl.Copy()

            CombUsrsFltr.DataSource = UsrPhTbl1
            CombUsrsFltr.DisplayMember = "UsrRealNm"
            CombUsrsFltr.ValueMember = "Usrid"
            CombUsrsFltr.ResetText()


            If cobindx > -1 Then
                CombUsrs.SelectedIndex = cobindx
            Else
                CombUsrs.ResetText()
            End If
            TxtCnt.Text = ""
            GridPopulte()
            If GridHeld.Rows.Count > 0 Then GridHeld.Rows(0).Selected = True
            AddHandler CombUsrs.SelectedIndexChanged, AddressOf CombUsrs_SelectedIndexChanged
            AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If


    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).Visible = False
        GridHeld.Columns(1).HeaderText = "رقم الشحنة"
        GridHeld.Columns(2).HeaderText = "الوزن"
        GridHeld.Columns(3).HeaderText = "اسم العميل"
        GridHeld.Columns(4).HeaderText = "بلد المنشأ"
        GridHeld.Columns(5).HeaderText = "رقم الموبايل"
        GridHeld.Columns(6).Visible = False
        GridHeld.Columns(7).Visible = False
        GridHeld.Columns(8).HeaderText = "تاريخ الحجز"
        GridHeld.Columns(9).Visible = False
        GridHeld.Columns(10).Visible = False
        GridHeld.Columns(11).Visible = False
        GridHeld.Columns(12).Visible = False
        GridHeld.Columns(13).HeaderText = "اسم الموظف"
        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridHeld.AutoResizeColumns()
        'LblMsg.Text = "تم تحميل  " & UsrPhTbl.Rows.Count & " بيان"
        'LblMsg.ForeColor = Color.Green
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridHeld.CurrentCell.Value)
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs)
        If GridHeld.Rows.Count > 0 Then
            If CombUsrsFltr.Text.Length > 0 Then
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & CombUsrsFltr.Text
                LblMsg.Refresh()
            Else
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
            End If
        Else
            LblMsg.Text = ""
            LblMsg.Refresh()
        End If

    End Sub
    Private Sub CombUsrs_SelectedIndexChanged(sender As Object, e As EventArgs)
        cobindx = CombUsrs.SelectedIndex
    End Sub
    Private Sub CombUsrsFltr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CombUsrsFltr.SelectedIndexChanged
        If CombUsrsFltr.Focused Then
            HeldTable.DefaultView.RowFilter = "[RsvAssignUser] = " & CombUsrsFltr.SelectedValue
            TxtCnt.Text = Trim(Split(CombUsrsFltr.Text, "|")(0))
            If GridHeld.Rows.Count > 0 Then GridHeld.Rows(0).Selected = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Rslt As DialogResult
        sqlComminsert_3.Connection = sqlCon
        sqlComminsert_3.CommandType = CommandType.Text
        sqlComminsert_4.Connection = sqlCon
        sqlComminsert_4.CommandType = CommandType.Text

        If Val(TxtCnt.Text) > 0 Then
            If CombUsrs.Text.Length > 0 Then
                Rslt = MessageBox.Show("سيتم تحويل عدد " & Val(TxtCnt.Text) & " لـ" & Trim(Split(CombUsrs.Text, "|")(1)), "رسالة معلومات", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    RemoveHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
                    AddHandler GridHeld.SelectionChanged, AddressOf Ntf_SelectionChanged
                    If sqlCon.State = ConnectionState.Closed Then
                        sqlCon.Open()
                    End If
                    Tran = sqlCon.BeginTransaction()
                    For rwindx = 0 To Val(TxtCnt.Text) - 1
                        sqlComminsert_3.CommandText = "UPDATE Rsv SET Rsv.RsvAssignUser = " & CombUsrs.SelectedValue & " WHERE (Rsv.RsvID= " & GridHeld.Rows(rwindx).Cells(0).Value & ");"
                        'sqlComminsert_4.CommandText = "INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) Values 
                        '                (" & DataGridView1.Rows(rwindx).Cells(0).Value & ",'" & "تم تحويل الشحنة لشاشة الاخطارات التليفونية" & "','" & "ADM" & "'," & 1 & ",'" & OsIP() & "')"
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
            Else
                LblMsg.Text = "برجاء اختيار اسم الموظف "
                LblMsg.ForeColor = Color.Red
                LblMsg.Refresh()
            End If
        Else
            LblMsg.Text = "برجاء ادخال العدد المراد تحويله "
            LblMsg.ForeColor = Color.Red
            LblMsg.Refresh()
        End If
        AddHandler GridHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
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
    Private Sub CombUsrsFltr_TextChanged(sender As Object, e As EventArgs) Handles CombUsrsFltr.TextChanged
        If CombUsrsFltr.SelectedIndex <> -1 Then

        Else
            HeldTable.DefaultView.RowFilter = String.Empty
            LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
            TxtCnt.Text = 0
        End If
    End Sub
End Class