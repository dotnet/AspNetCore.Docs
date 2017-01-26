if (string.IsNullOrEmpty(movieGenre))
        return View(movies);
else
{
	return View(movies.Where(x => x.Genre == movieGenre));
}