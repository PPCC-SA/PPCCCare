Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") = String.Empty Then
            Response.Redirect("Signin.aspx")
            Response.End()
        Else
            Response.Redirect("CustomerLog.aspx")
        End If
    End Sub

End Class