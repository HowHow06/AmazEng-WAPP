<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="AmazEng_WAPP.Result" %>

<%@ Register TagPrefix="my" TagName="IdiomCard" Src="~/Class/Controls/IdiomCard.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:GridView ID="GridIdioms"
            runat="server"
            ItemType="AmazEng_WAPP.Models.Idiom"
            DataKeyNames="Id"
            SelectMethod="GridIdioms_GetData"
            AllowSorting="true"
            AllowPaging="true" PageSize="7"
            AutoGenerateColumns="false" BorderStyle="None" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <my:IdiomCard runat="server" IdiomId='<%Eval("Id") %>'' CssClass="p-4 my-4"></my:IdiomCard>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                There is no member
            </EmptyDataTemplate>
            <PagerStyle CssClass="pager-control" />
        </asp:GridView>
    </div>

</asp:Content>
