public class DinnersController : Controller {

    //
    // HTTP-GET: /Dinners/

    public void Index() {
        Response.Write("<h1>Coming Soon: Dinners</h1>");
    }

    //
    // HTTP-GET: /Dinners/Details/2

    public void Details(int id) {
        Response.Write("<h1>Details DinnerID: " + id + "</h1>");
    }
}