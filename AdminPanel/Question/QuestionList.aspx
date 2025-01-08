<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminMaster.master" AutoEventWireup="true" CodeFile="QuestionList.aspx.cs" Inherits="AdminPanel_Question_QuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>Question List</h1>
                <br />
                <asp:HyperLink runat="server" ID="hlQuestionAdd" Text="Add New Question" NavigateUrl="~/Admin/Question/Add" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-10">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <div id="TableContent">
                    <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-advanced table-responsive-md table-responsive-sm table-striped table-hover hide-if-no-data" id="sample_1">
                                <%-- Table Header --%>
                                <tr>
                                    <th>
                                        <asp:Label ID="lblSRNo" runat="server" Text="Sr No."></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhQuestion" runat="server" Text="Question"></asp:Label>
                                    </th>
                                    <th style="text-align: center">
                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
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
                                    <%#Eval("Question") %>
                                </td>
                                <td class="text-nowrap text-center">
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary" runat="server" ToolTip="Edit Record" Text="Edit" NavigateUrl='<%# "~/Admin/Question/Edit/" + Eval("QueID").ToString().Trim() %>' />
                                    &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="Delete" ToolTip="Delete Record" CommandName="DeleteRecord" CommandArgument='<%# Eval("QueID") %>'></asp:LinkButton>
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

