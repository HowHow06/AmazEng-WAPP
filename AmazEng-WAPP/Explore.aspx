﻿<%@ Page Title="Explore" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="AmazEng_WAPP.Explore" %>

<%@ Register TagPrefix="my" TagName="IdiomCard" Src="~/Class/Controls/IdiomCard.ascx" %>
<%@ Register TagPrefix="my" TagName="Leaderboard" Src="~/Class/Controls/Leaderboard.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner Section Start -->
        <section class="banner-style-2 ">
            <div class="container">
                <div class="row align-items-center justify-content-center">
                    <div class="col-12">
                        <div class="banner-content text-center">

                            <asp:UpdatePanel ID="udpIdiomOfTheDay" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <span class="subheading">Idiom of the day</span>
                                    <h1 class="cd-headline clip is-full-width">
                                        <asp:UpdateProgress runat="server">
                                            <ProgressTemplate>loading...</ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <div runat="server" id="divIdiomOfTheDay">
                                            <asp:Literal runat="server" ID="lblIdiomOfTheDay"></asp:Literal>
                                            <div class="d-inline">
                                                <asp:LinkButton ID="btnRegenerateIdiom" OnClick="btnRegenerateIdiom_Click" ToolTip="Change an idiom" runat="server">
                                                <asp:Image Width="120px" ImageUrl="~/Assets/images/autorenew-white.svg" runat="server" />
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                    </h1>
                                    <div runat="server" id="divIdiomOfTheDayMeaning">
                                        <p>
                                            <asp:Literal runat="server" ID="lblIdiomMeaning"></asp:Literal>
                                        </p>
                                    </div>
                                    <div class="topbar-search mx-auto mt-4" style="max-width: 550px">
                                        <%--<a href="#" class="btn btn-white rounded ms-2">Get started </a>--%>
                                        <input type="text" placeholder="Search Idioms" class="form-control">
                                        <label><i class="fa fa-search"></i></label>
                                    </div>
                                    <p runat="server" id="lblViewCountStatement" class="mt-3" visible="false">
                                        You viewed
                            <asp:Literal ID="lblViewCount" runat="server"></asp:Literal>
                                        idiom(s) today.
                                    </p>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnRegenerateIdiom" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <!-- / .row -->
            </div>
            <!-- / .container -->
        </section>
        <!-- Banner Section End -->
        <div class="container">
            <div class="row my-4 justify-content-evenly">
                <div class="col-md-5 col-sm-12">
                    <%--<my:IdiomCard runat="server" IdiomId='1' CssClass="p-4 my-4"></my:IdiomCard>--%>
                    <asp:Repeater ID="repeaterIdioms"
                        runat="server"
                        ItemType="AmazEng_WAPP.Models.Idiom">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <my:IdiomCard runat="server" IdiomId='<%# Eval("Id")%>' CssClass="p-4 my-4"></my:IdiomCard>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="vr col-md-1 col-sm-0"></div>
                <div class="col-md-5 col-sm-12">
                    <my:Leaderboard runat="server" CssClass="p-4 my-2" />
                </div>
            </div>
        </div>
        <script>   
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(
                function (sender, args) {
                    $get("<%=divIdiomOfTheDay.ClientID %>").style.display = "none";
                $get("<%=divIdiomOfTheDayMeaning.ClientID %>").style.display = "none";
            }
        );
            prm.add_endRequest(
                function (sender, args) {
                    $get("<%=divIdiomOfTheDay.ClientID %>").style.display = "";
                $get("<%=divIdiomOfTheDayMeaning.ClientID %>").style.display = "";
            }
        );

        </script>
</asp:Content>
