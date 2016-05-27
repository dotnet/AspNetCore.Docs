

ApplicationBuilder Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder`








Syntax
------

.. code-block:: csharp

    public class ApplicationBuilder : IApplicationBuilder








.. dn:class:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ApplicationServices
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.ServerFeatures
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection ServerFeatures
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.ApplicationBuilder(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public ApplicationBuilder(IServiceProvider serviceProvider)
    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.ApplicationBuilder(System.IServiceProvider, System.Object)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        :type server: System.Object
    
        
        .. code-block:: csharp
    
            public ApplicationBuilder(IServiceProvider serviceProvider, object server)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Build()
    
    .. dn:method:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.New()
    
        
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder New()
    
    .. dn:method:: Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder.Use(System.Func<Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Http.RequestDelegate>)
    
        
    
        
        :type middleware: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>, Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    

