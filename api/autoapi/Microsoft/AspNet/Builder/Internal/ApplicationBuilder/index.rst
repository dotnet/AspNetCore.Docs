

ApplicationBuilder Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.Internal.ApplicationBuilder`








Syntax
------

.. code-block:: csharp

   public class ApplicationBuilder : IApplicationBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/ApplicationBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.ApplicationBuilder(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public ApplicationBuilder(IServiceProvider serviceProvider)
    
    .. dn:constructor:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.ApplicationBuilder(System.IServiceProvider, System.Object)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        
        
        :type server: System.Object
    
        
        .. code-block:: csharp
    
           public ApplicationBuilder(IServiceProvider serviceProvider, object server)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public RequestDelegate Build()
    
    .. dn:method:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.New()
    
        
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public IApplicationBuilder New()
    
    .. dn:method:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.Use(System.Func<Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Builder.RequestDelegate>)
    
        
        
        
        :type middleware: System.Func{Microsoft.AspNet.Builder.RequestDelegate,Microsoft.AspNet.Builder.RequestDelegate}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Builder.Internal.ApplicationBuilder.ServerFeatures
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public IFeatureCollection ServerFeatures { get; }
    

