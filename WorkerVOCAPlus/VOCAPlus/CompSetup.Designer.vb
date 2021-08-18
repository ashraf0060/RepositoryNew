<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CompSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompSetup))
        Me.BtSubmit = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ChckBxGB = New System.Windows.Forms.CheckBox()
        Me.ChckBxNm = New System.Windows.Forms.CheckBox()
        Me.ChckBxPh1 = New System.Windows.Forms.CheckBox()
        Me.ChckBxPh2 = New System.Windows.Forms.CheckBox()
        Me.ChckBxOff = New System.Windows.Forms.CheckBox()
        Me.ChckBxDt = New System.Windows.Forms.CheckBox()
        Me.ChckBxSrc = New System.Windows.Forms.CheckBox()
        Me.ChckBxAmnt = New System.Windows.Forms.CheckBox()
        Me.ChckBxTrck = New System.Windows.Forms.CheckBox()
        Me.ChckBxID = New System.Windows.Forms.CheckBox()
        Me.ChckBxDist = New System.Windows.Forms.CheckBox()
        Me.ChckBxCrd = New System.Windows.Forms.CheckBox()
        Me.MendGrp = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBxRef = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.TxtFnMngr = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadSusp = New System.Windows.Forms.RadioButton()
        Me.RadActv = New System.Windows.Forms.RadioButton()
        Me.TreeProd = New System.Windows.Forms.TreeView()
        Me.RadActvs = New System.Windows.Forms.RadioButton()
        Me.RadSusps = New System.Windows.Forms.RadioButton()
        Me.RadAlls = New System.Windows.Forms.RadioButton()
        Me.LblTrCnt = New System.Windows.Forms.Label()
        Me.TreeComp = New System.Windows.Forms.TreeView()
        Me.RadAl = New System.Windows.Forms.RadioButton()
        Me.RadSsp = New System.Windows.Forms.RadioButton()
        Me.RadAcv = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.MendGrp.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtSubmit
        '
        Me.BtSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSubmit.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtSubmit.FlatAppearance.BorderSize = 0
        Me.BtSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSubmit.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSubmit.Location = New System.Drawing.Point(951, 650)
        Me.BtSubmit.Name = "BtSubmit"
        Me.BtSubmit.Size = New System.Drawing.Size(102, 43)
        Me.BtSubmit.TabIndex = 5
        Me.BtSubmit.Text = "تسجيل"
        Me.BtSubmit.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ImageKey = "Add.ico"
        Me.TreeView1.Location = New System.Drawing.Point(12, 28)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode1.ForeColor = System.Drawing.Color.Red
        TreeNode1.Name = "Rooting"
        TreeNode1.Text = "Rooting"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(400, 572)
        Me.TreeView1.TabIndex = 49
        Me.TreeView1.Tag = "نوع الخدمة & نوع الشكوى"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripitem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(155, 26)
        '
        'CopyToolStripitem
        '
        Me.CopyToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CopyToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.delete1
        Me.CopyToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopyToolStripitem.Name = "CopyToolStripitem"
        Me.CopyToolStripitem.RightToLeftAutoMirrorImage = True
        Me.CopyToolStripitem.Size = New System.Drawing.Size(154, 22)
        Me.CopyToolStripitem.Text = "Delete Selected"
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
        'ChckBxGB
        '
        Me.ChckBxGB.AutoSize = True
        Me.ChckBxGB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxGB.Location = New System.Drawing.Point(57, 268)
        Me.ChckBxGB.Name = "ChckBxGB"
        Me.ChckBxGB.Size = New System.Drawing.Size(92, 23)
        Me.ChckBxGB.TabIndex = 8
        Me.ChckBxGB.Text = "رقم أمر الدفع"
        Me.ChckBxGB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxGB.UseVisualStyleBackColor = True
        '
        'ChckBxNm
        '
        Me.ChckBxNm.AutoSize = True
        Me.ChckBxNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxNm.Location = New System.Drawing.Point(57, 65)
        Me.ChckBxNm.Name = "ChckBxNm"
        Me.ChckBxNm.Size = New System.Drawing.Size(79, 23)
        Me.ChckBxNm.TabIndex = 1
        Me.ChckBxNm.Text = "اسم العميل"
        Me.ChckBxNm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxNm.UseVisualStyleBackColor = True
        '
        'ChckBxPh1
        '
        Me.ChckBxPh1.AutoSize = True
        Me.ChckBxPh1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxPh1.Location = New System.Drawing.Point(57, 36)
        Me.ChckBxPh1.Name = "ChckBxPh1"
        Me.ChckBxPh1.Size = New System.Drawing.Size(104, 23)
        Me.ChckBxPh1.TabIndex = 0
        Me.ChckBxPh1.Text = "تليفون العميل 1"
        Me.ChckBxPh1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxPh1.UseVisualStyleBackColor = True
        '
        'ChckBxPh2
        '
        Me.ChckBxPh2.AutoSize = True
        Me.ChckBxPh2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxPh2.Location = New System.Drawing.Point(57, 94)
        Me.ChckBxPh2.Name = "ChckBxPh2"
        Me.ChckBxPh2.Size = New System.Drawing.Size(104, 23)
        Me.ChckBxPh2.TabIndex = 2
        Me.ChckBxPh2.Text = "تليفون العميل 2"
        Me.ChckBxPh2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxPh2.UseVisualStyleBackColor = True
        '
        'ChckBxOff
        '
        Me.ChckBxOff.AutoSize = True
        Me.ChckBxOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxOff.Location = New System.Drawing.Point(57, 123)
        Me.ChckBxOff.Name = "ChckBxOff"
        Me.ChckBxOff.Size = New System.Drawing.Size(82, 23)
        Me.ChckBxOff.TabIndex = 3
        Me.ChckBxOff.Text = "اسم المكتب"
        Me.ChckBxOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxOff.UseVisualStyleBackColor = True
        '
        'ChckBxDt
        '
        Me.ChckBxDt.AutoSize = True
        Me.ChckBxDt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxDt.Location = New System.Drawing.Point(57, 355)
        Me.ChckBxDt.Name = "ChckBxDt"
        Me.ChckBxDt.Size = New System.Drawing.Size(91, 23)
        Me.ChckBxDt.TabIndex = 11
        Me.ChckBxDt.Text = "تاريخ العملية"
        Me.ChckBxDt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxDt.UseVisualStyleBackColor = True
        '
        'ChckBxSrc
        '
        Me.ChckBxSrc.AutoSize = True
        Me.ChckBxSrc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxSrc.Location = New System.Drawing.Point(57, 152)
        Me.ChckBxSrc.Name = "ChckBxSrc"
        Me.ChckBxSrc.Size = New System.Drawing.Size(103, 23)
        Me.ChckBxSrc.TabIndex = 4
        Me.ChckBxSrc.Text = "مصدر الشكوى"
        Me.ChckBxSrc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxSrc.UseVisualStyleBackColor = True
        '
        'ChckBxAmnt
        '
        Me.ChckBxAmnt.AutoSize = True
        Me.ChckBxAmnt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxAmnt.Location = New System.Drawing.Point(57, 326)
        Me.ChckBxAmnt.Name = "ChckBxAmnt"
        Me.ChckBxAmnt.Size = New System.Drawing.Size(83, 23)
        Me.ChckBxAmnt.TabIndex = 10
        Me.ChckBxAmnt.Text = "مبلغ العملية"
        Me.ChckBxAmnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxAmnt.UseVisualStyleBackColor = True
        '
        'ChckBxTrck
        '
        Me.ChckBxTrck.AutoSize = True
        Me.ChckBxTrck.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxTrck.Location = New System.Drawing.Point(57, 181)
        Me.ChckBxTrck.Name = "ChckBxTrck"
        Me.ChckBxTrck.Size = New System.Drawing.Size(82, 23)
        Me.ChckBxTrck.TabIndex = 5
        Me.ChckBxTrck.Text = "رقم الشحنة"
        Me.ChckBxTrck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxTrck.UseVisualStyleBackColor = True
        '
        'ChckBxID
        '
        Me.ChckBxID.AutoSize = True
        Me.ChckBxID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxID.Location = New System.Drawing.Point(57, 297)
        Me.ChckBxID.Name = "ChckBxID"
        Me.ChckBxID.Size = New System.Drawing.Size(87, 23)
        Me.ChckBxID.TabIndex = 9
        Me.ChckBxID.Text = "الرقم القومي"
        Me.ChckBxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxID.UseVisualStyleBackColor = True
        '
        'ChckBxDist
        '
        Me.ChckBxDist.AutoSize = True
        Me.ChckBxDist.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxDist.Location = New System.Drawing.Point(57, 210)
        Me.ChckBxDist.Name = "ChckBxDist"
        Me.ChckBxDist.Size = New System.Drawing.Size(101, 23)
        Me.ChckBxDist.TabIndex = 6
        Me.ChckBxDist.Text = "بلد المرسل إلية"
        Me.ChckBxDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxDist.UseVisualStyleBackColor = True
        '
        'ChckBxCrd
        '
        Me.ChckBxCrd.AutoSize = True
        Me.ChckBxCrd.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxCrd.Location = New System.Drawing.Point(57, 239)
        Me.ChckBxCrd.Name = "ChckBxCrd"
        Me.ChckBxCrd.Size = New System.Drawing.Size(84, 23)
        Me.ChckBxCrd.TabIndex = 7
        Me.ChckBxCrd.Text = "رقم الكارت"
        Me.ChckBxCrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckBxCrd.UseVisualStyleBackColor = True
        '
        'MendGrp
        '
        Me.MendGrp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MendGrp.BackColor = System.Drawing.Color.White
        Me.MendGrp.Controls.Add(Me.ChckBxNm)
        Me.MendGrp.Controls.Add(Me.ChckBxGB)
        Me.MendGrp.Controls.Add(Me.ChckBxTrck)
        Me.MendGrp.Controls.Add(Me.ChckBxID)
        Me.MendGrp.Controls.Add(Me.ChckBxAmnt)
        Me.MendGrp.Controls.Add(Me.ChckBxDist)
        Me.MendGrp.Controls.Add(Me.ChckBxPh1)
        Me.MendGrp.Controls.Add(Me.ChckBxSrc)
        Me.MendGrp.Controls.Add(Me.ChckBxCrd)
        Me.MendGrp.Controls.Add(Me.ChckBxPh2)
        Me.MendGrp.Controls.Add(Me.ChckBxDt)
        Me.MendGrp.Controls.Add(Me.ChckBxOff)
        Me.MendGrp.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MendGrp.Location = New System.Drawing.Point(625, 51)
        Me.MendGrp.Name = "MendGrp"
        Me.MendGrp.Size = New System.Drawing.Size(267, 413)
        Me.MendGrp.TabIndex = 63
        Me.MendGrp.TabStop = False
        Me.MendGrp.Text = "الحقول الإلزامية"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(644, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 23)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "اختار نوع شكوى لإظهار أسماء الحقول"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtBxRef
        '
        Me.TxtBxRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxRef.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.TxtBxRef.Location = New System.Drawing.Point(438, 132)
        Me.TxtBxRef.MaxLength = 8
        Me.TxtBxRef.Name = "TxtBxRef"
        Me.TxtBxRef.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBxRef.Size = New System.Drawing.Size(107, 30)
        Me.TxtBxRef.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 29)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "إلزامية"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LimeGreen
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 35)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "إلزامية "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 35)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "غير إلزامية"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.LightGray
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(434, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "الكود التعريفي للمنتج"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(218, 26)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "حقول قابلة للتعديل:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(218, 26)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "حقول غير قابلة للتعديل:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CloseBtn.Location = New System.Drawing.Point(1146, 652)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(106, 39)
        Me.CloseBtn.TabIndex = 87
        Me.CloseBtn.Text = "خروج"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'TxtFnMngr
        '
        Me.TxtFnMngr.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.TxtFnMngr.Location = New System.Drawing.Point(10, 217)
        Me.TxtFnMngr.MaxLength = 8
        Me.TxtFnMngr.Name = "TxtFnMngr"
        Me.TxtFnMngr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtFnMngr.Size = New System.Drawing.Size(107, 30)
        Me.TxtFnMngr.TabIndex = 88
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.LightGray
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(68, 249)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 20)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "اسم المجموعة"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Viner Hand ITC", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(672, 593)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(445, 23)
        Me.Label7.TabIndex = 72
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(34, 272)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(185, 29)
        Me.ComboBox1.TabIndex = 97
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.RadSusp)
        Me.GroupBox1.Controls.Add(Me.RadActv)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtFnMngr)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(985, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 413)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        '
        'RadSusp
        '
        Me.RadSusp.AutoSize = True
        Me.RadSusp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadSusp.ForeColor = System.Drawing.Color.Red
        Me.RadSusp.Location = New System.Drawing.Point(65, 326)
        Me.RadSusp.Name = "RadSusp"
        Me.RadSusp.Size = New System.Drawing.Size(65, 23)
        Me.RadSusp.TabIndex = 99
        Me.RadSusp.TabStop = True
        Me.RadSusp.Text = "موقوفة"
        Me.RadSusp.UseVisualStyleBackColor = True
        '
        'RadActv
        '
        Me.RadActv.AutoSize = True
        Me.RadActv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadActv.ForeColor = System.Drawing.Color.Green
        Me.RadActv.Location = New System.Drawing.Point(135, 326)
        Me.RadActv.Name = "RadActv"
        Me.RadActv.Size = New System.Drawing.Size(51, 23)
        Me.RadActv.TabIndex = 98
        Me.RadActv.TabStop = True
        Me.RadActv.Text = "تعمل"
        Me.RadActv.UseVisualStyleBackColor = True
        '
        'TreeProd
        '
        Me.TreeProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeProd.Location = New System.Drawing.Point(999, 48)
        Me.TreeProd.Name = "TreeProd"
        Me.TreeProd.RightToLeftLayout = True
        Me.TreeProd.Size = New System.Drawing.Size(130, 398)
        Me.TreeProd.TabIndex = 104
        '
        'RadActvs
        '
        Me.RadActvs.AutoSize = True
        Me.RadActvs.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadActvs.ForeColor = System.Drawing.Color.Green
        Me.RadActvs.Location = New System.Drawing.Point(439, 28)
        Me.RadActvs.Name = "RadActvs"
        Me.RadActvs.Size = New System.Drawing.Size(111, 23)
        Me.RadActvs.TabIndex = 100
        Me.RadActvs.TabStop = True
        Me.RadActvs.Text = "الشكاوى الحالية"
        Me.RadActvs.UseVisualStyleBackColor = True
        '
        'RadSusps
        '
        Me.RadSusps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadSusps.AutoSize = True
        Me.RadSusps.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadSusps.ForeColor = System.Drawing.Color.Red
        Me.RadSusps.Location = New System.Drawing.Point(438, 51)
        Me.RadSusps.Name = "RadSusps"
        Me.RadSusps.Size = New System.Drawing.Size(122, 23)
        Me.RadSusps.TabIndex = 101
        Me.RadSusps.TabStop = True
        Me.RadSusps.Text = "الشكاوى الموقوفة"
        Me.RadSusps.UseVisualStyleBackColor = True
        '
        'RadAlls
        '
        Me.RadAlls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadAlls.AutoSize = True
        Me.RadAlls.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadAlls.Location = New System.Drawing.Point(438, 74)
        Me.RadAlls.Name = "RadAlls"
        Me.RadAlls.Size = New System.Drawing.Size(48, 23)
        Me.RadAlls.TabIndex = 102
        Me.RadAlls.TabStop = True
        Me.RadAlls.Text = "الكل"
        Me.RadAlls.UseVisualStyleBackColor = True
        '
        'LblTrCnt
        '
        Me.LblTrCnt.AutoSize = True
        Me.LblTrCnt.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblTrCnt.Location = New System.Drawing.Point(172, 12)
        Me.LblTrCnt.Name = "LblTrCnt"
        Me.LblTrCnt.Size = New System.Drawing.Size(60, 21)
        Me.LblTrCnt.TabIndex = 103
        Me.LblTrCnt.Text = "Label1"
        '
        'TreeComp
        '
        Me.TreeComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeComp.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.TreeComp.Location = New System.Drawing.Point(563, 42)
        Me.TreeComp.Name = "TreeComp"
        Me.TreeComp.RightToLeftLayout = True
        Me.TreeComp.Size = New System.Drawing.Size(571, 451)
        Me.TreeComp.TabIndex = 105
        '
        'RadAl
        '
        Me.RadAl.AutoSize = True
        Me.RadAl.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadAl.Location = New System.Drawing.Point(159, 13)
        Me.RadAl.Name = "RadAl"
        Me.RadAl.Size = New System.Drawing.Size(48, 23)
        Me.RadAl.TabIndex = 108
        Me.RadAl.TabStop = True
        Me.RadAl.Text = "الكل"
        Me.RadAl.UseVisualStyleBackColor = True
        '
        'RadSsp
        '
        Me.RadSsp.AutoSize = True
        Me.RadSsp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadSsp.ForeColor = System.Drawing.Color.Red
        Me.RadSsp.Location = New System.Drawing.Point(215, 13)
        Me.RadSsp.Name = "RadSsp"
        Me.RadSsp.Size = New System.Drawing.Size(122, 23)
        Me.RadSsp.TabIndex = 107
        Me.RadSsp.TabStop = True
        Me.RadSsp.Text = "الشكاوى الموقوفة"
        Me.RadSsp.UseVisualStyleBackColor = True
        '
        'RadAcv
        '
        Me.RadAcv.AutoSize = True
        Me.RadAcv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RadAcv.ForeColor = System.Drawing.Color.Green
        Me.RadAcv.Location = New System.Drawing.Point(343, 13)
        Me.RadAcv.Name = "RadAcv"
        Me.RadAcv.Size = New System.Drawing.Size(111, 23)
        Me.RadAcv.TabIndex = 106
        Me.RadAcv.TabStop = True
        Me.RadAcv.Text = "الشكاوى الحالية"
        Me.RadAcv.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.RadAl)
        Me.GroupBox2.Controls.Add(Me.RadAcv)
        Me.GroupBox2.Controls.Add(Me.RadSsp)
        Me.GroupBox2.Location = New System.Drawing.Point(556, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 40)
        Me.GroupBox2.TabIndex = 109
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(470, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LblHelp
        '
        Me.LblHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHelp.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblHelp.ForeColor = System.Drawing.Color.Green
        Me.LblHelp.Location = New System.Drawing.Point(418, 496)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(834, 153)
        Me.LblHelp.TabIndex = 2037
        Me.LblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CompSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 703)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TreeComp)
        Me.Controls.Add(Me.LblTrCnt)
        Me.Controls.Add(Me.RadAlls)
        Me.Controls.Add(Me.RadSusps)
        Me.Controls.Add(Me.RadActvs)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtBxRef)
        Me.Controls.Add(Me.MendGrp)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.BtSubmit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TreeProd)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CompSetup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ضبط الحقول الإلزامية"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.MendGrp.ResumeLayout(False)
        Me.MendGrp.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtSubmit As Button
    Friend WithEvents ChckBxPh1 As CheckBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents ChckBxNm As CheckBox
    Friend WithEvents ChckBxPh2 As CheckBox
    Friend WithEvents ChckBxOff As CheckBox
    Friend WithEvents ChckBxSrc As CheckBox
    Friend WithEvents ChckBxTrck As CheckBox
    Friend WithEvents ChckBxDist As CheckBox
    Friend WithEvents ChckBxCrd As CheckBox
    Friend WithEvents ChckBxGB As CheckBox
    Friend WithEvents ChckBxID As CheckBox
    Friend WithEvents ChckBxAmnt As CheckBox
    Friend WithEvents ChckBxDt As CheckBox
    Friend WithEvents MendGrp As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBxRef As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CloseBtn As Button
    Friend WithEvents TxtFnMngr As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadActvs As RadioButton
    Friend WithEvents RadSusps As RadioButton
    Friend WithEvents RadAlls As RadioButton
    Friend WithEvents LblTrCnt As Label
    Friend WithEvents RadSusp As RadioButton
    Friend WithEvents RadActv As RadioButton
    Friend WithEvents TreeProd As TreeView
    Friend WithEvents TreeComp As TreeView
    Friend WithEvents RadAl As RadioButton
    Friend WithEvents RadSsp As RadioButton
    Friend WithEvents RadAcv As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyToolStripitem As ToolStripMenuItem
    Friend WithEvents LblHelp As Label
End Class
