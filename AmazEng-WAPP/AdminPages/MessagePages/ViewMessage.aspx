<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ViewMessage.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.MessagePages.ViewMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormMessageDetail" runat="server" ItemType="AmazEng_WAPP.Models.Message" SelectMethod="FormMessageDetail_GetItem" RenderOuterTable="false">
        <ItemTemplate>
            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">View Message: <%#:Item.Id %></h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminMessagesRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Back
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

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Issuer Name</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.IssuerName %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Issuer Email</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.IssuerEmail %></span>
                        </div>
                    </div>

                     <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Sent at</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.SentAt %></span>
                        </div>
                    </div>

                      <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Subject</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Subject %></span>
                        </div>
                    </div>

                    <%--field--%>
                    <div class="row g-3 align-items-center">
                        <div class="col-2">
                            <label class="col-form-label">Content</label>
                        </div>
                        <div class="col-auto">
                            <span class="form-text"><%#: Item.Content %></span>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
