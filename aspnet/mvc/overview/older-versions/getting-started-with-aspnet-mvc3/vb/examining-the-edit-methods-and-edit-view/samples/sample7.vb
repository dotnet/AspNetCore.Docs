Public Function Edit(Optional ByVal id As Integer = 0) As ActionResult
    Dim movie As Movie = db.Movies.Find(id)
    If movie Is Nothing Then
        Return HttpNotFound()
    End If
    Return View(movie)
End Function