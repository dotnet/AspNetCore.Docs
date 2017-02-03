<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContactManager.Models.ViewData.IndexModel>" %>
<%@ Import Namespace="Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<ul id="leftColumn">
<% foreach (var item in Model.Groups) { %>
    <li <%= Html.Selected(item.Id, Model.SelectedGroup.Id) %>>
    <%= Ajax.ActionLink(item.Name, "Index", new { id = item.Id }, new AjaxOptions { UpdateTargetId = "divContactList"})%>
    </li>
<% } %>
</ul>
<div id="divContactList">
    <% Html.RenderPartial("ContactList", Model.SelectedGroup); %>
</div>

<div class="divContactList-bottom"> </div>
</asp:Content>