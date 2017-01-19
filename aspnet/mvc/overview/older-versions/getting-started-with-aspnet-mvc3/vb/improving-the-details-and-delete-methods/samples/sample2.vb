' GET: /Movies/Delete/5

 Public Function Delete(Optional ByVal id As Integer = 0) As ActionResult
     Dim movie As Movie = db.Movies.Find(id)
     If movie Is Nothing Then
         Return HttpNotFound()
     End If
     Return View(movie)
 End Function

 '
 ' POST: /Movies/Delete/5

 <HttpPost(), ActionName("Delete")>
 Public Function DeleteConfirmed(Optional ByVal id As Integer = 0) As ActionResult
     Dim movie As Movie = db.Movies.Find(id)
     If movie Is Nothing Then
         Return HttpNotFound()
     End If
     db.Movies.Remove(movie)
     db.SaveChanges()
     Return RedirectToAction("Index")
 End Function