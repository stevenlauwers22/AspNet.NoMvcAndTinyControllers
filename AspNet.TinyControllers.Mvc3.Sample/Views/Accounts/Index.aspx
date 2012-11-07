<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Accounts - Index</h2>
    <p>
        To log in, click <a href="<%= Url.Action("LogOn", "Accounts") %>">here</a>
        To register, click <a href="<%= Url.Action("Register", "Accounts") %>">here</a>
    </p>
</asp:Content>