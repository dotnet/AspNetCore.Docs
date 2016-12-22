Public Class ProductController
     Inherits System.Web.Mvc.Controller

     Function Index()
          ' Add action logic here
          Throw New NotImplementedException()
     End Function

     Function Details(ByVal Id As Integer)
          If Id < 1 Then
               Return RedirectToAction("Index")
          End If
          Dim product As New Product(Id, "Laptop")
          Return View("Details", product)
     End Function
End Class