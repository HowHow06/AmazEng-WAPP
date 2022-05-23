<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AmazEng_WAPP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/Assets/css/home.css">
    <link rel="stylesheet" href="/Assets/css/meetourteam.css">
    <!-- Banner Section Start -->

    </section>
     <section class="page-header">
         <div class="container">
             <div class="row justify-content-center">
                 <div class="col-lg-8 col-xl-8">
                     <div class="title-block">
                         <h1>About Us</h1>
                     </div>
                 </div>
             </div>
         </div>
     </section>
    <!-- Banner Section End -->

    <!-- Welcome to AmazEng Start -->
    <section class="features section-padding ">
        <div class="container">
            <div class="row align-items-center justify-content-end mb-50">
                <div class="col-xl-6 pe-xl-5 col-lg-6">
                    <span class="subheading">What do we do?</span>
                    <h2 class="mb-20 font-lg">Welcome to AmazEng </h2>
                    <p>We provide an online platform for anyone to access and learn English idioms.</p>

                </div>

                <div class="col-xl-6 col-lg-6 ">
                    <div class="section-heading mt-5 mt-lg-0 mb-4">
                        <img src="assets/images/feature-image-2.jpg" alt="" class="img-fluid">
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
                <div class="col-xl-3 col-md-6">
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
                        <p class="quote-text py-5">Learning new things will bring you the opportunity to make the difference.</p>
                        <p class="choose-option">- The AmazEng Team</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Our Quote End -->


    <!-- Meet Our Team Start -->
    <div class="container text-center mt-5 mb-2">
        <h1 class="mb-0">Meet Our Team</h1>
    </div>
    <div class="container mt-3">
        <div class="row">
            <div class="col-md-3">
                <div class="bg-white p-3 text-center rounded box h-100">
                    <img class="img-responsive rounded-circle" src="assets/images/howard.jpg" width="150">
                    <h5 class="mt-3 name">Leader</h5>
                    <span class="work d-block">Howard Lim</span>
                    <div class="mt-4 about"><span>Use your loaf.</span></div>
                    <div class="mt-4">
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="bg-white p-3 text-center rounded box h-100">
                    <img class="img-responsive rounded-circle" src="assets/images/meet-our-team-jane.jpg" width="150">
                    <h5 class="mt-3 name">Developer</h5>
                    <span class="work d-block">Rin Mirakumi</span>
                    <div class="mt-4 about"><span>Her Quote</span></div>
                    <div class="mt-4">
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="bg-white p-3 text-center rounded box h-100">
                    <img class="img-responsive rounded-circle" src="assets/images/meet-our-team-mike.jpg" width="150">
                    <h5 class="mt-3 name">Developer</h5>
                    <span class="work d-block">Loh Kae Shyan</span>
                    <div class="mt-4 about"><span>His Quote</span></div>
                    <div class="mt-4">
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="bg-white p-3 text-center rounded box h-100">
                    <img class="img-responsive rounded-circle" src="assets/images/meet-our-team-marry.jpg" width="150">
                    <h5 class="mt-3 name">Developer</h5>
                    <span class="work d-block">Mohin</span>
                    <div class="mt-4 about"><span>His Quote</span></div>
                    <div class="mt-4">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Meet Our Team End -->


</asp:Content>
