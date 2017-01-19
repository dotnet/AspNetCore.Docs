<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Add()
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Add(ByVal form As FormCollection)
        Dim movieToAdd As New Movie()

        ' Deserialize (Include white list!)
        TryUpdateModel(movieToAdd, New String() {"Title", "Director"}, form.ToValueProvider())

        ' Validate
        If String.IsNullOrEmpty(movieToAdd.Title) Then
            ModelState.AddModelError("Title", "Title is required!")
        End If
        If String.IsNullOrEmpty(movieToAdd.Director) Then
            ModelState.AddModelError("Director", "Director is required!")
        End If

        ' If valid, save movie to database
        If (ModelState.IsValid) Then
            _db.AddToMovieSet(movieToAdd)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ' Otherwise, reshow form
        Return View(movieToAdd)
    End Function

End Class