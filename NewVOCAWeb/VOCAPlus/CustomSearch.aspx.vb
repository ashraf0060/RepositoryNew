Public Class CustomSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Result_.DataSourceID = "AreaOffGridSource0"
            RadioButton1.Checked = True
            RadOff.Checked = True
            AreaList.Visible = False
            TimeList.Visible = False
            WeekEndList.Visible = False
            RadOff.BackColor = System.Drawing.Color.GreenYellow
            RadATM.BackColor = System.Drawing.Color.White
            RadPrison.BackColor = System.Drawing.Color.White
            OffTabl.Visible = True
            ATMTabl.Visible = False
            PrisonTabl.Visible = False
        End If
    End Sub
    Protected Sub RadOff_CheckedChanged(sender As Object, e As EventArgs) Handles RadOff.CheckedChanged
        If RadOff.Checked = True Then
            RadATM.Checked = False
            RadPrison.Checked = False
            RadOff.BackColor = System.Drawing.Color.GreenYellow
            RadATM.BackColor = System.Drawing.Color.White
            RadPrison.BackColor = System.Drawing.Color.White
            OffTabl.Visible = True
            ATMTabl.Visible = False
            PrisonTabl.Visible = False
        End If
    End Sub
    Protected Sub RadATM_CheckedChanged(sender As Object, e As EventArgs) Handles RadATM.CheckedChanged
        If RadATM.Checked = True Then
            RadOff.Checked = False
            RadPrison.Checked = False
            RadOff.BackColor = System.Drawing.Color.White
            RadATM.BackColor = System.Drawing.Color.GreenYellow
            RadPrison.BackColor = System.Drawing.Color.White
            OffTabl.Visible = False
            ATMTabl.Visible = True
            PrisonTabl.Visible = False
        End If
    End Sub
    Protected Sub RadPrison_CheckedChanged(sender As Object, e As EventArgs) Handles RadPrison.CheckedChanged
        If RadPrison.Checked = True Then
            RadOff.Checked = False
            RadATM.Checked = False
            RadOff.BackColor = System.Drawing.Color.White
            RadATM.BackColor = System.Drawing.Color.White
            RadPrison.BackColor = System.Drawing.Color.GreenYellow
            PrisonTabl.Visible = True
            OffTabl.Visible = False
            ATMTabl.Visible = False
        End If
    End Sub
    Protected Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            AreaList.Visible = False
            TimeList.Visible = False
            WeekEndList.Visible = False
            TextBox10.Visible = True
            Button1.Visible = True
            Result_.DataSourceID = "AreaOffGridSource0"
        End If
    End Sub

    Protected Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            TextBox10.Visible = False
            Button1.Visible = False
            AreaList.Visible = True
            AreaList.DataSourceID = "AreaOffDataSource"
            TimeList.Visible = True
            WeekEndList.Visible = True
            Result_.DataSourceID = "AreaOffGridSource"
        End If
    End Sub
    Protected Sub TimeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeList.SelectedIndexChanged
        WeekEndList.ClearSelection()
        Result_.DataSourceID = "AreaOffGridSource1"
    End Sub

    Protected Sub WeekEndList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WeekEndList.SelectedIndexChanged
        Result_.DataSourceID = "AreaOffGridSource2"
    End Sub

    Protected Sub AreaList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AreaList.SelectedIndexChanged
        Result_.DataSourceID = "AreaOffGridSource"
    End Sub
End Class