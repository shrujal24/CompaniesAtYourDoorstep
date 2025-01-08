<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="QuestionAddEdit.aspx.cs" Inherits="AdminPanel_Question_QuestionAddEdit" %>

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
            <label for="lblQuestion" class="col-sm-2 col-from-label" style="font-weight: bold">Question</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" placeholder="Enter Question" />
                <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestion" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Question" ValidationGroup="Question"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Question" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin/Question" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

