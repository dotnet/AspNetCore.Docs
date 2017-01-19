Public Class HomeController
     Inherits System.Web.Mvc.Controller

     Private db As New FeedbackDataContext()

     Function Index()
          Return View(db.Feedbacks)
     End Function

     Function Create(ByVal message As String)
          ' Add feedback
          Dim newFeedback As New Feedback()
          newFeedback.Message = Server.HtmlEncode(message)

          newFeedback.EntryDate = DateTime.Now
          db.Feedbacks.InsertOnSubmit(newFeedback)
          db.SubmitChanges()

          ' Redirect
          Return RedirectToAction("Index")
     End Function

End Class