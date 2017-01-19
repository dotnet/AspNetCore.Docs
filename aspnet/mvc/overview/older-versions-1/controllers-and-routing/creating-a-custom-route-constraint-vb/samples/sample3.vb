Public Class MvcApplication
    Inherits System.Web.HttpApplication
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.MapRoute( _
            "Admin", _
            "Admin/{action}", _
            New With {.controller = "Admin"}, _
            New With {.isLocal = New LocalhostConstraint()} _
        )
        'routes.MapRoute( _
        '    "Default", _
        '    "{controller}/{action}/{id}", _
        '    New With {.controller = "Home", .action = "Index", .id = ""} _
        ')
    End Sub
    Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class