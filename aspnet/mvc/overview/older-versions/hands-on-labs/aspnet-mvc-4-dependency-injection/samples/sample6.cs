private static IUnityContainer BuildUnityContainer()
{
	var container = new UnityContainer();

	container.RegisterType<IStoreService, StoreService>();
	container.RegisterType<IController, StoreController>("Store");

	return container;
}