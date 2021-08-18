<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PostalExt
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cbxCountry = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcoun = New System.Windows.Forms.TextBox()
        Me.txtContinent = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtwight = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rdoKG = New System.Windows.Forms.RadioButton()
        Me.RdoGram = New System.Windows.Forms.RadioButton()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.serv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stat = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Max = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.com = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxCountry
        '
        Me.cbxCountry.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCountry.FormattingEnabled = True
        Me.cbxCountry.Location = New System.Drawing.Point(100, 6)
        Me.cbxCountry.Name = "cbxCountry"
        Me.cbxCountry.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxCountry.Size = New System.Drawing.Size(309, 29)
        Me.cbxCountry.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(77, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "اسم الدولة :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(82, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "رمز الدولة :"
        '
        'txtcoun
        '
        Me.txtcoun.Enabled = False
        Me.txtcoun.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcoun.Location = New System.Drawing.Point(100, 41)
        Me.txtcoun.Name = "txtcoun"
        Me.txtcoun.ReadOnly = True
        Me.txtcoun.Size = New System.Drawing.Size(62, 29)
        Me.txtcoun.TabIndex = 3
        Me.txtcoun.TabStop = False
        '
        'txtContinent
        '
        Me.txtContinent.Enabled = False
        Me.txtContinent.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContinent.Location = New System.Drawing.Point(224, 41)
        Me.txtContinent.Name = "txtContinent"
        Me.txtContinent.ReadOnly = True
        Me.txtContinent.Size = New System.Drawing.Size(185, 29)
        Me.txtContinent.TabIndex = 5
        Me.txtContinent.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(168, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(50, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "القارة :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(420, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(153, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "الوزن المطلوب بالكيلو :"
        '
        'txtwight
        '
        Me.txtwight.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwight.Location = New System.Drawing.Point(590, 22)
        Me.txtwight.Name = "txtwight"
        Me.txtwight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtwight.ShortcutsEnabled = False
        Me.txtwight.Size = New System.Drawing.Size(70, 29)
        Me.txtwight.TabIndex = 1
        Me.txtwight.Text = "0"
        Me.txtwight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1611, 655)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 51)
        Me.Button1.TabIndex = 94
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rdoKG
        '
        Me.rdoKG.AutoSize = True
        Me.rdoKG.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoKG.Location = New System.Drawing.Point(677, 23)
        Me.rdoKG.Name = "rdoKG"
        Me.rdoKG.Size = New System.Drawing.Size(57, 26)
        Me.rdoKG.TabIndex = 95
        Me.rdoKG.TabStop = True
        Me.rdoKG.Text = "KG"
        Me.rdoKG.UseVisualStyleBackColor = True
        '
        'RdoGram
        '
        Me.RdoGram.AutoSize = True
        Me.RdoGram.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoGram.Location = New System.Drawing.Point(738, 22)
        Me.RdoGram.Name = "RdoGram"
        Me.RdoGram.Size = New System.Drawing.Size(76, 26)
        Me.RdoGram.TabIndex = 96
        Me.RdoGram.TabStop = True
        Me.RdoGram.Text = "Gram"
        Me.RdoGram.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serv, Me.stat, Me.Max, Me.fWeight, Me.rp, Me.tax, Me.ins, Me.tot, Me.com})
        Me.dgv1.Location = New System.Drawing.Point(21, 94)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.Size = New System.Drawing.Size(1634, 555)
        Me.dgv1.TabIndex = 1
        '
        'serv
        '
        Me.serv.HeaderText = "الخدمة"
        Me.serv.Name = "serv"
        Me.serv.ReadOnly = True
        '
        'stat
        '
        Me.stat.HeaderText = "الحاله "
        Me.stat.Name = "stat"
        Me.stat.ReadOnly = True
        Me.stat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Max
        '
        Me.Max.HeaderText = "الحد الاقصي للوزن "
        Me.Max.Name = "Max"
        Me.Max.ReadOnly = True
        Me.Max.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Max.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'fWeight
        '
        Me.fWeight.HeaderText = "سعر الوزنه الاولي"
        Me.fWeight.Name = "fWeight"
        Me.fWeight.ReadOnly = True
        Me.fWeight.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'rp
        '
        Me.rp.HeaderText = "سعر التكرار"
        Me.rp.Name = "rp"
        Me.rp.ReadOnly = True
        '
        'tax
        '
        Me.tax.HeaderText = "الضريبة 14%"
        Me.tax.Name = "tax"
        Me.tax.ReadOnly = True
        '
        'ins
        '
        Me.ins.HeaderText = "التامين"
        Me.ins.Name = "ins"
        Me.ins.ReadOnly = True
        '
        'tot
        '
        Me.tot.HeaderText = "الاجمالي"
        Me.tot.Name = "tot"
        Me.tot.ReadOnly = True
        '
        'com
        '
        Me.com.HeaderText = "ملاحظات"
        Me.com.Name = "com"
        Me.com.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(524, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(549, 34)
        Me.Label6.TabIndex = 98
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PostalExt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1698, 718)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.RdoGram)
        Me.Controls.Add(Me.rdoKG)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtwight)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtContinent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcoun)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxCountry)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PostalExt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أسعار الخدمات البريدية الدولية"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxCountry As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcoun As TextBox
    Friend WithEvents txtContinent As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtwight As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents rdoKG As RadioButton
    Friend WithEvents RdoGram As RadioButton
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label6 As Label
    Friend WithEvents serv As DataGridViewTextBoxColumn
    Friend WithEvents stat As DataGridViewImageColumn
    Friend WithEvents Max As DataGridViewTextBoxColumn
    Friend WithEvents fWeight As DataGridViewTextBoxColumn
    Friend WithEvents rp As DataGridViewTextBoxColumn
    Friend WithEvents tax As DataGridViewTextBoxColumn
    Friend WithEvents ins As DataGridViewTextBoxColumn
    Friend WithEvents tot As DataGridViewTextBoxColumn
    Friend WithEvents com As DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As Timer
End Class
