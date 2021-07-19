Public Class MailService

    Dim Tik As Integer = 60
    Dim AAA, BBB As String
    Dim Start_ As New DateTime
    Dim End_ As New DateTime
    Dim Span_ As New TimeSpan
    Private Sub MailService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Span_ = TimeSpan.Parse("01:00:00")
        StatusBarPanel2.Text = "Last Job Was On : " & Now
        StatusBarPanel3.Text = ""
        Dim column As New DataGridViewCheckBoxColumn()
        Dim DailyQury As String = "select MailSTR, MailTo, MailCc, MailSub, MailBody, MailTime, MailRun, MailRule from AutoMail3 where ((MailRun =1));"

        sqlCon = New SqlConnection(strConn)
        sqlComm.Connection = sqlCon
        StatusBarPanel2.Text = "Trying To Open Connecton ........ "
        sqlCon.Open()


        sqlComm.CommandText = DailyQury
        SQLTblAdptr.SelectCommand = sqlComm

        MailTable.Rows.Clear()
        MailTable.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        SQLTblAdptr.Fill(MailTable)

        DataGridView1.ColumnCount = 8
        StatusBarPanel2.Text = "Asking For Required Job ........ "
        For Col = 0 To MailTable.Columns.Count - 1
            DataGridView1.Columns(Col).Name = (MailTable.Columns(Col).Caption.ToString)
        Next Col
        DataGridView1.Columns.Insert(8, column)
        With column
            .HeaderText = "Choose"
            .Name = "Choose"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
        End With


        For Rws = 0 To MailTable.Rows.Count - 1
            DataGridView1.Rows.Add()
            For col = 0 To MailTable.Columns.Count - 1
                DataGridView1.Rows(Rws).Cells(col).Value = MailTable.Rows(Rws).Item(col).ToString
            Next col
        Next Rws


        'AAA = StatusBarPanel2.Text
        'BBB = Now
        'Start_ = Convert.ToDateTime(AAA)
        'End_ = Convert.ToDateTime(BBB)
        'Span_ = End_.Subtract(Start_)

        'Dim ts1 As TimeSpan = TimeSpan.Parse("00:07:00")
        'Dim ts2 As TimeSpan = TimeSpan.Parse("00:03:00")
        'Dim tsSum As TimeSpan = ts1 + ts2
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        SecTimer.Stop()
        StatusBarPanel1.Text = ""
        StatusBarPanel2.Text = "Running Job Now ........ "
        Span_ = TimeSpan.Parse("01:00:00")


        If MailTable.Rows.Count > 0 Then
            Distin = "X"
            StatusBarPanel2.Text = "Running Job No. "
            For AutoMailRWS = 0 To MailTable.Rows.Count - 1                                                         ' For Record Equal True In Mail Table
                StatusBarPanel2.Text = "Running Job No. " & AutoMailRWS + 1 & " Of " & MailTable.Rows.Count
                If MailTable.Rows(AutoMailRWS).Item(7) = "MY,AY,DY" Then                                            ' If Type Equal This MY,AY,DY
                    If Format(MailTable.Rows(AutoMailRWS).Item(5), "HH") = Format(Now, "HH") Then                   'If Hour Of Time Eqaul Hour Of Now
                        Submit()
                    End If
                ElseIf MailTable.Rows(AutoMailRWS).Item(7) = "MY,AY,HY" Then                                          ' If Type Equal This MY,AY,HY
                    If Weekday(Today) < 6 Then                                                                        ' If Today Not Thursday Or Friday
                        If Format(MailTable.Rows(AutoMailRWS).Item(5), "HH") = Format(Now, "HH") Then                 'If Hour Of Time Eqaul Hour Of Now
                            StatusBarPanel3.Text = "Exporting Data ........ "
                            Dim Params(1) As SqlParameter
                            Params(0) = New SqlParameter("@p0", SqlDbType.Date)
                            Params(0).Value = Today
                            Params(1) = New SqlParameter("@p1", SqlDbType.Date)
                            Params(1).Value = Today
                            sqlCon = New SqlConnection(strConn)
                            sqlComm.Connection = sqlCon
                            SQLTblAdptr.SelectCommand = sqlComm
                            sqlComm.CommandType = CommandType.StoredProcedure
                            sqlComm.Parameters.AddRange(Params)
                            sqlComm.CommandText = MailTable.Rows(AutoMailRWS).Item(0).ToString
                            Submit()
                        End If

                    End If
                End If
            Next
        End If
        Timer1.Start()
        SecTimer.Start()
        StatusBarPanel2.Text = "Last Job Was On : " & Now
        StatusBarPanel3.Text = "Next Job On : " & Now.Add(Span_)
        sqlCon.Close()
        SqlConnection.ClearPool(sqlCon)

    End Sub

    Private Sub Submit()

        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        StatusBarPanel3.Text = "Exporting Data ........ "
        DataExpSrv(MailTable.Rows(AutoMailRWS).Item(3).ToString, MailTable.Rows(AutoMailRWS).Item(0).ToString)

        StatusBarPanel3.Text = "Sending Mail ........ "
        SEmail(MailTable.Rows(AutoMailRWS).Item(1).ToString, MailTable.Rows(AutoMailRWS).Item(2).ToString, , MailTable.Rows(AutoMailRWS).Item(3).ToString & " " & Now, "Attached File Information : " & Chr(13) & "Records Count : " & ExpDTable.Rows.Count & Chr(13) & "Columns Count : " & ExpDTable.Columns.Count & Chr(13) & Chr(13) & MailTable.Rows(AutoMailRWS).Item(4).ToString, Distin, "H")


        MailTable.Rows(AutoMailRWS).Item(6) = True
        DataGridView1.Rows(AutoMailRWS).Cells(8).Value = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Params(1) As SqlParameter
        Params(0) = New SqlParameter("@p0", SqlDbType.Date)
        Params(0).Value = "2020/04/09"
        Params(1) = New SqlParameter("@p1", SqlDbType.Date)
        Params(1).Value = "2020/04/09"

        sqlCon = New SqlConnection(strConn)
        sqlComm.Connection = sqlCon
        sqlCon.Open()
        sqlComm.CommandType = CommandType.StoredProcedure
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandText = "RsvEventPV"
        sqlComm.Parameters.AddRange(Params)
        DataExpSrv("Test Notification", "RsvEventPV")

        sqlCon.Close()
        SqlConnection.ClearPool(sqlCon)
        Params(0) = Nothing
        Params(1) = Nothing
    End Sub
    Private Sub SecTimer_Tick(sender As Object, e As EventArgs) Handles SecTimer.Tick
        Dim ts1 As TimeSpan = TimeSpan.Parse("00:00:01")

        StatusBarPanel1.Text = "Next Job Will Be After : " & (Span_ - ts1).ToString
        Span_ = Span_ - ts1
    End Sub

End Class