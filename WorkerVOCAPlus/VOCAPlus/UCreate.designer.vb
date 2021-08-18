<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCreate))
        Me.Exit_ = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.TxtNm = New System.Windows.Forms.TextBox()
        Me.TxtRNm = New System.Windows.Forms.TextBox()
        Me.TxtGSM = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.LblId = New System.Windows.Forms.Label()
        Me.LblNm = New System.Windows.Forms.Label()
        Me.LblRNm = New System.Windows.Forms.Label()
        Me.LblGsm = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblInf = New System.Windows.Forms.Label()
        Me.LblHEmail = New System.Windows.Forms.Label()
        Me.LblHNm = New System.Windows.Forms.Label()
        Me.BSave = New System.Windows.Forms.Button()
        Me.LblHRNm = New System.Windows.Forms.Label()
        Me.LblHGsm = New System.Windows.Forms.Label()
        Me.BtnUsrCreate = New System.Windows.Forms.Button()
        Me.LblHGndr = New System.Windows.Forms.Label()
        Me.LblGndr = New System.Windows.Forms.Label()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.CBxGndr = New System.Windows.Forms.ComboBox()
        Me.LblHCat = New System.Windows.Forms.Label()
        Me.LblCat = New System.Windows.Forms.Label()
        Me.TxtCat = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.FooterLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSep = New System.Windows.Forms.ToolStripSeparator()
        Me.ProgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Exit_
        '
        Me.Exit_.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Exit_.AutoEllipsis = True
        Me.Exit_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Exit_.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred
        Me.Exit_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Exit_.Cursor = System.Windows.Forms.Cursors.Default
        Me.Exit_.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Exit_.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Exit_.Location = New System.Drawing.Point(824, 505)
        Me.Exit_.Name = "Exit_"
        Me.Exit_.Size = New System.Drawing.Size(101, 31)
        Me.Exit_.TabIndex = 1
        Me.Exit_.Text = "EXIT"
        Me.Exit_.UseCompatibleTextRendering = True
        Me.Exit_.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Create"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.UserCreate
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'TxtId
        '
        Me.TxtId.BackColor = System.Drawing.Color.White
        Me.TxtId.Location = New System.Drawing.Point(184, 74)
        Me.TxtId.MaxLength = 5
        Me.TxtId.Name = "TxtId"
        Me.TxtId.ShortcutsEnabled = False
        Me.TxtId.Size = New System.Drawing.Size(119, 26)
        Me.TxtId.TabIndex = 0
        Me.TxtId.TabStop = False
        '
        'TxtNm
        '
        Me.TxtNm.BackColor = System.Drawing.Color.White
        Me.TxtNm.Location = New System.Drawing.Point(89, 117)
        Me.TxtNm.MaxLength = 15
        Me.TxtNm.Name = "TxtNm"
        Me.TxtNm.ShortcutsEnabled = False
        Me.TxtNm.Size = New System.Drawing.Size(340, 26)
        Me.TxtNm.TabIndex = 1
        Me.TxtNm.Visible = False
        '
        'TxtRNm
        '
        Me.TxtRNm.Location = New System.Drawing.Point(89, 149)
        Me.TxtRNm.MaxLength = 50
        Me.TxtRNm.Name = "TxtRNm"
        Me.TxtRNm.ShortcutsEnabled = False
        Me.TxtRNm.Size = New System.Drawing.Size(340, 26)
        Me.TxtRNm.TabIndex = 2
        Me.TxtRNm.Visible = False
        '
        'TxtGSM
        '
        Me.TxtGSM.Location = New System.Drawing.Point(89, 214)
        Me.TxtGSM.MaxLength = 11
        Me.TxtGSM.Name = "TxtGSM"
        Me.TxtGSM.ShortcutsEnabled = False
        Me.TxtGSM.Size = New System.Drawing.Size(340, 26)
        Me.TxtGSM.TabIndex = 4
        Me.TxtGSM.Visible = False
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(89, 246)
        Me.TxtEmail.MaxLength = 40
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.ShortcutsEnabled = False
        Me.TxtEmail.Size = New System.Drawing.Size(340, 26)
        Me.TxtEmail.TabIndex = 5
        Me.TxtEmail.Visible = False
        '
        'LblId
        '
        Me.LblId.Location = New System.Drawing.Point(107, 77)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(71, 19)
        Me.LblId.TabIndex = 13
        Me.LblId.Text = "User Id:"
        Me.LblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNm
        '
        Me.LblNm.BackColor = System.Drawing.Color.Transparent
        Me.LblNm.Location = New System.Drawing.Point(4, 117)
        Me.LblNm.Name = "LblNm"
        Me.LblNm.Size = New System.Drawing.Size(82, 19)
        Me.LblNm.TabIndex = 14
        Me.LblNm.Text = "User Name:"
        Me.LblNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblNm.Visible = False
        '
        'LblRNm
        '
        Me.LblRNm.BackColor = System.Drawing.Color.Transparent
        Me.LblRNm.Location = New System.Drawing.Point(4, 149)
        Me.LblRNm.Name = "LblRNm"
        Me.LblRNm.Size = New System.Drawing.Size(82, 19)
        Me.LblRNm.TabIndex = 15
        Me.LblRNm.Text = "Real Name"
        Me.LblRNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblRNm.Visible = False
        '
        'LblGsm
        '
        Me.LblGsm.BackColor = System.Drawing.Color.Transparent
        Me.LblGsm.Location = New System.Drawing.Point(4, 214)
        Me.LblGsm.Name = "LblGsm"
        Me.LblGsm.Size = New System.Drawing.Size(82, 19)
        Me.LblGsm.TabIndex = 18
        Me.LblGsm.Text = "GSM:"
        Me.LblGsm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblGsm.Visible = False
        '
        'LblEmail
        '
        Me.LblEmail.BackColor = System.Drawing.Color.Transparent
        Me.LblEmail.Location = New System.Drawing.Point(4, 246)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(82, 19)
        Me.LblEmail.TabIndex = 19
        Me.LblEmail.Text = "Email:"
        Me.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEmail.Visible = False
        '
        'LblInf
        '
        Me.LblInf.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.LblInf.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.LblInf.ForeColor = System.Drawing.Color.Red
        Me.LblInf.Location = New System.Drawing.Point(45, 376)
        Me.LblInf.Name = "LblInf"
        Me.LblInf.Size = New System.Drawing.Size(452, 48)
        Me.LblInf.TabIndex = 20
        Me.LblInf.Text = "Important Information: (Please Read Before Continue...)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* All Required data are " &
    "set we are ready to save." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* User Default PassWord is 0000 He can change it when" &
    " he login whatever has his need." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblInf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblInf.Visible = False
        '
        'LblHEmail
        '
        Me.LblHEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHEmail.BackColor = System.Drawing.Color.Transparent
        Me.LblHEmail.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHEmail.Location = New System.Drawing.Point(430, 246)
        Me.LblHEmail.Name = "LblHEmail"
        Me.LblHEmail.Size = New System.Drawing.Size(275, 19)
        Me.LblHEmail.TabIndex = 26
        Me.LblHEmail.Text = "Enter a valid Email"
        Me.LblHEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHEmail.Visible = False
        '
        'LblHNm
        '
        Me.LblHNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHNm.BackColor = System.Drawing.Color.Transparent
        Me.LblHNm.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHNm.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHNm.Location = New System.Drawing.Point(430, 117)
        Me.LblHNm.Name = "LblHNm"
        Me.LblHNm.Size = New System.Drawing.Size(275, 37)
        Me.LblHNm.TabIndex = 22
        Me.LblHNm.Text = "Access Name at least 3 characters and not more than 15 (alphanumeric no space)"
        Me.LblHNm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHNm.Visible = False
        '
        'BSave
        '
        Me.BSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSave.AutoEllipsis = True
        Me.BSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BSave.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.BSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSave.Location = New System.Drawing.Point(717, 505)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(101, 31)
        Me.BSave.TabIndex = 27
        Me.BSave.Text = " SAVE"
        Me.BSave.UseCompatibleTextRendering = True
        Me.BSave.UseVisualStyleBackColor = True
        '
        'LblHRNm
        '
        Me.LblHRNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHRNm.BackColor = System.Drawing.Color.Transparent
        Me.LblHRNm.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHRNm.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHRNm.Location = New System.Drawing.Point(430, 149)
        Me.LblHRNm.Name = "LblHRNm"
        Me.LblHRNm.Size = New System.Drawing.Size(275, 37)
        Me.LblHRNm.TabIndex = 29
        Me.LblHRNm.Text = "Real Name at least 3 characters and not more than 50 (alphabetic with space)"
        Me.LblHRNm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHRNm.Visible = False
        '
        'LblHGsm
        '
        Me.LblHGsm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHGsm.BackColor = System.Drawing.Color.Transparent
        Me.LblHGsm.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHGsm.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHGsm.Location = New System.Drawing.Point(430, 214)
        Me.LblHGsm.Name = "LblHGsm"
        Me.LblHGsm.Size = New System.Drawing.Size(275, 19)
        Me.LblHGsm.TabIndex = 31
        Me.LblHGsm.Text = "11 Numeric as a valid  phone number"
        Me.LblHGsm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHGsm.Visible = False
        '
        'BtnUsrCreate
        '
        Me.BtnUsrCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUsrCreate.AutoEllipsis = True
        Me.BtnUsrCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnUsrCreate.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recpurple
        Me.BtnUsrCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUsrCreate.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnUsrCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnUsrCreate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUsrCreate.Location = New System.Drawing.Point(610, 505)
        Me.BtnUsrCreate.Name = "BtnUsrCreate"
        Me.BtnUsrCreate.Size = New System.Drawing.Size(101, 31)
        Me.BtnUsrCreate.TabIndex = 32
        Me.BtnUsrCreate.Text = "Create"
        Me.BtnUsrCreate.UseCompatibleTextRendering = True
        Me.BtnUsrCreate.UseVisualStyleBackColor = True
        '
        'LblHGndr
        '
        Me.LblHGndr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHGndr.BackColor = System.Drawing.Color.Transparent
        Me.LblHGndr.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHGndr.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHGndr.Location = New System.Drawing.Point(430, 184)
        Me.LblHGndr.Name = "LblHGndr"
        Me.LblHGndr.Size = New System.Drawing.Size(275, 19)
        Me.LblHGndr.TabIndex = 35
        Me.LblHGndr.Text = "Select One"
        Me.LblHGndr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHGndr.Visible = False
        '
        'LblGndr
        '
        Me.LblGndr.BackColor = System.Drawing.Color.Transparent
        Me.LblGndr.Location = New System.Drawing.Point(4, 184)
        Me.LblGndr.Name = "LblGndr"
        Me.LblGndr.Size = New System.Drawing.Size(82, 19)
        Me.LblGndr.TabIndex = 34
        Me.LblGndr.Text = "Gender:"
        Me.LblGndr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblGndr.Visible = False
        '
        'ImgLst
        '
        Me.ImgLst.ImageStream = CType(resources.GetObject("ImgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLst.Images.SetKeyName(0, "arrow-right-3.png")
        Me.ImgLst.Images.SetKeyName(1, "arrow-right.png")
        Me.ImgLst.Images.SetKeyName(2, "arrow-right-double-3.png")
        Me.ImgLst.Images.SetKeyName(3, "arrow-right-double.png")
        '
        'UserTree
        '
        Me.UserTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.ImageIndex = 0
        Me.UserTree.ImageList = Me.ImgLst
        Me.UserTree.Location = New System.Drawing.Point(686, 3)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.SelectedImageIndex = 0
        Me.UserTree.Size = New System.Drawing.Size(242, 97)
        Me.UserTree.StateImageList = Me.ImgLst
        Me.UserTree.TabIndex = 6
        Me.UserTree.TabStop = False
        Me.UserTree.Visible = False
        '
        'CBxGndr
        '
        Me.CBxGndr.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBxGndr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBxGndr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CBxGndr.FormattingEnabled = True
        Me.CBxGndr.Items.AddRange(New Object() {"Male", "Female"})
        Me.CBxGndr.Location = New System.Drawing.Point(89, 181)
        Me.CBxGndr.MaxDropDownItems = 2
        Me.CBxGndr.MaxLength = 6
        Me.CBxGndr.Name = "CBxGndr"
        Me.CBxGndr.Size = New System.Drawing.Size(340, 27)
        Me.CBxGndr.TabIndex = 3
        Me.CBxGndr.Visible = False
        '
        'LblHCat
        '
        Me.LblHCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHCat.BackColor = System.Drawing.Color.Transparent
        Me.LblHCat.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHCat.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblHCat.Location = New System.Drawing.Point(430, 278)
        Me.LblHCat.Name = "LblHCat"
        Me.LblHCat.Size = New System.Drawing.Size(91, 19)
        Me.LblHCat.TabIndex = 38
        Me.LblHCat.Text = "Select from tree"
        Me.LblHCat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHCat.Visible = False
        '
        'LblCat
        '
        Me.LblCat.BackColor = System.Drawing.Color.Transparent
        Me.LblCat.Location = New System.Drawing.Point(4, 278)
        Me.LblCat.Name = "LblCat"
        Me.LblCat.Size = New System.Drawing.Size(82, 19)
        Me.LblCat.TabIndex = 37
        Me.LblCat.Text = "Category:"
        Me.LblCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblCat.Visible = False
        '
        'TxtCat
        '
        Me.TxtCat.Location = New System.Drawing.Point(89, 278)
        Me.TxtCat.MaxLength = 40
        Me.TxtCat.Name = "TxtCat"
        Me.TxtCat.ShortcutsEnabled = False
        Me.TxtCat.Size = New System.Drawing.Size(340, 26)
        Me.TxtCat.TabIndex = 36
        Me.TxtCat.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 536)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(927, 25)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FooterLbl
        '
        Me.FooterLbl.AutoSize = False
        Me.FooterLbl.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.FooterLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FooterLbl.Name = "FooterLbl"
        Me.FooterLbl.Size = New System.Drawing.Size(400, 22)
        Me.FooterLbl.Text = "Status"
        Me.FooterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSep
        '
        Me.ToolStripSep.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripSep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripSep.Name = "ToolStripSep"
        Me.ToolStripSep.Size = New System.Drawing.Size(6, 25)
        '
        'ProgBar
        '
        Me.ProgBar.BackColor = System.Drawing.Color.Lime
        Me.ProgBar.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgBar.Maximum = 7
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(200, 22)
        Me.ProgBar.Step = 1
        Me.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(886, 536)
        Me.TextBox1.MaxLength = 40
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ShortcutsEnabled = False
        Me.TextBox1.Size = New System.Drawing.Size(39, 26)
        Me.TextBox1.TabIndex = 40
        '
        'UCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.VocaWtr
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(927, 561)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LblHCat)
        Me.Controls.Add(Me.LblCat)
        Me.Controls.Add(Me.TxtCat)
        Me.Controls.Add(Me.CBxGndr)
        Me.Controls.Add(Me.UserTree)
        Me.Controls.Add(Me.LblHGndr)
        Me.Controls.Add(Me.LblGndr)
        Me.Controls.Add(Me.BtnUsrCreate)
        Me.Controls.Add(Me.LblHGsm)
        Me.Controls.Add(Me.LblHRNm)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.LblHEmail)
        Me.Controls.Add(Me.LblHNm)
        Me.Controls.Add(Me.LblInf)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.LblGsm)
        Me.Controls.Add(Me.LblRNm)
        Me.Controls.Add(Me.LblNm)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.TxtGSM)
        Me.Controls.Add(Me.TxtRNm)
        Me.Controls.Add(Me.TxtNm)
        Me.Controls.Add(Me.TxtId)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Exit_)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(1000, 600)
        Me.MinimumSize = New System.Drawing.Size(805, 550)
        Me.Name = "UCreate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New User"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Exit_ As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TxtId As TextBox
    Friend WithEvents TxtNm As TextBox
    Friend WithEvents TxtRNm As TextBox
    Friend WithEvents TxtGSM As TextBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents LblId As Label
    Friend WithEvents LblNm As Label
    Friend WithEvents LblRNm As Label
    Friend WithEvents LblGsm As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents LblInf As Label
    Friend WithEvents LblHEmail As Label
    Friend WithEvents LblHNm As Label
    Friend WithEvents BSave As Button
    Friend WithEvents LblHRNm As Label
    Friend WithEvents LblHGsm As Label
    Friend WithEvents BtnUsrCreate As Button
    Friend WithEvents LblHGndr As Label
    Friend WithEvents LblGndr As Label
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents UserTree As TreeView
    Friend WithEvents CBxGndr As ComboBox
    Friend WithEvents LblHCat As Label
    Friend WithEvents LblCat As Label
    Friend WithEvents TxtCat As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents FooterLbl As ToolStripLabel
    Friend WithEvents ProgBar As ToolStripProgressBar
    Friend WithEvents ToolStripSep As ToolStripSeparator
    Friend WithEvents TextBox1 As TextBox
End Class
