Imports System.Data
Imports System.Web.Services
Imports System.Xml

Public Class OldUpdateSupportLog
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Username") = String.Empty And Session("Customer") = String.Empty And Session("Category") = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else
                GetStatusSupport()
                GetCustomer()
                GetResource()
                GetErrorType()
                'GetResponseTime()
                GetDetail(Request.QueryString("sLogID"))
                EnabledField()
            End If
        End If
    End Sub

    Sub EnabledField()
        If Session("Category") = "Admin" Then 'Session("Customer") = "PPCC" Then
            ddlCustomer.Attributes.Add("disabled", "disabled")
        Else
            ddlCustomer.Attributes.Add("disabled", "disabled")
            txtProblems.Attributes.Add("disabled", "disabled")
            txtCause.Attributes.Add("disabled", "disabled")
            txtSolution.Attributes.Add("disabled", "disabled")
            ddlErrorType.Attributes.Add("disabled", "disabled")
            ddlResponsible.Attributes.Add("disabled", "disabled")
            ddlClosedBy.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Sub Display(ByVal sender As Object, ByVal e As EventArgs)
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        If txtLogID.Text <> String.Empty Then
            dt = oWS.LogDetail(txtLogID.Text)
            If dt.Rows.Count > 0 Then
                slblLogId.Text = dt.Rows(0).Item("log_id").ToString()
                slblCust.Text = dt.Rows(0).Item("customer").ToString()
                slblRequestor.Text = dt.Rows(0).Item("req").ToString()
                slblReqDate.Text = Format(CDate(dt.Rows(0).Item("req_date").ToString()), "dd/MM/yyyy")
                slblFormName.Text = dt.Rows(0).Item("form").ToString()
                slblProblem.Text = dt.Rows(0).Item("problem").ToString()
                slblDbSite.Text = dt.Rows(0).Item("db_site").ToString()
                slblCauses.Text = dt.Rows(0).Item("cause").ToString()
                slblSolutions.Text = dt.Rows(0).Item("solution").ToString()
                txtHowtoCheck.Text = dt.Rows(0).Item("how_to_check").ToString
                txtCurrentSol.Text = dt.Rows(0).Item("current_solution").ToString
                txtLongTermSol.Text = dt.Rows(0).Item("longterm_solution").ToString
                slblCloseDate.Text = dt.Rows(0).Item("end_date").ToString()
                slblCloseBy.Text = dt.Rows(0).Item("closed_by_name").ToString()
                slblResponseBy.Text = dt.Rows(0).Item("respond_by_name").ToString()
                txtResponseDate.Text = dt.Rows(0).Item("respond_date").ToString()
                ddlResponseTime.SelectedIndex = ddlResponseTime.Items.IndexOf(ddlResponseTime.Items.FindByValue(dt.Rows(0).Item("respond_time").ToString()))
                txtClosedDate.Text = dt.Rows(0).Item("end_date").ToString()
                ddlClosedTime.SelectedIndex = ddlClosedTime.Items.IndexOf(ddlClosedTime.Items.FindByValue(dt.Rows(0).Item("end_time").ToString()))
                GetDetail(txtLogID.Text)
            End If
        Else
            slblLogId.Text = String.Empty
            slblRequestor.Text = String.Empty
            slblReqDate.Text = String.Empty
            slblFormName.Text = String.Empty
            slblProblem.Text = String.Empty
            txtHowtoCheck.Text = String.Empty
            txtCurrentSol.Text = String.Empty
            txtLongTermSol.Text = String.Empty
        End If
        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal();", True)

    End Sub

    Protected Sub GetStatusSupport()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlStat.Items.Clear()
        dt = oWS.GetStatusSupport()
        If Session("Customer") <> String.Empty Then
            If Session("Category") <> "Admin" Then 'Session("Customer") <> "PPCC" Then
                dt.DefaultView.RowFilter = "stat in ('C', 'O', 'I')" 'dt.Select("stat='C'")
                ds.Tables.Add(dt.DefaultView.ToTable())
            Else
                ds.Tables.Add(dt)
            End If
        End If
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlStat.Items.Add(New ListItem(dRow("description"), dRow("stat")))
        Next
        ddlStat.Items.Insert(0, New ListItem("", ""))
    End Sub

    Protected Sub GetCustomer()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlCustomer.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlCustomer.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next

        If Session("Customer") <> String.Empty Then
            If Session("Category") = "Admin" Then 'Session("Customer") = "PPCC" Then
                ddlCustomer.Items.Insert(0, New ListItem("", ""))
            Else
                ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(Session("Customer").ToString))
            End If
        Else
            'condition when session customer is null
        End If
    End Sub

    Protected Sub GetResource()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlResponsible.Items.Clear()
        ddlClosedBy.Items.Clear()
        dt = oWS.GetResource()
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlResponsible.Items.Add(New ListItem(dRow("res_id") & " - " & dRow("name"), dRow("res_id")))
            ddlClosedBy.Items.Add(New ListItem(dRow("res_id") & " - " & dRow("name"), dRow("res_id")))
        Next
        ddlResponsible.Items.Insert(0, New ListItem("", ""))
        ddlClosedBy.Items.Insert(0, New ListItem("", ""))
    End Sub

    Protected Sub GetErrorType()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlErrorType.Items.Clear()
        dt = oWS.GetErrorType()
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlErrorType.Items.Add(New ListItem(dRow("desctiption"), dRow("error_id")))
        Next
        ddlErrorType.Items.Insert(0, New ListItem("", ""))
    End Sub

    Protected Sub GetDetail(ByVal LogId As String)
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        If LogId <> String.Empty Then
            dt = oWS.LogDetail(LogId)
            If dt.Rows.Count > 0 Then
                txtLogID.Text = LogId
                ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue(dt.Rows(0).Item("status").ToString()))
                ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(dt.Rows(0).Item("customer").ToString()))
                txtSubject.Text = dt.Rows(0).Item("subject").ToString
                txtProblems.Text = dt.Rows(0).Item("problem").ToString
                txtCause.Text = dt.Rows(0).Item("cause").ToString
                txtSolution.Text = dt.Rows(0).Item("solution").ToString
                txtHowtoCheck.Text = dt.Rows(0).Item("how_to_check").ToString
                txtCurrentSol.Text = dt.Rows(0).Item("current_solution").ToString
                txtLongTermSol.Text = dt.Rows(0).Item("longterm_solution").ToString
                ddlErrorType.SelectedIndex = ddlErrorType.Items.IndexOf(ddlErrorType.Items.FindByText(dt.Rows(0).Item("error_type").ToString()))
                ddlResponsible.SelectedIndex = ddlResponsible.Items.IndexOf(ddlResponsible.Items.FindByValue(dt.Rows(0).Item("respond_by").ToString()))
                txtResponseDate.Text = dt.Rows(0).Item("respond_date").ToString()
                ddlResponseTime.SelectedIndex = ddlResponseTime.Items.IndexOf(ddlResponseTime.Items.FindByValue(dt.Rows(0).Item("respond_time").ToString()))
                ddlClosedBy.SelectedIndex = ddlClosedBy.Items.IndexOf(ddlClosedBy.Items.FindByValue(dt.Rows(0).Item("closed_by").ToString()))
                txtClosedDate.Text = dt.Rows(0).Item("end_date").ToString()
                ddlClosedTime.SelectedIndex = ddlClosedTime.Items.IndexOf(ddlClosedTime.Items.FindByValue(dt.Rows(0).Item("end_time").ToString()))
            Else
                NotPassNotifyPanel.Visible = True
                NotPassText.Text = "Log ID. " & LogId & " not found."
            End If
            GetResponseTime()
        End If
    End Sub

    Protected Sub ClearText()
        GetStatusSupport()
        GetCustomer()
        GetResource()
        GetErrorType()
        txtLogID.Text = String.Empty
        txtSubject.Text = String.Empty
        txtCause.Text = String.Empty
        txtSolution.Text = String.Empty
        txtProblems.Text = String.Empty
        txtHowtoCheck.Text = String.Empty
        txtCurrentSol.Text = String.Empty
        txtLongTermSol.Text = String.Empty
        'txtResponseDate.Text = String.Empty
        ddlResponseTime.Items.Clear()
        ddlClosedTime.Items.Clear()
    End Sub

    Protected Sub txtLogID_TextChanged(sender As Object, e As EventArgs) Handles txtLogID.TextChanged
        If txtLogID.Text <> String.Empty Then
            PassNotifyPanel.Visible = False
            NotPassNotifyPanel.Visible = False
            GetDetail(txtLogID.Text)
        End If
    End Sub

    Protected Function GetSupportMailByCustomer(CustNum As String) As String
        Dim mail As String
        Dim objMail As GetMailSupport = New GetMailSupport()
        mail = objMail.GetMailSupport(CustNum)
        Return mail
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim arrEmail As String()
        Dim sOldStat As String = String.Empty
        Dim sEmailSupport As String = String.Empty
        Dim objSendMail As SendMail = New SendMail()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        Try
            If txtLogID.Text <> String.Empty Then
                dt = oWS.LogDetail(txtLogID.Text)
                sOldStat = dt.Rows(0).Item("status").ToString()
                dt.Clear()
                dt = oWS.UpdateSupportLog(txtLogID.Text,
                                          ddlStat.SelectedItem.Value,
                                          txtCause.Text,
                                          txtSolution.Text,
                                          ddlErrorType.SelectedItem.Value,
                                          ddlResponsible.SelectedItem.Value,
                                          ddlClosedBy.SelectedItem.Value,
                                          txtProblems.Text,
                                          Session("Username").ToString(),
                                          txtHowtoCheck.Text,
                                          txtCurrentSol.Text,
                                          txtLongTermSol.Text,
                                          txtResponseDate.Text,
                                          ddlResponseTime.SelectedItem.Text,
                                          txtClosedDate.Text,
                                          ddlClosedTime.SelectedItem.Text
                                          )
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("pStat").ToString = "0" Then
                        PassNotifyPanel.Visible = True
                        PassText.Text = dt.Rows(0).Item("pMessage").ToString
                        'Send Mail When Change Status Closed
                        If ddlStat.SelectedItem.Value = "C" And sOldStat <> "C" Then
                            If Not String.IsNullOrEmpty(dt.Rows(0).Item("email").ToString()) Then
                                arrEmail = dt.Rows(0).Item("email").ToString().Split(",")
                                sEmailSupport = GetSupportMailByCustomer(dt.Rows(0).Item("cust_num").ToString())
                                objSendMail.SendClosedMailSupport(arrEmail, sEmailSupport, dt)
                            End If
                            'For Each sListMail As String In arrEmail
                            '    MsgBox(arrEmail)
                            'Next
                            'arrEmail = dt.Rows(0).Item("email").ToString().Split(",")
                            'sEmailSupport = GetSupportMailByCustomer(dt.Rows(0).Item("cust_num").ToString())
                            'objSendMail.SendClosedMailSupport(arrEmail, sEmailSupport, dt)
                        End If
                    Else
                        NotPassNotifyPanel.Visible = True
                        NotPassText.Text = dt.Rows(0).Item("pMessage").ToString
                    End If
                Else
                    NotPassNotifyPanel.Visible = True
                    NotPassText.Text = dt.Rows(0).Item("pMessage").ToString
                End If
                ClearText()
            End If
        Catch ex As Exception
            NotPassNotifyPanel.Visible = True
            NotPassText.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearText()
    End Sub

    Protected Sub GetResponseTime()
        'Set start time (00:00 means 12:00 AM)
        Dim StartTime As DateTime = DateTime.ParseExact("00:00", "HH:mm", Nothing)
        'Set end time (23:55 means 11:55 PM)
        Dim EndTime As DateTime = DateTime.ParseExact("23:55", "HH:mm", Nothing)
        'Set 5 minutes interval
        Dim Interval As New TimeSpan(0, 5, 0)
        'To set 1 hour interval
        'Dim Interval As New TimeSpan(1, 0, 0)
        Dim ResponseTime As String = dt.Rows(0).Item("respond_time").ToString()
        Dim ClosedTime As String = dt.Rows(0).Item("end_time").ToString()
        While StartTime <= EndTime
            ddlResponseTime.Items.Add(StartTime.ToShortTimeString())
            ddlClosedTime.Items.Add(StartTime.ToShortTimeString())
            StartTime = StartTime.Add(Interval)
        End While
        ddlResponseTime.Items.Insert(0, New ListItem(ResponseTime, "0"))
        ddlClosedTime.Items.Insert(0, New ListItem(ClosedTime, "0"))
    End Sub

End Class