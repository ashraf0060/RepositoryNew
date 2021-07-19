Imports System.IO
Imports ExcelDataReader
Imports DataSet = System.Data.DataSet
Public Class TicketBulk
    Dim FileName As String
    Dim Ext As String
    Dim TikTbl As New DataTable
    Dim EvTbl As New DataTable
    Dim tables As DataTableCollection
    Private Sub BtnBrws_Click(sender As Object, e As EventArgs) Handles BtnBrws.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "File Upload"
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        fd.Filter = "All Files (*.*)|*.*|Microsoft Excel|*.*XLSX"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        Path.GetFileName(StrFileName)
        If fd.ShowDialog() = DialogResult.OK Then
            StrFileName = fd.FileName
            TextBox1.Text = StrFileName
            FileName = Path.GetFileName(StrFileName)
            Ext = Split(Path.GetFileName(StrFileName), ".")(1)
        End If
        TxtErr.Text &= Now & " : " & "Reading File" & vbCrLf
        TxtErr.Refresh()
        Try
            Using streem = File.Open(StrFileName, FileMode.Open, FileAccess.Read)
                Using Reader As IExcelDataReader = ExcelReaderFactory.CreateReader(streem)
                    Dim result As DataSet = Reader.AsDataSet(New ExcelDataSetConfiguration() With
                                                             {.ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With
                                                             {.UseHeaderRow = True}})
                    tables = result.Tables
                    ComboBox1.Items.Clear()
                    For Each table As DataTable In tables
                        ComboBox1.Items.Add(table.TableName)
                    Next
                End Using
            End Using
            ComboBox1.SelectedIndex = 0
            TxtErr.Text &= Now & " : " & "Filling Data Table" & vbCrLf
            TxtErr.Refresh()
            DataGridView1.DataSource = ""
            DataGridView1.Columns.Clear()
            TikTbl = tables(ComboBox1.SelectedItem.ToString)
            DataGridView1.DataSource = TikTbl
            DataGridView1.Rows(0).Selected = True

        Catch ex As Exception
            TxtErr.Text &= Now & " : " & "Reading Error " & ex.Message & vbCrLf
            TxtErr.Refresh()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Max_Tbl As New DataTable
        Max_Tbl.Rows.Clear()
        GetTbl("select max(Tickets.TkSQL)+1 from Tickets", Max_Tbl, "0000&H")
        Dim dd As Integer = Max_Tbl.Rows(0).Item(0).ToString

        TikTbl.Rows(0).Item(0) = Max_Tbl.Rows(0).Item(0)
        TikTbl.Rows(0).Item(1) = Max_Tbl.Rows(0).Item(0)
        TikTbl.Rows(0).Item(2) = Convert.ToDateTime(Now)
        For ff = 1 To DataGridView1.Rows.Count - 1
            TikTbl.Rows(ff).Item(0) = TikTbl.Rows(ff - 1).Item(0) + 1
            TikTbl.Rows(ff).Item(1) = TikTbl.Rows(ff - 1).Item(0) + 1
            TikTbl.Rows(ff).Item(2) = Convert.ToDateTime(Now)
        Next
#Region "Fill Ticket Datatable"
        'TikTbl.Rows.Clear()
        'TikTbl.Columns.Clear()

        'For Cnt_ = 0 To DataGridView1.Columns.Count - 1
        '    TikTbl.Columns.Add(DataGridView1.Columns(Cnt_).Name)
        'Next
        'For Cnt_ = 0 To DataGridView1.Rows.Count - 1
        '    TikTbl.Rows.Add()
        '    For Cnt_1 = 0 To DataGridView1.Columns.Count - 1
        '        TikTbl.Rows(Cnt_).Item(Cnt_1) = (DataGridView1.Rows(Cnt_).Cells(Cnt_1).Value)
        '    Next
        'Next
#End Region

        'create copy of original datatable (structure)
        EvTbl = TikTbl.Clone()
        'copy data
        EvTbl = TikTbl.Copy()

#Region "Fill Event Datatable"

        EvTbl.Columns(1).ColumnName = "TkupTkSql"
        EvTbl.Columns(2).ColumnName = "TkupSTime"
        EvTbl.Columns(6).ColumnName = "TkupTxt"
        EvTbl.Columns(7).ColumnName = "TkupUnread"
        EvTbl.Columns(8).ColumnName = "TkupEvtId"
        EvTbl.Columns(9).ColumnName = "TkupUserIP"
        EvTbl.Columns(10).ColumnName = "TkupUser"




        For Cnt_ = 0 To EvTbl.Rows.Count - 1
            EvTbl.Rows(Cnt_).Item(6) = "THE COMPLAINT HAS BEEN RECIEVED BY " & Usr.PUsrRlNm
            EvTbl.Rows(Cnt_).Item(7) = True
            EvTbl.Rows(Cnt_).Item(8) = 1000
            EvTbl.Rows(Cnt_).Item(9) = OsIP()
            EvTbl.Rows(Cnt_).Item(10) = Usr.PUsrID
        Next




        EvTbl.Columns.RemoveAt(5)
        EvTbl.Columns.RemoveAt(4)
        EvTbl.Columns.RemoveAt(3)
        EvTbl.Columns.RemoveAt(0)

        DataGridView2.DataSource = EvTbl





#End Region
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        Tran = sqlCon.BeginTransaction()

        Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Tran)
        SQLBulkCopy.DestinationTableName = "Tickets"
        Dim SQLBulkCopy2 As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Tran)
        SQLBulkCopy2.DestinationTableName = "TkEvent"
        Try
            For Each c As DataColumn In EvTbl.Columns
                SQLBulkCopy2.ColumnMappings.Add(c.ColumnName, c.ColumnName)
            Next
            For Each c As DataColumn In TikTbl.Columns
                SQLBulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName)
            Next
            SQLBulkCopy2.WriteToServer(EvTbl)
            SQLBulkCopy.WriteToServer(TikTbl)

            Tran.Commit()
            TxtErr.Text &= Now & " : " & "Total Recieved Complaints :" & TikTbl.Rows.Count
        Catch ex As Exception
            Tran.Rollback()
            TxtErr.Text &= Now & " : " & "Append Error " & ex.Message & "_" & ex.InnerException.Message & vbCrLf
        TxtErr.Refresh()
        End Try


    End Sub
End Class