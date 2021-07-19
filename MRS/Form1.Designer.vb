<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtSrvRsp = New System.Windows.Forms.TextBox()
        Me.webMail = New System.Windows.Forms.WebBrowser()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtFrmNm = New System.Windows.Forms.TextBox()
        Me.TxtFrmAdd = New System.Windows.Forms.TextBox()
        Me.TxtSub = New System.Windows.Forms.TextBox()
        Me.TxtTo = New System.Windows.Forms.TextBox()
        Me.TxtCc = New System.Windows.Forms.TextBox()
        Me.TreeViewFolder = New System.Windows.Forms.TreeView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.LblFtr = New System.Windows.Forms.StatusBarPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(576, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Connect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtSrvRsp
        '
        Me.TxtSrvRsp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSrvRsp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSrvRsp.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSrvRsp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtSrvRsp.Location = New System.Drawing.Point(881, 34)
        Me.TxtSrvRsp.Multiline = True
        Me.TxtSrvRsp.Name = "TxtSrvRsp"
        Me.TxtSrvRsp.ReadOnly = True
        Me.TxtSrvRsp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSrvRsp.Size = New System.Drawing.Size(316, 190)
        Me.TxtSrvRsp.TabIndex = 15
        Me.TxtSrvRsp.Text = "Waiting ..."
        '
        'webMail
        '
        Me.webMail.Location = New System.Drawing.Point(201, 365)
        Me.webMail.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webMail.Name = "webMail"
        Me.webMail.Size = New System.Drawing.Size(903, 315)
        Me.webMail.TabIndex = 18
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(201, 34)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(776, 200)
        Me.ListView1.TabIndex = 19
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(366, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 25)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "To : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(362, 334)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Cc : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtFrmNm
        '
        Me.TxtFrmNm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFrmNm.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TxtFrmNm.ForeColor = System.Drawing.Color.Navy
        Me.TxtFrmNm.Location = New System.Drawing.Point(435, 239)
        Me.TxtFrmNm.Name = "TxtFrmNm"
        Me.TxtFrmNm.ReadOnly = True
        Me.TxtFrmNm.Size = New System.Drawing.Size(305, 19)
        Me.TxtFrmNm.TabIndex = 23
        '
        'TxtFrmAdd
        '
        Me.TxtFrmAdd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFrmAdd.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtFrmAdd.Location = New System.Drawing.Point(746, 239)
        Me.TxtFrmAdd.Name = "TxtFrmAdd"
        Me.TxtFrmAdd.ReadOnly = True
        Me.TxtFrmAdd.Size = New System.Drawing.Size(366, 19)
        Me.TxtFrmAdd.TabIndex = 24
        '
        'TxtSub
        '
        Me.TxtSub.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSub.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TxtSub.Location = New System.Drawing.Point(435, 265)
        Me.TxtSub.Multiline = True
        Me.TxtSub.Name = "TxtSub"
        Me.TxtSub.ReadOnly = True
        Me.TxtSub.Size = New System.Drawing.Size(677, 27)
        Me.TxtSub.TabIndex = 25
        '
        'TxtTo
        '
        Me.TxtTo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTo.Location = New System.Drawing.Point(435, 298)
        Me.TxtTo.Multiline = True
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.ReadOnly = True
        Me.TxtTo.Size = New System.Drawing.Size(677, 28)
        Me.TxtTo.TabIndex = 27
        '
        'TxtCc
        '
        Me.TxtCc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCc.Location = New System.Drawing.Point(435, 331)
        Me.TxtCc.Multiline = True
        Me.TxtCc.Name = "TxtCc"
        Me.TxtCc.ReadOnly = True
        Me.TxtCc.Size = New System.Drawing.Size(677, 28)
        Me.TxtCc.TabIndex = 28
        '
        'TreeViewFolder
        '
        Me.TreeViewFolder.HideSelection = False
        Me.TreeViewFolder.Location = New System.Drawing.Point(12, 34)
        Me.TreeViewFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TreeViewFolder.Name = "TreeViewFolder"
        Me.TreeViewFolder.Size = New System.Drawing.Size(183, 645)
        Me.TreeViewFolder.TabIndex = 29
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(212, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(305, 19)
        Me.TextBox1.TabIndex = 30
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 686)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.LblFtr})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1209, 22)
        Me.StatusBar1.TabIndex = 31
        Me.StatusBar1.Text = "xxx"
        '
        'LblFtr
        '
        Me.LblFtr.Name = "LblFtr"
        Me.LblFtr.Width = 750
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Get"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(201, 142)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(776, 92)
        Me.DataGridView1.TabIndex = 33
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(800, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 23)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "paste cilbroad"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Large Icon" & Global.Microsoft.VisualBasic.ChrW(9), "Small Icon", "List", "Title", "Details"})
        Me.ComboBox1.Location = New System.Drawing.Point(673, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 35
        '
        'ListView2
        '
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(12, 249)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(283, 102)
        Me.ListView2.TabIndex = 36
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(922, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 23)
        Me.Button4.TabIndex = 37
        Me.Button4.Text = "Get one mail"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(102, 86)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(607, 147)
        Me.WebBrowser1.TabIndex = 38
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1209, 708)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TreeViewFolder)
        Me.Controls.Add(Me.TxtCc)
        Me.Controls.Add(Me.TxtTo)
        Me.Controls.Add(Me.TxtSub)
        Me.Controls.Add(Me.TxtFrmAdd)
        Me.Controls.Add(Me.TxtFrmNm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.webMail)
        Me.Controls.Add(Me.TxtSrvRsp)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TxtSrvRsp As TextBox
    Friend WithEvents webMail As WebBrowser
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtFrmNm As TextBox
    Friend WithEvents TxtFrmAdd As TextBox
    Friend WithEvents TxtSub As TextBox
    Friend WithEvents TxtTo As TextBox
    Friend WithEvents TxtCc As TextBox
    Friend WithEvents TreeViewFolder As TreeView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents LblFtr As StatusBarPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Button4 As Button
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
