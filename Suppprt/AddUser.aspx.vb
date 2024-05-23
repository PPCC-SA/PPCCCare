Imports System.Data
Imports System.Web.Services
Imports System.Xml
Imports System.Drawing
Imports System.Globalization

Public Class WebForm6
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet
    Dim MsgErr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Username") = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else
                BindGrid()
                GetCustomer()
                'GetEditCustomer()
            End If
        End If
    End Sub

    Protected Sub BindGrid()
        Dim sCustNum As String = ""
        GridUser.DataSource = Nothing
        GridUser.DataBind()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        dt = oWS.GetUserWebSupport()
        ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count > 0 Then
            GridUser.DataSource = ds.Tables(0)
            GridUser.DataBind()
        Else
            BuildNoRecord(ds, GridUser)
        End If
    End Sub

    Protected Sub BuildNoRecord(ByVal ds As DataSet, ByVal GridUser As GridView)
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Tables(0).Rows.Add(ds.Tables(0).NewRow())
            GridUser.DataSource = ds.Tables(0)
            GridUser.DataBind()

            Dim columnCount As Integer = GridUser.Rows(0).Cells.Count
            GridUser.Rows(0).Cells.Clear()
            GridUser.Rows(0).Cells.Add(New TableCell)
            GridUser.Rows(0).Cells(0).ColumnSpan = columnCount
            GridUser.Rows(0).Cells(0).Text = "Requestor returned 0 results"
            GridUser.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
            GridUser.Rows(0).Cells(0).ForeColor = Color.Red
            GridUser.Rows(0).Cells(0).Font.Bold = True
        End If

    End Sub

    Protected Sub GetCustomer()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlNewCustomer.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlNewCustomer.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next
        ddlNewCustomer.Items.Insert(0, New ListItem("", ""))
        ddlNewCustomer.Items.Insert(1, New ListItem("Premier Professional Consulting Co., Ltd.", "PPCC"))
    End Sub

    Protected Function GetEditCustomer() As DataTable
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        dt = oWS.GetCustomer(Session("CustGroup").ToString)

        Return dt
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        Try
            dt = oWS.InsertUserWebSupport(txtNewUsername.Text,
                                          txtNewPassword.Text,
                                          ddlNewCustomer.SelectedItem.Value,
                                          ddlNewCategory.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                'PassNotifyPanel.Visible = True
                'PassText.Text = "Saved successfully."
                ClearText()
                BindGrid()

                MsgErr = "Saved successfully."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Success','" & MsgErr & "', 'success');", True)
            Else

                MsgErr = "Saved failed. Please try agian."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)
                'NotPassNotifyPanel.Visible = True
                'NotPassText.Text = "Saved failed. Please try agian."
            End If
        Catch ex As Exception

            MsgErr = ex.Message
            MsgErr = MsgErr.Replace("'", "\'")
            MsgErr = MsgErr.Replace(vbLf, "\n")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)
            'NotPassNotifyPanel.Visible = True
            'NotPassText.Text = ex.Message
        End Try
    End Sub

    Protected Sub ClearText()
        txtNewUsername.Text = String.Empty
        txtNewPassword.Text = String.Empty
        GetCustomer()
    End Sub

    Protected Sub GridUser_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                Dim ddlCustomer As DropDownList = CType(e.Row.FindControl("ddlCustomer"), DropDownList)
                Dim ddlCategory As DropDownList = CType(e.Row.FindControl("ddlCategory"), DropDownList)
                ddlCustomer.DataTextField = "name"
                ddlCustomer.DataValueField = "cust_num"
                ddlCustomer.DataSource = GetEditCustomer()
                ddlCustomer.DataBind()
                ddlCustomer.Items.Insert(0, New ListItem("Premier Professional Consulting Co., Ltd.", "PPCC"))

                'Dafault Customer in Dropdown
                Dim sCustomer As String = (TryCast(e.Row.FindControl("lblEditCustomer"), Label)).Text
                ddlCustomer.Items.FindByValue(sCustomer).Selected = True

                'Dafault Category in Dropdown
                Dim sCategory As String = (TryCast(e.Row.FindControl("lblEditCategory"), Label)).Text
                ddlCategory.Items.FindByValue(sCategory).Selected = True

            End If
        End If

        Dim sPassword As String = String.Empty
        Dim sHidePassword As String = String.Empty
        Dim iLen As Integer = 0
        Dim lblPassword As Label = CType(e.Row.FindControl("lblPassword"), Label)
        If Not IsNothing(lblPassword) Then
            If Not IsDBNull(lblPassword.Text) Or lblPassword.Text <> String.Empty Then
                sPassword = lblPassword.Text
                iLen = sPassword.Length() - 1
                For i As Integer = 0 To iLen
                    sHidePassword = sHidePassword & "*"
                Next
                lblPassword.Text = sHidePassword
            End If
        End If


    End Sub

    Protected Sub GridUser_RowEditing(sender As Object, e As GridViewEditEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridUser.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub GridUser_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridUser.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub GridUser_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim sUsername As String = String.Empty
        Dim sPassword As String = String.Empty
        Dim sCustomer As String = String.Empty
        Dim sCategory As String = String.Empty
        Dim sRowPointer As String = String.Empty
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        Try
            Dim ddlCustomer As DropDownList = DirectCast(GridUser.Rows(e.RowIndex).FindControl("ddlCustomer"), DropDownList)
            Dim ddlCategory As DropDownList = DirectCast(GridUser.Rows(e.RowIndex).FindControl("ddlCategory"), DropDownList)

            'Read RowPointer from DataKeyNames
            sRowPointer = Convert.ToString(GridUser.DataKeys(e.RowIndex).Value)

            'Finding TextBox Inside GridView and Get Updated Value
            sUsername = DirectCast(GridUser.Rows(e.RowIndex).FindControl("lblEditUsername"), Label).Text.Trim()
            sPassword = DirectCast(GridUser.Rows(e.RowIndex).FindControl("txtPassword"), TextBox).Text.Trim()
            sCustomer = Convert.ToString(ddlCustomer.SelectedValue)
            sCategory = Convert.ToString(ddlCategory.SelectedValue)

            'Call Web Service
            dt = oWS.UpdateUserWebSupport(sUsername,
                                          sPassword,
                                          sCustomer,
                                          sCategory,
                                          sRowPointer)
            'PassNotifyPanel.Visible = True
            'PassText.Text = "Updated successfully."
            GridUser.EditIndex = -1
            BindGrid()

            MsgErr = "Updated successfully."
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Success','" & MsgErr & "', 'success');", True)


        Catch ex As Exception
            'NotPassNotifyPanel.Visible = True
            'NotPassText.Text = ex.Message

            MsgErr = ex.Message
            MsgErr = MsgErr.Replace("'", "\'")
            MsgErr = MsgErr.Replace(vbLf, "\n")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

        End Try
    End Sub

    Protected Sub GridUser_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridUser.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub GridUser_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim sRowPointer As String = String.Empty
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        Try
            sRowPointer = Convert.ToString(GridUser.DataKeys(e.RowIndex).Value)
            dt = oWS.DeleteUserWebSupport(sRowPointer)
            'PassNotifyPanel.Visible = True
            'PassText.Text = "Deleted successfully."
            GridUser.EditIndex = -1
            BindGrid()

            MsgErr = "Deleted successfully."
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Success','" & MsgErr & "', 'success');", True)
        Catch ex As Exception
            'NotPassNotifyPanel.Visible = True
            'NotPassText.Text = ex.Message

            MsgErr = ex.Message
            MsgErr = MsgErr.Replace("'", "\'")
            MsgErr = MsgErr.Replace(vbLf, "\n")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtNewUsername.Text = String.Empty
        txtNewPassword.Text = String.Empty
        ddlNewCustomer.SelectedIndex = ddlNewCustomer.Items.IndexOf(ddlNewCustomer.Items.FindByValue(""))
        ddlNewCategory.SelectedIndex = ddlNewCategory.Items.IndexOf(ddlNewCategory.Items.FindByValue("User"))
    End Sub

End Class