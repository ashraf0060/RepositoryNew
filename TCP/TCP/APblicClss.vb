Imports System.Data.SqlClient

Public Class APblicClss
    Public Class Defntion
        Public StatStr As String
        Public CONSQL As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
        Public reader As SqlDataReader
        Public sqlComm As New SqlCommand
    End Class
    Public Class Func
        Public Function GetTblXX(SSqlStr As String, SqlTbl As DataTable) As String
            Dim state As New Defntion
            state.StatStr = Nothing
            Dim StW As New Stopwatch
            StW.Start()
            state.CONSQL = New SqlConnection(strConn)
            Dim sqlCommW As New SqlCommand(SSqlStr, state.CONSQL)
            Try
                If state.CONSQL.State = ConnectionState.Closed Or state.CONSQL.State = ConnectionState.Broken Then
                    state.CONSQL.Open()
                End If
                state.reader = sqlCommW.ExecuteReader
                SqlTbl.Load(state.reader)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)
            Catch ex As Exception
                If ex.Message.Contains("The connection is broken and recovery is not possible") Then
                    state.CONSQL.Close()
                    SqlConnection.ClearPool(state.CONSQL)
                End If
                state.StatStr = ex.Message
            End Try
            state.CONSQL.Close()
            SqlConnection.ClearPool(state.CONSQL)
            state.sqlComm.Dispose()
            Return state.StatStr
        End Function
    End Class
End Class
