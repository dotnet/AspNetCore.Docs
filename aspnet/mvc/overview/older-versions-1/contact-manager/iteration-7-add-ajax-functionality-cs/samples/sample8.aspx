<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContactManager.Models.ViewData.IndexModel>" %>
<%@ Import Namespace="Helpers" %>
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
<% foreach (var item in Model.Groups) { %>
    <li <%= Html.Selected(item.Id, Model.SelectedGroup.Id) %>>
    <%= Ajax.ActionLink(item.Name, "Index", new { id = item.Id }, new AjaxOptions { UpdateTargetId = "divContactList", OnBegin = "beginContactList", OnSuccess = "successContactList", OnFailure = "failureContactList" }, new { groupid = item.Id })%>
    </li>
<% } %>
</ul>
<div id="divContactList">
    <% Html.RenderPartial("ContactList", Model.SelectedGroup); %>
</div>

<div class="divContactList-bottom"> </div>
</asp:Content>