<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="OldCustomerLog.aspx.vb" Inherits="Support.OldCustomerLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.js"></script>


<script type='text/javascript'>
    $(document).ready(function () {

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();

        function EndRequestHandler(sender, args) {
            $("#<%=txtFilterDate.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        }
      
    });



    $(function(){
          <%--var FilterStat = '<%=ddlFilterStat.ClientID%>';
          $('#' + FilterStat).val('0');--%>
        $("#<%=ddlFilterStat.ClientID%>").val('0');
    });

    $(function(){
          <%--var FilterType = '<%=ddlFilterType.ClientID%>';
          $('#' + FilterType).val('0');--%>
        $("#<%=ddlFilterType.ClientID%>").val('0');
    });

    $(function(){
          <%--var FilterRequestor = '<%=ddlFilterRequestor.ClientID%>';
          $('#' + FilterRequestor).val('0');--%>
        $("#<%=ddlFilterRequestor.ClientID%>").val('0');
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div id="wrapper">
    <div class="grid-form">
    <div class="row"> 
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
            <div class="col-xs-8 col-xs-offset-2">
		    <div class="input-group">
                <div class="input-group-btn search-panel">

                    <%--<button type="button" id="btnfilter" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                    	<span id="search_concept">Filter by</span> <span class="caret"></span>
                    </button>

                    <ul class="dropdown-menu" role="menu">
                      <li><a href="?filter=log_id">Log ID</a></li>
                      <li><a href="?filter=subject">Subject</a></li>
                      <li><a href="?filter=all">All</a></li>
                    </ul>--%>

                </div>

                <asp:HiddenField ID="search_param" runat="server" Value="all" />
                <asp:TextBox ID="txtSearch" runat="server" class="form-control"  placeholder="Search by Log ID or Subject"></asp:TextBox>
                <span class="input-group-btn">
                    
                    <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-default" OnClick="btnSearch_Click" CausesValidation="false" ><span class="fa fa-search"></span></asp:LinkButton>
                </span>
            </div>
        </div>

        <div class="col-xs-12">
            <div class="input-group">
                <div class="col-xs-3">
                        
                        <asp:TextBox runat="server" ID="txtFilterDate" AutoPostBack="true" AutoComplete="off" ToolTip="Filter by Submitted Date" placeholder="Submitted Date" CssClass="form-control"></asp:TextBox> 
                     
                </div>

            <div class="col-xs-3">
                  <asp:DropDownList runat="server" ID="ddlFilterStat" ToolTip="Filter by Status" CssClass="form-control"></asp:DropDownList>                                 
            </div>

            <div class="col-xs-3">
                <asp:DropDownList runat="server" ID="ddlFilterType" ToolTip="Filter by Type"  CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-xs-3">
                 <asp:DropDownList runat="server" ID="ddlFilterRequestor" ToolTip="Filter by Requestor"  CssClass="form-control"></asp:DropDownList>
            </div>

        </div>
      </div>

	</div>
    </ContentTemplate>

    </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
            <ContentTemplate>
        <div class="grid-form">
        
                <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-hover" 
                    runat="server" AutoGenerateColumns="false" >
                    <Columns>
                    <asp:TemplateField HeaderText="Status" ItemStyle-Wrap="true">
                        <ItemTemplate>
                            <asp:Label ID="lblstat" CssClass="label label-default label-font" runat="server" Text='<%# Eval("stat") %>' style="text-align:center"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Log ID" ItemStyle-Wrap="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkLogID" OnClick="Display" runat="server"  ToolTip="Click to view details" Text='<%# Eval("log_id") %>'></asp:LinkButton>                  
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:BoundField HeaderText="Subject" DataField="subject" ReadOnly="true" ItemStyle-Wrap="true" />
                     <asp:BoundField HeaderText="Type" DataField="type" ReadOnly="true" ItemStyle-Wrap="true" />
                     <asp:BoundField HeaderText="Request Date" DataField="end_date" ReadOnly="true" ItemStyle-Wrap="true" />
                     <asp:BoundField HeaderText="Requestor" DataField="req" ReadOnly="true" ItemStyle-Wrap="true" />
                     <asp:TemplateField HeaderText="Change Status Log" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <%--<asp:Button ID="bntUpdate" runat="server" Text="Update" class="btn btn-warning btn-sm"  />--%>
                             <asp:Button ID="bntUpdate" runat="server" Text="Change" CssClass="btn btn-warning btn-sm"
                              OnClick="btnUpdate_Click" CommandName="DelvDet" CommandArgument='<%# Eval("log_id") %>' 
                              Enabled='<%# VisibleButtonUpdate(Eval("stat")) %>'/>
                                 <%--OnClientClick="javascript:window.open('UpdateSupportLog.aspx?LogID=<%# Eval("log_id") %>')"/>--%>
                         </ItemTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="Log ID" ItemStyle-Wrap="true">
                        <ItemTemplate>
                            <asp:Label ID="lbllogid" runat="server" Text='<%# Eval("log_id") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="hidden" />
                         <ItemStyle CssClass="hidden" />
                    </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="GridView1" />
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
                        <asp:Label ID="Label1" CssClass="lebel-text" runat="server" Text="Mail Subject :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblSubjectDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label2" CssClass="lebel-text" runat="server" Text="Log ID :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblLodIdDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label3" CssClass="lebel-text" runat="server" Text="Requestor :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblReqDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label4" CssClass="lebel-text" runat="server" Text="Request Date :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblReqDateDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label5" CssClass="lebel-text" runat="server" Text="Error Type :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblErrorTypeDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label6" CssClass="lebel-text" runat="server" Text="Form/Report Name :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblFormDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label7" CssClass="lebel-text" runat="server" Text="Module :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblModuleDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label8" CssClass="lebel-text" runat="server" Text="Problem :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblProblemDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label9" CssClass="lebel-text" runat="server" Text="Cause :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblCauseDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label10" CssClass="lebel-text" runat="server" Text="Solution :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblSolutionDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label11" CssClass="lebel-text" runat="server" Text="Remark :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblRemarkDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:160px; vertical-align:top;">
                        <asp:Label ID="Label12" CssClass="lebel-text" runat="server" Text="Submitted Date :"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblEndDateDet" CssClass="lebel-text" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width:100%">
                <asp:Repeater ID="RepeaterReplyModel" runat="server">
                    <HeaderTemplate>
                        <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:left; width:160px; vertical-align:top;">
                                <asp:Label ID="lblReply" CssClass="lebel-text" runat="server" Text="">
                                    &nbsp; &nbsp;<i><%#Container.DataItem("username") %>- <%#Container.DataItem("reply_date") %>: </i>
                                    <%#Container.DataItem("reply") %>
                                </asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="modal-footer">
            <%--<a href="#" data-dismiss="modal" onclick="javascript:window.location='/ReplyLog.aspx'">
                <asp:Button ID="btnReply" runat="server" Text="Reply" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("log_id") %>' OnClick="btnUpdate_Click" />
            </a>--%>
            <asp:Button ID="btnReply" runat="server" Text="Reply" class="btn btn-success btn-sm" OnClick="btnReply_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn btn-default btn-sm" data-dismiss="modal" />
        </div>
      </div>
      
    </div>
  </div>
</div>

        
    </div>
    </div>
    </div>


<%--    <div id="normalModal" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title">Modal title</h4>
      </div>
      <div class="modal-body">
        XXX
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->--%>

</asp:Content>
