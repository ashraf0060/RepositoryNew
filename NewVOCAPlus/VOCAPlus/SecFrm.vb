Public Class SecFrm
    Private ReadOnly UserTable As DataTable = New DataTable
    Private ReadOnly SwTable As DataTable = New DataTable
    Private ReadOnly SwitemsTable As DataTable = New DataTable
    Dim SlctedNode As TreeNode
    Dim NodeCnt As Integer = 1
    Dim SlctUsrID As Integer
    Dim BeforSecStr As String = ""
    Private ReadOnly SecNODESTHATMATCH As New List(Of TreeNode) 'Tree Search Function
    Private ReadOnly NODESTHATMATCH As New List(Of TreeNode) 'Tree Search Function
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property
    Private Sub SecFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
        SecTree.Size = New Point((WelcomeScreen.Width - FlowLayoutPanel1.Width) * 0.35, Me.Height - 80)
        'UserTree.Size = New Point(SecTree.Width, Me.Height - 80)
        UserTree.Size = New Point((WelcomeScreen.Width - FlowLayoutPanel1.Width) * 0.6, Me.Height - 80)
        BtnSub(Me)
        'Me.Size = New Point(screenWidth, screenHeight)
        WelcomeScreen.StatBrPnlAr.Text = "جاري تحميل البيانات ........................."
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        UserTree.ImageList = ImgLst
        Dim Chldnode2 As TreeNode
        Dim TempNode() As TreeNode
        UserTable.Rows.Clear()
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GetTbl("SELECT IntUserCat.UCatId, IntUserCat.UCatNm + N' - ' + Int_user.UsrRealNm + N' - ' +  CAST(Int_user.UsrId as varchar(10))  , Int_user.UsrId, Int_user.UsrCat FROM IntUserCat INNER JOIN Int_user ON IntUserCat.UCatId = Int_user.UsrCat WHERE (Int_user.UsrCat = 0)", tempTable, "0000&H")
        UserTree.Nodes.Add(tempTable(0).Item(0).ToString, tempTable(0).Item(1).ToString, 1, 3)
        UserTree.Nodes(0).ForeColor = Color.Green
        UserTree.Nodes(0).NodeFont = New Font("Times New Roman", 18, FontStyle.Bold)
        '                0  ,    1  ,     2    ,    3   ,     4     as mix name                 ***   
        GetTbl("Select UsrId, UCatId, UCatIdSub, UCatLvl, UCatNm + N' - ' + UsrRealNm + N' - ' +  CAST(Int_user.UsrId as varchar(10)) AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) AND (dbo.IntUserCat.UCatLvl <> 0) Order By UCatIdSub, UsrId", UserTable, "1022&H")
        On Error Resume Next
        For Cnt_ = 0 To UserTable.Rows.Count - 1
            TempNode = UserTree.Nodes.Find(UserTable(Cnt_).Item(2).ToString, True)
            TempNode(0).Nodes.Add(UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(4).ToString, 0, 2)
            If TempNode(0).Nodes.Count > 0 Then
                TempNode(0).ImageIndex = 1
                TempNode(0).SelectedImageIndex = 3
            End If
        Next Cnt_

        StatusBarPanel1.Text = "تم تحميل عدد " + UserTree.GetNodeCount(True).ToString & " مستخدم"

        SwTable.Clear()
        GetTbl("SELECT SwNm, SwID, SwSer FROM ASwitchboard WHERE (SwType = N'Tab') AND (SwNm <> N'NA') ORDER BY SwID", SwTable, "1022&H")

        For Cnt_ = 0 To SwTable.Rows.Count - 1                      ' fill Tab
            SecTree.Nodes(0).Nodes.Add(SwTable.Rows(Cnt_).Item(1).ToString, SwTable.Rows(Cnt_).Item(1).ToString & "-" & SwTable.Rows(Cnt_).Item(0).ToString)
            SwitemsTable.Clear()
            GetTbl("SELECT SwNm, SwID, SwSer FROM ASwitchboard WHERE (SwType <> N'Tab') AND (SwNm <> N'NA') AND (SwSer = '" & SwTable.Rows(Cnt_).Item(2).ToString & "') ORDER BY SwID", SwitemsTable, "1022&H")
            Chldnode2 = SecTree.Nodes(0).Nodes(Cnt_)
            For Cnt_1 = 0 To SwitemsTable.Rows.Count - 1             ' fill Sub Tab
                Chldnode2.Nodes.Add(SwitemsTable.Rows(Cnt_1).Item(1).ToString, SwitemsTable.Rows(Cnt_1).Item(1).ToString & "-" & SwitemsTable.Rows(Cnt_1).Item(0).ToString)
                Chldnode2.BackColor = Color.Aqua
                Chldnode2.NodeFont = New Font("Times New Roman", 12, FontStyle.Bold)
            Next Cnt_1
        Next Cnt_
        'SwTable.Rows.Clear()
        'GetTbl("SELECT SwNm, SwID, SwSer FROM ASwitchboard WHERE  (SwType = N'Button') ORDER BY SwID", SwTable, "1022&H")
        'For Cnt_ = 0 To SwTable.Rows.Count - 1                      ' fill Button
        '    SecTree.Nodes(1).Nodes.Add(SwTable.Rows(Cnt_).Item(1).ToString, SwTable.Rows(Cnt_).Item(1).ToString & "-" & SwTable.Rows(Cnt_).Item(0).ToString)
        'Next
        SwTable.Rows.Clear()
        GetTbl("SELECT SwNm, SwID, SwSer FROM ASwitchboard WHERE  (SwType = N'System') ORDER BY SwID", SwTable, "1022&H")
        For Cnt_ = 0 To SwTable.Rows.Count - 1                      ' fill System
            SecTree.Nodes(1).Nodes.Add(SwTable.Rows(Cnt_).Item(1).ToString, SwTable.Rows(Cnt_).Item(1).ToString & "-" & SwTable.Rows(Cnt_).Item(0).ToString)
        Next
        SecTree.ExpandAll()
        UserTree.SelectedNode = Nothing
        SecTree.SelectedNode = SecTree.Nodes(0)
        WelcomeScreen.StatBrPnlAr.Text = ""
        AddHandler UserTree.AfterSelect, AddressOf UserTree_AfterSelect
        'Catch ex As Exception
        '    Beep()
        '    AppLog("1003&H" & ex.Message)
        '    MsgInf("فشل في الاتصال، يرجى إعادة المحاولة")
        '    'Me.Close()


    End Sub
    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs)
        If e.Action <> TreeViewAction.Unknown Then  ' The code only executes if the user caused the checked state to change.
            AftrSlct()
        End If
    End Sub
    Private Sub AftrSlct()
        Dim SecTreeNode As TreeNode
        sqlComm.Connection = sqlCon
        sqlComm.CommandText = "SELECT UsrId, UsrLevel FROM Int_user WHERE (UsrId = '" & Split(UserTree.SelectedNode.Text, " - ")(2).ToString & "');"
        sqlComm.CommandType = CommandType.Text
        LblSecLvl_ = ""
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            Reader_ = sqlComm.ExecuteReader
            Reader_.Read()
            BeforSecStr = Reader_!UsrLevel.ToString
            For Cnt_ = 0 To Reader_!UsrLevel.ToString.Length - 1
                SecTreeNode = SecSearchTreeView(SecTree, Cnt_ + 1)
                If IsNothing(SecTreeNode) <> True Then
                    If Mid(Reader_!UsrLevel, Cnt_ + 1, 1) = "A" Or
                        Mid(Reader_!UsrLevel, Cnt_ + 1, 1) = "H" Then
                        SecTreeNode.Checked = True
                        If SecTreeNode.Level > 1 Or SecTreeNode.Level = 1 Then
                            SecTreeNode.ForeColor = Color.DarkGreen
                            SecTreeNode.NodeFont = New Font("Times New Roman", 11, FontStyle.Bold)
                            'ElseIf SecTreeNode.Level = 1 Then
                            '    SecTreeNode.ForeColor = Color.FloralWhite
                            '    SecTreeNode.NodeFont = New Font("Times New Roman", 12, FontStyle.Regular)
                        End If
                    Else
                        SecTreeNode.Checked = False
                        If SecTreeNode.Level > 1 Or SecTreeNode.Level = 1 Then
                            SecTreeNode.ForeColor = Color.Red
                            SecTreeNode.NodeFont = New Font("Arial", 8, FontStyle.Italic)
                        End If
                    End If
                Else
                    'Exit For
                End If
            Next Cnt_
            SlctUsrID = Reader_!UsrId
            Reader_.Close()
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            If UserTree.SelectedNode.Nodes.Count > 0 Then UserTree.SelectedNode.Expand()
        Catch ex As Exception
            AppLog("1004&H", ex.Message, sqlComm.CommandText)
            Reader_.Close()
            MsgErr("كود خطأ : " & "1004&H" & vbCrLf & My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnCls.Click
        Me.Close()
    End Sub
    Private Sub SwTree_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles SecTree.AfterCheck
        If e.Action <> TreeViewAction.Unknown Then  ' The code only executes if the user caused the checked state to change.
            'Dim aaa As Integer = SwTree.SelectedNode.Nodes.Count
            Dim AStat As Boolean = e.Node.Checked
            If e.Node.Checked = True Then
                e.Node.ForeColor = Color.DarkGreen
                e.Node.NodeFont = New Font("Times New Roman", 11, FontStyle.Bold)
            Else
                e.Node.ForeColor = Color.Red
                e.Node.NodeFont = New Font("Arial", 8, FontStyle.Italic)
            End If


            For Cnt_ = 0 To e.Node.Nodes.Count - 1
                e.Node.Nodes(Cnt_).Checked = AStat

                If e.Node.Nodes(Cnt_).Level > 1 Then
                    If AStat = True Then
                        e.Node.Nodes(Cnt_).ForeColor = Color.DarkGreen
                        e.Node.Nodes(Cnt_).NodeFont = New Font("Times New Roman", 12, FontStyle.Regular)
                    Else
                        e.Node.Nodes(Cnt_).ForeColor = Color.Red
                        e.Node.Nodes(Cnt_).NodeFont = New Font("Arial", 10, FontStyle.Italic)
                    End If
                End If

            Next
        End If
    End Sub
    Private Sub AplyBtn_Click(sender As Object, e As EventArgs) Handles BtnAply.Click
        Dim SecTreeNode As TreeNode
        Dim PerStr(99) As String
        For Cnt_ = 0 To PerStr.Count - 1
            SecTreeNode = SecSearchTreeView(SecTree, Cnt_ + 1)
            If IsNothing(SecTreeNode) = False Then

                If SecTreeNode.Checked = True Then
                    'MsgInf(SecTreeNode.Text.ToString & PerStr(Cnt_))
                    PerStr(Cnt_) = "A"
                Else
                    PerStr(Cnt_) = "X"
                End If
            Else
                PerStr(Cnt_) = "X"
            End If

        Next
        LblSecLvl_ = String.Join("", PerStr)
        If BeforSecStr <> String.Join("", PerStr) Then
            If InsUpd("update Int_user set UsrLevel= '" & String.Join("", PerStr) & "' WHERE (UsrId = " & SlctUsrID & ");", "0000&H") = Nothing Then
                MsgBox("Saved")
            End If
        Else
            MsgBox("No Changes")
        End If
    End Sub
    'Dim NodesThatMatch As New List(Of TreeNode)
    Private Function SecSearchTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        SecNODESTHATMATCH.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If
            SecRecursiveSearch(TN, TextToFind)
        Next
        If SecNODESTHATMATCH.Count > 0 Then
            Return SecNODESTHATMATCH(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub SecRecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If

            SecRecursiveSearch(TN, TextToFind)
        Next
    End Sub
    Private Function SearchTheTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        NODESTHATMATCH.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Text.Contains(TextToFind) Then
                NODESTHATMATCH.Add(TN)

            End If
            RecursiveSearch(TN, TextToFind)
        Next

        If NODESTHATMATCH.Count > 0 Then
            For Each TN As TreeNode In TreeView1.Nodes
                If TN.Checked = True Then
                    MsgBox(TN.Text)
                    TreeView1.SelectedNode = TN
                    TN.ForeColor = Color.LightGreen
                End If
            Next
            Return NODESTHATMATCH(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text.Contains(TextToFind) Then
                NODESTHATMATCH.Add(TN)
                TN.Checked = True
            End If
            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Label4.Text = ""
        If IsNothing(SlctedNode) = False Then SlctedNode.BackColor = Color.White
        UserTree.CollapseAll()
        If SearchTheTreeView(UserTree, TreeSrchBx.Text) Is Nothing Then
            Label4.Text = ("No Match Found")
        Else
            NodeCnt = 1
            LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            UserTree.SelectedNode = SearchTheTreeView(UserTree, TreeSrchBx.Text)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
            AftrSlct()
        End If
    End Sub
    Private Sub BtnNxt_Click(sender As Object, e As EventArgs) Handles BtnNxt.Click
        Label4.Text = ""
        If NodeCnt < NODESTHATMATCH.Count Then
            If NodeCnt < NODESTHATMATCH.Count Then
                NodeCnt += 1
                LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            Else
                LblCnt.Text = NODESTHATMATCH.Count & " Of " & NODESTHATMATCH.Count
            End If
            UserTree.SelectedNode = NODESTHATMATCH(NodeCnt - 1)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
            AftrSlct()
        ElseIf NodeCnt = NODESTHATMATCH.Count Then
            Label4.Text = ("This is the Last Record")
        End If
    End Sub
    Private Sub BtnPrvs_Click(sender As Object, e As EventArgs) Handles BtnPrvs.Click
        Label4.Text = ""
        If NodeCnt >= 2 Then
            NodeCnt -= 1
            LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            UserTree.SelectedNode = NODESTHATMATCH(NodeCnt - 1)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
            AftrSlct()
        Else
            Label4.Text = ("This is the First Record")
        End If
    End Sub
    Private Sub UserTree_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles UserTree.BeforeSelect
        If IsNothing(SlctedNode) = False Then
            SlctedNode.BackColor = Color.White
        End If
    End Sub
    Private Sub BtnOpn_Click(sender As Object, e As EventArgs) Handles BtnOpn.Click
        SecFrmSub.Show()
    End Sub
End Class