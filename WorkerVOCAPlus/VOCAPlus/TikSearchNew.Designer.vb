<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TikSearchNew
    Inherits System.Windows.Forms.Form

    'Form Overrides dispose to clean up the component list.
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdiocls = New System.Windows.Forms.RadioButton()
        Me.RdioOpen = New System.Windows.Forms.RadioButton()
        Me.RdioAll = New System.Windows.Forms.RadioButton()
        Me.FilterComb = New System.Windows.Forms.ComboBox()
        Me.SerchTxt = New System.Windows.Forms.TextBox()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.GridTicket = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtnCncl = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(915, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 38)
        Me.GroupBox1.TabIndex = 2020
        Me.GroupBox1.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton3.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadioButton3.Location = New System.Drawing.Point(20, 11)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton3.Size = New System.Drawing.Size(65, 22)
        Me.RadioButton3.TabIndex = 502
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "الكل"
        Me.RadioButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(162, 11)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton1.Size = New System.Drawing.Size(75, 22)
        Me.RadioButton1.TabIndex = 500
        Me.RadioButton1.Text = "استفسار"
        Me.RadioButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(89, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton2.Size = New System.Drawing.Size(65, 22)
        Me.RadioButton2.TabIndex = 501
        Me.RadioButton2.Text = "شكوى"
        Me.RadioButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Rdiocls)
        Me.GroupBox2.Controls.Add(Me.RdioOpen)
        Me.GroupBox2.Controls.Add(Me.RdioAll)
        Me.GroupBox2.Location = New System.Drawing.Point(663, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 38)
        Me.GroupBox2.TabIndex = 2021
        Me.GroupBox2.TabStop = False
        '
        'Rdiocls
        '
        Me.Rdiocls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdiocls.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.Rdiocls.Cursor = System.Windows.Forms.Cursors.Default
        Me.Rdiocls.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Rdiocls.Location = New System.Drawing.Point(89, 13)
        Me.Rdiocls.Name = "Rdiocls"
        Me.Rdiocls.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Rdiocls.Size = New System.Drawing.Size(65, 22)
        Me.Rdiocls.TabIndex = 504
        Me.Rdiocls.Text = "مغلقة"
        Me.Rdiocls.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Rdiocls.UseVisualStyleBackColor = True
        '
        'RdioOpen
        '
        Me.RdioOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioOpen.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioOpen.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioOpen.Location = New System.Drawing.Point(160, 13)
        Me.RdioOpen.Name = "RdioOpen"
        Me.RdioOpen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioOpen.Size = New System.Drawing.Size(75, 22)
        Me.RdioOpen.TabIndex = 503
        Me.RdioOpen.Text = "مفتوحة"
        Me.RdioOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioOpen.UseVisualStyleBackColor = True
        '
        'RdioAll
        '
        Me.RdioAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioAll.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioAll.Checked = True
        Me.RdioAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioAll.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioAll.Location = New System.Drawing.Point(18, 13)
        Me.RdioAll.Name = "RdioAll"
        Me.RdioAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioAll.Size = New System.Drawing.Size(65, 22)
        Me.RdioAll.TabIndex = 505
        Me.RdioAll.TabStop = True
        Me.RdioAll.Text = "الكل"
        Me.RdioAll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioAll.UseVisualStyleBackColor = True
        '
        'FilterComb
        '
        Me.FilterComb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComb.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.FilterComb.FormattingEnabled = True
        Me.FilterComb.Location = New System.Drawing.Point(399, 19)
        Me.FilterComb.Name = "FilterComb"
        Me.FilterComb.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FilterComb.Size = New System.Drawing.Size(187, 27)
        Me.FilterComb.TabIndex = 6
        '
        'SerchTxt
        '
        Me.SerchTxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SerchTxt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SerchTxt.Location = New System.Drawing.Point(210, 20)
        Me.SerchTxt.Name = "SerchTxt"
        Me.SerchTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SerchTxt.Size = New System.Drawing.Size(187, 26)
        Me.SerchTxt.TabIndex = 0
        Me.SerchTxt.Text = "برجاء ادخال كلمات البحث"
        Me.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSerch
        '
        Me.BtnSerch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recblue
        Me.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnSerch.Location = New System.Drawing.Point(91, 15)
        Me.BtnSerch.Name = "BtnSerch"
        Me.BtnSerch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSerch.Size = New System.Drawing.Size(113, 34)
        Me.BtnSerch.TabIndex = 1
        Me.BtnSerch.Text = "بحث"
        Me.BtnSerch.UseVisualStyleBackColor = True
        '
        'GridTicket
        '
        Me.GridTicket.AllowUserToAddRows = False
        Me.GridTicket.AllowUserToDeleteRows = False
        Me.GridTicket.BackgroundColor = System.Drawing.Color.White
        Me.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTicket.Location = New System.Drawing.Point(6, 84)
        Me.GridTicket.MultiSelect = False
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.ReadOnly = True
        Me.GridTicket.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridTicket.Size = New System.Drawing.Size(1159, 108)
        Me.GridTicket.TabIndex = 20
        '
        'LblMsg
        '
        Me.LblMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblMsg.Location = New System.Drawing.Point(0, 432)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblMsg.Size = New System.Drawing.Size(1177, 33)
        Me.LblMsg.TabIndex = 2058
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
        Me.CloseBtn.Location = New System.Drawing.Point(15, 413)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(57, 36)
        Me.CloseBtn.TabIndex = 2024
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(584, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 2166
        Me.Label2.Text = "نوع البحث :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 52)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(306, 20)
        Me.ProgressBar1.TabIndex = 2167
        Me.ProgressBar1.Visible = False
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        Me.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCncl.FlatAppearance.BorderSize = 0
        Me.BtnCncl.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnCncl.Location = New System.Drawing.Point(6, 14)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCncl.Size = New System.Drawing.Size(69, 34)
        Me.BtnCncl.TabIndex = 2168
        Me.BtnCncl.Text = "Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'TikSearchNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1177, 465)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridTicket)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SerchTxt)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSerch)
        Me.Controls.Add(Me.FilterComb)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(0, 52)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TikSearchNew"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث الشكاوى والاستفسارات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GridTicket As DataGridView
    Friend WithEvents FilterComb As ComboBox
    Friend WithEvents SerchTxt As TextBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RdioAll As RadioButton
    Friend WithEvents Rdiocls As RadioButton
    Friend WithEvents RdioOpen As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblMsg As Label
    Friend WithEvents BtnSerch As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BtnCncl As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
