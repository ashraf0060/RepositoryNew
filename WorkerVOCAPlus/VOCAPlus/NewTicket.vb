Imports System.Threading
Imports Microsoft.Exchange.WebServices.Data

Public Class NewTicket
    Dim TickKind As Integer = 0       'ticket kind      0=Inquiry and 1=Complaint
    Dim PrdKind As String = ""        'Product kind     1=Financial and 2=Postal   3=Governmental and 4=Social and 5=Other
    Dim TickKindFltr As Integer = 2   'ticket kind      0=Inquiry and 1=Complaint
    Dim TicOpnFltr As Integer = 2      'ticket Sttaus   0=Open and 1=Close and 2=All
    Dim SqlCuCnt_ As Integer = 0         'Sql of Last New Ticket
    Dim SerchTable As DataTable = New DataTable()
    Dim PrdItmTable As DataTable = New DataTable()
    Dim RelatedTable As DataTable = New DataTable
    Dim FltrStr As String = ""
    Dim DubStr As String = ""
    Dim UpdtCurrTbl As DataTable = New DataTable()
    Dim BKClr(2) As String
    Dim PrdBol As Boolean = False
    Dim TickSubmt As Thread
    Dim TickOffSubmt As Thread
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub NewTeckit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreciFlag = False Then
            Me.Close()
            WelcomeScreen.StatBrPnlAr.Text = "لم يكتمل تحميل جميع البيانات"
            Beep()
        Else
            WelcomeScreen.StatBrPnlAr.Text = ""
            CmbEvent.DataSource = UpdateKTable
            CmbEvent.DisplayMember = "EvNm"
            CmbEvent.ValueMember = "EvId"
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
            CmbEvent2.DataSource = UpdateKTable
            CmbEvent2.DisplayMember = "EvNm"
            CmbEvent2.ValueMember = "EvId"
            CmbEvent2.SelectedIndex = -1
            TxtUpdt2.ReadOnly = True
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            NewTickSub()
            'Me.Width = screenWidth - 200
            Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
            FlowLayoutPanel4.Size = New Point((Me.Size.Width * 0.6), Me.Height - 100)
            FlowLayoutPanel2.Size = New Point((Me.Size.Width * 0.2), Me.Height - 100)
            FlowLayoutPanel3.Size = New Point((Me.Size.Width * 0.16), Me.Height - 100)
            'TreeView1.Size = New Point(WelcomeScreen.Width - (FlowLayoutPanel4.Width + FlowLayoutPanel3.Width + 45), Me.Height - (130 + MyGroupBox3.Height + MyGroupBox3.Margin.Top + MyGroupBox3.Margin.Bottom))
            IDTxtBx.Focus()
        End If
    End Sub
    Private Sub NewTickSub()
        DubStr = ""
        BKClr(0) = 210
        BKClr(1) = 241
        BKClr(2) = 255
        TransDtPicker.Value = Today.AddDays(1)
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        WelcomeScreen.StatBrPnlAr.Text = ""


        TreeView1.Enabled = True
        TreeView1.Visible = False
        TreeView1.CollapseAll()

        PostalGroup.Visible = False
        FinancialGroup.Visible = False
        CombProdRef.Visible = False

        SubmitBtn.Visible = True
        SubmitBtn.Enabled = False
        BtnDublicate.Visible = False

        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Remove(TabPage4)
        TabControl1.TabPages.Remove(TabPage5)


        RelatedTable.Rows.Clear()

        For Each ctrl In TabPage1.Controls
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Then
                ctrl.Enabled = True
                ctrl.text = ""
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = True
            ElseIf TypeOf ctrl Is GroupBox Then
                ctrl.Enabled = True
                Invoke(Sub() ctrl.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2)))
            ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                For Each C In ctrl.Controls
                    If TypeOf C Is FlowLayoutPanel Then
                        For Each H In C.Controls
                            If TypeOf H Is TextBox Or TypeOf H Is MaskedTextBox Then
                                H.text = ""
                                H.Enabled = True
                            ElseIf TypeOf H Is ComboBox Then
                                H.Enabled = True
                            ElseIf TypeOf H Is GroupBox Then
                                H.Enabled = True
                                Invoke(Sub() H.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2)))
                            ElseIf TypeOf H Is Panel Then
                                For Each G In H.Controls
                                    If TypeOf G Is RadioButton Then
                                        G.Enabled = True
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
        DateTxtBx.Enabled = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton11.Checked = False
        RadioButton12.Checked = False

        Phon1TxtBx.Enabled = False
        Phon2TxtBx.Enabled = False
        ComRefLbl.Text = ""
        AreaCmbBx.SelectedIndex = -1
        OffCmbBx.SelectedIndex = -1
        DistCmbBx.SelectedIndex = -1
        SrcCmbBx.SelectedIndex = -1
        AccMskdBx.Text = ""
        IDTxtBx.Text = ""
        IDTxtBx.Mask = "00000000000000"
        RadNID.Checked = True
        GBTxtBx.Text = ""
        AmountTxtBx.Text = "0"
        TrackMskBx.Text = ""
        OriginTxtBx.Text = ""

        TickKind = 0
        PrdKind = ""

        MyGroupBox2.Enabled = False
        LblComp.Text = 0
        LblInq.Text = 0
        LblClsOp.Text = 0
        LblClsCls.Text = 0
        LblDublicate.Text = "Ticket(s) Before :"
        LblDublicate.ForeColor = Color.Black

    End Sub
    Private Sub Mendatory()
        Dim Cnt_1 As Integer = 0
        Dim MendRw As DataRow = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
        If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
            If (MendRw.ItemArray(7).Length) > 0 Then                          ' Adjust TextBox Length according to LablRef Length
                If CombProdRef.Items.Count = 0 Then
                    For Cnt_ = 0 To Split(MendRw.ItemArray(7), "-").Count - 1
                        CombProdRef.Items.Add(Split(MendRw.ItemArray(7), "-")(Cnt_))
                    Next
                    CombProdRef.Width = 35 + Split(MendRw.ItemArray(7), "-")(0).Length * 10
                    If CombProdRef.Items.Count > 0 Then CombProdRef.SelectedIndex = 0
                End If

                TrackMskBx.MaxLength = 15 - CombProdRef.Text.Length
                AccMskdBx.MaxLength = 19 - CombProdRef.Text.Length
            End If


        End If
        LblHelp.Text = MendRw.ItemArray(11).ToString
        If TickKind = 1 Then         '-----------If Complaint True ---------------
            For Cnt_ = 0 To 11
                For Each c As Control In FlowLayoutPanel4.Controls
                    If c.TabIndex <= 4 And c.TabIndex > 0 Then
                        If Trim(c.Text).Length = 0 Then
                            If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ Then
                                c.AccessibleName = "Mendatory"
                            ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ Then
                                c.AccessibleName = "None"
                            End If
                        Else
                            c.AccessibleName = "None"
                        End If
                    End If
                Next c
                For Each c As Control In FlowLayoutPanel4.Controls
                    If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = "*"
                    ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = ""
                    End If
                Next c
                For Each c As Control In FinancialGroup.Controls
                    If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = "*"
                    ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = ""
                    End If
                Next c

                For Each c As Control In PostalGroup.Controls
                    If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = "*"
                    ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ + 2001 Then
                        c.Text = ""
                    End If
                Next c
            Next Cnt_
            If Mid(MendRw.ItemArray(6), 1, 1) = "Y" Then
                Cnt_ = 0
                For Cnt_1 = 1 To 11
                    If Mid(Phon1TxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                If Cnt_ < Phon1TxtBx.TextLength Then
                    Phon1TxtBx.AccessibleName = "Mendatory"
                Else
                    Phon1TxtBx.AccessibleName = "None"
                End If
            Else
                Phon1TxtBx.AccessibleName = "None"
            End If
            If Mid(MendRw.ItemArray(6), 6, 1) = "Y" Then
                TrackMskBx.Enabled = True
                If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                    'Put ProdRef Value in Track No Start
                    TrackMskBx.Text = CombProdRef.Text + Mid(TrackMskBx.Text, CombProdRef.Text.Length + 1, 19 - CombProdRef.Text.Length + 1)
                End If

                If MendRw.ItemArray(9) = True Then
                    TrackMskBx.Mask = "LLL 00000000 LL"
                    PrdBol = True
                    If Mid(TrackMskBx.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 And Mid(TrackMskBx.Text, 3, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TrackMskBx.Text, 5, 8).CompareTo("[0-9]*") = -1 Or Mid(TrackMskBx.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TrackMskBx.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                        TrackMskBx.AccessibleName = "Mendatory"
                    Else
                        TrackMskBx.AccessibleName = "None"
                    End If
                Else
                    PrdBol = False
                    TrackMskBx.Mask = "LL 000000000 LL"
                    If Mid(TrackMskBx.Text, 2, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TrackMskBx.Text, 4, 9).CompareTo("[0-9]*") = -1 Or Mid(TrackMskBx.Text, 14, 1).CompareTo("[A-Z][a-z]*") = -1 Or Mid(TrackMskBx.Text, 15, 1).CompareTo("[A-Z][a-z]*") = -1 Then
                        TrackMskBx.AccessibleName = "Mendatory"
                    Else
                        TrackMskBx.AccessibleName = "None"
                    End If
                End If

                'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) = "ايجى ميل" Then

                'Else

                'End If

            Else
                TrackMskBx.AccessibleName = "None"
                TrackMskBx.Text = ""
                TrackMskBx.Enabled = False
                TrackMskBx.Text = ""
            End If
            If DistCmbBx.Text.Length = 0 Then
                If Mid(MendRw.ItemArray(6), 7, 1) = "Y" Then
                    DistCmbBx.AccessibleName = "Mendatory"
                Else
                    DistCmbBx.AccessibleName = "None"
                End If
            Else
                DistCmbBx.AccessibleName = "None"
            End If
            Cnt_ = 0

            If Mid(MendRw.ItemArray(6), 8, 1) = "Y" Then
                AccMskdBx.Enabled = True
                If DBNull.Value.Equals(MendRw.ItemArray(7)) = False Then
                    'Put ProdRef Value in Acc No No Start
                    AccMskdBx.Text = CombProdRef.Text + Mid(AccMskdBx.Text, CombProdRef.Text.Length + 2, 19 - CombProdRef.Text.Length + 1)
                End If

                For Cnt_1 = 1 To 19
                    If Mid(AccMskdBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                If Cnt_ < 16 Then
                    AccMskdBx.AccessibleName = "Mendatory"
                Else
                    AccMskdBx.AccessibleName = "None"
                End If
            Else
                AccMskdBx.AccessibleName = "None"
                AccMskdBx.Text = ""
                AccMskdBx.Enabled = False
                AccMskdBx.Text = ""
            End If
            If Mid(MendRw.ItemArray(6), 9, 1) = "Y" Then
                Cnt_ = 0
                For Cnt_1 = 1 To 2
                    If Mid(GBTxtBx.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                For Cnt_1 = 3 To 16
                    If Mid(GBTxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                If Cnt_ < 16 Then
                    GBTxtBx.AccessibleName = "Mendatory"
                Else
                    GBTxtBx.AccessibleName = "None"
                End If
            Else
                GBTxtBx.AccessibleName = "None"
            End If
            If Mid(MendRw.ItemArray(6), 10, 1) = "Y" Then
                Cnt_ = 0
                For Cnt_1 = 1 To 14
                    If Mid(IDTxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                If Cnt_ < 14 Then
                    IDTxtBx.AccessibleName = "Mendatory"
                Else
                    IDTxtBx.AccessibleName = "None"
                End If
            Else
                IDTxtBx.AccessibleName = "None"
            End If

            If AmountTxtBx.Text = "0" Then
                If Mid(MendRw.ItemArray(6), 11, 1) = "Y" Then
                    AmountTxtBx.AccessibleName = "Mendatory"
                Else
                    AmountTxtBx.AccessibleName = "None"
                End If
            Else
                AmountTxtBx.AccessibleName = "None"
            End If
            If TransDtPicker.Value > Today Then
                If Mid(MendRw.ItemArray(6), 12, 1) = "Y" Then
                    TransDtPicker.AccessibleName = "Mendatory"
                Else
                    TransDtPicker.AccessibleName = "None"
                End If
            Else
                TransDtPicker.AccessibleName = "None"
            End If
        Else
            For Cnt_ = 0 To 11
                For Each c As Control In TabPage1.Controls
                    If c.TabIndex > 0 And c.TabIndex <= 2 Or c.TabIndex = 4 Then
                        If c.Text.Length = 0 Then
                            If Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "Y" And c.TabIndex = Cnt_ Then
                                c.AccessibleName = "Mendatory"
                            ElseIf Mid(MendRw.ItemArray(6), Cnt_ + 1, 1) = "X" And c.TabIndex = Cnt_ Then
                                c.AccessibleName = "None"
                            End If
                        Else
                            c.AccessibleName = "None"
                        End If
                    ElseIf c.TabIndex = 3 Then
                        c.AccessibleName = "None"
                    End If
                Next c
            Next Cnt_
            If Mid(MendRw.ItemArray(6), 1, 1) = "Y" Then
                Cnt_ = 0
                For Cnt_1 = 1 To 11
                    If Mid(Phon1TxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                        Cnt_ += 1
                    End If
                Next
                If Cnt_ < Phon1TxtBx.TextLength Then
                    Phon1TxtBx.AccessibleName = "Mendatory"
                Else
                    Phon1TxtBx.AccessibleName = "None"
                End If
            Else
                Phon1TxtBx.AccessibleName = "None"
            End If
            For Each c As Control In FinancialGroup.Controls
                c.AccessibleName = "None"
            Next
            For Each c As Control In PostalGroup.Controls
                c.AccessibleName = "None"
            Next
        End If
Ckeck_:
        Dim TTT As String = ""
        Dim TTTCount As Integer = 0
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX TO TEST MENDATORY
        For Each T As Control In FlowLayoutPanel4.Controls
            If T.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & T.Tag & vbCrLf
            End If
        Next
        For Each B As Control In FinancialGroup.Controls
            If B.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & B.Tag & vbCrLf
            End If
        Next
        For Each c As Control In PostalGroup.Controls
            If c.AccessibleName = "Mendatory" Then
                TTTCount += 1
                TTT &= TTTCount & " - " & c.Tag & vbCrLf
            End If
        Next
        If TTT.Length > 0 Then
            Label18.Text = "* حقول واجبة الإدخال" & vbCrLf & "  ---------------------------" & vbCrLf & TTT & vbCrLf
        Else
            Label18.Text = ""
        End If
        If TTTCount = 0 And TreeView1.SelectedNode IsNot Nothing Then
            Me.SubmitBtn.Enabled = True
        Else
            Me.SubmitBtn.Enabled = False
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TreeView1.SelectedNode Is Nothing Then
            Label18.Text = ""
            Exit Sub
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                Mendatory()
                TmrActv.Start()
            Else
                Label18.Text = ""
                TmrActv.Stop()
            End If
        End If
    End Sub
    Private Sub RadioButto_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click, RadioButton5.Click
        ' Change Form Caption
        If PreciFlag = False Then
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            Exit Sub
        End If
        If (RadioButton4.Checked) Then
            TickKind = 0
            Me.Text = "تسجيل استفسار جديد"
        ElseIf (RadioButton5.Checked) Then
            TickKind = 1
            Me.Text = "تسجيل شكوى جديدة"
        End If

        If AreaCmbBx.Items.Count = 0 Then
            AreaCmbBx.DataSource = AreaTable
            AreaCmbBx.SelectedIndex = -1
        End If

        If OffCmbBx.Items.Count = 0 Then
            OffCmbBx.DataSource = OfficeTable
            AddHandler AreaCmbBx.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
            OffCmbBx.SelectedIndex = -1
        End If

        If SrcCmbBx.Items.Count = 0 Then
            SrcCmbBx.DataSource = CompSurceTable
            SrcCmbBx.SelectedIndex = -1
        End If

        If DistCmbBx.Items.Count = 0 Then
            DistCmbBx.DataSource = CountryTable
            DistCmbBx.SelectedIndex = -1
        End If

Popul_:
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

        TreeView1.Visible = True
        MyGroupBox2.Enabled = True
        TreeView1.SelectedNode = Nothing
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox3.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
    End Sub
    'Allow Arabic, English Characters and Number From 0 to 9 Only 
    Public Sub AESpaceNumberOnly(ByVal e As KeyPressEventArgs)  ' 
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 32 Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Arabic, English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow Arabic and English Characters Only
    Public Sub AESpacesOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) Or Asc(e.KeyChar) = 32 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Arabic and English Characters Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow English Characters and Number From 0 to 9 Only
    Public Sub ENumberOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow Real Number Only
    Sub NumberDecimalOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
            ToolTip1.ToolTipIcon = ToolTipIcon.None
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow Number Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    'Allow number from 0 to 9 Only
    Public Sub NumberOnly(ByVal e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow number from 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    Private Sub Mail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MailTxtBx.Validating
        If IntUtly.IsValidEmail(MailTxtBx.Text) Then
            ''ok
        Else
            Dim result As DialogResult _
        = MessageBox.Show("The email address you entered is not valid." &
                                   " Do you want re-enter it?", "Invalid Email Address",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.Yes Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                MailTxtBx.Text = ""
            End If
        End If
    End Sub
    Private Sub NameTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles NameTxtBx.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            NameTxtBx.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub AddTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles AddTxtBx.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            AddTxtBx.Text = Clipboard.GetText()
        End If
    End Sub
    Private Sub Phone1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.Click, RadioButton8.Click
        TimrPhons.Start()
        Phon1TxtBx.Enabled = True
        Phon1TxtBx.Text = ""
        If (RadioButton8.Checked) Then
            Phon1TxtBx.Mask = "00000000000"
        ElseIf (RadioButton9.Checked) Then
            Phon1TxtBx.Mask = "0000000000"
        End If
        Phon1TxtBx.Focus()
        NameTxtBx.Text = ""
        AddTxtBx.Text = ""
        Phon2TxtBx.Text = ""
        MailTxtBx.Text = ""
        RelatedTable.Rows.Clear()
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Remove(TabPage4)
    End Sub
    Private Sub PhonTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Phon1TxtBx.KeyPress, Phon2TxtBx.KeyPress    'check character kind (Only numbers)
        NumberOnly(e)
    End Sub
    Public Sub ClntData()
        Dim primaryKey(0) As DataColumn
        RelatedTable.Rows.Clear()
        '  Table            0       1        2       3      4       5       6       7        8      9        10       11       12       13        14         15         16       17        18       19             20         21      22        23         24          25      26       27         28         29           30       31          32       33    34       35
        '  Grid             1        2       3      4       5       6       7        8       9      10       11       12       13        14       15          16         17      18        19       20             21         22      23        24         25          26      27       28         29         30           31       32          33       34    35       36
        If GetTbl("SELECT TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, TkDetails, TkClsStatus, TkFolw, TkEmpNm, UsrRealNm, 0 AS LstSqlEv, '1/1/0001 12:00:00 AM' AS LstUpdtTime, '' AS TkupTxt, 0 AS TkupUnread, 0 AS TkupEvtId, '' AS EvNm, 0 AS EvSusp, 0 AS TkupUser, TkReOp FROM dbo.TicketsAll  WHERE (TkClPh = '" & Phon1TxtBx.Text & "') ORDER BY TkSQL DESC;", RelatedTable, "1013&H") = Nothing Then
            primaryKey(0) = RelatedTable.Columns("TkSQL")
            RelatedTable.PrimaryKey = primaryKey

            If RelatedTable.Rows.Count > 0 Then
                Invoke(Sub() NameTxtBx.Text = RelatedTable(0).Item(5).ToString)
                Invoke(Sub() AddTxtBx.Text = RelatedTable(0).Item(9).ToString)
                Invoke(Sub() Phon2TxtBx.Text = RelatedTable(0).Item(7).ToString)
                If DBNull.Value.Equals(RelatedTable(0).Item(8).ToString) = False Then
                    Invoke(Sub() MailTxtBx.Text = RelatedTable(0).Item(8).ToString)
                Else

                End If

                If TabControl1.TabPages.Contains(TabPage2) = False Then Invoke(Sub() TabControl1.TabPages.Insert(1, TabPage2))
                SerchTable.Rows.Clear()
                SerchTable.Columns.Clear()
                SerchTable.Columns.Add("Kind")
                SerchTable.Columns.Add("Item")

                SerchTable.Rows.Add("STR", "اسم العميل")
                SerchTable.Rows.Add("STR", "الرقم القومي")
                SerchTable.Rows.Add("STR", "تليفون العميل2")
                SerchTable.Rows.Add("Int", "رقم الشكوى")
                SerchTable.Rows.Add("STR", "رقم الكارت")
                SerchTable.Rows.Add("STR", "رقم الشحنة")
                SerchTable.Rows.Add("STR", "رقم أمر الدفع")
                SerchTable.Rows.Add("STR", "مصدر الشكوى")
                SerchTable.Rows.Add("Int", "مبلغ العملية")

                FilterComb.DataSource = SerchTable
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

                Dim Comp As Integer = 0
                Dim InQ As Integer = 0
                Dim Stat As Integer = 0
                For YY = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable(YY).Item("TkKind") = True Then
                        Comp += 1
                    Else
                        InQ += 1
                    End If
                    If RelatedTable(YY).Item("TkClsStatus") = True Then
                        Stat += 1
                    End If
                Next


                Invoke(Sub() LblComp.Text = Comp)
                Invoke(Sub() LblInq.Text = InQ)
                Invoke(Sub() LblClsCls.Text = Stat)
                Invoke(Sub() LblClsOp.Text = RelatedTable.Rows.Count - Stat)
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
            Else
                Invoke(Sub() NameTxtBx.Text = "")
                Invoke(Sub() AddTxtBx.Text = "")
                Invoke(Sub() Phon2TxtBx.Text = "")
                Invoke(Sub() MailTxtBx.Text = "")
                Invoke(Sub() LblComp.Text = 0)
                Invoke(Sub() LblInq.Text = 0)
                Invoke(Sub() LblClsOp.Text = 0)
                Invoke(Sub() LblClsCls.Text = 0)
                Invoke(Sub() LblDublicate.Text = "Ticket(s) Before :")
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = " لا توجد بيانات متاحة للعرض")
                Invoke(Sub() TabControl1.TabPages.Remove(TabPage2))
            End If
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
        Else
            Invoke(Sub() TabControl1.TabPages.Remove(TabPage2))
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Invoke(Sub() LodngFrm.LblMsg.Text = My.Resources.ConnErr & " - " & My.Resources.TryAgain)
            Invoke(Sub() LodngFrm.LblMsg.ForeColor = Color.Red)
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
        End If
        FltrStr = ""
        Invoke(Sub() RelatedTable.DefaultView.RowFilter = String.Empty)
        Invoke(Sub() LodngFrm.Close())
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())

    End Sub
    'Load Customer Data If Available
    Private Sub Phon1TxtBx_TextChanged(sender As Object, e As EventArgs) Handles Phon1TxtBx.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To Phon1TxtBx.TextLength
            If Mid(Phon1TxtBx.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = Phon1TxtBx.TextLength Then

            Dim ClntThrd As New Thread(AddressOf ClntData)
            ClntThrd.IsBackground = True
            Phon1TxtBx.BackColor = Color.FromArgb(128, 255, 128)
            Phon1TxtBx.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
            WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ..........."
            TreeView1.Visible = True
            PublicCode.LoadFrm(500, 350)
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تحميل بيانات العميل ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            ClntThrd.Start()
            Me.Enabled = False
        Else
            Phon1TxtBx.BackColor = Color.OrangeRed
            Phon1TxtBx.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
            TreeView1.Visible = False
            NameTxtBx.Text = ""
            AddTxtBx.Text = ""
            Phon2TxtBx.Text = ""
            MailTxtBx.Text = ""
            LblComp.Text = 0
            LblInq.Text = 0
            LblClsOp.Text = 0
            LblClsCls.Text = 0
            LblDublicate.Text = "Ticket(s) Before :"
            TabControl1.TabPages.Remove(TabPage2)
        End If
    End Sub
    Private Sub Phon2TxtBx_TextChanged(sender As Object, e As EventArgs) Handles Phon2TxtBx.TextChanged
        Cnt_ = 0
        For cnt_1 = 1 To Phon2TxtBx.TextLength
            If Mid(Phon2TxtBx.Text, cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ = Phon2TxtBx.TextLength Then
            Phon2TxtBx.BackColor = Color.FromArgb(128, 255, 128)
            Phon2TxtBx.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        Else
            Phon2TxtBx.BackColor = Color.OrangeRed
            Phon2TxtBx.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        End If
    End Sub
    Private Sub PhonTxtBx1_Leave(sender As Object, e As EventArgs) Handles Phon1TxtBx.Leave
        If String.IsNullOrEmpty(Phon1TxtBx.Text) Then
            RadioButton8.Checked = False
            RadioButton9.Checked = False
            Me.Phon1TxtBx.Enabled = False
        Else
            If Phon1TxtBx.MaskFull = False Then
                ECnt_Label.ForeColor = Color.Red
                Phon1TxtBx.Focus()
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & Phon1TxtBx.MaxLength & " رقم"
                Beep()
            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub Phone2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.Click, RadioButton11.Click
        TimrPhons.Start()
        Phon2TxtBx.Enabled = True
        Phon2TxtBx.Text = ""
        If (RadioButton11.Checked) Then
            Phon2TxtBx.Mask = "00000000000"
        ElseIf (RadioButton12.Checked) Then
            Phon2TxtBx.Mask = "0000000000"
        End If
        Phon2TxtBx.Focus()
        ECnt_Label.ForeColor = Color.Green
        ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & Phon2TxtBx.MaxLength & " رقم"
    End Sub
    Private Sub Phon2TxtBx_KeyUp(sender As Object, e As KeyEventArgs)
        If Phon2TxtBx.TextLength < Phon2TxtBx.MaxLength Then
            Phon2TxtBx.BackColor = Color.OrangeRed
            Phon2TxtBx.ForeColor = Color.Yellow
            ECnt_Label.ForeColor = Color.Red
            ECnt_Label.Text = "رقم التليفون غير مكتمل"
        ElseIf Phon2TxtBx.TextLength = Phon2TxtBx.MaxLength Then
            Phon2TxtBx.BackColor = Color.FromArgb(128, 255, 128)
            Phon2TxtBx.ForeColor = Color.Black
            ECnt_Label.ForeColor = Color.Green
            ECnt_Label.Text = "رقم التليفون مكتمل"
        End If
    End Sub
    Private Sub Phon2TxtBx_Leave(sender As Object, e As EventArgs) Handles Phon2TxtBx.Leave
        If String.IsNullOrEmpty(Phon2TxtBx.Text) Then
            Phon2TxtBx.Enabled = False
            RadioButton11.Checked = False
            RadioButton12.Checked = False
            Me.Phon2TxtBx.Enabled = False
        Else
            If Phon2TxtBx.MaskFull = False Then
                Phon2TxtBx.Focus()
                ECnt_Label.ForeColor = Color.Red
                ECnt_Label.Text = "رقم الموبايل لابد أن يتكون من " & Phon2TxtBx.MaxLength & " رقم"
                Beep()
            End If
            If Phon2TxtBx.TextLength < Phon2TxtBx.MaxLength Then

            End If
        End If
        ECnt_Label.Text = ""
    End Sub
    Private Sub AmountTxtBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AmountTxtBx.KeyPress
        NumberDecimalOnly(e)
    End Sub
    Private Sub AmountTxtBx_Leave(sender As Object, e As EventArgs) Handles AmountTxtBx.Leave
        'Try
        '    AmountTxtBx.Text = Convert.ToDecimal(AmountTxtBx.Text).ToString("N2")
        'Catch exp As Exception
        '    MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    AmountTxtBx.Focus()
        'End Try
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        RemoveHandler AreaCmbBx.SelectedValueChanged, AddressOf AreaCmbBx_SelectedValueChanged 'Programming add Handler
        Timer1.Stop()
        Me.Close()
    End Sub
    Private Sub OffCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OffCmbBx.Validating
        If Len(OffCmbBx.Text) > 0 Then
            If (OffCmbBx.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", OffCmbBx, 0, 0, 5000)
            Else
                ToolTip1.Hide(OffCmbBx)
            End If
        End If
    End Sub
    Private Sub SubmtOfflineTick()
        Dim TranDt As String
        Dim Trck As String = ""
        Invoke(Sub() PublicCode.LoadFrm(340, 330))
        Invoke(Sub() LodngFrm.LblMsg.Text = "جاري تسجيل البيانات ...")
        Invoke(Sub() LodngFrm.LblMsg.Refresh())
        Dim Transction As SqlTransaction = Nothing             'SQL Transaction
        Dim OfflineCon As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OfflineDB.mdf;Integrated Security=True")
        For Cnt_ = 1 To TrackMskBx.TextLength
            If Mid(TrackMskBx.Text, Cnt_, 1) <> " " Then
                Trck &= Mid(TrackMskBx.Text, Cnt_, 1)
            End If
        Next
        Dim sqlComminsert1 As New SqlCommand            'SQL Command
        Dim sqlComminsert2 As New SqlCommand            'SQL Command
        Dim sqlComminsert3 As New SqlCommand            'SQL Command
        Dim sqlComminsert4 As New SqlCommand            'SQL Command
        If TransDtPicker.Value = Today.AddDays(1) Then
            TranDt = ""
        Else
            TranDt = Format(TransDtPicker.Value, "yyyy/MM/dd").ToString
        End If
        Try
            If OfflineCon.State = ConnectionState.Closed Then
                OfflineCon.Open()
            End If
            sqlComminsert1.Connection = OfflineCon
            sqlComminsert2.Connection = OfflineCon            'insert Update into Update Table
            sqlComminsert3.Connection = OfflineCon
            sqlComminsert4.Connection = OfflineCon
            sqlComm.Connection = OfflineCon                    'Get ID & Date & UserID
            sqlComminsert1.CommandType = CommandType.Text
            sqlComminsert2.CommandType = CommandType.Text
            sqlComminsert3.CommandType = CommandType.Text
            sqlComminsert4.CommandType = CommandType.Text
            sqlComm.CommandType = CommandType.Text
            If TickKind = 0 Then                            'Ticket Will be closed & Usr.ID will be the same User
                Invoke(Sub() sqlComminsert1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkClsStatus, TkEmpNm, TkFolw) VALUES (0, '" & TickKind & "','" &
                                               TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & 1 & "','" & Usr.PUsrID & "','" & "1" & "');")

                sqlComminsert2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Inquiry has been Recieved On Offline Mode" & "','" & "1" & "','" & "9" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            Else
                If Usr.PUsrCalCntr = True Then
                    Invoke(Sub() sqlComminsert1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail) VALUES (0, '" & TickKind & "','" &
                                      TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "');")
                Else
                    Invoke(Sub() sqlComminsert1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkEmpNm) VALUES (0, '" & TickKind & "','" &
                                  TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & Usr.PUsrID & "');")
                End If
                sqlComminsert2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Complaint has been Recieved On Offline Mode" & "','" & "1" & "','" & "9" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            End If
            sqlComminsert3.CommandText = "update Tickets set TkID = MaxID from (select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, TkEmpNm0 from Tickets where TkEmpNm0  = " & Usr.PUsrID & " GROUP BY TkEmpNm0) As MaxTable INNER JOIN Tickets ON Tickets.TkSQL = MaxTable.MaxID;"
            sqlComminsert4.CommandText = "select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, MAX(TkID) AS Max_ from TkEvent INNER JOIN Tickets ON TkEvent.TkupTkSql = Tickets.TkSQL GROUP BY TkupUser HAVING (TkupUser  = " & Usr.PUsrID & ");"
            Transction = OfflineCon.BeginTransaction()
            sqlComminsert1.Transaction = Transction
            sqlComminsert2.Transaction = Transction
            sqlComminsert3.Transaction = Transction
            sqlComminsert4.Transaction = Transction
            sqlComm.Transaction = Transction

            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "Exuting ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            sqlComminsert1.ExecuteNonQuery()
            sqlComminsert2.ExecuteNonQuery()
            sqlComminsert3.ExecuteNonQuery()

            Reader_ = sqlComminsert4.ExecuteReader
            Reader_.Read()
            SqlCuCnt_ = Reader_!MaxID
            If TickKind = 0 Then
                Invoke(Sub() ComRefLbl.Text = "Inquiry No.:  " & Reader_!Max_)
            Else
                Invoke(Sub() ComRefLbl.Text = "Complaint No.: " & Reader_!Max_)
            End If

            Invoke(Sub() DateTxtBx.Text = Reader_!MaxDt)
            Reader_.Close()
            Transction.Commit()
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "Done")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            For Each ctrl In TabPage1.Controls
                If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Then
                    ctrl.Enabled = False
                ElseIf TypeOf ctrl Is ComboBox Then
                    ctrl.Enabled = False
                ElseIf TypeOf ctrl Is GroupBox Then
                    ctrl.Enabled = False
                    Invoke(Sub() ctrl.backcolor = Color.FromArgb(105, 255, 123))
                ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                    For Each C In ctrl.Controls
                        If TypeOf C Is FlowLayoutPanel Then
                            For Each H In C.Controls
                                If TypeOf H Is TextBox Or TypeOf H Is MaskedTextBox Then
                                    H.Enabled = False
                                ElseIf TypeOf H Is ComboBox Then
                                    H.Enabled = False
                                    Invoke(Sub() H.backcolor = Color.FromArgb(105, 255, 123))
                                ElseIf TypeOf H Is GroupBox Then
                                    H.Enabled = False
                                    H.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
                                ElseIf TypeOf H Is Panel Then
                                    For Each G In H.Controls
                                        If TypeOf G Is RadioButton Then
                                            G.Enabled = False
                                        End If
                                    Next
                                End If
                            Next
                        End If

                    Next
                End If
            Next
            TreeView1.Enabled = False
            Invoke(Sub() SubmitBtn.Visible = False)
            Invoke(Sub() Me.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() TabPage1.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "تم تسجيل البيان بنجاح")
            Timer1.Stop()
            Invoke(Sub() BtnDublicate.Visible = True)
            DubStr = ""

            Dim exchange As ExchangeService
            exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
            exchange.Credentials = New WebCredentials("egyptpost\voca-support", MLXX)
            exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
            Dim message As New EmailMessage(exchange)
            'message.ToRecipients.Add(Usr.PUsrMail)
            'message.ToRecipients.Add("callcenter-followup@EgyptPost.Org")
            'message.CcRecipients.Add("CCQuality@EgyptPost.Org")
            'message.CcRecipients.Add("VOCA-SUPPORT@EgyptPost.Org")
            message.BccRecipients.Add("a.farag@egyptpost.org")
            message.Subject = "New Offline Complaints By : " & Usr.PUsrRlNm & "," & Usr.PUsrID & "," & OsIP()
            Invoke(Sub()
#Region "Body Message"
                       message.Body = "<p Style=" & Chr(34) & "text-align: center;" & Chr(34) & "><Span style=" & Chr(34) & "color: rgb(65, 168, 95); font-family:Times New Roman; font-size: 20px;text-align: center" & Chr(34) & "><strong>شكوى تم تسجيلها بوضع غير متصل بالشبكة</strong></span></p><br>" &
                                            "<p Style=" & Chr(34) & "text-align: right;direction: rtl" & Chr(34) & "><Span style=" & Chr(34) & "color: Black ; font-family:Times New Roman; font-size: 14px;text-align: right;direction: rtl" & Chr(34) & "><strong>تم تسجيل هذه الشكوى بوضع غير متصل بالشبكة لعدم إمكانية الوصول للخادم.<br>سيتم تسجيل هذه الشكوى فعلياً بمجرد توافر إمكانية الوصول للخادم<br>يرجى متابعة تسجيل الشكوى من عدمة وتسجيل ذلك</strong></span></p><br>" &
                                            "<table style=" & Chr(34) & " width:100%;direction: rtl;" & Chr(34) & "><tbody><tr><td style=" & Chr(34) & "width: 70.0000%;" & Chr(34) & "<div style=" & Chr(34) & "text-align: right;vertical-align:text-top;font-size: 18px;" & Chr(34) & "نوع الشكوى : " & TreeView1.SelectedNode.FullPath & "<br> نص التحديث : <Span Style=" & Chr(34) & "color:" & "Green" & Chr(34) & ";>" & Esc & "</span><br><br><br><Span Style=" & Chr(34) & "color:Black;font-family:Courier New" & Chr(34) & ";>" & "" & "</span></div></td><td style=" & Chr(34) & "width: 30.0000%;" & Chr(34) & ">" & "<div style=" & Chr(34) & "text-align: left;" & Chr(34) & "></td></tr></tbody></table>" &
                                            "<table style=“ & Chr(34) & “width: 100%; direction: rtl; border-style: solid; border-color:" & "Green" & Chr(34) & “><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>رقم الشكوى :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & Split(ComRefLbl.Text, " ")(2) & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>تاريخ تسجيل الشكوى :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & DateTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong> اسم العميل :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & NameTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>تليفون العميل 1 :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & Phon1TxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>تليفون العميل 2 :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & Phon2TxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>البريد الإلكتروني :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & MailTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>العنوان :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & AddTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>اسم المكتب :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & OffCmbBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>رقم الكارت :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & AccMskdBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>رقم الشحنة :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & Trck & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>الرقم القومى :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & IDTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>رقم أمر الدفع :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & GBTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>مبلغ العملية :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & AmountTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>تاريخ العملية :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & TranDt & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>تفاصيل الشكوى :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & DetailsTxtBx.Text & "</div></td></tr></tbody><tbody><tr><td><div style=“ & Chr(34) & “text-align: left; margin-Left: 10px;” & Chr(34) &
                                            “><strong>مصدر الشكوى :</strong></div></td><td style=“ & Chr(34) & “width: 85.0000%;” & Chr(34) & “><div style=“ & Chr(34) & “text-align: right;” & Chr(34) &
                                            “>" & SrcCmbBx.Text & "</div></td></tr></tbody></table>" & "<br><br><p style=" & Chr(34) & "direction:rtl;text-align: right;" & Chr(34) & "XXXXXXXXXXXXXXXXXXXXXXXXXX</p> "
#End Region

                   End Sub)
            message.Body.BodyType = BodyType.HTML
            message.Importance = 1
            Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "Trying To Sending mail ...")
            Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Try
                message.SendAndSaveCopy()
                Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "Mail has been sent")
                Invoke(Sub() LodngFrm.LblMsg.Refresh())
            Catch ex As Exception
                Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "Can't send Mail now")
                Invoke(Sub() LodngFrm.LblMsg.Refresh())
            End Try
            Invoke(Sub() LodngFrm.Close())
            AppLogTbl(Split("1011&H", "&H")(0), 1,, sqlComminsert1.CommandText & "_" & sqlComminsert2.CommandText & "_" & sqlComminsert3.CommandText & "_" & sqlComminsert4.CommandText)
        Catch ex As Exception
            Transction.Rollback()
            AppLogTbl(Split("1011&H", "&H")(0), 1, ex.Message, sqlComminsert1.CommandText & "_" & sqlComminsert2.CommandText & "_" & sqlComminsert3.CommandText & "_" & sqlComminsert4.CommandText)
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "تم تسجيل الشكوى بوضع الغير متصل بالشبكة")
        End Try
        Invoke(Sub() LodngFrm.Close())
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())
        Invoke(Sub() TimrPhons.Stop())
    End Sub
    Private Sub SubmtTick()

        Dim TranDt As String
        Dim Trck As String = ""
        Dim lodingStr As String = ""

        lodingStr = "جاري تسجيل البيانات ..."
        'Invoke(Sub() PublicCode.LoadFrm(lodingStr, 340, 330))

        For Cnt_ = 1 To TrackMskBx.TextLength
            If Mid(TrackMskBx.Text, Cnt_, 1) <> " " Then
                Trck &= Mid(TrackMskBx.Text, Cnt_, 1)
            End If
        Next
        Dim sqlComminsert_3 As New SqlCommand            'SQL Command
        Dim sqlComminsert_4 As New SqlCommand            'SQL Command
        If TransDtPicker.Value = Today.AddDays(1) Then
            TranDt = ""
        Else
            TranDt = Format(TransDtPicker.Value, "yyyy/MM/dd").ToString
        End If
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComminsert_1.Connection = sqlCon
            sqlComminsert_2.Connection = sqlCon            'insert Update into Update Table
            sqlComminsert_3.Connection = sqlCon
            sqlComminsert_4.Connection = sqlCon
            sqlComm.Connection = sqlCon                    'Get ID & Date & UserID
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_3.CommandType = CommandType.Text
            sqlComminsert_4.CommandType = CommandType.Text
            sqlComm.CommandType = CommandType.Text
            If TickKind = 0 Then                            'Ticket Will be closed & Usr.ID will be the same User
                Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkClsStatus, TkEmpNm, TkFolw) VALUES (0, '" & TickKind & "','" &
                                               TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & 1 & "','" & Usr.PUsrID & "','" & "1" & "');")

                sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Inquiry has been Recieved" & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            Else
                If Usr.PUsrCalCntr = True Then
                    Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail) VALUES (0, '" & TickKind & "','" &
                                      TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "');")
                Else
                    Invoke(Sub() sqlComminsert_1.CommandText = "INSERT INTO Tickets(TkID, TkKind, TkFnPrdCd, TkCompSrc, TkClNm, TkClPh, TkClPh1, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, TkDetails, TkSndrCoun, TkConsigCoun, TkOffNm, TkEmpNm0, TkMail, TkEmpNm) VALUES (0, '" & TickKind & "','" &
                                  TreeView1.SelectedNode.Name & "','" & SrcCmbBx.SelectedValue & "','" & Trim(NameTxtBx.Text) & "','" & Phon1TxtBx.Text & "','" & Phon2TxtBx.Text & "','" & AddTxtBx.Text & "','" & IDTxtBx.Text & "','" & Trck & "','" & GBTxtBx.Text & "','" & Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4)) & "','" & AmountTxtBx.Text & "','" & TranDt & "','" & DetailsTxtBx.Text & DubStr & "','" & Trim(Mid(TrackMskBx.Text, 14, 2)) & "','" & DistCmbBx.SelectedValue & "','" & OffCmbBx.SelectedValue & "','" & Usr.PUsrID & "','" & MailTxtBx.Text & "','" & Usr.PUsrID & "');")
                End If
                sqlComminsert_2.CommandText = "INSERT into TkEvent (TkupTkSql, TkupTxt, TkupUnread, TkupEvtId, TkupUserIP, TkupUser) VALUES 
                                                               ((Select Max(TkSQL) As RelationTkID FROM Tickets where TkEmpNm0 = " & Usr.PUsrID & "),'" & "The Complaint has been Recieved" & "','" & "1" & "','" & "0" & "','" & OsIP() & "','" & Usr.PUsrID & "');"
            End If
            sqlComminsert_3.CommandText = "update Tickets set TkID = MaxID from (select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, TkEmpNm0 from Tickets where TkEmpNm0  = " & Usr.PUsrID & " GROUP BY TkEmpNm0) As MaxTable INNER JOIN Tickets ON Tickets.TkSQL = MaxTable.MaxID;"
            sqlComminsert_4.CommandText = "select MAX(TkSQL) AS MaxID, MAX(TkDtStart) AS MaxDt, MAX(TkID) AS Max_ from TkEvent INNER JOIN Tickets ON TkEvent.TkupTkSql = Tickets.TkSQL GROUP BY TkupUser HAVING (TkupUser  = " & Usr.PUsrID & ");"
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_4.Transaction = Tran
            sqlComm.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Reader_ = sqlComminsert_4.ExecuteReader

            Reader_.Read()
            SqlCuCnt_ = Reader_!MaxID
            If TickKind = 0 Then
                Invoke(Sub() ComRefLbl.Text = "Inquiry No.:  " & Reader_!Max_)
            Else
                Invoke(Sub() ComRefLbl.Text = "Complaint No.: " & Reader_!Max_)
            End If

            Invoke(Sub() DateTxtBx.Text = Reader_!MaxDt)
            Reader_.Close()
            Tran.Commit()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            For Each ctrl In TabPage1.Controls
                If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Then
                    ctrl.Enabled = False
                ElseIf TypeOf ctrl Is ComboBox Then
                    ctrl.Enabled = False
                ElseIf TypeOf ctrl Is GroupBox Then
                    ctrl.Enabled = False
                    Invoke(Sub() ctrl.backcolor = Color.FromArgb(105, 255, 123))
                ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                    For Each C In ctrl.Controls
                        If TypeOf C Is FlowLayoutPanel Then
                            For Each H In C.Controls
                                If TypeOf H Is TextBox Or TypeOf H Is MaskedTextBox Then
                                    H.Enabled = False
                                ElseIf TypeOf H Is ComboBox Then
                                    H.Enabled = False
                                    Invoke(Sub() H.backcolor = Color.FromArgb(105, 255, 123))
                                ElseIf TypeOf H Is GroupBox Then
                                    H.Enabled = False
                                    H.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
                                ElseIf TypeOf H Is Panel Then
                                    For Each G In H.Controls
                                        If TypeOf G Is RadioButton Then
                                            G.Enabled = False
                                        End If
                                    Next
                                End If
                            Next
                        End If

                    Next
                End If
            Next
            TreeView1.Enabled = False
            Invoke(Sub() SubmitBtn.Visible = False)
            Invoke(Sub() Me.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() TabPage1.BackColor = Color.FromArgb(105, 255, 123))
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "تم تسجيل البيان بنجاح")
            Timer1.Stop()
            Invoke(Sub() BtnDublicate.Visible = True)
            DubStr = ""
            Invoke(Sub() LodngFrm.Close())
            Invoke(Sub() Me.Enabled = True)
            Invoke(Sub() Me.Activate())
            Invoke(Sub() TimrPhons.Stop())
        Catch ex As Exception
            'Tran.Rollback()
            'Invoke(Sub() WelcomeScreen.TimerCon.Start())
            'Invoke(Sub() WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032)
            Invoke(Sub() LodngFrm.Close())
            AppLog("1011&H", ex.Message, sqlComminsert_1.CommandText & "_" & sqlComminsert_2.CommandText)
            'Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لم ينجح الإتصال بالخادم .. سيتم تسجيل الشكوى بالوضع الغير متصل بالشبكة")
            'Dim Rslt As DialogResult
            'Rslt = MessageBox.Show("كود خطأ : " & "1011&H" & vbCrLf & "لم ينجح الإتصال بالخادم .. سيتم تسجيل الشكوى بالوضع الغير متصل بالشبكة" & vbCrLf & "هل تريد الإستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
            'If Rslt = DialogResult.Yes Then
            '    TickOffSubmt = New Thread(AddressOf SubmtOfflineTick)
            '    TickOffSubmt.IsBackground = True
            '    Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ...........")
            '    Invoke(Sub() TreeView1.Visible = True)
            '    TickOffSubmt.Start()
            '    TickSubmt.Abort()
            'End If

            'TickSubmt.Abort()
            MsgErr("كود خطأ : " & "1011&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & "لم ينجح الإتصال بالخادم .. سيتم تسجيل الشكوى بالوضع الغير متصل بالشبكة")
        End Try
        Invoke(Sub() LodngFrm.Close())
        Invoke(Sub() Me.Enabled = True)
        Invoke(Sub() Me.Activate())
        Invoke(Sub() TimrPhons.Stop())
    End Sub
    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        TickSubmt = New Thread(AddressOf SubmtTick)
        TickSubmt.IsBackground = True
        WelcomeScreen.StatBrPnlAr.Text = "جاري تسجيل البيانات ..........."
        TreeView1.Visible = True
        PublicCode.LoadFrm(340, 330)
        Invoke(Sub() LodngFrm.LblMsg.Text += vbCrLf & "جاري تسجيل البيانات ...")
        Invoke(Sub() LodngFrm.LblMsg.Refresh())
        TickSubmt.Start()
        Me.Enabled = False
    End Sub
    Private Sub AreaCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AreaCmbBx.Validating
        If AreaCmbBx.Text.Length > 0 Then
            If (AreaCmbBx.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", AreaCmbBx, 0, 20, 5000)
            Else
                ToolTip1.Hide(SrcCmbBx)
            End If
        End If
    End Sub
    Private Sub DistCmbBx_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DistCmbBx.Validating
        If DistCmbBx.Text.Length > 0 Then
            If (DistCmbBx.SelectedIndex = -1) Then
                e.Cancel = True
                Beep()
                ToolTip1.Show("Your choice Not listed", DistCmbBx, 0, 20, 5000)
            Else
                ToolTip1.Hide(SrcCmbBx)
            End If
        End If
    End Sub
    Private Sub TrackMskBx_Leave(sender As Object, e As EventArgs) Handles TrackMskBx.Leave
        Dim TempRow As DataRow
        Dim PrdNo As String
        Dim Stat_ As String
        Dim chck As Boolean = False

        LblDublicate.Text = "Ticket(s) Before :"
        TrackMskBx.Text = UCase(TrackMskBx.Text)

        If PrdBol = True Then
            PrdNo = Trim(Mid(TrackMskBx.Text, 1, 3)) & Trim(Mid(TrackMskBx.Text, 5, 8)) & Trim(Mid(TrackMskBx.Text, 14, 2))
            If (Trim(Mid(TrackMskBx.Text, 1, 3)) & Trim(Mid(TrackMskBx.Text, 5, 8)) & Trim(Mid(TrackMskBx.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        Else
            PrdNo = Trim(Mid(TrackMskBx.Text, 1, 2)) & Trim(Mid(TrackMskBx.Text, 4, 9)) & Trim(Mid(TrackMskBx.Text, 14, 2))
            If (Trim(Mid(TrackMskBx.Text, 1, 2)) & Trim(Mid(TrackMskBx.Text, 4, 9)) & Trim(Mid(TrackMskBx.Text, 14, 2))).Length = 13 Then
                chck = True
            Else
                chck = False
            End If
        End If
        If chck = True Then
            'If Mid(TrackMskBx.Text, 14, 1).CompareTo("[A-Z][a-z]*") = 1 Or Mid(TrackMskBx.Text, 15, 1).CompareTo("[A-Z][a-z]*") = 1 Then
            TempRow = CountryTable.Rows.Find(Mid(TrackMskBx.Text, 14, 2))
            If TempRow Is Nothing Then
                MsgInf("لا توجد دولة مسجلة بهذا الاسم" & vbCrLf & "يرجى مراجعة رقم التتبع")
            Else
                OriginTxtBx.Text = TempRow.ItemArray(1)
                TrackMskBx.BackColor = Color.FromArgb(128, 255, 128)
            End If
        Else
            Beep()
            WelcomeScreen.StatBrPnlAr.Text = "يرجى التحقق من رقم التتبع"
            TrackMskBx.Text = ""
            Exit Sub
        End If

        If PrdNo.Length = 13 Then
            If RelatedTable.Rows.Count > 0 Then
                For PrdRefCount = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable.Rows(PrdRefCount).Item(11).ToString = PrdNo Then
                        If RelatedTable.Rows(PrdRefCount).Item(24) = False Then
                            Stat_ = " ( Open )"
                        Else
                            Stat_ = " ( Closed )"
                        End If
                        LblDublicate.Text &= vbCrLf & "           - " & RelatedTable.Rows(PrdRefCount).Item(3).ToString & Stat_
                        LblDublicate.ForeColor = Color.Red
                        Beep()
                    End If
                Next
            End If
        Else
            LblDublicate.Text = "Ticket(s) Before :"
            LblDublicate.ForeColor = Color.Black
            TrackMskBx.Text = ""
        End If
    End Sub
    Private Sub TrackMskBx_TextChanged(sender As Object, e As EventArgs) Handles TrackMskBx.TextChanged
        ToolTip1.Hide(TrackMskBx)
        TrackMskBx.BackColor = Color.White
        OriginTxtBx.Text = ""
    End Sub
    Private Sub TrackMskBx_Enter(sender As Object, e As EventArgs) Handles TrackMskBx.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput            'Tansfer writing to English
    End Sub
    Private Sub NameTxtBx_Enter(sender As Object, e As EventArgs) Handles NameTxtBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub DistCmbBx_Enter(sender As Object, e As EventArgs) Handles DistCmbBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub MailTxtBx_Enter(sender As Object, e As EventArgs) Handles MailTxtBx.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub
    Private Sub DetailsTxtBx_Enter(sender As Object, e As EventArgs) Handles DetailsTxtBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub AddTxtBx_Enter(sender As Object, e As EventArgs) Handles AddTxtBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub OffCmbBx_Enter(sender As Object, e As EventArgs) Handles OffCmbBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim TempClr As DataRow
        LblDublicate.Text = "Ticket(s) Before :"
        SubmitBtn.Enabled = False
        TreeView1.SelectedNode.Expand()
        TempClr = ProdKTable.Rows.Find(Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0))
        BKClr = Split(TempClr.ItemArray(2), ",")
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox3.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))

        If (TreeView1.SelectedNode.Level) = 2 Then

            'If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1) = "ايجى ميل" Then

            'End If
            Timer1.Start()
            PrdKind = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0)
            Prdct.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(1)
            Comp.Text = Split(TreeView1.SelectedNode.FullPath.ToString, "\")(2)

        ElseIf (TreeView1.SelectedNode.Level) < 2 Then
            PrdBol = False
            Timer1.Stop()
            Prdct.Text = ""
            Comp.Text = ""
            AccMskdBx.Text = ""
            TrackMskBx.Text = ""
        End If

        If Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0) <> PrdKind Then PrdKind = ""

        If PrdKind = "مالية" Then
            Me.FinancialGroup.Visible = True
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = True
            TrackMskBx.Text = ""
            OriginTxtBx.Text = ""
            DistCmbBx.SelectedValue = ""
        ElseIf PrdKind = "بريدية" Then
            AccMskdBx.Text = ""
            GBTxtBx.Text = ""
            IDTxtBx.Text = ""
            AmountTxtBx.Text = "0"
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = True
            CombProdRef.Visible = True
        ElseIf PrdKind = "حكومية" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            AccMskdBx.Text = ""
            GBTxtBx.Text = ""
            IDTxtBx.Text = ""
            AmountTxtBx.Text = "0"
            TrackMskBx.Text = ""
            OriginTxtBx.Text = ""
            DistCmbBx.SelectedValue = ""
        ElseIf PrdKind = "مجتمعية" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            AccMskdBx.Text = ""
            GBTxtBx.Text = ""
            IDTxtBx.Text = ""
            AmountTxtBx.Text = ""
            TrackMskBx.Text = ""
            OriginTxtBx.Text = ""
            DistCmbBx.SelectedValue = ""
        ElseIf PrdKind = "أخرى" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            AccMskdBx.Text = ""
            GBTxtBx.Text = ""
            IDTxtBx.Text = ""
            AmountTxtBx.Text = "0"
            TrackMskBx.Text = ""
            OriginTxtBx.Text = ""
            DistCmbBx.SelectedValue = ""
        ElseIf PrdKind = "" Then
            Me.FinancialGroup.Visible = False
            Me.PostalGroup.Visible = False
            CombProdRef.Visible = False
            AccMskdBx.Text = ""
            GBTxtBx.Text = ""
            IDTxtBx.Text = ""
            AmountTxtBx.Text = "0"
            TrackMskBx.Text = ""
            OriginTxtBx.Text = ""
            DistCmbBx.SelectedValue = ""
        End If
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If TreeView1.SelectedNode Is Nothing Then
        Else
            If TreeView1.SelectedNode.Level = 2 Then
                TreeView1.SelectedNode.Parent.Parent.Collapse(False)  'True to leave the child nodes in their Current state; false to collapse the child nodes.
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Parent.Collapse(False)
            ElseIf TreeView1.SelectedNode.Level = 0 Then
                CombProdRef.Items.Clear()
                TreeView1.SelectedNode.Collapse(False)
            End If
        End If
    End Sub
    Private Sub AreaCmbBx_SelectedValueChanged(sender As Object, e As EventArgs) 'Programming add Handler
        Dim OffData As DataView
        OffData = OfficeTable.DefaultView
        If AreaCmbBx.SelectedIndex <> -1 Then
            OfficeTable.DefaultView.RowFilter = "OffArea = '" & AreaCmbBx.SelectedValue.ToString & "'"
            OffCmbBx.SelectedIndex = -1
        End If
    End Sub
    Dim NodesThatMatch As New List(Of TreeNode)
    Private Function SearchTheTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode

        '  Empty previous
        NodesThatMatch.Clear()

        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Text.Contains(TextToFind) Then
                NodesThatMatch.Add(TN)

            End If
            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > 0 Then
            For Each TN As TreeNode In TreeView1.Nodes
                If TN.Checked = True Then
                    MsgBox(TN.Text)
                    TreeView1.SelectedNode = TN
                    TN.BackColor = Color.LightGreen
                End If
            Next
            Return NodesThatMatch(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text.Contains(TextToFind) Then
                NodesThatMatch.Add(TN)
                TN.Checked = True
            End If
            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
    Private Sub AreaCmbBx_Enter(sender As Object, e As EventArgs) Handles AreaCmbBx.Enter
        InputLanguage.CurrentInputLanguage = ArabicInput            'Tansfer writing to English
    End Sub
    Private Sub IDTxtBx_Leave(sender As Object, e As EventArgs) Handles IDTxtBx.Leave
        Cnt_ = 0
        If RadNID.Checked = True Then
            For Cnt_1 = 1 To 14
                If Mid(IDTxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                    Cnt_ += 1
                End If
            Next
            If Cnt_ < 14 And Cnt_ <> 0 Then
                Beep()
                IDTxtBx.Text = ""
                MsgInf("الرقم القومي لابد أن يتكون من 14 رقم")
            End If
        End If
        IDTxtBx.Text = UCase(IDTxtBx.Text)
    End Sub
    Private Sub GBTxtBx_Leave(sender As Object, e As EventArgs) Handles GBTxtBx.Leave
        For Cnt_1 = 1 To 16
            If Mid(GBTxtBx.Text, Cnt_1, 1).CompareTo("[A-Z][a-z]*") = 1 Then
                Cnt_ += 1
            End If
            If Mid(GBTxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnt_ += 1
            End If
        Next
        If Cnt_ < 16 And Cnt_ <> 0 Then
            Beep()
            GBTxtBx.Text = ""
            MsgInf("رقم أمر الدفع لابد أن يتكون من 16 رقم")
        Else
            GBTxtBx.Text = UCase(GBTxtBx.Text)
        End If
    End Sub
    Private Sub NewBtn_Click(sender As Object, e As EventArgs) Handles NewBtn.Click
        NewTickSub()
    End Sub

    'Second Tab                     XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub SerchTxt_TextChanged(sender As Object, e As EventArgs) Handles SerchTxt.TextChanged
        Filtr()
    End Sub
    Private Sub FilterComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComb.SelectedIndexChanged
        If FilterComb.Text = "الرقم القومي" Then
            FilterComb.MaxLength = 14
        ElseIf FilterComb.Text = "تليفون العميل2" Then
            SerchTxt.MaxLength = 11
        ElseIf FilterComb.Text = "رقم الكارت" Or FilterComb.Text = "رقم أمر الدفع" Then
            SerchTxt.MaxLength = 16
        Else
            SerchTxt.MaxLength = 50
        End If
        SerchTxt.ForeColor = Color.Black
        SerchTxt.Focus()
        SerchTxt.Text = ""
    End Sub
    Private Sub PrdKComb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrdKComb.SelectedIndexChanged
        Filtr()
    End Sub
    Private Sub BckBtn_Click(sender As Object, e As EventArgs) Handles BtnBck.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click
        If RadioButton1.Checked = True Then
            TickKindFltr = 0
        ElseIf RadioButton2.Checked = True Then
            TickKindFltr = 1
        ElseIf RadioButton3.Checked = True Then
            TickKindFltr = 2
        End If
        Filtr()
    End Sub
    Private Sub RdioOpen_Click(sender As Object, e As EventArgs) Handles RdioOpen.Click, Rdiocls.Click, RdioAll.Click
        If RdioOpen.Checked = True Then
            TicOpnFltr = 0
        ElseIf Rdiocls.Checked = True Then
            TicOpnFltr = 1
        ElseIf RdioAll.Checked = True Then
            TicOpnFltr = 2
        End If
        Filtr()
    End Sub
    Private Sub Filtr()
        FltrStr = ""
        If PrdItmTable.Rows.Count = 5 Then
            If SerchTxt.Text <> "برجاء ادخال كلمات البحث" Then
                If SerchTxt.TextLength > 0 Then
                    If FilterComb.SelectedValue = "Int" Then
                        For Cnt_ = 0 To GridTicket.Columns.Count - 1
                            If FilterComb.Text = GridTicket.Columns(Cnt_).HeaderText Then
                                FltrStr = "[" & GridTicket.Columns(Cnt_).Name & "]" & " = '" & SerchTxt.Text & "'"
                                Exit For
                            End If
                        Next
                    Else
                        For Cnt_ = 0 To GridTicket.Columns.Count - 1
                            If FilterComb.Text = GridTicket.Columns(Cnt_).HeaderText Then
                                FltrStr = "[" & GridTicket.Columns(Cnt_).Name & "]" & " like '" & SerchTxt.Text & "%'"
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If

            If PrdKComb.SelectedIndex <> 0 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " and " & "PrdKind" & " = '" & PrdKComb.SelectedIndex & "'"
                Else
                    FltrStr = "PrdKind" & " = '" & PrdKComb.SelectedIndex & "'"
                End If
            End If
            If TickKindFltr <> 2 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= "and " & "TkKind" & " = " & TickKindFltr
                Else
                    FltrStr = "TkKind" & " = " & TickKindFltr
                End If
            End If
            If TicOpnFltr <> 2 Then
                If FltrStr.Length > 0 Then
                    FltrStr &= " and " & "TkClsStatus" & " = " & TicOpnFltr
                Else
                    FltrStr = "TkClsStatus" & " = " & TicOpnFltr
                End If
            End If


            If FltrStr.Length > 0 Then
                RelatedTable.DefaultView.RowFilter = FltrStr
            Else
                RelatedTable.DefaultView.RowFilter = String.Empty
            End If
            SubGrdTikFill(GridTicket, RelatedTable)
            FncGrdTickInfo(GridTicket)
        End If


    End Sub
    Private Sub SerchTxt_Enter(sender As Object, e As EventArgs) Handles SerchTxt.Enter
        If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
            SerchTxt.Text = ""
            SerchTxt.ForeColor = Color.Black
        End If
    End Sub
    Private Sub SerchTxt_Leave(sender As Object, e As EventArgs) Handles SerchTxt.Leave
        If SerchTxt.TextLength = 0 Then
            SerchTxt.Text = "برجاء ادخال كلمات البحث"
            SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        TabControl1.TabPages.Insert(1, TabPage3)
        PublicCode.FncGrdCurrRow(GridTicket, GridTicket.CurrentRow.Index)
        If StruGrdTk.ClsStat = True Then
            TcktImg.BackgroundImage = My.Resources.Tckoff
        Else
            TcktImg.BackgroundImage = My.Resources.Tckon
        End If

        TxtPh1.Text = StruGrdTk.Ph1
        TxtPh2.Text = StruGrdTk.Ph2
        TxtDt.Text = StruGrdTk.DtStrt
        TxtNm.Text = StruGrdTk.ClNm
        TxtAdd.Text = StruGrdTk.Adress
        TxtEmail.Text = StruGrdTk.Email
        TxtDetails.Text = StruGrdTk.Detls
        TxtArea.Text = StruGrdTk.Area
        TxtOff.Text = StruGrdTk.Offic
        TxtProd.Text = StruGrdTk.ProdNm
        TxtComp.Text = StruGrdTk.CompNm
        TxtSrc.Text = StruGrdTk.Src
        TxtTrck.Text = StruGrdTk.Trck
        TxtOrgin.Text = StruGrdTk.Orig
        TxtDist.Text = StruGrdTk.Dist
        TxtCard.Text = StruGrdTk.Card
        TxtGP.Text = StruGrdTk.Gp
        TxtNId.Text = StruGrdTk.NID
        TxtAmount.Text = StruGrdTk.Amnt
        TxtTransDt.Text = StruGrdTk.TransDt
        TxtFolw.Text = StruGrdTk.UsrNm
        If StruGrdTk.ProdK = 1 Then
            GroupBox3.Visible = True
            GroupBox4.Visible = False
        ElseIf StruGrdTk.ProdK = 2 Then
            GroupBox3.Visible = False
            GroupBox4.Visible = True
        Else
            GroupBox3.Visible = False
            GroupBox4.Visible = False
        End If
        TabControl1.SelectedTab = TabPage3
        TabControl1.TabPages.Remove(TabPage2)
        If StruGrdTk.Tick = 0 Then
            TabPage3.Text = "Inquiry No.: " & StruGrdTk.TkId
        Else
            TabPage3.Text = "Complaint No.: " & StruGrdTk.TkId
        End If
    End Sub
    Private Sub BckBtn2_Click(sender As Object, e As EventArgs) Handles Btn2Bck.Click
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2
        BtnDecrease(Btn2Bck)
        For Each c As Control In TabPage3.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If

        Next
        For Each c As Control In GroupBox4.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
        For Each c As Control In GroupBox3.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub

    Private Sub BtnSubmt_Click(sender As Object, e As EventArgs) Handles BtnSubmt.Click
        InsUpdtSub(StruGrdTk.Sql, CmbEvent, TxtUpdt, LblMsg)
        GetUpdtEvent(StruGrdTk.Sql)
        Dim FolwID As String = ""
        If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
        UpGrgFrmt(GridUpdt, FolwID)
    End Sub
    Private Sub InsUpdtSub(StrWhere As Integer, Knd As ComboBox, Txt As TextBox, LblNm As Label)
        If Knd.SelectedIndex > -1 Then
            If Txt.TextLength > 0 Then
                TreeView1.Visible = True
                If PublicCode.InsUpd("insert into TkEvent (TkupTkSql, TkupTxt, TkupEvtId, TkupUserIP, TkupUser) VALUES ('" & StrWhere & "','" & Txt.Text & "','" & Knd.SelectedValue & "','" & OsIP() & "','" & Usr.PUsrID & "')", "1018&H") = Nothing Then
                    LblNm.Text = ("تم إضافة التحديث بنجاح")
                    LblNm.ForeColor = Color.Green
                    Knd.SelectedIndex = -1
                    Txt.Text = ""
                    Txt.ReadOnly = True
                End If
            Else
                LblNm.Text = ("برجاء كتابة نص التحديث")
                LblNm.ForeColor = Color.Red
                Beep()
            End If
        Else
            LblNm.Text = ("برجاء اختيار نوع التحديث")
            LblNm.ForeColor = Color.Red
            Beep()
        End If
    End Sub
    Private Sub GetUpdtEvent(StrWhere As Integer)
        UpdtCurrTbl.Rows.Clear()
        '                     0        1         2         3         4         5        6         7         8           9
        If GetTbl("SELECT TkupSQL, TkupSTime, TkupTxt, UsrRealNm, TkupUser, EvSusp, TkupUnread, TkupTkSql, TkupReDt, UCatLvl FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where (TkupTkSql = " & StrWhere & ") ORDER BY TkupSQL DESC", UpdtCurrTbl, "1019&H") <> Nothing Then
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub CmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent.SelectedIndexChanged
        TxtUpdt.ReadOnly = False
        TxtUpdt.Focus()
    End Sub
    Private Sub TxtUpdt_Leave(sender As Object, e As EventArgs) Handles TxtUpdt.Leave
        If TxtUpdt.TextLength = 0 Then
            CmbEvent.SelectedIndex = -1
            TxtUpdt.ReadOnly = True
            LblMsg.Text = ""
        End If
    End Sub
    Private Sub BtnAddUpdt_Click(sender As Object, e As EventArgs)
        If TabControl1.TabPages.Contains(TabPage5) = False Then TabControl1.TabPages.Insert(2, TabPage5)
        TabControl1.SelectedTab = TabPage5
    End Sub
    Private Sub BtnBck4_Click(sender As Object, e As EventArgs) Handles BtnBck4.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub CmbEvent2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEvent2.SelectedIndexChanged
        TxtUpdt2.ReadOnly = False
        TxtUpdt2.Focus()
    End Sub
    Private Sub TxtUpdt2_Leave(sender As Object, e As EventArgs) Handles TxtUpdt2.Leave
        If TxtUpdt2.TextLength = 0 Then
            CmbEvent2.SelectedIndex = -1
            TxtUpdt2.ReadOnly = True
            LblMsg2.Text = ""
        End If
    End Sub
    Private Sub BtnSubmt2_Click(sender As Object, e As EventArgs) Handles BtnSubmt2.Click
        InsUpdtSub(SqlCuCnt_, CmbEvent2, TxtUpdt2, LblMsg2)
        GetUpdtEvent(SqlCuCnt_)
        UpGrgFrmt(GridUpdt2, "")
    End Sub
    Private Sub AccMskdBx_Leave(sender As Object, e As EventArgs) Handles AccMskdBx.Leave
        Dim PrdRefCount As Integer = 0
        Dim PrdNo As String
        Dim Stat_ As String
        LblDublicate.Text = "Ticket(s) Before :"
        PrdNo = Trim(Mid(AccMskdBx.Text, 1, 4)) & Trim(Mid(AccMskdBx.Text, 6, 4)) & Trim(Mid(AccMskdBx.Text, 11, 4)) & Trim(Mid(AccMskdBx.Text, 16, 4))
        If PrdNo.Length = 16 Then
            If RelatedTable.Rows.Count > 0 Then
                For PrdRefCount = 0 To RelatedTable.Rows.Count - 1
                    If RelatedTable.Rows(PrdRefCount).Item(10).ToString = PrdNo Then
                        If RelatedTable.Rows(PrdRefCount).Item(24) = False Then
                            Stat_ = " ( Open )"
                        Else
                            Stat_ = " ( Closed )"
                        End If
                        LblDublicate.Text &= vbCrLf & "           - " & RelatedTable.Rows(PrdRefCount).Item(3).ToString & Stat_
                        LblDublicate.ForeColor = Color.Red
                        Beep()
                    End If
                Next
            End If
        Else
            LblDublicate.Text = "Ticket(s) Before :"
            LblDublicate.ForeColor = Color.Black
            AccMskdBx.Text = ""
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.TabPages.Contains(TabPage2) = True Then

        If TabControl1.SelectedTab.Name = "TabPage2" Then
            If SerchTxt.Text = "برجاء ادخال كلمات البحث" Then
                SerchTxt.ForeColor = Color.FromArgb(224, 224, 224)
            End If
            SubGrdTikFill(GridTicket, RelatedTable)  'Adjust Fill Table and assign Grid Data source of Ticket Gridview
            FncGrdTickInfo(GridTicket)
        ElseIf TabControl1.SelectedTab.Name = "TabPage4" Then
            GetUpdtEvent(StruGrdTk.Sql)
            GridUpdt.DataSource = UpdtCurrTbl
            Dim FolwID As String = ""
            If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
            UpGrgFrmt(GridUpdt, FolwID)
            If StruGrdTk.Tick = 0 Then
                TabPage4.Text = "Inquiry No. : " & StruGrdTk.TkId
                CmbEvent.Enabled = False
                BtnSubmt.Enabled = False
                CmbEvent.SelectedIndex = -1
                TxtUpdt.Text = ""
                TxtUpdt.ReadOnly = True
                LblMsg.Text = "لا يمكن عمل تحديث على الاستفسار"
                LblMsg.ForeColor = Color.Red
            Else
                TabPage4.Text = "Complaint No. : " & StruGrdTk.TkId
                CmbEvent.Enabled = True
                BtnSubmt.Enabled = True
                If TxtUpdt.TextLength = 0 Then
                    CmbEvent.SelectedIndex = -1
                    TxtUpdt.ReadOnly = True
                End If
                LblMsg.Text = ""
            End If
        ElseIf TabControl1.SelectedTab.Name = "TabPage5" Then
            GetUpdtEvent(SqlCuCnt_)
            GridUpdt2.DataSource = UpdtCurrTbl
            UpGrgFrmt(GridUpdt2, "")
            If TxtUpdt2.TextLength = 0 Then
                CmbEvent2.SelectedIndex = -1
                TxtUpdt2.ReadOnly = True
            End If
            TabPage5.Text = ComRefLbl.Text
        End If
    End Sub
    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        'If GridTicket.Rows.Count = TempData.Count Then        'Because when clear GridView to RePopulate din't Make Error 1019
        If TabControl1.TabPages.Contains(TabPage4) = False Then TabControl1.TabPages.Insert(2, TabPage4)
        TabPage4.Text = "Ticket No.: " & StruGrdTk.TkId & " Updates"
        TabControl1.SelectedTab = TabPage4
        'End If
    End Sub
    Private Sub BtnBckComp_Click(sender As Object, e As EventArgs) Handles BtnBckComp.Click
        BtnDecrease(BtnBckComp)
        TabControl1.TabPages.Remove(TabPage4)
        If TabControl1.TabPages.Contains(TabPage3) = False Then TabControl1.TabPages.Insert(2, TabPage3)
        TabControl1.SelectedTab = TabPage3
    End Sub
    'Private Sub TxtUpdt2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUpdt2.KeyPress
    '    IntUtly.ValdtIntLetter(e)
    'End Sub

    Private Sub GridUpdt_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles GridUpdt.ColumnSortModeChanged
        Dim FolwID As String = ""
        If DBNull.Value.Equals(StruGrdTk.UserId) Then FolwID = "" Else FolwID = StruGrdTk.UserId
        UpGrgFrmt(GridUpdt, FolwID)
    End Sub

    Private Sub IDTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles IDTxtBx.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            IDTxtBx.Text = Clipboard.GetText()
        End If
        IDTxtBx.Text = Mid(IDTxtBx.Text, 1, IDTxtBx.MaxLength)
    End Sub

    Private Sub AccMskdBx_KeyDown(sender As Object, e As KeyEventArgs) Handles AccMskdBx.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            AccMskdBx.Text = Clipboard.GetText()
        End If
        AccMskdBx.Text = Mid(AccMskdBx.Text, 1, AccMskdBx.MaxLength)
    End Sub

    Private Sub GBTxtBx_KeyDown(sender As Object, e As KeyEventArgs) Handles GBTxtBx.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            GBTxtBx.Text = Clipboard.GetText()
        End If
        GBTxtBx.Text = Mid(GBTxtBx.Text, 1, GBTxtBx.MaxLength)
    End Sub

    Private Sub TxtUpdt_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUpdt.KeyDown
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            TxtUpdt.Text = Clipboard.GetText()
        End If
    End Sub

    Private Sub Phon1TxtBx_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Modifiers = Keys.Control Mod e.KeyCode = Keys.V Then
            Phon1TxtBx.Text = Clipboard.GetText()
        End If
        Phon1TxtBx.Text = Mid(Phon1TxtBx.Text, 1, Phon1TxtBx.MaxLength)
    End Sub
    Private Sub GBTxtBx_Enter(sender As Object, e As EventArgs) Handles GBTxtBx.Enter
        InputLanguage.CurrentInputLanguage = EnglishInput
    End Sub

    Private Sub TmrActv_Tick(sender As Object, e As EventArgs) Handles TmrActv.Tick
        Dim Cnter As Integer = 0
        For Cnt_1 = 1 To 11
            If Mid(Phon1TxtBx.Text, Cnt_1, 1).CompareTo("[0-9]*") = 1 Then
                Cnter += 1
            End If
        Next
        If Cnter = Phon1TxtBx.TextLength Then
            PublicCode.InsUpd("UPDATE Int_user SET UsrLastSeen = '" & Format(Now, "yyyy/MM/dd h:mm:ss") & "' WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H")  'Update User Active = false
        End If

    End Sub

    Private Sub RadNID_Click(sender As Object, e As EventArgs) Handles RadNID.Click, RadPss.Click
        IDTxtBx.Text = ""
        If RadNID.Checked = True Then
            IDTxtBx.Tag = "الرقم القومي"
            IDTxtBx.Mask = "00000000000000"
            RadNID.Checked = True
            RadPss.Checked = False
            Label11.Text = "الرقم القومي : "
        Else
            IDTxtBx.Tag = "رقم جواز السفر"
            IDTxtBx.Mask = "AAAAAAAAAAAAAA"
            RadNID.Checked = False
            RadPss.Checked = True
            Label11.Text = "رقم جواز السفر : "
        End If
    End Sub

    Private Sub BtnDublicate_Click(sender As Object, e As EventArgs) Handles BtnDublicate.Click
        DubStr = vbCrLf & vbCrLf & "إضافة تلقائية من النظام: " & vbCrLf & "تم تسجيل هذه الشكوى للعميل عن طريق استخدم زر التكرار"
        ComRefLbl.Text = ""
        For Each ctrl In TabPage1.Controls
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Then
                ctrl.Enabled = True
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = True
            ElseIf TypeOf ctrl Is GroupBox Then
                ctrl.Enabled = True
                Invoke(Sub() ctrl.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2)))
            ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                For Each C In ctrl.Controls
                    If TypeOf C Is FlowLayoutPanel Then
                        For Each H In C.Controls
                            If TypeOf H Is TextBox Or TypeOf H Is MaskedTextBox Then
                                H.Enabled = True
                            ElseIf TypeOf H Is ComboBox Then
                                H.Enabled = True
                            ElseIf TypeOf H Is GroupBox Then
                                H.Enabled = True
                                Invoke(Sub() H.backcolor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2)))
                            End If
                        Next
                    End If
                Next
            End If
        Next
        TreeView1.Enabled = True
        Invoke(Sub() SubmitBtn.Visible = True)
        Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "")
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TabPage1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox3.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox2.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MyGroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        FinancialGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        PostalGroup.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        Timer1.Start()
        Invoke(Sub() BtnDublicate.Visible = False)
    End Sub

    Private Sub CombProdRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CombProdRef.SelectedIndexChanged
        CombProdRef.Width = 25 + CombProdRef.Text.Length * 8
        CombProdRef.Location = New Point(210 - (CombProdRef.Width / 2), 424)
    End Sub

    Private Sub ToolTip1_Draw(sender As Object, e As DrawToolTipEventArgs) Handles ToolTip1.Draw
        e.DrawBackground()
        e.DrawBorder()
        e.DrawText()
    End Sub
    Private Sub TimrPhons_Tick(sender As Object, e As EventArgs) Handles TimrPhons.Tick

        If RadioButton8.Checked = True Then
            If PictureBox1.Size.Width > 29 Then
                PictureBox1.Size = New Point(PictureBox1.Size.Width - 1, 35)
                PictureBox1.Location = New Point(PictureBox1.Location.X + 0.5, PictureBox1.Location.Y + 1)
            Else
                PictureBox1.Size = New Point(PictureBox1.Size.Width + 1, 35)
                PictureBox1.Location = New Point(PictureBox1.Location.X - 0.5, PictureBox1.Location.Y - 1)
            End If
        End If
        If RadioButton9.Checked = True Then
            If PictureBox2.Size.Width > 38 Then
                PictureBox2.Size = New Point(PictureBox2.Size.Width - 1, 33)
                PictureBox2.Location = New Point(PictureBox2.Location.X + 0.5, PictureBox2.Location.Y + 1)
            Else
                PictureBox2.Size = New Point(PictureBox2.Size.Width + 1, 33)
                PictureBox2.Location = New Point(PictureBox2.Location.X - 0.5, PictureBox2.Location.Y - 1)
            End If
        End If
        If RadioButton11.Checked = True Then
            If PictureBox3.Size.Width > 29 Then
                PictureBox3.Size = New Point(PictureBox3.Size.Width - 1, 35)
                PictureBox3.Location = New Point(PictureBox3.Location.X + 0.5, PictureBox3.Location.Y + 1)
            Else
                PictureBox3.Size = New Point(PictureBox3.Size.Width + 1, 35)
                PictureBox3.Location = New Point(PictureBox3.Location.X - 0.5, PictureBox3.Location.Y - 1)
            End If
        End If
        If RadioButton12.Checked = True Then
            If PictureBox4.Size.Width > 38 Then
                PictureBox4.Size = New Point(PictureBox4.Size.Width - 1, 33)
                PictureBox4.Location = New Point(PictureBox4.Location.X + 0.5, PictureBox4.Location.Y + 1)
            Else
                PictureBox4.Size = New Point(PictureBox4.Size.Width + 1, 33)
                PictureBox4.Location = New Point(PictureBox4.Location.X - 0.5, PictureBox4.Location.Y - 1)
            End If
        End If
    End Sub

    Private Sub NewTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
        TimrPhons.Stop()
        TmrActv.Stop()
    End Sub

End Class