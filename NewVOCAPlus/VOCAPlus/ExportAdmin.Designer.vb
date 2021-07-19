<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExportAdmin
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
        Me.DataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.CombComp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdiocls = New System.Windows.Forms.RadioButton()
        Me.RdioOpen = New System.Windows.Forms.RadioButton()
        Me.RdioTikAll = New System.Windows.Forms.RadioButton()
        Me.PrdKComb = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RdioFlwN = New System.Windows.Forms.RadioButton()
        Me.RdioFlwY = New System.Windows.Forms.RadioButton()
        Me.RdioFlwAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RdioReopnN = New System.Windows.Forms.RadioButton()
        Me.RdioReopnY = New System.Windows.Forms.RadioButton()
        Me.RdioReopnAll = New System.Windows.Forms.RadioButton()
        Me.CombProd = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnExprt = New System.Windows.Forms.Button()
        Me.ChckBxDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnPrv = New System.Windows.Forms.Button()
        Me.LblStat = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataSet1BindingSource
        '
        Me.DataSet1BindingSource.DataMember = "DataSet1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 612)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel3})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1184, 29)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 2132
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 984
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusBarPanel3.Name = "StatusBarPanel3"
        Me.StatusBarPanel3.Width = 200
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(216, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 21)
        Me.Label2.TabIndex = 2130
        Me.Label2.Text = "إلى :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(458, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 21)
        Me.Label1.TabIndex = 2129
        Me.Label1.Text = "من :"
        '
        'DateTimeTo
        '
        Me.DateTimeTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimeTo.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.DateTimeTo.Location = New System.Drawing.Point(14, 17)
        Me.DateTimeTo.Name = "DateTimeTo"
        Me.DateTimeTo.RightToLeftLayout = True
        Me.DateTimeTo.Size = New System.Drawing.Size(196, 29)
        Me.DateTimeTo.TabIndex = 2128
        Me.DateTimeTo.Value = New Date(2020, 4, 22, 0, 0, 0, 0)
        '
        'DateTimeFrom
        '
        Me.DateTimeFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimeFrom.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.DateTimeFrom.Location = New System.Drawing.Point(262, 17)
        Me.DateTimeFrom.Name = "DateTimeFrom"
        Me.DateTimeFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimeFrom.RightToLeftLayout = True
        Me.DateTimeFrom.Size = New System.Drawing.Size(196, 29)
        Me.DateTimeFrom.TabIndex = 2127
        Me.DateTimeFrom.Value = New Date(2020, 4, 22, 0, 0, 0, 0)
        '
        'CombComp
        '
        Me.CombComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CombComp.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CombComp.FormattingEnabled = True
        Me.CombComp.Location = New System.Drawing.Point(822, 430)
        Me.CombComp.Name = "CombComp"
        Me.CombComp.Size = New System.Drawing.Size(307, 29)
        Me.CombComp.TabIndex = 2133
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label3.Location = New System.Drawing.Point(724, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 2131
        Me.Label3.Text = "نوع الشكوى :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label32.Location = New System.Drawing.Point(86, 432)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 23)
        Me.Label32.TabIndex = 2141
        Me.Label32.Text = "نوع الخدمة :"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Rdiocls)
        Me.GroupBox2.Controls.Add(Me.RdioOpen)
        Me.GroupBox2.Controls.Add(Me.RdioTikAll)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(188, 469)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 49)
        Me.GroupBox2.TabIndex = 2140
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "حالة الشكوى"
        '
        'Rdiocls
        '
        Me.Rdiocls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdiocls.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.Rdiocls.Cursor = System.Windows.Forms.Cursors.Default
        Me.Rdiocls.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Rdiocls.Location = New System.Drawing.Point(89, 20)
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
        Me.RdioOpen.Location = New System.Drawing.Point(160, 20)
        Me.RdioOpen.Name = "RdioOpen"
        Me.RdioOpen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioOpen.Size = New System.Drawing.Size(75, 22)
        Me.RdioOpen.TabIndex = 503
        Me.RdioOpen.Text = "مفتوحة"
        Me.RdioOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioOpen.UseVisualStyleBackColor = True
        '
        'RdioTikAll
        '
        Me.RdioTikAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioTikAll.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioTikAll.Checked = True
        Me.RdioTikAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioTikAll.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioTikAll.Location = New System.Drawing.Point(18, 20)
        Me.RdioTikAll.Name = "RdioTikAll"
        Me.RdioTikAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioTikAll.Size = New System.Drawing.Size(65, 22)
        Me.RdioTikAll.TabIndex = 505
        Me.RdioTikAll.TabStop = True
        Me.RdioTikAll.Text = "الكل"
        Me.RdioTikAll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioTikAll.UseVisualStyleBackColor = True
        '
        'PrdKComb
        '
        Me.PrdKComb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrdKComb.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.PrdKComb.FormattingEnabled = True
        Me.PrdKComb.Location = New System.Drawing.Point(180, 430)
        Me.PrdKComb.Name = "PrdKComb"
        Me.PrdKComb.Size = New System.Drawing.Size(126, 29)
        Me.PrdKComb.TabIndex = 2138
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.RdioFlwN)
        Me.GroupBox3.Controls.Add(Me.RdioFlwY)
        Me.GroupBox3.Controls.Add(Me.RdioFlwAll)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(455, 469)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 49)
        Me.GroupBox3.TabIndex = 2141
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "حالة المتابعة"
        '
        'RdioFlwN
        '
        Me.RdioFlwN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioFlwN.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioFlwN.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioFlwN.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioFlwN.Location = New System.Drawing.Point(89, 20)
        Me.RdioFlwN.Name = "RdioFlwN"
        Me.RdioFlwN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioFlwN.Size = New System.Drawing.Size(65, 22)
        Me.RdioFlwN.TabIndex = 504
        Me.RdioFlwN.Text = "لا"
        Me.RdioFlwN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioFlwN.UseVisualStyleBackColor = True
        '
        'RdioFlwY
        '
        Me.RdioFlwY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioFlwY.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioFlwY.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioFlwY.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioFlwY.Location = New System.Drawing.Point(160, 20)
        Me.RdioFlwY.Name = "RdioFlwY"
        Me.RdioFlwY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioFlwY.Size = New System.Drawing.Size(75, 22)
        Me.RdioFlwY.TabIndex = 503
        Me.RdioFlwY.Text = "نعم"
        Me.RdioFlwY.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioFlwY.UseVisualStyleBackColor = True
        '
        'RdioFlwAll
        '
        Me.RdioFlwAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioFlwAll.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioFlwAll.Checked = True
        Me.RdioFlwAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioFlwAll.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioFlwAll.Location = New System.Drawing.Point(18, 20)
        Me.RdioFlwAll.Name = "RdioFlwAll"
        Me.RdioFlwAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioFlwAll.Size = New System.Drawing.Size(65, 22)
        Me.RdioFlwAll.TabIndex = 505
        Me.RdioFlwAll.TabStop = True
        Me.RdioFlwAll.Text = "الكل"
        Me.RdioFlwAll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioFlwAll.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.RdioReopnN)
        Me.GroupBox4.Controls.Add(Me.RdioReopnY)
        Me.GroupBox4.Controls.Add(Me.RdioReopnAll)
        Me.GroupBox4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(720, 469)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 49)
        Me.GroupBox4.TabIndex = 2142
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "معادة الفتح"
        '
        'RdioReopnN
        '
        Me.RdioReopnN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioReopnN.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioReopnN.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioReopnN.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioReopnN.Location = New System.Drawing.Point(89, 20)
        Me.RdioReopnN.Name = "RdioReopnN"
        Me.RdioReopnN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioReopnN.Size = New System.Drawing.Size(65, 22)
        Me.RdioReopnN.TabIndex = 504
        Me.RdioReopnN.Text = "لا"
        Me.RdioReopnN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioReopnN.UseVisualStyleBackColor = True
        '
        'RdioReopnY
        '
        Me.RdioReopnY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioReopnY.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioReopnY.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioReopnY.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioReopnY.Location = New System.Drawing.Point(160, 20)
        Me.RdioReopnY.Name = "RdioReopnY"
        Me.RdioReopnY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioReopnY.Size = New System.Drawing.Size(75, 22)
        Me.RdioReopnY.TabIndex = 503
        Me.RdioReopnY.Text = "نعم"
        Me.RdioReopnY.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioReopnY.UseVisualStyleBackColor = True
        '
        'RdioReopnAll
        '
        Me.RdioReopnAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdioReopnAll.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RdioReopnAll.Checked = True
        Me.RdioReopnAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.RdioReopnAll.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RdioReopnAll.Location = New System.Drawing.Point(18, 20)
        Me.RdioReopnAll.Name = "RdioReopnAll"
        Me.RdioReopnAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdioReopnAll.Size = New System.Drawing.Size(65, 22)
        Me.RdioReopnAll.TabIndex = 505
        Me.RdioReopnAll.TabStop = True
        Me.RdioReopnAll.Text = "الكل"
        Me.RdioReopnAll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RdioReopnAll.UseVisualStyleBackColor = True
        '
        'CombProd
        '
        Me.CombProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CombProd.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CombProd.FormattingEnabled = True
        Me.CombProd.Location = New System.Drawing.Point(398, 430)
        Me.CombProd.Name = "CombProd"
        Me.CombProd.Size = New System.Drawing.Size(307, 29)
        Me.CombProd.TabIndex = 2144
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label4.Location = New System.Drawing.Point(308, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 21)
        Me.Label4.TabIndex = 2143
        Me.Label4.Text = "اسم المنتج :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnExprt
        '
        Me.BtnExprt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExprt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Export1
        Me.BtnExprt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExprt.Location = New System.Drawing.Point(1082, 519)
        Me.BtnExprt.Name = "BtnExprt"
        Me.BtnExprt.Size = New System.Drawing.Size(71, 67)
        Me.BtnExprt.TabIndex = 2145
        Me.BtnExprt.UseVisualStyleBackColor = True
        Me.BtnExprt.Visible = False
        '
        'ChckBxDate
        '
        Me.ChckBxDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChckBxDate.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckBxDate.AutoSize = True
        Me.ChckBxDate.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.ChckBxDate.Location = New System.Drawing.Point(556, 381)
        Me.ChckBxDate.Name = "ChckBxDate"
        Me.ChckBxDate.Size = New System.Drawing.Size(149, 31)
        Me.ChckBxDate.TabIndex = 2146
        Me.ChckBxDate.Text = "تجاهل تاريخ التسجيل"
        Me.ChckBxDate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimeFrom)
        Me.GroupBox1.Controls.Add(Me.DateTimeTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 367)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(502, 52)
        Me.GroupBox1.TabIndex = 2147
        Me.GroupBox1.TabStop = False
        '
        'BtnPrv
        '
        Me.BtnPrv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrv.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Preview
        Me.BtnPrv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrv.Location = New System.Drawing.Point(963, 529)
        Me.BtnPrv.Name = "BtnPrv"
        Me.BtnPrv.Size = New System.Drawing.Size(113, 47)
        Me.BtnPrv.TabIndex = 2148
        Me.BtnPrv.UseVisualStyleBackColor = True
        '
        'LblStat
        '
        Me.LblStat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStat.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblStat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStat.Location = New System.Drawing.Point(42, 348)
        Me.LblStat.Name = "LblStat"
        Me.LblStat.Size = New System.Drawing.Size(584, 24)
        Me.LblStat.TabIndex = 2149
        Me.LblStat.Text = "اختيار اسماء الحقول وجعلها باللون الأخضر يجعلها تظهر بنفس الترتيب  في ملف الاكسيل" &
    ""
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(280, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(584, 24)
        Me.Label5.TabIndex = 2150
        Me.Label5.Text = "شاشه تجريبية لإستخراج البيانات حسب صلاحية المستخدم"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(455, 529)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(397, 23)
        Me.ProgressBar1.TabIndex = 2151
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(515, 555)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(235, 54)
        Me.Label6.TabIndex = 2152
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 25.0!)
        Me.Label7.Location = New System.Drawing.Point(34, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(209, 123)
        Me.Label7.TabIndex = 2153
        Me.Label7.Text = "يرجى الإنتظار حتى إنتهاء التحميل"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ExportAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1184, 641)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnPrv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChckBxDate)
        Me.Controls.Add(Me.BtnExprt)
        Me.Controls.Add(Me.CombProd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PrdKComb)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CombComp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblStat)
        Me.MaximumSize = New System.Drawing.Size(1200, 680)
        Me.MinimumSize = New System.Drawing.Size(1200, 680)
        Me.Name = "ExportAdmin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "استخراج بيانات الشكاوى"
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatusBarPanel1 As StatusBarPanel
    Friend WithEvents StatusBarPanel3 As StatusBarPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimeTo As DateTimePicker
    Friend WithEvents DateTimeFrom As DateTimePicker
    Friend WithEvents CombComp As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Rdiocls As RadioButton
    Friend WithEvents RdioOpen As RadioButton
    Friend WithEvents RdioTikAll As RadioButton
    Friend WithEvents PrdKComb As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RdioFlwN As RadioButton
    Friend WithEvents RdioFlwY As RadioButton
    Friend WithEvents RdioFlwAll As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents RdioReopnN As RadioButton
    Friend WithEvents RdioReopnY As RadioButton
    Friend WithEvents RdioReopnAll As RadioButton
    Friend WithEvents CombProd As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnExprt As Button
    Friend WithEvents ChckBxDate As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnPrv As Button
    Friend WithEvents LblStat As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataSet1BindingSource As BindingSource
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
