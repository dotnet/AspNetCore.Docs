namespace ResponseFormattingSample.Models;

public class TodoItemStore
{
    private readonly List<TodoItem> _todoItems = new()
    {
        new TodoItem(1, "Todo #1"),
        new TodoItem(2, "Todo #2"),
        new TodoItem(3, "Todo #3"),
        new TodoItem(4, "Todo #4"),
        new TodoItem(5, "Todo #5"),
    };

    public IEnumerable<TodoItem> GetList()
        => _todoItems.ToList();

    public TodoItem? GetById(long id)
        => _todoItems.Find(x => x.Id == id);
}
