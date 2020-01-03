using ModelBindingSample.Models;
using ModelBindingSample.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModelBindingSample.Pages.InstructorsWithCollection
{
    public class InstructorsPageModel : PageModel
    {
        protected static List<InstructorWithCollection> _instructorsInMemoryStore = new List<InstructorWithCollection>();
        protected static List<Course> _courses = new List<Course>();
        public List<AssignedCourseData> AssignedCourseDataList;

        public InstructorsPageModel()
        {
            if (_instructorsInMemoryStore.Count == 0)
            {
                InitializeInstructors();
            }
        }

        private void InitializeInstructors()
        {
            _courses = new List<Course>
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
            };

            _instructorsInMemoryStore.Add(new InstructorWithCollection
            {
                ID = 1,
                FirstMidName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11"),
                Courses = _courses.Take(3).ToList()
            });
            _instructorsInMemoryStore.Add(new InstructorWithCollection
            {
                ID = 2,
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06"),
                Courses = new List<Course>()
            });
            _instructorsInMemoryStore.Add(new InstructorWithCollection
            {
                ID = 3,
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01"),
                Courses = _courses.Skip(3).Take(3).ToList()
            });

        }

        public void PopulateAssignedCourseData(InstructorWithCollection instructor)
        {
            var allCourses = _courses;
            var instructorCourses = new HashSet<int>(
                instructor.Courses.Select(c => c.CourseID));
            AssignedCourseDataList = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }

        public void UpdateInstructorCourses(string[] selectedCourses, InstructorWithCollection instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
                return;
            }
            if (instructorToUpdate.Courses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
            }
            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.Courses.Select(c => c.CourseID));
            foreach (var course in _courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Courses.Add(
                            new Course
                            {
                                CourseID = course.CourseID,
                                Title = course.Title,
                                Credits = course.Credits
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        Course courseToRemove
                            = instructorToUpdate
                                .Courses
                                .SingleOrDefault(i => i.CourseID == course.CourseID);
                        instructorToUpdate.Courses.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
