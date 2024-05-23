<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OldSupport.Master" CodeBehind="OldUpdateSupportLog.aspx.vb" Inherits="Support.OldUpdateSupportLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/richtext.min.css" rel="stylesheet" />
    <script src="js/jquery.richtext.min.js"></script>
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>   

    <%--<script>
        $(document).ready(function() {
            $('.content').richText();
        });
    </script>--%>

    <style type="text/css">
        .Notify { margin-left: -18px; }
    </style>

    <script type='text/javascript'>
        function openModal() {
            $('[id*=myModal]').modal('show');
        } 
    </script>

    <style type="text/css">
       .hide { display: none; }

       .lebel-text {
           font-family: 'Cloud-Light';
           color: #000000;
           font-weight: normal;
           font-size: medium;
       }
    </style>
    <script type='text/javascript'>
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

        $(document).ready(function () {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();

            function EndRequestHandler(sender, args) {
                $("#<%=txtClosedDate.ClientID%>").datepicker({
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
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
                </div>
                <div class="grid-form">
                    <div class="form-horizontal">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblLogID" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Log ID"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtLogID" runat="server" class="form-control" type="text" AutoPostBack="true" disabled="True"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblStatus" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Status"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlStat" runat="server" class="form-control1"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblCustomer" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Customer"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlCustomer" runat="server" class="form-control1" AutoPostBack="true"></asp:DropDownList>
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
                                    <asp:TextBox ID="txtSubject" runat="server" class="form-control" type="Text" disabled="True"></asp:TextBox>
                                </div>
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right"></div>
                                <div class="col-sm-8">
                                    <asp:LinkButton ID="lnkDetails" runat="server"  ToolTip="Click to view details" Text="View Details" OnClick="Display"></asp:LinkButton>
                                </div>
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblProblems" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Problem"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtProblems" runat="server" TextMode="MultiLine" Class="form-control content" rows="6"></asp:TextBox>
                                </div>
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblCause" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Cause"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtCause" runat="server" TextMode="MultiLine" Class="form-control content" rows="6"></asp:TextBox>
                                </div>
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblSolution" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Solution"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" Class="form-control content" rows="6"></asp:TextBox>
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
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblErrorType" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Error Type"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlErrorType" runat="server" class="form-control1" required="required"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblResponsible" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Responsible"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlResponsible" runat="server" class="form-control1" required="required"></asp:DropDownList>
                                </div>                                                               
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblResponseDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Acknowledge Date"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:TextBox runat="server" ID="txtResponseDate" AutoPostBack="true" AutoComplete="off" CssClass="form-control"></asp:TextBox> 
                                </div>      
                                <div class="col-sm-1 text-right">
                                    <asp:Label ID="lblResponseTime" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Time"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList runat="server" ID="ddlResponseTime" class="form-control1"></asp:DropDownList>
                                </div>            
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblClosedBy" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Closed By"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlClosedBy" runat="server" class="form-control1" required="required"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-2 text-right">
                                    <asp:Label ID="lblClosedDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Closed Date"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:TextBox runat="server" ID="txtClosedDate" AutoPostBack="true" AutoComplete="off" required="required" CssClass="form-control"></asp:TextBox> 
                                </div>      
                                <div class="col-sm-1 text-right">
                                    <asp:Label ID="lblClosedTime" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Time"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList runat="server" ID="ddlClosedTime" class="form-control1"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-4"></div>
                                <div class="col-sm-4" >
                                    <br />
                                    <asp:Button ID="btnSubmit" runat="server" class="btn-primary btn" Text="Submit" />
                                    &nbsp; &nbsp; 
                                    <asp:Button ID="btnCancel" runat="server" class="btn-default btn" Text="Cancel" />
                                </div>
                                <div class="col-sm-4"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="txtLogID"/>
                <asp:PostBackTrigger ControlID="lnkDetails"/>
                <asp:PostBackTrigger ControlID="btnSubmit"/>
            </Triggers>
        </asp:UpdatePanel>
        <!-- Modal -->
        <div class="container">
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4>&nbsp;Detail</h4>
                        </div>

                        <div class="modal-body">
                            <table style="width:100%">
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblLogId1" CssClass="lebel-text" runat="server" Text="Log ID :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblLogId" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblCust" CssClass="lebel-text" runat="server" Text="Customer :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblCust" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblRequestor" CssClass="lebel-text" runat="server" Text="Requestor :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblRequestor" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblReqDate" CssClass="lebel-text" runat="server" Text="Request Date :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblReqDate" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblFormName" CssClass="lebel-text" runat="server" Text="Form/Report Name :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblFormName" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblDbSite" CssClass="lebel-text" runat="server" Text="Site :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblDbSite" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblProblem" CssClass="lebel-text" runat="server" Text="Problem :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblProblem" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblCauses" CssClass="lebel-text" runat="server" Text="Cause :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblCauses" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblSolutions" CssClass="lebel-text" runat="server" Text="Solution :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblSolutions" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblResponseBy" CssClass="lebel-text" runat="server" Text="Response By :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblResponseBy" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblCloseDate" CssClass="lebel-text" runat="server" Text="Closed Date :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblCloseDate" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:160px; vertical-align:top;">
                                        <asp:Label ID="lblCloseBy" CssClass="lebel-text" runat="server" Text="Closed By :"></asp:Label>
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:Label ID="slblCloseBy" CssClass="lebel-text" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Button1" runat="server" Text="Close" class="btn btn-default btn-sm" data-dismiss="modal" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
