using System.ComponentModel.DataAnnotations;

namespace TestingControllersSample.ClientModels
{
    public class NewIdeaModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 1000000)]
        public int SessionId { get; set; }
    }
}
