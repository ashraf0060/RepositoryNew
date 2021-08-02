<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.TxtUsrPass = New System.Windows.Forms.TextBox()
        Me.TxtUsrNm = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.LblUsrPw = New System.Windows.Forms.Label()
        Me.LblUsrNm = New System.Windows.Forms.Label()
        Me.LblUsrIP = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.LogInBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LblLogin = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtUsrPass
        '
        Me.TxtUsrPass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtUsrPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrPass.Location = New System.Drawing.Point(156, 146)
        Me.TxtUsrPass.Name = "TxtUsrPass"
        Me.TxtUsrPass.Size = New System.Drawing.Size(232, 19)
        Me.TxtUsrPass.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtUsrPass, "كلمة المرور")
        Me.TxtUsrPass.UseSystemPasswordChar = True
        '
        'TxtUsrNm
        '
        Me.TxtUsrNm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtUsrNm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrNm.Location = New System.Drawing.Point(156, 116)
        Me.TxtUsrNm.Name = "TxtUsrNm"
        Me.TxtUsrNm.Size = New System.Drawing.Size(232, 19)
        Me.TxtUsrNm.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TxtUsrNm, "اسم المستخدم")
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 304)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(580, 39)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 6
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Icon = CType(resources.GetObject("StatusBarPanel1.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 580
        '
        'BtnShow
        '
        Me.BtnShow.BackColor = System.Drawing.Color.Transparent
        Me.BtnShow.BackgroundImage = Global.Calender.My.Resources.Resources.recorange
        Me.BtnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnShow.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnShow.FlatAppearance.BorderSize = 0
        Me.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnShow.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnShow.Location = New System.Drawing.Point(407, 144)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(161, 28)
        Me.BtnShow.TabIndex = 2
        Me.BtnShow.TabStop = False
        Me.BtnShow.Text = "Show/Hide PassWord"
        Me.ToolTip1.SetToolTip(Me.BtnShow, "اظهار / اخفاء كلمة المرور")
        Me.BtnShow.UseCompatibleTextRendering = True
        Me.BtnShow.UseVisualStyleBackColor = False
        '
        'ExitBtn
        '
        Me.ExitBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExitBtn.BackColor = System.Drawing.Color.Transparent
        Me.ExitBtn.BackgroundImage = Global.Calender.My.Resources.Resources.recred
        Me.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExitBtn.FlatAppearance.BorderSize = 0
        Me.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitBtn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ExitBtn.ForeColor = System.Drawing.Color.Black
        Me.ExitBtn.Location = New System.Drawing.Point(4, 4)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(91, 28)
        Me.ExitBtn.TabIndex = 4
        Me.ExitBtn.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.ExitBtn, "إغلاق البرنامج")
        Me.ExitBtn.UseCompatibleTextRendering = True
        Me.ExitBtn.UseVisualStyleBackColor = False
        '
        'LblUsrPw
        '
        Me.LblUsrPw.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrPw.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsrPw.Location = New System.Drawing.Point(20, 150)
        Me.LblUsrPw.Name = "LblUsrPw"
        Me.LblUsrPw.Size = New System.Drawing.Size(130, 19)
        Me.LblUsrPw.TabIndex = 58
        Me.LblUsrPw.Text = "Password: "
        Me.LblUsrPw.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsrNm
        '
        Me.LblUsrNm.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsrNm.Location = New System.Drawing.Point(24, 119)
        Me.LblUsrNm.Name = "LblUsrNm"
        Me.LblUsrNm.Size = New System.Drawing.Size(126, 19)
        Me.LblUsrNm.TabIndex = 57
        Me.LblUsrNm.Text = "User Name:"
        Me.LblUsrNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsrIP
        '
        Me.LblUsrIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUsrIP.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrIP.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.LblUsrIP.ForeColor = System.Drawing.Color.Red
        Me.LblUsrIP.Location = New System.Drawing.Point(345, 260)
        Me.LblUsrIP.Name = "LblUsrIP"
        Me.LblUsrIP.Size = New System.Drawing.Size(235, 20)
        Me.LblUsrIP.TabIndex = 68
        Me.LblUsrIP.Text = "IP:  "
        Me.LblUsrIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LblUsrIP, "IP Address Of Current Mashine")
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.Calender.My.Resources.Resources.usersLogin
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 85)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        '
        'PubVerLbl
        '
        Me.PubVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PubVerLbl.BackColor = System.Drawing.Color.Transparent
        Me.PubVerLbl.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(348, 277)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(232, 24)
        Me.PubVerLbl.TabIndex = 74
        Me.PubVerLbl.Text = "Publish Ver."
        Me.PubVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.PubVerLbl, "Publish Version Number")
        '
        'LogInBtn
        '
        Me.LogInBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LogInBtn.BackColor = System.Drawing.Color.Transparent
        Me.LogInBtn.BackgroundImage = Global.Calender.My.Resources.Resources.recgreen
        Me.LogInBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LogInBtn.FlatAppearance.BorderSize = 0
        Me.LogInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogInBtn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LogInBtn.ForeColor = System.Drawing.Color.Black
        Me.LogInBtn.Location = New System.Drawing.Point(4, 4)
        Me.LogInBtn.Name = "LogInBtn"
        Me.LogInBtn.Size = New System.Drawing.Size(91, 28)
        Me.LogInBtn.TabIndex = 3
        Me.LogInBtn.Text = "Login"
        Me.ToolTip1.SetToolTip(Me.LogInBtn, "تسجيل الدخول")
        Me.LogInBtn.UseCompatibleTextRendering = True
        Me.LogInBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Calender.My.Resources.Resources.ChangePass
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 56)
        Me.Button1.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button1, "تغيير الرقم السري")
        Me.Button1.UseCompatibleTextRendering = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.Calender.My.Resources.Resources.Frstaid
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(38, 36)
        Me.Button2.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button2, "الإعدادات")
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.Calender.My.Resources.Resources.RstPass
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(38, 36)
        Me.Button3.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button3, "إعادة ضبطالرقم السري")
        Me.Button3.UseCompatibleTextRendering = True
        Me.Button3.UseVisualStyleBackColor = False
        '
        'LblLogin
        '
        Me.LblLogin.BackColor = System.Drawing.Color.Transparent
        Me.LblLogin.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblLogin.Location = New System.Drawing.Point(90, 175)
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(478, 34)
        Me.LblLogin.TabIndex = 76
        Me.LblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ExitBtn)
        Me.Panel1.Location = New System.Drawing.Point(383, 212)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(98, 36)
        Me.Panel1.TabIndex = 78
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.LogInBtn)
        Me.Panel2.Location = New System.Drawing.Point(283, 212)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(99, 36)
        Me.Panel2.TabIndex = 79
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Location = New System.Drawing.Point(499, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(69, 61)
        Me.Panel3.TabIndex = 80
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Location = New System.Drawing.Point(450, 21)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(43, 42)
        Me.Panel4.TabIndex = 81
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Location = New System.Drawing.Point(401, 21)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(43, 42)
        Me.Panel5.TabIndex = 82
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BackgroundImage = Global.Calender.My.Resources.Resources.VocaWtr
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(580, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PubVerLbl)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblUsrIP)
        Me.Controls.Add(Me.TxtUsrPass)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.LblUsrPw)
        Me.Controls.Add(Me.LblUsrNm)
        Me.Controls.Add(Me.TxtUsrNm)
        Me.Controls.Add(Me.LblLogin)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(596, 382)
        Me.MinimumSize = New System.Drawing.Size(596, 382)
        Me.Name = "Login"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtUsrPass As TextBox
    Friend WithEvents TxtUsrNm As TextBox
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatusBarPanel1 As StatusBarPanel
    Friend WithEvents BtnShow As Button
    Friend WithEvents ExitBtn As Button
    Friend WithEvents LblUsrPw As Label
    Friend WithEvents LblUsrNm As Label
    Friend WithEvents LblUsrIP As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents LblLogin As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LogInBtn As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button3 As Button
End Class
