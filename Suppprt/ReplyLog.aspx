<%@ Page Title="Reply Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="ReplyLog.aspx.vb" Inherits="Support.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .Notify { margin-left: -18px; }

        .text-right {text-align:right;}

        .button,
        .button:hover {
            background-color: #0047BB;
            color: #fff;
            border-radius: 25px;
        }

        .reply-text {
            font-weight: normal;
            font-size: 0.9rem;
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

        //$(document).ready(function(){

        //    Swal.fire(
        //        'Success',
        //        '1234567',
        //        'success'
        //    )

        //});

    </script>

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

                            <%--<div class="row">
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
                            </div>--%>

                            <%--<div class="grid-form">
                                <div class="form-horizontal">
                                    <div class="media">--%>
                                        <%--<div class="media-left">
                                            <img src="\images\img_avatar3.png" class="media-object" style="width:60px">
                                        </div>--%>
                                            <h4>Reply Log ID. <b><asp:Label ID="lblsLogId" runat="server" Text=""></asp:Label></b></h4>
                                            <h4><asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></h4>
                                            <br />
                                            <div class="form-group row">
                                                <label for="lblsProblem" class="col-sm-2 col-form-label font-weight-bold">Problem:</label>
                                                <%--<asp:Label ID="lblProblem" runat="server" BorderWidth="0px" Text="Problem:"></asp:Label>--%>
                                                <div class="col-sm-10">
                                                    <asp:Label ID="lblsProblem" runat="server"  Text=""></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label for="lblsCause" class="col-sm-2 col-form-label font-weight-bold">Cause:</label>
                                                <%--<asp:Label ID="lblCause" runat="server" BorderWidth="0px" Text="Cause:"></asp:Label>--%>
                                                <div class="col-sm-10">
                                                    <asp:Label ID="lblsCause" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label for="lblsSolution" class="col-sm-2 col-form-label font-weight-bold">Solution:</label>
                                                <%--<asp:Label ID="lblSolution" runat="server" BorderWidth="0px" Text="Solution:"></asp:Label>--%>
                                                <div class="col-sm-10">
                                                    <asp:Label ID="lblsSolution" runat="server" BorderWidth="0px" Text=""></asp:Label>
                                                </div>
                                            </div>

                                    <%--</div>--%>
                                    <hr />
                                    <%--<ul class="media">--%>
                                        <asp:Repeater ID="RepeaterReply" runat="server">
                                            <ItemTemplate>
                                                <h5><asp:Label ID="lblSubject" CssClass="reply-text" runat="server"><i><b><%#Container.DataItem("username") %></b> - Posted on <%#Container.DataItem("reply_date") %></i></asp:Label></h5>
                                                <div class="form-group row">
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblsCause" runat="server"  CssClass="reply-text" ><p><%#Container.DataItem("reply") %></p></asp:Label>
                                                    </div>
                                                </div>

                                            </ItemTemplate>
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
                                    <div class="row d-flex justify-content-center">
                                        <div class="form-group col-md-12">
                                            <div class="justify-content-center">
                                                <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Class="form-control input_user" rows="6"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <div class="form-row">
                                                <%--<textarea class="content" id="txtDesc"></textarea>--%>
                                                <asp:Button ID="btnReply" runat="server" class="btn button btn-lg" Text="Reply" />
                                        </div>

                                    </div>
                                <%--</div>
                            </div>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnReply" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
