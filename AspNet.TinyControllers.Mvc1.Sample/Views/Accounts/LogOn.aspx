<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.TinyControllers.Mvc1.Sample.Models.Accounts.LogOnModel>" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
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
                    <%= Html.TextBox("Username") %>
                    <%= Html.ValidationMessage("Username") %>
                </p>
                <p>
                    <label for="Password">Password:</label>
                    <%= Html.Password("Password") %>
                    <%= Html.ValidationMessage("Password") %>
                </p>
                <p>
                    <%= Html.CheckBox("RememberMe") %>
                    <label class="inline" for="RememberMe">Remember me?</label>
                </p>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>