<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UReset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UReset))
        Me.UsrData = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.BindNavigatorUsr = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpSusp = New System.Windows.Forms.GroupBox()
        Me.Alls = New System.Windows.Forms.RadioButton()
        Me.Resm = New System.Windows.Forms.RadioButton()
        Me.Susd = New System.Windows.Forms.RadioButton()
        Me.TxtUsrNm = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnFltr = New System.Windows.Forms.Button()
        Me.LblLine = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSuRs = New System.Windows.Forms.Button()
        Me.BtnPassRst = New System.Windows.Forms.Button()
        Me.LblHint = New System.Windows.Forms.Label()
        Me.LblCUsr = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnRstCtrls = New System.Windows.Forms.Button()
        CType(Me.UsrData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.BindNavigatorUsr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindNavigatorUsr.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSusp.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsrData
        '
        Me.UsrData.AllowUserToAddRows = False
        Me.UsrData.AllowUserToDeleteRows = False
        Me.UsrData.AllowUserToResizeColumns = False
        Me.UsrData.AllowUserToResizeRows = False
        Me.UsrData.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.UsrData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.UsrData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsrData.ContextMenuStrip = Me.ContextMenuStrip2
        Me.UsrData.Location = New System.Drawing.Point(16, 51)
        Me.UsrData.Name = "UsrData"
        Me.UsrData.ReadOnly = True
        Me.UsrData.Size = New System.Drawing.Size(691, 500)
        Me.UsrData.TabIndex = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripitem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(173, 26)
        '
        'CopyToolStripitem
        '
        Me.CopyToolStripitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CopyToolStripitem.Image = Global.VOCAPlus.My.Resources.Resources.Copy
        Me.CopyToolStripitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopyToolStripitem.Name = "CopyToolStripitem"
        Me.CopyToolStripitem.RightToLeftAutoMirrorImage = True
        Me.CopyToolStripitem.Size = New System.Drawing.Size(172, 22)
        Me.CopyToolStripitem.Text = "Copy Selected Cell"
        '
        'LblHeader
        '
        Me.LblHeader.AutoSize = True
        Me.LblHeader.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblHeader.Location = New System.Drawing.Point(12, 25)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(332, 23)
        Me.LblHeader.TabIndex = 1
        Me.LblHeader.Text = "Manage Suspending && Reset Password"
        '
        'BindNavigatorUsr
        '
        Me.BindNavigatorUsr.AddNewItem = Nothing
        Me.BindNavigatorUsr.CountItem = Me.BindingNavigatorCountItem
        Me.BindNavigatorUsr.DeleteItem = Nothing
        Me.BindNavigatorUsr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.BindNavigatorUsr.Location = New System.Drawing.Point(0, 0)
        Me.BindNavigatorUsr.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindNavigatorUsr.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindNavigatorUsr.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindNavigatorUsr.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindNavigatorUsr.Name = "BindNavigatorUsr"
        Me.BindNavigatorUsr.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindNavigatorUsr.Size = New System.Drawing.Size(1573, 25)
        Me.BindNavigatorUsr.TabIndex = 2
        Me.BindNavigatorUsr.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(735, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Searching"
        '
        'GrpSusp
        '
        Me.GrpSusp.BackColor = System.Drawing.Color.Transparent
        Me.GrpSusp.Controls.Add(Me.Alls)
        Me.GrpSusp.Controls.Add(Me.Resm)
        Me.GrpSusp.Controls.Add(Me.Susd)
        Me.GrpSusp.Location = New System.Drawing.Point(763, 77)
        Me.GrpSusp.Name = "GrpSusp"
        Me.GrpSusp.Size = New System.Drawing.Size(104, 62)
        Me.GrpSusp.TabIndex = 4
        Me.GrpSusp.TabStop = False
        Me.GrpSusp.Text = " "
        '
        'Alls
        '
        Me.Alls.AutoSize = True
        Me.Alls.Location = New System.Drawing.Point(7, 42)
        Me.Alls.Name = "Alls"
        Me.Alls.Size = New System.Drawing.Size(36, 17)
        Me.Alls.TabIndex = 2
        Me.Alls.TabStop = True
        Me.Alls.Text = "All"
        Me.Alls.UseVisualStyleBackColor = True
        '
        'Resm
        '
        Me.Resm.AutoSize = True
        Me.Resm.Location = New System.Drawing.Point(7, 19)
        Me.Resm.Name = "Resm"
        Me.Resm.Size = New System.Drawing.Size(62, 17)
        Me.Resm.TabIndex = 1
        Me.Resm.TabStop = True
        Me.Resm.Text = "Allowed"
        Me.Resm.UseVisualStyleBackColor = True
        '
        'Susd
        '
        Me.Susd.AutoSize = True
        Me.Susd.Location = New System.Drawing.Point(7, 0)
        Me.Susd.Name = "Susd"
        Me.Susd.Size = New System.Drawing.Size(72, 17)
        Me.Susd.TabIndex = 0
        Me.Susd.TabStop = True
        Me.Susd.Text = "Suspeded"
        Me.Susd.UseVisualStyleBackColor = True
        '
        'TxtUsrNm
        '
        Me.TxtUsrNm.Location = New System.Drawing.Point(958, 103)
        Me.TxtUsrNm.Name = "TxtUsrNm"
        Me.TxtUsrNm.Size = New System.Drawing.Size(212, 20)
        Me.TxtUsrNm.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(954, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Searching Name Contain"
        '
        'BtnFltr
        '
        Me.BtnFltr.BackColor = System.Drawing.Color.Transparent
        Me.BtnFltr.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Search
        Me.BtnFltr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFltr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFltr.Location = New System.Drawing.Point(1317, 77)
        Me.BtnFltr.Name = "BtnFltr"
        Me.BtnFltr.Size = New System.Drawing.Size(78, 78)
        Me.BtnFltr.TabIndex = 7
        Me.BtnFltr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFltr.UseCompatibleTextRendering = True
        Me.BtnFltr.UseVisualStyleBackColor = False
        '
        'LblLine
        '
        Me.LblLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblLine.Location = New System.Drawing.Point(727, 162)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(680, 3)
        Me.LblLine.TabIndex = 8
        Me.LblLine.Text = " "
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(735, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Selected item Action"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(729, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 3)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = " "
        '
        'BtnSuRs
        '
        Me.BtnSuRs.BackColor = System.Drawing.Color.Transparent
        Me.BtnSuRs.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        Me.BtnSuRs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSuRs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSuRs.Location = New System.Drawing.Point(739, 235)
        Me.BtnSuRs.Name = "BtnSuRs"
        Me.BtnSuRs.Size = New System.Drawing.Size(80, 80)
        Me.BtnSuRs.TabIndex = 11
        Me.BtnSuRs.UseVisualStyleBackColor = False
        '
        'BtnPassRst
        '
        Me.BtnPassRst.BackColor = System.Drawing.Color.Transparent
        Me.BtnPassRst.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recgrey
        Me.BtnPassRst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPassRst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPassRst.Location = New System.Drawing.Point(854, 235)
        Me.BtnPassRst.Name = "BtnPassRst"
        Me.BtnPassRst.Size = New System.Drawing.Size(80, 80)
        Me.BtnPassRst.TabIndex = 12
        Me.BtnPassRst.Tag = "Reset PassWord"
        Me.ToolTip1.SetToolTip(Me.BtnPassRst, "Reset Password")
        Me.BtnPassRst.UseVisualStyleBackColor = False
        '
        'LblHint
        '
        Me.LblHint.BackColor = System.Drawing.Color.Transparent
        Me.LblHint.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblHint.Location = New System.Drawing.Point(735, 335)
        Me.LblHint.Name = "LblHint"
        Me.LblHint.Size = New System.Drawing.Size(660, 68)
        Me.LblHint.TabIndex = 14
        Me.LblHint.Text = " "
        '
        'LblCUsr
        '
        Me.LblCUsr.AutoSize = True
        Me.LblCUsr.BackColor = System.Drawing.Color.Transparent
        Me.LblCUsr.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblCUsr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblCUsr.Location = New System.Drawing.Point(935, 213)
        Me.LblCUsr.Name = "LblCUsr"
        Me.LblCUsr.Size = New System.Drawing.Size(179, 21)
        Me.LblCUsr.TabIndex = 15
        Me.LblCUsr.Text = "Current Selected user: "
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BtnRstCtrls
        '
        Me.BtnRstCtrls.BackColor = System.Drawing.Color.Transparent
        Me.BtnRstCtrls.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recred
        Me.BtnRstCtrls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRstCtrls.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnRstCtrls.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnRstCtrls.ForeColor = System.Drawing.Color.Yellow
        Me.BtnRstCtrls.Location = New System.Drawing.Point(947, 242)
        Me.BtnRstCtrls.Name = "BtnRstCtrls"
        Me.BtnRstCtrls.Size = New System.Drawing.Size(125, 70)
        Me.BtnRstCtrls.TabIndex = 16
        Me.BtnRstCtrls.Tag = "Reset PassWord"
        Me.BtnRstCtrls.Text = "Reset All Controls"
        Me.ToolTip1.SetToolTip(Me.BtnRstCtrls, "Reset Password")
        Me.BtnRstCtrls.UseVisualStyleBackColor = False
        '
        'UReset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.VocaWtr
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1573, 565)
        Me.Controls.Add(Me.BtnRstCtrls)
        Me.Controls.Add(Me.LblCUsr)
        Me.Controls.Add(Me.LblHint)
        Me.Controls.Add(Me.BtnPassRst)
        Me.Controls.Add(Me.BtnSuRs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UsrData)
        Me.Controls.Add(Me.BtnFltr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUsrNm)
        Me.Controls.Add(Me.GrpSusp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BindNavigatorUsr)
        Me.Controls.Add(Me.LblHeader)
        Me.Controls.Add(Me.LblLine)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(-3, 50)
        Me.Name = "UReset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reset Password / Suspend User"
        CType(Me.UsrData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.BindNavigatorUsr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindNavigatorUsr.ResumeLayout(False)
        Me.BindNavigatorUsr.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSusp.ResumeLayout(False)
        Me.GrpSusp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UsrData As DataGridView
    Friend WithEvents LblHeader As Label
    Friend WithEvents BindNavigatorUsr As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents GrpSusp As GroupBox
    Friend WithEvents Alls As RadioButton
    Friend WithEvents Resm As RadioButton
    Friend WithEvents Susd As RadioButton
    Friend WithEvents TxtUsrNm As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnFltr As Button
    Friend WithEvents LblLine As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnSuRs As Button
    Friend WithEvents BtnPassRst As Button
    Friend WithEvents LblHint As Label
    Friend WithEvents LblCUsr As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyToolStripitem As ToolStripMenuItem
    Friend WithEvents BtnRstCtrls As Button
End Class
