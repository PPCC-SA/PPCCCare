Imports System.Data
Imports System.Web.Services
Imports System.Xml
Imports System.Drawing
Imports System.Globalization

Public Class CustomerLog
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Username") = String.Empty Then

                Response.Redirect("Signin.aspx")
                Response.End()

            Else

                GetStatusSupport()
                GetTypeSupport()
                GetRequestorSupport()
                BindGrid()
                txtSearch.Focus()
                HideGridDataView(Session("Category").ToString)

            End If

        End If


    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)

        BindGrid()

    End Sub

    Protected Sub BindGrid()

        GridView1.DataSource = Nothing
        GridView1.DataBind()

        oWS = New ServiceSupport.ServiceSupportSoapClient

        Dim sDate As String
        Dim sParms As String
        sDate = txtFilterDate.Text

        If sDate = String.Empty Then
            sDate = "01/01/1990"
        End If

        Dim oDate As DateTime
        oDate = Convert.ToDateTime(sDate)

        dt = New DataTable
        ds = New DataSet

        'dt = oWS.CustomerLogList(Session("Username").ToString _
        '                       , txtSearch.Text _
        '                       , search_param.Value _
        '                       , Session("Customer").ToString _
        '                       , CDate(oDate).ToString("yyyy-MM-dd") _
        '                       , IIf(ddlFilterStat.SelectedItem.Value = "0", "", ddlFilterStat.SelectedItem.Value) _
        '                       , IIf(ddlFilterType.SelectedItem.Value = "0", "", ddlFilterType.SelectedItem.Value) _
        '                       , IIf(ddlFilterRequestor.SelectedItem.Value = "0", "", ddlFilterRequestor.SelectedItem.Value))

        If txtSearch.Text <> String.Empty Or
           ddlFilterRequestor.SelectedItem.Value <> "0" Or
           ddlFilterStat.SelectedItem.Value <> "0" Or
           ddlFilterType.SelectedItem.Value <> "0" Or
           txtFilterDate.Text <> String.Empty Then
            sParms = "Search"
            dt = oWS.CustomerLogList(Session("Username").ToString _
                               , txtSearch.Text _
                               , sParms.ToString() _
                               , Session("CustGroup").ToString _
                               , CDate(oDate).ToString("yyyy-MM-dd") _
                               , IIf(ddlFilterStat.SelectedItem.Value = "0", "", ddlFilterStat.SelectedItem.Value) _
                               , IIf(ddlFilterType.SelectedItem.Value = "0", "", ddlFilterType.SelectedItem.Value) _
                               , IIf(ddlFilterRequestor.SelectedItem.Value = "0", "", ddlFilterRequestor.SelectedItem.Value))
        Else
            sParms = search_param.Value
            dt = oWS.CustomerLogList(Session("Username").ToString _
                               , txtSearch.Text _
                               , sParms.ToString() _
                               , Session("CustGroup").ToString _
                               , CDate(oDate).ToString("yyyy-MM-dd") _
                               , IIf(ddlFilterStat.SelectedItem.Value = "0", "", ddlFilterStat.SelectedItem.Value) _
                               , IIf(ddlFilterType.SelectedItem.Value = "0", "", ddlFilterType.SelectedItem.Value) _
                               , IIf(ddlFilterRequestor.SelectedItem.Value = "0", "", ddlFilterRequestor.SelectedItem.Value))
        End If

        ds.Tables.Add(dt)

        If ds.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Else
            'BuildNoRecord(ds, GridView1)
        End If

    End Sub

    Protected Sub BuildNoRecord(ByVal ds As DataSet, ByVal Gridview1 As GridView)
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Tables(0).Rows.Add(ds.Tables(0).NewRow())
            Gridview1.DataSource = ds.Tables(0)
            Gridview1.DataBind()

            Dim columnCount As Integer = Gridview1.Rows(0).Cells.Count
            Gridview1.Rows(0).Cells.Clear()
            Gridview1.Rows(0).Cells.Add(New TableCell)
            Gridview1.Rows(0).Cells(0).ColumnSpan = columnCount
            Gridview1.Rows(0).Cells(0).Text = "Your Customer Log returned 0 results"
            Gridview1.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
            Gridview1.Rows(0).Cells(0).ForeColor = Color.Red
            Gridview1.Rows(0).Cells(0).Font.Bold = True

        End If

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblStat As Label = CType(e.Row.FindControl("lblstat"), Label)
            Dim bntUpdate As LinkButton = CType(e.Row.FindControl("bntUpdate"), LinkButton)


            If Not IsNothing(lblStat) Then

                If lblStat.Text = "In-Process" Or lblStat.Text = "Identify" _
                    Or lblStat.Text = "End Process" Or lblStat.Text = "Solution Finding" _
                    Or lblStat.Text = "Investigate" Or lblStat.Text Like "*CRP/UAT*" Then

                    lblStat.CssClass = "badge badge-success text-wrap"

                ElseIf lblStat.Text = "Open" Or lblStat.Text = "Re-Open" Then

                    lblStat.CssClass = "badge badge-primary text-wrap"

                ElseIf lblStat.Text = "Monitor" Or lblStat.Text Like "Awaiting*" _
                    Or lblStat.Text = "Internal PPCC QC" Then

                    lblStat.CssClass = "badge badge-warning text-wrap"

                ElseIf lblStat.Text = "IssueList" Then

                    lblStat.CssClass = "badge badge-danger text-wrap"

                Else

                    lblStat.CssClass = "badge badge-dark text-wrap"

                End If

                If lblStat.Text = "Closed" Then
                    bntUpdate.CssClass = "btn buttonchange_enabled btn-circle"
                Else
                    bntUpdate.CssClass = "btn btn-warning btn-circle"
                End If

            End If

        End If

    End Sub


    Sub Display(ByVal sender As Object, ByVal e As EventArgs)

        oWS = New ServiceSupport.ServiceSupportSoapClient

        Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
        Dim row As GridViewRow = GridView1.Rows(rowIndex)
        Dim SubjectDet, LodIdDet, ReqDet, ReqDateDet, ErrorTypeDet, FormDet, ModuleDet, ProblemDet, CauseDet, SolutionDet, RemarkDet, EndDateDet, Reply As String

        dt = New DataTable

        dt = oWS.LogDetail(TryCast(row.FindControl("lbllogid"), Label).Text)

        If dt.Rows.Count > 0 Then

            SubjectDet = dt.Rows(0).Item("subject").ToString
            LodIdDet = dt.Rows(0).Item("log_id").ToString
            ReqDet = dt.Rows(0).Item("req").ToString
            ReqDateDet = dt.Rows(0).Item("req_date").ToString
            ErrorTypeDet = dt.Rows(0).Item("error_type").ToString
            FormDet = dt.Rows(0).Item("form").ToString
            ModuleDet = dt.Rows(0).Item("module").ToString
            ProblemDet = dt.Rows(0).Item("problem").ToString
            CauseDet = dt.Rows(0).Item("cause").ToString
            SolutionDet = dt.Rows(0).Item("solution").ToString
            RemarkDet = dt.Rows(0).Item("remark").ToString
            EndDateDet = dt.Rows(0).Item("end_date").ToString

        End If

        ProblemDet = ProblemDet.Replace("'", "\'")
        ProblemDet = ProblemDet.Replace(vbLf, "\n")

        CauseDet = CauseDet.Replace("'", "\'")
        CauseDet = CauseDet.Replace(vbLf, "\n")

        SolutionDet = SolutionDet.Replace("'", "\'")
        SolutionDet = SolutionDet.Replace(vbLf, "\n")

        RemarkDet = RemarkDet.Replace("'", "\'")
        RemarkDet = RemarkDet.Replace(vbLf, "\n")

        SubjectDet = SubjectDet.Replace("'", "\'")
        SubjectDet = SubjectDet.Replace(vbLf, "\n")


        lblLodIdDet.Text = LodIdDet

        Reply = GetReplyLogNew(TryCast(row.FindControl("lbllogid"), Label).Text)

        Reply = Reply.Replace("'", "\'")
        Reply = Reply.Replace(vbLf, "<br/>")

        'GetReplyLog(TryCast(row.FindControl("lbllogid"), Label).Text)
        'ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal();", True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal('" & SubjectDet & "',
                                                                                '" & LodIdDet & "',
                                                                                '" & ReqDet & "',
                                                                                '" & ReqDateDet & "',
                                                                                '" & ErrorTypeDet & "',
                                                                                '" & FormDet & "',
                                                                                '" & ModuleDet & "',
                                                                                '" & ProblemDet & "',
                                                                                '" & CauseDet & "',
                                                                                '" & SolutionDet & "',
                                                                                '" & RemarkDet & "',
                                                                                '" & EndDateDet & "',
                                                                                '" & Reply & "');", True)



    End Sub


    Protected Sub GetStatusSupport()
        oWS = New ServiceSupport.ServiceSupportSoapClient

        dt = New DataTable
        ds = New DataSet

        ddlFilterStat.Items.Clear()
        dt = oWS.GetStatusSupport()

        ds.Tables.Add(dt)

        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlFilterStat.Items.Add(New ListItem(dRow("Description"), dRow("stat")))
        Next

        ddlFilterStat.Items.Insert(0, New ListItem("Status", "0"))


    End Sub

    Protected Sub GetTypeSupport()
        oWS = New ServiceSupport.ServiceSupportSoapClient

        dt = New DataTable
        ds = New DataSet

        ddlFilterType.Items.Clear()
        dt = oWS.GetTypeSupport()

        ds.Tables.Add(dt)

        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlFilterType.Items.Add(New ListItem(dRow("Description"), dRow("type")))
        Next

        ddlFilterType.Items.Insert(0, New ListItem("Type", "0"))


    End Sub

    Protected Sub GetRequestorSupport()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        ddlFilterRequestor.Items.Clear()
        dt = oWS.GetRequestorSupport(Session("CustGroup").ToString)
        ds.Tables.Add(dt)

        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlFilterRequestor.Items.Add(New ListItem(dRow("Description"), dRow("req")))
        Next

        ddlFilterRequestor.Items.Insert(0, New ListItem("Requestor", "0"))
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim LogId As String
        Dim url As String = Page.ResolveUrl("CustomerLogDetail.aspx")
        Dim fullurl As String = ""
        Dim parameter As String = ""
        Dim btn As LinkButton = CType(sender, LinkButton)

        LogId = btn.CommandArgument.ToString()
        parameter = "?sLogID=" & Server.UrlEncode(LogId)
        fullurl = url & parameter
        Response.Redirect(fullurl)
    End Sub


    Protected Sub btnReply_Click(sender As Object, e As EventArgs)
        Dim LogId As String
        Dim url As String = Page.ResolveUrl("ReplyLog.aspx")
        Dim fullurl As String = ""
        Dim parameter As String = ""
        Dim btn As Button = CType(sender, Button)

        LogId = lblLodIdDet.Text.ToString() 'btn.CommandArgument.ToString()
        parameter = "?sLogID=" & Server.UrlEncode(LogId)
        fullurl = url & parameter
        Response.Redirect(fullurl)
    End Sub

    Protected Sub GetReplyLog(LogID)
        'oWS = New ServiceSupport.ServiceSupportSoapClient
        'dt = New DataTable
        'ds = New DataSet

        'RepeaterReplyModel.DataSource = Nothing
        'RepeaterReplyModel.DataBind()
        'dt = oWS.GetReplyLog(LogID)
        'ds.Tables.Add(dt)
        'If ds.Tables(0).Rows.Count > 0 Then
        '    RepeaterReplyModel.DataSource = ds.Tables(0)
        '    RepeaterReplyModel.DataBind()
        'End If
    End Sub

    Function GetReplyLogNew(LogID) As String

        GetReplyLogNew = ""

        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        'RepeaterReplyModel.DataSource = Nothing
        'RepeaterReplyModel.DataBind()
        dt = oWS.GetReplyLog(LogID)
        ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count > 0 Then

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                GetReplyLogNew = GetReplyLogNew & "<b><i>" & ds.Tables(0).Rows(i)("username").ToString & "</b> - " & ds.Tables(0).Rows(i)("reply_date").ToString &
                                ": " & "</i>" & vbLf & ds.Tables(0).Rows(i)("reply").ToString & vbLf & vbLf
            Next

        End If
    End Function

    Function VisibleButtonUpdate(ByVal Stat As String) As Boolean
        Dim sBool As Boolean
        If Session("Category").ToString = "Admin" Then
            If Stat = "Closed" Then
                sBool = False
            Else
                sBool = True
            End If
        Else
            sBool = False
        End If

        Return sBool
    End Function

    Protected Sub HideGridDataView(ByVal sCategory As String)
        'Column Change Status Log
        If sCategory <> String.Empty Then
            If sCategory <> "Admin" Then
                GridView1.Columns(3).Visible = False
            Else
                GridView1.Columns(3).Visible = True
            End If
        Else
            GridView1.Columns(3).Visible = False
        End If
    End Sub
End Class