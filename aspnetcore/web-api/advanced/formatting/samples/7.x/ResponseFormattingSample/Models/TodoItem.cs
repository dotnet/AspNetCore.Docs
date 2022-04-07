namespace ResponseFormattingSample.Models;

public class TodoItem
{
    public TodoItem() { }

    public TodoItem(long id, string name, bool isComplete = false) =>
        (Id, Name, IsComplete) = (id, name, isComplete);

    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsComplete { get; set; } = false;
}
