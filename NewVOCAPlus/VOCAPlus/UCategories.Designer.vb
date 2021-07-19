<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCategories
    Inherits System.Windows.Forms.Form

    'Form Overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCategories))
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ImgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'UserTree
        '
        Me.UserTree.AllowDrop = True
        Me.UserTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        resources.ApplyResources(Me.UserTree, "UserTree")
        Me.UserTree.Name = "UserTree"
        Me.UserTree.ShowLines = False
        Me.UserTree.ShowPlusMinus = False
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
        'UCategories
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UserTree)
        Me.Name = "UCategories"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserTree As TreeView
    Friend WithEvents ImgLst As ImageList
End Class
