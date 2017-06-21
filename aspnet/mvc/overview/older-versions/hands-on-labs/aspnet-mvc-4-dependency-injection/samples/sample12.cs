namespace MvcMusicStore.Factories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using Microsoft.Practices.Unity;

	public class CustomViewPageActivator : IViewPageActivator
	{
		private IUnityContainer container;

		public CustomViewPageActivator(IUnityContainer container)
		{
			this.container = container;
		}

		public object Create(ControllerContext controllerContext, Type type)
		{
			return this.container.Resolve(type);
		}
	}
}