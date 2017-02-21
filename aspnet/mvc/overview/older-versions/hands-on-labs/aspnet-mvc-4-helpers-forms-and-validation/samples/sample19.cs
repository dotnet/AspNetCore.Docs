namespace MvcMusicStore.Models
{
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;

	public class Album
	{
		[ScaffoldColumn(false)]
		public int AlbumId { get; set; }

		[DisplayName("Genre")]
		public int GenreId { get; set; }

		[DisplayName("Artist")]
		public int ArtistId { get; set; }

		[Required(ErrorMessage = "An Album Title is required")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[StringLength(160, MinimumLength = 2)]
		public string Title { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[DisplayName("Album Art URL")]
		[DataType(DataType.ImageUrl)]
		[StringLength(1024)]
		public string AlbumArtUrl { get; set; }

		public virtual Genre Genre { get; set; }

		public virtual Artist Artist { get; set; }
	}
}