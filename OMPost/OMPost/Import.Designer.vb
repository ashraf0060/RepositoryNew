<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Import
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnBrws = New System.Windows.Forms.Button()
        Me.TxtErr = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 26)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(726, 380)
        Me.DataGridView1.TabIndex = 2075
        '
        'BtnCreate
        '
        Me.BtnCreate.BackgroundImage = Global.OMPost.My.Resources.Resources.CpAdd
        Me.BtnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCreate.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnCreate.Location = New System.Drawing.Point(675, 412)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(68, 63)
        Me.BtnCreate.TabIndex = 2083
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(401, 505)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2082
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(379, 502)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 2081
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 480)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(312, 27)
        Me.ComboBox1.TabIndex = 2079
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(12, 435)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(312, 26)
        Me.TextBox1.TabIndex = 2078
        '
        'BtnBrws
        '
        Me.BtnBrws.BackgroundImage = Global.OMPost.My.Resources.Resources.browse_button_png_th
        Me.BtnBrws.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrws.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnBrws.Location = New System.Drawing.Point(340, 424)
        Me.BtnBrws.Name = "BtnBrws"
        Me.BtnBrws.Size = New System.Drawing.Size(90, 45)
        Me.BtnBrws.TabIndex = 2077
        Me.BtnBrws.UseVisualStyleBackColor = True
        '
        'TxtErr
        '
        Me.TxtErr.Location = New System.Drawing.Point(749, 26)
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ReadOnly = True
        Me.TxtErr.Size = New System.Drawing.Size(531, 481)
        Me.TxtErr.TabIndex = 2084
        Me.TxtErr.Text = ""
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.OMPost.My.Resources.Resources.Download
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(459, 420)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(193, 46)
        Me.Button1.TabIndex = 2085
        Me.ToolTip1.SetToolTip(Me.Button1, "Download Template")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1302, 530)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtErr)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnBrws)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximumSize = New System.Drawing.Size(1318, 569)
        Me.MinimumSize = New System.Drawing.Size(1318, 569)
        Me.Name = "Import"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Users Create"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnCreate As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnBrws As Button
    Friend WithEvents TxtErr As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
