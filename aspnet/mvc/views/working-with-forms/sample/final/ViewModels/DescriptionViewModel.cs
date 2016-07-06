using System.ComponentModel.DataAnnotations;

public class DescriptionViewModel
{
    [MinLength(5)]
    [MaxLength(1024)]
    public string Description { get; set; }
}