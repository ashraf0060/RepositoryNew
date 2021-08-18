<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyProfile))
        Me.txtSisco = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUploadimage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lblmssg = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LblUsrRNm = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RadioRght = New System.Windows.Forms.RadioButton()
        Me.RadioWrng = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSisco
        '
        Me.txtSisco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSisco.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSisco.Location = New System.Drawing.Point(329, 366)
        Me.txtSisco.MaxLength = 4
        Me.txtSisco.Name = "txtSisco"
        Me.txtSisco.Size = New System.Drawing.Size(114, 26)
        Me.txtSisco.TabIndex = 0
        Me.txtSisco.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(449, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "الرقم الداخلي :"
        Me.Label1.Visible = False
        '
        'btnUploadimage
        '
        Me.btnUploadimage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUploadimage.BackColor = System.Drawing.Color.Transparent
        Me.btnUploadimage.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.upload_1
        Me.btnUploadimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUploadimage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUploadimage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUploadimage.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadimage.Location = New System.Drawing.Point(416, 194)
        Me.btnUploadimage.Name = "btnUploadimage"
        Me.btnUploadimage.Size = New System.Drawing.Size(68, 51)
        Me.btnUploadimage.TabIndex = 3
        Me.btnUploadimage.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(283, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "رقم الموبايل :"
        '
        'txtMobile
        '
        Me.txtMobile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobile.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(163, 248)
        Me.txtMobile.MaxLength = 11
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(114, 26)
        Me.txtMobile.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Lime
        Me.btnSave.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.SaveFl
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(88, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 50)
        Me.btnSave.TabIndex = 9
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Crimson
        Me.btnExit.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Enabled = False
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(6, 381)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(55, 50)
        Me.btnExit.TabIndex = 10
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.UsrResm
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(401, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(115, 137)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Lblmssg
        '
        Me.Lblmssg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lblmssg.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Lblmssg.ForeColor = System.Drawing.Color.Black
        Me.Lblmssg.Location = New System.Drawing.Point(367, 248)
        Me.Lblmssg.Name = "Lblmssg"
        Me.Lblmssg.Size = New System.Drawing.Size(175, 29)
        Me.Lblmssg.TabIndex = 2127
        Me.Lblmssg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.AddExtension = False
        Me.OpenFileDialog1.RestoreDirectory = True
        '
        'LblUsrRNm
        '
        Me.LblUsrRNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUsrRNm.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrRNm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrRNm.ForeColor = System.Drawing.Color.Black
        Me.LblUsrRNm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblUsrRNm.Location = New System.Drawing.Point(237, 9)
        Me.LblUsrRNm.Name = "LblUsrRNm"
        Me.LblUsrRNm.Size = New System.Drawing.Size(297, 20)
        Me.LblUsrRNm.TabIndex = 2128
        Me.LblUsrRNm.Text = "Welcome User: "
        Me.LblUsrRNm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(329, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(211, 19)
        Me.Label3.TabIndex = 2129
        Me.Label3.Text = "الصورة الشخصيه لابد أن تكون واضحه"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(283, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 2131
        Me.Label4.Text = "البريد الإلكتروني :"
        '
        'txtMail
        '
        Me.txtMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMail.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMail.Location = New System.Drawing.Point(57, 280)
        Me.txtMail.MaxLength = 100
        Me.txtMail.Name = "txtMail"
        Me.txtMail.ReadOnly = True
        Me.txtMail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMail.Size = New System.Drawing.Size(220, 26)
        Me.txtMail.TabIndex = 2130
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(371, 116)
        Me.Label5.TabIndex = 2132
        Me.Label5.Text = "لابد من ادخال رقم الموبايل لاستكمال تسجيل الدخول"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'RadioRght
        '
        Me.RadioRght.AutoSize = True
        Me.RadioRght.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RadioRght.ForeColor = System.Drawing.Color.Green
        Me.RadioRght.Location = New System.Drawing.Point(250, 327)
        Me.RadioRght.Name = "RadioRght"
        Me.RadioRght.Size = New System.Drawing.Size(149, 23)
        Me.RadioRght.TabIndex = 2133
        Me.RadioRght.TabStop = True
        Me.RadioRght.Text = "البريد الإلكتروني صحيح"
        Me.RadioRght.UseVisualStyleBackColor = True
        '
        'RadioWrng
        '
        Me.RadioWrng.AutoSize = True
        Me.RadioWrng.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RadioWrng.ForeColor = System.Drawing.Color.Red
        Me.RadioWrng.Location = New System.Drawing.Point(71, 327)
        Me.RadioWrng.Name = "RadioWrng"
        Me.RadioWrng.Size = New System.Drawing.Size(173, 23)
        Me.RadioWrng.TabIndex = 2134
        Me.RadioWrng.TabStop = True
        Me.RadioWrng.Text = "البريد الإلكتروني غير صحيح"
        Me.RadioWrng.UseVisualStyleBackColor = True
        '
        'MyProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(552, 443)
        Me.Controls.Add(Me.RadioWrng)
        Me.Controls.Add(Me.RadioRght)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblUsrRNm)
        Me.Controls.Add(Me.Lblmssg)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.btnUploadimage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSisco)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MyProfile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "My Profile"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSisco As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnUploadimage As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMobile As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lblmssg As Label
    Friend WithEvents LblUsrRNm As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents RadioRght As RadioButton
    Friend WithEvents RadioWrng As RadioButton
End Class
