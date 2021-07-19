<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChartFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.BtnCpyChrt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Chek3D = New System.Windows.Forms.CheckBox()
        Me.ChekLbl = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'Chart2
        '
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.None
        ChartArea1.AxisX.Crossing = -1.7976931348623157E+308R
        ChartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitStyle = CType((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Angle = 40
        ChartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Legend1.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chart2.Legends.Add(Legend1)
        Me.Chart2.Location = New System.Drawing.Point(0, 110)
        Me.Chart2.Name = "Chart2"
        Series1.ChartArea = "ChartArea1"
        Series1.CustomProperties = "PixelPointWidth=20, DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.3, " &
    "LabelStyle=Top, MaxPixelPointWidth=20"
        Series1.IsValueShownAsLabel = True
        Series1.IsXValueIndexed = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(1019, 566)
        Me.Chart2.TabIndex = 4
        Me.Chart2.Text = "Chart2"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(130, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(236, 3)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 7
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnCpyChrt)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Chek3D)
        Me.FlowLayoutPanel1.Controls.Add(Me.ChekLbl)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TrackBar1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TrackBar2)
        Me.FlowLayoutPanel1.Controls.Add(Me.TrackBar3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1019, 104)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "24"})
        Me.ComboBox2.Location = New System.Drawing.Point(342, 3)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 8
        '
        'BtnCpyChrt
        '
        Me.BtnCpyChrt.Location = New System.Drawing.Point(469, 3)
        Me.BtnCpyChrt.Name = "BtnCpyChrt"
        Me.BtnCpyChrt.Size = New System.Drawing.Size(75, 23)
        Me.BtnCpyChrt.TabIndex = 9
        Me.BtnCpyChrt.Text = "Copy Chart"
        Me.BtnCpyChrt.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(550, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Change Element Color"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(685, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(129, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Change Lable Color"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(3, 32)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(283, 21)
        Me.ComboBox3.TabIndex = 12
        '
        'Chek3D
        '
        Me.Chek3D.AutoSize = True
        Me.Chek3D.Checked = True
        Me.Chek3D.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chek3D.Location = New System.Drawing.Point(292, 32)
        Me.Chek3D.Name = "Chek3D"
        Me.Chek3D.Size = New System.Drawing.Size(39, 17)
        Me.Chek3D.TabIndex = 14
        Me.Chek3D.Text = "3D"
        Me.Chek3D.UseVisualStyleBackColor = True
        '
        'ChekLbl
        '
        Me.ChekLbl.AutoSize = True
        Me.ChekLbl.Location = New System.Drawing.Point(337, 32)
        Me.ChekLbl.Name = "ChekLbl"
        Me.ChekLbl.Size = New System.Drawing.Size(51, 17)
        Me.ChekLbl.TabIndex = 15
        Me.ChekLbl.Text = "Label"
        Me.ChekLbl.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(394, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(117, 17)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "Primary/Secondary"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.LargeChange = 10
        Me.TrackBar1.Location = New System.Drawing.Point(517, 32)
        Me.TrackBar1.Maximum = 180
        Me.TrackBar1.Minimum = 10
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(191, 27)
        Me.TrackBar1.SmallChange = 5
        Me.TrackBar1.TabIndex = 16
        Me.TrackBar1.Value = 10
        '
        'TrackBar2
        '
        Me.TrackBar2.AutoSize = False
        Me.TrackBar2.LargeChange = 100
        Me.TrackBar2.Location = New System.Drawing.Point(714, 32)
        Me.TrackBar2.Maximum = 1000
        Me.TrackBar2.Minimum = 10
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(191, 27)
        Me.TrackBar2.SmallChange = 10
        Me.TrackBar2.TabIndex = 17
        Me.TrackBar2.Value = 10
        '
        'TrackBar3
        '
        Me.TrackBar3.AutoSize = False
        Me.TrackBar3.LargeChange = 100
        Me.TrackBar3.Location = New System.Drawing.Point(3, 65)
        Me.TrackBar3.Maximum = 1000
        Me.TrackBar3.Minimum = 10
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(191, 27)
        Me.TrackBar3.SmallChange = 10
        Me.TrackBar3.TabIndex = 18
        Me.TrackBar3.Value = 10
        '
        'ChartFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 676)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Chart2)
        Me.Name = "ChartFrm"
        Me.Text = "Chart"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents BtnCpyChrt As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Chek3D As CheckBox
    Friend WithEvents ChekLbl As CheckBox
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents TrackBar3 As TrackBar
End Class
