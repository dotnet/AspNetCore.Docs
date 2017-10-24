using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChangeTokenSample.Data;
using ChangeTokenSample.Enums;

namespace ChangeTokenSample.Pages
{
    public class FileWatchingModel : PageModel
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileContents { get; private set; }
        public string CurrentFileState { get; private set; }

        #region snippet1
        public void OnGet()
        {
            FileName = MonitorFile.FileName;
            FilePath = MonitorFile.FilePath;
            FileContents = System.IO.File.ReadAllText(MonitorFile.FilePath);

            if (MonitorFile.CurrentFileState == FileState.Updated)
            {
                CurrentFileState = "Updated";
                ViewData["UpdatedStyle"] = "success";
            }
            else
            {
                CurrentFileState = "Not Updated";
                ViewData["UpdatedStyle"] = "danger";
            }
        }
        #endregion

        public IActionResult OnPostResetFileState()
        {
            MonitorFile.CurrentFileState = FileState.NotUpdated;

            return RedirectToPage();
        }
    }
}
