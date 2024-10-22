﻿<%@ Page Title="Manage Profile" Language="C#" MasterPageFile="~/NestedMemberManage.master" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="AmazEng_WAPP.ManageProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainInnerContent" runat="server">
    <div class="col-md-12">
        <h3>Edit Profile</h3>
        <hr />
        <div class="col-xl-12 col-md-6">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Username&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Name" ReadOnly></asp:TextBox>
                                </p>
                            </div>

                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Name&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="name here" TextMode="SingleLine"></asp:TextBox>
                                </p>
                            </div>

                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <label>Email&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Subject" TextMode="Email"></asp:TextBox>
                                </p>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="col-xl-12">
                                <p class="form-row form-row-wide">
                                    <asp:Image Width="100" Height="30%" Style="border-radius: 50%" ID="imgProfilePicture" ImageUrl="https://via.placeholder.com/400x400" runat="server" />
                                    <asp:FileUpload ID="txtImageUpload" runat="server"  CssClass="form-control"/>
                                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                        CssClass="invalid-feedback"
                                        Display="Dynamic"
                                        ControlToValidate="txtImageUpload"
                                        ErrorMessage="Only JPEG or PNG images are allowed"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|PNG)$">
                                    </asp:RegularExpressionValidator>
                                </p>
                            </div>

                        </div>
                        <p class="form-row form-row-wide d-grid">
                            <div class="row mb-2">
                                <asp:LinkButton runat="server" ID="btnSubmitReport" OnClick="btnSubmit_Click">
            <span id="btnClientReportSubmit" type="submit" class="btn btn-main rounded btn-sm">Submit</span>
                                </asp:LinkButton>
                                <%--<asp:Button class="button col-xl-3" Text="Cancel" runat="server" ID="btnCancel" />--%>
                                <%--<asp:Button class="btn btn-main rounded btn-sm" Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />--%>
                            </div>
                        </p>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        const image_input = document.querySelector("#MainContent_MainInnerContent_txtImageUpload");
        image_input.addEventListener("change", function () {
            const uploadElement = $("#MainContent_MainInnerContent_txtImageUpload");
            const imgTempUrl = window.URL.createObjectURL(uploadElement[0].files[0]);
            document.getElementById('MainContent_MainInnerContent_imgProfilePicture').src = imgTempUrl;
            return false;
        })
    </script>
</asp:Content>
