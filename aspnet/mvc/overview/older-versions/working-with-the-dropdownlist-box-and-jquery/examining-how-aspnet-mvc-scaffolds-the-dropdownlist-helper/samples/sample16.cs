private void SetGenreArtistViewBag(int? GenreID = null, int? ArtistID = null) {
    if (GenreID == null)

        ViewBag.Genres = new SelectList(db.Genres, "GenreId", "Name");

    else

        ViewBag.Genres = new SelectList(db.Genres.ToArray(), "GenreId", "Name", GenreID);

    if (ArtistID == null)

        ViewBag.Artists = new SelectList(db.Artists, "ArtistId", "Name");

    else

        ViewBag.Artists = new SelectList(db.Artists, "ArtistId", "Name", ArtistID);

}