<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IdiomCard.ascx.cs" Inherits="AmazEng_WAPP.Class.Controls.IdiomCard" %>

<div class="card <%= this.CssClass %>">
    <div class="d-flex justify-content-between" runat="server" id="divHeadline">
        <a class="h5" href='<%= GetRouteUrl("IdiomRoute", new { Id=this.IdiomId }) %>'><%= this.Idiom.Name %>
            <%  if (!string.IsNullOrEmpty(this.Idiom.Pronunciation))
                {
            %>
            <i class="fas fa-volume ms-3"></i>
            <%
                } %>
        </a>
        <asp:HiddenField  runat="server" Value="<%# this.IdiomId %>" ID="hdnIdiomId"/>
        <asp:UpdatePanel ID="udpIdiomCard" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="d-flex h6">
                    <asp:LinkButton ID="btnFavourite" OnClick="btnFavourite_Click" runat="server" CommandArgument="<%# this.IdiomId%>" ToolTip="Add to favourite">
                        <i class="fas fa-heart ms-2" runat="server" id="iIsFavourite"></i>
                        <i class="far fa-heart ms-2" runat="server" id="iIsNotFavourite"></i>
                    </asp:LinkButton>
                    <!-----------------------------separator-------------------------------->
                    <asp:LinkButton ID="btnLearnLater" OnClick="btnLearnLater_Click" runat="server" CommandArgument="<%# this.IdiomId%>" ToolTip="Add to Learn Later">
                        <i class="fas fa-check-double ms-2 " runat="server" id="iIsLearnLater"></i>
                        <i class="fas fa-list ms-2" runat="server" id="iIsNotLearnLater"></i>
                    </asp:LinkButton>
                    <asp:UpdateProgress runat="server">
                        <ProgressTemplate>loading...</ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFavourite" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnLearnLater" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="row mt-4">
        <asp:PlaceHolder runat="server" ID="phMeaning" />
    </div>
    <script>   
        var prm2 = Sys.WebForms.PageRequestManager.getInstance();
        prm2.add_beginRequest(
            function (sender, args) {
                $get("<%=btnFavourite.ClientID %>").style.display = "none";
                    $get("<%=btnLearnLater.ClientID %>").style.display = "none";
                }
            );
        prm2.add_endRequest(
            function (sender, args) {
                $get("<%=btnFavourite.ClientID %>").style.display = "";
                    $get("<%=btnLearnLater.ClientID %>").style.display = "";
                }
            );

    </script>
</div>
