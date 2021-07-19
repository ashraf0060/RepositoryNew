<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRSEx
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtErr = New System.Windows.Forms.TextBox()
        Me.lblServerResponse = New System.Windows.Forms.Label()
        Me.TxtSrvRsp = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.LblFtr = New System.Windows.Forms.StatusBarPanel()
        Me.LblERej = New System.Windows.Forms.Label()
        Me.LblEHandSh = New System.Windows.Forms.Label()
        Me.LblERtv = New System.Windows.Forms.Label()
        Me.LblEDrp = New System.Windows.Forms.Label()
        Me.TxtErtv = New System.Windows.Forms.TextBox()
        Me.TxtEDrp = New System.Windows.Forms.TextBox()
        Me.TxtEHandSh = New System.Windows.Forms.TextBox()
        Me.TxtERej = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRows = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCol = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCell = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbInterval = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(536, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Error Message"
        '
        'TxtErr
        '
        Me.TxtErr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtErr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtErr.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtErr.ForeColor = System.Drawing.Color.Blue
        Me.TxtErr.Location = New System.Drawing.Point(540, 22)
        Me.TxtErr.Multiline = True
        Me.TxtErr.Name = "TxtErr"
        Me.TxtErr.ReadOnly = True
        Me.TxtErr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtErr.Size = New System.Drawing.Size(315, 524)
        Me.TxtErr.TabIndex = 14
        Me.TxtErr.Text = "Error message"
        '
        'lblServerResponse
        '
        Me.lblServerResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblServerResponse.AutoSize = True
        Me.lblServerResponse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerResponse.Location = New System.Drawing.Point(857, 0)
        Me.lblServerResponse.Name = "lblServerResponse"
        Me.lblServerResponse.Size = New System.Drawing.Size(112, 19)
        Me.lblServerResponse.TabIndex = 13
        Me.lblServerResponse.Text = "Server Response"
        '
        'TxtSrvRsp
        '
        Me.TxtSrvRsp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSrvRsp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSrvRsp.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSrvRsp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtSrvRsp.Location = New System.Drawing.Point(861, 22)
        Me.TxtSrvRsp.Multiline = True
        Me.TxtSrvRsp.Name = "TxtSrvRsp"
        Me.TxtSrvRsp.ReadOnly = True
        Me.TxtSrvRsp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSrvRsp.Size = New System.Drawing.Size(315, 604)
        Me.TxtSrvRsp.TabIndex = 12
        Me.TxtSrvRsp.Text = "Waiting ..."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 632)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.LblFtr})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1188, 22)
        Me.StatusBar1.TabIndex = 16
        Me.StatusBar1.Text = "xxx"
        '
        'LblFtr
        '
        Me.LblFtr.Name = "LblFtr"
        Me.LblFtr.Width = 750
        '
        'LblERej
        '
        Me.LblERej.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblERej.Location = New System.Drawing.Point(21, 118)
        Me.LblERej.Name = "LblERej"
        Me.LblERej.Size = New System.Drawing.Size(112, 20)
        Me.LblERej.TabIndex = 20
        Me.LblERej.Text = "Rejected :"
        Me.LblERej.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblEHandSh
        '
        Me.LblEHandSh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEHandSh.Location = New System.Drawing.Point(21, 92)
        Me.LblEHandSh.Name = "LblEHandSh"
        Me.LblEHandSh.Size = New System.Drawing.Size(112, 20)
        Me.LblEHandSh.TabIndex = 19
        Me.LblEHandSh.Text = "HandShaked :"
        Me.LblEHandSh.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblERtv
        '
        Me.LblERtv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblERtv.Location = New System.Drawing.Point(21, 35)
        Me.LblERtv.Name = "LblERtv"
        Me.LblERtv.Size = New System.Drawing.Size(112, 20)
        Me.LblERtv.TabIndex = 18
        Me.LblERtv.Text = "Retrived :"
        Me.LblERtv.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblEDrp
        '
        Me.LblEDrp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEDrp.Location = New System.Drawing.Point(21, 63)
        Me.LblEDrp.Name = "LblEDrp"
        Me.LblEDrp.Size = New System.Drawing.Size(112, 20)
        Me.LblEDrp.TabIndex = 17
        Me.LblEDrp.Text = "Droped :"
        Me.LblEDrp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtErtv
        '
        Me.TxtErtv.Location = New System.Drawing.Point(137, 35)
        Me.TxtErtv.Name = "TxtErtv"
        Me.TxtErtv.Size = New System.Drawing.Size(100, 20)
        Me.TxtErtv.TabIndex = 21
        Me.TxtErtv.Text = "0"
        Me.TxtErtv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEDrp
        '
        Me.TxtEDrp.Location = New System.Drawing.Point(137, 63)
        Me.TxtEDrp.Name = "TxtEDrp"
        Me.TxtEDrp.Size = New System.Drawing.Size(100, 20)
        Me.TxtEDrp.TabIndex = 22
        Me.TxtEDrp.Text = "0"
        Me.TxtEDrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEHandSh
        '
        Me.TxtEHandSh.Location = New System.Drawing.Point(137, 92)
        Me.TxtEHandSh.Name = "TxtEHandSh"
        Me.TxtEHandSh.Size = New System.Drawing.Size(100, 20)
        Me.TxtEHandSh.TabIndex = 23
        Me.TxtEHandSh.Text = "0"
        Me.TxtEHandSh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtERej
        '
        Me.TxtERej.Location = New System.Drawing.Point(137, 120)
        Me.TxtERej.Name = "TxtERej"
        Me.TxtERej.Size = New System.Drawing.Size(100, 20)
        Me.TxtERej.TabIndex = 24
        Me.TxtERej.Text = "0"
        Me.TxtERej.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Emails"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(135, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Counters"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtRows
        '
        Me.TxtRows.Location = New System.Drawing.Point(137, 146)
        Me.TxtRows.Name = "TxtRows"
        Me.TxtRows.Size = New System.Drawing.Size(100, 20)
        Me.TxtRows.TabIndex = 28
        Me.TxtRows.Text = "0"
        Me.TxtRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Total Rows :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtCol
        '
        Me.TxtCol.Location = New System.Drawing.Point(137, 172)
        Me.TxtCol.Name = "TxtCol"
        Me.TxtCol.Size = New System.Drawing.Size(100, 20)
        Me.TxtCol.TabIndex = 30
        Me.TxtCol.Text = "0"
        Me.TxtCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Total Columns :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtCell
        '
        Me.TxtCell.Location = New System.Drawing.Point(137, 198)
        Me.TxtCell.Name = "TxtCell"
        Me.TxtCell.Size = New System.Drawing.Size(100, 20)
        Me.TxtCell.TabIndex = 32
        Me.TxtCell.Text = "0"
        Me.TxtCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Total Cells :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CmbInterval
        '
        Me.CmbInterval.FormattingEnabled = True
        Me.CmbInterval.Location = New System.Drawing.Point(340, 34)
        Me.CmbInterval.Name = "CmbInterval"
        Me.CmbInterval.Size = New System.Drawing.Size(121, 21)
        Me.CmbInterval.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(336, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Time Intrval"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MRSEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1188, 654)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbInterval)
        Me.Controls.Add(Me.TxtCell)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCol)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtRows)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtERej)
        Me.Controls.Add(Me.TxtEHandSh)
        Me.Controls.Add(Me.TxtEDrp)
        Me.Controls.Add(Me.TxtErtv)
        Me.Controls.Add(Me.LblERej)
        Me.Controls.Add(Me.LblEHandSh)
        Me.Controls.Add(Me.LblERtv)
        Me.Controls.Add(Me.LblEDrp)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtErr)
        Me.Controls.Add(Me.lblServerResponse)
        Me.Controls.Add(Me.TxtSrvRsp)
        Me.Name = "MRSEx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MRSEx"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LblFtr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtErr As TextBox
    Friend WithEvents lblServerResponse As Label
    Friend WithEvents TxtSrvRsp As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents LblFtr As StatusBarPanel
    Friend WithEvents LblERej As Label
    Friend WithEvents LblEHandSh As Label
    Friend WithEvents LblERtv As Label
    Friend WithEvents LblEDrp As Label
    Friend WithEvents TxtErtv As TextBox
    Friend WithEvents TxtEDrp As TextBox
    Friend WithEvents TxtEHandSh As TextBox
    Friend WithEvents TxtERej As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtRows As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtCol As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtCell As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbInterval As ComboBox
    Friend WithEvents Label7 As Label
End Class
