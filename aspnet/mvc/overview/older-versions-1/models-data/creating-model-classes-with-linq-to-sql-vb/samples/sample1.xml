<HandleError()> _
Public Class HomeController

     Inherits System.Web.Mvc.Controller

     Function Index()
          Dim dataContext As New MovieDataContext()
          Dim movies = From m In dataContext.Movies _
               Select m
          return View(movies)
     End Function
End Class