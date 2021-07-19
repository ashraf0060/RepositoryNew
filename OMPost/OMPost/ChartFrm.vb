Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Drawing.Drawing2D
Imports Microsoft.FSharp.Core

Public Class ChartFrm
    Dim Seris As String = ""
    Private Sub Chart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox3.DrawMode = DrawMode.OwnerDrawFixed
        ComboBox3.Font = New Font("Microsoft Sans Serif, 11.25pt", 11.25)
        ComboBox3.ItemHeight = 20
        Dim objFontFamily As FontFamily
        Dim objFontCollection As System.Drawing.Text.FontCollection
        objFontCollection = New Text.InstalledFontCollection()
        For Each objFontFamily In objFontCollection.Families
            ComboBox3.Items.Add(objFontFamily.Name)
        Next
        ComboBox1.DataSource = System.Enum.GetValues(GetType(SeriesChartType))
        Chart2.Series.RemoveAt(0)
        Chart2.DataSource = MainTbl
        Chart2.DataBind()

        Chart2.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        Chart2.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = 90

        'Chart2.Series("Series1").YAxisType = AxisType.Primary


        Chart2.ChartAreas("ChartArea1").AxisY.Minimum = 500
        Chart2.ChartAreas("ChartArea1").AxisY.Maximum = 900000

        Chart2.ChartAreas("ChartArea1").AxisY2.Minimum = 0
        Chart2.ChartAreas("ChartArea1").AxisY2.Maximum = 200

        Chart2.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        TrackBar1.Value = Chart2.ChartAreas("ChartArea1").Area3DStyle.Rotation
        TrackBar2.Value = Chart2.ChartAreas("ChartArea1").Area3DStyle.PointDepth
        TrackBar3.Value = Chart2.ChartAreas("ChartArea1").Area3DStyle.PointGapDepth
        Dim Rd As New RadioButton
        For DD = 1 To MainTbl.Columns.Count - 1
            Chart2.Series.Add(MainTbl.Columns(DD).ColumnName)
            Chart2.Series(MainTbl.Columns(DD).ColumnName).IsValueShownAsLabel = True
            Chart2.Series(MainTbl.Columns(DD).ColumnName).Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            Chart2.Series(MainTbl.Columns(DD).ColumnName)(ComboBox1.SelectedItem.ToString & "LabelStyle") = "best fit"
            Rd = New RadioButton
            Rd.AutoSize = True
            FlowLayoutPanel1.Controls.Add(Rd)
            Rd.Name = MainTbl.Columns(DD).ColumnName
            Rd.Text = MainTbl.Columns(DD).ColumnName
            AddHandler Rd.Click, AddressOf RadioButton_CheckedChanged
            For gg = 0 To MainTbl.Rows.Count - 1
                Chart2.Series(MainTbl.Columns(DD).ColumnName).Points.AddXY(MainTbl.Rows(gg).Item(0), MainTbl.Rows(gg).Item(DD))
                Chart2.Series(MainTbl.Columns(DD).ColumnName).YAxisType = AxisType.Primary
                Chart2.Series(MainTbl.Columns(DD).ColumnName).Points(gg).LabelFormat = "f0"
            Next
        Next
        Rd.Checked = True
        Seris = Rd.Name
        Me.Text = MainTbl.Rows.Count
        Chart2.Titles.Add(New Title("Evets Per Minute", Docking.Top, New Font("Verdana", 12.0F, FontStyle.Bold), Color.Black))

        TextBox1.Text = Chart2.ChartAreas("ChartArea1").AxisY.Minimum
        TextBox2.Text = Chart2.ChartAreas("ChartArea1").AxisY.Maximum
        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        'Chart2.Series("Series1").YValueMembers = "Ship"
        'Chart2.Series("Series1").XValueMember = "hh"
        'Chart2.Series("Series1").IsValueShownAsLabel = True
        'Chart2.Series("Series1").Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        'Chart2.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), ComboBox1.SelectedItem, True), SeriesChartType)
        'Chart2.Series("Series1")("ColumnLabelStyle") = "best fit"
        'Chart2.Series("Series1").la
        'Chart2.Series("Series1").Label = "#VALX"
        'Chart2.Series("Series2").Label = "#VALX"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Chart2.Series(Seris).ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), ComboBox1.SelectedItem, True), SeriesChartType)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Chart2.ChartAreas("ChartArea1").AxisY.Minimum = TextBox1.Text
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.Leave
        Chart2.ChartAreas("ChartArea1").AxisY.Maximum = TextBox2.Text
    End Sub
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        Seris = sender.name
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Chart2.Series(Seris).Font = New Font("Segoe UI", ComboBox2.SelectedItem, FontStyle.Bold)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnCpyChrt.Click
        'Dim SV As SaveFileDialog = New SaveFileDialog()
        'SV.Filter = "Jpeg|*.Jpeg"
        'If SV.ShowDialog() = DialogResult.OK Then
        '    Dim format As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg

        '    'Dim g As Graphics = Graphics.DrawImageAbort(format)
        '    'g.SmoothingMode = SmoothingMode.HighQuality
        '    'g.InterpolationMode = InterpolationMode.HighQualityBilinear
        '    'g.CompositingQuality = CompositingQuality.HighQuality
        '    'g.PixelOffsetMode = PixelOffsetMode.HighQuality

        '    Chart2.SaveImage(SV.FileName, format)







        Dim memoryImage As Bitmap

        Dim myGraphics As Graphics = Me.CreateGraphics()

        Dim s As Size = Chart2.Size

        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)

        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)

        memoryGraphics.CopyFromScreen(Chart2.Location.X, Chart2.Location.Y, 0, 0, s)




        myGraphics.SmoothingMode = SmoothingMode.HighQuality
        myGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear
        myGraphics.CompositingQuality = CompositingQuality.HighQuality
        myGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Using ms As New IO.MemoryStream()
            Try
                ms.Seek(0, SeekOrigin.Begin)
                Using mf As New Bitmap(memoryImage)
                    Clipboard.SetImage(mf)
                End Using
            Finally
                ms.Close()
            End Try
        End Using

        'End If
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim color_ As DialogResult
        color_ = ColorDialog1.ShowDialog
        If color_ = DialogResult.OK Then
            Chart2.Series(Seris).Color = ColorDialog1.Color
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim color_ As DialogResult
        color_ = ColorDialog1.ShowDialog
        If color_ = DialogResult.OK Then
            For RR = 0 To Chart2.Series(Seris).Points.Count - 1
                Chart2.Series(Seris).Points(RR).LabelBackColor = ColorDialog1.Color
            Next
        End If
    End Sub
    Private Sub ComboBox1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox3.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Focus) <> 0 Then
            e.DrawFocusRectangle()
        End If
        Dim objBrush As Brush = Nothing
        Try
            objBrush = New SolidBrush(e.ForeColor)
            Dim _FontName As String = ComboBox3.Items(e.Index)
            Dim _font As Font
            Dim _fontfamily = New FontFamily(_FontName)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                _font = New Font(_fontfamily, 14, FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                _font = New Font(_fontfamily, 14, FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                _font = New Font(_fontfamily, 14, FontStyle.Italic)
            End If
            e.Graphics.DrawString(_FontName, _font, objBrush, e.Bounds)
        Finally
            If objBrush IsNot Nothing Then
                objBrush.Dispose()
            End If
            objBrush = Nothing
        End Try
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Chart2.Series(Seris).Font = New Font(ComboBox3.SelectedItem.ToString, 8.0F, FontStyle.Bold)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Chart2.Series(Seris).YAxisType = AxisType.Primary
            CheckBox1.Text = "Primary"
        Else
            Chart2.Series(Seris).YAxisType = AxisType.Secondary
            CheckBox1.Text = "Secondary"
        End If
    End Sub

    Private Sub Chek3D_CheckedChanged(sender As Object, e As EventArgs) Handles Chek3D.CheckedChanged
        If Chek3D.Checked = True Then
            Chart2.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
            Chek3D.Text = "2D"
        Else
            Chart2.ChartAreas("ChartArea1").Area3DStyle.Enable3D = False
            Chek3D.Text = "3D"
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ChekLbl.CheckedChanged
        If ChekLbl.Checked = True Then
            Chart2.Series(Seris)(ComboBox1.Text & "LabelStyle") = "outSide"
        Else
            Chart2.Series(Seris)(ComboBox1.Text & "LabelStyle") = "inSide"
        End If

    End Sub
    Private Sub ChartFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Chart2.ChartAreas("ChartArea1").Area3DStyle.Rotation = TrackBar1.Value
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Chart2.ChartAreas("ChartArea1").Area3DStyle.PointDepth = TrackBar2.Value
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Chart2.ChartAreas("ChartArea1").Area3DStyle.PointGapDepth = TrackBar3.Value
    End Sub
End Class