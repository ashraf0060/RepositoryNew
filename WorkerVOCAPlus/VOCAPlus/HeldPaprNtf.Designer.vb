<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPaprNtf
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.BtnDoNtf = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.RdioPaprOnly = New System.Windows.Forms.RadioButton()
        Me.RdioAftrPh = New System.Windows.Forms.RadioButton()
        Me.RdioPaperAll = New System.Windows.Forms.RadioButton()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridHeld
        '
        Me.GridHeld.AllowUserToAddRows = False
        Me.GridHeld.AllowUserToDeleteRows = False
        Me.GridHeld.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridHeld.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GridHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridHeld.DefaultCellStyle = DataGridViewCellStyle6
        Me.GridHeld.Location = New System.Drawing.Point(27, 57)
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHeld.Size = New System.Drawing.Size(1193, 225)
        Me.GridHeld.TabIndex = 0
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(398, 641)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblMsg.Size = New System.Drawing.Size(517, 23)
        Me.LblMsg.TabIndex = 2060
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnDoNtf
        '
        Me.BtnDoNtf.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnDoNtf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDoNtf.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnDoNtf.Location = New System.Drawing.Point(855, 8)
        Me.BtnDoNtf.Name = "BtnDoNtf"
        Me.BtnDoNtf.Size = New System.Drawing.Size(122, 34)
        Me.BtnDoNtf.TabIndex = 2122
        Me.BtnDoNtf.Text = "عمل الإخطارات"
        Me.BtnDoNtf.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CloseBtn.Location = New System.Drawing.Point(12, 617)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 47)
        Me.CloseBtn.TabIndex = 2124
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'RdioPaprOnly
        '
        Me.RdioPaprOnly.AutoSize = True
        Me.RdioPaprOnly.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPaprOnly.Location = New System.Drawing.Point(517, 16)
        Me.RdioPaprOnly.Name = "RdioPaprOnly"
        Me.RdioPaprOnly.Size = New System.Drawing.Size(91, 26)
        Me.RdioPaprOnly.TabIndex = 2125
        Me.RdioPaprOnly.TabStop = True
        Me.RdioPaprOnly.Text = "ورقية فقط"
        Me.RdioPaprOnly.UseVisualStyleBackColor = True
        '
        'RdioAftrPh
        '
        Me.RdioAftrPh.AutoSize = True
        Me.RdioAftrPh.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioAftrPh.Location = New System.Drawing.Point(614, 16)
        Me.RdioAftrPh.Name = "RdioAftrPh"
        Me.RdioAftrPh.Size = New System.Drawing.Size(133, 26)
        Me.RdioAftrPh.TabIndex = 2126
        Me.RdioAftrPh.TabStop = True
        Me.RdioAftrPh.Text = "ورقية بعد الهاتف"
        Me.RdioAftrPh.UseVisualStyleBackColor = True
        '
        'RdioPaperAll
        '
        Me.RdioPaperAll.AutoSize = True
        Me.RdioPaperAll.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPaperAll.Location = New System.Drawing.Point(753, 16)
        Me.RdioPaperAll.Name = "RdioPaperAll"
        Me.RdioPaperAll.Size = New System.Drawing.Size(64, 26)
        Me.RdioPaperAll.TabIndex = 2127
        Me.RdioPaperAll.TabStop = True
        Me.RdioPaperAll.Text = "الــكـل"
        Me.RdioPaperAll.UseVisualStyleBackColor = True
        '
        'HeldPaprNtf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 681)
        Me.Controls.Add(Me.RdioPaperAll)
        Me.Controls.Add(Me.RdioAftrPh)
        Me.Controls.Add(Me.RdioPaprOnly)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.BtnDoNtf)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridHeld)
        Me.MinimumSize = New System.Drawing.Size(1263, 605)
        Me.Name = "HeldPaprNtf"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الإخطارات الورقية"
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents LblMsg As Label
    Friend WithEvents BtnDoNtf As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents RdioPaprOnly As RadioButton
    Friend WithEvents RdioAftrPh As RadioButton
    Friend WithEvents RdioPaperAll As RadioButton
End Class
