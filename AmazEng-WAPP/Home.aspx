﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AmazEng_WAPP.Home" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="/Assets/css/home.css">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    <!-- Learn Idiom With Us Section Start -->
    <section class="features section-padding ">
        <div class="container">
            <div class="row align-items-center justify-content-end mb-50">
                <div class="col-xl-6 pe-xl-5 col-lg-6">
                    <img src="assets/images/feature-image.jpg" alt="" class="img-fluid">
                </div>

                <div class="col-xl-6 col-lg-6 ">
                    <div class="section-heading mt-5 mt-lg-0 mb-4">
                        <span class="subheading">Know the ropes, learn the ropes</span>
                        <h2 class="mb-20 font-lg">Learn Idioms With Us </h2>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis recusandae reiciendis cumque, sequi vitae illum dolorem</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Learn Idiom With Us Section END -->
    <!--  Why Us Section -->

    <section class="course-wrapper section-padding-btm">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-8">
                    <div class="section-heading mb-70 text-center">
                        <h2 class="font-lg">Why Us?</h2>
                        <p>The most reliable and efficient way of learning.</p>
                    </div>
                </div>
            </div>

            <div class="col">
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-1 mb-4 mb-lg-0">
                            <i class="flaticon-man"></i>
                            <div class="count">
                                <span class="counter h2">200</span>
                            </div>
                            <p>Members</p>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-2 mb-4 mb-lg-0">
                            <i class="flaticon-infographic"></i>
                            <div class="count">
                                <span class="counter h2">1000</span><span>+</span>
                            </div>
                            <p>Idioms and Sayings</p>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-3">
                            <i class="flaticon-satisfaction"></i>
                            <div class="count">
                                <span class="counter h2">100</span><span>%</span>
                            </div>
                            <p>Satisfaction</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!--  Why Us Section End -->

    <!-- Our Quote Start -->
    <section class="choose-area pb-60 pt-60">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="choose-content text-center pt-5">
                        <div class="quote-icon">
                            <i class="fas fa-quote-left fa-2x"></i>
                        </div>
                        <p class="quote-text py-5">We belive that Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus blandit.</p>
                        <p class="choose-option">- The AmazEng Team</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Our Quote End -->

    <!-- Get in touch Section Start -->
    <section class="features section-padding ">
        <div class="container">
            <div class="row align-items-center justify-content-end mb-50">
                <div class="col-xl-6 col-lg-6 ">
                    <div class="section-heading mt-5 mt-lg-0 mb-4">
                        <h2 class="mb-60 font-lg">Get In Touch With Us!</h2>
                        <a href="#" class="btn btn-main rounded btn-cta">Contact Us<i class="fa fa-angle-right"></i></a>
                    </div>
                </div>
                <div class="col-xl-6 pe-xl-5 col-lg-6">
                    <img src="assets/images/contact-us.jpg" alt="" class="img-fluid">
                </div>

            </div>
        </div>
    </section>
    <!-- Get in touch Section END -->
</asp:Content>
