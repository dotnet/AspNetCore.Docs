using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BackgroundTasksSample.Services;
using System;
using Microsoft.AspNetCore.Hosting;

namespace BackgroundTasksSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationLifetime _appLifetime;

        #region snippet1
        public IndexModel(IBackgroundTaskQueue queue, IApplicationLifetime appLifetime)
        {
            Queue = queue;
            _appLifetime = appLifetime;
        }

        public IBackgroundTaskQueue Queue { get; }
        #endregion

        public void OnGet()
        {
        }

        #region snippet2
        public IActionResult OnPostAddTask()
        {
            Queue.QueueBackgroundWorkItem(async token =>
            {
                var guid = Guid.NewGuid().ToString();

                for (int delayLoop = 0; delayLoop < 3; delayLoop++)
                {
                    Console.WriteLine(
                        $"{DateTime.UtcNow} - Queued Background Task {guid} is running. " +
                        $"{delayLoop}/3");
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }

                Console.WriteLine(
                    $"{DateTime.UtcNow} - Queued Background Task {guid} is complete. 3/3");
            });

            return RedirectToPage();
        }
        #endregion
    }
}
