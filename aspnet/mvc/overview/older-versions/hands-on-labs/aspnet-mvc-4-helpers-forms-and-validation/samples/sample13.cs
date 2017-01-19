...
<fieldset>
     <legend>Album</legend>

     <div class="editor-label">
          @Html.LabelFor(model => model.GenreId, "Genre")
     </div>
     <div class="editor-field">
          @Html.DropDownList("GenreId", String.Empty)
          @Html.ValidationMessageFor(model => model.GenreId)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.ArtistId, "Artist")
     </div>
     <div class="editor-field">
          @Html.DropDownList("ArtistId", String.Empty)
          @Html.ValidationMessageFor(model => model.ArtistId)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.Title)
     </div>
    ...