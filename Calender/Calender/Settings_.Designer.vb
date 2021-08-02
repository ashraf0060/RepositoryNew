<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings_
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
        Me.LblUsrOpass = New System.Windows.Forms.Label()
        Me.TxtMailPassword = New System.Windows.Forms.TextBox()
        Me.LblUsrRNm = New System.Windows.Forms.Label()
        Me.TxtMailNm = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblUsrOpass
        '
        Me.LblUsrOpass.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrOpass.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrOpass.Location = New System.Drawing.Point(12, 46)
        Me.LblUsrOpass.Name = "LblUsrOpass"
        Me.LblUsrOpass.Size = New System.Drawing.Size(141, 18)
        Me.LblUsrOpass.TabIndex = 83
        Me.LblUsrOpass.Text = "Mail Password:"
        Me.LblUsrOpass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtMailPassword
        '
        Me.TxtMailPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtMailPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMailPassword.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMailPassword.Location = New System.Drawing.Point(155, 46)
        Me.TxtMailPassword.Name = "TxtMailPassword"
        Me.TxtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMailPassword.Size = New System.Drawing.Size(249, 19)
        Me.TxtMailPassword.TabIndex = 76
        '
        'LblUsrRNm
        '
        Me.LblUsrRNm.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrRNm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrRNm.Location = New System.Drawing.Point(12, 16)
        Me.LblUsrRNm.Name = "LblUsrRNm"
        Me.LblUsrRNm.Size = New System.Drawing.Size(137, 18)
        Me.LblUsrRNm.TabIndex = 82
        Me.LblUsrRNm.Text = "Mail:"
        Me.LblUsrRNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtMailNm
        '
        Me.TxtMailNm.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtMailNm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMailNm.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtMailNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMailNm.ForeColor = System.Drawing.Color.Black
        Me.TxtMailNm.Location = New System.Drawing.Point(155, 16)
        Me.TxtMailNm.MaxLength = 150
        Me.TxtMailNm.Name = "TxtMailNm"
        Me.TxtMailNm.Size = New System.Drawing.Size(138, 19)
        Me.TxtMailNm.TabIndex = 79
        Me.TxtMailNm.TabStop = False
        Me.TxtMailNm.Tag = "Real Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(299, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 18)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "@egyptpost.org"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(46, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Settings_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 106)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblUsrOpass)
        Me.Controls.Add(Me.TxtMailPassword)
        Me.Controls.Add(Me.LblUsrRNm)
        Me.Controls.Add(Me.TxtMailNm)
        Me.MaximumSize = New System.Drawing.Size(466, 145)
        Me.MinimumSize = New System.Drawing.Size(466, 145)
        Me.Name = "Settings_"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblUsrOpass As Label
    Friend WithEvents TxtMailPassword As TextBox
    Friend WithEvents LblUsrRNm As Label
    Friend WithEvents TxtMailNm As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
