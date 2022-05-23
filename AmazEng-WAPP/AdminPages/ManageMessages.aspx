<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ManageMessages.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.ManageMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
        <div class="d-block mb-4 mb-md-0">
            <h2 class="h3 m-0">Messages</h2>
        </div>
    </div>
    <div class="table-settings mb-4">
        <div class="row align-items-center justify-content-between">
            <div class="col col-md-6 col-lg-3 col-xl-4">
                <div class="input-group me-2 me-lg-3 fmxw-400">
                    <span class="input-group-text">
                        <svg class="icon icon-xs" x-description="Heroicon name: solid/search" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"></path>
                        </svg>
                    </span>
                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Search issuer name, email, subject" OnTextChanged="txtSearch_TextChanged" />
                </div>
            </div>
            <div class="col-4 col-md-2 col-xl-1 ps-md-0 text-end">
                <div class="dropdown">
                    <button class="btn btn-link text-dark dropdown-toggle dropdown-toggle-split m-0 p-1" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <svg class="icon icon-sm" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M11.49 3.17c-.38-1.56-2.6-1.56-2.98 0a1.532 1.532 0 01-2.286.948c-1.372-.836-2.942.734-2.106 2.106.54.886.061 2.042-.947 2.287-1.561.379-1.561 2.6 0 2.978a1.532 1.532 0 01.947 2.287c-.836 1.372.734 2.942 2.106 2.106a1.532 1.532 0 012.287.947c.379 1.561 2.6 1.561 2.978 0a1.533 1.533 0 012.287-.947c1.372.836 2.942-.734 2.106-2.106a1.533 1.533 0 01.947-2.287c1.561-.379 1.561-2.6 0-2.978a1.532 1.532 0 01-.947-2.287c.836-1.372-.734-2.942-2.106-2.106a1.532 1.532 0 01-2.287-.947zM10 13a3 3 0 100-6 3 3 0 000 6z" clip-rule="evenodd"></path></svg>
                        <span class="visually-hidden">Toggle Dropdown</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-xs dropdown-menu-end pb-0" runat="server" id="pageSizePicker">
                        <span class="small ps-3 fw-bold text-dark">Show</span>
                        <asp:LinkButton class="dropdown-item d-flex align-items-center fw-bold" CommandArgument='10' OnClick="anchorShow_Click" runat="server" ID="anchorShow10">
                            <span>10</span>
                        </asp:LinkButton>
                        <asp:LinkButton class="dropdown-item d-flex align-items-center fw-bold" CommandArgument='20' OnClick="anchorShow_Click" runat="server" ID="anchorShow20"> 
                            <span>20</span>
                        </asp:LinkButton>
                        <asp:LinkButton class="dropdown-item d-flex align-items-center fw-bold rounded-bottom" CommandArgument='30' OnClick="anchorShow_Click" runat="server" ID="anchorShow30">
                            <span>30</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="updatePanelGrid" runat="server">
        <ContentTemplate>
            <div class="card card-body border-0 shadow table-wrapper table-responsive">
                <asp:GridView ID="GridMessages"
                    runat="server"
                    ItemType="AmazEng_WAPP.Models.Message"
                    DataKeyNames="Id"
                    SelectMethod="GridMessages_GetData"
                    OnRowDeleted="GridMessages_RowDeleted"
                    OnRowCommand="GridMessages_RowCommand"
                    AllowSorting="true"
                    AllowPaging="true" PageSize="10"
                    AutoGenerateColumns="false" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:DynamicField DataField="Id" />
                        <asp:DynamicField DataField="IssuerName" HeaderText="Issuer Name" />
                        <asp:DynamicField DataField="IssuerEmail" HeaderText="Issuer Email" />
                        <asp:DynamicField DataField="Subject" />
                        <asp:DynamicField DataField="SentAt" HeaderText="Sent At" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AdminViewMessageRoute", new {Id = Item.Id }) %>'>
                            <i class="fas fa-eye pe-2"></i></asp:HyperLink>
                                <asp:LinkButton ID="LinkButton1" runat="server"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CommandName="del"
                                    OnClientClick='return confirm("Are you sure to delete this item?");'><i class="fas fa-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        There is no message
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="pager-control" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
