Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Drawing

Public Class Attendance
    Inherits System.Web.UI.Page
    Dim Errmsg As String
    Dim sqlComm As New SqlCommand                    'SQL Command
    Dim sqlCon As New SqlConnection '(strConn) ' I Have assigned conn STR here and delete this row from all project
    Dim SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
    Dim strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Dim IP_ As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Focus()
        IP_ = Request.UserHostAddress
        If Left(IP_, 9) = "10.10.200" Then
            Label1.Text = "القرية التكنولوجية بالمعادي"
        ElseIf Left(IP_, 8) = "10.11.51" _
            Or Left(IP_, 8) = "10.11.56" _
            Or Left(IP_, 8) = "10.11.58" Then
            Label1.Text = "مبنى السبيل"
        ElseIf Left(IP_, 9) = "10.10.220" Then
            Label1.Text = "البيت"
        Else
            Server.Transfer("~/NotAllowed.aspx")
        End If
        'Label1.Text = "Sabeel"
        'ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('This alert from code behind');", True)
    End Sub
    Private Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
        Errmsg = Nothing
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        sqlCon.ConnectionString = strConn
        sqlComm.Connection = sqlCon
        SQLTblAdptr.SelectCommand = sqlComm
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            SQLTblAdptr.Fill(SqlTbl)
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        Return Errmsg
    End Function
    Private Function InsUpd(SSqlStr As String) As String
        'LoadFrm("جاري تحميل البيانات ...", 500, 350)
        Dim sqlCConCCSYS As New SqlConnection
        Errmsg = Nothing
        sqlComm.Connection = sqlCon
        sqlComm.CommandType = CommandType.Text
        sqlComm.CommandText = SSqlStr
        Try
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            sqlComm.ExecuteNonQuery()
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)
        Catch ex As Exception
            Errmsg = "X"
        End Try
        'LodngFrm.Close()
        Return Errmsg
    End Function
    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim UsrTbl As New DataTable
        Dim TimeTble As New DataTable
        Dim AcssTble As New DataTable
        Dim Time_ As DateTime
        Label2.Text = "Loading ..."
        TimeTble.Rows.Clear()
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            If TimeTble.Rows.Count > 0 Then
                Time_ = Convert.ToDateTime(Format(TimeTble.Rows(0).Item(0), "HH:mm:ss"))
                AcssTble.Rows.Clear()

                If GetTbl("SELECT UsrId,UsrNm,UsrCat,UsrRealNm,UsrBarcode,UaccSTime,Posstion,ReportingTo FROM Int_access INNER JOIN Int_user ON UsrId = Int_access.UaccUsrID 
inner join (SELECT IntUserCat.UCatId, IntUserCat.UCatNm AS Posstion, IntUserCat_2.UCatNm AS ReportingTo
                                FROM IntUserCat INNER JOIN IntUserCat AS IntUserCat_2 ON IntUserCat.UCatIdSub = IntUserCat_2.UCatId) as Poss on Poss.UCatId = int_user.UsrCat
                                AND LEN(UsrBarcode)>0 AND UsrBarcode = N'" & TextBox1.Text & "' WHERE Int_access.UaccStat = 'LO' and FORMAT(UaccSTime,'yyyy/MM/dd') = '" & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd") & "'", AcssTble) = Nothing Then
                    If AcssTble.Rows.Count > 0 Then
                        'Timer1.Enabled = False
                        Label2.Text = "تم تسجيلك اليوم بالفعل الساعة " & Format(AcssTble.Rows(0).Item("UaccSTime"), "H:mm")
                        Label2.ForeColor = Color.Green
                        Label3.Text = AcssTble.Rows(0).Item("Posstion").ToString
                        Label4.Text = AcssTble.Rows(0).Item("ReportingTo").ToString
                        InsUpd("insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat)  values ('" & AcssTble.Rows(0).Item("UsrNm").ToString & "','" & AcssTble.Rows(0).Item("UsrId").ToString & "','" & IP_ & "','" & "LF" & "');")
                        Timer1.Enabled = False
                        Timer2.Enabled = True
                    Else
                        UsrTbl.Rows.Clear()
                        If GetTbl("select UsrId,UsrNm,UsrCat,UsrRealNm,Poss.Posstion,Poss.ReportingTo,UsrBarcode from int_user inner join 
                                (SELECT IntUserCat.UCatId, IntUserCat.UCatNm AS Posstion, IntUserCat_2.UCatNm AS ReportingTo
                                FROM IntUserCat INNER JOIN IntUserCat AS IntUserCat_2 ON IntUserCat.UCatIdSub = IntUserCat_2.UCatId) as Poss on Poss.UCatId = int_user.UsrCat
                                AND LEN(UsrBarcode)>0 AND UsrBarcode = '" & TextBox1.Text & "' where UsrSusp = 0", UsrTbl) = Nothing Then
                            If UsrTbl.Rows.Count > 0 Then
                                If CDate(Format(Time_, "HH:mm:ss")) <= #11:59:59 AM# Then
                                    'Label2.Text = Format(Time_, "HH:mm:ss").ToString & "d"
                                    Label2.Text = "صباح الخير : " & UsrTbl.Rows(0).Item("UsrRealNm").ToString
                                Else
                                    'Label2.Text = Format(CDate(Time_), "H:mm:ss").ToString & "t"
                                    Label2.Text = "مساء الخير : " & UsrTbl.Rows(0).Item("UsrRealNm").ToString
                                End If
                                Label2.ForeColor = Color.Green
                                Label3.Text = UsrTbl.Rows(0).Item("Posstion").ToString
                                Label4.Text = UsrTbl.Rows(0).Item("ReportingTo").ToString
                                InsUpd("insert into Int_access (UaccNm, UaccUsrID, UaccUsrIP, UaccStat)  values ('" & UsrTbl.Rows(0).Item("UsrNm").ToString & "','" & UsrTbl.Rows(0).Item("UsrId").ToString & "','" & IP_ & "','" & "LO" & "');")
                                TextBox1.Focus()
                                Timer1.Enabled = False
                                Timer2.Enabled = True
                            Else
                                Label2.Text = "Not Verified"
                                Label2.ForeColor = Color.Red
                            End If
                        Else
                            Label2.Text = "System Down"
                            Label2.ForeColor = Color.Red
                        End If
                    End If
                Else
                    Label2.Text = "System Down"
                    Label2.ForeColor = Color.Red
                End If
            Else
                Label2.Text = "System Down"
                Label2.ForeColor = Color.Red
            End If
        Else
            Label2.Text = "System Down"
            Label2.ForeColor = Color.Red
        End If

        TextBox1.Text = ""
    End Sub
    Private Sub Cleer()
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
    End Sub
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox1.Focus()
        TextBox1.BorderColor = Color.White
        Dim TimeTble As New DataTable
        If GetTbl("Select GetDate() as Now_", TimeTble) = Nothing Then
            Label5.Text = "الوقت والتاريخ : " & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
        End If
        GC.Collect()
    End Sub

    Protected Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Cleer()
        Timer2.Enabled = False
        Timer1.Enabled = True
    End Sub
End Class