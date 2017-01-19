protected override void OnActionExecuting(ActionExecutingContext filterContext)
{
    filterContext.HttpContext.Response.Cache.SetNoTransforms();
}