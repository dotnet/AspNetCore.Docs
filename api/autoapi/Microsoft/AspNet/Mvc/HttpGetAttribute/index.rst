

HttpGetAttribute Class
======================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP GET method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpGetAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpGetAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/HttpGetAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpGetAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpGetAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpGetAttribute.HttpGetAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpGetAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpGetAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpGetAttribute.HttpGetAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpGetAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpGetAttribute(string template)
    

