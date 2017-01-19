If String.IsNullOrEmpty(movieGenre) Then
        Return View(movies)
    Else
        Return View(movies.Where(Function(x) x.Genre = movieGenre))
    End If