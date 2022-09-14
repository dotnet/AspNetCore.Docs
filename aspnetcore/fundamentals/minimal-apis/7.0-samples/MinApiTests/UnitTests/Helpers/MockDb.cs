using Microsoft.EntityFrameworkCore;
using WebMinRouteGroup.Data;

namespace MinApiTests.UnitTests.Helpers;

public class MockDb : IDbContextFactory<TodoGroupDbContext>
{
    public TodoGroupDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TodoGroupDbContext>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

        return new TodoGroupDbContext(options);
    }
}
