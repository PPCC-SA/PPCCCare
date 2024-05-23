<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="OldReplyLog.aspx.vb" Inherits="Support.OldReplyLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Notify { margin-left: -18px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-xs-11 Notify">
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
                <div class="grid-form">
                    <div class="form-horizontal">
                        <div class="media">
                            <%--<div class="media-left">
                                <img src="\images\img_avatar3.png" class="media-object" style="width:60px">
                            </div>--%>
                            <div class="media-body">
                                <h4 class="media-heading">Reply Log ID. <b><asp:Label ID="lblsLogId" runat="server" BorderWidth="0px" Text=""></asp:Label></b></h4>
                                <h4 class="media-heading"><asp:Label ID="lblSubject" runat="server" BorderWidth="0px" Text=""></asp:Label></h4>
                                <br />
                                <div class="col-xs-12">
                                    <div class="input-group">
                                       <div class="col-sm-1 text-right">
                                           <asp:Label ID="lblProblem" runat="server" BorderWidth="0px" Text="Problem:"></asp:Label>
                                       </div>
                                       <div class="col-sm-8">
                                           <asp:Label ID="lblsProblem" runat="server" BorderWidth="0px" Text=""></asp:Label>
                                       </div>
                                       <div class="col-sm-2"></div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group">
                                       <div class="col-sm-1 text-right">
                                           <asp:Label ID="lblCause" runat="server" BorderWidth="0px" Text="Cause:"></asp:Label>
                                       </div>
                                       <div class="col-sm-8">
                                           <asp:Label ID="lblsCause" runat="server" BorderWidth="0px" Text=""></asp:Label>
                                       </div>
                                       <div class="col-sm-2"></div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group">
                                       <div class="col-sm-1 text-right">
                                           <asp:Label ID="lblSolution" runat="server" BorderWidth="0px" Text="Solution:"></asp:Label>
                                       </div>
                                       <div class="col-sm-8">
                                           <asp:Label ID="lblsSolution" runat="server" BorderWidth="0px" Text=""></asp:Label>
                                       </div>
                                       <div class="col-sm-2"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-11">
                                <hr>
                            </div>
                        </div>
                        <%--<ul class="media">--%>
                            <asp:Repeater ID="RepeaterReply" runat="server">
                                <ItemTemplate>
                                    <div class="media">
                                        <div class="media-body">
                                            <h5 class="media-heading"><asp:Label ID="lblSubject" runat="server" BorderWidth="0px"><i><b><%#Container.DataItem("username") %></b> - Posted on <%#Container.DataItem("reply_date") %></i></asp:Label></h5>
                                            <div class="col-xs-12">
                                                <div class="input-group">
                                                    <div class="col-sm-11">
                                                       <asp:Label ID="lblsCause" runat="server" BorderWidth="0px"><p><%#Container.DataItem("reply") %></p></asp:Label>
                                                   </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <%--<div class="col-xs-11">
                                        <hr />
                                    </div>--%>
                                </SeparatorTemplate>
                            </asp:Repeater>
                            <%--<li>
                                <div class="media-left">
                                    <img src="\images\img_avatar4.png" class="media-object" style="width:60px">
                                </div>
                                <div class="media-body">
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                </div>
                                <div class="col-xs-11">
                                    <hr>
                                </div>
                            </li>--%>
                        <%--</ul>--%>
                        <br />
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-11">
                                    <%--<textarea class="content" id="txtDesc"></textarea>--%>
                                    <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Class="form-control content" rows="6"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="input-group">
                                <div class="col-sm-10">
                                    <%--<textarea class="content" id="txtDesc"></textarea>--%>
                                </div>
                            </div>
                            <div class="input-group">
                                <div class="col-sm-4"></div>
                                <div class="col-sm-2 text-right">
                                    <%--<textarea class="content" id="txtDesc"></textarea>--%>
                                    <asp:Button ID="btnReply" runat="server" class="btn-success btn" Text="Reply" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
