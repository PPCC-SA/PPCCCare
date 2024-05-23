Imports System.Data
Imports System.Web.Services
Imports System.Xml
Public Class WebForm2
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet
    Dim MsgErr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("Username") = String.Empty And Session("Customer") = String.Empty And Session("Category") = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else

                If Request.QueryString("sLogID") <> "" Or Not String.IsNullOrEmpty(Request.QueryString("sLogID")) Then

                    GetStatusSupport()
                    GetCustomer()
                    GetResource()
                    GetErrorType()
                    'GetResponseTime()
                    EnabledField()
                    GetResponseTime()
                    GetDetail(Request.QueryString("sLogID"))

                Else

                    Response.Redirect("CustomerLog.aspx")

                End If




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

        Dim LogId, Cust, Requestor, ReqDate, FormName, DbSite, Problem, Causes, Solutions, ResponseBy, CloseDate, CloseBy As String

        If txtLogID.Text <> String.Empty Then
            dt = oWS.LogDetail(txtLogID.Text)
            If dt.Rows.Count > 0 Then

                LogId = dt.Rows(0).Item("log_id").ToString
                Cust = dt.Rows(0).Item("customer").ToString
                Requestor = dt.Rows(0).Item("req").ToString
                ReqDate = Format(CDate(dt.Rows(0).Item("req_date").ToString), "dd/MM/yyyy")
                FormName = dt.Rows(0).Item("form").ToString
                DbSite = dt.Rows(0).Item("db_site").ToString
                Problem = dt.Rows(0).Item("problem").ToString
                Causes = dt.Rows(0).Item("cause").ToString
                Solutions = dt.Rows(0).Item("solution").ToString
                ResponseBy = dt.Rows(0).Item("respond_by_name").ToString
                CloseDate = dt.Rows(0).Item("end_date").ToString
                CloseBy = dt.Rows(0).Item("closed_by_name").ToString

            End If

        Else

            LogId = String.Empty
            Cust = String.Empty
            Requestor = String.Empty
            ReqDate = String.Empty
            FormName = String.Empty
            DbSite = String.Empty
            Problem = String.Empty
            Causes = String.Empty
            Solutions = String.Empty
            ResponseBy = String.Empty
            CloseDate = String.Empty
            CloseBy = String.Empty

        End If

        Problem = Problem.Replace("'", "\'")
        Problem = Problem.Replace(vbLf, "\n")

        Causes = Causes.Replace("'", "\'")
        Causes = Causes.Replace(vbLf, "\n")

        Solutions = Solutions.Replace("'", "\'")
        Solutions = Solutions.Replace(vbLf, "\n")

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal('" & LogId & "',
                                                                                '" & Cust & "',
                                                                                '" & Requestor & "',
                                                                                '" & ReqDate & "',
                                                                                '" & FormName & "',
                                                                                '" & DbSite & "',
                                                                                '" & Problem & "',
                                                                                '" & Causes & "',
                                                                                '" & Solutions & "',
                                                                                '" & ResponseBy & "',
                                                                                '" & CloseDate & "',
                                                                                '" & CloseBy & "');", True)


        '    ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal();", True)

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
                ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue(dt.Rows(0).Item("status").ToString))
                HiddenStat.Value = dt.Rows(0).Item("status").ToString
                ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(dt.Rows(0).Item("customer").ToString))
                txtSubject.Text = dt.Rows(0).Item("subject").ToString
                txtProblems.Text = dt.Rows(0).Item("problem").ToString
                txtCause.Text = dt.Rows(0).Item("cause").ToString
                txtSolution.Text = dt.Rows(0).Item("solution").ToString
                txtHowtoCheck.Text = dt.Rows(0).Item("how_to_check").ToString
                txtCurrentSol.Text = dt.Rows(0).Item("current_solution").ToString
                txtLongTermSol.Text = dt.Rows(0).Item("longterm_solution").ToString
                ddlErrorType.SelectedIndex = ddlErrorType.Items.IndexOf(ddlErrorType.Items.FindByText(dt.Rows(0).Item("error_type").ToString))
                ddlResponsible.SelectedIndex = ddlResponsible.Items.IndexOf(ddlResponsible.Items.FindByValue(dt.Rows(0).Item("respond_by").ToString))
                txtResponseDate.Text = dt.Rows(0).Item("respond_date").ToString
                ddlResponseTime.SelectedIndex = ddlResponseTime.Items.IndexOf(ddlResponseTime.Items.FindByValue(dt.Rows(0).Item("respond_time").ToString))
                ddlClosedBy.SelectedIndex = ddlClosedBy.Items.IndexOf(ddlClosedBy.Items.FindByValue(dt.Rows(0).Item("closed_by").ToString))
                txtClosedDate.Text = dt.Rows(0).Item("end_date").ToString
                ddlClosedTime.SelectedIndex = ddlClosedTime.Items.IndexOf(ddlClosedTime.Items.FindByValue(dt.Rows(0).Item("end_time").ToString))
            Else

                MsgErr = "Log ID. " & LogId & " not found."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

                'NotPassNotifyPanel.Visible = True
                'NotPassText.Text = "Log ID. " & LogId & " not found."
            End If

        End If
    End Sub

    'Protected Sub ClearText()
    '    ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue(""))

    '    If Session("Customer") <> String.Empty Then
    '        If Session("Category") = "Admin" Then 'Session("Customer") = "PPCC" Then
    '            ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(""))
    '        Else
    '            ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(Session("Customer").ToString))
    '        End If
    '    End If

    '    ddlResponsible.SelectedIndex = ddlResponsible.Items.IndexOf(ddlResponsible.Items.FindByValue(""))
    '    ddlClosedBy.SelectedIndex = ddlClosedBy.Items.IndexOf(ddlClosedBy.Items.FindByValue(""))
    '    ddlErrorType.SelectedIndex = ddlErrorType.Items.IndexOf(ddlErrorType.Items.FindByText(""))

    '    txtLogID.Text = String.Empty
    '    txtSubject.Text = String.Empty
    '    txtCause.Text = String.Empty
    '    txtSolution.Text = String.Empty
    '    txtProblems.Text = String.Empty
    '    txtHowtoCheck.Text = String.Empty
    '    txtCurrentSol.Text = String.Empty
    '    txtLongTermSol.Text = String.Empty
    '    txtResponseDate.Text = String.Empty


    '    ddlResponseTime.SelectedIndex = ddlResponseTime.Items.IndexOf(ddlResponseTime.Items.FindByValue("0"))
    '    ddlClosedTime.SelectedIndex = ddlClosedTime.Items.IndexOf(ddlClosedTime.Items.FindByValue("0"))
    'End Sub

    Protected Sub txtLogID_TextChanged(sender As Object, e As EventArgs) Handles txtLogID.TextChanged
        If txtLogID.Text <> String.Empty Then
            'PassNotifyPanel.Visible = False
            'NotPassNotifyPanel.Visible = False
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
                'dt = oWS.LogDetail(txtLogID.Text)
                sOldStat = HiddenStat.Value
                dt.Clear()
                dt = oWS.UpdateSupportLog(txtLogID.Text,
                                          ddlStat.SelectedItem.Value,
                                          txtCause.Text,
                                          txtSolution.Text,
                                          ddlErrorType.SelectedItem.Value,
                                          ddlResponsible.SelectedItem.Value,
                                          ddlClosedBy.SelectedItem.Value,
                                          txtProblems.Text,
                                          Session("Username").ToString,
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
                        'PassNotifyPanel.Visible = True
                        'PassText.Text = dt.Rows(0).Item("pMessage").ToString

                        MsgErr = dt.Rows(0).Item("pMessage").ToString

                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlertBack('Success','" & MsgErr & "', 'success');", True)

                        'Send Mail When Change Status Closed
                        If ddlStat.SelectedItem.Value = "C" And sOldStat <> "C" Then
                            'Send Mail
                            If Not String.IsNullOrEmpty(dt.Rows(0).Item("email").ToString) Then
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
                        'NotPassNotifyPanel.Visible = True
                        'NotPassText.Text = dt.Rows(0).Item("pMessage").ToString

                        MsgErr = dt.Rows(0).Item("pMessage").ToString
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

                    End If

                Else
                    'NotPassNotifyPanel.Visible = True
                    'NotPassText.Text = dt.Rows(0).Item("pMessage").ToString

                    MsgErr = dt.Rows(0).Item("pMessage").ToString
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

                End If

                'ClearText()
                GetDetail(Request.QueryString("sLogID"))

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

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'ClearText()
        GetDetail(Request.QueryString("sLogID"))
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
        'Dim ResponseTime As String = dt.Rows(0).Item("respond_time").ToString()
        'Dim ClosedTime As String = dt.Rows(0).Item("end_time").ToString()
        While StartTime <= EndTime
            ddlResponseTime.Items.Add(StartTime.ToShortTimeString())
            ddlClosedTime.Items.Add(StartTime.ToShortTimeString())
            StartTime = StartTime.Add(Interval)
        End While
        ddlResponseTime.Items.Insert(0, New ListItem("", "0"))
        ddlClosedTime.Items.Insert(0, New ListItem("", "0"))
    End Sub


End Class