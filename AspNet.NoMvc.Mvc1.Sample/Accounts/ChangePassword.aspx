<%@ Page Language="C#" MasterPageFile="~/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.NoMvc.Mvc1.Sample.Accounts.ChangePasswordModel>" %>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Accounts - Change Password</h2>
    <p>
        Use the form below to change your password. 
    </p>
    <p>
        New passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%= Html.ValidationSummary("Password change was unsuccessful. Please correct the errors and try again.")%>

    <% using (Html.BeginForm("ChangePassword", "Accounts")) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="CurrentPassword">Current password:</label>
                    <%= Html.Password("CurrentPassword") %>
                    <%= Html.ValidationMessage("CurrentPassword") %>
                </p>
                <p>
                    <label for="NewPassword">New password:</label>
                    <%= Html.Password("NewPassword") %>
                    <%= Html.ValidationMessage("NewPassword") %>
                </p>
                <p>
                    <label for="ConfirmPassword">Confirm new password:</label>
                    <%= Html.Password("ConfirmPassword") %>
                    <%= Html.ValidationMessage("ConfirmPassword") %>
                </p>
                <p>
                    <input type="submit" value="Change Password" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>