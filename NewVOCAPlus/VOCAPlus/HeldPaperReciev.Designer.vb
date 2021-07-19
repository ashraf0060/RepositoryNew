<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPaperReciev
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
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.LblStat = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnUplod = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnBrws = New System.Windows.Forms.Button()
        Me.BtnSubmt = New System.Windows.Forms.Button()
        Me.GridHeldUpdt = New System.Windows.Forms.DataGridView()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TxtUpdt = New System.Windows.Forms.TextBox()
        Me.TxtOrgin = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtDoc = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtReason = New System.Windows.Forms.TextBox()
        Me.TxtWieght = New System.Windows.Forms.TextBox()
        Me.TxtDt = New System.Windows.Forms.TextBox()
        Me.TxtNm = New System.Windows.Forms.TextBox()
        Me.TxtPh = New System.Windows.Forms.TextBox()
        Me.TxtAdd = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTrck = New System.Windows.Forms.TextBox()
        Me.Lblmssg = New System.Windows.Forms.Label()
        Me.BtnClint = New System.Windows.Forms.Button()
        Me.LblClint = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.GridHeldUpdt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
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
        Me.CloseBtn.Location = New System.Drawing.Point(1256, 604)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 51)
        Me.CloseBtn.TabIndex = 2024
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'LblStat
        '
        Me.LblStat.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblStat.ForeColor = System.Drawing.Color.Red
        Me.LblStat.Location = New System.Drawing.Point(493, 469)
        Me.LblStat.Name = "LblStat"
        Me.LblStat.Size = New System.Drawing.Size(257, 30)
        Me.LblStat.TabIndex = 2122
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(756, 432)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListBox1.Size = New System.Drawing.Size(539, 154)
        Me.ListBox1.TabIndex = 2121
        '
        'BtnUplod
        '
        Me.BtnUplod.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.DbUp
        Me.BtnUplod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUplod.Location = New System.Drawing.Point(643, 392)
        Me.BtnUplod.Name = "BtnUplod"
        Me.BtnUplod.Size = New System.Drawing.Size(81, 64)
        Me.BtnUplod.TabIndex = 2120
        Me.ToolTip1.SetToolTip(Me.BtnUplod, "Upload")
        Me.BtnUplod.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"رقم قومي وجه", "رقم قومي ظهر", "رقم قومي وجه-ظهر", "روشته", "صورة الشحنة", "المواصفات الفنية", "اخرى"})
        Me.ComboBox1.Location = New System.Drawing.Point(1155, 351)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(140, 27)
        Me.ComboBox1.TabIndex = 2118
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(745, 352)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(404, 26)
        Me.TextBox1.TabIndex = 2116
        '
        'BtnBrws
        '
        Me.BtnBrws.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.browse_button_png_th
        Me.BtnBrws.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrws.Location = New System.Drawing.Point(627, 343)
        Me.BtnBrws.Name = "BtnBrws"
        Me.BtnBrws.Size = New System.Drawing.Size(112, 42)
        Me.BtnBrws.TabIndex = 2115
        Me.BtnBrws.UseVisualStyleBackColor = True
        '
        'BtnSubmt
        '
        Me.BtnSubmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSubmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSubmt.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnSubmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.BtnSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSubmt.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmt.Location = New System.Drawing.Point(557, 606)
        Me.BtnSubmt.Name = "BtnSubmt"
        Me.BtnSubmt.Size = New System.Drawing.Size(92, 43)
        Me.BtnSubmt.TabIndex = 2114
        Me.BtnSubmt.Text = "تسجيل"
        Me.BtnSubmt.UseVisualStyleBackColor = True
        Me.BtnSubmt.Visible = False
        '
        'GridHeldUpdt
        '
        Me.GridHeldUpdt.AllowUserToAddRows = False
        Me.GridHeldUpdt.AllowUserToDeleteRows = False
        Me.GridHeldUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridHeldUpdt.BackgroundColor = System.Drawing.Color.White
        Me.GridHeldUpdt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridHeldUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHeldUpdt.Location = New System.Drawing.Point(519, 8)
        Me.GridHeldUpdt.MultiSelect = False
        Me.GridHeldUpdt.Name = "GridHeldUpdt"
        Me.GridHeldUpdt.ReadOnly = True
        Me.GridHeldUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridHeldUpdt.Size = New System.Drawing.Size(786, 319)
        Me.GridHeldUpdt.TabIndex = 2113
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label60.Location = New System.Drawing.Point(578, 578)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(100, 25)
        Me.Label60.TabIndex = 2112
        Me.Label60.Text = "إضافة تحديث:"
        Me.Label60.Visible = False
        '
        'TxtUpdt
        '
        Me.TxtUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUpdt.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.TxtUpdt.Location = New System.Drawing.Point(610, 548)
        Me.TxtUpdt.Multiline = True
        Me.TxtUpdt.Name = "TxtUpdt"
        Me.TxtUpdt.Size = New System.Drawing.Size(78, 27)
        Me.TxtUpdt.TabIndex = 2111
        Me.TxtUpdt.Visible = False
        '
        'TxtOrgin
        '
        Me.TxtOrgin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOrgin.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtOrgin.Location = New System.Drawing.Point(120, 280)
        Me.TxtOrgin.Name = "TxtOrgin"
        Me.TxtOrgin.ReadOnly = True
        Me.TxtOrgin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOrgin.Size = New System.Drawing.Size(271, 26)
        Me.TxtOrgin.TabIndex = 2107
        Me.TxtOrgin.TabStop = False
        Me.TxtOrgin.Tag = "Email Address"
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(19, 315)
        Me.Label41.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label41.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label41.Size = New System.Drawing.Size(100, 22)
        Me.Label41.TabIndex = 2105
        Me.Label41.Text = "وزن الشحنة :"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(15, 120)
        Me.Label37.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label37.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label37.Size = New System.Drawing.Size(100, 22)
        Me.Label37.TabIndex = 2104
        Me.Label37.Text = "تليفون العميل :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(15, 87)
        Me.Label34.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label34.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label34.Size = New System.Drawing.Size(100, 22)
        Me.Label34.TabIndex = 2091
        Me.Label34.Text = "تاريخ الحجز :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(15, 157)
        Me.Label36.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label36.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label36.Size = New System.Drawing.Size(100, 17)
        Me.Label36.TabIndex = 2101
        Me.Label36.Text = "المرسل إلية :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(15, 198)
        Me.Label39.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label39.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label39.Size = New System.Drawing.Size(100, 17)
        Me.Label39.TabIndex = 2092
        Me.Label39.Text = "العنوان :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDoc
        '
        Me.TxtDoc.AcceptsReturn = True
        Me.TxtDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDoc.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtDoc.Location = New System.Drawing.Point(120, 346)
        Me.TxtDoc.Multiline = True
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.ReadOnly = True
        Me.TxtDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDoc.Size = New System.Drawing.Size(341, 110)
        Me.TxtDoc.TabIndex = 2099
        Me.TxtDoc.Tag = "نوع الخدمة"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(19, 509)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label43.Size = New System.Drawing.Size(96, 37)
        Me.Label43.TabIndex = 2098
        Me.Label43.Text = "المطلوب :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtReason
        '
        Me.TxtReason.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReason.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtReason.Location = New System.Drawing.Point(120, 460)
        Me.TxtReason.Multiline = True
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.ReadOnly = True
        Me.TxtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtReason.Size = New System.Drawing.Size(341, 134)
        Me.TxtReason.TabIndex = 2097
        Me.TxtReason.TabStop = False
        Me.TxtReason.Tag = "Details"
        '
        'TxtWieght
        '
        Me.TxtWieght.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWieght.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtWieght.Location = New System.Drawing.Point(120, 314)
        Me.TxtWieght.Name = "TxtWieght"
        Me.TxtWieght.ReadOnly = True
        Me.TxtWieght.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtWieght.Size = New System.Drawing.Size(271, 26)
        Me.TxtWieght.TabIndex = 2087
        Me.TxtWieght.Tag = "تليفون العميل 2"
        '
        'TxtDt
        '
        Me.TxtDt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtDt.Location = New System.Drawing.Point(120, 84)
        Me.TxtDt.Name = "TxtDt"
        Me.TxtDt.ReadOnly = True
        Me.TxtDt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDt.Size = New System.Drawing.Size(271, 26)
        Me.TxtDt.TabIndex = 2090
        Me.TxtDt.TabStop = False
        Me.TxtDt.Tag = "Date"
        '
        'TxtNm
        '
        Me.TxtNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtNm.Location = New System.Drawing.Point(120, 152)
        Me.TxtNm.Name = "TxtNm"
        Me.TxtNm.ReadOnly = True
        Me.TxtNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNm.Size = New System.Drawing.Size(271, 26)
        Me.TxtNm.TabIndex = 2086
        Me.TxtNm.TabStop = False
        Me.TxtNm.Tag = "اسم العميل"
        '
        'TxtPh
        '
        Me.TxtPh.AccessibleDescription = ""
        Me.TxtPh.AccessibleName = ""
        Me.TxtPh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtPh.Location = New System.Drawing.Point(120, 118)
        Me.TxtPh.Name = "TxtPh"
        Me.TxtPh.ReadOnly = True
        Me.TxtPh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh.Size = New System.Drawing.Size(271, 26)
        Me.TxtPh.TabIndex = 2085
        Me.TxtPh.Tag = "تليفون العميل 1"
        '
        'TxtAdd
        '
        Me.TxtAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtAdd.Location = New System.Drawing.Point(120, 186)
        Me.TxtAdd.Multiline = True
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.ReadOnly = True
        Me.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdd.Size = New System.Drawing.Size(271, 87)
        Me.TxtAdd.TabIndex = 2088
        Me.TxtAdd.Tag = "Address"
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Blue
        Me.Label51.Location = New System.Drawing.Point(19, 390)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label51.Size = New System.Drawing.Size(100, 22)
        Me.Label51.TabIndex = 2093
        Me.Label51.Text = "محتويات الشحنة :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label54
        '
        Me.Label54.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label54.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Blue
        Me.Label54.Location = New System.Drawing.Point(19, 286)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label54.Size = New System.Drawing.Size(100, 22)
        Me.Label54.TabIndex = 2102
        Me.Label54.Text = "بلد المنشأ :"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(15, 50)
        Me.Label1.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label1.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(100, 22)
        Me.Label1.TabIndex = 2110
        Me.Label1.Text = "رقم الشحنة :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtTrck
        '
        Me.TxtTrck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTrck.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtTrck.Location = New System.Drawing.Point(120, 48)
        Me.TxtTrck.MaxLength = 13
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTrck.Size = New System.Drawing.Size(271, 26)
        Me.TxtTrck.TabIndex = 2109
        Me.TxtTrck.Tag = "تليفون العميل 2"
        '
        'Lblmssg
        '
        Me.Lblmssg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Lblmssg.ForeColor = System.Drawing.Color.Green
        Me.Lblmssg.Location = New System.Drawing.Point(745, 386)
        Me.Lblmssg.Name = "Lblmssg"
        Me.Lblmssg.Size = New System.Drawing.Size(404, 30)
        Me.Lblmssg.TabIndex = 2126
        Me.Lblmssg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnClint
        '
        Me.BtnClint.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.UserC48
        Me.BtnClint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnClint.Location = New System.Drawing.Point(532, 333)
        Me.BtnClint.Name = "BtnClint"
        Me.BtnClint.Size = New System.Drawing.Size(72, 62)
        Me.BtnClint.TabIndex = 2127
        Me.BtnClint.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.BtnClint, "تسجيل حضور")
        Me.BtnClint.UseVisualStyleBackColor = True
        '
        'LblClint
        '
        Me.LblClint.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblClint.ForeColor = System.Drawing.Color.Red
        Me.LblClint.Location = New System.Drawing.Point(493, 512)
        Me.LblClint.Name = "LblClint"
        Me.LblClint.Size = New System.Drawing.Size(257, 30)
        Me.LblClint.TabIndex = 2128
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(120, 12)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(94, 22)
        Me.ComboBox2.TabIndex = 2131
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.MaximumSize = New System.Drawing.Size(100, 54)
        Me.Label3.MinimumSize = New System.Drawing.Size(100, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 2133
        Me.Label3.Text = "عدد التكرارات :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'HeldPaperReciev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1328, 669)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.LblClint)
        Me.Controls.Add(Me.BtnClint)
        Me.Controls.Add(Me.Lblmssg)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblStat)
        Me.Controls.Add(Me.TxtTrck)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.BtnUplod)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TxtAdd)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TxtPh)
        Me.Controls.Add(Me.BtnBrws)
        Me.Controls.Add(Me.TxtNm)
        Me.Controls.Add(Me.BtnSubmt)
        Me.Controls.Add(Me.TxtDt)
        Me.Controls.Add(Me.GridHeldUpdt)
        Me.Controls.Add(Me.TxtWieght)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.TxtReason)
        Me.Controls.Add(Me.TxtUpdt)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.TxtOrgin)
        Me.Controls.Add(Me.TxtDoc)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label34)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(-7, 52)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1366, 708)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(915, 545)
        Me.Name = "HeldPaperReciev"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تسجيل استلام الأوراق"
        CType(Me.GridHeldUpdt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CloseBtn As Button
    Friend WithEvents LblStat As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BtnUplod As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnBrws As Button
    Friend WithEvents BtnSubmt As Button
    Friend WithEvents GridHeldUpdt As DataGridView
    Friend WithEvents Label60 As Label
    Friend WithEvents TxtUpdt As TextBox
    Friend WithEvents TxtOrgin As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents TxtDoc As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents TxtReason As TextBox
    Friend WithEvents TxtWieght As TextBox
    Friend WithEvents TxtDt As TextBox
    Friend WithEvents TxtNm As TextBox
    Friend WithEvents TxtPh As TextBox
    Friend WithEvents TxtAdd As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtTrck As TextBox
    Friend WithEvents Lblmssg As Label
    Friend WithEvents BtnClint As Button
    Friend WithEvents LblClint As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
End Class
