using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BackgroundTasksSample.Data;
using BackgroundTasksSample.Services;

namespace BackgroundTasksSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public IndexModel(AppDbContext db, IBackgroundTaskQueue queue, 
            ILogger<IndexModel> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _db = db;
            _logger = logger;
            Queue = queue;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IBackgroundTaskQueue Queue { get; }
    #endregion
        public IReadOnlyList<Message> Messages { get; private set; }

        public async Task OnGetAsync()
        {
            Messages = await _db.Messages.AsNoTracking().ToListAsync();
        }

        #region snippet2
        public IActionResult OnPostAddTaskAsync()
        {
            Queue.QueueBackgroundWorkItem(async token =>
            {
                var guid = Guid.NewGuid().ToString();

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();

                    for (int delayLoop = 1; delayLoop < 4; delayLoop++)
                    {
                        try
                        {
                            db.Messages.Add(
                                new Message() 
                                { 
                                    Text = $"Queued Background Task {guid} has " +
                                        $"written a step. {delayLoop}/3"
                                });
                            await db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, 
                                "An error occurred writing to the " +
                                "database. Error: {Message}", ex.Message);
                        }

                        await Task.Delay(TimeSpan.FromSeconds(5), token);
                    }
                }

                _logger.LogInformation(
                    "Queued Background Task {Guid} is complete. 3/3", guid);
            });

            return RedirectToPage();
        }
        #endregion
    }
}
