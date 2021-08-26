<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TikFolow
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SerchTxt = New System.Windows.Forms.TextBox()
        Me.FilterComb = New System.Windows.Forms.ComboBox()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.GridTicket = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UplodAtchToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonlodAttchToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatBrPnlEn = New System.Windows.Forms.StatusBarPanel()
        Me.StatBrPnlAr = New System.Windows.Forms.StatusBarPanel()
        Me.BtnRefrsh = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl6 = New System.Windows.Forms.Label()
        Me.ChckEsc1 = New System.Windows.Forms.RadioButton()
        Me.Lbl7 = New System.Windows.Forms.Label()
        Me.ChckEsc2 = New System.Windows.Forms.RadioButton()
        Me.Lbl8 = New System.Windows.Forms.Label()
        Me.ChckEsc3 = New System.Windows.Forms.RadioButton()
        Me.Lbl5 = New System.Windows.Forms.Label()
        Me.ChckRead = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl3 = New System.Windows.Forms.Label()
        Me.Lbl4 = New System.Windows.Forms.Label()
        Me.Lbl2 = New System.Windows.Forms.Label()
        Me.Lbl0 = New System.Windows.Forms.Label()
        Me.Lbl1 = New System.Windows.Forms.Label()
        Me.ChckUpdAll = New System.Windows.Forms.RadioButton()
        Me.ChckUpdMe = New System.Windows.Forms.RadioButton()
        Me.ChckFlN = New System.Windows.Forms.RadioButton()
        Me.ChckTrnsDy = New System.Windows.Forms.RadioButton()
        Me.ChckUpdColeg = New System.Windows.Forms.RadioButton()
        Me.ChckUpdOther = New System.Windows.Forms.RadioButton()
        Me.BtnCncl = New System.Windows.Forms.Button()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(468, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(309, 23)
        Me.ProgressBar1.TabIndex = 2033
        Me.ProgressBar1.Visible = False
        '
        'SerchTxt
        '
        Me.SerchTxt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.SerchTxt.ForeColor = System.Drawing.Color.Silver
        Me.SerchTxt.Location = New System.Drawing.Point(800, 10)
        Me.SerchTxt.Name = "SerchTxt"
        Me.SerchTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SerchTxt.Size = New System.Drawing.Size(218, 26)
        Me.SerchTxt.TabIndex = 2024
        Me.SerchTxt.Text = "برجاء ادخال كلمات البحث"
        Me.SerchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FilterComb
        '
        Me.FilterComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComb.FormattingEnabled = True
        Me.FilterComb.Location = New System.Drawing.Point(1024, 12)
        Me.FilterComb.MinimumSize = New System.Drawing.Size(70, 0)
        Me.FilterComb.Name = "FilterComb"
        Me.FilterComb.Size = New System.Drawing.Size(196, 21)
        Me.FilterComb.TabIndex = 2023
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackColor = System.Drawing.Color.White
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBtn.Location = New System.Drawing.Point(28, 520)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(64, 64)
        Me.CloseBtn.TabIndex = 129
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = False
        '
        'GridTicket
        '
        Me.GridTicket.AllowUserToAddRows = False
        Me.GridTicket.AllowUserToDeleteRows = False
        Me.GridTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTicket.BackgroundColor = System.Drawing.Color.White
        Me.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTicket.Location = New System.Drawing.Point(12, 47)
        Me.GridTicket.MultiSelect = False
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.ReadOnly = True
        Me.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridTicket.Size = New System.Drawing.Size(1326, 463)
        Me.GridTicket.TabIndex = 123
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripitem, Me.UplodAtchToolStripitem, Me.DonlodAttchToolStripitem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(185, 70)
        '
        'CopyToolStripitem
        '
        Me.CopyToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CopyToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.Copy
        Me.CopyToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopyToolStripitem.Name = "CopyToolStripitem"
        Me.CopyToolStripitem.RightToLeftAutoMirrorImage = True
        Me.CopyToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.CopyToolStripitem.Text = "Copy Selected Cell"
        '
        'UplodAtchToolStripitem
        '
        Me.UplodAtchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UplodAtchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.UplodAtchToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.upload_1
        Me.UplodAtchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UplodAtchToolStripitem.Name = "UplodAtchToolStripitem"
        Me.UplodAtchToolStripitem.RightToLeftAutoMirrorImage = True
        Me.UplodAtchToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.UplodAtchToolStripitem.Text = "Upload Attachement"
        Me.UplodAtchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DonlodAttchToolStripitem
        '
        Me.DonlodAttchToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DonlodAttchToolStripitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DonlodAttchToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.Download
        Me.DonlodAttchToolStripitem.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.DonlodAttchToolStripitem.Name = "DonlodAttchToolStripitem"
        Me.DonlodAttchToolStripitem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DonlodAttchToolStripitem.RightToLeftAutoMirrorImage = True
        Me.DonlodAttchToolStripitem.Size = New System.Drawing.Size(184, 22)
        Me.DonlodAttchToolStripitem.Text = "Download attached"
        Me.DonlodAttchToolStripitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 588)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatBrPnlEn, Me.StatBrPnlAr})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1350, 33)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 126
        '
        'StatBrPnlEn
        '
        Me.StatBrPnlEn.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlEn.Name = "StatBrPnlEn"
        Me.StatBrPnlEn.Width = 675
        '
        'StatBrPnlAr
        '
        Me.StatBrPnlAr.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlAr.Name = "StatBrPnlAr"
        Me.StatBrPnlAr.Width = 675
        '
        'BtnRefrsh
        '
        Me.BtnRefrsh.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnRefrsh.Location = New System.Drawing.Point(335, 11)
        Me.BtnRefrsh.Name = "BtnRefrsh"
        Me.BtnRefrsh.Size = New System.Drawing.Size(90, 29)
        Me.BtnRefrsh.TabIndex = 2034
        Me.BtnRefrsh.Text = "تحديث"
        Me.BtnRefrsh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Lbl6)
        Me.GroupBox1.Controls.Add(Me.ChckEsc1)
        Me.GroupBox1.Controls.Add(Me.Lbl7)
        Me.GroupBox1.Controls.Add(Me.ChckEsc2)
        Me.GroupBox1.Controls.Add(Me.Lbl8)
        Me.GroupBox1.Controls.Add(Me.ChckEsc3)
        Me.GroupBox1.Controls.Add(Me.Lbl5)
        Me.GroupBox1.Controls.Add(Me.ChckRead)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Lbl3)
        Me.GroupBox1.Controls.Add(Me.Lbl4)
        Me.GroupBox1.Controls.Add(Me.Lbl2)
        Me.GroupBox1.Controls.Add(Me.Lbl0)
        Me.GroupBox1.Controls.Add(Me.Lbl1)
        Me.GroupBox1.Controls.Add(Me.ChckUpdAll)
        Me.GroupBox1.Controls.Add(Me.ChckUpdMe)
        Me.GroupBox1.Controls.Add(Me.ChckFlN)
        Me.GroupBox1.Controls.Add(Me.ChckTrnsDy)
        Me.GroupBox1.Controls.Add(Me.ChckUpdColeg)
        Me.GroupBox1.Controls.Add(Me.ChckUpdOther)
        Me.GroupBox1.Location = New System.Drawing.Point(154, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(989, 75)
        Me.GroupBox1.TabIndex = 2093
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تصفيه"
        '
        'Lbl6
        '
        Me.Lbl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl6.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl6.Location = New System.Drawing.Point(600, 44)
        Me.Lbl6.Name = "Lbl6"
        Me.Lbl6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl6.Size = New System.Drawing.Size(90, 20)
        Me.Lbl6.TabIndex = 2048
        Me.Lbl6.Text = "Label3"
        Me.Lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChckEsc1
        '
        Me.ChckEsc1.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckEsc1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckEsc1.Location = New System.Drawing.Point(600, 16)
        Me.ChckEsc1.Name = "ChckEsc1"
        Me.ChckEsc1.Size = New System.Drawing.Size(90, 25)
        Me.ChckEsc1.TabIndex = 2047
        Me.ChckEsc1.TabStop = True
        Me.ChckEsc1.Text = "متابعة 1"
        Me.ChckEsc1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckEsc1.UseVisualStyleBackColor = True
        '
        'Lbl7
        '
        Me.Lbl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl7.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl7.Location = New System.Drawing.Point(504, 44)
        Me.Lbl7.Name = "Lbl7"
        Me.Lbl7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl7.Size = New System.Drawing.Size(90, 20)
        Me.Lbl7.TabIndex = 2046
        Me.Lbl7.Text = "Label3"
        Me.Lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChckEsc2
        '
        Me.ChckEsc2.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckEsc2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckEsc2.Location = New System.Drawing.Point(504, 16)
        Me.ChckEsc2.Name = "ChckEsc2"
        Me.ChckEsc2.Size = New System.Drawing.Size(90, 25)
        Me.ChckEsc2.TabIndex = 2045
        Me.ChckEsc2.TabStop = True
        Me.ChckEsc2.Text = "متابعة 2"
        Me.ChckEsc2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckEsc2.UseVisualStyleBackColor = True
        '
        'Lbl8
        '
        Me.Lbl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl8.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl8.Location = New System.Drawing.Point(408, 44)
        Me.Lbl8.Name = "Lbl8"
        Me.Lbl8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl8.Size = New System.Drawing.Size(90, 20)
        Me.Lbl8.TabIndex = 2044
        Me.Lbl8.Text = "Label3"
        Me.Lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChckEsc3
        '
        Me.ChckEsc3.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckEsc3.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckEsc3.Location = New System.Drawing.Point(408, 16)
        Me.ChckEsc3.Name = "ChckEsc3"
        Me.ChckEsc3.Size = New System.Drawing.Size(90, 25)
        Me.ChckEsc3.TabIndex = 2043
        Me.ChckEsc3.TabStop = True
        Me.ChckEsc3.Text = "متابعة 3"
        Me.ChckEsc3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckEsc3.UseVisualStyleBackColor = True
        '
        'Lbl5
        '
        Me.Lbl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl5.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl5.Location = New System.Drawing.Point(885, 44)
        Me.Lbl5.Name = "Lbl5"
        Me.Lbl5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl5.Size = New System.Drawing.Size(90, 20)
        Me.Lbl5.TabIndex = 2042
        Me.Lbl5.Text = "Label3"
        Me.Lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChckRead
        '
        Me.ChckRead.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckRead.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckRead.Location = New System.Drawing.Point(885, 16)
        Me.ChckRead.Name = "ChckRead"
        Me.ChckRead.Size = New System.Drawing.Size(90, 25)
        Me.ChckRead.TabIndex = 2041
        Me.ChckRead.TabStop = True
        Me.ChckRead.Text = "غير مقروء"
        Me.ChckRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckRead.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 2039
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl3
        '
        Me.Lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl3.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl3.Location = New System.Drawing.Point(789, 44)
        Me.Lbl3.Name = "Lbl3"
        Me.Lbl3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl3.Size = New System.Drawing.Size(90, 20)
        Me.Lbl3.TabIndex = 2040
        Me.Lbl3.Text = "Label3"
        Me.Lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl4
        '
        Me.Lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl4.Location = New System.Drawing.Point(696, 44)
        Me.Lbl4.Name = "Lbl4"
        Me.Lbl4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl4.Size = New System.Drawing.Size(90, 20)
        Me.Lbl4.TabIndex = 2039
        Me.Lbl4.Text = "Label4"
        Me.Lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl2
        '
        Me.Lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl2.Location = New System.Drawing.Point(106, 44)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl2.Size = New System.Drawing.Size(90, 20)
        Me.Lbl2.TabIndex = 2038
        Me.Lbl2.Text = "Label2"
        Me.Lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl0
        '
        Me.Lbl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl0.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl0.Location = New System.Drawing.Point(304, 44)
        Me.Lbl0.Name = "Lbl0"
        Me.Lbl0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl0.Size = New System.Drawing.Size(100, 20)
        Me.Lbl0.TabIndex = 2030
        Me.Lbl0.Text = "Label0"
        Me.Lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl1
        '
        Me.Lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lbl1.Location = New System.Drawing.Point(200, 44)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl1.Size = New System.Drawing.Size(102, 20)
        Me.Lbl1.TabIndex = 2032
        Me.Lbl1.Text = "Label1"
        Me.Lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChckUpdAll
        '
        Me.ChckUpdAll.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckUpdAll.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckUpdAll.Location = New System.Drawing.Point(6, 16)
        Me.ChckUpdAll.Name = "ChckUpdAll"
        Me.ChckUpdAll.Size = New System.Drawing.Size(97, 25)
        Me.ChckUpdAll.TabIndex = 2037
        Me.ChckUpdAll.TabStop = True
        Me.ChckUpdAll.Text = "الكل"
        Me.ChckUpdAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckUpdAll.UseVisualStyleBackColor = True
        '
        'ChckUpdMe
        '
        Me.ChckUpdMe.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckUpdMe.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.ChckUpdMe.Location = New System.Drawing.Point(302, 16)
        Me.ChckUpdMe.Name = "ChckUpdMe"
        Me.ChckUpdMe.Size = New System.Drawing.Size(102, 25)
        Me.ChckUpdMe.TabIndex = 2036
        Me.ChckUpdMe.TabStop = True
        Me.ChckUpdMe.Text = "تحديثات المتابع"
        Me.ChckUpdMe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckUpdMe.UseVisualStyleBackColor = True
        '
        'ChckFlN
        '
        Me.ChckFlN.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckFlN.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckFlN.Location = New System.Drawing.Point(789, 16)
        Me.ChckFlN.Name = "ChckFlN"
        Me.ChckFlN.Size = New System.Drawing.Size(90, 25)
        Me.ChckFlN.TabIndex = 2035
        Me.ChckFlN.TabStop = True
        Me.ChckFlN.Text = "بدون متابعة"
        Me.ChckFlN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckFlN.UseVisualStyleBackColor = True
        '
        'ChckTrnsDy
        '
        Me.ChckTrnsDy.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckTrnsDy.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckTrnsDy.Location = New System.Drawing.Point(696, 16)
        Me.ChckTrnsDy.Name = "ChckTrnsDy"
        Me.ChckTrnsDy.Size = New System.Drawing.Size(90, 25)
        Me.ChckTrnsDy.TabIndex = 2034
        Me.ChckTrnsDy.TabStop = True
        Me.ChckTrnsDy.Text = "استلام اليوم"
        Me.ChckTrnsDy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckTrnsDy.UseVisualStyleBackColor = True
        '
        'ChckUpdColeg
        '
        Me.ChckUpdColeg.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckUpdColeg.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckUpdColeg.Location = New System.Drawing.Point(199, 16)
        Me.ChckUpdColeg.Name = "ChckUpdColeg"
        Me.ChckUpdColeg.Size = New System.Drawing.Size(102, 25)
        Me.ChckUpdColeg.TabIndex = 2033
        Me.ChckUpdColeg.TabStop = True
        Me.ChckUpdColeg.Text = "تحديثات الزملاء"
        Me.ChckUpdColeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckUpdColeg.UseVisualStyleBackColor = True
        '
        'ChckUpdOther
        '
        Me.ChckUpdOther.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChckUpdOther.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.ChckUpdOther.Location = New System.Drawing.Point(106, 16)
        Me.ChckUpdOther.Name = "ChckUpdOther"
        Me.ChckUpdOther.Size = New System.Drawing.Size(90, 25)
        Me.ChckUpdOther.TabIndex = 2032
        Me.ChckUpdOther.TabStop = True
        Me.ChckUpdOther.Text = "تحديثات الغير"
        Me.ChckUpdOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChckUpdOther.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        Me.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCncl.FlatAppearance.BorderSize = 0
        Me.BtnCncl.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnCncl.Location = New System.Drawing.Point(231, 7)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCncl.Size = New System.Drawing.Size(69, 34)
        Me.BtnCncl.TabIndex = 2169
        Me.BtnCncl.Text = "Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'TikFolow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 621)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnRefrsh)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GridTicket)
        Me.Controls.Add(Me.SerchTxt)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.FilterComb)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1366, 660)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1364, 660)
        Me.Name = "TikFolow"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "متابعة الشكاوى"
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CloseBtn As Button
    Friend WithEvents GridTicket As DataGridView
    Friend WithEvents SerchTxt As TextBox
    Friend WithEvents FilterComb As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatBrPnlEn As StatusBarPanel
    Friend WithEvents StatBrPnlAr As StatusBarPanel
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyToolStripitem As ToolStripMenuItem
    Friend WithEvents UplodAtchToolStripitem As ToolStripMenuItem
    Friend WithEvents DonlodAttchToolStripitem As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BtnRefrsh As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Lbl6 As Label
    Friend WithEvents ChckEsc1 As RadioButton
    Friend WithEvents Lbl7 As Label
    Friend WithEvents ChckEsc2 As RadioButton
    Friend WithEvents Lbl8 As Label
    Friend WithEvents ChckEsc3 As RadioButton
    Friend WithEvents Lbl5 As Label
    Friend WithEvents ChckRead As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Lbl3 As Label
    Friend WithEvents Lbl4 As Label
    Friend WithEvents Lbl2 As Label
    Friend WithEvents Lbl0 As Label
    Friend WithEvents Lbl1 As Label
    Friend WithEvents ChckUpdAll As RadioButton
    Friend WithEvents ChckUpdMe As RadioButton
    Friend WithEvents ChckFlN As RadioButton
    Friend WithEvents ChckTrnsDy As RadioButton
    Friend WithEvents ChckUpdColeg As RadioButton
    Friend WithEvents ChckUpdOther As RadioButton
    Friend WithEvents BtnCncl As Button
End Class
