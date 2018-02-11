using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BackgroundTasksSample.Services;
using System;

namespace BackgroundTasksSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        public IndexModel(IBackgroundTaskQueue queue)
        {
            Queue = queue ?? throw new ArgumentNullException(nameof(queue));
        }

        public IBackgroundTaskQueue Queue { get; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddTask()
        {
            Queue.QueueBackgroundWorkItem(async token =>
            {
                var guid = Guid.NewGuid().ToString();

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(
                        $"{DateTime.UtcNow} - Queued Background Task {guid} is running. {i}/3");
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }

                Console.WriteLine(
                    $"{DateTime.UtcNow} - Queued Background Task {guid} is complete. 3/3");
            });

            return RedirectToPage();
        }
    }
    #endregion
}
