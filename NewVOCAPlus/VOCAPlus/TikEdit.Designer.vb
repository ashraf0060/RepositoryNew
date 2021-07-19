<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TikEdit
    Inherits System.Windows.Forms.Form

    'Form Overrides dispose to clean up the component list.
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rooting")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TikEdit))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.TxtFolw = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtTransDt = New System.Windows.Forms.TextBox()
        Me.TxtCard = New System.Windows.Forms.MaskedTextBox()
        Me.TxtNId = New System.Windows.Forms.TextBox()
        Me.TxtAmount = New System.Windows.Forms.TextBox()
        Me.TxtGP = New System.Windows.Forms.TextBox()
        Me.TxtSrc = New System.Windows.Forms.TextBox()
        Me.TxtOff = New System.Windows.Forms.TextBox()
        Me.TxtArea = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtComp = New System.Windows.Forms.TextBox()
        Me.TxtProd = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtDetails = New System.Windows.Forms.TextBox()
        Me.TxtPh2 = New System.Windows.Forms.TextBox()
        Me.TxtDt = New System.Windows.Forms.TextBox()
        Me.TxtNm = New System.Windows.Forms.TextBox()
        Me.TxtPh1 = New System.Windows.Forms.TextBox()
        Me.TxtAdd = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtTrck = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TxtDist = New System.Windows.Forms.TextBox()
        Me.TxtOrgin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTikID = New System.Windows.Forms.TextBox()
        Me.BtnGet = New System.Windows.Forms.Button()
        Me.SubmitBtn = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.ChckReAssign = New System.Windows.Forms.CheckBox()
        Me.LblText = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ImageKey = "Add.ico"
        Me.TreeView1.Location = New System.Drawing.Point(745, 24)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode1.ForeColor = System.Drawing.Color.Red
        TreeNode1.Name = "Rooting"
        TreeNode1.Text = "Rooting"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(417, 597)
        Me.TreeView1.TabIndex = 49
        Me.TreeView1.Tag = "نوع الخدمة & نوع الشكوى"
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
        Me.CloseBtn.Location = New System.Drawing.Point(12, 540)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(106, 39)
        Me.CloseBtn.TabIndex = 2025
        Me.CloseBtn.Text = "خروج"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'TxtFolw
        '
        Me.TxtFolw.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFolw.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtFolw.Location = New System.Drawing.Point(94, 284)
        Me.TxtFolw.Name = "TxtFolw"
        Me.TxtFolw.ReadOnly = True
        Me.TxtFolw.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFolw.Size = New System.Drawing.Size(229, 26)
        Me.TxtFolw.TabIndex = 2138
        Me.TxtFolw.Tag = "نوع الشكوى"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(329, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2137
        Me.Label1.Text = "متابع الشكوى :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.Label42)
        Me.GroupBox3.Controls.Add(Me.TxtTransDt)
        Me.GroupBox3.Controls.Add(Me.TxtCard)
        Me.GroupBox3.Controls.Add(Me.TxtNId)
        Me.GroupBox3.Controls.Add(Me.TxtAmount)
        Me.GroupBox3.Controls.Add(Me.TxtGP)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(248, 432)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 160)
        Me.GroupBox3.TabIndex = 2111
        Me.GroupBox3.TabStop = False
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label33.Location = New System.Drawing.Point(292, 21)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 1008
        Me.Label33.Text = "رقم الكارت/الحساب :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label35.Location = New System.Drawing.Point(292, 71)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(103, 16)
        Me.Label35.TabIndex = 1010
        Me.Label35.Text = "الرقم القومي :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label38.Location = New System.Drawing.Point(292, 99)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 16)
        Me.Label38.TabIndex = 32
        Me.Label38.Text = "مبلغ العملية :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label40.Location = New System.Drawing.Point(292, 128)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 16)
        Me.Label40.TabIndex = 34
        Me.Label40.Text = "تاريخ العملية :"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label42.Location = New System.Drawing.Point(292, 47)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(103, 16)
        Me.Label42.TabIndex = 1009
        Me.Label42.Text = "رقم أمر الدفع :"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtTransDt
        '
        Me.TxtTransDt.Location = New System.Drawing.Point(36, 125)
        Me.TxtTransDt.MaxLength = 16
        Me.TxtTransDt.Name = "TxtTransDt"
        Me.TxtTransDt.ReadOnly = True
        Me.TxtTransDt.Size = New System.Drawing.Size(250, 23)
        Me.TxtTransDt.TabIndex = 1011
        Me.TxtTransDt.Tag = "مبلغ العملية"
        '
        'TxtCard
        '
        Me.TxtCard.Location = New System.Drawing.Point(36, 18)
        Me.TxtCard.Mask = "0000000000000000"
        Me.TxtCard.Name = "TxtCard"
        Me.TxtCard.ReadOnly = True
        Me.TxtCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtCard.Size = New System.Drawing.Size(250, 23)
        Me.TxtCard.TabIndex = 7
        Me.TxtCard.Tag = "رقم الكارت"
        '
        'TxtNId
        '
        Me.TxtNId.Location = New System.Drawing.Point(36, 69)
        Me.TxtNId.MaxLength = 14
        Me.TxtNId.Name = "TxtNId"
        Me.TxtNId.ReadOnly = True
        Me.TxtNId.Size = New System.Drawing.Size(250, 23)
        Me.TxtNId.TabIndex = 9
        Me.TxtNId.Tag = "الرقم القومي"
        Me.TxtNId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAmount
        '
        Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAmount.Location = New System.Drawing.Point(36, 97)
        Me.TxtAmount.MaxLength = 16
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(250, 23)
        Me.TxtAmount.TabIndex = 10
        Me.TxtAmount.Tag = "مبلغ العملية"
        '
        'TxtGP
        '
        Me.TxtGP.Location = New System.Drawing.Point(36, 43)
        Me.TxtGP.MaxLength = 16
        Me.TxtGP.Name = "TxtGP"
        Me.TxtGP.ReadOnly = True
        Me.TxtGP.Size = New System.Drawing.Size(250, 23)
        Me.TxtGP.TabIndex = 8
        Me.TxtGP.Tag = "رقم أمر الدفع"
        Me.TxtGP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSrc
        '
        Me.TxtSrc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSrc.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtSrc.Location = New System.Drawing.Point(94, 252)
        Me.TxtSrc.Name = "TxtSrc"
        Me.TxtSrc.ReadOnly = True
        Me.TxtSrc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSrc.Size = New System.Drawing.Size(229, 26)
        Me.TxtSrc.TabIndex = 2136
        Me.TxtSrc.Tag = "نوع الشكوى"
        '
        'TxtOff
        '
        Me.TxtOff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOff.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtOff.Location = New System.Drawing.Point(94, 155)
        Me.TxtOff.Name = "TxtOff"
        Me.TxtOff.ReadOnly = True
        Me.TxtOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOff.Size = New System.Drawing.Size(229, 26)
        Me.TxtOff.TabIndex = 2135
        Me.TxtOff.TabStop = False
        Me.TxtOff.Tag = "Email Address"
        '
        'TxtArea
        '
        Me.TxtArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtArea.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtArea.Location = New System.Drawing.Point(94, 123)
        Me.TxtArea.Name = "TxtArea"
        Me.TxtArea.ReadOnly = True
        Me.TxtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtArea.Size = New System.Drawing.Size(229, 26)
        Me.TxtArea.TabIndex = 2134
        Me.TxtArea.TabStop = False
        Me.TxtArea.Tag = "Email Address"
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(666, 126)
        Me.Label41.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label41.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label41.Size = New System.Drawing.Size(100, 20)
        Me.Label41.TabIndex = 2133
        Me.Label41.Text = "تليفون2 :"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(666, 88)
        Me.Label37.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label37.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label37.Size = New System.Drawing.Size(100, 20)
        Me.Label37.TabIndex = 2132
        Me.Label37.Text = "تليفون1 :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(666, 156)
        Me.Label34.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label34.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label34.Size = New System.Drawing.Size(100, 20)
        Me.Label34.TabIndex = 2119
        Me.Label34.Text = "التاريخ :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(666, 185)
        Me.Label36.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label36.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label36.Size = New System.Drawing.Size(100, 17)
        Me.Label36.TabIndex = 2129
        Me.Label36.Text = "اسم العميل :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(666, 219)
        Me.Label39.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label39.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label39.Size = New System.Drawing.Size(100, 17)
        Me.Label39.TabIndex = 2120
        Me.Label39.Text = "العنوان :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtComp
        '
        Me.TxtComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtComp.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtComp.Location = New System.Drawing.Point(94, 219)
        Me.TxtComp.Name = "TxtComp"
        Me.TxtComp.ReadOnly = True
        Me.TxtComp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtComp.Size = New System.Drawing.Size(229, 26)
        Me.TxtComp.TabIndex = 2128
        Me.TxtComp.Tag = "نوع الشكوى"
        '
        'TxtProd
        '
        Me.TxtProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtProd.Location = New System.Drawing.Point(94, 187)
        Me.TxtProd.Name = "TxtProd"
        Me.TxtProd.ReadOnly = True
        Me.TxtProd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtProd.Size = New System.Drawing.Size(229, 26)
        Me.TxtProd.TabIndex = 2127
        Me.TxtProd.Tag = "اسم الخدمة"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(670, 314)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 34)
        Me.Label43.TabIndex = 2126
        Me.Label43.Text = "التفاصيل :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDetails
        '
        Me.TxtDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDetails.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtDetails.Location = New System.Drawing.Point(94, 314)
        Me.TxtDetails.Multiline = True
        Me.TxtDetails.Name = "TxtDetails"
        Me.TxtDetails.ReadOnly = True
        Me.TxtDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDetails.Size = New System.Drawing.Size(570, 112)
        Me.TxtDetails.TabIndex = 2125
        Me.TxtDetails.TabStop = False
        Me.TxtDetails.Tag = "Details"
        '
        'TxtPh2
        '
        Me.TxtPh2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtPh2.Location = New System.Drawing.Point(435, 125)
        Me.TxtPh2.Name = "TxtPh2"
        Me.TxtPh2.ReadOnly = True
        Me.TxtPh2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh2.Size = New System.Drawing.Size(229, 26)
        Me.TxtPh2.TabIndex = 2115
        Me.TxtPh2.Tag = "تليفون العميل 2"
        '
        'TxtDt
        '
        Me.TxtDt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtDt.Location = New System.Drawing.Point(435, 159)
        Me.TxtDt.Name = "TxtDt"
        Me.TxtDt.ReadOnly = True
        Me.TxtDt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDt.Size = New System.Drawing.Size(229, 26)
        Me.TxtDt.TabIndex = 2118
        Me.TxtDt.TabStop = False
        Me.TxtDt.Tag = "Date"
        '
        'TxtNm
        '
        Me.TxtNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtNm.Location = New System.Drawing.Point(435, 188)
        Me.TxtNm.Name = "TxtNm"
        Me.TxtNm.ReadOnly = True
        Me.TxtNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNm.Size = New System.Drawing.Size(229, 26)
        Me.TxtNm.TabIndex = 2114
        Me.TxtNm.TabStop = False
        Me.TxtNm.Tag = "اسم العميل"
        '
        'TxtPh1
        '
        Me.TxtPh1.AccessibleDescription = ""
        Me.TxtPh1.AccessibleName = ""
        Me.TxtPh1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtPh1.Location = New System.Drawing.Point(435, 87)
        Me.TxtPh1.Name = "TxtPh1"
        Me.TxtPh1.ReadOnly = True
        Me.TxtPh1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh1.Size = New System.Drawing.Size(229, 26)
        Me.TxtPh1.TabIndex = 2113
        Me.TxtPh1.Tag = "تليفون العميل 1"
        '
        'TxtAdd
        '
        Me.TxtAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtAdd.Location = New System.Drawing.Point(435, 220)
        Me.TxtAdd.Multiline = True
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.ReadOnly = True
        Me.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdd.Size = New System.Drawing.Size(229, 85)
        Me.TxtAdd.TabIndex = 2116
        Me.TxtAdd.Tag = "Address"
        '
        'Label50
        '
        Me.Label50.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label50.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Blue
        Me.Label50.Location = New System.Drawing.Point(329, 89)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label50.Size = New System.Drawing.Size(100, 20)
        Me.Label50.TabIndex = 2124
        Me.Label50.Text = "البريد الإلكتروني :"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Blue
        Me.Label51.Location = New System.Drawing.Point(329, 190)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label51.Size = New System.Drawing.Size(100, 20)
        Me.Label51.TabIndex = 2121
        Me.Label51.Text = "نوع الخدمة :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtEmail
        '
        Me.TxtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmail.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtEmail.Location = New System.Drawing.Point(94, 90)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.ReadOnly = True
        Me.TxtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtEmail.Size = New System.Drawing.Size(229, 26)
        Me.TxtEmail.TabIndex = 2117
        Me.TxtEmail.TabStop = False
        Me.TxtEmail.Tag = "Email Address"
        '
        'Label52
        '
        Me.Label52.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label52.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Blue
        Me.Label52.Location = New System.Drawing.Point(329, 221)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label52.Size = New System.Drawing.Size(100, 20)
        Me.Label52.TabIndex = 2122
        Me.Label52.Text = "نوع الشكوى :"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label53
        '
        Me.Label53.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label53.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Blue
        Me.Label53.Location = New System.Drawing.Point(329, 253)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label53.Size = New System.Drawing.Size(100, 20)
        Me.Label53.TabIndex = 2131
        Me.Label53.Text = "مصدر الشكوى :"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label54
        '
        Me.Label54.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label54.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Blue
        Me.Label54.Location = New System.Drawing.Point(329, 156)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label54.Size = New System.Drawing.Size(100, 20)
        Me.Label54.TabIndex = 2130
        Me.Label54.Text = "اسم المكتب :"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label55
        '
        Me.Label55.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label55.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Blue
        Me.Label55.Location = New System.Drawing.Point(329, 126)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label55.Size = New System.Drawing.Size(100, 20)
        Me.Label55.TabIndex = 2123
        Me.Label55.Text = "المنطقة البريدية :"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtTrck)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.TxtDist)
        Me.GroupBox4.Controls.Add(Me.TxtOrgin)
        Me.GroupBox4.Location = New System.Drawing.Point(248, 432)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(416, 160)
        Me.GroupBox4.TabIndex = 2112
        Me.GroupBox4.TabStop = False
        '
        'TxtTrck
        '
        Me.TxtTrck.Location = New System.Drawing.Point(42, 21)
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.ReadOnly = True
        Me.TxtTrck.Size = New System.Drawing.Size(250, 20)
        Me.TxtTrck.TabIndex = 1010
        Me.TxtTrck.TabStop = False
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label45.Location = New System.Drawing.Point(298, 46)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(103, 16)
        Me.Label45.TabIndex = 29
        Me.Label45.Text = "بلد الراسل :"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label46.Location = New System.Drawing.Point(298, 73)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(103, 16)
        Me.Label46.TabIndex = 1007
        Me.Label46.Text = "بلد المرسل إلية :"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label47.Location = New System.Drawing.Point(298, 24)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(103, 16)
        Me.Label47.TabIndex = 1006
        Me.Label47.Text = "رقم الشحنة :"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDist
        '
        Me.TxtDist.Location = New System.Drawing.Point(42, 75)
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.ReadOnly = True
        Me.TxtDist.Size = New System.Drawing.Size(250, 20)
        Me.TxtDist.TabIndex = 1008
        Me.TxtDist.TabStop = False
        '
        'TxtOrgin
        '
        Me.TxtOrgin.Location = New System.Drawing.Point(42, 48)
        Me.TxtOrgin.Name = "TxtOrgin"
        Me.TxtOrgin.ReadOnly = True
        Me.TxtOrgin.Size = New System.Drawing.Size(250, 20)
        Me.TxtOrgin.TabIndex = 35
        Me.TxtOrgin.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(460, 24)
        Me.Label2.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label2.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 2140
        Me.Label2.Text = "رقم الشكوى :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtTikID
        '
        Me.TxtTikID.AccessibleDescription = ""
        Me.TxtTikID.AccessibleName = ""
        Me.TxtTikID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTikID.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtTikID.Location = New System.Drawing.Point(351, 22)
        Me.TxtTikID.Name = "TxtTikID"
        Me.TxtTikID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTikID.Size = New System.Drawing.Size(107, 26)
        Me.TxtTikID.TabIndex = 0
        Me.TxtTikID.Tag = "تليفون العميل 1"
        '
        'BtnGet
        '
        Me.BtnGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGet.BackColor = System.Drawing.Color.White
        Me.BtnGet.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.DbGet
        Me.BtnGet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnGet.FlatAppearance.BorderSize = 0
        Me.BtnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGet.Font = New System.Drawing.Font("Times New Roman", 1.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGet.ForeColor = System.Drawing.Color.Transparent
        Me.BtnGet.Location = New System.Drawing.Point(280, 6)
        Me.BtnGet.Name = "BtnGet"
        Me.BtnGet.Size = New System.Drawing.Size(50, 50)
        Me.BtnGet.TabIndex = 2141
        Me.BtnGet.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtnGet.UseVisualStyleBackColor = False
        '
        'SubmitBtn
        '
        Me.SubmitBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SubmitBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.SaveFl
        Me.SubmitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SubmitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.SubmitBtn.FlatAppearance.BorderSize = 0
        Me.SubmitBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SubmitBtn.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubmitBtn.Location = New System.Drawing.Point(160, 450)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(64, 64)
        Me.SubmitBtn.TabIndex = 2142
        Me.SubmitBtn.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblMsg.Location = New System.Drawing.Point(142, 583)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(526, 23)
        Me.lblMsg.TabIndex = 2143
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChckReAssign
        '
        Me.ChckReAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChckReAssign.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckReAssign.AutoSize = True
        Me.ChckReAssign.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.ChckReAssign.Location = New System.Drawing.Point(566, 24)
        Me.ChckReAssign.Name = "ChckReAssign"
        Me.ChckReAssign.Size = New System.Drawing.Size(131, 29)
        Me.ChckReAssign.TabIndex = 2144
        Me.ChckReAssign.Text = "تحويل للفريق المختص"
        Me.ChckReAssign.UseVisualStyleBackColor = True
        '
        'LblText
        '
        Me.LblText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblText.ForeColor = System.Drawing.Color.Green
        Me.LblText.Location = New System.Drawing.Point(74, 61)
        Me.LblText.Name = "LblText"
        Me.LblText.Size = New System.Drawing.Size(626, 23)
        Me.LblText.TabIndex = 2145
        Me.LblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TikEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1174, 609)
        Me.Controls.Add(Me.LblText)
        Me.Controls.Add(Me.ChckReAssign)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.SubmitBtn)
        Me.Controls.Add(Me.BtnGet)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTikID)
        Me.Controls.Add(Me.TxtFolw)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TxtSrc)
        Me.Controls.Add(Me.TxtOff)
        Me.Controls.Add(Me.TxtArea)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.TxtComp)
        Me.Controls.Add(Me.TxtProd)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.TxtDetails)
        Me.Controls.Add(Me.TxtPh2)
        Me.Controls.Add(Me.TxtDt)
        Me.Controls.Add(Me.TxtNm)
        Me.Controls.Add(Me.TxtPh1)
        Me.Controls.Add(Me.TxtAdd)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.CloseBtn)
        Me.Name = "TikEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعديل الشكوى"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents CloseBtn As Button
    Friend WithEvents TxtFolw As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents TxtTransDt As TextBox
    Friend WithEvents TxtCard As MaskedTextBox
    Friend WithEvents TxtNId As TextBox
    Friend WithEvents TxtAmount As TextBox
    Friend WithEvents TxtGP As TextBox
    Friend WithEvents TxtSrc As TextBox
    Friend WithEvents TxtOff As TextBox
    Friend WithEvents TxtArea As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents TxtComp As TextBox
    Friend WithEvents TxtProd As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents TxtDetails As TextBox
    Friend WithEvents TxtPh2 As TextBox
    Friend WithEvents TxtDt As TextBox
    Friend WithEvents TxtNm As TextBox
    Friend WithEvents TxtPh1 As TextBox
    Friend WithEvents TxtAdd As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TxtTrck As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents TxtDist As TextBox
    Friend WithEvents TxtOrgin As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtTikID As TextBox
    Friend WithEvents BtnGet As Button
    Friend WithEvents SubmitBtn As Button
    Friend WithEvents lblMsg As Label
    Friend WithEvents ChckReAssign As CheckBox
    Friend WithEvents LblText As Label
End Class
