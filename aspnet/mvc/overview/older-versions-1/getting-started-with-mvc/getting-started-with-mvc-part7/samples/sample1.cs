using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    [MetadataType(typeof(MovieMetadata))]
    public partial class Movie
    {
        class MovieMetadata
        {
            [Required(ErrorMessage="Titles are required")]
            public string Title { get; set; }

            [Required(ErrorMessage="The Price is required.")]
            [Range(5,100,ErrorMessage ="Movies cost between $5 and $100.")]
            public decimal Price { get; set; }
        }
    }
}