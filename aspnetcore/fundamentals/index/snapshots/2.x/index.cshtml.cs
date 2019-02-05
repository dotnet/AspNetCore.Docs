public class IndexModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public IndexModel(RazorPagesMovieContext context)
    {
        _context = context;
    }
    // ...
    public async Task OnGetAsync()
    {
        var movies = from m in _context.Movie
                        select m;
        Movie = await movies.ToListAsync();
    }
}
