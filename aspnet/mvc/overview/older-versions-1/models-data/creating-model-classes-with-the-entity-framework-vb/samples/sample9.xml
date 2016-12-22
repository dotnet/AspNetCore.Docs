<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Delete(ByVal id As Integer)
        ' Get movie to delete
        Dim movieToDelete As Movie = _db.MovieSet.First(Function(m) m.Id = id)

        ' Delete 
        _db.DeleteObject(movieToDelete)
        _db.SaveChanges()

        ' Show Index view
        Return RedirectToAction("Index")
    End Function

End Class