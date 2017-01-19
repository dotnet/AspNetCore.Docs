Public Class MvcApplication
    Inherits System.Web.HttpApplication
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Blog", _
            "Archive/{entryDate}", _
            New With {.controller = "Archive", .action = "Entry"} _
        )
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = ""} _
        )
    End Sub
    Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class