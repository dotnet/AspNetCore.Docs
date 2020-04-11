using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models {
    public class TodoItemDTO {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}