using System;

namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int Priority { get; set; }
    }
}