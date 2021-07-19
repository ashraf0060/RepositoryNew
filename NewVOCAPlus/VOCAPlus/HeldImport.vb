Imports System.IO
Imports ExcelDataReader
Imports DataSet = System.Data.DataSet
Public Class HeldImport
    Dim FileName As String
    Dim Ext As String
    Dim dt As New DataTable
    Dim tables As DataTableCollection
    Private Sub HeldImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BTNRecvdAtHld.Enabled = False
        BTNRecvdFrmHld.Enabled = False
    End Sub
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
            Dim currTable As DataTable = tables(ComboBox1.SelectedItem.ToString)
            DataGridView1.DataSource = currTable
            DataGridView1.Rows(0).Selected = True

            If DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Visible) = 17 Then
                BTNRecvdAtHld.Enabled = True
                BTNRecvdFrmHld.Enabled = False
            ElseIf DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Visible) = 25 Then
                BTNRecvdAtHld.Enabled = False
                BTNRecvdFrmHld.Enabled = True
            End If
        Catch ex As Exception
            TxtErr.Text &= Now & " : " & "Reading Error " & ex.Message & vbCrLf
            TxtErr.Refresh()
        End Try
    End Sub
    Private Sub BTNRecvdAtHld_Click(sender As Object, e As EventArgs) Handles BTNRecvdAtHld.Click
        Label1.Text = ""
        TxtErr.Text &= Now & " : " & "Add New Columns" & vbCrLf
        TxtErr.Refresh()
        DataGridView1.Columns.Add("Reason Name1", "Reason Name1")
        DataGridView1.Columns.Add("Hs Action1", "Hs Action1")
        DataGridView1.Columns.Add("Hs Code Content1", "Hs Code Content1")
        DataGridView1.Columns.Add("Keep/Remove", "Keep/Remove")
        DataGridView1.Columns.Add("Country", "Country")

        TxtErr.Text &= Now & " : " & "formating Columns with New Data " & DataGridView1.Rows.Count & vbCrLf
        TxtErr.Refresh()
#Region "Add the five columns with Equation"
        For Cnt_ = 0 To DataGridView1.Rows.Count - 1
            If Cnt_ = 0 Or Cnt_ = DataGridView1.Rows.Count - 1 Then
                DataGridView1.Rows(Cnt_).Cells(17).Value = DataGridView1.Rows(Cnt_).Cells(12).Value
                DataGridView1.Rows(Cnt_).Cells(18).Value = DataGridView1.Rows(Cnt_).Cells(13).Value
                DataGridView1.Rows(Cnt_).Cells(19).Value = DataGridView1.Rows(Cnt_).Cells(14).Value
            End If
            If Cnt_ > 0 And Cnt_ < DataGridView1.Rows.Count - 1 Then
                If DataGridView1.Rows(Cnt_ - 1).Cells(5).Value = DataGridView1.Rows(Cnt_).Cells(5).Value Then
                    DataGridView1.Rows(Cnt_).Cells(17).Value = DataGridView1.Rows(Cnt_ - 1).Cells(17).Value & "|" & DataGridView1.Rows(Cnt_).Cells(12).Value
                    DataGridView1.Rows(Cnt_).Cells(18).Value = DataGridView1.Rows(Cnt_ - 1).Cells(18).Value & "|" & DataGridView1.Rows(Cnt_).Cells(13).Value
                    DataGridView1.Rows(Cnt_).Cells(19).Value = DataGridView1.Rows(Cnt_ - 1).Cells(19).Value & "|" & DataGridView1.Rows(Cnt_).Cells(14).Value
                Else
                    DataGridView1.Rows(Cnt_).Cells(17).Value = DataGridView1.Rows(Cnt_).Cells(12).Value
                    DataGridView1.Rows(Cnt_).Cells(18).Value = DataGridView1.Rows(Cnt_).Cells(13).Value
                    DataGridView1.Rows(Cnt_).Cells(19).Value = DataGridView1.Rows(Cnt_).Cells(14).Value
                End If
            End If
            If Cnt_ < DataGridView1.Rows.Count - 1 Then
                If DataGridView1.Rows(Cnt_).Cells(5).Value = DataGridView1.Rows(Cnt_ + 1).Cells(5).Value Then
                    DataGridView1.Rows(Cnt_).Cells(20).Value = "Remove"
                Else
                    DataGridView1.Rows(Cnt_).Cells(20).Value = "Keep"
                End If
            Else
                DataGridView1.Rows(Cnt_).Cells(20).Value = "Keep"
            End If

            Dim PhCount As Integer = 0
            If DataGridView1.Rows(Cnt_).Cells(10).Value.ToString.Length > 0 Then
                For Phcnt = 0 To Len(DataGridView1.Rows(Cnt_).Cells(10).Value) - 1
                    If IsNumeric(Mid(DataGridView1.Rows(Cnt_).Cells(10).Value, Phcnt + 1, 1)) Then
                        PhCount += 1
                    End If
                Next Phcnt
                If PhCount <> Len(DataGridView1.Rows(Cnt_).Cells(10).Value) Then
                    DataGridView1.Rows(Cnt_).Cells(10).Value = DBNull.Value
                End If
            End If

            DataGridView1.Rows(Cnt_).Cells(21).Value = Mid(DataGridView1.Rows(Cnt_).Cells(5).Value, 12, 2)
        Next Cnt_
#End Region

        Dim EmptyColumn As New DataGridViewTextBoxColumn()
        EmptyColumn.Name = "SQL_"
        EmptyColumn.Width = 20
        DataGridView1.Columns.Insert(0, EmptyColumn)
        TxtErr.Text &= Now & " : " & "Filling New data Table RecieveAtHeld" & vbCrLf
        TxtErr.Refresh()

#Region "Fill New Datatable"
        dt.Rows.Clear()
        dt.Columns.Clear()

        For Cnt_ = 0 To DataGridView1.Columns.Count - 1
            dt.Columns.Add(DataGridView1.Columns(Cnt_).Name)
        Next
        For Cnt_ = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add()
            For Cnt_1 = 0 To DataGridView1.Columns.Count - 1
                dt.Rows(Cnt_).Item(Cnt_1) = (DataGridView1.Rows(Cnt_).Cells(Cnt_1).Value)
            Next
        Next
#End Region

        'TxtErr.Text &= Now & " : " & "Getting Max ID" & vbCrLf
        'TxtErr.Refresh()
        'MaxTable.Rows.Clear()
        'If CSYSGetTbl("select max(ID) As Max_ from RecieveAtHeld", MaxTable) = Nothing Then
        TxtErr.Text &= Now & " : " & "Strting Trans Bulk Records" & vbCrLf
        TxtErr.Refresh()

        sqlComminsert_1.Connection = sqlCon
        sqlComminsert_2.Connection = sqlCon
        sqlComminsert_3.Connection = sqlCon
        sqlComminsert_4.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComminsert_1.CommandType = CommandType.Text
        sqlComminsert_2.CommandType = CommandType.Text
        sqlComminsert_3.CommandType = CommandType.Text
        sqlComminsert_4.CommandType = CommandType.Text
        sqlComminsert_1.CommandText = "INSERT INTO Rsv ( RsvDate, RsvTracing, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDoc, RsvOrgin, RsvType, RsvType1, RsvEmpNm, User_IP, RsvStr, Rsv_Days, HeldID)
                                               SELECT Format([Transaction Date],'yyyy/MM/dd') AS TransactionDate, [Post Id], [Item Weight], [Customer name], [Customer address], [Customer tel no], [Hs Code Content*], [Hs Action*], Country, '0' AS RSVType, 'محجوز' AS RSVType1, " & Usr.PUsrID & " AS [User], '" & OsIP() & "' AS IP_, CASE WHEN substring([Post Id],1,1)='E' then '1' WHEN  substring([Post Id],1,1)='R' THEN '5' ELSE'2' END AS Store, 0 AS RsvDays, ID
                                               FROM RecieveAtHeld
                                               WHERE [Keep/Remove]='Keep' AND Add_ = 0"
        sqlComminsert_2.CommandText = "INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdate_time, RsvUpdateTxt, RsvUpdateUser, User_IP )
                                                       SELECT Rsv.RsvID, Rsv.RsvDate, ' تم حجز الشحنة بتاريخ اليوم بمبني التبادل واللوجيستات بمطار القاهره' AS TXT, " & Usr.PUsrID & " AS [User], '10.10.26.4' AS IP_
                                                       FROM dbo.RecieveAtHeld INNER JOIN dbo.Rsv AS Rsv ON dbo.RecieveAtHeld.ID = Rsv.HeldID WHERE(dbo.RecieveAtHeld.[Keep/Remove] = 'keep') AND (dbo.RecieveAtHeld.Add_ = 0)"
        sqlComminsert_3.CommandText = "UPDATE RecieveAtHeld SET RecieveAtHeld.Add_ = 1 WHERE (((RecieveAtHeld.Add_)=0))"
        sqlComminsert_4.CommandText = "UPDATE RecieveAtHeld SET RecieveAtHeld.Add_Updated = 1 WHERE (((RecieveAtHeld.Add_Updated)=0))"
        Try

            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            Tran = sqlCon.BeginTransaction()

            Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Tran)
            SQLBulkCopy.DestinationTableName = "RecieveAtHeld"

            SQLBulkCopy.ColumnMappings.Add(1, 1)
            SQLBulkCopy.ColumnMappings.Add(2, 2)
            SQLBulkCopy.ColumnMappings.Add(3, 3)
            SQLBulkCopy.ColumnMappings.Add(4, 4)
            SQLBulkCopy.ColumnMappings.Add(5, 5)
            SQLBulkCopy.ColumnMappings.Add(6, 6)
            SQLBulkCopy.ColumnMappings.Add(7, 7)
            SQLBulkCopy.ColumnMappings.Add(8, 8)
            SQLBulkCopy.ColumnMappings.Add(9, 9)
            SQLBulkCopy.ColumnMappings.Add(10, 10)
            SQLBulkCopy.ColumnMappings.Add(11, 11)
            SQLBulkCopy.ColumnMappings.Add(12, 12)
            SQLBulkCopy.ColumnMappings.Add(13, 13)
            SQLBulkCopy.ColumnMappings.Add(14, 14)
            SQLBulkCopy.ColumnMappings.Add(15, 15)
            SQLBulkCopy.ColumnMappings.Add(16, 16)
            SQLBulkCopy.ColumnMappings.Add(17, 17)
            SQLBulkCopy.ColumnMappings.Add(18, 18)
            SQLBulkCopy.ColumnMappings.Add(19, 19)
            SQLBulkCopy.ColumnMappings.Add(20, 20)
            SQLBulkCopy.ColumnMappings.Add(21, 21)
            SQLBulkCopy.ColumnMappings.Add(22, 22)


            SQLBulkCopy.WriteToServer(dt)

            TxtErr.Text &= Now & " : " & "Total Recieved At Held " & (From row As DataGridViewRow In DataGridView1.Rows
                                                                      Where row.Cells(21).Value = "Keep"
                                                                      Select Convert.ToString(row.Cells(21).Value)).Count().ToString("N0") & vbNewLine
            TxtErr.Refresh()
            Label2.Text = DataGridView1.Rows.Count.ToString("N0")


            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_4.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            sqlComminsert_4.ExecuteNonQuery()

            Tran.Commit()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            SQLBulkCopy.Close()
            Label1.Text = "_Done"

            DataGridView1.DataSource = ""
            DataGridView1.Columns.Clear()
            TextBox1.Text = ""
            ComboBox1.Items.Clear()
            TxtErr.Text &= Now & " : " & "Finished Job" & vbCrLf
            TxtErr.Refresh()
        Catch ex As Exception
            Tran.Rollback()
            TxtErr.Text &= Now & " : " & "Job Error " & ex.Message & vbCrLf
            TxtErr.Refresh()
            dt.Rows.Clear()
            dt.Columns.Clear()
        End Try
        'Else
        '    TxtErr.Text &= Now & " : " & "Failed To Insert To RSV and Updates " & vbCrLf
        '    TxtErr.Refresh()
        '    dt.Rows.Clear()
        '    dt.Columns.Clear()
        'End If
        '    Else
        '    TxtErr.Text &= Now & " : " & "Failed To getting Max " & vbCrLf
        '    TxtErr.Refresh()
        '    dt.Rows.Clear()
        '    dt.Columns.Clear()
        'End If


    End Sub
    Private Function CSYSGetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            SQLTblAdptr.Fill(SqlTbl)
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)

        Catch ex As Exception
            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Label2.Text = DataGridView1.CurrentRow.Index + 1 & " Of " & DataGridView1.Rows.Count.ToString("N0")
    End Sub
    Private Function PrInsUpd(SSqlStr As String) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            'LoadFrm("", 500, 350)
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
    Private Sub BTNRecvdFrmHld_Click(sender As Object, e As EventArgs) Handles BTNRecvdFrmHld.Click
#Region "Fill New Datatable"
        dt.Rows.Clear()
        dt.Columns.Clear()

        dt.Columns.Add("SQL")
        dt.Columns.Add(DataGridView1.Columns(2).Name)
        dt.Columns.Add(DataGridView1.Columns(5).Name)

        TxtErr.Text &= Now & " : " & "Filling Data Tables With " & DataGridView1.Rows.Count & vbCrLf

        For Cnt_ = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add()
            dt.Rows(Cnt_).Item(1) = (DataGridView1.Rows(Cnt_).Cells(2).Value)
            dt.Rows(Cnt_).Item(2) = (DataGridView1.Rows(Cnt_).Cells(5).Value)

        Next
        DataGridView1.DataSource = dt
        Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon)

        SQLBulkCopy.DestinationTableName = "Recieved_From_Customs"
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        SQLBulkCopy.WriteToServer(dt)
        Label2.Text = DataGridView1.Rows.Count.ToString("N0")
        SQLBulkCopy.Close()


#End Region
#Region "Updating Tables"
        TxtErr.Text &= Now & " : " & "Updating Tables " & vbCrLf
        TxtErr.Refresh()

        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        CSYSGetTbl("SELECT Rsv.RsvID FROM Recieved_From_Customs INNER JOIN Rsv ON Recieved_From_Customs.POST_ID = Rsv.RsvTracing WHERE (((Recieved_From_Customs.Updated)=0));", tempTable)
        TxtErr.Text &= Now & " : " & "Total Recieved From Held " & tempTable.Rows.Count & vbCrLf
        TxtErr.Refresh()

        sqlComminsert_1.Connection = sqlCon
        sqlComminsert_2.Connection = sqlCon
        sqlComminsert_3.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComminsert_1.CommandType = CommandType.Text
        sqlComminsert_2.CommandType = CommandType.Text
        sqlComminsert_3.CommandType = CommandType.Text
        sqlComminsert_1.CommandText = "INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdate_time, RsvUpdateTxt, RsvUpdateUser, User_IP )
                                       SELECT Rsv.RsvID, GETDATE() AS Today, 'تم الافراج عن الشحنة بتاريخ اليوم' AS TXT,  " & Usr.PUsrID & ",'" & OsIP() & "'
                                       FROM Recieved_From_Customs INNER JOIN Rsv ON Recieved_From_Customs.POST_ID = Rsv.RsvTracing
                                       WHERE (((Recieved_From_Customs.Updated)=0));"
        sqlComminsert_2.CommandText = "UPDATE Rsv  SET Rsv.RsvType1 = 'مفرج' 
                                       from (SELECT Rsv.RsvType1, Recieved_From_Customs.Updated, POST_ID FROM Recieved_From_Customs INNER JOIN Rsv ON Recieved_From_Customs.POST_ID = Rsv.RsvTracing
                                       WHERE (((Recieved_From_Customs.Updated)=0))) as ddd
                                       INNER JOIN Rsv ON ddd.POST_ID = Rsv.RsvTracing"

        sqlComminsert_3.CommandText = "update Recieved_From_Customs set Updated = 1 where Updated = 0"
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            Tran = sqlCon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_3.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            sqlComminsert_3.ExecuteNonQuery()
            Tran.Commit()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            Label1.Text = "_Done"

            DataGridView1.DataSource = ""
            DataGridView1.Columns.Clear()
            TextBox1.Text = ""
            ComboBox1.Items.Clear()
            TxtErr.Text &= Now & " : " & "Job Finished " & vbCrLf
            TxtErr.Refresh()
        Catch ex As Exception
            Tran.Rollback()
            TxtErr.Text &= Now & " : " & "Job Error " & ex.Message & vbCrLf
            TxtErr.Refresh()
        End Try
#End Region
    End Sub
    Private Sub NTFImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GC.Collect()
        Me.Dispose()
    End Sub
End Class