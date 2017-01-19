@model IEnumerable<MvcMusicStore.Models.Album>

@{
     ViewBag.Title = "Index";
}

<h2>Index</h2>

<p>
     @Html.ActionLink("Create New", "Create")
</p>
<table>
     <tr>
          <th>
                @Html.DisplayNameFor(model => model.GenreId)
          </th>
          <th>
                @Html.DisplayNameFor(model => model.ArtistId)
          </th>
          <th>
                @Html.DisplayNameFor(model => model.Title)
          </th>
          <th>
                @Html.DisplayNameFor(model => model.Price)
          </th>
          <th>
                @Html.DisplayNameFor(model => model.AlbumArtUrl)
          </th>
          <th></th>
     </tr>

@foreach (var item in Model) {
     <tr>
          <td>
                @Html.DisplayFor(modelItem => item.GenreId)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.ArtistId)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Title)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.Price)
          </td>
          <td>
                @Html.DisplayFor(modelItem => item.AlbumArtUrl)
          </td>
          <td>
                @Html.ActionLink("Edit", "Edit", new { id=item.AlbumId }) |
                @Html.ActionLink("Details", "Details", new { id=item.AlbumId }) |
                @Html.ActionLink("Delete", "Delete", new { id=item.AlbumId })
          </td>
     </tr>
}

</table>