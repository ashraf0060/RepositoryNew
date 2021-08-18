<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPaprNtfPrepare
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LblLoad = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtTrck = New System.Windows.Forms.MaskedTextBox()
        Me.RdioPaperAll = New System.Windows.Forms.RadioButton()
        Me.RdioPapNoPrnt = New System.Windows.Forms.RadioButton()
        Me.RdioPapPrnt = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridHeld
        '
        Me.GridHeld.AllowUserToAddRows = False
        Me.GridHeld.AllowUserToDeleteRows = False
        Me.GridHeld.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridHeld.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridHeld.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridHeld.Location = New System.Drawing.Point(27, 108)
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridHeld.Size = New System.Drawing.Size(1193, 507)
        Me.GridHeld.TabIndex = 0
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(399, 618)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblMsg.Size = New System.Drawing.Size(517, 23)
        Me.LblMsg.TabIndex = 2060
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CloseBtn.Location = New System.Drawing.Point(1167, 627)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 47)
        Me.CloseBtn.TabIndex = 2124
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Location = New System.Drawing.Point(547, 19)
        Me.DateTimePicker1.MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker1.TabIndex = 2125
        Me.DateTimePicker1.Value = New Date(2021, 1, 4, 0, 0, 0, 0)
        '
        'LblLoad
        '
        Me.LblLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLoad.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblLoad.Location = New System.Drawing.Point(365, 329)
        Me.LblLoad.Name = "LblLoad"
        Me.LblLoad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblLoad.Size = New System.Drawing.Size(517, 23)
        Me.LblLoad.TabIndex = 2126
        Me.LblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.rectan
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(782, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 40)
        Me.Button1.TabIndex = 2127
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtTrck
        '
        Me.TxtTrck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTrck.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtTrck.Location = New System.Drawing.Point(224, 76)
        Me.TxtTrck.Mask = "LL 900000000 LL"
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTrck.Size = New System.Drawing.Size(133, 26)
        Me.TxtTrck.TabIndex = 2132
        '
        'RdioPaperAll
        '
        Me.RdioPaperAll.AutoSize = True
        Me.RdioPaperAll.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPaperAll.Location = New System.Drawing.Point(709, 64)
        Me.RdioPaperAll.Name = "RdioPaperAll"
        Me.RdioPaperAll.Size = New System.Drawing.Size(64, 26)
        Me.RdioPaperAll.TabIndex = 2135
        Me.RdioPaperAll.TabStop = True
        Me.RdioPaperAll.Text = "الــكـل"
        Me.RdioPaperAll.UseVisualStyleBackColor = True
        '
        'RdioPapNoPrnt
        '
        Me.RdioPapNoPrnt.AutoSize = True
        Me.RdioPapNoPrnt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPapNoPrnt.Location = New System.Drawing.Point(601, 64)
        Me.RdioPapNoPrnt.Name = "RdioPapNoPrnt"
        Me.RdioPapNoPrnt.Size = New System.Drawing.Size(106, 26)
        Me.RdioPapNoPrnt.TabIndex = 2134
        Me.RdioPapNoPrnt.TabStop = True
        Me.RdioPapNoPrnt.Text = "غير مطبوعة"
        Me.RdioPapNoPrnt.UseVisualStyleBackColor = True
        '
        'RdioPapPrnt
        '
        Me.RdioPapPrnt.AutoSize = True
        Me.RdioPapPrnt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPapPrnt.Location = New System.Drawing.Point(492, 64)
        Me.RdioPapPrnt.Name = "RdioPapPrnt"
        Me.RdioPapPrnt.Size = New System.Drawing.Size(105, 26)
        Me.RdioPapPrnt.TabIndex = 2133
        Me.RdioPapPrnt.TabStop = True
        Me.RdioPapPrnt.Text = "مطبوعة فقط"
        Me.RdioPapPrnt.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(779, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 33)
        Me.Button2.TabIndex = 2136
        Me.Button2.Text = "تسجيل الطباعة"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'HeldPaprNtfPrepare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 681)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RdioPaperAll)
        Me.Controls.Add(Me.RdioPapNoPrnt)
        Me.Controls.Add(Me.RdioPapPrnt)
        Me.Controls.Add(Me.TxtTrck)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GridHeld)
        Me.Controls.Add(Me.LblLoad)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.LblMsg)
        Me.Name = "HeldPaprNtfPrepare"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طباعة الإخطارات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents LblMsg As Label
    Friend WithEvents CloseBtn As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LblLoad As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtTrck As MaskedTextBox
    Friend WithEvents RdioPaperAll As RadioButton
    Friend WithEvents RdioPapNoPrnt As RadioButton
    Friend WithEvents RdioPapPrnt As RadioButton
    Friend WithEvents Button2 As Button
End Class
