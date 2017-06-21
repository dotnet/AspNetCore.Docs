namespace MvcMusicStore.Filters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using MvcMusicStore.Models;

	#region Highlight
	public class CustomActionFilter : ActionFilterAttribute, IActionFilter
	{
		void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
		{
			// TODO: Add your action filter's tasks here

			// Log Action Filter call
			using (MusicStoreEntities storeDb = new MusicStoreEntities())
			{
				ActionLog log = new ActionLog()
				{
					Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
					Action = string.Concat(filterContext.ActionDescriptor.ActionName, " (Logged By: Custom Action Filter)"),
					IP = filterContext.HttpContext.Request.UserHostAddress,
					DateTime = filterContext.HttpContext.Timestamp
				};
				storeDb.ActionLogs.Add(log);
				storeDb.SaveChanges();
				OnActionExecuting(filterContext);
			}
		}
	}
	#endregion
}