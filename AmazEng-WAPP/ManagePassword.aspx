<%@ Page Title="Manage Password" Language="C#" MasterPageFile="~/NestedMemberManage.master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="AmazEng_WAPP.ManagePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainInnerContent" runat="server">
    <h3>Manage Password</h3>
    <hr />
    <div>
        <%--adding validation will make the whole postback not functional--%>
        <div class="mb-3">
            <label for="txtOldPassword" class="form-label">Original Password</label>
            <asp:TextBox runat="server" class="form-control" ID="txtOldPassword" TextMode="Password" />
             <asp:RequiredFieldValidator Display="Dynamic" CssClass="invalid-feedback" ErrorMessage="*This field is required" ControlToValidate="txtOldPassword" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtNewPassword" class="form-label">New Password</label>
            <asp:TextBox runat="server" class="form-control" ID="txtNewPassword" TextMode="Password" />
              <asp:RequiredFieldValidator Display="Dynamic" CssClass="invalid-feedback" ErrorMessage="*This field is required" ControlToValidate="txtNewPassword" runat="server" />
        </div>
         <div class="mb-3">
            <label for="txtReNewPassword" class="form-label">Re-enter Password</label>
            <asp:TextBox runat="server" class="form-control" ID="txtReNewPassword" TextMode="Password" />
              <asp:RequiredFieldValidator Display="Dynamic" CssClass="invalid-feedback" ErrorMessage="*This field is required" ControlToValidate="txtReNewPassword" runat="server" />
             <asp:CompareValidator Display="Dynamic" ErrorMessage="*Please make sure new password and re-enter password are the same." ControlToValidate="txtReNewPassword" ControlToCompare="txtNewPassword" runat="server" CssClass="invalid-feedback" />
        </div>
       
        <asp:LinkButton runat="server" ID="btnSubmitReport" OnClick="btnSubmitReport_Click">
            <span id="btnClientReportSubmit" type="submit" class="btn btn-main rounded btn-sm">Submit</span>
        </asp:LinkButton>

    </div>
</asp:Content>
