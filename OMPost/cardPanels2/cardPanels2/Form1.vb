Public Class Form1

    Dim groups As New List(Of cardGroup)
    Dim panels As New List(Of cardPanel)

    Private WithEvents cms As New ContextMenuStrip

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Dim cg As New cardGroup(Panel1)
        Me.Panel1.Controls.Add(cg)
        AddHandler cg.MouseMove, AddressOf cg_MouseMove
        AddHandler cg.cardClicked, AddressOf cg_cardClicked
        AddHandler cg.cardAdded, AddressOf cg_cardAdded
        AddHandler cg.cardDeleted, AddressOf cg_cardDeleted
        compactGroups()
        groups.Add(cg)
        cg.ContextMenuStrip = cms
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Dim p As Panel = DirectCast(sender, Panel)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString("Add group", p.Font, Brushes.Black, New Rectangle(Point.Empty, p.Size), sf)
    End Sub

    Private Sub compactGroups()
        Dim leftY As Integer = 6
        For Each g As cardGroup In Me.Panel1.Controls.OfType(Of cardGroup).OrderBy(Function(cg) cg.Left)
            g.Top = 6
            g.Left = leftY
            leftY = g.Right + 6
        Next
        Panel2.Left = leftY
    End Sub

    Private Sub cg_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim cg As cardGroup = DirectCast(sender, cardGroup)
            cg.BringToFront()
            cg.Capture = False
            api.SendMessage(cg.Handle, api.WM_NCLBUTTONDOWN, CType(api.HT_CAPTION, IntPtr), IntPtr.Zero)
            compactGroups()
        End If
    End Sub

    Private Sub cg_cardClicked(ByVal cp As cardPanel)
        ComboBox1.SelectedIndex = ComboBox1.FindStringExact(panels.IndexOf(cp).ToString)
    End Sub

    Private Sub cg_cardAdded(ByVal cp As cardPanel)
        ComboBox1.Items.Add(panels.Count)
        panels.Add(cp)
    End Sub

    Private Sub cg_cardDeleted(ByVal cp As cardPanel)
        panels.Remove(cp)
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(Array.ConvertAll(Enumerable.Range(0, panels.Count).ToArray, Function(x) x.ToString))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then Return
        NumericUpDown1.Value = panels(CInt(ComboBox1.Text)).percentage
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If ComboBox1.SelectedIndex = -1 Then Return
        panels(ComboBox1.SelectedIndex).percentage = CInt(NumericUpDown1.Value)
        panels(ComboBox1.SelectedIndex).Refresh()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.savedGroups.Clear()
        My.Settings.savedGroups.AddRange(Array.ConvertAll(groups.OrderBy(Function(g) g.Left).ToArray, Function(g) g.ToString))
        My.Settings.savedCards.Clear()
        My.Settings.savedCards.AddRange(Array.ConvertAll(panels.OrderBy(Function(p) p.Parent.Name).ThenBy(Function(p) p.Top).ToArray, Function(cp) cp.ToString))
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.savedGroups Is Nothing Then
            My.Settings.savedGroups = New Specialized.StringCollection
        Else
            Array.ConvertAll(My.Settings.savedGroups.Cast(Of String).ToArray, Function(s) loadGroup(s))
        End If
        If My.Settings.savedCards Is Nothing Then
            My.Settings.savedCards = New Specialized.StringCollection
        Else
            Array.ConvertAll(My.Settings.savedCards.Cast(Of String).ToArray, Function(s) loadCard(s))
        End If
        cms.Items.Add("Delete group", Nothing, AddressOf deleteGroup)
    End Sub

    Private Sub deleteGroup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cg As cardGroup = DirectCast(cms.SourceControl, cardGroup)
        groups.Remove(cg)
        panels.RemoveAll(Function(cp) cg.Controls.Contains(cp))
        cg.Dispose()
        compactGroups()
    End Sub

    Private Function loadGroup(ByVal savedCard As String) As cardGroup
        Dim fields() As String = savedCard.Split("|"c)

        Dim cg As New cardGroup(Panel1, fields(0), True)
        cg.Text = fields(1)
        Dim l() As String = fields(2).Split("="c)
        cg.Location = New Point(CInt(Val(l(1))), CInt(Val(l(2))))

        Dim s() As String = fields(3).Split("="c)
        cg.Size = New Size(CInt(Val(s(1))), CInt(Val(s(2))))

        Me.Panel1.Controls.Add(cg)
        AddHandler cg.MouseMove, AddressOf cg_MouseMove
        AddHandler cg.cardClicked, AddressOf cg_cardClicked
        AddHandler cg.cardAdded, AddressOf cg_cardAdded
        AddHandler cg.cardDeleted, AddressOf cg_cardDeleted
        compactGroups()
        groups.Add(cg)

        cg.ContextMenuStrip = cms

        Return Nothing

    End Function

    Private Function loadCard(ByVal savedCard As String) As cardPanel
        Dim fields() As String = savedCard.Split("|"c)

        Dim c As cardGroup = DirectCast(Me.Panel1.Controls(fields(2)), cardGroup)
        c.addCard(fields(1), CInt(fields(0)))

        Return Nothing

    End Function

End Class
