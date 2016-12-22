using System;
using System.Linq;
using ContosoUniversityModelBinding.Models;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ContosoUniversityModelBinding.BLL
{
    public class SchoolBL : IDisposable
    {
        SchoolContext db = new SchoolContext();

        public IQueryable<Student> GetStudents([Control] AcademicYear? displayYear)
        {
            var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));

            if (displayYear != null)
            {
                query = query.Where(s => s.Year == displayYear);
            }

            return query;
        }

        public void InsertStudent(ModelMethodContext context)
        {
            var item = new Student();

            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.Students.Add(item);
                db.SaveChanges();
            }
        }

        public void DeleteStudent(int studentID, ModelMethodContext context)
        {
            var item = new Student { StudentID = studentID };
            db.Entry(item).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                context.ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", studentID));
            }
        }

        public void UpdateStudent(int studentID, ModelMethodContext context)
        {
            Student item = null;
            item = db.Students.Find(studentID);
            if (item == null)
            {
                context.ModelState.AddModelError("", String.Format("Item with id {0} was not found", studentID));
                return;
            }

            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        public IQueryable<Enrollment> GetCourses([QueryString] int? studentID)
        {
            var query = db.Enrollments.Include(e => e.Course)
                .Where(e => e.StudentID == studentID);
            return query;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}