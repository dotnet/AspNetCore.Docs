using System.ComponentModel.DataAnnotations;

namespace ValidationSample.Models;

public enum Genre
{
    Classic,
    [Display(Name = "Post Classic")]
    PostClassic,
    Modern,
    [Display(Name = "Post Modern")]
    PostModern,
    Contemporary
}
