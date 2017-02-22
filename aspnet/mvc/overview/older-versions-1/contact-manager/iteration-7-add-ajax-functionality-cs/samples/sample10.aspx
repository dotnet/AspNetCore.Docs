<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ContactManager.Models.Group>" %>
<%@ Import Namespace="Helpers" %>
<table class="data-table" cellpadding="0" cellspacing="0">
    <thead>
        <tr>
            <th class="actions edit">
                Edit
            </th>
            <th class="actions delete">
                Delete
            </th>
            <th>
                Name
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var item in Model.Contacts)
           { %>
        <tr>
            <td class="actions edit">
                <a href='<%= Url.Action("Edit", new {id=item.Id}) %>'><img src="../../Content/Edit.png" alt="Edit" /></a>
            </td>
            <td class="actions delete">
            <%= Ajax.ImageActionLink("../../Content/Delete.png", "Delete", "Delete", new { id = item.Id }, new AjaxOptions { Confirm = "Delete contact?", HttpMethod = "Delete", UpdateTargetId = "divContactList" })%> 
            </td>
            <th>
                <%= Html.Encode(item.FirstName) %>
                <%= Html.Encode(item.LastName) %>
            </th>
            <td>
                <%= Html.Encode(item.Phone) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
        </tr>
        <% } %>
    </tbody>
</table>