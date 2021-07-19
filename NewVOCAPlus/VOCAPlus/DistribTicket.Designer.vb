<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DistribTicket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DistribTicket))
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatBrPnlEn = New System.Windows.Forms.StatusBarPanel()
        Me.StatBrPnlAr = New System.Windows.Forms.StatusBarPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.LblTickCount = New System.Windows.Forms.Label()
        Me.LblAgentCount = New System.Windows.Forms.Label()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.GridUsrTickCount = New System.Windows.Forms.DataGridView()
        Me.GridTicket = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnBck = New System.Windows.Forms.Button()
        Me.TcktImg = New System.Windows.Forms.PictureBox()
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
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridUsrTickCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.TcktImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TabControl1.Location = New System.Drawing.Point(4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1343, 619)
        Me.TabControl1.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.TabControl1, "شكاوى قيد التوزيع")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.StatusBar1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CloseBtn)
        Me.TabPage1.Controls.Add(Me.LblTickCount)
        Me.TabPage1.Controls.Add(Me.LblAgentCount)
        Me.TabPage1.Controls.Add(Me.BtnSubmit)
        Me.TabPage1.Controls.Add(Me.LblMsg)
        Me.TabPage1.Controls.Add(Me.GridUsrTickCount)
        Me.TabPage1.Controls.Add(Me.GridTicket)
        Me.TabPage1.Controls.Add(Me.UserTree)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1335, 587)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "توزيع الشكاوى"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(3, 551)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatBrPnlEn, Me.StatBrPnlAr})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1329, 33)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 2061
        '
        'StatBrPnlEn
        '
        Me.StatBrPnlEn.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlEn.Name = "StatBrPnlEn"
        Me.StatBrPnlEn.Width = 664
        '
        'StatBrPnlAr
        '
        Me.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlAr.Name = "StatBrPnlAr"
        Me.StatBrPnlAr.Width = 664
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(282, 523)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(696, 23)
        Me.Label4.TabIndex = 2060
        Me.Label4.Text = "اللون الأزرق يعني أن هناك شكاوى أخرى للعميل داخل الفريق"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(1147, 526)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(170, 20)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "إجمالي عدد شكاوى اليوم :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(1147, 500)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(170, 20)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "عدد موظفي الفريق :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.CloseBtn.Location = New System.Drawing.Point(17, 504)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(96, 43)
        Me.CloseBtn.TabIndex = 129
        Me.CloseBtn.Text = "خروج"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'LblTickCount
        '
        Me.LblTickCount.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblTickCount.Location = New System.Drawing.Point(1048, 527)
        Me.LblTickCount.Name = "LblTickCount"
        Me.LblTickCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblTickCount.Size = New System.Drawing.Size(100, 20)
        Me.LblTickCount.TabIndex = 128
        Me.LblTickCount.Text = "Label1"
        Me.LblTickCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAgentCount
        '
        Me.LblAgentCount.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblAgentCount.Location = New System.Drawing.Point(1048, 502)
        Me.LblAgentCount.Name = "LblAgentCount"
        Me.LblAgentCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblAgentCount.Size = New System.Drawing.Size(100, 20)
        Me.LblAgentCount.TabIndex = 127
        Me.LblAgentCount.Text = "Label1"
        Me.LblAgentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnSubmit
        '
        Me.BtnSubmit.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSubmit.FlatAppearance.BorderSize = 0
        Me.BtnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSubmit.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(141, 506)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(96, 43)
        Me.BtnSubmit.TabIndex = 126
        Me.BtnSubmit.Text = "تسجيل"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblMsg.ForeColor = System.Drawing.Color.Red
        Me.LblMsg.Location = New System.Drawing.Point(261, 491)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(450, 23)
        Me.LblMsg.TabIndex = 125
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridUsrTickCount
        '
        Me.GridUsrTickCount.AllowUserToAddRows = False
        Me.GridUsrTickCount.AllowUserToDeleteRows = False
        Me.GridUsrTickCount.BackgroundColor = System.Drawing.Color.White
        Me.GridUsrTickCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUsrTickCount.Location = New System.Drawing.Point(1100, 6)
        Me.GridUsrTickCount.MultiSelect = False
        Me.GridUsrTickCount.Name = "GridUsrTickCount"
        Me.GridUsrTickCount.ReadOnly = True
        Me.GridUsrTickCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridUsrTickCount.Size = New System.Drawing.Size(229, 481)
        Me.GridUsrTickCount.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.GridUsrTickCount, "عدد شكاوى اليوم لكل موظف")
        '
        'GridTicket
        '
        Me.GridTicket.AllowUserToAddRows = False
        Me.GridTicket.AllowUserToDeleteRows = False
        Me.GridTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTicket.BackgroundColor = System.Drawing.Color.White
        Me.GridTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTicket.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridTicket.Location = New System.Drawing.Point(6, 6)
        Me.GridTicket.MultiSelect = False
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.ReadOnly = True
        Me.GridTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridTicket.Size = New System.Drawing.Size(758, 481)
        Me.GridTicket.TabIndex = 123
        Me.ToolTip1.SetToolTip(Me.GridTicket, "شكاوى قيد  التوزيع")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopySelectedToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'CopySelectedToolStripMenuItem
        '
        Me.CopySelectedToolStripMenuItem.Image = Global.VOCAPlus.My.Resources.Resources.Copy
        Me.CopySelectedToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopySelectedToolStripMenuItem.Text = "Copy Selected"
        '
        'UserTree
        '
        Me.UserTree.BackColor = System.Drawing.SystemColors.Window
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.Location = New System.Drawing.Point(770, 6)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowNodeToolTips = True
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(324, 481)
        Me.UserTree.TabIndex = 122
        Me.UserTree.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.BtnBck)
        Me.TabPage2.Controls.Add(Me.TcktImg)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.TxtSrc)
        Me.TabPage2.Controls.Add(Me.TxtOff)
        Me.TabPage2.Controls.Add(Me.TxtArea)
        Me.TabPage2.Controls.Add(Me.Label41)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.Label36)
        Me.TabPage2.Controls.Add(Me.Label39)
        Me.TabPage2.Controls.Add(Me.TxtComp)
        Me.TabPage2.Controls.Add(Me.TxtProd)
        Me.TabPage2.Controls.Add(Me.Label43)
        Me.TabPage2.Controls.Add(Me.TxtDetails)
        Me.TabPage2.Controls.Add(Me.TxtPh2)
        Me.TabPage2.Controls.Add(Me.TxtDt)
        Me.TabPage2.Controls.Add(Me.TxtNm)
        Me.TabPage2.Controls.Add(Me.TxtPh1)
        Me.TabPage2.Controls.Add(Me.TxtAdd)
        Me.TabPage2.Controls.Add(Me.Label50)
        Me.TabPage2.Controls.Add(Me.Label51)
        Me.TabPage2.Controls.Add(Me.TxtEmail)
        Me.TabPage2.Controls.Add(Me.Label52)
        Me.TabPage2.Controls.Add(Me.Label53)
        Me.TabPage2.Controls.Add(Me.Label54)
        Me.TabPage2.Controls.Add(Me.Label55)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1335, 587)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BtnBck
        '
        Me.BtnBck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBck.BackColor = System.Drawing.Color.Transparent
        Me.BtnBck.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back
        Me.BtnBck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBck.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnBck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnBck.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBck.Location = New System.Drawing.Point(1266, 6)
        Me.BtnBck.Name = "BtnBck"
        Me.BtnBck.Size = New System.Drawing.Size(63, 59)
        Me.BtnBck.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.BtnBck, "العودة للتوزيع")
        Me.BtnBck.UseVisualStyleBackColor = False
        '
        'TcktImg
        '
        Me.TcktImg.Location = New System.Drawing.Point(220, 10)
        Me.TcktImg.Name = "TcktImg"
        Me.TcktImg.Size = New System.Drawing.Size(256, 186)
        Me.TcktImg.TabIndex = 2081
        Me.TcktImg.TabStop = False
        Me.ToolTip1.SetToolTip(Me.TcktImg, "حالة الشكوى")
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
        Me.GroupBox3.Location = New System.Drawing.Point(787, 352)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 160)
        Me.GroupBox3.TabIndex = 2056
        Me.GroupBox3.TabStop = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(292, 21)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 13)
        Me.Label33.TabIndex = 1008
        Me.Label33.Text = "رقم الكارت/الحساب :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(292, 66)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(103, 13)
        Me.Label35.TabIndex = 1010
        Me.Label35.Text = "الرقم القومي :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(292, 93)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 13)
        Me.Label38.TabIndex = 32
        Me.Label38.Text = "مبلغ العملية :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(292, 120)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 13)
        Me.Label40.TabIndex = 34
        Me.Label40.Text = "تاريخ العملية :"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(292, 45)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(103, 13)
        Me.Label42.TabIndex = 1009
        Me.Label42.Text = "رقم أمر الدفع :"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtTransDt
        '
        Me.TxtTransDt.Location = New System.Drawing.Point(36, 117)
        Me.TxtTransDt.MaxLength = 16
        Me.TxtTransDt.Name = "TxtTransDt"
        Me.TxtTransDt.ReadOnly = True
        Me.TxtTransDt.Size = New System.Drawing.Size(250, 26)
        Me.TxtTransDt.TabIndex = 1011
        Me.TxtTransDt.Tag = "مبلغ العملية"
        '
        'TxtCard
        '
        Me.TxtCard.Location = New System.Drawing.Point(36, 18)
        Me.TxtCard.Mask = "0000 0000 0000 0000"
        Me.TxtCard.Name = "TxtCard"
        Me.TxtCard.ReadOnly = True
        Me.TxtCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtCard.Size = New System.Drawing.Size(250, 26)
        Me.TxtCard.TabIndex = 7
        Me.TxtCard.Tag = "رقم الكارت"
        '
        'TxtNId
        '
        Me.TxtNId.Location = New System.Drawing.Point(36, 66)
        Me.TxtNId.MaxLength = 14
        Me.TxtNId.Name = "TxtNId"
        Me.TxtNId.ReadOnly = True
        Me.TxtNId.Size = New System.Drawing.Size(250, 26)
        Me.TxtNId.TabIndex = 9
        Me.TxtNId.Tag = "الرقم القومي"
        Me.TxtNId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAmount
        '
        Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAmount.Location = New System.Drawing.Point(36, 93)
        Me.TxtAmount.MaxLength = 16
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(250, 26)
        Me.TxtAmount.TabIndex = 10
        Me.TxtAmount.Tag = "مبلغ العملية"
        '
        'TxtGP
        '
        Me.TxtGP.Location = New System.Drawing.Point(36, 41)
        Me.TxtGP.MaxLength = 16
        Me.TxtGP.Name = "TxtGP"
        Me.TxtGP.ReadOnly = True
        Me.TxtGP.Size = New System.Drawing.Size(250, 26)
        Me.TxtGP.TabIndex = 8
        Me.TxtGP.Tag = "رقم أمر الدفع"
        Me.TxtGP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSrc
        '
        Me.TxtSrc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSrc.Location = New System.Drawing.Point(633, 165)
        Me.TxtSrc.Name = "TxtSrc"
        Me.TxtSrc.ReadOnly = True
        Me.TxtSrc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSrc.Size = New System.Drawing.Size(229, 26)
        Me.TxtSrc.TabIndex = 2080
        Me.TxtSrc.Tag = "نوع الشكوى"
        '
        'TxtOff
        '
        Me.TxtOff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOff.Location = New System.Drawing.Point(633, 76)
        Me.TxtOff.Name = "TxtOff"
        Me.TxtOff.ReadOnly = True
        Me.TxtOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOff.Size = New System.Drawing.Size(229, 26)
        Me.TxtOff.TabIndex = 2079
        Me.TxtOff.TabStop = False
        Me.TxtOff.Tag = "Email Address"
        '
        'TxtArea
        '
        Me.TxtArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtArea.Location = New System.Drawing.Point(633, 46)
        Me.TxtArea.Name = "TxtArea"
        Me.TxtArea.ReadOnly = True
        Me.TxtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtArea.Size = New System.Drawing.Size(229, 26)
        Me.TxtArea.TabIndex = 2078
        Me.TxtArea.TabStop = False
        Me.TxtArea.Tag = "Email Address"
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(1205, 46)
        Me.Label41.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label41.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label41.Size = New System.Drawing.Size(100, 20)
        Me.Label41.TabIndex = 2077
        Me.Label41.Text = "تليفون2 :"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(1205, 8)
        Me.Label37.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label37.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label37.Size = New System.Drawing.Size(100, 20)
        Me.Label37.TabIndex = 2076
        Me.Label37.Text = "تليفون1 :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(1205, 76)
        Me.Label34.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label34.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label34.Size = New System.Drawing.Size(100, 20)
        Me.Label34.TabIndex = 2063
        Me.Label34.Text = "التاريخ :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(1205, 105)
        Me.Label36.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label36.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label36.Size = New System.Drawing.Size(100, 17)
        Me.Label36.TabIndex = 2073
        Me.Label36.Text = "اسم العميل :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(1205, 134)
        Me.Label39.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label39.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label39.Size = New System.Drawing.Size(100, 17)
        Me.Label39.TabIndex = 2064
        Me.Label39.Text = "العنوان :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtComp
        '
        Me.TxtComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtComp.Location = New System.Drawing.Point(633, 134)
        Me.TxtComp.Name = "TxtComp"
        Me.TxtComp.ReadOnly = True
        Me.TxtComp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtComp.Size = New System.Drawing.Size(229, 26)
        Me.TxtComp.TabIndex = 2072
        Me.TxtComp.Tag = "نوع الشكوى"
        '
        'TxtProd
        '
        Me.TxtProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProd.Location = New System.Drawing.Point(633, 108)
        Me.TxtProd.Name = "TxtProd"
        Me.TxtProd.ReadOnly = True
        Me.TxtProd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtProd.Size = New System.Drawing.Size(229, 26)
        Me.TxtProd.TabIndex = 2071
        Me.TxtProd.Tag = "نوع الخدمة"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(1209, 189)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 34)
        Me.Label43.TabIndex = 2070
        Me.Label43.Text = "التفاصيل :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDetails
        '
        Me.TxtDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDetails.Location = New System.Drawing.Point(633, 204)
        Me.TxtDetails.Multiline = True
        Me.TxtDetails.Name = "TxtDetails"
        Me.TxtDetails.ReadOnly = True
        Me.TxtDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDetails.Size = New System.Drawing.Size(570, 142)
        Me.TxtDetails.TabIndex = 2069
        Me.TxtDetails.TabStop = False
        Me.TxtDetails.Tag = "Details"
        '
        'TxtPh2
        '
        Me.TxtPh2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh2.Location = New System.Drawing.Point(974, 45)
        Me.TxtPh2.Name = "TxtPh2"
        Me.TxtPh2.ReadOnly = True
        Me.TxtPh2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh2.Size = New System.Drawing.Size(229, 26)
        Me.TxtPh2.TabIndex = 2059
        Me.TxtPh2.Tag = "تليفون العميل 2"
        '
        'TxtDt
        '
        Me.TxtDt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDt.Location = New System.Drawing.Point(974, 79)
        Me.TxtDt.Name = "TxtDt"
        Me.TxtDt.ReadOnly = True
        Me.TxtDt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDt.Size = New System.Drawing.Size(229, 26)
        Me.TxtDt.TabIndex = 2062
        Me.TxtDt.TabStop = False
        Me.TxtDt.Tag = "Date"
        '
        'TxtNm
        '
        Me.TxtNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNm.Location = New System.Drawing.Point(974, 108)
        Me.TxtNm.Name = "TxtNm"
        Me.TxtNm.ReadOnly = True
        Me.TxtNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNm.Size = New System.Drawing.Size(229, 26)
        Me.TxtNm.TabIndex = 2058
        Me.TxtNm.TabStop = False
        Me.TxtNm.Tag = "اسم العميل"
        '
        'TxtPh1
        '
        Me.TxtPh1.AccessibleDescription = ""
        Me.TxtPh1.AccessibleName = ""
        Me.TxtPh1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh1.Location = New System.Drawing.Point(974, 7)
        Me.TxtPh1.Name = "TxtPh1"
        Me.TxtPh1.ReadOnly = True
        Me.TxtPh1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh1.Size = New System.Drawing.Size(229, 26)
        Me.TxtPh1.TabIndex = 2057
        Me.TxtPh1.Tag = "تليفون العميل 1"
        '
        'TxtAdd
        '
        Me.TxtAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd.Location = New System.Drawing.Point(974, 135)
        Me.TxtAdd.Multiline = True
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.ReadOnly = True
        Me.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdd.Size = New System.Drawing.Size(229, 50)
        Me.TxtAdd.TabIndex = 2060
        Me.TxtAdd.Tag = "Address"
        '
        'Label50
        '
        Me.Label50.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label50.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Blue
        Me.Label50.Location = New System.Drawing.Point(868, 9)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label50.Size = New System.Drawing.Size(100, 20)
        Me.Label50.TabIndex = 2068
        Me.Label50.Text = "البريد الإلكتروني :"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Blue
        Me.Label51.Location = New System.Drawing.Point(868, 110)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label51.Size = New System.Drawing.Size(100, 20)
        Me.Label51.TabIndex = 2065
        Me.Label51.Text = "نوع الخدمة :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtEmail
        '
        Me.TxtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmail.Location = New System.Drawing.Point(633, 10)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.ReadOnly = True
        Me.TxtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtEmail.Size = New System.Drawing.Size(229, 26)
        Me.TxtEmail.TabIndex = 2061
        Me.TxtEmail.TabStop = False
        Me.TxtEmail.Tag = "Email Address"
        '
        'Label52
        '
        Me.Label52.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label52.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Blue
        Me.Label52.Location = New System.Drawing.Point(868, 135)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label52.Size = New System.Drawing.Size(100, 20)
        Me.Label52.TabIndex = 2066
        Me.Label52.Text = "نوع الشكوى :"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label53
        '
        Me.Label53.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label53.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Blue
        Me.Label53.Location = New System.Drawing.Point(868, 166)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label53.Size = New System.Drawing.Size(100, 20)
        Me.Label53.TabIndex = 2075
        Me.Label53.Text = "مصدر الشكوى :"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label54
        '
        Me.Label54.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label54.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Blue
        Me.Label54.Location = New System.Drawing.Point(868, 76)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label54.Size = New System.Drawing.Size(100, 20)
        Me.Label54.TabIndex = 2074
        Me.Label54.Text = "اسم المكتب :"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label55
        '
        Me.Label55.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label55.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Blue
        Me.Label55.Location = New System.Drawing.Point(868, 46)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label55.Size = New System.Drawing.Size(100, 20)
        Me.Label55.TabIndex = 2067
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
        Me.GroupBox4.Location = New System.Drawing.Point(787, 352)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(416, 160)
        Me.GroupBox4.TabIndex = 2055
        Me.GroupBox4.TabStop = False
        '
        'TxtTrck
        '
        Me.TxtTrck.Location = New System.Drawing.Point(42, 21)
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.ReadOnly = True
        Me.TxtTrck.Size = New System.Drawing.Size(250, 26)
        Me.TxtTrck.TabIndex = 1010
        Me.TxtTrck.TabStop = False
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(298, 46)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(103, 13)
        Me.Label45.TabIndex = 29
        Me.Label45.Text = "بلد الراسل :"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(298, 73)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(103, 13)
        Me.Label46.TabIndex = 1007
        Me.Label46.Text = "بلد المرسل إلية :"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(298, 24)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(103, 13)
        Me.Label47.TabIndex = 1006
        Me.Label47.Text = "رقم الشحنة :"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDist
        '
        Me.TxtDist.Location = New System.Drawing.Point(42, 75)
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.ReadOnly = True
        Me.TxtDist.Size = New System.Drawing.Size(250, 26)
        Me.TxtDist.TabIndex = 1008
        Me.TxtDist.TabStop = False
        '
        'TxtOrgin
        '
        Me.TxtOrgin.Location = New System.Drawing.Point(42, 48)
        Me.TxtOrgin.Name = "TxtOrgin"
        Me.TxtOrgin.ReadOnly = True
        Me.TxtOrgin.Size = New System.Drawing.Size(250, 26)
        Me.TxtOrgin.TabIndex = 35
        Me.TxtOrgin.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.ForeColor = System.Drawing.Color.Black
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1335, 587)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(129, 532)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1108, 23)
        Me.Label3.TabIndex = 2059
        Me.Label3.Text = "اللون الأخضر يعني أن الشكوى مغلقة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1248, 523)
        Me.DataGridView1.TabIndex = 133
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(1266, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 59)
        Me.Button1.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.Button1, "العودة للتوزيع")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DistribTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 621)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1366, 660)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1364, 660)
        Me.Name = "DistribTicket"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "توزيع الشكاوى"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridUsrTickCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.TcktImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BtnBck As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TcktImg As PictureBox
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
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents TxtDist As TextBox
    Friend WithEvents TxtOrgin As TextBox
    Friend WithEvents TxtTrck As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatBrPnlEn As StatusBarPanel
    Friend WithEvents StatBrPnlAr As StatusBarPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseBtn As Button
    Friend WithEvents LblTickCount As Label
    Friend WithEvents LblAgentCount As Label
    Friend WithEvents BtnSubmit As Button
    Friend WithEvents LblMsg As Label
    Friend WithEvents GridUsrTickCount As DataGridView
    Friend WithEvents GridTicket As DataGridView
    Friend WithEvents UserTree As TreeView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As ToolStripMenuItem
End Class
