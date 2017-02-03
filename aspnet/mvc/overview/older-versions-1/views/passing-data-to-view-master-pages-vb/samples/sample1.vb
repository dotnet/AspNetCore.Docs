<HandleError()> _
Public Class HomeController
     Inherits System.Web.Mvc.Controller

     Private _dataContext As New MovieDataContext()

     ''' <summary>

     ''' Show list of all movies
     ''' </summary>
     Function Index()
          ViewData("categories") = From c In _dataContext.MovieCategories _
                    Select c
          ViewData("movies") = From m In _dataContext.Movies _
                    Select m
          Return View()
     End Function

     ''' <summary>
     ''' Show list of movies in a category
     ''' </summary>

     Function Details(ByVal id As Integer)
          ViewData("categories") = From c In _dataContext.MovieCategories _
                    Select c
          ViewData("movies") = From m In _dataContext.Movies _
                    Where m.CategoryId = id _
                    Select m
          Return View()
     End Function

End Class