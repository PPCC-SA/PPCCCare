Imports System.IO
Imports System.Web.HttpApplicationState
Imports System.Web.Services
Imports System.Xml

Public Class IssueSummary
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Username") = String.Empty And Session("Customer") = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else
                GetStartCustomer()
                GetEndCustomer()
                'DisabledCustomer()
                GetFirstAndLastDaysOfMonth()

                If Session("Category").ToString <> "Admin" Then 'Session("Customer") <> "PPCC" Then
                    If ddlStartCust.SelectedItem.Value <> String.Empty Then
                        oWS = New ServiceSupport.ServiceSupportSoapClient
                        dt = New DataTable
                        ds = New DataSet
                        dt = oWS.GetCustomer(Session("CustGroup").ToString)
                        If dt.Rows.Count = 1 Then
                            ddlEndCust.SelectedIndex = ddlEndCust.Items.IndexOf(ddlEndCust.Items.FindByValue(ddlStartCust.SelectedItem.Value))
                        End If
                    End If
                End If
            End If
        End If
    End Sub




    Protected Sub GetStartCustomer()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        ddlStartCust.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlStartCust.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next

        If Session("Customer") <> String.Empty Then
            If Session("Customer") = "PPCC" Then
                ddlStartCust.Items.Insert(0, New ListItem("", ""))
            Else
                'ddlStartCust.SelectedIndex = ddlStartCust.Items.IndexOf(ddlStartCust.Items.FindByValue(Session("Customer").ToString))
                If ds.Tables(0).Rows.Count = 1 Then
                    ddlStartCust.SelectedIndex = ddlStartCust.Items.IndexOf(ddlStartCust.Items.FindByValue(Session("Customer").ToString))
                Else
                    'ddlStartCust.Items.Insert(0, New ListItem("", ""))
                End If
            End If
        Else
            'condition when session customer is null
        End If

    End Sub

    Protected Sub GetEndCustomer()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlEndCust.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlEndCust.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next

        If Session("Customer") <> String.Empty Then
            If Session("Customer") = "PPCC" Then
                ddlEndCust.Items.Insert(0, New ListItem("", ""))
            Else
                'ddlEndCust.SelectedIndex = ddlStartCust.Items.IndexOf(ddlStartCust.Items.FindByValue(Session("Customer").ToString))
                If ds.Tables(0).Rows.Count = 1 Then
                    ddlEndCust.SelectedIndex = ddlEndCust.Items.IndexOf(ddlEndCust.Items.FindByValue(Session("Customer").ToString))
                Else
                    'ddlEndCust.Items.Insert(0, New ListItem("", ""))
                End If
            End If
        Else
            'condition when session customer is null
        End If

    End Sub


    Protected Sub DisabledCustomer()
        If Session("Customer") = "PPCC" Then
            ddlStartCust.Attributes.Remove("disabled")
            ddlEndCust.Attributes.Remove("disabled")
        Else
            ddlStartCust.Attributes.Add("disabled", "disabled")
            ddlEndCust.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Protected Sub GetFirstAndLastDaysOfMonth()
        Dim Current As Date
        Dim First As Date
        Dim Last As Date
        Current = Date.Now
        First = New DateTime(Current.Year, Current.Month, 1)
        Last = First.AddMonths(1).AddDays(-1)
        txtStartReqDate.Text = First.ToString("dd/MM/yyyy")
        txtEndReqDate.Text = Last.ToString("dd/MM/yyyy")
    End Sub

    Protected Sub ddlStartCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStartCust.SelectedIndexChanged
        Dim strCust As String
        strCust = String.Empty

        If ddlStartCust.SelectedValue <> String.Empty Then
            strCust = ddlStartCust.SelectedItem.Value
            ddlEndCust.SelectedIndex = ddlStartCust.Items.IndexOf(ddlStartCust.Items.FindByValue(strCust))
        End If
    End Sub


#Region "Get Support Log Insert into DataTable"
    Protected Sub bntLoad_Click(sender As Object, e As EventArgs) Handles bntLoad.Click
        Dim sDate, eDate, Name As String
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        sDate = txtStartReqDate.Text
        eDate = txtEndReqDate.Text
        Name = ddlStartCust.SelectedItem.Text

        If sDate = String.Empty Then
            sDate = "01/01/1990"
        End If

        If eDate = String.Empty Then
            eDate = "31/12/3000"
        End If

        If CheckBox1.Checked = True Then

            dt = oWS.GetIssueSummaryReports(IIf(ddlStartCust.SelectedItem.Value = String.Empty, String.Empty, ddlStartCust.SelectedItem.Value) _
                                       , IIf(ddlEndCust.SelectedItem.Value = String.Empty, String.Empty, ddlEndCust.SelectedItem.Value) _
                                       , CDate(Convert.ToDateTime(sDate)).ToString("yyyy-MM-dd") _
                                       , CDate(Convert.ToDateTime(eDate)).ToString("yyyy-MM-dd"), Session("CustGroup").ToString)
            ' ds.Tables.Add(dt)

        Else

            dt = oWS.GetIssueSummaryReport(IIf(ddlStartCust.SelectedItem.Value = String.Empty, String.Empty, ddlStartCust.SelectedItem.Value) _
                                   , IIf(ddlEndCust.SelectedItem.Value = String.Empty, String.Empty, ddlEndCust.SelectedItem.Value) _
                                   , CDate(Convert.ToDateTime(sDate)).ToString("yyyy-MM-dd") _
                                   , CDate(Convert.ToDateTime(eDate)).ToString("yyyy-MM-dd"), Session("CustGroup").ToString)
            'ds.Tables.Add(dt)

        End If

        ds.Tables.Add(dt)

        If dt.Rows.Count > 0 Then
                RenderExcel(dt, Name, sDate, eDate)
            Else
                RenderExcel(dt, Name, sDate, eDate)
            End If

    End Sub
#End Region


#Region "Render Excel"
    Protected Sub RenderExcel(dtReport As DataTable, Name As String, sReqDate As String, eReqDate As String)
        Dim sFileName As String
        sFileName = "attachment;filename=" & "PPCC_IssueSummary_" & Session("Customer") & "_" & Format(Now, "yyyyMMddHHmmss") & ".xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", sFileName)
        'Response.ContentType = "application/vnd.ms-excel"
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.ContentEncoding = System.Text.Encoding.Unicode
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        Response.Charset = "utf-8"
        Response.Write("<HTML>")
        Response.Write("<BODY>")
        Response.Write("<TABLE style='font-family: Tahoma; font-size: 11pt'>")
        Response.Write("<p style='text-align: center'>" & Name & " Support Log Report</p>")
        Response.Write("<p style='text-align: center'>" & sReqDate & " - " & eReqDate & "</p>")
        Response.Write("<TR>")
        For Each dc As DataColumn In dtReport.Columns
            Response.Write("<TD style='background-color: #4f81bd; vertical-align: middle; text-align: center; font-weight: bold; color: #ffffff'>")
            Response.Write(dc.ColumnName)
            Response.Write("</TD>")
            'sTab = vbTab
        Next
        Response.Write("</TR>")
        'Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dtReport.Rows
            'sTab = ""
            Response.Write("<TR style='vertical-align: middle'>")
            For i = 0 To dt.Columns.Count - 1
                Response.Write("<TD>")
                Response.Write(dr(i).ToString())
                Response.Write("</TD>")
                'sTab = vbTab
            Next
            Response.Write("</TR>")
            'Response.Write(vbLf)
        Next
        Response.Write("</TABLE>")
        Response.Write("</BODY>")
        Response.Write("</HTML>")
        'Response.Flush()
        Response.End()
    End Sub


#End Region

End Class