<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
     <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <br />
                    <asp:Label runat="server" ID="lblPageHeader" /><br />
                </h1>
                <hr />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
            </div>
            <br />
        </div>
        <br />
        <div class="form-group row">
            <label for="lblCityName" class="col-sm-2 col-form-label">City Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" placeholder="Enter City Name" />
                <asp:RequiredFieldValidator runat="server" ID="rfvCityName" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Enter City Name" ForeColor="Red" ValidationGroup="City" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblCountry" class="col-sm-2 col-form-label">Coutry</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" placeholder="Select Country" AutoPostBack="True"  OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfCountry" ControlToValidate="ddlCountry"  Display="Dynamic" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="City" InitialValue="-99" />
            </div>
            <label for="lblState" class="col-sm-2 col-form-label">State</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" placeholder="Select State" AutoPostBack="True"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfState" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="City" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="City" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/City" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

