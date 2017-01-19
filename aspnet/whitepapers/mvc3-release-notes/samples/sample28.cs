namespace System.Web.Mvc {
    using System.Collections.Generic;

    public interface IDependencyResolver {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}