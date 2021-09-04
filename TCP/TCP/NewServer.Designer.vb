<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.BtnStrtSrvr = New System.Windows.Forms.Button()
        Me.BtnStpSrvr = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.BtnSnd = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnStrtSrvr
        '
        Me.BtnStrtSrvr.Location = New System.Drawing.Point(12, 12)
        Me.BtnStrtSrvr.Name = "BtnStrtSrvr"
        Me.BtnStrtSrvr.Size = New System.Drawing.Size(75, 23)
        Me.BtnStrtSrvr.TabIndex = 5
        Me.BtnStrtSrvr.Text = "Start Server"
        Me.BtnStrtSrvr.UseVisualStyleBackColor = True
        '
        'BtnStpSrvr
        '
        Me.BtnStpSrvr.Location = New System.Drawing.Point(93, 12)
        Me.BtnStpSrvr.Name = "BtnStpSrvr"
        Me.BtnStpSrvr.Size = New System.Drawing.Size(75, 23)
        Me.BtnStpSrvr.TabIndex = 4
        Me.BtnStpSrvr.Text = "Stop Server"
        Me.BtnStpSrvr.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 41)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RichTextBox1.Size = New System.Drawing.Size(482, 163)
        Me.RichTextBox1.TabIndex = 8
        Me.RichTextBox1.Text = ""
        '
        'BtnSnd
        '
        Me.BtnSnd.Location = New System.Drawing.Point(513, 261)
        Me.BtnSnd.Name = "BtnSnd"
        Me.BtnSnd.Size = New System.Drawing.Size(75, 23)
        Me.BtnSnd.TabIndex = 12
        Me.BtnSnd.Text = "Send"
        Me.BtnSnd.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 210)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(482, 141)
        Me.TextBox1.TabIndex = 13
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(513, 305)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Enter To Send"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'NewServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnSnd)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnStrtSrvr)
        Me.Controls.Add(Me.BtnStpSrvr)
        Me.Name = "NewServer"
        Me.Text = "NewServer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnStrtSrvr As Button
    Friend WithEvents BtnStpSrvr As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents BtnSnd As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
