namespace System.Web.Mvc {
    public interface IViewPageActivator {
        object Create(ControllerContext controllerContext, Type type);
    }
}