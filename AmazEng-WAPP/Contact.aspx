<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AmazEng_WAPP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner Section Start -->
    <section class="page-header">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-8">
                    <div class="title-block">
                        <h1>Contact Us</h1>
                        <p>Feel free to contact us with the method below.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Banner Section End -->


    <!-- Leave us a message + form start -->
    <section class="features section-padding ">
        <div class="row justify-content-center mb-50">
            <div class="col-xl-3 col-md-6 ">
                <div class="card h-100">
                    <img src="Assets\images\message.png" class="card-img-top" alt="...">
                    <div class="card-header px-4">
                        <h3 class="my-0 font-weight-normal">Leave Us <br />
                            A Message</h3>
                    </div>
                    <div class="card-body d-flex flex-column  px-4">
                        <ul class="list-unstyled mt-3 mb-4">
                            <li class="fs-5"><i class="fas fa-envelope"></i><a href="mailto:TP055278@mail.apu.edu.my" class="ps-2" style="color:inherit">TP055278@mail.apu.edu.my </a></li>
                            <hr />
                            <li class="fs-5"><i class="fas fa-phone"></i><a href="tel:+60111111111" class="ps-2"  style="color:inherit">+60111111111</a></li>
                            <hr />
                            <li class="fs-5"><i class="fas fa-location-dot"></i><span class="ps-2" > 36 Tingkat 3 Persiaran 65C Off Jalan Pahang Barat, 57000 Kuala Lumpur</span>
                               </li>
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
                                    <label>Name&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="rfName" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                </p>
                            </div>
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Email&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                </p>
                            </div>

                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Subject&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtSubject" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox class="form-control" ID="txtSubject" runat="server" placeholder="Subject"></asp:TextBox>
                                </p>
                            </div>
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Message&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtMessage" ForeColor="Red"></asp:RequiredFieldValidator>
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
