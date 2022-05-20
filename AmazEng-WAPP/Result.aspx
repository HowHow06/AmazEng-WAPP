<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="AmazEng_WAPP.Result" %>

<%@ Register TagPrefix="my" TagName="IdiomCard" Src="~/Class/Controls/IdiomCard.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mb-100">
        <div class="h6 mt-3">
            <asp:Literal runat="server" ID="lblResultCount" />
        </div>
        <asp:GridView ID="GridIdioms"
            runat="server"
            ItemType="AmazEng_WAPP.Models.Idiom"
            DataKeyNames="Id"
            AllowPaging="true" PageSize="7"
            OnDataBound="GridIdioms_DataBound"
            SelectMethod="GridIdioms_GetData"
            AutoGenerateColumns="false" BorderStyle="None" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <my:IdiomCard runat="server" IdiomId='<%# Eval("Id") %>' CssClass="p-4 my-2"></my:IdiomCard>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                There is no idiom
            </EmptyDataTemplate>
            <PagerStyle CssClass="pager-control" />
            <PagerSettings Mode="NumericFirstLast"
                FirstPageText="First"
                LastPageText="Last"
                Position="Bottom" />
        </asp:GridView>
    </div>
</asp:Content>
