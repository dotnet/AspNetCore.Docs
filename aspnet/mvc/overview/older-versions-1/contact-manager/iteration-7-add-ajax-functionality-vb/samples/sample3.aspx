<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of ContactManager.IndexModel)" %>
<%@ Import Namespace="ContactManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<ul id="leftColumn">
<% For Each item in Model.Groups %>
    <li <%= Html.Selected(item.Id, Model.SelectedGroup.Id) %>>
    <%= Ajax.ActionLink(item.Name, "Index", New With { .id = item.Id }, New AjaxOptions With { .UpdateTargetId = "divContactList"})%>
    </li>
<% Next %>
</ul>
<div id="divContactList">
    <% Html.RenderPartial("ContactList", Model.SelectedGroup) %>
</div>

<div class="divContactList-bottom"> </div>
</asp:Content>