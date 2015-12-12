

HttpHeadAttribute Class
=======================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP HEAD method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpHeadAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpHeadAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpHeadAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpHeadAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpHeadAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpHeadAttribute.HttpHeadAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpHeadAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpHeadAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpHeadAttribute.HttpHeadAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpHeadAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpHeadAttribute(string template)
    

