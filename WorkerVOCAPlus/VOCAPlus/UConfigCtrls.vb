Public Class UConfigCtrls

    Private Sub UCongCtrls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        'sqlCon.ConnectionString = strConn
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl("select SwObjNm from ASwitchboard where SwObjNm is not null and SwObjNm <> 'Uconstr'", tempTable, "0000&H")
        For Cnt_ = 0 To tempTable.Rows.Count - 1
            ComboBox1.Items.Add(tempTable.Rows(Cnt_).Item(0))
        Next
        ComboBox1.Items.Add("WelcomeScreen")
        ComboBox1.Items.Add("Login")
    End Sub
    Private Sub BtnStrt_Click(sender As Object, e As EventArgs) Handles BtnStrt.Click
        Dim tbl As New DataTable
        Dim Chois As String = "and SwObjNm = '" & ComboBox1.Text & "'"
        'ConStrFn("Eg Server")
        CtlCnt = 0
        CtrlsTbl.Rows.Clear()
        CtrlsTbl.Columns.Clear()

        CtrlsTbl.Columns.Add("Sql")
        CtrlsTbl.Columns.Add("FormName")
        CtrlsTbl.Columns.Add("ControlName")
        CtrlsTbl.Columns.Add("ControlType")
        CtrlsTbl.Columns.Add("X")
        CtrlsTbl.Columns.Add("Y")
        CtrlsTbl.Columns.Add("FntSize")
        CtrlsTbl.Columns.Add("CtlFntWidth")
        CtrlsTbl.Columns.Add("CtlFntHeight")
        CtrlsTbl.Columns.Add("CtlIndx")
        CtrlsTbl.Columns.Add("CtlMargnLft")
        CtrlsTbl.Columns.Add("CtlMargnTop")
        CtrlsTbl.Columns.Add("CtlMargnRght")
        CtrlsTbl.Columns.Add("CtlMargnBttm")
        CtrlsTbl.Columns.Add("CtlFlowBreak")



        If CheckBox1.Checked = True Then
            Chois = ""

        End If
        If GetTbl("select SwObjNm from ASwitchboard where SwObjNm is not null and SwObjNm <> 'Uconstr'" & Chois, tbl, "0000&H") = Nothing Then
            tbl.Rows.Add("WelcomeScreen")
        tbl.Rows.Add("Login")

        For Cnt_ = 0 To tbl.Rows.Count - 1
            Dim formName As String = "VOCAPlus." & tbl.Rows(Cnt_).Item(0)
            Dim form1_ = CType(Activator.CreateInstance(Type.GetType(formName)), Form)
            Dim CtrlTble As New DataTable
            If GetTbl("Select * from AControls where CtlFormName = '" & tbl.Rows(Cnt_).Item(0) & "'", CtrlTble, "0000&H") = Nothing Then
                If CtrlTble.Rows.Count > 0 Then
                    InsUpd("delete from AControls where CtlFormName = '" & tbl.Rows(Cnt_).Item(0) & "'", "0000&H")
                End If
            End If
                FrmAllSub(form1_)
                StatBrPnlEn.Text = Cnt_ + 1 & " من " & tbl.Rows.Count
        Next
        Dim SQLBulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlCon)
        SQLBulkCopy.DestinationTableName = "AControls"
        If sqlCon.State = ConnectionState.Closed Then
            sqlCon.Open()
        End If
        SQLBulkCopy.WriteToServer(CtrlsTbl)
        SQLBulkCopy.Close()
            StatBrPnlEn.Text = "Finished"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ComboBox1.ResetText()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("DDD")
            ComboBox1.Focus()
        End If
    End Sub
End Class