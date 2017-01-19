Public Class MoviesController
        Inherits System.Web.Mvc.Controller

        Private db As MovieDBContext = New MovieDBContext

        '
        ' GET: /Movies/

        Function Index() As ViewResult
            Return View(db.Movies.ToList())
        End Function