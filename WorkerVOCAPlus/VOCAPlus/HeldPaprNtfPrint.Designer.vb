<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPaprNtfPrint
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridPHHeld = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.BtnPrv = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LblLoad = New System.Windows.Forms.Label()
        Me.RdioPaperAll = New System.Windows.Forms.RadioButton()
        Me.RdioPapNoPrnt = New System.Windows.Forms.RadioButton()
        Me.RdioPapPrnt = New System.Windows.Forms.RadioButton()
        CType(Me.GridPHHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridPHHeld
        '
        Me.GridPHHeld.AllowUserToAddRows = False
        Me.GridPHHeld.AllowUserToDeleteRows = False
        Me.GridPHHeld.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridPHHeld.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GridPHHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridPHHeld.DefaultCellStyle = DataGridViewCellStyle4
        Me.GridPHHeld.Location = New System.Drawing.Point(27, 57)
        Me.GridPHHeld.Name = "GridPHHeld"
        Me.GridPHHeld.ReadOnly = True
        Me.GridPHHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridPHHeld.Size = New System.Drawing.Size(1193, 558)
        Me.GridPHHeld.TabIndex = 0
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
        'BtnPrv
        '
        Me.BtnPrv.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Preview1
        Me.BtnPrv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnPrv.Location = New System.Drawing.Point(771, 11)
        Me.BtnPrv.Name = "BtnPrv"
        Me.BtnPrv.Size = New System.Drawing.Size(111, 40)
        Me.BtnPrv.TabIndex = 2122
        Me.BtnPrv.UseVisualStyleBackColor = True
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
        'RdioPaperAll
        '
        Me.RdioPaperAll.AutoSize = True
        Me.RdioPaperAll.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPaperAll.Location = New System.Drawing.Point(450, 19)
        Me.RdioPaperAll.Name = "RdioPaperAll"
        Me.RdioPaperAll.Size = New System.Drawing.Size(64, 26)
        Me.RdioPaperAll.TabIndex = 2138
        Me.RdioPaperAll.TabStop = True
        Me.RdioPaperAll.Text = "الــكـل"
        Me.RdioPaperAll.UseVisualStyleBackColor = True
        '
        'RdioPapNoPrnt
        '
        Me.RdioPapNoPrnt.AutoSize = True
        Me.RdioPapNoPrnt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPapNoPrnt.Location = New System.Drawing.Point(342, 19)
        Me.RdioPapNoPrnt.Name = "RdioPapNoPrnt"
        Me.RdioPapNoPrnt.Size = New System.Drawing.Size(106, 26)
        Me.RdioPapNoPrnt.TabIndex = 2137
        Me.RdioPapNoPrnt.TabStop = True
        Me.RdioPapNoPrnt.Text = "غير مطبوعة"
        Me.RdioPapNoPrnt.UseVisualStyleBackColor = True
        '
        'RdioPapPrnt
        '
        Me.RdioPapPrnt.AutoSize = True
        Me.RdioPapPrnt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RdioPapPrnt.Location = New System.Drawing.Point(233, 19)
        Me.RdioPapPrnt.Name = "RdioPapPrnt"
        Me.RdioPapPrnt.Size = New System.Drawing.Size(105, 26)
        Me.RdioPapPrnt.TabIndex = 2136
        Me.RdioPapPrnt.TabStop = True
        Me.RdioPapPrnt.Text = "مطبوعة فقط"
        Me.RdioPapPrnt.UseVisualStyleBackColor = True
        '
        'HeldPaprNtfPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 681)
        Me.Controls.Add(Me.RdioPaperAll)
        Me.Controls.Add(Me.RdioPapNoPrnt)
        Me.Controls.Add(Me.RdioPapPrnt)
        Me.Controls.Add(Me.GridPHHeld)
        Me.Controls.Add(Me.LblLoad)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.BtnPrv)
        Me.Controls.Add(Me.LblMsg)
        Me.Name = "HeldPaprNtfPrint"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طباعة الإخطارات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridPHHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridPHHeld As DataGridView
    Friend WithEvents LblMsg As Label
    Friend WithEvents BtnPrv As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LblLoad As Label
    Friend WithEvents RdioPaperAll As RadioButton
    Friend WithEvents RdioPapNoPrnt As RadioButton
    Friend WithEvents RdioPapPrnt As RadioButton
End Class
