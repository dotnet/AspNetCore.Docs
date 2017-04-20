namespace MvcMusicStore.Filters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class TraceActionFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			filterContext.HttpContext.Trace.Write("OnActionExecuted");
			filterContext.HttpContext.Trace.Write("Action " + filterContext.ActionDescriptor.ActionName);
			filterContext.HttpContext.Trace.Write("Controller " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			filterContext.HttpContext.Trace.Write("OnActionExecuting");
			filterContext.HttpContext.Trace.Write("Action " + filterContext.ActionDescriptor.ActionName);
			filterContext.HttpContext.Trace.Write("Controller " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
		}
	}
}