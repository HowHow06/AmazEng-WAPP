<%@ Page Title="Member" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ViewMember.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.MemberPages.ViewMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function refreshImage() {
            const uploadElement = $("#ContentPlaceHolder1_FormMemberDetail_uploadProfilePicture");
            const imgTempUrl = window.URL.createObjectURL(uploadElement[0].files[0]);
            document.getElementById('imgProfilePicture').src = imgTempUrl;
            return false;
        };
    </script>
    <asp:FormView ID="FormMemberDetail" runat="server" ItemType="AmazEng_WAPP.Models.Member" SelectMethod="FormMemberDetail_GetItem" RenderOuterTable="false">
        <ItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">View Member: <%#:Item.Name %></h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminMembersRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Back
                    </a>
                    <a href='<%#: GetRouteUrl("AdminViewMemberRoute", new {Id = Item.Id , Mode = "Edit"}) %>' class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center">Edit
                    </a>
                    <asp:Button class="btn btn-sm btn-gray-800 ms-2" Text="Delete" runat="server" ID="btnDelete" OnClick="btnDelete_Click"
                        OnClientClick='return confirm("Are you sure to delete this item?");' />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Profile Picture</label>
                        </div>
                        <div class="col-auto">
                            <img class="rounded avatar-xl" src='<%#: Item.ProfilePicture ?? "https://via.placeholder.com/400x400" %>' alt="profile-picture">
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Id</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Id %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Username</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Username %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Name</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Name %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Email</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Email %></span>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <%--edit view--%>
        <EditItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">Edit Member: <%#:Item.Name %></h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminViewMemberRoute", new {Id = Item.Id }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                    </a>
                    <asp:Button Text="Done" runat="server" ID="btnSubmit" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center"
                        OnClick="btnSubmit_Click" />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <%--field--%>
                    <div class="row g-3 align-items-center mb-1">
                        <div class="col-2">
                            <label class="col-form-label">Profile Picture</label>
                        </div>
                        <div class="col-auto">
                            <div class="d-inline-flex flex-column align-items-center ">
                                <img class="rounded avatar-xl" id="imgProfilePicture" src='<%#: Item.ProfilePicture ?? "https://via.placeholder.com/400x400" %>' alt="profile-picture">
                                <%--<asp:Image ID="imgProfilePicture" ImageUrl='<%#: Item.ProfilePicture ?? "https://via.placeholder.com/400x400" %>' AlternateText="profile-picture" class="rounded avatar-xl" runat="server" />--%>
                                <asp:LinkButton runat="server" ID="btnRefreshImage"
                                    class="text-primary d-inline-flex align-items-center my-1"
                                    OnClientClick="return refreshImage();">
                                    <small>Refresh <i class="fa-solid fa-arrows-rotate"></i></small>                                    
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:FileUpload ID="uploadProfilePicture" runat="server" />
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label class="col-form-label">Id</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Id %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtEditName" class="col-form-label">Name</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtEditName" class="form-control"
                                Text='<%# Bind("Name") %>'
                                runat="server" />
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtEditUsername" class="col-form-label">Username</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtEditUsername" class="form-control"
                                Text='<%# Bind("Username") %>'
                                runat="server" />
                        </div>
                    </div>


                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtEditEmail" class="col-form-label">Email</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtEditEmail" class="form-control"
                                Text='<%# Bind("Email") %>'
                                runat="server" />
                        </div>
                    </div>

                </div>
            </div>

        </EditItemTemplate>
        <InsertItemTemplate>
            hi
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
