<fieldset>
     <legend>Album</legend>

     @Html.HiddenFor(model => model.AlbumId)

     <div class="editor-label">
          @Html.LabelFor(model => model.Title)
     </div>
     <div class="editor-field">
          @Html.EditorFor(model => model.Title)
          @Html.ValidationMessageFor(model => model.Title)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.Price)
     </div>
     <div class="editor-field">
          @Html.EditorFor(model => model.Price)
          @Html.ValidationMessageFor(model => model.Price)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.AlbumArtUrl)
     </div>
     <div class="editor-field">
          @Html.EditorFor(model => model.AlbumArtUrl)
          @Html.ValidationMessageFor(model => model.AlbumArtUrl)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.Artist)
     </div>
     <div class="editor-field">
          @Html.DropDownList("ArtistId", (SelectList) ViewData["Artists"])
          @Html.ValidationMessageFor(model => model.ArtistId)
     </div>

     <div class="editor-label">
          @Html.LabelFor(model => model.Genre)
     </div>
     <div class="editor-field">
          @Html.DropDownList("GenreId", (SelectList) ViewData["Genres"])
          @Html.ValidationMessageFor(model => model.GenreId)
     </div>

     <p>
          <input type="submit" value="Save" />
     </p>
</fieldset>