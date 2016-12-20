public class Movie
{
   public int ID { get; set; }
   [Required,StringLength(60, MinimumLength = 3)]
   public string Title { get; set; }
   [Display(Name = "Release Date"),DataType(DataType.Date)]
   public DateTime ReleaseDate { get; set; }
   [Required]
   public string Genre { get; set; }
   [Range(1, 100),DataType(DataType.Currency)]
   public decimal Price { get; set; }
   [Required,StringLength(5)]
   public string Rating { get; set; }
}