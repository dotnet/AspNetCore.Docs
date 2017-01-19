Public Class MoviesController
    Inherits System.Web.Mvc.Controller

    Private _dataContext As MovieDataContext

    Public Sub New()
        _dataContext = New MovieDataContext()
    End Sub

    <OutputCache(Duration:=Integer.MaxValue, VaryByParam:="none")> _
    Public Function Master()
        ViewData.Model = (From m In _dataContext.Movies _
                          Select m).ToList()
        Return View()
    End Function

    <OutputCache(Duration:=Integer.MaxValue, VaryByParam:="id")> _
    Public Function Details(ByVal id As Integer)
        ViewData.Model = _dataContext.Movies.SingleOrDefault(Function(m) m.Id = id)
        Return View()
    End Function

End Class