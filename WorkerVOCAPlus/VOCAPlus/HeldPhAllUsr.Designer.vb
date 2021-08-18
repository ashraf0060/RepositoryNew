<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldPhAllUsr
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CombUsrsFltr = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtCnt = New System.Windows.Forms.TextBox()
        Me.CombUsrs = New System.Windows.Forms.ComboBox()
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
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
        Me.CloseBtn.Location = New System.Drawing.Point(11, 572)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 47)
        Me.CloseBtn.TabIndex = 2024
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = True
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
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(76, 576)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblMsg.Size = New System.Drawing.Size(1153, 23)
        Me.LblMsg.TabIndex = 2058
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CombUsrsFltr)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TxtCnt)
        Me.TabPage1.Controls.Add(Me.CombUsrs)
        Me.TabPage1.Controls.Add(Me.GridHeld)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1338, 528)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Users Balance"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(817, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(68, 21)
        Me.Label2.TabIndex = 2128
        Me.Label2.Text = "توزيع لـ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(1177, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(42, 21)
        Me.Label1.TabIndex = 2127
        Me.Label1.Text = "فلتر :"
        '
        'CombUsrsFltr
        '
        Me.CombUsrsFltr.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CombUsrsFltr.FormattingEnabled = True
        Me.CombUsrsFltr.Location = New System.Drawing.Point(896, 16)
        Me.CombUsrsFltr.Name = "CombUsrsFltr"
        Me.CombUsrsFltr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CombUsrsFltr.Size = New System.Drawing.Size(275, 27)
        Me.CombUsrsFltr.TabIndex = 2126
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(376, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 26)
        Me.Button1.TabIndex = 2125
        Me.Button1.Text = "توزيع"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCnt
        '
        Me.TxtCnt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtCnt.Location = New System.Drawing.Point(464, 16)
        Me.TxtCnt.Name = "TxtCnt"
        Me.TxtCnt.Size = New System.Drawing.Size(57, 26)
        Me.TxtCnt.TabIndex = 2124
        '
        'CombUsrs
        '
        Me.CombUsrs.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.CombUsrs.FormattingEnabled = True
        Me.CombUsrs.Location = New System.Drawing.Point(527, 15)
        Me.CombUsrs.Name = "CombUsrs"
        Me.CombUsrs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CombUsrs.Size = New System.Drawing.Size(284, 27)
        Me.CombUsrs.TabIndex = 2123
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
        Me.GridHeld.Location = New System.Drawing.Point(3, 70)
        Me.GridHeld.MultiSelect = False
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.ReadOnly = True
        Me.GridHeld.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHeld.Size = New System.Drawing.Size(1319, 460)
        Me.GridHeld.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TabControl1.ItemSize = New System.Drawing.Size(100, 30)
        Me.TabControl1.Location = New System.Drawing.Point(4, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(1346, 566)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 2020
        Me.TabControl1.TabStop = False
        '
        'HeldPhAllUsr
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
        Me.Name = "HeldPhAllUsr"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Balance"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents FilterComb As ComboBox
    Friend WithEvents LblMsg As Label
    Friend WithEvents CloseBtn As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtCnt As TextBox
    Friend WithEvents CombUsrs As ComboBox
    Friend WithEvents CombUsrsFltr As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
