Public Class HomeController
Inherits Controller

Private _db As New MoviesDBEntities()

Public Function Index() As ActionResult
	Return View(_db.MovieSet.ToList())
End Function

Public Function Create() As ActionResult
	Return View()
End Function

<AcceptVerbs(HttpVerbs.Post)> _
Public Function Create(<Bind(Exclude := "Id")> ByVal movieToCreate As Movie) As ActionResult
        ' Validate
        If (Not ModelState.IsValid) Then
        Return View()
        End If

	' Add to database
	Try
		_db.AddToMovieSet(movieToCreate)
		_db.SaveChanges()

		Return RedirectToAction("Index")
	Catch
		Return View()
	End Try
End Function

End Class