public class MoviesController : Controller
{
    private MovieDBContext db = new MovieDBContext();

    //
    // GET: /Movies/

    public ViewResult Index()
    {
        return View(db.Movies.ToList());
    }