

IApplicationBuilder Interface
=============================



.. contents:: 
   :local:



Summary
-------

Defines a class that provides the mechanisms to configure an application's request pipeline.











Syntax
------

.. code-block:: csharp

   public interface IApplicationBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs>`_





.. dn:interface:: Microsoft.AspNet.Builder.IApplicationBuilder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Builder.IApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.IApplicationBuilder.Build()
    
        
    
        Builds the delegate used by this application to process HTTP requests.
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
        :return: The request handling delegate.
    
        
        .. code-block:: csharp
    
           RequestDelegate Build()
    
    .. dn:method:: Microsoft.AspNet.Builder.IApplicationBuilder.New()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Builder.IApplicationBuilder` that shares the :dn:prop:`Microsoft.AspNet.Builder.IApplicationBuilder.Properties` of this 
        :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\.
    
        
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The new <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" />.
    
        
        .. code-block:: csharp
    
           IApplicationBuilder New()
    
    .. dn:method:: Microsoft.AspNet.Builder.IApplicationBuilder.Use(System.Func<Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Builder.RequestDelegate>)
    
        
    
        Adds a middleware delegate to the application's request pipeline.
    
        
        
        
        :param middleware: The middleware delgate.
        
        :type middleware: System.Func{Microsoft.AspNet.Builder.RequestDelegate,Microsoft.AspNet.Builder.RequestDelegate}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" />.
    
        
        .. code-block:: csharp
    
           IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Builder.IApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Builder.IApplicationBuilder.ApplicationServices
    
        
    
        Gets or sets the :any:`System.IServiceProvider` that provides access to the application's service container.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Builder.IApplicationBuilder.Properties
    
        
    
        Gets a key/value collection that can be used to share data between middleware.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           IDictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Builder.IApplicationBuilder.ServerFeatures
    
        
    
        Gets the set of HTTP features the application's server provides.
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           IFeatureCollection ServerFeatures { get; }
    

