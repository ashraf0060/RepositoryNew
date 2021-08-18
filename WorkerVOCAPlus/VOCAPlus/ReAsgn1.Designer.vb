<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReAsgn1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReAsgn1))
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtFollNm = New System.Windows.Forms.TextBox()
        Me.BtnGet = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCompId = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TxtComp = New System.Windows.Forms.TextBox()
        Me.TxtProd = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtDetails = New System.Windows.Forms.TextBox()
        Me.TxtDt = New System.Windows.Forms.TextBox()
        Me.TxtNm = New System.Windows.Forms.TextBox()
        Me.TxtPh1 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtCard = New System.Windows.Forms.TextBox()
        Me.TxtTrck = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblMsg.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblMsg.ForeColor = System.Drawing.Color.Green
        Me.LblMsg.Location = New System.Drawing.Point(486, 435)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(698, 23)
        Me.LblMsg.TabIndex = 2121
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(502, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 2120
        Me.Label2.Text = "متابع الشكوى:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtFollNm
        '
        Me.TxtFollNm.AccessibleDescription = ""
        Me.TxtFollNm.AccessibleName = ""
        Me.TxtFollNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFollNm.Location = New System.Drawing.Point(583, 175)
        Me.TxtFollNm.Name = "TxtFollNm"
        Me.TxtFollNm.ReadOnly = True
        Me.TxtFollNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFollNm.Size = New System.Drawing.Size(229, 20)
        Me.TxtFollNm.TabIndex = 2119
        Me.TxtFollNm.TabStop = False
        Me.TxtFollNm.Tag = "تليفون العميل 1"
        '
        'BtnGet
        '
        Me.BtnGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGet.BackColor = System.Drawing.Color.White
        Me.BtnGet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnGet.FlatAppearance.BorderSize = 0
        Me.BtnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGet.Font = New System.Drawing.Font("Times New Roman", 1.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGet.ForeColor = System.Drawing.Color.Transparent
        Me.BtnGet.Location = New System.Drawing.Point(712, 16)
        Me.BtnGet.Name = "BtnGet"
        Me.BtnGet.Size = New System.Drawing.Size(50, 50)
        Me.BtnGet.TabIndex = 2102
        Me.BtnGet.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtnGet.UseVisualStyleBackColor = False
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackColor = System.Drawing.Color.White
        Me.CloseBtn.BackgroundImage = Global.VOCAPlus.My.Resources.Resources._Exit1
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseBtn.FlatAppearance.BorderSize = 0
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBtn.Location = New System.Drawing.Point(1108, 485)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(64, 64)
        Me.CloseBtn.TabIndex = 2117
        Me.CloseBtn.TabStop = False
        Me.ToolTip1.SetToolTip(Me.CloseBtn, "خروج")
        Me.CloseBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(477, 35)
        Me.Label1.MaximumSize = New System.Drawing.Size(100, 50)
        Me.Label1.MinimumSize = New System.Drawing.Size(100, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2116
        Me.Label1.Text = "رقم الشكوى :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtCompId
        '
        Me.TxtCompId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompId.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TxtCompId.Location = New System.Drawing.Point(583, 32)
        Me.TxtCompId.Name = "TxtCompId"
        Me.TxtCompId.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtCompId.Size = New System.Drawing.Size(115, 26)
        Me.TxtCompId.TabIndex = 2103
        Me.TxtCompId.Tag = "نوع الخدمة"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(502, 89)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label34.Size = New System.Drawing.Size(75, 20)
        Me.Label34.TabIndex = 2115
        Me.Label34.Text = "التاريخ :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(502, 155)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label37.Size = New System.Drawing.Size(75, 20)
        Me.Label37.TabIndex = 2114
        Me.Label37.Text = "تليفون1 :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(502, 119)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label36.Size = New System.Drawing.Size(75, 17)
        Me.Label36.TabIndex = 2113
        Me.Label36.Text = "اسم العميل :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtComp
        '
        Me.TxtComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtComp.Location = New System.Drawing.Point(924, 175)
        Me.TxtComp.Name = "TxtComp"
        Me.TxtComp.ReadOnly = True
        Me.TxtComp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtComp.Size = New System.Drawing.Size(229, 20)
        Me.TxtComp.TabIndex = 2112
        Me.TxtComp.TabStop = False
        Me.TxtComp.Tag = "نوع الشكوى"
        '
        'TxtProd
        '
        Me.TxtProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProd.Location = New System.Drawing.Point(924, 143)
        Me.TxtProd.Name = "TxtProd"
        Me.TxtProd.ReadOnly = True
        Me.TxtProd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtProd.Size = New System.Drawing.Size(229, 20)
        Me.TxtProd.TabIndex = 2111
        Me.TxtProd.TabStop = False
        Me.TxtProd.Tag = "نوع الخدمة"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Blue
        Me.Label43.Location = New System.Drawing.Point(513, 303)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 34)
        Me.Label43.TabIndex = 2110
        Me.Label43.Text = "التفاصيل :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtDetails
        '
        Me.TxtDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDetails.Location = New System.Drawing.Point(583, 222)
        Me.TxtDetails.Multiline = True
        Me.TxtDetails.Name = "TxtDetails"
        Me.TxtDetails.ReadOnly = True
        Me.TxtDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDetails.Size = New System.Drawing.Size(570, 167)
        Me.TxtDetails.TabIndex = 2109
        Me.TxtDetails.TabStop = False
        Me.TxtDetails.Tag = "Details"
        '
        'TxtDt
        '
        Me.TxtDt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDt.Location = New System.Drawing.Point(583, 82)
        Me.TxtDt.Name = "TxtDt"
        Me.TxtDt.ReadOnly = True
        Me.TxtDt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDt.Size = New System.Drawing.Size(229, 20)
        Me.TxtDt.TabIndex = 2106
        Me.TxtDt.TabStop = False
        Me.TxtDt.Tag = "Date"
        '
        'TxtNm
        '
        Me.TxtNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNm.Location = New System.Drawing.Point(583, 114)
        Me.TxtNm.Name = "TxtNm"
        Me.TxtNm.ReadOnly = True
        Me.TxtNm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNm.Size = New System.Drawing.Size(229, 20)
        Me.TxtNm.TabIndex = 2105
        Me.TxtNm.TabStop = False
        Me.TxtNm.Tag = "اسم العميل"
        '
        'TxtPh1
        '
        Me.TxtPh1.AccessibleDescription = ""
        Me.TxtPh1.AccessibleName = ""
        Me.TxtPh1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPh1.Location = New System.Drawing.Point(583, 149)
        Me.TxtPh1.Name = "TxtPh1"
        Me.TxtPh1.ReadOnly = True
        Me.TxtPh1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPh1.Size = New System.Drawing.Size(229, 20)
        Me.TxtPh1.TabIndex = 2104
        Me.TxtPh1.TabStop = False
        Me.TxtPh1.Tag = "تليفون العميل 1"
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Blue
        Me.Label51.Location = New System.Drawing.Point(818, 148)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label51.Size = New System.Drawing.Size(100, 20)
        Me.Label51.TabIndex = 2107
        Me.Label51.Text = "نوع الخدمة :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label52
        '
        Me.Label52.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label52.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Blue
        Me.Label52.Location = New System.Drawing.Point(818, 179)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label52.Size = New System.Drawing.Size(100, 20)
        Me.Label52.TabIndex = 2108
        Me.Label52.Text = "نوع الشكوى :"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'UserTree
        '
        Me.UserTree.BackColor = System.Drawing.SystemColors.Window
        Me.UserTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UserTree.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTree.Location = New System.Drawing.Point(31, 12)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.RightToLeftLayout = True
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowNodeToolTips = True
        Me.UserTree.ShowPlusMinus = False
        Me.UserTree.Size = New System.Drawing.Size(465, 537)
        Me.UserTree.TabIndex = 2122
        Me.UserTree.TabStop = False
        '
        'ImgLst
        '
        Me.ImgLst.ImageStream = CType(resources.GetObject("ImgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLst.Images.SetKeyName(0, "Arrow - Right (5).ico")
        Me.ImgLst.Images.SetKeyName(1, "Arrow - Right (4).ico")
        Me.ImgLst.Images.SetKeyName(2, "arrow-right-3.png")
        Me.ImgLst.Images.SetKeyName(3, "arrow-right-double-3.png")
        '
        'TxtCard
        '
        Me.TxtCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCard.Location = New System.Drawing.Point(924, 114)
        Me.TxtCard.Name = "TxtCard"
        Me.TxtCard.ReadOnly = True
        Me.TxtCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtCard.Size = New System.Drawing.Size(229, 20)
        Me.TxtCard.TabIndex = 2126
        Me.TxtCard.TabStop = False
        Me.TxtCard.Tag = "نوع الشكوى"
        '
        'TxtTrck
        '
        Me.TxtTrck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTrck.Location = New System.Drawing.Point(924, 82)
        Me.TxtTrck.Name = "TxtTrck"
        Me.TxtTrck.ReadOnly = True
        Me.TxtTrck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTrck.Size = New System.Drawing.Size(229, 20)
        Me.TxtTrck.TabIndex = 2125
        Me.TxtTrck.TabStop = False
        Me.TxtTrck.Tag = "نوع الخدمة"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(818, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 2123
        Me.Label3.Text = "رقم الشحنة :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(818, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 2124
        Me.Label4.Text = "رقم الكارت :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ReAsgn1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.TxtCard)
        Me.Controls.Add(Me.TxtTrck)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UserTree)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtFollNm)
        Me.Controls.Add(Me.BtnGet)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCompId)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.TxtComp)
        Me.Controls.Add(Me.TxtProd)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.TxtDetails)
        Me.Controls.Add(Me.TxtDt)
        Me.Controls.Add(Me.TxtNm)
        Me.Controls.Add(Me.TxtPh1)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label52)
        Me.Location = New System.Drawing.Point(1000, 500)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1200, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1200, 600)
        Me.Name = "ReAsgn1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تحويل شكوى"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblMsg As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtFollNm As TextBox
    Friend WithEvents BtnGet As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCompId As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents TxtComp As TextBox
    Friend WithEvents TxtProd As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents TxtDetails As TextBox
    Friend WithEvents TxtDt As TextBox
    Friend WithEvents TxtNm As TextBox
    Friend WithEvents TxtPh1 As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents UserTree As TreeView
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TxtCard As TextBox
    Friend WithEvents TxtTrck As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
