<%@ Page Title="Explore" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="AmazEng_WAPP.Explore" %>
<%@ Register TagPrefix="my" TagName="IdiomCard" Src="~/Class/Controls/IdiomCard.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner Section Start -->
    <section class="banner-style-2 ">
        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-12">
                    <div class="banner-content text-center">
                        <span class="subheading">Knowledge is Power</span>
                        <h1 class="cd-headline clip is-full-width">Boost your
                        <span class="cd-words-wrapper">
                            <b class="is-visible">Writing Skills</b>
                            <b>Fluency</b>
                            <b>Creativity</b>
                        </span>
                        </h1>

                        <p>AmazEng is Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur risus erat, viverra nec ante eu, elementum luctus arcu. Fusce at.</p>

                        <div class="cta">
                            <a href="#" class="btn btn-white rounded ms-2">Get started </a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- / .row -->
        </div>
        <!-- / .container -->
    </section>
    <!-- Banner Section End -->
    <div class="container">
        <div class="row my-4">
            <div class="col-md-6 col-sm-12">
                <my:IdiomCard runat="server" IdiomId="1" CssClass="p-4"></my:IdiomCard>
            </div>
            <div class="col-md-6 col-sm-12">

            </div>
        </div>
    </div>
</asp:Content>
