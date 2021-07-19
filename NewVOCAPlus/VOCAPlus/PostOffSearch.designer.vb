<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PostOffSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostOffSearch))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ChckEMS = New System.Windows.Forms.CheckBox()
        Me.ChckEXP = New System.Windows.Forms.CheckBox()
        Me.ChckATM = New System.Windows.Forms.CheckBox()
        Me.ChckTrnsf = New System.Windows.Forms.CheckBox()
        Me.ChckTrnReciv = New System.Windows.Forms.CheckBox()
        Me.ChckCivil = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(291, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 27)
        Me.Label16.TabIndex = 286
        Me.Label16.Text = "بحث :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(357, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.Size = New System.Drawing.Size(331, 35)
        Me.txtSearch.TabIndex = 285
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(295, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1473, 637)
        Me.DataGridView1.TabIndex = 287
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 16.0!)
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImgLst
        Me.TreeView1.Location = New System.Drawing.Point(12, 53)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.SelectedImageIndex = 3
        Me.TreeView1.Size = New System.Drawing.Size(277, 490)
        Me.TreeView1.TabIndex = 288
        '
        'ImgLst
        '
        Me.ImgLst.ImageStream = CType(resources.GetObject("ImgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLst.Images.SetKeyName(0, "Sector.png")
        Me.ImgLst.Images.SetKeyName(1, "Area.png")
        Me.ImgLst.Images.SetKeyName(2, "home.png")
        Me.ImgLst.Images.SetKeyName(3, "Next.png")
        '
        'ChckEMS
        '
        Me.ChckEMS.AutoSize = True
        Me.ChckEMS.Location = New System.Drawing.Point(27, 549)
        Me.ChckEMS.Name = "ChckEMS"
        Me.ChckEMS.Size = New System.Drawing.Size(71, 17)
        Me.ChckEMS.TabIndex = 289
        Me.ChckEMS.Text = "بريد سريع"
        Me.ChckEMS.UseVisualStyleBackColor = True
        '
        'ChckEXP
        '
        Me.ChckEXP.AutoSize = True
        Me.ChckEXP.Location = New System.Drawing.Point(27, 572)
        Me.ChckEXP.Name = "ChckEXP"
        Me.ChckEXP.Size = New System.Drawing.Size(101, 17)
        Me.ChckEXP.TabIndex = 290
        Me.ChckEXP.Text = "Express Parcels"
        Me.ChckEXP.UseVisualStyleBackColor = True
        '
        'ChckATM
        '
        Me.ChckATM.AutoSize = True
        Me.ChckATM.Location = New System.Drawing.Point(27, 595)
        Me.ChckATM.Name = "ChckATM"
        Me.ChckATM.Size = New System.Drawing.Size(47, 17)
        Me.ChckATM.TabIndex = 291
        Me.ChckATM.Text = "ATM"
        Me.ChckATM.UseVisualStyleBackColor = True
        '
        'ChckTrnsf
        '
        Me.ChckTrnsf.AutoSize = True
        Me.ChckTrnsf.Location = New System.Drawing.Point(27, 618)
        Me.ChckTrnsf.Name = "ChckTrnsf"
        Me.ChckTrnsf.Size = New System.Drawing.Size(83, 17)
        Me.ChckTrnsf.TabIndex = 292
        Me.ChckTrnsf.Text = "حوالات فورية"
        Me.ChckTrnsf.UseVisualStyleBackColor = True
        '
        'ChckTrnReciv
        '
        Me.ChckTrnReciv.AutoSize = True
        Me.ChckTrnReciv.Location = New System.Drawing.Point(27, 641)
        Me.ChckTrnReciv.Name = "ChckTrnReciv"
        Me.ChckTrnReciv.Size = New System.Drawing.Size(124, 17)
        Me.ChckTrnReciv.TabIndex = 293
        Me.ChckTrnReciv.Text = "استقبال حوالات دولية"
        Me.ChckTrnReciv.UseVisualStyleBackColor = True
        '
        'ChckCivil
        '
        Me.ChckCivil.AutoSize = True
        Me.ChckCivil.Location = New System.Drawing.Point(27, 664)
        Me.ChckCivil.Name = "ChckCivil"
        Me.ChckCivil.Size = New System.Drawing.Size(93, 17)
        Me.ChckCivil.TabIndex = 294
        Me.ChckCivil.Text = "الأحوال المدنية"
        Me.ChckCivil.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.recpurple
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 35)
        Me.Button1.TabIndex = 295
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Collapse
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Location = New System.Drawing.Point(143, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 296
        Me.ToolTip1.SetToolTip(Me.Button2, "Collapse All")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.VOCAPlus.My.Resources.Resources.Expand
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.Location = New System.Drawing.Point(179, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 297
        Me.ToolTip1.SetToolTip(Me.Button3, "Expand All")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(974, 693)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(77, 25)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(711, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(228, 27)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "البحث باسم أو عنوان المكتب"
        '
        'PostOffSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1796, 768)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ChckCivil)
        Me.Controls.Add(Me.ChckTrnReciv)
        Me.Controls.Add(Me.ChckTrnsf)
        Me.Controls.Add(Me.ChckATM)
        Me.Controls.Add(Me.ChckEXP)
        Me.Controls.Add(Me.ChckEMS)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "PostOffSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث مكاتب البريد"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ChckEMS As CheckBox
    Friend WithEvents ChckEXP As CheckBox
    Friend WithEvents ChckATM As CheckBox
    Friend WithEvents ChckTrnsf As CheckBox
    Friend WithEvents ChckTrnReciv As CheckBox
    Friend WithEvents ChckCivil As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button2 As Button
    Friend WithEvents ImgLst As ImageList
    Friend WithEvents Label2 As Label
End Class
