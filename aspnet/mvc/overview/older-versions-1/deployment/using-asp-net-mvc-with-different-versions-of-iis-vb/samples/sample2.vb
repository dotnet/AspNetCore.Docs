Public Class MvcApplication

        Inherits System.Web.HttpApplication 

        Shared Sub RegisterRoutes(ByVal routes As RouteCollection)

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}") 

            ' MapRoute takes the following parameters, in order:

            ' (1) Route name

            ' (2) URL with parameters

            ' (3) Parameter defaults

            routes.MapRoute( _

                "Default", _

                "{controller}.mvc/{action}/{id}", _

                New With {.controller = "Home", .action = "Index", .id = ""} _

            ) 

            routes.MapRoute( _

                "Root", _

                "", _

                New With {.controller = "Home", .action = "Index", .id = ""} _

            ) 

        End Sub 

        Sub Application_Start()

            RegisterRoutes(RouteTable.Routes)

        End Sub

    End Class