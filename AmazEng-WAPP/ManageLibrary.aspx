<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMemberManage.master" AutoEventWireup="true" CodeBehind="ManageLibrary.aspx.cs" Inherits="AmazEng_WAPP.ManageLibrary" %>

<%@ Register TagPrefix="my" TagName="IdiomCard" Src="~/Class/Controls/IdiomCard.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainInnerContent" runat="server">

    <ul class="nav nav-tabs" id="libraryTabs" role="tablist">
        <li class="nav-item" role="presentation">
            <button class="nav-link active" id="history-tab" data-bs-toggle="tab" data-bs-target="#history" type="button" role="tab" aria-controls="history" aria-selected="true">
                History
            </button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="favourite-tab" data-bs-toggle="tab" data-bs-target="#favourite" type="button" role="tab" aria-controls="favourite" aria-selected="false">
                Favourite
            </button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="learnlater-tab" data-bs-toggle="tab" data-bs-target="#learnlater" type="button" role="tab" aria-controls="learnlater" aria-selected="false">
                Learn Later
            </button>
        </li>
    </ul>
    <div class="tab-content" id="myTabContent">
        <div class="tab-pane fade show active" id="history" role="tabpanel" aria-labelledby="history-tab">
            <%-- history code start here --%>
            <div class="container mb-100">
                <div class="h6 mt-3">
                    <asp:Literal runat="server" ID="lblHistoryCount" />
                </div>
                <asp:GridView ID="GridHistory"
                    runat="server"
                    ItemType="AmazEng_WAPP.Models.Idiom"
                    DataKeyNames="Id"
                    AllowPaging="true" PageSize="3"
                    OnDataBound="GridHistory_DataBound"
                    SelectMethod="GridHistory_GetData"
                    AutoGenerateColumns="false" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <my:IdiomCard runat="server" IdiomId='<%# Eval("Id") %>' CssClass="p-4 my-2"></my:IdiomCard>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>

                        <div cssclass="card p-4 my-2">
                            There is no idiom
                        </div>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="pager-control" />
                    <PagerSettings Mode="NumericFirstLast"
                        FirstPageText="First"
                        LastPageText="Last"
                        Position="Bottom" />
                </asp:GridView>
            </div>
            <%-- history code end here --%>
        </div>
        <div class="tab-pane fade" id="favourite" role="tabpanel" aria-labelledby="favourite-tab">
            <%-- favourite code start here --%>

            <div class="container mb-100">
                <div class="h6 mt-3">
                    <asp:Literal runat="server" ID="lblFavouriteCount" />
                </div>
                <asp:GridView ID="GridFavourite"
                    runat="server"
                    ItemType="AmazEng_WAPP.Models.Idiom"
                    DataKeyNames="Id"
                    AllowPaging="true" PageSize="3"
                    OnDataBound="GridFavourite_DataBound"
                    SelectMethod="GridFavourite_GetData"
                    AutoGenerateColumns="false" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <my:IdiomCard runat="server" IdiomId='<%# Eval("Id") %>' CssClass="p-4 my-2"></my:IdiomCard>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div cssclass="card p-4 my-2">
                            There is no idiom
                        </div>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="pager-control" />
                    <PagerSettings Mode="NumericFirstLast"
                        FirstPageText="First"
                        LastPageText="Last"
                        Position="Bottom" />
                </asp:GridView>
            </div>
            <%-- favourite code end here --%>
        </div>
        <div class="tab-pane fade" id="learnlater" role="tabpanel" aria-labelledby="learnlater-tab">
            <%-- learn later start here --%>
            <div class="container mb-100">
                <div class="h6 mt-3">
                    <asp:Literal runat="server" ID="lblLearnLaterCount" />
                </div>
                <asp:GridView ID="GridLearnLater"
                    runat="server"
                    ItemType="AmazEng_WAPP.Models.Idiom"
                    DataKeyNames="Id"
                    AllowPaging="true" PageSize="3"
                    OnDataBound="GridLearnLater_DataBound"
                    SelectMethod="GridLearnLater_GetData"
                    AutoGenerateColumns="false" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <my:IdiomCard runat="server" IdiomId='<%# Eval("Id") %>' CssClass="p-4 my-2"></my:IdiomCard>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div cssclass="card p-4 my-2">
                            There is no idiom
                        </div>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="pager-control" />
                    <PagerSettings Mode="NumericFirstLast"
                        FirstPageText="First"
                        LastPageText="Last"
                        Position="Bottom" />
                </asp:GridView>
            </div>
            <%-- learn later end here --%>
        </div>
    </div>
</asp:Content>
