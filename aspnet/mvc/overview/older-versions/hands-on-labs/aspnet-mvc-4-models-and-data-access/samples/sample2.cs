public ActionResult Browse(string genre)
{
    // Retrieve Genre and its Associated Albums from database
    var genreModel = new Genre
    {
        Name = genre,
        Albums = this.storeDB.Albums.ToList()
    };

    return this.View(genreModel);
}