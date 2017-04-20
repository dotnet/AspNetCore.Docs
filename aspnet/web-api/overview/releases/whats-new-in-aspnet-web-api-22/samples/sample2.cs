public class BaseController : ApiController
{
	[Route("{id:int}")]
	public string Get(int id)
	{
		return "Success:" + id;
	}
}
[RoutePrefix("api/values")]
public class ValuesController : BaseController
{
}
	   
config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());
public class CustomDirectRouteProvider : DefaultDirectRouteProvider
{
	protected override IReadOnlyList<IDirectRouteFactory> 
	GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
	{
		return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>
		(inherit: true);
	}
}