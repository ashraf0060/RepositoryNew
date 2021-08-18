<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Start = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SourceFile = New System.Windows.Forms.TextBox()
        Me.CompareString = New System.Windows.Forms.TextBox()
        Me.WordsCounted = New System.Windows.Forms.TextBox()
        Me.LinesCounted = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(102, 34)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(75, 23)
        Me.Start.TabIndex = 0
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(382, 34)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'SourceFile
        '
        Me.SourceFile.Location = New System.Drawing.Point(102, 116)
        Me.SourceFile.Name = "SourceFile"
        Me.SourceFile.Size = New System.Drawing.Size(100, 20)
        Me.SourceFile.TabIndex = 2
        '
        'CompareString
        '
        Me.CompareString.Location = New System.Drawing.Point(102, 160)
        Me.CompareString.Name = "CompareString"
        Me.CompareString.Size = New System.Drawing.Size(100, 20)
        Me.CompareString.TabIndex = 3
        '
        'WordsCounted
        '
        Me.WordsCounted.Location = New System.Drawing.Point(102, 204)
        Me.WordsCounted.Name = "WordsCounted"
        Me.WordsCounted.Size = New System.Drawing.Size(100, 20)
        Me.WordsCounted.TabIndex = 4
        '
        'LinesCounted
        '
        Me.LinesCounted.Location = New System.Drawing.Point(102, 248)
        Me.LinesCounted.Name = "LinesCounted"
        Me.LinesCounted.Size = New System.Drawing.Size(100, 20)
        Me.LinesCounted.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Source File"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Compare String"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Matching Words"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Lines Counted"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinesCounted)
        Me.Controls.Add(Me.WordsCounted)
        Me.Controls.Add(Me.CompareString)
        Me.Controls.Add(Me.SourceFile)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Start)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Start As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents SourceFile As TextBox
    Friend WithEvents CompareString As TextBox
    Friend WithEvents WordsCounted As TextBox
    Friend WithEvents LinesCounted As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
