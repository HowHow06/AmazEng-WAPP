<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="AmazEng_WAPP.Forgot" %>

<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Empty.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="AmazEng_WAPP.Forgot" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page-wrapper woocommerce single">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 col-xl-5">
                    <div class="login-form card">
                        <div class="form-header">
                            <h2 class="font-weight-bold mb-3">Forgot Password</h2>
                            <p class="woocommerce-register">
                                Remember your password? <a href="login" class="text-decoration-underline">Back to login</a>
                            </p>
                        </div>
                        <div class="woocommerce-form woocommerce-form-login login" method="post">
                            <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                <label for="username">
                                    Enter your registered email&nbsp;
                                    <i class="fal fa-info-circle" data-bs-toggle="tooltip" title="A password recovery email will be sent to this mailbox if it is valid"></i>

                                </label>
                                <asp:TextBox class="woocommerce-Input woocommerce-Input--text input-text form-control" ID="txtEmail" runat="server" autocomplete="email" ToolTip="Registered Email" placeholder="Email"></asp:TextBox>
                            </p>
                            <p class="form-row">
                                <asp:Button ID="btnSubmit" class="woocommerce-button button woocommerce-form-login__submit" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
