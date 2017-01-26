public interface IDependencyResolver {
	object GetService(Type serviceType);
	IEnumerable<object> GetServices(Type serviceType);
}