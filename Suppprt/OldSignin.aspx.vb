Imports System.Data
Imports System.Web.Services
Imports System.Xml

Public Class OldSignin
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            txtUsername.Focus()
        End If

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim UserName As String = Trim(txtUsername.Text)
        Dim Password As String = txtPassword.Text

        oWS = New ServiceSupport.ServiceSupportSoapClient

        dt = New DataTable
        dt = oWS.LoginSupport(UserName, Password)

        Session("Username") = ""
        Session("Customer") = ""
        Session("Category") = ""
        Session("CustGroup") = ""

        If dt.Rows.Count > 0 Then

            If dt.Rows(0)("msg").ToString = "" Then

                Session("Username") = dt.Rows(0)("username").ToString
                Session("Customer") = dt.Rows(0)("customer").ToString
                Session("CustGroup") = dt.Rows(0)("cust_group").ToString
                Session("Category") = dt.Rows(0)("category").ToString
                Response.Redirect("CustomerLog.aspx")
            Else
                NotificationPanel.Visible = True

                Literal1.Text = dt.Rows(0)("msg").ToString

            End If

        End If

    End Sub

End Class