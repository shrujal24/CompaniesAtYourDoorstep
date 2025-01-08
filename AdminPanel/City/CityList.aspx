<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <h1>City List</h1>
                <br />
                <asp:HyperLink ID="hlCityAdd" runat="server" Text="Add New City" NavigateUrl="~/Admin/City/Add" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblMessage" CssClass="alert-danger" EnableViewState="false" />
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
                                        <asp:Label ID="lbhCityName" runat="server" Text="City Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhStateName" runat="server" Text="State Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhCountryName" runat="server" Text="Country Name"></asp:Label>
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
                                    <%#Eval("CityName") %>
                                </td>
                                <td>
                                    <%#Eval("StateName") %>
                                </td>
                                <td>
                                    <%#Eval("CountryName") %>
                                </td>
                                <td class="text-nowrap text-center">
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary" runat="server" ToolTip="Edit Record" Text="Edit" NavigateUrl='<%# "~/Admin/City/Edit/" + Eval("CityID").ToString().Trim() %>' />
                                    &nbsp; &nbsp; &nbsp;    
                                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" ToolTip="Delete Record" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>'></asp:LinkButton>
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

