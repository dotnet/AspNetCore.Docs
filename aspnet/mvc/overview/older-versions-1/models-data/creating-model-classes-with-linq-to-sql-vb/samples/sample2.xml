<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="MvcApplication1.Index" %>
<%@ Import Namespace="MvcApplication1" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

<ul>
<%  For Each m As Movie In ViewData.Model%>
    <li><%= m.Title %></li>
<% Next%>
</ul>
</asp:Content>