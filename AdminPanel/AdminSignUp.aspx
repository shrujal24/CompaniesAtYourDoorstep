<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminSignUp.aspx.cs" Inherits="AdminPanel_AdminSignUp" %>

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
        <div class="hero-wrap img" style="background-image: url('../Content/images/image_3.jpg');">
            <div class="overlay"></div>
    <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Label runat="server" ID="lblPageHeader" CssClass="text-white" Text="Registration Form" />
                    </h1>
                    <hr />
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                </div>
                <br />
            </div>
            <br />
            <div class="form-group row">
                <label for="lblUsername" class="col-sm-2 col-form-label text-white">User Name</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Enter User Name" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvUsername" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Enter User Name" CssClass="text-danger" ValidationGroup="User" />
                </div>
                <label for="lblPassword" class="col-sm-2 col-form-label text-white">Password</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" CssClass="text-danger" ValidationGroup="User" />
                </div>
            </div>
            <div class="form-group row">
                <label for="txtMobileNumber" class="col-sm-2 col-form-label text-white">Mobile Number</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile Number" TextMode="Phone" MaxLength="10" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvMobileNumber" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="User" />
                    <asp:RegularExpressionValidator ID="revMobileNumber" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="^(?:(?:\+|0{0,2})91(\s*[\ -]\s*)?|[0]?)?[789]\d{9}|(\d[ -]?){10}\d$"></asp:RegularExpressionValidator>
                </div>
                 <label for="lblPassword" class="col-sm-2 col-form-label text-white">BirthDate</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvDate" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Select Date" CssClass="text-danger" ValidationGroup="User" />
                </div>
            </div>
             <div class="form-group row">
                <label for="txtEmailAddress" class="col-sm-2 col-form-label text-white">Email Address</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvEmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="User" />
                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSignUp" ValidationGroup="User" Text="SignUp" CssClass="btn btn-primary pull-right" OnClick="btnSignUp_Click"></asp:Button>
                    &nbsp;
                <asp:HyperLink runat="server" ID="hlClear" Text="Clear" NavigateUrl="~/Admin/SignUp" CssClass="btn btn-danger" />
                </div>
                <div class="col-md-12 ml-3">
                    <i class="text-white">Do have an account ?</i>
                    <asp:HyperLink runat="server" ID="hlLogin" NavigateUrl="~/Admin/Login">
                            <i class="" style="color:yellow">Login</i>
                    </asp:HyperLink>
                </div>
            </div>
        </div>
            </div>
    </form>
</body>
</html>
