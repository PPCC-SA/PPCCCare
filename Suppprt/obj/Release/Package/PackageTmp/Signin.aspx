<%@ Page Title="Sign in" Language="vb" AutoEventWireup="false" CodeBehind="Signin.aspx.vb" Inherits="Support.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %></title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="icon" href="images/PPCC-Care-Logo-p-00132x32.png" sizes="32x32" type="image/png" />
    <link rel="icon" href="images/PPCC-Care-Logo-p-00116x16.png" sizes="16x16" type="image/png" />
   <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <script src="js/bootstrap.min.js" type='text/javascript' ></script>
    <script src="js/jquery.min.js" type='text/javascript' ></script>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js" type="text/javascript"></script>
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP" crossorigin="anonymous">
    <link href="~/css/NewLogin.css" rel="stylesheet" type="text/css" />
    <script src="sweetalert2/sweetalert2.min.js"></script>
    <link href="sweetalert2/sweetalert2.min.css" rel="stylesheet" type="text/css" />
    <script>

        function ShowSweetAlert(type, msg, icon) {
            Swal.fire(
                type,
                msg,
                icon
            )

        }

    </script>


    <style type="text/css">
        body {
          background-image: url('images/bg_no_ppcc_care.png');
          background-repeat: no-repeat;
          background-attachment: fixed; 
          background-size: cover;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="container h-100">
		<div class="d-flex justify-content-center h-100">
            <div class="box_user_card">
                <div class="user_card">
                    <div class="form_container">
                        <%--<asp:Panel ID="NotificationPanel" runat="server" CssClass= "alert alert-danger alert-dismissable" Visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </asp:Panel>--%>
                        <div class="d-flex justify-content-center">
					        <div class="brand_logo_container">
						        <img src="images/PPCC-Care-Logo-p-500.png" class="brand_logo" alt="Logo">
					        </div>
				        </div>
						<div class="input-group mb-3">
                                <div class="input-group-prepend">
								    <span class="input-group-text"><i class="fas fa-user"></i></span>
                                </div>

							<asp:TextBox ID="txtUsername" runat="server" class="form-control input_user" placeholder="Username" required=""></asp:TextBox>
							<%--<input type="text" name="" class="form-control input_user" value="" placeholder="username">--%>
						</div>
						<div class="input-group mb-2">
							<div class="input-group-prepend">
								<span class="input-group-text"><i class="fas fa-key"></i></span>
							</div>

                            <asp:TextBox ID="txtPassword" runat="server" class="form-control input_pass" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
							<%--<input type="password" name="" class="form-control input_pass" value="" placeholder="password">--%>
						</div>
						<%--<div class="form-group">
							<div class="custom-control custom-checkbox">
								<input type="checkbox" class="custom-control-input" id="customControlInline">
								<label class="custom-control-label" for="customControlInline">Remember me</label>
							</div>
						</div>--%>
						<div class="d-flex justify-content-center mt-3 login_container">
				 	        <%--<button type="button" name="button" class="btn login_btn">Login</button>--%>
                            <asp:Button ID="btnLogin" runat="server" class="btn login_btn" Text="Sign in" />
				        </div>

                        <%--<div class="mt-4">
					        <div class="d-flex justify-content-center links">
						        Don't have an account? <a href="#" class="ml-2">Sign Up</a>
					        </div>
					        <div class="d-flex justify-content-center links">
						        <a href="#">Forgot your password?</a>
					        </div>
				        </div>--%>
				    </div>
                    
				    <%--<div class="d-flex justify-content-center">
					    <div class="brand_logo_container">
						    <img src="https://cdn.freebiesupply.com/logos/large/2x/pinterest-circle-logo-png-transparent.png" class="brand_logo" alt="Logo">
					    </div>
				    </div>--%>

                    
			    </div>
            </div>			
		</div>
	</div>
    </form>
</body>
</html>
