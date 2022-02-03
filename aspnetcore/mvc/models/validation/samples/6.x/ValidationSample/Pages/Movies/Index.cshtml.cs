using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValidationSample.Data;
using ValidationSample.Models;

namespace ValidationSample.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly MovieContext _context;

    public IndexModel(MovieContext context)
        => _context = context;

    public List<Movie> Movies { get; set; } = null!;

    public async Task OnGetAsync()
        => Movies = await _context.Movies.ToListAsync();
}
