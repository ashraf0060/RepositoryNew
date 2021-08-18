Imports System.Threading
Public Class HeldSearch
    Dim SerchItmTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
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

        SerchItmTable.Rows.Clear()
        SerchItmTable.Columns.Clear()
        SerchItmTable.Columns.Add("Kind")
        SerchItmTable.Columns.Add("Item")

        SerchItmTable.Rows.Add("Int-RsvTracing", "رقم الشحنة")
        SerchItmTable.Rows.Add("STR-RsvConsignee", "اسم العميل")
        SerchItmTable.Rows.Add("STR-RsvMob", "تليفون العميل")

        FilterComb.DataSource = SerchItmTable
        FilterComb.DisplayMember = "Item"
        FilterComb.ValueMember = "Kind"

        GridHeldUpdt.Columns.Add("م", "م")                                 '0
        GridHeldUpdt.Columns.Add("RsvUpdate_time", "تاريخ التحديث")       '1
        GridHeldUpdt.Columns.Add("RsvUpdateTxt", "نص التحديث")            '2
        GridHeldUpdt.Columns.Add("User_RealName", "محرر التحديث")         '3
        GridHeldUpdt.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub FilterComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComb.SelectedIndexChanged
        If FilterComb.Text = "رقم الشحنة" Then
            FilterComb.MaxLength = 13
        ElseIf FilterComb.Text = "تليفون العميل" Then
            SerchTxt.MaxLength = 11
        Else
            SerchTxt.MaxLength = 50
        End If
        HeldTable.Rows.Clear()
        LblMsg.Text = ""
        SerchTxt.ForeColor = Color.Black
        SerchTxt.Focus()
        SerchTxt.Text = ""
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        HeldTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String
        Dim primaryKey(0) As DataColumn
        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
            If Split(FilterComb.SelectedValue, "-")(0) = "Int" Then
                FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " = '" & SerchTxt.Text & "'"
            Else
                FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " like '" & SerchTxt.Text & "%'"
            End If

            If FltrStr.Length > 0 Then
                FltrStr = " And " & FltrStr
                '   Table                                                                          0        1      2        3          4        5           6          7       8        9        10        11       12       13        14       15      16       17           18      19       20            21         22                23                24                  27                  
                '   GridView                                                                       1        2      3        4          5        6           7          8       9        10        11       12       13        14       15       16      17       18           19      20       21            22         23                24                25                  26                         

                HeldTable.Rows.Clear()
                If GetTbl("SELECT ROW_NUMBER() Over (Order by RsvDate) As [S.N.],  Store_Name, RsvID, RsvNo, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDate, RsvType, RsvType1, RsvDoc, RsvEmpNm, CASE WHEN RsvStr > 5 THEN 'رمسيس' ELSE 'مطار القاهرة'END As Location, CASE WHEN RsvPHN = 1 THEN N'✔' ELSE '' END As RsvPHN, CASE WHEN RsvRec = 1 THEN N'✔' ELSE '' END As RsvRec, CASE WHEN RsvPrintPaper = 1 THEN N'✔' ELSE '' END As RsvPrintPaper, CASE WHEN RsvOut = 1 THEN N'✘' ELSE '' END As RsvOut,Phonefailure, RsvStart, Rsv_ad_Date, Rsv_Days, MONTH(RsvDate) AS Month, YEAR(RsvDate) AS Year,(select UsrRealNm from Int_user where UsrId = rsv.RsvAssignUser) As [موظف الإخطار التليفوني] FROM Rsv INNER JOIN Int_user ON RsvEmpNm = Usrid INNER JOIN CDCountry ON RsvOrgin = CDCountry.CounCd INNER JOIN Stores ON RsvStr = Store_No WHERE (YEAR(RsvDate) > 2018)" & FltrStr & " ORDER BY RsvDate", HeldTable, "1043&H") = Nothing Then
                    primaryKey(0) = HeldTable.Columns("RsvID")
                    HeldTable.PrimaryKey = primaryKey
                    If HeldTable.Rows.Count > 0 Then
                        GridHeld.DataSource = HeldTable
                        GridPopulte()
                    Else
                        LblMsg.Text = ("لا توجد نتيجة للبحث")
                        LblMsg.ForeColor = Color.Red
                        Beep()
                    End If
                Else
                    MsgErr("كود خطأ : " & "1043&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                    Beep()
                End If
            Else
                LblMsg.Text = ("برجاء ادخال كلمات البحث")
                LblMsg.ForeColor = Color.Red
                Beep()
            End If
        Else
            LblMsg.Text = ("برجاء ادخال كلمات البحث")
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green
        GridHeld.Columns(0).HeaderText = "م"
        GridHeld.Columns(1).HeaderText = "اسم القسم"
        GridHeld.Columns(2).Visible = False
        GridHeld.Columns(3).Visible = False
        GridHeld.Columns(4).HeaderText = "رقم الشحنة"
        GridHeld.Columns(5).HeaderText = "بلد المنشأ"
        GridHeld.Columns(6).Visible = False
        GridHeld.Columns(7).HeaderText = "اسم العميل"
        GridHeld.Columns(8).Visible = False
        GridHeld.Columns(9).HeaderText = "رقم الموبايل"
        GridHeld.Columns(10).Visible = False
        GridHeld.Columns(11).HeaderText = "تاريخ الحجز"
        GridHeld.Columns(12).Visible = False
        GridHeld.Columns(13).HeaderText = "حالة الشحنة"
        GridHeld.Columns(14).Visible = False
        GridHeld.Columns(15).Visible = False
        GridHeld.Columns(16).HeaderText = "موقع الحجز"
        GridHeld.Columns(17).HeaderText = "اخطار تليفوني"
        GridHeld.Columns(18).HeaderText = "استلام الأوراق"
        GridHeld.Columns(19).HeaderText = "طباعة الأوراق"
        GridHeld.Columns(20).HeaderText = "استبعاد"
        GridHeld.Columns(21).Visible = False
        GridHeld.Columns(22).Visible = False
        GridHeld.Columns(23).Visible = False
        GridHeld.Columns(24).Visible = False
        GridHeld.Columns(25).Visible = False
        GridHeld.Columns(26).Visible = False

        GridHeld.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(17).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(17).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(18).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(18).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(19).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(19).DefaultCellStyle.ForeColor = Color.Green
        GridHeld.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.Columns(20).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeld.Columns(20).DefaultCellStyle.ForeColor = Color.Red

        GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        GridHeld.Columns(0).Width = 50
        GridHeld.Columns(1).Width = 70
        GridHeld.Columns(4).Width = 130
        GridHeld.Columns(7).Width = 200
        GridHeld.Columns(9).Width = 100
        GridHeld.Columns(11).Width = 120
        GridHeld.Columns(16).Width = 90
        GridHeld.Columns(17).Width = 50
        GridHeld.Columns(18).Width = 50
        GridHeld.Columns(19).Width = 50
        GridHeld.Columns(20).Width = 50
        LblMsg.Text = "تم تحميل  " & HeldTable.Rows.Count & " بيان"
        LblMsg.ForeColor = Color.Green
    End Sub
    Private Sub SerchTxt_Enter(sender As Object, e As EventArgs) Handles SerchTxt.Enter
        If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
            SerchTxt.Text = ""
            SerchTxt.ForeColor = Color.Black
        End If
    End Sub
    Private Sub SerchTxt_Leave(sender As Object, e As EventArgs) Handles SerchTxt.Leave, MyBase.Load
        If SerchTxt.TextLength = 0 Then
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridHeld.DoubleClick
        If TabControl1.TabPages.Contains(TabPage2) = False Then TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub BckBtn2_Click(sender As Object, e As EventArgs) Handles Btn2Bck.Click
        TabControl1.SelectedTab = TabPage1
        For Each c As Control In TabPage2.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub
    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        If TxtUpdt.TextLength > 0 Then
            If InsUpd("insert into RsvUpdate (RsvRelationID, RsvUpdateTxt, User_IP, RsvUpdateUser) VALUES ('" & GridHeld.CurrentRow.Cells(2).Value & "','" & TxtUpdt.Text & "','" & OsIP() & "'," & Usr.PUsrID & ")", "1045&H") = Nothing Then
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
        If GetTbl("SELECT RsvRelationID, RsvUpdate_time,CASE WHEN (select MAX( DISTINCT RsvAdTrk) from RsvAd where  (RsvType = 1) AND (RsvAdTrk IS NOT NULL) AND (RsvAdReln = RsvRelationID) AND (format(RsvUpdate_time,'yyyy/MM/dd') = format(RsvAdDate,'yyyy/MM/dd'))) IS NULL THEN RsvUpdateTxt ELSE
RsvUpdateTxt + ' _ ' + (select MAX( DISTINCT RsvAdTrk) from RsvAd where  (RsvType = 1) AND (RsvAdTrk IS NOT NULL) AND (RsvAdReln = RsvRelationID) AND (format(RsvUpdate_time,'yyyy/MM/dd') = format(RsvAdDate,'yyyy/MM/dd'))) END, Int_user.UsrRealNm,(select MAX( DISTINCT RsvAdTrk) from RsvAd where  (RsvType = 1) AND (RsvAdTrk IS NOT NULL) AND (RsvAdReln = RsvRelationID) AND (format(RsvUpdate_time,'yyyy/MM/dd') = format(RsvAdDate,'yyyy/MM/dd'))) AS tRACK FROM Int_user INNER JOIN RsvUpdate ON Int_user.Usrid = RsvUpdateUser INNER JOIN Rsv ON RsvRelationID =  dbo.Rsv.RsvID where RsvRelationID = " & GridHeld.CurrentRow.Cells(2).Value & " ORDER BY RsvUpdate_time DESC", UpdtHeldTbl, "1044&H") = Nothing Then
            If UpdtHeldTbl.Rows.Count > 0 Then
                GridHeldUpdt.Rows.Clear()
                For Cnt_ = 0 To UpdtHeldTbl.Rows.Count - 1
                    GridHeldUpdt.Rows.Add()
                    GridHeldUpdt.Rows(Cnt_).Cells(0).Value = Cnt_ + 1
                    GridHeldUpdt.Rows(Cnt_).Cells(1).Value = UpdtHeldTbl(Cnt_).Item(1).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(2).Value = UpdtHeldTbl(Cnt_).Item(2).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(3).Value = UpdtHeldTbl(Cnt_).Item(3).ToString
                Next
                GridHeldUpdt.AutoResizeColumns()
                GridHeldUpdt.Columns(2).Width = 350
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
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs)
        If TxtUpdt.TextLength = 0 Then
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage1" Then
            If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
                SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
            End If
        ElseIf TabControl1.SelectedTab.Name = "TabPage2" Then
            TxtTrck.Text = GridHeld.CurrentRow.Cells(4).Value
            TxtDt.Text = GridHeld.CurrentRow.Cells(11).Value
            TxtPh.Text = GridHeld.CurrentRow.Cells(9).Value.ToString
            TxtNm.Text = GridHeld.CurrentRow.Cells(7).Value
            TxtAdd.Text = GridHeld.CurrentRow.Cells(8).Value
            TxtOrgin.Text = GridHeld.CurrentRow.Cells(5).Value
            If IsDBNull(GridHeld.CurrentRow.Cells(6).Value) = False Then TxtWieght.Text = GridHeld.CurrentRow.Cells(6).Value
            TxtDoc.Text = GridHeld.CurrentRow.Cells(10).Value
            TxtReason.Text = GridHeld.CurrentRow.Cells(14).Value.ToString
            GetUpdtEvent()
            TabPage2.Text = "رقم الشحنة : " & GridHeld.CurrentRow.Cells(4).Value
        End If
    End Sub
    Private Sub TxtUpdt_KeyPress(sender As Object, e As KeyPressEventArgs)
        IntUtly.ValdtIntLetter(e)
    End Sub
    Private Sub BtnSerch_Click(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Filtr()
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs)
        HeldTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Clipboard.SetText(GridHeld.CurrentCell.Value)
    End Sub
End Class