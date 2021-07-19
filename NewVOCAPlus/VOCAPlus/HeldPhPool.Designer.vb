<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPhPool
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HeldPhPool))
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CombUsrs = New System.Windows.Forms.ComboBox()
        Me.TxtCnt = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridHeld
        '
        Me.GridHeld.AllowUserToAddRows = False
        Me.GridHeld.AllowUserToDeleteRows = False
        Me.GridHeld.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridHeld.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GridHeld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridHeld.DefaultCellStyle = DataGridViewCellStyle4
        Me.GridHeld.Location = New System.Drawing.Point(12, 54)
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.ReadOnly = True
        Me.GridHeld.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridHeld.Size = New System.Drawing.Size(635, 555)
        Me.GridHeld.TabIndex = 0
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(406, 612)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblMsg.Size = New System.Drawing.Size(517, 23)
        Me.LblMsg.TabIndex = 2060
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CombUsrs
        '
        Me.CombUsrs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CombUsrs.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CombUsrs.FormattingEnabled = True
        Me.CombUsrs.Items.AddRange(New Object() {"الكل", "صيدلة", "إتصالات", "أمن عام", "مطبوعات", "مصنفات"})
        Me.CombUsrs.Location = New System.Drawing.Point(503, 12)
        Me.CombUsrs.Name = "CombUsrs"
        Me.CombUsrs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CombUsrs.Size = New System.Drawing.Size(376, 27)
        Me.CombUsrs.TabIndex = 2120
        '
        'TxtCnt
        '
        Me.TxtCnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCnt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtCnt.Location = New System.Drawing.Point(440, 12)
        Me.TxtCnt.Name = "TxtCnt"
        Me.TxtCnt.Size = New System.Drawing.Size(57, 26)
        Me.TxtCnt.TabIndex = 2121
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(337, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 26)
        Me.Button1.TabIndex = 2122
        Me.Button1.Text = "توزيع"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UserTree
        '
        Me.UserTree.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserTree.BackColor = System.Drawing.SystemColors.Window
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.Location = New System.Drawing.Point(707, 54)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowNodeToolTips = True
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(528, 555)
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
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(1049, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(105, 17)
        Me.RadioButton1.TabIndex = 2124
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "اختيار من الشجرة"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(942, 17)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(101, 17)
        Me.RadioButton2.TabIndex = 2125
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "اختيار من القائمة"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'HeldPhPool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 644)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.UserTree)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtCnt)
        Me.Controls.Add(Me.CombUsrs)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridHeld)
        Me.Location = New System.Drawing.Point(-3, 50)
        Me.Name = "HeldPhPool"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Main Pool"
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents LblMsg As Label
    Friend WithEvents CombUsrs As ComboBox
    Friend WithEvents TxtCnt As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents UserTree As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
