Imports System.Data.SqlClient

Public Class PostalExt
    Dim Maintbl As New DataTable
    Dim Insurnce As Integer = 0
    Dim Whight_Txt As Double = 0
    Dim Strng As String = ""
    Dim TotCost As Double = 0
    Dim NetCost As Double = 0
    Dim Taax As Double = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv1.Columns(8).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        If GetTbl("select * from Postal_Ext order by Country", Maintbl, "0000&H") = Nothing Then
            For ff = 0 To Maintbl.Rows.Count - 1
                Dim rr As Integer = 0
                If Maintbl.Rows(ff).Item(3) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(6) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(9) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(14) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(19) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(26) = 0 Then rr += 1
                If Maintbl.Rows(ff).Item(33) = 0 Then rr += 2
                Maintbl.Rows(ff).Item(1) &= " | " & rr & " خدمات"
            Next
            If populComb(cbxCountry, Maintbl, "Country", "ID") = Nothing Then
            End If
        End If
        cbxCountry.ResetText()
        dgv1.Visible = False
        rdoKG.Checked = True
        rdoKG.ForeColor = Color.Green
        dgv1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        AddHandler cbxCountry.SelectedIndexChanged, AddressOf CbxCountry_SelectedIndexChanged
        AddHandler txtwight.TextChanged, AddressOf Txtwight_TextChanged
        AddHandler RdoGram.Click, AddressOf RdoGram_Click
        AddHandler rdoKG.Click, AddressOf RdoGram_Click
    End Sub
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
    Private Sub FilTxtBxs()
        If dgv1.Rows.Count = 0 Then dgv1.Rows.Add(8)
        If cbxCountry.SelectedIndex <> -1 Or Val(txtwight.Text) <> 0 Then
            dgv1.Rows(0).Cells(0).Value = "البريد السريع الدولي  " & Chr(34) & " أول وزنه 500 جرام" & Chr(34)
            dgv1.Rows(0).Cells(0).Tag = "EMS"
            txtContinent.Text = Maintbl.Rows(cbxCountry.SelectedIndex).Item("Continent")
            txtcoun.Text = Maintbl.Rows(cbxCountry.SelectedIndex).Item("ID")
            dgv1.Rows(0).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("StEMS")
            dgv1.Rows(0).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxEMS500KG")
            dgv1.Rows(0).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rpEMS")
            dgv1.Rows(0).Cells(6).Value = 2
            dgv1.Rows(0).Cells(2).Value = "30"

            dgv1.Rows(1).Cells(0).Value = "Express Parcel" & Chr(34) & " أول وزنه 500 جرام" & Chr(34)
            dgv1.Rows(1).Cells(0).Tag = "EXP"
            dgv1.Rows(1).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("StExPr")
            dgv1.Rows(1).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxExPr500g")
            dgv1.Rows(1).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rptExPr")
            dgv1.Rows(1).Cells(6).Value = 3
            dgv1.Rows(1).Cells(2).Value = "30"

            dgv1.Rows(2).Cells(0).Value = "بريد عادي / جوي" & Chr(34) & " أول وزنه 1 كجم" & Chr(34)
            dgv1.Rows(2).Cells(0).Tag = "NormalAir"
            dgv1.Rows(2).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("StAirPr")
            dgv1.Rows(2).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirPr1KG")
            dgv1.Rows(2).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rpAirPr")
            dgv1.Rows(2).Cells(6).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("InsureAirPr")
            dgv1.Rows(2).Cells(2).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("MxKgAirPr")
            dgv1.Rows(2).Cells(5).Value = 0

            dgv1.Rows(3).Cells(0).Value = "بريد عادي / سطحي" & Chr(34) & " أول وزنه 1 كجم" & Chr(34)
            dgv1.Rows(3).Cells(0).Tag = "NormalSurf"
            dgv1.Rows(3).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("StSuPr")
            dgv1.Rows(3).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSuPr1kg")
            dgv1.Rows(3).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rpSuPr")
            dgv1.Rows(3).Cells(6).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("InsureSuPr")
            dgv1.Rows(3).Cells(2).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("MxSuPr")
            dgv1.Rows(3).Cells(5).Value = 0

            dgv1.Rows(4).Cells(0).Value = "MBag / جوي" & Chr(34) & " أول وزنه 5 كيلوجرام" & Chr(34)
            dgv1.Rows(4).Cells(0).Tag = "BagAir"
            dgv1.Rows(4).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("stMBag")
            dgv1.Rows(4).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxMBag5k1")
            dgv1.Rows(4).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rpMBag5k1")
            dgv1.Rows(4).Cells(2).Value = "--"
            dgv1.Rows(4).Cells(5).Value = 0
            dgv1.Rows(4).Cells(6).Value = 0

            dgv1.Rows(5).Cells(0).Value = "MBag / سطحي" & Chr(34) & " أول وزنه 5 كيلوجرام" & Chr(34) 'Maintbl.Rows(cbxCountry.SelectedIndex).Item("Coun")
            dgv1.Rows(5).Cells(0).Tag = "BagSurf"
            dgv1.Rows(5).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("stMBag")
            dgv1.Rows(5).Cells(3).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxMBag5k2")
            dgv1.Rows(5).Cells(4).Value = Maintbl.Rows(cbxCountry.SelectedIndex).Item("rpMBag5k2")
            dgv1.Rows(5).Cells(2).Value = "--"
            dgv1.Rows(5).Cells(5).Value = 0
            dgv1.Rows(5).Cells(6).Value = 0

            dgv1.Rows(6).Cells(0).Tag = "SmplSurf"
            dgv1.Rows(6).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("stAirSamp")
            dgv1.Rows(6).Cells(0).Value = "رسائل / عينات سطحي"
            dgv1.Rows(7).Cells(0).Tag = "SmplAir"
            dgv1.Rows(7).Cells(2).Tag = Maintbl.Rows(cbxCountry.SelectedIndex).Item("stSurSamp")
            dgv1.Rows(7).Cells(0).Value = "رسائل / عينات جوي"
            dgv1.Rows(6).Cells(2).Value = "عينات"
            dgv1.Rows(7).Cells(2).Value = "عينات"
            dgv1.Rows(6).Cells(5).Value = 0
            dgv1.Rows(7).Cells(5).Value = 0
            dgv1.Rows(6).Cells(6).Value = 0
            dgv1.Rows(7).Cells(6).Value = 0
            dgv1.Rows(7).Cells(4).Value = 0
            dgv1.Rows(6).Cells(4).Value = 0
        End If
    End Sub
    Private Sub ST()
        If cbxCountry.SelectedIndex <> -1 Then
            For Cnt_ = 0 To dgv1.Rows.Count - 1
                If dgv1.Rows(Cnt_).Cells(2).Tag = "0" Then
                    dgv1.Rows(Cnt_).Cells(1).Value = My.Resources.Yes
                Else
                    dgv1.Rows(Cnt_).Cells(1).Value = My.Resources.NO
                End If
            Next
        End If
    End Sub
    Private Sub CalAshraf()
        If cbxCountry.Text.Length > 0 And cbxCountry.SelectedIndex <> -1 And Val(txtwight.Text) > 0 Then
            FilTxtBxs()
            ST()
            For Cnt_ = 0 To dgv1.Rows.Count - 1
                Insurnce = 0
                Whight_Txt = Val(txtwight.Text)
                Strng = ""
                TotCost = 0
                NetCost = 0
                Taax = 0
                If RdoGram.Checked = True Then
                    Whight_Txt /= 1000
                End If
                If dgv1.Rows(Cnt_).Cells(2).Tag = "0" Then
                    Strng = "- الخدمة متاحة"
                    dgv1.Rows(Cnt_).Cells(8).Style.ForeColor = Color.Green
                    If IsNumeric(dgv1.Rows(Cnt_).Cells(2).Value) = True Then
                        If Val(Whight_Txt) <= Val(dgv1.Rows(Cnt_).Cells(2).Value) Then
                            CALLLLLL(Cnt_)
                        Else
                            Strng &= vbNewLine & "- تعديت الحد الأقصى"
                            dgv1.Rows(Cnt_).Cells(8).Style.ForeColor = Color.Red
                            TotCost = 0
                            Taax = 0
                        End If
                    Else
                        CALLLLLL(Cnt_)
                    End If
                Else
                    Strng = "- الخدمة غير متاحة"
                    dgv1.Rows(Cnt_).Cells(8).Style.ForeColor = Color.Red
                    TotCost = 0
                    Taax = 0
                End If
                dgv1.Rows(Cnt_).Cells(5).Value = Taax
                NetCost = TotCost + Taax + Insurnce
                dgv1.Rows(Cnt_).Cells(7).Value = Convert.ToDecimal(NetCost)
                dgv1.Rows(Cnt_).Cells(8).Value = Strng
            Next Cnt_
            Label6.Text = ""
            dgv1.Visible = True
        Else
            txtwight.Text = 0
            txtwight.SelectAll()
            dgv1.Visible = False
            Label6.Text = "برجاء اختيار الدولة وإدخال الوزن"
            txtContinent.Text = ""
            txtcoun.Text = ""
        End If
        dgv1.AutoResizeColumns()
        dgv1.AutoResizeRows()

    End Sub
    Private Function CALLLLLL(DD As Integer) As String
        Dim CalRslt As String = Nothing
        Try
#Region ""
            If dgv1.Rows(DD).Cells(0).Tag = "EMS" Then
#Region "EMS"
                If Whight_Txt - Int(Whight_Txt) > 0 And Whight_Txt - Int(Whight_Txt) <= 0.5 Then
                    TotCost = (Int(Whight_Txt) * 2) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                Else
                    TotCost = ((Math.Round(Val(Whight_Txt), 0) * 2) - 1) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                End If
                Taax = TotCost * 0.14
                Insurnce = 2
#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "EXP" Then
#Region "Express Parcel"
                If Whight_Txt - Int(Whight_Txt) > 0 And Whight_Txt - Int(Whight_Txt) <= 0.5 Then
                    TotCost = ((Int(Whight_Txt)) * 2) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                Else
                    TotCost = ((Math.Round(Val(Whight_Txt), 0) * 2) - 1) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                End If
                Taax = TotCost * 0.14
                Insurnce = 3
#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "NormalAir" Then
#Region "بريد عادي / جوي"
                Strng &= vbNewLine & "- اذا كان العميل يريدة مسجل يتم اضافة 35 جنية على الاجمالي"
                If Whight_Txt - Int(Whight_Txt) > 0 Then
                    TotCost = (Int(Whight_Txt) * dgv1.Rows(DD).Cells(4).Value) + dgv1.Rows(DD).Cells(3).Value
                Else
                    TotCost = ((Int(Whight_Txt) - 1) * dgv1.Rows(DD).Cells(4).Value) + dgv1.Rows(DD).Cells(3).Value
                End If
#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "NormalSurf" Then
#Region "بريد عادي / سطحي"
                Strng &= vbNewLine & "- اذا كان العميل يريدة مسجل يتم اضافة 35 جنية على الاجمالي"
                If Whight_Txt - Int(Whight_Txt) > 0 Then
                    TotCost = Int(Whight_Txt) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                Else
                    TotCost = (Int(Whight_Txt) - 1) * dgv1.Rows(DD).Cells(4).Value + dgv1.Rows(DD).Cells(3).Value
                End If
#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "SmplSurf" Then
#Region "رسائل / عينات سطحي"
                If Whight_Txt * 1000 <= 2000 Then
                    If Val(Whight_Txt) * 1000 > 0 And Val(Whight_Txt) * 1000 <= 20 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp20g")
                    ElseIf Val(Whight_Txt) * 1000 > 20 And Val(Whight_Txt) * 1000 <= 100 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp100g")
                    ElseIf Val(Whight_Txt) * 1000 > 100 And Val(Whight_Txt) * 1000 <= 250 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp250g")
                    ElseIf Val(Whight_Txt) * 1000 > 250 And Val(Whight_Txt) * 1000 <= 500 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp500g")
                    ElseIf Val(Whight_Txt) * 1000 > 500 And Val(Whight_Txt) * 1000 <= 1000 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp1kg")
                    ElseIf Val(Whight_Txt) * 1000 > 1000 And Val(Whight_Txt) * 1000 <= 2000 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxSurSamp2kg")
                    End If
                    TotCost += 15
                Else
                    TotCost = 0
                    Strng &= vbNewLine & "- لقد تعديت الحد الأقصى"
                    dgv1.Rows(DD).Cells(8).Style.ForeColor = Color.Red
                End If

#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "SmplAir" Then
#Region "رسائل / عينات جوي"
                If Whight_Txt * 1000 <= 2000 Then
                    If Val(Whight_Txt) * 1000 > 0 And Val(Whight_Txt) * 1000 <= 20 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp20g")
                    ElseIf Val(Whight_Txt) * 1000 > 20 And Val(Whight_Txt) * 1000 <= 100 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp100g")
                    ElseIf Val(Whight_Txt) * 1000 > 100 And Val(Whight_Txt) * 1000 <= 250 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp250g")
                    ElseIf Val(Whight_Txt) * 1000 > 250 And Val(Whight_Txt) * 1000 <= 500 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp500g")
                    ElseIf Val(Whight_Txt) * 1000 > 500 And Val(Whight_Txt) * 1000 <= 1000 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp1kg")
                    ElseIf Val(Whight_Txt) * 1000 > 1000 And Val(Whight_Txt) * 1000 <= 2000 Then
                        TotCost = Maintbl.Rows(cbxCountry.SelectedIndex).Item("fxAirSamp2kg")
                    End If
                    TotCost += 15
                Else
                    TotCost = 0
                    Strng &= vbNewLine & "- لقد تعديت الحد الأقصى"
                    dgv1.Rows(DD).Cells(8).Style.ForeColor = Color.Red
                End If

#End Region
            ElseIf dgv1.Rows(DD).Cells(0).Tag = "BagAir" Or dgv1.Rows(DD).Cells(0).Tag = "BagSurf" Then
#Region "MBag / جوي  & MBag / سطحي"
                Strng &= vbNewLine & "خدمة لنقل الكتب اقل وزن 5 كجم"
                If Val(Whight_Txt) >= 5 Then
                    'AirMBag
                    If (Whight_Txt / 5) - Int(Whight_Txt / 5) >= 0 Then
                        TotCost = Convert.ToDecimal(Val((Int(Whight_Txt / 5) * dgv1.Rows(DD).Cells(4).Value) + dgv1.Rows(DD).Cells(3).Value))
                    Else
                        TotCost = Convert.ToDecimal(Val((((Whight_Txt / 5) - 1) * dgv1.Rows(DD).Cells(4).Value) + dgv1.Rows(DD).Cells(3).Value))
                    End If
                Else
                    TotCost = Convert.ToDecimal(Int(Val(Whight_Txt) * 5 / Val(Whight_Txt) / 5) * Val(dgv1.Rows(DD).Cells(3).Value))
                End If
#End Region
            End If
#End Region
        Catch ex As Exception
            CalRslt = "X"
            MsgBox(ex.Message)
        End Try
        Return CalRslt
    End Function
    Private Sub Txtwight_TextChanged(sender As Object, e As EventArgs)
        CalAshraf()
    End Sub
    Private Sub CbxCountry_SelectedIndexChanged(sender As Object, e As EventArgs)
        CalAshraf()
        txtwight.Focus()
        txtwight.SelectAll()
    End Sub
    Private Sub RdoGram_Click(sender As Object, e As EventArgs)
        CalAshraf()
        If rdoKG.Checked = True Then
            Label4.Text = "الوزن المطلوب بالكيلو :"
            rdoKG.ForeColor = Color.Green
            RdoGram.ForeColor = Color.Black
        ElseIf RdoGram.Checked = True Then
            Label4.Text = "الوزن المطلوب بالجرام :"
            rdoKG.ForeColor = Color.Black
            RdoGram.ForeColor = Color.Green
        End If
    End Sub
    Private Sub Txtwight_Click(sender As Object, e As EventArgs) Handles txtwight.Click
        txtwight.SelectAll()
    End Sub
    Private Sub cbxCountry_Enter(sender As Object, e As EventArgs) Handles cbxCountry.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
