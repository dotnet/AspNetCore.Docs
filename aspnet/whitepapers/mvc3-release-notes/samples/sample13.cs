[ControllerSessionState(SessionStateBehavior.Disabled)]
public class CoolController : Controller {
	public ActionResult Index() {
		object o = Session["Key"]; // Causes an exception.

	}
}