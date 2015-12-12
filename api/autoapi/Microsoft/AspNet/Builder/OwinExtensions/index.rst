

OwinExtensions Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.OwinExtensions`








Syntax
------

.. code-block:: csharp

   public class OwinExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/OwinExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.OwinExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.OwinExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>)
    
        
        
        
        :type app: System.Action{System.Func{System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task},System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}}}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app)
    
    .. dn:method:: Microsoft.AspNet.Builder.OwinExtensions.UseBuilder(System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
        
        
        :type app: System.Action{System.Func{System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task},System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}}}
        
        
        :type pipeline: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: System.Action{System.Func{System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task},System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}}}
    
        
        .. code-block:: csharp
    
           public static Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> UseBuilder(Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> app, Action<IApplicationBuilder> pipeline)
    
    .. dn:method:: Microsoft.AspNet.Builder.OwinExtensions.UseOwin(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: System.Action{System.Func{System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task},System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}}}
    
        
        .. code-block:: csharp
    
           public static Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>> UseOwin(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.OwinExtensions.UseOwin(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<System.Action<System.Func<System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>>>>)
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type pipeline: System.Action{System.Action{System.Func{System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task},System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}}}}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseOwin(IApplicationBuilder builder, Action<Action<Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>>> pipeline)
    

