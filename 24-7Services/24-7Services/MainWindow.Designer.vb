<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.LblTimer = New System.Windows.Forms.Label()
        Me.PubVerLbl = New System.Windows.Forms.Label()
        Me.TxtErr = New System.Windows.Forms.TextBox()
        Me.BtnAbort = New System.Windows.Forms.Button()
        Me.TimerSecnods = New System.Windows.Forms.Timer(Me.components)
        Me.TimerEsc = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CombMin = New System.Windows.Forms.ComboBox()
        Me.CombHour = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.AutoMail = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTimer
        '
        Me.LblTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTimer.AutoSize = True
        Me.LblTimer.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LblTimer.ForeColor = System.Drawing.Color.Red
        Me.LblTimer.Location = New System.Drawing.Point(797, 20)
        Me.LblTimer.Name = "LblTimer"
        Me.LblTimer.Size = New System.Drawing.Size(52, 16)
        Me.LblTimer.TabIndex = 49
        Me.LblTimer.Text = "Label19"
        '
        'PubVerLbl
        '
        Me.PubVerLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PubVerLbl.AutoSize = True
        Me.PubVerLbl.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PubVerLbl.ForeColor = System.Drawing.Color.Red
        Me.PubVerLbl.Location = New System.Drawing.Point(1180, 696)
        Me.PubVerLbl.Name = "PubVerLbl"
        Me.PubVerLbl.Size = New System.Drawing.Size(44, 13)
        Me.PubVerLbl.TabIndex = 48
        Me.PubVerLbl.Text = "Label19"
        '
        'TxtErr
        '
        Me.TxtErr.Location = New System.Drawing.Point(12, 68)
        Me.TxtErr.Multiline = True
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ReadOnly = True
        Me.TxtErr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtErr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtErr.Size = New System.Drawing.Size(337, 626)
        Me.TxtErr.TabIndex = 46
        Me.TxtErr.Text = "Errors :"
        '
        'BtnAbort
        '
        Me.BtnAbort.Location = New System.Drawing.Point(14, 27)
        Me.BtnAbort.Name = "BtnAbort"
        Me.BtnAbort.Size = New System.Drawing.Size(160, 23)
        Me.BtnAbort.TabIndex = 40
        Me.BtnAbort.Text = "Import Notifications"
        Me.BtnAbort.UseVisualStyleBackColor = True
        '
        'TimerSecnods
        '
        Me.TimerSecnods.Enabled = True
        Me.TimerSecnods.Interval = 1000
        '
        'TimerEsc
        '
        Me.TimerEsc.Enabled = True
        Me.TimerEsc.Interval = 60000
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(353, 68)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(991, 269)
        Me.DataGridView1.TabIndex = 51
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label17.Location = New System.Drawing.Point(956, 551)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label17.Size = New System.Drawing.Size(74, 25)
        Me.Label17.TabIndex = 67
        Me.Label17.Text = "Minutes"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label16.Location = New System.Drawing.Point(876, 551)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label16.Size = New System.Drawing.Size(74, 25)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Hours"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CombMin
        '
        Me.CombMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombMin.FormattingEnabled = True
        Me.CombMin.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "00"})
        Me.CombMin.Location = New System.Drawing.Point(956, 579)
        Me.CombMin.Name = "CombMin"
        Me.CombMin.Size = New System.Drawing.Size(74, 21)
        Me.CombMin.TabIndex = 65
        '
        'CombHour
        '
        Me.CombHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombHour.FormattingEnabled = True
        Me.CombHour.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "00"})
        Me.CombHour.Location = New System.Drawing.Point(876, 579)
        Me.CombHour.Name = "CombHour"
        Me.CombHour.Size = New System.Drawing.Size(74, 21)
        Me.CombHour.TabIndex = 64
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label14.Location = New System.Drawing.Point(1036, 548)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label14.Size = New System.Drawing.Size(86, 31)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "رمسيس"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label13.Location = New System.Drawing.Point(1128, 548)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label13.Size = New System.Drawing.Size(82, 31)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "المطار"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label12.Location = New System.Drawing.Point(1227, 664)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label12.Size = New System.Drawing.Size(116, 31)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "إخطار ثالث"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label11.Location = New System.Drawing.Point(1227, 626)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(116, 31)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "إخطار ثاني"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label10.Location = New System.Drawing.Point(1227, 592)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label10.Size = New System.Drawing.Size(116, 31)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "إخطار أول"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label7.Location = New System.Drawing.Point(1044, 595)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(90, 25)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "0"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label8.Location = New System.Drawing.Point(1044, 626)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(90, 25)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "0"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label9.Location = New System.Drawing.Point(1044, 664)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(90, 25)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "0"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label6.Location = New System.Drawing.Point(1142, 664)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(84, 25)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "0"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label5.Location = New System.Drawing.Point(1142, 626)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(84, 25)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "0"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label4.Location = New System.Drawing.Point(1142, 595)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(84, 25)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "0"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.Label3.Location = New System.Drawing.Point(967, 511)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(374, 25)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(353, 339)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(991, 154)
        Me.DataGridView2.TabIndex = 68
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(353, 499)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.Size = New System.Drawing.Size(503, 132)
        Me.DataGridView3.TabIndex = 69
        '
        'AutoMail
        '
        Me.AutoMail.Enabled = True
        Me.AutoMail.Interval = 5000
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1353, 722)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CombMin)
        Me.Controls.Add(Me.CombHour)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LblTimer)
        Me.Controls.Add(Me.PubVerLbl)
        Me.Controls.Add(Me.TxtErr)
        Me.Controls.Add(Me.BtnAbort)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainWindow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTimer As Label
    Friend WithEvents PubVerLbl As Label
    Friend WithEvents TxtErr As TextBox
    Friend WithEvents BtnAbort As Button
    Friend WithEvents TimerSecnods As System.Windows.Forms.Timer
    Friend WithEvents TimerEsc As System.Windows.Forms.Timer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents CombMin As ComboBox
    Friend WithEvents CombHour As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents AutoMail As System.Windows.Forms.Timer
End Class
