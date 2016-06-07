

OwinExtensions Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Owin

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.OwinExtensions`








Syntax
------

.. code-block:: csharp

    public class OwinExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.OwinExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.OwinExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.OwinExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>)
    
        
    
        
        :type app: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        :type app: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        :type pipeline: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        .. code-block:: csharp
    
            public static Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app, Action<IApplicationBuilder> pipeline)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>, System.IServiceProvider)
    
        
    
        
        :type app: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        :type pipeline: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        .. code-block:: csharp
    
            public static Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app, Action<IApplicationBuilder> pipeline, IServiceProvider serviceProvider)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>, System.IServiceProvider)
    
        
    
        
        :type app: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app, IServiceProvider serviceProvider)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseOwin(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type builder: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}
    
        
        .. code-block:: csharp
    
            public static Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> UseOwin(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OwinExtensions.UseOwin(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action<System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>>)
    
        
    
        
        :type builder: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type pipeline: System.Action<System.Action`1>{System.Action<System.Action`1>{System.Func<System.Func`2>{System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}}}}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseOwin(IApplicationBuilder builder, Action<Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>>> pipeline)
    

