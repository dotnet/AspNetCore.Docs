

UrlActionContext Class
======================



.. contents:: 
   :local:



Summary
-------

Context object to be used for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` generates.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlActionContext`








Syntax
------

.. code-block:: csharp

   public class UrlActionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/UrlActionContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlActionContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlActionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Action
    
        
    
        The name of the action method that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Action { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Controller
    
        
    
        The name of the controller that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Fragment
    
        
    
        The fragment for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Fragment { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Host
    
        
    
        The host name for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Protocol
    
        
    
        The protocol for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` generates
        such as "http" or "https"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlActionContext.Values
    
        
    
        The object that contains the route parameters that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)`
        uses to generate URLs.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Values { get; set; }
    

