<%@ Page Title="Login" Language="C#" MasterPageFile="~/AdminPages/Site.Auth.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-lg-100 mt-5 mt-lg-0 bg-soft d-flex align-items-center">
        <div class="container">
            <p class="text-center">
                <a href="/" class="d-flex align-items-center justify-content-center">
                    <svg class="icon icon-xs me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd" d="M7.707 14.707a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 1.414L5.414 9H17a1 1 0 110 2H5.414l2.293 2.293a1 1 0 010 1.414z" clip-rule="evenodd"></path></svg>
                    Back to homepage
                </a>
            </p>
            <div class="row justify-content-center form-bg-image" 
               <%-- data-background-lg="../../assets/img/illustrations/signin.svg"--%>
                >
                <div class="col-12 d-flex align-items-center justify-content-center">
                    <div class="bg-white shadow border-0 rounded border-light p-4 p-lg-5 w-100 fmxw-500">
                        <div class="text-center text-md-center mb-4 mt-md-0">
                            <h1 class="mb-0 h3">Admin Sign In</h1>
                        </div>
                        <!-- Form -->
                        <div class="form-group mb-4">
                            <label for="email">Username or Email</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtLoginKey" runat="server" class="form-control" placeholder="Username or email" ></asp:TextBox>
                            </div>
                        </div>
                        <!-- End of Form -->
                        <div class="form-group">
                            <!-- Form -->
                            <div class="form-group mb-4">
                                <label for="password">Password</label>
                                <div class="input-group">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <!-- End of Form -->
                            <div class="d-flex justify-content-between align-items-top mb-4">
                                <div class="form-check">
                                    <asp:CheckBox class="form-check-input-webform" ID="ckbRemember" runat="server" Text=""/>
                                   
                                    <label class="form-check-label mb-0" for="remember">
                                        Remember me
                                    </label>
                                </div>
                                <div><a href="./forgot" class="small text-right">Forgot password?</a></div>
                            </div>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnAdminLogin" Text="Sign in" runat="server" class="btn btn-gray-800" OnClick="btnAdminLogin_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
