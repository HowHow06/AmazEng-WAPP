<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IdiomDetail.aspx.cs" Inherits="AmazEng_WAPP.IdiomDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="alert alert-success" style="display: none; position: fixed; right: 30px; top: 50px; z-index: 2000" id="copied-alert">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Success:">
                <use xlink:href="#check-circle-fill" />
            </svg>
            Copied url to clipboard!
        </div>
        <a href="#" id="btn-back" class="btn btn-main-outline btn-back rounded ms-2">Back</a>
        <div class="my-4">
            <asp:FormView ID="FormIdiom" runat="server" ItemType="AmazEng_WAPP.Models.Idiom" SelectMethod="FormIdiom_GetItem" RenderOuterTable="false">
                <ItemTemplate>
                    <div class="mx-1 d-flex justify-content-between">
                        <div>
                            <h4 class="h4"><%#: Item.Name %></h4>
                        </div>
                        <asp:UpdatePanel ID="udpIdiomCard" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="d-flex align-items-center h6">
                                    <asp:LinkButton ID="btnFavourite" runat="server" OnClick="btnFavourite_Click" CommandArgument="<%# this.Idiom.Id%>" ToolTip="Add to Favourite">
                                        <asp:Literal runat="server" ID="lblFavouriteCount" />
                                        <i class="fas fa-heart mx-2" runat="server" id="iIsFavourite"></i>
                                        <i class="far fa-heart mx-2" runat="server" id="iIsNotFavourite"></i>
                                    </asp:LinkButton>
                                    <!-----------------------------separator-------------------------------->
                                    |
                                    <asp:LinkButton ID="btnLearnLater" runat="server" OnClick="btnLearnLater_Click" CommandArgument="<%# this.Idiom.Id%>" ToolTip="Add to Learn Later">
                                        <i class="fas fa-check-double mx-2 " runat="server" id="iIsLearnLater"></i>
                                        <i class="fas fa-list mx-2" runat="server" id="iIsNotLearnLater"></i>
                                    </asp:LinkButton>
                                    |
                                    <a class="on-hover-pointer popup-with-zoom-anim" id="btnShare" onclick="copyToClipboard(window.location.href);" data-toggle="tooltip" title="Share this idiom">
                                        <i class="fas fa-share mx-2 "></i>
                                    </a>
                                    |
                                    <a
                                        class="on-hover-pointer"
                                        id="btnReport"
                                        data-bs-toggle="dropdown"
                                        aria-expanded="true"
                                        data-toggle="tooltip" title="Report this idiom"
                                        >
                                        <i class="fas fa-flag  mx-2 "></i>
                                        Report this idiom
                                    </a>
                                    <div class="dropdown-menu px-4 py-3 keep-open" id="reportIdiomModal" aria-labelledby="btnReport" style="width: 30%">
                                        <div>
                                                <%--adding validation will make the whole postback not functional--%>
                                            <div class="mb-3">
                                                <label for="txtReportName" class="form-label">Name</label>
                                                <asp:TextBox runat="server" class="form-control" ID="txtReportName" />
                                                <%-- <asp:RequiredFieldValidator Display="Dynamic" CssClass="form-text" ErrorMessage="*This field is required" ControlToValidate="txtReportName" runat="server" />--%>
                                            </div>
                                            <div class="mb-3">
                                                <label for="txtReportEmail" class="form-label">Email address</label>
                                                <asp:TextBox runat="server" class="form-control" ID="txtReportEmail" TextMode="Email" />
                                                <%--  <asp:RequiredFieldValidator Display="Dynamic" CssClass="form-text" ErrorMessage="*This field is required" ControlToValidate="txtReportEmail" runat="server" />--%>
                                            </div>
                                            <div class="mb-3">
                                                <label for="txtReportDescription" class="form-label">Description</label>
                                                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtReportDescription" Rows="3" />
                                                <%-- <asp:RequiredFieldValidator Display="Dynamic" CssClass="form-text" ErrorMessage="*This field is required" ControlToValidate="txtReportDescription" runat="server" />--%>
                                            </div>
                                            <asp:LinkButton runat="server" ID="btnSubmitReport" OnClick="btnSubmitReport_Click">
                                                <span id="btnClientReportSubmit" type="submit" class="btn btn-main rounded w-100 btn-sm">Submit</span></asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnFavourite" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnLearnLater" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </ItemTemplate>
            </asp:FormView>
            <div class="mt-4">
                <div runat="server" id="divPronunciation">
                    <asp:PlaceHolder runat="server" ID="phPronunciation" />
                </div>
                <p><u>Meaning:</u></p>
                <asp:PlaceHolder runat="server" ID="phMeaning" />
                <p><u>Example:</u></p>
                <asp:PlaceHolder runat="server" ID="phExample" />
                <p><u>Origin:</u></p>
                <asp:PlaceHolder runat="server" ID="phOrigin" />
                <p>
                    <asp:PlaceHolder runat="server" ID="phTags" />
                </p>
            </div>
        </div>
    </div>
    <script>
        (function () {
            var a = document.getElementById('btn-back'); //or grab it by tagname etc
            //if (document.referrer.split('/')[2] != location.hostname) {
            //    //User came from other domain or from direct
            //    a.href = "/result";
            //} else {
            //User came from another page on your site
            a.href = document.referrer;
            //}
        })();


        const copyToClipboard = (content) => {
            var dummy = document.createElement('input'),
                text = content;

            document.body.appendChild(dummy);
            dummy.value = text;
            dummy.select();
            document.execCommand('copy');
            document.body.removeChild(dummy);
            showCopiedToClipboardAlert();
        }

        const showCopiedToClipboardAlert = () => {
            $("#copied-alert").fadeTo(2000, 100).slideUp(500, function () {
                //$("#copied-alert").slideUp(500); //can remove this callback
            });
        }
    </script>
</asp:Content>
