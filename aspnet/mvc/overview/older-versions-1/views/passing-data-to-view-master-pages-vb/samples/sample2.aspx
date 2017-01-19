<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="MvcApplication1.Index" %>

<%@ Import Namespace="MvcApplication1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<ul>

<%  For Each m In ViewData("movies")%>

     <li><%= m.Title %></li>

<% Next%>
</ul>

</asp:Content>