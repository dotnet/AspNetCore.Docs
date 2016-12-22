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