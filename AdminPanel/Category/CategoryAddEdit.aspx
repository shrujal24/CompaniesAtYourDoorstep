<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CategoryAddEdit.aspx.cs" Inherits="AdminPanel_Category_CategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
     <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-sm-12">
                <h1>
                    <asp:Label runat="server" ID="lblPageHeader" />
                    <br />
                </h1>
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                <br />
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label for="lblCategoryName" class="col-sm-2 col-from-label" style="font-weight: bold">Category Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" placeholder="Enter Category Name" />
                <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Category Name" ValidationGroup="city"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="city" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/Category" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

