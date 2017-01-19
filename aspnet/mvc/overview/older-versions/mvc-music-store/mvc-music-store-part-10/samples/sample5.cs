@model IEnumerable<MvcMusicStore.Models.Genre>
<ul id="categories">
    @foreach (var genre in Model)
    {
        <li>@Html.ActionLink(genre.Name,
                "Browse", "Store", 
                new { Genre = genre.Name }, null)
        </li>
    }
</ul>