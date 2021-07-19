Public Class Form1

    Dim Prv As Form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = 1
        Me.WindowState = FormWindowState.Maximized
        WebBrowser1.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser2.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser3.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser4.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        Adjust_()
    End Sub

    Private Sub FilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterToolStripMenuItem.Click
        Me.Close()
        'Dim hh = sender.GetCurrentParent().SourceControl
        'MsgBox(hh.url.ToString)
    End Sub

    Private Sub RemoveFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFilterToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub MaxmizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaxmizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        If ToolStripTextBox1.Text.Length = 0 Then
            ToolStripTextBox1.Text = 1
        End If
        ToolStripTextBox1.SelectAll()
        Adjust_()
    End Sub
    Private Sub Adjust_()
        Dim PP As Integer = 0
        If FlowLayoutPanel1.Controls.Count >= Val(ToolStripTextBox1.Text) Then
            If (FlowLayoutPanel1.Controls.Count / Val(ToolStripTextBox1.Text)) > Int(FlowLayoutPanel1.Controls.Count / Val(ToolStripTextBox1.Text)) Then
                PP = Int(FlowLayoutPanel1.Controls.Count / Val(ToolStripTextBox1.Text)) + 1
            Else
                PP = Int(FlowLayoutPanel1.Controls.Count / Val(ToolStripTextBox1.Text))
            End If
        End If
        For Each R As WebBrowser In FlowLayoutPanel1.Controls
            R.Size = New Point((Screen.PrimaryScreen.Bounds.Width - 10) / Val(ToolStripTextBox1.Text), (Screen.PrimaryScreen.Bounds.Height - 10) / PP)
        Next
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim WebB As New WebBrowser
        WebB.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        WebB.Margin = New Padding(0)
        WebB.IsWebBrowserContextMenuEnabled = False
        WebB.ContextMenuStrip = ContextMenuStrip1
        FlowLayoutPanel1.Controls.Add(WebB)
        WebB.ScrollBarsEnabled = False
        Adjust_()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim hh = sender.GetCurrentParent().SourceControl
        hh.Refresh()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim hh = sender.GetCurrentParent().SourceControl
        hh.tabindex
        FlowLayoutPanel1.Controls.RemoveAt(hh.tabindex - 1)
        Adjust_()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
