<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MRSChkMail
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.LblFtr = New System.Windows.Forms.StatusBarPanel()
        Me.lblServerResponse = New System.Windows.Forms.Label()
        Me.TxtSrvRsp = New System.Windows.Forms.TextBox()
        Me.TxtErr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEDrp = New System.Windows.Forms.Label()
        Me.LblERtv = New System.Windows.Forms.Label()
        Me.LblEHandSh = New System.Windows.Forms.Label()
        Me.LblERej = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 543)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.LblFtr})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(911, 22)
        Me.StatusBar1.TabIndex = 1
        Me.StatusBar1.Text = "StatusBar1"
        '
        'LblFtr
        '
        Me.LblFtr.Name = "LblFtr"
        Me.LblFtr.Width = 750
        '
        'lblServerResponse
        '
        Me.lblServerResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblServerResponse.AutoSize = True
        Me.lblServerResponse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerResponse.Location = New System.Drawing.Point(591, 9)
        Me.lblServerResponse.Name = "lblServerResponse"
        Me.lblServerResponse.Size = New System.Drawing.Size(112, 19)
        Me.lblServerResponse.TabIndex = 9
        Me.lblServerResponse.Text = "Server Response"
        '
        'TxtSrvRsp
        '
        Me.TxtSrvRsp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSrvRsp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSrvRsp.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSrvRsp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtSrvRsp.Location = New System.Drawing.Point(595, 31)
        Me.TxtSrvRsp.Multiline = True
        Me.TxtSrvRsp.Name = "TxtSrvRsp"
        Me.TxtSrvRsp.ReadOnly = True
        Me.TxtSrvRsp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSrvRsp.Size = New System.Drawing.Size(315, 506)
        Me.TxtSrvRsp.TabIndex = 8
        Me.TxtSrvRsp.Text = "Waiting ..."
        '
        'TxtErr
        '
        Me.TxtErr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtErr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtErr.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtErr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtErr.Location = New System.Drawing.Point(274, 31)
        Me.TxtErr.Multiline = True
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ReadOnly = True
        Me.TxtErr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtErr.Size = New System.Drawing.Size(315, 385)
        Me.TxtErr.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Error Message"
        '
        'LblEDrp
        '
        Me.LblEDrp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEDrp.AutoSize = True
        Me.LblEDrp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEDrp.Location = New System.Drawing.Point(330, 452)
        Me.LblEDrp.Name = "LblEDrp"
        Me.LblEDrp.Size = New System.Drawing.Size(0, 19)
        Me.LblEDrp.TabIndex = 13
        '
        'LblERtv
        '
        Me.LblERtv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblERtv.AutoSize = True
        Me.LblERtv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblERtv.Location = New System.Drawing.Point(330, 424)
        Me.LblERtv.Name = "LblERtv"
        Me.LblERtv.Size = New System.Drawing.Size(0, 19)
        Me.LblERtv.TabIndex = 14
        '
        'LblEHandSh
        '
        Me.LblEHandSh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEHandSh.AutoSize = True
        Me.LblEHandSh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEHandSh.Location = New System.Drawing.Point(330, 481)
        Me.LblEHandSh.Name = "LblEHandSh"
        Me.LblEHandSh.Size = New System.Drawing.Size(0, 19)
        Me.LblEHandSh.TabIndex = 15
        '
        'LblERej
        '
        Me.LblERej.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblERej.AutoSize = True
        Me.LblERej.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblERej.Location = New System.Drawing.Point(330, 507)
        Me.LblERej.Name = "LblERej"
        Me.LblERej.Size = New System.Drawing.Size(0, 19)
        Me.LblERej.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(66, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MRSChkMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 565)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblERej)
        Me.Controls.Add(Me.LblEHandSh)
        Me.Controls.Add(Me.LblERtv)
        Me.Controls.Add(Me.LblEDrp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtErr)
        Me.Controls.Add(Me.lblServerResponse)
        Me.Controls.Add(Me.TxtSrvRsp)
        Me.Controls.Add(Me.StatusBar1)
        Me.Name = "MRSChkMail"
        Me.Text = "MRS Check Mail"
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents LblFtr As StatusBarPanel
    Friend WithEvents lblServerResponse As Label
    Friend WithEvents TxtSrvRsp As TextBox
    Friend WithEvents TxtErr As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblEDrp As Label
    Friend WithEvents LblERtv As Label
    Friend WithEvents LblEHandSh As Label
    Friend WithEvents LblERej As Label
    Friend WithEvents Button1 As Button
End Class
