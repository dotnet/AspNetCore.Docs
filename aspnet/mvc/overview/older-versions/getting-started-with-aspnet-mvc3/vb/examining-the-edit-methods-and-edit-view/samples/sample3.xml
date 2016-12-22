'
' GET: /Movies/Edit/5

Function Edit(id As Integer) As ViewResult
    Dim movie As Movie = db.Movies.Find(id)
    Return View(movie)
End Function

'
' POST: /Movies/Edit/5

<HttpPost()>
Function Edit(movie As Movie) As ActionResult
    If ModelState.IsValid Then
        db.Entry(movie).State = EntityState.Modified
        db.SaveChanges()
        Return RedirectToAction("Index")
    End If

    Return View(movie)
End Function