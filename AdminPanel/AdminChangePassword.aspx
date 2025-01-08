<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminChangePassword.aspx.cs" Inherits="AdminPanel_AdminChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3 ml-auto">
                    <h2>
                        <asp:Label ID="lblUserSession" runat="server" CssClass="text-dark" EnableViewState="false"></asp:Label></h2>
                </div>
                <%--<div class="col-md-2 ml-auto">
                    <asp:Image ID="imgUser" CssClass="rounded-circle img-thumbnail" runat="server" />
                </div>--%>
                <h2>
                    <asp:Label runat="server" ID="lblMsg" Text="Change Your Password" /></h2>
                <hr />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
            </div>
            <br />
        </div>
        <br />
        <div class="form-group row">
            <label for="lblPassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Enter Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter your old Password" CssClass="text-danger" ValidationGroup="User" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblNewPassword" class="col-sm-2 col-form-label">New Password</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" placeholder="Enter New Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ID="rfvNewPassword" ControlToValidate="txtNewPassword" Display="Dynamic" ErrorMessage="Enter New Password" CssClass="text-danger" ValidationGroup="User" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblRetypeNewPassword" class="col-sm-2 col-form-label">Re-Type Password</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtRetypeNewPassword" CssClass="form-control" placeholder="Re-type New Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ID="rvfRetypeNewPassword" ControlToValidate="txtRetypeNewPassword" Display="Dynamic" ErrorMessage="Re-type New Password" ForeColor="Red" ValidationGroup="User" />
                <asp:CompareValidator ID="cvRetypeNewpassword" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtRetypeNewPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="The Re-type New Password must match the New Password."></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="User" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/Home" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

