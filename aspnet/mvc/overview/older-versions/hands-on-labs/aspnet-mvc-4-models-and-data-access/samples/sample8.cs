namespace MvcMusicStore.Models
{
	using System.Collections.Generic;

	public class Genre
	{
	  public int GenreId { get; set; }

	  public string Name { get; set; }

	  public string Description { get; set; }

	  public List<Album> Albums { get; set; }
	}
}