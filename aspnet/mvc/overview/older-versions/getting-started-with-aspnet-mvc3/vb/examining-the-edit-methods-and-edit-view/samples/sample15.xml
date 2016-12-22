Public Function SearchIndex(ByVal movieGenre As String, ByVal searchString As String) As ActionResult
    Dim GenreLst = New List(Of String)()

    Dim GenreQry = From d In db.Movies
                   Order By d.Genre
                   Select d.Genre
    GenreLst.AddRange(GenreQry.Distinct())
    ViewBag.movieGenre = New SelectList(GenreLst)

    Dim movies = From m In db.Movies
                 Select m

    If Not String.IsNullOrEmpty(searchString) Then
        movies = movies.Where(Function(s) s.Title.Contains(searchString))
    End If

    If String.IsNullOrEmpty(movieGenre) Then
        Return View(movies)
    Else
        Return View(movies.Where(Function(x) x.Genre = movieGenre))
    End If

End Function