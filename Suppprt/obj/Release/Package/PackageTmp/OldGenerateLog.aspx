<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OldSupport.Master" CodeBehind="OldGenerateLog.aspx.vb" Inherits="Support.OldGenerateLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/richtext.min.css" rel="stylesheet" />
    <script src="js/jquery.richtext.min.js"></script>
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>   

   <%-- <script>
        $(document).ready(function() {
            $('.content').richText();
        });
    </script>--%>

    <style type="text/css">
        .Notify { margin-left: -18px; }
    </style>

    <script type='text/javascript'>
        $(document).ready(function () {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();

            function EndRequestHandler(sender, args) {
                $("#<%=txtProjectedDate.ClientID%>").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    format: "dd/mm/yyyy",
                }).on('changeDate', function (ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });
            }
      
        });

        $(document).ready(function () {

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();

        function EndRequestHandler(sender, args) {
            $("#<%=txtRequestDate.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        }
      
        });

        $(document).ready(function () {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();

            function EndRequestHandler(sender, args) {
                $("#<%=txtResponseDate.ClientID%>").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    format: "dd/mm/yyyy",
                }).on('changeDate', function (ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });
            }

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="row">
            <div class="col-xs-11 Notify">
                <asp:Panel ID="NotPassNotifyPanel" runat="server" CssClass= "alert alert-danger alert-dismissable" Visible="false" Width="100%">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <asp:Literal ID="NotPassText" runat="server"></asp:Literal>
                </asp:Panel>
                <asp:Panel ID="PassNotifyPanel" runat="server" CssClass= "alert alert-success alert-dismissable" Visible="false" Width="100%">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <asp:Literal ID="PassText" runat="server"></asp:Literal>
                </asp:Panel>
            </div>
            <%--<div class="col-xs-1"></div>--%>
            </div>
            <div class="grid-form">
            <div class="form-horizontal">
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblLogID" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Log ID"></asp:Label>
                        </div>
                        <%--<asp:Label ID="lblLogID" runat="server" class="form-control control-label hor-form" Text="Log ID"></asp:Label>--%>
                        <div class="col-sm-2">
                            <asp:TextBox ID="txtLogID" runat="server" class="form-control" type="text" disabled="True" Text="?"></asp:TextBox>
                        </div>
                        <div class="col-sm-1 text-right">
                            <asp:Label ID="lblInformProblem" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Infrom Problem"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlInfProblem" runat="server" class="form-control1"></asp:DropDownList>
                        </div>
                        <div class="col-sm-1 text-right">
                            <asp:Label ID="lblStatus" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Status"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlStat" runat="server" class="form-control1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblRequestDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Request Date"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtRequestDate" AutoPostBack="true" AutoComplete="off" required="required" CssClass="form-control"></asp:TextBox> 
                        </div>      
                        <div class="col-sm-1 text-right">
                            <asp:Label ID="lblRequestTime" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Time"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlRequestTime" class="form-control1"></asp:DropDownList>
                        </div>                    
                        <%--<div class="col-sm-2 text-right">
                            <asp:Label ID="lblStatus" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Status"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlStat" runat="server" class="form-control1"></asp:DropDownList>
                        </div>--%>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblResponseDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Acknowledge Date"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtResponseDate" AutoPostBack="true" AutoComplete="off"  CssClass="form-control"></asp:TextBox> 
                        </div>      
                        <div class="col-sm-1 text-right">
                            <asp:Label ID="lblResponseTime" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Time"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlResponseTime" class="form-control1"></asp:DropDownList>
                        </div>    
                        <div class="col-sm-1 text-right">
                            <asp:Label ID="lblAcknowledge" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Acknowledge By"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlAcknowledge" runat="server" class="form-control1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblCustomer" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Customer"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlCustomer" runat="server" class="form-control1" AutoPostBack="true" required="required"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lbDbSite" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Database Site"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlDbSite" runat="server" class="form-control1">
                                <%--<asp:ListItem value="LIV" selected="True">LIV</asp:ListItem>
                                <asp:ListItem value="CRP">CRP</asp:ListItem>
                                <asp:ListItem value="UAT">UAT</asp:ListItem>--%>
                             </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblRequestor" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Requestor"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlRequestor" name="ddlRequestor" runat="server" class="form-control1" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                     <div class="input-group">
                         <div class="col-sm-2 text-right">
                             <asp:Label ID="lblProgramName" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Form Name"></asp:Label>
                         </div>
                         <div class="col-sm-8">
                            <asp:TextBox ID="txtProgramName" runat="server" class="form-control" type="Text" required="required"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"></div>
                     </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblSubject" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Subject"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSubject" runat="server" class="form-control" type="Text"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblModule" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Module"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlModule" name="ddlModule" runat="server" class="form-control1" AutoPostBack="true" required="required"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblProgramGroup" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Program Group"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlProgramGroup" name="ddlProgramGroup" runat="server" class="form-control1" AutoPostBack="true" required="required"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblSeverity" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Severity"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlSeverity" name="ddlSeverity" runat="server" class="form-control1" AutoPostBack="true" required="required"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblProjectedDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Projected Date"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtProjectedDate" AutoPostBack="true" AutoComplete="off" ToolTip="Projected Date" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <%--<div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblSeverity" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Severity"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSeverity" name="ddlSeverity" runat="server" class="form-control1"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>--%>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblProblem" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Problem"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <%--<textarea class="content" id="txtDesc"></textarea>--%>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Class="form-control content" rows="10"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblCause" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Cause"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <%--<textarea class="content" id="txtCause"></textarea>--%>
                            <asp:TextBox ID="txtCause" runat="server" TextMode="MultiLine" Class="form-control content" rows="10"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblHowtoCheck" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="How to Check"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtHowtoCheck" runat="server" class="form-control content" type="Text"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblCurrentSol" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Current Solution"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCurrentSol" runat="server" class="form-control content" type="Text"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lblLongTermSol" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Long Term Solution"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtLongTermSol" runat="server" class="form-control content" type="Text"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <%--<div class="col-xs-12">
                    <div class="input-group">
                        <asp:Label ID="lbErrType" runat="server" class="col-sm-2 control-label" Text="Error Type"></asp:Label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlErrType" runat="server"  class="form-control1"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>--%>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="lbInputFile" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Attachment File"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:FileUpload ID="FileUpload" runat="server" />
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-xs-12">
                     <div class="input-group">
                         <div class="col-sm-2 text-right">
                             <asp:Label ID="lbEmail" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="E-Mail"></asp:Label>
                         </div>
                         <div class="col-sm-8">
                             <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="Text" AutoCompleteType="Email" required="required"></asp:TextBox>
                             <br /><asp:Label ID="lblText" runat="server" Text="หากต้องการระบุมากกว่า 1 Email ให้คั่นด้วยเครื่องหมาย Comma (,)"></asp:Label>
                         </div>
                          <div class="col-sm-2"></div>
                     </div>
                </div>
                <div class="col-xs-12">
                     <div class="input-group">
                         <div class="col-sm-2 text-right"></div>
                         <div class="col-sm-3">
                             <asp:CheckBox ID="CheckBoxAfterWork" runat="server" Checked="false" class="form-control1-checkbox" Text="&nbsp;&nbsp;&nbsp;After Work" BorderWidth="0px" />
                         </div>
                         <div class="col-sm-3">
                             <asp:CheckBox ID="CheckBoxHoliday" runat="server" Checked="false" class="form-control1-checkbox" Text="&nbsp;&nbsp;&nbsp;Holiday" BorderWidth="0px" />
                         </div>
                          <div class="col-sm-4"></div>
                     </div>
                </div>
                <div class="col-xs-12">
                    <div class="input-group">
                        <div class="col-sm-4"></div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnSubmit" runat="server" class="btn-primary btn" Text="Submit" />
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="btnCancel" runat="server" class="btn-default btn" Text="Cancel" />
                        </div>
                        <div class="col-sm-4"></div>
                    </div>
                </div>
            </div>
        </div>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtRequestDate" EventName="TextChanged"/>
                <asp:AsyncPostBackTrigger ControlID="ddlSeverity" EventName="SelectedIndexChanged"/>
                <asp:AsyncPostBackTrigger ControlID="ddlCustomer" EventName="SelectedIndexChanged"/>
                <asp:AsyncPostBackTrigger ControlID="ddlRequestor" EventName="SelectedIndexChanged"/>
                <asp:AsyncPostBackTrigger ControlID="ddlModule" EventName="SelectedIndexChanged"/>
                <asp:PostBackTrigger ControlID="txtEmail"/>
                <%--<asp:AsyncPostBackTrigger ControlID="ddlRequestor" EventName="SelectedIndexChanged" />--%>
                <asp:PostBackTrigger ControlID="txtDesc"/>
                <%--<asp:PostBackTrigger ControlID="txtRequestDate"/>--%>
                <asp:PostBackTrigger ControlID="btnSubmit"/>
                <%--<asp:PostBackTrigger ControlID="ddlRequestor"/>
                <asp:PostBackTrigger ControlID="ddlDbSite"/>--%>              
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
