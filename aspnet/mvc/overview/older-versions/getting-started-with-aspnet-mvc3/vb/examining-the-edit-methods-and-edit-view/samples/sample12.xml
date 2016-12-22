Public Function SearchIndex(ByVal id As String) As ActionResult
Dim searchString As String = id
Dim movies = From m In db.Movies
             Select m

If Not String.IsNullOrEmpty(searchString) Then
	movies = movies.Where(Function(s) s.Title.Contains(searchString))
End If

Return View(movies)
End Function