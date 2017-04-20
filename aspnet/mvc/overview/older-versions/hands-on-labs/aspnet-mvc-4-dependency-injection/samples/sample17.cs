public static void Initialise()
{
	var container = BuildUnityContainer();

	DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

	IDependencyResolver resolver = DependencyResolver.Current;

	IDependencyResolver newResolver = new Factories.UnityDependencyResolver(container, resolver);

	DependencyResolver.SetResolver(newResolver);
}