using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models {
    public class TodoItem {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public string Secret { get; set; }
    }
}