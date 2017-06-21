private static IUnityContainer BuildUnityContainer()
{
	var container = new UnityContainer();

	container.RegisterType<IStoreService, StoreService>();
	container.RegisterType<IController, StoreController>("Store");

	container.RegisterInstance<IMessageService>(new MessageService
	{
		Message = "You are welcome to our Web Camps Training Kit!",
		ImageUrl = "/Content/Images/webcamps.png"
	});

	container.RegisterType<IViewPageActivator, CustomViewPageActivator>(new InjectionConstructor(container));

	return container;
}