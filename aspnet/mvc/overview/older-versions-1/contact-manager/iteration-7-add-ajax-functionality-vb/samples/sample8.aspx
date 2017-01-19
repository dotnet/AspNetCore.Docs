<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of ContactManager.IndexModel)" %>
<%@ Import Namespace="ContactManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    var _currentGroupId = -1;

    Sys.Application.add_init(pageInit);

    function pageInit() {
        // Enable history
        Sys.Application.set_enableHistory(true);

        // Add Handler for history
        Sys.Application.add_navigate(navigate);
    }

    function navigate(sender, e) {
        // Get groupId from address bar
        var groupId = e.get_state().groupId;

        // If groupId != currentGroupId then navigate
        if (groupId != _currentGroupId) {
            _currentGroupId = groupId;
            $("#divContactList").load("/Contact/Index/" + groupId);
            selectGroup(groupId);
        }
    }

    function selectGroup(groupId) {
        $('#leftColumn li').removeClass('selected');
        if (groupId)
            $('a[groupid=' + groupId + ']').parent().addClass('selected');
        else
            $('#leftColumn li:first').addClass('selected');
    }

    function beginContactList(args) {
        // Highlight selected group
        _currentGroupId = this.getAttribute("groupid");
        selectGroup(_currentGroupId);

        // Add history point
        Sys.Application.addHistoryPoint({ "groupId": _currentGroupId });

        // Animate
        $('#divContactList').fadeOut('normal');
    }

    function successContactList() {
        // Animate
        $('#divContactList').fadeIn('normal');
    }

    function failureContactList() {
        alert("Could not retrieve contacts.");
    }

</script>

<ul id="leftColumn">
<% For Each item in Model.Groups %>
    <li <%= Html.Selected(item.Id, Model.SelectedGroup.Id) %>>
    <%= Ajax.ActionLink(item.Name, "Index", New With { .id = item.Id }, New AjaxOptions With { .UpdateTargetId = "divContactList", .OnBegin = "beginContactList", .OnSuccess = "successContactList", .OnFailure = "failureContactList" }, New With { .groupid = item.Id })%>
    </li>
<% Next %>
</ul>
<div id="divContactList">
    <% Html.RenderPartial("ContactList", Model.SelectedGroup) %>
</div>

<div class="divContactList-bottom"> </div>
</asp:Content>