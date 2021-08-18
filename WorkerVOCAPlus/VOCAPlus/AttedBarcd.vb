Imports System.IO
Public Class AttedBarcd
    Dim Brcd As New DataTable
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If PictureBox1.Image Is Nothing Then
            Return
        End If
        Dim SV As SaveFileDialog = New SaveFileDialog()
        SV.Filter = "PNG|*.png"
        If SV.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image.Save(SV.FileName)
        End If
    End Sub
    Private Sub AttedBarcd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        'ServerNm = "My Labtop"
        sqlCon.ConnectionString = strConn
        GetTbl("select UsrId,UsrNm,UsrCat,UsrRealNmEn,Poss.Posstion,Poss.ReportingTo,UsrBarcode from int_user inner join 
                                (SELECT IntUserCat.UCatId, IntUserCat.UCatNmEn AS Posstion, IntUserCat_2.UCatNmEn AS ReportingTo
                                FROM IntUserCat INNER JOIN IntUserCat AS IntUserCat_2 ON IntUserCat.UCatIdSub = IntUserCat_2.UCatId) as Poss on Poss.UCatId = int_user.UsrCat
                                AND LEN(UsrBarcode)>0 where UsrSusp = 0 order by ReportingTo,UsrRealNm", Brcd, "0000&H")
        DataGridView1.DataSource = Brcd
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If PictureBox1.Image Is Nothing Then
        '    Return
        'End If
        Dim SV As FolderBrowserDialog = New FolderBrowserDialog()
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        'SV.RootFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\"
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If SV.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = SV.SelectedPath & "\"
        End If
        For R = 0 To Brcd.Rows.Count - 1
            Label1.Text = "Generating Barcode " & R + 1 & " Of " & Brcd.Rows.Count
            Label1.Refresh()
            Dim Barcode_ As New BarcodeLib.Barcode
            Dim forcolr As Color = Color.Black
            Dim backcolr As Color = Color.Transparent
            Barcode_.BarWidth = 1
            Dim Img As Image = Barcode_.Encode(BarcodeLib.TYPE.CODE128, Brcd.Rows(R).Item("UsrBarcode"), forcolr, backcolr, CInt(Barcode_.BarWidth), CInt(PictureBox1.Height * 0.95))
            PictureBox1.Image = Img

            Dim ImgNm As New Bitmap(200, 50)
            Dim ImgTitle As New Bitmap(200, 50)

            Dim F As Font = New Font("Times New Roman", 12, System.Drawing.FontStyle.Regular)
            Dim W As Graphics = Graphics.FromImage(ImgNm)
            Dim Q As Graphics = Graphics.FromImage(ImgTitle)

            W.DrawString(Brcd.Rows(R).Item("UsrRealNmEn").ToString, F, New SolidBrush(Color.Black), 0, 0)
            Q.DrawString(Brcd.Rows(R).Item("Posstion").ToString, F, New SolidBrush(Color.Black), 0, 0)
            Dim Image3 As New Bitmap(300, 130)
            Using g As Graphics = Graphics.FromImage(Image3)
                g.DrawImage(ImgNm, New Point((Image3.Width - ImgNm.Width) / 2, 10))
                g.DrawImage(ImgTitle, New Point((Image3.Width - ImgTitle.Width) / 2, 30))
                g.DrawImage(Img, New Point((Image3.Width - Barcode_.Width) / 2, 60))
                ' Create pen.
                Dim blackPen As New Pen(Color.Black, 3)

                ' Create rectangle.
                Dim rect As New Rectangle(0, 0, Image3.Width, Image3.Height)

                ' Draw rectangle to screen.
                g.DrawRectangle(blackPen, rect)
            End Using

            Image3.Save(TextBox1.Text & Brcd.Rows(R).Item("UsrNm") & ".png")
            Image3.Dispose()
        Next
        Dim A4Img As New Bitmap(780, 1100)

        Dim FilesInFolder = Directory.GetFiles(TextBox1.Text, "*.png").Count

        Dim files() As String = IO.Directory.GetFiles(TextBox1.Text, "*.png")

        Dim X As Integer = 40
        Dim Y As Integer = 30

        Dim RwCnt As Integer = 0
        Dim PagCnt As Integer = 0
        Dim ItmsCnt As Integer = 0

        For Each file As String In files
            ' Do work, example
            Dim text As String = IO.File.ReadAllText(file)
            Dim imageX As New Bitmap(file)
            'imageX.Save("D:\Barcode\1\" & Split(file, "\")(Split(file, "\").Count - 1))

            Using F As Graphics = Graphics.FromImage(A4Img)

                ' Create pen.
                Dim blackPen As New Pen(Color.Black, 3)

                ' Create rectangle.
                Dim rect As New Rectangle(0, 0, A4Img.Width, A4Img.Height)

                ' Draw rectangle to screen.
                F.DrawRectangle(blackPen, rect)

                If RwCnt = 0 Then
                    F.DrawImage(imageX, New Point(X, Y))
                    X += imageX.Width + 60
                Else
                    F.DrawImage(imageX, New Point(X, Y))
                    If RwCnt = 2 Then
                        X += imageX.Width + 60
                        RwCnt = 0
                    Else
                        X = 40
                        Y += imageX.Height + 20
                    End If
                End If
                RwCnt += 1
                ItmsCnt += 1
                If ItmsCnt / 14 = 1 Then
                    A4Img.Save(TextBox1.Text & PagCnt & ".png")
                    ItmsCnt = 0
                    PagCnt += 1
                    X = 40
                    Y = 30
                    A4Img = New Bitmap(780, 1100)
                End If
            End Using
            Label1.Text = "Saving Pages " & PagCnt
            Label1.Refresh()
        Next
        If ItmsCnt > 0 Then
            A4Img.Save(TextBox1.Text & PagCnt & ".png")
            PagCnt += 1
        End If
        Label1.Text = "Saved  " & PagCnt & " Pages To " & TextBox1.Text
        Label1.Refresh()
        'For Cnt_ = 1 To FilesInFolder
        'Next
    End Sub
    'Public ReadOnly FullName As String = ""
    'Public ReadOnly Name_ As String = ""
    'Public ReadOnly FilesInFolder As Integer = 0
    'Public ReadOnly Exists As Boolean = False
    'Public Sub New(Optional dir As DirectoryInfo = Nothing)
    '    ' First check that a directory has been specified
    '    If dir Is Nothing Then Exit Sub

    '    ' Populate the class properties
    '    FullName = dir.FullName
    '    Name_ = dir.Name
    '    FilesInFolder = dir.GetFiles().Count
    '    Exists = dir.Exists

    'End Sub
End Class