[InheritedRoute("attributerouting/{controller}/{action=Index}/{id?}")]
public abstract class BaseController : Controller
{
}
public class BlogController : BaseController
{
    public string Index()
    {
        return "Hello from blog!";
    }
}
public class StoreController : BaseController
{
    public string Index()
    {
        return "Hello from store!";
    }
}
[AttributeUsage(AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
public class InheritedRouteAttribute : Attribute, IDirectRouteFactory
{
    public InheritedRouteAttribute(string template)
    {
        Template=template;
    }
    public string Name { get; set; }
    public int Order { get; set; }
    public string Template { get; private set; }
    public new RouteEntry CreateRoute(DirectRouteFactoryContext context)
    {
        // context.Actions will always contain at least one action - and all of the 
        // actions will always belong to the same controller.
        var controllerDescriptor=context.Actions.First().ControllerDescriptor;
        var template=Template.Replace("{controller}", 
            controllerDescriptor.ControllerName);
        IDirectRouteBuilder builder=context.CreateBuilder(template);
        builder.Name=Name;
        builder.Order=Order;
        return builder.Build();
    }
}
// Custom direct route provider which looks for route attributes of type 
// InheritedRouteAttribute and also supports attribute route inheritance.
public class InheritedDirectRouteProvider : DefaultDirectRouteProvider
{
    protected override IReadOnlyList<IDirectRouteFactory> 
         GetControllerRouteFactories(ControllerDescriptor controllerDescriptor)
    {
        return controllerDescriptor
            .GetCustomAttributes(typeof(InheritedRouteAttribute), inherit: true)
            .Cast<IDirectRouteFactory>()
            .ToArray();
    }
}