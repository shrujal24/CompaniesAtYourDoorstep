<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CandidateBasicDetailsList.aspx.cs" Inherits="AdminPanel_CandidateBasicDetails_CandidateBasicDetailsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>Candidate Basic Details List</h1>
                <br />
                <asp:HyperLink runat="server" ID="hlCandidateBasicDetailsAdd" Text="Add New Candidate" NavigateUrl="~/Admin/CandidateBasicDetails/Add" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
            </div>
        </div>
         <hr />

        <div class="row">
            <div class="col-md-12">
                <div id="TableContent">
                    <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-advanced table-responsive table-responsive-md table-responsive-sm table-striped table-hover" id="sample_1">
                                <%-- Table Header --%>
                                <tr>
                                    <th>
                                        <asp:Label ID="lblSRNo" runat="server" Text="Sr No."></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhUserName" runat="server" Text="User Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblCandidateAddress" runat="server" Text="CandidateAddress"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhProfileDate" runat="server" Text="Profile Date"></asp:Label>
                                    </th>
                                     <th>
                                        <asp:Label ID="lblCityName" runat="server" Text="CityName"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblContactNo" runat="server" Text="ContactNo"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblEmailAddress" runat="server" Text="EmailAddress"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblUserImage" runat="server" Text="User Image"></asp:Label>
                                    </th>
                                   
                                    <th style="text-align: center">
                                        <asp:Label ID="lbhAction" runat="server" Text="Action"></asp:Label>
                                    </th>
                                </tr>
                                <%-- END Table Header --%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%-- Table Rows --%>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSrNo" Text='<%# Container.ItemIndex +1 %>' runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%# Eval("Username") %>
                                </td>
                                <td>
                                    <%# Eval("FirstName") %>
                                </td>
                                <td>
                                    <%# Eval("MiddleName") %>
                                </td>
                                <td>
                                    <%# Eval("LastName") %>
                                </td>
                                <td>
                                    <%# Eval("CandidateAddress") %>
                                </td>
                                <td>
                                    <%# Eval("ProfileDate") %>
                                </td>
                                <td>
                                    <%# Eval("CityName") %>
                                </td>
                                <td>
                                    <%# Eval("Gender") %>
                                </td>
                                <td>
                                    <%# Eval("DOB") %>
                                </td>
                                <td>
                                    <%# Eval("ContactNo") %>
                                </td>
                                <td>
                                    <%# Eval("EmailAddress") %>
                                </td>
                                 <td>
                                    <asp:Image runat="server" ID="imgUser" CssClass="img-fluid" ImageUrl='<%# Eval("ImageUrl") %>' />
                                </td>
                                <td class="text-nowrap text-center">
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary" runat="server" ToolTip="Edit Record" Text="Edit" NavigateUrl='<%# "~/Admin/CandidateBasicDetails/Edit/" + Eval("CandidateID").ToString().Trim() %>' />
                                    &nbsp;&nbsp;&nbsp;&nbsp; 
                                     <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" ToolTip="Delete Record" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CandidateID") %>'></asp:LinkButton>
                                </td>
                            </tr>
                            <%-- END Table Rows --%>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>

                <br />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

