<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Start
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblUsrIP = New System.Windows.Forms.Label()
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MacWrWrkr = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.VOCAPlus.My.Resources.Resources.VOCAIntro3
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(697, 391)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LblUsrIP
        '
        Me.LblUsrIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUsrIP.BackColor = System.Drawing.Color.Transparent
        Me.LblUsrIP.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.LblUsrIP.ForeColor = System.Drawing.Color.Red
        Me.LblUsrIP.Location = New System.Drawing.Point(467, 351)
        Me.LblUsrIP.Name = "LblUsrIP"
        Me.LblUsrIP.Size = New System.Drawing.Size(218, 20)
        Me.LblUsrIP.TabIndex = 69
        Me.LblUsrIP.Text = "IP:  "
        Me.LblUsrIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PubVerLbl
        '
        Me.PubVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PubVerLbl.BackColor = System.Drawing.Color.Transparent
        Me.PubVerLbl.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(464, 371)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(221, 20)
        Me.PubVerLbl.TabIndex = 75
        Me.PubVerLbl.Text = "Publish Ver."
        Me.PubVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer2
        '
        Me.Timer2.Interval = 3000
        '
        'MacWrWrkr
        '
        Me.MacWrWrkr.WorkerReportsProgress = True
        Me.MacWrWrkr.WorkerSupportsCancellation = True
        '
        'Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(697, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.PubVerLbl)
        Me.Controls.Add(Me.LblUsrIP)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Start"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Start"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblUsrIP As Label
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents MacWrWrkr As System.ComponentModel.BackgroundWorker
End Class
