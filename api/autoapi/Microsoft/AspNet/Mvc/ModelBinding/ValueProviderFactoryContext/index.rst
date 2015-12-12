

ValueProviderFactoryContext Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext`








Syntax
------

.. code-block:: csharp

   public class ValueProviderFactoryContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ValueProviderFactoryContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext.ValueProviderFactoryContext(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public ValueProviderFactoryContext(HttpContext httpContext, IDictionary<string, object> routeValues)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext.RouteValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValues { get; }
    

