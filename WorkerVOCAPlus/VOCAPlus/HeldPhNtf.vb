Imports System.Threading
Public Class HeldPhNtf
    Dim sqlComnd As New SqlCommand                    'SQL Command
    Dim SQLTblAdpter As New SqlDataAdapter            'SQL Table Adapter
    Dim SerchItmTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim HeldPHTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    Dim NTFTbl As DataTable = New DataTable()
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
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)

        HeldPHTable.Rows.Clear()
        If GetTbl("SELECT RsvID, RsvTracing, RsvWeight, RsvConsignee, CounNm, RsvMob, RsvAdd, RsvReason, RsvDate, RsvDoc, RsvType, RsvType1, AssignedUser FROM dbo.Notification
                                       WHERE (RsvAssignUser = " & Usr.PUsrID & ") AND (Phonefailure = 0) AND (RsvType < 2) ORDER BY RsvID", HeldPHTable, "0000&H") = Nothing Then

            GridHeld.DataSource = HeldPHTable
            If GridHeld.SelectedCells.Count > 0 Then
                GridHeld.Rows(0).Selected = True
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
            End If
            LblCnt.Text = "عدد الإخطارات : " & HeldPHTable.Rows.Count
            GridHeld.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
            GridHeld.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
            GridPopulte()
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If

        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        '"SELECT RsvID, RsvTracing, RsvWeight, RsvConsignee, CounNm, RsvMob, RsvAdd, RsvReason, RsvDate, RsvDoc, RsvType, RsvType1, AssignedUser 
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
        GridHeld.Columns(12).HeaderText = "اسم الموظف"

        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        GridHeld.AutoResizeColumns()

        LblMsg.Text = "تم تحميل  " & HeldPHTable.Rows.Count & " بيان"
        LblMsg.ForeColor = Color.Green
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage1" Then

        ElseIf TabControl1.SelectedTab.Name = "TabPage2" Then
            TxtTrck.Text = GridHeld.CurrentRow.Cells("RsvTracing").Value
            TxtDt.Text = GridHeld.CurrentRow.Cells("RsvDate").Value
            TxtPh.Text = GridHeld.CurrentRow.Cells("RsvMob").Value.ToString
            TxtNm.Text = GridHeld.CurrentRow.Cells("RsvConsignee").Value
            TxtAdd.Text = GridHeld.CurrentRow.Cells("RsvAdd").Value
            TxtOrgin.Text = GridHeld.CurrentRow.Cells("CounNm").Value
            If IsDBNull(GridHeld.CurrentRow.Cells("RsvWeight").Value) = False Then TxtWieght.Text = GridHeld.CurrentRow.Cells("RsvWeight").Value
            TxtDoc.Text = GridHeld.CurrentRow.Cells("RsvReason").Value
            TxtReason.Text = GridHeld.CurrentRow.Cells("RsvDoc").Value.ToString
            TabControl1.SelectedTab = TabPage2
            Me.BackColor = Color.White
            Me.TabControl1.TabPages("TabPage2").BackColor = Color.White
            BtnPhNtf.Enabled = True
            BtnPaprNtf.Enabled = True
            BtnSubmt.Enabled = True
            GetUpdtEvent()
            GetNTF()
            TabPage2.Text = "رقم الشحنة : " & GridHeld.CurrentRow.Cells("RsvTracing").Value
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridHeld.DoubleClick
        If GridHeld.Rows.Count > 0 Then
            If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
            TabControl1.SelectedTab = TabPage2
        End If

    End Sub
    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        If TxtUpdt.TextLength > 0 Then
            If InsUpd("insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & TxtUpdt.Text & "','" & OsIP() & "'," & Usr.PUsrID & ")", "1045&H") = Nothing Then
                LblMsg.Text = ("تم إضافة التحديث بنجاح")
                LblMsg.ForeColor = Color.Green
                TxtUpdt.Text = ""
                GetUpdtEvent()
            Else
                MsgErr("كود خطأ : " & "1045&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        Else
            LblMsg.Text = ("برجاء كتابة نص التحديث")
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Private Sub GetUpdtEvent()
        UpdtHeldTbl.Rows.Clear()
        If GetTbl("SELECT RsvRelationID, RsvUpdate_time, RsvUpdateTxt, Int_user.UsrRealNm FROM Int_user INNER JOIN RsvUpdate ON Int_user.Usrid = RsvUpdateUser INNER JOIN Rsv ON RsvRelationID =  dbo.Rsv.RsvID where RsvRelationID = " & GridHeld.CurrentRow.Cells("RsvID").Value & " ORDER BY RsvUpdate_time DESC", UpdtHeldTbl, "1044&H") = Nothing Then
                If UpdtHeldTbl.Rows.Count > 0 Then
                    GridHeldUpdt.DataSource = UpdtHeldTbl
                    GridHeldUpdt.Columns(0).Visible = False
                    GridHeldUpdt.Columns(1).HeaderText = "تاريخ التحديث"
                    GridHeldUpdt.Columns(2).HeaderText = "نص التحديث"
                    GridHeldUpdt.Columns(3).HeaderText = "محرر التحديث"
                    GridHeldUpdt.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GridHeldUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GridHeldUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

                    GridHeldUpdt.AutoResizeColumns()
                    GridHeldUpdt.Columns(2).Width = 400
                    GridHeldUpdt.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    GridHeldUpdt.AutoResizeRows()
                Else
                    LblMsg.Text = ("لا توجد نتيجة للبحث")
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            Else
                MsgErr("كود خطأ : " & "1044&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
    End Sub
    Private Sub GetNTF()
        NTFTbl.Rows.Clear()
        If GetTbl("SELECT RsvAdID, RsvAdReln, RsvAdDate, RsvAdTrk, RsvAdNo, Int_user.UsrRealNm FROM Int_user INNER JOIN RsvAd ON Int_user.Usrid = RsvAdEmpNm where RsvAdReln = " & GridHeld.CurrentRow.Cells("RsvID").Value & " ORDER BY RsvAdID DESC;", NTFTbl, "1044&H") = Nothing Then
            If NTFTbl.Rows.Count > 0 Then
                GridNTF.DataSource = NTFTbl
                GridNTF.Columns(0).Visible = False
                GridNTF.Columns(1).Visible = False
                GridNTF.Columns(2).HeaderText = "تاريخ الإخطار"
                GridNTF.Columns(3).HeaderText = "رقم التتبع"
                GridNTF.Columns(4).HeaderText = "نوع الإخطار"
                GridNTF.Columns(5).HeaderText = "محرر الإخطار"
                GridNTF.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GridNTF.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GridNTF.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

                'GridNTF.AutoResizeColumns()
                'GridNTF.Columns(2).Width = 350
                'GridNTF.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                'GridNTF.AutoResizeRows()
            End If
        Else
            MsgErr("كود خطأ : " & "1044&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs)
        If TxtUpdt.TextLength = 0 Then
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub TxtUpdt_KeyPress(sender As Object, e As KeyPressEventArgs)
        IntUtly.ValdtIntLetter(e)
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridHeld.CurrentCell.Value)
    End Sub
    Private Sub BtnPhNtf_Click(sender As Object, e As EventArgs) Handles BtnPhNtf.Click
        Dim PhnTyp As String = ""
        Dim RsvStr As String = ""
        Dim RsvUpStr As String = ""
        If GridHeld.CurrentRow.Cells(10).Value = 0 Then
            PhnTyp = "Phone1"
            RsvStr = "update rsv set RsvType = 1, RsvPHN = 1, Rsv_ad_Date = (Select GetDate()), Rsv_Days = 0 where Rsv.RsvID = " & GridHeld.CurrentRow.Cells(0).Value
            RsvUpStr = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & "تم عمل الإخطار التليفوني الأول " & "','" & OsIP() & "','" & Usr.PUsrID & "')"
        ElseIf GridHeld.CurrentRow.Cells(10).Value = 1 Then
            PhnTyp = "Phone2"
            RsvStr = "update rsv set RsvType = 2, RsvPHN = 0, Rsv_ad_Date = (Select GetDate()), Rsv_Days = 0 where Rsv.RsvID = " & GridHeld.CurrentRow.Cells(0).Value
            RsvUpStr = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & "تم عمل الإخطار التليفوني الثاني" & "','" & OsIP() & "','" & Usr.PUsrID & "')"
        End If
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon
            sqlComminsert_3.Connection = sqlCon
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_3.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = RsvUpStr
            sqlComminsert_2.CommandText = "insert into RsvAd (RsvAdReln, RsvAdNo, RsvAdEmpNm, RsvType) VALUES (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & PhnTyp & "'," & Usr.PUsrID & ",'" & 0 & "')"
            sqlComminsert_3.CommandText = RsvStr
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Tran.Commit()
            Me.BackColor = Color.LimeGreen
            Me.TabControl1.TabPages("TabPage2").BackColor = Color.LimeGreen
            BtnPhNtf.Enabled = False
            BtnPaprNtf.Enabled = False
            BtnSubmt.Enabled = False
            GetUpdtEvent()
            GetNTF()
            HeldPHTable.Rows.RemoveAt(GridHeld.CurrentRow.Index)
            LblCnt.Text = "عدد الإخطارات : " & HeldPHTable.Rows.Count

            If GridHeld.Rows.Count > 0 Then
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            Else
                LblMsg.Text = ""
            End If
            If GridHeld.Rows.Count = 0 Then
                TabControl1.SelectedTab.Name = "TabPage1"
                TabControl1.TabPages.Remove(TabPage2)
                Me.BackColor = Color.White
            End If
        Catch ex As Exception
            Tran.Rollback()
            AppLog("0000&H", ex.Message, "" & "_" & "")
            WelcomeScreen.TimerCon.Start()
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
        End Try
        'sqlCon.Close()
        'SqlConnection.ClearPool(sqlCon)
    End Sub
    Private Sub BtnPaprNtf_Click(sender As Object, e As EventArgs) Handles BtnPaprNtf.Click
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_2.Connection = sqlCon
            sqlComminsert_3.Connection = sqlCon
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_3.CommandType = CommandType.Text
            sqlComminsert_2.CommandText = "insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES (" & GridHeld.CurrentRow.Cells(0).Value & ",'" & "لم نتمكن من عمل الاخطار التليفوني وتم تحويلها لشاشة الاخطارات الورقية" & "','" & OsIP() & "'," & Usr.PUsrID & ")"
            sqlComminsert_3.CommandText = "update rsv set Phonefailure = 1 where Rsv.RsvID = " & GridHeld.CurrentRow.Cells(0).Value
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Tran.Commit()
            Me.BackColor = Color.Yellow
            Me.TabControl1.TabPages("TabPage2").BackColor = Color.Yellow
            BtnPhNtf.Enabled = False
            BtnPaprNtf.Enabled = False
            BtnSubmt.Enabled = False
            GetUpdtEvent()
            HeldPHTable.Rows.RemoveAt(GridHeld.CurrentRow.Index)
            LblCnt.Text = "عدد الإخطارات : " & HeldPHTable.Rows.Count
            If GridHeld.Rows.Count > 0 Then
                LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            Else
                LblMsg.Text = ""
            End If
            If GridHeld.Rows.Count = 0 Then
                TabControl1.SelectedTab.Name = "TabPage1"
                TabControl1.TabPages.Remove(TabPage2)
                Me.BackColor = Color.White
            End If
        Catch ex As Exception
            Tran.Rollback()
            AppLog("0000&H", ex.Message, "" & "_" & "")
            WelcomeScreen.TimerCon.Start()
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
        End Try
        'sqlCon.Close()
        'SqlConnection.ClearPool(sqlCon)
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs) Handles GridHeld.SelectionChanged
        If GridHeld.SelectedCells.Count > 0 Then
            GridHeld.Rows(0).Selected = True
            LblMsg.Text = GridHeld.CurrentRow.Index + 1 & " Of " & GridHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
        End If
    End Sub
End Class