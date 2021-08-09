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
        Me.BtnBckComp = New System.Windows.Forms.Button()
        Me.BtnBrws = New System.Windows.Forms.Button()
        Me.BtnEsc = New System.Windows.Forms.Button()
        Me.FlowUpdt = New System.Windows.Forms.FlowLayoutPanel()
        Me.GridUpdt = New System.Windows.Forms.DataGridView()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.CmbEvent = New System.Windows.Forms.ComboBox()
        Me.TxtUpdt = New System.Windows.Forms.TextBox()
        Me.TxtBrws = New System.Windows.Forms.TextBox()
        Me.BtnSubmt = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdiocls = New System.Windows.Forms.RadioButton()
        Me.RdioOpen = New System.Windows.Forms.RadioButton()
        Me.RdioAll = New System.Windows.Forms.RadioButton()
        Me.PrdKComb = New System.Windows.Forms.ComboBox()
        Me.FilterComb = New System.Windows.Forms.ComboBox()
        Me.SerchTxt = New System.Windows.Forms.TextBox()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.GridTicket = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblWdays2 = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.TimerEscOpen = New System.Windows.Forms.Timer(Me.components)
        Me.TimerVisInvs = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.FlowUpdt.SuspendLayout()
        CType(Me.GridUpdt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BtnBckComp
        '
        Me.BtnBckComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBckComp.BackColor = System.Drawing.Color.Transparent
        Me.BtnBckComp.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back
        Me.BtnBckComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBckComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FlowUpdt.SetFlowBreak(Me.BtnBckComp, True)
        Me.BtnBckComp.Location = New System.Drawing.Point(198, 165)
        Me.BtnBckComp.Name = "BtnBckComp"
        Me.BtnBckComp.Size = New System.Drawing.Size(63, 59)
        Me.BtnBckComp.TabIndex = 2053
        Me.ToolTip1.SetToolTip(Me.BtnBckComp, "العودة لتفاصيل الشكوى")
        Me.BtnBckComp.UseVisualStyleBackColor = False
        '
        'BtnBrws
        '
        Me.BtnBrws.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrws.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.browse_button_png_th
        Me.BtnBrws.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrws.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBrws.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBrws.Location = New System.Drawing.Point(201, 396)
        Me.BtnBrws.Name = "BtnBrws"
        Me.BtnBrws.Size = New System.Drawing.Size(60, 27)
        Me.BtnBrws.TabIndex = 2158
        Me.ToolTip1.SetToolTip(Me.BtnBrws, "Browse")
        Me.BtnBrws.UseVisualStyleBackColor = True
        '
        'BtnEsc
        '
        Me.BtnEsc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsc.BackColor = System.Drawing.Color.Transparent
        Me.BtnEsc.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.escalate1
        Me.BtnEsc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEsc.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnEsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEsc.Location = New System.Drawing.Point(92, 461)
        Me.BtnEsc.Name = "BtnEsc"
        Me.BtnEsc.Size = New System.Drawing.Size(71, 71)
        Me.BtnEsc.TabIndex = 2060
        Me.ToolTip1.SetToolTip(Me.BtnEsc, "متابعه")
        Me.BtnEsc.UseVisualStyleBackColor = False
        Me.BtnEsc.Visible = False
        '
        'FlowUpdt
        '
        Me.FlowUpdt.Controls.Add(Me.GridUpdt)
        Me.FlowUpdt.Controls.Add(Me.BtnBckComp)
        Me.FlowUpdt.Controls.Add(Me.Label60)
        Me.FlowUpdt.Controls.Add(Me.CmbEvent)
        Me.FlowUpdt.Controls.Add(Me.TxtUpdt)
        Me.FlowUpdt.Controls.Add(Me.BtnBrws)
        Me.FlowUpdt.Controls.Add(Me.TxtBrws)
        Me.FlowUpdt.Controls.Add(Me.BtnSubmt)
        Me.FlowUpdt.Controls.Add(Me.BtnEsc)
        Me.FlowUpdt.Controls.Add(Me.Button1)
        Me.FlowUpdt.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowUpdt.Location = New System.Drawing.Point(223, 255)
        Me.FlowUpdt.Name = "FlowUpdt"
        Me.FlowUpdt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowUpdt.Size = New System.Drawing.Size(264, 126)
        Me.FlowUpdt.TabIndex = 2162
        Me.FlowUpdt.Visible = False
        '
        'GridUpdt
        '
        Me.GridUpdt.AllowUserToAddRows = False
        Me.GridUpdt.AllowUserToDeleteRows = False
        Me.GridUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUpdt.BackgroundColor = System.Drawing.Color.White
        Me.GridUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUpdt.Location = New System.Drawing.Point(47, 3)
        Me.GridUpdt.MultiSelect = False
        Me.GridUpdt.Name = "GridUpdt"
        Me.GridUpdt.ReadOnly = True
        Me.GridUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridUpdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridUpdt.Size = New System.Drawing.Size(214, 156)
        Me.GridUpdt.TabIndex = 2057
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label60.Location = New System.Drawing.Point(164, 227)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(97, 23)
        Me.Label60.TabIndex = 2055
        Me.Label60.Text = "إضافة تحديث:"
        '
        'CmbEvent
        '
        Me.CmbEvent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEvent.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CmbEvent.FormattingEnabled = True
        Me.CmbEvent.Location = New System.Drawing.Point(97, 253)
        Me.CmbEvent.Name = "CmbEvent"
        Me.CmbEvent.Size = New System.Drawing.Size(164, 27)
        Me.CmbEvent.TabIndex = 2056
        '
        'TxtUpdt
        '
        Me.TxtUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUpdt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtUpdt.Location = New System.Drawing.Point(-453, 286)
        Me.TxtUpdt.Multiline = True
        Me.TxtUpdt.Name = "TxtUpdt"
        Me.TxtUpdt.ReadOnly = True
        Me.TxtUpdt.Size = New System.Drawing.Size(714, 104)
        Me.TxtUpdt.TabIndex = 2054
        '
        'TxtBrws
        '
        Me.TxtBrws.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtBrws.Location = New System.Drawing.Point(7, 429)
        Me.TxtBrws.Name = "TxtBrws"
        Me.TxtBrws.ReadOnly = True
        Me.TxtBrws.Size = New System.Drawing.Size(254, 26)
        Me.TxtBrws.TabIndex = 2159
        '
        'BtnSubmt
        '
        Me.BtnSubmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSubmt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSubmt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmt.Location = New System.Drawing.Point(169, 461)
        Me.BtnSubmt.Name = "BtnSubmt"
        Me.BtnSubmt.Size = New System.Drawing.Size(92, 40)
        Me.BtnSubmt.TabIndex = 2059
        Me.BtnSubmt.Text = "تسجيل"
        Me.BtnSubmt.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 461)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2063
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(1024, 11)
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
        Me.GroupBox2.Location = New System.Drawing.Point(768, 11)
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
        'PrdKComb
        '
        Me.PrdKComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrdKComb.FormattingEnabled = True
        Me.PrdKComb.Location = New System.Drawing.Point(579, 20)
        Me.PrdKComb.Name = "PrdKComb"
        Me.PrdKComb.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PrdKComb.Size = New System.Drawing.Size(111, 21)
        Me.PrdKComb.TabIndex = 8
        '
        'FilterComb
        '
        Me.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComb.FormattingEnabled = True
        Me.FilterComb.Location = New System.Drawing.Point(320, 20)
        Me.FilterComb.Name = "FilterComb"
        Me.FilterComb.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FilterComb.Size = New System.Drawing.Size(187, 21)
        Me.FilterComb.TabIndex = 6
        '
        'SerchTxt
        '
        Me.SerchTxt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SerchTxt.Location = New System.Drawing.Point(127, 16)
        Me.SerchTxt.Name = "SerchTxt"
        Me.SerchTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SerchTxt.Size = New System.Drawing.Size(187, 26)
        Me.SerchTxt.TabIndex = 0
        Me.SerchTxt.Text = "برجاء ادخال كلمات البحث"
        Me.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSerch
        '
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recblue
        Me.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.Location = New System.Drawing.Point(8, 11)
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
        Me.GridTicket.Location = New System.Drawing.Point(2, 64)
        Me.GridTicket.MultiSelect = False
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.ReadOnly = True
        Me.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridTicket.Size = New System.Drawing.Size(1277, 108)
        Me.GridTicket.TabIndex = 20
        '
        'LblMsg
        '
        Me.LblMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblMsg.Location = New System.Drawing.Point(0, 432)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(1283, 33)
        Me.LblMsg.TabIndex = 2058
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblWdays2
        '
        Me.LblWdays2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWdays2.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblWdays2.Location = New System.Drawing.Point(597, 278)
        Me.LblWdays2.Name = "LblWdays2"
        Me.LblWdays2.Size = New System.Drawing.Size(334, 70)
        Me.LblWdays2.TabIndex = 2164
        Me.LblWdays2.Text = "Label3"
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
        Me.CloseBtn.Location = New System.Drawing.Point(1199, 393)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(57, 36)
        Me.CloseBtn.TabIndex = 2024
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'TimerEscOpen
        '
        Me.TimerEscOpen.Interval = 1000
        '
        'TimerVisInvs
        '
        Me.TimerVisInvs.Interval = 500
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(514, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 2166
        Me.Label2.Text = "نوع البحث :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(696, 25)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(66, 13)
        Me.Label32.TabIndex = 2165
        Me.Label32.Text = "نوع الخدمة : "
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TikSearchNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1283, 465)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridTicket)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SerchTxt)
        Me.Controls.Add(Me.LblWdays2)
        Me.Controls.Add(Me.FlowUpdt)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.BtnSerch)
        Me.Controls.Add(Me.FilterComb)
        Me.Controls.Add(Me.PrdKComb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(0, 52)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TikSearchNew"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث الشكاوى والاستفسارات"
        Me.FlowUpdt.ResumeLayout(False)
        Me.FlowUpdt.PerformLayout()
        CType(Me.GridUpdt, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PrdKComb As ComboBox
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
    Friend WithEvents TimerEscOpen As Timer
    Friend WithEvents TimerVisInvs As Timer
    Friend WithEvents FlowUpdt As FlowLayoutPanel
    Friend WithEvents GridUpdt As DataGridView
    Friend WithEvents BtnBckComp As Button
    Friend WithEvents Label60 As Label
    Friend WithEvents CmbEvent As ComboBox
    Friend WithEvents TxtUpdt As TextBox
    Friend WithEvents BtnBrws As Button
    Friend WithEvents TxtBrws As TextBox
    Friend WithEvents BtnSubmt As Button
    Friend WithEvents BtnEsc As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents LblWdays2 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label32 As Label
End Class
