<%@ Page Title="Admin" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ViewAdmin.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.ViewAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function refreshImage() {
            const uploadElement = $("#ContentPlaceHolder1_FormAdminDetail_uploadProfilePicture");
            const imgTempUrl = window.URL.createObjectURL(uploadElement[0].files[0]);
            document.getElementById('imgProfilePicture').src = imgTempUrl;
            return false;
        };
    </script>
    <asp:FormView ID="FormAdminDetail" runat="server" ItemType="AmazEng_WAPP.Models.Admin" SelectMethod="FormAdminDetail_GetItem" RenderOuterTable="false">
        <ItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">View Admin: <%#:Item.Name %></h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminAdminsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Back
                    </a>
                    <asp:Button ID="btnResetPassword" Text="Reset Password" runat="server" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center" OnClick="btnResetPassword_Click" OnClientClick='return confirm("Reset password for this Admin Account?");' />
                    <a href='<%#: GetRouteUrl("AdminViewAdminRoute", new {Id = Item.Id , Mode = "Edit"}) %>' class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center">Edit
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

                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Role</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: GetAdminRoleName((int) (Item.RoleId)) %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Last login at</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.LastLoginAt.HasValue ? Item.LastLoginAt.Value.ToLocalTime().ToString() : "-" %></span>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <%--edit view--%>
        <EditItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">Edit Admin: <%#:Item.Name %></h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminViewAdminRoute", new {Id = Item.Id }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                    </a>
                    <asp:Button Text="Done" CausesValidation="true" runat="server" ID="btnSubmit" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center"
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
                            
                             <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                    CssClass="invalid-feedback"
                                    Display="Dynamic"
                                    ControlToValidate="uploadProfilePicture"
                                    ErrorMessage="Only JPEG or PNG images are allowed"
                                    ValidationExpression="\.(jpe?g|tiff?|png|webp|bmp)$">
                                </asp:RegularExpressionValidator>
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
                        <div class="col-auto">
                            <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Invalid field input." ControlToValidate="txtEditName"
                                ValidationExpression="^[A-Za-z ,.'-]+$"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditName"></asp:RequiredFieldValidator>
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
                        <div class="col-auto">
                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditUsername"></asp:RequiredFieldValidator>
                            <asp:CustomValidator
                                class="invalid-feedback"
                                Display="Dynamic"
                                ErrorMessage="*This username is used by other admin."
                                ID="validatorUsername"
                                ControlToValidate="txtEditUsername"
                                OnServerValidate="validatorUsername_ServerValidate"
                                runat="server"></asp:CustomValidator>
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
                        <div class="col-auto">
                            <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Invalid field input." ControlToValidate="txtEditEmail"
                                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditEmail"></asp:RequiredFieldValidator>

                            <asp:CustomValidator
                                class="invalid-feedback"
                                Display="Dynamic"
                                ErrorMessage="*This email is used by other admin."
                                ID="validatorEditEmail"
                                ControlToValidate="txtEditEmail"
                                OnServerValidate="validatorEditEmail_ServerValidate"
                                runat="server"></asp:CustomValidator>
                        </div>
                    </div>



                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtEditEmail" class="col-form-label">Admin Role</label>
                        </div>

                        <div class="col-auto">
                            <asp:DropDownList ID="EditDropDownAdminRole" runat="server" SelectedValue='<%# GetAdminRoleName((int)Eval("RoleId")) %>'>
                                <asp:ListItem Value="">Please Select Role</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>Super Admin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
            </div>

        </EditItemTemplate>

        <%--new view--%>
        <InsertItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">New Admin</h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminAdminsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                    </a>
                    <asp:Button Text="Done" runat="server" ID="btnCreate" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center"
                        OnClick="btnCreate_Click" />
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
                                <img class="rounded avatar-xl" id="imgProfilePicture" src="https://via.placeholder.com/400x400" alt="profile-picture">
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
                            
                             <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                    CssClass="invalid-feedback"
                                    Display="Dynamic"
                                    ControlToValidate="uploadProfilePicture"
                                    ErrorMessage="Only JPEG or PNG images are allowed"
                                    ValidationExpression="\.(jpe?g|tiff?|png|webp|bmp)$">
                                </asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtNewName" class="col-form-label">Name</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtNewName" class="form-control"
                                placeholder="Name"
                                runat="server" />
                        </div>
                        <div class="col-auto">
                            <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Invalid field input." ControlToValidate="txtNewName"
                                ValidationExpression="^[A-Za-z ,.'-]+$"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewName"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtNewUsername" class="col-form-label">Username</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtNewUsername" class="form-control"
                                placeholder="Username"
                                runat="server" />
                        </div>
                        <div class="col-auto">
                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewUsername"></asp:RequiredFieldValidator>
                            <asp:CustomValidator
                                class="invalid-feedback"
                                Display="Dynamic"
                                ErrorMessage="*This username is used by other admin."
                                ID="validatorNewUsername"
                                ControlToValidate="txtNewUsername"
                                OnServerValidate="validatorNewUsername_ServerValidate"
                                runat="server"></asp:CustomValidator>
                        </div>
                    </div>


                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtNewEmail" class="col-form-label">Email</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtNewEmail" class="form-control"
                                placeholder="your-email@gmail.com"
                                runat="server" />
                        </div>
                        <div class="col-auto">
                            <asp:RegularExpressionValidator class="invalid-feedback" Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Invalid field input." ControlToValidate="txtNewEmail"
                                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewEmail"></asp:RequiredFieldValidator>
                            <asp:CustomValidator
                                class="invalid-feedback"
                                Display="Dynamic"
                                ErrorMessage="*This email is used by other admin."
                                ID="validatorNewEmail"
                                ControlToValidate="txtNewEmail"
                                OnServerValidate="validatorNewEmail_ServerValidate"
                                runat="server"></asp:CustomValidator>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtNewPassword" class="col-form-label">Password</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtNewPassword" class="form-control"
                                runat="server" TextMode="Password" />
                        </div>

                        <div class="col-auto">
                            <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center  mb-1">
                        <div class="col-2">
                            <label for="txtNewRePassword" class="col-form-label">Re-enter Password</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtNewRePassword" class="form-control"
                                TextMode="Password"
                                runat="server" />
                        </div>

                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtAdminRole" class="col-form-label">Admin Role</label>
                            </div>
                            <div class="col-4">
                                <asp:DropDownList ID="DropDownAdminRole" runat="server">
                                    <asp:ListItem Value="">Please Select Role</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Super Admin</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-auto">
                                <asp:CompareValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*Please make sure both passwords are the same"
                                    ControlToValidate="txtNewPassword"
                                    ControlToCompare="txtNewRePassword"
                                    Operator="Equal"
                                    runat="server" />
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewRePassword"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                </div>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
