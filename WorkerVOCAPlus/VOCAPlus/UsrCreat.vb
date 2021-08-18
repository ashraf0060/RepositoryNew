Imports System.IO
Imports ExcelDataReader
Imports DataSet = System.Data.DataSet
Public Class UsrCreat
    Dim FileName As String
    Dim Ext As String
    Dim currTable As DataTable
    Dim tables As DataTableCollection
    Dim Max_ As Integer
    'Public strConn As String = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
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
        TxtErr.Text = Now & " : " & "Reading File" & vbCrLf & TxtErr.Text
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
            TxtErr.Text = Now & " : " & "Filling Data Table" & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
            DataGridView1.DataSource = ""
            DataGridView1.Columns.Clear()
            currTable = tables(ComboBox1.SelectedItem.ToString)
            DataGridView1.DataSource = currTable
            DataGridView1.Rows(0).Selected = True
            BtnCheck.Enabled = True
        Catch ex As Exception
            BtnCheck.Enabled = False
            TxtErr.Text = Now & " : " & "Reading Error " & ex.Message & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
        End Try
    End Sub
    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
        Label1.Text = ""
        TxtErr.Text = Now & " : " & "Checking User If Registered Before" & vbCrLf & TxtErr.Text
        TxtErr.Refresh()

#Region "Fill New Datatable"

        Dim ChekTbl As New DataTable
        Dim ErrCnt As Integer = 0
        For Cnt_ = 0 To DataGridView1.Rows.Count - 1
            For Cnt_1 = 0 To DataGridView1.Columns.Count - 1
                currTable.Rows(Cnt_).Item(Cnt_1) = (DataGridView1.Rows(Cnt_).Cells(Cnt_1).Value)
            Next
            ChekTbl.Rows.Clear()
            ChekTbl.Columns.Clear()

            If CSYSGetTbl("select Int_user.UsrRealNm from Int_user where Int_user.UsrNm = '" & currTable.Rows(Cnt_).Item(1).ToString & "'", ChekTbl) = Nothing Then
                If ChekTbl.Rows.Count > 0 Then
                    ErrCnt += 1
                    TxtErr.Text = Now & " : Error : " & "User Name: " & currTable.Rows(Cnt_).Item(1).ToString & " is registered Before with " & ChekTbl.Rows(0).Item(0).ToString() & "_ " & ChekTbl.Rows.Count & vbCrLf & TxtErr.Text
                    TxtErr.Refresh()
                End If
            Else
                TxtErr.Text = Now & " : Error : in checking user Names" & vbCrLf & TxtErr.Text
                TxtErr.Refresh()
            End If
        Next
        If ErrCnt = 0 Then
            TxtErr.Text = Now & " : " & "All Users Are Available" & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
            ChekTbl.Rows.Clear()
            ChekTbl.Columns.Clear()
            TxtErr.Text = Now & " : " & "Checking Max User Id" & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
            If CSYSGetTbl("select max(int_user.UsrId) as maxUser from Int_user where UsrId < 32000", ChekTbl) = Nothing Then
                Max_ = ChekTbl.Rows(0).Item(0)
                TxtErr.Text = Now & " : " & "Max User Id Is " & Max_ & vbCrLf & TxtErr.Text
                TxtErr.Refresh()
                currTable.Rows(0).Item(0) = Max_ + 1
                TxtErr.Text = Now & " : " & "Review users Data : " & currTable.Rows.Count & " User" & vbCrLf & TxtErr.Text
                TxtErr.Refresh()
                For Cnt_ = 1 To currTable.Rows.Count - 1
                    TxtErr.Text = Now & " : " & "Review users Data : " & Cnt_ & " Of " & currTable.Rows.Count & vbCrLf & TxtErr.Text
                    TxtErr.Refresh()
                    currTable.Rows(Cnt_).Item(0) = currTable.Rows(Cnt_ - 1).Item(0) + 1
                    currTable.Rows(Cnt_).Item(1) = Trim(currTable.Rows(Cnt_).Item(1).ToString)
                Next
                TxtErr.Text = Now & " : " & "All User has been adjusted" & vbCrLf & TxtErr.Text
                TxtErr.Refresh()
                DataGridView1.DataSource = currTable
            Else
                TxtErr.Text = Now & " : Error : in checking user Names" & vbCrLf & TxtErr.Text
                TxtErr.Refresh()
            End If
            BtnCreate.Enabled = True
        Else
            TxtErr.Text = Now & " : Error : Users Registered Count is " & ErrCnt & vbCrLf & TxtErr.Text

            TxtErr.Text = Now & " : Error : Please Check this users or delete them from the Excel sheet " & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
            BtnCreate.Enabled = False
        End If
        SelctSerchTxt(TxtErr, "Error : ")
#End Region

        ChekTbl = Nothing

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
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)

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
        Return Errmsg
    End Function
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click

        TxtErr.Text = Now & " : " & "Strting Trans Bulk Records" & vbCrLf & TxtErr.Text
        TxtErr.Refresh()

        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            Tran = sqlCon.BeginTransaction()

            Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Tran)
            Dim SQLBulkCopy1 As SqlBulkCopy = New SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, Tran)
            SQLBulkCopy.DestinationTableName = "Int_user"
            SQLBulkCopy1.DestinationTableName = "Int_UserUpdates"

            SQLBulkCopy.ColumnMappings.Add("UsrId", "UsrId")
            SQLBulkCopy.ColumnMappings.Add("UsrNm", "UsrNm")
            SQLBulkCopy.ColumnMappings.Add("UsrCat", "UsrCat")
            SQLBulkCopy.ColumnMappings.Add("UsrRealNm", "UsrRealNm")
            SQLBulkCopy.ColumnMappings.Add("UsrRealNmEn", "UsrRealNmEn")
            SQLBulkCopy.ColumnMappings.Add("UsrGender", "UsrGender")
            SQLBulkCopy.ColumnMappings.Add("UsrEmail", "UsrEmail")
            SQLBulkCopy.WriteToServer(currTable)
            Dim UsrUpdates As New DataTable
            UsrUpdates = currTable.Clone
            UsrUpdates = currTable.Copy()

            UsrUpdates.Columns.RemoveAt(6)
            UsrUpdates.Columns.RemoveAt(5)
            UsrUpdates.Columns.RemoveAt(4)
            UsrUpdates.Columns.RemoveAt(3)
            UsrUpdates.Columns.RemoveAt(2)
            UsrUpdates.Columns.RemoveAt(1)

            UsrUpdates.Columns.Add("UserID2")
            UsrUpdates.Columns.Add("UserIP")
            Dim IP_ As String = OsIP()

            For PP = 0 To UsrUpdates.Rows.Count - 1
                UsrUpdates.Rows(PP).Item("UserID2") = Usr.PUsrID
                UsrUpdates.Rows(PP).Item("UserIP") = IP_
            Next
            '
            SQLBulkCopy1.ColumnMappings.Add("UsrId", "UsrUpdID")
            SQLBulkCopy1.ColumnMappings.Add("UserID2", "UsrCreatID")
            SQLBulkCopy1.ColumnMappings.Add("UserIP", "UsrCreatIP")

            SQLBulkCopy1.WriteToServer(UsrUpdates)

            Label2.Text = DataGridView1.Rows.Count.ToString("N0")
            Tran.Commit()
            SQLBulkCopy.Close()
            TxtErr.Text = Now & " : " & "Total Users Added " & (From row As DataGridViewRow In DataGridView1.Rows
                                                                Select Convert.ToString(row.Cells(0).Value)).Count().ToString("N0") & vbNewLine & TxtErr.Text
            TxtErr.Refresh()
        Catch ex As Exception
            Tran.Rollback()
            TxtErr.Text = Now & " : Error : " & ex.Message & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
        End Try
        SelctSerchTxt(TxtErr, "Error : ")
    End Sub

    Private Sub NTFImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GC.Collect()
        Me.Dispose()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        currTable = tables(ComboBox1.SelectedItem.ToString)
        DataGridView1.DataSource = currTable
    End Sub
    Private Sub UsrCreat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnCheck.Enabled = False
        BtnCreate.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UsrTemplt As New DataTable

        UsrTemplt.Columns.Add("UsrId")
        UsrTemplt.Columns.Add("UsrNm")
        UsrTemplt.Columns.Add("UsrCat")
        UsrTemplt.Columns.Add("UsrRealNm")
        UsrTemplt.Columns.Add("UsrRealNmEn")
        UsrTemplt.Columns.Add("UsrGender")
        UsrTemplt.Columns.Add("UsrEmail")

        UsrTemplt.Rows.Add("", "voca", 228, "VOCA Mohamed Ahmed", "فوكا محمد احمد", "Male", "voca@egyptpost.org")

        Exprt("UserBulkCreateTemplate", UsrTemplt)
    End Sub
End Class