<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcApplication1" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Calling helper without HTML attributes -->
    <%= Html.Image("img1", ResolveUrl("~/Content/XBox.jpg"), "XBox Console") %>

    <!-- Calling helper with HTML attributes -->
    <%= Html.Image("img1", ResolveUrl("~/Content/XBox.jpg"), "XBox Console", New With {.border="4px"})%>

</asp:Content>