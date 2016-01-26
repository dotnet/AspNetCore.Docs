

Microsoft.AspNet.Diagnostics.Entity Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/DataStoreErrorLogger/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/DataStoreErrorLogger/DataStoreErrorLog/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/DataStoreErrorLoggerProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/DatabaseErrorPageMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/DatabaseErrorPageOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/MigrationsEndPointMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Diagnostics/Entity/MigrationsEndPointOptions/index
   
   











.. dn:namespace:: Microsoft.AspNet.Diagnostics.Entity


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger`
        


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog`
        


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider`
        


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware`
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions`
        Options for the :any:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware`\.


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware`
        Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in the supplied options.


    class :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions`
        Options for the :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware`\.


