Public Class Form1
    Dim MailTable As New DataTable
    Dim Span_ As New TimeSpan
    Public Rws As Integer
    Public Col As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Private Sub SecTimer_Tick(sender As Object, e As EventArgs) Handles SecTimer.Tick
        Dim ts1 As TimeSpan = TimeSpan.Parse("00:00:01")

        StatusBarPanel1.Text = "Next Job Will Be After : " & (Span_ - ts1).ToString
        Span_ = Span_ - ts1
    End Sub
    Private Function PrivExp(sQlfLNm As String) As String
        Errmsg = Nothing
        Dim XLApp As Microsoft.Office.Interop.Excel.Application
        Dim XLWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim XLWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim DtCol As String = "" 'رقم عمود التاريخ عشان اعمل الفورمات بتاعه


        Try                                                                                                       'Try If there is available Connection
            If ExpDTable.Rows.Count > 0 Then
                Distin = "D:\" & sQlfLNm & Format(Now, "yyyy-MM-dd_HH_mm") & ".xlsx"
#Region "Change Columns Names"
                'ExpDTable.Columns(0).ColumnName = "شكوى / استفسار"
                'ExpDTable.Columns(1).ColumnName = "رقم الشكوى"
                'ExpDTable.Columns(2).ColumnName = "تاريخ الشكوى"
                'ExpDTable.Columns(3).ColumnName = "تاريخ الإغلاق"
                'ExpDTable.Columns(4).ColumnName = "مدة الإغلاق"
                'ExpDTable.Columns(5).ColumnName = "مصدر الشكوى"
                'ExpDTable.Columns(6).ColumnName = "اسم العميل"
                'ExpDTable.Columns(7).ColumnName = "رقم التليفون1"
                'ExpDTable.Columns(8).ColumnName = "رقم التليفون2"
                'ExpDTable.Columns(9).ColumnName = "البريد الإلكتروني"
                'ExpDTable.Columns(10).ColumnName = "العنوان"
                'ExpDTable.Columns(11).ColumnName = "الرقم القومي"
                'ExpDTable.Columns(12).ColumnName = "رقم الشحنة"
                'ExpDTable.Columns(13).ColumnName = "رقم أمر الدفع"
                'ExpDTable.Columns(14).ColumnName = "رقم الكارت"
                'ExpDTable.Columns(15).ColumnName = "مبلغ العملية"
                'ExpDTable.Columns(16).ColumnName = "تاريخ العملية"
                'ExpDTable.Columns(17).ColumnName = "نوع الخدمة"
                'ExpDTable.Columns(18).ColumnName = "اسم المنتج"
                'ExpDTable.Columns(19).ColumnName = "نوع الشكوى"
                'ExpDTable.Columns(20).ColumnName = "بلد الراسل"
                'ExpDTable.Columns(21).ColumnName = "بلد المرسل إلية"
                'ExpDTable.Columns(22).ColumnName = "اسم المكتب"
                'ExpDTable.Columns(23).ColumnName = "المنطقة"
                'ExpDTable.Columns(24).ColumnName = "تفاصيل الشكوى"
                'ExpDTable.Columns(25).ColumnName = "حالة الشكوى"
                'ExpDTable.Columns(26).ColumnName = "حالة المتابعة"
                'ExpDTable.Columns(27).ColumnName = "محرر الشكوى"
                'ExpDTable.Columns(28).ColumnName = "Team Leader"
                'ExpDTable.Columns(29).ColumnName = "متابع الشكوى"
                'ExpDTable.Columns(30).ColumnName = "المجموعة"
                'ExpDTable.Columns(31).ColumnName = "معادة الفتح"
                'ExpDTable.Columns(32).ColumnName = "تاريخ استلام الشكوى"
                'ExpDTable.Columns(33).ColumnName = "مدة التوزيع"
                'ExpDTable.Columns(34).ColumnName = "مدة الاستلام"
                'ExpDTable.Columns(35).ColumnName = "RecievedRange"
                'ExpDTable.Columns(36).ColumnName = "كود متابع الشكوى"
                'ExpDTable.Columns(37).ColumnName = "كود محرر الشكوى"
                'ExpDTable.Columns(38).ColumnName = "تاريخ آخر تحديث"
                'ExpDTable.Columns(39).ColumnName = "نص التحديث"
                'ExpDTable.Columns(40).ColumnName = "محرر التحديث"
                'ExpDTable.Columns(41).ColumnName = "طبيعة محرر التحديث"

#End Region

                StatusBarPanel2.Text = "جاري استخراج عدد " & ExpDTable.Rows.Count & " بيان"
                XLApp = New Microsoft.Office.Interop.Excel.Application
                XLWrkBk = XLApp.Workbooks.Add(misValue)
                XLWrkSht = XLWrkBk.Sheets("Sheet1")

                XLWrkBk.Title = ("VOCA Plus Auto Exported Data")
                XLWrkBk.Subject = ("Export Screen")
                XLWrkBk.Author = ("Ashraf Farag")
                XLWrkBk.Comments = ("VOCA+")

                'Set Signature
                XLWrkSht.Cells(1, 1) = "Powered By VOCA Plus"
                XLWrkSht.Cells(2, 1) = "Ashraf Farag"
                XLWrkSht.Cells(3, 1) = "'- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
                XLWrkSht.Rows("1:3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                XLWrkSht.Rows("1:3").Font.FontStyle = "Bold"
                XLWrkSht.Rows("1:1").font.color = Color.Red
                XLWrkSht.Rows("1:3").Font.Size = 12
                XLWrkSht.Rows("1:1").Font.Name = "Times New Roman"
                XLWrkSht.Rows("2:2").Font.Name = "Lucida Handwriting"
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Font.Color = Color.Black
                'Set Merge Signature Cells
                XLWrkSht.Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(1, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(2, 1), XLWrkSht.Cells(2, ExpDTable.Columns.Count)).Merge()
                XLWrkSht.Range(XLWrkSht.Cells(3, 1), XLWrkSht.Cells(3, ExpDTable.Columns.Count)).Merge()

                'Format All Rang as Text Befor write Rows To Prevent data lose
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).NumberFormat = "0"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"

                For Col = 0 To ExpDTable.Columns.Count - 1    ' Header Colum
                    XLWrkSht.Cells(4, Col + 1) = ExpDTable.Columns(Col).ToString
                    If ExpDTable.Columns(Col).ToString.Contains("Date") Or ExpDTable.Columns(Col).ToString.Contains("تاريخ") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "yyyy/MM/dd hh:mm " 'Date Columns
                    ElseIf ExpDTable.Columns(Col).ToString.Contains("تليفون") Or ExpDTable.Columns(Col).ToString.Contains("Phone") Or ExpDTable.Columns(Col).ToString.Contains("كارت") Or ExpDTable.Columns(Col).ToString.Contains("قومي") Then
                        XLWrkSht.Range(XLWrkSht.Cells(1, Col + 1), XLWrkSht.Cells(ExpDTable.Rows.Count + 4, Col + 1)).NumberFormat = "@" 'Date Columns
                    End If
                Next Col

                'Set Backcolor, Wrap Text, H Aligment, font name and font size for All Header
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Interior.Color = Color.FromArgb(0, 176, 80)
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Name = "Times New Roman"
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).Font.Size = 14
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).WrapText = True
                XLWrkSht.Range(XLWrkSht.Cells(4, 1), XLWrkSht.Cells(4, ExpDTable.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Invoke(Sub() Timer1.Start())

                For Rws = 0 To ExpDTable.Rows.Count - 1
                    For Col = 0 To ExpDTable.Columns.Count - 1
                        XLWrkSht.Cells(Rws + 5, Col + 1) = ExpDTable.Rows(Rws).Item(Col).ToString
                    Next Col
                    'Invoke(Sub() ProgressBar1.Value = Rws + 1)
                    'Invoke(Sub() WelcomeScreen.StatBrPnlAr.Text = "جاري استخراج عدد " & Rws + 1 & " من " & ExpDTable.Rows.Count)
                    'GC.Collect()
                    'FlushMemory()
                Next Rws
                With XLWrkSht
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Color = Color.Black
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(XLWrkSht.Cells(1, 1), XLWrkSht.Cells(Rws + 4, Col)).WrapText = False
                    .Cells.Columns.AutoFit()
                    .Columns("Y").ColumnWidth = 30
                    .Columns("AN").ColumnWidth = 30
                    '.Cells.EntireColumn.AutoFit()
                End With

                XLWrkSht.DisplayRightToLeft = True
                XLWrkSht.SaveAs(Distin)
                XLWrkBk.Close()
                XLApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkBk)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XLWrkSht)
                StatusBarPanel2.Text = "تم استخراج عدد " & ExpDTable.Rows.Count & " بيان إلى MyDocuments"
            Else
                StatusBarPanel2.Text = "لا توجد بيانات لإستخراجها في المدة المحددة"
        End If
        Catch ex As Exception
            Errmsg = "X"
            GoTo End_
        End Try

        XLApp = Nothing
        XLWrkBk = Nothing
        XLWrkSht = Nothing
        Invoke(Sub() StatusBarPanel2.Text = "")
        Invoke(Sub() Timer1.Stop())
End_:
        Return Errmsg
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        SecTimer.Stop()
        StatusBarPanel2.Text = "Last Job Was On : " & Now
        Span_ = TimeSpan.Parse("00:01:00")
        Dim column As New DataGridViewCheckBoxColumn()
        Dim STRQury As String = "select [MailSQL]
      ,[MailSTR]
      ,[MailTo]
      ,[MailCc]
      ,[MailSub]
      ,[MailBody]
      ,[MailTime]
      ,[MailRun]
      ,[MailRule] from [AutoMail]"
        sqlCon = New SqlConnection(strConn)
        sqlComm.Connection = sqlCon
        sqlCon.Open()

        sqlComm.CommandText = STRQury
        SQLTblAdptr.SelectCommand = sqlComm

        MailTable.Rows.Clear()
        MailTable.Columns.Clear()
        'DataGridView1.Rows.Clear()
        'DataGridView1.Columns.Clear()
        SQLTblAdptr.Fill(MailTable)

        DataGridView1.DataSource = MailTable

        Dim ff As New DataTable
        For cnt = 0 To MailTable.Rows.Count - 1
            ExpDTable.Rows.Clear()
            ExpDTable.Columns.Clear()
            If GetTbl(MailTable.Rows(cnt).Item(1), ExpDTable) = Nothing Then
                If PrivExp(MailTable.Rows(cnt).Item(4)) = Nothing Then
                    StatusBarPanel2.Text = "جاري ارسال أيميل إلى  " & MailTable.Rows(cnt).Item(2)
                    If SndExchngMil(MailTable.Rows(cnt).Item(2),,, MailTable.Rows(cnt).Item(4), MailTable.Rows(cnt).Item(5),, Distin, Distin) = Nothing Then
                        Distin = ""
                        StatusBarPanel2.Text = ""
                    Else
                        StatusBarPanel1.Text = "Err : " & Now & " Send Mail"
                    End If
                Else
                    StatusBarPanel1.Text = "Err : " & Now & " Can't Export"
                End If
            Else
                StatusBarPanel1.Text = "Err : " & Now & " Can't get Mail Table Data"
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'SndExchngMil("ahmed-rady@egyptpost.org", "eman.hassan@egyptpost.org",, "Test", "ازيك يا احمد وازيك يا ايما", 2,,)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class
