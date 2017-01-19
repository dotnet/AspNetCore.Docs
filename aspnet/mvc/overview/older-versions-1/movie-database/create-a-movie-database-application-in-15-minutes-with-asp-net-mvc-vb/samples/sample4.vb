Function Create() As ActionResult

            Return View()

        End Function 

        <AcceptVerbs(HttpVerbs.Post)> _

        Function Create(<_bind28_exclude3a_3d_22_id22_29_> ByVal movieToCreate As Movie) As ActionResult 

            If Not ModelState.IsValid Then

                Return View()

            End If 

            _db.AddToMovieSet(movieToCreate)

            _db.SaveChanges() 

            Return RedirectToAction("Index")

        End Function 
<!--_bind28_exclude3a_3d_22_id22_29_-->