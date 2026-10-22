using Microsoft.EntityFrameworkCore;

public class RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) : DbContext(options)
{
    public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;
}
