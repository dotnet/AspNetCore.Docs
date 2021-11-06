namespace WebMvcEF.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
