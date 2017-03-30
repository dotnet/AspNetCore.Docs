private static IUnityContainer BuildUnityContainer()
{
	var container = new UnityContainer();

	//...

	container.RegisterInstance<IFilterProvider>("FilterProvider", new FilterProvider(container));
	container.RegisterInstance<IActionFilter>("LogActionFilter", new TraceActionFilter());

	return container;
}