@model MvcMusicStore.Models.Album
@{
     ViewBag.Title = "Delete";
}
<h2>Delete Confirmation</h2>

<h3> Are you sure you want to delete the album title <strong>@Model.Title </strong> ? </h3>

@using (Html.BeginForm()) {
     <p>
          <input type="submit" value="Delete" /> |
          @Html.ActionLink("Back to List", "Index")
     </p>
}