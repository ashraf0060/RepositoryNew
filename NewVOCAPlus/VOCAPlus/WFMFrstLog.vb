Public Class WFMFrstLog
    Dim NtfTbl As New DataTable
    Dim SabelCnt As Integer
    Dim MaadiCnt As Integer
    Dim AnualCnt As Integer
    Private Sub WFM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
        DataGridView1.Size = New Point(WelcomeScreen.Width - 20, FlowLayoutPanel1.Size.Height - 10 - CmbMonth.Height)
        'DataGridView1.Location = New Point(screenWidth - 50, screenHeight - 150)
        'strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-2"
        'sqlCon.ConnectionString = strConn
        'ServerNm = "Egypt Post Server"
        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'GetTbl("SELECT YEAR(UaccSTime) AS Year_ FROM Int_access GROUP BY YEAR(UaccSTime) ORDER BY Year_", tempTable, "0000&H")
        CmbYear.Items.Add(2020)
        CmbYear.Items.Add(2021)

        For gg = 1 To 12
            CmbMonth.Items.Add(gg)
        Next

        'tempTable.Rows.Clear()
        'tempTable.Columns.Clear()
        'If GetTbl("SELECT Max(UaccSTime) AS MAXDt FROM Int_access", tempTable, "0000&H") = Nothing Then
        '    DateTimeFrom.MaxDate = tempTable.Rows(0).Item(0)
        '    DateTimeTo.MaxDate = tempTable.Rows(0).Item(0)
        '    DateTimeTo.Value = tempTable.Rows(0).Item(0)
        '    DateTimeFrom.Value = tempTable.Rows(0).Item(0)
        'End If
        DataGridView1.DataSource = NtfTbl
        RadioButton1.Checked = True
        AddHandler RadioButton1.CheckedChanged, AddressOf RadioButton1_CheckedChanged
        AddHandler RadioButton2.CheckedChanged, AddressOf RadioButton1_CheckedChanged
    End Sub
    Private Sub Fillll()
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ...................."
        Label1.Text = ""
        Label1.Refresh()
        NtfTbl.Rows.Clear()
        NtfTbl.Columns.Clear()
        DataGridView1.Visible = False
        If GetTbl("SELECT  [Dep.],Team,UaccUsrID,UsrNm,[User Name],replace( max([1]),'1900-01-01 00:00:00.000', '') AS '1',replace( max([2]), '1900-01-01 00:00:00.000' , '' ) AS '2',
                    replace( max([3]), '1900-01-01 00:00:00.000' , '' ) AS '3',replace( max([4]), '1900-01-01 00:00:00.000' , '' ) AS '4',replace( max([5]), '1900-01-01 00:00:00.000' , '' ) AS '5',
                    replace( max([6]) ,'1900-01-01 00:00:00.000' , '' ) AS '6',replace( max([7]), '1900-01-01 00:00:00.000' , '' ) AS '7',replace( max([8]), '1900-01-01 00:00:00.000' , '' ) AS '8',
                    replace( max([9]), '1900-01-01 00:00:00.000' , '' ) AS '9',replace( max([10]), '1900-01-01 00:00:00.000' , '') AS '10',replace( max([11]), '1900-01-01 00:00:00.000' , '' ) AS '11',
                    replace( max([12]), '1900-01-01 00:00:00.000' , '' ) AS '12',replace( max([13]), '1900-01-01 00:00:00.000' , '' ) AS '13',replace( max([14]),'1900-01-01 00:00:00.000' , '' ) AS '14',
                    replace( max([15]), '1900-01-01 00:00:00.000' , '' ) AS '15',replace( max([16]), '1900-01-01 00:00:00.000' , '') '16',replace( max([17]),'1900-01-01 00:00:00.000' , '' ) AS '17',
                    replace( max([18]),'1900-01-01 00:00:00.000' , '' ) AS '18',replace( max([19]), '1900-01-01 00:00:00.000' , '' ) '19',replace( max([20]), '1900-01-01 00:00:00.000' , '' ) AS '20',
                    replace( max([21]), '1900-01-01 00:00:00.000' , '' ) AS '21',replace( max([22]), '1900-01-01 00:00:00.000' , '') AS '22', replace( max([23]), '1900-01-01 00:00:00.000' , '' ) AS '23',
                    replace( max([24]), '1900-01-01 00:00:00.000' , '' ) AS '24',replace( max([25]), '1900-01-01 00:00:00.000' , '' ) AS '25',replace( max([26]), '1900-01-01 00:00:00.000' , '') AS '26',
                    replace( max([27]), '1900-01-01 00:00:00.000' , '' ) AS '27',replace( max([28]), '1900-01-01 00:00:00.000' , '' ) AS '28',replace( max([29]), '1900-01-01 00:00:00.000' , '' ) AS '29',
                    replace( max([30]), '1900-01-01 00:00:00.000' , '' ) AS '30',replace( max([31]), '1900-01-01 00:00:00.000' , '' ) AS '31'

                    FROM (SELECT min(Int_access.UaccSQL) AS Max_Id, format( min( Int_access.UaccSTime),'HH:mm') AS FirstLogin, Int_access.UaccUsrID, Int_user.UsrNm As UsrNm, Int_user.UsrRealNm AS [User Name], Int_user.UsrWv As Waves_,
                    case when SUBSTRING(MAX(DISTINCT Int_access.UaccUsrIP), 1, 9) = '10.10.200' THEN 'MAADI' ELSE 'Sabeel' END AS IPAddress, DAY(Int_access.UaccSTime) AS Day_, Int_user.UsrCat, IntUserCat.UCatNm As Team, IntUserCatLvCD.CatLvNm As [Dep.]
                    FROM Int_access AS Int_access INNER JOIN Int_user ON Int_access.UaccUsrID = Int_user.UsrId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId INNER JOIN IntUserCatLvCD ON IntUserCat.UCatLvl = IntUserCatLvCD.CatLvId 
                    GROUP BY DAY(Int_access.UaccSTime), MONTH(Int_access.UaccSTime),  Int_user.UsrNm, Int_user.UsrRealNm, YEAR(Int_access.UaccSTime), Int_access.UaccUsrID, Int_user.UsrCat, IntUserCat.UCatNm, IntUserCatLvCD.CatLvNm,Int_user.UsrWv
                    HAVING (Year(Int_access.UaccSTime) = '" & CmbYear.SelectedItem.ToString & "') AND (MONTH(Int_access.UaccSTime) = '" & CmbMonth.SelectedItem.ToString & "'))  ps 

                    PIVOT (min(FirstLogin) FOR Day_ IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31])) As pvt
                    --where UaccUsrID = 1190
                    where Waves_ = 1
                    group by Waves_,[Dep.],Team,UsrCat,UaccUsrID,UsrNm,[User Name]
			                    order by [Dep.], Team, [User Name]", NtfTbl, "0000&H") = Nothing Then
            If NtfTbl.Rows.Count > 0 Then
                Label1.Text = "إجمالي العدد " & NtfTbl.Rows.Count
                DataGridView1.Visible = True
                NtfTbl.Rows.Add()
                NtfTbl.Rows.Add()
                NtfTbl.Rows.Add()
                NtfTbl.Columns.Add("Total")
                ConfigGrid()
                ConfigTotal()
                DataGridView1.AutoResizeColumns()
                DataGridView1.EnableHeadersVisualStyles = False
                For YY = 0 To DataGridView1.Columns.Count - 1
                    If YY >= 5 Then
                        DataGridView1.Columns(YY).Width = 40
                        If YY < DataGridView1.Columns.Count - 1 Then
                            If Weekday(CmbYear.SelectedItem.ToString & "/" & CmbMonth.SelectedItem.ToString & "/" & DataGridView1.Columns(YY).HeaderText, FirstDayOfWeek.Sunday) = 6 Or
                                Weekday(CmbYear.SelectedItem.ToString & "/" & CmbMonth.SelectedItem.ToString & "/" & DataGridView1.Columns(YY).HeaderText, FirstDayOfWeek.Sunday) = 7 Then
                                DataGridView1.Columns(YY).HeaderCell.Style.BackColor = Color.Yellow
                            End If
                        End If
                    End If
                    DataGridView1.Columns(YY).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            Else
                DataGridView1.Visible = False
                Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لا توجد بيانات للعرض")
            End If
        Else
            Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "لم يتمكن من تحميل البياتات")
        End If
#Region "Grid Sum Row"

        'DataGridView1.Rows(ff).Cells(2).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(2).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(2).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(3).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(3).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(3).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(4).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(4).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(4).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(5).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(5).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(5).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(6).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(6).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(6).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(7).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(7).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(7).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(8).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(8).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(8).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(9).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										 Where row.Cells(9).FormattedValue.ToString() <> String.Empty
        '										 Select Convert.ToInt32(row.Cells(9).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(10).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										  Where row.Cells(10).FormattedValue.ToString() <> String.Empty
        '										  Select Convert.ToInt32(row.Cells(10).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(11).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										  Where row.Cells(11).FormattedValue.ToString() <> String.Empty
        '										  Select Convert.ToInt32(row.Cells(11).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(12).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										  Where row.Cells(12).FormattedValue.ToString() <> String.Empty
        '										  Select Convert.ToInt32(row.Cells(12).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(13).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										  Where row.Cells(13).FormattedValue.ToString() <> String.Empty
        '										  Select Convert.ToInt32(row.Cells(13).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).Cells(14).Value = (From row As DataGridViewRow In DataGridView1.Rows
        '										  Where row.Cells(14).FormattedValue.ToString() <> String.Empty
        '										  Select Convert.ToInt32(row.Cells(14).FormattedValue)).Sum().ToString("N0")
        'DataGridView1.Rows(ff).DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Bold)
        'DataGridView1.Rows(ff).DefaultCellStyle.ForeColor = Color.Green
#End Region
#Region "Sum Area"
        'Lbl1.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(1).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(1).FormattedValue)).Sum().ToString("N0")
        'Lbl2.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(2).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(2).FormattedValue)).Sum().ToString("N0")
        'Lbl3.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(3).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(3).FormattedValue)).Sum().ToString("N0")
        'Lbl4.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(4).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(4).FormattedValue)).Sum().ToString("N0")
        'Lbl5.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(5).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(5).FormattedValue)).Sum().ToString("N0")
        'Lbl6.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(6).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(6).FormattedValue)).Sum().ToString("N0")
        'Lbl7.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(7).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(7).FormattedValue)).Sum().ToString("N0")
        'Lbl8.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(8).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(8).FormattedValue)).Sum().ToString("N0")
        'Lbl9.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			 Where row.Cells(9).FormattedValue.ToString() <> String.Empty
        '			 Select Convert.ToInt32(row.Cells(9).FormattedValue)).Sum().ToString("N0")
        'Lbl10.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			  Where row.Cells(10).FormattedValue.ToString() <> String.Empty
        '			  Select Convert.ToInt32(row.Cells(10).FormattedValue)).Sum().ToString("N0")
        'Lbl11.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			  Where row.Cells(11).FormattedValue.ToString() <> String.Empty
        '			  Select Convert.ToInt32(row.Cells(11).FormattedValue)).Sum().ToString("N0")
        'Lbl12.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			  Where row.Cells(12).FormattedValue.ToString() <> String.Empty
        '			  Select Convert.ToInt32(row.Cells(12).FormattedValue)).Sum().ToString("N0")
        'Lbl13.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			  Where row.Cells(13).FormattedValue.ToString() <> String.Empty
        '			  Select Convert.ToInt32(row.Cells(13).FormattedValue)).Sum().ToString("N0")
        'Lbl14.Text = (From row As DataGridViewRow In DataGridView1.Rows
        '			  Where row.Cells(14).FormattedValue.ToString() <> String.Empty
        '			  Select Convert.ToInt32(row.Cells(14).FormattedValue)).Sum().ToString("N0")
#End Region

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Fillll()
    End Sub
    Private Sub ConfigGrid()
        'سبيل
        SabelCnt = NtfTbl.Rows.Count - 3
        'معادي
        MaadiCnt = NtfTbl.Rows.Count - 2
        'أجازه
        AnualCnt = NtfTbl.Rows.Count - 1



        DataGridView1.Rows(SabelCnt).Cells(4).Value = "ســـبــيــــل"
        DataGridView1.Rows(MaadiCnt).Cells(4).Value = "مـــــعـــادي"
        DataGridView1.Rows(AnualCnt).Cells(4).Value = "أجـــــــــازه"


        For Cnt_ = 0 To SabelCnt - 1
            Dim Tot As Integer
            For TT = 0 To DataGridView1.Columns.Count - 2
                If TT >= 5 And Cnt_ < SabelCnt Then
                    If DataGridView1.Rows(Cnt_).Cells(TT).Value.ToString.Length > 0 Then Tot += 1
                    If DataGridView1.Rows(Cnt_).Cells(TT).Value.ToString = "Sabeel" Then
                        DataGridView1.Rows(Cnt_).Cells(TT).Style.BackColor = Color.Azure
                    ElseIf DataGridView1.Rows(Cnt_).Cells(TT).Value.ToString = "MAADI" Then
                        DataGridView1.Rows(Cnt_).Cells(TT).Style.BackColor = Color.Beige
                    End If
                End If
            Next

            DataGridView1.Rows(Cnt_).Cells(DataGridView1.Columns.Count - 1).Value = Tot
            Tot = 0
        Next

        DataGridView1.Rows(SabelCnt).DefaultCellStyle.ForeColor = Color.Green
        DataGridView1.Rows(MaadiCnt).DefaultCellStyle.ForeColor = Color.Green
        DataGridView1.Rows(AnualCnt).DefaultCellStyle.ForeColor = Color.Green

        DataGridView1.Rows(SabelCnt).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        DataGridView1.Rows(MaadiCnt).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        DataGridView1.Rows(AnualCnt).DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
    End Sub
    Private Sub ConfigTotal()
        Dim ActCnt As Integer = NtfTbl.Rows.Count - 4
        Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "	جاري تحميل البيانات ......")
        DataGridView1.Visible = False
        For TT = 5 To DataGridView1.Columns.Count - 1
            If RadioButton1.Checked = True Then
                RadioButton1.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                RadioButton2.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                DataGridView1.Rows(SabelCnt).Cells(TT).Value = (From row As DataGridViewRow In DataGridView1.Rows
                                                                Where row.Cells(TT).FormattedValue.ToString() <> String.Empty And
                                                             row.Cells(TT).FormattedValue.ToString() = "Sabeel"
                                                                Select row.Cells(TT).FormattedValue).Count().ToString("N0")
                DataGridView1.Rows(MaadiCnt).Cells(TT).Value = (From row As DataGridViewRow In DataGridView1.Rows
                                                                Where row.Cells(TT).FormattedValue.ToString() <> String.Empty And
                                                             row.Cells(TT).FormattedValue.ToString() = "MAADI"
                                                                Select row.Cells(TT).FormattedValue).Count().ToString("N0")
                DataGridView1.Rows(AnualCnt).Cells(TT).Value = (From row As DataGridViewRow In DataGridView1.Rows
                                                                Where row.Cells(TT).FormattedValue.ToString() = String.Empty
                                                                Select row.Cells(TT).FormattedValue).Count() - 1.ToString("N0")

            ElseIf RadioButton2.Checked = True Then
                RadioButton1.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                RadioButton2.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                DataGridView1.Rows(SabelCnt).Cells(TT).Value = ((From row As DataGridViewRow In DataGridView1.Rows
                                                                 Where row.Cells(TT).FormattedValue.ToString() <> String.Empty And
                                                             row.Cells(TT).FormattedValue.ToString() = "Sabeel"
                                                                 Select row.Cells(TT).FormattedValue).Count() / ActCnt * 100).ToString("N0") & " % "
                DataGridView1.Rows(MaadiCnt).Cells(TT).Value = ((From row As DataGridViewRow In DataGridView1.Rows
                                                                 Where row.Cells(TT).FormattedValue.ToString() <> String.Empty And
                                                             row.Cells(TT).FormattedValue.ToString() = "MAADI"
                                                                 Select row.Cells(TT).FormattedValue).Count() / ActCnt * 100).ToString("N0") & " % "
                DataGridView1.Rows(AnualCnt).Cells(TT).Value = (((From row As DataGridViewRow In DataGridView1.Rows
                                                                  Where row.Cells(TT).FormattedValue.ToString() = String.Empty
                                                                  Select row.Cells(TT).FormattedValue).Count() - 1) / ActCnt * 100).ToString("N0") & " % "
            End If
        Next
        DataGridView1.Visible = True
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        ConfigTotal()
    End Sub
End Class