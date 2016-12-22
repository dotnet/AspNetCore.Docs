Public Class LogActionFilter
     Inherits ActionFilterAttribute

     Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
          Log("OnActionExecuting", filterContext.RouteData)

     End Sub

     Public Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)
          Log("OnActionExecuted", filterContext.RouteData)
     End Sub

     Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
          Log("OnResultExecuting", filterContext.RouteData)
     End Sub

     Public Overrides Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext)
          Log("OnResultExecuted", filterContext.RouteData)
     End Sub

     Private Sub Log(ByVal methodName As String, ByVal routeData As RouteData)
          Dim controllerName = routeData.Values("controller")
          Dim actionName = routeData.Values("action")
          Dim message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName)
          Debug.WriteLine(message, "Action Filter Log")
     End Sub

End Class