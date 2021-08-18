<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeldImport
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TxtErr = New System.Windows.Forms.TextBox()
        Me.BTNRecvdFrmHld = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNRecvdAtHld = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnBrws = New System.Windows.Forms.Button()
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
        Me.DataGridView1.Size = New System.Drawing.Size(952, 380)
        Me.DataGridView1.TabIndex = 2075
        '
        'TxtErr
        '
        Me.TxtErr.BackColor = System.Drawing.Color.White
        Me.TxtErr.Location = New System.Drawing.Point(975, 26)
        Me.TxtErr.Multiline = True
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ReadOnly = True
        Me.TxtErr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtErr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtErr.Size = New System.Drawing.Size(325, 465)
        Me.TxtErr.TabIndex = 2076
        '
        'BTNRecvdFrmHld
        '
        Me.BTNRecvdFrmHld.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BTNRecvdFrmHld.Location = New System.Drawing.Point(616, 421)
        Me.BTNRecvdFrmHld.Name = "BTNRecvdFrmHld"
        Me.BTNRecvdFrmHld.Size = New System.Drawing.Size(157, 26)
        Me.BTNRecvdFrmHld.TabIndex = 2083
        Me.BTNRecvdFrmHld.Text = "Recieved From Held"
        Me.BTNRecvdFrmHld.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(859, 428)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2082
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(442, 483)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 2081
        Me.Label1.Text = "Label1"
        '
        'BTNRecvdAtHld
        '
        Me.BTNRecvdAtHld.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BTNRecvdAtHld.Location = New System.Drawing.Point(458, 421)
        Me.BTNRecvdAtHld.Name = "BTNRecvdAtHld"
        Me.BTNRecvdAtHld.Size = New System.Drawing.Size(142, 26)
        Me.BTNRecvdAtHld.TabIndex = 2080
        Me.BTNRecvdAtHld.Text = "Recieved At Held"
        Me.BTNRecvdAtHld.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(17, 464)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(312, 27)
        Me.ComboBox1.TabIndex = 2079
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(17, 421)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(312, 26)
        Me.TextBox1.TabIndex = 2078
        '
        'BtnBrws
        '
        Me.BtnBrws.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.BtnBrws.Location = New System.Drawing.Point(345, 421)
        Me.BtnBrws.Name = "BtnBrws"
        Me.BtnBrws.Size = New System.Drawing.Size(88, 26)
        Me.BtnBrws.TabIndex = 2077
        Me.BtnBrws.Text = "Browse"
        Me.BtnBrws.UseVisualStyleBackColor = True
        '
        'HeldImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1302, 530)
        Me.Controls.Add(Me.BTNRecvdFrmHld)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNRecvdAtHld)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnBrws)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TxtErr)
        Me.MaximumSize = New System.Drawing.Size(1318, 569)
        Me.MinimumSize = New System.Drawing.Size(1318, 569)
        Me.Name = "HeldImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Held Shipments Import"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TxtErr As TextBox
    Friend WithEvents BTNRecvdFrmHld As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNRecvdAtHld As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnBrws As Button
End Class
