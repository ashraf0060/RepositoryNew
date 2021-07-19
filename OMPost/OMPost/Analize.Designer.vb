<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Analize
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.BtnChrt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtRevTot = New System.Windows.Forms.TextBox()
        Me.TxtShpTot = New System.Windows.Forms.TextBox()
        Me.BtnExprt = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(0, 181)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1174, 396)
        Me.DataGridView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AllowDrop = True
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnLoad)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnChrt)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1176, 70)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'BtnLoad
        '
        Me.BtnLoad.Location = New System.Drawing.Point(3, 3)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(75, 23)
        Me.BtnLoad.TabIndex = 0
        Me.BtnLoad.Text = "Load Data"
        Me.BtnLoad.UseVisualStyleBackColor = True
        '
        'BtnChrt
        '
        Me.BtnChrt.Enabled = False
        Me.BtnChrt.Location = New System.Drawing.Point(84, 3)
        Me.BtnChrt.Name = "BtnChrt"
        Me.BtnChrt.Size = New System.Drawing.Size(75, 23)
        Me.BtnChrt.TabIndex = 1
        Me.BtnChrt.Text = "Chart"
        Me.BtnChrt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'TxtRevTot
        '
        Me.TxtRevTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRevTot.Location = New System.Drawing.Point(3, 3)
        Me.TxtRevTot.Name = "TxtRevTot"
        Me.TxtRevTot.ReadOnly = True
        Me.TxtRevTot.Size = New System.Drawing.Size(100, 20)
        Me.TxtRevTot.TabIndex = 4
        '
        'TxtShpTot
        '
        Me.TxtShpTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShpTot.Location = New System.Drawing.Point(109, 3)
        Me.TxtShpTot.Name = "TxtShpTot"
        Me.TxtShpTot.ReadOnly = True
        Me.TxtShpTot.Size = New System.Drawing.Size(100, 20)
        Me.TxtShpTot.TabIndex = 5
        '
        'BtnExprt
        '
        Me.BtnExprt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExprt.Location = New System.Drawing.Point(215, 3)
        Me.BtnExprt.Name = "BtnExprt"
        Me.BtnExprt.Size = New System.Drawing.Size(75, 23)
        Me.BtnExprt.TabIndex = 7
        Me.BtnExprt.Text = "Export"
        Me.BtnExprt.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(12, 77)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(864, 98)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AllowDrop = True
        Me.FlowLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.Controls.Add(Me.TxtRevTot)
        Me.FlowLayoutPanel3.Controls.Add(Me.TxtShpTot)
        Me.FlowLayoutPanel3.Controls.Add(Me.BtnExprt)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(879, 75)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(295, 34)
        Me.FlowLayoutPanel3.TabIndex = 10
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.AllowDrop = True
        Me.FlowLayoutPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel4.Controls.Add(Me.RadioButton1)
        Me.FlowLayoutPanel4.Controls.Add(Me.RadioButton2)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(934, 112)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(215, 63)
        Me.FlowLayoutPanel4.TabIndex = 13
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Revenue"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(77, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(69, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Shipment"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.AllowDrop = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"ds", "jhg"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(527, 77)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(53, 34)
        Me.CheckedListBox1.TabIndex = 11
        Me.CheckedListBox1.Visible = False
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.AllowDrop = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(627, 77)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(23, 34)
        Me.CheckedListBox2.TabIndex = 12
        Me.CheckedListBox2.Visible = False
        '
        'Analize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1176, 577)
        Me.Controls.Add(Me.FlowLayoutPanel4)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Analize"
        Me.Text = "Analize"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents BtnLoad As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnChrt As Button
    Friend WithEvents TxtRevTot As TextBox
    Friend WithEvents TxtShpTot As TextBox
    Friend WithEvents BtnExprt As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
