Public Class HomeController

        Inherits System.Web.Mvc.Controller 

        '

        ' GET: /Home/ 

        Function Index() As ActionResult

            Return View()

        End Function 

        '

        ' GET: /Home/Details/5 

        Function Details(ByVal id As Integer) As ActionResult

            Return View()

        End Function 

        '

        ' GET: /Home/Create 

        Function Create() As ActionResult

            Return View()

        End Function 

        '

        ' POST: /Home/Create 

        <AcceptVerbs(HttpVerbs.Post)> _

        Function Create(ByVal collection As FormCollection) As ActionResult

            Try

                ' TODO: Add insert logic here

                Return RedirectToAction("Index")

            Catch

                Return View()

            End Try

        End Function 

        '

        ' GET: /Home/Edit/5 

        Function Edit(ByVal id As Integer) As ActionResult

            Return View()

        End Function 

        '

        ' POST: /Home/Edit/5 

        <AcceptVerbs(HttpVerbs.Post)> _

        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult

            Try

                ' TODO: Add update logic here 

                Return RedirectToAction("Index")

            Catch

                Return View()

            End Try

        End Function

    End Class