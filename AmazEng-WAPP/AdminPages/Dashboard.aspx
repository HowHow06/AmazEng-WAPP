<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.Dashboard" %>

<%@ Register TagPrefix="my" TagName="Leaderboard" Src="~/Class/Controls/Leaderboard.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- top Section -->
    <div class="row mb-2">
        <div class="col-md-4">
            <div class="card row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-100 position-relative p-3">
                <div class="col-6 d-flex flex-column justify-content-center">
                    <i class="fa-solid fa-square-poll-vertical fa-8x"></i>
                </div>
                <div class="col-6 d-flex flex-column position-static justify-content-center">
                    <h1>
                        <asp:Literal ID="lblTotalIdiomViewCount" runat="server" />

                    </h1>
                    <h6>Total Idioms View</h6>
                    <h6>
                        <asp:Literal ID="lblCurrentMonthYear1" runat="server" />
                    </h6>
                </div>

            </div>
        </div>
        <div class="col-md-4">
            <div class="card row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm  h-100 position-relative p-3">
                <div class="col-6 d-flex flex-column justify-content-center">
                    <i class="fa-solid fa-people-group fa-8x"></i>
                </div>
                <div class="col-6 d-flex flex-column position-static justify-content-center">
                    <h1>
                        <asp:Literal ID="lblMemberCount" runat="server" /></h1>
                    <h6>Registered Members</h6>
                    <h6>
                        <asp:Literal ID="lblCurrentMonthYear3" runat="server" />
                    </h6>
                </div>

            </div>
        </div>
        <div class="col-md-4">
            <div class="card row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm  h-100 position-relative p-3">
                <div class="col-6 d-flex flex-column justify-content-center">
                    <i class="fa-solid fa-user fa-8x"></i>
                </div>
                <div class="col-6 d-flex flex-column position-static justify-content-center">
                    <h1>
                        <asp:Literal ID="lblActiveMemberCount" runat="server" /></h1>
                    <h6>Active Members</h6>
                    <h6>
                        <asp:Literal ID="lblCurrentMonthYear2" runat="server" />
                    </h6>
                </div>
            </div>
        </div>
    </div>
    <!--  top Section -->
    <!--  mid Section -->
    <div class="row my-4">
        <div class="col-md-6">
            <div class="card h-100  shadow-sm ">
                <my:Leaderboard runat="server" CssClass="p-4 my-2" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="card h-100  shadow-sm ">
                <div class="p-4 my-2">
                    <span class="h4 mb-1 ">Most View Idioms</span>
                    <asp:GridView ID="GridMostViewIdiom"
                        runat="server"
                        ItemType="AmazEng_WAPP.Models.Idiom"
                        SelectMethod="GridMostViewIdiom_GetData"
                        AutoGenerateColumns="false" BorderStyle="None" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="Name" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <span><%# Item.ViewCount %></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            There is no idiom
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>

            </div>
        </div>
    </div>
    <!--  mid Section -->

</asp:Content>
