Public Class DataController
     Inherits System.Web.Mvc.Controller

     <OutputCache(Duration:=10)> _
     Function Index()
          Return DateTime.Now.ToString("T")

     End Function

End Class