<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="OldSupportLogReport.aspx.vb" Inherits="Support.OldSupportLogReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var Start = $('#<%=txtStartReqDate.ClientID%>');
            var End = $('#<%=txtEndReqDate.ClientID%>');
            Start.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });

            End.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
    </script>

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
           font-size:medium;
       }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <br />
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="input-group">
                            <div class="col-xs-2 text-right">
                                <asp:Label ID="lblCustomer" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Customer"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="ddlStartCust" AutoPostBack="true" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="ddlEndCust" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-4">
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="input-group">
                            <div class="col-xs-2 text-right">
                                <asp:Label ID="lblLogDate" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Request Date"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox runat="server" ID="txtStartReqDate" AutoPostBack="true" AutoComplete="off" ToolTip="Filter by Request Date" placeholder="Start Request Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox runat="server" ID="txtEndReqDate" AutoComplete="off" ToolTip="Filter by Request Date" placeholder="End Request Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-xs-12">
                        <div class="input-group">
                            <div class="col-xs-2 text-right">
                                <asp:Label ID="lblStatus" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Status"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="ddlStartStat" AutoPostBack="true" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="ddlEndStat" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-4">
                            </div>
                        </div>
                    </div>--%>
                    <div class="col-xs-12">
                        <div class="input-group">
                            <div class="col-xs-2 text-right">
                                <asp:Label ID="lblStatusCheckBox" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Status"></asp:Label>
                            </div>
                            <div class="col-xs-2">
                                <asp:CheckBox ID="CheckBoxOpen" runat="server" Checked="true" Text="Open" class="form-control" BorderWidth="0px" />
                            </div>
                            <div class="col-xs-2">
                                <asp:CheckBox ID="CheckBoxInprocess" runat="server" Checked="true" Text="Inprocess" class="form-control" BorderWidth="0px" />
                            </div>
                            <div class="col-xs-2">
                                <asp:CheckBox ID="CheckBoxClose" runat="server" Checked="true" Text="Close" class="form-control" BorderWidth="0px" />
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12">
                        <div class="input-group">
                            <div class="col-xs-3">
                            </div>
                            <div class="col-xs-4">
                                <br />
                                <label class="login-do hvr-shutter-in-horizontal login-sub">
                                    <asp:Button ID="bntLoad" runat="server" Text="Download Excel" />
                                </label>
                            </div>
                            <div class="col-xs-5">
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ddlStartCust"/>
                <%--<asp:AsyncPostBackTrigger ControlID="ddlStartCust" EventName="SelectedIndexChanged" />--%>
                <%--<asp:PostBackTrigger ControlID="txtStartReqDate" />--%>
                <%--<asp:PostBackTrigger ControlID="ddlStartStat" />--%>
                <%--<asp:AsyncPostBackTrigger ControlID="bntLoad" EventName="Click" />--%>
                <asp:PostBackTrigger ControlID="bntLoad"/>
            </Triggers>
        </asp:UpdatePanel>
        <div class="col-xs-12">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
