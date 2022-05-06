<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmazEng_WAPP.Login" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Empty.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmazEng_WAPP.Login" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Assets/css/auth.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page-wrapper woocommerce single">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6 col-xl-5">
                <div class="login-form card">
                    <div class="form-header">
                        <h2 class="font-weight-bold mb-3">Login</h2>
    
                        <p class="woocommerce-register">
                            Don't have an account yet? <a href="register" class="text-decoration-underline">Register for Free</a>
                        </p>
                    </div>
                    <div class="woocommerce-form woocommerce-form-login login" method="post">
                        <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                            <label for="username">Username or email address&nbsp;<span class="required">*</span></label>
                            <asp:TextBox class="woocommerce-Input woocommerce-Input--text input-text form-control" ID="txtUsername" runat="server" autocomplete="username" ToolTip="Username" placeholder="Username or Email"></asp:TextBox>
                        </p>
                        <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                            <label for="password">Password&nbsp;<span class="required">*</span></label>
                            <asp:TextBox class="woocommerce-Input woocommerce-Input--text input-text form-control" ID="txtPassword" runat="server" autocomplete="current-password" ToolTip="Password" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </p>
                       
                       <div class="d-flex align-items-center justify-content-between py-2">
                            <p class="form-row">
                                <label class="woocommerce-form__label woocommerce-form__label-for-checkbox woocommerce-form-login__rememberme">
                                    <asp:CheckBox class="woocommerce-form__input woocommerce-form__input-checkbox auth-checkbox" ID="ckbRememberMe" runat="server" Text="Remember me" />
                                </label>
                            </p>
    
                            <p class="woocommerce-LostPassword lost_password">
                                <a href="forgot">Forgot password?</a>
                            </p>
                       </div>
    
                       <p class="form-row">
                           <asp:Button ID="btnLogin" class="woocommerce-button button woocommerce-form-login__submit" runat="server" Text="Log in" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
