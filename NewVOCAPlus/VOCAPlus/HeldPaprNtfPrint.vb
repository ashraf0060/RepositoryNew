Public Class HeldPaprNtfPrint
    Dim HeldTable As DataTable = New DataTable
    Dim rwindx As Integer = 0
    Dim Ntf1 As Integer = 0
    Dim NTF2 As Integer = 0
    Dim NTF3 As Integer = 0
    Dim Prntd As String = ""
    Dim dataSet_ As New HeldaperPrnt
    Dim PintTbl As New DataTable
    Dim datasource As ReportDataSource
    'Dim sqlCon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=ntf;Password=@asdasdasd123321") ' I Have assigned conn STR here and delete this row from all project
    'Dim sqlCon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    Private Sub HeldPhPool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        RdioPaperAll.Checked = True
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()

        If GetTbl("SELECT MAX(RsvAdDate) AS MaxDt FROM RsvAd", tempTable, "0000&H") = Nothing Then
            DateTimePicker1.MaxDate = tempTable.Rows(0).Item(0)
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("SELECT MIN(RsvAdDate) AS MinDt FROM RsvAd", tempTable, "0000&H") = Nothing Then
                DateTimePicker1.MinDate = tempTable.Rows(0).Item(0)
                If Format(ServrTime(), "yyyy/MM/dd") <= DateTimePicker1.MaxDate Then
                    DateTimePicker1.Value = Format(ServrTime(), "yyyy/MM/dd")
                Else
                    DateTimePicker1.Value = DateTimePicker1.MaxDate
                End If
                GridPHHeld.Width = Me.Width - 50
                CloseBtn.Location = New Point(Me.Width - 80, CloseBtn.Location.Y)
                FilPhPool()
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If



    End Sub
    Private Sub BtnPrv_Click(sender As Object, e As EventArgs) Handles BtnPrv.Click
        Dim Prv As New Form
        Dim ddd As New ReportViewer
        Prv.Controls.Add(ddd)
        ddd.Dock = DockStyle.Fill
        ddd.PageCountMode = PageCountMode.Actual
        ddd.RightToLeft = RightToLeft.No
        ddd.ShowExportButton = False
        With ddd.LocalReport
            .ReportEmbeddedResource = "VOCAPlus.Held.rdlc"
            .DataSources.Clear()
        End With
        datasource = New ReportDataSource("HeldaperPrnt", PintTbl)
        ddd.LocalReport.DataSources.Add(datasource)
        Prv.Text = "عدد الإخطارات : " & GridPHHeld.Rows.Count & " ( " & Ntf1 & " إخطار أول " & "- " & NTF2 & " إخطار ثاني " & "- " & NTF3 & " إخطار ثالث )"

        ddd.RefreshReport()
        ddd.LocalReport.Refresh()
        Prv.WindowState = FormWindowState.Maximized
        ddd.SetDisplayMode(DisplayMode.PrintLayout)
        Prv.RightToLeftLayout = True
        Prv.RightToLeft = RightToLeft.Yes
        ddd.RightToLeft = RightToLeft.Yes
        Prv.ShowDialog()

        Prv = Nothing
        ddd = Nothing
        GC.Collect()
    End Sub
    Private Sub FilPhPool()
        RemoveHandler GridPHHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
        GridPHHeld.Visible = False
        Ntf1 = 0
        NTF2 = 0
        NTF3 = 0
        Dim EmtyTrck As Integer = 0

        LblLoad.Visible = True
        Me.Text = "جاري تحميل البيانات ......."
        LblLoad.Text = "جاري تحميل البيانات ......."
        LblLoad.Refresh()
        PintTbl.Rows.Clear()
        GetTbl("SELECT AllTbl.[1P] As Frst,AllTbl.[1PH] As ph1,AllTbl.[2P] As Scnd,AllTbl.[2PH] As ph2,AllTbl.[3P] As thrd,AllTbl.ORGN,AllTbl.RsvTracing,AllTbl.RsvWeight,AllTbl.RsvConsignee,AllTbl.RsvMob,AllTbl.RsvAdd,AllTbl.RsvType,AllTbl.RsvType1,AllTbl.RsvDoc,AllTbl.RsvReason, format(AllTbl.RsvDate,'yyyy/MM/dd') As RsvDate, Format(RsvAd.RsvAdDate,'yyyy/MM/dd') As AddDt,RsvAd.RsvAdNo,(SELECT UsrRealNm FROM dbo.Int_user AS Int_user_ WHERE (Usrid = dbo.RsvAd.RsvAdEmpNm)) AS AdUsr, RsvAd.RsvAdReln, RsvAd.RsvAdTrk,
                                        CASE WHEN AllTbl.RsvType = 3 or  AllTbl.RsvType = 2 THEN CASE WHEN AllTbl.[1P] IS NOT NULL THEN 'نحيط سيادتكم علما بأنه قد تم إخطاركم ورقياً مسبقا كاخطار اول بتاريخ ' + AllTbl.[1P] ELSE 'نحيط سيادتكم علما بأنه قد تم إخطاركم هاتفياً مسبقا كاخطار اول بتاريخ ' + AllTbl.[1PH] END else '' END As FirstNtf, 
                                        CASE WHEN AllTbl.RsvType = 3 THEN CASE WHEN AllTbl.[2P] IS NOT NULL THEN ' و كذلك كإخطار ورقي ثان بتاريخ ' + AllTbl.[2P] ELSE ' و كذلك كإخطار هاتفي ثان بتاريخ ' + AllTbl.[2PH] END else '' END As ScndNtf, 
                                        CASE WHEN AllTbl.RsvType = 3 THEN ' وقد وصلكم منا هذا الإخطار الثالث والأخير كتابيا لعدم وصول المستندات المطلوبة لبدء التخليص الجمركي.'  WHEN AllTbl.RsvType = 2 THEN ' وقد وصلكم منا هذا الإخطار الثاني كتابيا لعدم وصول المستندات المطلوبة لبدء التخليص الجمركي. ' else ''  END  As LstTxt FROM (
                                        SELECT * , (SELECT CounNm FROM dbo.CDCountry WHERE (CounCd = dbo.Rsv.RsvOrgin)) AS ORGN FROM (SELECT RsvAdReln,  [الأول] As '1P',[Phone1] As '1PH',[Phone2] As '2PH', [الثاني] As '2P', [الثالث] As '3P' 
                                        FROM (SELECT RsvAdReln, format(RsvAdDate,'yyyy/MM/dd') As RsvAdDate, RsvAdNo FROM RsvAd )  ps 
                                        PIVOT (MAX(RsvAdDate) FOR RsvAdNo IN ([الأول],[الثاني],[الثالث],[Phone1],[Phone2])) As pvt) AS Adtbl
                                        INNER JOIN     dbo.Rsv ON dbo.Rsv.RsvID = Adtbl.RsvAdReln) AS AllTbl INNER JOIN RsvAd ON RsvAd.RsvAdReln = AllTbl.RsvAdReln WHERE  (format(RsvAd.RsvAdDate, 'yyyy/MM/dd') = '" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & "') AND (RsvAd.RsvType = N'1') " & Prntd & "
                                        ORDER By RsvAd.RsvAdReln", PintTbl, "0000&H")
        Try
            GridPHHeld.DataSource = PintTbl
            If PintTbl.Rows.Count > 0 Then
                AddHandler GridPHHeld.SelectionChanged, AddressOf GridPHHeld_SelectionChanged
                GridPHHeld.Visible = True
                For pp = 0 To GridPHHeld.Rows.Count - 1
                    If GridPHHeld.Rows(pp).Cells(17).Value = "الأول" Then
                        Ntf1 += 1
                        GridPHHeld.Rows(pp).DefaultCellStyle.BackColor = Color.White
                    ElseIf GridPHHeld.Rows(pp).Cells(17).Value = "الثاني" Then
                        NTF2 += 1
                        GridPHHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AliceBlue
                    ElseIf GridPHHeld.Rows(pp).Cells(17).Value = "الثالث" Then
                        NTF3 += 1
                        GridPHHeld.Rows(pp).DefaultCellStyle.BackColor = Color.AntiqueWhite
                    End If
                    If DBNull.Value.Equals(GridPHHeld.Rows(pp).Cells(0).Value) = False Then
                        If GridPHHeld.Rows(pp).Cells(0).Value = DateTimePicker1.Value Then
                            GridPHHeld.Rows(pp).Cells(0).Style.BackColor = Color.GreenYellow
                        End If
                    End If
                    If DBNull.Value.Equals(GridPHHeld.Rows(pp).Cells(2).Value) = False Then
                        If GridPHHeld.Rows(pp).Cells(2).Value = DateTimePicker1.Value Then
                            GridPHHeld.Rows(pp).Cells(2).Style.BackColor = Color.GreenYellow
                        End If
                    End If
                    If DBNull.Value.Equals(GridPHHeld.Rows(pp).Cells(4).Value) = False Then
                        If GridPHHeld.Rows(pp).Cells(4).Value = DateTimePicker1.Value Then
                            GridPHHeld.Rows(pp).Cells(4).Style.BackColor = Color.GreenYellow
                        End If
                    End If
                    If DBNull.Value.Equals(GridPHHeld.Rows(pp).Cells(20).Value) = True Or GridPHHeld.Rows(pp).Cells(20).Value.ToString.Length = 0 Then
                        EmtyTrck += 1
                    End If
                Next
                If EmtyTrck > 0 Then
                    BtnPrv.Enabled = False
                    MsgInf("لم يتم ادخال عدد " & EmtyTrck & " باركود" & vbNewLine & "يرجى استكمال باقي البيانات أولاً حتى يتم تمكين الطباعة")
                Else
                    BtnPrv.Enabled = True
                End If
                LblLoad.Visible = False
            Else
                BtnPrv.Enabled = False
                LblLoad.Text = "لا توجد بيانات للعرض"
                LblLoad.Refresh()
            End If

            Me.Text = "طباعة الإخطارات : " & GridPHHeld.Rows.Count & " ( " & Ntf1 & " إخطار أول " & "- " & NTF2 & " إخطار ثاني " & "- " & NTF3 & " إخطار ثالث )"
            If GridPHHeld.SelectedCells.Count > 0 Then
                GridPHHeld.Rows(0).Selected = True
                LblMsg.Text = GridPHHeld.CurrentRow.Index + 1 & " Of " & GridPHHeld.Rows.Count.ToString("N0")
                LblMsg.Refresh()
            End If
            GridPopulte()
        Catch ex As Exception
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try

    End Sub
    Private Sub GridPopulte()
        LblMsg.ForeColor = Color.Green

        GridPHHeld.Columns(0).HeaderText = "ورقي أول"
        GridPHHeld.Columns(1).HeaderText = "تليفوني أول"
        GridPHHeld.Columns(2).HeaderText = "ورقي ثاني"
        GridPHHeld.Columns(3).HeaderText = "تليفوني ثاني"
        GridPHHeld.Columns(4).HeaderText = "ورقي ثالث"
        GridPHHeld.Columns(5).HeaderText = "بلد المنشأ"
        GridPHHeld.Columns(6).HeaderText = "رقم الشحنة"
        GridPHHeld.Columns(7).Visible = False                         ' "الوزن"
        GridPHHeld.Columns(8).HeaderText = "اسم العميل"
        GridPHHeld.Columns(9).HeaderText = "التليفون"
        GridPHHeld.Columns(10).HeaderText = "العنوان"
        GridPHHeld.Columns(11).HeaderText = "عدد الإخطارات"
        GridPHHeld.Columns(12).Visible = False                         ' "المطلوب"

        GridPHHeld.Columns(13).Visible = False                        ' "حالة الشحنة"
        GridPHHeld.Columns(14).Visible = False                        ' "محتويات الشحنة"
        GridPHHeld.Columns(15).HeaderText = "تاريخ الحجز"
        GridPHHeld.Columns(16).HeaderText = "تاريخ الإخطار"
        GridPHHeld.Columns(17).Visible = False                        ' "ترتيب الإخطار"
        GridPHHeld.Columns(18).HeaderText = "محرر الإخطار"
        GridPHHeld.Columns(19).HeaderText = "ID"
        GridPHHeld.Columns(20).HeaderText = "رقم الإخطار"
        GridPHHeld.Columns(21).Visible = False ' "Txt 1"
        GridPHHeld.Columns(22).Visible = False ' "Txt2"
        GridPHHeld.Columns(23).Visible = False ' "TxtLst"


        GridPHHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridPHHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        'GridPHHeld.AutoResizeColumns()
        'GridPHHeld.Columns(8).Width = 300
        'GridPHHeld.Columns(10).Width = 400
        For yy = 0 To GridPHHeld.Columns.Count - 1
            GridPHHeld.Columns(yy).ReadOnly = True
            GridPHHeld.Columns(yy).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub GridPHHeld_SelectionChanged(sender As Object, e As EventArgs)
        LblMsg.Text = GridPHHeld.CurrentRow.Index + 1 & " Of " & GridPHHeld.Rows.Count.ToString("N0")
        LblMsg.Refresh()
    End Sub
    Private Sub Ntf_SelectionChanged(sender As Object, e As EventArgs)
        If GridPHHeld.Rows.Count > 0 Then
            LblMsg.Text = GridPHHeld.Rows(rwindx).Index + 1 & " Of " & GridPHHeld.Rows.Count.ToString("N0")
            LblMsg.Refresh()
        Else
            LblMsg.Text = 0 & " Of " & 0
            LblMsg.Refresh()
        End If

    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        'AddHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged   
        FilPhPool()
        'Call DateTimePicker1_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub DateTimePicker1_Enter(sender As Object, e As EventArgs) Handles DateTimePicker1.MouseEnter
        'RemoveHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged
    End Sub

    Private Sub RdioPaperAll_CheckedChanged(sender As Object, e As EventArgs) Handles RdioPaperAll.Click, RdioPapNoPrnt.Click, RdioPapPrnt.Click
        If RdioPapPrnt.Checked = True Then
            Prntd = " AND (RsvAd.RsvAdPrint = 1)"
        ElseIf RdioPapNoPrnt.Checked = True Then
            Prntd = " AND (RsvAd.RsvAdPrint = 0)"
        ElseIf RdioPaperAll.Checked = True Then
            Prntd = ""
        End If
        FilPhPool()
    End Sub
End Class