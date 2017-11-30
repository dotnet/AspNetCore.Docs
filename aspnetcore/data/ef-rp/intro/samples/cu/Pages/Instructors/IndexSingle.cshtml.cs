#define single
#if single
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        #region snippet_single
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
                InstructorID = id.Value;
                Instructor instructor = Instructor.Instructors.Single(
                    i => i.ID == id.Value);
                Instructor.Courses = instructor.CourseAssignments.Select(
                    s => s.Course);
            }

            if (courseID != null)
            {
                CourseID = courseID.Value;
                Instructor.Enrollments = Instructor.Courses.Single(
                    x => x.CourseID == courseID).Enrollments;
            }
        }
        #endregion
    }
}
#endif