# Update the generated pages

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation isn't ideal. We don't want to see the time (12:00:00 AM in the image below) and **ReleaseDate** should be **Release Date** (two words).

![Movie application open in Chrome showing movie data](../../tutorials/razor-pages/sql/_static/m55.png)

## Update the generated code

Open the *Models/Movie.cs* file and add the highlighted lines shown in the following code:

[!code-csharp[](code/Models/Movie.cs?highlight=2,11-12)]
