

IApplicationBuilder Interface
=============================






Defines a class that provides the mechanisms to configure an application's request pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationBuilder








.. dn:interface:: Microsoft.AspNetCore.Builder.IApplicationBuilder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Builder.IApplicationBuilder

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Builder.IApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices
    
        
    
        
        Gets or sets the :any:`System.IServiceProvider` that provides access to the application's service container.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            IServiceProvider ApplicationServices
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IApplicationBuilder.Properties
    
        
    
        
        Gets a key/value collection that can be used to share data between middleware.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            IDictionary<string, object> Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IApplicationBuilder.ServerFeatures
    
        
    
        
        Gets the set of HTTP features the application's server provides.
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            IFeatureCollection ServerFeatures
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Builder.IApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.IApplicationBuilder.Build()
    
        
    
        
        Builds the delegate used by this application to process HTTP requests.
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
        :return: The request handling delegate.
    
        
        .. code-block:: csharp
    
            RequestDelegate Build()
    
    .. dn:method:: Microsoft.AspNetCore.Builder.IApplicationBuilder.New()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` that shares the :dn:prop:`Microsoft.AspNetCore.Builder.IApplicationBuilder.Properties` of this
        :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The new :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            IApplicationBuilder New()
    
    .. dn:method:: Microsoft.AspNetCore.Builder.IApplicationBuilder.Use(System.Func<Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Http.RequestDelegate>)
    
        
    
        
        Adds a middleware delegate to the application's request pipeline.
    
        
    
        
        :param middleware: The middleware delgate.
        
        :type middleware: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>, Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    

