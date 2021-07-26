Imports System.Threading
Imports ClosedXML.Excel

Public Class ExportAshraf
    'Dim CompTable As DataTable = New DataTable
    'Dim ProdTable As DataTable = New DataTable
    'Dim ProdKTable As DataTable = New DataTable
    Dim ExtTable As New DataTable
    Dim dataSet_ As New DataSetRep
    Dim dataSet_1 As New DataSetRepVisible
    Dim datasource As ReportDataSource
    Dim datasource1 As ReportDataSource
    Dim GridTicket As New DataGridView
    Dim SndMailTsk As Thread
    Dim RwSped As Double
    Dim Prv As Form
    Dim D As SaveFileDialog
    Dim slctStr As String = ""
    Private Sub ExportAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SndMailTsk = New Thread(AddressOf LoadSub)
        SndMailTsk.IsBackground = True
        SndMailTsk.Start()
    End Sub
    Private Sub LoadSub()
        Invoke(Sub()
                   If PreciFlag = False Then
                       Me.Close()
                       Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات")
                       Beep()
                   Else
                       TreeView1.Visible = False
                       RsetTree.Visible = False
                       UserTree.Visible = False
                       RstUer.Visible = False
                       BtnSub(Me)
                       Me.Enabled = False
                       Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات .........................")
                       Invoke(Sub() DateTimeFrom.Value = CStr(Format(Today, "yyyy/MM/dd")))
                       Invoke(Sub() DateTimeTo.Value = CStr(Format(Today, "yyyy/MM/dd")))
PopulUserTree_:
                       'If UserTree.Nodes.Count = 1 Or UserTree.Nodes.Count = Nothing Then
                       Dim Rooot As String = ""
                       Dim Chiild1 As String = ""
                       UserTree.ImageList = ImgLst
                       ' Populate Main Root
                       UserTree.Nodes.Clear()
                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                       GetTbl("SELECT IntUserCatLvCD.CatLvId, IntUserCatLvCD.CatLvNm FROM IntUserCatLvCD WHERE (((IntUserCatLvCD.CatLvNm)='مشرف خطوط خلفيه') OR (((IntUserCatLvCD.CatLvNm)='موظف خطوط خلفيه')) OR (((IntUserCatLvCD.CatLvNm)='خطوط خلفيه مركز الاتصال')))  ORDER BY CatLvNm", tempTable, "0000&H")
                       For Cnt_ = 0 To tempTable.Rows.Count - 1
                           UserTree.Nodes.Add(tempTable.Rows(Cnt_).Item(0).ToString, tempTable.Rows(Cnt_).Item(1).ToString, 1, 3)
                       Next

                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                       GetTbl("SELECT  Int_user.UsrId, IntUserCat.UCatId, IntUserCat.UCatIdSub, CASE WHEN Int_user.UsrRealNm IS NOT NULL THEN IntUserCat.UCatNm + N'-' + Int_user.UsrRealNm ELSE IntUserCat.UCatNm + N'-' END AS UsrMix, IntUserCatLvCD.CatLvId FROM IntUserCatLvCD INNER JOIN IntUserCat ON IntUserCatLvCD.CatLvId = IntUserCat.UCatLvl LEFT OUTER JOIN Int_user ON IntUserCat.UCatId = Int_user.UsrCat WHERE (Int_user.UsrSusp = 0) AND (IntUserCat.UCatLvl <> 0) AND (IntUserCatLvCD.CatLvId = 3 OR IntUserCatLvCD.CatLvId = 4 OR IntUserCatLvCD.CatLvId = 5) ORDER BY IntUserCat.UCatIdSub, Int_user.UsrId", tempTable, "0000&H")

                       'Populate Products Nodes
                       For Cnt_ = 0 To tempTable.Rows.Count - 1
                           For Each n As TreeNode In Me.UserTree.Nodes
                               If n.Name = tempTable.Rows(Cnt_).Item(4).ToString Then
                                   UserTree.SelectedNode = n
                                   UserTree.SelectedNode.Nodes.Add(tempTable.Rows(Cnt_).Item(2).ToString(), tempTable.Rows(Cnt_).Item(3).ToString(), 1, 3)
                               End If
                           Next
                           'If Chiild1 <> tempTable.Rows(Cnt_).Item(4).ToString Then
                           '    UserTree.SelectedNode.Nodes.Add(tempTable.Rows(Cnt_).Item(2).ToString(), tempTable.Rows(Cnt_).Item(3).ToString(), 1, 3)
                           'End If
                           'Chiild1 = tempTable.Rows(Cnt_).Item(4).ToString
                       Next
                       UserTree.SelectedNode = Nothing
PopulCompTree_:
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
                           TreeView1.SelectedNode = Nothing
                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                           GetTbl("select ExpStr from ALib", tempTable, "0000&H")

                           slctStr = tempTable.Rows(0).Item("ExpStr")
#Region "AAA"
                       'For Cnt_ = 0 To Split(slctStr, ",").Count - 1
                       '    Dim newCB As New CheckBox

                       '    newCB.Name = Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(0))
                       '    newCB.Text = Mid(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1)), 2, Len(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1))) - 2)
                       '    newCB.Visible = False
                       '    Me.Controls.Add(newCB)
                       '    newCB.Font = New Font("Times New Roman", 11, FontStyle.Bold)
                       '    newCB.TextAlign = ContentAlignment.BottomLeft
                       '    newCB.Appearance = Appearance.Button
                       '    newCB.BackColor = Color.Aqua

                       'tempTable.Rows.Clear()
                       'tempTable.Columns.Clear()
                       'GetTbl("select UsrExpCompStr from Int_user where UsrId = " & Usr.PUsrID, tempTable, "0000&H")
                       'If tempTable.Rows(0).Item("UsrExpCompStr").ToString.Length > 0 Then
                       '    For cnt = 0 To Split(tempTable.Rows(0).Item("UsrExpCompStr"), ",").Count - 1
                       '        If Trim(Split(tempTable.Rows(0).Item("UsrExpCompStr"), ",")(cnt)) = newCB.Name Then
                       '            newCB.Checked = True
                       '            newCB.BackColor = Color.LimeGreen
                       '            Exit For
                       '        End If
                       '    Next cnt
                       'End If

                       'AddHandler newCB.Click, AddressOf HandleChekedClick

                       '    If Cnt_ = 0 Then
                       '        Temp = newCB
                       '        Temp.Location = New Point(20, -5)
                       '    End If

                       '    If Temp.Location.Y > 350 Then
                       '        X += 130
                       '        Y = 0
                       '        newCB.Size = New Point(120, 35)
                       '        newCB.Location = New Point(X, Y + 30)
                       '        newCB.TextAlign = ContentAlignment.MiddleLeft
                       '    Else
                       '        X = Temp.Location.X
                       '        Y = Temp.Location.Y
                       '        newCB.Size = New Point(120, 35)
                       '        newCB.Location = New Point(X, Y + 35)
                       '        newCB.TextAlign = ContentAlignment.MiddleLeft
                       '    End If
                       '    Temp = newCB
                       '    newCB.Visible = True
                       '    Me.Refresh()
                       '    Label7.Location = New Point(X + 200, 150)

                       'Next
#End Region
                       For Cnt_ = 0 To Split(slctStr, ",").Count - 1
                           Dim Val As New CheckBox
                           Val.Size = New Point(120, 25)
                           Val.Text = Mid(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1)), 2, Len(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1))) - 2)
                           Val.Name = Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(0)).ToString
                           Me.FlowLayoutPanel1.Controls.Add(Val)
                           AddHandler Val.Click, AddressOf HandleChekedClick
                           Val.Appearance = Appearance.Button
                           Val.Font = New Font("Times New Roman", 11, FontStyle.Bold)
                           Val.TextAlign = ContentAlignment.MiddleCenter
                           Val.Appearance = Appearance.Button
                           Val.BackColor = Color.Aqua
                       Next

                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                       Dim UsrStrTbl As New DataTable
                       GetTbl("select UsrExpCompStr from Int_user where UsrId = " & Usr.PUsrID, UsrStrTbl, "0000&H")

                       For Each c As CheckBox In Me.FlowLayoutPanel1.Controls
                           For cnt = 0 To Split(UsrStrTbl.Rows(0).Item("UsrExpCompStr"), ",").Count - 1
                               If Trim(Split(UsrStrTbl.Rows(0).Item("UsrExpCompStr"), ",")(cnt)) = c.Name Then
                                   c.Checked = True
                                   c.BackColor = Color.LimeGreen
                                   Exit For
                               End If
                           Next
                       Next
                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                           If GetTbl("SELECT MIN(TkDtStart) AS MinDt FROM Tickets", tempTable, "0000&H") = Nothing Then
                               Invoke(Sub() DateTimeFrom.MinDate = tempTable.Rows(0).Item(0))
                               Invoke(Sub() DateTimeTo.MinDate = tempTable.Rows(0).Item(0))
                               tempTable.Rows.Clear()
                               tempTable.Columns.Clear()
                               If GetTbl("SELECT Max(TkDtStart) AS MinDt FROM Tickets", tempTable, "0000&H") = Nothing Then
                                   Invoke(Sub() DateTimeFrom.MaxDate = tempTable.Rows(0).Item(0))
                                   Invoke(Sub() DateTimeTo.MaxDate = tempTable.Rows(0).Item(0))
                               End If
                           End If
                           Me.Enabled = True
                           TreeView1.Visible = True
                           RsetTree.Visible = True
                           UserTree.Visible = True
                           RstUer.Visible = True
                           Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
                       End If
               End Sub)
        GC.Collect()
    End Sub
    Private Sub HandleChekedClick(sender As Object, e As EventArgs) Handles ChckBxDate.Click
        For Each c In Me.FlowLayoutPanel1.Controls
            If TypeOf c Is CheckBox Then
                If c.Checked = True Then
                    c.BackColor = Color.LimeGreen
                Else
                    c.BackColor = Color.Aqua
                End If
            End If
        Next
    End Sub
    Public Sub ExpThread()
        ExpSub()
        ExpDTable.Rows.Clear()
        ExpDTable.Columns.Clear()
        GetTbl(ExpStr, ExpDTable, "0000&H")
        DataExp("ComplaintReport")
    End Sub
    Private Sub BtnPrv_Click(sender As Object, e As EventArgs) Handles BtnPrv.Click

        If Mid(Usr.PUsrLvl, 43, 1) <> "A" Then
            If Math.Abs(DateTime.Parse(Format(DateTimeFrom.Value, "yyyy/MM/dd")).Subtract(DateTime.Parse(Format(DateTimeTo.Value, "yyyy/MM/dd"))).TotalDays) >= 31 And ChckBxDate.Checked = False Then
                MsgInf("أقصى مدة لإستخراج البيانات هي 31 يوم" & vbCrLf & "برجاء تقليل المدة من " & Math.Abs(DateTime.Parse(Format(DateTimeFrom.Value, "yyyy/MM/dd")).Subtract(DateTime.Parse(Format(DateTimeTo.Value, "yyyy/MM/dd"))).TotalDays) & " للمدة المطلوبه")
            Else
                'SndMailTsk = New Thread(AddressOf ExpSub)
                'SndMailTsk.IsBackground = True
                'SndMailTsk.Start()
                ExpSub()
            End If
        Else
            'SndMailTsk = New Thread(AddressOf ExpSub)
            'SndMailTsk.IsBackground = True
            'SndMailTsk.Start()
            ExpSub()
        End If
    End Sub
    Private Sub ExpSub()
        Dim SQLTblAdptr3 As New SqlDataAdapter

        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ....."
        Dim CollctStr As String = ""
        Dim UserStr As String = ""
        Dim TruFlse As String = ""
        For Each c In Me.FlowLayoutPanel1.Controls
            If c.Checked = True Then
                UserStr &= c.name & ", "
                CollctStr &= c.name & " As [" & c.text & "]" & ", "
            End If
        Next
        If CollctStr.Length = 0 Then
            WelcomeScreen.StatBrPnlAr.Text = ""
            Exit Sub
        End If

        Dim CollectStr As String = "Select " & Mid(CollctStr, 1, Len(CollctStr) - 2) & " From ExportRep2"
        Dim Mytem As String = ""

        If Mid(Usr.PUsrLvl, 42, 1) = "A" Then

        Else
            If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                Mytem = " And "
                Mytem += MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm")
            Else
                Mytem = " And "
                Mytem += MyTeam(Usr.PUsrCat, Usr.PUsrID, "TkEmpNm0")
            End If
        End If


        Dim str As String = ""

        If ChckBxDate.Checked = False Then
            If str.Length > 0 Then str &= " And "
            Dim DT As String = ""
            If RadRcv.Checked = True Then
                DT = "TkDtStart"
            ElseIf RadTrnsf.Checked = True Then
                DT = "TkRecieveDt"
            ElseIf RadClos.Checked = True Then
                DT = "TkDtClose"
            ElseIf Radtrans.Checked = True Then
                DT = "TransDate"
            End If
            str = "CONVERT(date, " & DT & ",111) BETWEEN CONVERT(date, '" & Format(DateTimeFrom.Value, "yyyy/MM/dd") & "', 111) AND  CONVERT(date, '" & Format(DateTimeTo.Value, "yyyy/MM/dd") & "', 111)"
        End If

        If RdioOpen.Checked = True Or Rdiocls.Checked = True Then
            If str.Length > 0 Then str &= " And "
        End If
        If RdioOpen.Checked = True Then
            str &= "[CompStat]" & " = '" & "مفتوحه" & "'"
        ElseIf Rdiocls.Checked = True Then
            str &= "[CompStat]" & " = '" & "مغلقة" & "'"
        ElseIf RdioTikAll.Checked = True Then
            str &= ""
        End If

        If RdioFlwY.Checked = True Or RdioFlwN.Checked = True Then
            If str.Length > 0 Then str &= " And "
        End If
        If RdioFlwY.Checked = True Then
            str &= "[FlwStat]" & " = '" & "نعم" & "'"
        ElseIf RdioFlwN.Checked = True Then
            str &= "[FlwStat]" & " = '" & "لا" & "'"
        ElseIf RdioFlwAll.Checked = True Then
            str &= ""
        End If

        If IsNothing(TreeView1.SelectedNode) = False Then
            If TreeView1.SelectedNode.Level = 0 Then
                str &= " And "
                str &= "[ProdKNm]" & " = '" & TreeView1.SelectedNode.Text & "'"
            Else
                str &= ""
            End If
            If TreeView1.SelectedNode.Level = 1 Then
                str &= " And "
                str &= "[PrdNm]" & " = '" & TreeView1.SelectedNode.Text & "'"
            Else
                str &= ""
            End If
            If TreeView1.SelectedNode.Level = 2 Then
                str &= " And "
                str &= "[CompNm]" & " = '" & TreeView1.SelectedNode.Text & "'"
            Else
                str &= ""
            End If
        End If

        'If IsNothing(UserTree.SelectedNode) = False Then

        Dim UsrSTR As String = ""
        For Each n As TreeNode In Me.UserTree.Nodes
            If n.Checked = True Then
                UsrSTR &= "[UsrType]" & " = '" & n.Text & "' Or "
            Else
                UsrSTR &= ""
            End If
            If n.Nodes.Count > 0 Then
                For dd = 0 To n.Nodes.Count - 1
                    If n.Nodes(dd).Checked = True Then
                        UsrSTR &= "[UsrRealNm]" & " = '" & Trim(Split(n.Nodes(dd).Text, "-")(1)) & "' Or "
                    Else
                        UsrSTR &= ""
                    End If
                Next
            End If

        Next

        If UsrSTR.Length > 0 Then UsrSTR = "And (" & Mid(UsrSTR, 1, Len(UsrSTR) - 4) & ")"

        InsUpd("update Int_user set UsrExpCompStr = '" & Mid(UserStr, 1, Len(UserStr) - 2) & "' where UsrId = " & Usr.PUsrID, "0000&H")
        sqlComm.CommandTimeout = 90
        ExpStr = " where " & str & Mytem
        ExpDTable.Rows.Clear()
        ExpDTable.Columns.Clear()

        If GetTbl(CollectStr & ExpStr & UsrSTR & " order by TkID", ExpDTable, "0000&H") = Nothing Then
            WelcomeScreen.StatBrPnlAr.Text = ""
            PrvForm()
        Else
            MsgInf("Err" & vbCrLf & "برجاء إعادة تشغيل التطبيق مرة أخرى")
        End If

    End Sub
    Private Sub ChckBxDate_Click(sender As Object, e As EventArgs) Handles ChckBxDate.Click
        If ChckBxDate.Checked = True Then
            RdioOpen.Checked = True
            GroupBox1.Visible = False
            Rdiocls.Enabled = False
            RdioTikAll.Enabled = False
            GrpDtKnd.Visible = False
        Else
            GroupBox1.Visible = True
            Rdiocls.Enabled = True
            RdioTikAll.Enabled = True
            RdioTikAll.Checked = True
            GrpDtKnd.Visible = True
        End If
    End Sub
    Private Sub PrvForm()
        Dim Btn As New Button
        Prv = New Form

        GridTicket = New DataGridView
        Prv.Controls.Add(GridTicket)
        GridTicket.Location = New Point(0, 40)
        GridTicket.ReadOnly = True
        GridTicket.AllowUserToAddRows = False
        Prv.Controls.Add(Btn)

        Btn.Location = New Point(150, 5)
        Btn.FlatStyle = FlatStyle.Flat
        Btn.BackgroundImage = My.Resources.Export1
        Btn.BackColor = Color.Transparent
        Btn.BackgroundImageLayout = ImageLayout.Stretch
        Btn.FlatAppearance.BorderSize = 0
        Btn.Size = New Point(30, 30)

        AddHandler Btn.Click, AddressOf Btn_Click
        Prv.Text = "معاينة استخراج البيانات" & " - " & "عدد الشكاوى : " & ExpDTable.Rows.Count.ToString("N0") & " - " & "عدد الأعمده : " & ExpDTable.Columns.Count.ToString("N0")

        GridTicket.DataSource = ExpDTable

        'Grdview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'Grdview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        'Grdview.BackgroundColor = Color.White
        'Grdview.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText



        Prv.WindowState = FormWindowState.Maximized
        Prv.RightToLeftLayout = True
        Prv.RightToLeft = RightToLeft.Yes
        Prv.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 100)
        Prv.StartPosition = FormStartPosition.CenterScreen
        GridTicket.Dock = DockStyle.Bottom
        GridTicket.Size = New Point(Prv.Width - 20, Screen.PrimaryScreen.Bounds.Height - 100)
        BtnSub(Prv)
        Prv.ShowDialog()
    End Sub
    Private Sub Btn_Click(sender As Object, e As EventArgs)
        D = New SaveFileDialog
        With D
            .Title = "Save Excel File"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Filter = "Excel File|*.xlsx"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        D.FileName = "ComplaintsReport" '& GroupBox1.Tag & GroupBox2.Tag & GroupBox3.Tag & GrpDtKnd.Tag
        If D.ShowDialog() = DialogResult.OK Then
            LoadFrm("جاري استخراج البيانات ...", (screenWidth - LodngFrm.Width) / 2, (screenHeight - LodngFrm.Height) / 2)
            Try
                'ExpDTable.Rows.Add("")
                Dim Workbook As XLWorkbook = New XLWorkbook()
                Workbook.Worksheets.Add(ExpDTable, "ComplaintsReport")
                Workbook.SaveAs(D.FileName)
                Invoke(Sub() LodngFrm.Close())
                MsgInf("Done")
            Catch ex As Exception
                Invoke(Sub() LodngFrm.Close())
                MsgInf(ex.Message)
            End Try
        End If
    End Sub
    Private Sub PrivExp(sQlfLNm As String)
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه

        Distin = Split(D.FileName, ".")(0) & Format(ServrTime(), "yyyy-MM-dd_HH_mm") & ".xlsx"
        Try                                                                                                       'Try If there is available Connection
            If ExpDTable.Rows.Count > 0 Then

#Region "Change Columns Names"
                ExpDTable.Columns(0).ColumnName = "شكوى / استفسار"
                ExpDTable.Columns(1).ColumnName = "رقم الشكوى"
                ExpDTable.Columns(2).ColumnName = "تاريخ الشكوى"
                ExpDTable.Columns(3).ColumnName = "تاريخ الإغلاق"
                ExpDTable.Columns(4).ColumnName = "مدة الإغلاق"
                ExpDTable.Columns(5).ColumnName = "مصدر الشكوى"
                ExpDTable.Columns(6).ColumnName = "اسم العميل"
                ExpDTable.Columns(7).ColumnName = "رقم التليفون1"
                ExpDTable.Columns(8).ColumnName = "رقم التليفون2"
                ExpDTable.Columns(9).ColumnName = "البريد الإلكتروني"
                ExpDTable.Columns(10).ColumnName = "العنوان"
                ExpDTable.Columns(11).ColumnName = "الرقم القومي"
                ExpDTable.Columns(12).ColumnName = "رقم الشحنة"
                ExpDTable.Columns(13).ColumnName = "رقم أمر الدفع"
                ExpDTable.Columns(14).ColumnName = "رقم الكارت"
                ExpDTable.Columns(15).ColumnName = "مبلغ العملية"
                ExpDTable.Columns(16).ColumnName = "تاريخ العملية"
                ExpDTable.Columns(17).ColumnName = "نوع الخدمة"
                ExpDTable.Columns(18).ColumnName = "اسم المنتج"
                ExpDTable.Columns(19).ColumnName = "نوع الشكوى"
                ExpDTable.Columns(20).ColumnName = "بلد الراسل"
                ExpDTable.Columns(21).ColumnName = "بلد المرسل إلية"
                ExpDTable.Columns(22).ColumnName = "اسم المكتب"
                ExpDTable.Columns(23).ColumnName = "المنطقة"
                ExpDTable.Columns(24).ColumnName = "تفاصيل الشكوى"
                ExpDTable.Columns(25).ColumnName = "حالة الشكوى"
                ExpDTable.Columns(26).ColumnName = "حالة المتابعة"
                ExpDTable.Columns(27).ColumnName = "محرر الشكوى"
                ExpDTable.Columns(28).ColumnName = "Team Leader"
                ExpDTable.Columns(29).ColumnName = "متابع الشكوى"
                ExpDTable.Columns(30).ColumnName = "المجموعة"
                ExpDTable.Columns(31).ColumnName = "معادة الفتح"
                ExpDTable.Columns(32).ColumnName = "تاريخ استلام الشكوى"
                ExpDTable.Columns(33).ColumnName = "مدة التوزيع"
                ExpDTable.Columns(34).ColumnName = "مدة الاستلام"
                ExpDTable.Columns(35).ColumnName = "RecievedRange"
                ExpDTable.Columns(36).ColumnName = "كود متابع الشكوى"
                ExpDTable.Columns(37).ColumnName = "كود محرر الشكوى"
                ExpDTable.Columns(38).ColumnName = "تاريخ آخر تحديث"
                ExpDTable.Columns(39).ColumnName = "نص التحديث"
                ExpDTable.Columns(40).ColumnName = "محرر التحديث"
                ExpDTable.Columns(41).ColumnName = "طبيعة محرر التحديث"

#End Region

                WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & ExpDTable.Rows.Count & " بيان"
                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")

                XLWrkBk.Title = ("VOCA Plus Auto Exported Data")
                XLWrkBk.Subject = ("Export Screen")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")

                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus"
                XLWrkSht.Cells(2, 1) = "Ashraf Farag"
                XLWrkSht.Cells(3, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Rows("1:3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                XLWrkSht.Rows("1:3").Font.FontStyle = "Bold"
                XLWrkSht.Rows("1:1").font.color = Color.Red
                XLWrkSht.Rows("1:3").Font.Size = 12
                XLWrkSht.Rows("1:1").Font.Name = "Times New Roman"
                XLWrkSht.Rows("2:2").Font.Name = "Lucida Handwriting"
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Font.Color = Color.Black
                'Set Merge Signature Cells
                XLWrkSht.Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(1, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(3, 1), XLWrkSht.Cells(3, ExpDTable.Columns.Count)).Merge()

                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"

                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" '"dd/mm/yyyy" 'Date Columns
                    ElseIf ExpDTable.Columns(Col).ToString.Contains("تليفون") Or ExpDTable.Columns(Col).ToString.Contains("Phone") Or ExpDTable.Columns(Col).ToString.Contains("كارت") Or ExpDTable.Columns(Col).ToString.Contains("قومي") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" 'Date Columns
                    End If
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    'Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & Rws + 1 & " من " & ExpDTable.Rows.Count)
                    'GC.Collect()
                    'FlushMemory()
                Next Rws
                With XLWrkSht
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Color = Color.Black
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).WrapText = False
                    .Cells.Columns.AutoFit()
                    .Columns("Y").ColumnWidth = 30
                    .Columns("AN").ColumnWidth = 30
                    '.Cells.EntireColumn.AutoFit()
                End With

                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
                WelcomeScreen.StatBrPnlAr.Text = "تم استخراج عدد " & ExpDTable.Rows.Count & " بيان إلى MyDocuments"
            Else
                WelcomeScreen.StatBrPnlAr.Text = "لا توجد بيانات لإستخراجها في المدة المحددة"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo End_
        End Try

        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        FlushMemory()
        Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
End_:

    End Sub
    Private Sub ExportAdmin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SndMailTsk.IsAlive = True Then
            MsgInf("لا يمكن إغلاق الشاشة حتى الإنتهاء من استخراج البيانات" & vbNewLine & "يمكنك فتح شاشة أخرى من أسفل الشاشة")
            e.Cancel = True
        End If
    End Sub
    Private Sub RsetTree_Click(sender As Object, e As EventArgs) Handles RsetTree.Click
        TreeView1.SelectedNode = Nothing
        TreeView1.CollapseAll()
    End Sub
    Private Sub RstUer_Click(sender As Object, e As EventArgs) Handles RstUer.Click
        UserTree.SelectedNode = Nothing
        UserTree.CollapseAll()
    End Sub

End Class