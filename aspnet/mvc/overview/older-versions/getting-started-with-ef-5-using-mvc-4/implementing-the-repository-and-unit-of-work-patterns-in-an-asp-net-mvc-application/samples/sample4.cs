using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.DAL;
using PagedList;

namespace ContosoUniversity.Controllers
{
   public class StudentController : Controller
   {
      private IStudentRepository studentRepository;

      public StudentController()
      {
         this.studentRepository = new StudentRepository(new SchoolContext());
      }

      public StudentController(IStudentRepository studentRepository)
      {
         this.studentRepository = studentRepository;
      }

      //
      // GET: /Student/

      public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
      {
         ViewBag.CurrentSort = sortOrder;
         ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
         ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

         if (searchString != null)
         {
            page = 1;
         }
         else
         {
            searchString = currentFilter;
         }
         ViewBag.CurrentFilter = searchString;

         var students = from s in studentRepository.GetStudents()
                        select s;
         if (!String.IsNullOrEmpty(searchString))
         {
            students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                   || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
         }
         switch (sortOrder)
         {
            case "name_desc":
               students = students.OrderByDescending(s => s.LastName);
               break;
            case "Date":
               students = students.OrderBy(s => s.EnrollmentDate);
               break;
            case "date_desc":
               students = students.OrderByDescending(s => s.EnrollmentDate);
               break;
            default:  // Name ascending 
               students = students.OrderBy(s => s.LastName);
               break;
         }

         int pageSize = 3;
         int pageNumber = (page ?? 1);
         return View(students.ToPagedList(pageNumber, pageSize));
      }

      //
      // GET: /Student/Details/5

      public ViewResult Details(int id)
      {
         Student student = studentRepository.GetStudentByID(id);
         return View(student);
      }

      //
      // GET: /Student/Create

      public ActionResult Create()
      {
         return View();
      }

      //
      // POST: /Student/Create

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(
         [Bind(Include = "LastName, FirstMidName, EnrollmentDate")]
           Student student)
      {
         try
         {
            if (ModelState.IsValid)
            {
               studentRepository.InsertStudent(student);
               studentRepository.Save();
               return RedirectToAction("Index");
            }
         }
         catch (DataException /* dex */)
         {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
         }
         return View(student);
      }

      //
      // GET: /Student/Edit/5

      public ActionResult Edit(int id)
      {
         Student student = studentRepository.GetStudentByID(id);
         return View(student);
      }

      //
      // POST: /Student/Edit/5

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(
         [Bind(Include = "LastName, FirstMidName, EnrollmentDate")]
         Student student)
      {
         try
         {
            if (ModelState.IsValid)
            {
               studentRepository.UpdateStudent(student);
               studentRepository.Save();
               return RedirectToAction("Index");
            }
         }
         catch (DataException /* dex */)
         {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
         }
         return View(student);
      }

      //
      // GET: /Student/Delete/5

      public ActionResult Delete(bool? saveChangesError = false, int id = 0)
      {
         if (saveChangesError.GetValueOrDefault())
         {
            ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
         }
         Student student = studentRepository.GetStudentByID(id);
         return View(student);
      }

      //
      // POST: /Student/Delete/5

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id)
      {
         try
         {
            Student student = studentRepository.GetStudentByID(id);
            studentRepository.DeleteStudent(id);
            studentRepository.Save();
         }
         catch (DataException /* dex */)
         {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
         }
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         studentRepository.Dispose();
         base.Dispose(disposing);
      }
   }
}