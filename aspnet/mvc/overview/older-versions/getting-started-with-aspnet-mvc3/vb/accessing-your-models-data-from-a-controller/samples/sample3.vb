Function Index() As ViewResult
            Return View(db.Movies.ToList())
       End Function