Injecting a Service Into a View
===============================

ASP.NET MVC 6 now supports injection into a view from a class. For this example, we'll create a simple class that exposes the total *todo* count, completed count and average priority. 

1. Examine the *Services\\StatisticsService.cs* class.

  .. code-block:: c#
    :linenos:
    
    using System.Linq;
    using System.Threading.Tasks;
    using TodoList.Models;

    namespace TodoList.Services
    {
      public class StatisticsService
      {
        private readonly ApplicationDbContext db;

        public StatisticsService(ApplicationDbContext context)
        {
          db = context;
        }

        public async Task<int> GetCount()
        {
          return await Task.FromResult(db.TodoItems.Count());
        }

        public async Task<int> GetCompletedCount()
        {
          return await Task.FromResult(
            db.TodoItems.Count(x => x.IsDone == true));
        }

        public async Task<double> GetAveragePriority()
        {
          if (db.TodoItems.Count() == 0)
          {
            return 0.0;
          }

          return await Task.FromResult(
            db.TodoItems.Average(x =>x.Priority));
        }
      }
    }

2. Update the *Index* view to inject the *todo* statistical data. Add the ``inject`` statement to the top of the file:

.. code-block:: html 
  :linenos:
  
  @inject TodoList.Services.StatisticsService Statistics

3. Add markup calling the StatisticsService to the end of the file:

  .. code-block:: html
    :linenos:
    :emphasize-lines: 6-11
    
    @* Markup removed for brevity *@
    <div>@Html.ActionLink("Create New Todo", "Create", "Todo") </div>
    </div>
      <div class="col-md-4">
        @await Component.InvokeAsync("PriorityList", 4, true)
        <h3>Stats</h3>
        <ul>
          <li>Items: @await Statistics.GetCount()</li>
          <li>Completed:@await Statistics.GetCompletedCount()</li>
          <li>Average Priority:@await Statistics.GetAveragePriority()</li>
        </ul>
      </div>
    </div>

4. Register the ``StatisticsService`` class in the *Startup.cs* file: 

  .. code-block:: c#
    :linenos:
    :emphasize-lines: 8
    
    public void ConfigureServices(IServiceCollection services)
    {
      // Code removed for brevity.
      // Add MVC services to the services container.
      services.AddMvc();
      services.AddTransient<TodoList.Services.StatisticsService>();
    }

The statistics are displayed:
 
.. image:: dependency-injection/_static/stat.png
