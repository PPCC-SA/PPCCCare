<%@ Page Title="Generate Customer Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="CustomerLogDetail.aspx.vb" Inherits="Support.CustomerLogDetail" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%--<script type='text/javascript'>
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

    </script>--%>

    <style type="text/css">
       .hide { display: none; }

       .lebel-text {
           /*font-family: 'Cloud-Light';
           color: #000000;*/
           font-weight: normal;
           font-size: 0.9rem;
       }

        .button,
        .button:hover {
            background-color: #0047BB;
            color: #fff;
            border-radius: 25px;
        }

        .button_cancel,
        .button_cancel:hover {
            background-color: #fff;
            color: #0047BB;
            border-color: #0047BB;
            border-radius: 25px;
        }

       .input_user,
       .input_user:focus {
            box-shadow: none !important;
            outline: 0px !important;
            border-radius: 1.5rem 1.5rem 1.5rem 1.5rem !important;
        }

    </style>

    <script>

        function ShowSweetAlert(type, msg, icon) {
            Swal.fire(
                type,
                msg,
                icon
            )

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="content-wrapper" class="d-flex flex-column">
    <div id="content">
    <%--<div class="container-fluid">--%>
        <div class="card shadow mb-4">
            <div class="card-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                
                        <div class="form-row">
                            <div class="form-group col-md-2">
                                <label for="txtLogID">Log ID</label>
                                <asp:TextBox ID="txtLogID" runat="server" class="form-control input_user" disabled="True" Text="?"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-5">
                                <label for="ddlCustomer">Customer</label>
                                <asp:DropDownList ID="ddlCustomer" runat="server" class="form-control input_user" AutoPostBack="true" required="required"></asp:DropDownList>
                            </div>
                            <%--<div class="form-group col-md-2">
                                <label for="ddlDbSite">Database Site</label>
                                <asp:DropDownList ID="ddlDbSite" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>--%>
                            <div class="form-group col-md-3">
                                <label for="ddlRequestor">Requestor</label>
                                <asp:DropDownList ID="ddlRequestor" runat="server" class="form-control input_user" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="ddlStat">Status</label>
                                <asp:DropDownList ID="ddlStat" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-3">
                                <label for="ddlStat">Status</label>
                                <asp:DropDownList ID="ddlStat" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>--%>
                            <%--<div class="form-group col-md-3">
                                <label for="ddlInfProblem">Infrom Problem</label>
                                 <asp:DropDownList ID="ddlInfProblem" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>--%>
                            <div class="form-group col-md-3">
                                <label for="txtRequestDate">Request Date</label>
                                <asp:TextBox runat="server" ID="txtRequestDate" AutoComplete="off" required="required" CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-3">
                                 <label for="ddlRequestTime">Request Time</label>
                                 <asp:DropDownList runat="server" ID="ddlRequestTime" class="form-control input_user"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="ddlSeverity">Severity</label>
                                <asp:DropDownList ID="ddlSeverity" runat="server" class="form-control input_user" AutoPostBack="true" required="required"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="txtProjectedDate">Projected Date</label>
                                <asp:TextBox runat="server" ID="txtProjectedDate" AutoComplete="off" ToolTip="Projected Date" CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>
                            
                        </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-6">
                                <label for="ddlAcknowledge">Acknowledge By</label>
                                <asp:DropDownList ID="ddlAcknowledge" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>--%>
                            <%--<div class="form-group col-md-3">
                                <label for="txtResponseDate">Acknowledge Date</label>
                                <asp:TextBox runat="server" ID="txtResponseDate" AutoComplete="off"  CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>--%>
                            <%--<div class="form-group col-md-3">
                                <label for="ddlResponseTime">Acknowledge Time</label>
                                <asp:DropDownList runat="server" ID="ddlResponseTime" class="form-control input_user"></asp:DropDownList>
                            </div>--%>
                            
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtProgramName">Form Name</label>
                                <asp:TextBox ID="txtProgramName" runat="server" class="form-control input_user" required="required"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtSubject">Subject</label>
                                <asp:TextBox ID="txtSubject" runat="server" class="form-control input_user"></asp:TextBox>
                            </div>
                        </div>

                        <%--<div class="form-row">--%>
                            <%--<div class="form-group col-md-3">
                                <label for="ddlModule">Module</label>
                                <asp:DropDownList ID="ddlModule" runat="server" class="form-control input_user" AutoPostBack="true" required="required"></asp:DropDownList>
                            </div>--%>
                            <%--<div class="form-group col-md-3">
                                <label for="ddlProgramGroup">Program Group</label>
                                <asp:DropDownList ID="ddlProgramGroup" runat="server" class="form-control input_user" AutoPostBack="true" required="required"></asp:DropDownList>
                            </div>--%>
                            <%--<div class="form-group col-md-3">
                                <label for="ddlSeverity">Severity</label>
                                <asp:DropDownList ID="ddlSeverity" runat="server" class="form-control input_user" AutoPostBack="true" required="required"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="txtProjectedDate">Projected Date</label>
                                <asp:TextBox runat="server" ID="txtProjectedDate" AutoComplete="off" ToolTip="Projected Date" CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>--%>
                        <%--</div>--%>

                         <div class="form-row">
                             <div class="form-group col-md-12">
                                 <label for="txtDesc">Problem</label>
                                 <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                             </div>
                         </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-12">
                                <label for="txtCause">Cause</label>
                                <asp:TextBox ID="txtCause" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                            </div>--%>
                        </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-12">
                                <label for="txtHowtoCheck">How to Check</label>
                                <asp:TextBox ID="txtHowtoCheck" runat="server" class="form-control input_user"></asp:TextBox>
                            </div>--%>
                        </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-12">
                                <label for="txtCurrentSol">Current Solution</label>
                                <asp:TextBox ID="txtCurrentSol" runat="server" class="form-control input_user" ></asp:TextBox>
                            </div>--%>
                        </div>

                        <div class="form-row">
                            <%--<div class="form-group col-md-12">
                                <label for="txtLongTermSol">Long Term Solution</label>
                                <asp:TextBox ID="txtLongTermSol" runat="server" class="form-control input_user"></asp:TextBox>
                            </div>--%>
                        </div>

                        <div class="form-row">
                             <div class="form-group col-md-12">
                                 <label for="txtEmail">E-Mail (หากต้องการระบุมากกว่า 1 Email ให้คั่นด้วยเครื่องหมาย Comma (,))</label>
                                 <asp:TextBox ID="txtEmail" runat="server" class="form-control input_user" AutoCompleteType="Email" required="required"></asp:TextBox>
                             </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="custom-file">
                                    <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control-file" />
                                </div>


                                 <%--<label for="FileUpload"></label>
                                <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control-file" />--%>
                            </div>
                        </div>

                        <%--<div class="form-group d-flex justify-content-center">
                            <div class="form-check col-md-3">
                                <asp:CheckBox ID="CheckBoxAfterWork" runat="server" Checked="false" class="form-check-input" Text="&nbsp;After Work" />
                                <label class="form-check-label lebel-text" for="CheckBoxAfterWork"></label>

                            </div>
                            <div class="form-check col-md-3">
                                <asp:CheckBox ID="CheckBoxHoliday" runat="server" Checked="false" class="form-check-input" Text="&nbsp;Holiday" />
                                <label class="form-check-label lebel-text" for="CheckBoxHoliday"></label>

                            </div>
                        </div>--%>

                        <div class="d-flex justify-content-center">
                            <div class="form-row">
                                <div class="form-group col-md-12 justify-content-center">
                                    <asp:Button ID="btnSubmit" runat="server" class="btn button" Text="Submit" />
                                    &nbsp; &nbsp; 
                                    <asp:Button ID="btnCancel" runat="server" class="btn button_cancel" Text="Cancel" UseSubmitBehavior="False" />
                                </div>
                            </div>
                        </div>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSeverity" EventName="SelectedIndexChanged"/>
                        <asp:AsyncPostBackTrigger ControlID="ddlCustomer" EventName="SelectedIndexChanged"/>
                        <asp:AsyncPostBackTrigger ControlID="ddlRequestor" EventName="SelectedIndexChanged"/>
                        <%--<asp:AsyncPostBackTrigger ControlID="ddlModule" EventName="SelectedIndexChanged"/>--%>
                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />            
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
    
        

</asp:Content>