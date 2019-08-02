#region snippet_all
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

        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            InstructorData = new InstructorIndexData();
            #region snippet_EagerLoading
            InstructorData.Instructors = await _context.Instructors
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
            #endregion

            #region snippet_SelectInstructor
            if (id != null)
            {
                InstructorID = id.Value;
                Instructor instructor = InstructorData.Instructors
                    .Where(i => i.ID == id.Value).Single();
                InstructorData.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }
            #endregion

            #region snippet_SelectCourse
            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = InstructorData.Courses
                    .Where(x => x.CourseID == courseID).Single();
                InstructorData.Enrollments = selectedCourse.Enrollments;
            }
            #endregion
        }
    }
}
#endregion