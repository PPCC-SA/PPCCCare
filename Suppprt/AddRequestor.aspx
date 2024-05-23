<%@ Page Title="Requestor" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="AddRequestor.aspx.vb" Inherits="Support.WebForm3" %>
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
                                    <div class="form-group col-md-6">
                                        <%--<asp:Label ID="Requestor" runat="server" class="lebel-text" BorderWidth="0px" Text="Requestor"></asp:Label>--%>
                                        <label for="txtRequestor">Requestor</label>
                                        <asp:TextBox ID="txtRequestor" runat="server" class="form-control input_user" type="Text" required="required"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="ddlCompany">Company</label>
                                        <%--<asp:Label ID="lblCompany" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Company"></asp:Label>--%>
                                        <asp:DropDownList ID="ddlCompany" name="ddlCompany" runat="server" class="form-control input_user" required="required"></asp:DropDownList>
                                    </div>
                                </div>
                                    
                                 <div class="form-row">
                                     <div class="form-group col-md-6">
                                        <label for="txtFirstName">First Name</label>
                                        <%--<asp:Label ID="lblFirstName" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="First Name"></asp:Label>--%>
                                            <asp:TextBox ID="txtFirstName" runat="server" class="form-control input_user" type="Text" required="required"></asp:TextBox>

                                    </div>
                                     <div class="form-group col-md-6">
                                         <label for="txtFirstName">Last Name</label>
                                         <%--<asp:Label ID="lblLastName" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="Last Name"></asp:Label>--%>
                                         <asp:TextBox ID="txtLastName" runat="server" class="form-control input_user" type="Text" required="required"></asp:TextBox>
                                     </div>
                                 </div>

                                <div class="form-row">
                                    <div class="form-group col-md-12">
                                        <label for="txtFirstName">E-Mail</label>
                                        <%--<asp:Label ID="lblEmail" runat="server" class="form-control control-label hor-form" BorderWidth="0px" Text="E-Mail"></asp:Label>--%>
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control input_user" TextMode="Email" required="required"></asp:TextBox>
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
                                        <asp:GridView ID="GridRequestor" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="false" AllowPaging="true"
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
                                                                    ToolTip="Delete" OnClientClick="ShowSweetAlertConfirm(this);"><img src="images/GridDelete.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnkUpdate" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Update" CommandArgument=''><img src="images/GridSave.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel" CommandArgument=''><img src="images/GridCancel.png" /></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Requestor" ItemStyle-Width="20%">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRequestor" runat="server" Text='<%# Bind("req") %>' MaxLength="30" Width="100%" class="form-control input_user"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("name") %>' MaxLength="30" Width="100%" class="form-control input_user"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' MaxLength="30" Width="100%" class="form-control input_user"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ddlCustomer" runat="server" Width="100%" class="form-control input_user" DataTextField="name" DataValueField="cust_num"></asp:DropDownList>
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
