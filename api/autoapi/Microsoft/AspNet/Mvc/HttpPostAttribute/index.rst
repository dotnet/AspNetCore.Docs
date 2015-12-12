

HttpPostAttribute Class
=======================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP POST method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpPostAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpPostAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpPostAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpPostAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpPostAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPostAttribute.HttpPostAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPostAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpPostAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPostAttribute.HttpPostAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPostAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpPostAttribute(string template)
    

