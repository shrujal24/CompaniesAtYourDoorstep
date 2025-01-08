<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

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
            <label for="lblCountryName" class="col-sm-2 col-from-label" style="font-weight: bold">Country Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control" placeholder="Enter Country Name" />
                <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Country Name" ValidationGroup="Country"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Country" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/Country" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

