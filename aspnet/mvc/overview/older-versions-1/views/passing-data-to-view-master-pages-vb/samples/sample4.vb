Public MustInherit Class ApplicationController
     Inherits System.Web.Mvc.Controller

     Private _dataContext As New MovieDataContext()

     Public ReadOnly Property DataContext() As MovieDataContext
          Get

               Return _dataContext
          End Get
     End Property


     Sub New()
          ViewData("categories") = From c In DataContext.MovieCategories _
                    Select c
     End Sub

End Class