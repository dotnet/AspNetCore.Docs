using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using RazorPagesMovie.Utilities;

namespace RazorPagesMovie.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        #region snippet1
        [BindProperty]
        public FileUpload FileUpload { get; set; }
        #endregion

        #region snippet2
        public IList<Schedule> Schedule { get; private set; }
        #endregion

        #region snippet3
        public async Task OnGetAsync()
        {
            Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
        }
        #endregion

        #region snippet4
        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return Page();
            }

            var publicScheduleData = 
                await FileHelpers.ProcessSchedule(FileUpload.UploadPublicSchedule, ModelState);

            var privateScheduleData = 
                await FileHelpers.ProcessSchedule(FileUpload.UploadPrivateSchedule, ModelState);

            // Perform a second check to catch ProcessSchedule method
            // violations.
            if (!ModelState.IsValid)
            {
                Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return Page();
            }

            var schedule = new Schedule() 
                { 
                    PublicSchedule = publicScheduleData, 
                    PublicScheduleSize = FileUpload.UploadPublicSchedule.Length, 
                    PrivateSchedule = privateScheduleData, 
                    PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length, 
                    Title = FileUpload.Title, 
                    UploadDT = DateTime.UtcNow
                };

            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        #endregion
    }
}
