using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todo_group.Data;

namespace MinApiTests.IntegrationTests.Helpers
{
    public class TestWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TodoGroupDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<TodoGroupDbContext>(options =>
                {
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    options.UseSqlite($"Data Source={Path.Join(path, "todo_group_tests.db")}");
                });
            });

            return base.CreateHost(builder);
        }
    }
}
