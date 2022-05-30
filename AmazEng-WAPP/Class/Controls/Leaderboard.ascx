<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Leaderboard.ascx.cs" Inherits="AmazEng_WAPP.Class.Controls.Leaderboard" %>
<div class="<%= this.CssClass %>">
    <span class="h4 mb-1">Leaderboard</span>
    <asp:GridView ID="GridLeaderboard"
        runat="server"
        ItemType="AmazEng_WAPP.Models.Member"
        SelectMethod="GridLeaderboard_GetData"
        AllowSorting="false"
        AllowPaging="true" PageSize="10"
        AutoGenerateColumns="false" BorderStyle="None" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="Username" />
            <asp:TemplateField HeaderText="Points">
                <ItemTemplate>
                    <span><%# Item.BrowsedIdiomCount %></span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            There is no member
        </EmptyDataTemplate>
        <PagerStyle CssClass="pager-control" />
    </asp:GridView>
</div>

