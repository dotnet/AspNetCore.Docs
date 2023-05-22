using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.ViewModels;

namespace ContosoUniversity
{
    public static class Utility
    {
        /// <summary>
        /// Returns a list of course IDs, titles, and whether or not the instructor
        /// is assigned to this course.
        /// </summary>
        /// <param name="context">DB context of calling procedure</param>
        /// <param name="instructor">Instructor</param>
        /// <returns>List of CourseAssigned objects for Instructor</returns>
        static public List<CourseAssigned> ReturnCoursesAssigned(SchoolContext context, Instructor instructor)
        {
            List<CourseAssigned> CoursesAssigned = new();
            var instructorCourseIDs = new HashSet<int>();

            if (instructor.Courses is not null)
            {
                instructorCourseIDs = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            }
            foreach (var course in context.Courses)
            {
                CoursesAssigned.Add(
                    new CourseAssigned
                    {
                        CourseID = course.CourseID,
                        Title = course.Title is null ? string.Empty : course.Title,
                        Assigned = instructorCourseIDs.Contains(course.CourseID)
                    }
                    );
            }
            return CoursesAssigned;
        }
    }
}
