Public Class cardGroup
    Inherits GroupBox

    Private WithEvents newCard As New Panel
    Private WithEvents cms As New ContextMenuStrip

    Public Event cardClicked(ByVal cp As cardPanel)
    Public Event cardAdded(ByVal cp As cardPanel)
    Public Event cardDeleted(ByVal cp As cardPanel)


    Public Sub New(ByVal parent As Panel, Optional ByVal name As String = "", Optional ByVal isSaved As Boolean = False)
        Me.Top = 6
        Me.Left = If(parent.Controls.OfType(Of cardGroup).Count > 0, parent.Controls.OfType(Of cardGroup).Max(Function(cg) cg.Right) + 6, 6)
        Me.Height = parent.Height - 25
        Me.Text = If(Not isSaved, InputBox("Enter caption"), "")
        If name <> "" Then
            Me.Name = name
        Else
            My.Settings.highestGroupIndex += 1
            Me.Name = "cardGroup" & My.Settings.highestGroupIndex
        End If
        newCard.Left = 6
        newCard.Top = 19
        newCard.Width = Me.Width - 12
        newCard.Height = 36
        newCard.BackColor = SystemColors.ControlDark
        Me.Controls.Add(newCard)
        cms.Items.Add("Delete", Nothing, AddressOf deleteCard)
    End Sub

    Private Sub newCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newCard.Click
        addCard()
    End Sub

    Public Sub addCard(Optional ByVal text As String = "", Optional ByVal percentage As Integer = 0)
        Dim newPanel As New cardPanel
        newPanel.Left = 6
        newPanel.Top = If(Me.Controls.OfType(Of cardPanel).Count > 0, Me.Controls.OfType(Of cardPanel).Max(Function(cp) cp.Bottom) + 6, 19)
        newPanel.Width = Me.Width - 12
        newPanel.Height = 36
        newPanel.BackColor = Color.White
        newPanel.percentage = percentage
        newPanel.Text = If(text <> "", text, InputBox("Enter caption"))
        Me.Controls.Add(newPanel)
        newPanel.ContextMenuStrip = cms
        AddHandler newPanel.MouseMove, AddressOf cardPanels_MouseMove
        AddHandler newPanel.MouseClick, AddressOf cardPanels_MouseClick
        RaiseEvent cardAdded(newPanel)
        compactCards()
    End Sub

    Private Sub newCard_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles newCard.Paint
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString("Add card", newCard.Font, Brushes.Black, New Rectangle(Point.Empty, newCard.Size), sf)
    End Sub

    Private Sub cardPanels_MouseClick(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        RaiseEvent cardClicked(DirectCast(sender, cardPanel))
    End Sub

    Private Sub cardPanels_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim cp As cardPanel = DirectCast(sender, cardPanel)
            Dim p As Point = cp.Parent.PointToScreen(cp.Location)
            Me.Controls.Remove(cp)
            Me.Parent.Controls.Add(cp)
            cp.Location = Me.Parent.PointToClient(p)
            cp.BringToFront()
            cp.Capture = False
            api.SendMessage(cp.Handle, api.WM_NCLBUTTONDOWN, CType(api.HT_CAPTION, IntPtr), IntPtr.Zero)
            Dim c As Control = GetContainerAtPoint(MousePosition)
            cp.Left = 6
            cp.Top = If(c.Controls.OfType(Of cardPanel).Count > 0, c.Controls.OfType(Of cardPanel).Max(Function(card) card.Bottom) + 6, 19)
            Me.Parent.Controls.Remove(cp)
            c.Controls.Add(cp)
            Array.ConvertAll(Me.Parent.Controls.OfType(Of cardGroup).ToArray, Function(cg) cg.compactCards())
        End If

    End Sub

    Private Function GetContainerAtPoint(ByVal p As Point) As Control
        Dim c As Control = Me.Parent.Controls.OfType(Of cardGroup).FirstOrDefault(Function(gb) gb.Bounds.Contains(Me.Parent.PointToClient(p)))
        If c IsNot Nothing Then
            Return c
        Else
            Return Me.Parent
        End If
    End Function

    Public Function compactCards() As Boolean
        Dim topY As Integer = 19
        For Each c As cardPanel In Me.Controls.OfType(Of cardPanel).OrderBy(Function(cp) cp.Top)
            c.Top = topY
            topY = c.Bottom + 6
        Next
        newCard.Top = topY
        Return True
    End Function

    Private Sub deleteCard(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent cardDeleted(DirectCast(cms.SourceControl, cardPanel))
        cms.SourceControl.Dispose()
        compactCards()
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}|{1}|{2}|{3}", Me.Name, MyBase.Text, MyBase.Location, MyBase.Size)
    End Function

End Class
