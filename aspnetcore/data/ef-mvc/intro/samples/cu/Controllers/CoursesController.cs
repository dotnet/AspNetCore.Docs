//#define ScaffoldedCode
#define RevisedIndexMethod

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;    
        }

        // GET: Courses
#if ScaffoldedCode
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Courses
                .Include(c => c.Department)
                .AsNoTracking();
            return View(await schoolContext.ToListAsync());
        }
#elif RevisedIndexMethod
// <snippet_RevisedIndexMethod>
        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses
                .Include(c => c.Department)
                .AsNoTracking();
            return View(await courses.ToListAsync());
        }
// </snippet_RevisedIndexMethod>
#endif
        // GET: Courses/Details/5
// <snippet_Details>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
// </snippet_Details>

        // GET: Courses/Create
// <snippet_CreateGet>
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }
// </snippet_CreateGet>
        // POST: Courses/Create
// <snippet_CreatePost>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,Credits,DepartmentID,Title")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }
// </snippet_CreatePost>

        // GET: Courses/Edit/5
// <snippet_EditGet>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }
// </snippet_EditGet>


        // POST: Courses/Edit/5
// <snippet_EditPost>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseID == id);

            if (await TryUpdateModelAsync<Course>(courseToUpdate,
                "",
                c => c.Credits, c => c.DepartmentID, c => c.Title))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return View(courseToUpdate);
        }
// </snippet_EditPost>

// <snippet_Departments>
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
// </snippet_Departments>

        // GET: Courses/Delete/5
// <snippet_DeleteGet>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
// </snippet_DeleteGet>

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

// <snippet_UpdateGet>
        public IActionResult UpdateCourseCredits()
        {
            return View();
        }
// </snippet_UpdateGet>

// <snippet_UpdatePost>
        [HttpPost]
        public async Task<IActionResult> UpdateCourseCredits(int? multiplier)
        {
            if (multiplier != null)
            {
                ViewData["RowsAffected"] = 
                    await _context.Database.ExecuteSqlCommandAsync(
                        "UPDATE Course SET Credits = Credits * {0}",
                        parameters: multiplier);
            }
            return View();
        }
// </snippet_UpdatePost>
    }
}
