<table>
    <tr>
      <th></th>
      <th>Genre</th>
      <th>Artist</th>
      <th>Title</th>
      <th>Price</th>
    </tr>

    @foreach (var item in Model) {
     <tr>
          <td>
                @Html.ActionLink("Edit", "Edit", new { id=item.AlbumId }) |

                @Html.ActionLink("Delete", "Delete", new { id=item.AlbumId })
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Genre.Name)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Artist.Name)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Title)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Price)
          </td>
     </tr>
    }
</table>