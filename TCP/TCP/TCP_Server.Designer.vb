<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TCP_Server
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnStpSrvr = New System.Windows.Forms.Button()
        Me.BtnStrtSrvr = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnSnd = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Clients = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnStpSrvr
        '
        Me.BtnStpSrvr.Location = New System.Drawing.Point(93, 12)
        Me.BtnStpSrvr.Name = "BtnStpSrvr"
        Me.BtnStpSrvr.Size = New System.Drawing.Size(75, 23)
        Me.BtnStpSrvr.TabIndex = 2
        Me.BtnStpSrvr.Text = "Stop Server"
        Me.BtnStpSrvr.UseVisualStyleBackColor = True
        '
        'BtnStrtSrvr
        '
        Me.BtnStrtSrvr.Location = New System.Drawing.Point(12, 12)
        Me.BtnStrtSrvr.Name = "BtnStrtSrvr"
        Me.BtnStrtSrvr.Size = New System.Drawing.Size(75, 23)
        Me.BtnStrtSrvr.TabIndex = 3
        Me.BtnStrtSrvr.Text = "Start Server"
        Me.BtnStrtSrvr.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 59)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RichTextBox1.Size = New System.Drawing.Size(482, 163)
        Me.RichTextBox1.TabIndex = 7
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 256)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(482, 141)
        Me.TextBox1.TabIndex = 10
        '
        'BtnSnd
        '
        Me.BtnSnd.Location = New System.Drawing.Point(513, 314)
        Me.BtnSnd.Name = "BtnSnd"
        Me.BtnSnd.Size = New System.Drawing.Size(75, 23)
        Me.BtnSnd.TabIndex = 11
        Me.BtnSnd.Text = "Send"
        Me.BtnSnd.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(513, 343)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Enter To Send"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Clients})
        Me.DataGridView1.Location = New System.Drawing.Point(513, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(199, 150)
        Me.DataGridView1.TabIndex = 13
        '
        'Clients
        '
        Me.Clients.HeaderText = "Clients"
        Me.Clients.Name = "Clients"
        Me.Clients.ReadOnly = True
        '
        'TCP_Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BtnSnd)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnStrtSrvr)
        Me.Controls.Add(Me.BtnStpSrvr)
        Me.Name = "TCP_Server"
        Me.Text = "TCP_Server"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnStpSrvr As Button
    Friend WithEvents BtnStrtSrvr As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnSnd As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Clients As DataGridViewTextBoxColumn
End Class
