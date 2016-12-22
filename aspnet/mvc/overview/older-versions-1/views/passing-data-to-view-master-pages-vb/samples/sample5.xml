<HandleError()> _
Public Class MoviesController
     Inherits ApplicationController

     ''' <summary>
     ''' Show list of all movies
     ''' </summary>
     Function Index()
          ViewData("movies") = From m In DataContext.Movies _
                    Select m
          Return View()

      End Function

     ''' <summary>
     ''' Show list of movies in a category
     ''' </summary>
     Function Details(ByVal id As Integer)
          ViewData("movies") = From m In DataContext.Movies _
                    Where m.CategoryId = id _
                    Select m
          Return View()
     End Function

End Class