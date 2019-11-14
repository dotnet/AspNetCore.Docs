using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SampleApp.Data;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IFileProvider _fileProvider;

        public IndexModel(AppDbContext context, IFileProvider fileProvider)
        {
            _context = context;
            _fileProvider = fileProvider;
        }

        public IList<AppFile> DatabaseFiles { get; private set; }
        public IDirectoryContents PhysicalFiles { get; private set; }

        public async Task OnGetAsync()
        {
            DatabaseFiles = await _context.File.AsNoTracking().ToListAsync();
            PhysicalFiles = _fileProvider.GetDirectoryContents(string.Empty);
        }

        public async Task<IActionResult> OnGetDownloadDbAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var requestFile = await _context.File.SingleOrDefaultAsync(m => m.Id == id);

            if (requestFile == null)
            {
                return Page();
            }

            // Don't display the untrusted file name in the UI. HTML-encode the value.
            return File(requestFile.Content, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.UntrustedName));
        }

        public IActionResult OnGetDownloadPhysical(string fileName)
        {
            var downloadFile = _fileProvider.GetFileInfo(fileName);

            return PhysicalFile(downloadFile.PhysicalPath, MediaTypeNames.Application.Octet, fileName);
        }
    }
}
