Public Class NotAllowed
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = Request.UserHostAddress
        Label2.text = Request.UserHostAddress
    End Sub

End Class