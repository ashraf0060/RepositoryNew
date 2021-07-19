Public Class HeldDlvryRprt
    Dim NtfTbl As New DataTable

    Private Sub HeldRepFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 100)
        DataGridView1.Size = New Point(screenWidth - 250, Me.Height - 250)
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

        If GetTbl("SELECT   ROW_NUMBER() Over (Order by RsvUpdate.RsvUpdate_time) As [مسلسل],RsvUpdate.RsvUpdate_time as [تاريخ الإستلام], (select rsv.RsvTracing from rsv where rsv.RsvID = RsvUpdate.RsvRelationID) as [رقم الشحنة],(select rsv.RsvConsignee from rsv where rsv.RsvID = RsvUpdate.RsvRelationID) AS [المرسل إلية],
					(select UsrRealNm from Int_user where RsvUpdateUser = UsrId) AS [الموظف]
					FROM RsvUpdate 
					WHERE RsvUpdate.RsvUpdateTxt = 'تم تسجيل طباعة أوراق التخليص' AND FORMAT(RsvUpdate.RsvUpdate_time,'yyyy/MM/dd') between '" & Format(DateTimeFrom.Value, "yyyy/MM/dd") & "' AND '" & Format(DateTimeTo.Value, "yyyy/MM/dd") & "' and  RsvUpdateUser = " & Usr.PUsrID & "
					Order by RsvUpdate.RsvUpdate_time", NtfTbl, "0000&H") = Nothing Then
            If NtfTbl.Rows.Count > 0 Then
                DataGridView1.Visible = True
                DataGridView1.AutoResizeColumns()
            Else
                Label1.Text = "لا توجد بيانات للعرض"
                Label1.ForeColor = Color.Green
            End If
        Else
            Label1.Text = "لم يتمكن من تحميل البياتات"
            Label1.ForeColor = Color.Red
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
		Fillll()
	End Sub
End Class