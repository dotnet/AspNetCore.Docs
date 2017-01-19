namespace MvcMusicStore.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int      AlbumId    { get; set; }
        [DisplayName("Genre")]
        public int      GenreId    { get; set; }
        [DisplayName("Artist")]
        public int      ArtistId   { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string   Title      { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price       { get; set; }
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre  Genre    { get; set; }
        public virtual Artist Artist   { get; set; }
    }
}