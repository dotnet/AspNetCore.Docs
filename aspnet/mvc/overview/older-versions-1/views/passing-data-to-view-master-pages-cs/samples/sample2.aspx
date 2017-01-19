<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcApplication1.Views.Home.Index" %>

<%@ Import Namespace="MvcApplication1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<ul>

<% foreach (var m in (IEnumerable<Movie>)ViewData["movies"])
     { %>

     <li><%= m.Title %></li>

<% } %>
</ul>

</asp:Content>