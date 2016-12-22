<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Edit(ByVal id As Integer)
        ' Get movie to update
        Dim movieToUpdate As Movie = _db.MovieSet.First(Function(m) m.Id = id)
        ViewData.Model = movieToUpdate
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Edit(ByVal form As FormCollection)

        ' Get movie to update
        Dim id As Integer = Integer.Parse(form("id"))
        Dim movieToUpdate As Movie = _db.MovieSet.First(Function(m) m.Id = id)

        ' Deserialize (Include white list!)
        TryUpdateModel(movieToUpdate, New String() {"Title", "Director"}, form.ToValueProvider)

        ' Validate
        If String.IsNullOrEmpty(movieToUpdate.Title) Then
            ModelState.AddModelError("Title", "Title is required!")
        End If
        If String.IsNullOrEmpty(movieToUpdate.Director) Then
            ModelState.AddModelError("Director", "Director is required!")
        End If

        ' If valid, save movie to database
        If (ModelState.IsValid) Then
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ' Otherwise, reshow form
        Return View(movieToUpdate)
    End Function

End Class