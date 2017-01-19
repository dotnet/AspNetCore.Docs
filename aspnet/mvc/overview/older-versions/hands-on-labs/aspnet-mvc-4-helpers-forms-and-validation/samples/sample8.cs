<tr>
     <td>
          @Html.ActionLink("Edit", "Edit", new { id=item.AlbumId }) |

          @Html.ActionLink("Delete", "Delete", new { id=item.AlbumId })
     </td>
     <td>
          @Html.DisplayFor(modelItem => item.Genre.Name)
     </td>
     <td>
          @Truncate(item.Artist.Name, 25)
     </td>
     <td>
          @Truncate(item.Title, 25)
     </td>
     <td>
          @Html.DisplayFor(modelItem => item.Price)
     </td>
</tr>