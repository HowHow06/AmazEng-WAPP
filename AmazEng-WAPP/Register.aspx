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
                            <h2 class="font-weight-bold mb-3">Register</h2>
                            <p class="woocommerce-register">
                                Already have an account? <a href="login" class="text-decoration-underline">Log in</a>
                            </p>
                        </div>
                        <div class="row">
                            <div class="col-xl-12">
                                <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                    <label>Name&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                </p>
                                <asp:RequiredFieldValidator CssClass="invalid-feedback" Display="Dynamic" ErrorMessage="This field is required." ControlToValidate="txtName" runat="server" />
                                <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" runat="server" ErrorMessage="Invalid name input." ControlToValidate="txtName"
                                    ValidationExpression="^[A-Za-z ,.'-]+$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-xl-6" id="usernameField" runat="server">
                                <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                    <label>Username&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                                </p>
                                <asp:RequiredFieldValidator CssClass="invalid-feedback" Display="Dynamic" ErrorMessage="This field is required." ControlToValidate="txtUsername" runat="server" />
                                <asp:CustomValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*This username is used by other member."
                                    ID="validatorUsername"
                                    ControlToValidate="txtUsername"
                                    OnServerValidate="validatorUsername_ServerValidate"
                                    runat="server"></asp:CustomValidator>
                            </div>
                            <div class="col-xl-6" runat="server" id="emailField">
                                <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                    <label>Email&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                </p>
                                <asp:RequiredFieldValidator CssClass="invalid-feedback" Display="Dynamic" ErrorMessage="This field is required." ControlToValidate="txtEmail" runat="server" />
                                <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Invalid field input." ControlToValidate="txtEmail"
                                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                                <asp:CustomValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*This email is used by other member."
                                    ID="validatorEditEmail"
                                    ControlToValidate="txtEmail"
                                    OnServerValidate="validatorEditEmail_ServerValidate"
                                    runat="server"></asp:CustomValidator>
                            </div>

                            <div class="col-xl-12">
                                <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                    <label>Password&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </p>
                                <asp:RequiredFieldValidator CssClass="invalid-feedback" Display="Dynamic" ErrorMessage="This field is required." ControlToValidate="txtPassword" runat="server" />
                            </div>
                            <div class="col-xl-12">
                                <p class="woocommerce-form-row woocommerce-form-row--wide form-row form-row-wide">
                                    <label>Re-Enter Password&nbsp;<span class="required">*</span></label>
                                    <asp:TextBox class="form-control" ID="txtRePassword" runat="server" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>
                                </p>
                                <asp:RequiredFieldValidator CssClass="invalid-feedback" Display="Dynamic" ErrorMessage="This field is required." ControlToValidate="txtRePassword" runat="server" />
                                <asp:CompareValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*Please make sure both passwords are the same"
                                    ControlToValidate="txtPassword"
                                    ControlToCompare="txtRePassword"
                                    Operator="Equal"
                                    runat="server" />
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
                            <asp:Button class="woocommerce-button button" Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
