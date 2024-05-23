Imports System.Net
Imports System.Net.Mail

Public Class SendMail
    Public Sub SendMailSupport(ByVal mTo As String(), ByVal mSupport As String, ByVal sData As DataTable)
        Dim objSetMail As SetMail = New SetMail()
        Dim objStat As StatSupport = New StatSupport()
        Dim sMail As String
        Dim sPassword As String
        sMail = objSetMail.Mail
        sPassword = objSetMail.Password
        objStat.StatSupport = sData.Rows(0).Item("stat").ToString()
        Try
            Dim SupportMail As New System.Net.Mail.MailMessage()
            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            SupportMail.IsBodyHtml = True
            SupportMail.BodyEncoding = System.Text.Encoding.UTF8
            For Each sListMail As String In mTo
                SupportMail.To.Add(sListMail)
            Next
            'SupportMail.To.Add(mTo)
            SupportMail.To.Add(mSupport)
            SupportMail.From = New MailAddress(sMail)
            SupportMail.Subject = sData.Rows(0).Item("subject") & " - " & "Log ID. " & sData.Rows(0).Item("log_id")
            SupportMail.Body = "<html>
                                <body style='margin: 0; padding: 0;'>
                                <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse;'>
                                <tr>
                                <td bgcolor='#00638c' style='padding: 10px 0 10px 0; color: #ffffff; font-family: Tahoma, sans-serif; font-size: 16px;' align='center'>
                                <h2>PPCC CUSTOMER SUPPORT</h2>
                                </td>
                                </tr>
                                <tr>
                                <td bgcolor='#e5e5e5' style='padding: 40px 30px 40px 30px;'>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                เรียน ท่านผู้เกี่ยวข้อง,
                                </td>
                                </tr>
                                <tr>
                                <td style='padding: 20px 0 30px 0; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                PPCC Support รับทราบปัญหาของท่านแล้ว<br>ท่านสามารถตรวจสอบสถานะของปัญหาได้ที่ <a href=" & """ http://9002a9b9fb45.quickddns.com:83/PPCCSupport/Signin """ & "><font style='color:#235F6F'>Customer Support</font></a><br>ท่านจะได้รับอีเมลแจ้งอีกครั้งเมื่อปัญหาของท่านได้รับการแก้ไขเรียบร้อยแล้ว
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td colspan='3' width='550' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b><u>รายละเอียดปัญหาที่แจ้ง</u></b>
                                </td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Log ID:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("log_id").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Problem:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("problem").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Form:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("form").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Database Site:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("db_site").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Requestor:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("req").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Request Date:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & Format(CDate(sData.Rows(0).Item("req_date")), "dd/MM/yyyy") &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Status:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & objStat.StatSupport &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Cause:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("cause").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>How to Check:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("how_to_check").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Current Solution:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("current_solution").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Long Term Solution:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("longterm_solution").ToString() &
                                "</td>
                                </tr>
                                </table>                              
                                </td>
                                </tr>

                                <tr>
                                <td style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <br><br><b>" & sData.Rows(0).Item("holiday_header").ToString() & "</b><br>" & sData.Rows(0).Item("holiday_text").ToString() &
                                "</td>
                                </tr>

                                </table>
                                </td>
                                </tr>
                                <tr>
                                <td bgcolor='#00638c' style='padding: 30px 30px 30px 30px;'>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td width='75%' style='color: #ffffff; font-family: Tahoma, sans-serif; font-size: 13px;'>
                                <b>&copy; 2019 Premier Professional Consulting Co., Ltd.</b><br/>
                                <b>All Rights Reserved .</b>
                                </td>
                                <td align='right'>
                                <table border='0' cellpadding='0' cellspacing='0'>
                                <tr>
                                <td>
                                <a href='" & "http://www.ppcc.co.th/" & "'>
                                <img src='" & "https://img.icons8.com/ios/50/000000/domain.png" & "' alt='Website' width='38' height='38' style='display: block;' border='0' />
                                </a>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='20'>&nbsp;</td>
                                <td>
                                <a href='" & "https://www.facebook.com/ppcc.co.th" & "'>
                                <img src='" & "https://img.icons8.com/ios/48/000000/facebook-new.png" & "' alt='Facebook' width='38' height='38' style='display: block;' border='0' />
                                </a>
                                </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                </table>
                                </body>
                                </html>"
            If Not String.IsNullOrEmpty(sData.Rows(0).Item("attachment_file")) Then
                Dim sAttachment As System.Net.Mail.Attachment
                sAttachment = New System.Net.Mail.Attachment(AppDomain.CurrentDomain.BaseDirectory & sData.Rows(0).Item("attachment_file"))
                SupportMail.Attachments.Add(sAttachment)
            End If
            smtpServer.EnableSsl = True
            smtpServer.UseDefaultCredentials = True
            smtpServer.Credentials = New System.Net.NetworkCredential(sMail, sPassword)
            smtpServer.Port = 587
            smtpServer.Send(SupportMail)
            SupportMail = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SendClosedMailSupport(ByVal mTo As String(), ByVal mSupport As String, ByVal sData As DataTable)
        Dim objSetMail As SetMail = New SetMail()
        Dim objStat As StatSupport = New StatSupport()
        Dim sMail As String
        Dim sPassword As String
        sMail = objSetMail.Mail
        sPassword = objSetMail.Password
        Try
            Dim SupportMail As New System.Net.Mail.MailMessage()
            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            SupportMail.IsBodyHtml = True
            SupportMail.BodyEncoding = System.Text.Encoding.UTF8
            For Each sListMail As String In mTo
                SupportMail.To.Add(sListMail)
            Next
            SupportMail.To.Add(mSupport)
            SupportMail.From = New MailAddress(sMail)
            SupportMail.Subject = sData.Rows(0).Item("subject") & " - " & "Log ID. " & sData.Rows(0).Item("log_id")
            'SupportMail.Subject = "Log ID. " & sData.Rows(0).Item("log_id") & " - " & sData.Rows(0).Item("subject")
            SupportMail.Body = "<html>
                                <body style='margin: 0; padding: 0;'>
                                <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse;'>
                                <tr>
                                <td bgcolor='#00638c' style='padding: 10px 0 10px 0; color: #ffffff; font-family: Tahoma, sans-serif; font-size: 16px;' align='center'>
                                <h2>PPCC CUSTOMER SUPPORT</h2>
                                </td>
                                </tr>
                                <tr>
                                <td bgcolor='#e5e5e5' style='padding: 40px 30px 40px 30px;'>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                เรียน ท่านผู้เกี่ยวข้อง,
                                </td>
                                <tr>
                                <tr>
                                <td style='padding: 20px 0 30px 0; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                จากปัญหาที่แจ้งมาทาง PPCC ได้ทำการแก้ไขหรือให้คำแนะนำไปแล้ว<br>หากลูกค้าได้ดำเนินการตามและสามารถแก้ไขปัญหาได้อย่างถูกต้องแล้ว<br>ขออนุญาตปิด Log ID: " & sData.Rows(0).Item("log_id") & "<br>หากมีข้อสงสัยหรือยังไม่สามารถแก้ไขได้รบกวนแจ้งกลับ
                                </td>
                                </tr>
                                </table>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td colspan='3' width='540' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b><u>รายละเอียดการแก้ไขปัญหา</u></b>
                                </td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Problem:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("problem").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Cause:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("cause").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Solution:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("solution").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>How to Check:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("how_to_check").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Current Solution:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("current_solution").ToString() &
                                "</td>
                                </tr>
                                <tr>
                                <td width='150' valign='top' style='text-align: right; color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <b>Long Term Solution:</b>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='10'>
                                &nbsp;
                                </td>
                                <td width='400' valign='top' style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>" _
                                & sData.Rows(0).Item("longterm_solution").ToString() &
                                "</td>
                                </tr>
                                </table>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <br><br>ด้วยความเคารพ<br>PPCC SUPPORT
                                </td>
                                </tr>
                                </table>

                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                <br><br><b>" & sData.Rows(0).Item("holiday_header").ToString() & "</b><br> " & sData.Rows(0).Item("holiday_text").ToString() &
                                "</td>
                                </tr>
                                </table>

                                </td>
                                </tr>
                                <tr>
                                <td bgcolor='#00638c' style='padding: 30px 30px 30px 30px;'>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                <tr>
                                <td width='75%' style='color: #ffffff; font-family: Tahoma, sans-serif; font-size: 13px;'>
                                <b>&copy; 2019 Premier Professional Consulting Co., Ltd.</b><br/><b>All Rights Reserved .</b>
                                </td>
                                <td align='right'>
                                <table border='0' cellpadding='0' cellspacing='0'>
                                <tr>
                                <td>
                                <a href='" & "http://www.ppcc.co.th/" & "'>
                                <img src='" & "https://img.icons8.com/ios/50/000000/domain.png" & "' alt='Website' width='38' height='38' style='display: block;' border='0' />
                                </a>
                                </td>
                                <td style='font-size: 0; line-height: 0;' width='20'>&nbsp;</td>
                                <td>
                                <a href='" & "https://www.facebook.com/ppcc.co.th" & "'>
                                <img src='" & "https://img.icons8.com/ios/48/000000/facebook-new.png" & "' alt='Facebook' width='38' height='38' style='display: block;' border='0' />
                                </a>
                                </td>
                                <tr>
                                </table>
                                </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                </table>
                                </body>
                                </html>"
            smtpServer.EnableSsl = True
            smtpServer.Credentials = New System.Net.NetworkCredential(sMail, sPassword)
            smtpServer.Port = 587
            smtpServer.Send(SupportMail)
            SupportMail = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SendMailReplyLog(ByVal mTo As String(), ByVal mSupport As String, ByVal sData As DataTable)
        Dim objSetMail As SetMail = New SetMail()
        Dim objStat As StatSupport = New StatSupport()
        Dim sMail As String
        Dim sPassword As String
        sMail = objSetMail.Mail
        sPassword = objSetMail.Password
        Try
            Dim ReplyLog As New System.Net.Mail.MailMessage()
            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            ReplyLog.IsBodyHtml = True
            ReplyLog.BodyEncoding = System.Text.Encoding.UTF8
            For Each sListMail As String In mTo
                ReplyLog.To.Add(sListMail)
            Next
            ReplyLog.To.Add(mSupport)
            ReplyLog.From = New MailAddress(sMail)
            ReplyLog.Subject = sData.Rows(0).Item("subject") & " - " & "Log ID. " & sData.Rows(0).Item("log_id")
            ReplyLog.Body = "<font style='color: #000000; font-family: Tahoma, sans-serif; font-size: 16px;'>
                                เรียน ท่านผู้เกี่ยวข้อง,
                                <br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;จากปัญหา " & sData.Rows(0).Item("subject") & " มีการตอบกลับปัญหามาดังนี้ " & sData.Rows(0).Item("reply") &
                            "</font>"
            smtpServer.EnableSsl = True
            smtpServer.Credentials = New System.Net.NetworkCredential(sMail, sPassword)
            smtpServer.Port = 587
            smtpServer.Send(ReplyLog)
            ReplyLog = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
