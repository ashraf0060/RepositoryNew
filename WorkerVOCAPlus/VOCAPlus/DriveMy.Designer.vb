<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DriveMy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DriveMy))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("")
        Me.BtnRnm = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CombDir = New System.Windows.Forms.ComboBox()
        Me.BtnCreatDir = New System.Windows.Forms.Button()
        Me.BtnDwnld = New System.Windows.Forms.Button()
        Me.LblUsrPw = New System.Windows.Forms.Label()
        Me.LblUsrNm = New System.Windows.Forms.Label()
        Me.Lblmssg = New System.Windows.Forms.Label()
        Me.BtnUplod = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnBrws = New System.Windows.Forms.Button()
        Me.BtnHome = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnLogn = New System.Windows.Forms.Button()
        Me.TxtUsrNm = New System.Windows.Forms.TextBox()
        Me.TxtUsrPass = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SnOutBt = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBck2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnRnm
        '
        Me.BtnRnm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRnm.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Rename
        Me.BtnRnm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRnm.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnRnm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRnm.Location = New System.Drawing.Point(183, 19)
        Me.BtnRnm.Name = "BtnRnm"
        Me.BtnRnm.Size = New System.Drawing.Size(32, 32)
        Me.BtnRnm.TabIndex = 2168
        Me.ToolTip1.SetToolTip(Me.BtnRnm, "Rename")
        Me.BtnRnm.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.delete1
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Location = New System.Drawing.Point(141, 19)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(32, 32)
        Me.BtnDelete.TabIndex = 2167
        Me.ToolTip1.SetToolTip(Me.BtnDelete, "Delete")
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(178, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(846, 26)
        Me.Label1.TabIndex = 2166
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CombDir
        '
        Me.CombDir.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CombDir.FormattingEnabled = True
        Me.CombDir.Location = New System.Drawing.Point(238, 44)
        Me.CombDir.Name = "CombDir"
        Me.CombDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CombDir.Size = New System.Drawing.Size(142, 27)
        Me.CombDir.TabIndex = 2165
        '
        'BtnCreatDir
        '
        Me.BtnCreatDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCreatDir.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.NewFolder
        Me.BtnCreatDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCreatDir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnCreatDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCreatDir.Location = New System.Drawing.Point(99, 19)
        Me.BtnCreatDir.Name = "BtnCreatDir"
        Me.BtnCreatDir.Size = New System.Drawing.Size(32, 32)
        Me.BtnCreatDir.TabIndex = 2164
        Me.ToolTip1.SetToolTip(Me.BtnCreatDir, "New Directory")
        Me.BtnCreatDir.UseVisualStyleBackColor = True
        '
        'BtnDwnld
        '
        Me.BtnDwnld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDwnld.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Download
        Me.BtnDwnld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDwnld.Location = New System.Drawing.Point(267, 19)
        Me.BtnDwnld.Name = "BtnDwnld"
        Me.BtnDwnld.Size = New System.Drawing.Size(72, 32)
        Me.BtnDwnld.TabIndex = 2163
        Me.ToolTip1.SetToolTip(Me.BtnDwnld, "Download")
        Me.BtnDwnld.UseVisualStyleBackColor = True
        '
        'LblUsrPw
        '
        Me.LblUsrPw.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrPw.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsrPw.Location = New System.Drawing.Point(145, 97)
        Me.LblUsrPw.Name = "LblUsrPw"
        Me.LblUsrPw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblUsrPw.Size = New System.Drawing.Size(87, 19)
        Me.LblUsrPw.TabIndex = 2162
        Me.LblUsrPw.Text = "Password :"
        Me.LblUsrPw.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsrNm
        '
        Me.LblUsrNm.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsrNm.Location = New System.Drawing.Point(457, 28)
        Me.LblUsrNm.Name = "LblUsrNm"
        Me.LblUsrNm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblUsrNm.Size = New System.Drawing.Size(91, 19)
        Me.LblUsrNm.TabIndex = 2161
        Me.LblUsrNm.Text = "User Name :"
        Me.LblUsrNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblUsrNm.Visible = False
        '
        'Lblmssg
        '
        Me.Lblmssg.BackColor = System.Drawing.Color.Transparent
        Me.Lblmssg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Lblmssg.ForeColor = System.Drawing.Color.Green
        Me.Lblmssg.Location = New System.Drawing.Point(702, 543)
        Me.Lblmssg.Name = "Lblmssg"
        Me.Lblmssg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lblmssg.Size = New System.Drawing.Size(404, 30)
        Me.Lblmssg.TabIndex = 2160
        Me.Lblmssg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnUplod
        '
        Me.BtnUplod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUplod.BackgroundImage = CType(resources.GetObject("BtnUplod.BackgroundImage"), System.Drawing.Image)
        Me.BtnUplod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUplod.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnUplod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUplod.Location = New System.Drawing.Point(225, 19)
        Me.BtnUplod.Name = "BtnUplod"
        Me.BtnUplod.Size = New System.Drawing.Size(32, 32)
        Me.BtnUplod.TabIndex = 2159
        Me.ToolTip1.SetToolTip(Me.BtnUplod, "Upload")
        Me.BtnUplod.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(635, 194)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(336, 26)
        Me.TextBox1.TabIndex = 2158
        '
        'BtnBrws
        '
        Me.BtnBrws.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrws.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.browse_button_png_th
        Me.BtnBrws.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrws.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBrws.Location = New System.Drawing.Point(977, 193)
        Me.BtnBrws.Name = "BtnBrws"
        Me.BtnBrws.Size = New System.Drawing.Size(60, 27)
        Me.BtnBrws.TabIndex = 2157
        Me.ToolTip1.SetToolTip(Me.BtnBrws, "Browse")
        Me.BtnBrws.UseVisualStyleBackColor = True
        '
        'BtnHome
        '
        Me.BtnHome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnHome.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.home
        Me.BtnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnHome.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHome.Location = New System.Drawing.Point(57, 19)
        Me.BtnHome.Name = "BtnHome"
        Me.BtnHome.Size = New System.Drawing.Size(32, 32)
        Me.BtnHome.TabIndex = 2156
        Me.ToolTip1.SetToolTip(Me.BtnHome, "Home")
        Me.BtnHome.UseVisualStyleBackColor = True
        '
        'BtnBack
        '
        Me.BtnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBack.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back1
        Me.BtnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnBack.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBack.Location = New System.Drawing.Point(169, 44)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(32, 32)
        Me.BtnBack.TabIndex = 2155
        Me.BtnBack.UseVisualStyleBackColor = True
        Me.BtnBack.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(577, 226)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(638, 314)
        Me.DataGridView1.TabIndex = 2154
        '
        'BtnLogn
        '
        Me.BtnLogn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnLogn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLogn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogn.Location = New System.Drawing.Point(386, 73)
        Me.BtnLogn.Name = "BtnLogn"
        Me.BtnLogn.Size = New System.Drawing.Size(63, 27)
        Me.BtnLogn.TabIndex = 2153
        Me.BtnLogn.Text = "Login"
        Me.ToolTip1.SetToolTip(Me.BtnLogn, "Login")
        Me.BtnLogn.UseVisualStyleBackColor = True
        '
        'TxtUsrNm
        '
        Me.TxtUsrNm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtUsrNm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrNm.Location = New System.Drawing.Point(554, 29)
        Me.TxtUsrNm.Name = "TxtUsrNm"
        Me.TxtUsrNm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtUsrNm.Size = New System.Drawing.Size(142, 19)
        Me.TxtUsrNm.TabIndex = 2151
        Me.TxtUsrNm.Visible = False
        '
        'TxtUsrPass
        '
        Me.TxtUsrPass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtUsrPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrPass.Location = New System.Drawing.Point(238, 99)
        Me.TxtUsrPass.Name = "TxtUsrPass"
        Me.TxtUsrPass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtUsrPass.Size = New System.Drawing.Size(142, 19)
        Me.TxtUsrPass.TabIndex = 2152
        Me.TxtUsrPass.UseSystemPasswordChar = True
        '
        'SnOutBt
        '
        Me.SnOutBt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recyellow
        Me.SnOutBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SnOutBt.Location = New System.Drawing.Point(12, 145)
        Me.SnOutBt.Name = "SnOutBt"
        Me.SnOutBt.Size = New System.Drawing.Size(92, 28)
        Me.SnOutBt.TabIndex = 2173
        Me.SnOutBt.Text = "Sign Out"
        Me.ToolTip1.SetToolTip(Me.SnOutBt, "تسجيل الخروج")
        Me.SnOutBt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBck2)
        Me.GroupBox1.Controls.Add(Me.BtnHome)
        Me.GroupBox1.Controls.Add(Me.BtnRnm)
        Me.GroupBox1.Controls.Add(Me.BtnDelete)
        Me.GroupBox1.Controls.Add(Me.BtnUplod)
        Me.GroupBox1.Controls.Add(Me.BtnDwnld)
        Me.GroupBox1.Controls.Add(Me.BtnCreatDir)
        Me.GroupBox1.Location = New System.Drawing.Point(635, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 65)
        Me.GroupBox1.TabIndex = 2169
        Me.GroupBox1.TabStop = False
        '
        'BtnBck2
        '
        Me.BtnBck2.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Back1
        Me.BtnBck2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBck2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBck2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBck2.Location = New System.Drawing.Point(15, 19)
        Me.BtnBck2.Name = "BtnBck2"
        Me.BtnBck2.Size = New System.Drawing.Size(32, 32)
        Me.BtnBck2.TabIndex = 2175
        Me.BtnBck2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(140, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 26)
        Me.Label2.TabIndex = 2170
        Me.Label2.Text = "FTP/"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Usrresm
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(115, 137)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2171
        Me.PictureBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(238, 72)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox1.Size = New System.Drawing.Size(142, 26)
        Me.CheckBox1.TabIndex = 2174
        Me.CheckBox1.Text = "Admin User"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(56, 179)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = ""
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.PathSeparator = "/"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(490, 361)
        Me.TreeView1.TabIndex = 2175
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Folder.png")
        '
        'DriveMy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.FTP
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1227, 600)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.BtnLogn)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.SnOutBt)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CombDir)
        Me.Controls.Add(Me.LblUsrPw)
        Me.Controls.Add(Me.LblUsrNm)
        Me.Controls.Add(Me.Lblmssg)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnBrws)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TxtUsrNm)
        Me.Controls.Add(Me.TxtUsrPass)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DriveMy"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DriveMy"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnRnm As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CombDir As ComboBox
    Friend WithEvents BtnCreatDir As Button
    Friend WithEvents BtnDwnld As Button
    Friend WithEvents LblUsrPw As Label
    Friend WithEvents LblUsrNm As Label
    Friend WithEvents Lblmssg As Label
    Friend WithEvents BtnUplod As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnBrws As Button
    Friend WithEvents BtnHome As Button
    Friend WithEvents BtnBack As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnLogn As Button
    Friend WithEvents TxtUsrNm As TextBox
    Friend WithEvents TxtUsrPass As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SnOutBt As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents BtnBck2 As Button
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImageList1 As ImageList
End Class
