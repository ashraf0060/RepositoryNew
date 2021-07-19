Public Class cardPanel
    Inherits Panel

    Private _percentage As Integer
    Public Property percentage() As Integer
        Get
            Return _percentage
        End Get
        Set(ByVal value As Integer)
            _percentage = value
        End Set
    End Property

    Private _text As String
    Public Shadows Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(212, 157, 93)), New Rectangle(0, 0, CInt((MyBase.Width / 100) * percentage), 6))
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(Text, MyBase.Font, Brushes.Black, New Rectangle(Point.Empty, MyBase.Size), sf)
        MyBase.OnPaint(e)
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}|{1}|{2}", percentage, Text, MyBase.Parent.Name)
    End Function

End Class
