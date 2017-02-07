<p>
    @Html.ActionLink("Create New", "Create")
    @Code
    ViewData("Title") = "SearchIndex"
    Using (Html.BeginForm())
         @<p> Genre: @Html.DropDownList("movieGenre", "All")
         Title: @Html.TextBox("SearchString") 
         <input type="submit" value="Filter" /></p>
        End Using
End Code
</p>