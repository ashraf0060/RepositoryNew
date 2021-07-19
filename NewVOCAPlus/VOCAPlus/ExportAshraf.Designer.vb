<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExportAshraf
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rooting")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportAshraf))
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rooting")
        Me.DataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdiocls = New System.Windows.Forms.RadioButton()
        Me.RdioOpen = New System.Windows.Forms.RadioButton()
        Me.RdioTikAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RdioFlwN = New System.Windows.Forms.RadioButton()
        Me.RdioFlwY = New System.Windows.Forms.RadioButton()
        Me.RdioFlwAll = New System.Windows.Forms.RadioButton()
        Me.ChckBxDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnPrv = New System.Windows.Forms.Button()
        Me.LblStat = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.RsetTree = New System.Windows.Forms.Button()
        Me.GrpDtKnd = New System.Windows.Forms.GroupBox()
        Me.Radtrans = New System.Windows.Forms.RadioButton()
        Me.RadTrnsf = New System.Windows.Forms.RadioButton()
        Me.RadRcv = New System.Windows.Forms.RadioButton()
        Me.RadClos = New System.Windows.Forms.RadioButton()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.RstUer = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpDtKnd.SuspendLayout()
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
        Me.StatusBar1.Size = New System.Drawing.Size(1325, 29)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 2132
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 1125
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Rdiocls)
        Me.GroupBox2.Controls.Add(Me.RdioOpen)
        Me.GroupBox2.Controls.Add(Me.RdioTikAll)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 537)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 45)
        Me.GroupBox2.TabIndex = 2140
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "حالة الشكوى"
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
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.RdioFlwN)
        Me.GroupBox3.Controls.Add(Me.RdioFlwY)
        Me.GroupBox3.Controls.Add(Me.RdioFlwAll)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(279, 537)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 45)
        Me.GroupBox3.TabIndex = 2141
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "حالة المتابعة"
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
        'ChckBxDate
        '
        Me.ChckBxDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChckBxDate.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckBxDate.AutoSize = True
        Me.ChckBxDate.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.ChckBxDate.Location = New System.Drawing.Point(324, 495)
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(502, 58)
        Me.GroupBox1.TabIndex = 2147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "التاريخ"
        '
        'BtnPrv
        '
        Me.BtnPrv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrv.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Preview
        Me.BtnPrv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrv.Location = New System.Drawing.Point(535, 547)
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
        Me.LblStat.Location = New System.Drawing.Point(3, 399)
        Me.LblStat.Name = "LblStat"
        Me.LblStat.Size = New System.Drawing.Size(507, 24)
        Me.LblStat.TabIndex = 2149
        Me.LblStat.Text = "اختيار اسماء الحقول وجعلها باللون الأخضر يجعلها تظهر بنفس الترتيب  في ملف الاكسيل" &
    ""
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TreeView1.ImageKey = "Add.ico"
        Me.TreeView1.Location = New System.Drawing.Point(935, 41)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode1.ForeColor = System.Drawing.Color.Red
        TreeNode1.Name = "Rooting"
        TreeNode1.Text = "Rooting"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(318, 499)
        Me.TreeView1.TabIndex = 2154
        Me.TreeView1.Tag = "نوع الشكوى"
        '
        'ImgLst
        '
        Me.ImgLst.ImageStream = CType(resources.GetObject("ImgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLst.Images.SetKeyName(0, "Arrow - Right (5).ico")
        Me.ImgLst.Images.SetKeyName(1, "Arrow - Right (4).ico")
        Me.ImgLst.Images.SetKeyName(2, "arrow-right-3.png")
        Me.ImgLst.Images.SetKeyName(3, "arrow-right-double-3.png")
        '
        'RsetTree
        '
        Me.RsetTree.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.RsetTree.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RsetTree.Location = New System.Drawing.Point(989, 1)
        Me.RsetTree.Name = "RsetTree"
        Me.RsetTree.Size = New System.Drawing.Size(93, 34)
        Me.RsetTree.TabIndex = 2155
        Me.RsetTree.Text = "Reset Tree"
        Me.RsetTree.UseVisualStyleBackColor = True
        '
        'GrpDtKnd
        '
        Me.GrpDtKnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDtKnd.Controls.Add(Me.Radtrans)
        Me.GrpDtKnd.Controls.Add(Me.RadTrnsf)
        Me.GrpDtKnd.Controls.Add(Me.RadRcv)
        Me.GrpDtKnd.Controls.Add(Me.RadClos)
        Me.GrpDtKnd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.GrpDtKnd.Location = New System.Drawing.Point(7, 485)
        Me.GrpDtKnd.Name = "GrpDtKnd"
        Me.GrpDtKnd.Size = New System.Drawing.Size(311, 49)
        Me.GrpDtKnd.TabIndex = 2142
        Me.GrpDtKnd.TabStop = False
        Me.GrpDtKnd.Tag = "نوع التاريخ"
        Me.GrpDtKnd.Text = "نوع التاريخ"
        '
        'Radtrans
        '
        Me.Radtrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Radtrans.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.Radtrans.Cursor = System.Windows.Forms.Cursors.Default
        Me.Radtrans.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Radtrans.Location = New System.Drawing.Point(6, 19)
        Me.Radtrans.Name = "Radtrans"
        Me.Radtrans.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radtrans.Size = New System.Drawing.Size(76, 22)
        Me.Radtrans.TabIndex = 506
        Me.Radtrans.Text = "العملية"
        Me.Radtrans.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Radtrans.UseVisualStyleBackColor = True
        '
        'RadTrnsf
        '
        Me.RadTrnsf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadTrnsf.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadTrnsf.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadTrnsf.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadTrnsf.Location = New System.Drawing.Point(157, 20)
        Me.RadTrnsf.Name = "RadTrnsf"
        Me.RadTrnsf.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadTrnsf.Size = New System.Drawing.Size(68, 22)
        Me.RadTrnsf.TabIndex = 504
        Me.RadTrnsf.Text = "تحويل"
        Me.RadTrnsf.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadTrnsf.UseVisualStyleBackColor = True
        '
        'RadRcv
        '
        Me.RadRcv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadRcv.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadRcv.Checked = True
        Me.RadRcv.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadRcv.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadRcv.Location = New System.Drawing.Point(231, 20)
        Me.RadRcv.Name = "RadRcv"
        Me.RadRcv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadRcv.Size = New System.Drawing.Size(75, 22)
        Me.RadRcv.TabIndex = 503
        Me.RadRcv.TabStop = True
        Me.RadRcv.Text = "تسجيل"
        Me.RadRcv.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadRcv.UseVisualStyleBackColor = True
        '
        'RadClos
        '
        Me.RadClos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadClos.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadClos.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadClos.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.RadClos.Location = New System.Drawing.Point(88, 20)
        Me.RadClos.Name = "RadClos"
        Me.RadClos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadClos.Size = New System.Drawing.Size(65, 22)
        Me.RadClos.TabIndex = 505
        Me.RadClos.Text = "إغلاق"
        Me.RadClos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadClos.UseVisualStyleBackColor = True
        '
        'UserTree
        '
        Me.UserTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserTree.CheckBoxes = True
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UserTree.ImageKey = "Add.ico"
        Me.UserTree.Location = New System.Drawing.Point(572, 42)
        Me.UserTree.Name = "UserTree"
        TreeNode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode2.ForeColor = System.Drawing.Color.Red
        TreeNode2.Name = "Rooting"
        TreeNode2.Text = "Rooting"
        Me.UserTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.UserTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowNodeToolTips = True
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(360, 499)
        Me.UserTree.TabIndex = 2156
        Me.UserTree.Tag = "نوع الشكوى"
        '
        'RstUer
        '
        Me.RstUer.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.RstUer.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RstUer.Location = New System.Drawing.Point(708, 6)
        Me.RstUer.Name = "RstUer"
        Me.RstUer.Size = New System.Drawing.Size(93, 34)
        Me.RstUer.TabIndex = 2157
        Me.RstUer.Text = "Reset Tree"
        Me.RstUer.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(22, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(521, 384)
        Me.FlowLayoutPanel1.TabIndex = 2158
        '
        'ExportAshraf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1325, 641)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.RstUer)
        Me.Controls.Add(Me.UserTree)
        Me.Controls.Add(Me.GrpDtKnd)
        Me.Controls.Add(Me.RsetTree)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.BtnPrv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChckBxDate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.LblStat)
        Me.MinimumSize = New System.Drawing.Size(1200, 680)
        Me.Name = "ExportAshraf"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "استخراج بيانات الشكاوى"
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GrpDtKnd.ResumeLayout(False)
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Rdiocls As RadioButton
    Friend WithEvents RdioOpen As RadioButton
    Friend WithEvents RdioTikAll As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RdioFlwN As RadioButton
    Friend WithEvents RdioFlwY As RadioButton
    Friend WithEvents RdioFlwAll As RadioButton
    Friend WithEvents ChckBxDate As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnPrv As Button
    Friend WithEvents LblStat As Label
    Friend WithEvents DataSet1BindingSource As BindingSource
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents RsetTree As Button
    Friend WithEvents GrpDtKnd As GroupBox
    Friend WithEvents RadTrnsf As RadioButton
    Friend WithEvents RadRcv As RadioButton
    Friend WithEvents RadClos As RadioButton
    Friend WithEvents Radtrans As RadioButton
    Friend WithEvents UserTree As TreeView
    Friend WithEvents RstUer As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
