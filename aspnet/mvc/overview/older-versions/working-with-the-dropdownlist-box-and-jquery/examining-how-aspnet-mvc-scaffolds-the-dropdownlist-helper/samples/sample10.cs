private void SetGenreArtistViewBag(int? GenreID = null, int? ArtistID = null) {

    if (GenreID == null)

        ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");

    else

        ViewBag.GenreId = new SelectList(db.Genres.ToArray(), "GenreId", "Name", GenreID);

    if (ArtistID == null)

        ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");

    else

        ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", ArtistID);

}