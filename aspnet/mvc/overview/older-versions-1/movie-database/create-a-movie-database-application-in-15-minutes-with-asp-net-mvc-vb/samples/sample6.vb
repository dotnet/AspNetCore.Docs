Function Edit(ByVal id As Integer) As ActionResult

            Dim movieToEdit = (From m In _db.MovieSet _

                           Where m.Id = id _

                           Select m).First() 

            Return View(movieToEdit)

        End Function 

        <AcceptVerbs(HttpVerbs.Post)> _

        Function Edit(ByVal movieToEdit As Movie) As ActionResult 

            Dim originalMovie = (From m In _db.MovieSet _

                       Where m.Id = movieToEdit.Id _

                       Select m).First() 

            If Not ModelState.IsValid Then

                Return View(originalMovie)

            End If 

            _db.ApplyPropertyChanges(originalMovie.EntityKey.EntitySetName, movieToEdit)

            _db.SaveChanges() 

            Return RedirectToAction("Index")

        End Function