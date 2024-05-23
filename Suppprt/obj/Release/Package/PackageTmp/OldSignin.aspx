<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OldSignin.aspx.vb" Inherits="Support.OldSignin" %>

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
    <form id="form1" runat="server">
        <div>
            <div class="login">
		<h1><a href="http://www.ppcc.co.th/" target="_blank"><img src="images/PPCC_LOGO_NEW.png" /></a></h1>

        

		<div class="login-bottom">
            <asp:Panel ID="NotificationPanel" runat="server" CssClass= "alert alert-danger alert-dismissable" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </asp:Panel>

			<div class="col-md-3"></div>

			<%--<form>--%>

			<div class="col-md-6">
                 
                <h2 style="text-align:left">SIGN IN</h2>

				<div class="login-mail">
                    <%--<input type="text" id="txtUsername" name="txtUsername" placeholder="Username" required="">--%>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" required=""></asp:TextBox>
					<i class="fa fa-user"></i>
				</div>
				<div class="login-mail">
					<%--<input type="password" id="txtPassword" name="txtPassword" placeholder="Password" required="">--%>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
					<i class="fa fa-lock"></i>
				</div>
               <%-- <div class="input-group">
                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control1">
                        <asp:ListItem Text="User" Value="User" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Administrator" Value="Admin"></asp:ListItem>
                    </asp:DropDownList>
                </div>--%>
                <%--<div class="input-group">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                        <asp:ListItem Value="C" Text="Customer" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="A" Text="Administrator"></asp:ListItem>
                    </asp:DropDownList>
				</div>--%>

            <%--<a class="news-letter " href="#">
					<label class="checkbox1"><input type="checkbox" name="checkbox" ><i> </i>Forget Password</label>

				</a>--%>

                    <label class="login-do hvr-shutter-in-horizontal login-sub">
					    <%--<input type="submit" id="btnLogin" name="btnLogin" value="Sing in">--%>
                        <asp:Button ID="btnLogin" runat="server" Text="Sign in" />
					</label>

			
			</div>

            <div class="col-md-3"></div>

			<%--<div class="col-md-6 login-do">
					<p>Do not have an account?</p>
                <asp:LinkButton ID="lnkSignup" class="hvr-shutter-in-horizontal" PostBackUrl="Signup.aspx" runat="server">Sign up</asp:LinkButton>--%>
			<%--</div>--%>
			
			<div class="clearfix"> </div>
			<%--</form>--%>
		</div>
	</div>
		<!---->
        <div class="copy-right">
           <p> &copy; 2019 Premier Professional Consulting Co., Ltd. All Rights Reserved .</p>	    </div> 

        </div>
    </form>
</body>
</html>