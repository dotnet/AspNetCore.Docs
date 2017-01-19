public class PhotoController : Controller
{
   public ActionResult Gallery()
   {
      return this.File("~/App_Data/Photos.json", "application/json");
   }
}