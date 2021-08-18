<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UConfigCtrls
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
        Me.BtnStrt = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatBrPnlEn = New System.Windows.Forms.StatusBarPanel()
        Me.StatBrPnlAr = New System.Windows.Forms.StatusBarPanel()
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnStrt
        '
        Me.BtnStrt.Location = New System.Drawing.Point(88, 198)
        Me.BtnStrt.Name = "BtnStrt"
        Me.BtnStrt.Size = New System.Drawing.Size(90, 41)
        Me.BtnStrt.TabIndex = 59
        Me.BtnStrt.Text = "Start"
        Me.BtnStrt.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(199, 221)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox1.TabIndex = 60
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(88, 37)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 61
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 417)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatBrPnlEn, Me.StatBrPnlAr})
        Me.StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(800, 33)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 62
        '
        'StatBrPnlEn
        '
        Me.StatBrPnlEn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlEn.Name = "StatBrPnlEn"
        Me.StatBrPnlEn.Width = 400
        '
        'StatBrPnlAr
        '
        Me.StatBrPnlAr.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatBrPnlAr.Name = "StatBrPnlAr"
        Me.StatBrPnlAr.Width = 400
        '
        'UConfigCtrls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BtnStrt)
        Me.Name = "UConfigCtrls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UCongCtrls"
        CType(Me.StatBrPnlEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatBrPnlAr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnStrt As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatBrPnlEn As StatusBarPanel
    Friend WithEvents StatBrPnlAr As StatusBarPanel
End Class
