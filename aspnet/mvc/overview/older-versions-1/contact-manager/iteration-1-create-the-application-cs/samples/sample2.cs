public class HomeController : Controller
{

    private ContactManagerDBEntities _entities = new ContactManagerDBEntities();

    //
    // GET: /Home/

    public ActionResult Index()
    {
        return View(_entities.ContactSet.ToList());
    }
…