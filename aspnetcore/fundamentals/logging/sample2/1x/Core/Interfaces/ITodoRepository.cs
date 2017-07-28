using System.Collections.Generic;
using ToDoAPI.Core.Model;

namespace ToDoAPI.Core.Interfaces
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}