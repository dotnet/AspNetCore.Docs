using System;
using System.Web.Mvc;
using CustomerFeedback.Models;
namespace CustomerFeedback.Controllers
{
     [HandleError]
     public class HomeController : Controller
     {
          private FeedbackDataContext db = new FeedbackDataContext();

          public ActionResult Index()
          {
               return View(db.Feedbacks);
          }

          public ActionResult Create(string message)
          {
               // Add feedback
               var newFeedback = new Feedback();
               newFeedback.Message = Server.HtmlEncode(message);
               newFeedback.EntryDate = DateTime.Now;
               db.Feedbacks.InsertOnSubmit(newFeedback);

               db.SubmitChanges();

               // Redirect
               return RedirectToAction("Index");
          }
     }
}