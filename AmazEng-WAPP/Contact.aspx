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


    <!-- Leave us a message + form start -->
    <section class="features section-padding ">
        <div class="row justify-content-center mb-50">
            <div class="col-xl-3 col-md-6 ">
                <div class="card h-100">
                    <img src="Assets\images\message.png" class="card-img-top" alt="...">
                    <div class="card-header">
                        <h3 class="my-0 font-weight-normal">Leave Us A Message</h3>
                    </div>
                    <div class="card-body d-flex flex-column">
                        <ul class="list-unstyled mt-3 mb-4">
                            <li class="fs-5">Email: <a href="mailto:TP055278@mail.apu.edu.my">TP055278@mail.apu.edu.my </a></li>
                            <li class="fs-5">Phone: +601121101456</li>
                            <li class="fs-5">Address: 3A, Jalan Ayam Goreng, KFC</li>
                        </ul>

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
                                <asp:Button class="button" Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- leave us a message + form end -->


</asp:Content>
