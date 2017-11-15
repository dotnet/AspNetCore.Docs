using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(d => d.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }

            // Scaffolder added ViewData, I'll remove it once code is working.
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FirstMidName");
           ViewData["rowVersion"] = System.Text.Encoding.UTF8.GetString(Department.RowVersion);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, byte[] rowVersion)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var departmentToUpdate = await _context.Departments
                .Include(i => i.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            // null means it was deleted by another user.
            if (departmentToUpdate == null)
            {
                Department = new Department();
                // Fetch the posted data so we can display it with the error message.
                await TryUpdateModelAsync(Department);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
                ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName",
                    Department.InstructorID);
                return Page();
            }

            var orgRV = _context.Entry(departmentToUpdate)
                .Property("RowVersion").OriginalValue;

            //_context.Entry(departmentToUpdate)
            //    .Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Department>(  
                departmentToUpdate,
                "Department",
                s => s.Name, s => s.StartDate, s => s.Budget, s => s.InstructorID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted " +
                            "by another user.");
                    }
                    else
                    {
                        var dbValues = (Department)databaseEntry.ToObject();

                        if (dbValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", 
                                $"Current value: {dbValues.Name}");
                        }
                        if (dbValues.Budget != clientValues.Budget)
                        {
                            ModelState.AddModelError("Budget", 
                                $"Current value: {dbValues.Budget:c}");
                        }
                        if (dbValues.StartDate != clientValues.StartDate)
                        {
                            ModelState.AddModelError("StartDate", 
                                $"Current value: {dbValues.StartDate:d}");
                        }
                        if (dbValues.InstructorID != clientValues.InstructorID)
                        {
                            Instructor dbInstructor = await _context.Instructors
                               .FirstOrDefaultAsync(i => i.ID==dbValues.InstructorID);
                            ModelState.AddModelError("InstructorID", 
                                $"Current value: {dbInstructor?.FullName}");
                        }

                        ModelState.AddModelError(string.Empty, 
                "The record you attempted to edit "
              + "was modified by another user after you got the original value. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again. Otherwise click the Back to List hyperlink.");

                        departmentToUpdate.RowVersion = (byte[])dbValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
            return Page();
        }
    }
}
