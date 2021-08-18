Imports Microsoft.VisualBasic.ApplicationServices

Public Class Categories
    Private Sub Categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CatTbl As DataTable = New DataTable
        Dim TempNode() As TreeNode
        UserTree.Nodes.Add("X0", "Root", 1, 3)
        '                 0  ,     1    ,   2 
        If PublicCode.GetTbl("SELECT UCatId, UCatIdSub, UCatNm FROM IntUserCat WHERE (UCatLvl <> 0) ORDER BY UCatIdSub", CatTbl, "1016&H") = Nothing Then
            For Cnt_ = 0 To CatTbl.Rows.Count - 1
                TempNode = UserTree.Nodes.Find("X" & CatTbl(Cnt_).Item(1).ToString, True)
                TempNode(0).Nodes.Add("X" & CatTbl(Cnt_).Item(0).ToString, CatTbl(Cnt_).Item(2).ToString, 4, 5)
                If TempNode(0).Nodes.Count > 0 Then
                    TempNode(0).ImageIndex = 4
                    TempNode(0).SelectedImageIndex = 5
                End If
            Next Cnt_
            '                0  ,   1   ,     2      
            PublicCode.GetTbl("Select UsrId, UsrCat, UsrRealNm From dbo.Int_user Where (UsrSusp = 0) And (UsrCat <> 0) Order By UsrCat, UsrId", UserTable, "1016&H")
            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find("X" & UserTable(Cnt_).Item(1).ToString, True)
                TempNode(0).Nodes.Add(UserTable(Cnt_).Item(0).ToString & "-" & UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(0).ToString & " - " & UserTable(Cnt_).Item(2).ToString, 0, 2)
                If TempNode(0).Nodes.Count > 0 Then
                    TempNode(0).ImageIndex = 4
                    TempNode(0).SelectedImageIndex = 5
                End If
            Next Cnt_
        Else
            WelcomeScreen.StatBrPnlEn.Text = "  Offline - Can't open User Create Form...  "
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
            Close()
        End If

    End Sub
    Private Sub UserTree_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles UserTree.ItemDrag
        If Strings.Left(e.Item.name, 1) <> "X" Then
            DoDragDrop(e.Item, DragDropEffects.Move)  'Set the drag node and initiate the DragDrop
        End If
    End Sub
    Private Sub UserTree_DragEnter(sender As Object, e As DragEventArgs) Handles UserTree.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then '  See if TreeNode is being dragged
            e.Effect = DragDropEffects.Move                                  '  Found then move effect
        Else
            e.Effect = DragDropEffects.None '                                   Not found no move
        End If
    End Sub
    Private Sub UserTree_DragOver(sender As Object, e As DragEventArgs) Handles UserTree.DragOver
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
        '       When the mouse moves over nodes, it highlighting the node that is the Current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim TrgtNode As TreeNode = selectedTreeview.GetNodeAt(pt)
        '       See if the targetNode is Currently selected, if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is TrgtNode) Then
            selectedTreeview.SelectedNode = TrgtNode '             Select the node Currently under the cursor

            'Check that the selected node is not the dropNode and also that it is not a child of the dropNode and is an invalid target
            Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Do Until TrgtNode Is Nothing
                If TrgtNode Is DrpNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                TrgtNode = TrgtNode.Parent
            Loop
        End If
        e.Effect = DragDropEffects.Move 'Currently selected node is a suitable target
    End Sub
    Private Sub UserTree_DragDrop(sender As Object, e As DragEventArgs) Handles UserTree.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
        Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode) 'Get the TreeNode being dragged
        Dim TrgtNode As TreeNode = selectedTreeview.SelectedNode 'The target node was selected from the DragOver event

        If TrgtNode Is Nothing Then  '   If there is no target Node do nothing else add it at end of the drop Node as child
            Exit Sub
        ElseIf DrpNode Is TrgtNode.Parent Then  '    If the  target node is a child in the drope node 
            Exit Sub
        ElseIf TrgtNode Is DrpNode Then
        ElseIf Strings.Left(TrgtNode.name, 1) <> "X" Then
            Exit Sub
        Else
            DrpNode.Remove()                '   Remove the drop node from its Current location
            TrgtNode.Nodes.Add(DrpNode)     '   Add the drop node to tthe new location
        End If
        DrpNode.EnsureVisible()
        selectedTreeview.SelectedNode = DrpNode ' make the change here of the catagory and sub catagory
        DrpNode.Name = Split(DrpNode.Text, "-")(0) & "-" & Strings.Right(TrgtNode.Name, TrgtNode.Name.Length - 1)

        'If InsUpd("update int_user set UsrCat = " & TrgtNode.Name & " Where (UsrId = " & Split(DrpNode.Text, "-")(3) & ");") <> Nothing Then
        '    MsgErr(Errmsg)
        'End If

    End Sub
End Class