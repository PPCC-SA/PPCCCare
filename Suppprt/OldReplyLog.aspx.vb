Imports System.Data
Imports System.Web.Services
Imports System.Xml

Public Class OldReplyLog
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Username").ToString = String.Empty And
               Session("Customer").ToString = String.Empty And
               Session("Category").ToString = String.Empty And
               Session("CustGroup").ToString = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else
                GetDetail(Request.QueryString("sLogID"))
                GetReplyLog(Request.QueryString("sLogID"))
            End If
        End If
    End Sub

    Protected Sub GetDetail(ByVal LogId As String)
        'Dim sFormName, sSubject, sProblem, sCause, sSolution As String
        'Dim sDetail As String
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        If LogId <> String.Empty Then
            dt = oWS.LogDetail(LogId)
            If dt.Rows.Count > 0 Then
                lblsLogId.Text = LogId
                lblsProblem.Text = dt.Rows(0).Item("problem").ToString
                lblsCause.Text = dt.Rows(0).Item("cause").ToString
                lblsSolution.Text = dt.Rows(0).Item("solution").ToString
                lblSubject.Text = dt.Rows(0).Item("subject").ToString
                'sDetail = "Form Name: " & sFormName & vbCrLf &
                '          "Subject: " & sSubject & vbCrLf
                'lblDetailLog.Text = sDetail.ToString()
            Else
                NotPassNotifyPanel.Visible = True
                NotPassText.Text = "Log ID. " & LogId & " not found."
            End If
        End If
    End Sub

    Protected Sub GetReplyLog(LogID)
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        RepeaterReply.DataSource = Nothing
        RepeaterReply.DataBind()
        dt = oWS.GetReplyLog(LogID)
        ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count > 0 Then
            RepeaterReply.DataSource = ds.Tables(0)
            RepeaterReply.DataBind()
        End If
    End Sub

    Protected Function GetSupportMailByCustomer(CustNum As String) As String
        Dim mail As String
        Dim objMail As GetMailSupport = New GetMailSupport()
        mail = objMail.GetMailSupport(CustNum)
        Return mail
    End Function

    Protected Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        Dim sLogId As String = lblsLogId.Text
        Dim User As String = Session("Username").ToString
        Dim objSendMail As SendMail = New SendMail()
        Dim sEmailSupport As String = String.Empty
        Dim arrEmail As String()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        Try
            dt = oWS.InsertReplyLog(lblsLogId.Text,
                                    txtReply.Text,
                                    Session("Username").ToString())

            If dt.Rows.Count > 0 Then
                txtReply.Text = String.Empty
                PassNotifyPanel.Visible = True
                sEmailSupport = GetSupportMailByCustomer(dt.Rows(0).Item("cust_num").ToString())
                arrEmail = dt.Rows(0).Item("email").ToString().Split(",")
                objSendMail.SendMailReplyLog(arrEmail, sEmailSupport, dt)
                PassText.Text = "Reply Log ID. " & sLogId & " saved successfully."
                GetReplyLog(Request.QueryString("sLogID"))
            Else
                NotPassNotifyPanel.Visible = True
                NotPassText.Text = "Saved failed. Please try agian."
            End If
        Catch ex As Exception
            NotPassNotifyPanel.Visible = True
            NotPassText.Text = ex.Message
        End Try
    End Sub
End Class