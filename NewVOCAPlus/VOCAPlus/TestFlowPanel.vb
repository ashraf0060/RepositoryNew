Public Class TestFlowPanel
    Dim R As Control
    Dim Drow As DataRow
    Dim CurrIndex As Integer = 0
    Dim FFW As Control
    Dim MyPen As Pen = New Pen(Drawing.Color.Blue, 5)
    Dim myGraphics As Graphics
    Private Sub TestFlowPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        sqlCon.ConnectionString = strConn
        Dim primaryKey(0) As DataColumn
        Dim dd As New DataTable
        GetTbl("select * from AAAAA order by indx", dd, "0000&H")
        primaryKey(0) = dd.Columns("Name")
        dd.PrimaryKey = primaryKey

        For Each R In FlowLayoutPanel1.Controls
            R.ContextMenuStrip = ContextMenuStrip1
            Drow = dd.Rows.Find(R.Name)
            If R.Name = Drow.ItemArray(0) Then
                FlowLayoutPanel1.Controls.SetChildIndex(R, Drow.ItemArray(3))
            End If
        Next

        'DataGridView1.DataSource = dd
        'DataGridView1.Columns.Add("rr", "ff")

        'For vv = 0 To dd.Rows.Count - 1
        '    For Each R In FlowLayoutPanel1.Controls
        '        If dd.Rows(vv).Item(0).Value = R.Name Then
        '            DataGridView1.Rows(vv).Cells(4).Value = R.ContextMenuStrip.Name
        '            Exit For
        '        End If

        '    Next
        'Next


        'InsUpd("insert into AAAAA (AAAAA.Name, AAAAA.locx, AAAAA.locy, indx) values ('" & R.Name & "'," & R.Location.X & "," & R.Location.Y & "," & FlowLayoutPanel1.Controls.GetChildIndex(R) & ")", "0000&H")

    End Sub
    Private Sub NextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextToolStripMenuItem.Click
        Dim cIndex As Integer
        Dim sms = (sender.GetCurrentParent()).SourceControl
        FFW = sms
        cIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        If cIndex > 0 Then
            FlowLayoutPanel1.Controls.SetChildIndex(FFW, cIndex + 1)
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")
        End If
    End Sub
    Private Sub PreviousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviousToolStripMenuItem.Click
        Dim sms = (sender.GetCurrentParent()).SourceControl
        FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        If CurrIndex > 0 Then
            FlowLayoutPanel1.Controls.SetChildIndex(FFW, CurrIndex - 1)
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")
        End If
    End Sub
    Private Sub FlowBreakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlowBreakToolStripMenuItem.Click
        Dim sms = (sender.GetCurrentParent()).SourceControl
        FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        FlowLayoutPanel1.SetFlowBreak(FFW, False)
        'InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")

    End Sub
    Private Sub FlowBreakTrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlowBreakTrueToolStripMenuItem.Click
        Dim sms = (sender.GetCurrentParent()).SourceControl
        FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        FlowLayoutPanel1.SetFlowBreak(FFW, True)
    End Sub

    Private Sub TToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TToolStripMenuItem.Click
        'Dim cIndex As Integer
        'Dim sms = (sender.GetCurrentParent()).SourceControl
        'FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        FlowLayoutPanel1.Controls.SetChildIndex(FFW, CurrIndex + 1)

        'FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) - 1)
        If CurrIndex < FlowLayoutPanel1.Controls.Count Then
            myGraphics.Dispose()
            FlowLayoutPanel1.Refresh()
            myGraphics = FlowLayoutPanel1.CreateGraphics
            myGraphics.DrawRectangle(MyPen, FFW.Location.X, FFW.Location.Y, FFW.Width, FFW.Height)
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")
            Dim ff As Control = FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) - 1)
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) - 1)) & " Where AAAAA.Name = '" & FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) - 1).Name & "'", "0000&H")
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        'Dim sms = (sender.GetCurrentParent()).SourceControl
        'FFW = sms
        If CurrIndex - 1 > 0 Then
            CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
            FlowLayoutPanel1.Controls.SetChildIndex(FFW, CurrIndex - 1)
            myGraphics.Dispose()
            FlowLayoutPanel1.Refresh()
            myGraphics = FlowLayoutPanel1.CreateGraphics
            myGraphics.DrawRectangle(MyPen, FFW.Location.X, FFW.Location.Y, FFW.Width, FFW.Height)
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FFW) & " Where AAAAA.Name = '" & FFW.Name & "'", "0000&H")
            InsUpd("update AAAAA set AAAAA.indx = " & FlowLayoutPanel1.Controls.GetChildIndex(FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) + 1)) & " Where AAAAA.Name = '" & FlowLayoutPanel1.Controls.Item(FlowLayoutPanel1.Controls.GetChildIndex(FFW) + 1).Name & "'", "0000&H")
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        'Dim sms = (sender.GetCurrentParent()).SourceControl
        'FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)
        FlowLayoutPanel1.SetFlowBreak(FFW, True)
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        'Dim sms = (sender.GetCurrentParent()).SourceControl
        'FFW = sms
        CurrIndex = FlowLayoutPanel1.Controls.GetChildIndex(FFW)

        If FlowLayoutPanel1.GetFlowBreak(FFW) = False Then
            FlowLayoutPanel1.SetFlowBreak(FFW, True)
            ToolStripMenuItem2.Text = "FlowBreak False"
        Else
            FlowLayoutPanel1.SetFlowBreak(FFW, False)
            ToolStripMenuItem2.Text = "FlowBreak True"
        End If
    End Sub

    Private Sub GoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToolStripMenuItem.Click
        If IsNothing(myGraphics) = False Then
            myGraphics.Dispose()
        End If

        FlowLayoutPanel1.Refresh()
        Dim sms = (sender.GetCurrentParent()).SourceControl
        FFW = sms
        myGraphics = FlowLayoutPanel1.CreateGraphics
        MyPen.DashStyle = Drawing.Drawing2D.DashStyle.Solid
        myGraphics.DrawRectangle(MyPen, FFW.Location.X, FFW.Location.Y, FFW.Width, FFW.Height)
        MenuStrip2.Items("TxtLeft").Text = FFW.Margin.Left
        MenuStrip2.Items("TxtTop").Text = FFW.Margin.Top
        MenuStrip2.Items("TxtRight").Text = FFW.Margin.Right
        MenuStrip2.Items("TxtBottom").Text = FFW.Margin.Bottom

        StripComboBox.Text = FlowLayoutPanel1.FlowDirection.ToString

        'MenuStrip2.Visible = True
        'MenuStrip2.BringToFront()

        'Dim X_ As Integer = 0
        'Dim Y_ As Integer = 0

        'If TypeOf FFW.Parent Is Form Or TypeOf FFW.Parent Is TabPage Then
        '    If FFW.Location.X + MenuStrip2.Width > Me.Width Then
        '        X_ = FFW.Location.X - MenuStrip2.Width
        '    Else
        '        X_ = FFW.Location.X
        '    End If
        'ElseIf TypeOf FFW.Parent Is GroupBox Then
        '    If FFW.Parent.Location.X + MenuStrip2.Width > Me.Width Then
        '        X_ = FFW.Parent.Location.X - MenuStrip2.Width
        '    Else
        '        X_ = FFW.Parent.Location.X
        '    End If
        'End If

        'If TypeOf FFW.Parent Is Form Or TypeOf FFW.Parent Is TabPage Then
        '    If FFW.Location.Y + MenuStrip2.Height + FFW.Height + 35 > Me.Height Then
        '        Y_ = (FFW.Location.Y) + (FFW.Location.Y + MenuStrip2.Height + FFW.Height + 35 - Me.Height) - MenuStrip2.Height
        '    Else
        '        Y_ = FFW.Location.Y + FFW.Height
        '    End If
        'ElseIf TypeOf FFW.Parent Is GroupBox Then
        '    If FFW.Parent.Location.Y + MenuStrip2.Height > Me.Height Then
        '        Y_ = FFW.Parent.Location.Y - FFW.Height - MenuStrip2.Height
        '    Else
        '        Y_ = FFW.Parent.Location.Y
        '    End If
        'End If


        'MenuStrip2.Location = New Point(X_, Y_)





        Dim PPoint As Point
        PPoint = MenuStrip2.PointToScreen(New Point(MenuStrip2.Location.X, MenuStrip2.Location.Y))
        'TToolStripMenuItem
        Cursor.Position = PPoint
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles MarginTop.Click
        FFW.Margin = New Padding(Val(MenuStrip2.Items("TxtLeft").Text), Val(MenuStrip2.Items("TxtTop").Text), Val(MenuStrip2.Items("TxtRight").Text), Val(MenuStrip2.Items("TxtBottom").Text))
        myGraphics.Dispose()
        FlowLayoutPanel1.Refresh()
        myGraphics = FlowLayoutPanel1.CreateGraphics
        myGraphics.DrawRectangle(MyPen, FFW.Location.X, FFW.Location.Y, FFW.Width, FFW.Height)
    End Sub

    Private Sub StripComboBox_Click(sender As Object, e As EventArgs) Handles StripComboBox.SelectedIndexChanged
        myGraphics.Dispose()
        FlowLayoutPanel1.Refresh()
        If StripComboBox.SelectedItem = "LeftToRight" Then
            FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight
        ElseIf StripComboBox.SelectedItem = "TopDown" Then
            FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        ElseIf StripComboBox.SelectedItem = "RightToLeft" Then
            FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft
        ElseIf StripComboBox.SelectedItem = "BottomUp" Then
            FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp
        End If
        myGraphics = FlowLayoutPanel1.CreateGraphics
        myGraphics.DrawRectangle(MyPen, FFW.Location.X, FFW.Location.Y, FFW.Width, FFW.Height)
    End Sub
End Class