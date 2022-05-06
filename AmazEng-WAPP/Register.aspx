<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AmazEng_WAPP.Register" %>

<%--<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Empty.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AmazEng_WAPP.Register" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Assets/css/auth.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="woocommerce single page-wrapper">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-8 col-xl-7">

                    <div class="signup-form">
                        <div class="form-header">
                            <h2 class="font-weight-bold mb-3">Sign Up</h2>
                            <p class="woocommerce-register">
                                Already have an account? <a href="login" class="text-decoration-underline">Log in</a>
                            </p>
                        </div>

                        <form method="post" class="woocommerce-form woocommerce-form-register register">

                            <div class="row">
                                <div class="col-xl-12">
                                    <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                        <label>Name&nbsp;<span class="required">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                    </p>
                                </div>
                                <div class="col-xl-6">
                                    <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                        <label>Username&nbsp;<span class="required">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                                    </p>
                                </div>

                                <div class="col-xl-6">
                                    <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                        <label>Email&nbsp;<span class="required">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                    </p>
                                </div>

                                <div class="col-xl-12">
                                    <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                        <label>Password&nbsp;<span class="required">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </p>
                                </div>
                                <div class="col-xl-12">
                                    <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                        <label>Re-Enter Password&nbsp;<span class="required">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtRePassword" runat="server" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>
                                    </p>
                                </div>

                                <div class="col-xl-12">
                                    <div class="d-flex align-items-center justify-content-between py-2">
                                        <p class="form-row">
                                            <label class="woocommerce-form__label woocommerce-form__label-for-checkbox woocommerce-form-login__policy">
                                                <asp:CheckBox class="woocommerce-form__input woocommerce-form__input-checkbox auth-checkbox" ID="ckbTerms" runat="server" Text="Accept the Terms and Privacy Policy" />
                                            </label>
                                        </p>

                                        <p class="woocommerce-LostPassword lost_password">
                                            <a href="forgot">Forgot password?</a>
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <p class="woocommerce-FormRow form-row">
                                <asp:Button class="woocommerce-button button" Text="Register" runat="server" ID="btnRegister" />
                            </p>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
