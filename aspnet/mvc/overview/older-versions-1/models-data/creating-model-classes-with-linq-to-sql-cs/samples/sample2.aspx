<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcApplication1.Views.Home.Index" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

     <ul>
          <% foreach (Movie m in (IEnumerable)ViewData.Model)

          { %>
               <li> <%= m.Title %> </li>
          <% } %>
     </ul>
</asp:Content>