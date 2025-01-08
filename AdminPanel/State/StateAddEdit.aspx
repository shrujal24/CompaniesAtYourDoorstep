<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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
            <label for="lblStateName" class="col-sm-2 col-from-label">State Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control" placeholder="Enter State Name" />
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Enter State Name" ForeColor="Red" ValidationGroup="State"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row">
            <label for="lblCountry" class="col-sm-2 col-from-label">CountryName</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" placeholder="Select Country" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfCountry" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="State" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="State" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" NavigateUrl="~/Admin/State" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

