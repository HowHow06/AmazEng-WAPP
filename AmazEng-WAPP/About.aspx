<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AmazEng_WAPP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner Section Start -->
    <section class="banner-style-2 ">
        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-12">
                    <div class="banner-content text-center">
                        <h1 class="cd-headline clip is-full-width">About</h1>
                    </div>
                </div>
            </div>
            <!-- / .row -->
        </div>
        <!-- / .container -->
    </section>
    <!-- Banner Section End -->

       <!-- Welcome to AmazEng Start -->
    <section class="features section-padding ">
        <div class="container">
            <div class="row align-items-center justify-content-end mb-50">
                <div class="col-xl-6 pe-xl-5 col-lg-6">
                    <span class="subheading">What do we do?</span>
                        <h2 class="mb-20 font-lg">Welcome to AmazEng </h2>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis recusandae reiciendis cumque, sequi vitae illum dolorem</p>
                    
                </div>

                <div class="col-xl-6 col-lg-6 ">
                    <div class="section-heading mt-5 mt-lg-0 mb-4">
                        <img src="assets/images/feature-image.jpg" alt="" class="img-fluid">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Welcome to AmazEng Section END -->

        <!--  Our goal Section -->

    <section class="course-wrapper section-padding-btm">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-8">
                    <div class="section-heading mb-70 text-center">
                        <h2 class="font-lg">Our goal</h2>
                    </div>
                </div>
            </div>

            <div class="col">
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-1 mb-4 mb-lg-0">
                            <i class="flaticon-man"></i>
                            <div class="count">
                            <span>Availability</span>
                            </div>
                            <p>Provide the best english learning platform for everyone, everywhere</p>
                        </div>
                    </div>

                    

                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-3">
                            <i class="flaticon-satisfaction"></i>
                            <div class="count">
                                <span>Quality</span>
                            </div>
                            <p>Advanced learning experience with the personalised contents</p>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="counter-box bg-2 mb-4 mb-lg-0">
                            <i class="flaticon-infographic"></i>
                            <div class="count">
                                <span>Adoptability</span>
                            </div>
                            <p>Keep enhancing the contents based on the feedback</p>
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
                        <p class="quote-text py-5">We belive that learning new things will bring you the opportunity to make a difference.</p>
                        <p class="choose-option">- The AmazEng Team</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Our Quote End -->

</asp:Content>
