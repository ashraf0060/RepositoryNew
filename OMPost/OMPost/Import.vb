Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports ExcelDataReader
Imports DataSet = System.Data.DataSet
Public Class Import
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
        TxtErr.Text = Now & " : " & "Reading File ....." & vbCrLf & TxtErr.Text
        TxtErr.Refresh()
        Try
            Using streem = File.Open(StrFileName, FileMode.Open, FileAccess.Read)
                Using Reader As IExcelDataReader = ExcelReaderFactory.CreateReader(streem)
                    'MsgBox(Reader.ResultsCount.ToString)
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
            TxtErr.Text = Now & " : " & "Filling Data Table ..... " & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
            DataGridView1.DataSource = ""
            DataGridView1.Columns.Clear()
            currTable = tables(ComboBox1.SelectedItem.ToString)
            DataGridView1.DataSource = currTable
            DataGridView1.Rows(0).Selected = True
            BtnCreate.Enabled = True
        Catch ex As Exception
            BtnCreate.Enabled = False
            TxtErr.Text = Now & " : " & "Reading Error " & ex.Message & vbCrLf & TxtErr.Text
            TxtErr.Refresh()
        End Try
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Label2.Text = DataGridView1.CurrentRow.Index + 1 & " Of " & DataGridView1.Rows.Count.ToString("N0")
    End Sub
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        TxtErr.Text = Now & " : " & "Strting Adding Records" & vbCrLf & TxtErr.Text
        TxtErr.Refresh()

        Dim PrTblTsk As New Thread(AddressOf imprt)
        PrTblTsk.IsBackground = True
        PrTblTsk.Start()


    End Sub

    Private Sub imprt()
        If OfflineCon.State = ConnectionState.Closed Then
            OfflineCon.Open()
        End If
        Tran = OfflineCon.BeginTransaction()
        Try

            Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(OfflineCon, SqlBulkCopyOptions.Default, Tran)
            SQLBulkCopy.DestinationTableName = "SaleStatement"
            'sqlComm.Connection = OfflineCon
            'sqlComm.CommandType = CommandType.Text
            'sqlComm.Transaction = Tran
            Dim Colmns As New List(Of String)

            Dim LLLL As String = ""
            For GG = 0 To currTable.Columns.Count - 1
                ''MsgBox(currTable.Columns(GG).DataType.Name.ToString)
                'currTable.Columns(GG).DataType = GetType(Date)
                'Colmns.Add(currTable.Columns(GG).ColumnName)
                'LLLL = "insert into SaleStatement (" & String.Join(",", Colmns) & ") values ('"
                SQLBulkCopy.ColumnMappings.Add(currTable.Columns(GG).ColumnName, currTable.Columns(GG).ColumnName)
            Next
            ''Invoke(Sub() TxtErr.Text = Now & " : " & " Start Adding " & currTable.Rows.Count.ToString & vbCrLf & TxtErr.Text)
            'Invoke(Sub() TxtErr.Refresh())
            'For HH = 0 To currTable.Rows.Count - 1
            '    If Mid(HH + 1, 3, 3) = "000" Then
            '        Invoke(Sub() TxtErr.Text = Now & " : " & "Adding " & HH + 1 & " Of " & currTable.Rows.Count.ToString & " ....." & vbCrLf & TxtErr.Text)
            '    End If
            '    'Invoke(Sub() TxtErr.Refresh())
            '    Dim Valus As New List(Of String)
            '    For PO = 0 To currTable.Columns.Count - 1
            '        If currTable.Rows(HH).Item(PO).ToString.Contains(Chr(34)) Then
            '            Valus.Add(Replace(currTable.Rows(HH).Item(PO).ToString, Chr(34), "$"))
            '            'MsgBox(Replace(currTable.Rows(HH).Item(PO).ToString, Chr(34), "$"))
            '        ElseIf currTable.Rows(HH).Item(PO).ToString.Contains(Chr(39)) Then
            '            Valus.Add(Replace(currTable.Rows(HH).Item(PO).ToString, Chr(39), "%"))
            '        Else
            '            Valus.Add(currTable.Rows(HH).Item(PO).ToString)
            '        End If
            '    Next
            '    sqlComm.CommandText = LLLL & String.Join("','", Valus) & "')"
            '    sqlComm.ExecuteNonQuery()
            'Next
            SQLBulkCopy.WriteToServer(currTable)
            Invoke(Sub() TxtErr.Text = Now & " : " & " Ended Adding " & currTable.Rows.Count.ToString & vbCrLf & TxtErr.Text)
            'Invoke(Sub() TxtErr.Refresh())
            Invoke(Sub() Label2.Text = DataGridView1.Rows.Count.ToString("N0"))
            Tran.Commit()
            SQLBulkCopy.Close()
            Invoke(Sub() TxtErr.Text = Now & " : " & "Total Users Added " & (From row As DataGridViewRow In DataGridView1.Rows
                                                                         Select Convert.ToString(row.Cells(0).Value)).Count().ToString("N0") & vbNewLine & TxtErr.Text)
            'Invoke(Sub() TxtErr.Refresh())
        Catch ex As Exception
        Tran.Rollback()
            Invoke(Sub() TxtErr.Text = Now & " : Error : " & ex.Message & "_" & sqlComm.CommandText & vbCrLf & TxtErr.Text)
            'Invoke(Sub() TxtErr.Refresh())
        End Try
        Invoke(Sub() SelctSerchTxt(TxtErr, "Error : "))
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
        BtnSub(Me)
        BtnCreate.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim UsrTemplt As New DataTable

        'UsrTemplt.Columns.Add("UsrId")
        'UsrTemplt.Columns.Add("UsrNm")
        'UsrTemplt.Columns.Add("UsrCat")
        'UsrTemplt.Columns.Add("UsrRealNm")
        'UsrTemplt.Columns.Add("UsrRealNmEn")
        'UsrTemplt.Columns.Add("UsrGender")
        'UsrTemplt.Columns.Add("UsrEmail")

        'UsrTemplt.Rows.Add("", "voca", 228, "VOCA Mohamed Ahmed", "فوكا محمد احمد", "Male", "voca@egyptpost.org")

        'Exprt("UserBulkCreateTemplate", UsrTemplt)
    End Sub
End Class