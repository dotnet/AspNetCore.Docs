using WebMinRouteGroup.Data;

namespace WebMinRouteGroup.Services;

public interface ITodoService
{
    Task<List<Todo>> GetAll();

    Task<List<Todo>> GetIncompleteTodos();

    ValueTask<Todo?> Find(int id);

    Task Add(Todo todo);

    Task Update(Todo todo);

    Task Remove(Todo todo);
}
