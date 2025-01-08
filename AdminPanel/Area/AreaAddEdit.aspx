<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="AreaAddEdit.aspx.cs" Inherits="AdminPanel_Area_AreaAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label runat="server" ID="lblPageHeader" />
                    <br />
                </h1>
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                <br />
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label for="lblAreaName" class="col-sm-2 col-from-label">Area Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtAreaName" CssClass="form-control" placeholder="Enter Area Name" />
                <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="txtAreaName" Display="Dynamic" ErrorMessage="Enter Area Name" ForeColor="Red" ValidationGroup="Area"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row">
            <label for="lblCategory" class="col-sm-2 col-from-label">CategoryName</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control" placeholder="Select Category" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfCategory" ControlToValidate="ddlCategory" Display="Dynamic" ErrorMessage="Select Category" ForeColor="Red" ValidationGroup="Area" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Area" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" NavigateUrl="~/Admin/Area" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

