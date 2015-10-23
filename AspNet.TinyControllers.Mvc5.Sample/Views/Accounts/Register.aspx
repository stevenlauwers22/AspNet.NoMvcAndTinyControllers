<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<AspNet.TinyControllers.Mvc5.Sample.Models.Accounts.RegisterModel>" %>

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
                    <%= Html.TextBoxFor(m => m.Username) %>
                    <%= Html.ValidationMessageFor(m => m.Username) %>
                </p>
                <p>
                    <label for="Email">Email:</label>
                    <%= Html.TextBoxFor(m => m.Email) %>
                    <%= Html.ValidationMessageFor(m => m.Email) %>
                </p>
                <p>
                    <label for="Password">Password:</label>
                    <%= Html.PasswordFor(m => m.Password) %>
                    <%= Html.ValidationMessageFor(m => m.Password) %>
                </p>
                <p>
                    <label for="ConfirmPassword">Confirm password:</label>
                    <%= Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%= Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </p>
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>