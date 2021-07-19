Imports System.Data.SqlClient
Imports System.Globalization
Imports ClosedXML.Excel

Public Class Analize
    Dim str As String = "[Branch],[Region],[ItemName],[prod type],[Shipment Y/N],[InterDom],[Year],[Month],[Day],[Weight],[Ship],[Rev],[Ship Contribution],[Rev Contribution]"
    Dim filtrStr As String = ""
    Dim Col As Integer
    Dim ShpCol As Integer
    Dim RevCol As Integer
    Dim RevBol As Boolean = False
    Dim ShpBol As Boolean = False
    Dim RevPercBol As Boolean = False
    Dim ShpPercBol As Boolean = False
    Dim Checkbx As New CheckBox
    Dim ChckList As New CheckedListBox
    Dim valuesList As List(Of String)
    Private Sub Analize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        Dim Btn As New Button
        Btn.Text = "Load Data"
        FlowLayoutPanel1.Dock = DockStyle.Top
        FlowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D
        FlowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowOnly
        FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight

        Dim Bool As Boolean = False
        For pp = 0 To Split(str, ",").Count - 1
            Checkbx = New CheckBox
            FlowLayoutPanel1.Controls.Add(Checkbx)
            Checkbx.Name = Split(str, ",")(pp)
            Checkbx.Text = Split(str, ",")(pp)
            Checkbx.Appearance = Appearance.Button
            Checkbx.AutoSize = True
            Checkbx.BackgroundImage = My.Resources.recyellow
            Checkbx.BackgroundImageLayout = ImageLayout.Stretch
            Checkbx.FlatAppearance.BorderColor = Color.White
            Checkbx.FlatStyle = FlatStyle.Flat
            Checkbx.Font = New Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Checkbx.TextAlign = ContentAlignment.MiddleCenter
            If Checkbx.Name = "[Ship]" Or Checkbx.Name = "[Rev]" Or Checkbx.Name = "[Ship Contribution]" Or Checkbx.Name = "[Rev Contribution]" Then
                Checkbx.Checked = True
            End If
            AddHandler Checkbx.MouseClick, AddressOf HandleChekedClick
            AddHandler Checkbx.MouseMove, AddressOf CheckBox_MouseClick
            If pp <= 8 Then
                Dim Tbl As New DataTable
                ChckList = New CheckedListBox
                ChckList.Sorted = True
                ChckList.CheckOnClick = True
                ChckList.ContextMenuStrip = ContextMenuStrip1
                If GetTbl("select " & Split(str, ",")(pp) & " From MainView GROUP BY " & Split(str, ",")(pp) & " Order by " & Split(str, ",")(pp), Tbl) = Nothing Then
                    ChckList.Name = Split(str, ",")(pp)
                    Dim GropBX As New GroupBox
                    GropBX.AutoSize = True
                    GropBX.AutoSizeMode = AutoSizeMode.GrowAndShrink
                    FlowLayoutPanel2.Controls.Add(GropBX)
                    GropBX.Text = Split(str, ",")(pp)
                    GropBX.Controls.Add(ChckList)
                    ChckList.Location = New Point(0, 15)
                    AddHandler ChckList.SelectedValueChanged, AddressOf CheckedListBox1_SelectedValueChanged
                    AddHandler ChckList.MouseEnter, AddressOf ClearChecked
                    Dim lstint As New List(Of Integer)
                    valuesList = New List(Of String)
                    For KKP = 0 To Tbl.Rows.Count - 1
                        valuesList.Add(Tbl.Rows(KKP).Item(0).ToString)
                        lstint.Add(40 + (Tbl.Rows(KKP).Item(0).ToString.Length * 5))
                    Next
                    valuesList.Sort()
                    lstint.Sort()
                    For Each F In valuesList
                        ChckList.Items.Add(F, True)
                    Next
                    ChckList.Width = lstint.Item(lstint.Count - 1)
                Else
                    MsgBox("Err : " & Errmsg)
                End If
            End If
        Next
        Filter_()
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 270)
        DataGridView1.Dock = DockStyle.Bottom
        Colr()
    End Sub
    Private Sub ClearChecked(sender As Object, e As EventArgs)
        ContextMenuStrip1.Items.Clear()
        'Dim sms = (sender.GetCurrentParent()).SourceControl
        ContextMenuStrip1.Items.Add("All")
        AddHandler ContextMenuStrip1.Items(0).Click, AddressOf clear_
    End Sub
    Private Sub clear_(sender As Object, e As EventArgs)
        Dim sms As CheckedListBox = (sender.GetCurrentParent()).SourceControl
        If sms.GetItemChecked(0) = True Then
            For H = 0 To sms.Items.Count - 1
                sms.SetItemChecked(H, False)
            Next
        Else
            For H = 0 To sms.Items.Count - 1
                sms.SetItemChecked(H, True)
            Next
        End If

    End Sub
    Private Sub Colr()
        Dim ChCnt As Integer = 0
        For Each c In Me.FlowLayoutPanel1.Controls
            If TypeOf c Is CheckBox Then
                If c.Checked = True And (c.Name <> "[Ship]" And c.Name <> "[Rev]" And c.Name <> "[Ship Contribution]" And c.Name <> "[Rev Contribution]") Then
                    ChCnt += 1
                End If
                '    End If

                If c.Checked = True Then
                    c.BackgroundImage = My.Resources.recgreen
                    'c.BackColor = Color.LimeGreen
                Else
                    c.BackgroundImage = My.Resources.recyellow
                    'c.BackColor = Color.Aqua
                End If
                For Each G In FlowLayoutPanel2.Controls
                    If c.name = "[" & G.name & "]" Then
                        If c.Checked = False Then
                            FlowLayoutPanel2.Controls.RemoveByKey(G.name)
                        End If
                    End If
                Next
            End If
        Next
        If ChCnt > 0 Then
            BtnLoad.Enabled = True
        Else
            BtnLoad.Enabled = False
        End If
    End Sub
    Private Sub HandleChekedClick(sender As Object, e As EventArgs)
        If sender.Checked = False Then
            If sender.Name = "[Ship]" Then
                For Each A In Me.FlowLayoutPanel1.Controls
                    If TypeOf A Is CheckBox Then
                        If A.name = "[Ship Contribution]" Then
                            A.checked = False
                            ShpPercBol = False
                        End If
                    End If
                Next
                ShpBol = False
            ElseIf sender.Name = "[Rev]" Then
                For Each A In Me.FlowLayoutPanel1.Controls
                    If TypeOf A Is CheckBox Then
                        If A.name = "[Rev Contribution]" Then
                            A.checked = False
                            RevPercBol = False
                        End If
                    End If
                Next
                RevBol = False
            ElseIf sender.Name = "[Ship Contribution]" Then
                ShpPercBol = False
            ElseIf sender.Name = "[Rev Contribution]" Then
                RevPercBol = False
            End If
        ElseIf sender.Checked = True Then
            If sender.Name = "[Ship Contribution]" Then
                For Each A In Me.FlowLayoutPanel1.Controls
                    If TypeOf A Is CheckBox Then
                        If A.name = "[Ship]" Then
                            A.checked = True
                            ShpBol = True
                        End If
                    End If
                Next
                ShpPercBol = True
            ElseIf sender.Name = "[Rev Contribution]" Then
                For Each A In Me.FlowLayoutPanel1.Controls
                    If TypeOf A Is CheckBox Then
                        If A.name = "[Rev]" Then
                            A.checked = True
                            RevBol = True
                        End If
                    End If
                Next
                RevPercBol = True
            End If
        End If
        MainTbl.Rows.Clear()
        MainTbl.Columns.Clear()
        RevBol = False
        ShpBol = False
        BtnChrt.Enabled = False
        Me.Text = "Revenue / Shipment" & " - " & MainTbl.DefaultView.Count
        Colr()
    End Sub
    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Dim PvtCol As String = Nothing
        Dim Tbl As New DataTable
        Dim Pivot As String = ""

        Dim Select_ As List(Of String) = New List(Of String)
        Dim Slct As List(Of String) = New List(Of String)
        Dim Grop As List(Of String) = New List(Of String)
        Dim SlctStr As String
        Dim WdysStr As String = ""

        For Each Ctrl In FlowLayoutPanel4.Controls
            If TypeOf Ctrl Is CheckBox Then
                PvtCol = Ctrl.name
                Slct.Add(PvtCol)
                Grop.Add(PvtCol)
            End If
        Next

        For Each c In FlowLayoutPanel1.Controls
            If TypeOf c Is CheckBox Then
                If c.Checked = True And (c.Name <> "[Ship]" And c.Name <> "[Weight]" And c.Name <> "[Rev]" And c.Name <> "[Ship Contribution]" And c.Name <> "[Rev Contribution]") Then
                    Select_.Add(c.Name)
                    Grop.Add(c.Name)
                    If c.name = "[Branch]" Then
                        'WdysStr = ", ((select [1]+[2]+[3]+[4]+[5]+[6]+[7]+[8]+[9]+[10]+[11]+[12] from (SELECT Month, Day, Branch FROM dbo.MainView GROUP BY Month, Branch, Day) ps pivot(count (Day) for month in ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) as pvt where Branch =  MainView.Branch )) as 'Working Days'"
                    End If
                Else
                    If c.Checked = True Then
                        If c.Name = "[Rev]" Then
                            Slct.Add("cast( CONVERT(Decimal(10,2),SUM(TMPAPOTotalAmount)) as real) As Rev")
                            RevBol = True
                        ElseIf c.Name = "[Ship]" Then
                            Slct.Add("cast(COUNT(TMPAPOTotalAmount) as real) AS Ship")
                            ShpBol = True
                        ElseIf c.Name = "[Weight]" Then
                            Slct.Add("cast(SUM(Weight) as real) AS Weight_")
                        ElseIf c.Name = "[Rev Contribution]" Then
                            Slct.Add("CAST(0.0 AS real) as [Rev Contribution]")
                            RevPercBol = True
                        ElseIf c.Name = "[Ship Contribution]" Then
                            Slct.Add("CAST(0.0 AS real) as [Ship Contribution]")
                            ShpPercBol = True
                        End If
                    End If
                End If
            End If
        Next

        SlctStr = "Select " & String.Join(",", Select_) & "," & String.Join(",", Slct) &
" FROM (select " & String.Join(",", Select_) & " ,Weight,TMPAPOTotalAmount from MainView where " & filtrStr & ") AS ff
GROUP BY " & String.Join(",", Grop)
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        If PvtCol <> Nothing Then
            If GetTbl("select " & PvtCol & " From MainView GROUP BY " & PvtCol & " Order By " & PvtCol, Tbl) = Nothing Then
                Dim PivotCols As List(Of String) = New List(Of String)
                For KKP = 0 To Tbl.Rows.Count - 1
                    PivotCols.Add("[" & Tbl.Rows(KKP).Item(0).ToString & "]")
                Next

                Dim PivtGrp As List(Of String) = New List(Of String)
                For LL = 0 To PivotCols.Count - 1
                    PivtGrp.Add("Sum(" & PivotCols(LL) & ") as " & PivotCols(LL))
                Next
                Dim hh As String = String.Join(",", PivtGrp)
                For Each KL In Grop
                    If KL = PvtCol Then
                        Grop.Remove(KL)
                        Exit For
                    End If
                Next
                Dim SumCount As String
                If RadioButton1.Checked = True Then
                    SumCount = "Sum"
                Else
                    SumCount = "count"
                End If
                Pivot = "Select " & String.Join(",", Grop) & "," & String.Join(",", PivtGrp) & " From (" & "select " & String.Join(",", Select_) & "," & PvtCol & " ,TMPAPOTotalAmount from MainView where " & filtrStr & ") PS PIVOT (" & SumCount & " ([TMPAPOTotalAmount]) for " & PvtCol & " in (" & String.Join(",", PivotCols) & ")) as pvt Group by" & String.Join(",", Grop)
            End If
        End If
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        TxtRevTot.Text = 0
        TxtShpTot.Text = 0

        Dim Last As String = Nothing
        If PvtCol = Nothing Then
            Last = SlctStr & " Order By " & String.Join(",", Select_)
        Else
            Last = Pivot
        End If
        MainTbl.Rows.Clear()
        MainTbl.Columns.Clear()


        Dim SQLAdptr As New SqlDataAdapter
        Errmsg = Nothing
        LoadfFrm("", 350, 500)
        OfflineCon.ConnectionString = ConSTR
        'sqlComm.CommandTimeout = 30
        sqlComm.Connection = OfflineCon
        SQLAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = Last
        Try
            SQLAdptr.Fill(MainTbl)
            Invoke(Sub() DataGridView1.DataSource = MainTbl.DefaultView)
            Me.Text = "Revenue / Shipment" & " - " & MainTbl.Rows.Count
            BtnChrt.Enabled = True

            ShpCol = 0
            RevCol = 0
            For ColCnt = 0 To MainTbl.Columns.Count - 1
                If MainTbl.Columns(ColCnt).DataType.Name.ToString <> "String" Then
                    DataGridView1.Columns(ColCnt).DefaultCellStyle.Format = "#,#0.00"
                    DataGridView1.Columns(ColCnt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

                If MainTbl.Columns(ColCnt).ColumnName = "Ship Contribution" Then
                    ShpCol = ColCnt
                ElseIf MainTbl.Columns(ColCnt).ColumnName = "Rev Contribution" Then
                    RevCol = ColCnt
                End If
            Next
            If PvtCol = Nothing Then
                If RevBol = True Then
                    TxtRevTot.Text = Convert.ToInt32(MainTbl.Compute("SUM(Rev)", String.Empty))
                End If
                If ShpBol = True Then
                    TxtShpTot.Text = MainTbl.Compute("SUM(Ship)", String.Empty)
                End If
                For RowCnt = 0 To MainTbl.Rows.Count - 1
                    If ShpPercBol = True Then
                        MainTbl.Rows(RowCnt).Item(ShpCol) = FormatNumber(MainTbl.Rows(RowCnt).Item("Ship") / Convert.ToInt32(MainTbl.Compute("SUM(Ship)", String.Empty)) * 100,  , TriState.True)
                    End If
                    If RevPercBol = True Then
                        MainTbl.Rows(RowCnt).Item(RevCol) = FormatNumber(MainTbl.Rows(RowCnt).Item("Rev") / Convert.ToInt32(MainTbl.Compute("SUM(Rev)", String.Empty)) * 100,  , TriState.True)
                    End If
                Next
            End If
            LoadFrm.Close()
            DataGridView1.AutoResizeColumns()
        Catch ex As Exception
            BtnChrt.Enabled = False
            Invoke(Sub() LoadFrm.Close())
            MsgBox("Exx : " & ex.Message)
        End Try


    End Sub
    Private Sub Filter_()
        filtrStr = ""
        Dim JJ As String = ""
        Dim ChckChose As List(Of String)
        Dim AND_ As List(Of String) = New List(Of String)
        For Each G As GroupBox In FlowLayoutPanel2.Controls
            If TypeOf G Is GroupBox Then
                Dim HHPP As New CheckedListBox
                HHPP = G.Controls(0)
                ChckChose = New List(Of String)
                For KK = 0 To HHPP.Items.Count - 1
                    If HHPP.GetItemChecked(KK) = True Then
                        ChckChose.Add(HHPP.Name & " ='" & HHPP.Items(KK) & "' ")
                    End If
                Next
                If ChckChose.Count > 0 Then
                    JJ = "(" & String.Join(" or ", ChckChose) & ") "
                End If
                If JJ.Length > 0 Then
                    AND_.Add(JJ)
                End If
            End If
        Next
        If JJ.Length > 0 Then
            filtrStr = "(" & String.Join(" AND ", AND_) & ")"
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnChrt.Click
        Try
            ChartFrm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub BtnExprt_Click(sender As Object, e As EventArgs) Handles BtnExprt.Click
        Exprt("Dynamic View")
    End Sub
    Private Sub CheckedListBox1_SelectedValueChanged(sender As Object, e As EventArgs)
        Filter_()
    End Sub
#Region "Drag & Drop Columns Pivot"
    Private ButtonIndex = 0
    Private DragDropCursor As Cursor
    Private Sub CheckBox_MouseClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim chckBox = DirectCast(sender, CheckBox)
            Using bmp As New Bitmap(chckBox.Width, chckBox.Height)
                chckBox.DrawToBitmap(bmp, New Rectangle(Point.Empty, chckBox.Size))
                DragDropCursor = New Cursor(bmp.GetHicon)
            End Using
            chckBox.Parent.DoDragDrop(chckBox, DragDropEffects.Move)
        End If
    End Sub
    Private Sub FlowLayoutPanel1_DragEnter(sender As Object, e As DragEventArgs) Handles FlowLayoutPanel1.DragEnter, FlowLayoutPanel4.DragEnter
        If e.AllowedEffect = DragDropEffects.Move AndAlso e.Data.GetDataPresent(GetType(CheckBox)) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub
    Private Sub FlowLayoutPanel1_DragDrop(sender As Object, e As DragEventArgs) Handles FlowLayoutPanel1.DragDrop, FlowLayoutPanel4.DragDrop
        Dim Chckboxx = DirectCast(e.Data.GetData(GetType(CheckBox)), CheckBox)
        Dim destPanel = DirectCast(sender, FlowLayoutPanel)
        Chckboxx.Checked = True
        If destPanel.Name = "FlowLayoutPanel4" Then

        For Each V In destPanel.Controls
            If TypeOf V Is CheckBox Then
                V.checked = True
                FlowLayoutPanel1.Controls.Add(V)
                destPanel.Controls.RemoveByKey(V.name)
            End If
        Next

        End If
        destPanel.Controls.Add(Chckboxx)
        Dim targetLoc = destPanel.GetChildAtPoint(destPanel.PointToClient(New Point(e.X, e.Y)))

        If targetLoc IsNot Nothing Then
            Dim idx = destPanel.Controls.GetChildIndex(targetLoc)
            destPanel.Controls.SetChildIndex(Chckboxx, idx)
        End If
    End Sub
    Private Sub OnFlowLayoutPanelGiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles FlowLayoutPanel1.GiveFeedback, FlowLayoutPanel4.GiveFeedback
        e.UseDefaultCursors = False
        Cursor.Current = DragDropCursor
    End Sub
#End Region
#Region "Drap Checkboxlist Item From One To Another"
    Dim itemIndex As Integer
    Private Sub CheckBox1_DragOver(sender As Object, e As DragEventArgs) Handles CheckedListBox2.DragOver, CheckedListBox1.DragOver
        If e.Data.GetDataPresent(GetType(System.String)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub CheckBox1_DragDrop(sender As Object, e As DragEventArgs) Handles CheckedListBox2.DragDrop, CheckedListBox1.DragDrop
        Dim clbSender As CheckedListBox = TryCast(sender, CheckedListBox)
        clbSender.Items.Add(e.Data.GetData(GetType(System.String)).ToString())

        If clbSender.Name = "CheckedListBox1" Then
            CheckedListBox2.Items.RemoveAt(itemIndex)
        Else
            CheckedListBox1.Items.RemoveAt(itemIndex)
        End If
    End Sub
    Private Sub CheckBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListBox2.MouseDown, CheckedListBox1.MouseDown
        Dim clb As CheckedListBox = TryCast(sender, CheckedListBox)
        itemIndex = clb.IndexFromPoint(e.X, e.Y)
        If itemIndex >= 0 And e.Button = MouseButtons.Left Then
            clb.DoDragDrop(clb.Items(itemIndex), DragDropEffects.Move)
        End If
    End Sub
#End Region
End Class