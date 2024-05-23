<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OldSupport.Master" CodeBehind="OldAddUser.aspx.vb" Inherits="Support.OldAddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <div class="form-horizontal">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="col-sm-4 text-right">
                                        <asp:Label ID="lblNewUsername" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Username"></asp:Label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtNewUsername" runat="server" class="form-control" type="Text" required="required"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="col-sm-4 text-right">
                                        <asp:Label ID="lblNewPassword" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Password"></asp:Label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" TextMode="Password" required="required"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="col-sm-4 text-right">
                                        <asp:Label ID="lblNewCustomer" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Customer"></asp:Label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlNewCustomer" runat="server" class="form-control1" required="required"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="col-sm-4 text-right">
                                        <asp:Label ID="lblNewCategory" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Category" required="required"></asp:Label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlNewCategory" runat="server" class="form-control1">
                                             <asp:ListItem Text="Administrator" Value="Admin"></asp:ListItem>
                                             <asp:ListItem Text="User" Value="User" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-4">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                        <asp:Button ID="btnSubmit" runat="server" class="btn-primary btn" Text="Add" Width="80px" />
                                        &nbsp; &nbsp; 
                                        <asp:Button ID="btnCancel" runat="server" class="btn-default btn" Text="Cancel" Width="80px" />
                                    </div>
                                    <div class="col-sm-3"></div>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="GridUser" CssClass="table table-bordered table-striped table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="RowPointer"
                                OnRowCancelingEdit="GridUser_RowCancelingEdit"
                                OnRowEditing="GridUser_RowEditing"
                                OnRowUpdating="GridUser_RowUpdating"
                                OnPageIndexChanging="GridUser_PageIndexChanging"
                                OnRowDeleting="GridUser_RowDeleting"
                                OnRowDataBound="GridUser_RowDataBound">
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
                                    <%--<FooterTemplate>
                                        <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add New Entry" CommandArgument=''><img src="../Images/GridAdd.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel" CommandArgument=''><img src="../Images/GridRefresh.png" /></asp:LinkButton>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Username" ItemStyle-Width="25%">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditUsername" runat="server" Text='<%# Bind("username") %>' CssClass="lebel-text"></asp:Label>
                                        <%--<asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("username") %>' MaxLength="30" Width="100%" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valUsername" runat="server" ControlToValidate="txtUsername"
                                                                    Display="Dynamic" ErrorMessage="Username is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="editGrp">*</asp:RequiredFieldValidator>--%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("username") %>' CssClass="lebel-text"></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <asp:TextBox ID="txtUsernameNew" runat="server" MaxLength="30"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valUsernameNew" runat="server" ControlToValidate="txtUsernameNew"
                                                                    Display="Dynamic" ErrorMessage="Username is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password" ItemStyle-Width="25%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("password") %>' MaxLength="30" Width="100%" class="form-control1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword"
                                                                    Display="Dynamic" ErrorMessage="Password is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("password") %>' CssClass="lebel-text"></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <asp:TextBox ID="txtUsernameNew" runat="server" MaxLength="30"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valUsernameNew" runat="server" ControlToValidate="txtUsernameNew"
                                                                    Display="Dynamic" ErrorMessage="Username is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" ItemStyle-Width="23%">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditCustomer" runat="server" Text='<%# Bind("customer") %>' CssClass="lebel-text" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCustomer" runat="server" Width="100%" class="form-control1" DataTextField="name" DataValueField="cust_num"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valCustomer" runat="server" ControlToValidate="ddlCustomer"
                                                                    Display="Dynamic" ErrorMessage="Customer is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("customer") %>' CssClass="lebel-text"></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <asp:TextBox ID="txtUsernameNew" runat="server" MaxLength="30"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valUsernameNew" runat="server" ControlToValidate="txtUsernameNew"
                                                                    Display="Dynamic" ErrorMessage="Username is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" ItemStyle-Width="20%">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditCategory" runat="server" Text='<%# Bind("category") %>' CssClass="lebel-text" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" Width="100%" class="form-control1">
                                            <asp:ListItem Text="Administrator" Value="Admin"></asp:ListItem>
                                            <asp:ListItem Text="User" Value="User"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valCategory" runat="server" ControlToValidate="ddlCategory"
                                                                    Display="Dynamic" ErrorMessage="Customer is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("category") %>' CssClass="lebel-text"></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <asp:TextBox ID="txtUsernameNew" runat="server" MaxLength="30"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valUsernameNew" runat="server" ControlToValidate="txtUsernameNew"
                                                                    Display="Dynamic" ErrorMessage="Username is required." ForeColor="Red" SetFocusOnError="True"
                                                                    ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>--%>
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
                    </ContentTemplate>
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
