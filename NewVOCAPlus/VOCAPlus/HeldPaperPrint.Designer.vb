<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeldPaperPrint
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
        Me.GridHeld = New System.Windows.Forms.DataGridView()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.BtnOpen = New System.Windows.Forms.ComboBox()
        Me.BtnRefrsh = New System.Windows.Forms.Button()
        Me.BtnDwnld = New System.Windows.Forms.Button()
        Me.Lblmssg = New System.Windows.Forms.Label()
        Me.Download = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOpn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GridHeld.Location = New System.Drawing.Point(11, 40)
        Me.GridHeld.MultiSelect = False
        Me.GridHeld.Name = "GridHeld"
        Me.GridHeld.ReadOnly = True
        Me.GridHeld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridHeld.Size = New System.Drawing.Size(927, 512)
        Me.GridHeld.TabIndex = 1
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.LblMsg.Location = New System.Drawing.Point(111, 589)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblMsg.Size = New System.Drawing.Size(1108, 23)
        Me.LblMsg.TabIndex = 2059
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.CloseBtn.Location = New System.Drawing.Point(1277, 558)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(54, 51)
        Me.CloseBtn.TabIndex = 2060
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'BtnOpen
        '
        Me.BtnOpen.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnOpen.FormattingEnabled = True
        Me.BtnOpen.Items.AddRange(New Object() {"الكل", "صيدلة", "إتصالات", "أمن عام", "مطبوعات", "مصنفات"})
        Me.BtnOpen.Location = New System.Drawing.Point(338, 7)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(198, 27)
        Me.BtnOpen.TabIndex = 2119
        '
        'BtnRefrsh
        '
        Me.BtnRefrsh.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgreen
        Me.BtnRefrsh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRefrsh.Location = New System.Drawing.Point(582, 7)
        Me.BtnRefrsh.Name = "BtnRefrsh"
        Me.BtnRefrsh.Size = New System.Drawing.Size(90, 27)
        Me.BtnRefrsh.TabIndex = 2120
        Me.BtnRefrsh.Text = "تحديث"
        Me.BtnRefrsh.UseVisualStyleBackColor = True
        '
        'BtnDwnld
        '
        Me.BtnDwnld.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Download
        Me.BtnDwnld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDwnld.Location = New System.Drawing.Point(1005, 266)
        Me.BtnDwnld.Name = "BtnDwnld"
        Me.BtnDwnld.Size = New System.Drawing.Size(108, 43)
        Me.BtnDwnld.TabIndex = 2126
        Me.BtnDwnld.UseVisualStyleBackColor = True
        '
        'Lblmssg
        '
        Me.Lblmssg.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Lblmssg.ForeColor = System.Drawing.Color.Green
        Me.Lblmssg.Location = New System.Drawing.Point(1011, 225)
        Me.Lblmssg.Name = "Lblmssg"
        Me.Lblmssg.Size = New System.Drawing.Size(264, 30)
        Me.Lblmssg.TabIndex = 2127
        Me.Lblmssg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Download
        '
        Me.Download.Location = New System.Drawing.Point(694, 11)
        Me.Download.Name = "Download"
        Me.Download.Size = New System.Drawing.Size(75, 23)
        Me.Download.TabIndex = 2128
        Me.Download.Text = "Button1"
        Me.Download.UseVisualStyleBackColor = True
        Me.Download.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(1011, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 29)
        Me.Label1.TabIndex = 2129
        Me.Label1.Text = "مستندات التخليص"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnOpn
        '
        Me.BtnOpn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Open
        Me.BtnOpn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOpn.Location = New System.Drawing.Point(1119, 261)
        Me.BtnOpn.Name = "BtnOpn"
        Me.BtnOpn.Size = New System.Drawing.Size(59, 48)
        Me.BtnOpn.TabIndex = 2130
        Me.BtnOpn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(946, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(385, 150)
        Me.DataGridView1.TabIndex = 2131
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(989, 315)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox1.Size = New System.Drawing.Size(124, 17)
        Me.CheckBox1.TabIndex = 2132
        Me.CheckBox1.Text = "فتح الملف بعد التنزيل"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
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
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopySelectedToolStripMenuItem.Text = "Copy Selected"
        '
        'HeldPaperPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 621)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnOpn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Download)
        Me.Controls.Add(Me.Lblmssg)
        Me.Controls.Add(Me.BtnDwnld)
        Me.Controls.Add(Me.BtnRefrsh)
        Me.Controls.Add(Me.BtnOpen)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.GridHeld)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HeldPaperPrint"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طباعة الأوراق"
        CType(Me.GridHeld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridHeld As DataGridView
    Friend WithEvents LblMsg As Label
    Friend WithEvents CloseBtn As Button
    Friend WithEvents BtnOpen As ComboBox
    Friend WithEvents BtnRefrsh As Button
    Friend WithEvents BtnDwnld As Button
    Friend WithEvents Lblmssg As Label
    Friend WithEvents Download As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnOpn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As ToolStripMenuItem
End Class
