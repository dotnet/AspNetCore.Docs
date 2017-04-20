<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcApplication1.Helpers" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Calling helper without HTML attributes -->
    <%= Html.Image("img1", ResolveUrl("~/Content/XBox.jpg"), "XBox Console") %>

    <!-- Calling helper with HTML attributes -->
    <%= Html.Image("img1", ResolveUrl("~/Content/XBox.jpg"), "XBox Console", new {border="4px"})%>

</asp:Content>