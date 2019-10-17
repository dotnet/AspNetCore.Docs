using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SampleApp.Utilities;

namespace SampleApp.Pages
{
    public class BufferedMultipleFileUploadPhysicalModel : PageModel
    {
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt" };
        private readonly string _targetFilePath;

        public BufferedMultipleFileUploadPhysicalModel(IConfiguration config)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }

        [BindProperty]
        public BufferedMultipleFileUploadPhysical FileUpload { get; set; }

        public string Result { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            foreach (var formFile in FileUpload.FormFiles)
            {
                var formFileContent = 
                    await FileHelpers
                        .ProcessFormFile<BufferedMultipleFileUploadPhysical>(
                            formFile, ModelState, _permittedExtensions, 
                            _fileSizeLimit);

                if (!ModelState.IsValid)
                {
                    Result = "Please correct the form.";

                    return Page();
                }

                // For the file name of the uploaded file stored
                // server-side, use Path.GetRandomFileName to generate a safe
                // random file name.
                var trustedFileNameForFileStorage = Path.GetRandomFileName();
                var filePath = Path.Combine(
                    _targetFilePath, trustedFileNameForFileStorage);

                // **WARNING!**
                // In the following example, the file is saved without
                // scanning the file's contents. In most production
                // scenarios, an anti-virus/anti-malware scanner API
                // is used on the file before making the file available
                // for download or for use by other systems. 
                // For more information, see the topic that accompanies 
                // this sample.

                using (var fileStream = System.IO.File.Create(filePath))
                {
                    await fileStream.WriteAsync(formFileContent);

                    // To work directly with the FormFiles, use the following
                    // instead:
                    //await formFile.CopyToAsync(fileStream);
                }
            }

            return RedirectToPage("./Index");
        }
    }

    public class BufferedMultipleFileUploadPhysical
    {
        [Required]
        [Display(Name="File")]
        public List<IFormFile> FormFiles { get; set; }

        [Display(Name="Note")]
        [StringLength(50, MinimumLength = 0)]
        public string Note { get; set; }
    }
}
