<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Site.Admin.Master" AutoEventWireup="true" CodeBehind="ViewIdiom.aspx.cs" Inherits="AmazEng_WAPP.AdminPages.IdiomPages.ViewIdiom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <link href="/AdminPages/Assets/vendors/multiselect/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="/AdminPages/Assets/vendors/multiselect/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lstTags]').multiselect({
                includeSelectAllOption: true,
                //enableFiltering: true,
                //filterPlaceholder: 'Search',
                //enableCaseInsensitiveFiltering: true,
                //dropRight: true
            });
        });
    </script>--%>
    <div class="mb-5">
        <asp:FormView ID="FormIdiomDetail" runat="server" ItemType="AmazEng_WAPP.Models.Idiom" SelectMethod="FormIdiomDetail_GetItem" RenderOuterTable="false">
            <ItemTemplate>
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                    <div class="d-block mb-4 mb-md-0">
                        <h2 class="h3 m-0">View Idiom: <%#:Item.Name %></h2>
                    </div>
                    <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                        <a href='<%#: GetRouteUrl("AdminIdiomsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Back
                        </a>
                        <a href='<%#: GetRouteUrl("AdminViewIdiomRoute", new {Id = Item.Id , Mode = "Edit"}) %>' class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center">Edit
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
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Origin</label>
                            </div>
                            <div class="col-auto">
                                <span class="form-text"><%#: string.IsNullOrEmpty(Item.Origin) ? "-" : Item.Origin %></span>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Meaning</label>
                            </div>
                            <div class="col-auto">
                                <asp:PlaceHolder runat="server" ID="phViewMeaning" />
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Example</label>
                            </div>
                            <div class="col-auto">
                                <asp:PlaceHolder runat="server" ID="phViewExample" />
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Pronunciation</label>
                            </div>
                            <div class="col-auto">
                                <asp:PlaceHolder runat="server" ID="phViewPronunciation" />
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center">
                            <div class="col-2">
                                <label class="col-form-label">Tags</label>
                            </div>
                            <div class="col-auto">
                                <p class="form-text">
                                    <asp:Literal runat="server" ID="lblViewTags" />
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
            <%--edit view--%>
            <EditItemTemplate>
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                    <div class="d-block mb-4 mb-md-0">
                        <h2 class="h3 m-0">Edit Idiom: <%#:Item.Name %></h2>
                    </div>
                    <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                        <a href='<%#: GetRouteUrl("AdminViewIdiomRoute", new {Id = Item.Id }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
                        </a>
                        <asp:Button Text="Done" CausesValidation="true" runat="server" ID="btnSubmit" class="btn btn-sm btn-gray-800  ms-2 d-inline-flex align-items-center" OnClick="btnSubmit_Click"/>
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
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtEditOrigin" class="col-form-label">Origin</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtEditOrigin" class="form-control"
                                    TextMode="MultiLine"
                                    Text='<%# Bind("Origin") %>'
                                    runat="server" />
                            </div>
                        </div>
                        <hr />

                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtEditMeaning" class="col-form-label">Meaning</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtEditMeaning" class="form-control"
                                    TextMode="MultiLine"
                                    Text="<%#: Item.GetMeaningForEdit() %>"
                                    runat="server" Rows="6" />
                            </div>
                            <div class="col-4">
                                <p class="form-text m-0 p-0 ">Please separate each meaning by a new line. For example:</p>
                                <p class="form-text m-0 p-0  text-italic">meaning 1</p>
                                <p class="form-text m-0 p-0  text-italic">meaning 2</p>
                            </div>
                            <div class="col-auto">
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtEditMeaning"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtEditExample" class="col-form-label">Example</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtEditExample" class="form-control"
                                    TextMode="MultiLine"
                                    Text="<%#: Item.GetExampleForEdit() %>"
                                    runat="server" Rows="6" />
                            </div>

                            <div class="col-4">
                                <p class="form-text m-0 p-0 ">Please separate each example by a new line. For example:</p>
                                <p class="form-text m-0 p-0  text-italic">example 1</p>
                                <p class="form-text m-0 p-0  text-italic">example 2</p>
                            </div>
                        </div>
                        <hr />

                        <%--field--%>
                        <div class="row g-3 align-items-center mb-1">
                            <div class="col-2">
                                <label class="col-form-label">Pronunciation</label>
                            </div>
                            <div class="col-auto">
                                <asp:FileUpload CssClass="form-control" ID="uploadEditPronunciation" runat="server" />
                            </div>
                        </div>
                        <hr />
                        <%--field--%>

                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="lstEditTags" class="col-form-label">Tags</label>
                            </div>
                            <div class="col-6">
                                <asp:ListBox runat="server" CssClass="form-control" ItemType="AmazEng_WAPP.Models.Tags" ID="lstEditTags" SelectionMode="Multiple"
                                    Height="250px"></asp:ListBox>
                            </div>
                            <div class="col-auto">
                                <p>
                                    <asp:Literal ID="lblEditDisplayTags" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    function decode(string) {
                        var div = document.createElement("div");
                        div.innerHTML = string;
                        return typeof div.textContent !== 'undefined' ? div.textContent : div.innerText;
                    }
                    //the function below is to decode apostrophe from  &#39; to '
                    (function () {
                        $('[id*=txtEditMeaning]').val(decode($('[id*=txtEditMeaning]').val()));
                        $('[id*=txtEditExample]').val(decode($('[id*=txtEditExample]').val()));
                    })();

                </script>
            </EditItemTemplate>
            <InsertItemTemplate>
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
                <div class="d-block mb-4 mb-md-0">
                    <h2 class="h3 m-0">New Idiom</h2>
                </div>
                <div class="btn-toolbar mb-2 mb-md-0 d-flex">
                    <a href='<%#: GetRouteUrl("AdminIdiomsRoute", new { }) %>' class="btn btn-sm  btn-outline-gray-600  d-inline-flex align-items-center">Cancel
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
                                    runat="server" />
                            </div>
                            <div class="col-auto">
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtNewOrigin" class="col-form-label">Origin</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtNewOrigin" class="form-control"
                                    TextMode="MultiLine"
                                    runat="server" />
                            </div>
                        </div>
                        <hr />

                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtNewMeaning" class="col-form-label">Meaning</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtNewMeaning" class="form-control"
                                    TextMode="MultiLine"
                                    runat="server" Rows="6" />
                            </div>
                            <div class="col-4">
                                <p class="form-text m-0 p-0 ">Please separate each meaning by a new line. For example:</p>
                                <p class="form-text m-0 p-0  text-italic">meaning 1</p>
                                <p class="form-text m-0 p-0  text-italic">meaning 2</p>
                            </div>
                            <div class="col-auto">
                                <asp:RequiredFieldValidator class="invalid-feedback" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*This field must not be empty" ControlToValidate="txtNewMeaning"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr />
                        <%--field--%>
                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="txtNewExample" class="col-form-label">Example</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtNewExample" class="form-control"
                                    TextMode="MultiLine"
                                    runat="server" Rows="6" />
                            </div>

                            <div class="col-4">
                                <p class="form-text m-0 p-0 ">Please separate each example by a new line. For example:</p>
                                <p class="form-text m-0 p-0  text-italic">example 1</p>
                                <p class="form-text m-0 p-0  text-italic">example 2</p>
                            </div>
                        </div>
                        <hr />

                        <%--field--%>
                        <div class="row g-3 align-items-center mb-1">
                            <div class="col-2">
                                <label class="col-form-label">Pronunciation</label>
                            </div>
                            <div class="col-auto">
                                <asp:FileUpload CssClass="form-control" ID="uploadNewPronunciation" runat="server" />
                            </div>
                        </div>
                        <hr />
                        <%--field--%>

                        <div class="row g-3 align-items-center  mb-1">
                            <div class="col-2">
                                <label for="lstNewTags" class="col-form-label">Tags</label>
                            </div>
                            <div class="col-6">
                                <asp:ListBox runat="server" CssClass="form-control" ItemType="AmazEng_WAPP.Models.Tags" ID="lstNewTags" SelectionMode="Multiple"
                                    Height="250px"></asp:ListBox>
                            </div>
                            <div class="col-auto">
                                <p>
                                    <asp:Literal ID="lblNewDisplayTags" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    function decode(string) {
                        var div = document.createElement("div");
                        div.innerHTML = string;
                        return typeof div.textContent !== 'undefined' ? div.textContent : div.innerText;
                    }
                    //the function below is to decode apostrophe from  &#39; to '
                    (function () {
                        $('[id*=txtEditMeaning]').val(decode($('[id*=txtEditMeaning]').val()));
                        $('[id*=txtEditExample]').val(decode($('[id*=txtEditExample]').val()));
                    })();

                </script>
            </InsertItemTemplate>

        </asp:FormView>
    </div>

</asp:Content>
