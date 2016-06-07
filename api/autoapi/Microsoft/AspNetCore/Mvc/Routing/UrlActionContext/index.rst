

UrlActionContext Class
======================






Context object to be used for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` generates.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.UrlActionContext`








Syntax
------

.. code-block:: csharp

    public class UrlActionContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Action
    
        
    
        
        The name of the action method that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Action
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Controller
    
        
    
        
        The name of the controller that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Controller
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Fragment
    
        
    
        
        The fragment for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Fragment
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Host
    
        
    
        
        The host name for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Host
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Protocol
    
        
    
        
        The protocol for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` generates
        such as "http" or "https"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protocol
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext.Values
    
        
    
        
        The object that contains the route parameters that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)`
        uses to generate URLs.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Values
            {
                get;
                set;
            }
    

