<%@ Page Language="C#" MasterPageFile="~/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.NoMvc.Mvc3.Sample.Accounts.LogOnModel>" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Accounts - Log On</h2>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Accounts") %> if you don't have an account.
    </p>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("LogOn", "Accounts")) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="Username">Username:</label>
                    <%= Html.TextBoxFor(m => m.Username) %>
                    <%= Html.ValidationMessageFor(m => m.Username) %>
                </p>
                <p>
                    <label for="Password">Password:</label>
                    <%= Html.PasswordFor(m => m.Password) %>
                    <%= Html.ValidationMessageFor(m => m.Password) %>
                </p>
                <p>
                    <%= Html.CheckBoxFor(m => m.RememberMe) %>
                    <label class="inline" for="RememberMe">Remember me?</label>
                </p>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>