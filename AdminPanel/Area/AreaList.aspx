<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="AreaList.aspx.cs" Inherits="AdminPanel_Area_AreaList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
     <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>Area List</h1>
                <br />
                <asp:HyperLink runat="server" ID="hlAreaAdd" Text="Add New Area" NavigateUrl="~/Admin/Area/Add" CssClass="btn btn-primary" />
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
                            <table class="table table-bordered table-advanced table-responsive-md table-responsive-sm table-striped table-hover" id="sample_1">
                                <%-- Table Header --%>
                                <tr>
                                    <th>
                                        <asp:Label ID="lblSRNo" runat="server" Text="Sr No."></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhAreaName" runat="server" Text="Area Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhCategoryName" runat="server" Text="Category Name"></asp:Label>
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
                                    <%# Eval("AreaName") %>
                                </td>
                                <td>
                                    <%# Eval("CategoryName") %>
                                </td>
                                <td class="text-nowrap text-center">
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary" runat="server" ToolTip="Edit Record" Text="Edit" NavigateUrl='<%# "~/Admin/Area/Edit/" + Eval("AreaID").ToString().Trim() %>' />
                                    &nbsp;&nbsp;&nbsp;&nbsp; 
                                     <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" ToolTip="Delete Record" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("AreaID") %>'></asp:LinkButton>
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

