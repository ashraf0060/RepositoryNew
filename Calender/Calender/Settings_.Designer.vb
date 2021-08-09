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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConStr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NtfSrt = New System.Windows.Forms.TextBox()
        Me.NtfEnd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NtfEvry = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.TxtMailPassword.BackColor = System.Drawing.Color.White
        Me.TxtMailPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMailPassword.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMailPassword.Location = New System.Drawing.Point(155, 46)
        Me.TxtMailPassword.Name = "TxtMailPassword"
        Me.TxtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMailPassword.Size = New System.Drawing.Size(249, 26)
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
        Me.TxtMailNm.BackColor = System.Drawing.Color.White
        Me.TxtMailNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMailNm.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtMailNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMailNm.ForeColor = System.Drawing.Color.Black
        Me.TxtMailNm.Location = New System.Drawing.Point(155, 16)
        Me.TxtMailNm.MaxLength = 150
        Me.TxtMailNm.Name = "TxtMailNm"
        Me.TxtMailNm.Size = New System.Drawing.Size(138, 26)
        Me.TxtMailNm.TabIndex = 79
        Me.TxtMailNm.TabStop = False
        Me.TxtMailNm.Tag = "Real Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(295, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 26)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "@egyptpost.org"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 18)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Database:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConStr
        '
        Me.txtConStr.BackColor = System.Drawing.Color.White
        Me.txtConStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConStr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConStr.Location = New System.Drawing.Point(155, 73)
        Me.txtConStr.Multiline = True
        Me.txtConStr.Name = "txtConStr"
        Me.txtConStr.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConStr.Size = New System.Drawing.Size(249, 109)
        Me.txtConStr.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(-1, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 18)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Notification Start:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NtfSrt
        '
        Me.NtfSrt.BackColor = System.Drawing.Color.White
        Me.NtfSrt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NtfSrt.Cursor = System.Windows.Forms.Cursors.Default
        Me.NtfSrt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NtfSrt.ForeColor = System.Drawing.Color.Black
        Me.NtfSrt.Location = New System.Drawing.Point(155, 187)
        Me.NtfSrt.MaxLength = 150
        Me.NtfSrt.Name = "NtfSrt"
        Me.NtfSrt.Size = New System.Drawing.Size(69, 26)
        Me.NtfSrt.TabIndex = 89
        Me.NtfSrt.TabStop = False
        Me.NtfSrt.Tag = "Real Name"
        '
        'NtfEnd
        '
        Me.NtfEnd.BackColor = System.Drawing.Color.White
        Me.NtfEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NtfEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.NtfEnd.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NtfEnd.ForeColor = System.Drawing.Color.Black
        Me.NtfEnd.Location = New System.Drawing.Point(373, 190)
        Me.NtfEnd.MaxLength = 150
        Me.NtfEnd.Name = "NtfEnd"
        Me.NtfEnd.Size = New System.Drawing.Size(69, 26)
        Me.NtfEnd.TabIndex = 91
        Me.NtfEnd.TabStop = False
        Me.NtfEnd.Tag = "Real Name"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(230, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 18)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Notification End:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NtfEvry
        '
        Me.NtfEvry.BackColor = System.Drawing.Color.White
        Me.NtfEvry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NtfEvry.Cursor = System.Windows.Forms.Cursors.Default
        Me.NtfEvry.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NtfEvry.ForeColor = System.Drawing.Color.Black
        Me.NtfEvry.Location = New System.Drawing.Point(155, 214)
        Me.NtfEvry.MaxLength = 150
        Me.NtfEvry.Name = "NtfEvry"
        Me.NtfEvry.Size = New System.Drawing.Size(69, 26)
        Me.NtfEvry.TabIndex = 93
        Me.NtfEvry.TabStop = False
        Me.NtfEvry.Tag = "Real Name"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(-1, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 18)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Notification Every Day:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(12, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 18)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Mail Time:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "hh:mm tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(159, 246)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(74, 20)
        Me.DateTimePicker1.TabIndex = 95
        Me.DateTimePicker1.Value = New Date(2021, 8, 5, 10, 34, 0, 0)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(400, 247)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 96
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Settings_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(518, 305)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NtfEvry)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NtfEnd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NtfSrt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConStr)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblUsrOpass)
        Me.Controls.Add(Me.TxtMailPassword)
        Me.Controls.Add(Me.LblUsrRNm)
        Me.Controls.Add(Me.TxtMailNm)
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
    Friend WithEvents Label2 As Label
    Friend WithEvents txtConStr As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NtfSrt As TextBox
    Friend WithEvents NtfEnd As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NtfEvry As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
End Class
