<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminPanel_AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="<%=ResolveClientUrl("~/Content/css/bootstrap.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Content/css/bootstrap-theme.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.min.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/open-iconic-bootstrap.min.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/animate.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/owl.carousel.min.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/owl.theme.default.min.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/magnific-popup.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/aos.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/ionicons.min.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/bootstrap-datepicker.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/jquery.timepicker.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/flaticon.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/icomoon.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/css/style.css") %>" />
    <script src="<%=ResolveClientUrl("~/Content/js/main.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery-migrate-3.0.1.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/popper.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.easing.1.3.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.waypoints.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.stellar.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/owl.carousel.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.magnific-popup.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/aos.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/jquery.animateNumber.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/scrollax.min.js") %>"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBVWaKrjvy3MaE7SQ74_uJiULgl1JY0H2s&sensor=false"></script>
    <script src="<%=ResolveClientUrl("~/Content/js/google-map.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hero-wrap img" style="background-image: url('../Content/images/image_3.jpg');" data-stellar-background-ratio="1">
            <div class="overlay"></div>
            <div class="container" style="padding-top: 50px;">
                <div class="row">

                    <div class="col-md-12">
                        <h1>
                            <asp:Label runat="server" ID="lblPageHeader" style="color:white" Text="Admin Login" />
                        </h1>
                        <hr />
                        <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                    </div>
                    <br />
                </div>
                <br />
                <div class="form-group row">
                    <label for="lblUserName" class="col-md-2 col-form-label" style="color:white">User Name</label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter User Name" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter User Name" CssClass="text-danger" ValidationGroup="User" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="lblPassword" class="col-md-2 col-form-label" style="color:white">Password</label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" CssClass="text-danger" ValidationGroup="User" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4">
                        <%--<asp:HyperLink runat="server" ID="hlForgetPassword" NavigateUrl="~/Admin/ForgetPassword">Forget Password?</asp:HyperLink>--%>
                        <%--<a runat="server" href="#" onclick="window.open('ForgetPassword.aspx','FP','width=500,height=50,top=300,left=500,fullscreen=no,resizable=0');" >Forget Password?</a>--%>
                        <%--<asp:Label ID="lblForgetPassword" runat="server" Text="Forget Password ?" Font-Underline="True"></asp:Label>--%>
                    </div>
                    <div class="col-sm-2 pull-right">
                        <asp:Button runat="server" ID="btnLogin" ValidationGroup="User" Text="Login" CssClass="btn btn-primary pull-right" OnClick="btnLogin_Click"></asp:Button>
                        &nbsp;
                <asp:HyperLink runat="server" ID="hlClear" Text="Clear" NavigateUrl="~/Admin/Login" CssClass="btn btn-danger" />
                    </div>
                    <div class="col-sm-12 ml-3">
                        <i class="small" style="color:white">Don't have an account ?</i>
                        <asp:HyperLink runat="server" ID="hlSignUp" NavigateUrl="~/Admin/SignUp">
                            <i class="small" style="color:yellow">SignUp</i>
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
