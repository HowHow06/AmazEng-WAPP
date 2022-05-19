<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IdiomCard.ascx.cs" Inherits="AmazEng_WAPP.Class.Controls.IdiomCard" %>

<div class="card <%= this.CssClass %>">
    <div class="d-flex justify-content-between">
        <span class="h5"><%= this.Idiom.Name %></span>
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <div class="d-flex h6">
                    <asp:LinkButton ID="btnFavourite" OnClick="btnFavourite_Click" runat="server">
                        <%
                            if (this.IsFavourite)
                            {%>
                        <i class="fas fa-heart ms-2"></i>
                        <% }
                            else
                            {
                        %>
                        <i class="far fa-heart ms-2"></i>
                        <% } %>
                    </asp:LinkButton>
                    <!-----------------------------separator-------------------------------->
                    <asp:LinkButton ID="btnLearnLater" OnClick="btnLearnLater_Click" runat="server">
                        <%
                            if (this.IsLearnLater)
                            {%>
                        <i class="fas fa-check-double ms-2"></i>
                        <% }
                            else
                            {
                        %><i class="fas fa-list ms-2"></i>
                        <% } %>
                    </asp:LinkButton>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row mt-4">
        <asp:PlaceHolder runat="server" ID="phMeaning" />
    </div>
</div>
