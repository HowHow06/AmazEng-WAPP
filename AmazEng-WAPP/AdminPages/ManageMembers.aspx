<%@ Page Title="Members" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.ManageMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
        <div class="d-block mb-4 mb-md-0">
            <h2 class="h3 m-0">Members</h2>
        </div>
        <div class="btn-toolbar mb-2 mb-md-0 d-flex">
            <asp:HyperLink runat="server" NavigateUrl='<%$RouteUrl:RouteName=AdminNewMemberRoute%>' class="btn btn-sm btn-gray-800 d-inline-flex align-items-center">
                <svg class="icon icon-xs me-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6v6m0 0v6m0-6h6m-6 0H6"></path></svg>
                New
            </asp:HyperLink>
       <%--     <asp:Button class="btn btn-sm btn-outline-gray-600 ms-2" Text="Delete" runat="server" ID="btnDelete" disabled="disabled" />--%>
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
                    <input type="text" class="form-control" placeholder="Search members">
                </div>
            </div>
            <div class="col-4 col-md-2 col-xl-1 ps-md-0 text-end">
                <div class="dropdown">
                    <button class="btn btn-link text-dark dropdown-toggle dropdown-toggle-split m-0 p-1" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <svg class="icon icon-sm" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M11.49 3.17c-.38-1.56-2.6-1.56-2.98 0a1.532 1.532 0 01-2.286.948c-1.372-.836-2.942.734-2.106 2.106.54.886.061 2.042-.947 2.287-1.561.379-1.561 2.6 0 2.978a1.532 1.532 0 01.947 2.287c-.836 1.372.734 2.942 2.106 2.106a1.532 1.532 0 012.287.947c.379 1.561 2.6 1.561 2.978 0a1.533 1.533 0 012.287-.947c1.372.836 2.942-.734 2.106-2.106a1.533 1.533 0 01.947-2.287c1.561-.379 1.561-2.6 0-2.978a1.532 1.532 0 01-.947-2.287c.836-1.372-.734-2.942-2.106-2.106a1.532 1.532 0 01-2.287-.947zM10 13a3 3 0 100-6 3 3 0 000 6z" clip-rule="evenodd"></path></svg>
                        <span class="visually-hidden">Toggle Dropdown</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-xs dropdown-menu-end pb-0">
                        <span class="small ps-3 fw-bold text-dark">Show</span>
                        <a class="dropdown-item d-flex align-items-center fw-bold" href="#">10
                            <svg class="icon icon-xxs ms-auto" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg></a>
                        <a class="dropdown-item fw-bold" href="#">20</a>
                        <a class="dropdown-item fw-bold rounded-bottom" href="#">30</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card card-body border-0 shadow table-wrapper table-responsive">
        <asp:GridView ID="GridMembers" runat="server" ItemType="AmazEng_WAPP.Models.Member" DataKeyNames="Id"
            SelectMethod="GridMembers_GetData"
            OnRowDeleted="GridMembers_RowDeleted"
            onrowcommand="GridMembers_RowCommand"
            AutoGenerateColumns="false" BorderStyle="None" Width="100%">
            <Columns>
                <asp:DynamicField DataField="Id" />
                <asp:DynamicField DataField="Username" />
                <asp:DynamicField DataField="Name" />
                <asp:DynamicField DataField="Email" />
                <asp:TemplateField HeaderText="Verified">
                    <ItemTemplate>
                        <asp:Label Text='<%# Item.EmailVerifiedAt is object ? "Verified" : "Not Verified" %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verified">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AdminViewMemberRoute", new {Id = Item.Id }) %>'>
                            <i class="fas fa-eye pe-2"></i></asp:HyperLink>
                        <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AdminViewMemberRoute", new {Id = Item.Id , Mode = "Edit"}) %>'><i class="fas fa-pen-square pe-2"></i></asp:HyperLink>
                        <%--the link below will pass the item's Id as parameter to GridMembers_RowCommand with the Command name "delete"--%>
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            CommandArgument='<%# Eval("Id") %>'
                            CommandName="del"
                            OnClientClick='return confirm("Are you sure to delete this item?");'
                            ><i class="fas fa-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="row alert alert-warning alert-dismissable fade in" style="margin-bottom: 0px">
                    There are no items in your shopping cart
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
