<%@ Page Language="C#" MasterPageFile="~/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.NoMvc.Sample.Accounts.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Password</h2>
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
                    <%= Html.PasswordFor(m => m.CurrentPassword) %>
                    <%= Html.ValidationMessageFor(m => m.CurrentPassword) %>
                </p>
                <p>
                    <label for="NewPassword">New password:</label>
                    <%= Html.PasswordFor(m => m.NewPassword) %>
                    <%= Html.ValidationMessageFor(m => m.NewPassword) %>
                </p>
                <p>
                    <label for="ConfirmPassword">Confirm new password:</label>
                    <%= Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%= Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </p>
                <p>
                    <input type="submit" value="Change Password" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>