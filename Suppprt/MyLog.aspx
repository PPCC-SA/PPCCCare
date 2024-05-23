<%@ Page Title="My Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="MyLog.aspx.vb" Inherits="Support.MyLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div id="wrapper">
    <div class="grid-form">
    <div class="row">    
        <div class="col-xs-8 col-xs-offset-2">
		    <div class="input-group">
                <div class="input-group-btn search-panel">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                    	<span id="search_concept">Filter by</span> <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                      <li><a href="#log_id">Log ID</a></li>
                      <li><a href="#subject">Subject</a></li>
                      <li class="divider"></li>
                      <li><a href="#all">All</a></li>
                    </ul>
                </div>
                <input type="hidden" name="search_param" value="all" id="search_param">         
                <input type="text" class="form-control" name="txtSearch" id="txtSearch" placeholder="Search">
                <span class="input-group-btn">
                    <button class="btn btn-default" id="btnSearch" name="btnSearch" type="button"><span class="fa fa-search"></span></button>
                </span>
            </div>
        </div>
	</div>

    <div id="wrapper">
        <div class="grid-form">
            <table class="table table-bordered table-striped table-hover">
            <thead class="table table-striped">
                <tr class="unread">
                    <td>Status</td>
                    <td>Log ID</td>
                    <td>Title</td>
                    
                    <td>Type</td>
                </tr>
            </thead>
            <tbody>
                <tr class="">
                    <td><span class="label label-success label-font">IN-PROCESS</span></td>
                    <%--<td class="view-message"><a data-toggle="modal" href="#normalModal">TAK1904002</a></td>--%>
                    <td>TAK1904002</td>
                    <td>Update เลข CN</td>
                    <td>Knowledge</td>
                </tr>
                <tr class="">
                    <td><span class="label label-success">IN-PROCESS</span></td>
                    <td>TAK1904006</td>
                    <td>พบยอดติดลบค่ะ</td>
                    <td>Standard Bug</td>
                </tr>
                <tr class="">
                    <td><span class="label label-default">CLOSED</span></td>
                    <td>TAK1904008</td>
                    <td>RE: ภาษีซื้อไม่วิ่งรายงานค่ะ</td>
                    <td>Customized Bug</td>
                </tr>
                    
            </tbody>
            </table>
        </div>

    </div>
    </div>
    </div>


</asp:Content>
