<%@ Page Language="C#" MasterPageFile="~/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log on / Register</h2>
    <p>
        To log in, click <a href="<%= Url.Action("LogOn", "Accounts") %>">here</a>
        To register, click <a href="<%= Url.Action("Register", "Accounts") %>">here</a>
    </p>
</asp:Content>