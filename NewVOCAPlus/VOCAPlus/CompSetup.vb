Imports Microsoft.VisualBasic.ApplicationServices
Public Class CompSetup
    Dim SQLLclAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim SQLLclAdptr1 As New SqlDataAdapter            'SQL Table Adapter
    Dim sqlComnd As New SqlCommand                    'SQL Command
    Dim CompTable As New DataTable
    Dim c As CheckBox
    Dim BKClr(2) As String
    Dim CntrlAry(11) As String
    Dim TempClr As DataRow                'Store Color Row filtered after tree selection
    Dim TempPrd As DataRow                'Store Product Row filtered after tree selection
    Dim EditDtaRw As DataRow              'DataRaw To Select and Update Data Table
    Dim MendArry As String = ""           'store array on Select
    Dim PrdRef_ As String = ""
    Dim MNGR_ As Integer = 0
    Dim Stat As Boolean
    Dim Suspended_ As String = ""
    Dim Sus_ As String = ""
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub CompSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        Dim UsrIdsTable As New DataTable

        GetTbl("SELECT UsrId, UsrRealNm FROM Int_user WHERE (((UsrRealNm) Like '%' + 'فريق' + '%'));", UsrIdsTable, "000&H")
        UsrIdsTable.Rows.Add("32000", "32000")
        ComboBox1.DataSource = UsrIdsTable
        ComboBox1.DisplayMember = "UsrRealNm"
        ComboBox1.ValueMember = "UsrId"
        'ComboBox1.ResetText()

        For Each c In MendGrp.Controls
            c.Appearance = Appearance.Button
            c.AutoSize = False
            c.Size = New Size(150, 30)
        Next
        ChckColor()

        RadActvs.Checked = True
        RadAcv.Checked = True
Popul_:
        PopulateTree()
    End Sub
    Private Sub ChckColor()
        For Each c In MendGrp.Controls
            If c.TabIndex >= 5 Or c.TabIndex = 2 Or c.TabIndex = 3 Then ' make the first 2 controls and fourth one enabled false and different back color
                If c.Checked = True Then
                    c.BackColor = Color.LimeGreen
                Else
                    c.BackColor = Color.Red
                End If
            End If

        Next
    End Sub
    Private Sub Checkbox_Click(sender As Object, e As EventArgs) Handles ChckBxPh1.Click, ChckBxTrck.Click, ChckBxSrc.Click, ChckBxPh2.Click, ChckBxOff.Click, ChckBxNm.Click, ChckBxID.Click, ChckBxGB.Click, ChckBxDt.Click, ChckBxDist.Click, ChckBxCrd.Click, ChckBxAmnt.Click
        ChckColor()
        Mend()
        ChngSub()
    End Sub
    Private Sub Mend()
        EditDtaRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
        For Each c In MendGrp.Controls
            If c.Checked = True Then
                CntrlAry(c.TabIndex) = "Y"
            Else
                CntrlAry(c.TabIndex) = "X"
            End If
        Next
        Dim fff As String = String.Join("", CntrlAry)
        ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(6) = String.Join("", CntrlAry)
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        On Error Resume Next
        '     TreeView1.SelectedNode.Collapse(False)
        If TreeView1.Nodes.Count = ProdCompTable.Rows.Count Then
            If TreeView1.SelectedNode.Level = 2 Then
                TreeView1.SelectedNode.Parent.Parent.Collapse(False)  'true to leave the child nodes in their Current state; false to collapse the child nodes.
            ElseIf TreeView1.SelectedNode.Level = 1 Then
                TreeView1.SelectedNode.Parent.Collapse(False)
            ElseIf TreeView1.SelectedNode.Level = 0 Then
                TreeView1.SelectedNode.Collapse(False)
            End If
        End If
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Label7.Text = ""
        TempClr = ProdKTable.Rows.Find(Split(TreeView1.SelectedNode.FullPath.ToString, "\")(0))
        BKClr = Split(TempClr.ItemArray(2), ",")

        TreeView1.SelectedNode.Expand()
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        TreeView1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MendGrp.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        GroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))

        TreeComp.Visible = False
        TreeProd.Visible = False
        GroupBox2.Visible = False

        If e.Action <> TreeViewAction.Unknown Then  ' The code only executes if the user caused the checked state to change.
            If (TreeView1.SelectedNode.Level) = 2 Then                              'Only if selected level = 2
                CopyToolStripitem.Enabled = True
                Label6.Visible = False
                TxtBxRef.Visible = False
                TxtFnMngr.Visible = False
                GroupBox1.Visible = True
                MendGrp.Visible = True
                BtSubmit.Enabled = True

                TempPrd = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)

                MendArry = TempPrd.ItemArray(6)
                MNGR_ = TempPrd.ItemArray(8)
                ComboBox1.SelectedValue = MNGR_
                Stat = TempPrd.ItemArray(10)
                LblHelp.Text = TempPrd.ItemArray(11).ToString
                If Stat = False Then
                    RadActv.Checked = True
                    RadSusp.Checked = False
                Else
                    RadActv.Checked = False
                    RadSusp.Checked = True
                End If

                For Cnt_ = 0 To CntrlAry.Count - 1                                  'for each array member
                    CntrlAry(Cnt_) = Mid(TempPrd.ItemArray(6), Cnt_ + 1, 1)
                    For Each c In MendGrp.Controls                                  'for each control
                        If CntrlAry(Cnt_) = "Y" Then
                            If c.TabIndex = Cnt_ Then
                                c.Checked = True                                    'make checked true if Y
                            End If
                        ElseIf CntrlAry(Cnt_) = "X" Then
                            If c.TabIndex = Cnt_ Then
                                c.Checked = False                                   'make checked false if X
                            End If
                        End If
                    Next c
                    ChckColor()                                                     ' call color sub
                Next Cnt_
                For Each c In MendGrp.Controls
                    If c.TabIndex <= 1 Or c.TabIndex = 4 Then ' make the first 2 controls and fourth one enabled false and different back color
                        c.Enabled = False
                        c.BackColor = Color.LightSeaGreen
                    End If
                    If TempClr.ItemArray(0) = 1 Then                                        'if Financial True
                        If c.TabIndex >= 7 And c.TabIndex <= 11 Then         'make financial fields are visible true
                            c.Visible = True
                        ElseIf c.TabIndex = 5 Or c.TabIndex = 6 Then          'make Postal fields are visible false
                            c.Visible = False
                        End If
                    ElseIf TempClr.ItemArray(0) = 2 Then                                    'if Financial false
                        If c.TabIndex >= 7 And c.TabIndex <= 11 Then          'make financial fields are visible false
                            c.Visible = False
                        ElseIf c.TabIndex = 5 Or c.TabIndex = 6 Then          'make Postal fields are visible true
                            c.Visible = True
                        End If
                    Else
                        If c.TabIndex >= 7 And c.TabIndex <= 11 Then          'make financial fields are visible false
                            c.Visible = False
                        ElseIf c.TabIndex = 5 Or c.TabIndex = 6 Then          'make Postal fields are visible false
                            c.Visible = False
                        End If
                    End If
                Next

            ElseIf (TreeView1.SelectedNode.Level) = 1 Then                              'Only if selected level = 2
                CopyToolStripitem.Enabled = False
                TempPrd = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Nodes(0).Name)
                If DBNull.Value.Equals(TempPrd.ItemArray(7)) = False Then
                    TxtBxRef.Text = TempPrd.ItemArray(7)
                    PrdRef_ = TempPrd.ItemArray(7)

                Else
                    TxtBxRef.Text = ""
                    PrdRef_ = ""
                End If
                GroupBox1.Visible = False
                Label6.Visible = True
                TxtBxRef.Visible = True
                MendGrp.Visible = False
                BtSubmit.Enabled = True
                If RadAlls.Checked = True Then
                    GroupBox2.Visible = True
                    TreeComp.Visible = True
                Else
                    GroupBox2.Visible = False
                    TreeComp.Visible = False
                End If
                LblHelp.Text = ""
            Else
                CopyToolStripitem.Enabled = False
                GroupBox1.Visible = False
                MendGrp.Visible = False
                Label6.Visible = False
                TxtBxRef.Visible = False
                BtSubmit.Enabled = False
                TreeComp.Visible = False
                TreeProd.Visible = False
                LblHelp.Text = ""
            End If
            ChngSub()
        End If
    End Sub
    Private Sub BtSubmit_Click(sender As Object, e As EventArgs) Handles BtSubmit.Click
        SSubmit()
        GC.Collect()
    End Sub
    Private Sub SSubmit()
        Dim Err As Boolean = False
        Label7.Text = ""
        If RadSusp.Checked = True Then
            Label7.Text = "لم يتم تفعيل الشكوى"
            Err = True
        End If
        If ComboBox1.Text = "32000" Then
            Label7.Text = "لم يتم تخصيص فريق للشكوى"
            Err = True
        End If
        If String.Join("", CntrlAry) = "YYXXYXXXXXXX" Then
            Label7.Text = "لم يتم تحديد الحقول الإلزامية"
            Err = True
        End If
        If TreeView1.SelectedNode.Level = 2 Then
            If MendArry <> String.Join("", CntrlAry) Or ComboBox1.SelectedValue.ToString <> TxtFnMngr.Text Or Stat <> TempPrd.ItemArray(10) Then
                MendArry = String.Join("", CntrlAry)
                MNGR_ = TempPrd.ItemArray(8)
                Stat = TempPrd.ItemArray(10)
                Dim thisBuilder As SqlCommandBuilder = New SqlCommandBuilder(SQLLclAdptr)
                SQLLclAdptr.SelectCommand = sqlComnd
                SQLLclAdptr.Update(ProdCompTable)
                ChngSub()
            End If
        ElseIf TreeView1.SelectedNode.Level = 1 Then
            If PrdRef_ <> TxtBxRef.Text Then
                If (TxtBxRef.TextLength) = 0 Then
                    InsUpd("update CDProd set PrdRef = NULL  where PrdCd='" & TreeView1.SelectedNode.Name & "';", "0000&H")
                Else
                    InsUpd("update CDProd set PrdRef='" & TxtBxRef.Text & "' where PrdCd='" & TreeView1.SelectedNode.Name & "';", "0000&H")
                    PrdRef_ = TempPrd.ItemArray(7)
                End If

                ChngSub()
                ProdCompTable.Rows.Clear()
                sqlComm.Connection = sqlCon
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm"
                SQLLclAdptr.SelectCommand = sqlComm
                SQLLclAdptr.Fill(ProdCompTable)
                sqlCon.Close()
            End If
        End If
        sqlCon.Close()
        If Err = True Then
            Label7.ForeColor = Color.Red
            Label7.Text &= " - تم التسجيل بنجاح"
        Else
            Label7.ForeColor = Color.Green
            Label7.Text &= "تم التسجيل بنجاح"
        End If

    End Sub
    Private Sub TxtBxRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBxRef.KeyPress
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or Asc(e.KeyChar) = 8 Or (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 45 Or (e.KeyChar) = Chr(8) Then
            '(Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) // Allow Characters CAPS English
            '(Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) // Allow Characters Smale English
            '(Asc(e.KeyChar) >= 199 And Asc(e.KeyChar) <= 237) // Allow characters  Arabic
            '(Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57)  // Allow numbers from 0 to 9
            'Asc(e.KeyChar) = 32  // Allow Space
            'Asc(e.KeyChar) = 8 // Allow backspace
            'Asc(e.KeyChar) = 46  // Allow decimal (dot=.)
            ToolTip1.Hide(ActiveControl)
        Else
            e.Handled = True
            Beep()
            ToolTip1.Show("Allow English Characters and Number From 0 to 9 Only", ActiveControl, 0, 20, 1000)
        End If
    End Sub
    Private Sub TxtBxRef_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtBxRef.KeyUp
        TxtBxRef.Text = UCase(TxtBxRef.Text)
        TxtBxRef.SelectionStart = TxtBxRef.TextLength
        TxtBxRef.SelectionLength = 0
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtFnMngr_Leave(sender As Object, e As EventArgs) Handles TxtFnMngr.Leave
        If TxtFnMngr.TextLength = 0 Then
            MsgInf("لابد من ادخال كود المجموعة")
            TxtFnMngr.Focus()
        End If
    End Sub
    Private Sub ComboBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If ComboBox1.SelectedIndex = -1 Then
            MsgInf("الاختيار غير مدرج بالقائمة")
        End If
    End Sub
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs)
        If ComboBox1.Focused = True Then
            EditDtaRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
            ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(8) = ComboBox1.SelectedValue
            ChngSub()
        End If
    End Sub
    Private Sub ChngSub()
        If TreeView1.SelectedNode.Level = 1 Then
            If PrdRef_ <> TxtBxRef.Text Then
                BtSubmit.Enabled = True
            Else
                BtSubmit.Enabled = False
            End If
        ElseIf TreeView1.SelectedNode.Level = 2 Then
            If MendArry <> String.Join("", CntrlAry) Or ComboBox1.SelectedValue <> MNGR_ Or Stat <> TempPrd.ItemArray(10) Then
                BtSubmit.Enabled = True
            Else
                BtSubmit.Enabled = False
            End If
        Else
            BtSubmit.Enabled = False
        End If
    End Sub
    Private Sub TxtBxRef_TextChanged(sender As Object, e As EventArgs) Handles TxtBxRef.TextChanged
        If TxtBxRef.Focused = True Then
            If TreeView1.SelectedNode.Level = 1 Then
                EditDtaRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Nodes(0).Name)
                If TxtBxRef.TextLength > 0 Then
                    ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(7) = TxtBxRef.Text
                Else
                    ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(7) = DBNull.Value
                End If
                ChngSub()
            End If
        End If


    End Sub
    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadActvs.Click, RadSusps.Click, RadAlls.Click
        PopulateTree()
    End Sub
    Private Sub RadActv_Click(sender As Object, e As EventArgs) Handles RadActv.Click, RadSusp.Click
        EditDtaRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
        If RadActv.Checked = True Then
            ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(10) = False
            TreeView1.SelectedNode.ForeColor = Color.Green
        ElseIf RadSusp.Checked = True Then
            ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Item(10) = True
            TreeView1.SelectedNode.ForeColor = Color.Red
        End If

        ChngSub()
    End Sub
    Private Sub PopulateTree()
        BKClr(0) = 210
        BKClr(1) = 241
        BKClr(2) = 255
        MendGrp.Visible = False
        GroupBox1.Visible = False
        Label6.Visible = False
        TxtBxRef.Visible = False
        BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        MendGrp.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))
        GroupBox1.BackColor = Color.FromArgb(BKClr(0), BKClr(1), BKClr(2))




        RemoveHandler ComboBox1.SelectedValueChanged, AddressOf ComboBox1_SelectedValueChanged
        TreeView1.Nodes.Clear()
        If TreeView1.Nodes.Count = 0 Or TreeView1.Nodes.Count = Nothing Then
            Dim Root As String = ""
            Dim Child1 As String = ""
            TreeView1.ImageList = ImgLst
            ' Populate Main Root

            For Cnt_ = 0 To ProdKTable.Rows.Count - 1
                TreeView1.Nodes.Add(ProdKTable.Rows(Cnt_).Item(0).ToString, ProdKTable.Rows(Cnt_).Item(1).ToString, 1, 3)
            Next


            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX Refill ProdCompTable with SQLLclAdptr to Can Update
            FilPrCpm()
            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


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

            Dim TempNode() As TreeNode
            TreeView1.SelectedNode = Nothing
            ' Populate Complaints Nodes
            For Cnt_ = 0 To ProdCompTable.Rows.Count - 1
                For Cnt_1 = 0 To TreeView1.Nodes.Count - 1
                    For Cnt_2 = 0 To TreeView1.Nodes(Cnt_1).Nodes.Count - 1
                        If Split(TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ToString, ": ")(1) = (ProdCompTable.Rows(Cnt_).Item("PrdNm").ToString) Then
                            TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).Nodes.Add(ProdCompTable.Rows(Cnt_).Item("FnSQL"), ProdCompTable.Rows(Cnt_).Item("CompNm").ToString(), 0, 2)
                            TempNode = TreeView1.Nodes.Find(Val(ProdCompTable.Rows(Cnt_).Item("FnSQL")), True)
                            For gg = 0 To TempNode.Count - 1
                                If TempNode(gg).Level = 2 Then
                                    If ProdCompTable.Rows(Cnt_).Item("FnSusp").ToString = True Then
                                        TempNode(gg).ForeColor = Color.Red
                                    Else
                                        TempNode(gg).ForeColor = Color.Green
                                    End If
                                End If
                            Next
                            TreeView1.Nodes(Cnt_1).Nodes.Item(Cnt_2).ForeColor = Color.FromArgb(165, 42, 42)
                        End If
                    Next Cnt_2
                Next Cnt_1
                WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل " & Cnt_ + 1 & " من " & ProdCompTable.Rows.Count
            Next Cnt_
        End If
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل أنواع الخدمات ..."
        Dim ProdTable As New DataTable
        TreeProd.Nodes.Clear()
        ProdTable.Rows.Clear()
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "SELECT PrdCd, PrdNm, PrdSusp FROM CDProd ORDER BY PrdNm"
        SQLLclAdptr1.SelectCommand = sqlComm
        SQLLclAdptr1.Fill(ProdTable)
        sqlCon.Close()

        Dim PrdNode() As TreeNode
        For ff = 0 To ProdTable.Rows.Count - 1
            TreeProd.Nodes.Add(ProdTable.Rows(ff).Item(0), ProdTable.Rows(ff).Item(1))
            PrdNode = TreeProd.Nodes.Find(ProdTable.Rows(ff).Item(0), True)
            If ProdTable.Rows(ff).Item(2) = True Then
                PrdNode(0).ForeColor = Color.Red
            Else
                PrdNode(0).ForeColor = Color.Green
            End If
        Next
        ProdTable = Nothing
        WelcomeScreen.StatBrPnlAr.Text = ""

        FilComp()
        AddHandler ComboBox1.SelectedValueChanged, AddressOf ComboBox1_SelectedValueChanged
    End Sub
    Private Sub FilPrCpm()
        If RadActvs.Checked = True Then
            Suspended_ = "where FnSusp = 0"
        ElseIf RadSusps.Checked = True Then
            Suspended_ = "where FnSusp = 1"
        ElseIf RadAlls.Checked = True Then
            Suspended_ = ""
        End If
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل أنواع المنتجات ..."
        ProdCompTable.Rows.Clear()
        'ProdCompTable.Columns.Clear()
        sqlComnd.Connection = sqlCon
        sqlComnd.CommandType = CommandType.Text
        sqlComnd.CommandText = "SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd " & Suspended_ & " ORDER BY PrdKind, PrdNm, CompNm"
        SQLLclAdptr.SelectCommand = sqlComnd
        SQLLclAdptr.Fill(ProdCompTable)
        WelcomeScreen.StatBrPnlAr.Text = ""
        sqlCon.Close()
        LblTrCnt.Text = "Tree Nodes Count : " & ProdCompTable.Rows.Count
    End Sub
    Private Sub FilComp()
        Dim primaryKey(0) As DataColumn
        Dim lbl_ As String = ""
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل أنواع الشكاوى ..."
        If RadAcv.Checked = True Then
            Sus_ = "where CompSusp = 0"
            lbl_ = "الحالية"
            Label1.ForeColor = Color.Green
        ElseIf RadSsp.Checked = True Then
            Sus_ = "where CompSusp = 1"
            lbl_ = "الموقوفة"
            Label1.ForeColor = Color.Red
        ElseIf RadAl.Checked = True Then
            Sus_ = ""
            lbl_ = "الكلية"
            Label1.ForeColor = Color.Black
        End If

        TreeComp.Nodes.Clear()
        CompTable.Rows.Clear()
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "SELECT CompCd, CompNm, CompSusp FROM CDComp " & Sus_ & " ORDER BY CompNm"
        SQLLclAdptr1.SelectCommand = sqlComm
        SQLLclAdptr1.Fill(CompTable)
        primaryKey(0) = CompTable.Columns("CompCd")
        CompTable.PrimaryKey = primaryKey
        sqlCon.Close()

        Dim CompNode() As TreeNode
        For ff = 0 To CompTable.Rows.Count - 1
            TreeComp.Nodes.Add(CompTable.Rows(ff).Item(0), CompTable.Rows(ff).Item(1))
            CompNode = TreeComp.Nodes.Find(CompTable.Rows(ff).Item(0), True)
            If CompTable.Rows(ff).Item(2) = True Then
                CompNode(0).ForeColor = Color.Red
            Else
                CompNode(0).ForeColor = Color.Green
            End If
        Next
        Label1.Text = "عدد الشكاوى " & lbl_ & ": " & CompTable.Rows.Count
        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub RadAcv_Click(sender As Object, e As EventArgs) Handles RadAcv.Click, RadSsp.Click, RadAl.Click
        FilComp()
    End Sub
#Region "Old Drag&Drop"
    'Private Sub TreeProd_DragEnter(sender As Object, e As DragEventArgs) Handles TreeProd.DragEnter, TreeView1.DragEnter
    '    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then '  See if TreeNode is being dragged
    '        e.Effect = DragDropEffects.Move                                  '  Found then move effect
    '    Else
    '        e.Effect = DragDropEffects.None '                                   Not found no move
    '    End If
    'End Sub
    'Private Sub TreeProd_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeProd.ItemDrag, TreeView1.ItemDrag
    '    If Strings.Left(e.Item.name, 1) <> "X" Then

    '        Dim tree As TreeView = CType(sender, TreeView)


    '        Dim node As TreeNode
    '        node = tree.GetNodeAt(TreeView1.Location.X, TreeView1.Location.Y)

    '        tree.SelectedNode = node



    '        If Not node Is Nothing Then

    '            tree.DoDragDrop(node.Clone(), DragDropEffects.Copy)
    '        End If



    '        'DoDragDrop(sender.Clone(), DragDropEffects.Copy)  'Set the drag node and initiate the DragDrop
    '    End If
    'End Sub
    'Private Sub TreeProd_DragOver(sender As Object, e As DragEventArgs) Handles TreeProd.DragOver, TreeView1.DragOver
    '    'Check that there is a TreeNode being dragged
    '    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then
    '        Exit Sub
    '    End If
    '    Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
    '    '       When the mouse moves over nodes, it highlighting the node that is the Current drop target
    '    Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
    '    Dim TrgtNode As TreeNode = selectedTreeview.GetNodeAt(pt)
    '    '       See if the targetNode is Currently selected, if so no need to validate again
    '    If Not (selectedTreeview.SelectedNode Is TrgtNode) Then
    '        selectedTreeview.SelectedNode = TrgtNode '             Select the node Currently under the cursor

    '        'Check that the selected node is not the dropNode and also that it is not a child of the dropNode and is an invalid target
    '        Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
    '        Do Until TrgtNode Is Nothing
    '            If TrgtNode Is DrpNode Then
    '                e.Effect = DragDropEffects.None
    '                Exit Sub
    '            End If
    '            TrgtNode = TrgtNode.Parent
    '        Loop
    '    End If
    '    e.Effect = DragDropEffects.Move 'Currently selected node is a suitable target
    'End Sub
    'Private Sub TreeProd_DragDrop(sender As Object, e As DragEventArgs) Handles TreeProd.DragDrop, TreeView1.DragDrop
    '    'Check that there is a TreeNode being dragged
    '    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
    '    Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
    '    Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode) 'Get the TreeNode being dragged
    '    Dim TrgtNode As TreeNode = selectedTreeview.SelectedNode 'The target node was selected from the DragOver event

    '    If TrgtNode Is Nothing Then  '   If there is no target Node do nothing else add it at end of the drop Node as child
    '        Exit Sub
    '    ElseIf DrpNode Is TrgtNode.Parent Then  '    If the  target node is a child in the drope node 
    '        Exit Sub
    '    ElseIf TrgtNode Is DrpNode Then
    '    ElseIf Strings.Left(TrgtNode.Name, 1) <> "X" Then
    '        selectedTreeview.DoDragDrop(DrpNode.Clone(), DragDropEffects.Copy)
    '        DrpNode.Clone()
    '        TrgtNode.Nodes.Add(DrpNode)     '   Add the drop node to tthe new location
    '        Exit Sub
    '    Else
    '        DrpNode.Remove()                '   Remove the drop node from its Current location
    '        TrgtNode.Nodes.Add(DrpNode)     '   Add the drop node to tthe new location
    '    End If
    '    DrpNode.EnsureVisible()
    '    selectedTreeview.SelectedNode = DrpNode ' make the change here of the catagory and sub catagory
    '    DrpNode.Name = Split(DrpNode.Text, "-")(0) & "-" & Strings.Right(TrgtNode.Name, TrgtNode.Name.Length - 1)

    '    'If InsUpd("update int_user set UsrCat = " & TrgtNode.Name & " Where (UsrId = " & Split(DrpNode.Text, "-")(3) & ");") <> Nothing Then
    '    '    MsgErr(Errmsg)
    '    'End If
    'End Sub
#End Region


#Region "New Drag & Drop"
    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles TreeComp.MouseDown
        Dim tree As TreeView = CType(sender, TreeView)
        Dim node As TreeNode
        node = tree.GetNodeAt(e.X, e.Y)
        tree.SelectedNode = node
        If Not node Is Nothing Then
            tree.DoDragDrop(node.Clone(), DragDropEffects.Copy)
        End If
        TreeView1.AllowDrop = True
    End Sub
    Private Sub treeTwo_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView1.DragOver, TreeComp.DragOver
        Dim tree As TreeView = CType(sender, TreeView)
        e.Effect = DragDropEffects.None
        If Not e.Data.GetData(GetType(TreeNode)) Is Nothing Then
            Dim pt As New Point(e.X, e.Y)
            pt = tree.PointToClient(pt)
            Dim node As TreeNode = tree.GetNodeAt(pt)
            If Not node Is Nothing Then
                e.Effect = DragDropEffects.Copy
                'tree.SelectedNode = node
            End If
        End If
    End Sub
    Private Sub treeTwo_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView1.DragDrop, TreeComp.DragDrop
        Dim Rslt As DialogResult
        Dim tree As TreeView = CType(sender, TreeView)
        Dim pt As New Point(e.X, e.Y)
        pt = tree.PointToClient(pt)
        Dim node As TreeNode = tree.GetNodeAt(pt)
        If node.Level = 1 Then
            Dim DrgdNode As TreeNode
            DrgdNode = e.Data.GetData(GetType(TreeNode))
            For ff = 0 To node.Nodes.Count - 1
                If node.Nodes(ff).Text = DrgdNode.Text Then
                    MsgBox("الشكوى موجوده بالفعل")
                    tree.SelectedNode = node.Nodes(ff)
                    Exit Sub
                End If
            Next
            Dim CpDtRw As DataRow = CompTable.Rows.Find(TreeComp.SelectedNode.Name)

            If CompTable.Rows(CompTable.Rows.IndexOf(CpDtRw)).Item(2) = True Then
                Rslt = MessageBox.Show("الشكوى التي تم إختيارها موقوفه مؤقتاً يجب تفعيلها أولاً" & vbNewLine & "هل تريد تفعيلها؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                If Rslt = DialogResult.Yes Then
                    InsUpd("update CDComp set CompSusp = 0 where CompCd = '" & DrgdNode.Name & "'", "0000&H")
                    TreeComp.SelectedNode.Remove()
                Else
                    Exit Sub
                End If
            End If


            node.Nodes.Add(DrgdNode.Name, DrgdNode.Text, 0, 2)
            node.Nodes.Item(node.Nodes.Count - 1).ForeColor = Color.Red
            InsUpd("insert into CDFnProd (FnSQL,FnProdCd,FnCompCd,FnMend,FnSusp,FnMngr) values ((SELECT MAX(FnSQL) AS Max_ FROM CDFnProd) + 1 ,
           '" & node.Name & "','" & node.Nodes.Item(node.Nodes.Count - 1).Name & "','" & "YYXXYXXXXXXX" & "'," & 1 & "," & 32000 & " )", "0000&H")
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("SELECT MAX(FnSQL) AS Max_ FROM CDFnProd", tempTable, "0000&H") = Nothing Then
                node.Nodes.Item(node.Nodes.Count - 1).Name = tempTable.Rows(0).Item(0)
                FilPrCpm()
            End If

        Else
            'MsgBox("HHHH")
        End If
    End Sub

#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sss As New Form
        Dim ddd As New DataGridView
        Dim www As New Label
        sss.Size = New Point(1360, 700)
        ddd.Size = New Point(1200, 650)
        ddd.Location = New Point(0, 30)
        sss.Controls.Add(ddd)
        sss.Controls.Add(www)
        sss.StartPosition = FormStartPosition.CenterScreen
        ddd.AllowUserToAddRows = False
        ddd.AllowUserToDeleteRows = False
        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp FROM VwFnProd  ORDER BY PrdKind, PrdNm, CompNm", tempTable, "0000&H")
        ddd.DataSource = ProdCompTable
        For gg = 0 To ddd.Columns.Count - 1
            ddd.Columns(gg).ReadOnly = True
        Next
        www.Text = ProdCompTable.Rows.Count
        sss.Show()
    End Sub

    Private Sub CopyToolStripitem_Click(sender As Object, e As EventArgs) Handles CopyToolStripitem.Click
        Dim Rslt As DialogResult
        If TreeView1.SelectedNode.Level = 2 Then
            EditDtaRw = ProdCompTable.Rows.Find(TreeView1.SelectedNode.Name)
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            If GetTbl("select TkSQL from Tickets where TkFnPrdCd = " & TreeView1.SelectedNode.Name, tempTable, "000&H") = Nothing Then
                If tempTable.Rows.Count = 0 Then
                    Rslt = MessageBox.Show("سيتم حذف شكوى " & Chr(34) & TreeView1.SelectedNode.Text & Chr(34) & " ولا يمكن الرجوع" & vbNewLine & "هل تريد الاستمرار؟", "رسالة معلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
                    If Rslt = DialogResult.Yes Then

                        Try
                            ProdCompTable.Rows(ProdCompTable.Rows.IndexOf(EditDtaRw)).Delete()
                            TreeView1.SelectedNode.Remove()
                            Dim thisBuilder As SqlCommandBuilder = New SqlCommandBuilder(SQLLclAdptr)
                            SQLLclAdptr.SelectCommand = sqlComnd
                            SQLLclAdptr.Update(ProdCompTable)
                            LblTrCnt.Text = "Tree Nodes Count : " & ProdCompTable.Rows.Count
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If
                Else
                    MsgInf("لا يمكن حذف الشكوى حيث أن تم استخدامها في تسجيل عدد " & tempTable.Rows.Count & " شكوى")
                End If
            End If
        End If
    End Sub
End Class