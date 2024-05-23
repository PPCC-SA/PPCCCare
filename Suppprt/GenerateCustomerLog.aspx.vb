Imports System.IO
Imports System.Web.Services
Imports System.Xml
Imports System.Net
Imports System.Net.Mail
Public Class GenerateCustomerLog
    Inherits System.Web.UI.Page

    Dim oWS As ServiceSupport.ServiceSupportSoapClient
    Dim dt As DataTable
    Dim ds As DataSet
    Dim MsgErr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Username").ToString = String.Empty And
               Session("Customer").ToString = String.Empty And
               Session("Category").ToString = String.Empty And
               Session("CustGroup").ToString = String.Empty Then
                Response.Redirect("Signin.aspx")
                Response.End()
            Else

                DisabledEnabledDropdown()
                DisabledDropdown()
                GetStatusSupport()
                GetCustomer(Session("CustGroup").ToString)
                'GetModuleSupport()
                GetRequestor(String.Empty)
                'GetDatabaseSite(String.Empty)
                'GetProgramGroup(String.Empty)
                GetSeverity()
                CalculateProjectedDate()
                'GetInformProblem()
                'GetResponse()
                GetRequestAndResponseTime()

                txtRequestDate.Text = Date.Now.ToString("dd/MM/yyyy")

                If ddlCustomer.SelectedItem.Value <> String.Empty Then
                    SetCustomerEmailSupport(ddlCustomer.SelectedItem.Value)
                End If
                'txtRequestDate.Text = Date.Now.ToString("dd/MM/yyyy")
                'txtResponseDate.Text = Date.Now.ToString("dd/MM/yyyy")               

            End If

        End If

        If ddlCustomer.SelectedItem.Value <> "" Then

            ddlRequestor.Attributes.Remove("disabled")
            'ddlDbSite.Attributes.Remove("disabled")
        Else

            ddlRequestor.Items.Clear()
            'ddlDbSite.Items.Clear()

            ddlRequestor.Attributes.Add("disabled", "disabled")
            'ddlDbSite.Attributes.Add("disabled", "disabled")
        End If

        'If ddlModule.SelectedItem.Value <> "" Then

        '    ddlProgramGroup.Attributes.Remove("disabled")

        'Else

        '    ddlProgramGroup.Items.Clear()

        '    ddlProgramGroup.Attributes.Add("disabled", "disabled")

        'End If


        'ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue("O"))
    End Sub

    Protected Sub DisabledDropdown()
        If Session("Category") = "Admin" Then 'Session("Customer") = "PPCC" Then
            'ddlStat.Attributes.Remove("disabled")
            ddlSeverity.Attributes.Remove("disabled")
            'ddlCustomer.Attributes.Remove("disabled")
        Else
            'ddlStat.Attributes.Add("disabled", "disabled")
            ddlSeverity.Attributes.Add("disabled", "disabled")
            'ddlCustomer.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Protected Sub GetRequestor(ByVal sSession As String)
        'Dim Customer As String
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        ddlRequestor.Items.Clear()
        If Session("Category").ToString <> "Admin" Then 'sSession <> "PPCC" Then
            dt = oWS.GetRequestorSupport(ddlCustomer.SelectedItem.Value)
            ds.Tables.Add(dt)
            For Each dRow As Data.DataRow In ds.Tables(0).Rows
                ddlRequestor.Items.Add(New ListItem(dRow("description"), dRow("req")))
            Next
        Else
            If ddlCustomer.SelectedItem.Value <> String.Empty Then
                dt = oWS.GetRequestorSupport(ddlCustomer.SelectedItem.Value)
                ds.Tables.Add(dt)
                For Each dRow As Data.DataRow In ds.Tables(0).Rows
                    ddlRequestor.Items.Add(New ListItem(dRow("description"), dRow("req")))
                Next
            End If
        End If
        ddlRequestor.Items.Insert(0, New ListItem("", ""))
    End Sub

    Protected Sub GetStatusSupport()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlStat.Items.Clear()
        dt = oWS.GetStatusSupport()
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlStat.Items.Add(New ListItem(dRow("description"), dRow("stat")))
        Next
        ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue("O"))
    End Sub

    'Protected Sub GetModuleSupport()
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet

    '    ddlModule.Items.Clear()
    '    dt = oWS.GetSupportModule()
    '    ds.Tables.Add(dt)
    '    For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '        ddlModule.Items.Add(New ListItem(dRow("desctiption"), dRow("module")))
    '    Next
    '    ddlModule.Items.Insert(0, New ListItem("", ""))
    'End Sub

    Protected Sub GetSeverity()
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlSeverity.Items.Clear()
        dt = oWS.GetSeverity()
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlSeverity.Items.Add(New ListItem(dRow("Value") & " " & dRow("Description"), dRow("Value")))
        Next
        ddlSeverity.SelectedIndex = ddlSeverity.Items.IndexOf(ddlSeverity.Items.FindByValue("Standard"))
        'ddlSeverity.Items.Insert(0, New ListItem("", ""))
    End Sub

    'Protected Sub GetProgramGroup(ByVal sModule As String)
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet

    '    ddlProgramGroup.Items.Clear()
    '    dt = oWS.GetProgramGroup(sModule)
    '    ds.Tables.Add(dt)
    '    For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '        ddlProgramGroup.Items.Add(New ListItem(dRow("programe_group"), dRow("programe_group")))
    '    Next
    '    ddlProgramGroup.Items.Insert(0, New ListItem("", ""))
    'End Sub

    Protected Sub GetCustomer(ByVal sCustGroup As String)
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet

        ddlCustomer.Items.Clear()
        dt = oWS.GetCustomer(Session("CustGroup").ToString)
        ds.Tables.Add(dt)
        For Each dRow As Data.DataRow In ds.Tables(0).Rows
            ddlCustomer.Items.Add(New ListItem(dRow("name"), dRow("cust_num")))
        Next

        If Session("CustGroup").ToString <> String.Empty Then
            If Session("Category") = "Admin" Then 'Session("Customer") = "PPCC" Then
                ddlCustomer.Items.Insert(0, New ListItem("", ""))
            Else
                If ds.Tables(0).Rows.Count = 1 Then
                    ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(Session("Customer").ToString))
                Else
                    ddlCustomer.Items.Insert(0, New ListItem("", ""))
                End If
            End If
        Else
            'condition when session customer is null
        End If
    End Sub

    'Protected Sub GetSupportType()
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet
    '    ddlType.Items.Clear()
    '    dt = oWS.GetTypeSupport()
    '    ds.Tables.Add(dt)
    '    For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '        ddlType.Items.Add(New ListItem(dRow("description"), dRow("type")))
    '    Next
    '    ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue("L"))
    'End Sub

    'Protected Sub GetDatabaseSite(ByVal sSession As String)
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet

    '    ddlDbSite.Items.Clear()

    '    If Session("Category") <> "Admin" Then 'sSession <> "PPCC" Then
    '        dt = oWS.GetDatabaseSite(ddlCustomer.SelectedItem.Value)
    '        ds.Tables.Add(dt)
    '        For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '            ddlDbSite.Items.Add(New ListItem(dRow("description"), dRow("db_site")))
    '        Next
    '    Else
    '        If ddlCustomer.SelectedItem.Value <> String.Empty Then
    '            dt = oWS.GetDatabaseSite(ddlCustomer.SelectedItem.Value)
    '            ds.Tables.Add(dt)
    '            For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '                ddlDbSite.Items.Add(New ListItem(dRow("description"), dRow("db_site")))
    '            Next
    '        End If
    '    End If
    '    ddlDbSite.Items.Insert(0, New ListItem("", ""))
    'End Sub

    Protected Sub SetCustomerEmailSupport(ByVal sCustNum As String)
        Dim sEmailSupport As String
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        dt = oWS.GetCustomerEmailSupport(sCustNum)

        If dt.Rows.Count > 0 Then
            sEmailSupport = IIf(IsDBNull(dt.Rows(0).Item("email_support")), String.Empty, dt.Rows(0).Item("email_support"))
        Else
            sEmailSupport = String.Empty
        End If
        txtEmail.Text = sEmailSupport
    End Sub

    Protected Function GetCustomerEmailSupport(ByVal sCustNum As String) As String
        Dim sEmailSupport As String
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        dt = oWS.GetCustomerEmailSupport(sCustNum)

        If dt.Rows.Count > 0 Then
            sEmailSupport = IIf(IsDBNull(dt.Rows(0).Item("email_support")), String.Empty, dt.Rows(0).Item("email_support"))
        Else
            sEmailSupport = String.Empty
        End If

        Return sEmailSupport
    End Function

    Protected Function GetSupportMailByCustomer(CustNum As String) As String
        Dim mail As String
        Dim objMail As GetMailSupport = New GetMailSupport()
        mail = objMail.GetMailSupport(CustNum)
        Return mail
    End Function

    Protected Sub UploadFile()
        Dim sFileName As String
        Dim sFilePathName As String
        Dim sBasePath As String

        sFilePathName = String.Empty
        If FileUpload.HasFiles Then
            sFileName = Path.GetFileName(FileUpload.FileName)
            sBasePath = AppDomain.CurrentDomain.BaseDirectory + "Files"
            If Not Directory.Exists(sBasePath) Then
                Directory.CreateDirectory(sBasePath)
            End If
            sFilePathName = sBasePath & "\" & sFileName
            FileUpload.SaveAs(sFilePathName)
        End If
    End Sub

    Protected Sub ClearText()

        ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue(""))
        'ddlDbSite.Items.Clear()
        ddlRequestor.Items.Clear()
        'ddlStat.SelectedIndex = ddlStat.Items.IndexOf(ddlStat.Items.FindByValue("O"))
        'ddlInfProblem.SelectedIndex = ddlInfProblem.Items.IndexOf(ddlInfProblem.Items.FindByValue("MAIL"))
        txtRequestDate.Text = Date.Now.ToString("dd/MM/yyyy")
        ddlRequestTime.SelectedIndex = ddlRequestTime.Items.IndexOf(ddlRequestTime.Items.FindByValue("0"))
        'ddlAcknowledge.SelectedIndex = ddlAcknowledge.Items.IndexOf(ddlAcknowledge.Items.FindByValue(""))
        'txtResponseDate.Text = String.Empty
        'ddlResponseTime.SelectedIndex = ddlResponseTime.Items.IndexOf(ddlResponseTime.Items.FindByValue("0"))
        txtProgramName.Text = String.Empty
        txtSubject.Text = String.Empty
        'ddlModule.SelectedIndex = ddlModule.Items.IndexOf(ddlModule.Items.FindByValue(""))
        'ddlProgramGroup.Items.Clear()
        ddlSeverity.SelectedIndex = ddlSeverity.Items.IndexOf(ddlSeverity.Items.FindByValue("Medium"))
        txtDesc.Text = String.Empty
        'txtCause.Text = String.Empty
        'txtHowtoCheck.Text = String.Empty
        'txtCurrentSol.Text = String.Empty
        'txtLongTermSol.Text = String.Empty
        txtEmail.Text = String.Empty
        FileUpload.Dispose()
        'CheckBoxAfterWork.Checked = False
        'CheckBoxHoliday.Checked = False
        CalculateProjectedDate()

        If ddlCustomer.SelectedItem.Value <> "" Then

            ddlRequestor.Attributes.Remove("disabled")
            'ddlDbSite.Attributes.Remove("disabled")
        Else

            ddlRequestor.Items.Clear()
            'ddlDbSite.Items.Clear()

            ddlRequestor.Attributes.Add("disabled", "disabled")
            'ddlDbSite.Attributes.Add("disabled", "disabled")
        End If

        'If ddlModule.SelectedItem.Value <> "" Then
        '    ddlProgramGroup.Attributes.Remove("disabled")

        'Else

        '    ddlProgramGroup.Items.Clear()
        '    ddlProgramGroup.Attributes.Add("disabled", "disabled")

        'End If

        'GetStatusSupport()
        'GetCustomer(Session("CustGroup").ToString())
        'GetRequestor(ddlCustomer.SelectedItem.Value)
        'GetDatabaseSite(ddlCustomer.SelectedItem.Value)
        'GetModuleSupport()
        'GetSeverity()
        'GetProgramGroup(String.Empty)
        'txtEmail.Text = String.Empty
        'txtProgramName.Text = String.Empty
        'txtSubject.Text = String.Empty
        'txtDesc.Text = String.Empty
        'FileUpload.Attributes.Clear()
        'CalculateProjectedDate()
        'GetInformProblem()
        'GetResponse()
        ''ddlRequestTime.Items.Clear()
        ''ddlResponseTime.Items.Clear()
        ''txtResponseDate.Text = String.Empty
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim sLog As String = String.Empty
        Dim sEmail As String = String.Empty
        Dim sEmailSupport As String = String.Empty
        Dim objSendMail As SendMail = New SendMail()
        Dim arrEmail As String()
        Dim iAfterWork As Integer
        Dim iHoliday As Integer
        iAfterWork = 0
        iHoliday = 0
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        ds = New DataSet
        Try
            'If CheckBoxAfterWork.Checked = True Then
            '    iAfterWork = 1
            'Else
            '    iAfterWork = 0
            'End If

            'If CheckBoxHoliday.Checked = True Then
            '    iHoliday = 1
            'Else
            '    iHoliday = 0
            'End If
            iAfterWork = 0
            iHoliday = 0
            UploadFile()
            CalculateProjectedDate()
            dt = oWS.InsertSupportLog(txtLogID.Text,
                                      "O", 'Status
                                      ddlCustomer.SelectedItem.Value,
                                      String.Empty, 'Site
                                      txtProgramName.Text,
                                      txtSubject.Text,
                                      RTrim(LTrim(txtDesc.Text.Replace("<div>", "").Replace("</div>", ""))),
                                      IIf(FileUpload.HasFiles, "Files\" & Path.GetFileName(FileUpload.FileName), String.Empty),
                                      txtEmail.Text,
                                      ddlRequestor.SelectedItem.Value,
                                      String.Empty, 'Module
                                      ddlSeverity.SelectedItem.Value,
                                      String.Empty, 'ProgramGroup
                                      txtProjectedDate.Text,
                                      txtRequestDate.Text,
                                      iAfterWork,
                                      iHoliday,
                                      String.Empty, 'Problem
                                      String.Empty, 'Cause
                                      String.Empty, 'HowtoCheck
                                      String.Empty, 'CurrentSol
                                      String.Empty, 'LongTermSol
                                      ddlRequestTime.SelectedItem.Text,
                                      String.Empty, 'Acknowledge
                                      String.Empty, 'ResponseDate
                                      String.Empty, 'ResponseTime
                                      Session("Username").ToString())

            If dt.Rows.Count > 0 Then

                sEmailSupport = GetSupportMailByCustomer(ddlCustomer.SelectedItem.Value)
                sLog = dt.Rows(0).Item("log_id")
                sEmail = dt.Rows(0).Item("email")
                arrEmail = dt.Rows(0).Item("email").ToString().Split(",")
                objSendMail.SendMailSupport(arrEmail, sEmailSupport, dt)

                MsgErr = "Log ID. " & sLog & " saved successfully. Information will be sent to " & dt.Rows(0).Item("email").ToString.Replace(",", " ")
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Success','" & MsgErr & "', 'success');", True)


                ClearText()

                'PassNotifyPanel.Visible = True
                'PassText.Text = "Log ID. " & sLog & " saved successfully. Information will be sent to " & dt.Rows(0).Item("email").ToString.Replace(",", " ")
            Else

                MsgErr = "Saved failed. Please try agian."
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

                'NotPassNotifyPanel.Visible = True
                'NotPassText.Text = "Saved failed. Please try agian."
            End If

            'ClearText()
        Catch ex As Exception

            MsgErr = ex.Message
            MsgErr = MsgErr.Replace("'", "\'")
            MsgErr = MsgErr.Replace(vbLf, "\n")

            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "ShowSweetAlert('Error','" & MsgErr & "', 'error');", True)

            'NotPassNotifyPanel.Visible = True
            'NotPassText.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged

        If ddlCustomer.SelectedItem.Value <> "" Then

            'GetDatabaseSite(ddlCustomer.SelectedItem.Value)
            GetRequestor(ddlCustomer.SelectedItem.Value)
            SetCustomerEmailSupport(ddlCustomer.SelectedItem.Value)

        End If


        'PassNotifyPanel.Visible = False
        'NotPassNotifyPanel.Visible = False
    End Sub

    Protected Sub ddlRequestor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRequestor.SelectedIndexChanged
        Dim sEmail As String = String.Empty
        Dim sSupportEmail As String = String.Empty
        oWS = New ServiceSupport.ServiceSupportSoapClient
        dt = New DataTable
        sSupportEmail = GetCustomerEmailSupport(ddlCustomer.SelectedItem.Value)
        If ddlRequestor.SelectedItem.Value <> String.Empty Then
            dt = oWS.GetEmailRequestor(ddlCustomer.SelectedItem.Value,
                                       ddlRequestor.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                sEmail = IIf(IsDBNull(dt.Rows(0).Item("email")), String.Empty, dt.Rows(0).Item("email"))
            Else
                sEmail = String.Empty
            End If

            If sSupportEmail <> String.Empty Then
                sEmail = sSupportEmail + IIf(sEmail = String.Empty, String.Empty, "," + sEmail)
            Else
                sEmail = sEmail
            End If

            txtEmail.Text = sEmail
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearText()
        'Response.Redirect("GenerateLog.aspx")
    End Sub

    'Protected Sub ddlModule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlModule.SelectedIndexChanged
    '    If ddlModule.SelectedItem.Value <> String.Empty Then
    '        GetProgramGroup(ddlModule.SelectedItem.Value)
    '    End If
    'End Sub

    Protected Sub DisabledEnabledDropdown()
        'ddlProgramGroup.Attributes.Add("disabled", "disabled")
        txtProjectedDate.Attributes.Add("disabled", "disabled")
    End Sub

    Protected Sub ddlSeverity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSeverity.SelectedIndexChanged
        Dim sReqDate As Date
        Dim sDateNow As Date
        sReqDate = CDate(txtRequestDate.Text)
        sDateNow = Date.Now.ToString("dd/MM/yyyy")
        If sReqDate = sDateNow Then
            CalculateProjectedDate()
        Else
            CalculateProjectedDateWithReqDate(sReqDate)
        End If
    End Sub

    Protected Sub CalculateProjectedDate()
        Dim sSeverity As String
        Dim iSeverity As Integer
        Dim dProjectDate As Date
        Dim arrSeverity() As Char
        Dim sDay As String
        iSeverity = 0
        sDay = String.Empty
        If ddlSeverity.SelectedItem.Value <> String.Empty Then
            sSeverity = ddlSeverity.SelectedItem.Text
            arrSeverity = sSeverity.ToCharArray()

            For Each CharSeverity As Char In arrSeverity
                If Char.IsDigit(CharSeverity) Then
                    sDay = sDay & CharSeverity
                End If
            Next

            If Len(sDay) > 1 Then
                iSeverity = CInt(Left(sDay, 1))
            Else
                iSeverity = CInt(sDay)
            End If

            'Select Case sSeverity
            '    Case "High"
            '        iSeverity = 1
            '    Case "Medium"
            '        iSeverity = 3
            '    Case "Low"
            '        iSeverity = 5
            '    Case Else
            '        iSeverity = 3
            'End Select

            oWS = New ServiceSupport.ServiceSupportSoapClient
            dt = New DataTable
            dt = oWS.GetProjectedDate(Date.Now(), iSeverity, "WD")
            If dt.Rows.Count > 0 Then
                dProjectDate = IIf(IsDBNull(dt.Rows(0).Item("WorkingDate")), "", dt.Rows(0).Item("WorkingDate"))
            Else
                dProjectDate = Date.Now()
            End If
            txtProjectedDate.Text = dProjectDate
        End If
    End Sub

    Protected Sub CalculateProjectedDateWithReqDate(ByVal ReqDate As Date)
        Dim sSeverity As String
        Dim iSeverity As Integer
        Dim dProjectDate As Date
        Dim arrSeverity() As Char
        Dim sDay As String
        iSeverity = 0
        sDay = String.Empty
        If ddlSeverity.SelectedItem.Value <> String.Empty Then
            sSeverity = ddlSeverity.SelectedItem.Text
            arrSeverity = sSeverity.ToCharArray()

            For Each CharSeverity As Char In arrSeverity
                If Char.IsDigit(CharSeverity) Then
                    sDay = sDay & CharSeverity
                End If
            Next

            If Len(sDay) > 1 Then
                iSeverity = CInt(Left(sDay, 1))
            Else
                iSeverity = CInt(sDay)
            End If

            'Select Case sSeverity
            '    Case "High"
            '        iSeverity = 1
            '    Case "Medium"
            '        iSeverity = 3
            '    Case "Low"
            '        iSeverity = 5
            '    Case Else
            '        iSeverity = 3
            'End Select

            oWS = New ServiceSupport.ServiceSupportSoapClient
            dt = New DataTable
            dt = oWS.GetProjectedDate(ReqDate, iSeverity, "WD")
            If dt.Rows.Count > 0 Then
                dProjectDate = IIf(IsDBNull(dt.Rows(0).Item("WorkingDate")), "", dt.Rows(0).Item("WorkingDate"))
            Else
                dProjectDate = Date.Now()
            End If
            txtProjectedDate.Text = dProjectDate
        End If
    End Sub

    Protected Sub txtRequestDate_TextChanged(sender As Object, e As EventArgs) Handles txtRequestDate.TextChanged
        Dim sReqDate As Date
        If txtRequestDate.Text <> String.Empty Then
            sReqDate = CDate(txtRequestDate.Text)
            CalculateProjectedDateWithReqDate(sReqDate)
        End If
    End Sub

    'Protected Sub GetInformProblem()
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet

    '    ddlInfProblem.Items.Clear()
    '    dt = oWS.GetInformProblem()
    '    ds.Tables.Add(dt)
    '    For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '        ddlInfProblem.Items.Add(New ListItem(dRow("description"), dRow("Value")))
    '    Next
    '    'ddlInfProblem.SelectedIndex = ddlInfProblem.Items.IndexOf(ddlInfProblem.Items.FindByValue("O"))
    'End Sub

    'Protected Sub GetResponse()
    '    oWS = New ServiceSupport.ServiceSupportSoapClient
    '    dt = New DataTable
    '    ds = New DataSet

    '    ddlAcknowledge.Items.Clear()
    '    dt = oWS.GetResource()
    '    ds.Tables.Add(dt)
    '    For Each dRow As Data.DataRow In ds.Tables(0).Rows
    '        ddlAcknowledge.Items.Add(New ListItem(dRow("res_id") & " - " & dRow("name"), dRow("res_id")))
    '    Next
    '    ddlAcknowledge.Items.Insert(0, New ListItem("", ""))
    'End Sub

    Protected Sub GetRequestAndResponseTime()
        'Set start time (00:00 means 12:00 AM)
        Dim StartTime As DateTime = DateTime.ParseExact("00:00", "HH:mm", Nothing)
        'Set end time (23:55 means 11:55 PM)
        Dim EndTime As DateTime = DateTime.ParseExact("23:55", "HH:mm", Nothing)
        'Set 5 minutes interval
        Dim Interval As New TimeSpan(0, 5, 0)
        'To set 1 hour interval
        'Dim Interval As New TimeSpan(1, 0, 0)
        'ddlRequestTime.Items.Clear()
        'ddlResponseTime.Items.Clear()
        'Dim RequestTime As String = txtRequestDate.Text
        'Dim ResponseTime As String = txtResponseDate.Text
        While StartTime <= EndTime
            ddlRequestTime.Items.Add(StartTime.ToShortTimeString())
            'ddlResponseTime.Items.Add(StartTime.ToShortTimeString())
            StartTime = StartTime.Add(Interval)
        End While
        ddlRequestTime.Items.Insert(0, New ListItem("", "0"))
        'ddlResponseTime.Items.Insert(0, New ListItem("", "0"))
    End Sub
End Class