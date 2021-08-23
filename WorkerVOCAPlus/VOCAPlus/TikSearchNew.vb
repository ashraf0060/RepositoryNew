Imports System.Net
Imports System.IO
Imports Microsoft.Exchange.WebServices.Data
Public Class TikSearchNew
    Dim TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Dim PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Dim TickKindFltr As Integer = 2   'ticket kind      0=Inquiry and 1=Complaint
    Dim TicOpnFltr As Integer = 2      'ticket Sttaus   0=Open and 1=Close and 2=All
    Dim SerchItmTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim TickSrchTable As DataTable = New DataTable

    Dim EscTable As New DataTable

    Private exchange As ExchangeService
    Dim Span_ As New TimeSpan
    Dim nxt As String
    Dim CurrRw As Integer
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TikSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
        Me.GridTicket.Width = screenWidth - 30
        Me.GridTicket.Height = Me.Height - 150
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            SerchItmTable.Rows.Clear()
            SerchItmTable.Columns.Clear()
            SerchItmTable.Columns.Add("Kind")
            SerchItmTable.Columns.Add("Item")

            SerchItmTable.Rows.Add("Int-TkID", "رقم الشكوى")
            SerchItmTable.Rows.Add("STR-TkClNm", "اسم العميل")
            SerchItmTable.Rows.Add("STR-TkClPh", "تليفون العميل1")
            SerchItmTable.Rows.Add("STR-TkClPh1", "تليفون العميل2")
            SerchItmTable.Rows.Add("STR-TkCardNo", "رقم الكارت")
            SerchItmTable.Rows.Add("STR-TkShpNo", "رقم الشحنة")
            SerchItmTable.Rows.Add("STR-TkGBNo", "رقم أمر الدفع")
            SerchItmTable.Rows.Add("STR-TkClNtID", "الرقم القومي")
            SerchItmTable.Rows.Add("Int-TkAmount", "مبلغ العملية")
            SerchItmTable.Rows.Add("STR-SrcNm", "مصدر الشكوى")


            FilterComb.DataSource = SerchItmTable
            FilterComb.DisplayMember = "Item"
            FilterComb.ValueMember = "Kind"

            PrdItmTable.Rows.Clear()
            PrdItmTable.Columns.Clear()
            PrdItmTable.Columns.Add("ID")
            PrdItmTable.Columns.Add("Item")

            PrdItmTable.Rows.Add("0", "All")
            PrdItmTable.Rows.Add("1", "مالية")
            PrdItmTable.Rows.Add("2", "بريدية")
            PrdItmTable.Rows.Add("3", "حكومية")
            PrdItmTable.Rows.Add("4", "مجتمعية")

            PrdKComb.DataSource = PrdItmTable
            PrdKComb.DisplayMember = "Item"
            PrdKComb.ValueMember = "ID"

            WelcomeScreen.StatBrPnlAr.Text = ""

        End If
    End Sub
#Region "First Tab"
    Private Sub BtnSerch_Click(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Filtr()
    End Sub
    Private Sub FilterComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComb.SelectedIndexChanged
        If FilterComb.Text = "الرقم القومي" Then
            FilterComb.MaxLength = 14
        ElseIf FilterComb.Text = "تليفون العميل1" Then
            SerchTxt.MaxLength = 11
        ElseIf FilterComb.Text = "تليفون العميل2" Then
            SerchTxt.MaxLength = 11
        ElseIf FilterComb.Text = "رقم الكارت" Or FilterComb.Text = "رقم أمر الدفع" Then
            SerchTxt.MaxLength = 16
        Else
            SerchTxt.MaxLength = 50
        End If
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
        SerchTxt.ForeColor = Color.Black
        SerchTxt.Focus()
        SerchTxt.Text = ""
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If RadioButton1.Checked = True Then
            TickKindFltr = 0
        ElseIf RadioButton2.Checked = True Then
            TickKindFltr = 1
        ElseIf RadioButton3.Checked = True Then
            TickKindFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub RdioOpen_Click(sender As Object, e As EventArgs) Handles RdioOpen.Click, Rdiocls.Click, RdioAll.Click
        If RdioOpen.Checked = True Then
            TicOpnFltr = 0
        ElseIf Rdiocls.Checked = True Then
            TicOpnFltr = 1
        ElseIf RdioAll.Checked = True Then
            TicOpnFltr = 2
        End If
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrdKComb.SelectedIndexChanged
        TickSrchTable.Rows.Clear()
        StruGrdTk.Sql = 0
        LblMsg.Text = ""
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Fn As New APblicClss.Func
        Dim Def As New APblicClss.Defntion
        Dim FltrStr As String = ""
        Dim primaryKey(0) As DataColumn
        TickSrchTable = New DataTable
        StruGrdTk.Sql = 0


        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
            Invoke(Sub() LblMsg.Text = "جاري تحميل البيانات ...........")
            Invoke(Sub() LblMsg.ForeColor = Color.Green)
            Invoke(Sub() LblMsg.Refresh())
            Invoke(Sub()
                       If Split(FilterComb.SelectedValue, "-")(0) = "Int" Then
                           FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " = '" & SerchTxt.Text & "'"
                       Else
                           FltrStr = "[" & Split(FilterComb.SelectedValue, "-")(1) & "]" & " like '" & SerchTxt.Text & "%'"
                       End If

                       If PrdKComb.SelectedIndex <> 0 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[PrdKind]" & " = '" & PrdKComb.SelectedIndex & "'"
                           Else
                               FltrStr = "[PrdKind]" & " = '" & PrdKComb.SelectedIndex & "'"
                           End If
                       End If
                       If TickKindFltr <> 2 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[TkKind]" & " = " & TickKindFltr
                           Else
                               FltrStr = "[TkKind]" & " = " & TickKindFltr
                           End If
                       End If
                       If TicOpnFltr <> 2 Then
                           If FltrStr.Length > 0 Then
                               FltrStr &= " and" & "[TkClsStatus]" & " = " & TicOpnFltr
                           Else
                               FltrStr = "[TkClsStatus]" & " = " & TicOpnFltr
                           End If
                       End If
                   End Sub)

            primaryKey(0) = TickSrchTable.Columns("TkSQL")
            TickSrchTable.PrimaryKey = primaryKey
            If FltrStr.Length > 0 Then
                FltrStr = " Where " & FltrStr
                Invoke(Sub() GridTicket.Visible = False)
                '  Grid                        1        2       3       4      5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27             28                    29                  30                  31               32                    33              34             35              36                        37        38            39       40      **************
                If Invoke(Sub() Fn.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll " & FltrStr & " ORDER BY TkSQL DESC;", TickSrchTable, "1042&H", sender)) = Nothing Then
                    Invoke(Sub() Me.Text = "بحث الشكاوى والاستفسارات" & "_" & ElapsedTimeSpan)
                    If TickSrchTable.Rows.Count > 0 Then
                        If TickSrchTable.Rows.Count > 10000 Then
                            MsgInf(" برجاء تقليل البحث")
                            Exit Sub
                        End If

                        Invoke(Sub() LblMsg.Text = "جاري تحميل التحديثات ...........")
                        Invoke(Sub() LblMsg.ForeColor = Color.Blue)
                        Invoke(Sub() LblMsg.Refresh())
#Region ""
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        'Try
                        '    Invoke(Sub() GridTicket.DataSource = TickSrchTable.DefaultView)
                        '    Def.CompList = New List(Of String)
                        '    Invoke(Sub() ProgressBar1.Visible = True)
                        '    ProgressBar1.Maximum = TickSrchTable.Columns.Count
                        '    For HH = 0 To TickSrchTable.Columns.Count - 1
                        '        Invoke(Sub() ProgressBar1.Value = HH + 1)
                        '        Invoke(Sub() ProgressBar1.Refresh())
                        '        If TickSrchTable.Columns(HH).ColumnName = "TkDtStart" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "تاريخ الشكوى")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "TkID" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "رقم الشكوى")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "SrcNm" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "مصدر الشكوى")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "TkClNm" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "اسم العميل")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "TkClPh" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "تليفون العميل1")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "TkClPh1" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "تليفون العميل2")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "PrdNm" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "اسم المنتج")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "CompNm" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "نوع الشكوى")
                        '        ElseIf TickSrchTable.Columns(HH).ColumnName = "UsrRealNm" Then
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "متابع الشكوى")
                        '        Else
                        '            Invoke(Sub() GridTicket.Columns(HH).HeaderText = "unknown")
                        '            Invoke(Sub() GridTicket.Columns(HH).Visible = False)
                        '        End If
                        '    Next
                        '    Invoke(Sub() ProgressBar1.Maximum = GridTicket.Rows.Count)
                        '    For GG = 0 To GridTicket.Rows.Count - 1
                        '        Invoke(Sub() ProgressBar1.Value = GG + 1)
                        '        'Invoke(Sub() ProgressBar1.Refresh())
                        '        Invoke(Sub() Def.CompList.Add("TkupTkSql = " & GridTicket.Rows(GG).Cells("TkSQL").Value))
                        '    Next
                        '    Invoke(Sub() CompIds = String.Join(" OR ", Def.CompList))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("تاريخ آخر تحديث"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("نص آخر تحديث"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("محرر آخر تحديث"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("TkupReDt"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("TkupUser"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("LastUpdateID"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("EvSusp"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("UCatLvl"))
                        '    Invoke(Sub() TickSrchTable.Columns.Add("TkupUnread"))

                        'Catch ex As Exception
                        '    Def.Errmsg = ex.Message
                        'End Try
                        'Invoke(Sub() ProgressBar1.Visible = False)
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
#End Region

                        Invoke(Sub() Fn.CompGrdTikFill(GridTicket, TickSrchTable, ProgressBar1, sender)) 'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                        Invoke(Sub() Fn.GetUpdtEvnt_(sender))

                        Invoke(Sub() LblMsg.Text = "جاري تنسيق البيانات ...........")
                        Invoke(Sub() LblMsg.ForeColor = Color.Blue)
                        Invoke(Sub() LblMsg.Refresh())
                        Invoke(Sub() GridTicket.Columns("TkupReDt").Visible = False)
                        Invoke(Sub() GridTicket.Columns("TkupUser").Visible = False)
                        Invoke(Sub() GridTicket.Columns("LastUpdateID").Visible = False)
                        Invoke(Sub() GridTicket.Columns("EvSusp").Visible = False)
                        Invoke(Sub() GridTicket.Columns("UCatLvl").Visible = False)
                        Invoke(Sub() GridTicket.Columns("TkupUnread").Visible = False)
                        Invoke(Sub() Fn.TikFormat(TickSrchTable, UpdtCurrTbl, ProgressBar1, sender))

                        Invoke(Sub() LblMsg.Text = ("نتيجة البحث : إجمالي عدد " & GridCuntRtrn.TickCount & " -- عدد الشكاوى : " & GridCuntRtrn.CompCount & " -- عدد الاستفسارات : " & GridCuntRtrn.TickCount - GridCuntRtrn.CompCount & " -- شكاوى مغلقة : " & GridCuntRtrn.ClsCount & " -- شكاوى مفتوحة : " & GridCuntRtrn.CompCount - GridCuntRtrn.ClsCount & " -- لم يتم المتابعة : " & GridCuntRtrn.NoFlwCount))
                        Invoke(Sub() LblMsg.ForeColor = Color.Green)
                        Invoke(Sub() GridTicket.ClearSelection())
                    Else
                        Invoke(Sub() LblMsg.Text = ("لا توجد نتيجة للبحث بـ" & FilterComb.Text))
                        Invoke(Sub() LblMsg.ForeColor = Color.Red)
                    End If
                    Invoke(Sub() GridTicket.Visible = True)
                Else
                    LblMsg.Text = "لم ينجح البحث - يرجى المحاولة مرة أخرى"
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            Else
            End If
        Else
            LblMsg.Text = ("برجاء ادخال كلمات البحث")
            LblMsg.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Private Sub Filtr()

        If IsHandleCreated = True Then
            Invoke(Sub()
                       Dim state As New APblicClss.Defntion
                       'WChckConn.CancelAsync()
                       Dim Cn As New APblicClss.Func
                       If BackgroundWorker1.IsBusy = False Then
                           Invoke(Sub() BackgroundWorker1.RunWorkerAsync(Cn))
                       End If
                   End Sub)
        End If



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
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        If (GridTicket.SelectedCells.Count) > 0 Then
            If GridTicket.CurrentRow.Index <> -1 Then
                CurrRw = GridTicket.CurrentRow.Index
                If TikGVDblClck(GridTicket) = Nothing Then
                    TikDetails.Text = "شكوى رقم " & StruGrdTk.Sql
                    TikDetails.ShowDialog()
                Else
                    MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
                End If
            End If
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
#End Region

#Region "Updates Partition"

#End Region
#Region "Tool Strip GridUpdate"
    Private Sub SerchTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SerchTxt.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Filtr()
        End If
    End Sub
    Private Sub GridTicket_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridTicket.RowEnter
        StruGrdTk.Sql = 0
    End Sub

    Private Sub TikSearchNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    End Sub
#End Region

End Class