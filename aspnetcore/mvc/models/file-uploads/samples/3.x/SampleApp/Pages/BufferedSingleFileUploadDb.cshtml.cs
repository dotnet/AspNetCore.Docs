using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SampleApp.Data;
using SampleApp.Models;
using SampleApp.Utilities;

namespace SampleApp.Pages
{
    public class BufferedSingleFileUploadDbModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt" };

        public BufferedSingleFileUploadDbModel(AppDbContext context, 
            IConfiguration config)
        {
            _context = context;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }

        public string Result { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            var formFileContent = 
                await FileHelpers.ProcessFormFile<BufferedSingleFileUploadDb>(
                    FileUpload.FormFile, ModelState, _permittedExtensions, 
                    _fileSizeLimit);

            // Perform a second check to catch ProcessFormFile method
            // violations. If any validation check fails, return to the
            // page.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            var file = new AppFile
            {
                Content = formFileContent, 
                UntrustedName = FileUpload.FormFile.FileName, 
                Note = FileUpload.Note,
                Size = FileUpload.FormFile.Length, 
                UploadDT = DateTime.UtcNow
            };

            _context.File.Add(file);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }

        [Display(Name="Note")]
        [StringLength(50, MinimumLength = 0)]
        public string Note { get; set; }
    }
}
