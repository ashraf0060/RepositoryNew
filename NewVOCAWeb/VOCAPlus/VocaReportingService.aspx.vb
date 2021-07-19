Imports Microsoft.Exchange.WebServices.Data
Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net


Public Class VocaReportingService
    Inherits System.Web.UI.Page
    Dim tempTable As DataTable = New DataTable
    Dim CollctStr As String = ""
    Dim CollectStr As String = ""
    Dim slctStr As String = ""
    Dim str As String = ""
    Dim DT As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            tempTable.Rows.Clear()
            tempTable.Columns.Clear()
            GETTTbl("select ExpStr from ALib", tempTable)
            slctStr = tempTable.Rows(0).Item("ExpStr").ToString
            For Cnt_ = 0 To Split(slctStr, ",").Count - 1
                Dim FF As New ListItem
                FF.Text = Mid(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1)), 2, Len(Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(1))) - 2)
                FF.Value = Trim(Split(Trim(Split(slctStr, ",")(Cnt_)), "AS")(0)).ToString
                CheckBoxList1.Items.Add(FF)
                FF.Selected = True
            Next
        End If
        If str.Length > 0 Then str &= " And "
        Dim AA As String = datepickerFrom.Value.ToString
        Dim BB As String = datepickerTo.Value.ToString
        str = " Where CONVERT(date, " & "TkDtStart" & ",111) BETWEEN CONVERT(date, '" + AA.ToString + "', 111) AND  CONVERT(date, '" + BB.ToString + "', 111)"
    End Sub

    Protected Sub BtnPrv_Click(sender As Object, e As EventArgs) Handles BtnPrv.Click
        CollctStr = ""
        For TT = 0 To CheckBoxList1.Items.Count - 1
            If CheckBoxList1.Items(TT).Selected = True Then
                CollctStr &= CheckBoxList1.Items(TT).Value & " As [" & CheckBoxList1.Items(TT).Text & "]" & ", "

            End If
        Next
        CollectStr = "Select " & Mid(CollctStr, 1, Len(CollctStr) - 2) & " From ExportRep2"
        Lbl.Text = CollectStr & str & "_" & CollctStr.Length.ToString
        tempTable.Rows.Clear()
        tempTable.Columns.Clear()
        GETTTbl(CollectStr & str, tempTable)
        GridView1.DataSource = tempTable
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.ClearContent()
        Response.AddHeader("Content-disposition", "attachment; Filename=SSSS.xls")
        Response.ContentType = "application/vnd.msexcel"
        Dim SW As New StringWriter()
        Dim HTMLWR As New HtmlTextWriter(SW)
        GridView1.RenderControl(HTMLWR)
        Response.Write(SW.ToString())
        Response.End()
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal c As Control)

    End Sub
End Class