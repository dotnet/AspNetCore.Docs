if (!string.IsNullOrEmpty(movieGenre))
{
	movies = movies.Where(x => x.Genre == movieGenre);
}