Public Class ProductController
     Inherits System.Web.Mvc.Controller

     Function Index()
          ' Add action logic here
          Throw New NotImplementedException()
     End Function

     Function Details(ByVal Id As Integer)
          Dim product As New Product(Id, "Laptop")
          Return View("Details", product)
     End Function
End Class