<%@ Page Title="Manage Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="AmazEng_WAPP.ManageProfile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mb-2">
        <div class="col-md-3">

            <div class="card">
                <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                    <div class="col-auto d-none d-lg-block">
                        <img style="border-radius: 50%" height="250" width="250" src="/Assets/images/NA.jpg" alt="profile pic here" />

                    </div>
                    <div class="col p-4 d-flex flex-column position-static">
                        <h1>user</h1>
                        <h6>username</h6>
                    </div>

                </div>
            </div>

            <nav class="nav flex-column">
                <a class="button mb-1" href="#">Manage Profile</a>
                <a class="button mb-1" href="#">Manage Library</a>
                <a class="button mb-1" href="#">Change Password</a>
                <a class="button mb-1" href="#">Logout</a>
            </nav>
        </div>
        <div class="col-md-9">
            <h1>Edit Profile</h1>
            <div class="col-xl-12 col-md-6">
                <div class="row mb-2">
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-xl-12">
                                        <p class="form-row form-row-wide">
                                            <label>Username&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                            <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Name" disable="true"></asp:TextBox>
                                        </p>
                                    </div>
                                    <div class="col-xl-12">
                                        <p class="form-row form-row-wide">
                                            <label>Name&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="name here"></asp:TextBox>
                                        </p>
                                    </div>

                                    <div class="col-xl-12">
                                        <p class="form-row form-row-wide">
                                            <label>Email&nbsp;<span class="required">*&nbsp;&nbsp;</span></label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Field" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Subject" TextMode="Email"></asp:TextBox>
                                        </p>
                                    </div>                                   
                                    <p class="form-row form-row-wide d-grid">
                                        <div class="row mb-2">
                                            <asp:Button class="button col-xl-3" Text="Cancel" runat="server" ID="btnCancel" />
                                            <asp:Button class="button col-xl-3" Text="Submit" runat="server" ID="btnSubmit" />
                                        </div>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">

                        <div class="card">
                            <div class="card-body">
                            <img style="border-radius:50%" width="250" height="250" src="/Assets/images/NA.jpg" alt="Avatar">
                                    <img style="border-radius: 50%" width="250" height="250" src="/Assets/images/NA.jpg" alt="Avatar">
                            <input class="form-control" type="file" id="txtImageUpload">
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
