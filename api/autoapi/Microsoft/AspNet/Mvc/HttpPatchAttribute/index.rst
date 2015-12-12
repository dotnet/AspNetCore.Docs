

HttpPatchAttribute Class
========================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP PATCH method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpPatchAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpPatchAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpPatchAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpPatchAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpPatchAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPatchAttribute.HttpPatchAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPatchAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpPatchAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpPatchAttribute.HttpPatchAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpPatchAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpPatchAttribute(string template)
    

