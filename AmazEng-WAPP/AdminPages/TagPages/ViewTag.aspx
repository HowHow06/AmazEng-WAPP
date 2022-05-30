<%@ Page Title="Tag" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ViewTag.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.TagPages.ViewTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-5">
        <asp:FormView ID="FormTagDetail" runat="server" ItemType="AmazEng_WAPP.Models.Tag" SelectMethod="FormTagDetail_GetItem" RenderOuterTable="false">
            <ItemTemplate>
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                    <div class="d-block mb-4 mb-md-0">
                        <h2 class="h3 m-0">View Tag: <%#:Item.Name %></h2>
                    </div>
                    <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                        <a href='<%#: GetRouteUrl("AdminTagsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Back
                        </a>
                        <a href='<%#: GetRouteUrl("AdminViewTagRoute", new {Id = Item.Id , Mode = "Edit"}) %>' class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center">Edit
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
                                <label class="col-form-label">Id</label>
                            </div>
                            <div class="col-auto">
                                <span class="form-text"><%#: Item.Id %></span>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Name</label>
                            </div>
                            <div class="col-auto">
                                <span class="form-text"><%#: Item.Name %></span>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>
            </ItemTemplate>
            <%--edit view--%>
            <EditItemTemplate>
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                    <div class="d-block mb-4 mb-md-0">
                        <h2 class="h3 m-0">Edit Tag: <%#:Item.Name %></h2>
                    </div>
                    <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                        <a href='<%#: GetRouteUrl("AdminViewTagRoute", new {Id = Item.Id }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                        </a>
                        <asp:Button Text="Done" CausesValidation="true" runat="server" ID="btnSubmit" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label class="col-form-label">Id</label>
                            </div>
                            <div class="col-auto">
                                <span class="form-text"><%#: Item.Id %></span>
                            </div>
                        </div>
                        <hr />
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
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditName"></asp:RequiredFieldValidator>
                                <asp:CustomValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*This name is used by other tag."
                                    ID="validatorName"
                                    ControlToValidate="txtEditName"
                                    OnServerValidate="validatorName_ServerValidate"
                                    runat="server"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                </div>
    
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                    <div class="d-block mb-4 mb-md-0">
                        <h2 class="h3 m-0">New Tag</h2>
                    </div>
                    <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                        <a href='<%#: GetRouteUrl("AdminTagsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                        </a>
                        <asp:Button Text="Done" runat="server" ID="btnCreate" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center"
                            OnClick="btnCreate_Click" />
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">

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
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewName"></asp:RequiredFieldValidator>
                                <asp:CustomValidator
                                    class="invalid-feedback"
                                    Display="Dynamic"
                                    ErrorMessage="*This name is used by other tag."
                                    ID="validatorNewTag"
                                    ControlToValidate="txtNewName"
                                    OnServerValidate="validatorNewName_ServerValidate"
                                    runat="server"></asp:CustomValidator>
                            </div>
                        </div>
            </InsertItemTemplate>

        </asp:FormView>
    </div>
</asp:Content>
