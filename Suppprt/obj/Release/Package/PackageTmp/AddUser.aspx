<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="AddUser.aspx.vb" Inherits="Support.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       .lebel-text {
          /*font-family: 'Cloud-Light';*/ 
           font-weight: normal;
           font-size: 100%; }

       .hide { display: none; }
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

       .button_cancel,
       .button_cancel:hover {
            background-color: #fff;
            color: #0047BB;
            border-color: #0047BB;
            border-radius: 25px;
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
                            <div class="form-group col-md-6">
                                <label for="txtNewUsername">Username</label>
                                <asp:TextBox ID="txtNewUsername" runat="server" class="form-control input_user" type="Text" required="required"></asp:TextBox>
                            </div>
                            
                            <div class="form-group col-md-6">
                                <label for="txtNewPassword">Password</label>    
                                <asp:TextBox ID="txtNewPassword" runat="server" class="form-control input_user" TextMode="Password" required="required"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="ddlNewCustomer">Customer</label>
                                <asp:DropDownList ID="ddlNewCustomer" runat="server" class="form-control input_user" required="required"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-6">
                                <label for="ddlNewCategory">Category</label>
                                <asp:DropDownList ID="ddlNewCategory" runat="server" class="form-control input_user">
                                        <asp:ListItem Text="Administrator" Value="Admin"></asp:ListItem>
                                        <asp:ListItem Text="User" Value="User" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                         <div class="d-flex justify-content-center">
                             <div class="form-row">
                                 <div class="form-group col-md-12 justify-content-center">
                                     <asp:Button ID="btnSubmit" runat="server" class="btn button" Text="Add" Width="80px" />
                                     &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" class="btn button_cancel" Text="Cancel" Width="80px" UseSubmitBehavior="False" />
                                 </div>
                                 
                             </div>
                         </div>
                        <div class="table-responsive">
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
                                                            ToolTip="Delete"><img src="images/GridDelete.png" /></asp:LinkButton>
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
                                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("password") %>' MaxLength="30" Width="100%" class="form-control input_user"></asp:TextBox>
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
                                            <asp:DropDownList ID="ddlCustomer" runat="server" Width="100%" class="form-control input_user" DataTextField="name" DataValueField="cust_num"></asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlCategory" runat="server" Width="100%" class="form-control input_user">
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
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
 </div>   
</asp:Content>
