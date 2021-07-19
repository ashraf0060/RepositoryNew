Public Class HeldRepFrm
	Dim NtfTbl As New DataTable
	Private Sub HeldRepFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Size = New Point(screenWidth, screenHeight - 100)
		DataGridView1.Size = New Point(screenWidth - 50, Me.Height - 150)
		'DataGridView1.Location = New Point(screenWidth - 50, screenHeight - 150)
		'strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-2"
		'sqlCon.ConnectionString = strConn
		'ServerNm = "Egypt Post Server"
		tempTable.Rows.Clear()
		tempTable.Columns.Clear()
		GetTbl("SELECT MIN(RsvUpdate_time) AS MinDt FROM RsvUpdate", tempTable, "0000&H")
		DateTimeFrom.MinDate = tempTable.Rows(0).Item(0)
		DateTimeTo.MaxDate = tempTable.Rows(0).Item(0)
		tempTable.Rows.Clear()
		tempTable.Columns.Clear()

		If GetTbl("SELECT Max(RsvUpdate_time) AS MAXDt FROM RsvUpdate", tempTable, "0000&H") = Nothing Then
			DateTimeFrom.MaxDate = tempTable.Rows(0).Item(0)
			DateTimeTo.MaxDate = tempTable.Rows(0).Item(0)
			DateTimeTo.Value = tempTable.Rows(0).Item(0)
			DateTimeFrom.Value = tempTable.Rows(0).Item(0)
		End If
		DataGridView1.DataSource = NtfTbl
		Fillll()
	End Sub
	Private Sub Fillll()
		NtfTbl.Rows.Clear()
		DataGridView1.Visible = False
		Label1.Text = "	جاري تحميل البيانات ......"
		Label1.ForeColor = Color.Green
		Label1.Refresh()
		If GetTbl("SELECT (select IntUserCat.UCatNm from IntUserCat where UsrCat1 = IntUserCat.UCatId )as [الفريق],UserNm as [الموظف],[ تم حجز الشحنة بتاريخ اليوم بمبني التبادل واللوجيستات بمطار القاهره]  aS 'تم حجز',
[تم الافراج عن الشحنة بتاريخ اليوم]AS 'إفراج', [تم عمل الإخطار الورقي الأول] AS'ورقي أول',[تم عمل الإخطار الورقي الثاني] AS'ورقي ثاني',[تم عمل الإخطار الورقي الثالث] AS'ورقي ثالث',[تم طباعة الإخطار تمهيداً لإرسالة] AS'طباعة إخطارات',
	 [تم عمل الإخطار التليفوني الأول] AS'تليفوني أول',[تم عمل الإخطار التليفوني الثاني] AS 'تليفوني ثاني',[تم تسجيل استلام الأوراق] AS'استلام أوراق',[تم تسجيل طباعة أوراق التخليص] As 'طباعة أوراق',
	[تم استبعاد الشحنة من منظومة الإخطارات لعدم اكتمال البيانات المطلوبة] As 'استبعاد',[تم تسجيل ارتداد الاخطار] As 'مرتد', [لم نتمكن من عمل الاخطار التليفوني وتم تحويلها لشاشة الاخطارات الورقية] As 'تحويل لورقي',(
[ تم حجز الشحنة بتاريخ اليوم بمبني التبادل واللوجيستات بمطار القاهره] + [تم الافراج عن الشحنة بتاريخ اليوم] 	+ [تم عمل الإخطار الورقي الأول] + [تم عمل الإخطار الورقي الثاني] +[تم عمل الإخطار الورقي الثالث]  +[تم تسجيل طباعة أوراق التخليص]+[تم طباعة الإخطار تمهيداً لإرسالة] +[تم عمل الإخطار التليفوني الأول]+[تم عمل الإخطار التليفوني الثاني]+[تم تسجيل استلام الأوراق]+
	 [تم استبعاد الشحنة من منظومة الإخطارات لعدم اكتمال البيانات المطلوبة]+[تم تسجيل ارتداد الاخطار]+[لم نتمكن من عمل الاخطار التليفوني وتم تحويلها لشاشة الاخطارات الورقية] ) as [إجمالي]

	 FROM (select  RsvUpdate.RsvUpdateTxt, RsvID,RsvUpdate.RsvUpdateUser,(select UsrRealNm from Int_user where UsrId = RsvUpdateUser )as UserNm,(select UsrCat from Int_user where UsrId = RsvUpdateUser )as UsrCat1
	 from vocaplus.dbo.RsvUpdate 
						WHERE ((SUBSTRING(RsvUpdate.RsvUpdateTxt,1,67) = ' تم حجز الشحنة بتاريخ اليوم بمبني التبادل واللوجيستات بمطار القاهره') or(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,33) = 'تم الافراج عن الشحنة بتاريخ اليوم')
							or(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,27) = 'تم عمل الإخطار الورقي الأول') or 
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,30) = 'تم عمل الإخطار الورقي الثاني') or 
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,28) = 'تم عمل الإخطار الورقي الثالث') or (SUBSTRING(RsvUpdate.RsvUpdateTxt,1,32) = 'تم طباعة الإخطار تمهيداً لإرسالة') OR
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,31) = 'تم عمل الإخطار التليفوني الأول') or (SUBSTRING(RsvUpdate.RsvUpdateTxt,1,31) = 'تم عمل الإخطار التليفوني الثاني') or
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,24) = 'تم تسجيل استلام الأوراق ')  OR (SUBSTRING(RsvUpdate.RsvUpdateTxt,1,28) = 'تم تسجيل طباعة أوراق التخليص') OR
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,67) = 'تم استبعاد الشحنة من منظومة الإخطارات لعدم اكتمال البيانات المطلوبة') or
							(SUBSTRING(RsvUpdate.RsvUpdateTxt,1,23) = 'تم تسجيل ارتداد الاخطار') or (SUBSTRING(RsvUpdate.RsvUpdateTxt,1,69) = 'لم نتمكن من عمل الاخطار التليفوني وتم تحويلها لشاشة الاخطارات الورقية')) 
							AND (format(RsvUpdate.RsvUpdate_time,'yyyy/MM/dd')  between '" & Format(DateTimeFrom.Value, "yyyy/MM/dd") & "' AND '" & Format(DateTimeTo.Value, "yyyy/MM/dd") & "')) PS

							PIVOT (COUNT(RsvID) FOR  RsvUpdateTxt IN ([ تم حجز الشحنة بتاريخ اليوم بمبني التبادل واللوجيستات بمطار القاهره],[تم الافراج عن الشحنة بتاريخ اليوم],[تم عمل الإخطار الورقي الأول],[تم عمل الإخطار الورقي الثاني],[تم عمل الإخطار الورقي الثالث],[تم طباعة الإخطار تمهيداً لإرسالة],
							[تم عمل الإخطار التليفوني الأول],[تم عمل الإخطار التليفوني الثاني],[تم تسجيل استلام الأوراق],[تم تسجيل طباعة أوراق التخليص],
							[تم استبعاد الشحنة من منظومة الإخطارات لعدم اكتمال البيانات المطلوبة],[تم تسجيل ارتداد الاخطار],[لم نتمكن من عمل الاخطار التليفوني وتم تحويلها لشاشة الاخطارات الورقية]
							) ) AS PVT order by  [الفريق],UserNm", NtfTbl, "0000&H") = Nothing Then
			If NtfTbl.Rows.Count > 0 Then
				DataGridView1.Visible = True
			Else
				Label1.Text = "لا توجد بيانات للعرض"
				Label1.ForeColor = Color.Green
			End If
		Else
			Label1.Text = "لم يتمكن من تحميل البياتات"
			Label1.ForeColor = Color.Red
		End If

#Region "Grid Sum Row"

		Dim ff As Integer = NtfTbl.Rows.Count
		NtfTbl.Rows.Add()
		DataGridView1.Rows(ff).Cells(1).Value = "الإجمالي"
		Dim gg As Integer
		For gg = 2 To DataGridView1.Columns.Count - 1
			'NtfTbl.Columns(gg).DataType = GetType(Integer)
			DataGridView1.Rows(ff).Cells(gg).Value = (From row As DataGridViewRow In DataGridView1.Rows
													  Where row.Cells(gg).FormattedValue.ToString() <> String.Empty
													  Select Convert.ToInt64(row.Cells(gg).FormattedValue)).Sum()
		Next

		'DataGridView1.Rows(ff).Cells(1).Value = (From row As DataGridViewRow In DataGridView1.Rows
		'										 Where row.Cells(1).FormattedValue.ToString() <> String.Empty
		'										 Select Convert.ToInt32(row.Cells(2).FormattedValue)).Sum().ToString("N0")
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
		DataGridView1.Rows(ff).DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Bold)
		DataGridView1.Rows(ff).DefaultCellStyle.ForeColor = Color.Green
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

#Region "Adjust Lables"
		'Lbl1.Location = New Point(DataGridView1.GetColumnDisplayRectangle(1, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl2.Location = New Point(DataGridView1.GetColumnDisplayRectangle(2, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl3.Location = New Point(DataGridView1.GetColumnDisplayRectangle(3, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl4.Location = New Point(DataGridView1.GetColumnDisplayRectangle(4, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl5.Location = New Point(DataGridView1.GetColumnDisplayRectangle(5, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl6.Location = New Point(DataGridView1.GetColumnDisplayRectangle(6, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl7.Location = New Point(DataGridView1.GetColumnDisplayRectangle(7, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl8.Location = New Point(DataGridView1.GetColumnDisplayRectangle(8, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl9.Location = New Point(DataGridView1.GetColumnDisplayRectangle(9, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl10.Location = New Point(DataGridView1.GetColumnDisplayRectangle(10, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl11.Location = New Point(DataGridView1.GetColumnDisplayRectangle(11, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl12.Location = New Point(DataGridView1.GetColumnDisplayRectangle(12, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl13.Location = New Point(DataGridView1.GetColumnDisplayRectangle(13, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)
		'Lbl14.Location = New Point(DataGridView1.GetColumnDisplayRectangle(14, False).Location.X + 21, DataGridView1.Location.Y + DataGridView1.Height)

		'Lbl1.Width = DataGridView1.Columns(1).Width
		'Lbl2.Width = DataGridView1.Columns(2).Width
		'Lbl3.Width = DataGridView1.Columns(3).Width
		'Lbl4.Width = DataGridView1.Columns(4).Width
		'Lbl5.Width = DataGridView1.Columns(5).Width
		'Lbl6.Width = DataGridView1.Columns(6).Width
		'Lbl7.Width = DataGridView1.Columns(7).Width
		'Lbl8.Width = DataGridView1.Columns(8).Width
		'Lbl9.Width = DataGridView1.Columns(9).Width
		'Lbl10.Width = DataGridView1.Columns(10).Width
		'Lbl11.Width = DataGridView1.Columns(11).Width
		'Lbl12.Width = DataGridView1.Columns(12).Width
		'Lbl13.Width = DataGridView1.Columns(13).Width
		'Lbl14.Width = DataGridView1.Columns(14).Width
#End Region
	End Sub
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
		Fillll()
	End Sub
End Class