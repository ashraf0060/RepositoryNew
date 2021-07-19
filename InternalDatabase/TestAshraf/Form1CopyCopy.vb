Public Class Form1CopyCopy

    Dim Prv As Form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = 2
        Me.WindowState = FormWindowState.Maximized
        'WebBrowser1.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser2.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser3.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        'WebBrowser4.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        Adjust_()

        AddHandler ToolStripTextBox1.TextChanged, AddressOf ToolStripTextBox1_TextChanged
    End Sub

    Private Sub FilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RemoveFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFilterToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub MaxmizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaxmizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs)
        If ToolStripTextBox1.Text.Length = 0 Then
            ToolStripTextBox1.Text = 1
        End If
        ToolStripTextBox1.SelectAll()
        Adjust_()
    End Sub
    Private Sub Adjust_()
        Dim Lines_ As Integer = Int(Me.Controls.Count / ToolStripTextBox1.Text)
        Dim ItemPerLine As Integer = 0
        Dim X_ As Integer = 0
        Dim Y_ As Integer = 0

        For Each f In Me.Controls
            f.Size = New Point((Screen.PrimaryScreen.Bounds.Width / Val(ToolStripTextBox1.Text)), (Screen.PrimaryScreen.Bounds.Height / Val(ToolStripTextBox1.Text)))
            If f.tabindex = 0 Then
                f.Location = New Point(X_, Y_)
            Else
                If ToolStripTextBox1.Text = ItemPerLine Then
                    Y_ += f.size.Height
                    X_ += 0
                    ItemPerLine = 0
                Else
                    X_ += f.Size.Width
                End If
                f.Location = New Point(X_, Y_)

            End If


            f.Text = f.Name
            ItemPerLine += 1
        Next

        For f = 0 To Me.Controls.Count - 1

        Next
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim WebB As New WebBrowser
        WebB.Navigate("//10.10.26.4:8000/VOCAWedget.aspx")
        WebB.Margin = New Padding(0)
        WebB.IsWebBrowserContextMenuEnabled = False
        WebB.ContextMenuStrip = ContextMenuStrip1
        Me.Controls.Add(WebB)
        WebB.ScrollBarsEnabled = False
        Adjust_()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub FullToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullToolStripMenuItem.Click
        Dim hh = sender.GetCurrentParent().SourceControl
        'hh.Dock = DockStyle.Fill
        hh.dock = DockStyle.Fill
        hh.BringToFront()
    End Sub

    Private Sub RefullToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefullToolStripMenuItem.Click
        Dim hh = sender.GetCurrentParent().SourceControl
        hh.dock = DockStyle.None
        Adjust_()
    End Sub
    Private Sub AddToolStri_Click(sender As Object, e As EventArgs)
        MsgBox(sender.name.ToString)
    End Sub

    Private Sub ببToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ببToolStripMenuItem.Click
        Dim hh = sender.GetCurrentParent().SourceControl
        MsgBox(hh.name.ToString)
    End Sub
End Class
