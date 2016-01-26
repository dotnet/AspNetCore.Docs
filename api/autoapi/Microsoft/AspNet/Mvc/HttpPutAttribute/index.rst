

HttpPutAttribute Class
======================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP PUT method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpPutAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpPutAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpPutAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpPutAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpPutAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPutAttribute.HttpPutAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPutAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpPutAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPutAttribute.HttpPutAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPutAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpPutAttribute(string template)
    

