<%@ Page Title="Customer Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="CustomerLog.aspx.vb" Inherits="Support.CustomerLog" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type='text/javascript'>
          

        $(document).ready(function(){

            $("#<%=ddlFilterStat.ClientID%>").val('0');

        });

        $(document).ready(function(){

            $("#<%=ddlFilterType.ClientID%>").val('0');
        });

        $(document).ready(function(){

            $("#<%=ddlFilterRequestor.ClientID%>").val('0');
        });

    </script>

    <script type='text/javascript'>
        function openModal(SubjectDet, LodIdDet, ReqDet, ReqDateDet, ErrorTypeDet, FormDet, ModuleDet, ProblemDet, CauseDet, SolutionDet, RemarkDet, EndDateDet, Reply) {
          //  document.getElementById("xxx").value = "My Value";

            //    $('#SubjectDet').html(SubjectDet)
            //    $('#LodIdDet').html(LodIdDet)
            //    $('#ReqDet').html(ReqDet)
            //    $('#ReqDateDet').html(ReqDateDet)
            //    $('#ErrorTypeDet').html(ErrorTypeDet)
            //    $('#FormDet').html(FormDet)
            //    $('#ModuleDet').html(ModuleDet)
            //    $('#ProblemDet').html(ProblemDet)
            //    $('#CauseDet').html(CauseDet)
            //    $('#SolutionDet').html(SolutionDet)
            //    $('#RemarkDet').html(RemarkDet)
            //    $('#EndDateDet').html(EndDateDet)
                document.getElementById("SubjectDet").innerHTML = SubjectDet;
                document.getElementById("LodIdDet").innerHTML = LodIdDet;
                document.getElementById("ReqDet").innerHTML = ReqDet;
                document.getElementById("ReqDateDet").innerHTML = ReqDateDet;
                document.getElementById("ErrorTypeDet").innerHTML = ErrorTypeDet;
                document.getElementById("FormDet").innerHTML = FormDet;
                document.getElementById("ModuleDet").innerHTML = ModuleDet;
                document.getElementById("ProblemDet").innerHTML = ProblemDet;
                document.getElementById("CauseDet").innerHTML = CauseDet;
                document.getElementById("SolutionDet").innerHTML = SolutionDet;
                document.getElementById("EndDateDet").innerHTML = EndDateDet;
                document.getElementById("RemarkDet").innerHTML = RemarkDet;
                document.getElementById("Reply").innerHTML = Reply;

                if (Reply !== "") {
                    var element = document.getElementById("ReplyBlog");
                    element.classList.remove("hide");
                }

                //$('#myModal').modal('show');
                $('#myModal').modal({
                    backdrop: 'static',
                    keyboard: true,
                    show: true
                });
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

       .input_search,
       .input_search:hover {
            box-shadow: none !important;
            outline: 0px !important;
            border-radius: 1.5rem 0rem 0rem 1.5rem !important;
        }

       .button_search,
       .button_search:hover {
            background-color: #0047BB;
            color: #fff;
            box-shadow: none !important;
            outline: 0px !important;
            border-radius: 0rem 1.5rem 1.5rem 0rem !important;
        }

        .buttonchange_enabled,
        .buttonchange_enabled:hover {
            background-color: #fff;
            color: #e5e5e5;
            border-color: #e5e5e5;
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div id="content-wrapper" class="d-flex flex-column">
        <div id="content">
            <%--<div class="container-fluid">--%>
                <div class="card shadow mb-4">
                     <div class="card-body">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                             <ContentTemplate>
                        <asp:HiddenField ID="search_param" runat="server" Value="all" />

                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control input_search"  placeholder="Search by Log ID or Subject"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:LinkButton runat="server" ID="btnSearch"  CssClass="btn button_search" OnClick="btnSearch_Click"   >
                                            <span class="fa fa-search"></span>

                                        </asp:LinkButton>
                                        
                               
                                    </div>
                                </div>
                            </div>


                            <div class="form-row mb-3">
                                <div class="form-group col-md-3">
                                    <asp:TextBox runat="server" ID="txtFilterDate" AutoComplete="off" ToolTip="Filter by Submitted Date" placeholder="Submitted Date" CssClass="form-control input_user datepicker"></asp:TextBox>                     
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:DropDownList runat="server" ID="ddlFilterStat" ToolTip="Filter by Status" CssClass="form-control input_user"></asp:DropDownList>                                 
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:DropDownList runat="server" ID="ddlFilterType" ToolTip="Filter by Type"  CssClass="form-control input_user"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:DropDownList runat="server" ID="ddlFilterRequestor" ToolTip="Filter by Requestor"  CssClass="form-control input_user"></asp:DropDownList>
                                </div>
                                
                            </div>
                           

                            <%--<div class="input-group mb-3">
                            
                                
                                &nbsp; &nbsp;
                                
                                &nbsp; &nbsp;
                                
                                &nbsp; &nbsp;
                                                           

                            </div>--%>
                    </ContentTemplate>
                             <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                           <%--<asp:AsyncPostBackTrigger ControlID="txtFilterDate" EventName="TextChanged" />--%>
                       </Triggers>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                       <ContentTemplate>

                           <div class="table-responsive">

                                   <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped" 
                                        runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                        <asp:TemplateField HeaderText="Log ID<br />Status" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkLogID" OnClick="Display" runat="server" ToolTip="Click to view details" Text='<%# Eval("log_id") %>'></asp:LinkButton>
                                                <br /><asp:Label ID="lblstat" CssClass="badge badge-dark text-wrap" runat="server" Text='<%# Eval("stat") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Type<br />Subject" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                  <asp:Label ID="lbltype" runat="server" Text='<%# Eval("type") %>'></asp:Label>   
                                                  <br /><asp:Label ID="lblsubject" runat="server" Text='<%# Eval("subject") %>'></asp:Label>                
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Request Date<br />Requestor" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                  <asp:Label ID="lblReqDate" runat="server" Text='<%# Eval("end_date") %>'></asp:Label>   
                                                  <br /><asp:Label ID="lblRequestor" runat="server" Text='<%# Eval("req") %>'></asp:Label>                
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <%--<asp:BoundField HeaderText="Type<br />Subject" DataField="subject" ReadOnly="true" ItemStyle-Wrap="true" />--%>
                                         <%--<asp:BoundField HeaderText="Type" DataField="type" ReadOnly="true" ItemStyle-Wrap="true" />--%>
                                         <%--<asp:BoundField HeaderText="Request Date" DataField="end_date" ReadOnly="true" ItemStyle-Wrap="true" />--%>
                                         <%--<asp:BoundField HeaderText="Requestor" DataField="req" ReadOnly="true" ItemStyle-Wrap="true" />--%>
                                         <asp:TemplateField HeaderText="Change Status Log" ItemStyle-HorizontalAlign="Center">
                                             <ItemTemplate>                                                 
                                                     <%--<asp:Button ID="bntUpdate" runat="server" Text="Edit" CssClass="btn btn-warning btn-circle font-size"
                                                      OnClick="btnUpdate_Click" CommandName="DelvDet" CommandArgument='<%# Eval("log_id") %>' 
                                                      Enabled='<%# VisibleButtonUpdate(Eval("stat")) %>'/>--%>

                                                 <asp:LinkButton ID="bntUpdate" runat="server" CssClass="btn btn-warning btn-circle"
                                                      OnClick="btnUpdate_Click" CommandName="DelvDet" CommandArgument='<%# Eval("log_id") %>'
                                                      Enabled='<%# VisibleButtonUpdate(Eval("stat")) %>'>
                                                        <i class="fas fa-edit"></i>
                                                 </asp:LinkButton>
                                                     
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Log ID" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllogid" runat="server" Text='<%# Eval("log_id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="hide" />
                                             <ItemStyle CssClass="hide" />
                                        </asp:TemplateField>

                                        </Columns>
                                       
                                    </asp:GridView>
                                        
                             </div>
                        </ContentTemplate>
                </asp:UpdatePanel> 

                        <!-- Modal -->
                        <div class="container">
                  <div class="modal fade" id="myModal" role="dialog" tabindex="-1" aria-hidden="true">
                    <div class="modal-dialog">
    
                      <!-- Modal content-->
                      <div class="modal-content">
                        <div class="modal-header">
                           
                            <h4>&nbsp;Detail</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>    
                        </div>

                        <div class="modal-body">
                            <div class="form-group row">
                                 <p class="col-sm-4 lebel-text">Mail Subject :</p>
                                <div class="col-sm-8">
                                    <p id="SubjectDet" class="lebel-text"></p>
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Log ID :</p>
                                <div class="col-sm-8">
                                    <p id="LodIdDet" class="lebel-text"></p>
                                    <asp:Label ID="lblLodIdDet" CssClass="lebel-text hide" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Requestor :</p>
                                <div class="col-sm-8">
                                     <p id="ReqDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Request Date :</p>
                                <div class="col-sm-8">
                                     <p id="ReqDateDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Error Type :</p>
                                <div class="col-sm-8">
                                     <p id="ErrorTypeDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Form/Report Name :</p>
                                <div class="col-sm-8">
                                     <p id="FormDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Module :</p>
                                <div class="col-sm-8">
                                     <p id="ModuleDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Problem :</p>
                                <div class="col-sm-8">
                                     <p id="ProblemDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                             <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Cause :</p>
                                <div class="col-sm-8">
                                     <p id="CauseDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Solution :</p>
                                <div class="col-sm-8">
                                     <p id="SolutionDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Remark :</p>
                                <div class="col-sm-8">
                                      <p id="RemarkDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div class="form-group row">
                                <p class="col-sm-4 lebel-text">Submitted Date :</p>
                                <div class="col-sm-8">
                                      <p id="EndDateDet" class="lebel-text"></p>
                                    
                                </div>
                            </div>

                            <div id="ReplyBlog" class="hide">
                                <hr />
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <p id="Reply" class="reply-text"></p>
                                </div>
                            </div>



                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="btnReply" runat="server" Text="Reply" class="btn button btn-sm"  OnClick="btnReply_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn button_cancel btn-sm" data-dismiss="modal" />
                        </div>
                      </div>
      
                    </div>
                  </div>
                </div>

                    </div>               
               </div>
          <%--</div>--%>
      </div>
   </div>

</asp:Content>




