Imports System.Data.SqlClient

Public Class Settings_
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMailNm.Text = My.Settings.MailUsrNm
        TxtMailPassword.Text = My.Settings.MailUsrPass
    End Sub

    Private Sub TxtMailPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtMailPassword.TextChanged
        My.Settings.MailUsrPass = TxtMailPassword.Text
        My.Settings.Save()
    End Sub
    Private Sub TxtMailNm_TextChanged(sender As Object, e As EventArgs) Handles TxtMailNm.TextChanged
        My.Settings.MailUsrNm = TxtMailNm.Text
        My.Settings.Save()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CalTbl As New DataTable
        If GetTbl("select YEAR( [HDate]) from [CDHolDay] group by YEAR( [HDate])", CalTbl) = Nothing Then
            If CalTbl.Rows.Count = 0 Then
                MsgInf("تم تجهيز " & CalTbl.Rows(0).Item(0) & " من قبل")
            Else
                CalTbl = New DataTable
                Dim from_ = Date.ParseExact("2025" & "/01/01", "yyyy/MM/dd", Nothing)
                Dim To_ As DateTime = Convert.ToDateTime("2025" & "-12-31")
                Dim Days As Integer = To_.Subtract(from_).TotalDays + 1
                Dim Weekend As New Integer
                Dim WeekendStr As String

                CalTbl.Columns.Add("[HDate]")
                CalTbl.Columns.Add("[HDay]")
                CalTbl.Columns.Add("[HDayW]")
                CalTbl.Columns.Add("[HDetails]")
                CalTbl.Columns.Add("[HDy]")

                If Weekday(from_) > 5 Then
                    Weekend = 0
                Else
                    Weekend = 1
                End If

                CalTbl.Rows.Add(from_, Format(from_, "dddd"), Weekday(from_), "", Weekend)
                For GG = 1 To Days - 1
                    If Weekday(from_.AddDays(GG)) > 5 Then
                        Weekend = 0
                        WeekendStr = "Week End"
                    Else
                        Weekend = 1
                        WeekendStr = ""
                    End If
                    CalTbl.Rows.Add(from_.AddDays(GG), Format(from_.AddDays(GG), "dddd"), Weekday(from_.AddDays(GG)), WeekendStr, Weekend)
                Next
                If OfflineCon.State = ConnectionState.Closed Then
                    OfflineCon.Open()
                End If
                Tran = OfflineCon.BeginTransaction()
                Try

                    Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(OfflineCon, SqlBulkCopyOptions.Default, Tran)
                    SQLBulkCopy.DestinationTableName = "CDHolDay"

                    'For GG = 0 To CalTbl.Columns.Count - 1
                    '    SQLBulkCopy.ColumnMappings.Add(CalTbl.Columns(GG).ColumnName, CalTbl.Columns(GG).ColumnName)
                    'Next

                    SQLBulkCopy.WriteToServer(CalTbl)
                    Tran.Commit()
                    SQLBulkCopy.Close()
                Catch ex As Exception
                    Tran.Rollback()
                End Try
            End If
        End If
    End Sub
End Class