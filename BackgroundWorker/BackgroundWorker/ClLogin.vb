Imports System.Data.SqlClient
Imports System.Management
Public Class ClLogin

    Public Class Defntin
        Public Errmsg As String
        Public strConn As String = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        '"Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        '"Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
        Public sqlCon As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
        Public ElapsedTimeSpan As String
        Public MacTable As DataTable
        Public ServerNm As String = "Egypt Post Server"
        Public cnt As Integer
        Public StatStr As String
    End Class
    Public Class Func
        Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntin
            state.StatStr = "Connecting"
            Dim StW As New Stopwatch
            StW.Start()

            state.Errmsg = Nothing
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Dim sqlCommW As New SqlCommand
            Try
                If state.sqlCon.State = ConnectionState.Closed Then
                    state.sqlCon.Open()
                End If
                SQLGetAdptr = New SqlDataAdapter            'SQL Table Adapter
                sqlCommW = New SqlCommand(SSqlStr, state.sqlCon)
                SQLGetAdptr.SelectCommand = sqlCommW
                SQLGetAdptr.Fill(SqlTbl)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)

            Catch ex As Exception
                state.StatStr = ex.Message
                'MsgBox(ex.Message)
            End Try
            SqlTbl.Dispose()
            SQLGetAdptr.Dispose()
            sqlCommW.Dispose()
            state.sqlCon.Close()
            SqlConnection.ClearPool(state.sqlCon)
            Return state.StatStr
            worker.ReportProgress(0, state)
        End Function

        Public Function ConStrFn(tt As String) As List(Of String)
            Dim ff As New List(Of String)
            Dim Def As New Defntin
            If tt = "Eg Server" Then
                Def.strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                Def.ServerNm = "Egypt Post Server"
            ElseIf tt = "My Labtop" Then
                Def.strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
                Def.ServerNm = "My Labtop"
            ElseIf tt = "Test Database" Then
                Def.strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                Def.ServerNm = "Test Database"
            End If
            'If sqlCon.State = ConnectionState.Connecting Or sqlCon.State = ConnectionState.Open Then

            Try
                Def.sqlCon = New SqlConnection
                Def.sqlCon.ConnectionString = Def.strConn
            Catch ex As Exception
                Def.sqlCon.Close()
                SqlConnection.ClearPool(Def.sqlCon)
                Def.sqlCon.ConnectionString = Def.strConn
            End Try
            'Else
            '    sqlCon.ConnectionString = strConn
            'End If
            ff.Add(Def.strConn)
            ff.Add(Def.ServerNm)
            Return ff
        End Function

    End Class

End Class
