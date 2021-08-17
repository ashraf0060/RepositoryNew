Public Class UsrInfo
    Dim URstTbl As DataTable = New DataTable
    Dim TmpUsrSusp As Boolean
    Private Sub UsrInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '     0  ,    1 ,   2      ,    3   ,  4
        If PublicCode.GetTbl("SELECT UsrId as [كود الموظف], UsrRealNm as [اسم الموظف], UsrGsm As [رقم الموبايل], UsrSisco As [الرقم الداخلي], UCatNm As [الوظيفة] FROM Int_user INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId where UsrSusp = 0 order by UCatNm,UsrRealNm", URstTbl, "1046&H") = Nothing Then
            BindingSource1.DataSource = URstTbl
            BindNavigatorUsr.BindingSource = BindingSource1
            UsrData.DataSource = BindingSource1
            UsrData.AutoResizeColumns()
            If Usr.PUsrUCatLvl > 9 Then
                UsrData.Columns(2).Visible = True
            Else
                UsrData.Columns(2).Visible = False
            End If
        End If
        Refresh()
    End Sub
    Private Sub Filtration(sender As Object, e As EventArgs)
        Dofiltr()
    End Sub
    Sub Dofiltr()
        Dim Filtr As String = String.Empty
        If TxtUsrNm.TextLength > 0 Then
            If IsNumeric(TxtUsrNm.Text) = False Then Filtr = "[اسم الموظف] like '%" & TxtUsrNm.Text & "%'"
            If IsNumeric(TxtUsrNm.Text) = False Then
                If Filtr.Length > 0 Then
                    Filtr += " Or [الوظيفة] like '%" & TxtUsrNm.Text & "%'"
                Else
                    Filtr = " [الوظيفة] like '%" & TxtUsrNm.Text & "%'"
                End If

            End If
            If IsNumeric(TxtUsrNm.Text) = True Then
                If Filtr.Length > 0 Then
                    Filtr += " Or [رقم الموبايل] like '%" & TxtUsrNm.Text & "%'"
                Else
                    Filtr = " [رقم الموبايل] like '%" & TxtUsrNm.Text & "%'"
                End If

            End If
            If IsNumeric(TxtUsrNm.Text) = True Then
                If Filtr.Length > 0 Then
                    Filtr += " Or [الرقم الداخلي] like '%" & TxtUsrNm.Text & "%'"
                Else
                    Filtr = " [الرقم الداخلي] like '%" & TxtUsrNm.Text & "%'"
                End If

            End If
            If IsNumeric(TxtUsrNm.Text) = True Then
                If Filtr.Length > 0 Then
                    Filtr += " Or [كود الموظف]  = " & TxtUsrNm.Text
                Else
                    Filtr = " [كود الموظف]  = " & TxtUsrNm.Text
                End If

            End If
        End If
        URstTbl.DefaultView.RowFilter = Filtr
    End Sub
    Private Sub TxtUsrNm_TextChanged(sender As Object, e As EventArgs) Handles TxtUsrNm.TextChanged
        Dofiltr()
    End Sub
End Class