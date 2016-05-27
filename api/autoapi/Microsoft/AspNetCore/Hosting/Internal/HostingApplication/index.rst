

HostingApplication Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.HostingApplication`








Syntax
------

.. code-block:: csharp

    public class HostingApplication : IHttpApplication<HostingApplication.Context>








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.HostingApplication(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Http.IHttpContextFactory)
    
        
    
        
        :type application: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type httpContextFactory: Microsoft.AspNetCore.Http.IHttpContextFactory
    
        
        .. code-block:: csharp
    
            public HostingApplication(RequestDelegate application, ILogger logger, DiagnosticSource diagnosticSource, IHttpContextFactory httpContextFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.CreateContext(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type contextFeatures: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context
    
        
        .. code-block:: csharp
    
            public HostingApplication.Context CreateContext(IFeatureCollection contextFeatures)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.DisposeContext(Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context, System.Exception)
    
        
    
        
        :type context: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context
    
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
            public void DisposeContext(HostingApplication.Context context, Exception exception)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.ProcessRequestAsync(Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context)
    
        
    
        
        :type context: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ProcessRequestAsync(HostingApplication.Context context)
    

