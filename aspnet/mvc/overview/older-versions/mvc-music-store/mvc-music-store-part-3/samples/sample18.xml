@model IEnumerable<MvcMusicStore.Models.Genre>
@{
    ViewBag.Title = "Store";
}
<h3>Browse Genres</h3>
<p>
    Select from @Model.Count()
genres:</p>
<ul>
    @foreach (var genre in Model)
    {
        <li>@genre.Name</li>
    }
</ul>