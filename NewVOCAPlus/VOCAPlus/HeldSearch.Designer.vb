<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldSearch
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnSubmt = New System.Windows.Forms.Button()
        Me.GridHeldUpdt = New System.Windows.Forms.DataGridView()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TxtUpdt = New System.Windows.Forms.TextBox()
        Me.Btn2Bck = New System.Windows.Forms.Button()
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
        Me.BtnBckComp = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SerchTxt = New System.Windows.Forms.TextBox()
        Me.FilterComb = New System.Windows.Forms.ComboBox()
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridHeldUpdt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage2.Controls.Add(Me.BtnSubmt)
        Me.TabPage2.Controls.Add(Me.GridHeldUpdt)
        Me.TabPage2.Controls.Add(Me.Label60)
        Me.TabPage2.Controls.Add(Me.TxtUpdt)
        Me.TabPage2.Controls.Add(Me.Btn2Bck)
        Me.TabPage2.Controls.Add(Me.TxtOrgin)
        Me.TabPage2.Controls.Add(Me.Label41)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.Label36)
        Me.TabPage2.Controls.Add(Me.Label39)
        Me.TabPage2.Controls.Add(Me.TxtDoc)
        Me.TabPage2.Controls.Add(Me.Label43)
        Me.TabPage2.Controls.Add(Me.TxtReason)
        Me.TabPage2.Controls.Add(Me.TxtWieght)
        Me.TabPage2.Controls.Add(Me.TxtDt)
        Me.TabPage2.Controls.Add(Me.TxtNm)
        Me.TabPage2.Controls.Add(Me.TxtPh)
        Me.TabPage2.Controls.Add(Me.TxtAdd)
        Me.TabPage2.Controls.Add(Me.Label51)
        Me.TabPage2.Controls.Add(Me.Label54)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.TxtTrck)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1342, 528)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "TabPage2"
        Me.ToolTip1.SetToolTip(Me.TabPage2, "تفاصيل الشكاوى أوالاستفسارات")
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
        Me.BtnSubmt.Location = New System.Drawing.Point(7, 470)
        Me.BtnSubmt.Name = "BtnSubmt"
        Me.BtnSubmt.Size = New System.Drawing.Size(92, 40)
        Me.BtnSubmt.TabIndex = 2114
        Me.BtnSubmt.Text = "تسجيل"
        Me.BtnSubmt.UseVisualStyleBackColor = True
        '
        'GridHeldUpdt
        '
        Me.GridHeldUpdt.AllowUserToAddRows = False
        Me.GridHeldUpdt.AllowUserToDeleteRows = False
        Me.GridHeldUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridHeldUpdt.BackgroundColor = System.Drawing.Color.White
        Me.GridHeldUpdt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridHeldUpdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHeldUpdt.Location = New System.Drawing.Point(8, 12)
        Me.GridHeldUpdt.MultiSelect = False
        Me.GridHeldUpdt.Name = "GridHeldUpdt"
        Me.GridHeldUpdt.ReadOnly = True
        Me.GridHeldUpdt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridHeldUpdt.Size = New System.Drawing.Size(786, 374)
        Me.GridHeldUpdt.TabIndex = 2113
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label60.Location = New System.Drawing.Point(634, 404)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(100, 23)
        Me.Label60.TabIndex = 2112
        Me.Label60.Text = "إضافة تحديث:"
        '
        'TxtUpdt
        '
        Me.TxtUpdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUpdt.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.TxtUpdt.Location = New System.Drawing.Point(106, 395)
        Me.TxtUpdt.Multiline = True
        Me.TxtUpdt.Name = "TxtUpdt"
        Me.TxtUpdt.Size = New System.Drawing.Size(522, 125)
        Me.TxtUpdt.TabIndex = 2111
        '
        'Btn2Bck
        '
        Me.Btn2Bck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn2Bck.BackColor = System.Drawing.Color.Transparent
        Me.Btn2Bck.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back
        Me.Btn2Bck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn2Bck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn2Bck.Location = New System.Drawing.Point(1267, 6)
        Me.Btn2Bck.Name = "Btn2Bck"
        Me.Btn2Bck.Size = New System.Drawing.Size(63, 59)
        Me.Btn2Bck.TabIndex = 2052
        Me.ToolTip1.SetToolTip(Me.Btn2Bck, "العودة للشكاوى المرتبطة")
        Me.Btn2Bck.UseVisualStyleBackColor = False
        '
        'TxtOrgin
        '
        Me.TxtOrgin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOrgin.Location = New System.Drawing.Point(910, 224)
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
        Me.Label41.Location = New System.Drawing.Point(1187, 256)
        Me.Label41.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label41.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label41.Size = New System.Drawing.Size(100, 20)
        Me.Label41.TabIndex = 2105
        Me.Label41.Text = "وزن الشحنة :"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(1183, 75)
        Me.Label37.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label37.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label37.Size = New System.Drawing.Size(100, 20)
        Me.Label37.TabIndex = 2104
        Me.Label37.Text = "تليفون العميل :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(1183, 44)
        Me.Label34.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label34.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label34.Size = New System.Drawing.Size(100, 20)
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
        Me.Label36.Location = New System.Drawing.Point(1183, 109)
        Me.Label36.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label36.MinimumSize = New System.Drawing.Size(100, 15)
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
        Me.Label39.Location = New System.Drawing.Point(1183, 147)
        Me.Label39.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label39.MinimumSize = New System.Drawing.Size(100, 15)
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
        Me.TxtDoc.Location = New System.Drawing.Point(840, 289)
        Me.TxtDoc.Multiline = True
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.ReadOnly = True
        Me.TxtDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDoc.Size = New System.Drawing.Size(341, 102)
        Me.TxtDoc.TabIndex = 2099
        Me.TxtDoc.Tag = "نوع الخدمة"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(1187, 397)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 34)
        Me.Label43.TabIndex = 2098
        Me.Label43.Text = "المطلوب :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtReason
        '
        Me.TxtReason.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReason.Location = New System.Drawing.Point(840, 397)
        Me.TxtReason.Multiline = True
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.ReadOnly = True
        Me.TxtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtReason.Size = New System.Drawing.Size(341, 125)
        Me.TxtReason.TabIndex = 2097
        Me.TxtReason.TabStop = False
        Me.TxtReason.Tag = "Details"
        '
        'TxtWieght
        '
        Me.TxtWieght.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWieght.Location = New System.Drawing.Point(910, 256)
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
        Me.TxtDt.Location = New System.Drawing.Point(910, 42)
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
        Me.TxtNm.Location = New System.Drawing.Point(910, 105)
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
        Me.TxtPh.Location = New System.Drawing.Point(910, 74)
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
        Me.TxtAdd.Location = New System.Drawing.Point(910, 137)
        Me.TxtAdd.Multiline = True
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.ReadOnly = True
        Me.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdd.Size = New System.Drawing.Size(271, 81)
        Me.TxtAdd.TabIndex = 2088
        Me.TxtAdd.Tag = "Address"
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Blue
        Me.Label51.Location = New System.Drawing.Point(1187, 296)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label51.Size = New System.Drawing.Size(100, 20)
        Me.Label51.TabIndex = 2093
        Me.Label51.Text = "محتويات الشحنة :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label54
        '
        Me.Label54.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label54.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Blue
        Me.Label54.Location = New System.Drawing.Point(1187, 229)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label54.Size = New System.Drawing.Size(100, 20)
        Me.Label54.TabIndex = 2102
        Me.Label54.Text = "بلد المنشأ :"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(1183, 10)
        Me.Label1.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label1.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2110
        Me.Label1.Text = "رقم الشحنة :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtTrck
        '
        Me.TxtTrck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTrck.Location = New System.Drawing.Point(910, 9)
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.ReadOnly = True
        Me.TxtTrck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTrck.Size = New System.Drawing.Size(271, 26)
        Me.TxtTrck.TabIndex = 2109
        Me.TxtTrck.Tag = "تليفون العميل 2"
        '
        'BtnBckComp
        '
        Me.BtnBckComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBckComp.BackColor = System.Drawing.Color.Transparent
        Me.BtnBckComp.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back
        Me.BtnBckComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBckComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBckComp.Location = New System.Drawing.Point(1267, 6)
        Me.BtnBckComp.Name = "BtnBckComp"
        Me.BtnBckComp.Size = New System.Drawing.Size(63, 59)
        Me.BtnBckComp.TabIndex = 2053
        Me.ToolTip1.SetToolTip(Me.BtnBckComp, "العودة للشكاوى المرتبطة")
        Me.BtnBckComp.UseVisualStyleBackColor = False
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
        Me.CloseBtn.Location = New System.Drawing.Point(1284, 563)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 47)
        Me.CloseBtn.TabIndex = 2024
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'BtnSerch
        '
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Search11
        Me.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.Location = New System.Drawing.Point(636, 3)
        Me.BtnSerch.Name = "BtnSerch"
        Me.BtnSerch.Size = New System.Drawing.Size(64, 64)
        Me.BtnSerch.TabIndex = 2023
        Me.ToolTip1.SetToolTip(Me.BtnSerch, "بحث")
        Me.BtnSerch.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.BtnSerch)
        Me.TabPage1.Controls.Add(Me.SerchTxt)
        Me.TabPage1.Controls.Add(Me.FilterComb)
        Me.TabPage1.Controls.Add(Me.GridHeld)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1342, 528)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "بحث المحجوزات"
        '
        'SerchTxt
        '
        Me.SerchTxt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.SerchTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SerchTxt.Location = New System.Drawing.Point(723, 25)
        Me.SerchTxt.Name = "SerchTxt"
        Me.SerchTxt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SerchTxt.Size = New System.Drawing.Size(187, 26)
        Me.SerchTxt.TabIndex = 7
        Me.SerchTxt.Text = "برجاء ادخال كلمات البحث"
        Me.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FilterComb
        '
        Me.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComb.FormattingEnabled = True
        Me.FilterComb.Location = New System.Drawing.Point(916, 24)
        Me.FilterComb.Name = "FilterComb"
        Me.FilterComb.Size = New System.Drawing.Size(187, 27)
        Me.FilterComb.TabIndex = 6
        '
        'GridHeld
        '
        Me.GridHeld.AllowUserToAddRows = False
        Me.GridHeld.AllowUserToDeleteRows = False
        Me.GridHeld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridHeld.BackgroundColor = System.Drawing.Color.White
        Me.GridHeld.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHeld.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridHeld.Location = New System.Drawing.Point(7, 72)
        Me.GridHeld.MultiSelect = False
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.ReadOnly = True
        Me.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridHeld.Size = New System.Drawing.Size(1319, 440)
        Me.GridHeld.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopySelectedToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 26)
        '
        'CopySelectedToolStripMenuItem
        '
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CopySelectedToolStripMenuItem.Text = "Copy Selected"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TabControl1.ItemSize = New System.Drawing.Size(100, 30)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(1350, 566)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 2020
        Me.TabControl1.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.BtnBckComp)
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1342, 528)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(100, 576)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblMsg.Size = New System.Drawing.Size(1108, 23)
        Me.LblMsg.TabIndex = 2058
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HeldSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 621)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(-7, 52)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1366, 660)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1364, 660)
        Me.Name = "HeldSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث المحجوزات"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GridHeldUpdt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents FilterComb As ComboBox
    Friend WithEvents SerchTxt As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Btn2Bck As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents LblMsg As Label
    Friend WithEvents BtnBckComp As Button
    Friend WithEvents BtnSerch As Button
    Friend WithEvents CloseBtn As Button
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
    Friend WithEvents BtnSubmt As Button
    Friend WithEvents GridHeldUpdt As DataGridView
    Friend WithEvents Label60 As Label
    Friend WithEvents TxtUpdt As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As ToolStripMenuItem
End Class
