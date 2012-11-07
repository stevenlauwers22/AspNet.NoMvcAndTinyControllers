<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.TinyControllers.Mvc1.Sample.Models.Accounts.RegisterModel>" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Accounts - Register</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("Register", "Accounts")) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="Username">Username:</label>
                    <%= Html.TextBox("Username") %>
                    <%= Html.ValidationMessage("Username") %>
                </p>
                <p>
                    <label for="Email">Email:</label>
                    <%= Html.TextBox("Email") %>
                    <%= Html.ValidationMessage("Email") %>
                </p>
                <p>
                    <label for="Password">Password:</label>
                    <%= Html.Password("Password") %>
                    <%= Html.ValidationMessage("Password") %>
                </p>
                <p>
                    <label for="ConfirmPassword">Confirm password:</label>
                    <%= Html.Password("ConfirmPassword") %>
                    <%= Html.ValidationMessage("ConfirmPassword") %>
                </p>
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>