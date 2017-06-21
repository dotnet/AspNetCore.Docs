[ControllerSessionState(SessionStateBehavior.ReadOnly)]
public class CoolController : Controller {
	public ActionResult Index() {
	Session["Key"] = "value"; // Value is not available in
	the next request
	}
}