

AcceptVerbsAttribute Class
==========================






Specifies what HTTP methods an action supports.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class AcceptVerbsAttribute : Attribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.HttpMethods
    
        
    
        
        Gets the HTTP methods the action supports.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> HttpMethods
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            int ? IRouteTemplateProvider.Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IRouteTemplateProvider.Template
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.Order
    
        
    
        
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
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.Route
    
        
    
        
        The route template. May be null.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Route
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.AcceptVerbsAttribute(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute` class.
    
        
    
        
        :param method: The HTTP method the action supports.
        
        :type method: System.String
    
        
        .. code-block:: csharp
    
            public AcceptVerbsAttribute(string method)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute.AcceptVerbsAttribute(System.String[])
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.AcceptVerbsAttribute` class.
    
        
    
        
        :param methods: The HTTP methods the action supports.
        
        :type methods: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public AcceptVerbsAttribute(params string[] methods)
    

