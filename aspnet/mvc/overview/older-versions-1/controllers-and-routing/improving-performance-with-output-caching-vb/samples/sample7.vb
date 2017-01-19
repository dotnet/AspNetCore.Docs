Public Class ProfileController
    Inherits System.Web.Mvc.Controller

    <OutputCache(CacheProfile:="Cache1Hour")> _
    Function Index()
        Return DateTime.Now.ToString("T")
    End Function

End Class