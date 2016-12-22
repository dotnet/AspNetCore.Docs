Sub Application_Start()
        System.Data.Entity.Database.SetInitializer(Of MovieDBContext)(New MvcMovie.Models.MovieInitializer())
       
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
    End Sub