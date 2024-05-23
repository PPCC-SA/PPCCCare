Imports System.Data
Imports System.Web.Services
Imports System.Xml
Imports System.Drawing
Imports System.Globalization

Public Class WebForm3
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
            End If
        End If

    End Sub

    Protected Sub BindGrid()
        Dim sCustNum As String = ""
        GridRequestor.DataSource = Nothing
        GridRequestor.DataBind()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        dt = oWS.GetRequestor(sCustNum)
        ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count > 0 Then
            GridRequestor.DataSource = ds.Tables(0)
            GridRequestor.DataBind()
        Else
            BuildNoRecord(ds, GridRequestor)
        End If
    End Sub

    Protected Sub BuildNoRecord(ByVal ds As DataSet, ByVal GridRequestor As GridView)
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Tables(0).Rows.Add(ds.Tables(0).NewRow())
            GridRequestor.DataSource = ds.Tables(0)
            GridRequestor.DataBind()

            Dim columnCount As Integer = GridRequestor.Rows(0).Cells.Count
            GridRequestor.Rows(0).Cells.Clear()
            GridRequestor.Rows(0).Cells.Add(New TableCell)
            GridRequestor.Rows(0).Cells(0).ColumnSpan = columnCount
            GridRequestor.Rows(0).Cells(0).Text = "Requestor returned 0 results"
            GridRequestor.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
            GridRequestor.Rows(0).Cells(0).ForeColor = Color.Red
            GridRequestor.Rows(0).Cells(0).Font.Bold = True
        End If

    End Sub

    Protected Sub GetCustomer()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlCompany.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlCompany.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next
        ddlCompany.Items.Insert(0, New ListItem("", ""))
    End Sub

    Protected Sub ClearText()
        txtRequestor.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtEmail.Text = String.Empty
        ddlCompany.SelectedIndex = ddlCompany.Items.IndexOf(ddlCompany.Items.FindByValue(""))
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearText()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        Try
            dt = oWS.InsertRequestor(ddlCompany.SelectedItem.Value,
                                     txtRequestor.Text,
                                     txtFirstName.Text,
                                     txtLastName.Text,
                                     txtEmail.Text)
            If dt.Rows.Count > 0 Then
                'PassNotifyPanel.Visible = True
                'PassText.Text = "Saved successfully."
                ClearText()
                BindGrid()

                MsgErr = "Saved successfully."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Success','" & MsgErr & "', 'success');", True)

        Else
                'NotPassNotifyPanel.Visible = True
                'NotPassText.Text = "Saved failed. Please try agian."

                MsgErr = "Saved failed. Please try agian."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)
            End If
        Catch ex As Exception
            'NotPassNotifyPanel.Visible = True
            'NotPassText.Text = ex.Message
            MsgErr = ex.Message
            MsgErr = MsgErr.Replace("'", "\'")
            MsgErr = MsgErr.Replace(vbLf, "\n")

            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)
        End Try

    End Sub

    Protected Function GetEditCustomer() As DataTable
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        dt = oWS.GetCustomer(Session("CustGroup").ToString)

        Return dt
    End Function

    Protected Sub GridRequestor_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridRequestor.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub GridRequestor_RowEditing(sender As Object, e As GridViewEditEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridRequestor.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub GridRequestor_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim sRequestor As String = String.Empty
        Dim sArrFullName() As String
        Dim sFullName As String = String.Empty
        Dim sName As String = String.Empty
        Dim sLastname As String = String.Empty
        Dim sCustomer As String = String.Empty
        Dim sEmail As String = String.Empty
        Dim sRowPointer As String = String.Empty
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        Try
            Dim ddlCustomer As DropDownList = DirectCast(GridRequestor.Rows(e.RowIndex).FindControl("ddlCustomer"), DropDownList)

            'Read RowPointer from DataKeyNames
            sRowPointer = Convert.ToString(GridRequestor.DataKeys(e.RowIndex).Value)

            'Finding TextBox Inside GridView and Get Updated Value
            sRequestor = DirectCast(GridRequestor.Rows(e.RowIndex).FindControl("txtRequestor"), TextBox).Text.Trim()
            sFullName = DirectCast(GridRequestor.Rows(e.RowIndex).FindControl("txtName"), TextBox).Text.Trim()
            sArrFullName = sFullName.Split(" ")
            For i As Integer = 0 To sArrFullName.Length - 1
                If i = 0 Then
                    sName = sArrFullName(i)
                ElseIf i = 1 Then
                    sLastname = sArrFullName(i)
                End If
            Next
            sEmail = DirectCast(GridRequestor.Rows(e.RowIndex).FindControl("txtEmail"), TextBox).Text.Trim()
            sCustomer = Convert.ToString(ddlCustomer.SelectedValue)

            'Call Web Service
            dt = oWS.UpdateRequestor(sRequestor,
                                     sName,
                                     sLastname,
                                     sEmail,
                                     sCustomer,
                                     sRowPointer)
            'PassNotifyPanel.Visible = True
            'PassText.Text = "Updated successfully."

            GridRequestor.EditIndex = -1
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

    Protected Sub GridRequestor_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        GridRequestor.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub GridRequestor_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim sRowPointer As String = String.Empty
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
        Try


            sRowPointer = Convert.ToString(GridRequestor.DataKeys(e.RowIndex).Value)
            dt = oWS.DeleteRequestor(sRowPointer)
            'PassNotifyPanel.Visible = True
            'PassText.Text = "Deleted successfully."
            GridRequestor.EditIndex = -1
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

    Protected Sub GridRequestor_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                Dim ddlCustomer As DropDownList = CType(e.Row.FindControl("ddlCustomer"), DropDownList)
                ddlCustomer.DataTextField = "name"
                ddlCustomer.DataValueField = "cust_num"
                ddlCustomer.DataSource = GetEditCustomer()
                ddlCustomer.DataBind()

                'Dafault Customer in Dropdown
                Dim sCustomer As String = (TryCast(e.Row.FindControl("lblEditCustomer"), Label)).Text
                ddlCustomer.Items.FindByValue(sCustomer).Selected = True
            End If
        End If
    End Sub
End Class