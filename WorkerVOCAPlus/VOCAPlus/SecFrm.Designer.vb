<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SecFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecFrm))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tab")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("System Varible")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Free Button")
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.SecTree = New System.Windows.Forms.TreeView()
        Me.BtnAply = New System.Windows.Forms.Button()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.BtnCls = New System.Windows.Forms.Button()
        Me.BtnSerch = New System.Windows.Forms.Button()
        Me.TreeSrchBx = New System.Windows.Forms.TextBox()
        Me.BtnNxt = New System.Windows.Forms.Button()
        Me.BtnPrvs = New System.Windows.Forms.Button()
        Me.LblCnt = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnOpn = New System.Windows.Forms.Button()
        Me.LblSecLvl = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
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
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 595)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel2, Me.StatusBarPanel1})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1232, 29)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 127
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 616
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 616
        '
        'SecTree
        '
        Me.SecTree.CheckBoxes = True
        Me.SecTree.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecTree.Location = New System.Drawing.Point(260, 0)
        Me.SecTree.Margin = New System.Windows.Forms.Padding(0)
        Me.SecTree.Name = "SecTree"
        TreeNode1.Name = "Tab"
        TreeNode1.Text = "Tab"
        TreeNode2.Name = "SystemVarible"
        TreeNode2.Text = "System Varible"
        TreeNode3.Name = "FreeButton"
        TreeNode3.Text = "Free Button"
        Me.SecTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.SecTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SecTree.RightToLeftLayout = True
        Me.SecTree.Size = New System.Drawing.Size(421, 586)
        Me.SecTree.TabIndex = 130
        Me.SecTree.TabStop = False
        '
        'BtnAply
        '
        Me.BtnAply.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnAply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAply.FlatAppearance.BorderSize = 0
        Me.BtnAply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAply.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnAply.Location = New System.Drawing.Point(5, 6)
        Me.BtnAply.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnAply.Name = "BtnAply"
        Me.BtnAply.Size = New System.Drawing.Size(100, 38)
        Me.BtnAply.TabIndex = 133
        Me.BtnAply.Text = "Apply"
        Me.BtnAply.UseVisualStyleBackColor = True
        '
        'UserTree
        '
        Me.UserTree.BackColor = System.Drawing.SystemColors.Window
        Me.UserTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.Location = New System.Drawing.Point(988, 0)
        Me.UserTree.Margin = New System.Windows.Forms.Padding(0)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(244, 586)
        Me.UserTree.TabIndex = 121
        Me.UserTree.TabStop = False
        '
        'BtnCls
        '
        Me.BtnCls.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred
        Me.BtnCls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCls.FlatAppearance.BorderSize = 0
        Me.BtnCls.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCls.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnCls.Location = New System.Drawing.Point(7, 4)
        Me.BtnCls.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCls.Name = "BtnCls"
        Me.BtnCls.Size = New System.Drawing.Size(100, 38)
        Me.BtnCls.TabIndex = 134
        Me.BtnCls.Text = "Close"
        Me.BtnCls.UseVisualStyleBackColor = True
        '
        'BtnSerch
        '
        Me.BtnSerch.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSerch.FlatAppearance.BorderSize = 0
        Me.BtnSerch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSerch.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnSerch.Location = New System.Drawing.Point(7, 5)
        Me.BtnSerch.Margin = New System.Windows.Forms.Padding(3, 3, 80, 3)
        Me.BtnSerch.Name = "BtnSerch"
        Me.BtnSerch.Size = New System.Drawing.Size(100, 38)
        Me.BtnSerch.TabIndex = 135
        Me.BtnSerch.Text = "Search"
        Me.BtnSerch.UseVisualStyleBackColor = True
        '
        'TreeSrchBx
        '
        Me.TreeSrchBx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FlowLayoutPanel1.SetFlowBreak(Me.TreeSrchBx, True)
        Me.TreeSrchBx.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TreeSrchBx.Location = New System.Drawing.Point(30, 56)
        Me.TreeSrchBx.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.TreeSrchBx.Name = "TreeSrchBx"
        Me.TreeSrchBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeSrchBx.Size = New System.Drawing.Size(257, 26)
        Me.TreeSrchBx.TabIndex = 136
        Me.TreeSrchBx.TabStop = False
        Me.TreeSrchBx.Tag = "اسم العميل"
        '
        'BtnNxt
        '
        Me.BtnNxt.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Next
        Me.BtnNxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNxt.FlatAppearance.BorderSize = 0
        Me.BtnNxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNxt.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnNxt.Location = New System.Drawing.Point(230, 141)
        Me.BtnNxt.Margin = New System.Windows.Forms.Padding(3, 3, 45, 3)
        Me.BtnNxt.Name = "BtnNxt"
        Me.BtnNxt.Size = New System.Drawing.Size(32, 32)
        Me.BtnNxt.TabIndex = 137
        Me.BtnNxt.UseVisualStyleBackColor = True
        '
        'BtnPrvs
        '
        Me.BtnPrvs.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Prev
        Me.BtnPrvs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrvs.FlatAppearance.BorderSize = 0
        Me.BtnPrvs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FlowLayoutPanel1.SetFlowBreak(Me.BtnPrvs, True)
        Me.BtnPrvs.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnPrvs.Location = New System.Drawing.Point(86, 141)
        Me.BtnPrvs.Name = "BtnPrvs"
        Me.BtnPrvs.Size = New System.Drawing.Size(32, 32)
        Me.BtnPrvs.TabIndex = 138
        Me.BtnPrvs.UseVisualStyleBackColor = True
        '
        'LblCnt
        '
        Me.LblCnt.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblCnt.Location = New System.Drawing.Point(124, 145)
        Me.LblCnt.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.LblCnt.Name = "LblCnt"
        Me.LblCnt.Size = New System.Drawing.Size(100, 23)
        Me.LblCnt.TabIndex = 139
        Me.LblCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.FlowLayoutPanel1.SetFlowBreak(Me.Label4, True)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(30, 179)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 23)
        Me.Label4.TabIndex = 2061
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnOpn
        '
        Me.BtnOpn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnOpn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOpn.FlatAppearance.BorderSize = 0
        Me.BtnOpn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpn.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.BtnOpn.Location = New System.Drawing.Point(7, 4)
        Me.BtnOpn.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnOpn.Name = "BtnOpn"
        Me.BtnOpn.Size = New System.Drawing.Size(100, 38)
        Me.BtnOpn.TabIndex = 2062
        Me.BtnOpn.Text = "Check"
        Me.BtnOpn.UseVisualStyleBackColor = True
        '
        'LblSecLvl
        '
        Me.FlowLayoutPanel1.SetFlowBreak(Me.LblSecLvl, True)
        Me.LblSecLvl.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblSecLvl.ForeColor = System.Drawing.Color.Blue
        Me.LblSecLvl.Location = New System.Drawing.Point(30, 208)
        Me.LblSecLvl.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.LblSecLvl.Name = "LblSecLvl"
        Me.LblSecLvl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblSecLvl.Size = New System.Drawing.Size(257, 23)
        Me.LblSecLvl.TabIndex = 2063
        Me.LblSecLvl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel6)
        Me.FlowLayoutPanel1.Controls.Add(Me.TreeSrchBx)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnNxt)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblCnt)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnPrvs)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblSecLvl)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(681, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(307, 586)
        Me.FlowLayoutPanel1.TabIndex = 2064
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.BtnOpn)
        Me.Panel6.Location = New System.Drawing.Point(112, 3)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 3, 80, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(115, 47)
        Me.Panel6.TabIndex = 2070
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.BtnSerch)
        Me.FlowLayoutPanel1.SetFlowBreak(Me.Panel3, True)
        Me.Panel3.Location = New System.Drawing.Point(112, 88)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 3, 80, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(115, 47)
        Me.Panel3.TabIndex = 2069
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.BtnCls)
        Me.Panel4.Location = New System.Drawing.Point(162, 237)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(115, 47)
        Me.Panel4.TabIndex = 2067
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.BtnAply)
        Me.Panel5.Location = New System.Drawing.Point(29, 237)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(110, 47)
        Me.Panel5.TabIndex = 2068
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Controls.Add(Me.UserTree)
        Me.FlowLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.FlowLayoutPanel2.Controls.Add(Me.SecTree)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(1232, 595)
        Me.FlowLayoutPanel2.TabIndex = 2065
        '
        'SecFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1232, 624)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.StatusBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(-3, 50)
        Me.Name = "SecFrm"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Security Setup"
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatusBarPanel2 As StatusBarPanel
    Friend WithEvents StatusBarPanel1 As StatusBarPanel
    Friend WithEvents SecTree As TreeView
    Friend WithEvents BtnAply As Button
    Friend WithEvents UserTree As TreeView
    Friend WithEvents BtnCls As Button
    Friend WithEvents BtnSerch As Button
    Friend WithEvents TreeSrchBx As TextBox
    Friend WithEvents BtnNxt As Button
    Friend WithEvents BtnPrvs As Button
    Friend WithEvents LblCnt As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnOpn As Button
    Friend WithEvents LblSecLvl As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
End Class
