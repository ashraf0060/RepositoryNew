Imports System.Threading
Imports System.ComponentModel
Public Class TotView
    Private ReadOnly UserTable As DataTable = New DataTable
    Dim MyUsrsTable As DataTable = New DataTable()
    Dim TotViewTable As DataTable = New DataTable
    Dim TempNode() As TreeNode
    Dim UsrStr As String = ""
    Dim TempData As DataView
    Dim RwCnt As Integer
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TotView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsrStr = ""
        UserTable.Rows.Clear()
        MyUsrsTable.Rows.Clear()
        If MyUsrsTable.Columns.Count < 2 Then
            MyUsrsTable.Columns.Add("Id")
            MyUsrsTable.Columns.Add("Nm")
        End If
        UserTree.ImageList = ImgLst
        If Mid(Usr.PUsrLvl, 17, 1) = "A" Then
            UserTree.Nodes.Add("2", 32006 & " - " & "قطاع خدمة العملاء" & " - " & "عبد العزيز حسين", 1, 3)
        Else
            UserTree.Nodes.Add(Usr.PUsrCat.ToString, Usr.PUsrID & " - " & Usr.PUsrCatNm & " - " & Usr.PUsrRlNm, 1, 3)
        End If
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ...................."
        '                   0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
        If GetTbl("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0)  Order By UCatIdSub, UsrRealNm", UserTable, "1038&H") = Nothing Then
            'Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) AND (UCatLvl between 3 and 5) Order By UCatIdSub, UsrRealNm
            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTable(Cnt_).Item(2).ToString, True)
                If TempNode.Length > 0 Then
                    TempNode(0).Nodes.Add(UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(0).ToString & " - " & UserTable(Cnt_).Item(4).ToString, 0, 2)
                    MyUsrsTable.Rows.Add(UserTable(Cnt_).Item(0).ToString, Split(UserTable(Cnt_).Item(4).ToString, " - ")(1))
                    UsrStr &= "UsrId = " & UserTable(Cnt_).Item(0).ToString & " OR "
                    If TempNode(0).Nodes.Count > 0 Then
                        TempNode(0).ImageIndex = 1
                        TempNode(0).SelectedImageIndex = 3
                    End If
                End If
            Next Cnt_


            If UsrStr.Length > 0 Then UsrStr = "Where (" & Mid(UsrStr, 1, UsrStr.Length - 4) & ")" Else UsrStr = ""

            MyUsrsTable.Rows.Clear()
            MyUsrsTable.Columns.Clear()
            '      SELECT UsrId, UsrRealNm, (CASE WHEN UsrClsN = 0 THEN '' ELSE CONVERT(varchar(20), UsrClsN) END) AS UsrClsN, (CASE WHEN UsrFlN = 0 THEN '' ELSE CONVERT(varchar(20), UsrFlN) END)AS UsrFlN, (CASE WHEN UsrReOpY = 0 THEN '' ELSE CONVERT(varchar(20), UsrReOpY) END)AS UsrReOpY, (CASE WHEN UsrUnRead = 0 THEN '' ELSE CONVERT(varchar(20), UsrUnRead) END) AS UsrUnRead, (CASE WHEN UsrEvDy = 0 THEN '' ELSE CONVERT(varchar(20), UsrEvDy) END)AS UsrEvDy, (CASE WHEN UsrClsYDy = 0 THEN '' ELSE CONVERT(varchar(20), UsrClsYDy) END) AS UsrClsYDy, (CASE WHEN UsrReadYDy = 0 THEN '' ELSE CONVERT(varchar(20), UsrReadYDy) END) AS UsrReadYDy, (CASE WHEN UsrRecevDy = 0 THEN '' ELSE CONVERT(varchar(20), UsrRecevDy) END) AS UsrRecevDy FROM Int_user
            If GetTbl("SELECT UsrId, UsrRealNm, UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrTikFlowDy, UsrEvDy, UsrClsYDy, UsrReadYDy, UsrRecevDy, UsrClsUpdtd, UsrEsc1, UsrEsc2, UsrEsc3 FROM Int_user " & UsrStr & " order by UsrRealNm", MyUsrsTable, "1049&H") = Nothing Then
                GridTicket1.DataSource = MyUsrsTable
                GridTicket1.Columns(0).Visible = False
                GridTicket1.Columns(1).HeaderText = "اسم الموظف"
                GridTicket1.Columns(2).HeaderText = "مفتوحة"
                GridTicket1.Columns(3).HeaderText = "بدون متابعة"
                GridTicket1.Columns(4).HeaderText = "معادة الفتح"
                GridTicket1.Columns(5).HeaderText = "تحديثات غير مقروءه"
                GridTicket1.Columns(6).HeaderText = "تعامل اليوم"
                GridTicket1.Columns(7).HeaderText = "تحديثات اليوم"
                GridTicket1.Columns(8).HeaderText = "إغلاق اليوم"
                GridTicket1.Columns(9).HeaderText = "تحديثات مقرءه"
                GridTicket1.Columns(10).HeaderText = "استلام اليوم"
                GridTicket1.Columns(11).HeaderText = "تحديثات شكاوى مغلقة"
                GridTicket1.Columns(12).HeaderText = "متابعة 1"
                GridTicket1.Columns(13).HeaderText = "متابعة 2"
                GridTicket1.Columns(14).HeaderText = "متابعة 3"
                For Cnt_ = 2 To GridTicket1.Columns.Count - 1
                    GridTicket1.Columns(Cnt_).Width = 55
                Next
                GridTicket1.DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Regular)
                GridTicket1.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Bold)
                GridTicket1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
                GridTicket1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GridTicket1.Columns(1).Width = 150

                UserTree.SelectedNode = UserTree.Nodes(0)
                GridTicket1.Rows(0).Cells(1).Selected = True
                Cal_()
            End If

        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Me.Close()
        End If
        UserTree.CollapseAll()
    End Sub
    Private Sub Cal_()
        Label4.Text = GridTicket1.Rows.Count.ToString("N0")

        'If MyUsrsTable.Rows.Count - RwCnt <> 1 Then
        '    RwCnt = MyUsrsTable.Rows.Count
        '    MyUsrsTable.Rows.Add()
        'End If

        'For TT = 2 To MyUsrsTable.Columns.Count - 1
        '    Dim Sumd As Integer = 0
        '    For GH = 0 To MyUsrsTable.DefaultView.Count - 2
        '        If DBNull.Value.Equals(MyUsrsTable.DefaultView(GH).Item(TT)) = False Then
        '            Sumd += MyUsrsTable.DefaultView(GH).Item(TT)
        '        End If
        '    Next
        '    MyUsrsTable.Rows(RwCnt).Item(TT) = 0
        '    MyUsrsTable.Rows(RwCnt).Item(TT) = Sumd
        'Next
        'GridTicket1.Rows(MyUsrsTable.DefaultView.Count - 1).DefaultCellStyle.ForeColor = Color.Green
        'GridTicket1.Rows(MyUsrsTable.DefaultView.Count - 1).DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Bold)
#Region "Delete"
        LblOpen.Text = (From row As DataGridViewRow In GridTicket1.Rows
                        Where row.Cells(2).FormattedValue.ToString() <> String.Empty
                        Select Convert.ToInt32(row.Cells(2).FormattedValue)).Sum().ToString("N0")
        LblNoFollow.Text = (From row As DataGridViewRow In GridTicket1.Rows
                            Where row.Cells(3).FormattedValue.ToString() <> String.Empty
                            Select Convert.ToInt32(row.Cells(3).FormattedValue)).Sum().ToString("N0")
        LblReOpen.Text = (From row As DataGridViewRow In GridTicket1.Rows
                          Where row.Cells(4).FormattedValue.ToString() <> String.Empty
                          Select Convert.ToInt32(row.Cells(4).FormattedValue)).Sum().ToString("N0")
        LblUnrd.Text = (From row As DataGridViewRow In GridTicket1.Rows
                        Where row.Cells(5).FormattedValue.ToString() <> String.Empty
                        Select Convert.ToInt32(row.Cells(5).FormattedValue)).Sum().ToString("N0")
        LblFolwDy.Text = (From row As DataGridViewRow In GridTicket1.Rows
                          Where row.Cells(6).FormattedValue.ToString() <> String.Empty
                          Select Convert.ToInt32(row.Cells(6).FormattedValue)).Sum().ToString("N0")
        LblEvt.Text = (From row As DataGridViewRow In GridTicket1.Rows
                       Where row.Cells(7).FormattedValue.ToString() <> String.Empty
                       Select Convert.ToInt32(row.Cells(7).FormattedValue)).Sum().ToString("N0")
        LblCls.Text = (From row As DataGridViewRow In GridTicket1.Rows
                       Where row.Cells(8).FormattedValue.ToString() <> String.Empty
                       Select Convert.ToInt32(row.Cells(8).FormattedValue)).Sum().ToString("N0")
        LblRead.Text = (From row As DataGridViewRow In GridTicket1.Rows
                        Where row.Cells(9).FormattedValue.ToString() <> String.Empty
                        Select Convert.ToInt32(row.Cells(9).FormattedValue)).Sum().ToString("N0")
        LblRecived.Text = (From row As DataGridViewRow In GridTicket1.Rows
                           Where row.Cells(10).FormattedValue.ToString() <> String.Empty
                           Select Convert.ToInt32(row.Cells(10).FormattedValue)).Sum().ToString("N0")
        LblClsUpted.Text = (From row As DataGridViewRow In GridTicket1.Rows
                            Where row.Cells(11).FormattedValue.ToString() <> String.Empty
                            Select Convert.ToInt32(row.Cells(11).FormattedValue)).Sum().ToString("N0")
#End Region
        WelcomeScreen.StatBrPnlAr.Text = ""
        ChckColor()
    End Sub
    Private Sub ChckColor()
        For Each c In GroupBox1.Controls
            'If TypeOf c Is RadioButton Then
            '    If c.Checked = True Then
            '        c.BackColor = Color.LimeGreen
            '        c.font = New Font("Times New Roman", 12, FontStyle.Bold)
            '    Else
            '        c.BackColor = Color.White
            '        c.font = New Font("Times New Roman", 10, FontStyle.Regular)
            '    End If
            If TypeOf c Is Label Then
                If Mid(c.Name, 1, 3) = "Lbl" Then
                    If CDbl(Val(c.Text)) > 0 Then
                        c.ForeColor = Color.Green
                        c.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                    Else
                        c.ForeColor = Color.Black
                        c.Font = New Font("Times New Roman", 6, FontStyle.Regular)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub Filtr()
        Dim FltrStr As String = ""
        TempData = MyUsrsTable.DefaultView

        If UsrStr.Length > 0 Then
            FltrStr = UsrStr
        End If
        If FltrStr.Length > 0 Then
            '" and" & "[UsrRealNm]" & " = '" & String.Empty & "'"
            If RwCnt > 0 Then FltrStr &= " OR" & " [UsrRealNm] IS NULL "
            MyUsrsTable.DefaultView.RowFilter = FltrStr
        Else
            MyUsrsTable.DefaultView.RowFilter = String.Empty
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterSelect
        UsrStr = ""
        If UserTree.SelectedNode.Nodes.Count > 0 Then
            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTree.SelectedNode.Name.ToString, True)
                If UserTree.SelectedNode.Name.ToString = UserTable(Cnt_).Item(2).ToString Then
                    UsrStr &= "UsrId = " & UserTable(Cnt_).Item(0).ToString & " OR "
                End If
            Next Cnt_
            If UsrStr.Length > 0 Then
                If UsrStr.Length > 0 Then UsrStr = "(" & Mid(UsrStr, 1, UsrStr.Length - 4) & ")" Else UsrStr = ""
            Else
                UsrStr = ""
            End If
        Else
            UsrStr = " (UsrId = " & Split(UserTree.SelectedNode.Text, "-")(0) & ")"
        End If
        Filtr()
        Cal_()
    End Sub
    Private Sub GridTicket_SelectionChanged(sender As Object, e As EventArgs) Handles GridTicket1.SelectionChanged
        If GridTicket1.SelectedCells.Count > 0 Then
            StatBrPnlEn.Text = GridTicket1.CurrentRow.Index + 1 & " Of " & GridTicket1.Rows.Count.ToString("N0")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MyUsrsTable.DefaultView.RowFilter = String.Empty
        Cal_()
    End Sub
End Class