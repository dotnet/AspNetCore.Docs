

HttpMethodAttribute Class
=========================






Identifies an action that only supports a given set of HTTP methods.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class HttpMethodAttribute : Attribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.HttpMethods
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> HttpMethods
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            int ? IRouteTemplateProvider.Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.Order
    
        
    
        
        Gets the route order. The order determines the order of route execution. Routes with a lower
        order value are tried first. When a route doesn't specify a value, it gets the value of the
        :dn:prop:`Microsoft.AspNetCore.Mvc.RouteAttribute.Order` or a default value of 0 if the :any:`Microsoft.AspNetCore.Mvc.RouteAttribute`
        doesn't define a value on the controller.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Template
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.HttpMethodAttribute(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute` with the given
        set of HTTP methods.
        <param name="httpMethods">The set of supported HTTP methods.</param>
    
        
    
        
        :type httpMethods: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public HttpMethodAttribute(IEnumerable<string> httpMethods)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute.HttpMethodAttribute(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute` with the given
        set of HTTP methods an the given route template.
    
        
    
        
        :param httpMethods: The set of supported methods.
        
        :type httpMethods: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpMethodAttribute(IEnumerable<string> httpMethods, string template)
    

