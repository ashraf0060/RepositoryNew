
Imports System.Net
Imports System.IO
Public Class HeldNtfReturn
    Dim hldID As Integer
    Dim Ext As String
    Dim HeldTable As DataTable = New DataTable
    Dim UpdtHeldTbl As DataTable = New DataTable()
    Dim Directry As String = "ftp://10.10.26.4/AirportPaperWorkRecieved/"
    'Dim sqlCConCCSYS As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=CSSYS;Persist Security Info=True;User ID=voca;Password=asdasdasD123") ' I Have assigned conn STR here and delete this row from all project
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200      ' Disable close button
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub HeldPapeCnt_eciev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSub(Me)
        GridHeldUpdt.Columns.Add("م", "م")                                 '0
        GridHeldUpdt.Columns.Add("RsvUpdate_time", "تاريخ التحديث")       '1
        GridHeldUpdt.Columns.Add("RsvUpdateTxt", "نص التحديث")            '2
        GridHeldUpdt.Columns.Add("User_RealName", "محرر التحديث")         '3
        GridHeldUpdt.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
        GridHeldUpdt.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridHeldUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

        WelcomeScreen.StatBrPnlAr.Text = ""
    End Sub
    Private Sub GetUpdtEvent()
        UpdtHeldTbl.Rows.Clear()
        If GetTbl("SELECT RsvRelationID, RsvUpdate_time, RsvUpdateTxt, Int_user.UsrRealNm FROM Int_user INNER JOIN RsvUpdate ON Int_user.Usrid = RsvUpdateUser INNER JOIN Rsv ON RsvRelationID =  dbo.Rsv.RsvID where RsvRelationID = " & hldID & " ORDER BY RsvUpdate_time DESC", UpdtHeldTbl, "0000&H") = Nothing Then
            If UpdtHeldTbl.Rows.Count > 0 Then
                GridHeldUpdt.Rows.Clear()
                For Cnt_ = 0 To UpdtHeldTbl.Rows.Count - 1
                    GridHeldUpdt.Rows.Add()
                    GridHeldUpdt.Rows(Cnt_).Cells(0).Value = Cnt_ + 1
                    GridHeldUpdt.Rows(Cnt_).Cells(1).Value = UpdtHeldTbl(Cnt_).Item(1).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(2).Value = UpdtHeldTbl(Cnt_).Item(2).ToString
                    GridHeldUpdt.Rows(Cnt_).Cells(3).Value = UpdtHeldTbl(Cnt_).Item(3).ToString
                Next
                GridHeldUpdt.AutoResizeColumns()
                GridHeldUpdt.Columns(2).Width = 350
                GridHeldUpdt.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                GridHeldUpdt.AutoResizeRows()
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub TxtTrck_TextChanged(sender As Object, e As EventArgs) Handles TxtTrckNtf.TextChanged
        If TxtTrckNtf.TextLength = 13 Then
            FillHldtable()
        Else
            TxtTrck.Text = ""
            TxtDt.Text = ""
            TxtPh.Text = ""
            TxtNm.Text = ""
            TxtAdd.Text = ""
            TxtOrgin.Text = ""
            TxtWieght.Text = ""
            TxtDoc.Text = ""
            TxtReason.Text = ""
            hldID = 0
            GridHeldUpdt.Rows.Clear()
        End If
    End Sub
    Private Sub FillHldtable()
        Lblmssg.Text = "جاري تحميل البيانات ........"
        Lblmssg.Refresh()
        HeldTable.Rows.Clear()
        If GetTbl("select RsvAdID, format(RsvAd.RsvAdDate,'yyyy/MM/dd') As RsvAdDate, (select rsvid from Rsv where RsvID = RsvAd.RsvAdReln) As RsvID, RsvAdTrk, RsvAdNo, (SELECT UsrRealNm FROM Int_user WHERE RsvAdEmpNm = UsrId) AS USRNm, RsvAdRe, 
(select RsvTracing from Rsv where RsvID = RsvAd.RsvAdReln) As RsvTracing, 
(select RsvConsignee from Rsv where RsvID = RsvAd.RsvAdReln) As RsvConsignee,
(select RsvAdd from Rsv where RsvID = RsvAd.RsvAdReln) As RsvAdd,
(select RsvMob from Rsv where RsvID = RsvAd.RsvAdReln) As RsvMob,
(select RsvDate from Rsv where RsvID = RsvAd.RsvAdReln) As RsvDate,
(select RsvWeight from Rsv where RsvID = RsvAd.RsvAdReln) As RsvWeight,
(select RsvDoc from Rsv where RsvID = RsvAd.RsvAdReln) As RsvDoc,
(select RsvReason from Rsv where RsvID = RsvAd.RsvAdReln) As RsvReason,
(select RsvOrgin from Rsv where RsvID = RsvAd.RsvAdReln) As RsvOrgin,
(select CDCountry.CounNm from CDCountry where CDCountry.CounCd = (select RsvOrgin from Rsv where RsvID = RsvAd.RsvAdReln) ) As CounNm
from RsvAd where RsvAdTrk = '" & TxtTrckNtf.Text & "'", HeldTable, "0000&H") = Nothing Then
            If HeldTable.Rows.Count > 0 Then
                If HeldTable.Rows.Count > 1 Then
                    Me.BackColor = Color.Aqua
                    ComboBox2.Enabled = True
                Else
                    ComboBox2.Enabled = False
                    Me.BackColor = Color.White
                End If
                ComboBox2.Items.Clear()
                For Cnt_ = 0 To HeldTable.Rows.Count - 1
                    ComboBox2.Items.Add(Cnt_ + 1)
                Next
                ComboBox2.SelectedIndex = 0
                TxtTrck.Text = HeldTable.Rows(0).Item("RsvTracing").ToString
                TxtDt.Text = HeldTable.Rows(0).Item("RsvAdDate").ToString
                TxtPh.Text = HeldTable.Rows(0).Item("RsvMob").ToString
                TxtNm.Text = HeldTable.Rows(0).Item("RsvConsignee").ToString
                TxtAdd.Text = HeldTable.Rows(0).Item("RsvAdd").ToString
                TxtOrgin.Text = HeldTable.Rows(0).Item("CounNm").ToString
                TxtWieght.Text = HeldTable.Rows(0).Item("RsvWeight").ToString
                TxtDoc.Text = HeldTable.Rows(0).Item("RsvDoc").ToString
                TxtReason.Text = HeldTable.Rows(0).Item("RsvReason").ToString
                hldID = HeldTable.Rows(0).Item("RsvID")
                If HeldTable.Rows(0).Item("RsvAdRe") = True Then
                    Lblmssg.Text = ("تم تسجيل ارتداد الإخطار من قبل")
                    Beep()
                Else
                    If InsTrans("INSERT INTO RsvUpdate ( RsvRelationID, RsvUpdateTxt, RsvUpdateUser, RsvREAD_UNREAD, User_IP ) values (" & hldID & ",'" & "تم تسجيل ارتداد الاخطار" & "'," & Usr.PUsrID & ",'" & 1 & "','" & OsIP() & "') ", "update RsvAd set RsvAdRe = 1 where RsvAd.RsvAdReln = " & hldID, "0000&H") = Nothing Then
                        Lblmssg.Text = ("تم تسجيل ارتداد الإخطار بنجاح")
                    End If
                End If
                GetUpdtEvent()
            Else
                TxtTrck.Text = ""
                TxtDt.Text = ""
                TxtPh.Text = ""
                TxtNm.Text = ""
                TxtAdd.Text = ""
                TxtOrgin.Text = ""
                TxtWieght.Text = ""
                TxtDoc.Text = ""
                TxtReason.Text = ""
                hldID = 0
                GridHeldUpdt.Rows.Clear()
                Lblmssg.Text = ("لا توجد شحنة مسجلة بهذا الرقم" & " - " & "برجاء التأكد من رقم الشحنة")
                Beep()
            End If
        Else
            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Lblmssg.Text = "جاري تحميل البيانات ........"
        Lblmssg.Refresh()
        If HeldTable.Rows.Count > 0 Then
            TxtTrck.Text = HeldTable.Rows(0).Item("RsvTracing").ToString
            TxtDt.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvAdDate").ToString
            TxtPh.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvMob").ToString
            TxtNm.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvConsignee").ToString
            TxtAdd.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvAdd").ToString
            TxtOrgin.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("CounNm").ToString
            TxtWieght.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvWeight").ToString
            TxtDoc.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvDoc").ToString
            TxtReason.Text = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item("RsvReason").ToString
            hldID = HeldTable.Rows(ComboBox2.SelectedItem - 1).Item(2).ToString
            GetUpdtEvent()
            Lblmssg.Text = ""
        Else
            TxtTrck.Text = ""
            TxtDt.Text = ""
            TxtPh.Text = ""
            TxtNm.Text = ""
            TxtAdd.Text = ""
            TxtOrgin.Text = ""
            TxtWieght.Text = ""
            TxtDoc.Text = ""
            TxtReason.Text = ""
            hldID = 0
            GridHeldUpdt.Rows.Clear()
        End If

    End Sub
End Class