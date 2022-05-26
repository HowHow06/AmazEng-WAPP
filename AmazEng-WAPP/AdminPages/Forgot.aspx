<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/AdminPages/Site.Auth.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.AdminForgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-lg-100 mt-5 mt-lg-0 bg-soft d-flex align-items-center">
        <div class="container">
            <div class="row justify-content-center form-bg-image">
                <p class="text-center">
                    <a href="./login" class="d-flex align-items-center justify-content-center">
                        <svg class="icon icon-xs me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M7.707 14.707a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 1.414L5.414 9H17a1 1 0 110 2H5.414l2.293 2.293a1 1 0 010 1.414z" clip-rule="evenodd"></path></svg>
                        Back to log in
                    </a>
                </p>
                <div class="col-12 d-flex align-items-center justify-content-center">
                    <div class="signin-inner my-3 my-lg-0 bg-white shadow border-0 rounded p-4 p-lg-5 w-100 fmxw-500">
                        <div class="text-center text-md-center mb-4 mt-md-0">
                            <h1 class="h3">Forgot password</h1>
                            <p class="mb-4">Type in your email to reset your password!</p>
                        </div>

                        <!-- Form -->
                        <div class="mb-4">
                            <label for="email">Your Email</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="example@email.com" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                        <!-- End of Form -->
                        <div class="d-grid">
                            <asp:Button Text="Recover password" runat="server" class="btn btn-gray-800" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
