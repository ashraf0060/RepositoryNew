Imports Microsoft.Exchange.WebServices.Data
Public Class Test
    Dim Tickets As New DataTable
    Dim sqladptr As New SqlDataAdapter

    Dim Slctd As Boolean = False
    Dim CtlCnt As Integer = 0
    Dim TbCtrl As New TabControl
    Dim Cmstrip1 As MenuStrip

    Dim sqlCConCCSYS As New SqlConnection("Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=CSSYS;Persist Security Info=True;User ID=sa;Password=Hemonad105046") ' I Have assigned conn STR here and delete this row from all project

    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thisBuilder As SqlCommandBuilder = New SqlCommandBuilder(sqladptr)
        sqladptr.SelectCommand = sqlComm
        sqladptr.Update(Tickets)
        Fil()
        sqlCon.Close()
    End Sub
    Private Sub Fil()
        'Tickets.Columns.Clear()
        Tickets.Rows.Clear()
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "SELECT * from VwFnProd"
        SQLTblAdptr.SelectCommand = sqlComm
        SQLTblAdptr.Fill(Tickets)
        sqlCon.Close()
        DataGridView1.DataSource = Tickets
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

#Region "Email Body"
        Dim Bdy As String = "<p><span style= " & Chr(34) & "text-align: left;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">Dear " & Usr.PUsrRlNm & ",</span></p>
<p><span style =  " & Chr(34) & "text-align: left;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > You recieved this message because you have confirmed your email address on <strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "><span style=" & Chr(34) & " color: #339966;" & Chr(34) & ">VOCA Plus</span>&nbsp;</span></strong></span><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">Application, and you will not recieve this mail again.</span></p>
<ul>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > If your email address is correct and you are the right User, please don't reply.</span></li>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > please feel free to contact us any time On <a href=" & Chr(34) & "mailto:voca-support@egyptpost.org" & Chr(34) & ">VOCA Support Team</a>.</span></li>
</ul>" &
"<br>

<p style= " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & "><span  >عزيزي" & Usr.PUsrRlNm & "</span></p>
<p style =  " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "  dir=" & Chr(34) & "rtl" & Chr(34) & "><span " & " >لقد استلمت هذا البريد الإلكتروني فقط لتأكيد بريديك الألكتروني المسجل على تطبيق  <strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & "><span style=" & Chr(34) & " color: #339966;" & Chr(34) & ">VOCA Plus</span>&nbsp;</span></strong></span><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & ">، ونخبرك أيضا أنك لن تستلم هذه الرسالة مره أخرى.</span></p>


<ul style=" & Chr(34) & "padding-left: 150px; text-align: right;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & ">

<li><span style = " & Chr(34) & "text-align: right;" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " dir=" & Chr(34) & "rtl" & Chr(34) & " >في حالة كونك المستخدم الصحيح وقد قمت باستلام الرسالة بالفعل، رجاء لا تقوم بالرد على هذا الإيميل..</span></li>
<li><span style = " & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " > لا تستشعر الحرج في التواصل معنا في أي وقت على  <a href=" & Chr(34) & "mailto:voca-support@egyptpost.org" & Chr(34) & ">VOCA Support Team</a>.</span></li>
</ul>" &
"<p><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " data-mce-mark=" & Chr(34) & "1" & Chr(34) & ">Best Regard,</span></p>
<p><strong><span style=" & Chr(34) & "font-family: 'times new roman', times; font-size: small;" & Chr(34) & " data-mce-mark=" & Chr(34) & "1" & Chr(34) & ">VOCA Plus Team</span></strong></p>" & "<img src=" & Chr(34) & "ftp://10.10.26.4/CallCenter/Attch/VocaIcon1.jpg" & Chr(34) & "width=" & Chr(34) & "64" & Chr(34) & " height=" & Chr(34) & "64" & Chr(34) & " />"
#End Region
        SndExchngMil("a.farag@egyptpost.org",,,, Bdy, 2)

    End Sub
    Private Sub Button8_MouseMove(sender As Object, e As MouseEventArgs) Handles Button8.MouseMove
        'StatBrPnlEn.Text = New Point(e.X, e.Y).ToString & "_" & (e.X - e.Y).ToString
        'If e.X >= 0 And e.X <= 3 And e.Y > 0 Or e.Y = Button8.Height - 3 And e.X >= 0 Then
        '    Button8.Cursor = Cursors.SizeAll
        '    AddHandler MyBase.MouseMove, AddressOf Butto55_MouseMove
        '    RemoveHandler Button8.MouseMove, AddressOf Button8_MouseMove
        'Else
        '    Button8.Cursor = Cursors.Default
        'End If

    End Sub
    Private Sub Butto55_MouseMove(sender As Object, e As MouseEventArgs)
        Button8.Location = New Point(e.X, e.Y)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim HeldTable As New DataTable
        Dim HeldTable1 As New DataTable

        sqlComm.Connection = sqlCConCCSYS
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = "SELECT [DocID],[DocCD],[DocAr],[DocEn],[DocChoose]  FROM [CSSYS].[dbo].[Doc]"
        Try
            SQLTblAdptr.Fill(HeldTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            SQLTblAdptr.Fill(HeldTable1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If sqlCConCCSYS.State = ConnectionState.Closed Then
            sqlCConCCSYS.Open()
        End If
        Tran = sqlCConCCSYS.BeginTransaction()
        Try
            For rwindx = 0 To HeldTable.Rows.Count - 1
                sqlComminsert_1.Connection = sqlCConCCSYS
                sqlComminsert_2.Connection = sqlCConCCSYS
                sqlComminsert_3.Connection = sqlCConCCSYS
                sqlComminsert_1.CommandType = CommandType.Text
                sqlComminsert_2.CommandType = CommandType.Text
                sqlComminsert_3.CommandType = CommandType.Text
                sqlComminsert_1.CommandText = "update [Doc] set [DocChoose] = 0 where [DocID] = " & HeldTable.Rows(rwindx).Item(0)
                sqlComminsert_2.CommandText = "update [Doc] set [DocEn] = 0 where [DocID] = " & HeldTable.Rows(rwindx).Item(0)
                Try
                    sqlComm.Transaction = Tran
                    sqlComm.Connection = sqlCConCCSYS
                    SQLTblAdptr.SelectCommand = sqlComm
                    sqlComm.CommandType = CommandType.Text
                    sqlComm.CommandText = "SELECT MAX(DocID) AS Expr1 FROM dbo.Doc"
                    HeldTable1.Rows.Clear()
                    HeldTable1.Columns.Clear()
                    SQLTblAdptr.Fill(HeldTable1)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                sqlComminsert_3.CommandText = "Insert into Doc ([DocID],[DocCD],[DocAr],[DocEn],[DocChoose]) values (" & HeldTable1.Rows(0).Item(0) + 1 & " , '1','1','66',1)"
                sqlComminsert_1.Transaction = Tran
                sqlComminsert_2.Transaction = Tran
                sqlComminsert_3.Transaction = Tran
                sqlComminsert_1.ExecuteNonQuery()
                sqlComminsert_2.ExecuteNonQuery()
                sqlComminsert_3.ExecuteNonQuery()
            Next
            Tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub GhhghToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GhhghToolStripMenuItem.Click

        Dim sms = sender.GetCurrentParent().SourceControl
        Dim cnt As New Control
        'Dim ct As Control = CType(ComponentModel.TypeDescriptor.GetConverter(GetType(Control)).ConvertFromString(sender.GetCurrentParent().SourceControl.name), DataGridView)
        MsgBox(sms.Location.ToString)
    End Sub
    Private Function CmstripAsgn(Cnrol As Object) As Control
        Cnrol.GetCurrentParent().SourceControl.name
        Return Cnrol

    End Function

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.MouseDown
        If TextBox4.Focused = False Then

        End If

    End Sub

    Private Sub TextBox4_MouseHover(sender As Object, e As EventArgs) Handles TextBox4.MouseMove
        TextBox4.SelectAll()
    End Sub
End Class