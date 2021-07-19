<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HighLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkingDaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HighLevelToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegionsProductTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PubVerLbl
        '
        Me.PubVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PubVerLbl.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Italic)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(545, 428)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(247, 19)
        Me.PubVerLbl.TabIndex = 4
        Me.PubVerLbl.Text = "Label1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HighLevelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 26)
        '
        'HighLevelToolStripMenuItem
        '
        Me.HighLevelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegionsToolStripMenuItem})
        Me.HighLevelToolStripMenuItem.Name = "HighLevelToolStripMenuItem"
        Me.HighLevelToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.HighLevelToolStripMenuItem.Text = "High Level"
        '
        'RegionsToolStripMenuItem
        '
        Me.RegionsToolStripMenuItem.Name = "RegionsToolStripMenuItem"
        Me.RegionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.RegionsToolStripMenuItem.Text = "Regions"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.HighLevelToolStripMenuItem1, Me.SetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 30)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkingDaysToolStripMenuItem, Me.MainFormToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(65, 26)
        Me.ToolStripMenuItem1.Text = "Main"
        '
        'WorkingDaysToolStripMenuItem
        '
        Me.WorkingDaysToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkingDaysToolStripMenuItem.Name = "WorkingDaysToolStripMenuItem"
        Me.WorkingDaysToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.WorkingDaysToolStripMenuItem.Text = "Working Days"
        '
        'MainFormToolStripMenuItem
        '
        Me.MainFormToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainFormToolStripMenuItem.Name = "MainFormToolStripMenuItem"
        Me.MainFormToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.MainFormToolStripMenuItem.Text = "Analysis"
        '
        'HighLevelToolStripMenuItem1
        '
        Me.HighLevelToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegionsToolStripMenuItem1, Me.RegionsProductTypeToolStripMenuItem})
        Me.HighLevelToolStripMenuItem1.Name = "HighLevelToolStripMenuItem1"
        Me.HighLevelToolStripMenuItem1.Size = New System.Drawing.Size(110, 26)
        Me.HighLevelToolStripMenuItem1.Text = "High Level"
        '
        'RegionsToolStripMenuItem1
        '
        Me.RegionsToolStripMenuItem1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegionsToolStripMenuItem1.Name = "RegionsToolStripMenuItem1"
        Me.RegionsToolStripMenuItem1.Size = New System.Drawing.Size(213, 24)
        Me.RegionsToolStripMenuItem1.Text = "Regions"
        '
        'RegionsProductTypeToolStripMenuItem
        '
        Me.RegionsProductTypeToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegionsProductTypeToolStripMenuItem.Name = "RegionsProductTypeToolStripMenuItem"
        Me.RegionsProductTypeToolStripMenuItem.Size = New System.Drawing.Size(213, 24)
        Me.RegionsProductTypeToolStripMenuItem.Text = "Regions Product Type"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ImportToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(68, 26)
        Me.SetupToolStripMenuItem.Text = "Setup"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(163, 24)
        Me.ToolStripMenuItem2.Text = "Setup Groups"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(163, 24)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PubVerLbl)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Switchboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents HighLevelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HighLevelToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RegionsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RegionsProductTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WorkingDaysToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainFormToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
End Class
