//#define Explicit

using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public InstructorIndexData Instructor { get; set; }

#if Explicit
        public async Task OnGetAsync(int? id, int? courseID)
        {
            Instructor = new InstructorIndexData();
            Instructor.Instructors = await _context.Instructors
                  .Include(i => i.OfficeAssignment)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                  //.Include(i => i.CourseAssignments)
                  //    .ThenInclude(i => i.Course)
                  //        .ThenInclude(i => i.Enrollments)
                  //            .ThenInclude(i => i.Student)
                  // .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();


            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = Instructor.Instructors.Where(
                    i => i.ID == id.Value).Single();
                Instructor.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                var selectedCourse = Instructor.Courses.Where(x => x.CourseID == courseID).Single();
                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                Instructor.Enrollments = selectedCourse.Enrollments;
            }
        }
#else
        public async Task OnGetAsync(int? id, int? courseID)
        {
            Instructor = new InstructorIndexData();
            Instructor.Instructors = await _context.Instructors
               .Include(i => i.OfficeAssignment)
               .Include(i => i.CourseAssignments)
                 .ThenInclude(i => i.Course)
                     .ThenInclude(i => i.Department)
                 .Include(i => i.CourseAssignments)
                     .ThenInclude(i => i.Course)
                         .ThenInclude(i => i.Enrollments)
                             .ThenInclude(i => i.Student)
               .AsNoTracking()
               .OrderBy(i => i.LastName)
               .ToListAsync();

            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = Instructor.Instructors.Where(
                    i => i.ID == id.Value).Single();
                Instructor.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                Instructor.Enrollments = Instructor.Courses.Where(
                    x => x.CourseID == courseID).Single().Enrollments;
            }
        }
#endif
    }
}
