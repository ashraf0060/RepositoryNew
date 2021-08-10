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
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TikSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
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
        LblMsg.Text = ""
    End Sub
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrdKComb.SelectedIndexChanged
        TickSrchTable.Rows.Clear()
        LblMsg.Text = ""
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String = ""
        Dim primaryKey(0) As DataColumn
        TickSrchTable = New DataTable
        If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
            LblMsg.Text = "جاري تحميل البيانات ..........."
            LblMsg.ForeColor = Color.Green
            LblMsg.Refresh()

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
            primaryKey(0) = TickSrchTable.Columns("TkSQL")
            TickSrchTable.PrimaryKey = primaryKey
            TickSrchTable.Rows.Clear()
            If FltrStr.Length > 0 Then
                FltrStr = " Where " & FltrStr

                '  Grid                        1        2       3       4      5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27             28                    29                  30                  31               32                    33              34             35              36                        37        38            39       40      **************
                If PublicCode.GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '' AS LstUpdtTime, '' AS TkupTxt, 1 AS TkupUnread, 0 AS TkupEvtId, '' AS LstUpUsr, TkReOp, TkRecieveDt, TkEscTyp, ProdKNm, CompHelp FROM dbo.TicketsAll " & FltrStr & " ORDER BY TkSQL DESC;", TickSrchTable, "1042&H") = Nothing Then
                    Me.Text = "بحث الشكاوى والاستفسارات" & "_" & ElapsedTimeSpan
                    If TickSrchTable.Rows.Count > 0 Then
                        LblMsg.Text = "جاري تنسيق البيانات ..........."
                        LblMsg.ForeColor = Color.Blue
                        LblMsg.Refresh()
                        CompGrdTikFill(GridTicket, TickSrchTable)  'Adjust Fill Table and assign Grid Data source of Ticket Gridview
                        GetUpdtEvnt_()
                        TickSrchTable.Columns.Add("تاريخ آخر تحديث")
                        TickSrchTable.Columns.Add("نص آخر تحديث")
                        TickSrchTable.Columns.Add("محرر آخر تحديث")
                        TickSrchTable.Columns.Add("LastUpdateID")

                        GridTicket.Columns("LastUpdateID").Visible = False

                        TikFormat(TickSrchTable, UpdtCurrTbl)

                        LblMsg.Text = ("نتيجة البحث : إجمالي عدد " & GridCuntRtrn.TickCount & " -- عدد الشكاوى : " & GridCuntRtrn.CompCount & " -- عدد الاستفسارات : " & GridCuntRtrn.TickCount - GridCuntRtrn.CompCount & " -- شكاوى مغلقة : " & GridCuntRtrn.ClsCount & " -- شكاوى مفتوحة : " & GridCuntRtrn.CompCount - GridCuntRtrn.ClsCount & " -- لم يتم المتابعة : " & GridCuntRtrn.NoFlwCount)
                        LblMsg.ForeColor = Color.Green
                        GridTicket.ClearSelection()
                    Else
                        LblMsg.Text = ("لا توجد نتيجة للبحث بـ" & FilterComb.Text)
                        LblMsg.ForeColor = Color.Red
                        Beep()
                    End If
                Else
                    LblMsg.Text = "لم ينجح البحث - يرجى المحاولة مرة أخرى"
                    LblMsg.ForeColor = Color.Red
                    Beep()
                End If
            End If
        Else
            LblMsg.Text = ("برجاء ادخال كلمات البحث")
            LblMsg.ForeColor = Color.Red
            Beep()
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
                StruGrdTk.Tick = GridTicket.CurrentRow.Cells("TkKind").Value
                StruGrdTk.FlwStat = GridTicket.CurrentRow.Cells("TkClsStatus").Value
                StruGrdTk.Sql = GridTicket.CurrentRow.Cells("TkSQL").Value
                StruGrdTk.Ph1 = GridTicket.CurrentRow.Cells("TkClPh").Value
                StruGrdTk.Ph2 = GridTicket.CurrentRow.Cells("TkClPh1").Value.ToString
                StruGrdTk.DtStrt = GridTicket.CurrentRow.Cells("TkDtStart").Value
                StruGrdTk.ClNm = GridTicket.CurrentRow.Cells("TkClNm").Value
                StruGrdTk.Adress = GridTicket.CurrentRow.Cells("TkClAdr").Value.ToString
                StruGrdTk.Email = GridTicket.CurrentRow.Cells("TkMail").Value.ToString
                StruGrdTk.Detls = GridTicket.CurrentRow.Cells("TkDetails").Value.ToString
                StruGrdTk.Area = GridTicket.CurrentRow.Cells("OffArea").Value.ToString
                StruGrdTk.Offic = GridTicket.CurrentRow.Cells("OffNm1").Value.ToString
                StruGrdTk.ProdNm = GridTicket.CurrentRow.Cells("PrdNm").Value
                StruGrdTk.CompNm = GridTicket.CurrentRow.Cells("CompNm").Value
                StruGrdTk.Src = GridTicket.CurrentRow.Cells("SrcNm").Value
                StruGrdTk.Trck = GridTicket.CurrentRow.Cells("TkShpNo").Value.ToString
                StruGrdTk.Orig = GridTicket.CurrentRow.Cells("CounNmSender").Value.ToString
                StruGrdTk.Dist = GridTicket.CurrentRow.Cells("CounNmConsign").Value.ToString
                StruGrdTk.Card = GridTicket.CurrentRow.Cells("TkCardNo").Value.ToString
                StruGrdTk.Gp = GridTicket.CurrentRow.Cells("TkGBNo").Value.ToString
                StruGrdTk.NID = GridTicket.CurrentRow.Cells("TkClNtID").Value.ToString
                StruGrdTk.Amnt = GridTicket.CurrentRow.Cells("TkAmount").Value
                If DBNull.Value.Equals(GridTicket.CurrentRow.Cells("TkTransDate").Value) = False Then StruGrdTk.TransDt = GridTicket.CurrentRow.Cells("TkTransDate").Value
                StruGrdTk.UsrNm = GridTicket.CurrentRow.Cells("UsrRealNm").Value
                StruGrdTk.Help_ = GridTicket.CurrentRow.Cells("CompHelp").Value.ToString
                StruGrdTk.ProdK = GridTicket.CurrentRow.Cells("PrdKind").Value
                TikDetails.Text = "شكوى رقم " & StruGrdTk.Sql

                StruGrdTk.LstUpDt = GridTicket.CurrentRow.Cells("تاريخ آخر تحديث").Value
                StruGrdTk.LstUpEvId = GridTicket.CurrentRow.Cells("LastUpdateID").Value

                TikDetails.ShowDialog()

            End If
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
#End Region

#Region "Updates Partition"
    Private Sub GetUpdtEvnt_()
        UpdtCurrTbl = New DataTable
        '                                 0        1         2         3         4        5        6         7         8         9
        If PublicCode.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( " & CompIds & ") ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H") = Nothing Then
            UpdtCurrTbl.Columns.Add("File")        ' Add files Columns 
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
#End Region
#Region "Tool Strip GridUpdate"
    Private Sub SerchTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SerchTxt.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Filtr()
        End If
    End Sub
#End Region

End Class