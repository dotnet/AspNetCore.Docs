'
' GET: /Movies/Create

Function Create() As ViewResult
    Return View()
End Function

'
' POST: /Movies/Create

<HttpPost()>
Function Create(movie As Movie) As ActionResult
    If ModelState.IsValid Then
        db.Movies.Add(movie)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End If

    Return View(movie)
End Function