<td class="actions edit">
    <a href='<%= Url.Action("Edit", new {id=item.Id}) %>'><img src="../../Content/Edit.png" alt="Edit" /></a>
</td>
<td class="actions delete">
    <a href='<%= Url.Action("Delete", new {id=item.Id}) %>'><img src="../../Content/Delete.png" alt="Delete" /></a>
</td>