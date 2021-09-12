<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupLog))
        Me.BtnExitFrm = New System.Windows.Forms.Button()
        Me.BtnRdFl = New System.Windows.Forms.Button()
        Me.LogData = New System.Windows.Forms.DataGridView()
        Me.BtnWrFl = New System.Windows.Forms.Button()
        Me.LblHeader = New System.Windows.Forms.Label()
        CType(Me.LogData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnExitFrm
        '
        Me.BtnExitFrm.BackColor = System.Drawing.Color.Transparent
        Me.BtnExitFrm.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.BtnExitFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExitFrm.Location = New System.Drawing.Point(141, 0)
        Me.BtnExitFrm.Name = "BtnExitFrm"
        Me.BtnExitFrm.Size = New System.Drawing.Size(64, 64)
        Me.BtnExitFrm.TabIndex = 11
        Me.BtnExitFrm.Tag = "Exit to Welcome Screen"
        Me.BtnExitFrm.UseVisualStyleBackColor = False
        '
        'BtnRdFl
        '
        Me.BtnRdFl.BackColor = System.Drawing.Color.Transparent
        Me.BtnRdFl.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.LoadFl
        Me.BtnRdFl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRdFl.Location = New System.Drawing.Point(1, 0)
        Me.BtnRdFl.Name = "BtnRdFl"
        Me.BtnRdFl.Size = New System.Drawing.Size(64, 64)
        Me.BtnRdFl.TabIndex = 12
        Me.BtnRdFl.Tag = "Load the file to Grid"
        Me.BtnRdFl.UseVisualStyleBackColor = False
        '
        'LogData
        '
        Me.LogData.AllowUserToAddRows = False
        Me.LogData.AllowUserToDeleteRows = False
        Me.LogData.AllowUserToResizeColumns = False
        Me.LogData.AllowUserToResizeRows = False
        Me.LogData.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.LogData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.LogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LogData.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LogData.Location = New System.Drawing.Point(0, 70)
        Me.LogData.Name = "LogData"
        Me.LogData.Size = New System.Drawing.Size(1350, 679)
        Me.LogData.TabIndex = 17
        '
        'BtnWrFl
        '
        Me.BtnWrFl.BackColor = System.Drawing.Color.Transparent
        Me.BtnWrFl.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.SaveFl
        Me.BtnWrFl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnWrFl.Location = New System.Drawing.Point(71, 0)
        Me.BtnWrFl.Name = "BtnWrFl"
        Me.BtnWrFl.Size = New System.Drawing.Size(64, 64)
        Me.BtnWrFl.TabIndex = 18
        Me.BtnWrFl.Tag = "Encode the file then Save in Txt form, Without load it."
        Me.BtnWrFl.UseVisualStyleBackColor = False
        '
        'LblHeader
        '
        Me.LblHeader.BackColor = System.Drawing.Color.Transparent
        Me.LblHeader.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblHeader.Location = New System.Drawing.Point(211, 9)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(716, 30)
        Me.LblHeader.TabIndex = 19
        Me.LblHeader.Text = " "
        '
        'SupLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1350, 749)
        Me.Controls.Add(Me.LblHeader)
        Me.Controls.Add(Me.LogData)
        Me.Controls.Add(Me.BtnRdFl)
        Me.Controls.Add(Me.BtnExitFrm)
        Me.Controls.Add(Me.BtnWrFl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SupLog"
        Me.Text = "SupLog"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LogData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnExitFrm As Button
    Friend WithEvents BtnRdFl As Button
    Friend WithEvents LogData As DataGridView
    Friend WithEvents BtnWrFl As Button
    Friend WithEvents LblHeader As Label
End Class
