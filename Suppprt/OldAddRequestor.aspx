<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OldSupport.Master" CodeBehind="OldAddRequestor.aspx.vb" Inherits="Support.OldAddRequestor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.js"></script>

    <style type="text/css">
       .lebel-text {
           font-family: 'Cloud-Light';
           color: #666666;
           font-weight: normal;
           font-size: 100%; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        <div class="grid-form">
            <div class="row">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-xs-12 Notify">
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
                        <%--<div class="grid-form">--%>
                            <div class="form-horizontal">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <div class="col-sm-2 text-right">
                                            <asp:Label ID="Requestor" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Requestor"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtRequestor" runat="server" class="form-control" type="Text" required="required"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2 text-right">
                                            <asp:Label ID="lblCompany" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Company"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlCompany" name="ddlCompany" runat="server" class="form-control1" required="required"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <div class="col-sm-2 text-right">
                                            <asp:Label ID="lblFirstName" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="First Name"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtFirstName" runat="server" class="form-control" type="Text" required="required"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2 text-right">
                                            <asp:Label ID="lblLastName" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Last Name"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtLastName" runat="server" class="form-control" type="Text" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <div class="col-sm-2 text-right">
                                            <asp:Label ID="lblEmail" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="E-Mail"></asp:Label>
                                        </div>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <div class="col-sm-5"></div>
                                        <div class="col-sm-4">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn-primary btn" Text="Add" Width="80px" />
                                            &nbsp; &nbsp; 
                                            <asp:Button ID="btnCancel" runat="server" class="btn-default btn" Text="Cancel" Width="80px" />
                                        </div>
                                        <div class="col-sm-3"></div>
                                    </div>
                                </div>
                                <asp:GridView ID="GridRequestor" CssClass="table table-bordered table-striped table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        DataKeyNames="RowPointer"
                                        OnRowCancelingEdit="GridRequestor_RowCancelingEdit"
                                        OnRowEditing="GridRequestor_RowEditing"
                                        OnRowUpdating="GridRequestor_RowUpdating"
                                        OnPageIndexChanging="GridRequestor_PageIndexChanging"
                                        OnRowDeleting="GridRequestor_RowDeleting"
                                        OnRowDataBound="GridRequestor_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" ToolTip="Edit"><img src="images/GridEdit.png" /></asp:LinkButton>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                                                ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'><img src="images/GridDelete.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Update" CommandArgument=''><img src="images/GridSave.png" /></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel" CommandArgument=''><img src="images/GridCancel.png" /></asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requestor" ItemStyle-Width="20%">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRequestor" runat="server" Text='<%# Bind("req") %>' MaxLength="30" Width="100%" class="form-control1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valRequestor" runat="server" ControlToValidate="txtRequestor"
                                                                    Display="Dynamic" ErrorMessage="Requestor is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequestor" runat="server" Text='<%# Bind("req") %>' CssClass="lebel-text"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" ItemStyle-Width="25%">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("name") %>' MaxLength="30" Width="100%" class="form-control1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName"
                                                                            Display="Dynamic" ErrorMessage="Name is required." ForeColor="Red" SetFocusOnError="True"
                                                                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("name") %>' CssClass="lebel-text"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" ItemStyle-Width="30%" ItemStyle-Wrap="true">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' MaxLength="30" Width="100%" class="form-control1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                                                                            Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                                                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>' CssClass="lebel-text"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer" ItemStyle-Width="25%" ItemStyle-Wrap="true">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEditCustomer" runat="server" Text='<%# Bind("cust_num") %>' CssClass="lebel-text" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlCustomer" runat="server" Width="100%" class="form-control1" DataTextField="name" DataValueField="cust_num"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valCustomer" runat="server" ControlToValidate="ddlCustomer"
                                                                            Display="Dynamic" ErrorMessage="Customer is required." ForeColor="Red" SetFocusOnError="True"
                                                                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("cust_num") %>' CssClass="lebel-text"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RowPointer" ItemStyle-Wrap="true">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEditRowPointer" runat="server" Text='<%# Eval("RowPointer") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowPointer" runat="server" Text='<%# Eval("RowPointer") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="hidden" />
                                            <ItemStyle CssClass="hidden" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        <%--</div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
