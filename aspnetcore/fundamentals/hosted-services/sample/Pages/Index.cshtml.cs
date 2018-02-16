using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BackgroundTasksSample.Services;

namespace BackgroundTasksSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationLifetime _appLifetime;
        private readonly ILogger _logger;

        #region snippet1
        public IndexModel(IBackgroundTaskQueue queue, 
            IApplicationLifetime appLifetime,
            ILogger<IndexModel> logger)
        {
            Queue = queue;
            _appLifetime = appLifetime;
            _logger = logger;
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
                    _logger.LogInformation(
                        $"Queued Background Task {guid} is running. {delayLoop}/3");
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }

                _logger.LogInformation(
                    $"Queued Background Task {guid} is complete. 3/3");
            });

            return RedirectToPage();
        }
        #endregion
    }
}
