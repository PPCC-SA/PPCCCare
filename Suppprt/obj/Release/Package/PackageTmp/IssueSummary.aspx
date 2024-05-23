<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="IssueSummary.aspx.vb" Inherits="Support.IssueSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%--<script type="text/javascript">
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
    </script>--%>

    <script type='text/javascript'>
        function openModal() {
            $('[id*=myModal]').modal('show');
        } 
    </script>
    
    <style type="text/css">
       .hide { display: none; }

       .lebel-text {
          /*font-family: 'Cloud-Light';*/
           font-weight: normal;
           font-size:1rem;
       }

       .input_user,
       .input_user:focus {
            box-shadow: none !important;
            outline: 0px !important;
            border-radius: 1.5rem 1.5rem 1.5rem 1.5rem !important;
        }

       .button,
       .button:hover {
            background-color: #0047BB;
            color: #fff;
            border-radius: 25px;
        }

    </style> 
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

                        <div class="form-row d-flex justify-content-center">
                            <div class="form-group col-md-5">
                                <label for="ddlStartCust">Starting Customer</label>
                                <asp:DropDownList ID="ddlStartCust" AutoPostBack="true" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-5">
                                <label for="ddlEndCust">Ending Customer</label>
                                <asp:DropDownList ID="ddlEndCust" AutoPostBack="true" runat="server" class="form-control input_user"></asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-row d-flex justify-content-center">
                            <div class="form-group col-md-5">
                                <label for="ddlStartCust">Starting Request Date</label>
                                <asp:TextBox runat="server" ID="txtStartReqDate" AutoComplete="off" ToolTip="Filter by Request Date" placeholder="Start Request Date" CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-5">
                                <label for="ddlStartCust">Ending Request Date</label>
                                <asp:TextBox runat="server" ID="txtEndReqDate" AutoComplete="off" ToolTip="Filter by Request Date" placeholder="End Request Date" CssClass="form-control input_user datepicker"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group d-flex justify-content-center">
                            <div class="form-check col-md-10">
                                    <asp:CheckBox ID="CheckBox1" CssClass="form-check-input" runat="server" Text="&nbsp;Case&nbsp;ที่ยังไม่ทราบสาเหตุ" />
                                    <label class="form-check-label lebel-text" for="CheckBox1"></label>
                            </div>
                        </div>

                        <div class="d-flex justify-content-center">
                            <div class="form-row">
                                <asp:Button ID="bntLoad" runat="server"  CssClass="btn button" Text="Download Excel" />
                            </div>
                        </div>

            </ContentTemplate>
            <Triggers>
                        
                <asp:AsyncPostBackTrigger ControlID="ddlStartCust" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlEndCust" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="bntLoad"/>

            </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
 </div>

</asp:Content>
