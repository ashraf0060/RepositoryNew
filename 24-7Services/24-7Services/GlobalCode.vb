Imports ClosedXML.Excel

Module GlobalCode
    Public Errmsg As String          ' Handel error message
    Public Esc As String = ""
    Public EscCnt As Integer = 0
    Public EscID As Integer = 0
    Public Cnt As Integer = 0
    Public CntDay As Integer = 0
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public sqlComm As New SqlCommand                    'SQL Command
    Public sqlComnd As New SqlCommand                    'SQL Command
    Public sqlCommUpddate_ As New SqlCommand            'SQL Command
    Public sqlComminsert_1 As New SqlCommand            'SQL Command
    Public sqlComminsert_2 As New SqlCommand            'SQL Command
    Public sqlComminsert_3 As New SqlCommand            'SQL Command
    Public sqlComminsert_4 As New SqlCommand            'SQL Command
    Public SQLTblAdpter As New SqlDataAdapter            'SQL Table Adapter
    Public SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Public Reader_ As SqlDataReader                     'SQL Reader
    Public AssignTable As DataTable = New DataTable
    Public EscAtoTable As DataTable = New DataTable
    Public EscTable As DataTable = New DataTable
    Public tempTable As DataTable = New DataTable
    Public WdysTable As New DataTable
    Public HeldTbl As DataTable = New DataTable()
    Public sqlCcon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project
    'Public sqlCcon As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046")
    Public sqlCcon1 As New SqlConnection("Data Source=NEW-VOCA\SQLVOCAPLUS;Initial Catalog=VOCAPlus;Integrated Security=True") ' I Have assigned conn STR here and delete this row from all project
    Public Span_ As New TimeSpan
    Public StrFileName As String = "X"
    Public nxt As String
    Public ExpoTbl As New DataTable
    Public FileExported As String

    Public Function CalDate(StDt As Date, ByRef EnDt As Date) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
        Dim WdyCount As Integer
        StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
        EnDt = DateValue(EnDt)
        sqlComm.Connection = sqlCcon1 ' Get ID & Date & UserID                        
        sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
        sqlComm.CommandType = CommandType.Text
        Try
            Reader_ = sqlComm.ExecuteReader
            Reader_.Read()
            WdyCount = Reader_!WDaysCount
            Reader_.Close()
        Catch ex As Exception

        End Try
        Return WdyCount
    End Function
    Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
        OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
    End Function
    Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        sqlComnd.Connection = sqlCcon
        SQLTblAdpter.SelectCommand = sqlComnd
        sqlComnd.CommandType = CommandType.Text
        sqlComnd.CommandText = SSqlStr
        Try
            SqlTbl.Rows.Clear()
            SQLTblAdpter.Fill(SqlTbl)
            sqlCcon.Close()
            SqlConnection.ClearPool(sqlCcon)
        Catch ex As Exception
            MainWindow.TxtErr.Text = Now & " GetTbl ___" & SqlTbl.TableName & ex.Message & vbCrLf
            MainWindow.TxtErr.Refresh()
            'MsgBox(ex.Message)
        End Try
        Return Errmsg
    End Function
    Public Function InsUpd(SSqlStr As String) As String
        Errmsg = Nothing
        sqlComm.Connection = sqlCcon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCcon.State = ConnectionState.Closed Then
                sqlCcon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            sqlCcon.Close()
            SqlConnection.ClearPool(sqlCcon)
        Catch ex As Exception
            MainWindow.TxtErr.Text = Now & " InsUpd ___ " & SSqlStr & ex.Message & vbCrLf & MainWindow.TxtErr.Text
            MainWindow.TxtErr.Refresh()
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Public Function InsTrans(TranStr1 As String, TranStr2 As String) As String
        Errmsg = Nothing
        Try
            If sqlCcon.State = ConnectionState.Closed Then
                sqlCcon.Open()
            End If
            sqlComminsert_1.Connection = sqlCcon
            sqlComminsert_2.Connection = sqlCcon
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_2.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = TranStr1
            sqlComminsert_2.CommandText = TranStr2
            Tran = sqlCcon.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            sqlComminsert_2.Transaction = Tran
            sqlComminsert_1.ExecuteNonQuery()
            sqlComminsert_2.ExecuteNonQuery()
            Tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            MainWindow.TxtErr.Text = vbCrLf & Now & " InsTrans ___ " & TranStr1 & "_____" & TranStr2 & ex.Message & vbCrLf
            MainWindow.TxtErr.Refresh()
            Errmsg = "X"
        End Try
        sqlCcon.Close()
        SqlConnection.ClearPool(sqlCcon)
        Return Errmsg
    End Function
    Public Sub MsgInf(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub
    Public Function ServrTime() As DateTime
        Errmsg = Nothing
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        Dim Nw As DateTime
        Try
            GlobalCode.GetTbl("Select GetDate() as Now_", tempTable)
            Nw = Format(tempTable.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
        Catch ex As Exception

        End Try
        Return Nw
    End Function
End Module
