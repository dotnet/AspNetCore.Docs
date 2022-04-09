using System.ComponentModel.DataAnnotations;

namespace ViewComponentSample.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; }
    }
}
