Imports System.Data.SqlClient
Imports System.Threading

Public Class Form1
    Dim panel1 As New FlowLayoutPanel
    Dim valuesList As List(Of String)
    Dim filtrStr As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            PubVerLbl.Text = "Ver. : " + Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)
        Else
            PubVerLbl.Text = "Publish Ver. : This isn't a Publish version"
        End If
    End Sub
    Private Sub Btn_Click(sender As Object, e As EventArgs)
        MainTbl.Columns.Clear()
        MainTbl.Rows.Clear()
        Dim ConnOff As New Thread(AddressOf RevPerShip)
        ConnOff.IsBackground = True
        If ConnOff.IsAlive = False Then
            ConnOff.Start()
        End If
    End Sub
    Private Sub RevPerShip()
        WDays()
    End Sub
    Private Sub WDays()
        Dim WdysTbl As New DataTable
        Dim Wdys As New Form
        GrdView = New DataGridView
        Wdys.Controls.Add(GrdView)
        If GetTbl("select * from (SELECT Month, Day, Branch FROM dbo.MainView GROUP BY Month, Branch, Day) ps pivot(count (Day) for month in ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) as pvt order by Branch", WdysTbl) = Nothing Then
            GrdView.DataSource = WdysTbl
            GrdView.AllowUserToAddRows = False
            GrdView.AllowUserToDeleteRows = False
            GrdView.ReadOnly = True
            Wdys.WindowState = FormWindowState.Maximized
            GrdView.Dock = DockStyle.Fill
            GrdView.AutoResizeColumns()
            Wdys.Text = "Working Days" & " - " & WdysTbl.Rows.Count
            Invoke(Sub() LoadFrm.Close())
            Wdys.ShowDialog()
            Wdys.Dispose()
            Wdys.Dispose()
        Else
            MsgBox("Exx : " & Errmsg)
        End If
    End Sub
    Private Function Views_(FrmNm As String, SlcStr As String, Bl As Boolean) As String
        Dim ErrFunction As String = Nothing
        Try
            Frm = New Form
            Frm.BackColor = Color.White
            Dim BtnChrt As New Button
            Dim BtnExport As New Button

            CntxStrip = New ContextMenuStrip
            panel1.BorderStyle = BorderStyle.FixedSingle
            panel1.Dock = DockStyle.Top
            panel1.Height = 70
            GrdView = New DataGridView
            GrdView.Height = Screen.PrimaryScreen.Bounds.Height - 150
            Frm.Controls.Add(panel1)
            panel1.BackColor = Color.White
            panel1.Controls.Add(BtnChrt)
            BtnChrt.Text = "Chart"
            AddHandler BtnChrt.Click, AddressOf BtnChart_click
            panel1.Controls.Add(BtnExport)
            BtnExport.BackgroundImage = My.Resources.Export
            BtnExport.FlatStyle = FlatStyle.Flat
            BtnExport.FlatAppearance.BorderColor = Color.White
            BtnExport.BackgroundImageLayout = ImageLayout.Zoom
            BtnExport.Size = New Point(50, 40)
            BtnExport.FlatStyle = FlatStyle.Flat
            AddHandler BtnExport.Click, AddressOf BtnExport_click
            GrdView.BackgroundColor = Color.White
            GrdView.ContextMenuStrip = CntxStrip
            AddHandler GrdView.CellClick, AddressOf renamCol
            CntxStrip.Items.Add("Clear Column")
            AddHandler CntxStrip.Click, AddressOf Removeolumn_Click
            CntxStrip.Items(0).Image = My.Resources._Exit
            Frm.Controls.Add(GrdView)
            GrdView.Dock = DockStyle.Bottom
            MainTbl.Rows.Clear()
            MainTbl.Columns.Clear()
            If GetTbl(SlcStr, MainTbl) = Nothing Then
                GrdView.DataSource = MainTbl
                GrdView.AllowUserToAddRows = False
                GrdView.AllowUserToDeleteRows = False
                GrdView.ReadOnly = True
                Frm.WindowState = FormWindowState.Maximized
                Frm.Text = FrmNm & " - " & MainTbl.Rows.Count
                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                For ColCnt = 0 To MainTbl.Columns.Count - 1
                    If MainTbl.Columns(ColCnt).DataType.Name.ToString <> "String" Then
                        GrdView.Columns(ColCnt).DefaultCellStyle.Format = "#,#0.00"
                        GrdView.Columns(ColCnt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                    'If MainTbl.Columns(ColCnt).ColumnName = "Ship Contribution" Then

                    'ElseIf MainTbl.Columns(ColCnt).ColumnName = "Rev Contribution" Then
                    '    GrdView.Columns(ColCnt).DefaultCellStyle.Format = "#,#0.00"
                    'ElseIf MainTbl.Columns(ColCnt).ColumnName = "Ship" Then
                    '    GrdView.Columns(ColCnt).DefaultCellStyle.Format = "#,#0.00"
                    'ElseIf MainTbl.Columns(ColCnt).ColumnName = "Rev" Then
                    '    GrdView.Columns(ColCnt).DefaultCellStyle.Format = "#,#0.00"
                    'End If
                Next
                If Bl = True Then

                    For RowCnt = 0 To MainTbl.Rows.Count - 1
                        MainTbl.Rows(RowCnt).Item(3) = FormatNumber(MainTbl.Rows(RowCnt).Item("Ship") / Convert.ToInt32(MainTbl.Compute("SUM(Ship)", String.Empty)) * 100,  , TriState.True)
                        MainTbl.Rows(RowCnt).Item(4) = FormatNumber(MainTbl.Rows(RowCnt).Item("Rev") / Convert.ToInt32(MainTbl.Compute("SUM(Rev)", String.Empty)) * 100,  , TriState.True)
                    Next
                End If
                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                GrdView.DefaultCellStyle.Font = New Font("Times New Roman", 12, System.Drawing.FontStyle.Regular)
                GrdView.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 14, System.Drawing.FontStyle.Regular)
                GrdView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GrdView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
                AddHandler Frm.Load, AddressOf Refreshs
                CheckBxLstAdd()
                Frm.ShowDialog()
                Frm.Dispose()
            Else
                MsgBox("Fill Err : " & Errmsg)
            End If

        Catch ex As Exception
            ErrFunction = "X"
            MsgBox("Err Function : " & ex.Message)
        End Try
        Return ErrFunction
    End Function
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CheckBxLstAdd()
        'Dim result As List(Of String)
        For HHJ = 0 To MainTbl.Columns.Count - 1
            Dim ChckList = New CheckedListBox
            ChckList.Sorted = True
            ChckList.CheckOnClick = True
            Dim Bool As Boolean = False
            If MainTbl.Columns(HHJ).DataType.Name.ToString = "String" Or (MainTbl.Columns(HHJ).ColumnName).Contains("Day") Or (MainTbl.Columns(HHJ).ColumnName).Contains("Month") Then
                Dim Tbl As New DataTable
                'Tbl.Columns.Add("")
                'Tbl.Columns(0).DataType = Type.GetType("System.Int32")
                If GetTbl("select [" & MainTbl.Columns(HHJ).ColumnName & "] From MainView GROUP BY [" & MainTbl.Columns(HHJ).ColumnName & "]", Tbl) = Nothing Then
                    If panel1.Controls.Count > 0 Then
                        For Each M In panel1.Controls
                            If TypeOf M Is CheckedListBox Then
                                If M.name = MainTbl.Columns(HHJ).ColumnName Then
                                    Bool = True
                                    ChckList = M
                                End If
                            End If
                        Next
                        If Bool = False Then
                            ChckList.Name = MainTbl.Columns(HHJ).ColumnName
                            panel1.Controls.Add(ChckList)
                            AddHandler ChckList.SelectedValueChanged, AddressOf CheckedListBox1_SelectedValueChanged
                        End If
                    Else
                        ChckList.Name = MainTbl.Columns(HHJ).ColumnName
                        panel1.Controls.Add(ChckList)
                        AddHandler ChckList.SelectedValueChanged, AddressOf CheckedListBox1_SelectedValueChanged
                    End If
                    ChckList.Items.Clear()
                    valuesList = New List(Of String)
                    For KKP = 0 To Tbl.Rows.Count - 1
                        valuesList.Add(Tbl.Rows(KKP).Item(0).ToString)
                        'result = values.Distinct().ToList
                        valuesList.Sort()
                    Next
                    For Each F In valuesList
                        ChckList.Items.Add(F, True)
                    Next
                Else
                    MsgBox("Err : " & Errmsg)
                End If
            End If
        Next
        Me.Refresh()
    End Sub

    Private Sub CheckedListBox1_SelectedValueChanged(sender As Object, e As EventArgs)
        Filter_()
    End Sub

    Private Sub Filter_()
        filtrStr = ""
        Dim JJ As String = ""
        For Each G In panel1.Controls
            If TypeOf G Is CheckedListBox Then
                Dim HHPP As New CheckedListBox
                HHPP = G
                For KK = 0 To HHPP.Items.Count - 1
                    If HHPP.GetItemChecked(KK) = True Then
                        JJ += "[" & G.Name & "] ='" & HHPP.Items(KK) & "' or "
                    End If
                Next
                If JJ.Length > 0 Then
                    JJ = "(" & Mid(JJ, 1, JJ.Length - 4) & ") " & "AND "
                End If
            End If
        Next

        If JJ.Length > 0 Then
            filtrStr = "(" & Mid(JJ, 1, JJ.Length - 5) & ")"
        End If

        MainTbl.DefaultView.RowFilter = filtrStr
        Me.Text = "Revenue / Shipment" & " - " & MainTbl.DefaultView.Count

        'If MainTbl.DefaultView.Count > 0 Then
        '    If RevBol = True Then
        '        TxtRevTot.Text = Convert.ToInt32(MainTbl.Compute("SUM(Rev)", filtrStr))
        '    End If
        '    If ShpBol = True Then
        '        TxtShpTot.Text = Convert.ToInt32(MainTbl.Compute("SUM(Ship)", filtrStr))
        '    End If
        'End If


        'For RowCnt = 0 To MainTbl.DefaultView.Count - 1
        '    If ShpPercBol = True Then
        '        MainTbl.DefaultView(RowCnt).Item(ShpCol) = FormatNumber(MainTbl.DefaultView(RowCnt).Item("Ship") / Convert.ToInt32(MainTbl.Compute("SUM(Ship)", filtrStr)) * 100,  , TriState.True)
        '    End If
        '    If RevPercBol = True Then
        '        MainTbl.DefaultView(RowCnt).Item(RevCol) = FormatNumber(MainTbl.DefaultView(RowCnt).Item("Rev") / Convert.ToInt32(MainTbl.Compute("SUM(Rev)", filtrStr)) * 100,  , TriState.True)
        '    End If
        'Next
        GrdView.AutoResizeColumns()
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX







    Private Sub Refreshs(sender As Object, e As EventArgs)
        GrdView.AutoResizeColumnHeadersHeight()
        GrdView.AutoResizeColumns()
    End Sub

    Private Sub BtnExport_click(sender As Object, e As EventArgs)
        Exprt(Frm.Text)
    End Sub

    Private Sub renamCol(sender As Object, e As DataGridViewCellEventArgs)
        CntxStrip.Items(0).Text = "Delete : " & GrdView.Columns(GrdView.CurrentCell.ColumnIndex).Name
    End Sub

    Private Sub Removeolumn_Click(sender As Object, e As EventArgs)
        MainTbl.Columns.RemoveAt(GrdView.CurrentCell.ColumnIndex)
    End Sub

    Private Sub BtnChart_click(sender As Object, e As EventArgs)
        ChartFrm.ShowDialog()
    End Sub
    Private Sub RegionsView_Click(sender As Object, e As EventArgs) Handles RegionsToolStripMenuItem1.Click
        Views_("Regions View", "Select [Region],COUNT(TMPAPOTotalAmount) AS Ship, CONVERT(Decimal(10,2),SUM(TMPAPOTotalAmount)) As Rev,CAST(0.0 AS real) as [Ship Contribution],CAST(0.0 AS real) as [Rev Contribution] FROM MainView GROUP BY [Region]", True)
    End Sub
    Private Sub RegionsProductTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegionsProductTypeToolStripMenuItem.Click
        Views_("Regions Per Product View-Revenue", "Select [Region],Sum([cartoon]) as [cartoon],Sum([minstry of housing ]) as [minstry of housing ],Sum([postal dom]) as [postal dom],Sum([stamps]) as [stamps],Sum([postal intl]) as [postal intl],Sum([box]) as [box],Sum([other]) as [other],Sum([postal Asyad]) as [postal Asyad],Sum([E Post ]) as [E Post ],Sum([matjar]) as [matjar] From (Select [prod type],COUNT(TMPAPOTotalAmount) AS Ship, CONVERT(Decimal(10,2),SUM(TMPAPOTotalAmount)) As Rev,CAST(0.0 AS real) as [Ship Contribution],CAST(0.0 AS real) as [Rev Contribution],[Region] FROM MainView
GROUP BY [prod type],[Region]) PS PIVOT (Sum([Rev]) for [prod type] in ([cartoon],[minstry of housing ],[postal dom],[stamps],[postal intl],[box],[other],[postal Asyad],[E Post ],[matjar])) as pvt Group by[Region]", False)
    End Sub

    Private Sub WorkingDaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkingDaysToolStripMenuItem.Click
        Dim ConnOff As New Thread(AddressOf WDays)
        ConnOff.IsBackground = True
        If ConnOff.IsAlive = False Then
            ConnOff.Start()
        End If
    End Sub

    Private Sub MainFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainFormToolStripMenuItem.Click
        Analize.Show()
    End Sub
    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ProdGroup.ShowDialog()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Import.ShowDialog()
    End Sub
End Class
