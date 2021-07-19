<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PostalInt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblweight = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.cbxFrom = New System.Windows.Forms.ComboBox()
        Me.RdoGram = New System.Windows.Forms.RadioButton()
        Me.rdoKG = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.serv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Max = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.com = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CbxTo = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(205, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(44, 24)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "إلي :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(42, 24)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "من :"
        '
        'lblweight
        '
        Me.lblweight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblweight.AutoSize = True
        Me.lblweight.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblweight.Location = New System.Drawing.Point(394, 31)
        Me.lblweight.Name = "lblweight"
        Me.lblweight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblweight.Size = New System.Drawing.Size(173, 24)
        Me.lblweight.TabIndex = 115
        Me.lblweight.Text = "الوزن المطلوب بالكيلو :"
        '
        'txtWeight
        '
        Me.txtWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWeight.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(573, 30)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWeight.Size = New System.Drawing.Size(100, 29)
        Me.txtWeight.TabIndex = 114
        Me.txtWeight.Text = "0"
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxFrom
        '
        Me.cbxFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxFrom.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFrom.FormattingEnabled = True
        Me.cbxFrom.Location = New System.Drawing.Point(78, 31)
        Me.cbxFrom.Name = "cbxFrom"
        Me.cbxFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxFrom.Size = New System.Drawing.Size(121, 27)
        Me.cbxFrom.TabIndex = 112
        '
        'RdoGram
        '
        Me.RdoGram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoGram.AutoSize = True
        Me.RdoGram.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoGram.Location = New System.Drawing.Point(735, 30)
        Me.RdoGram.Name = "RdoGram"
        Me.RdoGram.Size = New System.Drawing.Size(71, 23)
        Me.RdoGram.TabIndex = 120
        Me.RdoGram.TabStop = True
        Me.RdoGram.Text = "Gram"
        Me.RdoGram.UseVisualStyleBackColor = True
        '
        'rdoKG
        '
        Me.rdoKG.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoKG.AutoSize = True
        Me.rdoKG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoKG.Location = New System.Drawing.Point(679, 31)
        Me.rdoKG.Name = "rdoKG"
        Me.rdoKG.Size = New System.Drawing.Size(50, 23)
        Me.rdoKG.TabIndex = 119
        Me.rdoKG.TabStop = True
        Me.rdoKG.Text = "KG"
        Me.rdoKG.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serv, Me.Max, Me.fWeight, Me.rp, Me.tax, Me.ins, Me.tot, Me.com})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.Location = New System.Drawing.Point(12, 95)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.Size = New System.Drawing.Size(1778, 412)
        Me.dgv1.TabIndex = 118
        '
        'serv
        '
        Me.serv.HeaderText = "الخدمة"
        Me.serv.Name = "serv"
        Me.serv.ReadOnly = True
        Me.serv.Width = 81
        '
        'Max
        '
        Me.Max.HeaderText = "الحد الاقصي للوزن "
        Me.Max.Name = "Max"
        Me.Max.ReadOnly = True
        Me.Max.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Max.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Max.Width = 147
        '
        'fWeight
        '
        Me.fWeight.HeaderText = "سعر الوزنه الاولي"
        Me.fWeight.Name = "fWeight"
        Me.fWeight.ReadOnly = True
        Me.fWeight.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fWeight.Width = 138
        '
        'rp
        '
        Me.rp.HeaderText = "سعر التكرار"
        Me.rp.Name = "rp"
        Me.rp.ReadOnly = True
        Me.rp.Width = 113
        '
        'tax
        '
        Me.tax.HeaderText = "الضريبة 14%"
        Me.tax.Name = "tax"
        Me.tax.ReadOnly = True
        Me.tax.Width = 128
        '
        'ins
        '
        Me.ins.HeaderText = "التامين"
        Me.ins.Name = "ins"
        Me.ins.ReadOnly = True
        Me.ins.Width = 81
        '
        'tot
        '
        Me.tot.HeaderText = "الاجمالي"
        Me.tot.Name = "tot"
        Me.tot.ReadOnly = True
        Me.tot.Width = 95
        '
        'com
        '
        Me.com.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.com.HeaderText = "ملاحظات"
        Me.com.Name = "com"
        Me.com.ReadOnly = True
        Me.com.Width = 96
        '
        'CbxTo
        '
        Me.CbxTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxTo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxTo.FormattingEnabled = True
        Me.CbxTo.Location = New System.Drawing.Point(255, 28)
        Me.CbxTo.Name = "CbxTo"
        Me.CbxTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CbxTo.Size = New System.Drawing.Size(121, 30)
        Me.CbxTo.TabIndex = 113
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1715, 535)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 51)
        Me.Button1.TabIndex = 123
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PostalInt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1802, 598)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblweight)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.cbxFrom)
        Me.Controls.Add(Me.RdoGram)
        Me.Controls.Add(Me.rdoKG)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.CbxTo)
        Me.Name = "PostalInt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أسعار الخدمات البريدية المحلية"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblweight As Label
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents cbxFrom As ComboBox
    Friend WithEvents RdoGram As RadioButton
    Friend WithEvents rdoKG As RadioButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents CbxTo As ComboBox
    Friend WithEvents serv As DataGridViewTextBoxColumn
    Friend WithEvents Max As DataGridViewTextBoxColumn
    Friend WithEvents fWeight As DataGridViewTextBoxColumn
    Friend WithEvents rp As DataGridViewTextBoxColumn
    Friend WithEvents tax As DataGridViewTextBoxColumn
    Friend WithEvents ins As DataGridViewTextBoxColumn
    Friend WithEvents tot As DataGridViewTextBoxColumn
    Friend WithEvents com As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
End Class
