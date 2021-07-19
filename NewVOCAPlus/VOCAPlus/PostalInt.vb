
Public Class PostalInt
    Dim tblFrm As New DataTable
    Dim tblSamp As New DataTable
    Dim DtaRw As DataRow
    Dim PriKy(0) As DataColumn
    Dim Insurnce As Double = 0
    Dim Whight_Txt As Double = 0
    Dim Strng As String = ""
    Dim TotCost As Double = 0
    Dim NetCost As Double = 0
    Dim Taax As Double = 0
    Private Function GetTbl1(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlCon.ConnectionString = strConn
        sqlComm.CommandTimeout = 90
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            WelcomeScreen.TimerCon.Start()
            WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
            AppLog(ErrHndl, ex.Message, SSqlStr)
            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
    Private Function populComb(Comb As ComboBox, CompTbl As DataTable, disp As String, val As String) As String
        Dim X As String = Nothing
        Try
            Comb.DataSource = CompTbl
            Comb.DisplayMember = disp
            Comb.ValueMember = val
        Catch ex As Exception
            X = "Err"
        End Try
        Return X
    End Function
    Private Sub PostalInt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        dgv1.Rows.Add(5)
        rdoKG.Checked = True
        'strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=DBEgyptPost;User ID=sa;Password=Hemonad105046"
        'sqlCon.ConnectionString = strConn
        GetTbl("select * from PostalInt", tblFrm, "0000&H")
        GetTbl("select * from PostalIntSamp", tblSamp, "0000&H")
        PriKy(0) = tblFrm.Columns("Area")
        tblFrm.PrimaryKey = PriKy
        populComb(cbxFrom, tblFrm, "Area", "IDins")
#Region "تغيير اسم الأعمدة"
        tblFrm.Columns(2).ColumnName = "القاهرة"
        tblFrm.Columns(3).ColumnName = "الجيزة"
        tblFrm.Columns(4).ColumnName = "الأسكندرية"
        tblFrm.Columns(5).ColumnName = "البحيرة"
        tblFrm.Columns(6).ColumnName = "القليوبية"
        tblFrm.Columns(7).ColumnName = "الغربية"
        tblFrm.Columns(8).ColumnName = "المنوفية"
        tblFrm.Columns(9).ColumnName = "دمياط"
        tblFrm.Columns(10).ColumnName = "الدقهلية"
        tblFrm.Columns(11).ColumnName = "كفر الشيخ"
        tblFrm.Columns(12).ColumnName = "مرسى مطروح"
        tblFrm.Columns(13).ColumnName = "الإسماعيلية"
        tblFrm.Columns(14).ColumnName = "السويس"
        tblFrm.Columns(15).ColumnName = "بورسعيد"
        tblFrm.Columns(16).ColumnName = "الشرقية"
        tblFrm.Columns(17).ColumnName = "الفيوم"
        tblFrm.Columns(18).ColumnName = "بني سويف"
        tblFrm.Columns(19).ColumnName = "المنيا"
        tblFrm.Columns(20).ColumnName = "أسيوط"
        tblFrm.Columns(21).ColumnName = "سوهاج"
        tblFrm.Columns(22).ColumnName = "قنا"
        tblFrm.Columns(23).ColumnName = "أسوان"
        tblFrm.Columns(24).ColumnName = "الأقصر"
        tblFrm.Columns(25).ColumnName = "البحر الأحمر"
        tblFrm.Columns(26).ColumnName = "الوادي الجديد"
        tblFrm.Columns(27).ColumnName = "جنوب سينا"
        tblFrm.Columns(28).ColumnName = "شمال سينا"
#End Region
#Region "Populate ComboTo"
        For cnt = 0 To tblFrm.Columns.Count - 1
            If cnt > 1 Then CbxTo.Items.Add(tblFrm.Columns(cnt).ColumnName)
        Next
#End Region
        dgv1.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv1.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        cbxFrom.ResetText()
        AddHandler cbxFrom.SelectedIndexChanged, AddressOf cbxFrom_SelectedIndexChanged
        CbxTo.Enabled = False
        If txtWeight.Text = "" Then
            txtWeight.Text = 0
        End If
    End Sub
    Private Sub fILL_()
#Region "Fill Grid"
        dgv1.Rows(0).Cells(0).Value = "البريد السريع الداخلى  " & Chr(34) & " أول وزنه 1000 جرام" & Chr(34)
        dgv1.Rows(0).Cells(0).Tag = "EMS"
        dgv1.Rows(0).Cells(1).Value = 20.ToString("n2")
        dgv1.Rows(0).Cells(3).Value = 2.ToString("n2")
        dgv1.Rows(0).Cells(5).Value = "0.50"

        dgv1.Rows(1).Cells(0).Value = "البريد العادى" & Chr(34) & " أول وزنه 1000 جرام" & Chr(34)
        dgv1.Rows(1).Cells(0).Tag = "N"
        dgv1.Rows(1).Cells(1).Value = 50.ToString("n2")
        dgv1.Rows(1).Cells(2).Value = 15.ToString("n2")
        dgv1.Rows(1).Cells(3).Value = 2.5.ToString("n2")
        dgv1.Rows(1).Cells(4).Value = "لا يوجد ضريبة"
        dgv1.Rows(1).Cells(5).Value = "لا يوجد تأمين"

        dgv1.Rows(2).Cells(0).Value = "البريد المسجل" & Chr(34) & " أول وزنه 1000 جرام" & Chr(34)
        dgv1.Rows(2).Cells(0).Tag = "R"
        dgv1.Rows(2).Cells(1).Value = 50.ToString("n2")
        dgv1.Rows(2).Cells(2).Value = 20.ToString("n2")
        dgv1.Rows(2).Cells(3).Value = 2.5.ToString("n2")
        dgv1.Rows(2).Cells(4).Value = "لا يوجد ضريبة"
        dgv1.Rows(2).Cells(5).Value = "لا يوجد تأمين"

        dgv1.Rows(3).Cells(0).Value = " رسائل / عينات " & Chr(34) & " بريد عادي" & Chr(34)
        dgv1.Rows(3).Cells(0).Tag = "SN"
        dgv1.Rows(3).Cells(1).Value = "اوزان محددة"
        dgv1.Rows(3).Cells(3).Value = "-----------"
        dgv1.Rows(3).Cells(4).Value = "لا يوجد ضريبة"
        dgv1.Rows(3).Cells(5).Value = "لا يوجد تأمين"

        dgv1.Rows(4).Cells(0).Value = " رسائل / عينات " & Chr(34) & " بريد مسجل" & Chr(34)
        dgv1.Rows(4).Cells(0).Tag = "SR"
        dgv1.Rows(4).Cells(1).Value = "اوزان محددة"
        dgv1.Rows(4).Cells(3).Value = "-----------"
        dgv1.Rows(4).Cells(4).Value = "لا يوجد ضريبة"
        dgv1.Rows(4).Cells(5).Value = "لا يوجد تأمين"
#End Region
    End Sub
    Private Sub Cal()
        If Val(txtWeight.Text) > 0 And cbxFrom.SelectedIndex > -1 And CbxTo.SelectedIndex > -1 Then
            fILL_()
            dgv1.Visible = True
            DtaRw = tblFrm.Rows.Find(cbxFrom.Text)
            dgv1.Rows(0).Cells(2).Value = DtaRw.Item(DtaRw.Table.Columns(CbxTo.Text).ColumnName)
            For UU = 0 To dgv1.Rows.Count - 1
                Insurnce = 0
                Whight_Txt = Val(txtWeight.Text)
                Strng = ""
                TotCost = 0
                NetCost = 0
                Taax = 0
                If RdoGram.Checked = True Then
                    Whight_Txt /= 1000
                End If
                If IsNumeric(dgv1.Rows(UU).Cells(1).Value) = True Then
                    If Whight_Txt <= Val(dgv1.Rows(UU).Cells(1).Value) Then
                        CALLLLLL(UU)
                        dgv1.Rows(UU).Cells(7).Style.ForeColor = Color.Green
                    Else
                        Strng &= vbNewLine + "- تعديت الحد الاقصي"
                        Insurnce = 0
                        TotCost = 0
                        Taax = 0
                        dgv1.Rows(UU).Cells(7).Style.ForeColor = Color.Red
                    End If
                Else

                    If Whight_Txt * 1000 > 500 Then
                        Strng &= vbNewLine + "- لا يمكن ارسال رسالة او عينة اكثر من 500 جرام"
                        dgv1.Rows(UU).Cells(7).Style.ForeColor = Color.Red
                        NetCost = 0
                    Else
                        CALLLLLL(UU)
                        Strng &= vbNewLine + "- يمكن ارسال الشحنه كعينه "
                        dgv1.Rows(UU).Cells(7).Style.ForeColor = Color.Green
                    End If
                End If
                dgv1.Rows(UU).Cells(7).Value = Strng
                dgv1.Rows(UU).Cells(4).Value = Taax
                NetCost = TotCost + Taax + Insurnce
                dgv1.Rows(UU).Cells(6).Value = NetCost
            Next UU
        Else
            txtWeight.Text = 0
            txtWeight.SelectAll()
            dgv1.Visible = False
        End If
        dgv1.AutoResizeColumns()
        dgv1.AutoResizeRows()
    End Sub
    Private Function CALLLLLL(DD As Integer) As String
        Dim CalRslt As String = Nothing
        Try
            Dim Rep1 As Double = 0
            Dim Rep2 As Double = 0

#Region "EMS"
            If dgv1.Rows(DD).Cells(0).Tag = "EMS" Then
                Rep1 = Int((Whight_Txt - 1) / 0.5)
                Rep2 = (((Whight_Txt - 1) / 0.5) - Int((Whight_Txt - 1) / 0.5))
                If Rep2 > 0 Then Rep1 += 1
                Strng = "- الخدمة متاحه"
                If Whight_Txt > 0 And Whight_Txt <= 1 Then
                    TotCost = dgv1.Rows(DD).Cells(2).Value
                Else
                    TotCost = dgv1.Rows(DD).Cells(2).Value + Rep1 * dgv1.Rows(DD).Cells(3).Value ' (((Val(Int(Whight_Txt)) * 2) + 1) - 2) * 2 + 2
                End If
                Insurnce = 0.5
                Taax = Convert.ToDecimal(TotCost * 0.14)
            End If
#End Region
#Region "Normal"
            If dgv1.Rows(DD).Cells(0).Tag = "N" Then
                Rep1 = Int((Whight_Txt - 1) / 1)
                Rep2 = (((Whight_Txt - 1) / 1) - Int((Whight_Txt - 1) / 1))
                If Rep2 > 0 Then Rep1 += 1
                Strng = "- الخدمة متاحه"
                If Whight_Txt > 0 And Whight_Txt <= 1 Then
                    TotCost = dgv1.Rows(DD).Cells(2).Value
                Else
                    TotCost = dgv1.Rows(DD).Cells(2).Value + Rep1 * dgv1.Rows(DD).Cells(3).Value ' (((Val(Int(Whight_Txt)) * 2) + 1) - 2) * 2 + 2
                End If
                Insurnce = 0
                Taax = 0
            End If
#End Region
#Region "Register"
            If dgv1.Rows(DD).Cells(0).Tag = "R" Then
                Rep1 = Int((Whight_Txt - 1) / 1)
                Rep2 = (((Whight_Txt - 1) / 1) - Int((Whight_Txt - 1) / 1))
                If Rep2 > 0 Then Rep1 += 1
                Strng = "- الخدمة متاحه" + vbNewLine + "- في حال رغبة العميل يضاف مبلغ 2 جنيه قيمة تسليم علم الوصول في مكتب البريد" + vbNewLine + "- في حال رغبة العميل يضاف مبلغ 5 جنيه قيمة تسليم علم الوصول لمحل الإقامة"
                If Whight_Txt > 0 And Whight_Txt <= 1 Then
                    TotCost = dgv1.Rows(DD).Cells(2).Value
                Else
                    TotCost = dgv1.Rows(DD).Cells(2).Value + Rep1 * dgv1.Rows(DD).Cells(3).Value ' (((Val(Int(Whight_Txt)) * 2) + 1) - 2) * 2 + 2
                End If
                Insurnce = 0
                Taax = 0
            End If
#End Region
#Region "Samples N"
            If dgv1.Rows(DD).Cells(0).Tag = "SN" Then
                Strng = "- الخدمة متاحه"
                If Val(Whight_Txt) * 1000 > 0 And Val(Whight_Txt) * 1000 <= 20 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor20Gram")
                End If
                If Val(Whight_Txt) * 1000 > 20 And Val(Whight_Txt) * 1000 <= 50 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor50Gram")
                End If
                If Val(Whight_Txt) * 1000 > 50 And Val(Whight_Txt) * 1000 <= 100 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor100Gram")
                End If
                If Val(Whight_Txt) * 1000 > 50 And Val(Whight_Txt) * 1000 <= 100 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor100Gram")
                End If
                If Val(Whight_Txt) * 1000 > 100 And Val(Whight_Txt) * 1000 <= 250 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor250Gram")
                End If
                If Val(Whight_Txt) * 1000 > 250 And Val(Whight_Txt) * 1000 <= 500 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Nor500Gram")
                End If
                TotCost = dgv1.Rows(DD).Cells(2).Value
            End If
#End Region
#Region "Samples R"
            If dgv1.Rows(DD).Cells(0).Tag = "SR" Then
                Strng = "- الخدمة متاحه"
                If Val(Whight_Txt) * 1000 > 0 And Val(Whight_Txt) * 1000 <= 20 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg20Gram")
                End If
                If Val(Whight_Txt) * 1000 > 20 And Val(Whight_Txt) * 1000 <= 50 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg50Gram")
                End If
                If Val(Whight_Txt) * 1000 > 50 And Val(Whight_Txt) * 1000 <= 100 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg100Gram")
                End If
                If Val(Whight_Txt) * 1000 > 50 And Val(Whight_Txt) * 1000 <= 100 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg100Gram")
                End If
                If Val(Whight_Txt) * 1000 > 100 And Val(Whight_Txt) * 1000 <= 250 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg250Gram")
                End If
                If Val(Whight_Txt) * 1000 > 250 And Val(Whight_Txt) * 1000 <= 500 Then
                    dgv1.Rows(DD).Cells(2).Value = tblSamp.Rows(0).Item("Reg500Gram")
                End If
                TotCost = dgv1.Rows(DD).Cells(2).Value
            End If
#End Region
        Catch ex As Exception
            CalRslt = "X"
            MsgBox(ex.Message)
        End Try
        Return CalRslt
    End Function
    Private Sub CbxTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTo.SelectedIndexChanged
        If Val(txtWeight.Text) > 0 Then
            Cal()
        End If
    End Sub
    Private Sub cbxFrom_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbxFrom.SelectedIndex = -1 Then
            CbxTo.Enabled = False
        Else
            CbxTo.Enabled = True
        End If
        Cal()
    End Sub
    Private Sub txtWeight_TextChanged(sender As Object, e As EventArgs) Handles txtWeight.TextChanged
        Cal()
    End Sub
    Private Sub RdoGram_CheckedChanged(sender As Object, e As EventArgs) Handles RdoGram.CheckedChanged, rdoKG.CheckedChanged
        Cal()
        If rdoKG.Checked = True Then
            lblweight.Text = "الوزن المطلوب بالكيلو :"
            rdoKG.ForeColor = Color.Green
            RdoGram.ForeColor = Color.Black
        ElseIf RdoGram.Checked = True Then
            lblweight.Text = "الوزن المطلوب بالجرام :"
            rdoKG.ForeColor = Color.Black
            RdoGram.ForeColor = Color.Green
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If rdoKG.Checked = True Then
            If rdoKG.Visible = True Then
                Timer1.Interval = 300
                rdoKG.Visible = False
            ElseIf rdoKG.Visible = False Then
                Timer1.Interval = 1500
                rdoKG.Visible = True
            End If
            RdoGram.Visible = True
        ElseIf RdoGram.Checked = True Then
            If RdoGram.Visible = True Then
                Timer1.Interval = 300
                RdoGram.Visible = False
            ElseIf RdoGram.Visible = False Then
                Timer1.Interval = 1500
                RdoGram.Visible = True
            End If
            rdoKG.Visible = True
        End If
    End Sub
End Class