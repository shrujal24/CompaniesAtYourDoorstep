<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CandidateBasicDetailsAddEdit.aspx.cs" Inherits="AdminPanel_CandidateBasicDetails_CandidateBasicDetailsAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
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
            <label for="lblFirstName" class="col-sm-2 col-from-label">Name</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="Enter First Name" />
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Enter First Name" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
            </div>
            <%--<label for="lblMiddleName" class="col-sm-2 col-from-label">Middle Name</label>--%>
            <div class="col-sm-3">
                <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" placeholder="Enter Middle Name" />
                <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ControlToValidate="txtMiddleName" Display="Dynamic" ErrorMessage="Enter Middle Name" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
            </div>
            <%--<label for="lblLastName" class="col-sm-2 col-from-label">Last Name</label>--%>
            <div class="col-sm-3">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Enter Last Name" />
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Enter Last Name" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row">
            <label for="lblUserName" class="col-sm-2 col-from-label">User Name</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Enter User Name" />
                <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Enter User Name" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
            </div>
            <label for="lblPassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Enter Password" />
                <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" CssClass="text-danger" ValidationGroup="User" />
            </div>
        </div>
        <div class="form-group row">
            <label for="txtMobileNumber" class="col-sm-2 col-form-label">Mobile Number</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" placeholder="Enter Mobile Number" TextMode="Phone" MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ID="rfvMobileNumber" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="User" />
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="^(?:(?:\+|0{0,2})91(\s*[\ -]\s*)?|[0]?)?[789]\d{9}|(\d[ -]?){10}\d$"></asp:RegularExpressionValidator>
            </div>
            <label for="lblPassword" class="col-sm-2 col-form-label">BirthDate</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvDOB" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="Select Date" CssClass="text-danger" ValidationGroup="User" />
            </div>
        </div>
        <div class="form-group row">
            <label for="txtEmailAddress" class="col-sm-2 col-form-label">Email Address</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ID="rfvEmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="User" />
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <label for="lblGender" class="col-sm-2 col-form-label">Gender</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control" placeholder="Select Gender" AutoPostBack="True">
                    <asp:ListItem Value="-99" Selected="True" Disabled="Disabled">Select Gender</asp:ListItem>
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="2">Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfGender" ControlToValidate="ddlGender" Display="Dynamic" ErrorMessage="Select Gender" ForeColor="Red" ValidationGroup="User" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblPassword" class="col-sm-2 col-form-label">Address</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtCandidateAddress" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Address" />
                <asp:RequiredFieldValidator runat="server" ID="rfvCandidateAddress" ControlToValidate="txtCandidateAddress" Display="Dynamic" ErrorMessage="Enter Address" CssClass="text-danger" ValidationGroup="User" />
            </div>
             <label for="lblCountry" class="col-sm-2 col-form-label">Coutry</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" placeholder="Select Country" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfCountry" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="User" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblState" class="col-sm-2 col-form-label">State</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" placeholder="Select State" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfState" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="User" InitialValue="-99" />
            </div>
           <label for="lblCityd" class="col-sm-2 col-form-label">City</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control" placeholder="Select City" AutoPostBack="True"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfCity" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Select City" ForeColor="Red" ValidationGroup="User" InitialValue="-99" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblQuestion" class="col-sm-2 col-from-label">Question</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlQuestion" CssClass="form-control" placeholder="Select Question" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rvfQuestion" ControlToValidate="ddlQuestion" Display="Dynamic" ErrorMessage="Select Question" ForeColor="Red" ValidationGroup="User" InitialValue="-99" />
            </div>
            <label for="fuImage" class="col-sm-2 col-form-label">Image Upload</label>
            <div class="col-sm-2">
                <asp:Image ID="imgUser" CssClass="rounded-circle img-thumbnail" Visible="false" Height="150px"  runat="server" />
                <asp:FileUpload ID="fuImage" runat="server" ToolTip="Choose Image" />
                <asp:RequiredFieldValidator runat="server" ID="rfvImage" ControlToValidate="fuImage" Display="Dynamic" ErrorMessage="Choose Image File" CssClass="text-danger" ValidationGroup="User" ForeColor="Red" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblAnswer" class="col-sm-2 col-from-label">Answer</label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtAnswer" CssClass="form-control" placeholder="Enter Answer" />
                <asp:RequiredFieldValidator ID="rvfAnswer" runat="server" ControlToValidate="txtAnswer" Display="Dynamic" ErrorMessage="Enter Answer" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10"></div>
            <div class="col-sm-2 pull-right">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="User" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" NavigateUrl="~/Admin/CandidateBasicDetails" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

