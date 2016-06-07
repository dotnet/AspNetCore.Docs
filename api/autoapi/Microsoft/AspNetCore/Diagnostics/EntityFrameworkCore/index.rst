

Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore Namespace
==============================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Diagnostics/EntityFrameworkCore/DataStoreErrorLogger/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Diagnostics/EntityFrameworkCore/DataStoreErrorLogger/DataStoreErrorLog/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Diagnostics/EntityFrameworkCore/DataStoreErrorLoggerProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Diagnostics/EntityFrameworkCore/DatabaseErrorPageMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Diagnostics/EntityFrameworkCore/MigrationsEndPointMiddleware/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore


    .. rubric:: Classes


    class :dn:cls:`DataStoreErrorLogger`
        .. object: type=class name=Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger

        


    class :dn:cls:`DataStoreErrorLog`
        .. object: type=class name=Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog

        


    class :dn:cls:`DataStoreErrorLoggerProvider`
        .. object: type=class name=Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider

        


    class :dn:cls:`DatabaseErrorPageMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware

        
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.


    class :dn:cls:`MigrationsEndPointMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware

        
        Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in the supplied options.


