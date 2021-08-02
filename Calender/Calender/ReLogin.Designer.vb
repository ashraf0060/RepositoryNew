<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReLogin))
        Me.TxtUsCnt_Pass = New System.Windows.Forms.TextBox()
        Me.TxtUsrPass = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.BtSub = New System.Windows.Forms.Button()
        Me.LblUsCnt_Pass = New System.Windows.Forms.Label()
        Me.LblUsrPass = New System.Windows.Forms.Label()
        Me.LblHint = New System.Windows.Forms.Label()
        Me.LblUsrRNm = New System.Windows.Forms.Label()
        Me.TxtUsCnt_lNm = New System.Windows.Forms.TextBox()
        Me.AssVerLbl = New System.Windows.Forms.Label()
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblUsrOpass = New System.Windows.Forms.Label()
        Me.TxtUsrOPass = New System.Windows.Forms.TextBox()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtUsCnt_Pass
        '
        Me.TxtUsCnt_Pass.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtUsCnt_Pass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsCnt_Pass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsCnt_Pass.Location = New System.Drawing.Point(155, 159)
        Me.TxtUsCnt_Pass.Name = "TxtUsCnt_Pass"
        Me.TxtUsCnt_Pass.Size = New System.Drawing.Size(233, 19)
        Me.TxtUsCnt_Pass.TabIndex = 2
        '
        'TxtUsrPass
        '
        Me.TxtUsrPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtUsrPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrPass.Location = New System.Drawing.Point(155, 131)
        Me.TxtUsrPass.Name = "TxtUsrPass"
        Me.TxtUsrPass.Size = New System.Drawing.Size(233, 19)
        Me.TxtUsrPass.TabIndex = 1
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 261)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(588, 33)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 8
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 588
        '
        'BtSub
        '
        Me.BtSub.BackColor = System.Drawing.Color.Transparent
        Me.BtSub.BackgroundImage = Global.Calender.My.Resources.Resources.recgrey
        Me.BtSub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtSub.FlatAppearance.BorderSize = 0
        Me.BtSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSub.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSub.Location = New System.Drawing.Point(433, 86)
        Me.BtSub.Name = "BtSub"
        Me.BtSub.Size = New System.Drawing.Size(131, 29)
        Me.BtSub.TabIndex = 3
        Me.BtSub.Tag = "Submit the new password"
        Me.BtSub.Text = "Submit"
        Me.BtSub.UseVisualStyleBackColor = False
        '
        'LblUsCnt_Pass
        '
        Me.LblUsCnt_Pass.BackColor = System.Drawing.Color.Transparent
        Me.LblUsCnt_Pass.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsCnt_Pass.Location = New System.Drawing.Point(12, 159)
        Me.LblUsCnt_Pass.Name = "LblUsCnt_Pass"
        Me.LblUsCnt_Pass.Size = New System.Drawing.Size(141, 18)
        Me.LblUsCnt_Pass.TabIndex = 68
        Me.LblUsCnt_Pass.Text = "ReEnter PassWord: "
        Me.LblUsCnt_Pass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsrPass
        '
        Me.LblUsrPass.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrPass.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrPass.Location = New System.Drawing.Point(12, 131)
        Me.LblUsrPass.Name = "LblUsrPass"
        Me.LblUsrPass.Size = New System.Drawing.Size(137, 18)
        Me.LblUsrPass.TabIndex = 67
        Me.LblUsrPass.Text = "Enter PassWord:"
        Me.LblUsrPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblHint
        '
        Me.LblHint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblHint.BackColor = System.Drawing.Color.Transparent
        Me.LblHint.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblHint.ForeColor = System.Drawing.Color.Red
        Me.LblHint.Location = New System.Drawing.Point(13, 188)
        Me.LblHint.Name = "LblHint"
        Me.LblHint.Size = New System.Drawing.Size(525, 40)
        Me.LblHint.TabIndex = 64
        Me.LblHint.Text = " "
        Me.LblHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsrRNm
        '
        Me.LblUsrRNm.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrRNm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrRNm.Location = New System.Drawing.Point(12, 75)
        Me.LblUsrRNm.Name = "LblUsrRNm"
        Me.LblUsrRNm.Size = New System.Drawing.Size(137, 18)
        Me.LblUsrRNm.TabIndex = 70
        Me.LblUsrRNm.Text = "User Real Name:"
        Me.LblUsrRNm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtUsCnt_lNm
        '
        Me.TxtUsCnt_lNm.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtUsCnt_lNm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsCnt_lNm.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtUsCnt_lNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsCnt_lNm.ForeColor = System.Drawing.Color.Black
        Me.TxtUsCnt_lNm.Location = New System.Drawing.Point(155, 75)
        Me.TxtUsCnt_lNm.MaxLength = 150
        Me.TxtUsCnt_lNm.Name = "TxtUsCnt_lNm"
        Me.TxtUsCnt_lNm.Size = New System.Drawing.Size(233, 19)
        Me.TxtUsCnt_lNm.TabIndex = 5
        Me.TxtUsCnt_lNm.TabStop = False
        Me.TxtUsCnt_lNm.Tag = "Real Name"
        '
        'AssVerLbl
        '
        Me.AssVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AssVerLbl.BackColor = System.Drawing.Color.Transparent
        Me.AssVerLbl.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.AssVerLbl.ForeColor = System.Drawing.Color.Red
        Me.AssVerLbl.Location = New System.Drawing.Point(303, 228)
        Me.AssVerLbl.Name = "AssVerLbl"
        Me.AssVerLbl.Size = New System.Drawing.Size(285, 20)
        Me.AssVerLbl.TabIndex = 6
        Me.AssVerLbl.Text = "Assembly Ver."
        Me.AssVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PubVerLbl
        '
        Me.PubVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PubVerLbl.BackColor = System.Drawing.Color.Transparent
        Me.PubVerLbl.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(303, 245)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(285, 20)
        Me.PubVerLbl.TabIndex = 7
        Me.PubVerLbl.Text = "Publish Ver."
        Me.PubVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExitBtn
        '
        Me.ExitBtn.BackColor = System.Drawing.Color.Transparent
        Me.ExitBtn.BackgroundImage = Global.Calender.My.Resources.Resources.recred
        Me.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExitBtn.FlatAppearance.BorderSize = 0
        Me.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitBtn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ExitBtn.ForeColor = System.Drawing.Color.Black
        Me.ExitBtn.Location = New System.Drawing.Point(433, 134)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(131, 30)
        Me.ExitBtn.TabIndex = 4
        Me.ExitBtn.Text = "Exit"
        Me.ExitBtn.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.Calender.My.Resources.Resources.ChangePass
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 63
        Me.PictureBox2.TabStop = False
        '
        'LblUsrOpass
        '
        Me.LblUsrOpass.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrOpass.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LblUsrOpass.Location = New System.Drawing.Point(12, 105)
        Me.LblUsrOpass.Name = "LblUsrOpass"
        Me.LblUsrOpass.Size = New System.Drawing.Size(141, 18)
        Me.LblUsrOpass.TabIndex = 75
        Me.LblUsrOpass.Text = "Old PassWord: "
        Me.LblUsrOpass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtUsrOPass
        '
        Me.TxtUsrOPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtUsrOPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsrOPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsrOPass.Location = New System.Drawing.Point(155, 105)
        Me.TxtUsrOPass.Name = "TxtUsrOPass"
        Me.TxtUsrOPass.Size = New System.Drawing.Size(233, 19)
        Me.TxtUsrOPass.TabIndex = 0
        '
        'ReLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.Calender.My.Resources.Resources.VocaWtr
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(588, 294)
        Me.Controls.Add(Me.LblUsrOpass)
        Me.Controls.Add(Me.TxtUsrOPass)
        Me.Controls.Add(Me.ExitBtn)
        Me.Controls.Add(Me.AssVerLbl)
        Me.Controls.Add(Me.PubVerLbl)
        Me.Controls.Add(Me.LblUsrRNm)
        Me.Controls.Add(Me.TxtUsCnt_lNm)
        Me.Controls.Add(Me.LblUsCnt_Pass)
        Me.Controls.Add(Me.LblUsrPass)
        Me.Controls.Add(Me.BtSub)
        Me.Controls.Add(Me.LblHint)
        Me.Controls.Add(Me.TxtUsCnt_Pass)
        Me.Controls.Add(Me.TxtUsrPass)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.PictureBox2)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change PassWord"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtUsCnt_Pass As TextBox
    Friend WithEvents TxtUsrPass As TextBox
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatusBarPanel1 As StatusBarPanel
    Friend WithEvents BtSub As Button
    Friend WithEvents LblUsCnt_Pass As Label
    Friend WithEvents LblUsrPass As Label
    Friend WithEvents LblHint As Label
    Friend WithEvents LblUsrRNm As Label
    Friend WithEvents TxtUsCnt_lNm As TextBox
    Friend WithEvents AssVerLbl As Label
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents ExitBtn As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LblUsrOpass As Label
    Friend WithEvents TxtUsrOPass As TextBox
End Class
