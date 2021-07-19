<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TotView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TotView))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.GridTicket1 = New System.Windows.Forms.DataGridView()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblFolwDy = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblClsUpted = New System.Windows.Forms.Label()
        Me.LblRecived = New System.Windows.Forms.Label()
        Me.LblRead = New System.Windows.Forms.Label()
        Me.LblCls = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblEvt = New System.Windows.Forms.Label()
        Me.LblUnrd = New System.Windows.Forms.Label()
        Me.LblOpen = New System.Windows.Forms.Label()
        Me.LblReOpen = New System.Windows.Forms.Label()
        Me.LblNoFollow = New System.Windows.Forms.Label()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatBrPnlEn = New System.Windows.Forms.StatusBarPanel()
        Me.StatBrPnlAr = New System.Windows.Forms.StatusBarPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.GridTicket1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserTree
        '
        Me.UserTree.BackColor = System.Drawing.SystemColors.Window
        Me.UserTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.Location = New System.Drawing.Point(12, 12)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowNodeToolTips = True
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(390, 508)
        Me.UserTree.TabIndex = 2123
        Me.UserTree.TabStop = False
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
        'GridTicket1
        '
        Me.GridTicket1.AllowUserToAddRows = False
        Me.GridTicket1.AllowUserToDeleteRows = False
        Me.GridTicket1.BackgroundColor = System.Drawing.Color.White
        Me.GridTicket1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.GridTicket1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTicket1.Location = New System.Drawing.Point(408, 12)
        Me.GridTicket1.MultiSelect = False
        Me.GridTicket1.Name = "GridTicket1"
        Me.GridTicket1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridTicket1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GridTicket1.Size = New System.Drawing.Size(924, 508)
        Me.GridTicket1.TabIndex = 2124
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
        Me.CloseBtn.Location = New System.Drawing.Point(1268, 526)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(64, 64)
        Me.CloseBtn.TabIndex = 2133
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.LblFolwDy)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblClsUpted)
        Me.GroupBox1.Controls.Add(Me.LblRecived)
        Me.GroupBox1.Controls.Add(Me.LblRead)
        Me.GroupBox1.Controls.Add(Me.LblCls)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LblEvt)
        Me.GroupBox1.Controls.Add(Me.LblUnrd)
        Me.GroupBox1.Controls.Add(Me.LblOpen)
        Me.GroupBox1.Controls.Add(Me.LblReOpen)
        Me.GroupBox1.Controls.Add(Me.LblNoFollow)
        Me.GroupBox1.Location = New System.Drawing.Point(206, 526)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1056, 75)
        Me.GroupBox1.TabIndex = 2134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تصفيه"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label12.Location = New System.Drawing.Point(450, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 20)
        Me.Label12.TabIndex = 2059
        Me.Label12.Text = "تعامل اليوم"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFolwDy
        '
        Me.LblFolwDy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFolwDy.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblFolwDy.Location = New System.Drawing.Point(450, 48)
        Me.LblFolwDy.Name = "LblFolwDy"
        Me.LblFolwDy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblFolwDy.Size = New System.Drawing.Size(80, 20)
        Me.LblFolwDy.TabIndex = 2058
        Me.LblFolwDy.Text = "Lbl5"
        Me.LblFolwDy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(18, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 20)
        Me.Label11.TabIndex = 2057
        Me.Label11.Text = "تحديثات شكاوى مغلقة"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(103, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 2056
        Me.Label10.Text = "استلام اليوم"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label9.Location = New System.Drawing.Point(189, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 2055
        Me.Label9.Text = "تحديثات مقروءه"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(277, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 2054
        Me.Label8.Text = "إغلاق اليوم"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(363, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 2053
        Me.Label7.Text = "تحديثات اليوم"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(538, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 2052
        Me.Label6.Text = "غير مقروء"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(625, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 2051
        Me.Label5.Text = "معادة الفتح"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(716, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 2050
        Me.Label3.Text = "بدون متابعة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(796, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 2049
        Me.Label2.Text = "مفتوحة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(932, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 2048
        Me.Label1.Text = "عدد الموظفين"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClsUpted
        '
        Me.LblClsUpted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblClsUpted.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblClsUpted.Location = New System.Drawing.Point(18, 48)
        Me.LblClsUpted.Name = "LblClsUpted"
        Me.LblClsUpted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblClsUpted.Size = New System.Drawing.Size(80, 20)
        Me.LblClsUpted.TabIndex = 2047
        Me.LblClsUpted.Text = "Lbl10"
        Me.LblClsUpted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRecived
        '
        Me.LblRecived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRecived.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblRecived.Location = New System.Drawing.Point(103, 48)
        Me.LblRecived.Name = "LblRecived"
        Me.LblRecived.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblRecived.Size = New System.Drawing.Size(80, 20)
        Me.LblRecived.TabIndex = 2046
        Me.LblRecived.Text = "Lbl9"
        Me.LblRecived.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRead
        '
        Me.LblRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRead.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblRead.Location = New System.Drawing.Point(189, 48)
        Me.LblRead.Name = "LblRead"
        Me.LblRead.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblRead.Size = New System.Drawing.Size(80, 20)
        Me.LblRead.TabIndex = 2045
        Me.LblRead.Text = "Lbl8"
        Me.LblRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCls
        '
        Me.LblCls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCls.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblCls.Location = New System.Drawing.Point(277, 48)
        Me.LblCls.Name = "LblCls"
        Me.LblCls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCls.Size = New System.Drawing.Size(80, 20)
        Me.LblCls.TabIndex = 2044
        Me.LblCls.Text = "Lbl7"
        Me.LblCls.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(932, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 2039
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEvt
        '
        Me.LblEvt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEvt.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblEvt.Location = New System.Drawing.Point(363, 48)
        Me.LblEvt.Name = "LblEvt"
        Me.LblEvt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblEvt.Size = New System.Drawing.Size(80, 20)
        Me.LblEvt.TabIndex = 2040
        Me.LblEvt.Text = "Lbl6"
        Me.LblEvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUnrd
        '
        Me.LblUnrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblUnrd.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblUnrd.Location = New System.Drawing.Point(538, 48)
        Me.LblUnrd.Name = "LblUnrd"
        Me.LblUnrd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblUnrd.Size = New System.Drawing.Size(80, 20)
        Me.LblUnrd.TabIndex = 2039
        Me.LblUnrd.Text = "Lbl5"
        Me.LblUnrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOpen
        '
        Me.LblOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOpen.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblOpen.Location = New System.Drawing.Point(796, 48)
        Me.LblOpen.Name = "LblOpen"
        Me.LblOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblOpen.Size = New System.Drawing.Size(80, 20)
        Me.LblOpen.TabIndex = 2038
        Me.LblOpen.Text = "Lbl2"
        Me.LblOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblReOpen
        '
        Me.LblReOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblReOpen.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblReOpen.Location = New System.Drawing.Point(625, 48)
        Me.LblReOpen.Name = "LblReOpen"
        Me.LblReOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblReOpen.Size = New System.Drawing.Size(80, 20)
        Me.LblReOpen.TabIndex = 2030
        Me.LblReOpen.Text = "Lbl4"
        Me.LblReOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNoFollow
        '
        Me.LblNoFollow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNoFollow.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblNoFollow.Location = New System.Drawing.Point(711, 48)
        Me.LblNoFollow.Name = "LblNoFollow"
        Me.LblNoFollow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblNoFollow.Size = New System.Drawing.Size(80, 20)
        Me.LblNoFollow.TabIndex = 2032
        Me.LblNoFollow.Text = "Lbl3"
        Me.LblNoFollow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 628)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatBrPnlEn, Me.StatBrPnlAr})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1344, 33)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 2135
        '
        'StatBrPnlEn
        '
        Me.StatBrPnlEn.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlEn.Name = "StatBrPnlEn"
        Me.StatBrPnlEn.Width = 672
        '
        'StatBrPnlAr
        '
        Me.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlAr.Name = "StatBrPnlAr"
        Me.StatBrPnlAr.Width = 672
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recorange
        Me.Button1.Location = New System.Drawing.Point(72, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 37)
        Me.Button1.TabIndex = 2136
        Me.Button1.Text = "Remove Filter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TotView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1344, 661)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.GridTicket1)
        Me.Controls.Add(Me.UserTree)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1360, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1360, 700)
        Me.Name = "TotView"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أرقام الفريق"
        CType(Me.GridTicket1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserTree As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents GridTicket1 As DataGridView
    Friend WithEvents CloseBtn As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblCls As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblEvt As Label
    Friend WithEvents LblUnrd As Label
    Friend WithEvents LblOpen As Label
    Friend WithEvents LblReOpen As Label
    Friend WithEvents LblNoFollow As Label
    Friend WithEvents LblClsUpted As Label
    Friend WithEvents LblRecived As Label
    Friend WithEvents LblRead As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblFolwDy As Label
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatBrPnlEn As StatusBarPanel
    Friend WithEvents StatBrPnlAr As StatusBarPanel
    Friend WithEvents Button1 As Button
End Class
