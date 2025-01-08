<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminPanel_AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <%--<div class="hero-wrap img" style="background-image: url(../content/images/bg_1.jpg);">
    <div class="overlay"></div>
        </div>--%>
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3 ml-auto">
                    <h2>
                        <asp:Label ID="lblUserSession" runat="server" CssClass="text-dark" EnableViewState="false"></asp:Label></h2>
                </div>
                <%--code for Image--%>
                <%--<div class="col-md-2 ml-auto">
                    <asp:Image ID="imgUser" CssClass="rounded-circle img-thumbnail"  runat="server" />
                    <asp:FileUpload ID="fuImage" runat="server" Visible="false" />
                 <asp:RequiredFieldValidator runat="server" ID="rfvImage" ControlToValidate="fuImage" Display="Dynamic" ErrorMessage="Choose Image File" CssClass="text-danger" ValidationGroup="User" ForeColor="Red" />
                 
                </div>--%>

                <h2>
                    <asp:Label runat="server" ID="lblMsg" EnableViewState="false" /></h2>
                <asp:Button runat="server" ID="btnEdit" Text="Edit Details" CssClass="btn btn-primary" OnClick="btnEdit_Click"></asp:Button>
                <%--<asp:Button runat="server" ID="btnChangePassword" Text="Change Password" CssClass="btn btn-primary" Visible="false" OnClick="btnChangePassword_Click"></asp:Button>--%>
                <hr />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
            </div>
            <br />
        </div>
        <br />
        <div class="form-group row">
            <label for="lblUserName" class="col-sm-2 col-form-label">User Name</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter User Name" Enabled="False" />
                <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter User Name" CssClass="text-danger" ValidationGroup="User" />
            </div>
            <label for="lblBirthdate" class="col-sm-2 col-form-label">BirthDate</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtBirthdate" runat="server" TextMode="Date" CssClass="form-control" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvDate" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Select Date" CssClass="text-danger" ValidationGroup="User" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblMobileNo" class="col-sm-2 col-form-label">Mobile No.</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile No." MaxLength="10" TextMode="Phone" Enabled="False" />
                <asp:RequiredFieldValidator runat="server" ID="rvfMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No." ForeColor="Red" ValidationGroup="User" />
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="^([0-9]{10})$"></asp:RegularExpressionValidator>
            </div>
            <label for="lblEmailAddress" class="col-sm-2 col-form-label">Email Address</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email" Enabled="False" />
                <asp:RequiredFieldValidator runat="server" ID="rvfEmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="User" />
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-12">
                <asp:HyperLink runat="server" ID="hlChangePassword" NavigateUrl="~/Admin/ChangePassword" Visible="false">
                            <i class="text-primary">Change Password</i>
                </asp:HyperLink>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="User" CssClass="btn btn-primary pull-right" Visible="false" OnClick="btnSave_Click" />
                &nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/Home" CssClass="btn btn-danger" Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

