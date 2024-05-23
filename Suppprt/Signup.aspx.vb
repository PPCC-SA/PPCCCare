Imports System.Data
Imports System.Web.Services
Imports System.Xml
Imports System.Drawing

Public Class Signup
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            txtUsername.Focus()
            GetCustomer(Session("CustGroup").ToString)

        End If

    End Sub

    Protected Sub GetCustomer(ByVal sCustGroup As String)
        oWS = New ServiceSupport.ServiceSupportSoapClient

        dt = New DataTable
        ds = New DataSet

        ddlCustomer.Items.Clear()
        dt = oWS.GetCustomer(String.Empty)

        ds.Tables.Add(dt)

        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlCustomer.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next

        ddlCustomer.Items.Insert(0, New ListItem("", ""))

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim UserName As String = Trim(txtUsername.Text)
        Dim Password As String = Trim(txtPassword.Text)
        Dim Customer As String = ddlCustomer.SelectedItem.Value

        'MsgBox(Customer)
        oWS = New ServiceSupport.ServiceSupportSoapClient

        dt = New DataTable
        dt = oWS.SignupSupport(UserName, Password, Customer)

        If dt.Rows.Count > 0 Then

            If dt.Rows(0)("stat").ToString = "Not Pass" Then
                NotPassNotifyPanel.Visible = True
                NotPassText.Text = dt.Rows(0)("msg").ToString
            Else
                PassNotifyPanel.Visible = True
                PassText.Text = dt.Rows(0)("msg").ToString

                txtUsername.Text = String.Empty
                txtPassword.Text = String.Empty
                ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(""))
            End If

        End If

    End Sub

End Class