using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMovie.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int MovieId { get; set; }


        [Required]
        [StringLength(25)]
        public string ReviewerName { get; set; }

        [Required]        
        [Range(1, 5)]
        public int Level { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

    }
}