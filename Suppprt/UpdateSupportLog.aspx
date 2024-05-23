<%@ Page Title="Update Support Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="UpdateSupportLog.aspx.vb" Inherits="Support.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

     <script type='text/javascript'>
        function openModal(LogId, Cust, Requestor, ReqDate, FormName, DbSite, Problem, Causes, Solutions, ResponseBy, CloseDate, CloseBy) {
                document.getElementById("LogId").innerHTML = LogId;
                document.getElementById("Cust").innerHTML = Cust;
                document.getElementById("Requestor").innerHTML = Requestor;
                document.getElementById("ReqDate").innerHTML = ReqDate;
                document.getElementById("FormName").innerHTML = FormName;
                document.getElementById("DbSite").innerHTML = DbSite;
                document.getElementById("Problem").innerHTML = Problem;
                document.getElementById("Causes").innerHTML = Causes;
                document.getElementById("Solutions").innerHTML = Solutions;
                document.getElementById("ResponseBy").innerHTML = ResponseBy;
                document.getElementById("CloseDate").innerHTML = CloseDate;
                document.getElementById("CloseBy").innerHTML = CloseBy;

                $('#myModal').modal('show');
            //$('[id*=myModal]').modal('show');
        } 
    </script>

    <style type="text/css">
       .hide { display: none; }

       .lebel-text {
           /*font-family: 'Cloud-Light';*/
           color: #000000;
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

       .reply-text {
           font-weight: normal;
           font-size:0.8rem;
       }

        .row{
            margin-bottom: 0px;
        }

        p{
            margin-bottom: 0px;
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

    <script>

        function ShowSweetAlertBack(type, msg, icon) {
            Swal.fire(
                type,
                msg,
                icon
            ).then((result) => {  
 
                if (result.value) {
                    window.location = "CustomerLog.aspx";
 	            }
            });                  

        }

    </script>
    <%--<script type='text/javascript'>
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

    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-wrapper" class="d-flex flex-column">
        <div id="content">
        <%--<div class="container-fluid">--%>
            <div class="card shadow mb-4">
                <div class="card-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="form-group col-md-3">
                                    <label for="txtLogID">Log ID</label>
                                    <asp:TextBox ID="txtLogID" runat="server" class="form-control input_user" type="text" AutoPostBack="true" disabled="True"></asp:TextBox>
                                </div>                                 
                                <div class="form-group col-md-6">
                                    <label for="ddlCustomer">Customer</label>
                                    <asp:DropDownList ID="ddlCustomer" runat="server" class="form-control input_user" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-3">
                                     <label for="ddlStat">Status</label>
                                     <asp:DropDownList ID="ddlStat" runat="server" class="form-control input_user"></asp:DropDownList>
                                     <asp:HiddenField ID="HiddenStat" runat="server" />
                                 </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-9">
                                    <label for="txtSubject">Subject</label>
                                    <asp:TextBox ID="txtSubject" runat="server" class="form-control input_user" type="Text" disabled="True"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="ddlErrorType">Error Type</label>
                                    <asp:DropDownList ID="ddlErrorType" runat="server" class="form-control input_user" required="required"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-5">
                                    <label for="ddlResponsible">Responsible</label>
                                    <asp:DropDownList ID="ddlResponsible" runat="server" class="form-control input_user" required="required"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-4">
                                     <label for="txtResponseDate">Acknowledge Date</label>
                                     <asp:TextBox runat="server" ID="txtResponseDate" AutoComplete="off" CssClass="form-control input_user datepicker"></asp:TextBox> 
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="ddlResponseTime">Acknowledge Time</label>
                                    <asp:DropDownList runat="server" ID="ddlResponseTime" class="form-control input_user"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-5">
                                    <label for="ddlClosedBy">Closed By</label>
                                    <asp:DropDownList ID="ddlClosedBy" runat="server" class="form-control input_user" required="required"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="txtClosedDate">Closed Date</label>
                                    <asp:TextBox runat="server" ID="txtClosedDate" AutoComplete="off" required="required" CssClass="form-control input_user datepicker"></asp:TextBox> 
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="ddlClosedTime">Closed Time</label>
                                    <asp:DropDownList runat="server" ID="ddlClosedTime" class="form-control input_user"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label for="txtProblems">Problem</label>
                                     <asp:TextBox ID="txtProblems" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label for="txtCause">Cause</label>
                                    <asp:TextBox ID="txtCause" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                 <div class="form-group col-md-12">
                                     <label for="txtSolution">Solution</label>
                                     <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                                 </div>
                            </div>

                            <div class="form-row">
                                 <div class="form-group col-md-12">
                                     <label for="txtHowtoCheck">How to Check</label>
                                     <asp:TextBox ID="txtHowtoCheck" runat="server" class="form-control input_user"></asp:TextBox>
                                 </div>
                            </div>

                             <div class="form-row">
                                 <div class="form-group col-md-12">
                                     <label for="txtCurrentSol">Current Solution</label>
                                     <asp:TextBox ID="txtCurrentSol" runat="server" class="form-control input_user"></asp:TextBox>
                                 </div>
                             </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label for="txtLongTermSol">Long Term Solution</label>
                                    <asp:TextBox ID="txtLongTermSol" runat="server" class="form-control input_user"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <asp:LinkButton ID="lnkDetails" runat="server"  ToolTip="Click to view details" Text="View Details" OnClick="Display"></asp:LinkButton>
                                </div>
                            </div>

                            <div class="d-flex justify-content-center">
                                <div class="form-row">
                                    <div class="form-group col-md-12 justify-content-center">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn button" Text="Submit" />
                                        &nbsp;&nbsp; 
                                        <asp:Button ID="btnCancel" runat="server" class="btn button_cancel" Text="Cancel" UseSubmitBehavior="False" />
                                         <asp:Button ID="Button2" runat="server" class="btn button" Text="test" UseSubmitBehavior="False" />
                                    </div>
                                </div>
                            </div>

                            

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <!-- Modal -->
                    <div class="container">
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">                                        
                                        <h4>&nbsp;Detail</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <div class="modal-body">
                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Log ID :</p>
                                            <div class="col-sm-8">
                                                <p id="LogId" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Customer :</p>
                                            <div class="col-sm-8">
                                                <p id="Cust" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Requestor :</p>
                                             <div class="col-sm-8">
                                                <p id="Requestor" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Request Date :</p>
                                             <div class="col-sm-8">
                                                <p id="ReqDate" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Form/Report Name :</p>
                                             <div class="col-sm-8">
                                                <p id="FormName" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Site :</p>
                                             <div class="col-sm-8">
                                                <p id="DbSite" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Problem :</p>
                                             <div class="col-sm-8">
                                                <p id="Problem" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Cause :</p>
                                             <div class="col-sm-8">
                                                <p id="Causes" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Solution :</p>
                                             <div class="col-sm-8">
                                                <p id="Solutions" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Response By :</p>
                                             <div class="col-sm-8">
                                                <p id="ResponseBy" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Closed Date :</p>
                                             <div class="col-sm-8">
                                                <p id="CloseDate" class="lebel-text"></p>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <p class="col-sm-4 lebel-text">Closed By :</p>
                                             <div class="col-sm-8">
                                                <p id="CloseBy" class="lebel-text"></p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="Button1" runat="server" Text="Close" class="btn button btn-sm" data-dismiss="modal" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        
</asp:Content>
