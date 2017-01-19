<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of ContactManager.IndexModel)" %>
<%@ Import Namespace="ContactManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    function beginContactList(args) 
    {
        // Highlight selected group
        $('#leftColumn li').removeClass('selected');
        $(this).parent().addClass('selected');

        // Animate
        $('#divContactList').fadeOut('normal');
    }

    function successContactList() 
    {
        // Animate
        $('#divContactList').fadeIn('normal');
    }

    function failureContactList()
    {
        alert("Could not retrieve contacts.");
    }

</script>

<ul id="leftColumn">
<% For Each item in Model.Groups %>
    <li <%= Html.Selected(item.Id, Model.SelectedGroup.Id) %>>
    <%= Ajax.ActionLink(item.Name, "Index", New With { .id = item.Id }, New AjaxOptions With { .UpdateTargetId = "divContactList", .OnBegin = "beginContactList", .OnSuccess = "successContactList", .OnFailure = "failureContactList" })%>
    </li>
<% Next %>
</ul>
<div id="divContactList">
    <% Html.RenderPartial("ContactList", Model.SelectedGroup) %>
</div>

<div class="divContactList-bottom"> </div>
</asp:Content>