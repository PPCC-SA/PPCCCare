<%@ Page Title="Sign up" Language="vb" AutoEventWireup="false" CodeBehind="Signup.aspx.vb" Inherits="Support.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %></title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom Theme files -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/font-awesome.css" rel="stylesheet" /> 
    <script src="js/jquery.min.js"> </script>
    <script src="js/bootstrap.min.js"> </script>

</head>
<body>
    <form id="form1" runat="server" data-toggle="validator" role="form">
        <div>
            <div class="login">
		<h1><a href="http://www.ppcc.co.th/" target="_blank"><img src="images/LOGO_PPCC.png" /></a></h1>
		<div class="login-bottom">

            <asp:Panel ID="NotPassNotifyPanel" runat="server" CssClass= "alert alert-danger alert-dismissable" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <asp:Literal ID="NotPassText" runat="server"></asp:Literal>
            </asp:Panel>

            <asp:Panel ID="PassNotifyPanel" runat="server" CssClass= "alert alert-success alert-dismissable" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <asp:Literal ID="PassText" runat="server"></asp:Literal>
            </asp:Panel>

			<h2>SIGN UP</h2>
			<form>
			<div class="col-md-6">
				<div class="login-mail">
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" required=""></asp:TextBox>					
					<i class="fa fa-user"></i>
				</div>
				<div class="login-mail">
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
					<i class="fa fa-lock"></i>
				</div>
				<%--<div class="login-mail">
                    <asp:TextBox ID="txtRepassword" runat="server" placeholder="Repeated password" required="" TextMode="Password"></asp:TextBox>
					<i class="fa fa-lock"></i>
				</div>--%>

                <div class="form-group">
                    <asp:DropDownList ID="ddlCustomer" class="form-control" runat="server" required=""></asp:DropDownList>
                        
                </div>

				<%--<a class="news-letter " href="#">
					<label class="checkbox1"><input type="checkbox" name="checkbox" ><i> </i>I agree with the terms</label>
				</a>--%>

                    <label class="login-do hvr-shutter-in-horizontal login-sub">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
					    
					</label>

			</div>

			<div class="col-md-6 login-do">
					<p>Already register</p>
                <asp:LinkButton ID="lnkSignin" class="hvr-shutter-in-horizontal" PostBackUrl="Signin.aspx" runat="server">Sign in</asp:LinkButton>
				<%--<a href="Signin.aspx" class="hvr-shutter-in-horizontal">Sign in</a>--%>
			</div>
			
			<div class="clearfix"> </div>
			</form>
		</div>
	</div>
		<!---->
        <div class="copy-right">
           <p> &copy; 2019 Premier Professional Consulting Co., Ltd. All Rights Reserved .</p>	    </div> 
        </div>
    </form>
</body>
</html>
