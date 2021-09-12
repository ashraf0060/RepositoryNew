Imports System.IO
Imports System.Text
Public Class SupLog
    Private Sub BtnRdFl_Click(sender As Object, e As EventArgs) Handles BtnRdFl.Click
        Dim SelFl As OpenFileDialog = New OpenFileDialog()
        Dim TblLog As New DataTable ' Create four typed columns in the DataTable.
        TblLog.Columns.Add("Ser", GetType(Integer))
        TblLog.Columns.Add("Date", GetType(String))
        TblLog.Columns.Add("ECnt_No", GetType(Integer))
        TblLog.Columns.Add("Msg", GetType(String))
        TblLog.Columns.Add("Sql", GetType(String))
        Dim TmpOrg As String
        Dim Tmpdate As String
        Dim TmpLine As String
        Dim TmpSer As Integer = 0
        StrFileName = ""


        SelFl.Title = "Loading Voca Log File"
        SelFl.Multiselect = False
        SelFl.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        SelFl.Filter = "Voca+ Log Files|*.Vlg"
        SelFl.RestoreDirectory = True

        If SelFl.ShowDialog() = DialogResult.OK Then
            StrFileName = SelFl.FileName
        End If
        'MsgBox(File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg").Length.ToString)
        If StrFileName = "" Then
            Exit Sub
        End If
        Dim StCnt_dr As StreamReader = New StreamReader(StrFileName)
        'On Error Resume Next
        Do While StCnt_dr.Peek() >= 0
            TmpOrg = StCnt_dr.ReadLine()
            If TmpOrg = "" Then
            Else
                'If Split(TmpOrg, ", ").Count > 1 Then
                Tmpdate = Split(TmpOrg, ",")(0)
                If TmpOrg.Length > Tmpdate.Length Then
                    TmpLine = Strings.Right(TmpOrg, (TmpOrg.Length - Tmpdate.Length - 1))
                Else
                    TmpLine = Strings.Right(TmpOrg, (TmpOrg.Length - Tmpdate.Length))
                End If
                TmpSer += 1
                Dim SPLIT0 As String = ""
                Dim SPLIT1 As String = ""
                Dim SPLIT2 As String = ""
                If Split(TmpLine, "&H").Count = 3 Then
                    SPLIT0 = Split(TmpLine, "&H")(0)
                    SPLIT1 = Split(TmpLine, "&H")(1)
                    SPLIT2 = Split(TmpLine, "&H")(2)
                ElseIf Split(TmpLine, "&H").Count = 2 Then
                    SPLIT0 = Split(TmpLine, "&H")(0)
                    SPLIT1 = Split(TmpLine, "&H")(1)
                    SPLIT2 = ""
                ElseIf Split(TmpLine, "&H").Count = 1 Then
                    SPLIT0 = 0
                    SPLIT1 = ""
                    SPLIT2 = ""
                Else
                    SPLIT0 = 0
                End If
                InsUpd("insert into ALog ([LogSer], [LogDt] ,[LogErrCd] ,[LogExMsg] ,[LogSQLStr] ,[LogIP],[LogUsrID]) values (" & TmpSer & ",'" & Tmpdate & "'," & SPLIT0 & ",'" & Replace(SPLIT1, "'", "$") & "','" & Replace(PassDecoding(SPLIT2, GenSaltKey), "'", "$") & "','" & OsIP() & "'," & Usr.PUsrID & ")", "0000&H")
                'InsUpd("set QUOTED_IDENTIFIER OFF;insert into ALog ([ALogSer], [ALogDate] ,[ALogErrCd] ,[ALogExMsg] ,[ALogSQLStr] ,[ALogIP],[ALogUserId]) values (" & TmpSer & ",'" & Tmpdate & "'," & SPLIT0 & ",'" & SPLIT1 & "','" & PassDecoding(SPLIT2, GenSaltKey) & "','" & OsIP() & "'," & Usr.PUsrID & ");set QUOTED_IDENTIFIER ON;", "0000&H")
                TblLog.Rows.Add(TmpSer, Tmpdate, Integer.Parse(SPLIT0), SPLIT1, PassDecoding(SPLIT2, GenSaltKey))
            End If
            'End If
        Loop
        StCnt_dr.Close()
        LogData.DataSource = TblLog
        LogData.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        'LogData.AutoResizeColumns()
        LogData.Columns(3).Width = 500
        LogData.Columns(4).Width = 525
        LogData.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        LogData.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        LogData.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        LogData.AutoResizeRows()

    End Sub
    Private Sub BtnExitFrm_Click(sender As Object, e As EventArgs) Handles BtnExitFrm.Click
        StrFileName = ""
        FlushMemory()
        Close()
    End Sub

    Private Sub BtnMouseHover(sender As Object, e As EventArgs) Handles BtnRdFl.MouseHover, BtnWrFl.MouseHover, BtnExitFrm.MouseHover
        Dim Btns As Button = sender
        LblHeader.Text = Btns.Tag
    End Sub

    Private Sub BtnMouseLeave(sender As Object, e As EventArgs) Handles BtnWrFl.MouseLeave, BtnRdFl.MouseLeave, BtnExitFrm.MouseLeave
        LblHeader.Text = " "
    End Sub

    Private Sub BtnWrFl_Click(sender As Object, e As EventArgs) Handles BtnWrFl.Click


        'My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
        '  & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Format(Now, "yyyyMMdd HH:mm:ss") & " ," & ECnt_Hndls & LogMsg & " &H" & PassEncoding(SSqlStrs, GenSaltKey) & vbCrLf, True)

    End Sub

    Private Sub SupLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(screenWidth, screenHeight - 120)
    End Sub
End Class