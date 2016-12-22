using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    Public Class MoviesController 
        Inherits System.Web.Mvc.Controller

             Private _repository As IMovieRepository

             Sub New()
                  Me.New(New MovieRepository())
             End Sub

             Sub New(ByVal repository As IMovieRepository)
                  _repository = repository
             End Sub

             Function Index()
                  Return View(_repository.ListAll())
             End Function
    End Class
}