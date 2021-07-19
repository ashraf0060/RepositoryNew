Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting
Public Class VOCAWedget
    Inherits System.Web.UI.Page
    Dim Errmsg As String
    Dim sqlComm As New SqlCommand                    'SQL Command
    Dim sqlCon1 As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Dim SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Dim IP_ As String
    Dim EnvPerMinTble As New DataTable
    Dim TimeTble As New DataTable
    Dim TickPerCatTble As New DataTable
    Dim UsrPerLocTble As New DataTable
    Dim OpnCompTbl As New DataTable
    Dim PerformerTbl As New DataTable
    Dim LstUpdtTbl As New DataTable
    Dim NotHandledTbl As New DataTable
    Dim TopCompKndTbl As New DataTable
    Private Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlCon1.ConnectionString = strConn
        sqlComm.Connection = sqlCon1
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        'Dim ff As String = ""
        Try
            'If sqlCon1.State = ConnectionState.Closed Then
            '    sqlCon1.ConnectionString = strConn
            '    sqlCon1.Open()
            'End If
            SQLTblAdptr.Fill(SqlTbl)
            'For hh = 0 To SqlTbl.Columns.Count - 1
            '    ff &= SqlTbl.Columns(hh).ColumnName
            'Next
            'Label1.Text = CStr((SqlTbl.Rows.Count)) & "_" & ff
            'sqlCon1.Close()
            'SqlConnection.ClearPool(sqlCon1)
        Catch ex As Exception
            'Label1.Text = ex.Message & "_" & ff
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DropDownList1.DataSource = System.Enum.GetValues(GetType(SeriesChartType))
            DropDownList1.DataBind()
            DropDownList1.SelectedItem.Text = "Column"

            DropDownList2.Items.Add("1")
            DropDownList2.Items.Add("5")
            DropDownList2.Items.Add("10")
            DropDownList2.Items.Add("15")
            DropDownList2.Items.Add("20")
            DropDownList2.Items.Add("30")
            DropDownList2.Items.Add("45")
            DropDownList2.Items.Add("60")
            DropDownList2.SelectedItem.Text = "15"
            'EvntPerMin()
            'CompCountGroup()
            'UserPerLocation()
            'OpenComp()
            'TopPerformer()
            'LstUpdate()
            'NotHandled()
            'TopCompKind()
        End If
        If IsPostBack = False Then
            IP_ = Request.UserHostAddress
            If IP_ = "10.11.56.180" Then
            ElseIf IP_ = "10.11.56.181" Then
            ElseIf IP_ = "10.11.51.232" Then
            ElseIf IP_ = "10.11.51.233" Then
            ElseIf IP_ = "10.10.26.4" Then
                'Else
                '    Server.Transfer("~/NotAllowed.aspx")
                '    Exit Sub
            End If
            TextBox1.Text = CStr(1)
            SlideShow()
        Else

        End If
    End Sub
    Private Sub EvntPerMin()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        EnvPerMinTble.Rows.Clear()

        GetTbl("SELECT FORMAT(TkupSTime, 'mm') AS Min, COUNT(TkupSQL) AS Count
        FROM dbo.TkEvent WHERE (FORMAT(TkupSTime, 'yyyy/MM/dd') = FORMAT(GETDATE(), 'yyyy/MM/dd')) AND 
        (FORMAT(TkupSTime, 'HH') = FORMAT(GETDATE(), 'HH')) GROUP BY FORMAT(TkupSTime, 'mm')
        HAVING (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm')) OR
                                 (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm') - 1) OR
                                 (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm') - 2) OR
                                 (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm') - 3) OR
                                 (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm') - 4) OR
                                 (FORMAT(TkupSTime, 'mm') = FORMAT(GETDATE(), 'mm') - 5)
        ORDER BY Min", EnvPerMinTble)

        'Chart1.Series("Series1").Legend = "Stores"
    End Sub
    Private Sub CompCountGroup()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        TickPerCatTble.Rows.Clear()
        GetTbl("SELECT CASE WHEN CatLvNm IS NULL THEN 'قيد التوزيع' ELSE CatLvNm END As [CatLvNm],  COUNT(dbo.Tickets.TkSQL) AS Count
FROM            dbo.Int_user INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId RIGHT OUTER JOIN
                         dbo.Tickets ON dbo.Int_user.UsrId = dbo.Tickets.TkEmpNm
WHERE        (format(dbo.Tickets.TkDtStart, 'yyyy/MM/dd') = format(GETDATE(), 'yyyy/MM/dd'))
GROUP BY CASE WHEN CatLvNm IS NULL THEN 'قيد التوزيع' ELSE CatLvNm END, dbo.IntUserCatLvCD.CatLvNm  ORDER BY 
     CASE
        WHEN CatLvNm = 'خطوط خلفيه مركز الاتصال' THEN 1
        WHEN CatLvNm = 'موظف خطوط خلفيه' THEN 2
        WHEN CatLvNm = 'مشرف خطوط خلفيه' THEN 3
		WHEN CatLvNm = 'قيد التوزيع' THEN 4
    END", TickPerCatTble)
    End Sub
    Private Sub UserPerLocation()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        UsrPerLocTble.Rows.Clear()
        GetTbl("SELECT        CASE WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 9) = '10.10.200' THEN 'Maadi' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 7) = '10.11.5' THEN 'Sabeel' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 6) 
                         = '10.122' THEN 'Airport' ELSE 'Others' END AS Location, COUNT(dbo.Int_user.UsrCat) AS Count
FROM            dbo.Int_user INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId
WHERE        (format(dbo.Int_user.UsrLastSeen, 'yyyy/MM/dd') = format(getdate(), 'yyyy/MM/dd'))
GROUP BY  CASE WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 9) = '10.10.200' THEN 'Maadi' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 7) 
                         = '10.11.5' THEN 'Sabeel' WHEN SUBSTRING(dbo.Int_user.UsrIP, 1, 6) = '10.122' THEN 'Airport' ELSE 'Others' END
						 order by Count desc", UsrPerLocTble)

    End Sub
    Private Sub OpenComp()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        OpnCompTbl.Rows.Clear()
        GetTbl("SELECT    CatLvNm,  COUNT(dbo.Tickets.TkSQL) AS Count
FROM            dbo.Int_user INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId INNER JOIN
                         dbo.Tickets ON dbo.Int_user.UsrId = dbo.Tickets.TkEmpNm
WHERE     ( Tickets.TkClsStatus = 0)
GROUP BY CatLvNm, dbo.IntUserCatLvCD.CatLvNm 

 ORDER BY 
     CASE
        WHEN CatLvNm = 'خطوط خلفيه مركز الاتصال' THEN 1
        WHEN CatLvNm = 'موظف خطوط خلفيه' THEN 2
        WHEN CatLvNm = 'مشرف خطوط خلفيه' THEN 3
    END", OpnCompTbl)
    End Sub
    Private Sub TopPerformer()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        PerformerTbl.Rows.Clear()
        GetTbl("SELECT TOP (10)  COUNT(DISTINCT dbo.TkEvent.TkupTkSql) AS Count, dbo.Int_user.UsrRealNm + N'(' + SUBSTRING(dbo.IntUserCatLvCD.CatLvNm, 6, 25) + N')' AS EmpNm
                        FROM dbo.IntUserCat INNER JOIN
                         dbo.Int_user ON dbo.IntUserCat.UCatId = dbo.Int_user.UsrCat INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId INNER JOIN
                         dbo.TkEvent INNER JOIN
                         dbo.CDEvent ON dbo.TkEvent.TkupEvtId = dbo.CDEvent.EvId ON dbo.Int_user.UsrId = dbo.TkEvent.TkupUser
WHERE        (CONVERT(VARCHAR, dbo.TkEvent.TkupSTime, 111) = CONVERT(VARCHAR, GETDATE(), 111)) AND (dbo.CDEvent.EvSusp = 0) AND (dbo.IntUserCat.UCatLvl >= 3 AND dbo.IntUserCat.UCatLvl <= 5)
GROUP BY dbo.Int_user.UsrRealNm + N'(' + SUBSTRING(dbo.IntUserCatLvCD.CatLvNm, 6, 25) + N')'
ORDER BY Count DESC", PerformerTbl)
    End Sub
    Private Sub LstUpdate()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        LstUpdtTbl.Rows.Clear()
        GetTbl("SELECT  COUNT(gg.WDays) AS County, 
                         CASE WHEN gg.WDays = 0 THEN 'Same Day' WHEN gg.WDays <= 5 THEN 'One Week' WHEN gg.WDays <= 10 THEN 'Two Weeks' WHEN gg.WDays <= 15 THEN 'Three Weeks' WHEN gg.WDays <= 20 THEN 'One Month' ELSE 'More Than Month' END
                          AS Rang
FROM            (SELECT        dbo.Tickets.TkSQL AS Count_,
                                                        (SELECT        COUNT(HDate) AS WDaysCount
                                                           FROM            dbo.CDHolDay
                                                           WHERE        (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, dbo.TicLstEv.LstUpdtTime, 111) AND CONVERT(DATETIME, GETDATE(), 111))) AS WDays, dbo.IntUserCatLvCD.CatLvNm, 
                                                    dbo.TicLstEv.LstUpdtTime
                           FROM            dbo.IntUserCat INNER JOIN
                                                    dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId INNER JOIN
                                                    dbo.Int_user ON dbo.IntUserCat.UCatId = dbo.Int_user.UsrCat INNER JOIN
                                                    dbo.Tickets INNER JOIN
                                                    dbo.TicLstEv ON dbo.Tickets.TkSQL = dbo.TicLstEv.LstSqlTick ON dbo.Int_user.UsrId = dbo.Tickets.TkEmpNm
                           WHERE        (dbo.Tickets.TkClsStatus = 0)) AS gg
GROUP BY CASE WHEN gg.WDays = 0 THEN 'Same Day' WHEN gg.WDays <= 5 THEN 'One Week' WHEN gg.WDays <= 10 THEN 'Two Weeks' WHEN gg.WDays <= 15 THEN 'Three Weeks' WHEN gg.WDays <= 20 THEN 'One Month' ELSE 'More Than Month' END
ORDER BY County DESC", LstUpdtTbl)

        'Chart5.Legends(0).Docking = Docking.Right
        'Chart5.Legends(0).MaximumAutoSize = 100
        'Chart5.Legends(0).IsEquallySpacedItems = False
        'Chart5.Legends(0).IsTextAutoFit = False
        'Chart5.Legends(0).IsDockedInsideChartArea = True
        'Chart6.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.Line
        ''Chart5.Legends(0).Position.Y = TextOrientation.Rotated90
    End Sub
    Private Sub NotHandled()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        NotHandledTbl.Rows.Clear()
        GetTbl("SELECT  dbo.IntUserCatLvCD.CatLvNm, COUNT(dbo.Tickets.TkSQL) AS Count
FROM            dbo.Int_user INNER JOIN
                         dbo.IntUserCat ON dbo.Int_user.UsrCat = dbo.IntUserCat.UCatId INNER JOIN
                         dbo.IntUserCatLvCD ON dbo.IntUserCat.UCatLvl = dbo.IntUserCatLvCD.CatLvId INNER JOIN
                         dbo.Tickets ON dbo.Int_user.UsrId = dbo.Tickets.TkEmpNm
WHERE        (dbo.Tickets.TkClsStatus = 0) AND (dbo.Tickets.TkFolw = 0)
GROUP BY dbo.IntUserCatLvCD.CatLvNm, dbo.IntUserCatLvCD.CatLvNm", NotHandledTbl)

        ''Chart5.Legends(0).Position.Y = TextOrientation.Rotated90
    End Sub
    Private Sub TopCompKind()
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label1.Text = "Last Update Time : " & Format(TimeTble.Rows(0).Item(0), "HH:mm:ss")
        End If
        TopCompKndTbl.Rows.Clear()
        GetTbl("SELECT        TOP (10) dbo.VwFnProd.CompNm, COUNT(dbo.Tickets.TkSQL) AS Count, dbo.VwFnProd.ProdKNm
FROM            dbo.Tickets INNER JOIN
                         dbo.VwFnProd ON dbo.Tickets.TkFnPrdCd = dbo.VwFnProd.FnSQL
WHERE        (format(dbo.Tickets.TkDtStart, 'yyyy/MM/dd') = format(GETDATE(), 'yyyy/MM/dd'))
GROUP BY dbo.VwFnProd.CompNm, dbo.VwFnProd.ProdKNm
ORDER BY Count DESC", TopCompKndTbl)

        ''Chart5.Legends(0).Position.Y = TextOrientation.Rotated90
    End Sub
    Protected Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If CheckBox1.Checked = False Then
            TextBox1.Text = CStr(CInt(TextBox1.Text) + 1)
            SlideShow()
        Else
            SlideShow()
        End If
    End Sub
    Private Sub SlideShow()
        If CInt(TextBox1.Text) = 1 Then
            EvntPerMin()
            DropDownList1.SelectedItem.Text = "Column"
            Chart1.DataSource = EnvPerMinTble
            Chart1.DataBind()
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "Min"
            'Chart1.Series("Series1").Label = "#VALX"
            Chart1.Series("Series1").Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series("Series1")("ColumnLabelStyle") = "Outside"
            Chart1.Titles.Add(New Title("Evets Per Minute    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
        ElseIf CInt(TextBox1.Text) = 2 Then
            CompCountGroup()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "CatLvNm"
            Chart1.DataSource = TickPerCatTble
            Chart1.DataBind()

            Chart1.Series(0).Label = "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Regular)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            Chart1.Titles.Add(New Title("Today Complaints Per Backline Type    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.DoubleLine
            On Error Resume Next
            Chart1.Series(0).Points(0).Color = Color.Yellow
            Chart1.Series(0).Points(1).Color = Color.Green
            Chart1.Series(0).Points(2).Color = Color.AliceBlue
            Chart1.Series(0).Points(3).Color = Color.Aqua
        ElseIf CInt(TextBox1.Text) = 3 Then
            UserPerLocation()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Doughnut"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "Location"
            Chart1.DataSource = UsrPerLocTble
            Chart1.DataBind()

            'Chart1.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            Chart1.Titles.Add(New Title("Users Count Per Location    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.DoubleLine
        ElseIf CInt(TextBox1.Text) = 4 Then
            OpenComp()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "CatLvNm"
            Chart1.DataSource = OpnCompTbl
            Chart1.DataBind()

            'Chart1.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            Chart1.Titles.Add(New Title("Total Open Complaints    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.DoubleLine
            On Error Resume Next
            Chart1.Series(0).Points(0).Color = Color.Yellow
            Chart1.Series(0).Points(1).Color = Color.Green
            Chart1.Series(0).Points(2).Color = Color.AliceBlue
            Chart1.Series(0).Points(3).Color = Color.Aqua
        ElseIf CInt(TextBox1.Text) = 5 Then
            TopPerformer()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "EmpNm"
            Chart1.DataSource = PerformerTbl
            Chart1.DataBind()


            'Chart1.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Regular)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            'Chart1.ChartAreas(0).AxisX2.TextOrientation = TextOrientation.Rotated90
            Chart1.RightToLeft = RightToLeft.Yes
            'Chart1.ChartAreas(0).AxisX.IntervalType = .Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            Chart1.Titles.Add(New Title("Backline Top 10 Performers    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            'Chart1.Legends(0).Docking = Docking.Right
            'Chart1.Legends(0).MaximumAutoSize = 100
            'Chart1.Legends(0).IsEquallySpacedItems = False
            'Chart1.Legends(0).IsTextAutoFit = False
            'Chart1.Legends(0).IsDockedInsideChartArea = True
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.Line
            ''Chart1.Legends(0).Position.Y = TextOrientation.Rotated90
        ElseIf CInt(TextBox1.Text) = 6 Then
            LstUpdate()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "County"
            Chart1.Series("Series1").XValueMember = "Rang"
            Chart1.DataSource = LstUpdtTbl
            Chart1.DataBind()


            'Chart5.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            'Chart5.ChartAreas(0).AxisX2.TextOrientation = TextOrientation.Rotated90
            Chart1.RightToLeft = RightToLeft.Yes
            'Chart5.ChartAreas(0).AxisX.IntervalType = .Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            Chart1.Titles.Add(New Title("Last Update On Open Complaints    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
        ElseIf CInt(TextBox1.Text) = 7 Then
            NotHandled()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "CatLvNm"
            Chart1.DataSource = NotHandledTbl
            Chart1.DataBind()


            'Chart5.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            'Chart5.ChartAreas(0).AxisX2.TextOrientation = TextOrientation.Rotated90
            Chart1.RightToLeft = RightToLeft.Yes
            'Chart5.ChartAreas(0).AxisX.IntervalType = .Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            Chart1.Titles.Add(New Title("Not Handled Complaints    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            'Chart5.Legends(0).Docking = Docking.Right
            'Chart5.Legends(0).MaximumAutoSize = 100
            'Chart5.Legends(0).IsEquallySpacedItems = False
            'Chart5.Legends(0).IsTextAutoFit = False
            'Chart5.Legends(0).IsDockedInsideChartArea = True
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.DoubleLine
        ElseIf CInt(TextBox1.Text) = 8 Then
            TopCompKind()
            If CheckBox1.Checked = False Then DropDownList1.SelectedItem.Text = "Pie"
            Chart1.Series("Series1").YValueMembers = "Count"
            Chart1.Series("Series1").XValueMember = "CompNm"
            Chart1.DataSource = TopCompKndTbl
            Chart1.DataBind()


            'Chart5.Series(0).Label = "#VALX" & "_" & "#PERCENT{P2}"
            Chart1.Series(0).Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
            Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
            Chart1.Series(0).LegendText = "#VALX"
            'Chart5.ChartAreas(0).AxisX2.TextOrientation = TextOrientation.Rotated90
            Chart1.RightToLeft = RightToLeft.Yes
            'Chart5.ChartAreas(0).AxisX.IntervalType = .Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            Chart1.Titles.Add(New Title("Today Top 10 Complaint    " & CInt(TextBox1.Text) & " Of 8", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))
            Chart1.Series("Series1")("PieLabelStyle") = "Outside"
            'Chart5.Legends(0).Docking = Docking.Right
            'Chart5.Legends(0).MaximumAutoSize = 100
            'Chart5.Legends(0).IsEquallySpacedItems = False
            'Chart5.Legends(0).IsTextAutoFit = False
            'Chart5.Legends(0).IsDockedInsideChartArea = True
            Chart1.Legends(0).ItemColumnSeparator = LegendSeparatorStyle.Line
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Chart1.Series(0).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), DropDownList1.SelectedItem.ToString(), True), SeriesChartType)
        SlideShow()
    End Sub
    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        Timer2.Interval = CInt(DropDownList2.SelectedItem.ToString) * 1000
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'If CheckBox1.Checked = False Then
        '    Timer2.Enabled = True
        'Else
        '    Timer2.Enabled = False
        'End If
    End Sub
    Protected Sub BtnNxt_Click(sender As Object, e As EventArgs) Handles BtnNxt.Click
        Dim Txt As String = ""
        If CInt(TextBox1.Text) = 8 Then
            TextBox1.Text = CStr(8)
            Txt = "Last Record"
            BtnNxt.BackColor = Color.Green
            SlideShow()
        ElseIf CInt(TextBox1.Text) < 8 Then
            TextBox1.Text = CStr(CInt(TextBox1.Text) + 1)
            Txt = CStr(CInt(TextBox1.Text)) & "_" & "Next >>"
            BtnNxt.BackColor = Color.White
            SlideShow()
        End If
        BtnNxt.Text = Txt
    End Sub
    Protected Sub BtnPrv_Click(sender As Object, e As EventArgs) Handles BtnPrv.Click
        Dim Txt As String = ""
        If CInt(TextBox1.Text) = 1 Then
            TextBox1.Text = CStr(1)
            Txt = "First Record"
            BtnPrv.BackColor = Color.Green
            SlideShow()
        ElseIf CInt(TextBox1.Text) >= 2 Then
            TextBox1.Text = CStr(CInt(TextBox1.Text) - 1)
            Txt = "<< Previous" & "_" & CStr(CInt(TextBox1.Text))
            BtnPrv.BackColor = Color.White
            SlideShow()
        End If
        BtnPrv.Text = Txt
    End Sub
End Class