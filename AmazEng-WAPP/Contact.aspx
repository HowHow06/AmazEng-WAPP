<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AmazEng_WAPP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner Section Start -->
    <section class="banner-style-2 ">
        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-12">
                    <div class="banner-content text-center">
                        <h1 class="cd-headline clip is-full-width">Contact Us</h1>
                    </div>
                </div>
            </div>
            <!-- / .row -->
        </div>
        <!-- / .container -->
    </section>
    <!-- Banner Section End -->


    <!-- test here -->
    <section class="features section-padding ">
        <div class="row justify-content-center mb-50">
            <div class="col-xl-3 col-md-6 ">
                <div class="card h-100">
                    <div class="card-body d-flex flex-column">
                        <h1>Leave Us A Message</h1>
                        <div class="flex-grow-1">
                        <ul class="list-group h-100">
                            <li class="list-group-item flex-fill">Email: TP055278@mail.apu.edu.my</li>
                            <li class="list-group-item flex-fill">Phone: 01121101456</li>
                            <li class="list-group-item flex-fill">Address: 3A, Jalan Ayam Goreng, KFC</li>
                        </ul>
                            </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-7 col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Name&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                </p>
                            </div>
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Email&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                </p>
                            </div>

                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Subject&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtSubject" runat="server" placeholder="Subject"></asp:TextBox>
                                </p>
                            </div>
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Message&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtMessage" runat="server" placeholder="Message" TextMode="MultiLine"></asp:TextBox>
                                </p>
                            </div>
                            <p class="form-row form-row-wide d-grid">
                                <asp:Button class="button" Text="Submit" runat="server" ID="btnSubmit" onclick="btnSubmit_Click"/>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- end here -->
</asp:Content>
