

HttpDeleteAttribute Class
=========================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports the HTTP DELETE method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpDeleteAttribute`








Syntax
------

.. code-block:: csharp

   public class HttpDeleteAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/HttpDeleteAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpDeleteAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpDeleteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpDeleteAttribute.HttpDeleteAttribute()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpDeleteAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public HttpDeleteAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpDeleteAttribute.HttpDeleteAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpDeleteAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpDeleteAttribute(string template)
    

