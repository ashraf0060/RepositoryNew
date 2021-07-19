Imports System.Threading
Public Class ExportAdmin
    Dim CompTable As DataTable = New DataTable
    Dim ProdTable As DataTable = New DataTable
    Dim ProdKTable As DataTable = New DataTable
    Dim ExtTable As New DataTable
    Dim dataSet_ As New DataSetRep
    Dim dataSet_1 As New DataSetRepVisible
    Dim datasource As ReportDataSource
    Dim datasource1 As ReportDataSource
    Dim ddd As New ReportViewer
    Dim Combo As New ComboBox
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
                       BtnSub(Me)
                       Me.Enabled = False
                       Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات .........................")
                       Invoke(Sub() DateTimeFrom.Value = CStr(Format(Today, "yyyy/MM/dd")))
                       Invoke(Sub() DateTimeTo.Value = CStr(Format(Today, "yyyy/MM/dd")))

                       GetTbl("select ProdKNm from CDProdK where ProdKSusp = 0", ProdKTable, "0000&H")
                       Invoke(Sub() PrdKComb.DataSource = ProdKTable)
                       Invoke(Sub() PrdKComb.ValueMember = "ProdKNm")
                       Invoke(Sub() PrdKComb.DisplayMember = "ProdKNm")
                       Invoke(Sub() PrdKComb.ResetText())


                       GetTbl("select CompCd, CompNm from CDComp where CompSusp = 0 order by CompNm", CompTable, "0000&H")
                       Invoke(Sub() CombComp.DataSource = CompTable)
                       Invoke(Sub() CombComp.ValueMember = "CompCd")
                       Invoke(Sub() CombComp.DisplayMember = "CompNm")
                       Invoke(Sub() CombComp.ResetText())

                       GetTbl("select PrdCd, PrdNm from CDProd where PrdSusp = 0 order by PrdNm", ProdTable, "0000&H")
                       Invoke(Sub() CombProd.DataSource = ProdTable)
                       Invoke(Sub() CombProd.ValueMember = "PrdCd")
                       Invoke(Sub() CombProd.DisplayMember = "PrdNm")
                       Invoke(Sub() CombProd.ResetText())
                       Me.Refresh()
                       Dim Temp As Control
                       Dim X As Integer = 0
                       Dim Y As Integer = 0
                       tempTable.Rows.Clear()
                       tempTable.Columns.Clear()
                       GetTbl("select ExpStr from ALib", tempTable, "0000&H")

                       slctStr = tempTable.Rows(0).Item("ExpStr")

                       For Cnt_ = 0 To Split(slctStr, ",").Count - 1
                           Dim newCB As New CheckBox

                           newCB.Name = Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(0))
                           newCB.Text = Mid(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1)), 2, Len(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1))) - 2)
                           newCB.Visible = False
                           Me.Controls.Add(newCB)
                           newCB.Font = New Font("Times New Roman", 11, FontStyle.Bold)
                           newCB.TextAlign = ContentAlignment.BottomLeft
                           newCB.Appearance = Appearance.Button
                           newCB.BackColor = Color.Aqua

                           tempTable.Rows.Clear()
                           tempTable.Columns.Clear()
                           GetTbl("select UsrExpCompStr from Int_user where UsrId = " & Usr.PUsrID, tempTable, "0000&H")
                           If tempTable.Rows(0).Item("UsrExpCompStr").ToString.Length > 0 Then
                               For cnt = 0 To Split(tempTable.Rows(0).Item("UsrExpCompStr"), ",").Count - 1
                                   If Trim(Split(tempTable.Rows(0).Item("UsrExpCompStr"), ",")(cnt)) = newCB.Name Then
                                       newCB.Checked = True
                                       newCB.BackColor = Color.LimeGreen
                                       Exit For
                                   End If
                               Next cnt
                           End If

                           AddHandler newCB.Click, AddressOf HandleChekedClick

                           If Cnt_ = 0 Then
                               Temp = newCB
                               Temp.Location = New Point(20, -5)
                           End If

                           If Temp.Location.Y > 260 Then
                               X += 190
                               Y = 0
                               newCB.Size = New Point(180, 35)
                               newCB.Location = New Point(X, Y + 30)
                               newCB.TextAlign = ContentAlignment.MiddleLeft
                           Else
                               X = Temp.Location.X
                               Y = Temp.Location.Y
                               newCB.Size = New Point(180, 35)
                               newCB.Location = New Point(X, Y + 35)
                               newCB.TextAlign = ContentAlignment.MiddleLeft
                           End If
                           Temp = newCB
                           newCB.Visible = True
                           Me.Refresh()
                           Label7.Location = New Point(X + 200, 150)

                       Next
                       Label7.Visible = False
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
                       Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
                   End If
               End Sub)
        GC.Collect()
    End Sub
    Private Sub HandleChekedClick(sender As Object, e As EventArgs) Handles ChckBxDate.Click
        For Each c In Me.Controls
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
                SndMailTsk = New Thread(AddressOf ExpSub)
                SndMailTsk.IsBackground = True
                SndMailTsk.Start()
                'ExpDTable.Rows.Clear()
                'ExpDTable.Columns.Clear()
                'If GetTbl(ExpStr, ExpDTable, "0000&H") = Nothing Then
                '    If ExpDTable.Rows.Count > 0 Then
                '        ExpPrev.ShowDialog()
                '    Else
                '        MsgInf("لا توجد بيانات للعرض")
                '    End If
                'Else
                '    MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                'End If
            End If
        Else
            SndMailTsk = New Thread(AddressOf ExpSub)
            SndMailTsk.IsBackground = True
            SndMailTsk.Start()
            'ExpPrev.ShowDialog()
            'ff()

            'ExpDTable.Rows.Clear()
            'ExpDTable.Columns.Clear()
            'If GetTbl(ExpStr, ExpDTable, "0000&H") = Nothing Then
            '    If ExpDTable.Rows.Count > 0 Then
            '        ExpPrev.ShowDialog()
            '    Else
            '        MsgInf("لا توجد بيانات للعرض")
            '    End If
            'Else
            '    MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            'End If
        End If
    End Sub
    Private Sub BtnExprt_Click(sender As Object, e As EventArgs) Handles BtnExprt.Click
        If Mid(Usr.PUsrLvl, 43, 1) <> "A" Then
            If Math.Abs(DateTime.Parse(Format(DateTimeFrom.Value, "yyyy/MM/dd")).Subtract(DateTime.Parse(Format(DateTimeTo.Value, "yyyy/MM/dd"))).TotalDays) >= 31 Then
                MsgInf("أقصى مدة لإستخراج البيانات هي 31 يوم" & vbCrLf & "برجاء تقليل المدة من " & Math.Abs(DateTime.Parse(Format(DateTimeFrom.Value, "yyyy/MM/dd")).Subtract(DateTime.Parse(Format(DateTimeTo.Value, "yyyy/MM/dd"))).TotalDays) & " للمدة المطلوبه")
                Exit Sub
            Else
                WelcomeScreen.StatBrPnlAr.Text = " ......................... جاري تحميل البيانات"
                ExpSub()
                ExpDTable.Rows.Clear()
                ExpDTable.Columns.Clear()
                If GetTbl(ExpStr, ExpDTable, "0000&H") = Nothing Then
                    If ExpDTable.Rows.Count > 0 Then
                        DataExp("ComplaintReport")
                    Else
                        MsgInf("لا توجد بيانات للعرض")
                    End If
                Else
                    MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                End If
            End If
        Else
            ExpSub()
            ExpDTable.Rows.Clear()
            ExpDTable.Columns.Clear()
            If GetTbl(ExpStr, ExpDTable, "0000&H") = Nothing Then
                If ExpDTable.Rows.Count > 0 Then
                    DataExp("ComplaintReport")
                Else
                    MsgInf("لا توجد بيانات للعرض")
                End If
            Else
                MsgInf(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        End If
        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub ExpSub()
        Invoke(Sub()
                   WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ....."
                   Dim CollctStr As String = ""
                   Dim TruFlse As String = ""
                   ExpTrFlseTable.Rows.Clear()
                   ExpTrFlseTable.Columns.Clear()
                   ExpTrFlseTable.Rows.Add()
                   For Each c In Me.Controls
                       If TypeOf c Is CheckBox Then
                           If c.TabIndex > 2148 Then
                               ExpTrFlseTable.Columns.Add(c.Name)
                               ExpTrFlseTable.Rows(0).Item(c.Name) = c.checked
                               If c.Checked = True Then
                                   CollctStr &= c.name & ", "
                               End If
                           End If
                       End If
                   Next
                   If CollctStr.Length = 0 Then
                       Exit Sub
                   End If

                   Dim CollectStr As String = "Select " & Mid(CollctStr, 1, Len(CollctStr) - 2) & " From ExportRep"
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
                       str = "CONVERT(date, TkDtStart,111) BETWEEN CONVERT(date, '" & Format(DateTimeFrom.Value, "yyyy/MM/dd") & "', 111) AND  CONVERT(date, '" & Format(DateTimeTo.Value, "yyyy/MM/dd") & "', 111)"
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

                   If RdioReopnY.Checked = True Or RdioReopnN.Checked = True Then
                       If str.Length > 0 Then str &= " And "
                   End If
                   If RdioReopnY.Checked = True Then
                       str &= "[ReopenStat]" & " = '" & "نعم" & "'"
                   ElseIf RdioReopnN.Checked = True Then
                       str &= "[ReopenStat]" & " = '" & "لا" & "'"
                   ElseIf RdioReopnAll.Checked = True Then
                       str &= ""
                   End If
                   ', CompStat, FlwStat, TikCreat, TikCreatTeam, UsrRealNm, UCatNm, ReopenStat
                   If PrdKComb.Text.Length > 0 Then
                       str &= " And "
                       str &= "[ProdKNm]" & " = '" & PrdKComb.Text & "'"
                   Else
                       str &= ""
                   End If

                   If CombProd.Text.Length > 0 Then
                       str &= " And "
                       str &= "[PrdNm]" & " = '" & CombProd.Text & "'"
                   Else
                       str &= ""
                   End If

                   If CombComp.Text.Length > 0 Then
                       str &= " And "
                       str &= "[CompNm]" & " = '" & CombComp.Text & "'"
                   Else
                       str &= ""
                   End If

                   InsUpd("update Int_user set UsrExpCompStr = '" & Mid(CollctStr, 1, Len(CollctStr) - 2) & "' where UsrId = " & Usr.PUsrID, "0000&H")

                   'My.Settings.ExportStr = Mid(CollctStr, 1, Len(CollctStr) - 2)
                   'My.Settings.Save()
                   sqlComm.CommandTimeout = 90
                   ExpStr = " where " & str & Mytem
                   ExpDTable.Rows.Clear()
                   ExpDTable.Columns.Clear()
                   GetTbl("Select TkKind, TkID, TkDtStart, TkDtClose, TkDuration, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TransDate, ProdKNm, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, CompStat, FlwStat, TikCreat, TikCreatTeam, UsrRealNm, UCatNm, ReopenStat, TkRecieveDt, DistripDurastion, RecievedWDays, RecievedRange, TkEmpNm, TkEmpNm0, TkupSTime, TkupTxt, UpdateUsrNm, CatLvNm From ExportRep1 " & ExpStr & " order by TkID", ExpDTable, "0000&H")
                   WelcomeScreen.StatBrPnlAr.Text = ""
                   ProgressBar1.Maximum = ExpDTable.Rows.Count
                   PrvForm()
               End Sub)

    End Sub
    Private Sub ChckBxDate_Click(sender As Object, e As EventArgs) Handles ChckBxDate.Click
        If ChckBxDate.Checked = True Then
            RdioOpen.Checked = True
            GroupBox1.Visible = False
            Rdiocls.Enabled = False
            RdioTikAll.Enabled = False
        Else
            GroupBox1.Visible = True
            Rdiocls.Enabled = True
            RdioTikAll.Enabled = True
            RdioTikAll.Checked = True
        End If
    End Sub
    Private Sub ChckBxDate_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxDate.CheckedChanged

        'If ChckBxDate.Checked = True Then
        '    RdioOpen.Checked = True
        '    Rdiocls.Enabled = False
        '    RdioTikAll.Enabled = False
        'Else
        '    Rdiocls.Enabled = True
        '    RdioTikAll.Enabled = True
        'End If
    End Sub
    Private Sub PrvForm()
        Prv = New Form
        Dim Btn As New Button
        ddd = New ReportViewer
        Combo = New ComboBox

        Prv.Controls.Add(ddd)
        Prv.Controls.Add(Combo)
        Prv.Controls.Add(Btn)



        ExtTable.Columns.Clear()
        ExtTable.Rows.Clear()
        ExtTable.Columns.Add("Ext")
        ExtTable.Columns.Add("Item")

        ExtTable.Rows.Add(".xls", "Excel")
        ExtTable.Rows.Add(".pdf", "PDF")


        Combo.DataSource = ExtTable
        Combo.DisplayMember = "Item"
        Combo.ValueMember = "Ext"

        ddd.Dock = DockStyle.None
        ddd.PageCountMode = PageCountMode.Actual
        ddd.Location = New Point(0, 40)
        Combo.Location = New Point(10, 5)
        Btn.Location = New Point(150, 5)
        Btn.FlatStyle = FlatStyle.Flat
        Btn.BackgroundImage = My.Resources.Export1
        Btn.BackColor = Color.Transparent
        Btn.BackgroundImageLayout = ImageLayout.Stretch
        Btn.FlatAppearance.BorderSize = 0
        Btn.Size = New Point(30, 30)
        AddHandler Btn.MouseEnter, AddressOf Btn_MouseEnter
        AddHandler Btn.MouseLeave, AddressOf Btn_MouseLeave
        AddHandler Btn.Click, AddressOf Btn_Click

        ddd.ShowPrintButton = False
        ddd.ShowExportButton = False
        With ddd.LocalReport
            .ReportEmbeddedResource = "VOCAPlus.ExpReprt.rdlc"
            .DataSources.Clear()
        End With

        datasource = New ReportDataSource("DataSetRep", ExpDTable)
        ddd.LocalReport.DataSources.Add(datasource)

        datasource1 = New ReportDataSource("DataSetRepVisible", ExpTrFlseTable)
        ddd.LocalReport.DataSources.Add(datasource1)
        sqlCon.Close()

        Dim fff As Integer = 0
        For Cnt_ = 0 To ExpTrFlseTable.Columns.Count - 1
            If ExpTrFlseTable.Rows(0).Item(Cnt_) = True Then fff += 1
        Next
        Prv.Text = "معاينة استخراج البيانات" & " - " & "عدد الشكاوى : " & ExpDTable.Rows.Count.ToString("N0") & " - " & "عدد الأعمده : " & fff

        ddd.RefreshReport()
        ddd.LocalReport.Refresh()
        'Prv.WindowState = FormWindowState.Maximized
        'ddd.SetDisplayMode(DisplayMode.PrintLayout)
        Prv.RightToLeftLayout = True
        Prv.RightToLeft = RightToLeft.Yes
        ddd.RightToLeft = RightToLeft.Yes
        Prv.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 100)
        Prv.StartPosition = FormStartPosition.CenterScreen
        ddd.Size = New Point(Prv.Width - 20, Screen.PrimaryScreen.Bounds.Height - 180)
        Prv.ShowDialog()
    End Sub
    Private Sub Btn_Click(sender As Object, e As EventArgs)
        Dim Botn As Button = sender

        'Me.Enabled = False
        'Dim mybytes As [Byte]() = ddd.LocalReport.Render(Combo.Text)
        ''Byte[] mybytes = report.Render("PDF"); For exporting To PDF

        'Using fs As IO.FileStream = IO.File.Create("D:\Complaint_Test" & Combo.SelectedValue) 'Format(ExportAdmin.DateTimeFrom.Value, "yyyy-MM-dd") & "_" & Format(ExportAdmin.DateTimeTo.Value, "yyyy-MM-dd") & "_" & Format(Now, "HH_mm_ss") & ComboBox1.SelectedValue) 
        '    fs.Write(mybytes, 0, mybytes.Length)
        'End Using

        'Me.Enabled = True
        D = New SaveFileDialog
        With D
            .Title = "Save Excel File"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Filter = "Excel File|*.Xlsx"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        D.FileName = "ComplaintsReport"
        If D.ShowDialog() = DialogResult.OK Then
            BtnPrv.Enabled = False
            Prv.Close()
            Prv = Nothing
            ddd = Nothing
            GC.Collect()
            SndMailTsk = New Thread(AddressOf EXp)
            SndMailTsk.IsBackground = True
            SndMailTsk.Start()
        End If

    End Sub
    Private Sub EXp()
        PrivExp(Split(Split(D.FileName, "\")(Split(D.FileName, "\").Count - 1), ".")(0))
        Invoke(Sub() BtnPrv.Enabled = True)
        MsgInf("تم الانتهاء من استخراج البيانات")
        Invoke(Sub() Label6.Text = "")
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
                Invoke(Sub() Timer1.Start())

                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    Invoke(Sub() ProgressBar1.Value = Rws + 1)
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
        Invoke(Sub() Timer1.Stop())
End_:

    End Sub
    Private Sub ExportAdmin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SndMailTsk.IsAlive = True Then
            MsgInf("لا يمكن إغلاق الشاشة حتى الإنتهاء من استخراج البيانات" & vbNewLine & "يمكنك فتح شاشة أخرى من أسفل الشاشة")
            e.Cancel = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If RwSped = 0 Then RwSped = Rws
        If Rws < ExpDTable.Rows.Count Then
            If Rws - RwSped > 0 Then
                Dim ddd As Integer = ExpDTable.Rows.Count - Rws
                Dim ff As Double = Rws - RwSped
                Label6.Text = "Export Speed : " & ff.ToString("N0") & " Rows/ Sec " & vbNewLine & "Estimated Time " & Chr(34) & "Min" & Chr(34) & "  : " & (ddd / ff / 60).ToString("N2")
                Label6.Refresh()
                RwSped = Rws
            Else
                Invoke(Sub() Label6.Text = "....  جاري بدأ استخراج الملف")
            End If
        Else
            Label6.Text = "....  جاري حفظ الملف"
            Label6.Refresh()
        End If


    End Sub
End Class